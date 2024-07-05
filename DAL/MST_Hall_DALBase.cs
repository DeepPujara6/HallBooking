#region Import Namespaces
using HallBooking.Areas.MST_Hall.Models;
using HallBooking.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
#endregion

namespace HallBooking.DAL
{
	public class MST_Hall_DALBase : DAL_Helper
	{

		#region Method: PR_API_MST_HALL_SELECTALL
		public DataTable PR_API_MST_HALL_SELECTALL()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_HALL_SELECTALL");
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

		#region Method: PR_API_MST_HALL_DELETE
		public int PR_API_MST_HALL_DELETE(int HallID)
		{
			try
			{
				int id = HallID;
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_HALL_DELETE");
				sqlDB.AddInParameter(dbCMD, "HallID", SqlDbType.Int, HallID);

				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue);
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		#endregion

		#region Method: PR_API_MST_HALL_INSERT
		public bool? PR_API_MST_HALL_INSERT(HallModel modelHallModel)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_HALL_INSERT");
				sqlDB.AddInParameter(dbCMD, "@HallName", SqlDbType.VarChar, modelHallModel.HallName);
				sqlDB.AddInParameter(dbCMD, "@HallDescription", SqlDbType.VarChar, modelHallModel.HallDescription);
				sqlDB.AddInParameter(dbCMD, "@Capacity", SqlDbType.Int, modelHallModel.Capacity);
				sqlDB.AddInParameter(dbCMD, "@PricePerDay", SqlDbType.Int, modelHallModel.PricePerDay);
				sqlDB.AddInParameter(dbCMD, "@Deposit", SqlDbType.Int, modelHallModel.Deposit);
				sqlDB.AddInParameter(dbCMD, "@LocationURL", SqlDbType.VarChar, modelHallModel.LocationURL);
				sqlDB.AddInParameter(dbCMD, "@ImageURL", SqlDbType.VarChar, modelHallModel.ImageURL);
				sqlDB.AddInParameter(dbCMD, "@FloorNo", SqlDbType.Int, modelHallModel.FloorNo);
				sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, modelHallModel.Address);
				sqlDB.AddInParameter(dbCMD, "@ContactPerson", SqlDbType.VarChar, modelHallModel.ContactPerson);
				sqlDB.AddInParameter(dbCMD, "@ContactNumber", SqlDbType.VarChar, modelHallModel.ContactNumber);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
				sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DateTime.Now.ToString());
				sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());
				sqlDB.AddInParameter(dbCMD, "@MCID", SqlDbType.Int, modelHallModel.MCID);

				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue == -1 ? false : true);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region Method: PR_API_MST_HALL_SELECTBYPK
		public DataTable PR_API_MST_HALL_SELECTBYPK(int? HallID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_HALL_SELECTBYPK");
				sqlDB.AddInParameter(dbCMD, "HallID", SqlDbType.Int, HallID);
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

		#region Method: PR_API_MST_HALL_UPDATE
		public bool? PR_API_MST_HALL_UPDATE(HallModel modelHallModel)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_HALL_UPDATE");
				sqlDB.AddInParameter(dbCMD, "HallID", SqlDbType.Int, modelHallModel.HallID);
				sqlDB.AddInParameter(dbCMD, "@HallName", SqlDbType.VarChar, modelHallModel.HallName);
				sqlDB.AddInParameter(dbCMD, "@HallDescription", SqlDbType.VarChar, modelHallModel.HallDescription);
				sqlDB.AddInParameter(dbCMD, "@Capacity", SqlDbType.Int, modelHallModel.Capacity);
				sqlDB.AddInParameter(dbCMD, "@PricePerDay", SqlDbType.Int, modelHallModel.PricePerDay);
				sqlDB.AddInParameter(dbCMD, "@Deposit", SqlDbType.Int, modelHallModel.Deposit);
				sqlDB.AddInParameter(dbCMD, "@LocationURL", SqlDbType.VarChar, modelHallModel.LocationURL);
				sqlDB.AddInParameter(dbCMD, "@ImageURL", SqlDbType.VarChar, modelHallModel.ImageURL);
				sqlDB.AddInParameter(dbCMD, "@FloorNo", SqlDbType.Int, modelHallModel.FloorNo);
				sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.VarChar, modelHallModel.Address);
				sqlDB.AddInParameter(dbCMD, "@ContactPerson", SqlDbType.VarChar, modelHallModel.ContactPerson);
				sqlDB.AddInParameter(dbCMD, "@ContactNumber", SqlDbType.VarChar, modelHallModel.ContactNumber);
				sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
				sqlDB.AddInParameter(dbCMD, "@MCID", SqlDbType.Int, modelHallModel.MCID);

				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue == -1 ? false : true);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region Method: PR_MST_HALL_SEARCH
		public DataTable PR_MST_HALL_SEARCH(string HallName, int Capacity)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_HALL_SEARCH");
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
				if (HallName != null)
				{
					sqlDB.AddInParameter(dbCMD, "HallName", SqlDbType.VarChar, HallName);
				}

				if (Capacity != null)
				{
					sqlDB.AddInParameter(dbCMD, "Capacity", SqlDbType.Int, Capacity);
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

		#region MCID_DROPDOWN
		public DataTable PR_MCID_DROPDOWN()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MCID_DROPDOWN");
				DataTable dt = new DataTable();
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
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

		#region Method: PR_API_MST_HALL_SELECTALL_USER
		public DataTable PR_API_MST_HALL_SELECTALL_USER(int? MCID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_HALL_SELECTALL_USER");
				sqlDB.AddInParameter(dbCMD, "MCID", SqlDbType.Int, MCID);

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

	}

}
