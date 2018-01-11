using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	/// <summary>
	/// MaterialDayArriveds 的摘要说明。
	/// </summary>
	public class MaterialDayArriveds:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String VEHICLENO_PARM      = "@vehicleno";
		private const String MATERIALID_PARM     = "@materialid";
		private const String PROVIDER_PARM       = "@provider";
		private const String ARRIVALDATE_PARM    = "@arrivaldate";

		private const String MANUFACTURER_PARM   = "@manufacturer";
		private const String FREIGHT_PARM        = "@freight";
		private const String AMOUNT_PARM         = "@amount";
		private const String UNIT_PARM           = "@unit";
		private const String CHANGERATE_PARM     = "@changerate";
		private const String STATUS_PARM         = "@status";
		private const String DRAWDEPARTMENT_PARM = "@drawdepartment";
		private const String DRAWPERSON_PARM     = "@drawperson";
		private const String DRAWDATE_PARM       = "@drawdate";
		private const String ACCOUNTDEP_PARM     = "@accountdep";
		private const String DESCRIPTION_PARM    = "@description";

		//Added by WeiTaojiang 2005-8-29
		private const String OLDARRIVALDATE_PARM = "@oldarrivaldate";

		#region Create Adapter
		public MaterialDayArriveds()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",MaterialDayArrivedData.MATERIALDAYARRIVED_TABLE);
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

		#region  read data
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_MaterialDayArrived",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;
			
			return loadCommand;
		}
		public MaterialDayArrivedData LoadMaterialDayArrived()
		{
			if(dsCommand == null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			MaterialDayArrivedData data = new MaterialDayArrivedData();

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

		#region Insert data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_MaterialDayArrived",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_vehicleno = new SqlParameter(VEHICLENO_PARM,SqlDbType.Char);
			parm_vehicleno.Direction    = ParameterDirection.Input;
			parm_vehicleno.SourceColumn = MaterialDayArrivedData.VEHICLENO_FIELD;
			insertCommand.Parameters.Add(parm_vehicleno);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = MaterialDayArrivedData.MATERIALID_FIELD;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_provider = new SqlParameter(PROVIDER_PARM,SqlDbType.Char);
			parm_provider.Direction    = ParameterDirection.Input;
			parm_provider.SourceColumn = MaterialDayArrivedData.PROVIDER_FIELD;
			insertCommand.Parameters.Add(parm_provider);

			SqlParameter parm_arrivaldate = new SqlParameter(ARRIVALDATE_PARM,SqlDbType.DateTime);
			parm_arrivaldate.Direction    = ParameterDirection.Input;
			parm_arrivaldate.SourceColumn = MaterialDayArrivedData.ARRIVALDATE_FIELD;
			insertCommand.Parameters.Add(parm_arrivaldate);

			SqlParameter parm_manufacturer = new SqlParameter(MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.Direction    = ParameterDirection.Input;
			parm_manufacturer.SourceColumn = MaterialDayArrivedData.MANUFACTURER_FIELD;
			insertCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_freight = new SqlParameter(FREIGHT_PARM,SqlDbType.Decimal);
			parm_freight.Direction    = ParameterDirection.Input;
			parm_freight.SourceColumn = MaterialDayArrivedData.FREIGHT_FIELD;
			insertCommand.Parameters.Add(parm_freight);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.Direction    = ParameterDirection.Input;
			parm_amount.SourceColumn = MaterialDayArrivedData.AMOUNT_FIELD;
			insertCommand.Parameters.Add(parm_amount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = MaterialDayArrivedData.UNIT_FIELD;
			insertCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = MaterialDayArrivedData.CHANGERATE_FIELD;
			insertCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = MaterialDayArrivedData.STATUS_FIELD;
			insertCommand.Parameters.Add(parm_status);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = MaterialDayArrivedData.DRAWDEPARTMENT_FIELD;
			insertCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = MaterialDayArrivedData.DRAWPERSON_FIELD;
			insertCommand.Parameters.Add(parm_drawperson);

			
			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = MaterialDayArrivedData.DRAWDATE_FIELD;
			insertCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = MaterialDayArrivedData.ACCOUNTDEP_FIELD;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = MaterialDayArrivedData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;
		}
		public bool InsertMaterialDayArrived(MaterialDayArrivedData info)
		{
			if(dsCommand == null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			//
			//Get insetCommand and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,MaterialDayArrivedData.MATERIALDAYARRIVED_TABLE);
			//
			//  Check for table errors to see if the update failed.
			//
			if( info.HasErrors )
			{
				info.Tables[MaterialDayArrivedData.MATERIALDAYARRIVED_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion

		//Modified by WeiTaojiang 2005-9-5
		#region Update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_MaterialDayArrived",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_vehicleno = new SqlParameter(VEHICLENO_PARM,SqlDbType.Char);
			parm_vehicleno.Direction    = ParameterDirection.Input;
			parm_vehicleno.SourceColumn = MaterialDayArrivedData.VEHICLENO_FIELD;
			updateCommand.Parameters.Add(parm_vehicleno);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			parm_materialid.SourceColumn = MaterialDayArrivedData.MATERIALID_FIELD;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_provider = new SqlParameter(PROVIDER_PARM,SqlDbType.Char);
			parm_provider.Direction    = ParameterDirection.Input;
			parm_provider.SourceColumn = MaterialDayArrivedData.PROVIDER_FIELD;
			updateCommand.Parameters.Add(parm_provider);

			SqlParameter parm_arrivaldate = new SqlParameter(ARRIVALDATE_PARM,SqlDbType.DateTime);
			parm_arrivaldate.Direction    = ParameterDirection.Input;
			parm_arrivaldate.SourceColumn = MaterialDayArrivedData.ARRIVALDATE_FIELD;
			parm_arrivaldate.SourceVersion = DataRowVersion.Current;                              //------------2005-9-5 魏套江修改
			updateCommand.Parameters.Add(parm_arrivaldate);

			SqlParameter parm_oldarrivaldate = new SqlParameter(OLDARRIVALDATE_PARM,SqlDbType.DateTime);
			parm_oldarrivaldate.Direction    = ParameterDirection.Input;
			parm_oldarrivaldate.SourceColumn = MaterialDayArrivedData.ARRIVALDATE_FIELD;
			parm_oldarrivaldate.SourceVersion = DataRowVersion.Original;                         //------------2005-9-5 魏套江修改
			updateCommand.Parameters.Add(parm_oldarrivaldate);


			SqlParameter parm_manufacturer = new SqlParameter(MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.Direction    = ParameterDirection.Input;
			parm_manufacturer.SourceColumn = MaterialDayArrivedData.MANUFACTURER_FIELD;
			updateCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_freight = new SqlParameter(FREIGHT_PARM,SqlDbType.Decimal);
			parm_freight.Direction    = ParameterDirection.Input;
			parm_freight.SourceColumn = MaterialDayArrivedData.FREIGHT_FIELD;
			updateCommand.Parameters.Add(parm_freight);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.Direction    = ParameterDirection.Input;
			parm_amount.SourceColumn = MaterialDayArrivedData.AMOUNT_FIELD;
			updateCommand.Parameters.Add(parm_amount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.Direction    = ParameterDirection.Input;
			parm_unit.SourceColumn = MaterialDayArrivedData.UNIT_FIELD;
			updateCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction    = ParameterDirection.Input;
			parm_changerate.SourceColumn = MaterialDayArrivedData.CHANGERATE_FIELD;
			updateCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM,SqlDbType.Char);
			parm_status.Direction    = ParameterDirection.Input;
			parm_status.SourceColumn = MaterialDayArrivedData.STATUS_FIELD;
			updateCommand.Parameters.Add(parm_status);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = MaterialDayArrivedData.DRAWDEPARTMENT_FIELD;
			updateCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = MaterialDayArrivedData.DRAWPERSON_FIELD;
			updateCommand.Parameters.Add(parm_drawperson);

			
			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = MaterialDayArrivedData.DRAWDATE_FIELD;
			updateCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_accountdep.Direction    = ParameterDirection.Input;
			parm_accountdep.SourceColumn = MaterialDayArrivedData.ACCOUNTDEP_FIELD;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = MaterialDayArrivedData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;
		}
		public bool UpdateMaterialDayArrived(MaterialDayArrivedData infodata)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}  
			//
			// Get the command and update the database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(infodata,MaterialDayArrivedData.MATERIALDAYARRIVED_TABLE);
			//
			// Check it if it update fail;
			//
			if(infodata.HasErrors)
			{
				infodata.Tables[MaterialDayArrivedData.MATERIALDAYARRIVED_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
					infodata.AcceptChanges();
				return true;
			}
		}
		#endregion

		#region Delete data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_MaterialDayArrived",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_vehicleno = new SqlParameter(VEHICLENO_PARM,SqlDbType.Char);
			parm_vehicleno.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_vehicleno);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_provider = new SqlParameter(PROVIDER_PARM,SqlDbType.Char);
			parm_provider.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_provider);

			SqlParameter parm_arrivaldate = new SqlParameter(ARRIVALDATE_PARM,SqlDbType.DateTime);
			parm_arrivaldate.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_arrivaldate);

			return deleteCommand;
		}
		public bool DeleteMaterialDayArrived(string vehicleno,string materialid,string provider,System.DateTime arrivaldate)
		{
			if(dsCommand == null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
		
			SqlCommand deleteCommand  = GetDeleteCommand();

			deleteCommand.Parameters[VEHICLENO_PARM].Value   = vehicleno;
			deleteCommand.Parameters[MATERIALID_PARM].Value  = materialid;
			deleteCommand.Parameters[PROVIDER_PARM].Value    = provider;
			deleteCommand.Parameters[ARRIVALDATE_PARM].Value = arrivaldate;

			try
			{
				deleteCommand.Connection.Open();
				if(deleteCommand.ExecuteNonQuery() > 0 )
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
			}
		}
		#endregion
	}
}
