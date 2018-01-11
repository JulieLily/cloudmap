using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	/// <summary>
	/// TakeStocks 的摘要说明。
	/// </summary>
	public class TakeStocks :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDHOUSEID_PARM		 = "@oldHouseID";
        private const String OLDDEPARTMENTID_PARM   = "@oldDepartmentID";

		private const String TSRID_PARM          = "@TSRID";
		private const String TSRNAME_PARM		 = "@TSRName";
		private const String HOUSEID_PARM		 = "@HouseID";
		private const String DEPARTMENTID_PARM   = "@DepartmentID";
		private const String ACCOUNTDEP_PARM     = "@AccountDep";

		private const String TSDATE_PARM         = "@TSDate";
		private const String ACCOUNTDATE_PARM    = "@AccountDate";
		private const String CHECKDATE_PARM		 = "@CheckDate";
		private const String CHECKER_PARM		 = "@Checker";
		private const String SUPERVISO_PARM		 = "@Superviso";
		
		private const String FILLER_PARM		 = "@Filler";
		private const String FILLDATE_PARM		 = "@FillDate";
		private const String STATUS_PARM	     = "@Status";
		private const String DESCRIPTION_PARM    = "@Description";


		public TakeStocks()
		{
			da=new SqlDataAdapter();
			da.TableMappings.Add("Table",TakeStockData.TAKESTOCK_TABLE);
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

		# region 读取记录-----库房盘点单

		public TakeStockData LoadTakeStock()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			TakeStockData data = new TakeStockData();
			da.SelectCommand=GetLoadCommand();
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
			SqlCommand load =new SqlCommand("Q_TakeStock",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType=CommandType.StoredProcedure;

			return load;
		}
		#endregion


		 // ycx 加的读取数据信息

		#region  读取数据信息 
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)
				strsql = "select t.*,d1.name departmentname,s.name housename,"
					+ "s1.name Supervisoname,s2.name checkername,s3.name Fillername "
					+ "from (select * from tbl_TakeStock where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.Superviso "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t. Filler "
					
					+ "left join tbl_storehouse s on t.houseid=s.houseid ";
			else
				strsql = "select t.*,d1.name departmentname,s.name housename,"
					+ "s1.name Supervisoname,s2.name checkername,s3.name Fillername "
					+ "from tbl_TakeStock t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.Superviso "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.Filler "
					+ "left join tbl_storehouse s on t.houseid=s.houseid ";
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public TakeStockData LoadTakeStock(string filter)
		{
			if ( da == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			TakeStockData data = new TakeStockData ();
			
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

		# region 添加记录-----库房盘点单

		public bool InsertTakeStock(TakeStockData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand  = GetInsertCommand();
			da.Update(data,TakeStockData.TAKESTOCK_TABLE);
			if(data.HasErrors)
			{
				data.Tables[TakeStockData.TAKESTOCK_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand insert =new SqlCommand("I_TakeStock",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_tsrid = new SqlParameter(TSRID_PARM,SqlDbType.Char,28);
			parm_tsrid.Direction=ParameterDirection.Input;
			parm_tsrid.SourceColumn=TakeStockData.TSRID_FIELD;
			insert.Parameters.Add(parm_tsrid);

			SqlParameter parm_tsname = new SqlParameter(TSRNAME_PARM,SqlDbType.Char,40);
			parm_tsname.Direction=ParameterDirection.Input;
			parm_tsname.SourceColumn=TakeStockData.TSRNAME_FIELD;
			insert.Parameters.Add(parm_tsname);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char,4);
			parm_houseid.Direction=ParameterDirection.Input;
			parm_houseid.SourceColumn=TakeStockData.HOUSEID_FIELD;
			insert.Parameters.Add(parm_houseid);

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.Direction=ParameterDirection.Input;
			parm_departid.SourceColumn=TakeStockData.DEPARTMENTID_FIELD;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char,10);
			parm_accountdep.Direction=ParameterDirection.Input;
			parm_accountdep.SourceColumn=TakeStockData.ACCOUNTDEP_FIELD;
			insert.Parameters.Add(parm_accountdep);



			SqlParameter parm_tsdate = new SqlParameter(TSDATE_PARM,SqlDbType.DateTime,8);
			parm_tsdate.Direction=ParameterDirection.Input;
			parm_tsdate.SourceColumn=TakeStockData.TSDATE_FIELD;
			insert.Parameters.Add(parm_tsdate);

			SqlParameter parm_accountdate = new SqlParameter(ACCOUNTDATE_PARM,SqlDbType.DateTime,8);
			parm_accountdate.Direction=ParameterDirection.Input;
			parm_accountdate.SourceColumn=TakeStockData.ACCOUNTDATE_FIELD;
			insert.Parameters.Add(parm_accountdate);

			SqlParameter parm_checkdate = new SqlParameter(CHECKDATE_PARM,SqlDbType.DateTime,8);
			parm_checkdate.Direction=ParameterDirection.Input;
			parm_checkdate.SourceColumn=TakeStockData.CHECKDATE_FIELD;
			insert.Parameters.Add(parm_checkdate);

			SqlParameter parm_checker = new SqlParameter(CHECKER_PARM,SqlDbType.Char,18);
			parm_checker.Direction=ParameterDirection.Input;
			parm_checker.SourceColumn=TakeStockData.CHECKER_FIELD;
			insert.Parameters.Add(parm_checker);

			SqlParameter parm_superviso = new SqlParameter(SUPERVISO_PARM,SqlDbType.Char,18);
			parm_superviso.Direction=ParameterDirection.Input;
			parm_superviso.SourceColumn=TakeStockData.SUPERVISO_FIELD;
			insert.Parameters.Add(parm_superviso);



			SqlParameter parm_filler = new SqlParameter(FILLER_PARM,SqlDbType.Char,18);
			parm_filler.Direction=ParameterDirection.Input;
			parm_filler.SourceColumn=TakeStockData.FILLER_FIELD;
			insert.Parameters.Add(parm_filler);

			SqlParameter parm_filldate = new SqlParameter(FILLDATE_PARM,SqlDbType.DateTime,8);
			parm_filldate.Direction=ParameterDirection.Input;
			parm_filldate.SourceColumn=TakeStockData.FILLDATE_FIELD;
			insert.Parameters.Add(parm_filldate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char,10);
			parm_status.Direction=ParameterDirection.Input;
			parm_status.SourceColumn=TakeStockData.STATUS_FIELD;
			insert.Parameters.Add(parm_status);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar,200);
			parm_description.Direction=ParameterDirection.Input;
			parm_description.SourceColumn=TakeStockData.DESCRIPTION_FIELD;
			insert.Parameters.Add(parm_description);

			return insert;

		}
		#endregion

		#region 更新记录-----库房盘点单

		public bool  UpdateTakeStock(TakeStockData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand=GetUpdateCommand();
			da.Update(data,TakeStockData.TAKESTOCK_TABLE);
			if(data.HasErrors)
			{
				data.Tables[TakeStockData.TAKESTOCK_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand update =new SqlCommand("U_TakeStock",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_tsrid = new SqlParameter(TSRID_PARM,SqlDbType.Char,28);  //--current tsrid
			parm_tsrid.Direction=ParameterDirection.Input;
			parm_tsrid.SourceColumn=TakeStockData.TSRID_FIELD;
			parm_tsrid.SourceVersion=DataRowVersion.Original;
			update.Parameters.Add(parm_tsrid);

			SqlParameter parm_tsname = new SqlParameter(TSRNAME_PARM,SqlDbType.Char,40);
			parm_tsname.Direction=ParameterDirection.Input;
			parm_tsname.SourceColumn=TakeStockData.TSRNAME_FIELD;
			update.Parameters.Add(parm_tsname);

			

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char,4);
			parm_houseid.Direction=ParameterDirection.Input;
			parm_houseid.SourceColumn=TakeStockData.HOUSEID_FIELD;
			parm_houseid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_houseid);

			

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.Direction=ParameterDirection.Input;
			parm_departid.SourceColumn=TakeStockData.DEPARTMENTID_FIELD;
			parm_departid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_departid);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char,10);
			parm_accountdep.Direction=ParameterDirection.Input;
			parm_accountdep.SourceColumn=TakeStockData.ACCOUNTDEP_FIELD;
			update.Parameters.Add(parm_accountdep);



			SqlParameter parm_tsdate = new SqlParameter(TSDATE_PARM,SqlDbType.DateTime,8);
			parm_tsdate.Direction=ParameterDirection.Input;
			parm_tsdate.SourceColumn=TakeStockData.TSDATE_FIELD;
			update.Parameters.Add(parm_tsdate);

			SqlParameter parm_accountdate = new SqlParameter(ACCOUNTDATE_PARM,SqlDbType.DateTime,8);
			parm_accountdate.Direction=ParameterDirection.Input;
			parm_accountdate.SourceColumn=TakeStockData.ACCOUNTDATE_FIELD;
			update.Parameters.Add(parm_accountdate);

			SqlParameter parm_checkdate = new SqlParameter(CHECKDATE_PARM,SqlDbType.DateTime,8);
			parm_checkdate.Direction=ParameterDirection.Input;
			parm_checkdate.SourceColumn=TakeStockData.CHECKDATE_FIELD;
			update.Parameters.Add(parm_checkdate);

			SqlParameter parm_checker = new SqlParameter(CHECKER_PARM,SqlDbType.Char,18);
			parm_checker.Direction=ParameterDirection.Input;
			parm_checker.SourceColumn=TakeStockData.CHECKER_FIELD;
			update.Parameters.Add(parm_checker);

			SqlParameter parm_superviso = new SqlParameter(SUPERVISO_PARM,SqlDbType.Char,18);
			parm_superviso.Direction=ParameterDirection.Input;
			parm_superviso.SourceColumn=TakeStockData.SUPERVISO_FIELD;
			update.Parameters.Add(parm_superviso);



			SqlParameter parm_filler = new SqlParameter(FILLER_PARM,SqlDbType.Char,18);
			parm_filler.Direction=ParameterDirection.Input;
			parm_filler.SourceColumn=TakeStockData.FILLER_FIELD;
			update.Parameters.Add(parm_filler);

			SqlParameter parm_filldate = new SqlParameter(FILLDATE_PARM,SqlDbType.DateTime,8);
			parm_filldate.Direction=ParameterDirection.Input;
			parm_filldate.SourceColumn=TakeStockData.FILLDATE_FIELD;
			update.Parameters.Add(parm_filldate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char,10);
			parm_status.Direction=ParameterDirection.Input;
			parm_status.SourceColumn=TakeStockData.STATUS_FIELD;
			update.Parameters.Add(parm_status);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar,200);
			parm_description.Direction=ParameterDirection.Input;
			parm_description.SourceColumn=TakeStockData.DESCRIPTION_FIELD;
			update.Parameters.Add(parm_description);

			return update;
		}
		#endregion

		//ycx 对删除做了修改!

		#region 删除记录----库位盘点单

		public bool DeleteTakeStock(string tsrid)
		{
			SqlCommand deletecommand=GetDeleteCommand();
			deletecommand.Parameters[TSRID_PARM].Value=tsrid;
			
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
			SqlCommand delete = new SqlCommand("D_TakeStock",new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_tsrid = new SqlParameter(TSRID_PARM,SqlDbType.Char,28);  //--current tsrid
			parm_tsrid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_tsrid);

			

			return delete;

		}
		#endregion
	}
}
