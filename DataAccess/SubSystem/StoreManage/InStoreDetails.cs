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
	
	public class InStoreDetails:IDisposable
	{
		#region 定义常量及初始化  
		private SqlDataAdapter dsCommand;
		
		private const String MATERIALID_PARM            = "@materialid";
		private const String BATCHNO_PARM               = "@batchno";
		private const String PUB_ATTTRIBUTE_PARM         = "@pub_Attribute";
		private const String ISRID_PARM					 = "@isrid";
		private const String DECLAREAMOUNT_PARM          = "@declareamount";
 
		private const String REALAMOUNT_PARM             = "@realamount";
		private const String UNIT_PARM                   = "@unit";
		private const String CHANGERATE_PARM             = "@changerate";
		private const String PRICE_PARM                  = "@price";
		private const String TAXRATE_PARM                = "@taxrate";

		private const String DISCOUNTRATE_PARM            = "@discountrate";
		private const string ALLSUM_PARM                   = "@ALLsum";
		private const String DISCOUNTSUM_PARM           = "@discountsum";
		private const String WITHOUTTAXSUM_PARM         = "@withouttaxsum";
		private const String TAXSUM_PARM                = "@taxsum";

		private const String QCRID_PARM                   = "@qcrid";
		private const String DESCRIPTION_PARM             = "@description";
		private const String OLDMATERIALID_PARM             = "@oldmaterialid";
		private const String OLDBATCHNO_PARM            = "@oldbatchno";
		private const String OLDPUB_ATTTRIBUTE_PARM         = "@oldpub_Attribute";


	
		public InStoreDetails()
		{
			dsCommand= new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",InStoreDetailData.INSTOREDETAIL_TABLE);

		}

		#endregion
	
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

		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadsCommand=new SqlCommand("Q_InStoreDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
			parm_isrid.Direction = ParameterDirection.Input;
			loadsCommand.Parameters.Add(parm_isrid);
			
			return loadsCommand;
		}
		public InStoreDetailData LoadInStoreDetail(string isrid)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			InStoreDetailData data = new InStoreDetailData();
			dsCommand.SelectCommand = GetLoadCommand();
			dsCommand.SelectCommand.Parameters[ISRID_PARM].Value = isrid;

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

		#region 条件读取入库单信息
		//Begin of Added by YiChangxin 2005-8-26
		private SqlCommand GetsLoadCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)

				strsql = "select t.*,m.Model,m.MaterialName "
					+ "from (select * from TBL_InStoreDetail where " + filter + ") t "
					
					+ "left join TBL_Material m on t.MaterialID=m.MaterialID ";
		
			else					
		
				strsql = "select t.*,m.Model,m.MaterialName"
					+ "from TBL_InStoreDetail t "
					+ "left join TBL_Material m on t.MaterialID=m.MaterialID ";
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public InStoreDetailData LoadsInStoreDetail(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			InStoreDetailData data = new InStoreDetailData();
			
			dsCommand.SelectCommand = GetsLoadCommand(filter);
			
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
		//End of Added 2005-8-26
		#endregion
		
		#region  添加数据
		private SqlCommand GetInsertCommand()
		
		{
			SqlCommand insertCommand=new SqlCommand("I_InStoreDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType=CommandType.StoredProcedure;
				
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
			parm_materialid.SourceColumn = InStoreDetailData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.SourceColumn=InStoreDetailData.BATCHNO_FIELD;
			parm_batchno.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_batchno);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_pub_Attribute.SourceColumn = InStoreDetailData.PUB_ATTTRIBUTE_FIELD;
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_pub_Attribute);
				
			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
			parm_isrid.SourceColumn = InStoreDetailData.ISRID_FIELD;
			parm_isrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_isrid);
				
			SqlParameter parm_declareamount = new SqlParameter(DECLAREAMOUNT_PARM, SqlDbType.Decimal);
			parm_declareamount.SourceColumn = InStoreDetailData.DECLAREAMOUNT_FIELD;
			parm_declareamount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_declareamount);
				
			SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM, SqlDbType.Decimal);
			parm_realamount.SourceColumn = InStoreDetailData.REALAMOUNT_FIELD;
			parm_realamount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_realamount);
				
			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char, 10);
			parm_unit.SourceColumn = InStoreDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_unit);
				
			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = InStoreDetailData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_changerate);
				
			SqlParameter parm_price = new SqlParameter(PRICE_PARM, SqlDbType.Decimal);
			parm_price.SourceColumn = InStoreDetailData.PRICE_FIELD;
			parm_price.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_price);
				
			SqlParameter parm_ALLSUM = new SqlParameter(ALLSUM_PARM, SqlDbType.Decimal);
			parm_ALLSUM.SourceColumn = InStoreDetailData.ALLSUM_FIELD;
			parm_ALLSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ALLSUM);
				
			SqlParameter parm_discountSUM = new SqlParameter(DISCOUNTSUM_PARM, SqlDbType.Decimal);
			parm_discountSUM.SourceColumn = InStoreDetailData.DISCOUNTSUM_FIELD;
			parm_discountSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discountSUM);
				
			SqlParameter parm_WITHOUTTAXSUM = new SqlParameter(WITHOUTTAXSUM_PARM, SqlDbType.Decimal);
			parm_WITHOUTTAXSUM.SourceColumn = InStoreDetailData.WITHOUTTAXSUM_FIELD;
			parm_WITHOUTTAXSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_WITHOUTTAXSUM);
				
			SqlParameter parm_taxSUM = new SqlParameter(TAXSUM_PARM, SqlDbType.Decimal);
			parm_taxSUM.SourceColumn = InStoreDetailData.TAXSUM_FIELD;
			parm_taxSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxSUM);
				
			SqlParameter parm_taxrate = new SqlParameter(TAXRATE_PARM, SqlDbType.Decimal);
			parm_taxrate.SourceColumn = InStoreDetailData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxrate);
				
			SqlParameter parm_discountrate = new SqlParameter(DISCOUNTRATE_PARM, SqlDbType.Decimal);
			parm_discountrate.SourceColumn = InStoreDetailData.DISCOUNTRATE_FIELD;
			parm_discountrate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discountrate);
				
			SqlParameter parm_qcrid = new SqlParameter(QCRID_PARM, SqlDbType.Char,28);
			parm_qcrid.SourceColumn = InStoreDetailData.QCRID_FIELD;
			parm_qcrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_qcrid);
				
			SqlParameter parm_description= new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 200);
			parm_description.SourceColumn = InStoreDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);
			
			return insertCommand;
		}
		public bool InsertInStoreDetail(InStoreDetailData data)			
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.InsertCommand = GetInsertCommand();
           
			try
			{
				dsCommand.Update(data,InStoreDetailData.INSTOREDETAIL_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[InStoreDetailData.INSTOREDETAIL_TABLE].GetErrors()[0].ClearErrors();
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

		#region  修改数据

		private SqlCommand GetUpdateCommanddetail()
		{
			
			SqlCommand updateCommand=new SqlCommand("U_Instoredetail",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType=CommandType.StoredProcedure;
			
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
			parm_materialid.SourceColumn = InStoreDetailData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.SourceColumn=InStoreDetailData.BATCHNO_FIELD;
			parm_batchno.Direction=ParameterDirection.Input;
			parm_batchno.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_batchno);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_pub_Attribute.SourceColumn = InStoreDetailData.PUB_ATTTRIBUTE_FIELD;
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			parm_pub_Attribute.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_pub_Attribute);

			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM, SqlDbType.Char, 20);
			parm_oldmaterialid.Direction = ParameterDirection.Input;
			parm_oldmaterialid.SourceColumn = InStoreDetailData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_oldbatchno=new SqlParameter(OLDBATCHNO_PARM,SqlDbType.Char,28);
			parm_oldbatchno.Direction=ParameterDirection.Input;
			parm_oldbatchno.SourceColumn=InStoreDetailData.BATCHNO_FIELD;
			parm_oldbatchno.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldbatchno);

			SqlParameter parm_oldpub_Attribute = new SqlParameter(OLDPUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_oldpub_Attribute.Direction = ParameterDirection.Input;
			parm_oldpub_Attribute.SourceColumn = InStoreDetailData.PUB_ATTTRIBUTE_FIELD;
			parm_oldpub_Attribute.SourceVersion = DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldpub_Attribute);
				
		
			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
			parm_isrid.SourceColumn = InStoreDetailData.ISRID_FIELD;
			parm_isrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_isrid);
				
			SqlParameter parm_declareamount = new SqlParameter(DECLAREAMOUNT_PARM, SqlDbType.Decimal);
			parm_declareamount.SourceColumn = InStoreDetailData.DECLAREAMOUNT_FIELD;
			parm_declareamount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_declareamount);
				
			SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM, SqlDbType.Decimal);
			parm_realamount.SourceColumn = InStoreDetailData.REALAMOUNT_FIELD;
			parm_realamount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_realamount);
				
			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char, 10);
			parm_unit.SourceColumn = InStoreDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_unit);
				
			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = InStoreDetailData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_changerate);
				
			SqlParameter parm_price = new SqlParameter(PRICE_PARM, SqlDbType.Decimal);
			parm_price.SourceColumn = InStoreDetailData.PRICE_FIELD;
			parm_price.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_price);
				
			SqlParameter parm_ALLSUM = new SqlParameter(ALLSUM_PARM, SqlDbType.Decimal);
			parm_ALLSUM.SourceColumn = InStoreDetailData.ALLSUM_FIELD;
			parm_ALLSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ALLSUM);
				
			SqlParameter parm_discountSUM = new SqlParameter(DISCOUNTSUM_PARM, SqlDbType.Decimal);
			parm_discountSUM.SourceColumn = InStoreDetailData.DISCOUNTSUM_FIELD;
			parm_discountSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discountSUM);
				
			SqlParameter parm_WITHOUTTAXSUM = new SqlParameter(WITHOUTTAXSUM_PARM, SqlDbType.Decimal);
			parm_WITHOUTTAXSUM.SourceColumn = InStoreDetailData.WITHOUTTAXSUM_FIELD;
			parm_WITHOUTTAXSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_WITHOUTTAXSUM);
				
			SqlParameter parm_taxSUM = new SqlParameter(TAXSUM_PARM, SqlDbType.Decimal);
			parm_taxSUM.SourceColumn = InStoreDetailData.TAXSUM_FIELD;
			parm_taxSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxSUM);
				
			SqlParameter parm_taxrate = new SqlParameter(TAXRATE_PARM, SqlDbType.Decimal);
			parm_taxrate.SourceColumn = InStoreDetailData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxrate);
				
			SqlParameter parm_discountrate = new SqlParameter(DISCOUNTRATE_PARM, SqlDbType.Decimal);
			parm_discountrate.SourceColumn = InStoreDetailData.DISCOUNTRATE_FIELD;
			parm_discountrate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discountrate);
				
			SqlParameter parm_qcrid = new SqlParameter(QCRID_PARM, SqlDbType.Char,28);
			parm_qcrid.SourceColumn = InStoreDetailData.QCRID_FIELD;
			parm_qcrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_qcrid);
				
			SqlParameter parm_description= new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 200);
			parm_description.SourceColumn = InStoreDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);
			

			
			return updateCommand;
		}

		public bool UpdateInStoreDetail(InStoreDetailData data)
		{
			 
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.UpdateCommand = GetUpdateCommanddetail();

			try
			{
				dsCommand.Update(data, InStoreDetailData.INSTOREDETAIL_TABLE);

				if ( data.HasErrors )
				{
					data.Tables[InStoreData.INSTORE_TABLE].GetErrors()[0].ClearErrors();
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
		//Begin of Modified by YiChangXin 2005-8-26
		//修改传入参数顺序
		private SqlCommand GetDeleteInStoreDetail()
		{
			
			SqlCommand deleteCommand=new SqlCommand("D_Instoredemail",new SqlConnection(ERPConfiguration.ConnectionString));
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
				
			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char,28);
			parm_isrid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_isrid);
			
			return deleteCommand;
		} 
		public bool DeleteInStoreDetail(string isrid,string materialid,string batchnumber,string pub_attribute)
		{
			SqlCommand DeleteCommand=GetDeleteInStoreDetail();
			DeleteCommand.Parameters[MATERIALID_PARM].Value = materialid;
			DeleteCommand.Parameters[BATCHNO_PARM].Value = batchnumber;
			DeleteCommand.Parameters[PUB_ATTTRIBUTE_PARM].Value = pub_attribute;
			DeleteCommand.Parameters[ISRID_PARM].Value = isrid;
          
			try
			{
				DeleteCommand.Connection.Open();
				int i = DeleteCommand.ExecuteNonQuery();
				DeleteCommand.Connection.Close();
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
				DeleteCommand.Connection.Close();
			}
		}
		//End of Modified 2005-8-26
		#endregion
		
	}	
}
