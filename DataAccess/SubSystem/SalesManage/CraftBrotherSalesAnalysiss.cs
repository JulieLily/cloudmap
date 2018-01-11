using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// CraftBrotherSalesAnalysiss 的摘要说明。
	/// </summary>
	public class CraftBrotherSalesAnalysiss:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String AREAID_PARM         = "@areaid";
		private const String CRAFTBROTHERID_PARM = "@craftbrotherid";
		private const String DEPARTMENTID_PARM   = "@departmentid";
		private const String BEGINDATE_PARM      = "@begindate";
		private const String PRODUCTNAME_PARM    = "@productname";

		private const String MODEL_PARM          = "@model";
		private const String ENDDATE_PARM        = "@enddate";
		private const String OUTAMOUNT_PARM      = "@outamount";
		private const String INAMOUNT_PARM       = "@inamount";
		private const String UNIT_PARM           = "@unit";
		private const String SALESPRICE_PARM     = "@salesprice";
		private const String FUTURESPRICE_PARM   = "@futuresprice";
		private const String CYCLE_PARM          = "@cycle";
		private const String CHARACTERISTIC_PARM = "@characteristic";
		private const String DESCRIPTION_PARM    = "@description";

		//2005-9-5 魏套江添加
		private const String OLDBEGINDATE_PARM = "@oldbegindate";

		#region Create Adapter
		public CraftBrotherSalesAnalysiss()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",CraftBrotherSalesAnalysisData.CRAFTBROTHERSALESANALYSIS_TABLE);
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
			SqlCommand loadCommand = new SqlCommand("Q_CraftBrotherSalesAnalysis",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_craftbrotherid);

			
			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_departmentid);

			return loadCommand;
		}
		public CraftBrotherSalesAnalysisData LoadCraftBrotherSalesAnalysis(string craftbrotherid,string departmentid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			CraftBrotherSalesAnalysisData data = new CraftBrotherSalesAnalysisData();

			dsCommand.SelectCommand = GetLoadCommand();
			dsCommand.SelectCommand.Parameters[CRAFTBROTHERID_PARM].Value = craftbrotherid;
			dsCommand.SelectCommand.Parameters[DEPARTMENTID_PARM].Value = departmentid;

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

		#region Insert data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_CraftBrotherSalesAnalysis",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_areaid = new SqlParameter(AREAID_PARM,SqlDbType.Char);
			parm_areaid.Direction    = ParameterDirection.Input;
			parm_areaid.SourceColumn = CraftBrotherSalesAnalysisData.AREAID_FIELD;
			insertCommand.Parameters.Add(parm_areaid);

			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			parm_craftbrotherid.SourceColumn = CraftBrotherSalesAnalysisData.CRAFTBROTHERID_FIELD;
			insertCommand.Parameters.Add(parm_craftbrotherid);

			
			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = CraftBrotherSalesAnalysisData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.DateTime);
			parm_begindate.Direction    = ParameterDirection.Input;
			parm_begindate.SourceColumn = CraftBrotherSalesAnalysisData.BEGINDATE_FIELD;
			insertCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_productname = new SqlParameter(PRODUCTNAME_PARM,SqlDbType.VarChar);
			parm_productname.Direction    = ParameterDirection.Input;
			parm_productname.SourceColumn = CraftBrotherSalesAnalysisData.PRODUCTNAME_FIELD;
			insertCommand.Parameters.Add(parm_productname);

			SqlParameter parm_model = new SqlParameter(MODEL_PARM,SqlDbType.VarChar);
			parm_model.Direction    = ParameterDirection.Input;
			parm_model.SourceColumn = CraftBrotherSalesAnalysisData.MODEL_FIELD;
			insertCommand.Parameters.Add(parm_model);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM,SqlDbType.DateTime);
			parm_enddate.Direction    = ParameterDirection.Input;
			parm_enddate.SourceColumn = CraftBrotherSalesAnalysisData.ENDDATE_FIELD;
			insertCommand.Parameters.Add(parm_enddate);

			SqlParameter parm_outamount = new SqlParameter(OUTAMOUNT_PARM,SqlDbType.Decimal);
			parm_outamount.Direction    = ParameterDirection.Input;
			parm_outamount.SourceColumn = CraftBrotherSalesAnalysisData.OUTAMOUNT_FIELD;
			insertCommand.Parameters.Add(parm_outamount);

			SqlParameter parm_inamount = new SqlParameter(INAMOUNT_PARM,SqlDbType.Decimal);
			parm_inamount.Direction    = ParameterDirection.Input;
			parm_inamount.SourceColumn = CraftBrotherSalesAnalysisData.INAMOUNT_FIELD;
			insertCommand.Parameters.Add(parm_inamount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = CraftBrotherSalesAnalysisData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);

			SqlParameter parm_salesprice = new SqlParameter(SALESPRICE_PARM,SqlDbType.Decimal);
			parm_salesprice.Direction    = ParameterDirection.Input;
			parm_salesprice.SourceColumn = CraftBrotherSalesAnalysisData.SALESPRICE_FIELD;
			insertCommand.Parameters.Add(parm_salesprice);

			SqlParameter parm_futuresprice = new SqlParameter(FUTURESPRICE_PARM,SqlDbType.Decimal);
			parm_futuresprice.Direction    = ParameterDirection.Input;
			parm_futuresprice.SourceColumn = CraftBrotherSalesAnalysisData.FUTURESPRICE_FIELD;
			insertCommand.Parameters.Add(parm_futuresprice);

			SqlParameter parm_cycle = new SqlParameter(CYCLE_PARM,SqlDbType.VarChar);
			parm_cycle.Direction    = ParameterDirection.Input;
			parm_cycle.SourceColumn = CraftBrotherSalesAnalysisData.CYCLE_FIELD;
			insertCommand.Parameters.Add(parm_cycle);

			SqlParameter parm_characteristic = new SqlParameter(CHARACTERISTIC_PARM,SqlDbType.VarChar);
			parm_characteristic.Direction    = ParameterDirection.Input;
			parm_characteristic.SourceColumn = CraftBrotherSalesAnalysisData.CHARACTERISTIC_FIELD;
			insertCommand.Parameters.Add(parm_characteristic);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = CraftBrotherSalesAnalysisData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;

		}
		public bool InsertCraftBrotherSalesAnalysis(CraftBrotherSalesAnalysisData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,CraftBrotherSalesAnalysisData.CRAFTBROTHERSALESANALYSIS_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[CraftBrotherSalesAnalysisData.CRAFTBROTHERSALESANALYSIS_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion

		//Modified by WeiTaojiang 2005-9-5
		#region Update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_CraftBrotherSalesAnalysis",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_areaid = new SqlParameter(AREAID_PARM,SqlDbType.Char);
			parm_areaid.Direction    = ParameterDirection.Input;
			parm_areaid.SourceColumn = CraftBrotherSalesAnalysisData.AREAID_FIELD;
			//			parm_areaid.SourceVersion = DataRowVersion.Current;                     //---------------魏套江添加
			updateCommand.Parameters.Add(parm_areaid);

			//			SqlParameter parm_oldareaid = new SqlParameter(OLDAREAID_PARM,SqlDbType.Char);   //----------------2005-9-5 魏套江添加
			//			parm_oldareaid.Direction    = ParameterDirection.Input;
			//			parm_oldareaid.SourceColumn = CraftBrotherSalesAnalysisData.AREAID_FIELD;
			//			parm_oldareaid.SourceVersion = DataRowVersion.Original;
			//			updateCommand.Parameters.Add(parm_oldareaid);


			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			parm_craftbrotherid.SourceColumn = CraftBrotherSalesAnalysisData.CRAFTBROTHERID_FIELD;
			updateCommand.Parameters.Add(parm_craftbrotherid);

			
			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = CraftBrotherSalesAnalysisData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.DateTime);
			parm_begindate.Direction    = ParameterDirection.Input;
			parm_begindate.SourceColumn = CraftBrotherSalesAnalysisData.BEGINDATE_FIELD;
			parm_begindate.SourceVersion = DataRowVersion.Current;                         //------------------------魏套江添加
			updateCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_oldbegindate = new SqlParameter(OLDBEGINDATE_PARM,SqlDbType.DateTime);  //------------2005-9-5 魏套江添加
			parm_oldbegindate.Direction    = ParameterDirection.Input;
			parm_oldbegindate.SourceColumn = CraftBrotherSalesAnalysisData.BEGINDATE_FIELD;
			parm_oldbegindate.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldbegindate);

			SqlParameter parm_productname = new SqlParameter(PRODUCTNAME_PARM,SqlDbType.VarChar);
			parm_productname.Direction    = ParameterDirection.Input;
			parm_productname.SourceColumn = CraftBrotherSalesAnalysisData.PRODUCTNAME_FIELD;
			updateCommand.Parameters.Add(parm_productname);

			SqlParameter parm_model = new SqlParameter(MODEL_PARM,SqlDbType.VarChar);
			parm_model.Direction    = ParameterDirection.Input;
			parm_model.SourceColumn = CraftBrotherSalesAnalysisData.MODEL_FIELD;
			updateCommand.Parameters.Add(parm_model);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM,SqlDbType.DateTime);
			parm_enddate.Direction    = ParameterDirection.Input;
			parm_enddate.SourceColumn = CraftBrotherSalesAnalysisData.ENDDATE_FIELD;
			updateCommand.Parameters.Add(parm_enddate);

			SqlParameter parm_outamount = new SqlParameter(OUTAMOUNT_PARM,SqlDbType.Decimal);
			parm_outamount.Direction    = ParameterDirection.Input;
			parm_outamount.SourceColumn = CraftBrotherSalesAnalysisData.OUTAMOUNT_FIELD;
			updateCommand.Parameters.Add(parm_outamount);

			SqlParameter parm_inamount = new SqlParameter(INAMOUNT_PARM,SqlDbType.Decimal);
			parm_inamount.Direction    = ParameterDirection.Input;
			parm_inamount.SourceColumn = CraftBrotherSalesAnalysisData.INAMOUNT_FIELD;
			updateCommand.Parameters.Add(parm_inamount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = CraftBrotherSalesAnalysisData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);

			SqlParameter parm_salesprice = new SqlParameter(SALESPRICE_PARM,SqlDbType.Decimal);
			parm_salesprice.Direction    = ParameterDirection.Input;
			parm_salesprice.SourceColumn = CraftBrotherSalesAnalysisData.SALESPRICE_FIELD;
			updateCommand.Parameters.Add(parm_salesprice);

			SqlParameter parm_futuresprice = new SqlParameter(FUTURESPRICE_PARM,SqlDbType.Decimal);
			parm_futuresprice.Direction    = ParameterDirection.Input;
			parm_futuresprice.SourceColumn = CraftBrotherSalesAnalysisData.FUTURESPRICE_FIELD;
			updateCommand.Parameters.Add(parm_futuresprice);

			SqlParameter parm_cycle = new SqlParameter(CYCLE_PARM,SqlDbType.VarChar);
			parm_cycle.Direction    = ParameterDirection.Input;
			parm_cycle.SourceColumn = CraftBrotherSalesAnalysisData.CYCLE_FIELD;
			updateCommand.Parameters.Add(parm_cycle);

			SqlParameter parm_characteristic = new SqlParameter(CHARACTERISTIC_PARM,SqlDbType.VarChar);
			parm_characteristic.Direction    = ParameterDirection.Input;
			parm_characteristic.SourceColumn = CraftBrotherSalesAnalysisData.CHARACTERISTIC_FIELD;
			updateCommand.Parameters.Add(parm_characteristic);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = CraftBrotherSalesAnalysisData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;
		}
		public bool UpdateCraftBrotherSalesAnalysis(CraftBrotherSalesAnalysisData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,CraftBrotherSalesAnalysisData.CRAFTBROTHERSALESANALYSIS_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[CraftBrotherSalesAnalysisData.CRAFTBROTHERSALESANALYSIS_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_CraftBrotherSalesAnalysis",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_areaid = new SqlParameter(AREAID_PARM,SqlDbType.Char);
			parm_areaid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_areaid);

			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_craftbrotherid);

			
			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = CraftBrotherSalesAnalysisData.DEPARTMENTID_FIELD;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.DateTime);
			parm_begindate.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_productname = new SqlParameter(PRODUCTNAME_PARM,SqlDbType.VarChar);
			parm_productname.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_productname);

			return deleteCommand;
		}
		public bool DeleteCraftBrotherSalesAnalysis(string areaid,string craftbrotherid,string departmentid,DateTime begindate,string productname)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[AREAID_PARM].Value         = areaid;
			deleteCommand.Parameters[CRAFTBROTHERID_PARM].Value = craftbrotherid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value   = departmentid;
			deleteCommand.Parameters[BEGINDATE_PARM].Value      = begindate;
			deleteCommand.Parameters[PRODUCTNAME_PARM].Value    = productname;

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
