using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	/// <summary>
	/// PurchasingPlanDetails 的摘要说明。
	/// </summary>
	public class PurchasingPlanDetails:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String MANUFACTURER_PARM      = "@manufacturer";
		private const String PURCHASINGPLANID_PARM  = "@purchasingplanid";
		private const String DEPARTMENTID_PARM      = "@departmentid";
		private const String MATERIALID_PARM        = "@materialid";

		private const String OLDMANUFACTURER_PARM      = "@oldmanufacturer";//2005-9-29
		private const String OLDDEPARTMENTID_PARM      = "@olddepartmentid";//2005-9-29
		private const String OLDMATERIALID_PARM        = "@oldmaterialid";//2005-9-29

		private const String AMOUNT_PARM            = "@amount";
		private const String MAINGRADE_PARM         = "@maingrade";
		private const String CURRENTSTOCK_PARM      = "@currentstock";
		private const String UNIT_PARM              = "@unit";
		private const String CHANGERATE_PARM        = "@changerate";
		private const String PRECARRIAGE_PARM       = "@precarriage";
		private const String STATIONOFDISPATCH_PARM = "@stationofdispatch";
		private const String TIMELIMIT_PARM         = "@timelimit";
		private const String MODE_PARM              = "@mode";
		private const String PRICE_PARM             = "@price";
		private const String SUM_PARM               = "@sum";
		private const String ARRIVEDTIME_PARM       = "@arrivedtime";
		private const String DESCRIPTION_PARM       = "@description";

		#region Criate Adapter
		public PurchasingPlanDetails()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",PurchasingPlanDetailData.PURCHASINGPLANDETAIL_TABLE);
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
		// Modified by XuJiansong 2005-8-29
//		private SqlCommand GetLoadCommand()
//		{
//			SqlCommand loadCommand = new SqlCommand("Q_PurchasingPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
//			loadCommand.CommandType = CommandType.StoredProcedure;
//
//			return loadCommand;
//		}
//		public PurchasingPlanDetailData LoadPurchasingPlanDetail()
//		{
//			if(dsCommand == null)
//			{
//				throw new System.EntryPointNotFoundException(GetType().FullName);
//			}
//			//
//			// Get load command and read data
//			//
//			PurchasingPlanDetailData data = new PurchasingPlanDetailData();
//			dsCommand.SelectCommand = GetLoadCommand();
//			try
//			{
//				dsCommand.Fill(data);
//				return data;
//			}
//			catch
//			{
//				return null;
//			}
//		}

		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_PurchasingPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_purchasingplanid = new SqlParameter(PURCHASINGPLANID_PARM,SqlDbType.Char);
			parm_purchasingplanid.Direction =ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_purchasingplanid);

			return loadCommand;
		}
		public PurchasingPlanDetailData LoadPurchasingPlanDetail(string purchasingplanid )
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			PurchasingPlanDetailData data = new PurchasingPlanDetailData();
			dsCommand.SelectCommand = GetLoadCommand();
			dsCommand.SelectCommand.Parameters[PURCHASINGPLANID_PARM].Value =purchasingplanid;
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
			SqlCommand insertCommand = new SqlCommand("I_PurchasingPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_manufacturer = new SqlParameter(MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.Direction    = ParameterDirection.Input;
			parm_manufacturer.SourceColumn = PurchasingPlanDetailData.MANUFACTURER_FIELD;
			insertCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_purchasingplanid = new SqlParameter(PURCHASINGPLANID_PARM,SqlDbType.Char);
			parm_purchasingplanid.Direction    = ParameterDirection.Input;
			parm_purchasingplanid.SourceColumn = PurchasingPlanDetailData.PURCHASINGPLANID_FIELD;
			insertCommand.Parameters.Add(parm_purchasingplanid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = PurchasingPlanDetailData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = PurchasingPlanDetailData.MATERIALID_FIELD;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.Direction    = ParameterDirection.Input;
			parm_amount.SourceColumn = PurchasingPlanDetailData.AMOUNT_FIELD;
			insertCommand.Parameters.Add(parm_amount);

			SqlParameter parm_maingrade = new SqlParameter(MAINGRADE_PARM,SqlDbType.Real);
			parm_maingrade.Direction    = ParameterDirection.Input;
			parm_maingrade.SourceColumn = PurchasingPlanDetailData.MAINGRADE_FIELD;
			insertCommand.Parameters.Add(parm_maingrade);

			SqlParameter parm_currentstock = new SqlParameter(CURRENTSTOCK_PARM,SqlDbType.Decimal);
			parm_currentstock.Direction    = ParameterDirection.Input;
			parm_currentstock.SourceColumn = PurchasingPlanDetailData.CURRENTSTOCK_FIELD;
			insertCommand.Parameters.Add(parm_currentstock);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = PurchasingPlanDetailData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = PurchasingPlanDetailData.CHANGERATE_FIELD;
			insertCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_precarriage = new SqlParameter(PRECARRIAGE_PARM,SqlDbType.SmallInt);
			parm_precarriage.Direction    = ParameterDirection.Input;
			parm_precarriage.SourceColumn = PurchasingPlanDetailData.PRECARRIAGE_FIELD;
			insertCommand.Parameters.Add(parm_precarriage);

			SqlParameter parm_stationofdispatch = new SqlParameter(STATIONOFDISPATCH_PARM,SqlDbType.Char);
			parm_stationofdispatch.Direction    = ParameterDirection.Input;
			parm_stationofdispatch.SourceColumn = PurchasingPlanDetailData.STATIONOFDISPATCH_FIELD;
			insertCommand.Parameters.Add(parm_stationofdispatch);

			SqlParameter parm_timelimit = new SqlParameter(TIMELIMIT_PARM,SqlDbType.Char);
			parm_timelimit.Direction    = ParameterDirection.Input;
			parm_timelimit.SourceColumn = PurchasingPlanDetailData.TIMELIMIT_FIELD;
			insertCommand.Parameters.Add(parm_timelimit);

			SqlParameter parm_mode = new SqlParameter(MODE_PARM,SqlDbType.Char);
			parm_mode.Direction    = ParameterDirection.Input;
			parm_mode.SourceColumn = PurchasingPlanDetailData.MODE_FIELD;
			insertCommand.Parameters.Add(parm_mode);

			SqlParameter parm_price = new SqlParameter(PRICE_PARM,SqlDbType.Decimal);
			parm_price.Direction    = ParameterDirection.Input;
			parm_price.SourceColumn = PurchasingPlanDetailData.PRICE_FIELD;
			insertCommand.Parameters.Add(parm_price);

			SqlParameter parm_sum = new SqlParameter(SUM_PARM,SqlDbType.Decimal);
			parm_sum.Direction    = ParameterDirection.Input;
			parm_sum.SourceColumn = PurchasingPlanDetailData.SUM_FIELD;
			insertCommand.Parameters.Add(parm_sum);

			SqlParameter parm_arrivedtime = new SqlParameter(ARRIVEDTIME_PARM,SqlDbType.DateTime);
			parm_arrivedtime.Direction    = ParameterDirection.Input;
			parm_arrivedtime.SourceColumn = PurchasingPlanDetailData.ARRIVEDTIME_FIELD;
			insertCommand.Parameters.Add(parm_arrivedtime);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = PurchasingPlanDetailData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;
		}
		public bool InsertPurchasingPlanDetail(PurchasingPlanDetailData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,PurchasingPlanDetailData.PURCHASINGPLANDETAIL_TABLE);

			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[PurchasingPlanDetailData.PURCHASINGPLANDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion

		#region Update data--//2005-9-29
		private SqlCommand GetUpdateCommand() //2005-9-29
		{
			SqlCommand updateCommand = new SqlCommand("U_PurchasingPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_manufacturer = new SqlParameter(MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.Direction    = ParameterDirection.Input;
			parm_manufacturer.SourceColumn = PurchasingPlanDetailData.MANUFACTURER_FIELD;
			parm_manufacturer.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_oldmanufacturer = new SqlParameter(OLDMANUFACTURER_PARM,SqlDbType.Char);
			parm_oldmanufacturer.Direction    = ParameterDirection.Input;
			parm_oldmanufacturer.SourceColumn = PurchasingPlanDetailData.MANUFACTURER_FIELD;
			parm_oldmanufacturer.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldmanufacturer);//2005-9-29

			SqlParameter parm_purchasingplanid = new SqlParameter(PURCHASINGPLANID_PARM,SqlDbType.Char);
			parm_purchasingplanid.Direction    = ParameterDirection.Input;
			parm_purchasingplanid.SourceColumn = PurchasingPlanDetailData.PURCHASINGPLANID_FIELD;
			updateCommand.Parameters.Add(parm_purchasingplanid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = PurchasingPlanDetailData.DEPARTMENTID_FIELD;
			parm_departmentid.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = PurchasingPlanDetailData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_olddepartmentid = new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char);
			parm_olddepartmentid.Direction    = ParameterDirection.Input;
			parm_olddepartmentid.SourceColumn = PurchasingPlanDetailData.DEPARTMENTID_FIELD;
			parm_olddepartmentid.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_olddepartmentid);//2005-9-29

			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char);
			parm_oldmaterialid.Direction    = ParameterDirection.Input;
			parm_oldmaterialid.SourceColumn = PurchasingPlanDetailData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldmaterialid);//2005-9-29

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.Direction    = ParameterDirection.Input;
			parm_amount.SourceColumn = PurchasingPlanDetailData.AMOUNT_FIELD;
			updateCommand.Parameters.Add(parm_amount);

			SqlParameter parm_maingrade = new SqlParameter(MAINGRADE_PARM,SqlDbType.Real);
			parm_maingrade.Direction    = ParameterDirection.Input;
			parm_maingrade.SourceColumn = PurchasingPlanDetailData.MAINGRADE_FIELD;
			updateCommand.Parameters.Add(parm_maingrade);

			SqlParameter parm_currentstock = new SqlParameter(CURRENTSTOCK_PARM,SqlDbType.Decimal);
			parm_currentstock.Direction    = ParameterDirection.Input;
			parm_currentstock.SourceColumn = PurchasingPlanDetailData.CURRENTSTOCK_FIELD;
			updateCommand.Parameters.Add(parm_currentstock);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = PurchasingPlanDetailData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = PurchasingPlanDetailData.CHANGERATE_FIELD;
			updateCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_precarriage = new SqlParameter(PRECARRIAGE_PARM,SqlDbType.SmallInt);
			parm_precarriage.Direction    = ParameterDirection.Input;
			parm_precarriage.SourceColumn = PurchasingPlanDetailData.PRECARRIAGE_FIELD;
			updateCommand.Parameters.Add(parm_precarriage);

			SqlParameter parm_stationofdispatch = new SqlParameter(STATIONOFDISPATCH_PARM,SqlDbType.Char);
			parm_stationofdispatch.Direction    = ParameterDirection.Input;
			parm_stationofdispatch.SourceColumn = PurchasingPlanDetailData.STATIONOFDISPATCH_FIELD;
			updateCommand.Parameters.Add(parm_stationofdispatch);

			SqlParameter parm_timelimit = new SqlParameter(TIMELIMIT_PARM,SqlDbType.Char);
			parm_timelimit.Direction    = ParameterDirection.Input;
			parm_timelimit.SourceColumn = PurchasingPlanDetailData.TIMELIMIT_FIELD;
			updateCommand.Parameters.Add(parm_timelimit);

			SqlParameter parm_mode = new SqlParameter(MODE_PARM,SqlDbType.Char);
			parm_mode.Direction    = ParameterDirection.Input;
			parm_mode.SourceColumn = PurchasingPlanDetailData.MODE_FIELD;
			updateCommand.Parameters.Add(parm_mode);

			SqlParameter parm_price = new SqlParameter(PRICE_PARM,SqlDbType.Decimal);
			parm_price.Direction    = ParameterDirection.Input;
			parm_price.SourceColumn = PurchasingPlanDetailData.PRICE_FIELD;
			updateCommand.Parameters.Add(parm_price);

			SqlParameter parm_sum = new SqlParameter(SUM_PARM,SqlDbType.Decimal);
			parm_sum.Direction    = ParameterDirection.Input;
			parm_sum.SourceColumn = PurchasingPlanDetailData.SUM_FIELD;
			updateCommand.Parameters.Add(parm_sum);

			SqlParameter parm_arrivedtime = new SqlParameter(ARRIVEDTIME_PARM,SqlDbType.DateTime);
			parm_arrivedtime.Direction    = ParameterDirection.Input;
			parm_arrivedtime.SourceColumn = PurchasingPlanDetailData.ARRIVEDTIME_FIELD;
			updateCommand.Parameters.Add(parm_arrivedtime);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = PurchasingPlanDetailData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;
		}
		public bool UpdatePurchasingPlanDetail(PurchasingPlanDetailData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,PurchasingPlanDetailData.PURCHASINGPLANDETAIL_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[PurchasingPlanDetailData.PURCHASINGPLANDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_PurchasingPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_manufacturer = new SqlParameter(MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.Direction    = ParameterDirection.Input;  
			deleteCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_purchasingplanid = new SqlParameter(PURCHASINGPLANID_PARM,SqlDbType.Char);
			parm_purchasingplanid.Direction    = ParameterDirection.Input;			 
			deleteCommand.Parameters.Add(parm_purchasingplanid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			 
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			return deleteCommand;
		}
		public bool DeletePurchasingPlanDetail(string manufacturer,string purchasingplanid,string departmentid,string materialid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[MANUFACTURER_PARM].Value     = manufacturer;
			deleteCommand.Parameters[PURCHASINGPLANID_PARM].Value = purchasingplanid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value     = departmentid;
			deleteCommand.Parameters[MATERIALID_PARM].Value       = materialid;
			//
			//  Check it if it update failed
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
