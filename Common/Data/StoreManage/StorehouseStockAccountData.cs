using System;
using System.Data;
using System.Runtime.Serialization;


namespace TOPSUN.ERP.Common.Data.StoreManage
{
	/// <summary>
	/// StorehouseStockAccountData 的摘要说明。
	/// </summary>
	[SerializableAttribute]
	[System.ComponentModel.DesignerCategory("Code")]

	public class StorehouseStockAccountData :DataSet
	{
		public const String  STOREHOUSESTOCKACCOUNT_TABLE		= "TBL_StorehouseStockAccount";
		
		public const String  HOUSEID_FIELD						= "HouseID";
		public const String  MATERIALID_FIELD					= "MaterialID";
		public const String  DEPARTMENTID_FIELD					= "DepartmentID";
		public const String  PUB_ATTRIBUTE_FIELD			    = "PUB_Attribute";
		public const String  ACCOUNTDEP_FIELD					= "AccountDep";

		public const String  YEAR_FIELD							= "Year";
		public const String  MONTH_FIELD						= "Month";
		public const String  LASTMARGIN_FIELD					= "LastMargin";
		public const String  THISIN_FIELD						= "ThisIn";
		public const String  THISOUT_FIELD						= "ThisOut";

		public const String  UNIT_FIELD							= "Unit";
		public const String  CHANGERATE_FIELD					= "ChangeRate";
		public const String  STATUS_FIELD						= "Status";

		public StorehouseStockAccountData()
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			DataTable   tables	=	new DataTable(STOREHOUSESTOCKACCOUNT_TABLE);
			DataColumnCollection columns=tables.Columns;

			columns.Add(HOUSEID_FIELD ,typeof(System.String));
			columns.Add(MATERIALID_FIELD ,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD ,typeof(System.String));
			columns.Add(PUB_ATTRIBUTE_FIELD, typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD ,typeof(System.String));

			columns.Add(YEAR_FIELD, typeof(System.Int16));
			columns.Add(MONTH_FIELD, typeof(System.Int16));
			columns.Add(LASTMARGIN_FIELD, typeof(System.Decimal));
			columns.Add(THISIN_FIELD, typeof(System.Decimal));
			columns.Add(THISOUT_FIELD ,typeof(System.Decimal));

			columns.Add(UNIT_FIELD ,typeof(System.String));
			columns.Add(CHANGERATE_FIELD ,typeof(System.String));
			columns.Add(STATUS_FIELD ,typeof(System.String));
			
			this.Tables.Add(tables);
			 
		}
	}
}
