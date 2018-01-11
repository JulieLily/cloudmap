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

	
	public class InStorePlaces:IDisposable

	{
		private SqlDataAdapter dsCommand;

		private const string MATERIALID_PARM            ="@materialid";    
		private const string BATCHNO_PARM			    ="@batchNO";
		private const string PUB_ATTTRIBUTE_PARM		="@pub_Attribute";
		private const string ISRID_PARM					="@isrid";
		private const string PLACEID_PARM                ="@placeid";    
		private const string CHESTAMOUNT_PARM			="@chestamount";
		private const string REALAMOUNT_PARM		    ="@realamount";
		private const string PIECES_PARM					="@pieces";
		private const string DESCRIPTION_PARM			="@description";
		private const string OLDPLACEID_PARM           ="@oldplaceid";

		public InStorePlaces()
		{

			dsCommand= new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",InStorePlaceData.INSTOREPLACE_TABLE);

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
			
			    SqlCommand loadCommand=new SqlCommand("Q_InStoreplace",new SqlConnection(ERPConfiguration.ConnectionString));
				loadCommand.CommandType=CommandType.StoredProcedure;
			
			return loadCommand;
		}
		public InStorePlaceData loadInStorePlace()
		{
			if(dsCommand==null)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			InStorePlaceData data = new InStorePlaceData();
			dsCommand.SelectCommand=GetloadCommand();
			dsCommand.Fill(data);
			return data;
		}
		#endregion

		#region  添加记录
		private SqlCommand GetInsertCommand()
		{
			
			    SqlCommand insertCommand=new SqlCommand("I_InStoreplace",new SqlConnection(ERPConfiguration.ConnectionString));
				insertCommand.CommandType=CommandType.StoredProcedure;

				SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
				parm_materialid.SourceColumn = InStorePlaceData.MATERIALID_FIELD;
				parm_materialid.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_materialid);

				SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
				parm_batchno.SourceColumn=InStorePlaceData.BATCHNO_FIELD;
				parm_batchno.Direction=ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_batchno);

				SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
				parm_pub_Attribute.SourceColumn = InStorePlaceData.PUB_ATTTRIBUTE_FIELD;
				parm_pub_Attribute.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_pub_Attribute);
				
				SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
				parm_isrid.SourceColumn = InStorePlaceData.ISRID_FIELD;
				parm_isrid.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_isrid);
				
				SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM, SqlDbType.Char,6);
				parm_placeid.SourceColumn = InStorePlaceData.PLACEID_FIELD;
				parm_placeid.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_placeid);
				
				SqlParameter parm_chestamount = new SqlParameter(CHESTAMOUNT_PARM, SqlDbType.SmallInt);
				parm_chestamount.SourceColumn = InStorePlaceData.CHESTAMOUNT_FIELD;
				parm_chestamount.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_chestamount);
				
				SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM, SqlDbType.Decimal);
				parm_realamount.SourceColumn = InStorePlaceData.REALAMOUNT_FIELD;
				parm_realamount.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_realamount);
				
				
				SqlParameter parm_pieces = new SqlParameter(PIECES_PARM, SqlDbType.SmallInt);
				parm_pieces.SourceColumn = InStorePlaceData.PIECES_FIELD;
				parm_pieces.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_pieces);
				
				SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar,200);
				parm_description.SourceColumn = InStorePlaceData.DESCRIPTION_FIELD;
				parm_description.Direction = ParameterDirection.Input;
				insertCommand.Parameters.Add(parm_description);
			
			return insertCommand;
		}

		public bool InsertInstoreplace(InStorePlaceData data)			
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.InsertCommand = GetInsertCommand();
           
			try
			{
				dsCommand.Update(data,InStorePlaceData.INSTOREPLACE_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[InStorePlaceData.INSTOREPLACE_TABLE].GetErrors()[0].ClearErrors();
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
			
				SqlCommand updateCommand= new SqlCommand("U_Instoreplace",new SqlConnection(ERPConfiguration.ConnectionString));
				updateCommand.CommandType=CommandType.StoredProcedure;

				SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
				parm_materialid.SourceColumn = InStorePlaceData.MATERIALID_FIELD;
				parm_materialid.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_materialid);

				SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
				parm_batchno.SourceColumn=InStorePlaceData.BATCHNO_FIELD;
				parm_batchno.Direction=ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_batchno);

				SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
				parm_pub_Attribute.SourceColumn = InStorePlaceData.PUB_ATTTRIBUTE_FIELD;
				parm_pub_Attribute.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_pub_Attribute);
				
				SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
				parm_isrid.SourceColumn = InStorePlaceData.ISRID_FIELD;
				parm_isrid.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_isrid);
				
				SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM, SqlDbType.Char,6);
				parm_placeid.SourceColumn = InStorePlaceData.PLACEID_FIELD;
				parm_placeid.SourceVersion=DataRowVersion.Current;
				parm_placeid.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_placeid);

				SqlParameter parm_oldplaceid=new SqlParameter(OLDPLACEID_PARM,SqlDbType.Char,6);
				parm_oldplaceid.Direction=ParameterDirection.Input;
				parm_oldplaceid.SourceColumn = InStorePlaceData.PLACEID_FIELD;
				parm_oldplaceid.SourceVersion=DataRowVersion.Original;
				updateCommand.Parameters.Add(parm_oldplaceid);
				
				SqlParameter parm_chestamount = new SqlParameter(CHESTAMOUNT_PARM, SqlDbType.SmallInt);
				parm_chestamount.SourceColumn = InStorePlaceData.CHESTAMOUNT_FIELD;
				parm_chestamount.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_chestamount);
				
				SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM, SqlDbType.Decimal);
				parm_realamount.SourceColumn = InStorePlaceData.REALAMOUNT_FIELD;
				parm_realamount.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_realamount);
				
				
				SqlParameter parm_pieces = new SqlParameter(PIECES_PARM, SqlDbType.SmallInt);
				parm_pieces.SourceColumn = InStorePlaceData.PIECES_FIELD;
				parm_pieces.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_pieces);
				
				SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar,200);
				parm_description.SourceColumn = InStorePlaceData.DESCRIPTION_FIELD;
				parm_description.Direction = ParameterDirection.Input;
				updateCommand.Parameters.Add(parm_description);


			
			return updateCommand;
		}

		public bool UpdateInstorePlace(InStorePlaceData data)
		{
			 
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.UpdateCommand = GetUpdateCommand();

			try
		    {
			   dsCommand.Update(data, InStorePlaceData.INSTOREPLACE_TABLE);
			   if ( data.HasErrors )
			   {
				  data.Tables[InStorePlaceData.INSTOREPLACE_TABLE].GetErrors()[0].ClearErrors();
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


		private SqlCommand GetDeleteCommand()
		{
			
				SqlCommand deleteCommand=new SqlCommand("D_Instoreplace",new SqlConnection(ERPConfiguration.ConnectionString));
				deleteCommand.CommandType=CommandType.StoredProcedure;

				SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
				parm_materialid.Direction = ParameterDirection.Input;
				deleteCommand.Parameters.Add(parm_materialid);

				SqlParameter parm_batchnumber=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
				parm_batchnumber.Direction=ParameterDirection.Input;
				deleteCommand.Parameters.Add(parm_batchnumber);

				SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
				parm_pub_Attribute.Direction = ParameterDirection.Input;
				deleteCommand.Parameters.Add(parm_pub_Attribute);
				
				SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
				parm_isrid.SourceColumn = InStoreDetailData.ISRID_FIELD;
				parm_isrid.Direction = ParameterDirection.Input;
				deleteCommand.Parameters.Add(parm_isrid);

				SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM, SqlDbType.Char,6);
				parm_placeid.Direction = ParameterDirection.Input;
				deleteCommand.Parameters.Add(parm_placeid);



			
			return deleteCommand;
		}

		public bool DeleteInstorePlace(string materialid,string batchnumber,string pub_attribute,string Isrid,string placeid)
		{
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[MATERIALID_PARM].Value= materialid;
			deleteCommand.Parameters[BATCHNO_PARM].Value= batchnumber;
			deleteCommand.Parameters[PUB_ATTTRIBUTE_PARM].Value= pub_attribute;
			deleteCommand.Parameters[ISRID_PARM].Value= Isrid;
			deleteCommand.Parameters[PLACEID_PARM].Value= placeid;


            
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
