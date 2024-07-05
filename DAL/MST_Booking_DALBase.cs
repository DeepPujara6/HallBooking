#region Import Namespaces
using HallBooking.Areas.MST_Booking.Models;
using HallBooking.BAL;
using HallBooking.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
#endregion

namespace HallBooking.DAL
{
    public class MST_Booking_DALBase : DAL_Helper
    {
        #region Method: PR_API_MST_BOOKING_SELECTALL
        public DataTable PR_API_MST_BOOKING_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_BOOKING_SELECTALL");
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_API_MST_BOOKING_DELETE
        public int PR_API_MST_BOOKING_DELETE(int BookingID)
        {
            try
            {
                int id = BookingID;
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_BOOKING_DELETE");
                sqlDB.AddInParameter(dbCMD, "BookingID", SqlDbType.Int, BookingID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Method: PR_API_MST_BOOKING_INSERT
        public bool? PR_API_MST_BOOKING_INSERT(BookingModel modelBookingModel)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_BOOKING_INSERT");

                sqlDB.AddInParameter(dbCMD, "@HallID", SqlDbType.Int, modelBookingModel.HallID);
                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, modelBookingModel.Date);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, modelBookingModel.FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, modelBookingModel.ToDate);
                sqlDB.AddInParameter(dbCMD, "@Persons", SqlDbType.Int, modelBookingModel.Persons);
                sqlDB.AddInParameter(dbCMD, "@BookingPurpose", SqlDbType.VarChar, modelBookingModel.BookingPurpose);
                sqlDB.AddInParameter(dbCMD, "@CustomerName", SqlDbType.VarChar, modelBookingModel.CustomerName);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, modelBookingModel.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, modelBookingModel.Email);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, modelBookingModel.Address);
                sqlDB.AddInParameter(dbCMD, "@IdProofNo", SqlDbType.Int, modelBookingModel.IdProofNo);
                sqlDB.AddInParameter(dbCMD, "@IdProofPhoto", SqlDbType.VarChar, modelBookingModel.IdProofPhoto);
                sqlDB.AddInParameter(dbCMD, "@IsPending", SqlDbType.Bit, modelBookingModel.IsPending);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DateTime.Now.ToString());
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_API_MST_BOOKING_SELECTBYPK
        public DataTable PR_API_MST_BOOKING_SELECTBYPK(int? BookingID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_BOOKING_SELECTBYPK");
                sqlDB.AddInParameter(dbCMD, "BookingID", SqlDbType.Int, BookingID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_API_MST_BOOKING_UPDATE
        public bool? PR_API_MST_BOOKING_UPDATE(BookingModel modelBookingModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_BOOKING_UPDATE");
                sqlDB.AddInParameter(dbCMD, "BookingID", SqlDbType.Int, modelBookingModel.BookingID);
                sqlDB.AddInParameter(dbCMD, "@HallID", SqlDbType.Int, modelBookingModel.HallID);
                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, modelBookingModel.Date);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, modelBookingModel.FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, modelBookingModel.ToDate);
                sqlDB.AddInParameter(dbCMD, "@Persons", SqlDbType.Int, modelBookingModel.Persons);
                sqlDB.AddInParameter(dbCMD, "@BookingPurpose", SqlDbType.VarChar, modelBookingModel.BookingPurpose);
                sqlDB.AddInParameter(dbCMD, "@CustomerName", SqlDbType.VarChar, modelBookingModel.CustomerName);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, modelBookingModel.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, modelBookingModel.Email);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, modelBookingModel.Address);
                sqlDB.AddInParameter(dbCMD, "@IdProofNo", SqlDbType.Int, modelBookingModel.IdProofNo);
                sqlDB.AddInParameter(dbCMD, "@IdProofPhoto", SqlDbType.VarChar, modelBookingModel.IdProofPhoto);
                sqlDB.AddInParameter(dbCMD, "@IsPending", SqlDbType.VarChar, modelBookingModel.IsPending);
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_HALL_DROPDOWN
        public DataTable PR_HALL_DROPDOWN()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_HALL_DROPDOWN");
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region CheckBookingAvailability
        public DataTable CheckBookingAvailability(int HallID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("CheckBookingAvailability");
                sqlDB.AddInParameter(dbCMD, "HallID", SqlDbType.Int, HallID);
                sqlDB.AddInParameter(dbCMD, "FromDate", SqlDbType.DateTime, FromDate);
                sqlDB.AddInParameter(dbCMD, "ToDate", SqlDbType.DateTime, ToDate);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;

            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return null; // Return -1 indicating an error
            }
        }
        #endregion

        #region Method: PR_MST_Booking_SEARCH
        public DataTable PR_MST_Booking_Search(string HallName, string CustomerName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Booking_Search");
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                if (HallName != null)
                {
                    sqlDB.AddInParameter(dbCMD, "HallName", SqlDbType.VarChar, HallName);
                }

                if (CustomerName != null)
                {
                    sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.VarChar, CustomerName);
                }

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_API_MST_BOOKING_INSERT_USER
        public bool? PR_API_MST_BOOKING_INSERT_USER(UserModel modelUserModel)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_BOOKING_INSERT");

                sqlDB.AddInParameter(dbCMD, "@HallID", SqlDbType.Int, modelUserModel.HallID);
                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, modelUserModel.Date);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, modelUserModel.FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, modelUserModel.ToDate);
                sqlDB.AddInParameter(dbCMD, "@Persons", SqlDbType.Int, modelUserModel.Persons);
                sqlDB.AddInParameter(dbCMD, "@BookingPurpose", SqlDbType.VarChar, modelUserModel.BookingPurpose);
                sqlDB.AddInParameter(dbCMD, "@CustomerName", SqlDbType.VarChar, modelUserModel.CustomerName);
                sqlDB.AddInParameter(dbCMD, "@Mobile", SqlDbType.VarChar, modelUserModel.Mobile);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, modelUserModel.Email);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, modelUserModel.Address);
                sqlDB.AddInParameter(dbCMD, "@IdProofNo", SqlDbType.Int, modelUserModel.IdProofNo);
                sqlDB.AddInParameter(dbCMD, "@IdProofPhoto", SqlDbType.VarChar, modelUserModel.IdProofPhoto);
                sqlDB.AddInParameter(dbCMD, "@IsPending", SqlDbType.Bit, modelUserModel.IsPending);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DateTime.Now.ToString());
                sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: GetBookingDetailsByBookingNo
        public DataTable GetBookingDetailsByBookingNo(int bookingNo)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("GetBookingDetailsByBookingNo");
                sqlDB.AddInParameter(dbCMD, "BookingNo", SqlDbType.Int, bookingNo);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: UpdatePendingAmount
        public bool UpdatePendingAmount(int BookingNo, decimal PendingAmount)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("UpdatePendingAmount");
                sqlDB.AddInParameter(dbCMD, "BookingNo", SqlDbType.Int, BookingNo);
                sqlDB.AddInParameter(dbCMD, "PendingAmount", SqlDbType.Decimal, PendingAmount);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
