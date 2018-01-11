using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	/// <summary>
	/// PurchasingContractDetailData 的摘要说明。
	/// </summary>
	public class PurchasingContractDetailData :DataSet
	{
		public const String PURCHARINGCONTRACTDETAIL_TABLE		= "TBL_PurchasingContractDetail";
		
		public const String CONTRACTID_FIELD					= "ContractID";
		public const String PRICEMODE_FIELD						= "PriceMode";
		public const String MATERIALID_FIELD					= "MaterialID";
		public const String AMOUNT_FIELD						= "Amount";
		public const String UNIT_FIELD							= "Unit";

		public const String CHANGERATE_FIELD					= "ChangeRate";
		public const String PRICE_FIELD							= "Price";
		public const String TAXRATE_FIELD						= "TaxRate";
		public const String DISCOUNTRATE_FIELD					= "DiscountRate";
        public const String DISCOUNTSUM_FIELD					= "DiscountSum";
		
		public const String ALLSUM_FIELD						= "AllSum";
		public const String WITHOUTTAXSUM_FIELD					= "WithoutTaxSum";
		public const String TAXSUM_FIELD						= "TaxSum";
		public const String ITEMCONTEXT_FIELD					= "ItemContext";
		public const String DESCRIPTION_FIELD					= "Description";

		//Added by YiChangxin 2005-8-30
		public const String MATERIALNAME_FIELD					= "Materialname";
		public const String MODEL_FIELD							= "model";


		public PurchasingContractDetailData()
		{
			CreateTable();
		}

		private void CreateTable()
		{
			DataTable tables =   new DataTable(PURCHARINGCONTRACTDETAIL_TABLE);
			DataColumnCollection columns=tables.Columns;

			columns.Add(CONTRACTID_FIELD  ,typeof(System.String));
			columns.Add(PRICEMODE_FIELD  ,typeof(System.String));
			columns.Add(MATERIALID_FIELD  ,typeof(System.String));
			columns.Add(AMOUNT_FIELD  ,typeof(System.Decimal));
			columns.Add(UNIT_FIELD  ,typeof(System.String));

			columns.Add(CHANGERATE_FIELD  ,typeof(System.String));
			columns.Add(PRICE_FIELD  ,typeof(System.Decimal));
			columns.Add(TAXRATE_FIELD  ,typeof(System.Decimal));
			columns.Add(DISCOUNTRATE_FIELD  ,typeof(System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD  ,typeof(System.Decimal));

			columns.Add(ALLSUM_FIELD  ,typeof(System.Decimal));
			columns.Add(WITHOUTTAXSUM_FIELD  ,typeof(System.Decimal));
			columns.Add(TAXSUM_FIELD  ,typeof(System.Decimal));
			columns.Add(ITEMCONTEXT_FIELD  ,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD  ,typeof(System.String));

			//Added by YiChangxin 2005-8-30
			columns.Add(MATERIALNAME_FIELD  ,typeof(System.String));
			columns.Add(MODEL_FIELD  ,typeof(System.String));

			this.Tables.Add(tables);
		}
	}
}
