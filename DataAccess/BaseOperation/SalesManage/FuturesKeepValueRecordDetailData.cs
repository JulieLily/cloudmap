using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// FuturesKeepValueRecordDetailData 的摘要说明。
	/// </summary>
	public class FuturesKeepValueRecordDetailData :DataSet
	{
		public const String FUTURESKEEPVALUERECORDDETAIL_TABLE		=	"TBL_FuturesKeepValueRecordDetail";
		
		public const String MATERIALID_FIELD						=	"MaterialID";
		public const String FKVRID_FIELD							=	"FKVRID";
		public const String PRICEMODE_FIELD							=	"PriceMode";
		public const String AMOUNT_FIELD							=	"Amount";
		public const String ITEMCONTEXT_FIELD						=	"ItemContext";

		public const String UNIT_FIELD								=	"Unit";
		public const String CHANGERATE_FIELD						=	"ChangeRate";
		public const String PRICE_FIElD								=	"Price";
		public const String SUM_FILD								=	"Sum";
		public const String DESCRIPTION_FIELD						=	"Description";

		public FuturesKeepValueRecordDetailData()
		{
		
			CreateTable();
		}
		private void CreateTable()
		{
			DataTable   tables = new DataTable(FUTURESKEEPVALUERECORDDETAIL_TABLE);
			DataColumnCollection  columns = tables.Columns;

			columns.Add(MATERIALID_FIELD  , typeof(System.String));
			columns.Add(FKVRID_FIELD  , typeof(System.String));
			columns.Add(PRICEMODE_FIELD  , typeof(System.String));
			columns.Add(AMOUNT_FIELD  , typeof(System.Decimal));
			columns.Add(ITEMCONTEXT_FIELD  , typeof(System.String));

			columns.Add(UNIT_FIELD  , typeof(System.String));
			columns.Add(CHANGERATE_FIELD  , typeof(System.String));
			columns.Add(PRICE_FIElD  , typeof(System.Decimal));
			columns.Add(SUM_FILD  , typeof(System.Decimal));
			columns.Add(DESCRIPTION_FIELD  , typeof(System.String));

			this.Tables.Add(tables);
		}
	}
}
