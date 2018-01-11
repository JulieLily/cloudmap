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
	/// RequirementPlanDetailData 的摘要说明。
	/// </summary>
	public class RequirementPlanDetailData:DataSet
	{
		public const String REQUIREMENTPLANDETAIL_TABLE = "tbl_requirementplandetail";

		public const String DEPARTMENTID_FIELD      = "departmentid";
		public const String REQUIREMENTPLANID_FIELD = "requirementplanid";
		public const String MATERIALID_FIELD        = "materialid";
		public const String UNIT_FIELD              = "unit";
		public const String CHANGERATE_FIELD        = "changerate";
		public const String PLANPRICE_FIELD         = "planprice";
		public const String PLANSUM_FIELD           = "plansum";
		public const String DESCRIPTION_FIELD       = "description";
		public const String AMOUNT_FIELD            = "amount";
	 

		public RequirementPlanDetailData()
		{
			BuildTables();
		}
		private RequirementPlanDetailData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(REQUIREMENTPLANDETAIL_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(REQUIREMENTPLANID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(UNIT_FIELD,typeof(System.String));
			columns.Add(CHANGERATE_FIELD,typeof(System.Single));
			columns.Add(PLANPRICE_FIELD,typeof(System.Decimal));
			columns.Add(PLANSUM_FIELD,typeof(System.Decimal));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			columns.Add(AMOUNT_FIELD,typeof(System.Decimal));

			this.Tables.Add(table);
		}
	}
}
