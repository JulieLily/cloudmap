using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
 
using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	/// <summary>
	/// StorePlaces 的摘要说明。
	/// </summary>
	public class Storeplaces:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String DEPARTMENTID_PARM = "@departmentid";
		private const String HOUSEID_PARM      = "@houseid";
		private const String PLACEID_PARM      = "@placeid";
		private const String PLACE_PARM        = "@place";
		private const String DESCRIPTION_PARM  = "@description";
		private const String ENABLE_PARM       = "@enable";
		private const String CAPACITY_PARM     = "@capacity";
		private const String UNIT_PARM         = "@unit";

		#region Create Adapter
		public Storeplaces()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",StoreplaceData.STOREPLACE_TABLE);
		}
		#endregion

		#region 释放资源
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected virtual void Dispose(bool disposing )
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

		#region  Read data
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_StorePlace",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

		    return loadCommand;
		}
		public StoreplaceData LoadStoreplace()
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			StoreplaceData data = new StoreplaceData();
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

		private SqlCommand GetLoadCommandByHouse()
		{
			SqlCommand loadCommand = new SqlCommand("Q_StorePlaceByHouse",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_houseid);

			return loadCommand;
		}
		public StoreplaceData LoadStoreplace(string department,string houseid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			StoreplaceData data = new StoreplaceData();
			dsCommand.SelectCommand = GetLoadCommandByHouse();
			dsCommand.SelectCommand.Parameters[DEPARTMENTID_PARM].Value = department;
			dsCommand.SelectCommand.Parameters[HOUSEID_PARM].Value = houseid;

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

		private SqlCommand GetLoadCommandByDepartment()
		{
			SqlCommand loadCommand = new SqlCommand("Q_StorePlaceByDepartment",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_departmentid);

			return loadCommand;
		}
		public StoreplaceData LoadStoreplace(string department)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			StoreplaceData data = new StoreplaceData();
			dsCommand.SelectCommand = GetLoadCommandByDepartment();
			dsCommand.SelectCommand.Parameters[DEPARTMENTID_PARM].Value = department;

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
			SqlCommand insertCommand = new SqlCommand("I_Storeplace",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = StoreplaceData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = StoreplaceData.HOUSEID_FIELD;
			insertCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM,SqlDbType.Char);
			parm_placeid.Direction    = ParameterDirection.Input;
			parm_placeid.SourceColumn = StoreplaceData.PLACEID_FIELD;
			insertCommand.Parameters.Add(parm_placeid);

			SqlParameter parm_place = new SqlParameter(PLACE_PARM,SqlDbType.VarChar);
			parm_place.Direction    = ParameterDirection.Input;
			parm_place.SourceColumn = StoreplaceData.PLACE_FIELD;
			insertCommand.Parameters.Add(parm_place);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = StoreplaceData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_enable = new SqlParameter(ENABLE_PARM,SqlDbType.Char);
			parm_enable.Direction    = ParameterDirection.Input;
			parm_enable.SourceColumn = StoreplaceData.ENABLE_FIELD;
			insertCommand.Parameters.Add(parm_enable);

			SqlParameter parm_capacity = new SqlParameter(CAPACITY_PARM,SqlDbType.Real);
			parm_capacity.Direction    = ParameterDirection.Input;
			parm_capacity.SourceColumn = StoreplaceData.CAPACITY_FIELD;
			insertCommand.Parameters.Add(parm_capacity);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = StoreplaceData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);

			return insertCommand;
		}
		public bool InsertStoreplace(StoreplaceData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,StoreplaceData.STOREPLACE_TABLE);
			//
			// Check it if it has error
			//
			if(info.HasErrors)
			{
				info.Tables[StoreplaceData.STOREPLACE_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand updateCommand = new SqlCommand("U_Storeplace",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = StoreplaceData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = StoreplaceData.HOUSEID_FIELD;
			updateCommand.Parameters.Add(parm_houseid);	

			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM,SqlDbType.Char);
			parm_placeid.Direction    = ParameterDirection.Input;
			parm_placeid.SourceColumn = StoreplaceData.PLACEID_FIELD;
			updateCommand.Parameters.Add(parm_placeid);

			SqlParameter parm_place = new SqlParameter(PLACE_PARM,SqlDbType.VarChar);
			parm_place.Direction    = ParameterDirection.Input;
			parm_place.SourceColumn = StoreplaceData.PLACE_FIELD;
			updateCommand.Parameters.Add(parm_place);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = StoreplaceData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			SqlParameter parm_enable = new SqlParameter(ENABLE_PARM,SqlDbType.Char);
			parm_enable.Direction    = ParameterDirection.Input;
			parm_enable.SourceColumn = StoreplaceData.ENABLE_FIELD;
			updateCommand.Parameters.Add(parm_enable);

			SqlParameter parm_capacity = new SqlParameter(CAPACITY_PARM,SqlDbType.Real);
			parm_capacity.Direction    = ParameterDirection.Input;
			parm_capacity.SourceColumn = StoreplaceData.CAPACITY_FIELD;
			updateCommand.Parameters.Add(parm_capacity);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = StoreplaceData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);

			return updateCommand;
		}
		public bool UpdateStoreplace(StoreplaceData info)    
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,StoreplaceData.STOREPLACE_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[StoreplaceData.STOREPLACE_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand =new SqlCommand("D_StorePlace",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;
            
			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_houseid);
	

			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM,SqlDbType.Char);
			parm_placeid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_placeid);

			return deleteCommand;
		}
		public bool DeleteStoreplace(string departmentid,string houseid,string placeid)   
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			//  Get delete command and update database
			//
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value = departmentid;
			deleteCommand.Parameters[HOUSEID_PARM].Value      = houseid;
			deleteCommand.Parameters[PLACEID_PARM].Value      = placeid;
			try
			{
				deleteCommand.Connection.Open();
				if(deleteCommand.ExecuteNonQuery() > 0)
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
				deleteCommand.Connection.Dispose();
				deleteCommand.Dispose();
				dsCommand.Dispose();
			}
		}
		#endregion
	}
}
