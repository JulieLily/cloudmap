using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	
	public class SalesContractDetails:IDisposable
	{
		private  SqlDataAdapter dsCommand;

		private const string CONTRACTID_PARM	            ="@ContractID";
		private const string MATERIALID_PARM	            ="@MaterialID";
		private const string PRICEMODE_PARM					="@PriceMode";
		private const string AMOUNT_PARM					="@Amount";
		private const string UNIT_PARM						="@Unit";

		private const string CHANGERATE_PARM	            ="@ChangeRate";
		private const string PRICE_PARM						="@Price";
		private const string TAXRATE_PARM					="@TaxRate";
		private const string DISCOUNTRATE_PARM	            ="@DiscountRate";
		private const string DISCOUNTSUM_PARM	            ="@DiscountSum";

		private const string ALLSUM_PARM					="@allSum";
		private const string WITHOUTTAXSUM_PARM				="@WithoutTaxSum";
		private const string TAXSUM_PARM					="@TaxSum";
		private const string ITEMCONTEXT_PARM	            ="@ItemContext";
		private const string DESCRIPTION_PARM	            ="@Description";

		private const string OLDCONTRACTID_PARM	            ="@oldCONTRACTID";
		private const string OLDMATERIALID_PARM	            ="@oldMaterialID";
		public SalesContractDetails()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",SalesContractDetailData.SALESCONTRACTDETAIL_TABLE);
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

		#region  通过销售合同ID获得销售合同明细信息
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_SalesContractDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char,28);
			parm_contractid.Direction = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_contractid);

			return loadCommand;
		}
		public SalesContractDetailData LoadSalesContractDetails(string contractid)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			SalesContractDetailData  data = new SalesContractDetailData ();
			dsCommand.SelectCommand=GetLoadCommand();
			dsCommand.SelectCommand.Parameters[CONTRACTID_PARM].Value = contractid;
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

		#region  通过条件获得销售合同明细信息---YiChangxin 做了修改 2005-9-21
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)
				strsql = "select t.*,m.MaterialName MaterialName,m.Model Model,m.StandardUnit "
					+ "from (select * from tbl_salescontractdetail where " + filter + ") t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid ";

			else 

				strsql = "select t.*,m.MaterialName MaterialName,m.Model Model  ,m.StandardUnit"
					+ "from tbl_salescontractdetail t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid ";
			SqlCommand loadCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.Text;

			return loadCommand;
		}
		public SalesContractDetailData LoadSalesContractDetail(string filter)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			SalesContractDetailData  data = new SalesContractDetailData ();
			dsCommand.SelectCommand=GetLoadCommand(filter);
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

		#region  Insert Data

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_SalesContractDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_CONTRACTID= new SqlParameter  (CONTRACTID_PARM,SqlDbType.Char);
			parm_CONTRACTID.SourceColumn = SalesContractDetailData.CONTRACTID_FIELD;
			parm_CONTRACTID.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_CONTRACTID);

			SqlParameter parm_MaterialID= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_MaterialID.SourceColumn = SalesContractDetailData.MATERIALID_FIELD;
			parm_MaterialID.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_MaterialID);

			SqlParameter parm_PriceMode= new SqlParameter  (PRICEMODE_PARM,SqlDbType.Char);
			parm_PriceMode.SourceColumn = SalesContractDetailData.PRICEMODE_FIELD;
			parm_PriceMode.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PriceMode);

			SqlParameter parm_Amount= new SqlParameter  (AMOUNT_PARM,SqlDbType.Decimal);
			parm_Amount.SourceColumn = SalesContractDetailData.AMOUNT_FIELD;
			parm_Amount.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Amount);

			SqlParameter parm_Unit= new SqlParameter  (UNIT_PARM,SqlDbType.Char);
			parm_Unit.SourceColumn = SalesContractDetailData.UNIT_FIELD;
			parm_Unit.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Unit);

			SqlParameter parm_ChangeRate= new SqlParameter  (CHANGERATE_PARM,SqlDbType.Real);
			parm_ChangeRate.SourceColumn = SalesContractDetailData.CHANGERATE_FIELD;
			parm_ChangeRate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ChangeRate);

			SqlParameter parm_Price= new SqlParameter  (PRICE_PARM,SqlDbType.Decimal);
			parm_Price.SourceColumn = SalesContractDetailData.PRICE_FIELD;
			parm_Price.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Price);

			SqlParameter parm_TaxRate= new SqlParameter  (TAXRATE_PARM,SqlDbType.Decimal);
			parm_TaxRate.SourceColumn = SalesContractDetailData.TAXRATE_FIELD;
			parm_TaxRate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TaxRate);

			SqlParameter parm_DiscountRate= new SqlParameter  (DISCOUNTRATE_PARM,SqlDbType.Decimal);
			parm_DiscountRate.SourceColumn = SalesContractDetailData.DISCOUNTRATE_FIELD;
			parm_DiscountRate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DiscountRate);

			SqlParameter parm_DiscountSum= new SqlParameter  (DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_DiscountSum.SourceColumn = SalesContractDetailData.DISCOUNTSUM_FIELD;
			parm_DiscountSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DiscountSum);

			SqlParameter parm_ALLSum= new SqlParameter  (ALLSUM_PARM,SqlDbType.Decimal);
			parm_ALLSum.SourceColumn = SalesContractDetailData.ALLSUM_FIELD;
			parm_ALLSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ALLSum);

			SqlParameter parm_WithoutTaxSum= new SqlParameter  (WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_WithoutTaxSum.SourceColumn = SalesContractDetailData.WITHOUTTAXSUM_FIELD;
			parm_WithoutTaxSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_WithoutTaxSum);

			SqlParameter parm_TaxSum= new SqlParameter  (TAXSUM_PARM,SqlDbType.Decimal);
			parm_TaxSum.SourceColumn = SalesContractDetailData.TAXSUM_FIELD;
			parm_TaxSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TaxSum);

			SqlParameter parm_ItemContext= new SqlParameter  (ITEMCONTEXT_PARM,SqlDbType.Char);
			parm_ItemContext.SourceColumn = SalesContractDetailData.ITEMCONTEXT_FIELD;
			parm_ItemContext.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ItemContext);

			SqlParameter parm_Description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.Char);
			parm_Description.SourceColumn = SalesContractDetailData.DESCRIPTION_FIELD;
			parm_Description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Description);

			return insertCommand;

		}

		public bool InsertSalesContractDetail(SalesContractDetailData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			try
			{
				dsCommand.Update(data,SalesContractDetailData.SALESCONTRACTDETAIL_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesContractDetailData.SALESCONTRACTDETAIL_TABLE].GetErrors()[0].ClearErrors();
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

		#region  update  Data
		//Modified by YiChangxin 2005-8-26
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_SalesContractDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType= CommandType.StoredProcedure;

			SqlParameter parm_CONTRACTID= new SqlParameter  (CONTRACTID_PARM,SqlDbType.Char);
			parm_CONTRACTID.SourceColumn = SalesContractDetailData.CONTRACTID_FIELD;
			parm_CONTRACTID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_CONTRACTID);

			SqlParameter parm_MaterialID= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_MaterialID.SourceColumn = SalesContractDetailData.MATERIALID_FIELD;
			parm_MaterialID.SourceVersion = DataRowVersion.Current;
			parm_MaterialID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_MaterialID);

			SqlParameter parm_OLDMATERIALID= new SqlParameter  (OLDMATERIALID_PARM,SqlDbType.Char);
			parm_OLDMATERIALID.SourceColumn = SalesContractDetailData.MATERIALID_FIELD;
			parm_OLDMATERIALID.SourceVersion = DataRowVersion.Original;
			parm_OLDMATERIALID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_OLDMATERIALID);

			SqlParameter parm_PriceMode= new SqlParameter  (PRICEMODE_PARM,SqlDbType.Char);
			parm_PriceMode.SourceColumn = SalesContractDetailData.PRICEMODE_FIELD;
			parm_PriceMode.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PriceMode);

			SqlParameter parm_Amount= new SqlParameter  (AMOUNT_PARM,SqlDbType.Decimal);
			parm_Amount.SourceColumn = SalesContractDetailData.AMOUNT_FIELD;
			parm_Amount.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Amount);

			SqlParameter parm_Unit= new SqlParameter  (UNIT_PARM,SqlDbType.Char);
			parm_Unit.SourceColumn = SalesContractDetailData.UNIT_FIELD;
			parm_Unit.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Unit);

			SqlParameter parm_ChangeRate= new SqlParameter  (CHANGERATE_PARM,SqlDbType.Real);
			parm_ChangeRate.SourceColumn = SalesContractDetailData.CHANGERATE_FIELD;
			parm_ChangeRate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ChangeRate);

			SqlParameter parm_Price= new SqlParameter  (PRICE_PARM,SqlDbType.Decimal);
			parm_Price.SourceColumn = SalesContractDetailData.PRICE_FIELD;
			parm_Price.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Price);

			SqlParameter parm_TaxRate= new SqlParameter  (TAXRATE_PARM,SqlDbType.Decimal);
			parm_TaxRate.SourceColumn = SalesContractDetailData.TAXRATE_FIELD;
			parm_TaxRate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TaxRate);

			SqlParameter parm_DiscountRate= new SqlParameter  (DISCOUNTRATE_PARM,SqlDbType.Decimal);
			parm_DiscountRate.SourceColumn = SalesContractDetailData.DISCOUNTRATE_FIELD;
			parm_DiscountRate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DiscountRate);

			SqlParameter parm_DiscountSum= new SqlParameter  (DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_DiscountSum.SourceColumn = SalesContractDetailData.DISCOUNTSUM_FIELD;
			parm_DiscountSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DiscountSum);

			SqlParameter parm_ALLSum= new SqlParameter  (ALLSUM_PARM,SqlDbType.Decimal);
			parm_ALLSum.SourceColumn = SalesContractDetailData.ALLSUM_FIELD;
			parm_ALLSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ALLSum);

			SqlParameter parm_WithoutTaxSum= new SqlParameter  (WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_WithoutTaxSum.SourceColumn = SalesContractDetailData.WITHOUTTAXSUM_FIELD;
			parm_WithoutTaxSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_WithoutTaxSum);

			SqlParameter parm_TaxSum= new SqlParameter  (TAXSUM_PARM,SqlDbType.Decimal);
			parm_TaxSum.SourceColumn = SalesContractDetailData.TAXSUM_FIELD;
			parm_TaxSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TaxSum);

			SqlParameter parm_ItemContext= new SqlParameter  (ITEMCONTEXT_PARM,SqlDbType.VarChar);
			parm_ItemContext.SourceColumn = SalesContractDetailData.ITEMCONTEXT_FIELD;
			parm_ItemContext.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ItemContext);

			SqlParameter parm_Description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_Description.SourceColumn = SalesContractDetailData.DESCRIPTION_FIELD;
			parm_Description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Description);

			return updateCommand;
		}

		public bool UpdateSalesContractDetail(SalesContractDetailData data)
		{
			if(dsCommand==null)
			{

				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.UpdateCommand = GetUpdateCommand();
			try 
			{
				dsCommand.Update(data,SalesContractDetailData.SALESCONTRACTDETAIL_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesContractDetailData.SALESCONTRACTDETAIL_TABLE].GetErrors()[0].ClearErrors();
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

		#region  delete Data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_SalesContractDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;
			
			SqlParameter parm_CONTRACTID= new SqlParameter  (CONTRACTID_PARM,SqlDbType.Char);
			parm_CONTRACTID.SourceColumn = SalesContractDetailData.CONTRACTID_FIELD;
			parm_CONTRACTID.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_CONTRACTID);

			SqlParameter parm_MaterialID= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_MaterialID.SourceColumn = SalesContractDetailData.MATERIALID_FIELD;
			parm_MaterialID.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_MaterialID);
			return deleteCommand;
		}
		public bool DeleteSalesContractDetail(string ContractID,string MaterialID)
		{
			
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[CONTRACTID_PARM].Value = ContractID;
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
