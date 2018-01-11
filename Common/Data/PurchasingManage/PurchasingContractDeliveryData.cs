using System;
using System.Data;

namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	/// <summary>
	/// PurchasingContractDeliveryData 的摘要说明。
	/// </summary>
	public class PurchasingContractDeliveryData :DataSet
	{

		public const String  PURCHASINGCONTRACTDELIVERY_TABLE			= "TBL_PurchasingContractDelivery";

		public const String  CONTRACTID_FIELD							= "ContractID";
		public const String  MATERIALID_FIELD							= "MaterialID";
		public const String  DELIVERYDATE_FIELD							= "DeliveryDate";
		public const String  AMOUNT_FIELD								= "Amount";

		public PurchasingContractDeliveryData()
		{
			CreateTable();
		}

		private void CreateTable()
		{
			DataTable tables   =  new DataTable(PURCHASINGCONTRACTDELIVERY_TABLE);
			DataColumnCollection  columns =tables.Columns;

			columns.Add(CONTRACTID_FIELD  ,typeof (System.String));
			columns.Add(MATERIALID_FIELD  ,typeof (System.String));
			columns.Add(DELIVERYDATE_FIELD  ,typeof (System.DateTime));
			columns.Add(AMOUNT_FIELD  ,typeof (System.Decimal));

			this.Tables.Add(tables);

		
		}
	}
}
