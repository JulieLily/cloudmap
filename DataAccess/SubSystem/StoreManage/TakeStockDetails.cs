using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	
	public class TakeStockDetails :IDisposable
	{
		private SqlDataAdapter da;

		
		private const String  OLDPLACEID_PARM				= "@oldPlaceID";
		private const String  OLDMATERIALID_PARM			= "@oldMaterialID";


		private const String  PLACEID_PARM				= "@PlaceID";
		private const String  TSRID_PARM				= "@TSRID";
		private const String  MATERIALID_PARM			= "@MaterialID";
		private const String  INTIME_PARM				= "@InTime";
		private const String  PUB_ATTRIBUTE_PARM		= "@PUB_Attribute";

		private const String  BATCHNO_PARM				= "@BatchNO";
		private const String  STORAGEAMOUNT_PARM		= "@StorageAmount";
		private const String  REALAMOUNT_PARM			= "@RealAmount";
		private const String  UNIT_PARM					= "@Unit";
		private const String  CHANGERATE_PARM			= "@ChangeRate";

		private const String  PRICE_PARM				= "@Price";
		private const String  ISDECLARCHECK_PARM		= "@IsDeclareCheck";
		private const String  HANDWORKREMARK_PARM		= "@HandworkRemark";
		private const string PORLAMOUNT_FIELD			= "@porlamount";//ycx 所加
		private const string PORLSUM_FIELD					= "@porlsum";//ycx 所加



		public TakeStockDetails()
		{
		
			da=new SqlDataAdapter();
			da.TableMappings.Add("Table",TakeStockDetailData.TAKESTOCKDETAIL_TABLE);
		}
		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 
			if(da!=null)
			{
				if(da.SelectCommand!=null)
				{
					if(da.SelectCommand.Connection!=null)
					{
						da.SelectCommand.Connection.Dispose();
					}
					da.SelectCommand.Dispose();
				}

				if(da.InsertCommand!=null)
				{
					if(da.InsertCommand.Connection!=null)
					{
						da.InsertCommand.Connection.Dispose();
					}
					da.InsertCommand.Dispose();
				}

				if(da.UpdateCommand!=null)
				{
					if(da.UpdateCommand.Connection!=null)
					{
						da.UpdateCommand.Connection.Dispose();
					}
					da.UpdateCommand.Dispose();
				}

				//				if(da.DeleteCommand!=null)
				//				{
				//					if(da.DeleteCommand.Connection!=null)
				//					{
				//						da.DeleteCommand.Connection.Dispose();
				//					}
				//					da.DeleteCommand.Dispose();
				//				}
				da.Dispose();
				da=null;
			}
		}

		#endregion

		# region 读取----------盘点详细

		public TakeStockDetailData LoadTakeStockDetail(string tskid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			TakeStockDetailData data = new TakeStockDetailData();
			da.SelectCommand  = GetLoadCommand();
			da.SelectCommand.Parameters[TSRID_PARM].Value = tskid;
			try
			{
				da.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}

		private SqlCommand GetLoadCommand()
		{
			SqlCommand load =new SqlCommand("Q_TakeStockDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_tskid = new SqlParameter(TSRID_PARM, SqlDbType.Char,28);
			parm_tskid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_tskid);

			return load;
		}
		#endregion


		#region 添加记录-------盘点详细

		public bool InsertTakeStockDetail(TakeStockDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			da.InsertCommand=GetInsertCommand();
			da.Update(data ,TakeStockDetailData.TAKESTOCKDETAIL_TABLE);
			if(data.HasErrors)
			{
				data.Tables[TakeStockDetailData.TAKESTOCKDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insert =new SqlCommand("I_TakeStockDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_tsrid = new SqlParameter(TSRID_PARM,SqlDbType.Char,28);
			parm_tsrid.Direction=ParameterDirection.Input;
			parm_tsrid.SourceColumn=TakeStockDetailData.TSRID_FIELD;
			insert.Parameters.Add(parm_tsrid);

			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM,SqlDbType.Char,6);
			parm_placeid.Direction=ParameterDirection.Input;
			parm_placeid.SourceColumn=TakeStockDetailData.PLACEID_FIELD;
			insert.Parameters.Add(parm_placeid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materialid.Direction=ParameterDirection.Input;
			parm_materialid.SourceColumn=TakeStockDetailData.MATERIALID_FIELD;
			insert.Parameters.Add(parm_materialid);
			 
			SqlParameter parm_intime = new SqlParameter(INTIME_PARM,SqlDbType.DateTime,8);
			parm_intime.Direction=ParameterDirection.Input;
			parm_intime.SourceColumn=TakeStockDetailData.INTIME_FIELD;
			insert.Parameters.Add(parm_intime);

			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,8);
			parm_pub_attribute.Direction=ParameterDirection.Input;
			parm_pub_attribute.SourceColumn=TakeStockDetailData.PUB_ATTRIBUTE_FIELD;
			insert.Parameters.Add(parm_pub_attribute);



			SqlParameter parm_batchno = new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.Direction=ParameterDirection.Input;
			parm_batchno.SourceColumn=TakeStockDetailData.BATCHNO_FIELD;
			insert.Parameters.Add(parm_batchno);

			SqlParameter parm_storageamount = new SqlParameter(STORAGEAMOUNT_PARM,SqlDbType.Decimal,9);
			parm_storageamount.Direction=ParameterDirection.Input;
			parm_storageamount.SourceColumn=TakeStockDetailData.STORAGEAMOUNT_FIELD;
			insert.Parameters.Add(parm_storageamount);

			SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM,SqlDbType.Decimal,9);
			parm_realamount.Direction=ParameterDirection.Input;
			parm_realamount.SourceColumn=TakeStockDetailData.REALAMOUNT_FIELD;
			insert.Parameters.Add(parm_realamount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char,10);
			parm_unit.Direction=ParameterDirection.Input;
			parm_unit.SourceColumn=TakeStockDetailData.UNIT_FIELD;
			insert.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real,4);
			parm_changerate.Direction=ParameterDirection.Input;
			parm_changerate.SourceColumn=TakeStockDetailData.CHANGERATE_FIELD;
			insert.Parameters.Add(parm_changerate);




			SqlParameter parm_price = new SqlParameter(PRICE_PARM,SqlDbType.Decimal,9);
			parm_price.Direction=ParameterDirection.Input;
			parm_price.SourceColumn=TakeStockDetailData.PRICE_FIELD;
			insert.Parameters.Add(parm_price);

			SqlParameter parm_isdeclarcheck = new SqlParameter(ISDECLARCHECK_PARM,SqlDbType.Char,4);
			parm_isdeclarcheck.Direction=ParameterDirection.Input;
			parm_isdeclarcheck.SourceColumn=TakeStockDetailData.ISDECLARCHECK_FIELD;
			insert.Parameters.Add(parm_isdeclarcheck);

			SqlParameter parm_handworkremark = new SqlParameter(HANDWORKREMARK_PARM,SqlDbType.Char,4);
			parm_handworkremark.Direction=ParameterDirection.Input;
			parm_handworkremark.SourceColumn=TakeStockDetailData.HANDWORKREMARK_FIELD;
			insert.Parameters.Add(parm_handworkremark);
   
			return insert;

		}
		#endregion


		#region 修改记录-------盘点详细

		public bool UpdateTakeStockDetail(TakeStockDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			da.UpdateCommand=GetUpdateCommand();
			da.Update(data ,TakeStockDetailData.TAKESTOCKDETAIL_TABLE);
			if(data.HasErrors)
			{
				data.Tables[TakeStockDetailData.TAKESTOCKDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand update =new SqlCommand("U_TakeStockDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType=CommandType.StoredProcedure;


			SqlParameter parm_tsrid = new SqlParameter(TSRID_PARM,SqlDbType.Char,28);
			parm_tsrid.Direction=ParameterDirection.Input;
			parm_tsrid.SourceColumn=TakeStockDetailData.TSRID_FIELD;
			update.Parameters.Add(parm_tsrid);


			SqlParameter parm_placeid = new SqlParameter(PLACEID_PARM,SqlDbType.Char,6);
			parm_placeid.Direction=ParameterDirection.Input;
			parm_placeid.SourceColumn=TakeStockDetailData.PLACEID_FIELD;	
			update.Parameters.Add(parm_placeid);


			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materialid.Direction=ParameterDirection.Input;
			parm_materialid.SourceColumn=TakeStockDetailData.MATERIALID_FIELD;
			update.Parameters.Add(parm_materialid);
			 
//			SqlParameter parm_intime = new SqlParameter(INTIME_PARM,SqlDbType.DateTime);
//			parm_intime.Direction=ParameterDirection.Input;
//			parm_intime.SourceColumn=TakeStockDetailData.INTIME_FIELD;
//			update.Parameters.Add(parm_intime); 
// ycx 所注!
			SqlParameter parm_pub_attribute = new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,8);
			parm_pub_attribute.Direction=ParameterDirection.Input;
			parm_pub_attribute.SourceColumn=TakeStockDetailData.PUB_ATTRIBUTE_FIELD;
			update.Parameters.Add(parm_pub_attribute);


			SqlParameter parm_batchno = new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.Direction=ParameterDirection.Input;
			parm_batchno.SourceColumn=TakeStockDetailData.BATCHNO_FIELD;
			update.Parameters.Add(parm_batchno);


			SqlParameter parm_storageamount = new SqlParameter(STORAGEAMOUNT_PARM,SqlDbType.Decimal);
			parm_storageamount.Direction=ParameterDirection.Input;
			parm_storageamount.SourceColumn=TakeStockDetailData.STORAGEAMOUNT_FIELD;
			update.Parameters.Add(parm_storageamount);

			SqlParameter parm_realamount = new SqlParameter(REALAMOUNT_PARM,SqlDbType.Decimal);
			parm_realamount.Direction=ParameterDirection.Input;
			parm_realamount.SourceColumn=TakeStockDetailData.REALAMOUNT_FIELD;
			update.Parameters.Add(parm_realamount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char,10);
			parm_unit.Direction=ParameterDirection.Input;
			parm_unit.SourceColumn=TakeStockDetailData.UNIT_FIELD;
			update.Parameters.Add(parm_unit);

			

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.Direction=ParameterDirection.Input;
			parm_changerate.SourceColumn=TakeStockDetailData.CHANGERATE_FIELD;
			update.Parameters.Add(parm_changerate);

			
			SqlParameter parm_price = new SqlParameter(PRICE_PARM,SqlDbType.Decimal);
			parm_price.Direction=ParameterDirection.Input;
			parm_price.SourceColumn=TakeStockDetailData.PRICE_FIELD;
			update.Parameters.Add(parm_price);


			SqlParameter parm_ISDECLARCHECK = new SqlParameter(ISDECLARCHECK_PARM,SqlDbType.Char,4);
			parm_ISDECLARCHECK.Direction=ParameterDirection.Input;
			parm_ISDECLARCHECK.SourceColumn=TakeStockDetailData.ISDECLARCHECK_FIELD;
			update.Parameters.Add(parm_ISDECLARCHECK);


			SqlParameter parm_handworkremark = new SqlParameter(HANDWORKREMARK_PARM,SqlDbType.Char,4);
			parm_handworkremark.Direction=ParameterDirection.Input;
			parm_handworkremark.SourceColumn=TakeStockDetailData.HANDWORKREMARK_FIELD;
			update.Parameters.Add(parm_handworkremark);

			return update;

		}
		#endregion

		#region 删除 记录-----盘点详细

		public bool DeleteCommand()
		{
			SqlCommand deletecommand = GetDeleteCommand();

			try
			{
				deletecommand.Connection.Open();
				if(deletecommand.ExecuteNonQuery()>0)
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
				deletecommand.Connection.Close();
				deletecommand.Connection.Dispose();
				deletecommand.Dispose();
			}
		}

		private SqlCommand GetDeleteCommand ()
		{
			SqlCommand delete =new SqlCommand("D_TakeStockDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType=CommandType.StoredProcedure;



			return delete;
		}
		#endregion
	}
}
