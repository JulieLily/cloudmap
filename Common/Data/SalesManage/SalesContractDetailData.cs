using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	public class SalesContractDetailData:DataSet
	{

		public const string SALESCONTRACTDETAIL_TABLE		="tbl_salescontractdetail";
		
		public const string CONTRACTID_FIELD	            ="CONTRACTID";
		public const string MATERIALID_FIELD	            ="MaterialID";
		public const String MATERIALNAME_FIELD				= "Materialname";//YCX做销售合同所加
		public const String MODEL_FIELD						= "model";		//YCX做销售合同所加
		public const string PRICEMODE_FIELD					="PriceMode";
		public const string AMOUNT_FIELD					="Amount";
		public const string UNIT_FIELD						="Unit";
		public const string CHANGERATE_FIELD	            ="ChangeRate";
		public const string PRICE_FIELD						="Price";
		public const string TAXRATE_FIELD					="TaxRate";
		public const string DISCOUNTRATE_FIELD	            ="DiscountRate";
		public const string DISCOUNTSUM_FIELD	            ="DiscountSum";
		public const string ALLSUM_FIELD	                ="allSum";
		public const string WITHOUTTAXSUM_FIELD	            ="WithoutTaxSum";
		public const string TAXSUM_FIELD					="TaxSum";
		public const string ITEMCONTEXT_FIELD	            ="ItemContext";
		public const string DESCRIPTION_FIELD	            ="Description";

		public SalesContractDetailData()
		{
			BuildTable();
		}
		private void BuildTable()
		{
			DataTable table = new DataTable (SalesContractDetailData.SALESCONTRACTDETAIL_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(CONTRACTID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(MATERIALNAME_FIELD,typeof(System.String));//YCX做销售合同所加
			columns.Add(MODEL_FIELD,typeof(System.String));		  //YCX做销售合同所加
			columns.Add(PRICEMODE_FIELD,typeof(System.String));
			columns.Add(AMOUNT_FIELD,typeof(System.Decimal));
			columns.Add(UNIT_FIELD,typeof(System.String));
			columns.Add(CHANGERATE_FIELD,typeof(System.String));
			columns.Add(PRICE_FIELD,typeof(System.Decimal));
			columns.Add(TAXRATE_FIELD,typeof(System.Decimal));
			columns.Add(DISCOUNTRATE_FIELD,typeof(System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD,typeof(System.Decimal));
			columns.Add(ALLSUM_FIELD,typeof(System.Decimal));
			columns.Add(WITHOUTTAXSUM_FIELD,typeof(System.Decimal));
			columns.Add(TAXSUM_FIELD,typeof(System.Decimal));
			columns.Add(ITEMCONTEXT_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			this.Tables.Add(table);

		}
	}
}
