using HallBooking.BAL;
using HallBooking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace HallBooking.Controllers
{
    [CheckAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            var connectionstr = "Data Source=DESKTOP-DVN2N38\\SQLEXPRESS;Initial Catalog=HallBooking;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionstr);
            DataTable dt = new DataTable();
            conn.Open();
            SqlCommand objcmd = conn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_Counts";
            SqlDataReader reader = objcmd.ExecuteReader();
            dt.Load(reader);
            conn.Close();

            return View("Index", dt);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}