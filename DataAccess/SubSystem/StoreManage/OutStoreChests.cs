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
	public class OutStoreChests:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const string MATERIALID_PARM            ="@materialid";   
		private const string BATCHNO_PARM 			    ="@batchNO";
		private const string PUB_ATTTRIBUTE_PARM 	    ="@pub_Attribute";
		private const string OSRID_PARM 					="@osrid";
		private const string PLACEID_PARM                ="@placeid"; 
		private const string CHESTID_PARM 			    ="@chestid";
		private const string OLDCHESTID_PARM 			    ="@oldchestid";

		private const string UNIT_PARM 		            ="@unit";
		private const string PIECES_PARM 					="@pieces";
		private const string CHANGERATE_PARM 			="@changerate";
		private const string WEIGHT_PARM 				="@weight";
		private const string DESCRIPTION_PARM 			="@description";

		public OutStoreChests()
		{
		    dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",OutStoreChestData.OUTSTORECHEST_TABLE);
			
		}

		#region 释放资源
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); // as a service to those who might inherit from us
		}


		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; // we're being collected, so let the GC take care of this object

			if (dsCommand != null)
			{
				if(dsCommand.SelectCommand != null)
				{
					if( dsCommand.SelectCommand.Connection != null  )
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				} 
				if(dsCommand.DeleteCommand != null)
				{
					if( dsCommand.DeleteCommand.Connection != null  )
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}    
				if(dsCommand.UpdateCommand != null)
				{
					if( dsCommand.UpdateCommand.Connection != null  )
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}    
				if(dsCommand.InsertCommand != null)
				{
					if( dsCommand.InsertCommand.Connection != null  )
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}    
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion

		#region  读数据
		private SqlCommand GetloadCommand()
		{
			
				SqlCommand loadCommand=new SqlCommand("Q_outstoreChest",new SqlConnection(ERPConfiguration.ConnectionString));
				loadCommand.CommandType=CommandType.StoredProcedure;
			
			return loadCommand;
		}
		public OutStoreChestData loadoutstoreChest()
		{
			if(dsCommand==null)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			OutStoreChestData data = new OutStoreChestData();
			dsCommand.SelectCommand=GetloadCommand();
			dsCommand.Fill(data);
			return data;
		}
		#endregion

		#region  添加记录
		private SqlCommand GetInsertCommand()
		{
			
				SqlCommand insertCommand=new SqlCommand("I_OutStoreChest",new SqlConnection(ERPConfiguration.ConnectionString));
				insertCommand.CommandType=CommandType.StoredProcedure;

				SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
				parm_materialid.SourceColumn = OutStoreChestData.MATERIALID_FIELD;
				parm_materialid.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_materialid);

				SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
				parm_batchno.SourceColumn=OutStoreChestData.BATCHNO_FIELD;
				parm_batchno.Direction=ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_batchno);

				SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
				parm_pub_Attribute.SourceColumn = OutStoreChestData.PUB_ATTTRIBUTE_FIELD;
				parm_pub_Attribute.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_pub_Attribute);
				
				SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char,28);
				parm_osrid.SourceColumn = OutStoreChestData.OSRID_FIELD;
				parm_osrid.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_osrid);
				
				SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM, SqlDbType.Char,6);
				parm_placeid.SourceColumn = OutStoreChestData.PLACEID_FIELD;
				parm_placeid.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_placeid);
				
				SqlParameter parm_chestID = new SqlParameter(CHESTID_PARM, SqlDbType.Char,20);
				parm_chestID.SourceColumn = OutStoreChestData.CHESTID_FIELD;
				parm_chestID.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_chestID);

				
				SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char,10);
				parm_unit.SourceColumn = OutStoreChestData.UNIT_FIELD;
				parm_unit.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_unit);

				SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
				parm_changerate.SourceColumn = OutStoreChestData.CHANGERATE_FIELD;
				parm_changerate.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_changerate);

				SqlParameter parm_weight = new SqlParameter(WEIGHT_PARM, SqlDbType.Decimal);
				parm_weight.SourceColumn = OutStoreChestData.WEIGHT_FIELD;
				parm_weight.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_weight);
				
				
				SqlParameter parm_pieces = new SqlParameter(PIECES_PARM, SqlDbType.SmallInt);
				parm_pieces.SourceColumn = OutStoreChestData.PIECES_FIELD;
				parm_pieces.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_pieces);
				
				SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar,200);
				parm_description.SourceColumn = OutStoreChestData.DESCRIPTION_FIELD;
				parm_description.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_description);
			
			return insertCommand;
		}

		public bool InsertOutstoreChest(OutStoreChestData data)			
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.InsertCommand = GetInsertCommand();
           
			try
			{
				dsCommand.Update(data,OutStoreChestData.OUTSTORECHEST_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[OutStoreChestData.OUTSTORECHEST_TABLE].GetErrors()[0].ClearErrors();
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

		#region 修改记录

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand= new SqlCommand("U_OutstoreChest",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType=CommandType.StoredProcedure;
			    
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
			parm_materialid.SourceColumn = OutStoreChestData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.SourceColumn=OutStoreChestData.BATCHNO_FIELD;
			parm_batchno.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_batchno);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_pub_Attribute.SourceColumn = OutStoreChestData.PUB_ATTTRIBUTE_FIELD;
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_pub_Attribute);
				
			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char,28);
			parm_osrid.SourceColumn = OutStoreChestData.OSRID_FIELD;
			parm_osrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_osrid);
				
			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM, SqlDbType.Char,6);
			parm_placeid.SourceColumn = OutStoreChestData.PLACEID_FIELD;
			parm_placeid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_placeid);
				
			SqlParameter parm_chestID = new SqlParameter(CHESTID_PARM, SqlDbType.Char,20);
			parm_chestID.SourceColumn = OutStoreChestData.CHESTID_FIELD;
			parm_chestID.SourceVersion = DataRowVersion.Current;
			parm_chestID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_chestID);

			SqlParameter parm_oldchestID = new SqlParameter(OLDCHESTID_PARM, SqlDbType.Char,20);
			parm_oldchestID.SourceColumn = OutStoreChestData.CHESTID_FIELD;
			parm_oldchestID.SourceVersion = DataRowVersion.Original;
			parm_oldchestID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldchestID);
		
			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char,10);
			parm_unit.SourceColumn = OutStoreChestData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = OutStoreChestData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_changerate);

			SqlParameter parm_weight = new SqlParameter(WEIGHT_PARM, SqlDbType.Decimal);
			parm_weight.SourceColumn = OutStoreChestData.WEIGHT_FIELD;
			parm_weight.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_weight);
				
				
			SqlParameter parm_pieces = new SqlParameter(PIECES_PARM, SqlDbType.SmallInt);
			parm_pieces.SourceColumn = OutStoreChestData.PIECES_FIELD;
			parm_pieces.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_pieces);
				
			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar,200);
			parm_description.SourceColumn = OutStoreChestData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);
			


			
			return updateCommand;
		}

		public bool UpdateOutstoreChest(OutStoreChestData data)
		{
			 
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.UpdateCommand = GetUpdateCommand();

			try
			{
				dsCommand.Update(data, OutStoreChestData.OUTSTORECHEST_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[OutStoreChestData.OUTSTORECHEST_TABLE].GetErrors()[0].ClearErrors();
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

		#region  删除记录


		private SqlCommand GetDeleteOutstoreChest()
		{
			SqlCommand deleteCommand=new SqlCommand("D_outstoreChest",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
			parm_materialid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_batchno);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_pub_Attribute);
				
			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char,28);
			parm_osrid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_osrid);

			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM, SqlDbType.Char,6);
			parm_placeid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_placeid);

			SqlParameter parm_chestid = new SqlParameter(CHESTID_PARM, SqlDbType.Char,20);
			parm_chestid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_chestid);

			
				


			
			return deleteCommand;
		}

		public bool DeleteOutstoreChest(string materialid,string batchnumber,string pub_attribute,string Isrid,string placeid,string chestid)
		{
			SqlCommand deleteCommand = GetDeleteOutstoreChest();
			deleteCommand.Parameters[MATERIALID_PARM].Value= materialid;
			deleteCommand.Parameters[BATCHNO_PARM].Value= batchnumber;
			deleteCommand.Parameters[PUB_ATTTRIBUTE_PARM].Value= pub_attribute;
			deleteCommand.Parameters[OSRID_PARM].Value= Isrid;
			deleteCommand.Parameters[PLACEID_PARM].Value= placeid;
			deleteCommand.Parameters[CHESTID_PARM].Value= chestid;
     
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
