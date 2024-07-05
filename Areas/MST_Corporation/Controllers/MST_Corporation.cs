#region Import Namespaces
using HallBooking.Areas.MST_Corporation.Models;
using HallBooking.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
#endregion

namespace HallBooking.Areas.MST_Corporation.Controllers
{
    #region Route
    [Area("MST_Corporation")]
    [Route("MST_Corporation/[Controller]/[Action]")]
    #endregion
    public class MST_Corporation : Controller
    {
        MST_Corporation_DALBase dalMST_CORPORATION = new MST_Corporation_DALBase();
        #region CorporationSelectAll
        public IActionResult CorporationSelectAll()
        {
            DataTable dt = dalMST_CORPORATION.PR_API_MST_CORPORATION_SELECTALL();
            return View("CorporationSelectAll", dt);
        }
        #endregion

        #region CorporationDelete
        public IActionResult Delete(int id)
        {
            int ax = dalMST_CORPORATION.PR_API_MST_CORPORATION_DELETE(id);
            if (ax > 0)
                return RedirectToAction("CorporationSelectAll");
            return View("CorporationSelectAll");
        }
        #endregion

        #region CorporationAddEditView
        public IActionResult CorporationAddEdit()
        {
            return View();
        }
        #endregion


        #region Add/Edit
        public IActionResult Add(int? MCID)
        {
            #region Record Select by PK
            if (MCID != null)
            {
                DataTable dt = dalMST_CORPORATION.PR_API_MST_CORPORATION_SELECTBYPK(MCID);
                if (dt.Rows.Count > 0)
                {
                    CorporationModel model = new CorporationModel();
                    foreach (DataRow dr in dt.Rows)
                    {

                        model.MCID = Convert.ToInt32(dr["MCID"]);
                        model.MCName = dr["MCName"].ToString();
                        model.MCCity = dr["MCCity"].ToString();
                        model.MCPinCode = Convert.ToInt32(dr["MCPinCode"]);
                        model.UserID = Convert.ToInt32(dr["UserID"]);
                        model.MCLogo = dr["MCLogo"].ToString();
                        model.MCEmail = dr["MCEmail"].ToString();
                        model.ContactPerson = dr["ContactPerson"].ToString();
                        model.ContactNo = dr["ContactNo"].ToString();
                        model.MCAddress = dr["MCAddress"].ToString();

                    }
                    return View("CorporationAddEdit", model);
                }
            }
            #endregion
            return View("CorporationAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(CorporationModel modelCorporationModel)
        {
            if (modelCorporationModel.File != null)
            {
                //determine uploaded GroundImage type (i.e. .docx, .pdf, .jpg, etc.) and create folder according to file type
                string filePath = System.IO.Path.GetExtension(modelCorporationModel.File.FileName);

                //Define the physical directory path to store the GroundImage to particular location and append our GroundImage path to it.(change your project physical path as required)
                string directoryPath = @"C:\Users\DELL\source\repos\HallBooking\wwwroot\" + filePath;

                //check if directory exists on our defined directory path ?
                //if not then create our directory path
                if (!Directory.Exists(directoryPath))
                {
                    //create directory at specified path
                    Directory.CreateDirectory(directoryPath);
                }
                //upload GroundImage to root directory of our project
                string folderPath = Path.Combine("wwwroot/" + filePath + "/", modelCorporationModel.File.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    modelCorporationModel.File.CopyTo(fs);
                }
                // Store GroundImage path in the list
                modelCorporationModel.MCLogo = "/" + filePath + "/" + modelCorporationModel.File.FileName;
            }
            if (ModelState.IsValid)
            {
                if (modelCorporationModel.MCID == null)
                {
                    if (Convert.ToBoolean(dalMST_CORPORATION.PR_API_MST_CORPORATION_INSERT(modelCorporationModel)))
                    {
                        TempData["successMessage"] = "Record Inserted Successfully";
                    }
                    return RedirectToAction("CorporationSelectAll");
                }
                else
                {
                    if (Convert.ToBoolean(dalMST_CORPORATION.PR_API_MST_CORPORATION_UPDATE(modelCorporationModel)))
                    {
                        TempData["successMessage"] = "Record Updated Successfully";
                    }

                    return RedirectToAction("CorporationSelectAll");
                }

            }
            TempData["errorMessage"] = "Some error has occurred";
            return RedirectToAction("CorporationSelectAll");
        }
        #endregion

        #region CorporationSearch
        public IActionResult CorporationSearch(string MCName)
        {
            DataTable dt = dalMST_CORPORATION.PR_MST_Corporation_SEARCH(MCName);
            return View("CorporationSelectAll", dt);

        }
        #endregion
    }
}
