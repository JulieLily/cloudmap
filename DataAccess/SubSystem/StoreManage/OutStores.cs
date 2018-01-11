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

	public class OutStores:IDisposable

	{
		#region  定义常量及初始化

		private SqlDataAdapter dsCommand;
		private const String OUTSTORES_PARM        = "out_outstores"; 

		private const String OSRID_PARM             = "@osrid";
		private const String OSRNAME_PARM           = "@osrname";
		private const String REDBLUEREMARK_PARM     = "@redblueremark";
		private const String DEPARTMENTID_PARM      = "@departmentid";
		private const String HOUSEID_PARM           = "@houseid";

		private const String CORCOMPANY_PARM           = "@corcompany";
		private const String OUTTYPE_PARM               = "@outtype";
		private const String OUTCATEGORY_PARM            = "@outcategory";
		private const String OUTDATE_PARM               = "@outdate";
		private const String ALLSUM_PARM                = "@allsum";

		private const String DISCOUNTSUM_PARM        = "@discountsum";
		private const string WITHOUTTAXSUM_PARM      = "@withouttaxsum";
		private const String TAXSUM_PARM           = "@taxsum";
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
		private const String FREEZEDATE_PARM			= "@freezedate";

		public OutStores()
		{
			dsCommand = new SqlDataAdapter();
        
			dsCommand.TableMappings.Add("Table", OutStoreData.OUTSTORE_TABLE);
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

		#region 读取出库单信息
		#region	读取一般出库单
		private SqlCommand GetLoadOutStoreRecordCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)
				strsql = "select t.*,d1.name departmentname,s.name housename,c.name corcompanyname,d2.name drawdepartmentname,"
					+ "s1.name drawpersonname,s2.name checkername,s3.name custodianname,s4.name businesspersonname "
					+ "from (select * from tbl_outstore where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.businessperson "
					+ "left join tbl_storehouse s on t.houseid=s.houseid "
					+ "left join tbl_correspondentcompany c on t.corcompany=c.companyid and t.departmentid=c.departmentid ";
			else
				strsql = "select t.*,d1.name departmentname,s.name housename,c.name corcompanyname,d2.name drawdepartmentname, "
					+ "s1.name drawpersonname,s2.name checkername,s3.name custodianname,s4.name businesspersonname "
					+ "from tbl_outstore t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.businessperson "
					+ "left join tbl_storehouse s on t.houseid=s.houseid "
					+ "left join tbl_correspondentcompany c on t.corcompany=c.companyid and t.departmentid=c.departmentid ";
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public OutStoreData LoadOutStoreRecord(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			OutStoreData data = new OutStoreData();
			
			dsCommand.SelectCommand = GetLoadOutStoreRecordCommand(filter);
			
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

		#region	读取销售出库单
		//2005-9-22 魏套江 修改
		private SqlCommand GetLoadSalesOutRecordCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null&&filter!="客户")
				strsql = "select t.*,d1.name departmentname,x.osrname recordname,d2.name drawdepartmentname,s.ContractID,s.ContractName,c1.Companyid,c1.name,c2.name CustomerName,c3.name corcompanyname,h.Name HouseName, "
					+ "s1.name drawpersonname,s2.name businesspersonname,s3.name CheckerName,s4.name CustodianName,s5.name FinancialPersonName,s6.name InventoryPersonName "
					+ "from (select * from tbl_outstore where " + filter + " ) t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.businessperson "
					+ "left JOIN tbl_StaffInfo s3  ON s3.id =t.checker "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s5  ON s5.id =t.financialperson "
					+ "left JOIN TBL_StaffInfo s6  ON s6.id =t.inventoryperson "
					+ "left JOIN tbl_outstore x  ON x.osrid =t.recordid "
					+ "left join tbl_salescontract s ON s.contractID=t.contractID " 
					+ "left join tbl_correspondentcompany c2 ON c2.companyID=t.corcompany "
					+ "left join tbl_correspondentcompany c3 ON c3.companyID=t.corcompany "
					+ "left join tbl_correspondentcompany c1 ON c1.companyID=s.customer and s.customer=t.corcompany and c1.companyID=t.corcompany and t.outcategory='销售订单出库' " 
					+ "left join tbl_storehouse h ON h.houseid=t.houseid and t.departmentID=h.departmentID " ;
			else
				strsql = "select t.*,d1.name departmentname,x.osrname recordname,d2.name drawdepartmentname,s.ContractID,s.ContractName,c1.Companyid,c1.name,c2.name CustomerName,c3.name corcompanyname,h.Name HouseName, "
					+ "s1.name drawpersonname,s2.name businesspersonname,s3.name CheckerName,s4.name CustodianName,s5.name FinancialPersonName,s6.name InventoryPersonName "
					+ "from tbl_outstore t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.businessperson "
					+ "left JOIN tbl_StaffInfo s3  ON s3.id =t.checker "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s5  ON s5.id =t.financialperson "
					+ "left JOIN TBL_StaffInfo s6  ON s6.id =t.inventoryperson "
					+ "left JOIN tbl_outstore x  ON x.osrid =t.recordid "
					+ "left join tbl_salescontract s ON s.contractID=t.contractID " 
					+ "left join tbl_correspondentcompany c2 ON c2.companyID=t.corcompany "
					+ "left join tbl_correspondentcompany c3 ON c3.companyID=t.corcompany "
					+ "left join tbl_correspondentcompany c1 ON c1.companyID=s.customer and s.customer=t.corcompany and c1.companyID=t.corcompany and t.outcategory='销售订单出库' " 
					+ "left join tbl_storehouse h ON h.houseid=t.houseid and t.departmentID=h.departmentID " ;
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public OutStoreData LoadSalesOutRecord(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			OutStoreData data = new OutStoreData();
			
			dsCommand.SelectCommand = GetLoadSalesOutRecordCommand(filter);
			
			//			try
		{
			dsCommand.Fill(data);
				
			return data;
		}
			//			catch
		{
			return null;				
		}
		}
		#endregion

		#region	读取移库出库单
		//Added by XuJiansong 2005-8-22
		private SqlCommand GetLoadMoveOutRecordCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)
				strsql = "select t.*,d1.name departmentname,s.name housename,c.name corcompanyname,d2.name drawdepartmentname, x.ContractName ContractName ,"
					+ "s1.name drawpersonname,s2.name checkername,s3.name custodianname,s4.name businesspersonname "
					+ "from (select * from tbl_outstore where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.businessperson "
					+ "left join tbl_storehouse s on t.houseid=s.houseid "
					+ " left join TBL_PurchasingContract x on t.ContractID = x.ContractID "
					+ "left join tbl_correspondentcompany c on t.corcompany=c.companyid and t.departmentid=c.departmentid";
			else
				strsql = "select t.*,d1.name departmentname,s.name housename,c.name corcompanyname,d2.name drawdepartmentname,x.ContractName ContractName , "
					+ "s1.name drawpersonname,s2.name checkername,s3.name custodianname,s4.name businesspersonname "
					+ "from tbl_outstore t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =t.drawperson "
					+ "left JOIN TBL_StaffInfo s2  ON s2.id =t.checker "
					+ "left JOIN TBL_StaffInfo s3  ON s3.id =t.custodian "
					+ "left JOIN TBL_StaffInfo s4  ON s4.id =t.businessperson "
					+ "left join tbl_storehouse s on t.houseid=s.houseid "
					+ " left join TBL_PurchasingContract x on t.ContractID = x.ContractID "
					+ "left join tbl_correspondentcompany c on t.corcompany=c.companyid and t.departmentid=c.departmentid";
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public OutStoreData LoadMoveOutRecord(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			OutStoreData data = new OutStoreData();
			
			dsCommand.SelectCommand = GetLoadMoveOutRecordCommand(filter);
			
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

		#region 读取销售退货单信息
		//Added by YiChangxin 2005-8-25
		private SqlCommand GetLoadSalesReturnRecordCommand()
		{
			SqlCommand	loadsCommand = new SqlCommand("Q_OutStoreRecrod",new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.StoredProcedure;
            
			return loadsCommand;
		}

		public OutStoreData LoadSalesReturnRecord()
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			OutStoreData data = new OutStoreData();
			
			dsCommand.SelectCommand = GetLoadSalesReturnRecordCommand();
			
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
		#endregion 读取出库单信息
		
		#region 添加部门信息
		private SqlCommand GetInsertCommand()
		{
			
			SqlCommand insertCommand = new SqlCommand("I_OutStore",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;


			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char, 10);
			parm_departmentid.SourceColumn = OutStoreData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char, 28);
			parm_osrid.SourceColumn = OutStoreData.OSRID_FIELD;
			parm_osrid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_osrid);
				
			SqlParameter parm_osrname = new SqlParameter(OSRNAME_PARM, SqlDbType.Char, 40);
			parm_osrname.SourceColumn = OutStoreData.OSRNAME_FIELD;
			parm_osrname.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_osrname);

			SqlParameter parm_redblueremark = new SqlParameter(REDBLUEREMARK_PARM, SqlDbType.SmallInt);
			parm_redblueremark.SourceColumn = OutStoreData.REDBLUEREMARK_FIELD;
			parm_redblueremark.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_redblueremark);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM, SqlDbType.Char, 4);
			parm_houseid.SourceColumn = OutStoreData.HOUSEID_FIELD;
			parm_houseid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_corcompany = new SqlParameter(CORCOMPANY_PARM, SqlDbType.Char, 10);
			parm_corcompany.SourceColumn = OutStoreData.CORCOMPANY_FIELD;
			parm_corcompany.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_corcompany);

			SqlParameter parm_outtype = new SqlParameter(OUTTYPE_PARM, SqlDbType.Char, 16);
			parm_outtype.SourceColumn = OutStoreData.OUTTYPE_FIELD;
			parm_outtype.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_outtype);

			SqlParameter parm_outcategory = new SqlParameter(OUTCATEGORY_PARM, SqlDbType.Char, 16);
			parm_outcategory.SourceColumn = OutStoreData.OUTCATEGORY_FIELD;
			parm_outcategory.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_outcategory);

			SqlParameter parm_outdate = new SqlParameter(OUTDATE_PARM, SqlDbType.DateTime);
			parm_outdate.SourceColumn = OutStoreData.OUTDATE_FIELD;
			parm_outdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_outdate);

			SqlParameter parm_ALLSUM = new SqlParameter(ALLSUM_PARM, SqlDbType.Decimal);
			parm_ALLSUM.SourceColumn = OutStoreData.ALLSUM_FIELD;
			parm_ALLSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_ALLSUM);

			SqlParameter parm_discountSUM = new SqlParameter(DISCOUNTSUM_PARM, SqlDbType.Decimal);
			parm_discountSUM.SourceColumn = OutStoreData.DISCOUNTSUM_FIELD;
			parm_discountSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_discountSUM);

			SqlParameter parm_WITHOUTTAXSUM = new SqlParameter(WITHOUTTAXSUM_PARM, SqlDbType.Decimal);
			parm_WITHOUTTAXSUM.SourceColumn = OutStoreData.WITHOUTTAXSUM_FIELD;
			parm_WITHOUTTAXSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_WITHOUTTAXSUM);

			SqlParameter parm_taxSUM = new SqlParameter(TAXSUM_PARM, SqlDbType.Decimal);
			parm_taxSUM.SourceColumn = OutStoreData.TAXSUM_FIELD;
			parm_taxSUM.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxSUM);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM, SqlDbType.Char, 10);
			parm_drawdepartment.SourceColumn = OutStoreData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM, SqlDbType.Char,10);
			parm_drawperson.SourceColumn = OutStoreData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM, SqlDbType.DateTime);
			parm_drawdate.SourceColumn = OutStoreData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_checker= new SqlParameter(CHECKER_PARM, SqlDbType.Char, 10);
			parm_checker.SourceColumn = OutStoreData.CHECKER_FIELD;
			parm_checker.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_checker);

			SqlParameter parm_custodian = new SqlParameter(CUSTODIAN_PARM, SqlDbType.Char,10);
			parm_custodian.SourceColumn = OutStoreData.CUSTODIAN_FIELD;
			parm_custodian.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_custodian);

			SqlParameter parm_businessperson = new SqlParameter(BUSINESSPERSON_PARM, SqlDbType.Char,10);
			parm_businessperson.SourceColumn = OutStoreData.BUSINESSPERSON_FIELD;
			parm_businessperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_businessperson);

			SqlParameter parm_financialperson = new SqlParameter(FINANCIALPERSON_PARM, SqlDbType.Char, 18);
			parm_financialperson.SourceColumn = OutStoreData.FINANCIALPERSON_FIELD;
			parm_financialperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_financialperson);

			SqlParameter parm_financialremark = new SqlParameter(FINANCIALREMARK_PARM, SqlDbType.Char, 10);
			parm_financialremark.SourceColumn = OutStoreData.FINANCIALREMARK_FIELD;
			parm_financialremark.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_financialremark);

			SqlParameter parm_financialdate = new SqlParameter(FINANCIALDATE_PARM, SqlDbType.DateTime);
			parm_financialdate.SourceColumn = OutStoreData.FINANCIALDATE_FIELD;
			parm_financialdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_financialdate);

			SqlParameter parm_inventoryporson = new SqlParameter(INVENTORYPERSON_PARM, SqlDbType.Char,18);
			parm_inventoryporson.SourceColumn = OutStoreData.INVENTORYPERSON_FIELD;
			parm_inventoryporson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_inventoryporson);

			SqlParameter parm_inventoryremark = new SqlParameter(INVENTORYREMARK_PARM, SqlDbType.Char, 10);
			parm_inventoryremark.SourceColumn = OutStoreData.INVENTORYREMARK_FIELD;
			parm_inventoryremark.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_inventoryremark);

			SqlParameter parm_inventorydate= new SqlParameter(INVENTORYDATE_PARM, SqlDbType.DateTime);
			parm_inventorydate.SourceColumn = OutStoreData.INVENTORYDATE_FIELD;
			parm_inventorydate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_inventorydate);

			SqlParameter parm_recordid = new SqlParameter(RECORDID_PARM, SqlDbType.Char,28);
			parm_recordid.SourceColumn = OutStoreData.RECORDID_FIELD;
			parm_recordid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_recordid);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM, SqlDbType.Char, 10);
			parm_accountdep.SourceColumn = OutStoreData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char, 28);
			parm_contractid.SourceColumn = OutStoreData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_contractid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char, 16);
			parm_status.SourceColumn = OutStoreData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_status);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 1000);
			parm_description.SourceColumn = OutStoreData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);
				
				
			SqlParameter parm_freezedate = new SqlParameter(FREEZEDATE_PARM, SqlDbType.VarChar, 1000);
			parm_freezedate.SourceColumn = OutStoreData.FREEZEDATE_FIELD;
			parm_freezedate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_freezedate);

			            
			return insertCommand;
		}

		public bool InsertOutstore(OutStoreData data)			
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.InsertCommand = GetInsertCommand();
           
			try
			{
				dsCommand.Update(data,OutStoreData.OUTSTORE_TABLE);
				if ( data.HasErrors )
				{
					data.Tables[OutStoreData.OUTSTORE_TABLE].GetErrors()[0].ClearErrors();
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
			
			SqlCommand updateCommand = new SqlCommand("U_Outstore",new SqlConnection (ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

				
			SqlParameter parm_freezedate = new SqlParameter(FREEZEDATE_PARM, SqlDbType.VarChar, 1000);
			parm_freezedate.SourceColumn = OutStoreData.FREEZEDATE_FIELD;
			parm_freezedate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_freezedate);


			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char, 10);
			parm_departmentid.SourceColumn = OutStoreData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char, 28);
			parm_osrid.SourceColumn = OutStoreData.OSRID_FIELD;
			parm_osrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_osrid);
				
			SqlParameter parm_osrname = new SqlParameter(OSRNAME_PARM, SqlDbType.Char, 40);
			parm_osrname.SourceColumn = OutStoreData.OSRNAME_FIELD;
			parm_osrname.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_osrname);

			SqlParameter parm_redblueremark = new SqlParameter(REDBLUEREMARK_PARM, SqlDbType.SmallInt);
			parm_redblueremark.SourceColumn = OutStoreData.REDBLUEREMARK_FIELD;
			parm_redblueremark.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_redblueremark);

			SqlParameter parm_houseid = new SqlParameter(HOUSEID_PARM, SqlDbType.Char, 4);
			parm_houseid.SourceColumn = OutStoreData.HOUSEID_FIELD;
			parm_houseid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_houseid);

			SqlParameter parm_corcompany = new SqlParameter(CORCOMPANY_PARM, SqlDbType.Char, 10);
			parm_corcompany.SourceColumn = OutStoreData.CORCOMPANY_FIELD;
			parm_corcompany.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_corcompany);

			SqlParameter parm_outtype = new SqlParameter(OUTTYPE_PARM, SqlDbType.Char, 16);
			parm_outtype.SourceColumn = OutStoreData.OUTTYPE_FIELD;
			parm_outtype.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_outtype);

			SqlParameter parm_outcategory = new SqlParameter(OUTCATEGORY_PARM, SqlDbType.Char, 16);
			parm_outcategory.SourceColumn = OutStoreData.OUTCATEGORY_FIELD;
			parm_outcategory.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_outcategory);

			SqlParameter parm_outdate = new SqlParameter(OUTDATE_PARM, SqlDbType.DateTime);
			parm_outdate.SourceColumn = OutStoreData.OUTDATE_FIELD;
			parm_outdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_outdate);

			SqlParameter parm_ALLSUM = new SqlParameter(ALLSUM_PARM, SqlDbType.Decimal);
			parm_ALLSUM.SourceColumn = OutStoreData.ALLSUM_FIELD;
			parm_ALLSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_ALLSUM);

			SqlParameter parm_discountSUM = new SqlParameter(DISCOUNTSUM_PARM, SqlDbType.Decimal);
			parm_discountSUM.SourceColumn = OutStoreData.DISCOUNTSUM_FIELD;
			parm_discountSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_discountSUM);

			SqlParameter parm_WITHOUTTAXSUM = new SqlParameter(WITHOUTTAXSUM_PARM, SqlDbType.Decimal);
			parm_WITHOUTTAXSUM.SourceColumn = OutStoreData.WITHOUTTAXSUM_FIELD;
			parm_WITHOUTTAXSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_WITHOUTTAXSUM);

			SqlParameter parm_taxSUM = new SqlParameter(TAXSUM_PARM, SqlDbType.Decimal);
			parm_taxSUM.SourceColumn = OutStoreData.TAXSUM_FIELD;
			parm_taxSUM.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxSUM);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM, SqlDbType.Char, 10);
			parm_drawdepartment.SourceColumn = OutStoreData.DRAWDEPARTMENT_FIELD;
			parm_drawdepartment.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM, SqlDbType.Char,10);
			parm_drawperson.SourceColumn = OutStoreData.DRAWPERSON_FIELD;
			parm_drawperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM, SqlDbType.DateTime);
			parm_drawdate.SourceColumn = OutStoreData.DRAWDATE_FIELD;
			parm_drawdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_checker= new SqlParameter(CHECKER_PARM, SqlDbType.Char, 10);
			parm_checker.SourceColumn = OutStoreData.CHECKER_FIELD;
			parm_checker.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_checker);

			SqlParameter parm_custodian = new SqlParameter(CUSTODIAN_PARM, SqlDbType.Char,10);
			parm_custodian.SourceColumn = OutStoreData.CUSTODIAN_FIELD;
			parm_custodian.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_custodian);

			SqlParameter parm_businessperson = new SqlParameter(BUSINESSPERSON_PARM, SqlDbType.Char,10);
			parm_businessperson.SourceColumn = OutStoreData.BUSINESSPERSON_FIELD;
			parm_businessperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_businessperson);

			SqlParameter parm_financialperson = new SqlParameter(FINANCIALPERSON_PARM, SqlDbType.Char, 18);
			parm_financialperson.SourceColumn = OutStoreData.FINANCIALPERSON_FIELD;
			parm_financialperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_financialperson);

			SqlParameter parm_financialremark = new SqlParameter(FINANCIALREMARK_PARM, SqlDbType.Char, 10);
			parm_financialremark.SourceColumn = OutStoreData.FINANCIALREMARK_FIELD;
			parm_financialremark.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_financialremark);

			SqlParameter parm_financialdate = new SqlParameter(FINANCIALDATE_PARM, SqlDbType.DateTime);
			parm_financialdate.SourceColumn = OutStoreData.FINANCIALDATE_FIELD;
			parm_financialdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_financialdate);

			SqlParameter parm_inventoryporson = new SqlParameter(INVENTORYPERSON_PARM, SqlDbType.Char,18);
			parm_inventoryporson.SourceColumn = OutStoreData.INVENTORYPERSON_FIELD;
			parm_inventoryporson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_inventoryporson);

			SqlParameter parm_inventoryremark = new SqlParameter(INVENTORYREMARK_PARM, SqlDbType.Char, 10);
			parm_inventoryremark.SourceColumn = OutStoreData.INVENTORYREMARK_FIELD;
			parm_inventoryremark.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_inventoryremark);

			SqlParameter parm_inventorydate= new SqlParameter(INVENTORYDATE_PARM, SqlDbType.DateTime);
			parm_inventorydate.SourceColumn = OutStoreData.INVENTORYDATE_FIELD;
			parm_inventorydate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_inventorydate);

			SqlParameter parm_recordid = new SqlParameter(RECORDID_PARM, SqlDbType.Char,28);
			parm_recordid.SourceColumn = OutStoreData.RECORDID_FIELD;
			parm_recordid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_recordid);

			SqlParameter parm_accountdep = new SqlParameter(ACCOUNTDEP_PARM, SqlDbType.Char, 10);
			parm_accountdep.SourceColumn = OutStoreData.ACCOUNTDEP_FIELD;
			parm_accountdep.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_accountdep);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char, 28);
			parm_contractid.SourceColumn = OutStoreData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_contractid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char, 16);
			parm_status.SourceColumn = OutStoreData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar, 1000);
			parm_description.SourceColumn = OutStoreData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);

			
			return updateCommand;
		}

		public bool UpdateOutstore(OutStoreData data)
		{
			 
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			dsCommand.UpdateCommand = GetUpdateCommand();

			//			try
		{
			dsCommand.Update(data, OutStoreData.OUTSTORE_TABLE);
			if ( data.HasErrors )
			{
				data.Tables[OutStoreData.OUTSTORE_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}
			//			catch
		{
			return false;
		}
		}
		#endregion

		#region 删除部门
		private SqlCommand GetDeleteCommand()
		{
			
			SqlCommand deleteCommand = new SqlCommand("D_Outstore",new SqlConnection (ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;
            
			SqlParameter parm_osrid = new SqlParameter(OSRID_PARM, SqlDbType.Char, 28);
			parm_osrid.Direction = ParameterDirection.Input;

			deleteCommand.Parameters.Add(parm_osrid);
			
			return deleteCommand;
		}

		public bool DeleteOutstore(string osrid)
		{
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[OSRID_PARM].Value = osrid;
            
			try
			{
				deleteCommand.Connection.Open();
				int i = deleteCommand.ExecuteNonQuery();
				deleteCommand.Connection.Close();
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
			}
		}
		#endregion

		#region 修改提交单状态
		//2005-9-13 魏套江添加
		private SqlCommand GetUpdateOutStoreRecordStatusCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_OutStoreRecordStatus",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_osrid= new SqlParameter  (OSRID_PARM,SqlDbType.Char);
			parm_osrid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_osrid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char);
			parm_status.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);
            
			return updateCommand;
		}
		public bool UpdateOutStoreRecordStatus(string osrid,string status)
		{
			SqlCommand updateCommand = GetUpdateOutStoreRecordStatusCommand();
			updateCommand.Parameters[OSRID_PARM].Value = osrid;
			updateCommand.Parameters[STATUS_PARM].Value = status;

			try
			{
				updateCommand.Connection.Open();
				if(updateCommand.ExecuteNonQuery()>0)
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
				updateCommand.Connection.Close();
				updateCommand.Connection.Dispose();
				updateCommand.Dispose();
			}
		}
		#endregion
		
		

	}
}
