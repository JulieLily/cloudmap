using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.StoreManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// Stock3LevelsAccountData 的摘要说明。
	/// </summary>
	public class Stock3LevelsAccountData:DataSet
	{
		public const String STOCK3LEVELSACCOUNT_TABLE = "tbl_stock3levelsaccount";

		public const String HOUSEID_FIELD               = "houseid";
		public const String DEPARTMENTID_FIELD          = "departmentid";
		public const String MATERIALID_FIELD            = "materialid";
		public const String YEAR_FIELD                  = "year";
		public const String MONTH_FIELD                 = "month";
		public const String PUB_ATTRIBUTE_FIELD         = "pub_attribute";

		public const String LASTBUSINESSMARGIN_FIELD    = "lastbusinessmargin";
		public const String LASTACCOUNTMARGIN_FIELD     = "lastaccountmargin";
		public const String LASTDIFFENCEINVENTORY_FIELD = "lastdiffenceinventory";
		public const String LASTACCOUNTBALANCE_FIELD    = "lastaccountbalance";

		public const String THISBUSINESSIN_FIELD        = "thisbusinessin";
		public const String THISBUSINESSOUT_FIELD       = "thisbusinessout";
		public const String THISACCOUNTIN_FIELD         = "thisaccountin";
		public const String THISACCOUNTOUT_FIELD        = "thisaccountout";
		public const String THISINMONEY_FIELD           = "thisinmoney";
		public const String THISOUTMONEY_FIELD          = "thisoutmoney";
		public const String THISINDIFFENCE_FIELD        = "thisindiffence";
		public const String THISDIFFENCERATE_FIELD      = "thisdiffencerate";
		public const String AVERAGEPRICE_FIELD          = "averageprice";
		public const String ACCOUNTDEP_FIELD            = "accountdep";
		public const String STATUS_FIELD                = "status";

		public Stock3LevelsAccountData()
		{
			BuildTables();
		}
		private Stock3LevelsAccountData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(STOCK3LEVELSACCOUNT_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(HOUSEID_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(YEAR_FIELD,typeof(System.Int16));
			columns.Add(MONTH_FIELD,typeof(System.Int16));
			columns.Add(PUB_ATTRIBUTE_FIELD,typeof(System.String));

			columns.Add(LASTBUSINESSMARGIN_FIELD,typeof(System.Single));
			columns.Add(LASTACCOUNTMARGIN_FIELD,typeof(System.Single));
			columns.Add(LASTDIFFENCEINVENTORY_FIELD,typeof(System.Single));
			columns.Add(LASTACCOUNTBALANCE_FIELD,typeof(System.Single));

			columns.Add(THISBUSINESSIN_FIELD,typeof(System.Single));
			columns.Add(THISBUSINESSOUT_FIELD,typeof(System.Single));
			columns.Add(THISACCOUNTIN_FIELD,typeof(System.Single));
			columns.Add(THISACCOUNTOUT_FIELD,typeof(System.Single));
			columns.Add(THISINMONEY_FIELD,typeof(System.Single));
			columns.Add(THISOUTMONEY_FIELD,typeof(System.Single));
			columns.Add(THISINDIFFENCE_FIELD,typeof(System.Single));
			columns.Add(THISDIFFENCERATE_FIELD,typeof(System.Single));

			columns.Add(AVERAGEPRICE_FIELD,typeof(System.Single));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(STATUS_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
