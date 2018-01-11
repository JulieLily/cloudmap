using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// SalesPlans 的摘要说明。
	/// </summary>
	public class SalesPlans :IDisposable
	{
		private SqlDataAdapter da ;

		private const String SALESPLANNAME_PARM			= "@SalesPlanName";
		private const String SALESPLANID_PARM			= "@SalesPlanID";
		private const String SALESPLANTYPE_PARM			= "@SalesPlanType";
		private const String BUSINESSTYPE_PARM			= "@BusinessType";
		private const String ORIGINALSALESPLANID_PARM	= "@OriginalSalesPlanID";

		private const String BEGINDATE_PARM				= "@BeginDate";
		private const String ENDDATE_PARM				= "@EndDate";
		private const String PLANSUM_PARM				= "@PlanSum";
		private const String DRAWDEPARTMENT_PARM		= "@DrawDepartment";
		private const String DRAWPERSON_PARM			= "@DrawPerson";

		private const String DRAWDATE_PARM				= "@DrawDate";
		private const String STATUS_PARM				= "@Status";
		private const String ACCOUNTDEP_PARM			= "@AccountDep";
		private const String DESCRIPTION_PARM			= "@Description";


		public SalesPlans()
		{
			
			da =new SqlDataAdapter();
			da.TableMappings.Add("Table" ,SalesPlanData.SALESPLAN_TABLE);
		}
		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 
			if(da!=null)
			{
				if(da.SelectCommand!=null)
				{
					if(da.SelectCommand.Connection!=null)
					{
						da.SelectCommand.Connection.Dispose();
					}
					da.SelectCommand.Dispose();
				}

				if(da.InsertCommand!=null)
				{
					if(da.InsertCommand.Connection!=null)
					{
						da.InsertCommand.Connection.Dispose();
					}
					da.InsertCommand.Dispose();
				}

				if(da.UpdateCommand!=null)
				{
					if(da.UpdateCommand.Connection!=null)
					{
						da.UpdateCommand.Connection.Dispose();
					}
					da.UpdateCommand.Dispose();
				}

				//				if(da.DeleteCommand!=null)
				//				{
				//					if(da.DeleteCommand.Connection!=null)
				//					{
				//						da.DeleteCommand.Connection.Dispose();
				//					}
				//					da.DeleteCommand.Dispose();
				//				}
				da.Dispose();
				da=null;
			}
		}

		#endregion

		# region 读取数据-----销售计划

		public SalesPlanData LoadSalesPlan()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			SalesPlanData data  =  new SalesPlanData();
			da.SelectCommand = GetLoadCommand();

			try
			{
				da.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}
		private SqlCommand GetLoadCommand()
		{
			SqlCommand load =  new SqlCommand("Q_SalesPlan" ,new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			return load;
		}
		#endregion

		#region 条件读取销售计划信息
		//Add by WeiTaojiang 2005-8-19
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)
			{
				strsql = "select t.*,d1.name drawdepartmentname,"
					+ "s1.name DrawPersonName "
					+ "from (select * from tbl_salesplan where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1 ON s1.id =t.drawperson ";
			}
			else 
			{
				strsql = "select t.*,d1.name drawdepartmentname,"
					+ "s1.name DrawPersonName "
					+ "from tbl_salesplan t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson ";
			}
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public SalesPlanData LoadSalesPlan(string filter)
		{
			if ( da == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			SalesPlanData data = new SalesPlanData();
			
			da.SelectCommand = GetLoadCommand(filter);
			
			try
			{
				da.Fill(data);
				
				return data;
			}
			catch
			{
				return null;				
			}
		}
		#endregion

		#region 添加数据----销售计划

		public bool InsertSalesPlan(SalesPlanData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand = GetInsertCommand();
			try
			{
				da.Update(data,SalesPlanData.SALESPLAN_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesPlanData.SALESPLAN_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				else
				{
					data.AcceptChanges();
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insert =  new SqlCommand("I_SalesPlan" ,new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_salesplanname = new SqlParameter(SALESPLANNAME_PARM ,SqlDbType.VarChar);
			parm_salesplanname.SourceColumn = SalesPlanData.SALESPLANNAME_FIELD;
			parm_salesplanname.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salesplanname);

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM ,SqlDbType.Char);
			parm_salesplanid.SourceColumn = SalesPlanData.SALESPLANID_FIELD;
			parm_salesplanid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salesplanid);

			SqlParameter parm_salesplantype = new SqlParameter(SALESPLANTYPE_PARM ,SqlDbType.Char);
			parm_salesplantype.SourceColumn = SalesPlanData.SALESPLANTYPE_FIELD;
			parm_salesplantype.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salesplantype);

			SqlParameter parm_businesstype = new SqlParameter(BUSINESSTYPE_PARM ,SqlDbType.Char);
			parm_businesstype.SourceColumn = SalesPlanData.BUSINESSTYPE_FIELD;
			parm_businesstype.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_businesstype);

			SqlParameter parm_originalsalesplanid = new SqlParameter(ORIGINALSALESPLANID_PARM ,SqlDbType.Char);
			parm_originalsalesplanid.SourceColumn = SalesPlanData.ORIGINALSALESPLANID_FIELD;
			parm_originalsalesplanid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_originalsalesplanid);


			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM ,SqlDbType.DateTime);
			parm_begindate.SourceColumn = SalesPlanData.BEGINDATE_FIELD;
			parm_begindate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_begindate);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM ,SqlDbType.DateTime);
			parm_enddate.SourceColumn = SalesPlanData.ENDDATE_FIELD;
			parm_enddate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_enddate);

			SqlParameter parm_plansum = new SqlParameter(PLANSUM_PARM ,SqlDbType.Decimal);
			parm_plansum.SourceColumn = SalesPlanData.PLANSUM_FIELD;
			parm_plansum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_plansum);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM ,SqlDbType.Char);
			parm_drawdepartment.SourceColumn = SalesPlanData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM ,SqlDbType.Char);
			parm_drawperson.SourceColumn = SalesPlanData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_drawperson);


			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM ,SqlDbType.DateTime);
			parm_drawdate.SourceColumn = SalesPlanData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM ,SqlDbType.Char);
			parm_status.SourceColumn = SalesPlanData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM ,SqlDbType.Char);
			parm_accountdep.SourceColumn = SalesPlanData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM ,SqlDbType.VarChar);
			parm_description.SourceColumn = SalesPlanData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		#endregion

		#region 更新记录----- 销售计划

		public bool UpdateSalesPlan(SalesPlanData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand = GetUpdateCommand();
			try
			{
				da.Update(data, SalesPlanData.SALESPLAN_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesPlanData.SALESPLAN_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				else
				{
					data.AcceptChanges();
					return true;
				}
			}
			catch
			{
				return false;
			}
		}

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand update =  new SqlCommand("U_SalesPlan" ,new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_salesplanname = new SqlParameter(SALESPLANNAME_PARM ,SqlDbType.VarChar);
			parm_salesplanname.SourceColumn = SalesPlanData.SALESPLANNAME_FIELD;
			parm_salesplanname.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salesplanname);

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM ,SqlDbType.Char);      // old  SalesPlanID
			parm_salesplanid.SourceColumn = SalesPlanData.SALESPLANID_FIELD;
			parm_salesplanid.SourceVersion = DataRowVersion.Original;
			parm_salesplanid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salesplanid);

			SqlParameter parm_salesplantype = new SqlParameter(SALESPLANTYPE_PARM ,SqlDbType.Char);
			parm_salesplantype.SourceColumn = SalesPlanData.SALESPLANTYPE_FIELD;
			parm_salesplantype.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salesplantype);

			SqlParameter parm_businesstype = new SqlParameter(BUSINESSTYPE_PARM ,SqlDbType.Char);
			parm_businesstype.SourceColumn = SalesPlanData.BUSINESSTYPE_FIELD;
			parm_businesstype.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_businesstype);

			SqlParameter parm_originalsalesplanid = new SqlParameter(ORIGINALSALESPLANID_PARM ,SqlDbType.Char);
			parm_originalsalesplanid.SourceColumn = SalesPlanData.ORIGINALSALESPLANID_FIELD;
			parm_originalsalesplanid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_originalsalesplanid);


			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM ,SqlDbType.DateTime);
			parm_begindate.SourceColumn = SalesPlanData.BEGINDATE_FIELD;
			parm_begindate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_begindate);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM ,SqlDbType.DateTime);
			parm_enddate.SourceColumn = SalesPlanData.ENDDATE_FIELD;
			parm_enddate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_enddate);

			SqlParameter parm_plansum = new SqlParameter(PLANSUM_PARM ,SqlDbType.Decimal);
			parm_plansum.SourceColumn = SalesPlanData.PLANSUM_FIELD;
			parm_plansum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_plansum);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM ,SqlDbType.Char);
			parm_drawdepartment.SourceColumn = SalesPlanData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM ,SqlDbType.Char);
			parm_drawperson.SourceColumn = SalesPlanData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_drawperson);


			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM ,SqlDbType.DateTime);
			parm_drawdate.SourceColumn = SalesPlanData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM ,SqlDbType.Char);
			parm_status.SourceColumn = SalesPlanData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM ,SqlDbType.Char);
			parm_accountdep.SourceColumn = SalesPlanData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM ,SqlDbType.VarChar);
			parm_description.SourceColumn = SalesPlanData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;
		}
		#endregion

		#region 删除记录---销售计划

		public bool DeleteSalesPlan(string salesplanid)
		{
			SqlCommand deletecommand = GetDeleteCommand();
			deletecommand.Parameters[SALESPLANID_PARM].Value = salesplanid;
			try
			{
				deletecommand.Connection.Open();
				if(deletecommand.ExecuteNonQuery()>0)
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
				deletecommand.Connection.Close();
				deletecommand.Connection.Dispose();
				deletecommand.Dispose();
			}
		}
		private SqlCommand GetDeleteCommand ()
		{
			SqlCommand delete =  new SqlCommand("D_SalesPlan" ,new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM ,SqlDbType.Char);      // old  SalesPlanID
			parm_salesplanid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_salesplanid);

			return delete;
 
		}
		#endregion

		#region 修改提交单状态 @@@@@--------------------------------2005-9-13 魏套江添加
		private SqlCommand GetUpdateSalesPlanRecordStatusCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_SalesPlanRecordStatus",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_salesplanid = new SqlParameter  (SALESPLANID_PARM,SqlDbType.Char);
			parm_salesplanid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_salesplanid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char);
			parm_status.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);
            
			return updateCommand;
		}
		public bool UpdateSalesPlanRecordStatus(string salesplanid,string status)
		{
			SqlCommand updateCommand = GetUpdateSalesPlanRecordStatusCommand();
			updateCommand.Parameters[SALESPLANID_PARM].Value = salesplanid;
			updateCommand.Parameters[STATUS_PARM].Value = status;

			try
			{
				updateCommand.Connection.Open();
				if(updateCommand.ExecuteNonQuery()>0)
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
				updateCommand.Connection.Close();
				updateCommand.Connection.Dispose();
				updateCommand.Dispose();
			}
		}
		#endregion

	}
}
