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
	/// StorehouseStockAccounts 的摘要说明。
	/// </summary>
	public class StorehouseStockAccounts :IDisposable
	{
		private SqlDataAdapter da;

		private const String  OLDYEAR_PARM							= "@oldYear";
		private const String  OLDMONTH_PARM						    = "@oldMonth";

		private const String  OLDHOUSEID_PARM						= "@oldHouseID";
		private const String  OLDMATERIALID_PARM					= "@oldMaterialID";
	    private const String  OLDDEPARTMENTID_PARM					= "@oldDepartmentID";
		private const String  OLDPUB_ATTRIBUTE_PARM			        = "@oldPUB_Attribute";

		private const String  HOUSEID_PARM						= "@HouseID";
		private const String  MATERIALID_PARM					= "@MaterialID";
		private const String  DEPARTMENTID_PARM					= "@DepartmentID";
		private const String  PUB_ATTRIBUTE_PARM			    = "@PUB_Attribute";
		private const String  ACCOUNTDEP_PARM					= "@AccountDep";

		private const String  YEAR_PARM							= "@Year";
		private const String  MONTH_PARM						= "@Month";
		private const String  LASTMARGIN_PARM					= "@LastMargin";
		private const String  THISIN_PARM						= "@ThisIn";
		private const String  THISOUT_PARM						= "@ThisOut";

		private const String  UNIT_PARM							= "@Unit";
		private const String  CHANGERATE_PARM					= "@ChangeRate";
		private const String  STATUS_PARM						= "@Status";

		public StorehouseStockAccounts()
		{
		  da=new SqlDataAdapter();
		  da.TableMappings.Add("Table",StorehouseStockAccountData.STOREHOUSESTOCKACCOUNT_TABLE);
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

		# region 读取数据----库房库存帐

		public StorehouseStockAccountData LoadStorehouseStockAccount()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			StorehouseStockAccountData data = new StorehouseStockAccountData();
			da.SelectCommand= GetLoadCommand();
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
			SqlCommand load  =  new SqlCommand("Q_StorehouseStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			return load;
		}
		#endregion

		#region  添加记录-----库房库存帐

		public bool InsertStorehouseStockAccount(StorehouseStockAccountData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand  = GetInsertCommand();
			da.Update(data,StorehouseStockAccountData.STOREHOUSESTOCKACCOUNT_TABLE);
			if(data.HasErrors)
			{
				data.Tables[StorehouseStockAccountData.STOREHOUSESTOCKACCOUNT_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand insert = new SqlCommand("I_StorehouseStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char,4);
			parm_houseid.Direction =ParameterDirection.Input;
			parm_houseid.SourceColumn =StorehouseStockAccountData.HOUSEID_FIELD;
			insert.Parameters.Add(parm_houseid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materialid.Direction =ParameterDirection.Input;
			parm_materialid.SourceColumn =StorehouseStockAccountData.MATERIALID_FIELD;
			insert.Parameters.Add(parm_materialid);

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.Direction =ParameterDirection.Input;
			parm_departid.SourceColumn =StorehouseStockAccountData.DEPARTMENTID_FIELD;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,18);
			parm_pub_attribute.Direction =ParameterDirection.Input;
			parm_pub_attribute.SourceColumn =StorehouseStockAccountData.PUB_ATTRIBUTE_FIELD;
			insert.Parameters.Add(parm_pub_attribute);

			SqlParameter parm_pub_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char,10);
			parm_pub_accountdep.Direction =ParameterDirection.Input;
			parm_pub_accountdep.SourceColumn =StorehouseStockAccountData.ACCOUNTDEP_FIELD;
			insert.Parameters.Add(parm_pub_accountdep);



			SqlParameter parm_pub_year = new SqlParameter(YEAR_PARM,SqlDbType.SmallInt,2);
			parm_pub_year.Direction =ParameterDirection.Input;
			parm_pub_year.SourceColumn =StorehouseStockAccountData.YEAR_FIELD;
			insert.Parameters.Add(parm_pub_year);

			SqlParameter parm_pub_month = new SqlParameter(MONTH_PARM,SqlDbType.SmallInt,2);
			parm_pub_month.Direction =ParameterDirection.Input;
			parm_pub_month.SourceColumn =StorehouseStockAccountData.MONTH_FIELD;
			insert.Parameters.Add(parm_pub_month);

			SqlParameter parm_pub_lastmargin = new SqlParameter(LASTMARGIN_PARM,SqlDbType.Decimal,9);
			parm_pub_lastmargin.Direction =ParameterDirection.Input;
			parm_pub_lastmargin.SourceColumn =StorehouseStockAccountData.LASTMARGIN_FIELD;
			insert.Parameters.Add(parm_pub_lastmargin);

			SqlParameter parm_pub_thisin = new SqlParameter(THISIN_PARM,SqlDbType.Decimal,9);
			parm_pub_thisin.Direction =ParameterDirection.Input;
			parm_pub_thisin.SourceColumn =StorehouseStockAccountData.THISIN_FIELD;
			insert.Parameters.Add(parm_pub_thisin);

			SqlParameter parm_pub_thisout = new SqlParameter(THISOUT_PARM,SqlDbType.Decimal,9);
			parm_pub_thisout.Direction =ParameterDirection.Input;
			parm_pub_thisout.SourceColumn =StorehouseStockAccountData.THISOUT_FIELD;
			insert.Parameters.Add(parm_pub_thisout);



			SqlParameter parm_pub_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char,10);
			parm_pub_unit.Direction =ParameterDirection.Input;
			parm_pub_unit.SourceColumn =StorehouseStockAccountData.UNIT_FIELD;
			insert.Parameters.Add(parm_pub_unit);

			SqlParameter parm_pub_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real,4);
			parm_pub_changerate.Direction =ParameterDirection.Input;
			parm_pub_changerate.SourceColumn =StorehouseStockAccountData.CHANGERATE_FIELD;
			insert.Parameters.Add(parm_pub_changerate);

			SqlParameter parm_pub_status = new SqlParameter(STATUS_PARM,SqlDbType.Char,16);
			parm_pub_status.Direction =ParameterDirection.Input;
			parm_pub_status.SourceColumn =StorehouseStockAccountData.STATUS_FIELD;
			insert.Parameters.Add(parm_pub_status);

			return insert;

		}
		#endregion

		#region 更新 记录----库房库存帐

		public bool UpdateStorehouseStockAccount(StorehouseStockAccountData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand  = GetUpdateCommand();
			da.Update(data,StorehouseStockAccountData.STOREHOUSESTOCKACCOUNT_TABLE);
			if(data.HasErrors)
			{
				data.Tables[StorehouseStockAccountData.STOREHOUSESTOCKACCOUNT_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand update = new SqlCommand("U_StorehouseStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_oldhouseid = new SqlParameter(OLDHOUSEID_PARM,SqlDbType.Char,4);  //------old houseid
			parm_oldhouseid.Direction =ParameterDirection.Input;
			parm_oldhouseid.SourceColumn =StorehouseStockAccountData.HOUSEID_FIELD;
			parm_oldhouseid.SourceVersion = DataRowVersion.Original;
			update.Parameters.Add(parm_oldhouseid);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char,4);
			parm_houseid.Direction =ParameterDirection.Input;
			parm_houseid.SourceColumn =StorehouseStockAccountData.HOUSEID_FIELD;
			parm_houseid.SourceVersion = DataRowVersion.Current;
			update.Parameters.Add(parm_houseid);

			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char,20); //. ------ old  Materialid
			parm_oldmaterialid.Direction =ParameterDirection.Input;
			parm_oldmaterialid.SourceColumn =StorehouseStockAccountData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			update.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materialid.Direction =ParameterDirection.Input;
			parm_materialid.SourceColumn =StorehouseStockAccountData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			update.Parameters.Add(parm_materialid);

			SqlParameter parm_olddepartid = new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char,10);  // ----- old departid
			parm_olddepartid.Direction =ParameterDirection.Input;
			parm_olddepartid.SourceColumn =StorehouseStockAccountData.DEPARTMENTID_FIELD;
			parm_olddepartid.SourceVersion = DataRowVersion.Original;
			update.Parameters.Add(parm_olddepartid);

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.Direction =ParameterDirection.Input;
			parm_departid.SourceColumn =StorehouseStockAccountData.DEPARTMENTID_FIELD;
			parm_departid.SourceVersion = DataRowVersion.Current;
			update.Parameters.Add(parm_departid);

			SqlParameter parm_pub_oldattribute = new SqlParameter(OLDPUB_ATTRIBUTE_PARM,SqlDbType.Char,18); // -------- old  Pub_Attribute
			parm_pub_oldattribute.Direction =ParameterDirection.Input;
			parm_pub_oldattribute.SourceColumn =StorehouseStockAccountData.PUB_ATTRIBUTE_FIELD;
			parm_pub_oldattribute.SourceVersion = DataRowVersion.Original;
			update.Parameters.Add(parm_pub_oldattribute);

			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,18);
			parm_pub_attribute.Direction =ParameterDirection.Input;
			parm_pub_attribute.SourceColumn =StorehouseStockAccountData.PUB_ATTRIBUTE_FIELD;
			parm_pub_attribute.SourceVersion = DataRowVersion.Current;
			update.Parameters.Add(parm_pub_attribute);

			SqlParameter parm_pub_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char,10);
			parm_pub_accountdep.Direction =ParameterDirection.Input;
			parm_pub_accountdep.SourceColumn =StorehouseStockAccountData.ACCOUNTDEP_FIELD;
			update.Parameters.Add(parm_pub_accountdep);


			SqlParameter parm_oldyear = new SqlParameter(OLDYEAR_PARM,SqlDbType.SmallInt,2);  //  ----------- old year
			parm_oldyear.Direction =ParameterDirection.Input;
			parm_oldyear.SourceColumn =StorehouseStockAccountData.YEAR_FIELD;
			parm_oldyear.SourceVersion = DataRowVersion.Original;
			update.Parameters.Add(parm_oldyear);

			SqlParameter parm_year = new SqlParameter(YEAR_PARM,SqlDbType.SmallInt,2);
			parm_year.Direction =ParameterDirection.Input;
			parm_year.SourceColumn =StorehouseStockAccountData.YEAR_FIELD;
			parm_year.SourceVersion = DataRowVersion.Current;
			update.Parameters.Add(parm_year);

			SqlParameter parm_pub_oldmonth = new SqlParameter(OLDMONTH_PARM,SqlDbType.SmallInt,2); //----- old month
			parm_pub_oldmonth.Direction =ParameterDirection.Input;
			parm_pub_oldmonth.SourceColumn =StorehouseStockAccountData.MONTH_FIELD;
			parm_pub_oldmonth.SourceVersion = DataRowVersion.Original;
			update.Parameters.Add(parm_pub_oldmonth);

			SqlParameter parm_pub_month = new SqlParameter(MONTH_PARM,SqlDbType.SmallInt,2);
			parm_pub_month.Direction =ParameterDirection.Input;
			parm_pub_month.SourceColumn =StorehouseStockAccountData.MONTH_FIELD;
			parm_pub_month.SourceVersion = DataRowVersion.Current;
			update.Parameters.Add(parm_pub_month);

			SqlParameter parm_pub_lastmargin = new SqlParameter(LASTMARGIN_PARM,SqlDbType.Decimal,9);
			parm_pub_lastmargin.Direction =ParameterDirection.Input;
			parm_pub_lastmargin.SourceColumn =StorehouseStockAccountData.LASTMARGIN_FIELD;
			update.Parameters.Add(parm_pub_lastmargin);

			SqlParameter parm_pub_thisin = new SqlParameter(THISIN_PARM,SqlDbType.Decimal,9);
			parm_pub_thisin.Direction =ParameterDirection.Input;
			parm_pub_thisin.SourceColumn =StorehouseStockAccountData.THISIN_FIELD;
			update.Parameters.Add(parm_pub_thisin);

			SqlParameter parm_pub_thisout = new SqlParameter(THISOUT_PARM,SqlDbType.Decimal,9);
			parm_pub_thisout.Direction =ParameterDirection.Input;
			parm_pub_thisout.SourceColumn =StorehouseStockAccountData.THISOUT_FIELD;
			update.Parameters.Add(parm_pub_thisout);



			SqlParameter parm_pub_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char,10);
			parm_pub_unit.Direction =ParameterDirection.Input;
			parm_pub_unit.SourceColumn =StorehouseStockAccountData.UNIT_FIELD;
			update.Parameters.Add(parm_pub_unit);

			SqlParameter parm_pub_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real,4);
			parm_pub_changerate.Direction =ParameterDirection.Input;
			parm_pub_changerate.SourceColumn =StorehouseStockAccountData.CHANGERATE_FIELD;
			update.Parameters.Add(parm_pub_changerate);

			SqlParameter parm_pub_status = new SqlParameter(STATUS_PARM,SqlDbType.Char,16);
			parm_pub_status.Direction =ParameterDirection.Input;
			parm_pub_status.SourceColumn =StorehouseStockAccountData.STATUS_FIELD;
			update.Parameters.Add(parm_pub_status);

			return update;

		}
		#endregion

		# region 删除记录--- 库房库存帐

		public  bool DeleteStorehouseStockAccount(string houseid,string materialid,string departid ,string pub_attribute,string year,string month)
		{
			SqlCommand deletecommand = GetDeleteCommand();
			deletecommand.Parameters[HOUSEID_PARM].Value              = houseid;
			deletecommand.Parameters[MATERIALID_PARM].Value           = materialid;
			deletecommand.Parameters[DEPARTMENTID_PARM].Value         = departid;
			deletecommand.Parameters[PUB_ATTRIBUTE_PARM].Value        = pub_attribute;
			deletecommand.Parameters[YEAR_PARM].Value                 = year;
			deletecommand.Parameters[MONTH_PARM].Value                =month;

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
		
			SqlCommand delete = new SqlCommand("D_StorehouseStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char,4);
			parm_houseid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_houseid);


			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materialid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_materialid);


			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_departid);


			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,18);
			parm_pub_attribute.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_pub_attribute);
 

			SqlParameter parm_year = new SqlParameter(YEAR_PARM,SqlDbType.SmallInt,2);
			parm_year.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_year);

			SqlParameter parm_pub_month = new SqlParameter(MONTH_PARM,SqlDbType.SmallInt,2);
			parm_pub_month.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_pub_month);

			return delete;
		}
		#endregion

		#region 通过物料id 汇总当前的物料的库存量
		/// <summary>
		/// 通过物料id 汇总当前的物料的库存量
		/// Added by XuJiansong 2005-8-29
		/// </summary>
		/// <param name="materialid"></param>
		/// <returns></returns>
		public StorehouseStockAccountData LoadStorehouseMaterialStock(string materialid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			StorehouseStockAccountData data = new StorehouseStockAccountData();
			da.SelectCommand= GetLoadMaterialStockCommand();
			da.SelectCommand.Parameters[MATERIALID_PARM].Value =materialid;
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

		private SqlCommand GetLoadMaterialStockCommand()
		{
			SqlCommand load  =  new SqlCommand("Q_StorehouseMaterialStock",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM ,SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_materialid);

			return load;
		}
		#endregion
	}
}
