using System;
using System.Runtime.Serialization;
using System.Data;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]
	
	public class RequisitionMoneyData  :DataSet
	{
		public const string REQUISITIONMONEY_TABLE  ="tbl_requisitionmoney";

		public const string RMRID_FIELD             ="rmrid";
		public const string RMRNAME_FIELD    ="rmrname";
		public const string DEPARTMENTID_FIELD      ="departmentid";
		public const string BEGINDATE_FIELD         ="begindate";
		public const string ENDDATE_FIELD			="enddate";
		public const string SUM_FIELD				="sum";
		public const string REQUISITIONDATE_FIELD	="requisitiondate";
		public const string REQUISITIONPERSON_FIELD ="requisitionperson";
		public const string STATUS_FIELD			="status";
		public const string ACCOUNTDEP_FIELD		="accountdep";
		public const string DESCRIPTION_FIELD		="description";

		//Added by YiChangxin 2005-8-30
		public const string REQUISITIONPERSONNAME_FIELD				="requisitionpersonname";
		public const string RMR_FIELD								="rmr";
		public const string DEPNAME_FIELD							="depname";

		public enum RequisitionMoneyRecordStatus
		{
			未确认=0,
			
			已驳回=1,
			
			已生效=2,
		
			已确认=3
		}

		public RequisitionMoneyData()
		{
			BuildTable();
		}
		private void BuildTable()
		{
			DataTable table = new DataTable(RequisitionMoneyData.REQUISITIONMONEY_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(RMRNAME_FIELD,typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD,typeof(System.String));
			columns.Add(BEGINDATE_FIELD,typeof(System.DateTime));
			columns.Add(ENDDATE_FIELD,typeof(System.DateTime));
			columns.Add(SUM_FIELD,typeof(System.Decimal));
			columns.Add(REQUISITIONDATE_FIELD,typeof(System.DateTime));
			columns.Add(REQUISITIONPERSON_FIELD,typeof(System.String));

			columns.Add(STATUS_FIELD,typeof(System.String));
			columns.Add(ACCOUNTDEP_FIELD,typeof(System.String));
			columns.Add(DESCRIPTION_FIELD,typeof(System.String));
			columns.Add (RMRID_FIELD,typeof(System.String));

			//Added by YiChangxin 2005-8-30
			columns.Add (REQUISITIONPERSONNAME_FIELD,typeof(System.String));
			columns.Add (RMR_FIELD,typeof(System.String));
			columns.Add (DEPNAME_FIELD,typeof(System.String));

			this.Tables.Add(table);
			

		}
	}
}
