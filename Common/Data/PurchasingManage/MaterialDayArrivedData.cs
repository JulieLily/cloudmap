using System;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;

using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// MaterialDayArrivedData 的摘要说明。
	/// </summary>
	public class MaterialDayArrivedData:DataSet
	{
		public const String MATERIALDAYARRIVED_TABLE = "tbl_materialdayarrived";

		public const String VEHICLENO_FIELD     = "vehicleno";
		public const String MATERIALID_FIELD    = "materialid";
		public const String PROVIDER_FIELD      = "provider";
		public const String ARRIVALDATE_FIELD   = "arrivaldate";

		public const String MANUFACTURER_FIELD   = "manufacturer";
		public const String FREIGHT_FIELD        = "freight";
		public const String AMOUNT_FIELD         = "amount";
		public const String UNIT_FIELD           = "unit";
		public const String CHANGERATE_FIELD     = "changerate";
		public const String STATUS_FIELD         = "status";
		public const String DRAWDEPARTMENT_FIELD = "drawdepartment";
		public const String DRAWPERSON_FIELD     = "drawperson";
		public const String DRAWDATE_FIELD       = "drawdate";
		public const String ACCOUNTDEP_FIELD     = "accountdep";
		public const String DESCRIPTION_FIELD    = "description";

		//Added by 魏套江 2005-8-16  
		public const String PROVIDERNAME_FIELD = "providername";
		public const String MANUFACTURERNAME_FIELD= "manufacturername";
		public const String DRAWDEPARTMENTNAME_FIELD = "drawdepartmentname";
		public const String DRAWPERSONNAME_FIELD = "drawpersonname";
		public const String MATERIALNAME_FIELD = "materialname";
		public const String MODEL_FIELD = "model";

		public MaterialDayArrivedData()
		{
			BuildTables();
		}
		private MaterialDayArrivedData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(MATERIALDAYARRIVED_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(VEHICLENO_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(PROVIDER_FIELD,typeof(System.String));
			columns.Add(ARRIVALDATE_FIELD,typeof(System.DateTime));

			columns.Add(MANUFACTURER_FIELD,typeof(System.String));
			columns.Add(FREIGHT_FIELD,typeof(System.Decimal));
			columns.Add(AMOUNT_FIELD,typeof(System.Decimal));
			columns.Add(UNIT_FIELD,typeof(System.String));
			columns.Add(CHANGERATE_FIELD,typeof(System.Single));
			columns.Add(STATUS_FIELD,typeof(System.String));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			//Added by 魏套江 2005-8-16  
			columns.Add(PROVIDERNAME_FIELD,typeof(System.String));
			columns.Add(MANUFACTURERNAME_FIELD,typeof(System.String));
			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));
			columns.Add(MATERIALNAME_FIELD,typeof(System.String));
			columns.Add(MODEL_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
