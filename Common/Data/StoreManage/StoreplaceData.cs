using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// StorePlaceData 的摘要说明。
	/// </summary>
	public class StoreplaceData:DataSet
	{
		public const String STOREPLACE_TABLE		= "tbl_storeplace";

		public const String DEPARTMENTID_FIELD		= "departmentid";
		public const String DEPARTMENTNAME_FIELD	= "departmentname";
		public const String HOUSEID_FIELD			= "houseid";
		public const String HOUSENAME_FIELD			= "housename";
		public const String PLACEID_FIELD			= "placeid";
		public const String PLACE_FIELD				= "place";
		public const String DESCRIPTION_FIELD		= "description";
		public const String ENABLE_FIELD			= "enable";
		public const String CAPACITY_FIELD			= "capacity";
		public const String UNIT_FIELD				= "unit";


		public StoreplaceData()
		{
			BuildTables();
		}
		private StoreplaceData(SerializationInfo info,StreamingContext context):base(info,context)
		{
		}
		private void BuildTables()
		{
			DataTable table = new DataTable(STOREPLACE_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(HOUSEID_FIELD,typeof(System.String));
			columns.Add(HOUSENAME_FIELD,typeof(System.String));
			columns.Add(PLACEID_FIELD,typeof(System.String));
			columns.Add(PLACE_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			columns.Add(ENABLE_FIELD,typeof(System.String));
			columns.Add(CAPACITY_FIELD,typeof(System.Single));
			columns.Add(UNIT_FIELD,typeof(System.String));

			this.Tables.Add(table);


		}
	}
}
