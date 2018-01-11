using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	/// <summary>
	/// StoreplaceStockAccountData 的摘要说明。
	/// </summary>
	[SerializableAttribute]
	[System.ComponentModel.DesignerCategory("Code")]

	public class StoreplaceStockAccountData:DataSet
	{
		public const String  STOREPLACESTOCKACCOUNT_TABLE		= "TBL_StoreplaceStockAccount";
		
		public const String  PLACEID_FIELD						= "PlaceID";
		public const String  HOUSEID_FIELD						= "HouseID";
		public const String  DEPARTMENTID_FIELD					= "DepartmentID";
		public const String  MATERIALID_FIELD					= "MaterialID";
		public const String  PUB_ATTRIBUTE_FIELD				= "PUB_Attribute";

		public const String  INTIME_FIELD						= "InTime";
		public const String  BATCHNO_FIELD						= "BatchNO";
		public const String  ACCOUNTSTOCK_FIELD					= "AccountStock";
		public const String  REALSTOCK_FIELD					= "RealStock";
		public const String  UNIT_FIELD							= "Unit";

		public const String  CHANGERATE_FIELD					= "ChangeRate";
		public const String  STOCKPRICE_FIELD					= "StockPrice";
		public const String  ACCOUNTDEP_FIELD					= "AccountDep";
		public const String  STORAGEAMOUNT_FIELD				= "storageamount";//ycx所加
		public const String  TIMES_FIELD						= "times";//ycx所加

		public StoreplaceStockAccountData()
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			DataTable   tables	=	new DataTable(STOREPLACESTOCKACCOUNT_TABLE);
			DataColumnCollection columns=tables.Columns;

			columns.Add(PLACEID_FIELD ,typeof(System.String));
			columns.Add(HOUSEID_FIELD ,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD ,typeof(System.String));
			columns.Add(MATERIALID_FIELD, typeof(System.String));
			columns.Add(PUB_ATTRIBUTE_FIELD ,typeof(System.String));

			columns.Add(INTIME_FIELD, typeof(System.DateTime));
			columns.Add(BATCHNO_FIELD, typeof(System.String));
			columns.Add(ACCOUNTSTOCK_FIELD, typeof(System.Decimal));
			columns.Add(REALSTOCK_FIELD, typeof(System.Decimal));
			columns.Add(UNIT_FIELD ,typeof(System.String));

			columns.Add(CHANGERATE_FIELD ,typeof(System.String));
			columns.Add(STOCKPRICE_FIELD ,typeof(System.Decimal));
			columns.Add(ACCOUNTDEP_FIELD ,typeof(System.String));
			columns.Add(STORAGEAMOUNT_FIELD ,typeof(System.Decimal));
			columns.Add(TIMES_FIELD ,typeof(System.DateTime));
			
			this.Tables.Add(tables);
			 
		}
	}
}
