using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	
	public class OutStorePlaceData:DataSet
	{
		public const string OUTSTOREPLACE_TABLE		="tbl_outstoreplace";

		public const string MATERIALID_FIELD            ="materialid";    
		public const string BATCHNO_FIELD			    ="batchNO";
		public const string PUB_ATTTRIBUTE_FIELD	="pub_Attribute";
		public const string OSRID_FIELD					="osrid";
		public const string PLACEID_FIELD               ="placeid";
    
		public const string CHESTAMOUNT_FIELD			="chestamount";
		public const string REALAMOUNT_FIELD		    ="realamount";
		public const string PIECES_FIELD					="pieces";
//		public const string OUTTIME_FIELD                 ="outtime";
		public const string DESCRIPTION_FIELD			="description";

		public OutStorePlaceData()
		{
			
			BuildTables();
		}
		private void BuildTables()
		{
			DataTable table = new DataTable(OUTSTOREPLACE_TABLE);
			DataColumnCollection columns = table.Columns;
			
			columns.Add(MATERIALID_FIELD, typeof(System.String));
			columns.Add(BATCHNO_FIELD,typeof(System.String));
			columns.Add(PUB_ATTTRIBUTE_FIELD, typeof(System.String));
			columns.Add(OSRID_FIELD, typeof(System.String));
			columns.Add(PLACEID_FIELD, typeof(System.String));

			columns.Add(CHESTAMOUNT_FIELD, typeof(System.Int16));
			columns.Add(REALAMOUNT_FIELD, typeof(System.Decimal));
			columns.Add(PIECES_FIELD, typeof(System.Int16));
			columns.Add(DESCRIPTION_FIELD, typeof(System.String));
			this.Tables.Add (table);



		}
	}
}
