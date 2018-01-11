using System;
using System.Runtime.Serialization;
using System.Data;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// CustomerVisitRecordData 的摘要说明。
	/// </summary>
	public class CustomerVisitRecordData : DataSet
	{
		public const String CUSTOMERVISITRECORD_TABLE = "tbl_customervisitrecord";

		public const String CVRID_FIELD          = "cvrid";
		public const String CVRNAME_FIELD        = "cvrname";
		public const String CUSTOMERNO_FIELD     = "customerno";
		public const String CUSTOMERNAME_FIELD     = "customername";
		public const String TYPE_FIELD           = "type";
		public const String GOAL_FIELD           = "goal";
		public const String CONTEXT_FIELD        = "context";
		public const String BEGINTIME_FIELD      = "begintime";
		public const String ENDTIME_FIELD        = "endtime";
		public const String MASTERSTAFF_FIELD    = "masterstaff";
		public const String CUSTOMERSTAFF_FIELD  = "customerstaff";
		public const String GIFT_FIELD           = "gift";
		public const String COSTSUM_FIELD        = "costsum";
		public const String RESULT_FIELD         = "result";
		public const String ADDRESS_FIELD        = "address";
		public const String DRAWDEPARTMENT_FIELD = "drawdepartment";
		public const String DRAWDEPARTMENTNAME_FIELD = "drawdepartmentname";
		public const String DRAWPERSON_FIELD     = "drawperson";
		public const String DRAWPERSONNAME_FIELD     = "drawpersonname";
		public const String DRAWDATE_FIELD       = "drawdate";
		public const String STATUS_FIELD         = "status";
		public const String ACCOUNTDEP_FIELD     = "accountdep";
		public const String DESCRIPTION_FIELD    = "description";
		public const String CVRIDRECORD_FIELD    = "cvridrecord";


		public CustomerVisitRecordData()
		{
			BuildTables();
		}
		private CustomerVisitRecordData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(CUSTOMERVISITRECORD_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(CVRID_FIELD,typeof(System.String));
			columns.Add(CVRNAME_FIELD,typeof(System.String));
			columns.Add(CUSTOMERNO_FIELD,typeof(System.String));
			columns.Add(TYPE_FIELD,typeof(System.String));
			columns.Add(GOAL_FIELD,typeof(System.String));
			columns.Add(CONTEXT_FIELD,typeof(System.String));
			columns.Add(BEGINTIME_FIELD,typeof(System.DateTime));
			columns.Add(ENDTIME_FIELD,typeof(System.DateTime));
			columns.Add(MASTERSTAFF_FIELD,typeof(System.String));
			columns.Add(CUSTOMERSTAFF_FIELD,typeof(System.String));
			columns.Add(GIFT_FIELD,typeof(System.String));
			columns.Add(COSTSUM_FIELD,typeof(System.String));
			columns.Add(RESULT_FIELD,typeof(System.String));
			columns.Add(ADDRESS_FIELD,typeof(System.String));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));
			columns.Add(STATUS_FIELD,typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			//Added by YiChangxin 2005-8-29
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));
			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(CUSTOMERNAME_FIELD,typeof(System.String));
			columns.Add(CVRIDRECORD_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
