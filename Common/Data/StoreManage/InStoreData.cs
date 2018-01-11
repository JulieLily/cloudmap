using System;
using System.Data;
using System.Runtime.Serialization;


namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	public class InStoreData:DataSet
	{
		public const String INSTORE_TABLE          = "TBL_Instore";

		public const String ISRID_FIELD            = "isrid";
		public const string ISRNAME_FIELD          = "isrname";
        public const string REDBLUEREMARK_FIELD    = "redblueremark";
        public const string DEPARTMENTID_FIELD     = "departmentid";
		public const string DEPARTMENTNAME_FIELD   = "departmentname";
		public const string HOUSEID_FIELD          = "houseid";
		public const string HOUSENAME_FIELD        = "housename";

		public const string CORCOMPANY_FIELD       ="corcompany";
		public const string CORCOMPANYNAME_FIELD   ="corcompanyname";
		public const string INTYPE_FIELD           ="intype";
		public const string INCATEGORY_FIELD       ="incategory";
		public const string INDATE_FIELD           ="indate";
		public const string ALLSUM_FIELD		   ="allsum";

		public const string DISCOUNTSUM_FIELD     ="discountsum";
		public const string WITHOUTTAXSUM_FIELD   ="withouttaxsum";
		public const string TAXSUM_FIELD          ="taxsum";
		public const string DRAWDEPARTMENT_FIELD    ="drawdepartment";
		public const string DRAWDEPARTMENTNAME_FIELD    ="drawdepartmentname";
		public const string DRAWPERSON_FIELD        ="drawperson";
	    public const string DRAWPERSONNAME_FIELD        ="drawpersonname";

	    public const string DRAWDATE_FIELD          ="drawdate";
        public const string CHECKER_FIELD			="checker";
		public const string CUSTODIAN_FIELD			="custodian";
		public const string BUSINESSPERSON_FIELD    ="businessperson";
		public const string CHECKERNAME_FIELD			="checkername";
		public const string CUSTODIANNAME_FIELD			="custodianname";
		public const string BUSINESSPERSONNAME_FIELD    ="businesspersonname";
		public const string FINANCIALPERSON_FIELD   ="financialperson";

        public const string FINANCIALREMARK_FIELD   ="financialremark";
		public const string FINANCIALDATE_FIELD		="financialdate";
		public const string INVENTORYPERSON_FIELD	="inventoryperson";
		public const string INVENTORYREMARK_FIELD   ="inventoryremark";	
		public const string INVENTORYDATE_FIELD     ="inventorydate";

    	public const string RECORDID_FIELD				="recordid";
		public const string RECORDNAME_FIELD			="recordname";
		public const string ACCOUNTDEP_FIELD            ="accountdep";
		public const string CONTRACTID_FIELD			="contractid";
		public const string CONTRACTNAME_FIELD			="contractname";
		public const string STATUS_FIELD                ="status";
		public const string DESCRIPTION_FIELD			="description";

		public const string OSRNAME_FIELD			 ="osrname";  //ycx移库入库所加

		public const string SEQUENCENAME  = "InStoreRecord";

		public enum RecordState   // add FIELD ------by 徐建松 2005-09-12
		{
			/// <summary>
			/// 未确认状态
			/// </summary>
			//			NoSubmitState = 0,
			未确认=0,
			/// <summary>
			/// 已驳回状态
			/// </summary>
			//			NoPassState = 1,
			已驳回=1,
			/// <summary>
			/// 已生效状态
			/// </summary>
			//			PassState = 2,
			已生效=2,
			/// <summary>
			/// 已确认状态
			/// </summary>
			//			SubmitState = 3
			已确认=3
		}

		public InStoreData()
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			DataTable table =new DataTable(INSTORE_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(ISRID_FIELD, typeof(System.String));
			columns.Add(ISRNAME_FIELD,typeof(System.String));
			columns.Add(REDBLUEREMARK_FIELD, typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD, typeof(System.String));
			columns.Add(DEPARTMENTNAME_FIELD, typeof(System.String));
			columns.Add(HOUSEID_FIELD, typeof(System.String));
			columns.Add(HOUSENAME_FIELD, typeof(System.String));
			columns.Add(CORCOMPANY_FIELD, typeof(System.String));
			columns.Add(CORCOMPANYNAME_FIELD, typeof(System.String));
			columns.Add(INTYPE_FIELD, typeof(System.String));
			columns.Add(INCATEGORY_FIELD, typeof(System.String));		
			columns.Add(INDATE_FIELD, typeof(System.DateTime));
			columns.Add(ALLSUM_FIELD, typeof(System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD, typeof(System.Decimal));
			columns.Add(WITHOUTTAXSUM_FIELD, typeof(System.Decimal));
			columns.Add(TAXSUM_FIELD, typeof(System.Decimal));
			columns.Add(DRAWDEPARTMENT_FIELD, typeof(System.String));
			columns.Add(DRAWDEPARTMENTNAME_FIELD, typeof(System.String));
			columns.Add(DRAWPERSON_FIELD, typeof(System.String));	
			columns.Add(DRAWPERSONNAME_FIELD, typeof(System.String));		
			columns.Add(DRAWDATE_FIELD, typeof(System.DateTime));		
			columns.Add(CHECKER_FIELD, typeof(System.String));
			columns.Add(CUSTODIAN_FIELD, typeof(System.String));
			columns.Add(BUSINESSPERSON_FIELD, typeof(System.String));
			columns.Add(CHECKERNAME_FIELD, typeof(System.String));
			columns.Add(CUSTODIANNAME_FIELD, typeof(System.String));
			columns.Add(BUSINESSPERSONNAME_FIELD, typeof(System.String));
			columns.Add(FINANCIALPERSON_FIELD, typeof(System.String));
			columns.Add(FINANCIALREMARK_FIELD, typeof(System.String));
			columns.Add(FINANCIALDATE_FIELD, typeof(System.DateTime));
			columns.Add(INVENTORYPERSON_FIELD, typeof(System.String));
			columns.Add(INVENTORYREMARK_FIELD, typeof(System.String));
			columns.Add(INVENTORYDATE_FIELD, typeof(System.DateTime));
			columns.Add(RECORDID_FIELD, typeof(System.String));
			columns.Add(RECORDNAME_FIELD, typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD, typeof(System.String));
			columns.Add(CONTRACTID_FIELD, typeof(System.String));
			columns.Add(CONTRACTNAME_FIELD, typeof(System.String));
			columns.Add(STATUS_FIELD, typeof(System.String));
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			this.Tables.Add(table);
		}
	}
}
