using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	/// <summary>
	/// RequisitionMoneyDetailData ��ժҪ˵����
	/// </summary>
	public class RequisitionMoneyDetailData :DataSet
	{
		public const String REQUESISITIONMONEYDETAIL_TABLE			= "TBL_RequisitionMoneyDetail";

		public const String RMRID_FIELD								= "RMRID";
		public const String DEPARTMENTID_FIELD						= "DepartmentID";
		public const String CORCOMPANYID_FIELD						= "CorCompanyID";
		public const String CONTRACTID_FIELD						= "ContractID";
		public const String MATERIALID_FIELD						= "MaterialID";

		public const String SUM_FIELD								= "Sum";
		public const String PAIDSUM_FIELD							= "PaidSum";
		public const String CURRENTPAYSUM_FIELD						= "CurrentPaySum";
		public const String DESCRIPTION_FIELD						= "Description";

		//Added by YiChangxin 2005-8-30
		public const String MATERIALNAME_FIELD						= "materialname";  //��������
		public const String CONDTRACTNAME_FIRLD						= "contractname";  //��������
		public const String CORCOMPANYNAME_FIELD					= "corcompanyname";  //��������
		public const String MODEL_FIELD						        = "model";           //��������

		public RequisitionMoneyDetailData()
		{
			CreateTable();
		}

		private void CreateTable()
		{
			DataTable tables  =  new DataTable(REQUESISITIONMONEYDETAIL_TABLE);
			DataColumnCollection  columns = tables.Columns;

			columns.Add(RMRID_FIELD , typeof (System.String));
			columns.Add(DEPARTMENTID_FIELD , typeof (System.String));
			columns.Add(CORCOMPANYID_FIELD , typeof (System.String));
			columns.Add(CONTRACTID_FIELD , typeof (System.String));
			columns.Add(MATERIALID_FIELD , typeof (System.String));

			columns.Add(SUM_FIELD , typeof (System.Decimal));
			columns.Add(PAIDSUM_FIELD , typeof (System.Decimal));
			columns.Add(CURRENTPAYSUM_FIELD , typeof (System.Decimal));
			columns.Add(DESCRIPTION_FIELD , typeof (System.String));

			//Added by YiChangxin 2005-8-30
			columns.Add(MATERIALNAME_FIELD , typeof (System.String));	//��������
			columns.Add(CONDTRACTNAME_FIRLD , typeof (System.String)); //��������
			columns.Add(CORCOMPANYNAME_FIELD , typeof (System.String)); //��������
			columns.Add(MODEL_FIELD , typeof (System.String));			//��������

			this.Tables.Add(tables);
		}
	}
}
