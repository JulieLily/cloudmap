using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	public class InStorePlaceData:DataSet
	{
		public const string INSTOREPLACE_TABLE = "tbl_instoreplace";

		public const string MATERIALID_FIELD            ="materialid";   
		public const string BATCHNO_FIELD			    ="batchNO";
		public const string PUB_ATTTRIBUTE_FIELD	="pub_Attribute";
		public const string ISRID_FIELD					="isrid";
		public const string PLACEID_FIELD               ="placeid";    
		public const string CHESTAMOUNT_FIELD			="chestamount";
		public const string REALAMOUNT_FIELD		    ="realamount";
		public const string PIECES_FIELD					="pieces";
		public const string DESCRIPTION_FIELD			="description";
		public InStorePlaceData()
		{
			BuildTables();
		}
		private void BuildTables()
		{
			DataTable table =new DataTable(INSTOREPLACE_TABLE);
			DataColumnCollection columns=table.Columns;

			columns.Add(MATERIALID_FIELD, typeof(System.String));
			columns.Add(BATCHNO_FIELD,typeof(System.String));
			columns.Add(PUB_ATTTRIBUTE_FIELD, typeof(System.String));
			columns.Add(ISRID_FIELD, typeof(System.String));
			columns.Add(PLACEID_FIELD, typeof(System.String));

			columns.Add(CHESTAMOUNT_FIELD, typeof(System.Int16));
			columns.Add(REALAMOUNT_FIELD, typeof(System.Decimal));
			columns.Add(PIECES_FIELD, typeof(System.Int16));		
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			
			this.Tables.Add (table);
		}
	}
}
