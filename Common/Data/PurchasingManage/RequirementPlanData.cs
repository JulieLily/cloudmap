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
	/// RequirementPlanData ��ժҪ˵����
	/// </summary>
	public class RequirementPlanData:DataSet
	{
		public const String REQUIREMENTPLAN_TABLE = "tbl_requirementplan";
		
		public const String REQUIREMENTPLANID_FIELD			= "requirementplanid";
		public const String PLANNAME_FIELD					= "planname";
		public const String PLANTYPE_FIELD					= "plantype";
		public const String BEGINDATE_FIELD					= "begindate";
		public const String ENDDATE_FIELD					= "enddate";
		public const String BUSINESSTYPE_FIELD				= "businesstype";
		public const String PLANSUM_FIELD					= "plansum";
		public const String DRAWDEPARTMENT_FIELD			= "drawdepartment";
		public const String DRAWPERSON_FIELD				= "drawperson";
		public const String DRAWDATE_FIELD					= "drawdate";
		public const String DESCRIPTION_FIELD				= "description";
		public const String ACCOUNTDEP_FIELD				= "accountdep";
		public const String STATUS_FIELD					= "status";

		//Added by XuJiansong 2005-8-22
		public const string DRAWDEPARTMENTNAME_FIELD    ="drawdepartmentname";
		public const string DRAWPERSONNAME_FIELD        ="drawpersonname";
		public const string SEQUENCENAME				= "RequirementPlanID";

		public enum RecordState   // add FIELD ------by �콨�� 2005-09-12
		{
			/// δȷ��״̬
			//			NoSubmitState = 0,
			δȷ��=0,
			/// �Ѳ���״̬
			//			NoPassState = 1,
			�Ѳ���=1,
			/// ����Ч״̬
			//			PassState = 2,
			����Ч=2,
			/// ��ȷ��״̬
			//			SubmitState = 3
			��ȷ��=3
		}


		public RequirementPlanData()
		{
			BuildTables();
		}
		private RequirementPlanData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(REQUIREMENTPLAN_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(REQUIREMENTPLANID_FIELD,typeof(System.String));
			columns.Add(PLANNAME_FIELD,typeof(System.String));
			columns.Add(PLANTYPE_FIELD,typeof(System.String));
			columns.Add(BEGINDATE_FIELD,typeof(System.DateTime));
			columns.Add(ENDDATE_FIELD,typeof(System.DateTime));
			columns.Add(BUSINESSTYPE_FIELD,typeof(System.String));
			columns.Add(PLANSUM_FIELD,typeof(System.Decimal));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(STATUS_FIELD,typeof(System.String));

			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
