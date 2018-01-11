using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	/// <summary>
	/// CraftBrotherInfoData 的摘要说明。
	/// </summary>
	public class CraftBrotherInfoData:DataSet
	{
		public const String CRAFTBROTHERINFO_TABLE = "tbl_craftbrotherinfo";
		
		public const String DEPARTMENTID_FIELD        = "departmentid";
		public const String CRAFTBROTHERID_FIELD      = "craftbrotherid";
		public const String CRAFTBROTHERNAME_FIELD    = "craftbrothername";
		public const String LEGALREPRESENTATIVE_FIELD = "legalrepresentative";
		public const String AREAID_FIELD              = "areaid";
		public const String PHONE_FIELD               = "phone";
		public const String ADDRESS_FIELD             = "address";
		public const String SALEPRINCIPAL_FIELD       = "saleprincipal";
		public const String ENJOYPOLICY_FIELD         = "enjoypolicy";
		public const String PRODUCTIONCAPACITY_FIELD  = "productioncapacity";
		public const String SALEINCOME_FIELD          = "saleincome";
		public const String SALEPROFIT_FIELD          = "saleprofit";
		public const String DRAWDEPARTMENT_FIELD      = "drawdepartment";
		public const String DRAWPERSON_FIELD          = "drawperson";
		public const String DRAWDATE_FIELD            = "drawdate";
		public const String DESCRIPTION_FIELD         = "description";


		public CraftBrotherInfoData()
		{
			BuildTables();
		}
		private CraftBrotherInfoData(SerializationInfo info,StreamingContext context):base(info,context)
		{

		}
		private void BuildTables()
		{
			DataTable table = new DataTable(CRAFTBROTHERINFO_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(CRAFTBROTHERID_FIELD,typeof(System.String));
			columns.Add(CRAFTBROTHERNAME_FIELD,typeof(System.String));
			columns.Add(LEGALREPRESENTATIVE_FIELD,typeof(System.String));
			columns.Add(AREAID_FIELD,typeof(System.String));
			columns.Add(PHONE_FIELD,typeof(System.String));
			columns.Add(ADDRESS_FIELD,typeof(System.String));
			columns.Add(SALEPRINCIPAL_FIELD,typeof(System.String));
			columns.Add(ENJOYPOLICY_FIELD,typeof(System.String));
			columns.Add(PRODUCTIONCAPACITY_FIELD,typeof(System.String));
			columns.Add(SALEINCOME_FIELD,typeof(System.String));
			columns.Add(SALEPROFIT_FIELD,typeof(System.String));
			columns.Add(DRAWDEPARTMENT_FIELD,typeof(System.String));
			columns.Add(DRAWPERSON_FIELD,typeof(System.String));
			columns.Add(DRAWDATE_FIELD,typeof(System.DateTime));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));

			this.Tables.Add(table);
		}
	}
}
