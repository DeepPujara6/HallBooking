#region Import Namespaces
using HallBooking.Areas.SEC_User.Models;
using HallBooking.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
#endregion

namespace HallBooking.DAL
{
    public class MST_User_DALBase : DAL_Helper
    {
        #region Method: PR_API_MST_USER_SELECTALL
        public DataTable PR_API_MST_USER_SELECTALL()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_USER_SELECTALL");

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

        #region Method: PR_API_MST_USER_DELETE
        public int PR_API_MST_USER_DELETE(int UserID)
        {
            try
            {
                int id = UserID;
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_USER_DELETE");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Method: PR_API_MST_USER_INSERT
        public bool? PR_API_MST_USER_INSERT(SEC_UserLoginModel modelUserModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_USER_INSERT");
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, modelUserModel.UserName);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, modelUserModel.Password);
                sqlDB.AddInParameter(dbCMD, "@FirstName", SqlDbType.VarChar, modelUserModel.FirstName);
                sqlDB.AddInParameter(dbCMD, "@LastName", SqlDbType.VarChar, modelUserModel.LastName);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, modelUserModel.Email);
                sqlDB.AddInParameter(dbCMD, "@PhoneNumber", SqlDbType.VarChar, modelUserModel.PhoneNumber);
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

        #region Method: PR_API_MST_USER_SELECTBYPK
        public DataTable PR_API_MST_USER_SELECTBYPK(int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_USER_SELECTBYPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
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

        #region Method: PR_API_MST_USER_UPDATE
        public bool? PR_API_MST_USER_UPDATE(SEC_UserLoginModel modelUserModel)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnStr);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_USER_UPDATE");
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.VarChar, modelUserModel.UserName);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.VarChar, modelUserModel.Password);
                sqlDB.AddInParameter(dbCMD, "@FirstName", SqlDbType.VarChar, modelUserModel.FirstName);
                sqlDB.AddInParameter(dbCMD, "@LastName", SqlDbType.VarChar, modelUserModel.LastName);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.VarChar, modelUserModel.Email);
                sqlDB.AddInParameter(dbCMD, "@PhoneNumber", SqlDbType.VarChar, modelUserModel.PhoneNumber);
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
    }
}
