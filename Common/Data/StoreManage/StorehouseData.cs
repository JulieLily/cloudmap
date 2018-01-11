using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// StorehouseData 的摘要说明。
	/// </summary>
	public class StorehouseData:DataSet
	{
		public const String STOREHOUSE_TABLE   = "TBL_Storehouse";

		public const String HOUSEID_FIELD      = "houseid";
		public const String DEPARTMENTID_FIELD = "departmentid";
		public const String DEPARTMENTNAME_FIELD = "departmentname";
		public const String NAME_FIELD         = "name";
		public const String TYPE_FIELD         = "PUB_StorehouseType";
		public const String ADDRESS_FIELD      = "address";
		public const String ACCOUNTDEP_FIELD   = "accountdep";
		public const String DESCRIPTION_FIELD  = "description";
		public const String ENABLE_FIELD       = "enable";
		public const String CAPACITY_FIELD     = "capacity";
		public const String UNIT_FIELD         = "unit";

		public const string SEQUENCENAME	= "StorehouseID";


		public StorehouseData()
		{
			BuildTables();
		}
		private StorehouseData(SerializationInfo info,StreamingContext context):base(info,context)
		{
		}
		private void BuildTables()
		{
			DataTable table = new DataTable(STOREHOUSE_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(HOUSEID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(NAME_FIELD,typeof(System.String));
			columns.Add(TYPE_FIELD,typeof(System.String));
			columns.Add(ADDRESS_FIELD,typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			columns.Add(ENABLE_FIELD,typeof(System.String));
			columns.Add(CAPACITY_FIELD,typeof(System.Single));
			columns.Add(UNIT_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
