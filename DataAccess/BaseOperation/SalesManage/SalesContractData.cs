using System;
using System.Data;
using System.Runtime.Serialization;

namespace TOPSUN.ERP.Common.Data.SalesManage
{
	[System.ComponentModel.DesignerCategory("code")]
	[SerializableAttribute]

	public class SalesContractData:DataSet
	{
		public const string SALESCONTRACT_TABLE			="tbl_salescontract";

		public const string CONTRACTID_FIELD			="ContractID";
		public const string CONTRACTNAME_FIELD			="ContractName";
		public const string CONTRACTNO_FIELD			="contractno";
		public const string PUB_CONTRACTTYPE_FIELD		="PUB_ContractType";
		public const string SALESTYPE_FIELD				="SalesType";

		public const string DEPARTMENTID_FIELD			="departmentid";
		public const string CUSTOMER_FIELD				="Customer";
		public const string MONEYTYPE_FIELD				="MoneyType";
		public const string ALLSUM_FIELD				="AllSum";
		public const string DISCOUNTSUM_FIELD			="discountsum";

		public const string WITHOUTTAXSUM_FIELD			="WithoutTaxSum";
		public const string TAXSUM_FIELD				="taxsum";
		public const string PUB_CLEARINGFORM_FIELD		="PUB_ClearingForm"; 
		public const string PUB_TRAFFICMODE_FIELD		="PUB_TrafficMode";
		public const string PUB_TAKEDELIVERYMODE_FIELD	="PUB_TakeDeliveryMode";

		public const string STATIONOFDELIVARY_FIELD		="StationOfDelivery";//
		public const string PLACEOFDELIVERY_FIELD		="PlaceOfDelivery";
		public const string CARRIAGEBEAR_FIELD			="CarriageBear";
		public const string SIGNADDRESS_FIELD			="SignAddress";
		public const string SIGNDATE_FIELD				="SignDate";

		public const string VALIDBEGINDATE_FIELD		="ValidBeginDate";
		public const string VALIDENDDATE_FIELD			="ValidEndDate";
		public const string NLEGAREPRESENTATIVE_FIELD	="NLegalRepresentative";
		public const string NPRINCIPAL_FIELD			="NPrincipal";
		public const string PLEGALREPRESENTATIVE_FIELD	="PLegalRepresentative";

		public const string PPRINCIPAL_FIELD			="PPrincipal";
		public const string ACCOUNTBANK_FIELD			="AccountBank";
		public const string ACCOUNTS_FIELD				="Accounts";
		public const string TAXNO_FIELD		            ="TaxNo"; 
		public const string TRADEITEM_FIELD		        ="TradeItem";

		public const string PHONE_FIELD				    ="Phone";//
		public const string FAX_FIELD			        ="Fax";
		public const string TELEGRAM_FIELD				="Telegram";
		public const string POSTCODE_FIELD				="Postcode";
		public const string ADDRESS_FIELD				="Address";

		public const string CONTRACTPERSON_FIELD		="ContactPerson";
		public const string STATUS_FIELD				="Status";
		public const string DRAWPERSON_FIELD		    ="DrawPerson";
		public const string DRAWDATE_FIELD		        ="DrawDate"; 
		public const string IVALIDDATE_FIELD		    ="IvalidDate";

		public const string DESCRIPTION_FIELD		    ="Description"; 
		public const string ACCOUNTDEP_FIELD		    ="AccountDep";
		

		public SalesContractData()
		{
			BuildTable();

		}
		private void BuildTable()
		{
			DataTable table = new DataTable (SalesContractData.SALESCONTRACT_TABLE);
			DataColumnCollection columns = table.Columns;

			columns.Add(CONTRACTID_FIELD,typeof (System.String));
			columns.Add(CONTRACTNAME_FIELD,typeof (System.String));
			columns.Add(CONTRACTNO_FIELD,typeof (System.String));
			columns.Add(PUB_CONTRACTTYPE_FIELD,typeof (System.String));
			columns.Add(SALESTYPE_FIELD,typeof (System.String));

			columns.Add(DEPARTMENTID_FIELD,typeof (System.String));
			columns.Add(CUSTOMER_FIELD,typeof (System.String));
			columns.Add(MONEYTYPE_FIELD,typeof (System.String));
			columns.Add(ALLSUM_FIELD,typeof (System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD,typeof (System.Decimal));

			columns.Add(WITHOUTTAXSUM_FIELD,typeof (System.Decimal));
			columns.Add(TAXSUM_FIELD,typeof (System.Decimal));
			columns.Add(PUB_CLEARINGFORM_FIELD,typeof (System.String));
			columns.Add(PUB_TRAFFICMODE_FIELD,typeof (System.String));
			columns.Add(PUB_TAKEDELIVERYMODE_FIELD,typeof (System.String));

			columns.Add(STATIONOFDELIVARY_FIELD,typeof (System.String));
			columns.Add(PLACEOFDELIVERY_FIELD,typeof (System.String));
			columns.Add(CARRIAGEBEAR_FIELD,typeof (System.String));
			columns.Add(SIGNADDRESS_FIELD,typeof (System.String));
			columns.Add(SIGNDATE_FIELD,typeof (System.DateTime));

			columns.Add(VALIDBEGINDATE_FIELD,typeof (System.DateTime));
			columns.Add(VALIDENDDATE_FIELD,typeof (System.DateTime));
			columns.Add(NLEGAREPRESENTATIVE_FIELD,typeof (System.String));
			columns.Add(NPRINCIPAL_FIELD,typeof (System.String));
			columns.Add(PLEGALREPRESENTATIVE_FIELD,typeof (System.String));

			columns.Add(PPRINCIPAL_FIELD,typeof (System.String));
			columns.Add(ACCOUNTBANK_FIELD,typeof (System.String));
			columns.Add(ACCOUNTS_FIELD,typeof (System.String));
			columns.Add(TAXNO_FIELD,typeof (System.String));
			columns.Add(TRADEITEM_FIELD,typeof (System.String));

			columns.Add(PHONE_FIELD,typeof (System.String));
			columns.Add(FAX_FIELD,typeof (System.String));
			columns.Add(TELEGRAM_FIELD,typeof (System.String));
			columns.Add(POSTCODE_FIELD,typeof (System.String));
			columns.Add(ADDRESS_FIELD,typeof (System.String));

			columns.Add(CONTRACTPERSON_FIELD,typeof (System.String));
			columns.Add(STATUS_FIELD,typeof (System.String));
			columns.Add(DRAWPERSON_FIELD,typeof (System.String));
			columns.Add(DRAWDATE_FIELD,typeof (System.DateTime));
			columns.Add(IVALIDDATE_FIELD,typeof (System.DateTime));

			columns.Add(DESCRIPTION_FIELD,typeof (System.String));
			columns.Add(ACCOUNTDEP_FIELD,typeof (System.String));
			
			this.Tables.Add(table);
		}
	}
}
