using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	/// <summary>
	/// TakeStockDetailData 的摘要说明。
	/// </summary>
	[SerializableAttribute]
	[System.ComponentModel.DesignerCategory("Code")]

	public class TakeStockDetailData :DataSet
	{
		public const String  TAKESTOCKDETAIL_TABLE		=  "TBL_TakeStockDetail";

		public const String  PLACEID_FIELD				= "PlaceID";
		public const String  TSRID_FIELD				= "TSRID";
		public const String  MATERIALID_FIELD			= "MaterialID";
		
		public const string  MODEL_FIELD					= "model";

		public const String  INTIME_FIELD				= "InTime";
		public const String  PUB_ATTRIBUTE_FIELD		= "PUB_Attribute";

		public const String  BATCHNO_FIELD				= "BatchNO";
		public const String  STORAGEAMOUNT_FIELD		= "StorageAmount";
		public const String  REALAMOUNT_FIELD			= "RealAmount";
		public const String  UNIT_FIELD					= "Unit";
		public const String  CHANGERATE_FIELD			= "ChangeRate";

		public const String  PRICE_FIELD				= "Price";
		public const String  ISDECLARCHECK_FIELD		= "IsDeclareCheck";
		public const String  HANDWORKREMARK_FIELD		= "HandworkRemark";

		//Added by YiChangXin 2005-8-23
		public const string PORLAMOUNT_FIELD			= "porlamount";//ycx 所加
		public const string PORLSUM_FIELD					= "porlsum";//ycx 所加
		public const string  MATERIALNAME_FIELD			= "materialname";//ycx 所加


		public TakeStockDetailData()
		{
			BuildDataTables();
		}
		private void BuildDataTables()
		{
			DataTable   tables	=	new DataTable(TAKESTOCKDETAIL_TABLE);
			DataColumnCollection columns=tables.Columns;

			columns.Add(PLACEID_FIELD ,typeof(System.String));
			columns.Add(TSRID_FIELD ,typeof(System.String));
			columns.Add(MATERIALID_FIELD ,typeof(System.String));
			columns.Add(INTIME_FIELD, typeof(System.DateTime));
			columns.Add(PUB_ATTRIBUTE_FIELD ,typeof(System.String));

			columns.Add(BATCHNO_FIELD, typeof(System.String));
			columns.Add(STORAGEAMOUNT_FIELD, typeof(System.Decimal));
			columns.Add(REALAMOUNT_FIELD, typeof(System.Decimal));
			columns.Add(UNIT_FIELD, typeof(System.String));
			columns.Add(CHANGERATE_FIELD ,typeof(System.Decimal));

			columns.Add(PRICE_FIELD ,typeof(System.Decimal));
			columns.Add(ISDECLARCHECK_FIELD ,typeof(System.String));
			columns.Add(HANDWORKREMARK_FIELD ,typeof(System.String));

			columns.Add(MATERIALNAME_FIELD, typeof(System.String));
			columns.Add(MODEL_FIELD, typeof(System.String));
			columns.Add(PORLAMOUNT_FIELD, typeof(System.String));
			columns.Add(PORLSUM_FIELD ,typeof(System.String));
			
			
			this.Tables.Add(tables);
			 
		}
	}
}
