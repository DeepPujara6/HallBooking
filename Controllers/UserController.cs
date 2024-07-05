using HallBooking.DAL;
using HallBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HallBooking.Controllers
{
	[Route("User/[Controller]/[Action]")]
	public class UserController : Controller
	{
		#region DAL_Objects
		MST_Corporation_DALBase dalMST_CORPORATION = new MST_Corporation_DALBase();
		MST_Hall_DALBase dalMST_Hall = new MST_Hall_DALBase();
		MST_Booking_DALBase dalMST_BOOKING = new MST_Booking_DALBase();
		#endregion

		#region User_Index
		public IActionResult UserIndex()
		{
			DataTable dt = dalMST_CORPORATION.PR_API_MST_CORPORATION_SELECTALL_USER();
			return View("UserIndex", dt);
		}
		#endregion

		#region HallList
		public IActionResult HallListUser(int? MCID)
		{

			DataTable dt = dalMST_Hall.PR_API_MST_HALL_SELECTALL_USER(MCID);
			return View("HallListUser", dt);
		}
		#endregion

		#region HallDetail
		public IActionResult HallDetail(int HallID)
		{
			DataTable dt = dalMST_Hall.PR_API_MST_HALL_SELECTBYPK(HallID);
			return View("HallDetail", dt);
		}
		#endregion


		#region UserBooking
		public IActionResult UserBooking(int HallID, int PricePerDay, int Deposit)
		{
			ViewBag.PricePerDay = PricePerDay;
			ViewBag.Deposit = Deposit;
			return View("UserBooking");
		}
		#endregion

		#region Save
		[HttpPost]
		public IActionResult Save(UserModel modelUserModel)
		{
			if (modelUserModel.File != null)
			{
				//determine uploaded GroundImage type (i.e. .docx, .pdf, .jpg, etc.) and create folder according to file type
				string filePath = System.IO.Path.GetExtension(modelUserModel.File.FileName);

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
				string folderPath = Path.Combine("wwwroot/" + filePath + "/", modelUserModel.File.FileName);
				using (FileStream fs = System.IO.File.Create(folderPath))
				{
					modelUserModel.File.CopyTo(fs);
				}
				// Store GroundImage path in the list
				modelUserModel.IdProofPhoto = "/" + filePath + "/" + modelUserModel.File.FileName;
			}

			if (ModelState.IsValid)
			{

				if (Convert.ToBoolean(dalMST_BOOKING.PR_API_MST_BOOKING_INSERT_USER(modelUserModel)))
				{
					TempData["successMessage"] = "Booking Successful";
				}
				return RedirectToAction("UserIndex");


			}
			TempData["errorMessage"] = "Some error has occurred";
			return RedirectToAction("UserIndex");

		}
		#endregion

		#region BookingList
		public IActionResult BookingList()
		{
			DataTable dt = dalMST_BOOKING.PR_API_MST_BOOKING_SELECTALL();
			return View("BookingList", dt);
		}
		#endregion

		#region HelpCenterPage
		public IActionResult HelpCenter()
		{
			return View("HelpCenter");
		}
		#endregion


		#region CorporationSearchUser
		public IActionResult CorporationSearchUser(string MCName)
		{
			DataTable dt = dalMST_CORPORATION.PR_MST_Corporation_Search_User(MCName);
			return View("UserIndex", dt);

		}
		#endregion

		#region About
		public IActionResult About()
		{
			return View("About");
		}
		#endregion

		#region ContactUs
		public IActionResult ContactUs()
		{
			return View("ContactUs");
		}
		#endregion

	}
}
