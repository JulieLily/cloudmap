using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// CraftBrotherSalesAnalysisData 的摘要说明。
	/// </summary>
	public class CraftBrotherSalesAnalysisData:DataSet
	{
		public const String CRAFTBROTHERSALESANALYSIS_TABLE = "tbl_craftbrothersalesanalysis";

		public const String AREAID_FIELD         = "areaid";
		public const String AREANAME_FIELD		 = "areaname";		//2005-9-5 魏套江添加		
		public const String CRAFTBROTHERID_FIELD = "craftbrotherid";
		public const String DEPARTMENTID_FIELD   = "departmentid";
		public const String BEGINDATE_FIELD      = "begindate";
		public const String PRODUCTNAME_FIELD    = "productname";

		public const String MODEL_FIELD          = "model";
		public const String ENDDATE_FIELD        = "enddate";
		public const String OUTAMOUNT_FIELD      = "outamount";
		public const String INAMOUNT_FIELD       = "inamount";
		public const String UNIT_FIELD           = "unit";
		public const String SALESPRICE_FIELD     = "salesprice";
		public const String FUTURESPRICE_FIELD   = "futuresprice";
		public const String CYCLE_FIELD          = "cycle";
		public const String CHARACTERISTIC_FIELD = "characteristic";
		public const String DESCRIPTION_FIELD    = "description";

		public CraftBrotherSalesAnalysisData()
		{
			BuildTables();
		}
		private CraftBrotherSalesAnalysisData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(CRAFTBROTHERSALESANALYSIS_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(AREAID_FIELD,typeof(System.String));
			columns.Add(AREANAME_FIELD,typeof(System.String));
			columns.Add(CRAFTBROTHERID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(BEGINDATE_FIELD,typeof(System.DateTime));
			columns.Add(PRODUCTNAME_FIELD,typeof(System.String));

			columns.Add(MODEL_FIELD,typeof(System.String));
			columns.Add(ENDDATE_FIELD,typeof(System.DateTime));
			columns.Add(OUTAMOUNT_FIELD,typeof(System.Decimal));
			columns.Add(INAMOUNT_FIELD,typeof(System.Decimal));
			columns.Add(UNIT_FIELD,typeof(System.String));
			columns.Add(SALESPRICE_FIELD,typeof(System.Decimal));
			columns.Add(FUTURESPRICE_FIELD,typeof(System.Decimal));
			columns.Add(CYCLE_FIELD,typeof(System.String));
			columns.Add(CHARACTERISTIC_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
