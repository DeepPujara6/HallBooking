#region Import Namespaces
using HallBooking.Areas.MST_Booking.Models;
using HallBooking.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
#endregion
namespace HallBooking.Areas.MST_Booking.Controllers
{
    #region Route
    [Area("MST_Booking")]
    [Route("MST_Booking/[controller]/[action]")]
    #endregion
    public class MST_Booking : Controller
    {
        #region DAL Object
        MST_Booking_DALBase dalMST_BOOKING = new MST_Booking_DALBase();
        #endregion

        #region BookingSelectAll
        public IActionResult BookingSelectAll()
        {
            DataTable dt = dalMST_BOOKING.PR_API_MST_BOOKING_SELECTALL();
            return View("BookingSelectAll", dt);
        }
        #endregion

        #region BookingDelete
        public IActionResult Delete(int id)
        {
            int ax = dalMST_BOOKING.PR_API_MST_BOOKING_DELETE(id);
            if (ax > 0)
                return RedirectToAction("BookingSelectAll");
            return View("BookingSelectAll");
        }
        #endregion

        #region FillHallDropdown
        public IActionResult BookingAddEdit()
        {

            DataTable dtMC = dalMST_BOOKING.PR_HALL_DROPDOWN();

            List<BookingModel> bookingModel = new List<BookingModel>();
            foreach (DataRow dr in dtMC.Rows)
            {
                BookingModel vlst = new BookingModel();
                vlst.HallID = Convert.ToInt32(dr["HallID"]);
                vlst.HallName = dr["HallName"].ToString();
                bookingModel.Add(vlst);
            }
            ViewBag.HallList = bookingModel;
            return View();
        }
        #endregion

        #region Add/Edit
        public IActionResult Add(int? BookingID)
        {
            DataTable dtMC = dalMST_BOOKING.PR_HALL_DROPDOWN();

            List<BookingModel> bookingModel = new List<BookingModel>();
            foreach (DataRow dr in dtMC.Rows)
            {
                BookingModel vlst = new BookingModel();
                vlst.HallID = Convert.ToInt32(dr["HallID"]);
                vlst.HallName = dr["HallName"].ToString();
                bookingModel.Add(vlst);
            }
            ViewBag.HallList = bookingModel;

            #region Record Select by PK
            if (BookingID != null)
            {
                DataTable dt = dalMST_BOOKING.PR_API_MST_BOOKING_SELECTBYPK(BookingID);
                if (dt.Rows.Count > 0)
                {
                    BookingModel model = new BookingModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.BookingID = Convert.ToInt32(dr["BookingID"]);
                        model.HallID = Convert.ToInt32(dr["HallID"]);
                        model.Date = Convert.ToDateTime(dr["Date"]);
                        model.FromDate = Convert.ToDateTime(dr["FromDate"]);
                        model.ToDate = Convert.ToDateTime(dr["ToDate"]);
                        model.Persons = Convert.ToInt32(dr["Persons"]);
                        model.BookingPurpose = dr["BookingPurpose"].ToString();
                        model.CustomerName = dr["CustomerName"].ToString();
                        model.Mobile = dr["Mobile"].ToString();
                        model.Email = dr["Email"].ToString();
                        model.Address = dr["Address"].ToString();
                        model.IdProofNo = dr["IdProofNo"].ToString();
                        model.IdProofPhoto = dr["IdProofPhoto"].ToString();
                        model.UserID = Convert.ToInt32(dr["UserID"]);
                    }
                    return View("BookingAddEdit", model);
                }
            }
            #endregion
            return View("BookingAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(BookingModel modelBookingModel)
        {
            if (modelBookingModel.File != null)
            {
                //determine uploaded GroundImage type (i.e. .docx, .pdf, .jpg, etc.) and create folder according to file type
                string filePath = System.IO.Path.GetExtension(modelBookingModel.File.FileName);

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
                string folderPath = Path.Combine("wwwroot/" + filePath + "/", modelBookingModel.File.FileName);
                using (FileStream fs = System.IO.File.Create(folderPath))
                {
                    modelBookingModel.File.CopyTo(fs);
                }
                // Store GroundImage path in the list
                modelBookingModel.IdProofPhoto = "/" + filePath + "/" + modelBookingModel.File.FileName;
            }


            if (ModelState.IsValid)
            {
                if (modelBookingModel.BookingID == null)
                {
                    if (Convert.ToBoolean(dalMST_BOOKING.PR_API_MST_BOOKING_INSERT(modelBookingModel)))
                    {
                        TempData["successMessage"] = "Record Inserted Successfully";
                    }
                    return RedirectToAction("BookingSelectAll");
                }
                else
                {
                    if (Convert.ToBoolean(dalMST_BOOKING.PR_API_MST_BOOKING_UPDATE(modelBookingModel)))
                    {
                        TempData["successMessage"] = "Record Updated Successfully";
                    }

                    return RedirectToAction("BookingSelectAll");
                }

            }
            TempData["errorMessage"] = "Some error has occurred";
            return RedirectToAction("BookingSelectAll");
        }
        #endregion

        #region CheckBookingAvailability
        public IActionResult CheckBookingAvailability(int HallID, DateTime FromDate, DateTime ToDate)
        {
            int result = 0;
            BookingModel model = new BookingModel();
            DataTable dt = dalMST_BOOKING.CheckBookingAvailability(HallID, FromDate, ToDate);
            foreach (DataRow dr in dt.Rows)
            {

                result = Convert.ToInt32(dr["result"]);

            }
            if (result > 0)
            {
                return Json("Hall is already booked for the selected date and time");
                //result = "Hall is already booked for the selected date and time";
            }
            else
            {
                return Json("Hall is available for booking");
                //result = "Hall is available for booking";
            }
        }

        #endregion

        #region BookingSearch
        public IActionResult BookingSearch(string HallName, string CustomerName)
        {

            DataTable dt = dalMST_BOOKING.PR_MST_Booking_Search(HallName, CustomerName);
            return View("BookingSelectAll", dt);

        }
        #endregion

        #region ManageBooking
        public IActionResult ManageBooking()
        {

            return View("ManageBooking");
        }
        #endregion

        #region FetchBookingDetails
        public ActionResult FetchBookingDetails(int bookingNo)
        {

            DataTable dt = dalMST_BOOKING.GetBookingDetailsByBookingNo(bookingNo);
            if (dt != null && dt.Rows.Count > 0)
            {
                return View("ManageBooking", dt);
            }
            else
            {
                TempData["Message"] = "No booking found for the provided booking number.";
                return RedirectToAction("ManageBooking");
            }
        }
        #endregion

        public ActionResult UpdatePendingAmount(int bookingNo, decimal pendingAmount)
        {
            bool result = dalMST_BOOKING.UpdatePendingAmount(bookingNo, pendingAmount);
            if (result)
            {
                TempData["Message"] = "Pending Amount updated successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to update Pending Amount.";
            }
            return RedirectToAction("ManageBooking");
        }



    }
}
