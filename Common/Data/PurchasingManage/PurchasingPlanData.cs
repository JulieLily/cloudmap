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
	/// PurchasingPlanData 的摘要说明。
	/// </summary>
	public class PurchasingPlanData:DataSet
	{
		public const String PURCHASINGPLAN_TABLE   = "tbl_purchasingplan";

		public const String PURCHASINGPLANID_FIELD = "purchasingplanid";
		public const String NAME_FIELD             = "name";
		public const String PLANTYPE_FIELD         = "plantype";
		public const String BEGINDATE_FIELD        = "begindate";
		public const String ENDDATE_FIELD          = "enddate";
		public const String BUSINESSTYPE_FIELD     = "businesstype";
		public const String PLANSUM_FIELD          = "plansum";
		public const String DRAWDEPARTMENT_FIELD   = "drawdepartment";
		public const String DRAWPERSON_FIELD       = "drawperson";
		public const String DRAWDATE_FIELD         = "drawdate";
		public const String STATUS_FIELD            = "status";
		public const String ACCOUNTDEP_FIELD       = "accountdep";
		public const String ORIGINALID_FIELD       = "originalid";
		public const String DESCRIPTION_FIELD      = "description";

		// Added by XuJiansong 2005-8-29
		public const string DRAWDEPARTMENTNAME_FIELD    ="drawdepartmentname";
		public const string DRAWPERSONNAME_FIELD        ="drawpersonname";
		public const string SEQUENCENAME				= "Purchasingplanid";  

		public enum RecordState   // add FIELD ------by 徐建松 2005-09-14
		{
			/// 未确认状态
			//			NoSubmitState = 0,
			未确认=0,
			/// 已驳回状态
			//			NoPassState = 1,
			已驳回=1,
			/// 已生效状态
			//			PassState = 2,
			已生效=2,
			/// 已确认状态
			//			SubmitState = 3
			已确认=3
		}
		
		public PurchasingPlanData()
		{
			BuildTables();
		}
		private PurchasingPlanData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(PURCHASINGPLAN_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(PURCHASINGPLANID_FIELD,typeof(System.String));
			columns.Add(NAME_FIELD,typeof(System.String));
			columns.Add(PLANTYPE_FIELD,typeof(System.String));
			columns.Add(BEGINDATE_FIELD,typeof(System.DateTime));
			columns.Add(ENDDATE_FIELD,typeof(System.DateTime));
			columns.Add(BUSINESSTYPE_FIELD,typeof(System.String));
			columns.Add(PLANSUM_FIELD,typeof(System.Decimal));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));
			columns.Add(STATUS_FIELD,typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(ORIGINALID_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			//Added by XuJiansong 2005-8-29
			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));

			this.Tables.Add(table);

		}
	}
}
