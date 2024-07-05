#region Import Namespaces
using HallBooking.Areas.SEC_User.Models;
using HallBooking.BAL;
using HallBooking.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
#endregion
namespace HallBooking.Areas.SEC_User.Controllers
{
    #region Route
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    #endregion
    public class SEC_User : Controller

    {
        #region IHttpContextAccessor
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region DAL Object
        MST_User_DALBase dalMST_User = new MST_User_DALBase();
        #endregion

        #region Login
        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }


        [HttpPost]
        public IActionResult Login(SEC_UserLoginModel userLoginModel)
        {
            string? ErrorMsg = null;
            if (string.IsNullOrEmpty(userLoginModel.UserName))
            {
                ErrorMsg += "User Name is Required";
            }
            if (string.IsNullOrEmpty(userLoginModel.Password))
            {
                ErrorMsg += "<br/>Password is Required";
            }


            if (ErrorMsg == null)
            {
                var connectionstr = "Data Source=DESKTOP-DVN2N38\\SQLEXPRESS;Initial Catalog=HallBooking;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionstr);

                conn.Open();
                SqlCommand objCmd = conn.CreateCommand();
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_SEC_User_Login";
                objCmd.Parameters.AddWithValue("@UserName", userLoginModel.UserName);
                objCmd.Parameters.AddWithValue("@Password", userLoginModel.Password);
                SqlDataReader objSDR = objCmd.ExecuteReader();
                DataTable dtLogin = new DataTable();
                // Check if Data Reader has Rows or not
                // if row(s) does not exists that means either username or password or both are invalid.
                if (!objSDR.HasRows)
                {
                    TempData["ErrorMessage"] = "Invalid User Name or Password";
                    return RedirectToAction("Login", "SEC_User");
                }
                else
                {
                    dtLogin.Load(objSDR);
                    //Load the retrived data to session through HttpContext.
                    foreach (DataRow dr in dtLogin.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        HttpContext.Session.SetString("IsAdmin", dr["IsAdmin"].ToString());

                    }
                    if (CommonVariables.IsAdmin() == false)
                    {
                        return RedirectToAction("UserIndex", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //return RedirectToAction("HallSelectAll", "MST_Hall", new { area = "MST_Hall" });

                }
            }
            else
            {
                TempData["ErrorMessage"] = ErrorMsg;
                return RedirectToAction("Login", "SEC_User");
            }
        }
        #endregion

        #region Logout


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "SEC_User");
        }
        #endregion

        #region SelectByPK
        public IActionResult Add()
        {
            int? userId = Convert.ToInt32((HttpContext.Session.GetString("UserID").ToString()));
            #region Record Select by PK

            DataTable dt = dalMST_User.PR_API_MST_USER_SELECTBYPK(userId);
            if (dt.Rows.Count > 0)
            {
                SEC_UserLoginModel model = new SEC_UserLoginModel();
                foreach (DataRow dr in dt.Rows)
                {
                    model.UserID = Convert.ToInt32(dr["UserID"]);
                    model.UserName = dr["UserName"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.FirstName = dr["FirstName"].ToString();
                    model.LastName = dr["LastName"].ToString();
                    model.Email = dr["Email"].ToString();
                    model.PhoneNumber = dr["PhoneNumber"].ToString();

                }
                return View("Profile", model);
            }

            #endregion
            return View("Profile");

        }
        #endregion

        #region Save(Insert/Update)
        [HttpPost]
        public IActionResult Save(SEC_UserLoginModel modelUserModel)
        {


            if (ModelState.IsValid)
            {
                if (modelUserModel.UserID == null)
                {
                    if (Convert.ToBoolean(dalMST_User.PR_API_MST_USER_INSERT(modelUserModel)))
                    {
                        TempData["successMessage"] = "Registered Successfully";
                    }
                    return RedirectToAction("Login");
                }
                else
                {
                    if (Convert.ToBoolean(dalMST_User.PR_API_MST_USER_UPDATE(modelUserModel)))
                    {
                        TempData["successMessage"] = "Record Updated Successfully";
                    }

                    return RedirectToAction("Profile");
                }

            }

            return View("Register");
        }
        #endregion

        #region RegisterView
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region ProfileView
        public IActionResult Profile()
        {
            return View();
        }
        #endregion

        public async Task LoginG()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            return RedirectToAction("Index", "Home");
        }

    }



}
