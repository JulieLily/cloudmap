using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	/// <summary>
	/// PurchasingContractDeliverys 的摘要说明。
	/// </summary>
	public class PurchasingContractDeliverys :IDisposable
	{

		private SqlDataAdapter da;

		private const String  OLDCONTRACTID_PARM							= "@oldContractID";
		private const String  OLDMATERIALID_PARM							= "@oldMaterialID";
		private const String  OLDDELIVERYDATE_PARM							= "@oldDeliveryDate";


		private const String  CONTRACTID_PARM							= "@ContractID";
		private const String  MATERIALID_PARM							= "@MaterialID";
		private const String  DELIVERYDATE_PARM							= "@DeliveryDate";
		private const String  AMOUNT_PARM								= "@Amount";

		public PurchasingContractDeliverys()
		{
			
			da = new SqlDataAdapter();
			da.TableMappings.Add("Table",PurchasingContractDeliveryData.PURCHASINGCONTRACTDELIVERY_TABLE);
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

		#region 读取数据-----采购合同交货信息
		//Begin of Modified by YiChangxin 2005-8-30
		public PurchasingContractDeliveryData LoadPurchasingContractDelivery(string contractid,string materailid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			PurchasingContractDeliveryData data  = new PurchasingContractDeliveryData();
			

			da.SelectCommand =GetLoadCommand();
			da.SelectCommand.Parameters[CONTRACTID_PARM].Value = contractid	;
			da.SelectCommand.Parameters[MATERIALID_PARM].Value = materailid;
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
			SqlCommand load = new SqlCommand("Q_PurchasingContractDelivery" ,new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char,28);
			parm_contractid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_contractid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char,20);
			parm_materialid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_materialid);

			return load;
		}
		//End of Modified by Yichangxin 2005-8-30
		#endregion

		#region 添加记录---- 采购合同交货信息

		public bool InsertPurchasingContractDelivery(PurchasingContractDeliveryData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand =GetInsertCommand();
			da.Update(data,PurchasingContractDeliveryData.PURCHASINGCONTRACTDELIVERY_TABLE);
			if(data.HasErrors)
			{
				data.Tables[PurchasingContractDeliveryData.PURCHASINGCONTRACTDELIVERY_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand insert = new SqlCommand("I_PurchasingContractDelivery" ,new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char);
			parm_contractid.SourceColumn =PurchasingContractDeliveryData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_contractid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.SourceColumn =PurchasingContractDeliveryData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_materialid);

			SqlParameter parm_deliverydate = new SqlParameter(DELIVERYDATE_PARM, SqlDbType.DateTime);
			parm_deliverydate.SourceColumn =PurchasingContractDeliveryData.DELIVERYDATE_FIELD;
			parm_deliverydate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_deliverydate);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM, SqlDbType.Decimal);
			parm_amount.SourceColumn =PurchasingContractDeliveryData.AMOUNT_FIELD;
			parm_amount.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_amount);

			return insert;
		}
		#endregion

		#region 更新数据----采购合同交货信息

		public bool UpdatePurchasingContractDelivery(PurchasingContractDeliveryData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand = GetUpdateCommand ();
			da.Update(data,PurchasingContractDeliveryData.PURCHASINGCONTRACTDELIVERY_TABLE);
			if(data.HasErrors)
			{
				data.Tables[PurchasingContractDeliveryData.PURCHASINGCONTRACTDELIVERY_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}
		private SqlCommand GetUpdateCommand ()
		{
			SqlCommand update = new SqlCommand("U_PurchasingContractDelivery" ,new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_oldcontractid = new SqlParameter(OLDCONTRACTID_PARM, SqlDbType.Char);    //  old contarctid
			parm_oldcontractid.SourceColumn =PurchasingContractDeliveryData.CONTRACTID_FIELD;
			parm_oldcontractid.SourceVersion = DataRowVersion.Original;
			parm_oldcontractid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldcontractid);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char);
			parm_contractid.SourceColumn =PurchasingContractDeliveryData.CONTRACTID_FIELD;
			parm_contractid.SourceVersion = DataRowVersion.Current;
			parm_contractid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_contractid);


			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM, SqlDbType.Char);    //  old  materialid
			parm_oldmaterialid.SourceColumn =PurchasingContractDeliveryData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			parm_oldmaterialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.SourceColumn =PurchasingContractDeliveryData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_materialid);

			SqlParameter parm_olddeliverydate = new SqlParameter(OLDDELIVERYDATE_PARM, SqlDbType.DateTime);  //  old deliverydate
			parm_olddeliverydate.SourceColumn =PurchasingContractDeliveryData.DELIVERYDATE_FIELD;
			parm_olddeliverydate.SourceVersion  =  DataRowVersion.Original;
			parm_olddeliverydate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_olddeliverydate);

			SqlParameter parm_deliverydate = new SqlParameter(DELIVERYDATE_PARM, SqlDbType.DateTime);
			parm_deliverydate.SourceColumn =PurchasingContractDeliveryData.DELIVERYDATE_FIELD;
			parm_deliverydate.SourceVersion  =  DataRowVersion.Current;
			parm_deliverydate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_deliverydate);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM, SqlDbType.Decimal);
			parm_amount.SourceColumn =PurchasingContractDeliveryData.AMOUNT_FIELD;
			parm_amount.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_amount);

			return update;
		}
		#endregion

		#region 删除记录----采购合同交货信息

		public bool DeletePurchasingContractDelivery(string contractid ,string materialid, string deliverydate)
		{
			SqlCommand deletecommand = GetDeleteCommand();
			deletecommand.Parameters[CONTRACTID_PARM].Value		= contractid;
			deletecommand.Parameters[MATERIALID_PARM].Value		= materialid;
			deletecommand.Parameters[DELIVERYDATE_PARM].Value	= deliverydate;

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

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand delete = new SqlCommand("D_PurchasingContractDelivery" ,new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure ;


			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char);
			parm_contractid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_contractid);

 
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_materialid);


			SqlParameter parm_deliverydate = new SqlParameter(DELIVERYDATE_PARM, SqlDbType.DateTime);
			parm_deliverydate.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_deliverydate);

			return delete;

		}
		#endregion
	}
}
