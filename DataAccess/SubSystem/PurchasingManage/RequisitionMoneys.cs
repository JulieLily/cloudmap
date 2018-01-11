using System;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	
	public class RequisitionMoneys	:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const string RMRID_PARM          ="@rmrid";
		private const string OLDRMRID_PARM           ="@oldrmrid";

		private const string RMRNAME_PARM    ="@rmrname";
		private const string DEPARTMENTID_PARM     ="@departmentid";
		private const string BEGINDATE_PARM         ="@begindate";
		private const string ENDDATE_PARM			="@enddate";
		private const string SUM_PARM				="@sum";
		private const string REQUISITIONDATE_PARM	="@requisitiondate";
		private const string REQUISITIONPERSON_PARM ="@requisitionperson";
		private const string STATUS_PARM			="@status";
		private const string ACCOUNTDEP_PARM		="@accountdep";
		private const string DESCRIPTION_PARM		="@description";
		public RequisitionMoneys()
		{
			dsCommand= new SqlDataAdapter ();
			dsCommand.TableMappings.Add("Table",RequisitionMoneyData.REQUISITIONMONEY_TABLE);

			
		}

		#region 释放资源
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); // as a service to those who might inherit from us
		}


		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; // we're being collected, so let the GC take care of this object

			if (dsCommand != null)
			{
				if(dsCommand.SelectCommand != null)
				{
					if( dsCommand.SelectCommand.Connection != null  )
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				} 
				if(dsCommand.DeleteCommand != null)
				{
					if( dsCommand.DeleteCommand.Connection != null  )
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}    
				if(dsCommand.UpdateCommand != null)
				{
					if( dsCommand.UpdateCommand.Connection != null  )
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}    
				if(dsCommand.InsertCommand != null)
				{
					if( dsCommand.InsertCommand.Connection != null  )
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}    
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion
		
		#region Load Data
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_RequisitionMoney",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType=CommandType.StoredProcedure;

			return loadCommand;
		}
		public  RequisitionMoneyData　 LoadReqisitionMoney()
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			RequisitionMoneyData data = new RequisitionMoneyData ();
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

		#region 读取信息
		//Begin of Add by YiChangxin 2005-8-30
		private SqlCommand GetLoadsCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)

				strsql = "select t.*,d1.name depname,s.name requisitionpersonname "
					+ "from (select * from TBL_RequisitionMoney where " + filter + ") t "
					+ "left JOIN TBL_StaffInfo s ON s.id =t.requisitionperson "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.DepartmentID ";
					
		
			else 
		
				strsql = "select t.*,d1.name depname,s.name requisitionpersonname "
					+ "from TBL_RequisitionMoney t "
					+ "left JOIN TBL_StaffInfo s ON s.id =t.requisitionperson "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.DepartmentID ";
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public RequisitionMoneyData LoadsRequisitionMoney(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			RequisitionMoneyData data = new RequisitionMoneyData();
			
			dsCommand.SelectCommand = GetLoadsCommand(filter);
			
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
		//End of Add 2005-8-26
		#endregion		

		#region Insert Data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_requisitionMoney",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.Char);
			parm_rmrid.SourceColumn = RequisitionMoneyData.RMRID_FIELD;
			parm_rmrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_rmrid);


			SqlParameter parm_rmrname = new SqlParameter(RMRNAME_PARM,SqlDbType.Char);
			parm_rmrname.SourceColumn = RequisitionMoneyData.RMRNAME_FIELD;
			parm_rmrname.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_rmrname);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = RequisitionMoneyData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.Char);
			parm_begindate.SourceColumn = RequisitionMoneyData.BEGINDATE_FIELD;
			parm_begindate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM,SqlDbType.Char);
			parm_enddate.SourceColumn = RequisitionMoneyData.ENDDATE_FIELD;
			parm_enddate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_enddate);

			SqlParameter parm_sum = new SqlParameter(SUM_PARM,SqlDbType.Char);
			parm_sum.SourceColumn = RequisitionMoneyData.SUM_FIELD;
			parm_sum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_sum);

			SqlParameter parm_requisitiondate = new SqlParameter(REQUISITIONDATE_PARM,SqlDbType.Char);
			parm_requisitiondate.SourceColumn = RequisitionMoneyData.REQUISITIONDATE_FIELD;
			parm_requisitiondate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_requisitiondate);

			SqlParameter parm_requisitionperson = new SqlParameter(REQUISITIONPERSON_PARM,SqlDbType.Char);
			parm_requisitionperson.SourceColumn = RequisitionMoneyData.REQUISITIONPERSON_FIELD;
			parm_requisitionperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_requisitionperson);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.SourceColumn = RequisitionMoneyData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.SourceColumn = RequisitionMoneyData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.SourceColumn = RequisitionMoneyData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;



		}
		public bool InsertRequisitionMoney(RequisitionMoneyData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand =   GetInsertCommand();
			try
			{
				dsCommand.Update(data ,RequisitionMoneyData.REQUISITIONMONEY_TABLE);
				if(data.HasErrors)
				{
					data.Tables[RequisitionMoneyData.REQUISITIONMONEY_TABLE].GetErrors()[0].ClearErrors();
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
		#endregion

		#region Update Data
		//Begin of Modified by YiChangxin 2005-8-26
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_RequisitionMoney",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.Char);
			parm_rmrid.SourceColumn = RequisitionMoneyData.RMRID_FIELD;
			parm_rmrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_rmrid);


			SqlParameter parm_rmrname = new SqlParameter(RMRNAME_PARM,SqlDbType.Char);
			parm_rmrname.SourceColumn = RequisitionMoneyData.RMRNAME_FIELD;
			parm_rmrname.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_rmrname);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = RequisitionMoneyData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM,SqlDbType.Char);
			parm_begindate.SourceColumn = RequisitionMoneyData.BEGINDATE_FIELD;
			parm_begindate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_begindate);

			SqlParameter parm_enddate = new SqlParameter(ENDDATE_PARM,SqlDbType.Char);
			parm_enddate.SourceColumn = RequisitionMoneyData.ENDDATE_FIELD;
			parm_enddate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_enddate);

			SqlParameter parm_sum = new SqlParameter(SUM_PARM,SqlDbType.Char);
			parm_sum.SourceColumn = RequisitionMoneyData.SUM_FIELD;
			parm_sum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_sum);

			SqlParameter parm_requisitiondate = new SqlParameter(REQUISITIONDATE_PARM,SqlDbType.Char);
			parm_requisitiondate.SourceColumn = RequisitionMoneyData.REQUISITIONDATE_FIELD;
			parm_requisitiondate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_requisitiondate);

			SqlParameter parm_requisitionperson = new SqlParameter(REQUISITIONPERSON_PARM,SqlDbType.Char);
			parm_requisitionperson.SourceColumn = RequisitionMoneyData.REQUISITIONPERSON_FIELD;
			parm_requisitionperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_requisitionperson);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.SourceColumn = RequisitionMoneyData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.SourceColumn = RequisitionMoneyData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.SourceColumn = RequisitionMoneyData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;
		}

		public bool updateRequisitionMoney(RequisitionMoneyData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.UpdateCommand =   GetUpdateCommand();
			try 
			{
				dsCommand.Update(data,RequisitionMoneyData.REQUISITIONMONEY_TABLE);
				if(data.HasErrors)
				{
					data.Tables[RequisitionMoneyData.REQUISITIONMONEY_TABLE].GetErrors()[0].ClearErrors();
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
		//End of Modified 2005-8-26
		#endregion

		#region Delete Data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_RequisitionMoney",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.Char);
			parm_rmrid.SourceColumn = RequisitionMoneyData.RMRID_FIELD;
			parm_rmrid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_rmrid);

			return deleteCommand;


		}
		public bool DeleteRequisitionMoney(string rmrid)
		{
			
			SqlCommand deleteCommand =	GetDeleteCommand();
			deleteCommand.Parameters[RMRID_PARM].Value=rmrid;
			try
			{
				deleteCommand.Connection.Open();
				int i = deleteCommand.ExecuteNonQuery();
				deleteCommand.Connection.Close();
				if(i>=1)
					return true;
				else
					return false;
			}
			catch
			{
				return false;
			}
              

		}
		#endregion
			
		
		
	}
}
