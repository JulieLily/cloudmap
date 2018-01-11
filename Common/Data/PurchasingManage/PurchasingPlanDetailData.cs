using System;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// PurchasingPlanDetailData 的摘要说明。
	/// </summary>
	public class PurchasingPlanDetailData:DataSet
	{
		public const String PURCHASINGPLANDETAIL_TABLE = "tbl_purchasingplandetail";

		public const String MANUFACTURER_FIELD      = "manufacturer";
		public const String PURCHASINGPLANID_FIELD  = "purchasingplanid";
		public const String DEPARTMENTID_FIELD      = "departmentid";
		public const String MATERIALID_FIELD        = "materialid";

		public const String AMOUNT_FIELD            = "amount";
		public const String MAINGRADE_FIELD         = "maingrade";
		public const String CURRENTSTOCK_FIELD      = "currentstock";
		public const String UNIT_FIELD              = "unit";
		public const String CHANGERATE_FIELD        = "changerate";
		public const String PRECARRIAGE_FIELD       = "precarriage";
		public const String STATIONOFDISPATCH_FIELD = "stationofdispatch";
		public const String TIMELIMIT_FIELD         = "timelimit";
		public const String MODE_FIELD              = "mode";
		public const String PRICE_FIELD             = "price";
		public const String SUM_FIELD               = "sum";
		public const String ARRIVEDTIME_FIELD       = "arrivedtime";
		public const String DESCRIPTION_FIELD       = "description";

		// Added by XuJiansong 2005-8-29
		public const String MANUFACTURERNAME_FIELD      = "manufacturername";

        public PurchasingPlanDetailData()
		{
			 BuildTables();
		}
		private PurchasingPlanDetailData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(PURCHASINGPLANDETAIL_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(MANUFACTURER_FIELD,typeof(System.String));
			columns.Add(PURCHASINGPLANID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));

			columns.Add(AMOUNT_FIELD,typeof(System.Decimal));
			columns.Add(MAINGRADE_FIELD,typeof(System.Single));
			columns.Add(CURRENTSTOCK_FIELD,typeof(System.Decimal));
			columns.Add(UNIT_FIELD,typeof(System.String));
//			columns.Add(CHANGERATE_FIELD,typeof(System.Int16));
			columns.Add(CHANGERATE_FIELD,typeof(System.String)); // Modify Xujiansong 2005-10-9 (转换关系为real 类型 )*****************
			columns.Add(PRECARRIAGE_FIELD,typeof(System.Int16));
			columns.Add(STATIONOFDISPATCH_FIELD,typeof(System.String));
			columns.Add(TIMELIMIT_FIELD,typeof(System.String));
			columns.Add(MODE_FIELD,typeof(System.String));
			columns.Add(PRICE_FIELD,typeof(System.Decimal));
			columns.Add(SUM_FIELD,typeof(System.Decimal));
			columns.Add(ARRIVEDTIME_FIELD,typeof(System.DateTime));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			//Added by XuJiansong 2005-8-29
			columns.Add(MANUFACTURERNAME_FIELD,typeof(System.String)); 

			this.Tables.Add(table);

		}
	}
}
