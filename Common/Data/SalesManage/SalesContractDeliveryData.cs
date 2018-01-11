using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	/// <summary>
	/// SalesContractDeliveryData 的摘要说明。
	/// </summary>
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute]
	public class SalesContractDeliveryData : DataSet
	{
		public const string SALESCONTRACTDELIVERY_TABLE		= "TBL_SalesContractDelivery";

		public const string DELIVERDATE_FIELD				= "DeliveryDate";
		public const string MATERIALID_FIELD				= "MaterialID";
		public const string CONTRACTID_FIELD				= "ContractID";
		public const string AMOUNT_FIELD					= "Amount";

		private SalesContractDeliveryData(SerializationInfo info, StreamingContext context) : base(info, context) 
		{		
		}

		public SalesContractDeliveryData()
		{ 
			CreateTable();
		}

		private void CreateTable()
		{
			DataTable tables = new DataTable(SALESCONTRACTDELIVERY_TABLE);
			DataColumnCollection columns = tables.Columns;

			columns.Add(DELIVERDATE_FIELD,typeof(System.DateTime));
			columns.Add(MATERIALID_FIELD,typeof(System.String));
			columns.Add(CONTRACTID_FIELD,typeof(System.String));
			columns.Add(AMOUNT_FIELD,typeof(System.Decimal));

			this.Tables.Add(tables);
		}
	}
}
