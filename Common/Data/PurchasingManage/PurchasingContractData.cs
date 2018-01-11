using System;
using System.Data;


namespace TOPSUN.ERP.Common.Data.PurchasingManage
{
	[System.ComponentModel.DesignerCategory("Code")]
	[SerializableAttribute] 
	/// <summary>
	/// PurchasingContractData 的摘要说明。
	/// </summary>
	public class PurchasingContractData :DataSet
	{
		public const String PURCHARINGCONTRACT_TABLE			= "TBL_PurchasingContract";

		public const String CONTRACTNAME_FIELD					= "ContractName";
		public const String CONTRACTID_FIELD					= "ContractID";
		public const String CONTRACTNO_FIELD					= "ContractNo";
		public const String DEPARTMENTID_FIELD					= "DepartmentID";
		public const String CORCOMPANYID_FIELD					= "CorCompanyID";

		public const String PUB_CONTRACTTYPE_FIELD				= "PUB_ContractType";
		public const String MONEYTYPE_FIELD						= "MoneyType";
		public const String ALLSUM_FIELD						= "AllSum";
		public const String DISCOUNTSUM_FIELD					= "DiscountSum";
		public const String WITHOUTTAXSUM_FIELD					= "WithoutTaxSum";

		public const String TAXSUM_FIELD						= "TaxSum";
		public const String PUB_CEARINGFORM_FIELD				= "PUB_CearingForm";
		public const String PUB_TRAFFICMODE_FIELD				= "PUB_TrafficMode";
		public const String PUB_TAKEDELIVERYNO_FIELD			= "PUB_TakeDeliveryMode"; 
		public const String STATIONOFDISPATCH_FIELD				= "StationOfDispatch";   

		public const String PLACEOFDELIVERY_FIELD				= "PlaceOfDelivery";
		public const String CARRIAGEBEAR_FIELD					= "CarriageBear";
		public const String SIGNADDRESS_FIELD					= "SignAddress";
		public const String SIGNDATE_FIELD						= "SignDate";
        public const String VALIDBEGINDATE_FIELD				= "ValidBeginDate";

		public const String VALIDENDDATE_FIELD					= "ValidEndDate";
		public const String NLEGALREPRESENTATI_FIELD			= "NLegalRepresentative";
		public const String NPRINCIPAL_FIELD					= "NPrincipal";
		public const String PLEGALREPRESENTATI_FIELD			= "PLegalRepresentative";
		public const String PPRINCIPAL_FIELD					= "PPrincipal";

		public const String ACCOUNTBANK_FIELD					= "AccountBank";
		public const String ACCOUNTS_FIELD						= "Accounts";
		public const String TAXNO_FIELD							= "TaxNo";
		public const String TRADEITEM_FIELD						= "TradeItem";
		public const String PHONE_FIELD							= "Phone";

		public const String FAX_FIELD							= "Fax";
		public const String TELEGRAM_FIELD						= "Telegram";
		public const String POSTCODE_FIELD						= "Postcode";
		public const String ADDRESS_FIELD						= "Address";
		public const String CONTACTPERSON_FIELD					= "ContactPerson";

		public const String STATUS_FIELD						= "Status";
		public const String DRAWPERSON_FIELD					= "DrawPerson";
		public const String DRAWLISTDATE_FIELD					= "DrawDate";
		public const String ACCOUNTDEP_FIELD					= "AccountDep";
		public const String INVALIDDATE_FIELD					= "InvalidDate";

		public const String DESCRIPTION_FIELD					= "Description";

		//Added by YiChangxin 2005-8-30
		public const String CONTRACT_FIELD						= "Contract";
		public const String CORCOMPANYNAME_FIELD				= "corcompanyname";
		public const String DEPARTMENTNAME_FIELD				= "departmentname";

		public enum PurchasingContractRecordStatus
		{
			未确认=0,
			
			已驳回=1,
			
			已生效=2,
		
			已确认=3
		}


		public PurchasingContractData()
		{
			CreateTable();
		}

		private void CreateTable()
		{
			DataTable tables =   new DataTable(PURCHARINGCONTRACT_TABLE);
			DataColumnCollection columns=tables.Columns;

			columns.Add(CONTRACTNAME_FIELD  ,typeof(System.String));
			columns.Add(CONTRACTID_FIELD  ,typeof(System.String));
			columns.Add(CONTRACTNO_FIELD,  typeof(System.String));
			columns.Add(DEPARTMENTID_FIELD  ,typeof(System.String));
			columns.Add(CORCOMPANYID_FIELD ,typeof(System.String));

			columns.Add(PUB_CONTRACTTYPE_FIELD  ,typeof(System.String));
			columns.Add(MONEYTYPE_FIELD , typeof(System.String));
			columns.Add(ALLSUM_FIELD , typeof(System.Decimal));
			columns.Add(DISCOUNTSUM_FIELD , typeof(System.Decimal));
			columns.Add(WITHOUTTAXSUM_FIELD , typeof(System.Decimal));

			columns.Add(TAXSUM_FIELD , typeof(System.Decimal));
			columns.Add(PUB_CEARINGFORM_FIELD , typeof(System.String));
			columns.Add(PUB_TRAFFICMODE_FIELD , typeof(System.String));
			columns.Add(PUB_TAKEDELIVERYNO_FIELD , typeof(System.String));
			columns.Add(STATIONOFDISPATCH_FIELD , typeof(System.String));

			columns.Add(PLACEOFDELIVERY_FIELD , typeof(System.String));
			columns.Add(CARRIAGEBEAR_FIELD , typeof(System.String));
			columns.Add(SIGNADDRESS_FIELD , typeof(System.String));
			columns.Add(SIGNDATE_FIELD , typeof(System.DateTime));
			columns.Add(VALIDBEGINDATE_FIELD , typeof(System.DateTime));

			columns.Add(VALIDENDDATE_FIELD , typeof(System.DateTime));
			columns.Add(NLEGALREPRESENTATI_FIELD , typeof(System.String));
			columns.Add(NPRINCIPAL_FIELD , typeof(System.String));
			columns.Add(PLEGALREPRESENTATI_FIELD , typeof(System.String));
			columns.Add(PPRINCIPAL_FIELD , typeof(System.String));

			columns.Add(ACCOUNTBANK_FIELD , typeof(System.String));
			columns.Add(ACCOUNTS_FIELD , typeof(System.String));
			columns.Add(TAXNO_FIELD , typeof(System.String));
			columns.Add(TRADEITEM_FIELD , typeof(System.String));
			columns.Add(PHONE_FIELD , typeof(System.String));

			columns.Add(FAX_FIELD , typeof(System.String));
			columns.Add(TELEGRAM_FIELD , typeof(System.String));
			columns.Add(POSTCODE_FIELD , typeof(System.String));
			columns.Add(ADDRESS_FIELD , typeof(System.String));
			columns.Add(CONTACTPERSON_FIELD , typeof(System.String));

			columns.Add(STATUS_FIELD , typeof(System.String));
			columns.Add(DRAWPERSON_FIELD , typeof(System.String));
			columns.Add(DRAWLISTDATE_FIELD , typeof(System.DateTime));
			columns.Add(ACCOUNTDEP_FIELD , typeof(System.String));
			columns.Add(INVALIDDATE_FIELD , typeof(System.DateTime));

			columns.Add(DESCRIPTION_FIELD , typeof(System.String));

			//Added by YiChangxin 2005-8-30
			columns.Add(CONTRACT_FIELD ,typeof(System.String));
			columns.Add(CORCOMPANYNAME_FIELD ,typeof(System.String));
			columns.Add(DEPARTMENTNAME_FIELD ,typeof(System.String));

			this.Tables.Add(tables);
		}
	}
}
