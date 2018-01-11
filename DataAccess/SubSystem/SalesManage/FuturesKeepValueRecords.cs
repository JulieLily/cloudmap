using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// FuturesKeepValueRecords 的摘要说明。
	/// </summary>
	public class FuturesKeepValueRecords :IDisposable
	{
		private SqlDataAdapter da;

		private const String FKVRNAME_PARM					=	"@FKVRName";
		private const String FKVRID_PARM					=	"@FKVRID";
		private const String CONTRACTID_PARM				=	"@ContractID";
		private const String BEGINDATE_PARM					=	"@BeginDate";
		private const String ENDDATE_PARM					=	"@EndDate";

		private const String SUM_PARM						=	"@Sum";
		private const String DRAWDEPARTMENT_PARM			=	"@DrawDepartment";
		private const String DRAWPERSON_PARM				=	"@DrawPerson";
		private const String DRAWDATE_PARM					=	"@DrawDate";
		private const String STATUS_PARM					=	"@Status";

		private const String ACCOUNTDEP_PARM				=	"@AccountDep";
		private const String DESCRIPTION_PARM				=	"@Description";


		public FuturesKeepValueRecords()
		{
			da =new SqlDataAdapter();
			da.TableMappings.Add("Table", FuturesKeepValueRecordData.FUTURESKEEPVALUERECORD_TABLE);
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

		#region 读取数据----期货保值单

		public FuturesKeepValueRecordData LoadFuturesKeepValueRecord()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			FuturesKeepValueRecordData data =  new FuturesKeepValueRecordData();

			da.SelectCommand =GetLoadCommand();
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
			SqlCommand load = new SqlCommand("Q_FuturesKeepValueRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;
			return load;
		}
		#endregion

		#region 条件读取信息
		//Added by YiChangxin 2005-8-29
		private SqlCommand GetsLoadCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)

				strsql = "select t.*,d1.name drawdepartmentname,s.contractname contractname,a.name DrawPersonname "
					+ "from (select * from TBL_FuturesKeepValueRecord where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.drawdepartment "
					+ "left JOIN TBL_StaffInfo a  ON a.id =t.DrawPerson "
					+ "left join tbl_salescontract s on t.contractid=s.contractid ";//
		
			else 
		
				strsql = "select t.*,d1.name drawdepartmentname,s.contractname contractname ,a.name DrawPersonname "
					+ "from TBL_FuturesKeepValueRecord t "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.drawdepartment "
					+ "left JOIN TBL_StaffInfo a  ON a.id =t.DrawPerson "
					+ "left join tbl_salescontract s on t.contractid=s.contractid ";//
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public FuturesKeepValueRecordData LoadsFuturesKeepValueRecord(string filter)
		{
			if ( da == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			FuturesKeepValueRecordData data = new FuturesKeepValueRecordData ();
			
			da.SelectCommand = GetsLoadCommand(filter);
			
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

		#region 添加记录----期货保值

		public bool InsertFuturesKeepValueRecord(FuturesKeepValueRecordData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand = GetInsertCommand();
			da.Update(data,FuturesKeepValueRecordData.FUTURESKEEPVALUERECORD_TABLE);
			if(data.HasErrors)
			{
				data.Tables[FuturesKeepValueRecordData.FUTURESKEEPVALUERECORD_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insert = new SqlCommand("I_FuturesKeepValueRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_fkvrname = new SqlParameter(FKVRNAME_PARM ,SqlDbType.VarChar);
			parm_fkvrname.SourceColumn = FuturesKeepValueRecordData.FKVRNAME_FIELD;
			parm_fkvrname.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_fkvrname);

			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM ,SqlDbType.Char);
			parm_fkvrid.SourceColumn = FuturesKeepValueRecordData.FKVRID_FIELD;
			parm_fkvrid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_fkvrid);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM ,SqlDbType.Char);
			parm_contractid.SourceColumn = FuturesKeepValueRecordData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_contractid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM ,SqlDbType.DateTime);
			parm_begindate.SourceColumn = FuturesKeepValueRecordData.BEGINDATE_FIELD;
			parm_begindate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_begindate);

			SqlParameter parm_endtime = new SqlParameter(ENDDATE_PARM ,SqlDbType.DateTime);
			parm_endtime.SourceColumn = FuturesKeepValueRecordData.ENDDATE_FIELD;
			parm_endtime.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_endtime);


			SqlParameter parm_sum = new SqlParameter(SUM_PARM ,SqlDbType.Decimal);
			parm_sum.SourceColumn = FuturesKeepValueRecordData.SUM_FIELD;
			parm_sum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_sum);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM ,SqlDbType.Char);
			parm_drawdepartment.SourceColumn = FuturesKeepValueRecordData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM ,SqlDbType.Char);
			parm_drawperson.SourceColumn = FuturesKeepValueRecordData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM ,SqlDbType.DateTime);
			parm_drawdate.SourceColumn = FuturesKeepValueRecordData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM ,SqlDbType.Char);
			parm_status.SourceColumn = FuturesKeepValueRecordData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_status);



			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM ,SqlDbType.Char);
			parm_accountdep.SourceColumn = FuturesKeepValueRecordData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM ,SqlDbType.VarChar);
			parm_description.SourceColumn = FuturesKeepValueRecordData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		#endregion

		#region 更新记录----期货保值

		public bool UpdateFuturesKeepValueRecord(FuturesKeepValueRecordData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand =GetUpdateCommand();
			da.Update(data ,FuturesKeepValueRecordData.FUTURESKEEPVALUERECORD_TABLE );
			if(data.HasErrors)
			{
				data.Tables[FuturesKeepValueRecordData.FUTURESKEEPVALUERECORD_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private  SqlCommand GetUpdateCommand()
		{
			SqlCommand update = new SqlCommand("U_FuturesKeepValueRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_fkvrname = new SqlParameter(FKVRNAME_PARM ,SqlDbType.VarChar);
			parm_fkvrname.SourceColumn = FuturesKeepValueRecordData.FKVRNAME_FIELD;
			parm_fkvrname.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_fkvrname);

			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM ,SqlDbType.Char);       //   old -----master  key [FKVRID]
			parm_fkvrid.SourceColumn = FuturesKeepValueRecordData.FKVRID_FIELD;
			parm_fkvrid.SourceVersion  = DataRowVersion.Original;
			parm_fkvrid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_fkvrid);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM ,SqlDbType.Char);
			parm_contractid.SourceColumn = FuturesKeepValueRecordData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_contractid);

			SqlParameter parm_begindate = new SqlParameter(BEGINDATE_PARM ,SqlDbType.DateTime);
			parm_begindate.SourceColumn = FuturesKeepValueRecordData.BEGINDATE_FIELD;
			parm_begindate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_begindate);

			SqlParameter parm_endtime = new SqlParameter(ENDDATE_PARM ,SqlDbType.DateTime);
			parm_endtime.SourceColumn = FuturesKeepValueRecordData.ENDDATE_FIELD;
			parm_endtime.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_endtime);


			SqlParameter parm_sum = new SqlParameter(SUM_PARM ,SqlDbType.Decimal);
			parm_sum.SourceColumn = FuturesKeepValueRecordData.SUM_FIELD;
			parm_sum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_sum);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM ,SqlDbType.Char);
			parm_drawdepartment.SourceColumn = FuturesKeepValueRecordData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM ,SqlDbType.Char);
			parm_drawperson.SourceColumn = FuturesKeepValueRecordData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM ,SqlDbType.DateTime);
			parm_drawdate.SourceColumn = FuturesKeepValueRecordData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_drawdate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM ,SqlDbType.Char);
			parm_status.SourceColumn = FuturesKeepValueRecordData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_status);



			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM ,SqlDbType.Char);
			parm_accountdep.SourceColumn = FuturesKeepValueRecordData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM ,SqlDbType.VarChar);
			parm_description.SourceColumn = FuturesKeepValueRecordData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;
		}
		#endregion

		#region 删除记录------期货保值

		public bool  DeleteFuturesKeepValueRecord(string fkvrid)
		{
			SqlCommand deletecommand = GetDeleteCommand ();
			deletecommand.Parameters[FKVRID_PARM].Value	= fkvrid;
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

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand delete = new SqlCommand("D_FuturesKeepValueRecord",new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM ,SqlDbType.Char);       //   old -----master  key [FKVRID]
			parm_fkvrid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_fkvrid);

			return delete;
		}
		#endregion
	}
}
