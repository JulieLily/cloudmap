using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]

	public class CorCompanyGradeData:DataSet
	{
		public const string CORCOMPANYGRADE_TABLE			= "tbl_corcompanygrade";

		public const string CORCOMPANYID_FIELD			    ="corcompanyid";
		public const string DEPARTMENTID_FIELD				="departmentid";
		public const string TYPE_FIELD						="type";
		public const string MATERIALID_FIELD				="materialid";
		public const string PRODUCTID_FIELD					="productid";

		public const string MANUFACTURER_FIELD				= "manufacturer";
		public const string BRAND_FIELD						= "brand";
		public const string SUPPLYCYCLE_FIELD				="supplycycle";
		public const string PROVIDEABILITY_FIELD			="provideAbility";
		public const string SUPPLYRANK_FIELD				="supplyrank";

		public const string PRICERANK_FIELD					="pricerank";
		public const string QUALITYRANK_FIELD				= "qualityrank";
		public const string PUB_CORRANK_FIELD				="pub_corrank";
		public const string DRAWDEPARTMENT_FIELD			="DRAWdepartment";
		public const string DRAWDATE_FIELD					="DRAWdate";

		
		public const string DRAWPERSON_FIELD				="DRAWperson";
		public const string APPLICATIONDATE_FIELD			="applicationdate";
		public const string DESCRIPTION_FIELD				="description";
		public const string STATUS_FIELD					="status";

		//Added by 魏套江 2005-8-10
		public const string CORCOMPANYNAME_FIELD   = "corcompanyname";
		public const string MANUFACTURERNAME_FIELD  = "Manufacturername";
		public const string MATERIALNAME_FIELD = "materialname";
		public const string DRAWDEPARTMENTNAME_FIELD = "drawdepartmentname";
		public const string DRAWPERSONNAME_FIELD = "drawpersonname";
		public const string MODEL_FIELD = "model";

		public enum RecordStatus
		{
			未确认 = 10,
			已确认 = 15,
			已驳回 = 30,
			已生效 = 40,			
		}

		
		public CorCompanyGradeData()
		{
			
			BuildTable();
		}
		private void BuildTable()
		{
			DataTable table = new DataTable(CorCompanyGradeData.CORCOMPANYGRADE_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(CORCOMPANYID_FIELD,typeof (System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(TYPE_FIELD,typeof (System.String));
			columns.Add(PRODUCTID_FIELD,typeof(System.String));
			columns.Add(MATERIALID_FIELD,typeof (System.String));

			columns.Add(MANUFACTURER_FIELD,typeof(System.String));
			columns.Add(BRAND_FIELD,typeof (System.String));
			columns.Add(SUPPLYCYCLE_FIELD,typeof(System.Int16));
			columns.Add(PRICERANK_FIELD,typeof (System.Int16));
			columns.Add(QUALITYRANK_FIELD,typeof(System.Int16));

			columns.Add(PUB_CORRANK_FIELD,typeof (System.String));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof (System.DateTime));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));

			columns.Add(DESCRIPTION_FIELD,typeof (System.String));
			columns.Add(PROVIDEABILITY_FIELD,typeof (System.String));
			columns.Add(SUPPLYRANK_FIELD,typeof(System.Int16));			
			columns.Add(APPLICATIONDATE_FIELD,typeof (System.DateTime));
			columns.Add(STATUS_FIELD,typeof(System.String));

			// Added by WeiTaojiang 2005-8-29
			columns.Add(CORCOMPANYNAME_FIELD,typeof(System.String));
			columns.Add(MANUFACTURERNAME_FIELD,typeof(System.String));
			columns.Add(MATERIALNAME_FIELD,typeof(System.String));
			columns.Add(DRAWDEPARTMENTNAME_FIELD,typeof(System.String));
			columns.Add(DRAWPERSONNAME_FIELD,typeof(System.String));
			columns.Add(MODEL_FIELD,typeof(System.String));

			this.Tables.Add(table);
				
		}
	}
}
