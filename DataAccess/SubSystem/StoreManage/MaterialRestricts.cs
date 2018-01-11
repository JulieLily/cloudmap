using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage ;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	/// <summary>
	/// MaterialRestricts 的摘要说明。
	/// </summary>
	public class MaterialRestricts:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String ID_PARM           = "@id";
		private const String MATERIALID_PARM   = "@materialid";
		private const String DESCRIPTION_PARM  = "@description";
		private const String RESTRICTTYPE_PARM = "@restricttype";

		#region Create Adapter
		public MaterialRestricts()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",MaterialRestrictData.MATERIALRESTRICT_TABLE);
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
			SqlCommand loadCommand = new SqlCommand("Q_MaterialRestrict",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public MaterialRestrictData Loadmaterialrestrict()
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			MaterialRestrictData data = new MaterialRestrictData();
			dsCommand.SelectCommand  = GetLoadCommand();
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
			SqlCommand insertCommand = new SqlCommand("I_MaterialRestrict",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_id = new SqlParameter(ID_PARM,SqlDbType.SmallInt);
			parm_id.Direction    = ParameterDirection.Input;
			parm_id.SourceColumn = MaterialRestrictData.ID_FIELD;
			insertCommand.Parameters.Add(parm_id);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = MaterialRestrictData.MATERIALID_FIELD;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = MaterialRestrictData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_restricttype = new SqlParameter(RESTRICTTYPE_PARM,SqlDbType.Char);
			parm_restricttype.Direction    = ParameterDirection.Input;
			parm_restricttype.SourceColumn = MaterialRestrictData.RESTRICTTYPE_FIELD;
			insertCommand.Parameters.Add(parm_restricttype);

			return insertCommand;
		}
		public bool Insertmaterialrestrict(MaterialRestrictData data)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert Command  and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(data,MaterialRestrictData.MATERIALRESTRICT_TABLE);
			//
			// Check table error to see if the update failed
			//
			if(data.HasErrors)
			{
				data.Tables[MaterialRestrictData.MATERIALRESTRICT_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else 
			{
				data.AcceptChanges();
				return true;
			}
		
		}
		#endregion 
        #region update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_MaterialRestrict",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_id = new SqlParameter(ID_PARM,SqlDbType.SmallInt);
			parm_id.Direction    = ParameterDirection.Input;
			parm_id.SourceColumn = MaterialRestrictData.ID_FIELD;
			updateCommand.Parameters.Add(parm_id);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = MaterialRestrictData.MATERIALID_FIELD;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = MaterialRestrictData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			SqlParameter parm_restricttype = new SqlParameter(RESTRICTTYPE_PARM,SqlDbType.Char);
			parm_restricttype.Direction    = ParameterDirection.Input;
			parm_restricttype.SourceColumn = MaterialRestrictData.RESTRICTTYPE_FIELD;
			updateCommand.Parameters.Add(parm_restricttype);

			return updateCommand;
		}
		public bool UpdateMaterialRestrict(MaterialRestrictData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();
 
			dsCommand.Update(info,MaterialRestrictData.MATERIALRESTRICT_TABLE);
			//
			// Check it if it has errors
			//
			if(info.HasErrors)
			{
				info.Tables[MaterialRestrictData.MATERIALRESTRICT_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand = new SqlCommand("D_MaterialRestrict",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_id = new SqlParameter(ID_PARM,SqlDbType.SmallInt);
			parm_id.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_id);

		return deleteCommand;
		}
		public bool DeleteMaterialRestrict(string id)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			SqlCommand deleteCommand   = GetDeleteCommand();
			deleteCommand.Parameters[ID_PARM].Value = id;
			try
			{
				deleteCommand.Connection.Open();
				if(deleteCommand.ExecuteNonQuery() >0)
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
