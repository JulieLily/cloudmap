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

	public class OutStoreDetails:IDisposable
	{
		private SqlDataAdapter dsCommand;
		
		private const String MATERIALID_PARM             = "@materialid";
		private const String BATCHNO_PARM                = "@batchnO";
		private const String PUB_ATTTRIBUTE_PARM         = "@pub_Attribute";
		private const String OSRID_PARM					 = "@osrid";
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
		private const String BALANCEAMOUNT_PARM           = "@balanceamount";
		private const String ADJUSTDATE_PARM              = "@adjustdate";
		private const String ADJUSTTOTAL_PARM             = "@adjusttotal";

		private const String OLDMATERIALID_PARM            = "@oldmaterialid";
		private const String OLDBATCHNO_PARM               = "@oldbatchnO";
		private const String OLDPUB_ATTTRIBUTE_PARM        = "@oldpub_Attribute";

		public OutStoreDetails()
		{
			dsCommand= new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",OutStoreDetailData.OUTSTOREDETAIL_TABLE);

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

		#region 读取数据
		//begin of Modifyed by XuJiansong 2005-8-22
		private SqlCommand GetloadsCommand()
		{
			
			SqlCommand loadsCommand=new SqlCommand("Q_OutStoreDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType=CommandType.StoredProcedure;

			// xujiansong ---add 根据主表的出库id 读取明细表

			SqlParameter parm_orsid = new SqlParameter(OSRID_PARM ,SqlDbType.Char);
			parm_orsid.Direction =ParameterDirection.Input;
			loadsCommand.Parameters.Add(parm_orsid);
			
			return loadsCommand;
		}
		public OutStoreDetailData loadOutStoreDetail(string osrid)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			OutStoreDetailData data=new OutStoreDetailData();
			dsCommand.SelectCommand=GetloadsCommand();
			dsCommand.SelectCommand.Parameters[OSRID_PARM].Value =osrid;
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

		//end of Modifyed by XuJiansong 2005-8-22
		#endregion

		#region 条件读取销售退货明细信息
		//Added by YiChangXin 2005-8-25
		private SqlCommand GetsLoadCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)

				strsql = "select t.*,m.Model,m.MaterialName "
					+ "from (select * from TBL_OutStoreDetail where " + filter + ") t "
					
					+ "left join TBL_Material m on t.MaterialID=m.MaterialID ";
		
			else					
		
				strsql = "select t.*,m.Model,m.MaterialName"
					+ "from TBL_OutStoreDetail t "
					+ "left join TBL_Material m on t.MaterialID=m.MaterialID ";
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public OutStoreDetailData LoadsOutStoreDetail(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			OutStoreDetailData data = new OutStoreDetailData();
			
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
		#endregion

		#region  添加数据
		private SqlCommand GetInsertCommand()
		
		{
			
			SqlCommand insertCommand=new SqlCommand("I_OutStoreDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType=CommandType.StoredProcedure;
				
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
			parm_materialid.SourceColumn = OutStoreDetailData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_BATCHNO=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_BATCHNO.SourceColumn=OutStoreDetailData.BATCHNO_FIELD;
			parm_BATCHNO.Direction=ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_BATCHNO);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_pub_Attribute.SourceColumn = OutStoreDetailData.PUB_ATTTRIBUTE_FIELD;
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_pub_Attribute);

				
			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char,28);
			parm_osrid.SourceColumn = OutStoreDetailData.OSRID_FIELD;
			parm_osrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_osrid);
				
			SqlParameter parm_declareamount = new SqlParameter(DECLAREAMOUNT_PARM, SqlDbType.Decimal);
			parm_declareamount.SourceColumn = OutStoreDetailData.DECLAREAMOUNT_FIELD;
			parm_declareamount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_declareamount);
				
			SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM, SqlDbType.Decimal);
			parm_realamount.SourceColumn = OutStoreDetailData.REALAMOUNT_FIELD;
			parm_realamount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_realamount);
				
			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char, 10);
			parm_unit.SourceColumn = OutStoreDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_unit);
				
			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = OutStoreDetailData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_changerate);
				
			SqlParameter parm_price = new SqlParameter(PRICE_PARM, SqlDbType.Decimal);
			parm_price.SourceColumn = OutStoreDetailData.PRICE_FIELD;
			parm_price.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_price);
				
			SqlParameter parm_SUM = new SqlParameter(ALLSUM_PARM, SqlDbType.Decimal);
			parm_SUM.SourceColumn = OutStoreDetailData.ALLSUM_FIELD;
			parm_SUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_SUM);
				
			SqlParameter parm_discountSUM = new SqlParameter(DISCOUNTSUM_PARM, SqlDbType.Decimal);
			parm_discountSUM.SourceColumn = OutStoreDetailData.DISCOUNTSUM_FIELD;
			parm_discountSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discountSUM);
				
			SqlParameter parm_WITHOUTTAXSUM = new SqlParameter(WITHOUTTAXSUM_PARM, SqlDbType.Decimal);
			parm_WITHOUTTAXSUM.SourceColumn = OutStoreDetailData.WITHOUTTAXSUM_FIELD;
			parm_WITHOUTTAXSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_WITHOUTTAXSUM);
				
			SqlParameter parm_taxSUM = new SqlParameter(TAXSUM_PARM, SqlDbType.Decimal);
			parm_taxSUM.SourceColumn = OutStoreDetailData.TAXSUM_FIELD;
			parm_taxSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxSUM);
				
			SqlParameter parm_taxrate = new SqlParameter(TAXRATE_PARM, SqlDbType.Char, 10);
			parm_taxrate.SourceColumn = OutStoreDetailData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxrate);
				
			SqlParameter parm_discountrate = new SqlParameter(DISCOUNTRATE_PARM, SqlDbType.Char,10);
			parm_discountrate.SourceColumn = OutStoreDetailData.DISCOUNTRATE_FIELD;
			parm_discountrate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discountrate);
				
			SqlParameter parm_qcrid = new SqlParameter(QCRID_PARM, SqlDbType.Char,28);
			parm_qcrid.SourceColumn = OutStoreDetailData.QCRID_FIELD;
			parm_qcrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_qcrid);
				
			SqlParameter parm_description= new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 200);
			parm_description.SourceColumn = OutStoreDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_balanceamount = new SqlParameter(BALANCEAMOUNT_PARM, SqlDbType.Decimal);
			parm_balanceamount.SourceColumn = OutStoreDetailData.BALANCEAMOUNT_FIELD;
			parm_balanceamount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_balanceamount);
				
			SqlParameter parm_adjustdate = new SqlParameter(ADJUSTDATE_PARM, SqlDbType.DateTime);
			parm_adjustdate.SourceColumn = OutStoreDetailData.ADJUSTDATE_FIELD;
			parm_adjustdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_adjustdate);
				
			SqlParameter parm_ADJUSTTOTAL= new SqlParameter(ADJUSTTOTAL_PARM, SqlDbType.Decimal);
			parm_ADJUSTTOTAL.SourceColumn = OutStoreDetailData.ADJUSTTOTAL_FIELD;
			parm_ADJUSTTOTAL.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ADJUSTTOTAL);
			
			
			return insertCommand;
		}
		public bool InsertOutStoreDetail(OutStoreDetailData data)			
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.InsertCommand = GetInsertCommand();
           
			try
			{
				dsCommand.Update(data,OutStoreDetailData.OUTSTOREDETAIL_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[OutStoreDetailData.OUTSTOREDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand updateCommand=new SqlCommand("U_OutStoredetail",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 20);
			parm_materialid.SourceColumn = OutStoreDetailData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_BATCHNO=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_BATCHNO.SourceColumn=OutStoreDetailData.BATCHNO_FIELD;
			parm_BATCHNO.SourceVersion = DataRowVersion.Current;
			parm_BATCHNO.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_BATCHNO);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_pub_Attribute.SourceColumn = OutStoreDetailData.PUB_ATTTRIBUTE_FIELD;
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			parm_pub_Attribute.SourceVersion =DataRowVersion.Current;
			updateCommand.Parameters.Add(parm_pub_Attribute);

			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM, SqlDbType.Char, 20);
			parm_oldmaterialid.Direction = ParameterDirection.Input;
			parm_oldmaterialid.SourceColumn=OutStoreDetailData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion=DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_oldBATCHNO=new SqlParameter(OLDBATCHNO_PARM,SqlDbType.Char,28);
			parm_oldBATCHNO.Direction=ParameterDirection.Input;
			parm_oldBATCHNO.SourceColumn=OutStoreDetailData.BATCHNO_FIELD;
			parm_oldBATCHNO.SourceVersion=DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldBATCHNO);

			SqlParameter parm_oldpub_Attribute = new SqlParameter(OLDPUB_ATTTRIBUTE_PARM, SqlDbType.Char, 8);
			parm_oldpub_Attribute.Direction = ParameterDirection.Input;
			parm_oldpub_Attribute.SourceColumn=OutStoreDetailData.PUB_ATTTRIBUTE_FIELD;
			parm_oldpub_Attribute.SourceVersion=DataRowVersion.Original;
			updateCommand.Parameters.Add(parm_oldpub_Attribute);
				
			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char,28);
			parm_osrid.SourceColumn = OutStoreDetailData.OSRID_FIELD;
			parm_osrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_osrid);
				
			SqlParameter parm_declareamount = new SqlParameter(DECLAREAMOUNT_PARM, SqlDbType.Decimal);
			parm_declareamount.SourceColumn = OutStoreDetailData.DECLAREAMOUNT_FIELD;
			parm_declareamount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_declareamount);
				
			SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM, SqlDbType.Decimal);
			parm_realamount.SourceColumn = OutStoreDetailData.REALAMOUNT_FIELD;
			parm_realamount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_realamount);
				
			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char, 10);
			parm_unit.SourceColumn = OutStoreDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_unit);
				
			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = OutStoreDetailData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_changerate);
				
			SqlParameter parm_price = new SqlParameter(PRICE_PARM, SqlDbType.Decimal);
			parm_price.SourceColumn = OutStoreDetailData.PRICE_FIELD;
			parm_price.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_price);
				
			SqlParameter parm_SUM = new SqlParameter(ALLSUM_PARM, SqlDbType.Decimal);
			parm_SUM.SourceColumn = OutStoreDetailData.ALLSUM_FIELD;
			parm_SUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_SUM);
				
			SqlParameter parm_discountSUM = new SqlParameter(DISCOUNTSUM_PARM, SqlDbType.Decimal);
			parm_discountSUM.SourceColumn = OutStoreDetailData.DISCOUNTSUM_FIELD;
			parm_discountSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discountSUM);
				
			SqlParameter parm_WITHOUTTAXSUM = new SqlParameter(WITHOUTTAXSUM_PARM, SqlDbType.Decimal);
			parm_WITHOUTTAXSUM.SourceColumn = OutStoreDetailData.WITHOUTTAXSUM_FIELD;
			parm_WITHOUTTAXSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_WITHOUTTAXSUM);
				
			SqlParameter parm_taxSUM = new SqlParameter(TAXSUM_PARM, SqlDbType.Decimal);
			parm_taxSUM.SourceColumn = OutStoreDetailData.TAXSUM_FIELD;
			parm_taxSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxSUM);
				
			SqlParameter parm_taxrate = new SqlParameter(TAXRATE_PARM, SqlDbType.Char, 10);
			parm_taxrate.SourceColumn = OutStoreDetailData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxrate);
				
			SqlParameter parm_discountrate = new SqlParameter(DISCOUNTRATE_PARM, SqlDbType.Char,10);
			parm_discountrate.SourceColumn = OutStoreDetailData.DISCOUNTRATE_FIELD;
			parm_discountrate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discountrate);
				
			SqlParameter parm_qcrid = new SqlParameter(QCRID_PARM, SqlDbType.Char,28);
			parm_qcrid.SourceColumn = OutStoreDetailData.QCRID_FIELD;
			parm_qcrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_qcrid);
				
			SqlParameter parm_description= new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 200);
			parm_description.SourceColumn = OutStoreDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);

			SqlParameter parm_balanceamount = new SqlParameter(BALANCEAMOUNT_PARM, SqlDbType.Decimal);
			parm_balanceamount.SourceColumn = OutStoreDetailData.BALANCEAMOUNT_FIELD;
			parm_balanceamount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_balanceamount);
				
			SqlParameter parm_adjustdate = new SqlParameter(ADJUSTDATE_PARM, SqlDbType.DateTime);
			parm_adjustdate.SourceColumn = OutStoreDetailData.ADJUSTDATE_FIELD;
			parm_adjustdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_adjustdate);
				
			SqlParameter parm_ADJUSTTOTAL= new SqlParameter(ADJUSTTOTAL_PARM, SqlDbType.Decimal);
			parm_ADJUSTTOTAL.SourceColumn = OutStoreDetailData.ADJUSTTOTAL_FIELD;
			parm_ADJUSTTOTAL.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ADJUSTTOTAL);
			
				
			return updateCommand;
		}

		public bool UpdateOutStoreDetail(OutStoreDetailData data)
		{
			 
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.UpdateCommand = GetUpdateCommanddetail();

			try
			{
				dsCommand.Update(data, OutStoreDetailData.OUTSTOREDETAIL_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[OutStoreDetailData.OUTSTOREDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand deleteCommand=new SqlCommand("D_OutStoreDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char, 10);
			parm_materialid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_BATCHNO=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_BATCHNO.Direction=ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_BATCHNO);

			SqlParameter parm_pub_Attribute = new SqlParameter(PUB_ATTTRIBUTE_PARM, SqlDbType.Char, 40);
			parm_pub_Attribute.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_pub_Attribute);
				
			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char,28);
			parm_osrid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_osrid);
					
			return deleteCommand;
		} 
		public bool DeleteOutStoreDetail(string Osrid,string materialid,string BATCHNO,string pub_attribute)
		{
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[MATERIALID_PARM].Value= materialid;
			deleteCommand.Parameters[BATCHNO_PARM].Value= BATCHNO;
			deleteCommand.Parameters[PUB_ATTTRIBUTE_PARM].Value= pub_attribute;
			deleteCommand.Parameters[OSRID_PARM].Value= Osrid;
           
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
