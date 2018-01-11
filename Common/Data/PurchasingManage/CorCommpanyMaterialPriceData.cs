using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	
	public class CorCommpanyMaterialPriceData:DataSet
	{
		public const string CORCOMPANYMATERIALPRICE_TABLE ="tbl_corcommpanymaterialprice";
 
		public const string CORCOMPANYID_FIELD			    ="corcompanyid";
		public const string DEPARTMENTID_FIELD				="departmentid";
		public const string TYPE_FIELD						="type";
		public const string QUOTEDATE_FIELD				    ="quotedate";
		public const string MATERIALID_FIELD				="materialid";

		public const string PRICES_FIELD					="prices";
		public const string TAXRATE_FIELD					="taxrate";
		public const string DRAWDEPARTMENT_FIELD			="DRAWdepartment";
		public const string DRAWDATE_FIELD					="DRAWdate";
		public const string DRAWPERSON_FIELD				="DRAWperson";

		public const string DESCRIPTION_FIELD				="description";
		public const string STATUS_FIELD					="status";

		//2005-8-12 Added by ÎºÌ×½­
		public const string DRAWDEPARTMENTNAME_FIELD ="drawdepartmentname";
		public const string DRAWPERSONNAME_FIELD ="drawpersonname";


		public CorCommpanyMaterialPriceData()
		{
		   BuildTable();
		}
		private  void BuildTable()
		{
			DataTable table = new DataTable(CORCOMPANYMATERIALPRICE_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(CORCOMPANYID_FIELD,typeof (System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(TYPE_FIELD,typeof (System.String));
			columns.Add(QUOTEDATE_FIELD,typeof(System.DateTime));
			columns.Add(MATERIALID_FIELD,typeof (System.String));

			columns.Add(PRICES_FIELD,typeof(System.String));
			columns.Add(TAXRATE_FIELD,typeof (System.String));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof (System.DateTime));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));

			columns.Add(DESCRIPTION_FIELD,typeof (System.String));
			columns.Add(STATUS_FIELD,typeof(System.String));

			//2005-8-12 Added by ÎºÌ×½­
			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));
			
			this.Tables.Add(table);
		}
	}
}
