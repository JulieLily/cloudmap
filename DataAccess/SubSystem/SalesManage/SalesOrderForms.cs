using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	
	public class SalesOrderForms:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const string ORDERFORMID_PARM			="@orderformID";
		private const string ORDERFORMNAME_PARM			="@orderformName";
		private const string ORDERFORMNO_PARM			="@orderformno";
		private const string PUB_CONTRACTTYPE_PARM		="@PUB_ContractType";
		private const string SALESTYPE_PARM				="@SalesType";
		private const string CONTRACTID_PARM			="@ContractID";

		private const string DEPARTMENTID_PARM			="@departmentid";
		private const string CUSTOMER_PARM				="@Customer";
		private const string MONEYTYPE_PARM				="@MoneyType";
		private const string ALLSUM_PARM				="@AllSum";
		private const string DISCOUNTSUM_PARM			="@discountsum";

		private const string WITHOUTTAXSUM_PARM			="@WithoutTaxSum";
		private const string TAXSUM_PARM				="@taxsum";
		private const string PUB_CLEARINGFORM_PARM		="@PUB_ClearingForm"; 
		private const string PUB_TRAFFICMODE_PARM		="@PUB_TrafficMode";
		private const string PUB_TAKEDELIVERYMODE_PARM	="@PUB_TakeDeliveryMode";

		private const string STATIONOFDELIVARY_PARM		="@StationOfDelivery";
		private const string PLACEOFDELIVERY_PARM		="@PlaceOfDelivery";
		private const string CARRIAGEBEAR_PARM			="@CarriageBear";
		private const string SIGNADDRESS_PARM			="@SignAddress";
		private const string SIGNDATE_PARM				="@SignDate";

		private const string VALIDBEGINDATE_PARM		="@ValidBeginDate";
		private const string VALIDENDDATE_PARM			="@ValidEndDate";
		private const string NLEGAREPRESENTATIVE_PARM	="@NLegalRepresentative";
		private const string NPRINCIPAL_PARM			="@NPrincipal";
		private const string PLEGALREPRESENTATIVE_PARM	="@PLegalRepresentative";

		private const string PPRINCIPAL_PARM			="@PPrincipal";
		private const string ACCOUNTBANK_PARM			="@AccountBank";
		private const string ACCOUNTS_PARM				="@Accounts";
		private const string TAXNO_PARM					="@TaxNo"; 
		private const string TRADEITEM_PARM				 ="@TradeItem";

		private const string PHONE_PARM					="@Phone";
		private const string FAX_PARM			        ="@Fax";
		private const string TELEGRAM_PARM				="@Telegram";
		private const string POSTCODE_PARM				="@Postcode";
		private const string ADDRESS_PARM				="@Address";

		private const string CONTRACTPERSON_PARM		="@ContactPerson";
		private const string STATUS_PARM				="@Status";
		private const string DRAWPERSON_PARM		    ="@DrawPerson";
		private const string DRAWDATE_PARM		        ="@DrawDate"; 
		private const string IVALIDDATE_PARM		    ="@IvalidDate";

		private const string DESCRIPTION_PARM		    ="@Description"; 
		private const string ACCOUNTDEP_PARM		    ="@AccountDep";

		public SalesOrderForms()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",SalesOrderFormData.SALESORDERFORM_TABLE);
		}

		#region  释放资源
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected virtual void Dispose(bool disposing)
		{
			if( ! disposing)
				return;
			if(dsCommand!=null)
			{
				if(dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				}
				if(dsCommand.InsertCommand!=null)
				{
					if(dsCommand.InsertCommand.Connection!=null)
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}
				if(dsCommand.UpdateCommand!=null)
				{
					if(dsCommand.UpdateCommand.Connection!=null)
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}
				if(dsCommand.DeleteCommand!=null)
				{
					if(dsCommand.DeleteCommand.Connection!=null)
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}
				dsCommand.Dispose();
				dsCommand=null;
			}
		}
		#endregion 

		#region  Get Data  //Modified by XuJiansong 2005-9-12

		//		private SqlCommand GetloadCommand()
		//		{
		//			SqlCommand loadCommand = new SqlCommand("Q_SalesOrderForm",new SqlConnection(ERPConfiguration.ConnectionString));
		//			loadCommand.CommandType = CommandType.StoredProcedure;
		//
		//			return loadCommand;
		//		}

		// 改用 具有filter 的条件读取所有的记录  	//Modified by XuJiansong 2005-9-12

		private SqlCommand GetloadCommand(string filter)
		{
			string sql;
			if(filter==""||filter==null)
				sql = " select t.* ,d.Name DrawDepartmentName , s.Name DrawpersonName , c.ContractID ,c.ContractName ContractName  ,f.CompanyID Customer ,f.Name CustomerName "
					+"  from tbl_salesorderform t left join TBL_DepartmentInfo d on t.DepartmentID =d.DepartmentID "
					+"  left join  TBL_SalesContract c  on  t.ContractID = c.ContractID "
					+"  left join TBL_CorrespondentCompany f on t.Customer = f.CompanyID and t.DepartmentID =f.DepartmentID  and PUB_Category ='客户' "
					+"  left join TBL_StaffInfo s  on s.ID = t.DrawPerson " ;
			else
				//				sql = "select * from TBL_SalesOrderForm where " + filter;
				sql = " select t.* ,d.Name DrawDepartmentName , s.Name DrawpersonName , c.ContractID ,c.ContractName ContractName  ,f.CompanyID Customer ,f.Name CustomerName "
					+"  from (select * from tbl_salesorderform where " + filter + ") t left join TBL_DepartmentInfo d on t.DepartmentID =d.DepartmentID "
					+"  left join  TBL_SalesContract c  on  t.ContractID = c.ContractID "
					+"  left join TBL_CorrespondentCompany f on t.Customer = f.CompanyID and t.DepartmentID =f.DepartmentID  and PUB_Category ='客户' "
					+"  left join TBL_StaffInfo s  on s.ID = t.DrawPerson " ;

			SqlCommand loadCommand = new SqlCommand(sql ,new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.Text;

			return loadCommand;
		}
		public SalesOrderFormData LoadSalesOrderForm(string filter)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			SalesOrderFormData  data = new SalesOrderFormData  ();
			dsCommand.SelectCommand=GetloadCommand(filter);
			try
			{
				dsCommand.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}

		}

		#endregion

		#region  Insert Data

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_SalesOrderForm",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_orderformID= new SqlParameter  (ORDERFORMID_PARM,SqlDbType.Char);
			parm_orderformID.SourceColumn = SalesOrderFormData.ORDERFORMID_FIELD;
			parm_orderformID.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_orderformID);

			SqlParameter parm_orderformName= new SqlParameter  (ORDERFORMNAME_PARM,SqlDbType.Char);
			parm_orderformName.SourceColumn = SalesOrderFormData.ORDERFORMNAME_FIELD;
			parm_orderformName.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_orderformName);

			SqlParameter parm_orderformno= new SqlParameter  (ORDERFORMNO_PARM,SqlDbType.VarChar);
			parm_orderformno.SourceColumn = SalesOrderFormData.ORDERFORMNO_FIELD;
			parm_orderformno.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_orderformno);

			SqlParameter parm_PUB_ContractType= new SqlParameter  (PUB_CONTRACTTYPE_PARM,SqlDbType.Char);
			parm_PUB_ContractType.SourceColumn = SalesOrderFormData.PUB_CONTRACTTYPE_FIELD;
			parm_PUB_ContractType.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PUB_ContractType);

			SqlParameter parm_SalesType= new SqlParameter  (SALESTYPE_PARM,SqlDbType.Char);
			parm_SalesType.SourceColumn = SalesOrderFormData.SALESTYPE_FIELD;
			parm_SalesType.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_SalesType);

			SqlParameter parm_contractid= new SqlParameter  (CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.SourceColumn = SalesOrderFormData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_contractid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = SalesOrderFormData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_Customer= new SqlParameter  (CUSTOMER_PARM,SqlDbType.Char);
			parm_Customer.SourceColumn = SalesOrderFormData.CUSTOMER_FIELD;
			parm_Customer.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Customer);

			SqlParameter parm_MoneyType= new SqlParameter  (MONEYTYPE_PARM,SqlDbType.Char);
			parm_MoneyType.SourceColumn = SalesOrderFormData.MONEYTYPE_FIELD;
			parm_MoneyType.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_MoneyType);

			SqlParameter parm_AllSum= new SqlParameter  (ALLSUM_PARM,SqlDbType.Decimal);
			parm_AllSum.SourceColumn = SalesOrderFormData.ALLSUM_FIELD;
			parm_AllSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_AllSum);

			SqlParameter parm_discountsum= new SqlParameter  (DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_discountsum.SourceColumn = SalesOrderFormData.DISCOUNTSUM_FIELD;
			parm_discountsum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discountsum);

			SqlParameter parm_WithoutTaxSum= new SqlParameter  (WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_WithoutTaxSum.SourceColumn = SalesOrderFormData.WITHOUTTAXSUM_FIELD;
			parm_WithoutTaxSum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_WithoutTaxSum);

			SqlParameter parm_taxsum= new SqlParameter  (TAXSUM_PARM,SqlDbType.Decimal);
			parm_taxsum.SourceColumn = SalesOrderFormData.TAXSUM_FIELD;
			parm_taxsum.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxsum);

			SqlParameter parm_PUB_ClearingForm= new SqlParameter  (PUB_CLEARINGFORM_PARM,SqlDbType.Char);
			parm_PUB_ClearingForm.SourceColumn = SalesOrderFormData.PUB_CLEARINGFORM_FIELD;
			parm_PUB_ClearingForm.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PUB_ClearingForm);

			SqlParameter parm_PUB_TrafficMode= new SqlParameter  (PUB_TRAFFICMODE_PARM,SqlDbType.Char);
			parm_PUB_TrafficMode.SourceColumn = SalesOrderFormData.PUB_TRAFFICMODE_FIELD;
			parm_PUB_TrafficMode.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PUB_TrafficMode);

			SqlParameter parm_PUB_TakeDeliveryMode= new SqlParameter  (PUB_TAKEDELIVERYMODE_PARM,SqlDbType.Char);
			parm_PUB_TakeDeliveryMode.SourceColumn = SalesOrderFormData.PUB_TAKEDELIVERYMODE_FIELD;
			parm_PUB_TakeDeliveryMode.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PUB_TakeDeliveryMode);

			SqlParameter parm_StationOfDelivery= new SqlParameter  (STATIONOFDELIVARY_PARM,SqlDbType.VarChar);
			parm_StationOfDelivery.SourceColumn = SalesOrderFormData.STATIONOFDELIVARY_FIELD;
			parm_StationOfDelivery.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_StationOfDelivery);

			SqlParameter parm_PlaceOfDelivery= new SqlParameter  (PLACEOFDELIVERY_PARM,SqlDbType.VarChar);
			parm_PlaceOfDelivery.SourceColumn = SalesOrderFormData.PLACEOFDELIVERY_FIELD;
			parm_PlaceOfDelivery.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PlaceOfDelivery);

			SqlParameter parm_CarriageBear= new SqlParameter  (CARRIAGEBEAR_PARM,SqlDbType.Char);
			parm_CarriageBear.SourceColumn = SalesOrderFormData.CARRIAGEBEAR_FIELD;
			parm_CarriageBear.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_CarriageBear);

			SqlParameter parm_SignAddress= new SqlParameter  (SIGNADDRESS_PARM,SqlDbType.Char);
			parm_SignAddress.SourceColumn = SalesOrderFormData.SIGNADDRESS_FIELD;
			parm_SignAddress.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_SignAddress);

			SqlParameter parm_SignDate= new SqlParameter  (SIGNDATE_PARM,SqlDbType.DateTime);
			parm_SignDate.SourceColumn = SalesOrderFormData.SIGNDATE_FIELD;
			parm_SignDate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_SignDate);

			SqlParameter parm_ValidBeginDate= new SqlParameter  (VALIDBEGINDATE_PARM,SqlDbType.DateTime);
			parm_ValidBeginDate.SourceColumn = SalesOrderFormData.VALIDBEGINDATE_FIELD;
			parm_ValidBeginDate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ValidBeginDate);

			SqlParameter parm_ValidEndDate= new SqlParameter  (VALIDENDDATE_PARM,SqlDbType.DateTime);
			parm_ValidEndDate.SourceColumn = SalesOrderFormData.VALIDENDDATE_FIELD;
			parm_ValidEndDate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ValidEndDate);

			SqlParameter parm_NLegalRepresentative= new SqlParameter  (NLEGAREPRESENTATIVE_PARM,SqlDbType.Char);
			parm_NLegalRepresentative.SourceColumn = SalesOrderFormData.NLEGAREPRESENTATIVE_FIELD;
			parm_NLegalRepresentative.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_NLegalRepresentative);

			SqlParameter parm_NPrincipal= new SqlParameter  (NPRINCIPAL_PARM,SqlDbType.Char);
			parm_NPrincipal.SourceColumn = SalesOrderFormData.NPRINCIPAL_FIELD;
			parm_NPrincipal.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_NPrincipal);

			SqlParameter parm_PLegalRepresentative= new SqlParameter  (PLEGALREPRESENTATIVE_PARM,SqlDbType.Char);
			parm_PLegalRepresentative.SourceColumn = SalesOrderFormData.PLEGALREPRESENTATIVE_FIELD;
			parm_PLegalRepresentative.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PLegalRepresentative);

			SqlParameter parm_PPrincipal= new SqlParameter  (PPRINCIPAL_PARM,SqlDbType.Char);
			parm_PPrincipal.SourceColumn = SalesOrderFormData.PPRINCIPAL_FIELD;
			parm_PPrincipal.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_PPrincipal);

			SqlParameter parm_AccountBank= new SqlParameter  (ACCOUNTBANK_PARM,SqlDbType.Char);
			parm_AccountBank.SourceColumn = SalesOrderFormData.ACCOUNTBANK_FIELD;
			parm_AccountBank.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_AccountBank);

			SqlParameter parm_Accounts= new SqlParameter  (ACCOUNTS_PARM,SqlDbType.Char);
			parm_Accounts.SourceColumn = SalesOrderFormData.ACCOUNTS_FIELD;
			parm_Accounts.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Accounts);

			SqlParameter parm_TaxNo= new SqlParameter  (TAXNO_PARM,SqlDbType.Char);
			parm_TaxNo.SourceColumn = SalesOrderFormData.TAXNO_FIELD;
			parm_TaxNo.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TaxNo);

			SqlParameter parm_TradeItem= new SqlParameter  (TRADEITEM_PARM,SqlDbType.VarChar);
			parm_TradeItem.SourceColumn = SalesOrderFormData.TRADEITEM_FIELD;
			parm_TradeItem.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_TradeItem);

			SqlParameter parm_Phone= new SqlParameter  (PHONE_PARM,SqlDbType.Char);
			parm_Phone.SourceColumn = SalesOrderFormData.PHONE_FIELD;
			parm_Phone.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Phone);

			SqlParameter parm_Fax= new SqlParameter  (FAX_PARM,SqlDbType.Char);
			parm_Fax.SourceColumn = SalesOrderFormData.FAX_FIELD;
			parm_Fax.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Fax);

			SqlParameter parm_Telegram= new SqlParameter  (TELEGRAM_PARM,SqlDbType.Char);
			parm_Telegram.SourceColumn = SalesOrderFormData.TELEGRAM_FIELD;
			parm_Telegram.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Telegram);

			SqlParameter parm_Postcode= new SqlParameter  (POSTCODE_PARM,SqlDbType.Char);
			parm_Postcode.SourceColumn = SalesOrderFormData.POSTCODE_FIELD;
			parm_Postcode.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Postcode);

			SqlParameter parm_Address= new SqlParameter  (ADDRESS_PARM,SqlDbType.Char);
			parm_Address.SourceColumn = SalesOrderFormData.ADDRESS_FIELD;
			parm_Address.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Address);

			SqlParameter parm_ContactPerson= new SqlParameter  (CONTRACTPERSON_PARM,SqlDbType.Char);
			parm_ContactPerson.SourceColumn = SalesOrderFormData.CONTRACTPERSON_FIELD;
			parm_ContactPerson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ContactPerson);

			SqlParameter parm_Status= new SqlParameter  (STATUS_PARM,SqlDbType.Char);
			parm_Status.SourceColumn = SalesOrderFormData.STATUS_FIELD;
			parm_Status.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Status);

			SqlParameter parm_DrawPerson= new SqlParameter  (DRAWPERSON_PARM,SqlDbType.Char);
			parm_DrawPerson.SourceColumn = SalesOrderFormData.DRAWPERSON_FIELD;
			parm_DrawPerson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DrawPerson);

			SqlParameter parm_DrawDate= new SqlParameter  (DRAWDATE_PARM,SqlDbType.DateTime);
			parm_DrawDate.SourceColumn = SalesOrderFormData.DRAWDATE_FIELD;
			parm_DrawDate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DrawDate);

			SqlParameter parm_IvalidDate= new SqlParameter  (IVALIDDATE_PARM,SqlDbType.DateTime);
			parm_IvalidDate.SourceColumn = SalesOrderFormData.IVALIDDATE_FIELD;
			parm_IvalidDate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_IvalidDate);

			SqlParameter parm_Description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_Description.SourceColumn = SalesOrderFormData.DESCRIPTION_FIELD;
			parm_Description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_Description);

			SqlParameter parm_AccountDep= new SqlParameter  (ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_AccountDep.SourceColumn = SalesOrderFormData.ACCOUNTDEP_FIELD;
			parm_AccountDep.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_AccountDep);

			return insertCommand;


		}
		public bool InsertSalesOrderForm(SalesOrderFormData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			try
			{
				dsCommand.Update(data,SalesOrderFormData.SALESORDERFORM_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesOrderFormData.SALESORDERFORM_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				data.AcceptChanges();
				return true;
			}
			catch
			{
				return false;

			}
		}

		#endregion

		#region  Update Data

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_SalesOrderForm",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType= CommandType.StoredProcedure;

			SqlParameter parm_orderformID= new SqlParameter  (ORDERFORMID_PARM,SqlDbType.Char);
			parm_orderformID.SourceColumn = SalesOrderFormData.ORDERFORMID_FIELD;
			parm_orderformID.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_orderformID);

			SqlParameter parm_orderformName= new SqlParameter  (ORDERFORMNAME_PARM,SqlDbType.Char);
			parm_orderformName.SourceColumn = SalesOrderFormData.ORDERFORMNAME_FIELD;
			parm_orderformName.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_orderformName);

			SqlParameter parm_orderformno= new SqlParameter  (ORDERFORMNO_PARM,SqlDbType.VarChar);
			parm_orderformno.SourceColumn = SalesOrderFormData.ORDERFORMNO_FIELD;
			parm_orderformno.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_orderformno);

			SqlParameter parm_PUB_ContractType= new SqlParameter  (PUB_CONTRACTTYPE_PARM,SqlDbType.Char);
			parm_PUB_ContractType.SourceColumn = SalesOrderFormData.PUB_CONTRACTTYPE_FIELD;
			parm_PUB_ContractType.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PUB_ContractType);

			SqlParameter parm_SalesType= new SqlParameter  (SALESTYPE_PARM,SqlDbType.Char);
			parm_SalesType.SourceColumn = SalesOrderFormData.SALESTYPE_FIELD;
			parm_SalesType.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_SalesType);

			SqlParameter parm_contractid= new SqlParameter  (CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.SourceColumn = SalesOrderFormData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_contractid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = SalesOrderFormData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_Customer= new SqlParameter  (CUSTOMER_PARM,SqlDbType.Char);
			parm_Customer.SourceColumn = SalesOrderFormData.CUSTOMER_FIELD;
			parm_Customer.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Customer);

			SqlParameter parm_MoneyType= new SqlParameter  (MONEYTYPE_PARM,SqlDbType.Char);
			parm_MoneyType.SourceColumn = SalesOrderFormData.MONEYTYPE_FIELD;
			parm_MoneyType.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_MoneyType);

			SqlParameter parm_AllSum= new SqlParameter  (ALLSUM_PARM,SqlDbType.Decimal);
			parm_AllSum.SourceColumn = SalesOrderFormData.ALLSUM_FIELD;
			parm_AllSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_AllSum);

			SqlParameter parm_discountsum= new SqlParameter  (DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_discountsum.SourceColumn = SalesOrderFormData.DISCOUNTSUM_FIELD;
			parm_discountsum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discountsum);

			SqlParameter parm_WithoutTaxSum= new SqlParameter  (WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_WithoutTaxSum.SourceColumn = SalesOrderFormData.WITHOUTTAXSUM_FIELD;
			parm_WithoutTaxSum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_WithoutTaxSum);

			SqlParameter parm_taxsum= new SqlParameter  (TAXSUM_PARM,SqlDbType.Decimal);
			parm_taxsum.SourceColumn = SalesOrderFormData.TAXSUM_FIELD;
			parm_taxsum.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxsum);

			SqlParameter parm_PUB_ClearingForm= new SqlParameter  (PUB_CLEARINGFORM_PARM,SqlDbType.Char);
			parm_PUB_ClearingForm.SourceColumn = SalesOrderFormData.PUB_CLEARINGFORM_FIELD;
			parm_PUB_ClearingForm.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PUB_ClearingForm);

			SqlParameter parm_PUB_TrafficMode= new SqlParameter  (PUB_TRAFFICMODE_PARM,SqlDbType.Char);
			parm_PUB_TrafficMode.SourceColumn = SalesOrderFormData.PUB_TRAFFICMODE_FIELD;
			parm_PUB_TrafficMode.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PUB_TrafficMode);

			SqlParameter parm_PUB_TakeDeliveryMode= new SqlParameter  (PUB_TAKEDELIVERYMODE_PARM,SqlDbType.Char);
			parm_PUB_TakeDeliveryMode.SourceColumn = SalesOrderFormData.PUB_TAKEDELIVERYMODE_FIELD;
			parm_PUB_TakeDeliveryMode.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PUB_TakeDeliveryMode);

			SqlParameter parm_StationOfDelivery= new SqlParameter  (STATIONOFDELIVARY_PARM,SqlDbType.VarChar);
			parm_StationOfDelivery.SourceColumn = SalesOrderFormData.STATIONOFDELIVARY_FIELD;
			parm_StationOfDelivery.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_StationOfDelivery);

			SqlParameter parm_PlaceOfDelivery= new SqlParameter  (PLACEOFDELIVERY_PARM,SqlDbType.VarChar);
			parm_PlaceOfDelivery.SourceColumn = SalesOrderFormData.PLACEOFDELIVERY_FIELD;
			parm_PlaceOfDelivery.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PlaceOfDelivery);

			SqlParameter parm_CarriageBear= new SqlParameter  (CARRIAGEBEAR_PARM,SqlDbType.Char);
			parm_CarriageBear.SourceColumn = SalesOrderFormData.CARRIAGEBEAR_FIELD;
			parm_CarriageBear.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_CarriageBear);

			SqlParameter parm_SignAddress= new SqlParameter  (SIGNADDRESS_PARM,SqlDbType.Char);
			parm_SignAddress.SourceColumn = SalesOrderFormData.SIGNADDRESS_FIELD;
			parm_SignAddress.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_SignAddress);

			SqlParameter parm_SignDate= new SqlParameter  (SIGNDATE_PARM,SqlDbType.DateTime);
			parm_SignDate.SourceColumn = SalesOrderFormData.SIGNDATE_FIELD;
			parm_SignDate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_SignDate);

			SqlParameter parm_ValidBeginDate= new SqlParameter  (VALIDBEGINDATE_PARM,SqlDbType.DateTime);
			parm_ValidBeginDate.SourceColumn = SalesOrderFormData.VALIDBEGINDATE_FIELD;
			parm_ValidBeginDate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ValidBeginDate);

			SqlParameter parm_ValidEndDate= new SqlParameter  (VALIDENDDATE_PARM,SqlDbType.DateTime);
			parm_ValidEndDate.SourceColumn = SalesOrderFormData.VALIDENDDATE_FIELD;
			parm_ValidEndDate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ValidEndDate);

			SqlParameter parm_NLegalRepresentative= new SqlParameter  (NLEGAREPRESENTATIVE_PARM,SqlDbType.Char);
			parm_NLegalRepresentative.SourceColumn = SalesOrderFormData.NLEGAREPRESENTATIVE_FIELD;
			parm_NLegalRepresentative.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_NLegalRepresentative);

			SqlParameter parm_NPrincipal= new SqlParameter  (NPRINCIPAL_PARM,SqlDbType.Char);
			parm_NPrincipal.SourceColumn = SalesOrderFormData.NPRINCIPAL_FIELD;
			parm_NPrincipal.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_NPrincipal);

			SqlParameter parm_PLegalRepresentative= new SqlParameter  (PLEGALREPRESENTATIVE_PARM,SqlDbType.Char);
			parm_PLegalRepresentative.SourceColumn = SalesOrderFormData.PLEGALREPRESENTATIVE_FIELD;
			parm_PLegalRepresentative.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PLegalRepresentative);

			SqlParameter parm_PPrincipal= new SqlParameter  (PPRINCIPAL_PARM,SqlDbType.Char);
			parm_PPrincipal.SourceColumn = SalesOrderFormData.PPRINCIPAL_FIELD;
			parm_PPrincipal.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_PPrincipal);

			SqlParameter parm_AccountBank= new SqlParameter  (ACCOUNTBANK_PARM,SqlDbType.Char);
			parm_AccountBank.SourceColumn = SalesOrderFormData.ACCOUNTBANK_FIELD;
			parm_AccountBank.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_AccountBank);

			SqlParameter parm_Accounts= new SqlParameter  (ACCOUNTS_PARM,SqlDbType.Char);
			parm_Accounts.SourceColumn = SalesOrderFormData.ACCOUNTS_FIELD;
			parm_Accounts.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Accounts);

			SqlParameter parm_TaxNo= new SqlParameter  (TAXNO_PARM,SqlDbType.Char);
			parm_TaxNo.SourceColumn = SalesOrderFormData.TAXNO_FIELD;
			parm_TaxNo.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TaxNo);

			SqlParameter parm_TradeItem= new SqlParameter  (TRADEITEM_PARM,SqlDbType.VarChar);
			parm_TradeItem.SourceColumn = SalesOrderFormData.TRADEITEM_FIELD;
			parm_TradeItem.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_TradeItem);

			SqlParameter parm_Phone= new SqlParameter  (PHONE_PARM,SqlDbType.Char);
			parm_Phone.SourceColumn = SalesOrderFormData.PHONE_FIELD;
			parm_Phone.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Phone);

			SqlParameter parm_Fax= new SqlParameter  (FAX_PARM,SqlDbType.Char);
			parm_Fax.SourceColumn = SalesOrderFormData.FAX_FIELD;
			parm_Fax.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Fax);

			SqlParameter parm_Telegram= new SqlParameter  (TELEGRAM_PARM,SqlDbType.Char);
			parm_Telegram.SourceColumn = SalesOrderFormData.TELEGRAM_FIELD;
			parm_Telegram.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Telegram);

			SqlParameter parm_Postcode= new SqlParameter  (POSTCODE_PARM,SqlDbType.Char);
			parm_Postcode.SourceColumn = SalesOrderFormData.POSTCODE_FIELD;
			parm_Postcode.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Postcode);

			SqlParameter parm_Address= new SqlParameter  (ADDRESS_PARM,SqlDbType.Char);
			parm_Address.SourceColumn = SalesOrderFormData.ADDRESS_FIELD;
			parm_Address.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Address);

			SqlParameter parm_ContactPerson= new SqlParameter  (CONTRACTPERSON_PARM,SqlDbType.Char);
			parm_ContactPerson.SourceColumn = SalesOrderFormData.CONTRACTPERSON_FIELD;
			parm_ContactPerson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ContactPerson);

			SqlParameter parm_Status= new SqlParameter  (STATUS_PARM,SqlDbType.Char);
			parm_Status.SourceColumn = SalesOrderFormData.STATUS_FIELD;
			parm_Status.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Status);

			SqlParameter parm_DrawPerson= new SqlParameter  (DRAWPERSON_PARM,SqlDbType.Char);
			parm_DrawPerson.SourceColumn = SalesOrderFormData.DRAWPERSON_FIELD;
			parm_DrawPerson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DrawPerson);

			SqlParameter parm_DrawDate= new SqlParameter  (DRAWDATE_PARM,SqlDbType.DateTime);
			parm_DrawDate.SourceColumn = SalesOrderFormData.DRAWDATE_FIELD;
			parm_DrawDate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DrawDate);

			SqlParameter parm_IvalidDate= new SqlParameter  (IVALIDDATE_PARM,SqlDbType.DateTime);
			parm_IvalidDate.SourceColumn = SalesOrderFormData.IVALIDDATE_FIELD;
			parm_IvalidDate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_IvalidDate);

			SqlParameter parm_Description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_Description.SourceColumn = SalesOrderFormData.DESCRIPTION_FIELD;
			parm_Description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_Description);

			SqlParameter parm_AccountDep= new SqlParameter  (ACCOUNTDEP_PARM,SqlDbType.Char);
			parm_AccountDep.SourceColumn = SalesOrderFormData.ACCOUNTDEP_FIELD;
			parm_AccountDep.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_AccountDep);

			return updateCommand;

		}

		public bool UpdateSalesOrderForm(SalesOrderFormData data)
		{
			if(dsCommand==null)
			{

				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.UpdateCommand = GetUpdateCommand();
			try 
			{
				dsCommand.Update(data,SalesOrderFormData.SALESORDERFORM_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesOrderFormData.SALESORDERFORM_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				else
				{
					data.AcceptChanges();
					return true;
				}

			}
			catch 
			{
				return false;
			}
		}

		#endregion

		#region  Delete Data

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_SalesOrderForm",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_orderformID= new SqlParameter  (ORDERFORMID_PARM,SqlDbType.Char);
			parm_orderformID.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_orderformID);
			
			return deleteCommand;
		}

		public bool DeleteSalesOrderForm(string orderformID)
		{
			
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[ORDERFORMID_PARM].Value = orderformID;
			
			try
			{
				deleteCommand.Connection.Open ();
				int i = deleteCommand.ExecuteNonQuery();
				deleteCommand.Connection.Close();
				if(i>=1)
					return true;
				else
					return false;
		
			}
			catch
			{
				return false;
			}
		}

		#endregion

	}
}
