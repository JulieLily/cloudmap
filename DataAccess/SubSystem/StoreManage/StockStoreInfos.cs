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
	/// StockStoreInfos 的摘要说明。
	/// </summary>
	public class StockStoreInfos :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDMATERIALID_PARM        = "@oldMaterialID";
		private const String OLDDEPARTMENTID_PARM      = "@oldDepartmentID";

		private const String DEPARTMENTID_PARM      = "@DepartmentID";
		private const String MATERIALID_PARM        = "@MaterialID";
		private const String DRAWMENT_PARM          = "@DrawDepartment";
		private const String HIGHERLIMIT_PARM       = "@HigherLimit";
		private const String LOWERLIMIT_PARM        = "@LowerLimit";

		private const String WARNHIGHERLIMIT_PARM   = "@WarningHigherLimit";
		private const String WARNLOWERLIMIT_PARM    = "@WarningLowerLimit";
		private const String SAFESTOCK_PARM         = "@SafeStock";
		private const String OUTMODE_PARM           = "@OutMode";
		private const String DRAWPERSON_PARM        = "@DrawPerson";

		private const String DRAWDATE_PARM          = "@DrawDate";
		private const String BATCHTRACK_PARM        = "@BatchTrack";
		private const String DESCRIPTION_PARM       = "@Description";

		public StockStoreInfos()
		{
			da=new SqlDataAdapter();
			da.TableMappings.Add("Table",StockStoreInfoData.STOCKSTOREINFO_TABLE);
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

	
		# region 读取数据----库存储备信息

		public StockStoreInfoData LoadStockStoreInfo()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			StockStoreInfoData data=new StockStoreInfoData();
			
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
			SqlCommand load=new SqlCommand("Q_StockStoreInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType=CommandType.StoredProcedure;

			return load ;
		}
		#endregion

		#region 添加------库存储备信息

		public bool InsertStockStoreInfo(StockStoreInfoData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			da.InsertCommand=GetInsertCommand();
			da.Update(data,StockStoreInfoData.STOCKSTOREINFO_TABLE);
			if(data.HasErrors)
			{
				data.Tables[StockStoreInfoData.STOCKSTOREINFO_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand insert=new SqlCommand("I_StockStoreInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.SourceColumn=StockStoreInfoData.DEPARTMENTID_FIELD;
			parm_departid.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_materid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materid.SourceColumn=StockStoreInfoData.MATERIALID_FIELD;
			parm_materid.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_materid);


			SqlParameter parm_drawment = new SqlParameter(DRAWMENT_PARM,SqlDbType.Char,10);
			parm_drawment.SourceColumn=StockStoreInfoData.DRAWMENT_FIELD;
			parm_drawment.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_drawment);

			SqlParameter parm_higherlimit = new SqlParameter(HIGHERLIMIT_PARM,SqlDbType.Real,4);
			parm_higherlimit.SourceColumn=StockStoreInfoData.HIGHERLIMIT_FIELD;
			parm_higherlimit.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_higherlimit);

			SqlParameter parm_lowerlimit = new SqlParameter(LOWERLIMIT_PARM,SqlDbType.Real,4);
			parm_lowerlimit.SourceColumn=StockStoreInfoData.LOWERLIMIT_FIELD;
			parm_lowerlimit.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_lowerlimit);


			SqlParameter parm_warnhighlimit = new SqlParameter(WARNHIGHERLIMIT_PARM,SqlDbType.Real,4);
			parm_warnhighlimit.SourceColumn=StockStoreInfoData.WARNHIGHERLIMIT_FIELD;
			parm_warnhighlimit.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_warnhighlimit);

			SqlParameter parm_warnlowerlimit = new SqlParameter(WARNLOWERLIMIT_PARM,SqlDbType.Real,4);
			parm_warnlowerlimit.SourceColumn=StockStoreInfoData.WARNLOWERLIMIT_FIELD;
			parm_warnlowerlimit.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_warnlowerlimit);

			SqlParameter parm_safestock = new SqlParameter(SAFESTOCK_PARM,SqlDbType.Real,4);
			parm_safestock.SourceColumn=StockStoreInfoData.SAFESTOCK_FIELD;
			parm_safestock.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_safestock);

			SqlParameter parm_outmode = new SqlParameter(OUTMODE_PARM,SqlDbType.Char,8);
			parm_outmode.SourceColumn=StockStoreInfoData.OUTMODE_FIELD;
			parm_outmode.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_outmode);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char,18);
			parm_drawperson.SourceColumn=StockStoreInfoData.DRAWPERSON_FIELD;
			parm_drawperson.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_drawperson);


			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime,8);
			parm_drawdate.SourceColumn=StockStoreInfoData.DRAWDATE_FIELD;
			parm_drawdate.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_drawdate);

			SqlParameter parm_batchtrack = new SqlParameter(BATCHTRACK_PARM,SqlDbType.Char,6);
			parm_batchtrack.SourceColumn=StockStoreInfoData.BATCHTRACK_FIELD;
			parm_batchtrack.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_batchtrack);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar,200);
			parm_description.SourceColumn=StockStoreInfoData.DESCRIPTION_FIELD;
			parm_description.Direction=ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		#endregion

		#region 更新数据----库存储备信息


		public bool UpdateStockStoreInfo(StockStoreInfoData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand=GetUpdateCommand();
			da.Update(data,StockStoreInfoData.STOCKSTOREINFO_TABLE);
			if(data.HasErrors)
			{
				data.Tables[StockStoreInfoData.STOCKSTOREINFO_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand update  = new SqlCommand("U_StockStoreInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType=CommandType.StoredProcedure;


			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);  //  部门ID 新值----Current
			parm_departid.SourceColumn=StockStoreInfoData.DEPARTMENTID_FIELD;
			parm_departid.SourceVersion=DataRowVersion.Current;
			parm_departid.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_departid);

			SqlParameter parm_olddepartid = new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char,10);  //  部门ID 原值----Original  
			parm_olddepartid.SourceColumn=StockStoreInfoData.DEPARTMENTID_FIELD;
			parm_olddepartid.SourceVersion=DataRowVersion.Original;
			parm_olddepartid.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_olddepartid);

			SqlParameter parm_materid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);   //  物料ID 新值----Current
			parm_materid.SourceColumn=StockStoreInfoData.MATERIALID_FIELD;
			parm_materid.SourceVersion=DataRowVersion.Current;
			parm_materid.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_materid);

			SqlParameter parm_oldmaterid = new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char,20);   //  物料ID 原值----Origianl
			parm_oldmaterid.SourceColumn=StockStoreInfoData.MATERIALID_FIELD;
			parm_oldmaterid.SourceVersion=DataRowVersion.Original;
			parm_oldmaterid.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_oldmaterid);


			SqlParameter parm_drawment = new SqlParameter(DRAWMENT_PARM,SqlDbType.Char,10);
			parm_drawment.SourceColumn=StockStoreInfoData.DRAWMENT_FIELD;
			parm_drawment.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_drawment);

			SqlParameter parm_higherlimit = new SqlParameter(HIGHERLIMIT_PARM,SqlDbType.Real,4);
			parm_higherlimit.SourceColumn=StockStoreInfoData.HIGHERLIMIT_FIELD;
			parm_higherlimit.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_higherlimit);

			SqlParameter parm_lowerlimit = new SqlParameter(LOWERLIMIT_PARM,SqlDbType.Real,4);
			parm_lowerlimit.SourceColumn=StockStoreInfoData.LOWERLIMIT_FIELD;
			parm_lowerlimit.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_lowerlimit);


			SqlParameter parm_warnhighlimit = new SqlParameter(WARNHIGHERLIMIT_PARM,SqlDbType.Real,4);
			parm_warnhighlimit.SourceColumn=StockStoreInfoData.WARNHIGHERLIMIT_FIELD;
			parm_warnhighlimit.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_warnhighlimit);

			SqlParameter parm_warnlowerlimit = new SqlParameter(WARNLOWERLIMIT_PARM,SqlDbType.Real,4);
			parm_warnlowerlimit.SourceColumn=StockStoreInfoData.WARNLOWERLIMIT_FIELD;
			parm_warnlowerlimit.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_warnlowerlimit);

			SqlParameter parm_safestock = new SqlParameter(SAFESTOCK_PARM,SqlDbType.Real,4);
			parm_safestock.SourceColumn=StockStoreInfoData.SAFESTOCK_FIELD;
			parm_safestock.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_safestock);

			SqlParameter parm_outmode = new SqlParameter(OUTMODE_PARM,SqlDbType.Char,8);
			parm_outmode.SourceColumn=StockStoreInfoData.OUTMODE_FIELD;
			parm_outmode.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_outmode);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char,18);
			parm_drawperson.SourceColumn=StockStoreInfoData.DRAWPERSON_FIELD;
			parm_drawperson.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_drawperson);


			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime,8);
			parm_drawdate.SourceColumn=StockStoreInfoData.DRAWDATE_FIELD;
			parm_drawdate.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_drawdate);

			SqlParameter parm_batchtrack = new SqlParameter(BATCHTRACK_PARM,SqlDbType.Char,6);
			parm_batchtrack.SourceColumn=StockStoreInfoData.BATCHTRACK_FIELD;
			parm_batchtrack.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_batchtrack);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar,200);
			parm_description.SourceColumn=StockStoreInfoData.DESCRIPTION_FIELD;
			parm_description.Direction=ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;
			 
		}
		#endregion


		#region 删除数据 ---库存储备信息

		public  bool DeleteStockStoreInfo(string departid ,string materialid)
		{
			SqlCommand deletecommand=GetDeleteCommand();
			deletecommand.Parameters[DEPARTMENTID_PARM].Value=departid;
			deletecommand.Parameters[MATERIALID_PARM].Value=materialid;
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
			SqlCommand del=new SqlCommand("D_StockStoreInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			del.CommandType=CommandType.StoredProcedure;


			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);  //  部门ID  
			parm_departid.Direction=ParameterDirection.Input;
			del.Parameters.Add(parm_departid);

			SqlParameter parm_materid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);   //  物料ID  
			parm_materid.Direction=ParameterDirection.Input;
			del.Parameters.Add(parm_materid);

			return del;

		}
		#endregion
	}
}
