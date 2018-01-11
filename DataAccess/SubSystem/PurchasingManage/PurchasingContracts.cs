using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	/// <summary>
	/// PurchasingContracts 的摘要说明。
	/// </summary>
	public class PurchasingContracts :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDCONTRACTID_PARM					= "@oldContractID";
	    private const String OLDDEPARTMENTID_PARM			 	= "@oldDepartmentID";
		private const String OLDCORCOMPANYID_PARM				= "@oldCorCompanyID";


		private const String CONTRACTNAME_PARM					= "@ContractName";
		private const String CONTRACTID_PARM					= "@ContractID";
		private const String CONTRACTNO_PARM					= "@ContractNo";
		private const String DEPARTMENTID_PARM					= "@DepartmentID";
		private const String CORCOMPANYID_PARM					= "@CorCompanyID";

		private const String PUB_CONTRACTTYPE_PARM				= "@PUB_ContractType";
		private const String MONEYTYPE_PARM						= "@MoneyType";
		private const String ALLSUM_PARM						= "@AllSum";
		private const String DISCOUNTSUM_PARM					= "@DiscountSum";
		private const String WITHOUTTAXSUM_PARM					= "@WithoutTaxSum";

		private const String TAXSUM_PARM						= "@TaxSum";
		private const String PUB_CEARINGFORM_PARM				= "@PUB_CearingForm";
		private const String PUB_TRAFFICMODE_PARM				= "@PUB_TrafficMode";
		private const String PUB_TAKEDELIVERYNO_PARM			= "@PUB_TakeDeliveryMode";
		private const String STATIONOFDISPATCH_PARM				= "@StationOfDispatch";

		private const String PLACEOFDELIVERY_PARM				= "@PlaceOfDelivery";
		private const String CARRIAGEBEAR_PARM					= "@CarriageBear";
		private const String SIGNADDRESS_PARM					= "@SignAddress";
		private const String SIGNDATE_PARM						= "@SignDate";
		private const String VALIDBEGINDATE_PARM				= "@ValidBeginDate";

		private const String VALIDENDDATE_PARM					= "@ValidEndDate";
		private const String NLEGALREPRESENTATI_PARM			= "@NLegalRepresentative";
		private const String NPRINCIPAL_PARM					= "@NPrincipal";
		private const String PLEGALREPRESENTATI_PARM			= "@PLegalRepresentative";
		private const String PPRINCIPAL_PARM					= "@PPrincipal";

		private const String ACCOUNTBANK_PARM					= "@AccountBank";
		private const String ACCOUNTS_PARM						= "@Accounts";
		private const String TAXNO_PARM							= "@TaxNo";
		private const String TRADEITEM_PARM						= "@TradeItem";
		private const String PHONE_PARM							= "@Phone";

		private const String FAX_PARM							= "@Fax";
		private const String TELEGRAM_PARM						= "@Telegram";
		private const String POSTCODE_PARM						= "@Postcode";
		private const String ADDRESS_PARM						= "@Address";
		private const String CONTACTPERSON_PARM					= "@ContactPerson";

		private const String STATUS_PARM						= "@Status";
		private const String DRAWPERSON_PARM					= "@DrawPerson";
		private const String DRAWLISTDATE_PARM					= "@DrawDate";
		private const String ACCOUNTDEP_PARM					= "@AccountDep";
		private const String INVALIDDATE_PARM					= "@InvalidDate";

		private const String DESCRIPTION_PARM					= "@Description";


		public PurchasingContracts()
		{
			da = new SqlDataAdapter();
			da.TableMappings.Add("Table" , PurchasingContractData.PURCHARINGCONTRACT_TABLE);
		}
		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 
			if(da!=null)
			{
				if(da.SelectCommand!=null)
				{
					if(da.SelectCommand.Connection!=null)
					{
						da.SelectCommand.Connection.Dispose();
					}
					da.SelectCommand.Dispose();
				}

				if(da.InsertCommand!=null)
				{
					if(da.InsertCommand.Connection!=null)
					{
						da.InsertCommand.Connection.Dispose();
					}
					da.InsertCommand.Dispose();
				}

				if(da.UpdateCommand!=null)
				{
					if(da.UpdateCommand.Connection!=null)
					{
						da.UpdateCommand.Connection.Dispose();
					}
					da.UpdateCommand.Dispose();
				}

//				if(da.DeleteCommand!=null)
//				{
//					if(da.DeleteCommand.Connection!=null)
//					{
//						da.DeleteCommand.Connection.Dispose();
//					}
//					da.DeleteCommand.Dispose();
//				}
				da.Dispose();
				da=null;
			}
		}

		#endregion

		# region 读取数据----采购合同/协议

		public PurchasingContractData LoadPurchasingContract()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			PurchasingContractData data = new PurchasingContractData();
			da.SelectCommand = GetLoadCommand();
			try
			{
				da.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}

		private SqlCommand GetLoadCommand()
		{
			SqlCommand load = new SqlCommand("Q_PurchasingContract" ,new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			return load;
		}
		#endregion

		#region 读取信息		
		//begin of Added by YiChangXin  2005-8-26
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)

				strsql = "select t.*,d1.name departmentname,c.name corcompanyname "
					+ "from (select * from TBL_PurchasingContract where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.DepartmentID "
					+ "left join tbl_correspondentcompany c on t.corcompanyid=c.companyid and t.departmentid=c.departmentid ";
		
			else 
		
				strsql = "select t.*,d1.name departmentname,c.name corcompanyname "
					+ "from tbl_purchasingcontract t "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.DepartmentID "
					+ "left join tbl_correspondentcompany c on t.corcompanyid=c.companyid and t.departmentid=c.departmentid";
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public PurchasingContractData LoadsPurchasingContract(string filter)
		{
			if ( da == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			PurchasingContractData data = new PurchasingContractData ();
			
			da.SelectCommand = GetLoadCommand(filter);
			
			try
			{
				da.Fill(data);
				
				return data;
			}
			catch
			{
				return null;				
			}
		}
		//end of add 2005-8-26
		#endregion		

		# region 添加记录-----采购合同/协议
		//begin of Modified by YiChangXin  2005-8-26
		public bool InsertPurchasingContract(PurchasingContractData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			da.InsertCommand = GetInsertCommand();
			da.Update(data,PurchasingContractData.PURCHARINGCONTRACT_TABLE);
			if(data.HasErrors)
			{
				data.Tables[PurchasingContractData.PURCHARINGCONTRACT_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand  GetInsertCommand ()
		{
			SqlCommand  insert = new SqlCommand("I_PurchasingContract" ,new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			// 1-5 参数 
			SqlParameter parm_contractname  = new SqlParameter(CONTRACTNAME_PARM ,SqlDbType.Char);
			parm_contractname.SourceColumn  = PurchasingContractData.CONTRACTNAME_FIELD;
			parm_contractname.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_contractname);

			SqlParameter parm_contractid  = new SqlParameter(CONTRACTID_PARM ,SqlDbType.Char);
			parm_contractid.SourceColumn  = PurchasingContractData.CONTRACTID_FIELD;
			parm_contractid.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_contractid);

			SqlParameter parm_contractno  = new SqlParameter(CONTRACTNO_PARM ,SqlDbType.VarChar);
			parm_contractno.SourceColumn  = PurchasingContractData.CONTRACTNO_FIELD;
			parm_contractno.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_contractno);

			SqlParameter parm_departid  = new SqlParameter(DEPARTMENTID_PARM ,SqlDbType.Char);
			parm_departid.SourceColumn  = PurchasingContractData.DEPARTMENTID_FIELD;
			parm_departid.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_corcompanyid  = new SqlParameter(CORCOMPANYID_PARM ,SqlDbType.Char);
			parm_corcompanyid.SourceColumn  = PurchasingContractData.CORCOMPANYID_FIELD;
			parm_corcompanyid.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_corcompanyid);

			// top 6-10  参数
			SqlParameter parm_pub_contracttype  = new SqlParameter(PUB_CONTRACTTYPE_PARM ,SqlDbType.Char);
			parm_pub_contracttype.SourceColumn  = PurchasingContractData.PUB_CONTRACTTYPE_FIELD;
			parm_pub_contracttype.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_pub_contracttype);

			SqlParameter parm_pub_moneytype  = new SqlParameter(MONEYTYPE_PARM ,SqlDbType.Char);
			parm_pub_moneytype.SourceColumn  = PurchasingContractData.MONEYTYPE_FIELD;
			parm_pub_moneytype.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_pub_moneytype);

			SqlParameter parm_allsum  = new SqlParameter(ALLSUM_PARM ,SqlDbType.Decimal);
			parm_allsum.SourceColumn  = PurchasingContractData.ALLSUM_FIELD;
			parm_allsum.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_allsum);

			SqlParameter parm_discountsum  = new SqlParameter(DISCOUNTSUM_PARM ,SqlDbType.Decimal);
			parm_discountsum.SourceColumn  = PurchasingContractData.DISCOUNTSUM_FIELD;
			parm_discountsum.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_discountsum);

			SqlParameter parm_withouttaxsum  = new SqlParameter(WITHOUTTAXSUM_PARM ,SqlDbType.Decimal);
			parm_withouttaxsum.SourceColumn  = PurchasingContractData.WITHOUTTAXSUM_FIELD;
			parm_withouttaxsum.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_withouttaxsum);

			// 11-15 参数
			SqlParameter parm_taxsum  = new SqlParameter(TAXSUM_PARM ,SqlDbType.Decimal);
			parm_taxsum.SourceColumn  = PurchasingContractData.TAXSUM_FIELD;
			parm_taxsum.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_taxsum);

			SqlParameter parm_pub_cearingform  = new SqlParameter(PUB_CEARINGFORM_PARM ,SqlDbType.Char);
			parm_pub_cearingform.SourceColumn  = PurchasingContractData.PUB_CEARINGFORM_FIELD;
			parm_pub_cearingform.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_pub_cearingform);

			SqlParameter parm_pub_trafficmode  = new SqlParameter(PUB_TRAFFICMODE_PARM ,SqlDbType.Char);
			parm_pub_trafficmode.SourceColumn  = PurchasingContractData.PUB_TRAFFICMODE_FIELD;
			parm_pub_trafficmode.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_pub_trafficmode);

			SqlParameter parm_pub_takedeliveryno  = new SqlParameter(PUB_TAKEDELIVERYNO_PARM ,SqlDbType.Char);
			parm_pub_takedeliveryno.SourceColumn  = PurchasingContractData.PUB_TAKEDELIVERYNO_FIELD;
			parm_pub_takedeliveryno.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_pub_takedeliveryno);

			SqlParameter parm_stationofdispatch  = new SqlParameter(STATIONOFDISPATCH_PARM ,SqlDbType.VarChar);
			parm_stationofdispatch.SourceColumn  = PurchasingContractData.STATIONOFDISPATCH_FIELD;
			parm_stationofdispatch.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_stationofdispatch);

			// 16-20 参数 
			SqlParameter parm_placeofdelivery  = new SqlParameter(PLACEOFDELIVERY_PARM ,SqlDbType.VarChar);
			parm_placeofdelivery.SourceColumn  = PurchasingContractData.PLACEOFDELIVERY_FIELD;
			parm_placeofdelivery.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_placeofdelivery);

			SqlParameter parm_carriagebear  = new SqlParameter(CARRIAGEBEAR_PARM ,SqlDbType.Char);
			parm_carriagebear.SourceColumn  = PurchasingContractData.CARRIAGEBEAR_FIELD;
			parm_carriagebear.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_carriagebear);

			SqlParameter parm_signaddress  = new SqlParameter(SIGNADDRESS_PARM ,SqlDbType.Char);
			parm_signaddress.SourceColumn  = PurchasingContractData.SIGNADDRESS_FIELD;
			parm_signaddress.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_signaddress);

			SqlParameter parm_signdate = new SqlParameter(SIGNDATE_PARM ,SqlDbType.DateTime);
			parm_signdate.SourceColumn  = PurchasingContractData.SIGNDATE_FIELD;
			parm_signdate.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_signdate);

			SqlParameter parm_validbegin = new SqlParameter(VALIDBEGINDATE_PARM ,SqlDbType.DateTime);
			parm_validbegin.SourceColumn  = PurchasingContractData.VALIDBEGINDATE_FIELD;
			parm_validbegin.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_validbegin);

			// 21-25 参数
			SqlParameter parm_validend = new SqlParameter(VALIDENDDATE_PARM ,SqlDbType.DateTime);
			parm_validend.SourceColumn  = PurchasingContractData.VALIDENDDATE_FIELD;
			parm_validend.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_validend);

			SqlParameter parm_nlegalrepresentati = new SqlParameter(NLEGALREPRESENTATI_PARM ,SqlDbType.Char);
			parm_nlegalrepresentati.SourceColumn  = PurchasingContractData.NLEGALREPRESENTATI_FIELD;
			parm_nlegalrepresentati.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_nlegalrepresentati);

			SqlParameter parm_nprincipal = new SqlParameter(NPRINCIPAL_PARM ,SqlDbType.Char);
			parm_nprincipal.SourceColumn  = PurchasingContractData.NPRINCIPAL_FIELD;
			parm_nprincipal.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_nprincipal);

			SqlParameter parm_plegalrepresentati = new SqlParameter(PLEGALREPRESENTATI_PARM ,SqlDbType.Char);
			parm_plegalrepresentati.SourceColumn  = PurchasingContractData.PLEGALREPRESENTATI_FIELD;
			parm_plegalrepresentati.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_plegalrepresentati);

			SqlParameter parm_pprincipal = new SqlParameter(PPRINCIPAL_PARM ,SqlDbType.Char);
			parm_pprincipal.SourceColumn  = PurchasingContractData.PPRINCIPAL_FIELD;
			parm_pprincipal.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_pprincipal);

			// 26-30 参数
			SqlParameter parm_accountbank = new SqlParameter(ACCOUNTBANK_PARM ,SqlDbType.Char);
			parm_accountbank.SourceColumn  = PurchasingContractData.ACCOUNTBANK_FIELD;
			parm_accountbank.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_accountbank);

			SqlParameter parm_accounts = new SqlParameter(ACCOUNTS_PARM ,SqlDbType.Char);
			parm_accounts.SourceColumn  = PurchasingContractData.ACCOUNTS_FIELD;
			parm_accounts.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_accounts);

			SqlParameter parm_taxno = new SqlParameter(TAXNO_PARM ,SqlDbType.Char);
			parm_taxno.SourceColumn  = PurchasingContractData.TAXNO_FIELD;
			parm_taxno.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_taxno);

			SqlParameter parm_tradeitem = new SqlParameter(TRADEITEM_PARM ,SqlDbType.VarChar);
			parm_tradeitem.SourceColumn  = PurchasingContractData.TRADEITEM_FIELD;
			parm_tradeitem.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_tradeitem);

			SqlParameter parm_phone = new SqlParameter(PHONE_PARM ,SqlDbType.Char);
			parm_phone.SourceColumn  = PurchasingContractData.PHONE_FIELD;
			parm_phone.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_phone);

			// 31-35 参数
			SqlParameter parm_fax = new SqlParameter(FAX_PARM ,SqlDbType.Char);
			parm_fax.SourceColumn  = PurchasingContractData.FAX_FIELD;
			parm_fax.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_fax);

			SqlParameter parm_telegram = new SqlParameter(TELEGRAM_PARM ,SqlDbType.Char);
			parm_telegram.SourceColumn  = PurchasingContractData.TELEGRAM_FIELD;
			parm_telegram.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_telegram);

			SqlParameter parm_postcode = new SqlParameter(POSTCODE_PARM ,SqlDbType.Char);
			parm_postcode.SourceColumn  = PurchasingContractData.POSTCODE_FIELD;
			parm_postcode.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_postcode);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM ,SqlDbType.Char);
			parm_address.SourceColumn  = PurchasingContractData.ADDRESS_FIELD;
			parm_address.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_address);

			SqlParameter parm_contactperson = new SqlParameter(CONTACTPERSON_PARM ,SqlDbType.Char);
			parm_contactperson.SourceColumn  = PurchasingContractData.CONTACTPERSON_FIELD;
			parm_contactperson.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_contactperson);

			// 36-40 参数
			SqlParameter parm_status = new SqlParameter(STATUS_PARM ,SqlDbType.Char);
			parm_status.SourceColumn  = PurchasingContractData.STATUS_FIELD;
			parm_status.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_status);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM ,SqlDbType.Char);
			parm_drawperson.SourceColumn  = PurchasingContractData.DRAWPERSON_FIELD;
			parm_drawperson.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawlistdate= new SqlParameter(DRAWLISTDATE_PARM ,SqlDbType.DateTime);
			parm_drawlistdate.SourceColumn  = PurchasingContractData.DRAWLISTDATE_FIELD;
			parm_drawlistdate.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_drawlistdate);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM ,SqlDbType.Char);
			parm_accountdep.SourceColumn  = PurchasingContractData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_accountdep);

			SqlParameter parm_invaliddate = new SqlParameter(INVALIDDATE_PARM ,SqlDbType.DateTime);
			parm_invaliddate.SourceColumn  = PurchasingContractData.INVALIDDATE_FIELD;
			parm_invaliddate.Direction =  ParameterDirection.Input;
			insert.Parameters.Add(parm_invaliddate);

			//41 参数

			SqlParameter parm_description  = new SqlParameter(DESCRIPTION_PARM ,SqlDbType.VarChar);// YCX修改
			parm_description.SourceColumn  = PurchasingContractData.DESCRIPTION_FIELD;
			parm_description.Direction  =  ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;

		}
		//End of Modified 2005-8-26
		#endregion
	
		#region 更新记录-----采购合同/协议
		//begin of Modified by YiChangXin  2005-8-26
		public bool UpdatePurchasingContract (PurchasingContractData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			da.UpdateCommand = GetUpdateCommand();
 
			da.Update(data,PurchasingContractData.PURCHARINGCONTRACT_TABLE);
	 
			if(data.HasErrors)
			{
				data.Tables[PurchasingContractData.PURCHARINGCONTRACT_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
		 
	 
			else
			{
				data.AcceptChanges();
				return true;
			}
		
		}

		private SqlCommand GetUpdateCommand ()
		{
			SqlCommand  update = new SqlCommand("U_PurchasingContract" ,new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			// 1-5 参数 和 3 主键原值参数
			SqlParameter parm_contractname  = new SqlParameter(CONTRACTNAME_PARM ,SqlDbType.Char);
			parm_contractname.SourceColumn  = PurchasingContractData.CONTRACTNAME_FIELD;
			parm_contractname.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_contractname);


			SqlParameter parm_contractid  = new SqlParameter(CONTRACTID_PARM ,SqlDbType.Char);
			parm_contractid.SourceColumn  = PurchasingContractData.CONTRACTID_FIELD;
			parm_contractid.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_contractid);

			SqlParameter parm_contractno  = new SqlParameter(CONTRACTNO_PARM ,SqlDbType.VarChar);
			parm_contractno.SourceColumn  = PurchasingContractData.CONTRACTNO_FIELD;
			parm_contractno.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_contractno);


			

			SqlParameter parm_departid  = new SqlParameter(DEPARTMENTID_PARM ,SqlDbType.Char);
			parm_departid.SourceColumn  = PurchasingContractData.DEPARTMENTID_FIELD;
			parm_departid.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_departid);


			

			SqlParameter parm_corcompanyid  = new SqlParameter(CORCOMPANYID_PARM ,SqlDbType.Char);   
			parm_corcompanyid.SourceColumn  = PurchasingContractData.CORCOMPANYID_FIELD;
			parm_corcompanyid.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_corcompanyid);

			// top 6-10  参数
			SqlParameter parm_pub_contracttype  = new SqlParameter(PUB_CONTRACTTYPE_PARM ,SqlDbType.Char);
			parm_pub_contracttype.SourceColumn  = PurchasingContractData.PUB_CONTRACTTYPE_FIELD;
			parm_pub_contracttype.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_pub_contracttype);

			SqlParameter parm_pub_moneytype  = new SqlParameter(MONEYTYPE_PARM ,SqlDbType.Char);
			parm_pub_moneytype.SourceColumn  = PurchasingContractData.MONEYTYPE_FIELD;
			parm_pub_moneytype.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_pub_moneytype);

			SqlParameter parm_allsum  = new SqlParameter(ALLSUM_PARM ,SqlDbType.Decimal);
			parm_allsum.SourceColumn  = PurchasingContractData.ALLSUM_FIELD;
			parm_allsum.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_allsum);

			SqlParameter parm_discountsum  = new SqlParameter(DISCOUNTSUM_PARM ,SqlDbType.Decimal);
			parm_discountsum.SourceColumn  = PurchasingContractData.DISCOUNTSUM_FIELD;
			parm_discountsum.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_discountsum);

			SqlParameter parm_withouttaxsum  = new SqlParameter(WITHOUTTAXSUM_PARM ,SqlDbType.Decimal);
			parm_withouttaxsum.SourceColumn  = PurchasingContractData.WITHOUTTAXSUM_FIELD;
			parm_withouttaxsum.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_withouttaxsum);

			// 11-15 参数
			SqlParameter parm_taxsum  = new SqlParameter(TAXSUM_PARM ,SqlDbType.Decimal);
			parm_taxsum.SourceColumn  = PurchasingContractData.TAXSUM_FIELD;
			parm_taxsum.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_taxsum);

			SqlParameter parm_pub_cearingform  = new SqlParameter(PUB_CEARINGFORM_PARM ,SqlDbType.Char);
			parm_pub_cearingform.SourceColumn  = PurchasingContractData.PUB_CEARINGFORM_FIELD;
			parm_pub_cearingform.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_pub_cearingform);

			SqlParameter parm_pub_trafficmode  = new SqlParameter(PUB_TRAFFICMODE_PARM ,SqlDbType.Char);
			parm_pub_trafficmode.SourceColumn  = PurchasingContractData.PUB_TRAFFICMODE_FIELD;
			parm_pub_trafficmode.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_pub_trafficmode);

			SqlParameter parm_pub_takedeliveryno  = new SqlParameter(PUB_TAKEDELIVERYNO_PARM ,SqlDbType.Char);
			parm_pub_takedeliveryno.SourceColumn  = PurchasingContractData.PUB_TAKEDELIVERYNO_FIELD;
			parm_pub_takedeliveryno.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_pub_takedeliveryno);

			SqlParameter parm_stationofdispatch  = new SqlParameter(STATIONOFDISPATCH_PARM ,SqlDbType.VarChar);
			parm_stationofdispatch.SourceColumn  = PurchasingContractData.STATIONOFDISPATCH_FIELD;
			parm_stationofdispatch.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_stationofdispatch);

			// 16-20 参数 
			SqlParameter parm_placeofdelivery  = new SqlParameter(PLACEOFDELIVERY_PARM ,SqlDbType.VarChar);
			parm_placeofdelivery.SourceColumn  = PurchasingContractData.PLACEOFDELIVERY_FIELD;
			parm_placeofdelivery.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_placeofdelivery);

			SqlParameter parm_carriagebear  = new SqlParameter(CARRIAGEBEAR_PARM ,SqlDbType.Char);
			parm_carriagebear.SourceColumn  = PurchasingContractData.CARRIAGEBEAR_FIELD;
			parm_carriagebear.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_carriagebear);

			SqlParameter parm_signaddress  = new SqlParameter(SIGNADDRESS_PARM ,SqlDbType.Char);
			parm_signaddress.SourceColumn  = PurchasingContractData.SIGNADDRESS_FIELD;
			parm_signaddress.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_signaddress);

			SqlParameter parm_signdate = new SqlParameter(SIGNDATE_PARM ,SqlDbType.DateTime);
			parm_signdate.SourceColumn  = PurchasingContractData.SIGNDATE_FIELD;
			parm_signdate.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_signdate);

			SqlParameter parm_validbegin = new SqlParameter(VALIDBEGINDATE_PARM ,SqlDbType.DateTime);
			parm_validbegin.SourceColumn  = PurchasingContractData.VALIDBEGINDATE_FIELD;
			parm_validbegin.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_validbegin);

			// 21-25 参数
			SqlParameter parm_validend = new SqlParameter(VALIDENDDATE_PARM ,SqlDbType.DateTime);
			parm_validend.SourceColumn  = PurchasingContractData.VALIDENDDATE_FIELD;
			parm_validend.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_validend);

			SqlParameter parm_nlegalrepresentati = new SqlParameter(NLEGALREPRESENTATI_PARM ,SqlDbType.Char);
			parm_nlegalrepresentati.SourceColumn  = PurchasingContractData.NLEGALREPRESENTATI_FIELD;
			parm_nlegalrepresentati.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_nlegalrepresentati);

			SqlParameter parm_nprincipal = new SqlParameter(NPRINCIPAL_PARM ,SqlDbType.Char);
			parm_nprincipal.SourceColumn  = PurchasingContractData.NPRINCIPAL_FIELD;
			parm_nprincipal.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_nprincipal);

			SqlParameter parm_plegalrepresentati = new SqlParameter(PLEGALREPRESENTATI_PARM ,SqlDbType.Char);
			parm_plegalrepresentati.SourceColumn  = PurchasingContractData.PLEGALREPRESENTATI_FIELD;
			parm_plegalrepresentati.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_plegalrepresentati);

			SqlParameter parm_pprincipal = new SqlParameter(PPRINCIPAL_PARM ,SqlDbType.Char);
			parm_pprincipal.SourceColumn  = PurchasingContractData.PPRINCIPAL_FIELD;
			parm_pprincipal.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_pprincipal);

			// 26-30 参数
			SqlParameter parm_accountbank = new SqlParameter(ACCOUNTBANK_PARM ,SqlDbType.Char);
			parm_accountbank.SourceColumn  = PurchasingContractData.ACCOUNTBANK_FIELD;
			parm_accountbank.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_accountbank);

			SqlParameter parm_accounts = new SqlParameter(ACCOUNTS_PARM ,SqlDbType.Char);
			parm_accounts.SourceColumn  = PurchasingContractData.ACCOUNTS_FIELD;
			parm_accounts.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_accounts);

			SqlParameter parm_taxno = new SqlParameter(TAXNO_PARM ,SqlDbType.Char);
			parm_taxno.SourceColumn  = PurchasingContractData.TAXNO_FIELD;
			parm_taxno.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_taxno);

			SqlParameter parm_tradeitem = new SqlParameter(TRADEITEM_PARM ,SqlDbType.VarChar);
			parm_tradeitem.SourceColumn  = PurchasingContractData.TRADEITEM_FIELD;
			parm_tradeitem.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_tradeitem);

			SqlParameter parm_phone = new SqlParameter(PHONE_PARM ,SqlDbType.Char);
			parm_phone.SourceColumn  = PurchasingContractData.PHONE_FIELD;
			parm_phone.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_phone);

			// 31-35 参数
			SqlParameter parm_fax = new SqlParameter(FAX_PARM ,SqlDbType.Char);
			parm_fax.SourceColumn  = PurchasingContractData.FAX_FIELD;
			parm_fax.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_fax);

			SqlParameter parm_telegram = new SqlParameter(TELEGRAM_PARM ,SqlDbType.Char);
			parm_telegram.SourceColumn  = PurchasingContractData.TELEGRAM_FIELD;
			parm_telegram.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_telegram);

			SqlParameter parm_postcode = new SqlParameter(POSTCODE_PARM ,SqlDbType.Char);
			parm_postcode.SourceColumn  = PurchasingContractData.POSTCODE_FIELD;
			parm_postcode.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_postcode);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM ,SqlDbType.Char);
			parm_address.SourceColumn  = PurchasingContractData.ADDRESS_FIELD;
			parm_address.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_address);

			SqlParameter parm_contactperson = new SqlParameter(CONTACTPERSON_PARM ,SqlDbType.Char);
			parm_contactperson.SourceColumn  = PurchasingContractData.CONTACTPERSON_FIELD;
			parm_contactperson.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_contactperson);

			// 36-40 参数
			SqlParameter parm_status = new SqlParameter(STATUS_PARM ,SqlDbType.Char);
			parm_status.SourceColumn  = PurchasingContractData.STATUS_FIELD;
			parm_status.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_status);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM ,SqlDbType.Char);
			parm_drawperson.SourceColumn  = PurchasingContractData.DRAWPERSON_FIELD;
			parm_drawperson.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawlistdate= new SqlParameter(DRAWLISTDATE_PARM ,SqlDbType.DateTime);
			parm_drawlistdate.SourceColumn  = PurchasingContractData.DRAWLISTDATE_FIELD;
			parm_drawlistdate.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_drawlistdate);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM ,SqlDbType.Char);
			parm_accountdep.SourceColumn  = PurchasingContractData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_accountdep);

			SqlParameter parm_invaliddate = new SqlParameter(INVALIDDATE_PARM ,SqlDbType.DateTime);
			parm_invaliddate.SourceColumn  = PurchasingContractData.INVALIDDATE_FIELD;
			parm_invaliddate.Direction =  ParameterDirection.Input;
			update.Parameters.Add(parm_invaliddate);

			//41 参数

			SqlParameter parm_description  = new SqlParameter(DESCRIPTION_PARM ,SqlDbType.VarChar);
			parm_description.SourceColumn  = PurchasingContractData.DESCRIPTION_FIELD;
			parm_description.Direction  =  ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;

		}

		//End of Modified 2005-8-26
		#endregion

		#region 删除记录----采购合同/协议
		//begin of Modified by YiChangXin  2005-8-26
		public bool DeletePurchasingContract (string contractid)
		{
			SqlCommand deletecommand = GetDeleteCommand ();
			deletecommand.Parameters[CONTRACTID_PARM].Value		= contractid;
			
			//			try
		{
			deletecommand.Connection.Open();
			if(deletecommand.ExecuteNonQuery()>0)
				return true;
			else
				return false;
		}
			//			catch
		{
			return false;
		}
			//			finally
		{
			deletecommand.Connection.Close();
			deletecommand.Connection.Dispose();
			deletecommand.Dispose();
		}
		}

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand  delete = new SqlCommand("D_PurchasingContract" ,new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_contractid  = new SqlParameter(CONTRACTID_PARM ,SqlDbType.Char);
			parm_contractid.Direction =  ParameterDirection.Input;
			delete.Parameters.Add(parm_contractid);

			return delete;

		}
		//End of Modified 2005-8-26
		#endregion
	}
}