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
	/// RequirementPlans 的摘要说明。
	/// </summary>
	public class RequirementPlans:IDisposable
	{
		private SqlDataAdapter dsCommand;


		private const String REQUIREMENTPLANID_PARM = "@requirementplanid";
		private const String PLANNAME_PARM          = "@planname";
		private const String PLANTYPE_PARM          = "@plantype";
		private const String BEGINDATE_PARM         = "@begindate";
		private const String ENDDATE_PARM           = "@enddate";
		private const String BUSINESSTYPE_PARM      = "@businesstype";
		private const String PLANSUM_PARM           = "@plansum";
		private const String DRAWDEPARTMENT_PARM    = "@drawdepartment";
		private const String DRAWPERSON_PARM        = "@drawperson";
		private const String DRAWDATE_PARM          = "@drawdate";
		private const String DESCRIPTION_PARM       = "@description";
		private const String ACCOUNTDEP_PARM        = "@accountdep";
		private const String STATUS_PARM            = "@status";


		#region Create data
		public RequirementPlans()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",RequirementPlanData.REQUIREMENTPLAN_TABLE);
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

		#region Read data		  // 改用 具有filter 的条件读取所有的记录  	//Modified by XuJiansong 2005-9-13
		//		private SqlCommand GetLoadCommand()
		//		{
		//			SqlCommand loadCommand = new SqlCommand("Q_RequirementPlan",new SqlConnection(ERPConfiguration.ConnectionString));
		//			loadCommand.CommandType = CommandType.StoredProcedure;
		//
		//			return loadCommand;
		//		}


		private SqlCommand GetLoadCommand(string filter) //   // 改用 具有filter 的条件读取所有的记录  	//Modified by XuJiansong 2005-9-13
		{
			string sql;
			if(filter==""||filter==null)
				sql = " select  t.* ,d1.Name DrawDepartmentName  ,s1.name drawpersonname from " 
					+" tbl_requirementplan  t  left join TBL_DepartmentInfo d1 on d1.DepartmentID =t.drawDepartment "
					+" left join TBL_StaffInfo s1 on s1.id =t.DrawPerson ";
					 
			else
				sql = " select  t.* ,d1.Name DrawDepartmentName  ,s1.name drawpersonname from " 
					+" (select * from tbl_requirementplan where "+filter+")  t  left join TBL_DepartmentInfo d1 on d1.DepartmentID =t.drawDepartment "
					+" left join TBL_StaffInfo s1 on s1.id =t.DrawPerson ";

				 
			SqlCommand loadCommand = new SqlCommand(sql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.Text;

			return loadCommand;
		}

		public RequirementPlanData LoadRequirementPlan(string filter)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			RequirementPlanData data = new RequirementPlanData();
			dsCommand.SelectCommand = GetLoadCommand(filter);
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
			SqlCommand insertCommand = new SqlCommand("I_RequirementPlan",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_requirementplanid = new SqlParameter(REQUIREMENTPLANID_PARM,SqlDbType.Char);
			parm_requirementplanid.Direction    = ParameterDirection.Input;
			parm_requirementplanid.SourceColumn = RequirementPlanData.REQUIREMENTPLANID_FIELD;
			insertCommand.Parameters.Add(parm_requirementplanid);

			SqlParameter parm_planname = new SqlParameter(PLANNAME_PARM,SqlDbType.VarChar);
			parm_planname.Direction    = ParameterDirection.Input;
			parm_planname.SourceColumn = RequirementPlanData.PLANNAME_FIELD;
			insertCommand.Parameters.Add(parm_planname);

			SqlParameter parm_plantype = new SqlParameter(PLANTYPE_PARM,SqlDbType.Char);
			parm_plantype.Direction    = ParameterDirection.Input;
			parm_plantype.SourceColumn = RequirementPlanData.PLANTYPE_FIELD;
			insertCommand.Parameters.Add(parm_plantype);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.DateTime);
			parm_begindate.Direction    = ParameterDirection.Input;
			parm_begindate.SourceColumn = RequirementPlanData.BEGINDATE_FIELD;
			insertCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM,SqlDbType.DateTime);
			parm_enddate.Direction    = ParameterDirection.Input;
			parm_enddate.SourceColumn = RequirementPlanData.ENDDATE_FIELD;
			insertCommand.Parameters.Add(parm_enddate);

			SqlParameter parm_businesstype = new SqlParameter(BUSINESSTYPE_PARM,SqlDbType.Char);
			parm_businesstype.Direction    = ParameterDirection.Input;
			parm_businesstype.SourceColumn = RequirementPlanData.BUSINESSTYPE_FIELD;
			insertCommand.Parameters.Add(parm_businesstype);

			SqlParameter parm_plansum = new SqlParameter(PLANSUM_PARM,SqlDbType.Decimal);
			parm_plansum.Direction    = ParameterDirection.Input;
			parm_plansum.SourceColumn = RequirementPlanData.PLANSUM_FIELD;
			insertCommand.Parameters.Add(parm_plansum);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = RequirementPlanData.DRAWDEPARTMENT_FIELD;
			insertCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = RequirementPlanData.DRAWPERSON_FIELD;
			insertCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = RequirementPlanData.DRAWDATE_FIELD;
			insertCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = RequirementPlanData.STATUS_FIELD;
			insertCommand.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = RequirementPlanData.ACCOUNTDEP_FIELD;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = RequirementPlanData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);
                                                    
			return insertCommand;

		}
		public bool InsertRequirementPlan(RequirementPlanData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,RequirementPlanData.REQUIREMENTPLAN_TABLE);
            //
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[RequirementPlanData.REQUIREMENTPLAN_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion

		#region Update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_RequirementPlan",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_requirementplanid = new SqlParameter(REQUIREMENTPLANID_PARM,SqlDbType.Char);
			parm_requirementplanid.Direction    = ParameterDirection.Input;
			parm_requirementplanid.SourceColumn = RequirementPlanData.REQUIREMENTPLANID_FIELD;
			updateCommand.Parameters.Add(parm_requirementplanid);

			SqlParameter parm_planname = new SqlParameter(PLANNAME_PARM,SqlDbType.VarChar);
			parm_planname.Direction    = ParameterDirection.Input;
			parm_planname.SourceColumn = RequirementPlanData.PLANNAME_FIELD;
			updateCommand.Parameters.Add(parm_planname);

			SqlParameter parm_plantype = new SqlParameter(PLANTYPE_PARM,SqlDbType.Char);
			parm_plantype.Direction    = ParameterDirection.Input;
			parm_plantype.SourceColumn = RequirementPlanData.PLANTYPE_FIELD;
			updateCommand.Parameters.Add(parm_plantype);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.DateTime);
			parm_begindate.Direction    = ParameterDirection.Input;
			parm_begindate.SourceColumn = RequirementPlanData.BEGINDATE_FIELD;
			updateCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM,SqlDbType.DateTime);
			parm_enddate.Direction    = ParameterDirection.Input;
			parm_enddate.SourceColumn = RequirementPlanData.ENDDATE_FIELD;
			updateCommand.Parameters.Add(parm_enddate);

			SqlParameter parm_businesstype = new SqlParameter(BUSINESSTYPE_PARM,SqlDbType.Char);
			parm_businesstype.Direction    = ParameterDirection.Input;
			parm_businesstype.SourceColumn = RequirementPlanData.BUSINESSTYPE_FIELD;
			updateCommand.Parameters.Add(parm_businesstype);

			SqlParameter parm_plansum = new SqlParameter(PLANSUM_PARM,SqlDbType.Decimal);
			parm_plansum.Direction    = ParameterDirection.Input;
			parm_plansum.SourceColumn = RequirementPlanData.PLANSUM_FIELD;
			updateCommand.Parameters.Add(parm_plansum);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = RequirementPlanData.DRAWDEPARTMENT_FIELD;
			updateCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = RequirementPlanData.DRAWPERSON_FIELD;
			updateCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = RequirementPlanData.DRAWDATE_FIELD;
			updateCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = RequirementPlanData.STATUS_FIELD;
			updateCommand.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = RequirementPlanData.ACCOUNTDEP_FIELD;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = RequirementPlanData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);
                                                    
			return updateCommand;
		}
		public bool UpdateRequirementPlan(RequirementPlanData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,RequirementPlanData.REQUIREMENTPLAN_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[RequirementPlanData.REQUIREMENTPLAN_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_RequirementPlan",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_requirementplanid = new SqlParameter(REQUIREMENTPLANID_PARM,SqlDbType.Char);
			parm_requirementplanid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_requirementplanid);

			return deleteCommand;
		}
		public bool DeleteRequirementPlan(string requirementplanid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[REQUIREMENTPLANID_PARM].Value = requirementplanid;
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
