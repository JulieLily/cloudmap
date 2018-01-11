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
	/// Chests 的摘要说明。
	/// </summary>
	public class Chests:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String CHESTID_PARM      = "@chestid";
		private const String DEPARTMENTID_PARM = "@departmentid";
		private const String MATERIALID_PARM   = "@materialid";
		private const String BATCHNO_PARM      = "@batchno";
		private const String HOUSEID_PARM      = "@houseid";
		private const String HOUSEDEP_PARM     = "@housedep";
		private const String WEIGHT_PARM       = "@weight";
		private const String PIECES_PARM       = "@pieces";
		private const String UNIT_PARM         = "@unit";
		private const String CHANGERATE_PARM   = "@changerate";
		private const String DESCRIPTION_PARM  = "@description";

		#region Create Adapter	
		public Chests()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",ChestData.CHEST_TABLE);
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
			SqlCommand loadCommand = new SqlCommand("Q_Chest",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public ChestData LoadChest()
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			ChestData data = new ChestData();
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

		#region insert data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_Chest",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_chestid = new SqlParameter(CHESTID_PARM,SqlDbType.Char);
			parm_chestid.Direction    = ParameterDirection.Input;
			parm_chestid.SourceColumn = ChestData.CHESTID_FIELD;
			insertCommand.Parameters.Add(parm_chestid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = ChestData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = ChestData.MATERIALID_FIELD;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno = new SqlParameter(BATCHNO_PARM,SqlDbType.Char);
			parm_batchno.Direction    = ParameterDirection.Input;
			parm_batchno.SourceColumn = ChestData.BATCHNO_FIELD;
			insertCommand.Parameters.Add(parm_batchno);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = ChestData.HOUSEID_FIELD;
			insertCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_housedep = new SqlParameter(HOUSEDEP_PARM,SqlDbType.Char);
			parm_housedep.Direction    = ParameterDirection.Input;
			parm_housedep.SourceColumn = ChestData.HOUSEDEP_FIELD;
			insertCommand.Parameters.Add(parm_housedep);

			SqlParameter parm_weight = new SqlParameter(WEIGHT_PARM,SqlDbType.Decimal);
			parm_weight.Direction    = ParameterDirection.Input;
			parm_weight.SourceColumn = ChestData.WEIGHT_FIELD;
			insertCommand.Parameters.Add(parm_weight);

			SqlParameter parm_pieces = new SqlParameter(PIECES_PARM,SqlDbType.SmallInt);
			parm_pieces.Direction    = ParameterDirection.Input;
			parm_pieces.SourceColumn = ChestData.PIECES_FIELD;
			insertCommand.Parameters.Add(parm_pieces);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = ChestData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = ChestData.CHANGERATE_FIELD;
			insertCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = ChestData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;
		}
		public bool InsertChest(ChestData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,ChestData.CHEST_TABLE); 
			//
			// Check it if it is update failed
			//
			if(info.HasErrors)
			{
				info.Tables[ChestData.CHEST_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand updateCommand = new SqlCommand("U_Chest",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_chestid = new SqlParameter(CHESTID_PARM,SqlDbType.Char);
			parm_chestid.Direction    = ParameterDirection.Input;
			parm_chestid.SourceColumn = ChestData.CHESTID_FIELD;
			updateCommand.Parameters.Add(parm_chestid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = ChestData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = ChestData.MATERIALID_FIELD;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno = new SqlParameter(BATCHNO_PARM,SqlDbType.Char);
			parm_batchno.Direction    = ParameterDirection.Input;
			parm_batchno.SourceColumn = ChestData.BATCHNO_FIELD;
			updateCommand.Parameters.Add(parm_batchno);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM,SqlDbType.Char);
			parm_houseid.Direction    = ParameterDirection.Input;
			parm_houseid.SourceColumn = ChestData.HOUSEID_FIELD;
			updateCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_housedep = new SqlParameter(HOUSEDEP_PARM,SqlDbType.Char);
			parm_housedep.Direction    = ParameterDirection.Input;
			parm_housedep.SourceColumn = ChestData.HOUSEDEP_FIELD;
			updateCommand.Parameters.Add(parm_housedep);

			SqlParameter parm_weight = new SqlParameter(WEIGHT_PARM,SqlDbType.Decimal);
			parm_weight.Direction    = ParameterDirection.Input;
			parm_weight.SourceColumn = ChestData.WEIGHT_FIELD;
			updateCommand.Parameters.Add(parm_weight);

			SqlParameter parm_pieces = new SqlParameter(PIECES_PARM,SqlDbType.SmallInt);
			parm_pieces.Direction    = ParameterDirection.Input;
			parm_pieces.SourceColumn = ChestData.PIECES_FIELD;
			updateCommand.Parameters.Add(parm_pieces);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = ChestData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = ChestData.CHANGERATE_FIELD;
			updateCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = ChestData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);
			
			return updateCommand;
		}
		public bool UpdateChest(ChestData info)   
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
 			//
			dsCommand.UpdateCommand = GetUpdateCommand();
 
			dsCommand.Update(info,ChestData.CHEST_TABLE);
			//
			// Check it if it has error
			//
			if(info.HasErrors)
			{
				info.Tables[ChestData.CHEST_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_Chest",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_chestid = new SqlParameter(CHESTID_PARM,SqlDbType.Char);
			parm_chestid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_chestid);

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno = new SqlParameter(BATCHNO_PARM,SqlDbType.Char);
			parm_batchno.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_batchno);

			return deleteCommand;
		}
		public bool DeleteChest(string chestid,string departmentid,string materialid,string batchno)   
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			SqlCommand deleteCommand = GetDeleteCommand();
	
			deleteCommand.Parameters[CHESTID_PARM].Value      = chestid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value = departmentid;
			deleteCommand.Parameters[BATCHNO_PARM].Value      = batchno;
			deleteCommand.Parameters[MATERIALID_PARM].Value   = materialid;
			
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
				deleteCommand.Dispose();
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion
	}
}
