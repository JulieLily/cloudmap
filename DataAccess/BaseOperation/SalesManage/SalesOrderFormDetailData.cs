using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	public class SalesOrderFormDetailData:DataSet
	{
		public const string SALESORDERFORMDETAIL_TABLE		="tbl_salesorderformdetail";
		
		public const string ORDERFORMID_FIELD	            ="OrderFormID";
		public const string MATERIALID_FIELD	            ="MaterialID";
		public const string PRICEMODE_FIELD					="PriceMode";
		public const string AMOUNT_FIELD					="Amount";
		public const string UNIT_FIELD						="Unit";
		public const string CHANGERATE_FIELD	            ="ChangeRate";
		public const string PRICE_FIELD						="Price";
		public const string TAXRATE_FIELD					="TaxRate";
		public const string DISCOUNTRATE_FIELD	            ="DiscountRate";
		public const string DISCOUNTSUM_FIELD	            ="DiscountSum";
		public const string TAXMONEYSUM_FIELD	            ="TaxMoneySum";
		public const string WITHOUTTAXSUM_FIELD	            ="WithoutTaxSum";
		public const string TAXSUM_FIELD					="TaxSum";
		public const string ITEMCONTEXT_FIELD	            ="ItemContext";
		public const string DESCRIPTION_FIELD	            ="Description";


		public SalesOrderFormDetailData()
		{
			BuildTable();
		}
		private void BuildTable()
		{
			DataTable table = new DataTable (SalesOrderFormDetailData.SALESORDERFORMDETAIL_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(ORDERFORMID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(PRICEMODE_FIELD,typeof(System.String));
			columns.Add(AMOUNT_FIELD,typeof(System.Decimal));
			columns.Add(UNIT_FIELD,typeof(System.String));
			columns.Add(CHANGERATE_FIELD,typeof(System.String));
			columns.Add(PRICE_FIELD,typeof(System.Decimal));
			columns.Add(TAXRATE_FIELD,typeof(System.Decimal));
			columns.Add(DISCOUNTRATE_FIELD,typeof(System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD,typeof(System.Decimal));
			columns.Add(TAXMONEYSUM_FIELD,typeof(System.Decimal));
			columns.Add(WITHOUTTAXSUM_FIELD,typeof(System.Decimal));
			columns.Add(TAXSUM_FIELD,typeof(System.Decimal));
			columns.Add(ITEMCONTEXT_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			this.Tables.Add(table);

		}
	}
}
