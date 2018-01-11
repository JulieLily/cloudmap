using System;
using System.Data;
using System.Runtime.Serialization;


namespace TOPSUN.ERP.Common.Data.StoreManage
{

	[SerializableAttribute]
	[System.ComponentModel.DesignerCategory("Code")]
	/// <summary>
	/// StockStoreInfoData 的摘要说明。
	/// </summary>
	public class StockStoreInfoData :DataSet
	{
		public const String STOCKSTOREINFO_TABLE    = "TBL_StockStoreInfo";

		public const String DEPARTMENTID_FIELD      = "DepartmentID";
		public const String MATERIALID_FIELD        = "MaterialID";
		public const String DRAWMENT_FIELD          = "DrawDepartment";
		public const String HIGHERLIMIT_FIELD       = "HigherLimit";
		public const String LOWERLIMIT_FIELD        = "LowerLimit";

		public const String WARNHIGHERLIMIT_FIELD   = "WarningHigherLimit";
		public const String WARNLOWERLIMIT_FIELD    = "WarningLowerLimit";
		public const String SAFESTOCK_FIELD         = "SafeStock";
		public const String OUTMODE_FIELD           = "OutMode";
		public const String DRAWPERSON_FIELD        = "DrawPerson";

		public const String DRAWDATE_FIELD          = "DrawDate";
		public const String BATCHTRACK_FIELD        = "BatchTrack";
		public const String DESCRIPTION_FIELD       = "Description";
		

		public StockStoreInfoData()
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			 DataTable   tables	=	new DataTable(STOCKSTOREINFO_TABLE);
			 DataColumnCollection columns=tables.Columns;

			 columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			 columns.Add(MATERIALID_FIELD,typeof(System.String));
			 columns.Add(DRAWMENT_FIELD,typeof(System.String));
			 columns.Add(HIGHERLIMIT_FIELD,typeof(System.String));
			 columns.Add(LOWERLIMIT_FIELD,typeof(System.String));

			 columns.Add(WARNHIGHERLIMIT_FIELD,typeof(System.String));
			 columns.Add(WARNLOWERLIMIT_FIELD,typeof(System.String));
			 columns.Add(SAFESTOCK_FIELD,typeof(System.String));
			 columns.Add(OUTMODE_FIELD,typeof(System.String));
			 columns.Add(DRAWPERSON_FIELD,typeof(System.String));

			 columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));
			 columns.Add(BATCHTRACK_FIELD,typeof(System.String));
			 columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			
			this.Tables.Add(tables);
			 
		}
	}
}
