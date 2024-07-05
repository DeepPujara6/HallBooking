namespace HallBooking.DAL
{
    public class DAL_Helper
    {
        #region Connection String
        public static string ConnStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnection");
        #endregion
    }
}
