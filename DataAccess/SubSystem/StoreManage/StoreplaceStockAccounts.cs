using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{

	
	public class StoreplaceStockAccounts:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String  PLACEID_PARM						= "@PlaceID";
		private const String  HOUSEID_PARM					    = "@HouseID";
		private const String  DEPARTMENTID_PARM					= "@DepartmentID";
		private const String  MATERIALID_PARM					= "@MaterialID";
		private const String  PUB_ATTRIBUTE_PARM				= "@PUB_Attribute";
		private const String  INTIME_PARM						= "@InTime";

		private const String  OLDPLACEID_PARM						= "@oldPlaceID";
		private const String  OLDHOUSEID_PARM					    = "@oldHouseID";
		private const String  OLDDEPARTMENTID_PARM					= "@oldDepartmentID";
		private const String  OLDMATERIALID_PARM					= "@oldMaterialID";
		private const String  OLDPUB_ATTRIBUTE_PARM				= "@oldPUB_Attribute";
		private const String  OLDINTIME_PARM						= "@oldInTime";

		private const String  BATCHNO_PARM						= "@BatchNO";
		private const String  ACCOUNTSTOCK_PARM					= "@AccountStock";
		private const String  REALSTOCK_PARM					= "@RealStock";
		private const String  UNIT_PARM							= "@Unit";

		private const String  CHANGERATE_PARM					= "@ChangeRate";
		private const String  STOCKPRICE_PARM					= "@StockPrice";
		private const String  ACCOUNTDEP_PARM					= "@AccountDep";
		public StoreplaceStockAccounts()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",StoreplaceStockAccountData.STOREPLACESTOCKACCOUNT_TABLE);
			
		}
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
			if(dsCommand!=null)
			{
				if(dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				}
				if(dsCommand.InsertCommand!=null)
				{
					if(dsCommand.InsertCommand.Connection!=null)
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}
				if(dsCommand.UpdateCommand!=null)
				{
					if(dsCommand.UpdateCommand.Connection!=null)
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}
				if(dsCommand.DeleteCommand!=null)
				{
					if(dsCommand.DeleteCommand.Connection!=null)
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}
				dsCommand.Dispose();
				dsCommand=null;

			}
		}
	
		#endregion


		#region 读数据

		//Begin of Modifyed by YiChangxin 2005-8-23
		private SqlCommand GetloadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_StoreplaceStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_Departmentid = new SqlParameter (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_Departmentid.Direction=ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_Departmentid);


			SqlParameter parm_houseid = new SqlParameter (HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction=ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_houseid);

			return loadCommand;
		}
		public StoreplaceStockAccountData LoadStoreplaceStockAccount(string departmentid,string houseid)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			StoreplaceStockAccountData data = new StoreplaceStockAccountData();
			dsCommand.SelectCommand=GetloadCommand();
			dsCommand.SelectCommand.Parameters[DEPARTMENTID_PARM].Value= departmentid;
			dsCommand.SelectCommand.Parameters[HOUSEID_PARM].Value= houseid;
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
		//End of Modifyed by YiChangxin 2005-8-23

		//Begin of Added by Weitaojiang 2005-8-23
		private SqlCommand GetLoadCommand(string filter)
		{

			string sql = "SELECT s.*,c.*,d.Sname DepartmentName,m.* "
				+ " FROM(select * from TBL_StoreplaceStockAccount where "+ filter+ ") c"
				+ " LEFT JOIN TBL_storehouse s ON s.houseid=c.houseid Left JOIN TBL_DepartmentInfo d ON d.departmentid=c.departmentid"
				+ " LEFT JOIN TBL_material m ON m.materialid=c.materialid";
			SqlCommand loadCommand = new SqlCommand(sql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.Text;

			return loadCommand;
		}
		public StoreplaceStockAccountData LoadStoreplaceStockAccount(string filter)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			StoreplaceStockAccountData data = new StoreplaceStockAccountData();
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
		//End of Added by WeiTaojiang 2005-8-23
		#endregion
		
		
		#region 添加数据
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_StoreplaceStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType= CommandType.StoredProcedure;
				
			SqlParameter parm_Departmentid = new SqlParameter (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_Departmentid.SourceColumn=StoreplaceStockAccountData.DEPARTMENTID_FIELD;
			parm_Departmentid.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Departmentid);


			SqlParameter parm_houseid = new SqlParameter (HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.SourceColumn=StoreplaceStockAccountData.HOUSEID_FIELD;
			parm_houseid.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_houseid);


			SqlParameter parm_placeid = new SqlParameter (PLACEID_PARM,SqlDbType.Char);
			parm_placeid.SourceColumn=StoreplaceStockAccountData.PLACEID_FIELD;
			parm_placeid.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_placeid);

			SqlParameter parm_materialid = new SqlParameter (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn=StoreplaceStockAccountData.MATERIALID_FIELD;
			parm_materialid.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_materialid);


			SqlParameter parm_PUBattribute = new SqlParameter (PUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_PUBattribute.SourceColumn=StoreplaceStockAccountData.PUB_ATTRIBUTE_FIELD;
			parm_PUBattribute.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PUBattribute);


			SqlParameter parm_intime = new SqlParameter (INTIME_PARM,SqlDbType.DateTime);
			parm_intime.SourceColumn=StoreplaceStockAccountData.INTIME_FIELD;
			parm_intime.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_intime);

			SqlParameter parm_accountstock = new SqlParameter (ACCOUNTSTOCK_PARM,SqlDbType.Decimal);
			parm_accountstock.SourceColumn=StoreplaceStockAccountData.ACCOUNTSTOCK_FIELD;
			parm_accountstock.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_accountstock);

			SqlParameter parm_realstock = new SqlParameter (REALSTOCK_PARM,SqlDbType.Decimal);
			parm_realstock.SourceColumn=StoreplaceStockAccountData.REALSTOCK_FIELD;
			parm_realstock.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_realstock);

			SqlParameter parm_unit= new SqlParameter (UNIT_PARM,SqlDbType.Char);
			parm_unit.SourceColumn=StoreplaceStockAccountData.UNIT_FIELD;
			parm_unit.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter (CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.SourceColumn=StoreplaceStockAccountData.CHANGERATE_FIELD;
			parm_changerate.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_changerate);

				
			SqlParameter parm_accountdep = new SqlParameter (ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.SourceColumn=StoreplaceStockAccountData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_stockprice = new SqlParameter (STOCKPRICE_PARM,SqlDbType.Decimal);
			parm_stockprice.SourceColumn=StoreplaceStockAccountData.STOCKPRICE_FIELD;
			parm_stockprice.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_stockprice);

			SqlParameter parm_batchno = new SqlParameter (BATCHNO_PARM,SqlDbType.Char);
			parm_batchno.SourceColumn=StoreplaceStockAccountData.BATCHNO_FIELD;
			parm_batchno.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_batchno);

			return insertCommand;
		}
		public bool InsertStorepaceStockAccount(StoreplaceStockAccountData data)

		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			try
			{
				dsCommand.Update(data, StoreplaceStockAccountData.STOREPLACESTOCKACCOUNT_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[StoreplaceStockAccountData.STOREPLACESTOCKACCOUNT_TABLE].GetErrors()[0].ClearErrors();
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

		#region 修改数据
		private SqlCommand GetupdataCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_StoreplaceStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType= CommandType.StoredProcedure;
				
			SqlParameter parm_Departmentid = new SqlParameter (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_Departmentid.SourceColumn=StoreplaceStockAccountData.DEPARTMENTID_FIELD;
			parm_Departmentid.SourceVersion=DataRowVersion.Current;
			parm_Departmentid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Departmentid);

			SqlParameter parm_oldDepartmentid = new SqlParameter (OLDDEPARTMENTID_PARM,SqlDbType.Char);
			parm_oldDepartmentid.SourceColumn=StoreplaceStockAccountData.DEPARTMENTID_FIELD;
			parm_oldDepartmentid.SourceVersion=DataRowVersion.Original;
			parm_oldDepartmentid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldDepartmentid);

			SqlParameter parm_houseid = new SqlParameter (HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.SourceColumn=StoreplaceStockAccountData.HOUSEID_FIELD;
			parm_houseid.SourceVersion=DataRowVersion.Current;
			parm_houseid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_oldhouseid = new SqlParameter (OLDHOUSEID_PARM,SqlDbType.Char);
			parm_oldhouseid.SourceColumn=StoreplaceStockAccountData.HOUSEID_FIELD;
			parm_oldhouseid.SourceVersion=DataRowVersion.Original;
			parm_oldhouseid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldhouseid);

			SqlParameter parm_placeid = new SqlParameter (PLACEID_PARM,SqlDbType.Char);
			parm_placeid.SourceColumn=StoreplaceStockAccountData.PLACEID_FIELD;
			parm_placeid.SourceVersion=DataRowVersion.Current;
			parm_placeid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_placeid);

			SqlParameter parm_oldplaceid = new SqlParameter (OLDPLACEID_PARM,SqlDbType.Char);
			parm_oldplaceid.SourceColumn=StoreplaceStockAccountData.PLACEID_FIELD;
			parm_oldplaceid.SourceVersion=DataRowVersion.Original;
			parm_oldplaceid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldplaceid);

			SqlParameter parm_materialid = new SqlParameter (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn=StoreplaceStockAccountData.MATERIALID_FIELD;
			parm_materialid.SourceVersion=DataRowVersion.Current;
			parm_materialid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_OLDmaterialid = new SqlParameter (OLDMATERIALID_PARM,SqlDbType.Char);
			parm_OLDmaterialid.SourceColumn=StoreplaceStockAccountData.MATERIALID_FIELD;
			parm_OLDmaterialid.SourceVersion=DataRowVersion.Original;
			parm_OLDmaterialid.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_OLDmaterialid);

			SqlParameter parm_PUBattribute = new SqlParameter (PUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_PUBattribute.SourceColumn=StoreplaceStockAccountData.PUB_ATTRIBUTE_FIELD;
			parm_PUBattribute.SourceVersion=DataRowVersion.Current;
			parm_PUBattribute.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PUBattribute);

			SqlParameter parm_oldPUBattribute = new SqlParameter (OLDPUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_oldPUBattribute.SourceColumn=StoreplaceStockAccountData.PUB_ATTRIBUTE_FIELD;
			parm_oldPUBattribute.SourceVersion=DataRowVersion.Original;
			parm_oldPUBattribute.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldPUBattribute);

			SqlParameter parm_intime = new SqlParameter (INTIME_PARM,SqlDbType.DateTime);
			parm_intime.SourceColumn=StoreplaceStockAccountData.INTIME_FIELD;
			parm_intime.SourceVersion=DataRowVersion.Current;
			parm_intime.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_intime);

			SqlParameter parm_oldintime = new SqlParameter (OLDINTIME_PARM,SqlDbType.DateTime);
			parm_oldintime.SourceColumn=StoreplaceStockAccountData.INTIME_FIELD;
			parm_oldintime.SourceVersion=DataRowVersion.Original;
			parm_oldintime.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldintime);

			SqlParameter parm_accountstock = new SqlParameter( ACCOUNTSTOCK_PARM,SqlDbType.Decimal);
			parm_accountstock.SourceColumn=StoreplaceStockAccountData.ACCOUNTSTOCK_FIELD;
			
			parm_accountstock.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_accountstock);

			SqlParameter parm_realstock = new SqlParameter (REALSTOCK_PARM,SqlDbType.Decimal);
			parm_realstock.SourceColumn=StoreplaceStockAccountData.REALSTOCK_FIELD;
			parm_realstock.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_realstock);

			SqlParameter parm_unit= new SqlParameter (UNIT_PARM,SqlDbType.Char);
			parm_unit.SourceColumn=StoreplaceStockAccountData.UNIT_FIELD;
			parm_unit.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter (CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.SourceColumn=StoreplaceStockAccountData.CHANGERATE_FIELD;
			parm_changerate.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_changerate);

				
			SqlParameter parm_accountdep = new SqlParameter (ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.SourceColumn=StoreplaceStockAccountData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_stockprice = new SqlParameter (STOCKPRICE_PARM,SqlDbType.Decimal);
			parm_stockprice.SourceColumn=StoreplaceStockAccountData.STOCKPRICE_FIELD;
			parm_stockprice.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_stockprice);

			SqlParameter parm_batchno = new SqlParameter (BATCHNO_PARM,SqlDbType.Char);
			parm_batchno.SourceColumn=StoreplaceStockAccountData.BATCHNO_FIELD;
			parm_batchno.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_batchno);

			return updateCommand;
		}
		public bool UpdateStoreplaceAccount(StoreplaceStockAccountData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			dsCommand.UpdateCommand = GetupdataCommand();
			try
			{
				dsCommand.Update(data, StoreplaceStockAccountData.STOREPLACESTOCKACCOUNT_TABLE);
				if(data.HasErrors)
				{
					data.Tables[StoreplaceStockAccountData.STOREPLACESTOCKACCOUNT_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				else
					data.AcceptChanges();
				return true;
			}
			catch
			{
				return false;

			}
		}
		#endregion

		#region 删除数据
		private SqlCommand GetDeleteCommmand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_StoreplaceStockAccount",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType= CommandType.StoredProcedure;

			SqlParameter parm_Departmentid = new SqlParameter (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_Departmentid.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_Departmentid);


			SqlParameter parm_houseid = new SqlParameter (HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_houseid);


			SqlParameter parm_placeid = new SqlParameter (PLACEID_PARM,SqlDbType.Char);
			parm_placeid.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_placeid);

			SqlParameter parm_materialid = new SqlParameter (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);


			SqlParameter parm_PUBattribute = new SqlParameter (PUB_ATTRIBUTE_PARM,SqlDbType.Char);
			parm_PUBattribute.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_PUBattribute);


			SqlParameter parm_intime = new SqlParameter (INTIME_PARM,SqlDbType.DateTime);
			parm_intime.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_intime);
			return deleteCommand;
		}
		public bool DeleteStoreplaceStockAccount(string materialid,string placeid,string houseid,string departmentid,string pub_attribute,string intime)
		{
			SqlCommand deleteCommand = GetDeleteCommmand();
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value= departmentid;
			deleteCommand.Parameters[HOUSEID_PARM].Value= houseid;
			deleteCommand.Parameters[PLACEID_PARM].Value= placeid;
			deleteCommand.Parameters[MATERIALID_PARM].Value= materialid;
			deleteCommand.Parameters[PUB_ATTRIBUTE_PARM].Value= pub_attribute;
			deleteCommand.Parameters[INTIME_PARM].Value= intime;
     
			try
			{
				deleteCommand.Connection.Open();
				int i = deleteCommand.ExecuteNonQuery();
				deleteCommand.Connection.Close();
				if (i>=1)
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
			}
		}

		#endregion
	}
}
			