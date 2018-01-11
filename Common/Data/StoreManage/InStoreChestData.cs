using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	public class InStoreChestData:DataSet
	{
		public const string INSTORECHEST_TABLE          ="tbl_instorechest";

		public const string MATERIALID_FIELD            ="materialid";   
		public const string BATCHNO_FIELD			    ="batchNO";
		public const string PUB_ATTTRIBUTE_FIELD	    ="pub_Attribute";
		public const string ISRID_FIELD					="isrid";
		public const string PLACEID_FIELD               ="placeid"; 
		public const string CHESTID_FIELD			    ="chestid";
		public const string UNIT_FIELD		            ="unit";
		public const string PIECES_FIELD				="pieces";
		public const string CHANGERATE_FIELD			="changerate";
		public const string WEIGHT_FIELD				="weight";
		public const string DESCRIPTION_FIELD			="description";
		public InStoreChestData()
		{
			BuildTables();
		}
		private void BuildTables()
		{
			DataTable table = new DataTable(INSTORECHEST_TABLE);
			DataColumnCollection columns=table.Columns;

			columns.Add(MATERIALID_FIELD, typeof(System.String));
			columns.Add(BATCHNO_FIELD,typeof(System.String));
			columns.Add(PUB_ATTTRIBUTE_FIELD, typeof(System.String));
			columns.Add(ISRID_FIELD, typeof(System.String));
			columns.Add(PLACEID_FIELD, typeof(System.String));

			columns.Add(CHESTID_FIELD, typeof(System.String));
			columns.Add(UNIT_FIELD, typeof(System.String));
			columns.Add(PIECES_FIELD, typeof(System.Int16));		
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			columns.Add(CHANGERATE_FIELD, typeof(System.String));
			columns.Add(WEIGHT_FIELD, typeof(System.Decimal));
			this.Tables.Add(table);
		}
	}
}
