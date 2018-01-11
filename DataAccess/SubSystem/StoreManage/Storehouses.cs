using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	/// <summary>
	/// Storehouses 的摘要说明。
	/// </summary>
	public class Storehouses:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String HOUSEID_PARM      = "@houseid";
		private const String DEPARTMENTID_PARM = "@departmentid";
		private const String OLDDEPARTMENTID_PARM = "@olddepartmentid";
		private const String NAME_PARM         = "@name";
		private const String TYPE_PARM         = "@type";
		private const String ADDRESS_PARM      = "@address";
		private const String ACCOUNTDEP_PARM   = "@accountdep";
		private const String DESCRIPTION_PARM  = "@description";
        private const String ENABLE_PARM       = "@enable";
		private const String CAPACITY_PARM     = "@capacity";
		private const String UNIT_PARM         = "@unit";

		#region Create Adapter
		public Storehouses()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",StorehouseData.STOREHOUSE_TABLE);
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
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_Storehouse",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public StorehouseData LoadStorehouse()
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			StorehouseData data = new StorehouseData();
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

		private SqlCommand GetLoadCommandByHouseID()
		{
			SqlCommand loadCommand = new SqlCommand("Q_StorehouseByHouseID",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_departmentid);

			return loadCommand;
		}
		public StorehouseData LoadStorehouse(string departmentid,string houseid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			StorehouseData data = new StorehouseData();
			dsCommand.SelectCommand = GetLoadCommandByHouseID();
			dsCommand.SelectCommand.Parameters[HOUSEID_PARM].Value = houseid;
			dsCommand.SelectCommand.Parameters[DEPARTMENTID_PARM].Value = departmentid;

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

		#region Read data
		private SqlCommand GetLoadCommand(string filter)
		{
			string sql = "SELECT s.*,d.Sname DepartmentName FROM(select * from TBL_Storehouse where "
				+ filter
				+ ") s LEFT JOIN TBL_DepartmentInfo d ON s.DepartmentID=d.DepartmentID";
			SqlCommand loadCommand = new SqlCommand(sql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.Text;

			return loadCommand;
		}
		public StorehouseData LoadStorehouse(string filter)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			StorehouseData data = new StorehouseData();
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
			SqlCommand insertCommand = new SqlCommand("I_Storehouse",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = StorehouseData.HOUSEID_FIELD;
			insertCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = StorehouseData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_name = new SqlParameter(NAME_PARM,SqlDbType.Char);
			parm_name.Direction    = ParameterDirection.Input;
			parm_name.SourceColumn = StorehouseData.NAME_FIELD;
			insertCommand.Parameters.Add(parm_name);

			SqlParameter parm_type = new SqlParameter(TYPE_PARM,SqlDbType.Char);
			parm_type.Direction    = ParameterDirection.Input;
			parm_type.SourceColumn = StorehouseData.TYPE_FIELD;
			insertCommand.Parameters.Add(parm_type);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM,SqlDbType.VarChar);
			parm_address.Direction    = ParameterDirection.Input;
			parm_address.SourceColumn = StorehouseData.ADDRESS_FIELD;
			insertCommand.Parameters.Add(parm_address);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = StorehouseData.ACCOUNTDEP_FIELD;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn =StorehouseData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_enable = new SqlParameter(ENABLE_PARM,SqlDbType.Char);
			parm_enable.Direction    = ParameterDirection.Input;
			parm_enable.SourceColumn = StorehouseData.ENABLE_FIELD;
			insertCommand.Parameters.Add(parm_enable);

			SqlParameter parm_capacity = new SqlParameter(CAPACITY_PARM,SqlDbType.Real);
			parm_capacity.Direction    = ParameterDirection.Input;
			parm_capacity.SourceColumn = StorehouseData.CAPACITY_FIELD;
			insertCommand.Parameters.Add(parm_capacity);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = StorehouseData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);

			return insertCommand;
		}
		public bool InsertStorehouse(StorehouseData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,StorehouseData.STOREHOUSE_TABLE);

			if(info.HasErrors)
			{
				info.Tables[StorehouseData.STOREHOUSE_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion
		#region update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_Storehouse",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = StorehouseData.HOUSEID_FIELD;
			updateCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid	= new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction		= ParameterDirection.Input;
			parm_departmentid.SourceVersion	= DataRowVersion.Current;
			parm_departmentid.SourceColumn	= StorehouseData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_olddep	= new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char);
			parm_olddep.Direction		= ParameterDirection.Input;
			parm_olddep.SourceVersion	= DataRowVersion.Original;
			parm_olddep.SourceColumn	= StorehouseData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_olddep);

			SqlParameter parm_name = new SqlParameter(NAME_PARM,SqlDbType.Char);
			parm_name.Direction    = ParameterDirection.Input;
			parm_name.SourceColumn = StorehouseData.NAME_FIELD;
			updateCommand.Parameters.Add(parm_name);

			SqlParameter parm_type = new SqlParameter(TYPE_PARM,SqlDbType.Char);
			parm_type.Direction    = ParameterDirection.Input;
			parm_type.SourceColumn = StorehouseData.TYPE_FIELD;
			updateCommand.Parameters.Add(parm_type);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM,SqlDbType.VarChar);
			parm_address.Direction    = ParameterDirection.Input;
			parm_address.SourceColumn = StorehouseData.ADDRESS_FIELD;
			updateCommand.Parameters.Add(parm_address);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = StorehouseData.ACCOUNTDEP_FIELD;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn =StorehouseData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			SqlParameter parm_enable = new SqlParameter(ENABLE_PARM,SqlDbType.Char);
			parm_enable.Direction    = ParameterDirection.Input;
			parm_enable.SourceColumn = StorehouseData.ENABLE_FIELD;
			updateCommand.Parameters.Add(parm_enable);

			SqlParameter parm_capacity = new SqlParameter(CAPACITY_PARM,SqlDbType.Real);
			parm_capacity.Direction    = ParameterDirection.Input;
			parm_capacity.SourceColumn = StorehouseData.CAPACITY_FIELD;
			updateCommand.Parameters.Add(parm_capacity);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = StorehouseData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);

			return updateCommand;
		}
		public bool UpdateStorehouse(StorehouseData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,StorehouseData.STOREHOUSE_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[StorehouseData.STOREHOUSE_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_Storehouse",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			return deleteCommand;
		}
		public bool DeleteStorehouse(string houseid,string departmentid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get delete command and update database
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[HOUSEID_PARM].Value      = houseid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value = departmentid;
			//
			//  Check it if it update failed
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
