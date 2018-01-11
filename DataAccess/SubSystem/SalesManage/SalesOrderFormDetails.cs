using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	
	public class SalesOrderFormDetails:IDisposable
	{
		private  SqlDataAdapter dsCommand;

		private const string ORDERFORMID_PARM	            ="@OrderFormID";
		private const string MATERIALID_PARM	            ="@MaterialID";
		private const string PRICEMODE_PARM					="@PriceMode";
		private const string AMOUNT_PARM					="@Amount";
		private const string UNIT_PARM						="@Unit";

		private const string CHANGERATE_PARM	            ="@ChangeRate";
		private const string PRICE_PARM						="@Price";
		private const string TAXRATE_PARM					="@TaxRate";
		private const string DISCOUNTRATE_PARM	            ="@DiscountRate";
		private const string DISCOUNTSUM_PARM	            ="@DiscountSum";

		private const string TAXMONEYSUM_PARM	            ="@TaxMoneySum";
		private const string WITHOUTTAXSUM_PARM				="@WithoutTaxSum";
		private const string TAXSUM_PARM					="@TaxSum";
		private const string ITEMCONTEXT_PARM	            ="@ItemContext";
		private const string DESCRIPTION_PARM	            ="@Description";

		private const string OLDORDERFORMID_PARM	            ="@oldOrderFormID";
		private const string OLDMATERIALID_PARM	            ="@oldMaterialID";
		public SalesOrderFormDetails()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",SalesOrderFormDetailData.SALESORDERFORMDETAIL_TABLE);
		}

		#region  释放资源
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected virtual void Dispose(bool disposing)
		{
			if( ! disposing)
				return;
			if(dsCommand!=null)
			{
				if(dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				}
				if(dsCommand.InsertCommand!=null)
				{
					if(dsCommand.InsertCommand.Connection!=null)
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}
				if(dsCommand.UpdateCommand!=null)
				{
					if(dsCommand.UpdateCommand.Connection!=null)
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}
				if(dsCommand.DeleteCommand!=null)
				{
					if(dsCommand.DeleteCommand.Connection!=null)
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}
				dsCommand.Dispose();
				dsCommand=null;
			}
		}
		#endregion 

		#region  通过销售订单ID获得明细信息
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_SalesOrderFormDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;
			SqlParameter parm_orderformid = new SqlParameter(ORDERFORMID_PARM ,SqlDbType.Char);
			parm_orderformid.Direction = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_orderformid);

			return loadCommand;
		}
		public SalesOrderFormDetailData LoadSalesOrderFormDetail(string orderformid )
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			SalesOrderFormDetailData  data = new SalesOrderFormDetailData();
			dsCommand.SelectCommand=GetLoadCommand();
			dsCommand.SelectCommand.Parameters[ORDERFORMID_PARM].Value =orderformid;
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

		#region  Insert  Data

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_SalesOrderFormDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_OrderFormID= new SqlParameter  (ORDERFORMID_PARM,SqlDbType.Char);
			parm_OrderFormID.SourceColumn = SalesOrderFormDetailData.ORDERFORMID_FIELD;
			parm_OrderFormID.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_OrderFormID);

			SqlParameter parm_MaterialID= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_MaterialID.SourceColumn = SalesOrderFormDetailData.MATERIALID_FIELD;
			parm_MaterialID.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_MaterialID);

			SqlParameter parm_PriceMode= new SqlParameter  (PRICEMODE_PARM,SqlDbType.Char);
			parm_PriceMode.SourceColumn = SalesOrderFormDetailData.PRICEMODE_FIELD;
			parm_PriceMode.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PriceMode);

			SqlParameter parm_Amount= new SqlParameter  (AMOUNT_PARM,SqlDbType.Decimal);
			parm_Amount.SourceColumn = SalesOrderFormDetailData.AMOUNT_FIELD;
			parm_Amount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Amount);

			SqlParameter parm_Unit= new SqlParameter  (UNIT_PARM,SqlDbType.Char);
			parm_Unit.SourceColumn = SalesOrderFormDetailData.UNIT_FIELD;
			parm_Unit.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Unit);

			SqlParameter parm_ChangeRate= new SqlParameter  (CHANGERATE_PARM,SqlDbType.Real);
			parm_ChangeRate.SourceColumn = SalesOrderFormDetailData.CHANGERATE_FIELD;
			parm_ChangeRate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ChangeRate);

			SqlParameter parm_Price= new SqlParameter  (PRICE_PARM,SqlDbType.Decimal);
			parm_Price.SourceColumn = SalesOrderFormDetailData.PRICE_FIELD;
			parm_Price.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Price);

			SqlParameter parm_TaxRate= new SqlParameter  (TAXRATE_PARM,SqlDbType.Decimal);
			parm_TaxRate.SourceColumn = SalesOrderFormDetailData.TAXRATE_FIELD;
			parm_TaxRate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TaxRate);

			SqlParameter parm_DiscountRate= new SqlParameter  (DISCOUNTRATE_PARM,SqlDbType.Decimal);
			parm_DiscountRate.SourceColumn = SalesOrderFormDetailData.DISCOUNTRATE_FIELD;
			parm_DiscountRate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DiscountRate);

			SqlParameter parm_DiscountSum= new SqlParameter  (DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_DiscountSum.SourceColumn = SalesOrderFormDetailData.DISCOUNTSUM_FIELD;
			parm_DiscountSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DiscountSum);

			SqlParameter parm_TaxMoneySum= new SqlParameter  (TAXMONEYSUM_PARM,SqlDbType.Decimal);
			parm_TaxMoneySum.SourceColumn = SalesOrderFormDetailData.TAXMONEYSUM_FIELD;
			parm_TaxMoneySum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TaxMoneySum);

			SqlParameter parm_WithoutTaxSum= new SqlParameter  (WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_WithoutTaxSum.SourceColumn = SalesOrderFormDetailData.WITHOUTTAXSUM_FIELD;
			parm_WithoutTaxSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_WithoutTaxSum);

			SqlParameter parm_TaxSum= new SqlParameter  (TAXSUM_PARM,SqlDbType.Decimal);
			parm_TaxSum.SourceColumn = SalesOrderFormDetailData.TAXSUM_FIELD;
			parm_TaxSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TaxSum);

			SqlParameter parm_ItemContext= new SqlParameter  (ITEMCONTEXT_PARM,SqlDbType.Char);
			parm_ItemContext.SourceColumn = SalesOrderFormDetailData.ITEMCONTEXT_FIELD;
			parm_ItemContext.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ItemContext);

			SqlParameter parm_Description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.Char);
			parm_Description.SourceColumn = SalesOrderFormDetailData.DESCRIPTION_FIELD;
			parm_Description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Description);

			return insertCommand;

		}

		public bool InsertSalesOrderFormDetail(SalesOrderFormDetailData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			try
			{
				dsCommand.Update(data,SalesOrderFormDetailData.SALESORDERFORMDETAIL_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesOrderFormDetailData.SALESORDERFORMDETAIL_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				data.AcceptChanges();
				return true;
			}
			catch
			{
				return false;

			}
		}

		#endregion

		#region  Update Data

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_SalesOrderFormDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType= CommandType.StoredProcedure;

			SqlParameter parm_OrderFormID= new SqlParameter  (ORDERFORMID_PARM,SqlDbType.Char);
			parm_OrderFormID.SourceColumn = SalesOrderFormDetailData.ORDERFORMID_FIELD;
			parm_OrderFormID.SourceVersion = DataRowVersion.Current;
			parm_OrderFormID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_OrderFormID);

			SqlParameter parm_MaterialID= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_MaterialID.SourceColumn = SalesOrderFormDetailData.MATERIALID_FIELD;
			parm_MaterialID.SourceVersion = DataRowVersion.Current;
			parm_MaterialID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_MaterialID);

			SqlParameter parm_oldOrderFormID= new SqlParameter  (OLDORDERFORMID_PARM,SqlDbType.Char);
			parm_oldOrderFormID.SourceColumn = SalesOrderFormDetailData.ORDERFORMID_FIELD;
			parm_oldOrderFormID.SourceVersion = DataRowVersion.Original;
			parm_oldOrderFormID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldOrderFormID);

			SqlParameter parm_oldMaterialID= new SqlParameter  (OLDMATERIALID_PARM,SqlDbType.Char);
			parm_oldMaterialID.SourceColumn = SalesOrderFormDetailData.MATERIALID_FIELD;
			parm_oldMaterialID.SourceVersion = DataRowVersion.Original;
			parm_oldMaterialID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldMaterialID);

			SqlParameter parm_PriceMode= new SqlParameter  (PRICEMODE_PARM,SqlDbType.Char);
			parm_PriceMode.SourceColumn = SalesOrderFormDetailData.PRICEMODE_FIELD;
			parm_PriceMode.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PriceMode);

			SqlParameter parm_Amount= new SqlParameter  (AMOUNT_PARM,SqlDbType.Decimal);
			parm_Amount.SourceColumn = SalesOrderFormDetailData.AMOUNT_FIELD;
			parm_Amount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Amount);

			SqlParameter parm_Unit= new SqlParameter  (UNIT_PARM,SqlDbType.Char);
			parm_Unit.SourceColumn = SalesOrderFormDetailData.UNIT_FIELD;
			parm_Unit.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Unit);

			SqlParameter parm_ChangeRate= new SqlParameter  (CHANGERATE_PARM,SqlDbType.Real);
			parm_ChangeRate.SourceColumn = SalesOrderFormDetailData.CHANGERATE_FIELD;
			parm_ChangeRate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ChangeRate);

			SqlParameter parm_Price= new SqlParameter  (PRICE_PARM,SqlDbType.Decimal);
			parm_Price.SourceColumn = SalesOrderFormDetailData.PRICE_FIELD;
			parm_Price.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Price);

			SqlParameter parm_TaxRate= new SqlParameter  (TAXRATE_PARM,SqlDbType.Decimal);
			parm_TaxRate.SourceColumn = SalesOrderFormDetailData.TAXRATE_FIELD;
			parm_TaxRate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TaxRate);

			SqlParameter parm_DiscountRate= new SqlParameter  (DISCOUNTRATE_PARM,SqlDbType.Decimal);
			parm_DiscountRate.SourceColumn = SalesOrderFormDetailData.DISCOUNTRATE_FIELD;
			parm_DiscountRate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DiscountRate);

			SqlParameter parm_DiscountSum= new SqlParameter  (DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_DiscountSum.SourceColumn = SalesOrderFormDetailData.DISCOUNTSUM_FIELD;
			parm_DiscountSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DiscountSum);

			SqlParameter parm_TaxMoneySum= new SqlParameter  (TAXMONEYSUM_PARM,SqlDbType.Decimal);
			parm_TaxMoneySum.SourceColumn = SalesOrderFormDetailData.TAXMONEYSUM_FIELD;
			parm_TaxMoneySum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TaxMoneySum);

			SqlParameter parm_WithoutTaxSum= new SqlParameter  (WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_WithoutTaxSum.SourceColumn = SalesOrderFormDetailData.WITHOUTTAXSUM_FIELD;
			parm_WithoutTaxSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_WithoutTaxSum);

			SqlParameter parm_TaxSum= new SqlParameter  (TAXSUM_PARM,SqlDbType.Decimal);
			parm_TaxSum.SourceColumn = SalesOrderFormDetailData.TAXSUM_FIELD;
			parm_TaxSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TaxSum);

			SqlParameter parm_ItemContext= new SqlParameter  (ITEMCONTEXT_PARM,SqlDbType.Char);
			parm_ItemContext.SourceColumn = SalesOrderFormDetailData.ITEMCONTEXT_FIELD;
			parm_ItemContext.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ItemContext);

			SqlParameter parm_Description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.Char);
			parm_Description.SourceColumn = SalesOrderFormDetailData.DESCRIPTION_FIELD;
			parm_Description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Description);

			return updateCommand;
		}

		public bool UpdateSalesOrderFormDetail(SalesOrderFormDetailData data)
		{
			if(dsCommand==null)
			{

				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.UpdateCommand = GetUpdateCommand();
			try 
			{
				dsCommand.Update(data,SalesOrderFormDetailData.SALESORDERFORMDETAIL_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesOrderFormDetailData.SALESORDERFORMDETAIL_TABLE].GetErrors()[0].ClearErrors();
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

		#region  Delete  Data

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_SalesOrderFormDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter parm_OrderFormID= new SqlParameter  (ORDERFORMID_PARM,SqlDbType.Char);
			parm_OrderFormID.SourceColumn = SalesOrderFormDetailData.ORDERFORMID_FIELD;
			parm_OrderFormID.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_OrderFormID);

			SqlParameter parm_MaterialID= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_MaterialID.SourceColumn = SalesOrderFormDetailData.MATERIALID_FIELD;
			parm_MaterialID.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_MaterialID);
			return deleteCommand;
		}
		public bool DeleteSalesOrderFormDetail(string OrderFormID,string MaterialID)
		{
			
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[ORDERFORMID_PARM].Value = OrderFormID;
			deleteCommand.Parameters[MATERIALID_PARM].Value = MaterialID;

			
			try
			{
				deleteCommand.Connection.Open ();
				int i = deleteCommand.ExecuteNonQuery();
				deleteCommand.Connection.Close();
				if(i>=1)
					return true;
				else
					return false;
		
			}
			catch
			{
				return false;
			}
		}
		#endregion
	}
}
