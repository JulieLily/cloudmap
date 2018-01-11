using System;
using System.Data;
using System.Runtime .Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	
	public class InStoreDetailData:DataSet
	{
		public const String INSTOREDETAIL_TABLE         = "TBL_InStoreDetail";


		public const string MATERIALID_FIELD			= "materialid";   
		public const string MATERIALNAME_FIELD			= "materialname";
		public const string MODEL_FIELD					= "model";
		public const string BATCHNO_FIELD				= "batchNO";
		public const string PUB_ATTTRIBUTE_FIELD		= "pub_Attribute";
		public const string ISRID_FIELD					= "isrid";
		public const string DECLAREAMOUNT_FIELD			= "declareamount";

		public const string REALAMOUNT_FIELD			= "realamount";
		public const string UNIT_FIELD                  = "unit";
		public const string CHANGERATE_FIELD			= "changerate";
		public const string PRICE_FIELD					= "price";
		public const string TAXRATE_FIELD				= "taxrate";

		public const string DISCOUNTRATE_FIELD			= "discountrate";
		public const string ALLSUM_FIELD			    = "allsum";
		public const string DISCOUNTSUM_FIELD			= "discountsum";
		public const string WITHOUTTAXSUM_FIELD	 		= "withouttaxsum";
		public const string TAXSUM_FIELD				= "taxsum";

		public const string QCRID_FIELD					= "qcrid";
		public const string DESCRIPTION_FIELD			= "description";

		public InStoreDetailData()   //  InStoreDetailData
		{
			BuildTables();
		}

		private void BuildTables()
		{
			DataTable table=new DataTable(INSTOREDETAIL_TABLE);
			DataColumnCollection columns=table.Columns;

			columns.Add(MATERIALID_FIELD, typeof(System.String));
			columns.Add(MATERIALNAME_FIELD, typeof(System.String));
			columns.Add(MODEL_FIELD, typeof(System.String));
			columns.Add(BATCHNO_FIELD,typeof(System.String));
			columns.Add(PUB_ATTTRIBUTE_FIELD, typeof(System.String));
			columns.Add(ISRID_FIELD, typeof(System.String));
			columns.Add(DECLAREAMOUNT_FIELD, typeof(System.Decimal));

			columns.Add(REALAMOUNT_FIELD, typeof(System.Decimal));
			columns.Add(UNIT_FIELD, typeof(System.String));
			columns.Add(CHANGERATE_FIELD, typeof(System.Double));		
			columns.Add(PRICE_FIELD, typeof(System.Decimal));
			columns.Add(TAXRATE_FIELD, typeof(System.Decimal));

			columns.Add(DISCOUNTRATE_FIELD, typeof(System.Decimal));
			columns.Add(ALLSUM_FIELD, typeof(System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD, typeof(System.Decimal));
			columns.Add(WITHOUTTAXSUM_FIELD, typeof(System.Decimal));
			columns.Add(TAXSUM_FIELD, typeof(System.Decimal));	
	
			columns.Add(QCRID_FIELD, typeof(System.String));		
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
