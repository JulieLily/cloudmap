using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// CustomerVisitRecords 的摘要说明。
	/// </summary>
	public class CustomerVisitRecords:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String CVRID_PARM          = "@cvrid";
		private const String CVRNAME_PARM        = "@cvrname";
		private const String CUSTOMERNO_PARM     = "@customerno";
		private const String TYPE_PARM           = "@type";
		private const String GOAL_PARM           = "@goal";
		private const String CONTEXT_PARM        = "@context";
		private const String BEGINTIME_PARM      = "@begintime";
		private const String ENDTIME_PARM        = "@endtime";
		private const String MASTERSTAFF_PARM    = "@masterstaff";
		private const String CUSTOMERSTAFF_PARM  = "@customerstaff";
		private const String GIFT_PARM           = "@gift";
		private const String COSTSUM_PARM        = "@costsum";
		private const String RESULT_PARM         = "@result";
		private const String ADDRESS_PARM        = "@address";
		private const String DRAWDEPARTMENT_PARM = "@drawdepartment";
		private const String DRAWPERSON_PARM     = "@drawperson";
		private const String DRAWDATE_PARM       = "@drawdate";
		private const String STATUS_PARM         = "@status";
		private const String ACCOUNTDEP_PARM     = "@accountdep";
		private const String DESCRIPTION_PARM    = "@description";

		#region Create Adapter
		public CustomerVisitRecords()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",CustomerVisitRecordData.CUSTOMERVISITRECORD_TABLE);
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
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)

				strsql = "select t.*,c.name customername,s.name drawpersonname,d.name drawdepartmentname "
					+ "from (select * from tbl_customervisitrecord where " + filter + ") t "
					+ "left join tbl_correspondentcompany c on t.customerno=c.companyid and c.departmentid = t.drawdepartment "
					+ "left join TBL_StaffInfo s on  t.drawPerson = s.ID "
					+ "left JOIN TBL_DepartmentInfo d ON d.DepartmentID =t.DrawDepartment ";

		
			else 
		
				strsql = "select t.*,c.name customername,s.name drawpersonname,d.name drawdepartmentname "
					+ "from tbl_customervisitrecord t "
					+ "left join tbl_correspondentcompany c on t.customerno=c.companyid and c.departmentid = t.drawdepartment "
					+ "left join TBL_StaffInfo s on  t.drawPerson = s.ID "
					+ "left JOIN TBL_DepartmentInfo d ON d.DepartmentID =t.DrawDepartment ";
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}
			 public CustomerVisitRecordData LoadCustomerVisitRecord(string filter)
			 {
				 if ( dsCommand == null )
				 {
					 throw new System.ObjectDisposedException( GetType().FullName );
				 }            
				 CustomerVisitRecordData data = new CustomerVisitRecordData();
			
				 dsCommand.SelectCommand = GetLoadCommand(filter);
			
//				 try
				 {
					 dsCommand.Fill(data);
				
					 return data;
				 }
//				 catch
				 {
					 return null;				
				 }
			 }
		#endregion

		#region Insert data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_CustomerVisitRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_cvrid = new SqlParameter(CVRID_PARM,SqlDbType.Char);
			parm_cvrid.Direction    = ParameterDirection.Input;
			parm_cvrid.SourceColumn = CustomerVisitRecordData.CVRID_FIELD;
			insertCommand.Parameters.Add(parm_cvrid);

			SqlParameter parm_cvrname = new SqlParameter(CVRNAME_PARM,SqlDbType.VarChar);
			parm_cvrname.Direction    = ParameterDirection.Input;
			parm_cvrname.SourceColumn = CustomerVisitRecordData.CVRNAME_FIELD;
			insertCommand.Parameters.Add(parm_cvrname);

			
			SqlParameter parm_customerno = new SqlParameter(CUSTOMERNO_PARM,SqlDbType.Char);
			parm_customerno.Direction    = ParameterDirection.Input;
			parm_customerno.SourceColumn = CustomerVisitRecordData.CUSTOMERNO_FIELD;
			insertCommand.Parameters.Add(parm_customerno);

			SqlParameter parm_type = new SqlParameter(TYPE_PARM,SqlDbType.Char);
			parm_type.Direction    = ParameterDirection.Input;
			parm_type.SourceColumn = CustomerVisitRecordData.TYPE_FIELD;
			insertCommand.Parameters.Add(parm_type);

			SqlParameter parm_goal = new SqlParameter(GOAL_PARM,SqlDbType.VarChar);
			parm_goal.Direction    = ParameterDirection.Input;
			parm_goal.SourceColumn = CustomerVisitRecordData.GOAL_FIELD;
			insertCommand.Parameters.Add(parm_goal);

			SqlParameter parm_context = new SqlParameter(CONTEXT_PARM,SqlDbType.VarChar);
			parm_context.Direction    = ParameterDirection.Input;
			parm_context.SourceColumn = CustomerVisitRecordData.CONTEXT_FIELD;
			insertCommand.Parameters.Add(parm_context);

			SqlParameter parm_begintime = new SqlParameter(BEGINTIME_PARM,SqlDbType.DateTime);
			parm_begintime.Direction    = ParameterDirection.Input;
			parm_begintime.SourceColumn = CustomerVisitRecordData.BEGINTIME_FIELD;
			insertCommand.Parameters.Add(parm_begintime);

			SqlParameter parm_endtime = new SqlParameter(ENDTIME_PARM,SqlDbType.DateTime);
			parm_endtime.Direction    = ParameterDirection.Input;
			parm_endtime.SourceColumn = CustomerVisitRecordData.ENDTIME_FIELD;
			insertCommand.Parameters.Add(parm_endtime);

			SqlParameter parm_masterstaff = new SqlParameter(MASTERSTAFF_PARM,SqlDbType.VarChar);
			parm_masterstaff.Direction    = ParameterDirection.Input;
			parm_masterstaff.SourceColumn = CustomerVisitRecordData.MASTERSTAFF_FIELD;
			insertCommand.Parameters.Add(parm_masterstaff);

			SqlParameter parm_customerstaff = new SqlParameter(CUSTOMERSTAFF_PARM,SqlDbType.VarChar);
			parm_customerstaff.Direction    = ParameterDirection.Input;
			parm_customerstaff.SourceColumn = CustomerVisitRecordData.CUSTOMERSTAFF_FIELD;
			insertCommand.Parameters.Add(parm_customerstaff);

			SqlParameter parm_gift = new SqlParameter(GIFT_PARM,SqlDbType.VarChar);
			parm_gift.Direction    = ParameterDirection.Input;
			parm_gift.SourceColumn = CustomerVisitRecordData.GIFT_FIELD;
			insertCommand.Parameters.Add(parm_gift);

			SqlParameter parm_costsum = new SqlParameter(COSTSUM_PARM,SqlDbType.Real);
			parm_costsum.Direction    = ParameterDirection.Input;
			parm_costsum.SourceColumn = CustomerVisitRecordData.COSTSUM_FIELD;
			insertCommand.Parameters.Add(parm_costsum);

			SqlParameter parm_result = new SqlParameter(RESULT_PARM,SqlDbType.VarChar);
			parm_result.Direction    = ParameterDirection.Input;
			parm_result.SourceColumn = CustomerVisitRecordData.RESULT_FIELD;
			insertCommand.Parameters.Add(parm_result);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM,SqlDbType.VarChar);
			parm_address.Direction    = ParameterDirection.Input;
			parm_address.SourceColumn = CustomerVisitRecordData.ADDRESS_FIELD;
			insertCommand.Parameters.Add(parm_address);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = CustomerVisitRecordData.DRAWDEPARTMENT_FIELD;
			insertCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = CustomerVisitRecordData.DRAWPERSON_FIELD;
			insertCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = CustomerVisitRecordData.DRAWDATE_FIELD;
			insertCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = CustomerVisitRecordData.STATUS_FIELD;
			insertCommand.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = CustomerVisitRecordData.ACCOUNTDEP_FIELD;
			insertCommand.Parameters.Add(parm_accountdep);


			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = CustomerVisitRecordData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;
		}
		public bool InsertCustomerVisitRecord(CustomerVisitRecordData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();

			dsCommand.Update(info,CustomerVisitRecordData.CUSTOMERVISITRECORD_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[CustomerVisitRecordData.CUSTOMERVISITRECORD_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand updateCommand = new SqlCommand("U_CustomerVisitRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_cvrid = new SqlParameter(CVRID_PARM,SqlDbType.Char);
			parm_cvrid.Direction    = ParameterDirection.Input;
			parm_cvrid.SourceColumn = CustomerVisitRecordData.CVRID_FIELD;
			updateCommand.Parameters.Add(parm_cvrid);

			SqlParameter parm_cvrname = new SqlParameter(CVRNAME_PARM,SqlDbType.VarChar);
			parm_cvrname.Direction    = ParameterDirection.Input;
			parm_cvrname.SourceColumn = CustomerVisitRecordData.CVRNAME_FIELD;
			updateCommand.Parameters.Add(parm_cvrname);

			
			SqlParameter parm_customerno = new SqlParameter(CUSTOMERNO_PARM,SqlDbType.Char);
			parm_customerno.Direction    = ParameterDirection.Input;
			parm_customerno.SourceColumn = CustomerVisitRecordData.CUSTOMERNO_FIELD;
			updateCommand.Parameters.Add(parm_customerno);

			SqlParameter parm_type = new SqlParameter(TYPE_PARM,SqlDbType.Char);
			parm_type.Direction    = ParameterDirection.Input;
			parm_type.SourceColumn = CustomerVisitRecordData.TYPE_FIELD;
			updateCommand.Parameters.Add(parm_type);

			SqlParameter parm_goal = new SqlParameter(GOAL_PARM,SqlDbType.VarChar);
			parm_goal.Direction    = ParameterDirection.Input;
			parm_goal.SourceColumn = CustomerVisitRecordData.GOAL_FIELD;
			updateCommand.Parameters.Add(parm_goal);

			SqlParameter parm_context = new SqlParameter(CONTEXT_PARM,SqlDbType.VarChar);
			parm_context.Direction    = ParameterDirection.Input;
			parm_context.SourceColumn = CustomerVisitRecordData.CONTEXT_FIELD;
			updateCommand.Parameters.Add(parm_context);

			SqlParameter parm_begintime = new SqlParameter(BEGINTIME_PARM,SqlDbType.DateTime);
			parm_begintime.Direction    = ParameterDirection.Input;
			parm_begintime.SourceColumn = CustomerVisitRecordData.BEGINTIME_FIELD;
			updateCommand.Parameters.Add(parm_begintime);

			SqlParameter parm_endtime = new SqlParameter(ENDTIME_PARM,SqlDbType.DateTime);
			parm_endtime.Direction    = ParameterDirection.Input;
			parm_endtime.SourceColumn = CustomerVisitRecordData.ENDTIME_FIELD;
			updateCommand.Parameters.Add(parm_endtime);

			SqlParameter parm_masterstaff = new SqlParameter(MASTERSTAFF_PARM,SqlDbType.VarChar);
			parm_masterstaff.Direction    = ParameterDirection.Input;
			parm_masterstaff.SourceColumn = CustomerVisitRecordData.MASTERSTAFF_FIELD;
			updateCommand.Parameters.Add(parm_masterstaff);

			SqlParameter parm_customerstaff = new SqlParameter(CUSTOMERSTAFF_PARM,SqlDbType.VarChar);
			parm_customerstaff.Direction    = ParameterDirection.Input;
			parm_customerstaff.SourceColumn = CustomerVisitRecordData.CUSTOMERSTAFF_FIELD;
			updateCommand.Parameters.Add(parm_customerstaff);

			SqlParameter parm_gift = new SqlParameter(GIFT_PARM,SqlDbType.VarChar);
			parm_gift.Direction    = ParameterDirection.Input;
			parm_gift.SourceColumn = CustomerVisitRecordData.GIFT_FIELD;
			updateCommand.Parameters.Add(parm_gift);

			SqlParameter parm_costsum = new SqlParameter(COSTSUM_PARM,SqlDbType.Real);
			parm_costsum.Direction    = ParameterDirection.Input;
			parm_costsum.SourceColumn = CustomerVisitRecordData.COSTSUM_FIELD;
			updateCommand.Parameters.Add(parm_costsum);

			SqlParameter parm_result = new SqlParameter(RESULT_PARM,SqlDbType.VarChar);
			parm_result.Direction    = ParameterDirection.Input;
			parm_result.SourceColumn = CustomerVisitRecordData.RESULT_FIELD;
			updateCommand.Parameters.Add(parm_result);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM,SqlDbType.VarChar);
			parm_address.Direction    = ParameterDirection.Input;
			parm_address.SourceColumn = CustomerVisitRecordData.ADDRESS_FIELD;
			updateCommand.Parameters.Add(parm_address);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = CustomerVisitRecordData.DRAWDEPARTMENT_FIELD;
			updateCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = CustomerVisitRecordData.DRAWPERSON_FIELD;
			updateCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = CustomerVisitRecordData.DRAWDATE_FIELD;
			updateCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = CustomerVisitRecordData.STATUS_FIELD;
			updateCommand.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = CustomerVisitRecordData.ACCOUNTDEP_FIELD;
			updateCommand.Parameters.Add(parm_accountdep);


			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = CustomerVisitRecordData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;

		}
		public bool UpdateCustomerVisitRecord(CustomerVisitRecordData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,CustomerVisitRecordData.CUSTOMERVISITRECORD_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[CustomerVisitRecordData.CUSTOMERVISITRECORD_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_CustomerVisitRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_cvrid = new SqlParameter(CVRID_PARM,SqlDbType.Char);
			parm_cvrid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_cvrid);

			return deleteCommand;
		}
		public bool DeleteCustomerVisitRecord(string cvrid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[CVRID_PARM].Value = cvrid;
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
