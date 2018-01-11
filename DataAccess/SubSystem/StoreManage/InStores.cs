using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{

	public class InStores:IDisposable

	{
		#region  定义常量及初始化

		private SqlDataAdapter dsCommand;
		private const String INSTORES_PARM        = "out_InStores"; 

		private const String ISRID_PARM             = "@isrid";
		private const String ISRNAME_PARM           = "@isrname";
		private const String REDBLUEREMARK_PARM     = "@redblueremark";
		private const String DEPARTMENTID_PARM      = "@departmentid";
		private const String HOUSEID_PARM           = "@houseid";

		private const String CORCOMPANY_PARM           = "@corcompany";
		private const String INTYPE_PARM               = "@intype";
		private const String INCATEGORY_PARM            = "@incategory";
		private const String INDATE_PARM               = "@indate";
		private const String TOTAL_PARM                = "@allsum";

		private const String DISCOUNTTOTAL_PARM        = "@discountsum";
		private const string TOTALWITHOUTTAX_PARM      = "@withouttaxsum";
		private const String TAXTOTAL_PARM				= "@taxsum";
		private const String DRAWDEPARTMENT_PARM       = "@drawdepartment";
		private const String DRAWPERSON_PARM           = "@drawperson";

		private const String DRAWDATE_PARM             = "@drawdate";
		private const String CHECKER_PARM              = "@checker";
		private const String CUSTODIAN_PARM            = "@custodian";
		private const String BUSINESSPERSON_PARM       = "@businessperson";
		private const String FINANCIALPERSON_PARM      = "@financialperson";

		private const String FINANCIALREMARK_PARM      = "@financialremark";
		private const String FINANCIALDATE_PARM        = "@financialdate";
		private const String INVENTORYPERSON_PARM      = "@inventoryperson";
		private const String INVENTORYREMARK_PARM      = "@inventoryremark";
		private const String INVENTORYDATE_PARM        = "@inventorydate";

		private const String RECORDID_PARM             = "@recordid";
		private const String ACCOUNTDEP_PARM           = "@accountdep";
		private const String CONTRACTID_PARM		    = "@contractid";
		private const String STATUS_PARM				= "@status";
		private const String DESCRIPTION_PARM			= "@description";

		public InStores()
		{
			dsCommand = new SqlDataAdapter();
        
			dsCommand.TableMappings.Add("Table", InStoreData.INSTORE_TABLE);
		}
		
		#endregion

		#region 释放资源
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true); // as a service to those who might inherit from us
		}


		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; // we're being collected, so let the GC take care of this object

			if (dsCommand != null)
			{
				if(dsCommand.SelectCommand != null)
				{
					if( dsCommand.SelectCommand.Connection != null  )
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				} 
				if(dsCommand.DeleteCommand != null)
				{
					if( dsCommand.DeleteCommand.Connection != null  )
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}    
				if(dsCommand.UpdateCommand != null)
				{
					if( dsCommand.UpdateCommand.Connection != null  )
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}    
				if(dsCommand.InsertCommand != null)
				{
					if( dsCommand.InsertCommand.Connection != null  )
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}    
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion

		#region 读取所有信息
		
		private SqlCommand GetLoadAllCommand()
		{
		
			
			SqlCommand	loadsCommand = new SqlCommand("Q_Instores",new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.StoredProcedure;
				
            
			return loadsCommand;
		}

		public InStoreData LoadInStore()
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			InStoreData data = new InStoreData();
			
			dsCommand.SelectCommand = GetLoadAllCommand();
			
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

		#region 读取采购退货单信息
		//begin of Added by YiChangxin 2005-8-26
		private SqlCommand GetLoadReturnPurchaseInvoiceCommand()
		{
			SqlCommand	loadsCommand = new SqlCommand("Q_InStoreRecrod",new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.StoredProcedure;
			return loadsCommand;
		}

		public InStoreData LoadReturnPurchaseInvoice()
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			InStoreData data = new InStoreData();
			
			dsCommand.SelectCommand = GetLoadReturnPurchaseInvoiceCommand();
			
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
		//End of Added by YiChangxin 2005-8-26
		#endregion

		#region 读取入库单信息		-----yichangxin	加了一个虚字段 2005-9-20
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)
				strsql = "select t.*,d1.name departmentname,h.isrname recordname,s.name housename,c.name corcompanyname,pc.contractname,d2.name drawdepartmentname,"
					+ "s1.name drawpersonname,s2.name checkername,s3.name custodianname,s4.name businesspersonname "
					+ "from (select * from tbl_instore where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_PurchasingContract pc  ON pc.contractid =t.contractid "
					+ "left JOIN TBL_instore h  ON h.isrid =t.recordid " 
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.businessperson "
					+ "left join tbl_storehouse s on t.houseid=s.houseid "
					+ "left join tbl_correspondentcompany c on t.corcompany=c.companyid and t.departmentid=c.departmentid";
			else
				strsql = "select t.*,d1.name departmentname,h.isrname recordname,s.name housename,c.name corcompanyname,pc.contractname,d2.name drawdepartmentname,"
					+ "s1.name drawpersonname,s2.name checkername,s3.name custodianname,s4.name businesspersonname "
					+ "from tbl_instore t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_instore h  ON h.isrid =t.recordid " 
					+ "left JOIN TBL_PurchasingContract pc  ON pc.contractid =t.contractid "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.businessperson "
					+ "left join tbl_storehouse s on t.houseid=s.houseid "
					+ "left join tbl_correspondentcompany c on t.corcompany=c.companyid and t.departmentid=c.departmentid";
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public InStoreData LoadInStore(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			InStoreData data = new InStoreData();
			
			dsCommand.SelectCommand = GetLoadCommand(filter);
			
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
		
		#region 添加信息
		private SqlCommand GetInsertCommand()
		{
			
	
			SqlCommand insertCommand = new SqlCommand("I_InStore",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;


			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char, 10);
			parm_departmentid.SourceColumn = InStoreData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char, 28);
			parm_isrid.SourceColumn = InStoreData.ISRID_FIELD;
			parm_isrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_isrid);
				
			SqlParameter parm_isrname = new SqlParameter(ISRNAME_PARM, SqlDbType.Char, 40);
			parm_isrname.SourceColumn = InStoreData.ISRNAME_FIELD;
			parm_isrname.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_isrname);

			SqlParameter parm_redblueremark = new SqlParameter(REDBLUEREMARK_PARM, SqlDbType.SmallInt);
			parm_redblueremark.SourceColumn = InStoreData.REDBLUEREMARK_FIELD;
			parm_redblueremark.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_redblueremark);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM, SqlDbType.Char, 4);
			parm_houseid.SourceColumn = InStoreData.HOUSEID_FIELD;
			parm_houseid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_corcompany = new SqlParameter(CORCOMPANY_PARM, SqlDbType.Char, 10);
			parm_corcompany.SourceColumn = InStoreData.CORCOMPANY_FIELD;
			parm_corcompany.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_corcompany);

			SqlParameter parm_intype = new SqlParameter(INTYPE_PARM, SqlDbType.Char, 16);
			parm_intype.SourceColumn = InStoreData.INTYPE_FIELD;
			parm_intype.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_intype);

			SqlParameter parm_incategory = new SqlParameter(INCATEGORY_PARM, SqlDbType.Char, 16);
			parm_incategory.SourceColumn = InStoreData.INCATEGORY_FIELD;
			parm_incategory.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_incategory);

			SqlParameter parm_indate = new SqlParameter(INDATE_PARM, SqlDbType.DateTime);
			parm_indate.SourceColumn = InStoreData.INDATE_FIELD;
			parm_indate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_indate);

			SqlParameter parm_total = new SqlParameter(TOTAL_PARM, SqlDbType.Decimal);
			parm_total.SourceColumn = InStoreData.ALLSUM_FIELD;
			parm_total.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_total);

			SqlParameter parm_discounttotal = new SqlParameter(DISCOUNTTOTAL_PARM, SqlDbType.Decimal);
			parm_discounttotal.SourceColumn = InStoreData.DISCOUNTSUM_FIELD;
			parm_discounttotal.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discounttotal);

			SqlParameter parm_totalwithouttax = new SqlParameter(TOTALWITHOUTTAX_PARM, SqlDbType.Decimal);
			parm_totalwithouttax.SourceColumn = InStoreData.WITHOUTTAXSUM_FIELD;
			parm_totalwithouttax.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_totalwithouttax);

			SqlParameter parm_taxtotal = new SqlParameter(TAXTOTAL_PARM, SqlDbType.Decimal);
			parm_taxtotal.SourceColumn = InStoreData.TAXSUM_FIELD;
			parm_taxtotal.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxtotal);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM, SqlDbType.Char, 10);
			parm_drawdepartment.SourceColumn = InStoreData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM, SqlDbType.Char,10);
			parm_drawperson.SourceColumn = InStoreData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM, SqlDbType.DateTime);
			parm_drawdate.SourceColumn = InStoreData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_checker= new SqlParameter(CHECKER_PARM, SqlDbType.Char, 10);
			parm_checker.SourceColumn = InStoreData.CHECKER_FIELD;
			parm_checker.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_checker);

			SqlParameter parm_custodian = new SqlParameter(CUSTODIAN_PARM, SqlDbType.Char,10);
			parm_custodian.SourceColumn = InStoreData.CUSTODIAN_FIELD;
			parm_custodian.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_custodian);

			SqlParameter parm_businessperson = new SqlParameter(BUSINESSPERSON_PARM, SqlDbType.Char,10);
			parm_businessperson.SourceColumn = InStoreData.BUSINESSPERSON_FIELD;
			parm_businessperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_businessperson);

			SqlParameter parm_financialperson = new SqlParameter(FINANCIALPERSON_PARM, SqlDbType.Char, 18);
			parm_financialperson.SourceColumn = InStoreData.FINANCIALPERSON_FIELD;
			parm_financialperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_financialperson);

			SqlParameter parm_financialremark = new SqlParameter(FINANCIALREMARK_PARM, SqlDbType.Char, 10);
			parm_financialremark.SourceColumn = InStoreData.FINANCIALREMARK_FIELD;
			parm_financialremark.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_financialremark);

			SqlParameter parm_financialdate = new SqlParameter(FINANCIALDATE_PARM, SqlDbType.DateTime);
			parm_financialdate.SourceColumn = InStoreData.FINANCIALDATE_FIELD;
			parm_financialdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_financialdate);

			SqlParameter parm_inventoryporson = new SqlParameter(INVENTORYPERSON_PARM, SqlDbType.Char,18);
			parm_inventoryporson.SourceColumn = InStoreData.INVENTORYPERSON_FIELD;
			parm_inventoryporson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_inventoryporson);

			SqlParameter parm_inventoryremark = new SqlParameter(INVENTORYREMARK_PARM, SqlDbType.Char, 10);
			parm_inventoryremark.SourceColumn = InStoreData.INVENTORYREMARK_FIELD;
			parm_inventoryremark.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_inventoryremark);

			SqlParameter parm_inventorydate= new SqlParameter(INVENTORYDATE_PARM, SqlDbType.DateTime);
			parm_inventorydate.SourceColumn = InStoreData.INVENTORYDATE_FIELD;
			parm_inventorydate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_inventorydate);

			SqlParameter parm_recordid = new SqlParameter(RECORDID_PARM, SqlDbType.Char,28);
			parm_recordid.SourceColumn = InStoreData.RECORDID_FIELD;
			parm_recordid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_recordid);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM, SqlDbType.Char, 10);
			parm_accountdep.SourceColumn = InStoreData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char, 28);
			parm_contractid.SourceColumn = InStoreData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_contractid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char, 16);
			parm_status.SourceColumn = InStoreData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_status);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 1000);
			parm_description.SourceColumn = InStoreData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);
			          
			return insertCommand;
		}

		public bool InsertInStore(InStoreData data)			
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.InsertCommand = GetInsertCommand();
           
			try
			{
				dsCommand.Update(data,InStoreData.INSTORE_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[InStoreData.INSTORE_TABLE].GetErrors()[0].ClearErrors();
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
	
		#region 更新部门信息
		private SqlCommand GetUpdateCommand()
		{
			
			SqlCommand updateCommand = new SqlCommand("U_Instore",new SqlConnection (ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char, 10);
			parm_departmentid.SourceColumn = InStoreData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char, 28);
			parm_isrid.SourceColumn = InStoreData.ISRID_FIELD;
			parm_isrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_isrid);
				
			SqlParameter parm_isrname = new SqlParameter(ISRNAME_PARM, SqlDbType.Char, 40);
			parm_isrname.SourceColumn = InStoreData.ISRNAME_FIELD;
			parm_isrname.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_isrname);

			SqlParameter parm_redblueremark = new SqlParameter(REDBLUEREMARK_PARM, SqlDbType.SmallInt);
			parm_redblueremark.SourceColumn = InStoreData.REDBLUEREMARK_FIELD;
			parm_redblueremark.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_redblueremark);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM, SqlDbType.Char, 4);
			parm_houseid.SourceColumn = InStoreData.HOUSEID_FIELD;
			parm_houseid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_corcompany = new SqlParameter(CORCOMPANY_PARM, SqlDbType.Char, 10);
			parm_corcompany.SourceColumn = InStoreData.CORCOMPANY_FIELD;
			parm_corcompany.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_corcompany);

			SqlParameter parm_intype = new SqlParameter(INTYPE_PARM, SqlDbType.Char, 16);
			parm_intype.SourceColumn = InStoreData.INTYPE_FIELD;
			parm_intype.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_intype);

			SqlParameter parm_incategory = new SqlParameter(INCATEGORY_PARM, SqlDbType.Char, 16);
			parm_incategory.SourceColumn = InStoreData.INCATEGORY_FIELD;
			parm_incategory.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_incategory);

			SqlParameter parm_indate = new SqlParameter(INDATE_PARM, SqlDbType.DateTime);
			parm_indate.SourceColumn = InStoreData.INDATE_FIELD;
			parm_indate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_indate);

			SqlParameter parm_total = new SqlParameter(TOTAL_PARM, SqlDbType.Decimal);
			parm_total.SourceColumn = InStoreData.ALLSUM_FIELD;
			parm_total.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_total);

			SqlParameter parm_discounttotal = new SqlParameter(DISCOUNTTOTAL_PARM, SqlDbType.Decimal);
			parm_discounttotal.SourceColumn = InStoreData.DISCOUNTSUM_FIELD;
			parm_discounttotal.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discounttotal);

			SqlParameter parm_totalwithouttax = new SqlParameter(TOTALWITHOUTTAX_PARM, SqlDbType.Decimal);
			parm_totalwithouttax.SourceColumn = InStoreData.WITHOUTTAXSUM_FIELD;
			parm_totalwithouttax.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_totalwithouttax);

			SqlParameter parm_taxtotal = new SqlParameter(TAXTOTAL_PARM, SqlDbType.Decimal);
			parm_taxtotal.SourceColumn = InStoreData.TAXSUM_FIELD;
			parm_taxtotal.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxtotal);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM, SqlDbType.Char, 10);
			parm_drawdepartment.SourceColumn = InStoreData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM, SqlDbType.Char,10);
			parm_drawperson.SourceColumn = InStoreData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM, SqlDbType.DateTime);
			parm_drawdate.SourceColumn = InStoreData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_checker= new SqlParameter(CHECKER_PARM, SqlDbType.Char, 10);
			parm_checker.SourceColumn = InStoreData.CHECKER_FIELD;
			parm_checker.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_checker);

			SqlParameter parm_custodian = new SqlParameter(CUSTODIAN_PARM, SqlDbType.Char,10);
			parm_custodian.SourceColumn = InStoreData.CUSTODIAN_FIELD;
			parm_custodian.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_custodian);

			SqlParameter parm_businessperson = new SqlParameter(BUSINESSPERSON_PARM, SqlDbType.Char,10);
			parm_businessperson.SourceColumn = InStoreData.BUSINESSPERSON_FIELD;
			parm_businessperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_businessperson);

			SqlParameter parm_financialperson = new SqlParameter(FINANCIALPERSON_PARM, SqlDbType.Char, 18);
			parm_financialperson.SourceColumn = InStoreData.FINANCIALPERSON_FIELD;
			parm_financialperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_financialperson);

			SqlParameter parm_financialremark = new SqlParameter(FINANCIALREMARK_PARM, SqlDbType.Char, 10);
			parm_financialremark.SourceColumn = InStoreData.FINANCIALREMARK_FIELD;
			parm_financialremark.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_financialremark);

			SqlParameter parm_financialdate = new SqlParameter(FINANCIALDATE_PARM, SqlDbType.DateTime);
			parm_financialdate.SourceColumn = InStoreData.FINANCIALDATE_FIELD;
			parm_financialdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_financialdate);

			SqlParameter parm_inventoryporson = new SqlParameter(INVENTORYPERSON_PARM, SqlDbType.Char,18);
			parm_inventoryporson.SourceColumn = InStoreData.INVENTORYPERSON_FIELD;
			parm_inventoryporson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_inventoryporson);

			SqlParameter parm_inventoryremark = new SqlParameter(INVENTORYREMARK_PARM, SqlDbType.Char, 10);
			parm_inventoryremark.SourceColumn = InStoreData.INVENTORYREMARK_FIELD;
			parm_inventoryremark.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_inventoryremark);

			SqlParameter parm_inventorydate= new SqlParameter(INVENTORYDATE_PARM, SqlDbType.DateTime);
			parm_inventorydate.SourceColumn = InStoreData.INVENTORYDATE_FIELD;
			parm_inventorydate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_inventorydate);

			SqlParameter parm_recordid = new SqlParameter(RECORDID_PARM, SqlDbType.Char,28);
			parm_recordid.SourceColumn = InStoreData.RECORDID_FIELD;
			parm_recordid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_recordid);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM, SqlDbType.Char, 10);
			parm_accountdep.SourceColumn = InStoreData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char, 28);
			parm_contractid.SourceColumn = InStoreData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_contractid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char, 16);
			parm_status.SourceColumn = InStoreData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 1000);
			parm_description.SourceColumn = InStoreData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);

			
			return updateCommand;
		}

		public bool UpdateInStore(InStoreData data)
		{
			 
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.UpdateCommand = GetUpdateCommand();
			try
			{
				dsCommand.Update(data, InStoreData.INSTORE_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[InStoreData.INSTORE_TABLE].GetErrors()[0].ClearErrors();
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

		#region 删除部门
		private SqlCommand GetDeleteCommand()
		{
			
			
			SqlCommand deleteCommand = new SqlCommand("D_Instore",new SqlConnection (ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;
            
			SqlParameter parm_isrid = new SqlParameter(ISRID_PARM, SqlDbType.Char, 28);
			parm_isrid.Direction = ParameterDirection.Input;

			deleteCommand.Parameters.Add(parm_isrid);
			
			return deleteCommand;
		}

		public bool DeleteInStore(string isrid)
		{
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[ISRID_PARM].Value = isrid;
            
			try
			{
				deleteCommand.Connection.Open();
				int i = deleteCommand.ExecuteNonQuery();
				if (i>=1)
					return true;
				else
					return false;
			}
			catch
			{
				return false;
			}
			finally
			{
				deleteCommand.Connection.Close();
				deleteCommand.Connection.Dispose();
				deleteCommand.Dispose();
			}
		}
		#endregion


	}
}
