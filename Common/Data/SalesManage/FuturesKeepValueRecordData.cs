using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	/// <summary>
	/// FuturesKeepValueRecordData 的摘要说明。
	/// </summary>
	/// 
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]

	public class FuturesKeepValueRecordData :DataSet
	{
		public const String FUTURESKEEPVALUERECORD_TABLE		=	"TBL_FuturesKeepValueRecord";

		public const String FKVRNAME_FIELD						=	"FKVRName";
		public const String FKVRID_FIELD						=	 "FKVRID";
		public const String FKVR_FIELD							=	 "fkvr";
		public const String CONTRACTID_FIELD					=	"ContractID";
		public const String CONTRACTNAME_FIELD					=	"Contractname";
        public const String BEGINDATE_FIELD						=	"BeginDate";
		public const String ENDDATE_FIELD						=	 "EndDate";

		public const String SUM_FIELD							=	"Sum";
		public const String DRAWDEPARTMENT_FIELD				=	"DrawDepartment";
		public const String DRAWDEPARTMENTNAME_FIELD			=	"DrawDepartmentname";
		public const String DRAWPERSON_FIELD					=	"DrawPerson";
		public const String DRAWPERSONNAME_FIELD				=	"DrawPersonname";
		public const String DRAWDATE_FIELD						=	"DrawDate";
		public const String STATUS_FIELD						=	"Status";

		public const String ACCOUNTDEP_FIELD					=	"AccountDep";
		public const String DESCRIPTION_FIELD					=	"Description";

		public enum FuturesKeepValueRecordStatus
		{
			未确认=0,
			
			已驳回=1,
			
			已生效=2,
		
			已确认=3
		}

		public FuturesKeepValueRecordData()
		{
			CreateTable();
		}
		private void CreateTable()
		{
			DataTable tables   =  new DataTable(FUTURESKEEPVALUERECORD_TABLE);
			DataColumnCollection  columns = tables.Columns;

			columns.Add(FKVRNAME_FIELD  , typeof(System.String));
			columns.Add(FKVRID_FIELD  , typeof(System.String));
			columns.Add(FKVR_FIELD  , typeof(System.String));
			columns.Add(CONTRACTID_FIELD  , typeof(System.String));
			columns.Add(CONTRACTNAME_FIELD  , typeof(System.String));
			columns.Add(BEGINDATE_FIELD  , typeof(System.DateTime));
			columns.Add(ENDDATE_FIELD  , typeof(System.DateTime));

			columns.Add(SUM_FIELD  , typeof(System.Decimal));
			columns.Add(DRAWDEPARTMENT_FIELD  , typeof(System.String));
			columns.Add(DRAWDEPARTMENTNAME_FIELD  , typeof(System.String));
			columns.Add(DRAWPERSON_FIELD  , typeof(System.String));
			columns.Add(DRAWPERSONNAME_FIELD  , typeof(System.String));
			columns.Add(DRAWDATE_FIELD  , typeof(System.DateTime));
			columns.Add(STATUS_FIELD  , typeof(System.String));

			columns.Add(ACCOUNTDEP_FIELD  , typeof(System.String));
			columns.Add(DESCRIPTION_FIELD  , typeof(System.String));

			this.Tables.Add(tables);

		}
	}
}
