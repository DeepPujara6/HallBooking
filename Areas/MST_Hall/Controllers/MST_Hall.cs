#region Import Namespaces
using ClosedXML.Excel;
using HallBooking.Areas.MST_Hall.Models;
using HallBooking.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
#endregion
namespace HallBooking.Areas.MST_Hall.Controllers
{
    #region Route
    [Area("MST_Hall")]
    [Route("MST_Hall/[Controller]/[Action]")]
    #endregion
    public class MST_Hall : Controller
    {
        #region DAL Object
        MST_Hall_DALBase dalMST_HALL = new MST_Hall_DALBase();
        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region HallSelectAll
        public IActionResult HallSelectAll()
        {
            DataTable dt = dalMST_HALL.PR_API_MST_HALL_SELECTALL();
            return View("HallSelectAll", dt);
        }
        #endregion

        #region HallDelete
        public IActionResult Delete(int id)
        {
            int ax = dalMST_HALL.PR_API_MST_HALL_DELETE(id);
            if (ax > 0)
                return RedirectToAction("HallSelectAll");
            return View("HallSelectAll");
        }
        #endregion

        #region MCDropdown
        public IActionResult HallAddEdit()
        {
            DataTable dtMC = dalMST_HALL.PR_MCID_DROPDOWN();

            List<HallModel> hallModel = new List<HallModel>();
            foreach (DataRow dr in dtMC.Rows)
            {
                HallModel vlst = new HallModel();
                vlst.MCID = Convert.ToInt32(dr["MCID"]);
                vlst.MCName = dr["MCName"].ToString();
                hallModel.Add(vlst);
            }
            ViewBag.MCList = hallModel;
            return View();
        }
        #endregion

        #region Add/Edit
        public IActionResult Add(int? HallID)
        {
            DataTable dtMC = dalMST_HALL.PR_MCID_DROPDOWN();

            List<HallModel> hallModel = new List<HallModel>();
            foreach (DataRow dr in dtMC.Rows)
            {
                HallModel vlst = new HallModel();
                vlst.MCID = Convert.ToInt32(dr["MCID"]);
                vlst.MCName = dr["MCName"].ToString();
                hallModel.Add(vlst);
            }
            ViewBag.MCList = hallModel;




            #region Record Select by PK
            if (HallID != null)
            {
                DataTable dt = dalMST_HALL.PR_API_MST_HALL_SELECTBYPK(HallID);
                if (dt.Rows.Count > 0)
                {
                    HallModel model = new HallModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.HallID = Convert.ToInt32(dr["HallID"]);
                        model.HallName = dr["HallName"].ToString();
                        model.HallDescription = dr["HallDescription"].ToString();
                        model.Capacity = Convert.ToInt32(dr["Capacity"]);
                        model.PricePerDay = Convert.ToInt32(dr["PricePerDay"]);
                        model.Deposit = Convert.ToInt32(dr["Deposit"]);
                        model.LocationURL = dr["LocationURL"].ToString();
                        model.ImageURL = dr["ImageURL"].ToString();
                        model.FloorNo = Convert.ToInt32(dr["FloorNo"]);
                        model.Address = dr["Address"].ToString();
                        model.ContactPerson = dr["ContactPerson"].ToString();
                        model.ContactNumber = dr["ContactNumber"].ToString();
                        model.UserID = Convert.ToInt32(dr["UserID"]);
                        model.MCID = Convert.ToInt32(dr["MCID"]);
                    }
                    return View("HallAddEdit", model);
                }
            }
            #endregion
            return View("HallAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(HallModel modelHallModel)
        {
            if (modelHallModel.File != null)
            {
                //determine uploaded GroundImage type (i.e. .docx, .pdf, .jpg, etc.) and create folder according to file type
                string filePath = System.IO.Path.GetExtension(modelHallModel.File.FileName);

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
                string folderPath = Path.Combine("wwwroot/" + filePath + "/", modelHallModel.File.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    modelHallModel.File.CopyTo(fs);
                }
                // Store GroundImage path in the list
                modelHallModel.ImageURL = "/" + filePath + "/" + modelHallModel.File.FileName;
            }


            if (ModelState.IsValid)
            {
                if (modelHallModel.HallID == null)
                {
                    if (Convert.ToBoolean(dalMST_HALL.PR_API_MST_HALL_INSERT(modelHallModel)))
                    {
                        TempData["successMessage"] = "Record Inserted Successfully";
                    }
                    return RedirectToAction("HallSelectAll");
                }
                else
                {
                    if (Convert.ToBoolean(dalMST_HALL.PR_API_MST_HALL_UPDATE(modelHallModel)))
                    {
                        TempData["successMessage"] = "Record Updated Successfully";
                    }

                    return RedirectToAction("HallSelectAll");
                }

            }
            TempData["errorMessage"] = "Some error has occurred";
            return RedirectToAction("HallSelectAll");
        }
        #endregion

        #region HallSearch
        public IActionResult HallSearch(string HallName, string HallCapacity)
        {
            int cap = Convert.ToInt32(HallCapacity);
            DataTable dt = dalMST_HALL.PR_MST_HALL_SEARCH(HallName, cap);
            return View("HallSelectAll", dt);

        }
        #endregion

        #region ExportToExcel
        public IActionResult WritedatatoExcel()
        {
            return ExportHallsToExcel(dalMST_HALL.PR_API_MST_HALL_SELECTALL());

        }

        public IActionResult ExportHallsToExcel(DataTable dt)
        {
            string filename = "Halls.xlsx";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Halls");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
                }
            }

        }
        #endregion

        #region DeleteByCheckBox
        public IActionResult deletemultiple(string ids)
        {


            int i = 0;
            var st = ids.Split(',');
            foreach (var id in st)
            {
                i = dalMST_HALL.PR_API_MST_HALL_DELETE(int.Parse(id));

            }
            if (i > 0)
            {
                return Json(new { status = true, message = "Data deleted successfully" });
            }
            else
            {
                return Json(new { status = false, message = "Error deleting data" });
            }
        }

        #endregion
    }


}
