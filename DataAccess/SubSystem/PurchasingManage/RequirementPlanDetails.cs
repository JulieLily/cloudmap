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
	/// RequirementPlanDetails 的摘要说明。
	/// </summary>
	public class RequirementPlanDetails:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String DEPARTMENTID_PARM      = "@departmentid";
		private const String REQUIREMENTPLANID_PARM = "@requirementplanid";
		private const String MATERIALID_PARM        = "@materialid";
		private const String UNIT_PARM              = "@unit";
		private const String CHANGERATE_PARM        = "@changerate";
		private const String PLANPRICE_PARM         = "@planprice";
		private const String PLANSUM_PARM           = "@plansum";
		private const String DESCRIPTION_PARM       = "@description";
		private const String AMOUNT_PARM            = "@amount";

		//Add by XuJiansong 2005-8-29
		private const String BEGINDATE_PARM            = "@BeginDate";
		private const String ENDDATE_PARM              = "@EndDate";

		//2005-9-28 wtj 添加 
		private const String OLDMATERIALID_PARM = "@oldmaterialid";
		private const String OLDDEPARTMENTID_PARM = "@olddepartmentid";

		#region
		public RequirementPlanDetails()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",RequirementPlanDetailData.REQUIREMENTPLANDETAIL_TABLE);
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
		/// <summary>
		/// 
		/// Modifyed by XuJiansong 2005-8-29
		/// </summary>
		/// <returns></returns>
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_RequirementPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_requirementpid = new SqlParameter(REQUIREMENTPLANID_PARM, SqlDbType.Char);
			parm_requirementpid.Direction =ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_requirementpid);

			return loadCommand;
		}
		public RequirementPlanDetailData LoadRequirementPlanDetail(string requirementplanid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			RequirementPlanDetailData data = new RequirementPlanDetailData();
			dsCommand.SelectCommand = GetLoadCommand();
			dsCommand.SelectCommand.Parameters[REQUIREMENTPLANID_PARM].Value =requirementplanid;
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
			SqlCommand insertCommand = new SqlCommand("I_RequirementPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = RequirementPlanDetailData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_requirementplanid = new SqlParameter(REQUIREMENTPLANID_PARM,SqlDbType.Char);
			parm_requirementplanid.Direction    = ParameterDirection.Input;
			parm_requirementplanid.SourceColumn = RequirementPlanDetailData.REQUIREMENTPLANID_FIELD;
			insertCommand.Parameters.Add(parm_requirementplanid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = RequirementPlanDetailData.MATERIALID_FIELD;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = RequirementPlanDetailData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);
 
			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = RequirementPlanDetailData.CHANGERATE_FIELD;
			insertCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_planprice = new SqlParameter(PLANPRICE_PARM,SqlDbType.Decimal);
			parm_planprice.Direction    = ParameterDirection.Input;
			parm_planprice.SourceColumn = RequirementPlanDetailData.PLANPRICE_FIELD;
			insertCommand.Parameters.Add(parm_planprice);

			SqlParameter parm_plansum = new SqlParameter(PLANSUM_PARM,SqlDbType.Decimal);
			parm_plansum.Direction    = ParameterDirection.Input;
			parm_plansum.SourceColumn = RequirementPlanDetailData.PLANSUM_FIELD;
			insertCommand.Parameters.Add(parm_plansum);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = RequirementPlanDetailData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.Direction    = ParameterDirection.Input;
			parm_amount.SourceColumn = RequirementPlanDetailData.AMOUNT_FIELD;
			insertCommand.Parameters.Add(parm_amount);

			return insertCommand;

		}
		public bool InsertRequirementPlanDetail(RequirementPlanDetailData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,RequirementPlanDetailData.REQUIREMENTPLANDETAIL_TABLE);
            
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[RequirementPlanDetailData.REQUIREMENTPLANDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion

		#region Update data  －－－－－ 2005-9-28 修改 
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_RequirementPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_requirementplanid = new SqlParameter(REQUIREMENTPLANID_PARM,SqlDbType.Char);
			parm_requirementplanid.Direction    = ParameterDirection.Input;
			parm_requirementplanid.SourceColumn = RequirementPlanDetailData.REQUIREMENTPLANID_FIELD;
			updateCommand.Parameters.Add(parm_requirementplanid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceVersion = DataRowVersion.Current;
			parm_departmentid.SourceColumn = RequirementPlanDetailData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);
			//--------------------------------------------------------------------------------------------------------------------2005-9-28 begin
			SqlParameter parm_olddepartmentid = new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char);
			parm_olddepartmentid.Direction    = ParameterDirection.Input;
			parm_olddepartmentid.SourceVersion= DataRowVersion.Original;
			parm_olddepartmentid.SourceColumn = RequirementPlanDetailData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_olddepartmentid);
			//--------------------------------------------------------------------------------------------------------------------end

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.SourceColumn = RequirementPlanDetailData.MATERIALID_FIELD;
			updateCommand.Parameters.Add(parm_materialid);
			//--------------------------------------------------------------------------------------------------------------begin
			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char);
			parm_oldmaterialid.Direction    = ParameterDirection.Input;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			parm_oldmaterialid.SourceColumn = RequirementPlanDetailData.MATERIALID_FIELD;
			updateCommand.Parameters.Add(parm_oldmaterialid);
			//------------------------------------------------------------------------------------------------------------------end
			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = RequirementPlanDetailData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);
 
			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = RequirementPlanDetailData.CHANGERATE_FIELD;
			updateCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_planprice = new SqlParameter(PLANPRICE_PARM,SqlDbType.Decimal);
			parm_planprice.Direction    = ParameterDirection.Input;
			parm_planprice.SourceColumn = RequirementPlanDetailData.PLANPRICE_FIELD;
			updateCommand.Parameters.Add(parm_planprice);

			SqlParameter parm_plansum = new SqlParameter(PLANSUM_PARM,SqlDbType.Decimal);
			parm_plansum.Direction    = ParameterDirection.Input;
			parm_plansum.SourceColumn = RequirementPlanDetailData.PLANSUM_FIELD;
			updateCommand.Parameters.Add(parm_plansum);
	
			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.Direction    = ParameterDirection.Input;
			parm_amount.SourceColumn = RequirementPlanDetailData.AMOUNT_FIELD;
			updateCommand.Parameters.Add(parm_amount);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = RequirementPlanDetailData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;
		}
		public bool UpdateRequirementPlanDetail(RequirementPlanDetailData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,RequirementPlanDetailData.REQUIREMENTPLANDETAIL_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[RequirementPlanDetailData.REQUIREMENTPLANDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_RequirementPlanDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_requirementplanid = new SqlParameter(REQUIREMENTPLANID_PARM,SqlDbType.Char);
			parm_requirementplanid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_requirementplanid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			return deleteCommand;
		}
		public bool DeleteRequirementPlanDetail(string departmentid,string requirementplanid,string materialid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[DEPARTMENTID_PARM].Value      = departmentid;
			deleteCommand.Parameters[REQUIREMENTPLANID_PARM].Value = requirementplanid;
			deleteCommand.Parameters[MATERIALID_PARM].Value        = materialid;
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

		#region 添加的需求计划汇总添加的需求计划汇总
		private SqlCommand GetLoadSumDateCommand()
		{
			SqlCommand loadcommand = new SqlCommand("Q_RequirementPlan_Sumdata" ,new SqlConnection(ERPConfiguration.ConnectionString));
			loadcommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_begin = new SqlParameter(BEGINDATE_PARM ,SqlDbType.DateTime);
			parm_begin.Direction =ParameterDirection.Input;
			loadcommand.Parameters.Add(parm_begin);

			SqlParameter parm_end = new SqlParameter(ENDDATE_PARM ,SqlDbType.DateTime);
			parm_end.Direction =ParameterDirection.Input;
			loadcommand.Parameters.Add(parm_end);
			return loadcommand;
		}
		public RequirementPlanDetailData LoadSumData(string begindate,string enddate)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			RequirementPlanDetailData data = new RequirementPlanDetailData();
			dsCommand.SelectCommand = GetLoadSumDateCommand();
			dsCommand.SelectCommand.Parameters[BEGINDATE_PARM].Value = begindate;
			dsCommand.SelectCommand.Parameters[ENDDATE_PARM].Value = enddate;

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
	}
}
