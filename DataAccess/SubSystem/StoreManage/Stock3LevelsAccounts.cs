using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	/// <summary>
	/// Stock3LevelsAccounts 的摘要说明。
	/// </summary>
	public class Stock3LevelsAccounts:IDisposable
	{
		private SqlDataAdapter dsCommand;
        
		private const String HOUSEID_PARM               = "@houseid";
		private const String DEPARTMENTID_PARM          = "@departmentid";
		private const String MATERIALID_PARM            = "@materialid";
		private const String YEAR_PARM                  = "@year";
		private const String MONTH_PARM                 = "@month";
		private const String PUB_ATTRIBUTE_PARM         = "@pub_attribute";

		private const String LASTBUSINESSMARGIN_PARM    = "@lastbusinessmargin";
		private const String LASTACCOUNTMARGIN_PARM     = "@lastaccountmargin";
		private const String LASTDIFFENCEINVENTORY_PARM = "@lastdiffenceinventory";
		private const String LASTACCOUNTBALANCE_PARM    = "@lastaccountbalance";

		private const String THISBUSINESSIN_PARM        = "@thisbusinessin";
		private const String THISBUSINESSOUT_PARM       = "@thisbusinessout";
		private const String THISACCOUNTIN_PARM         = "@thisaccountin";
		private const String THISACCOUNTOUT_PARM        = "@thisaccountout";

		private const String THISINMONEY_PARM           = "@thisinmoney";
		private const String THISOUTMONEY_PARM          = "@thisoutmoney";
		private const String THISINDIFFENCE_PARM        = "@thisindiffence";
		private const String THISDIFFENCERATE_PARM      = "@thisdiffencerate";

		private const String AVERAGEPRICE_PARM          = "@averageprice";
		private const String ACCOUNTDEP_PARM            = "@accountdep";
		private const String STATUS_PARM                = "@status";

		#region Create Adapter
		public Stock3LevelsAccounts()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",Stock3LevelsAccountData.STOCK3LEVELSACCOUNT_TABLE);
		}
		#endregion
		#region 释放资源
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected virtual void Dispose(bool disposing)
		{
			if(!disposing)
				return;
			if(dsCommand != null)
			{
				if(dsCommand.SelectCommand != null)
				{
					if(dsCommand.SelectCommand.Connection != null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				}
				if(dsCommand.InsertCommand != null)
				{
					if(dsCommand.InsertCommand.Connection != null)
					{
						dsCommand.InsertCommand.Connection.Close();
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}
				if(dsCommand.UpdateCommand != null)
				{
					if(dsCommand.UpdateCommand.Connection != null)
					{
						dsCommand.UpdateCommand.Connection.Close();
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion
		#region Read data
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_Stock3LevelsAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public Stock3LevelsAccountData LoadStock3LevelsAccount()
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			Stock3LevelsAccountData data = new Stock3LevelsAccountData();
			dsCommand.SelectCommand = GetLoadCommand();
			try
			{
				dsCommand.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}
		#endregion
		#region insert data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_Stock3LevelsAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = Stock3LevelsAccountData.HOUSEID_FIELD;
			insertCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = Stock3LevelsAccountData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = Stock3LevelsAccountData.MATERIALID_FIELD;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_year = new SqlParameter(YEAR_PARM,SqlDbType.SmallInt);
			parm_year.Direction    = ParameterDirection.Input;
			parm_year.SourceColumn = Stock3LevelsAccountData.YEAR_FIELD;
			insertCommand.Parameters.Add(parm_year);

			SqlParameter parm_month = new SqlParameter(MONTH_PARM,SqlDbType.SmallInt);
			parm_month.Direction    = ParameterDirection.Input;
			parm_month.SourceColumn = Stock3LevelsAccountData.MONTH_FIELD;
			insertCommand.Parameters.Add(parm_month);

			
			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_pub_attribute.Direction    = ParameterDirection.Input;
			parm_pub_attribute.SourceColumn = Stock3LevelsAccountData.PUB_ATTRIBUTE_FIELD;
			insertCommand.Parameters.Add(parm_pub_attribute);

			SqlParameter parm_lastbusinessmargin = new SqlParameter(LASTBUSINESSMARGIN_PARM,SqlDbType.Real);
			parm_lastbusinessmargin.Direction    = ParameterDirection.Input;
			parm_lastbusinessmargin.SourceColumn = Stock3LevelsAccountData.LASTBUSINESSMARGIN_FIELD;
			insertCommand.Parameters.Add(parm_lastbusinessmargin);

			SqlParameter parm_lastaccountmargin = new SqlParameter(LASTACCOUNTMARGIN_PARM,SqlDbType.Real);
			parm_lastaccountmargin.Direction    = ParameterDirection.Input;
			parm_lastaccountmargin.SourceColumn = Stock3LevelsAccountData.LASTACCOUNTMARGIN_FIELD;
			insertCommand.Parameters.Add(parm_lastaccountmargin);

			SqlParameter parm_lastdiffenceinventory = new SqlParameter(LASTDIFFENCEINVENTORY_PARM,SqlDbType.Real);
			parm_lastdiffenceinventory.Direction    = ParameterDirection.Input;
			parm_lastdiffenceinventory.SourceColumn = Stock3LevelsAccountData.LASTDIFFENCEINVENTORY_FIELD;
			insertCommand.Parameters.Add(parm_lastdiffenceinventory);

			SqlParameter parm_lastaccountbalance = new SqlParameter(LASTACCOUNTBALANCE_PARM,SqlDbType.Real);
			parm_lastaccountbalance.Direction    = ParameterDirection.Input;
			parm_lastaccountbalance.SourceColumn = Stock3LevelsAccountData.LASTACCOUNTBALANCE_FIELD;
			insertCommand.Parameters.Add(parm_lastaccountbalance);

			SqlParameter parm_thisbusinessin = new SqlParameter(THISBUSINESSIN_PARM,SqlDbType.Real);
			parm_thisbusinessin.Direction    = ParameterDirection.Input;
			parm_thisbusinessin.SourceColumn = Stock3LevelsAccountData.THISBUSINESSIN_FIELD;
			insertCommand.Parameters.Add(parm_thisbusinessin);

			SqlParameter parm_thisbusinessout = new SqlParameter(THISBUSINESSOUT_PARM,SqlDbType.Real);
			parm_thisbusinessout.Direction    = ParameterDirection.Input;
			parm_thisbusinessout.SourceColumn = Stock3LevelsAccountData.THISBUSINESSOUT_FIELD;
			insertCommand.Parameters.Add(parm_thisbusinessout);

			SqlParameter parm_thisaccountin = new SqlParameter(THISACCOUNTIN_PARM,SqlDbType.Real);
			parm_thisaccountin.Direction    = ParameterDirection.Input;
			parm_thisaccountin.SourceColumn = Stock3LevelsAccountData.THISACCOUNTIN_FIELD;
			insertCommand.Parameters.Add(parm_thisaccountin);

			SqlParameter parm_thisaccountout = new SqlParameter(THISACCOUNTOUT_PARM,SqlDbType.Real);
			parm_thisaccountout.Direction    = ParameterDirection.Input;
			parm_thisaccountout.SourceColumn = Stock3LevelsAccountData.THISACCOUNTOUT_FIELD;
			insertCommand.Parameters.Add(parm_thisaccountout);

			SqlParameter parm_thisinmoney = new SqlParameter(THISINMONEY_PARM,SqlDbType.Real);
			parm_thisinmoney.Direction    = ParameterDirection.Input;
			parm_thisinmoney.SourceColumn = Stock3LevelsAccountData.THISINMONEY_FIELD;
			insertCommand.Parameters.Add(parm_thisinmoney);

			SqlParameter parm_thisoutmoney = new SqlParameter(THISOUTMONEY_PARM,SqlDbType.Real);
			parm_thisoutmoney.Direction    = ParameterDirection.Input;
			parm_thisoutmoney.SourceColumn = Stock3LevelsAccountData.THISOUTMONEY_FIELD;
			insertCommand.Parameters.Add(parm_thisoutmoney);

			SqlParameter parm_thisindiffence = new SqlParameter(THISINDIFFENCE_PARM,SqlDbType.Real);
			parm_thisindiffence.Direction    = ParameterDirection.Input;
			parm_thisindiffence.SourceColumn = Stock3LevelsAccountData.THISINDIFFENCE_FIELD;
			insertCommand.Parameters.Add(parm_thisindiffence);

			SqlParameter parm_thisdiffencerate = new SqlParameter(THISDIFFENCERATE_PARM,SqlDbType.Real);
			parm_thisdiffencerate.Direction    = ParameterDirection.Input;
			parm_thisdiffencerate.SourceColumn = Stock3LevelsAccountData.THISDIFFENCERATE_FIELD;
			insertCommand.Parameters.Add(parm_thisdiffencerate);

			SqlParameter parm_averageprice = new SqlParameter(AVERAGEPRICE_PARM,SqlDbType.Real);
			parm_averageprice.Direction    = ParameterDirection.Input;
			parm_averageprice.SourceColumn = Stock3LevelsAccountData.AVERAGEPRICE_FIELD;
			insertCommand.Parameters.Add(parm_averageprice);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = Stock3LevelsAccountData.ACCOUNTDEP_FIELD;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = Stock3LevelsAccountData.STATUS_FIELD;
			insertCommand.Parameters.Add(parm_status);

			return insertCommand;

		}
		public bool InsertStock3LevelsAccount(Stock3LevelsAccountData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,Stock3LevelsAccountData.STOCK3LEVELSACCOUNT_TABLE);

			if(info.HasErrors)
			{
				info.Tables[Stock3LevelsAccountData.STOCK3LEVELSACCOUNT_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion
		#region update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_Stock3LevelsAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = Stock3LevelsAccountData.HOUSEID_FIELD;
			updateCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = Stock3LevelsAccountData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = Stock3LevelsAccountData.MATERIALID_FIELD;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_year = new SqlParameter(YEAR_PARM,SqlDbType.SmallInt);
			parm_year.Direction    = ParameterDirection.Input;
			parm_year.SourceColumn = Stock3LevelsAccountData.YEAR_FIELD;
			updateCommand.Parameters.Add(parm_year);

			SqlParameter parm_month = new SqlParameter(MONTH_PARM,SqlDbType.SmallInt);
			parm_month.Direction    = ParameterDirection.Input;
			parm_month.SourceColumn = Stock3LevelsAccountData.MONTH_FIELD;
			updateCommand.Parameters.Add(parm_month);

			
			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_pub_attribute.Direction    = ParameterDirection.Input;
			parm_pub_attribute.SourceColumn = Stock3LevelsAccountData.PUB_ATTRIBUTE_FIELD;
			updateCommand.Parameters.Add(parm_pub_attribute);

			SqlParameter parm_lastbusinessmargin = new SqlParameter(LASTBUSINESSMARGIN_PARM,SqlDbType.Real);
			parm_lastbusinessmargin.Direction    = ParameterDirection.Input;
			parm_lastbusinessmargin.SourceColumn = Stock3LevelsAccountData.LASTBUSINESSMARGIN_FIELD;
			updateCommand.Parameters.Add(parm_lastbusinessmargin);

			SqlParameter parm_lastaccountmargin = new SqlParameter(LASTACCOUNTMARGIN_PARM,SqlDbType.Real);
			parm_lastaccountmargin.Direction    = ParameterDirection.Input;
			parm_lastaccountmargin.SourceColumn = Stock3LevelsAccountData.LASTACCOUNTMARGIN_FIELD;
			updateCommand.Parameters.Add(parm_lastaccountmargin);

			SqlParameter parm_lastdiffenceinventory = new SqlParameter(LASTDIFFENCEINVENTORY_PARM,SqlDbType.Real);
			parm_lastdiffenceinventory.Direction    = ParameterDirection.Input;
			parm_lastdiffenceinventory.SourceColumn = Stock3LevelsAccountData.LASTDIFFENCEINVENTORY_FIELD;
			updateCommand.Parameters.Add(parm_lastdiffenceinventory);

			SqlParameter parm_lastaccountbalance = new SqlParameter(LASTACCOUNTBALANCE_PARM,SqlDbType.Real);
			parm_lastaccountbalance.Direction    = ParameterDirection.Input;
			parm_lastaccountbalance.SourceColumn = Stock3LevelsAccountData.LASTACCOUNTBALANCE_FIELD;
			updateCommand.Parameters.Add(parm_lastaccountbalance);

			SqlParameter parm_thisbusinessin = new SqlParameter(THISBUSINESSIN_PARM,SqlDbType.Real);
			parm_thisbusinessin.Direction    = ParameterDirection.Input;
			parm_thisbusinessin.SourceColumn = Stock3LevelsAccountData.THISBUSINESSIN_FIELD;
			updateCommand.Parameters.Add(parm_thisbusinessin);

			SqlParameter parm_thisbusinessout = new SqlParameter(THISBUSINESSOUT_PARM,SqlDbType.Real);
			parm_thisbusinessout.Direction    = ParameterDirection.Input;
			parm_thisbusinessout.SourceColumn = Stock3LevelsAccountData.THISBUSINESSOUT_FIELD;
			updateCommand.Parameters.Add(parm_thisbusinessout);

			SqlParameter parm_thisaccountin = new SqlParameter(THISACCOUNTIN_PARM,SqlDbType.Real);
			parm_thisaccountin.Direction    = ParameterDirection.Input;
			parm_thisaccountin.SourceColumn = Stock3LevelsAccountData.THISACCOUNTIN_FIELD;
			updateCommand.Parameters.Add(parm_thisaccountin);

			SqlParameter parm_thisaccountout = new SqlParameter(THISACCOUNTOUT_PARM,SqlDbType.Real);
			parm_thisaccountout.Direction    = ParameterDirection.Input;
			parm_thisaccountout.SourceColumn = Stock3LevelsAccountData.THISACCOUNTOUT_FIELD;
			updateCommand.Parameters.Add(parm_thisaccountout);

			SqlParameter parm_thisinmoney = new SqlParameter(THISINMONEY_PARM,SqlDbType.Real);
			parm_thisinmoney.Direction    = ParameterDirection.Input;
			parm_thisinmoney.SourceColumn = Stock3LevelsAccountData.THISINMONEY_FIELD;
			updateCommand.Parameters.Add(parm_thisinmoney);

			SqlParameter parm_thisoutmoney = new SqlParameter(THISOUTMONEY_PARM,SqlDbType.Real);
			parm_thisoutmoney.Direction    = ParameterDirection.Input;
			parm_thisoutmoney.SourceColumn = Stock3LevelsAccountData.THISOUTMONEY_FIELD;
			updateCommand.Parameters.Add(parm_thisoutmoney);

			SqlParameter parm_thisindiffence = new SqlParameter(THISINDIFFENCE_PARM,SqlDbType.Real);
			parm_thisindiffence.Direction    = ParameterDirection.Input;
			parm_thisindiffence.SourceColumn = Stock3LevelsAccountData.THISINDIFFENCE_FIELD;
			updateCommand.Parameters.Add(parm_thisindiffence);

			SqlParameter parm_thisdiffencerate = new SqlParameter(THISDIFFENCERATE_PARM,SqlDbType.Real);
			parm_thisdiffencerate.Direction    = ParameterDirection.Input;
			parm_thisdiffencerate.SourceColumn = Stock3LevelsAccountData.THISDIFFENCERATE_FIELD;
			updateCommand.Parameters.Add(parm_thisdiffencerate);

			SqlParameter parm_averageprice = new SqlParameter(AVERAGEPRICE_PARM,SqlDbType.Real);
			parm_averageprice.Direction    = ParameterDirection.Input;
			parm_averageprice.SourceColumn = Stock3LevelsAccountData.AVERAGEPRICE_FIELD;
			updateCommand.Parameters.Add(parm_averageprice);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = Stock3LevelsAccountData.ACCOUNTDEP_FIELD;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = Stock3LevelsAccountData.STATUS_FIELD;
			updateCommand.Parameters.Add(parm_status);

			return updateCommand;
		}
		public bool UpdateStock3LevelsAccount(Stock3LevelsAccountData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,Stock3LevelsAccountData.STOCK3LEVELSACCOUNT_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[Stock3LevelsAccountData.STOCK3LEVELSACCOUNT_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else 
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion
		#region Delete data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_Stock3LevelsAccountData",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			//			parm_houseid.SourceColumn = Stock3LevelsAccountData.HOUSEID_FIELD;
			deleteCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			//			parm_departmentid.SourceColumn = Stock3LevelsAccountData.DEPARTMENTID_FIELD;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			//			parm_materialid.SourceColumn = Stock3LevelsAccountData.MATERIALID_FIELD;
			deleteCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_year = new SqlParameter(YEAR_PARM,SqlDbType.SmallInt);
			parm_year.Direction    = ParameterDirection.Input;
			////			parm_year.SourceColumn = Stock3LevelsAccountData.YEAR_FIELD;
			deleteCommand.Parameters.Add(parm_year);

			SqlParameter parm_month = new SqlParameter(MONTH_PARM,SqlDbType.SmallInt);
			parm_month.Direction    = ParameterDirection.Input;
			//			parm_month.SourceColumn = Stock3LevelsAccountData.MONTH_FIELD;
			deleteCommand.Parameters.Add(parm_month);

			
			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_pub_attribute.Direction    = ParameterDirection.Input;
			//			parm_pub_attribute.SourceColumn = Stock3LevelsAccountData.PUB_ATTRIBUTE_FIELD;
			deleteCommand.Parameters.Add(parm_pub_attribute);

			return deleteCommand;
		}
		public bool DeleteStock3LevelsAccount(string houseid,string departmentid,string materialid,System.Int16 year,System.Int16 month,string pub_attribute)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
		    //
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[HOUSEID_PARM].Value       = houseid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value  = departmentid;
			deleteCommand.Parameters[MATERIALID_PARM].Value    = materialid;
			deleteCommand.Parameters[YEAR_PARM].Value          = year;
			deleteCommand.Parameters[MONTH_PARM].Value         = month;
			deleteCommand.Parameters[PUB_ATTRIBUTE_PARM].Value = pub_attribute;
            //
			//  Check it if it is update failed
			//
			try
			{
				deleteCommand.Connection.Open();
				if(deleteCommand.ExecuteNonQuery()>0)
					return true;
				else
					return false;
			}
			catch
			{
				return false;
			}
			finally 
			{
				deleteCommand.Connection.Close();
				deleteCommand.Dispose();
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion
	}
}
