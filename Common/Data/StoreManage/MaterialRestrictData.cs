using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// MaterialRestrictData 的摘要说明。
	/// </summary>
	public class MaterialRestrictData:DataSet
	{
		public const String MATERIALRESTRICT_TABLE  = "tbl_materialrestrict";
		public const String ID_FIELD           = "id";
		public const String MATERIALID_FIELD   = "materialid";
		public const String DESCRIPTION_FIELD  = "description";
		public const String RESTRICTTYPE_FIELD = "restricttype";




		public MaterialRestrictData()
		{
			BuildTables();
		}
		private MaterialRestrictData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(MATERIALRESTRICT_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(ID_FIELD,typeof(System.UInt16));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			columns.Add(RESTRICTTYPE_FIELD,typeof(System.String));

			this.Tables.Add(table);

		}
	}
}
