using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// ChestData 的摘要说明。
	/// </summary>
	public class ChestData:DataSet
	{
		public const String CHEST_TABLE   = "tbl_chest";

	
		public const String CHESTID_FIELD      = "chestid";
		public const String DEPARTMENTID_FIELD = "departmentid";
		public const String MATERIALID_FIELD   = "materialid";
		public const String BATCHNO_FIELD      = "batchno";
		public const String HOUSEID_FIELD      = "houseid";
		public const String HOUSEDEP_FIELD     = "housedep";
		public const String WEIGHT_FIELD       = "weight";
		public const String PIECES_FIELD       = "pieces";
		public const String UNIT_FIELD         = "unit";
		public const String CHANGERATE_FIELD   = "changerate";
		public const String DESCRIPTION_FIELD  = "description";



		public ChestData()
		{
			BuildTables();
		}
		private ChestData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(CHEST_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(CHESTID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(BATCHNO_FIELD,typeof(System.String));
			columns.Add(HOUSEID_FIELD,typeof(System.String));
			columns.Add(HOUSEDEP_FIELD,typeof(System.String));
			columns.Add(WEIGHT_FIELD,typeof(System.Decimal));
			columns.Add(PIECES_FIELD,typeof(System.UInt16));
			columns.Add(UNIT_FIELD,typeof(System.String));
			columns.Add(CHANGERATE_FIELD,typeof(System.Single));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}

	}
}
