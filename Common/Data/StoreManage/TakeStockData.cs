using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	/// <summary>
	/// TakeStockData 的摘要说明。
	/// </summary> 
	[SerializableAttribute]
	[System.ComponentModel.DesignerCategory("Code")]
	public class TakeStockData :DataSet
	{
		public  const String TAKESTOCK_TABLE     = "TBL_TakeStock";

		public const String TSRID_FIELD          = "TSRID";
		public const String TSRNAME_FIELD		 = "TSRName";
		public const String HOUSEID_FIELD		 = "HouseID";
		public const string HOUSENAME_FIELD        = "housename";
		public const String DEPARTMENTID_FIELD   = "DepartmentID";
		public const string DEPARTMENTNAME_FIELD   = "departmentname";
		public const String ACCOUNTDEP_FIELD     = "AccountDep";

		public const String TSDATE_FIELD         = "TSDate";
		public const String ACCOUNTDATE_FIELD    = "AccountDate";
		public const String CHECKDATE_FIELD		 = "CheckDate";
		public const String CHECKER_FIELD		 = "Checker";
		public const String CHECKERNAME_FIELD		 = "Checkername";
		public const String SUPERVISO_FIELD		 = "Superviso";
		public const String SUPERVISONAME_FIELD		 = "Supervisoname";
		
		public const String FILLER_FIELD		 = "Filler";
		public const String FILLERNAME_FIELD		 = "Fillername";
		public const String FILLDATE_FIELD		 = "FillDate";
		public const String STATUS_FIELD	     = "Status";
		public const String DESCRIPTION_FIELD    = "Description";

		//Added by YiChangXin 2005-8-23
		public const String TAKESTOCKID_FIELD    = "TakeStockID";
		public const string MATERIALNAME_FIELD			= "materialname";
		public const string MODEL_FIELD					= "model";

		public enum TakeStockRecordStatus
		{
			未确认=0,
			
			已驳回=1,
			
			已生效=2,
		
			已确认=3
		}


		public TakeStockData() 
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			DataTable  tables = new DataTable(TAKESTOCK_TABLE);
			DataColumnCollection  columns  =tables.Columns;

			columns.Add(TSRID_FIELD ,   typeof(System.String));
			columns.Add(TSRNAME_FIELD ,  typeof(System.String));
			columns.Add(HOUSEID_FIELD ,  typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD ,typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD , typeof(System.String));

			columns.Add(TSDATE_FIELD  ,  typeof(System.DateTime));
			columns.Add(ACCOUNTDATE_FIELD  ,typeof(System.DateTime));
			columns.Add(CHECKDATE_FIELD  ,typeof(System.DateTime));
			columns.Add(CHECKER_FIELD   ,typeof(System.String));
			columns.Add(SUPERVISO_FIELD  ,typeof(System.String));

			columns.Add(FILLER_FIELD  , typeof(System.String));
			columns.Add(FILLDATE_FIELD  ,typeof(System.DateTime));
			columns.Add(STATUS_FIELD  , typeof(System.String));
			columns.Add(DESCRIPTION_FIELD ,typeof(System.String));
			columns.Add(HOUSENAME_FIELD  , typeof(System.String));
			columns.Add(DEPARTMENTNAME_FIELD ,typeof(System.String));
			columns.Add(CHECKERNAME_FIELD ,typeof(System.String));
			columns.Add(SUPERVISONAME_FIELD ,typeof(System.String));
			columns.Add(FILLERNAME_FIELD ,typeof(System.String));
			columns.Add(TAKESTOCKID_FIELD ,typeof(System.String));

			this.Tables.Add(tables);
			

		}
	}
}
