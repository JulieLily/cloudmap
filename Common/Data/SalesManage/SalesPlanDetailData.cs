using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	/// <summary>
	/// SalesPlanDetailData 的摘要说明。
	/// </summary>
	public class SalesPlanDetailData :DataSet
	{

		public const String  SALESPLANDETAIL_TABLE			= "TBL_SalesPlanDetail";

		public const String CUSTOMER_FIELD					= "Customer";
		public const string CUSTOMERNAME_FIELD				= "customername";
		public const String MATERIALID_FIELD				= "MaterialID";
		public const string MATERIALNAME_FIELD				= "materialname";
		public const string MODEL_FIELD						= "model";
		public const String SALESPLANID_FIELD				= "SalesPlanID";
		public const String DEPARTMENTID_FIELD				= "DepartmentID";
		public const string DEPARTMENTNAME_FIELD			= "Departmentname";
		public const String SALESTYPE_FIELD					= "SalesType";

		public const String SALESAMOUNT_FIELD				= "SaleAmount";
		public const String UNIT_FIELD						= "Unit";
		public const String CHANGERATE_FIELD				= "ChangeRate";
		public const String SALESPRICE_FIELD				= "SalePrice";
		public const String SALESSUM_FIELD					= "SaleSum";

		public const String TIMELIMIT_FIELD					= "TimeLimit";
		public const String MODE_FIELD						= "Mode";
		public const String STATIONOFDISPATCH_FIELD			= "StationOfDispatch";
		public const String CURRENTSTOCK_FIELD				= "CurrentStock";
		public const String DELIVERYTIME_FIELD				= "DeliveryTime";

		public const String PRECARRIAGE_FIELD				= "PreCarriage";
		public const String DESCRIPTION_FIELD				= "Description";

		public SalesPlanDetailData()
		{
			CreateTable();
		}
		private void CreateTable()
		{
			DataTable  tables = new DataTable(SALESPLANDETAIL_TABLE);
			DataColumnCollection  columns = tables.Columns;

			columns.Add(CUSTOMER_FIELD , typeof(System.String));
			columns.Add(CUSTOMERNAME_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD , typeof(System.String));
			columns.Add(MATERIALNAME_FIELD,typeof(System.String));
			columns.Add(MODEL_FIELD,typeof(System.String));
			columns.Add(SALESPLANID_FIELD , typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD , typeof(System.String));
			columns.Add(DEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(SALESTYPE_FIELD , typeof(System.String));

			columns.Add(SALESAMOUNT_FIELD , typeof(System.Decimal));
			columns.Add(UNIT_FIELD , typeof(System.String));
			columns.Add(CHANGERATE_FIELD , typeof(System.String));
			columns.Add(SALESPRICE_FIELD , typeof(System.Decimal));
			columns.Add(SALESSUM_FIELD , typeof(System.Decimal));

			columns.Add(TIMELIMIT_FIELD , typeof(System.String));
			columns.Add(MODE_FIELD , typeof(System.String));
			columns.Add(STATIONOFDISPATCH_FIELD , typeof(System.String));
			columns.Add(CURRENTSTOCK_FIELD , typeof(System.Decimal));
			columns.Add(DELIVERYTIME_FIELD , typeof(System.DateTime));

			columns.Add(PRECARRIAGE_FIELD , typeof(System.Int16));
			columns.Add(DESCRIPTION_FIELD , typeof(System.String));

			this.Tables.Add(tables);


		}
	}
}
