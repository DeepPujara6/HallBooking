#region Import Namespaces
using HallBooking.Areas.MST_Corporation.Models;
using HallBooking.BAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
#endregion

namespace HallBooking.DAL
{
	public class MST_Corporation_DALBase : DAL_Helper
	{
		#region Method: PR_API_MST_CORPORATION_SELECTALL
		public DataTable PR_API_MST_CORPORATION_SELECTALL()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_CORPORATION_SELECTALL");
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

		#region Method: PR_API_MST_CORPORATION_DELETE
		public int PR_API_MST_CORPORATION_DELETE(int MCID)
		{
			try
			{
				int id = MCID;
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_CORPORATION_DELETE");
				sqlDB.AddInParameter(dbCMD, "MCID", SqlDbType.Int, MCID);

				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue);
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		#endregion

		#region Method: PR_API_MST_CORPORATION_INSERT
		public bool? PR_API_MST_CORPORATION_INSERT(CorporationModel modelCorporationModel)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_CORPORATION_INSERT");
				sqlDB.AddInParameter(dbCMD, "@MCName", SqlDbType.VarChar, modelCorporationModel.MCName);
				sqlDB.AddInParameter(dbCMD, "@MCCity", SqlDbType.VarChar, modelCorporationModel.MCCity);
				sqlDB.AddInParameter(dbCMD, "@MCPinCode", SqlDbType.Int, modelCorporationModel.MCPinCode);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
				sqlDB.AddInParameter(dbCMD, "Created", SqlDbType.DateTime, DateTime.Now.ToString());
				sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());
				sqlDB.AddInParameter(dbCMD, "@MCLogo", SqlDbType.VarChar, modelCorporationModel.MCLogo);
				sqlDB.AddInParameter(dbCMD, "@MCEmail", SqlDbType.VarChar, modelCorporationModel.MCEmail);
				sqlDB.AddInParameter(dbCMD, "@ContactPerson", SqlDbType.VarChar, modelCorporationModel.ContactPerson);
				sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, modelCorporationModel.ContactNo);
				sqlDB.AddInParameter(dbCMD, "@MCAddress", SqlDbType.VarChar, modelCorporationModel.MCAddress);

				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue == -1 ? false : true);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region Method: PR_API_MST_CORPORATION_SELECTBYPK
		public DataTable PR_API_MST_CORPORATION_SELECTBYPK(int? MCID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_CORPORATION_SELECTBYPK");
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

		#region Method: PR_API_MST_CORPORATION_UPDATE
		public bool? PR_API_MST_CORPORATION_UPDATE(CorporationModel modelCorporationModel)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_CORPORATION_UPDATE");
				sqlDB.AddInParameter(dbCMD, "@MCID", SqlDbType.Int, modelCorporationModel.MCID);
				sqlDB.AddInParameter(dbCMD, "@MCName", SqlDbType.VarChar, modelCorporationModel.MCName);
				sqlDB.AddInParameter(dbCMD, "@MCCity", SqlDbType.VarChar, modelCorporationModel.MCCity);
				sqlDB.AddInParameter(dbCMD, "@MCPinCode", SqlDbType.Int, modelCorporationModel.MCPinCode);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
				sqlDB.AddInParameter(dbCMD, "Modified", SqlDbType.DateTime, DateTime.Now.ToString());
				sqlDB.AddInParameter(dbCMD, "@MCLogo", SqlDbType.VarChar, modelCorporationModel.MCLogo);
				sqlDB.AddInParameter(dbCMD, "@MCEmail", SqlDbType.VarChar, modelCorporationModel.MCEmail);
				sqlDB.AddInParameter(dbCMD, "@ContactPerson", SqlDbType.VarChar, modelCorporationModel.ContactPerson);
				sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, modelCorporationModel.ContactNo);
				sqlDB.AddInParameter(dbCMD, "@MCAddress", SqlDbType.VarChar, modelCorporationModel.MCAddress);
				int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
				return (vReturnValue == -1 ? false : true);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
		#endregion

		#region Method: PR_MST_CORPORATION_SEARCH
		public DataTable PR_MST_Corporation_SEARCH(string MCName)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Corporation_SEARCH");
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, CommonVariables.UserID());
				if (MCName != null)
				{
					sqlDB.AddInParameter(dbCMD, "MCName", SqlDbType.VarChar, MCName);
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

		#region Method: PR_API_MST_CORPORATION_SELECTALL_USER
		public DataTable PR_API_MST_CORPORATION_SELECTALL_USER()
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_API_MST_CORPORATION_SELECTALL_USER");
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

		#region Method: PR_MST_Corporation_Search_User
		public DataTable PR_MST_Corporation_Search_User(string MCName)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(ConnStr);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Corporation_Search_User");
				if (MCName != null)
				{
					sqlDB.AddInParameter(dbCMD, "MCName", SqlDbType.VarChar, MCName);
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
	}
}
