using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	/// <summary>
	/// SalesPlanData 的摘要说明。
	/// </summary>
	public class SalesPlanData : DataSet
	{
		public const String SALESPLAN_TABLE				= "TBL_SalesPlan";

		public const String SALESPLANNAME_FIELD			= "SalesPlanName";
		public const String SALESPLANID_FIELD			= "SalesPlanID";
		public const String SALESPLANTYPE_FIELD			= "SalesPlanType";
		public const String BUSINESSTYPE_FIELD			= "BusinessType";
		public const String ORIGINALSALESPLANID_FIELD	= "OriginalSalesPlanID";

		public const String BEGINDATE_FIELD				= "BeginDate";
		public const String ENDDATE_FIELD				= "EndDate";
		public const String PLANSUM_FIELD				= "PlanSum";
		public const String DRAWDEPARTMENT_FIELD		= "DrawDepartment";
		public const String DRAWDEPARTMENTNAME_FIELD	= "DrawDepartmentname";
		public const String DRAWPERSON_FIELD			= "DrawPerson";
		public const String DRAWPERSONNAME_FIELD		= "DrawPersonname";

		public const String DRAWDATE_FIELD				= "DrawDate";
		public const String STATUS_FIELD				= "Status";
		public const String ACCOUNTDEP_FIELD			= "AccountDep";
		public const String DESCRIPTION_FIELD			= "Description";

		public const string SEQUENCENAME  = "SalesPlanID";

		public enum RecordStatus
		{
			未确认 = 10,
			已确认 = 15,
			已驳回 = 30,
			已生效 = 40,
			
		}


		public SalesPlanData()
		{
			CreateTable();
		}
		private void CreateTable()
		{
			DataTable   tables  = new DataTable(SALESPLAN_TABLE);
			DataColumnCollection  columns = tables.Columns;

			columns.Add(SALESPLANNAME_FIELD , typeof (System.String));
			columns.Add(SALESPLANID_FIELD , typeof (System.String));
			columns.Add(SALESPLANTYPE_FIELD , typeof (System.String));
			columns.Add(BUSINESSTYPE_FIELD , typeof (System.String));
			columns.Add(ORIGINALSALESPLANID_FIELD , typeof (System.String));

			columns.Add(BEGINDATE_FIELD , typeof (System.DateTime));
			columns.Add(ENDDATE_FIELD , typeof (System.DateTime));
			columns.Add(PLANSUM_FIELD , typeof (System.Decimal));
			columns.Add(DRAWDEPARTMENT_FIELD , typeof (System.String));
			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD , typeof (System.String));
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));

			columns.Add(DRAWDATE_FIELD , typeof (System.DateTime));
			columns.Add(STATUS_FIELD , typeof (System.String));
			columns.Add(ACCOUNTDEP_FIELD , typeof (System.String));
			columns.Add(DESCRIPTION_FIELD , typeof (System.String));

			this.Tables.Add(tables);

		}
	}
}
