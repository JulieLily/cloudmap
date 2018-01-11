using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// SalesPlanDetails 的摘要说明。
	/// </summary>
	public class SalesPlanDetails :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDCUSTOMER_PARM					= "@oldCustomer";
		private const String OLDMATERIALID_PARM					= "@oldMaterialID";
		private const String OLDSALESPLANID_PARM				= "@oldSalesPlanID";
		private const String OLDDEPARTMENTID_PARM				= "@oldDepartmentID";

		private const String CUSTOMER_PARM					= "@Customer";
		private const String MATERIALID_PARM				= "@MaterialID";
		private const String SALESPLANID_PARM				= "@SalesPlanID";
		private const String DEPARTMENTID_PARM				= "@DepartmentID";
		private const String SALESTYPE_PARM					= "@SalesType";

		private const String SALESAMOUNT_PARM				= "@SaleAmount";
		private const String UNIT_PARM						= "@Unit";
		private const String CHANGERATE_PARM				= "@ChangeRate";
		private const String SALESPRICE_PARM				= "@SalePrice";
		private const String SALESSUM_PARM					= "@SaleSum";

		private const String TIMELIMIT_PARM					= "@TimeLimit";
		private const String MODE_PARM						= "@Mode";
		private const String STATIONOFDISPATCH_PARM			= "@StationOfDispatch";
		private const String CURRENTSTOCK_PARM				= "@CurrentStock";
		private const String DELIVERYTIME_PARM				= "@DeliveryTime";

		private const String PRECARRIAGE_PARM				= "@PreCarriage";
		private const String DESCRIPTION_PARM				= "@Description";

		public SalesPlanDetails()
		{
			da = new SqlDataAdapter();
			da.TableMappings.Add("Table" ,SalesPlanDetailData.SALESPLANDETAIL_TABLE);
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

		#region 读取销售计划信息 2005-8-19 魏套江 add		
		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null&&filter!="使用"&&filter!="客户")
			{
				strsql = "select t.*,d1.name drawdepartmentname,"
					+ "s1.name DrawPersonName,c.*,c.name CustomerName "
					+ "from (select * from tbl_salesplandetail where " + filter + ") t "
					+ "left JOIN TBL_DepartmentInfo d1 ON d1.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_StaffInfo s1 ON s1.id =t.drawperson "
					+ "left JOIN TBL_correspondentcompany c ON c.departmentid=t.departmentid and pub_category='客户'" ;
			}
			else if(filter=="使用")
			{
				strsql=" select * from tbl_material where enable='使用' ";
			}
			else if(filter=="客户")
			{
				strsql="select c.* from TBL_correspondentcompany c "
					+ "left join tbl_salesplandetail s on s.departmentid=c.departmentid and c.pub_category='客户' ";
			}
			else 
			{
				strsql = "select t.*,d1.name drawdepartmentname,"
					+ "c.name CustomerName "
					+ "from tbl_salesplandetail t "
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =t.drawDepartment "
					+ "left JOIN TBL_correspondentcompany c ON c.departmentid=t.departmentid and pub_category='客户'" ;
			}
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public SalesPlanDetailData LoadSalesPlanDetail(string filter)
		{
			if ( da == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			SalesPlanDetailData data = new SalesPlanDetailData();
			
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
		#endregion

		#region 读取所有记录---销售计划明细 2005-8-22 魏套江 修改
		public SalesPlanDetailData GetLoadSalesPlanDetail(string salesplanID)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			SalesPlanDetailData data = new SalesPlanDetailData();
			da.SelectCommand = GetLoadCommand();
			da.SelectCommand.Parameters[SALESPLANID_PARM].Value = salesplanID;
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
			SqlCommand load = new SqlCommand("Q_SalesPlanDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM, SqlDbType.Char);
			parm_salesplanid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_salesplanid);

			return load;
		}
		#endregion

		#region 读取所有记录---当前库存量 2005-8-22 魏套江 修改
		public SalesPlanDetailData GetCurrentStock(string materialid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			SalesPlanDetailData data = new SalesPlanDetailData();
			da.SelectCommand = GetLoadCurrentStockCommand();
			da.SelectCommand.Parameters[MATERIALID_PARM].Value = materialid;
 
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
		private SqlCommand GetLoadCurrentStockCommand()
		{
			SqlCommand load = new SqlCommand("Q_StorehouseMaterialStock" , new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_materialid);

			return load;
		}
		#endregion

		#region 添加记录---销售计划明细
		public bool InsertSalesPlanDetail(SalesPlanDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand = GetInsertCommand();
			try
			{
				da.Update(data ,SalesPlanDetailData.SALESPLANDETAIL_TABLE);
				if(data.HasErrors)
				{
					data.Tables[SalesPlanDetailData.SALESPLANDETAIL_TABLE].GetErrors()[0].ClearErrors();
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

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insert = new SqlCommand("I_SalesPlanDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_customer = new SqlParameter(CUSTOMER_PARM, SqlDbType.Char);
			parm_customer.SourceColumn = SalesPlanDetailData.CUSTOMER_FIELD; 
			parm_customer.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_customer);
			
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.SourceColumn = SalesPlanDetailData.MATERIALID_FIELD; 
			parm_materialid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_materialid);

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM, SqlDbType.Char);
			parm_salesplanid.SourceColumn = SalesPlanDetailData.SALESPLANID_FIELD; 
			parm_salesplanid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salesplanid);
			
			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char);
			parm_departid.SourceColumn = SalesPlanDetailData.DEPARTMENTID_FIELD; 
			parm_departid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_salestype = new SqlParameter(SALESTYPE_PARM, SqlDbType.Char);
			parm_salestype.SourceColumn = SalesPlanDetailData.SALESTYPE_FIELD; 
			parm_salestype.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salestype);


			SqlParameter parm_salesamount = new SqlParameter(SALESAMOUNT_PARM, SqlDbType.Decimal);
			parm_salesamount.SourceColumn = SalesPlanDetailData.SALESAMOUNT_FIELD; 
			parm_salesamount.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salesamount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char);
			parm_unit.SourceColumn = SalesPlanDetailData.UNIT_FIELD; 
			parm_unit.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = SalesPlanDetailData.CHANGERATE_FIELD; 
			parm_changerate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_changerate);

			SqlParameter parm_salesprice= new SqlParameter(SALESPRICE_PARM, SqlDbType.Decimal);
			parm_salesprice.SourceColumn = SalesPlanDetailData.SALESPRICE_FIELD; 
			parm_salesprice.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salesprice);

			SqlParameter parm_salessum = new SqlParameter(SALESSUM_PARM, SqlDbType.Decimal);
			parm_salessum.SourceColumn = SalesPlanDetailData.SALESSUM_FIELD; 
			parm_salessum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_salessum);


			SqlParameter parm_timelimit = new SqlParameter(TIMELIMIT_PARM, SqlDbType.Char);
			parm_timelimit.SourceColumn = SalesPlanDetailData.TIMELIMIT_FIELD; 
			parm_timelimit.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_timelimit);

			SqlParameter parm_mode = new SqlParameter(MODE_PARM, SqlDbType.Char);
			parm_mode.SourceColumn = SalesPlanDetailData.MODE_FIELD; 
			parm_mode.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_mode);

			SqlParameter parm_stationofdispatch = new SqlParameter(STATIONOFDISPATCH_PARM, SqlDbType.Char);
			parm_stationofdispatch.SourceColumn = SalesPlanDetailData.STATIONOFDISPATCH_FIELD; 
			parm_stationofdispatch.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_stationofdispatch);

			SqlParameter parm_currentstock = new SqlParameter(CURRENTSTOCK_PARM, SqlDbType.Decimal);
			parm_currentstock.SourceColumn = SalesPlanDetailData.CURRENTSTOCK_FIELD; 
			parm_currentstock.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_currentstock);

			SqlParameter parm_deliverytime = new SqlParameter(DELIVERYTIME_PARM, SqlDbType.DateTime);
			parm_deliverytime.SourceColumn = SalesPlanDetailData.DELIVERYTIME_FIELD; 
			parm_deliverytime.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_deliverytime);


			SqlParameter parm_precarriage = new SqlParameter(PRECARRIAGE_PARM, SqlDbType.SmallInt);
			parm_precarriage.SourceColumn = SalesPlanDetailData.PRECARRIAGE_FIELD; 
			parm_precarriage.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_precarriage);

			SqlParameter parm_description= new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar);
			parm_description.SourceColumn = SalesPlanDetailData.DESCRIPTION_FIELD; 
			parm_description.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		#endregion

		#region 更新记录---销售计划明细

		public bool UpdateSalesPlanDetail(SalesPlanDetailData data )
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand = GetUpdateCommand();
			try
			{
			    da.Update(data, SalesPlanDetailData.SALESPLANDETAIL_TABLE );
				if(data.HasErrors)
				{
					data.Tables[SalesPlanDetailData.SALESPLANDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
		
		private SqlCommand  GetUpdateCommand()
		{
			SqlCommand update = new SqlCommand("U_SalesPlanDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_oldcustomer = new SqlParameter(OLDCUSTOMER_PARM, SqlDbType.Char);  //            old Customer 
			parm_oldcustomer.SourceColumn = SalesPlanDetailData.CUSTOMER_FIELD; 
			parm_oldcustomer.SourceVersion = DataRowVersion.Original; 
			parm_oldcustomer.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldcustomer);

			SqlParameter parm_customer = new SqlParameter(CUSTOMER_PARM, SqlDbType.Char);
			parm_customer.SourceColumn = SalesPlanDetailData.CUSTOMER_FIELD; 
			parm_customer.SourceVersion = DataRowVersion.Current; 
			parm_customer.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_customer);
			
			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM, SqlDbType.Char);    //           old MaterialID
			parm_oldmaterialid.SourceColumn = SalesPlanDetailData.MATERIALID_FIELD; 
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			parm_oldmaterialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.SourceColumn = SalesPlanDetailData.MATERIALID_FIELD; 
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_materialid);

			SqlParameter parm_oldsalesplanid = new SqlParameter(OLDSALESPLANID_PARM, SqlDbType.Char);  //         old SalesPlanID
			parm_oldsalesplanid.SourceColumn = SalesPlanDetailData.SALESPLANID_FIELD; 
			parm_oldsalesplanid.SourceVersion = DataRowVersion.Original;
			parm_oldsalesplanid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldsalesplanid);

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM, SqlDbType.Char);
			parm_salesplanid.SourceColumn = SalesPlanDetailData.SALESPLANID_FIELD; 
			parm_salesplanid.SourceVersion = DataRowVersion.Current;
			parm_salesplanid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salesplanid);

			SqlParameter parm_olddepartid = new SqlParameter(OLDDEPARTMENTID_PARM, SqlDbType.Char);  //           old  DepartmentID
			parm_olddepartid.SourceColumn = SalesPlanDetailData.DEPARTMENTID_FIELD; 
			parm_olddepartid.SourceVersion = DataRowVersion.Original;
			parm_olddepartid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_olddepartid);
			
			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char);
			parm_departid.SourceColumn = SalesPlanDetailData.DEPARTMENTID_FIELD; 
			parm_departid.SourceVersion = DataRowVersion.Current;
			parm_departid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_departid);


			SqlParameter parm_salestype = new SqlParameter(SALESTYPE_PARM, SqlDbType.Char);
			parm_salestype.SourceColumn = SalesPlanDetailData.SALESTYPE_FIELD; 
			parm_salestype.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salestype);


			SqlParameter parm_salesamount = new SqlParameter(SALESAMOUNT_PARM, SqlDbType.Decimal);
			parm_salesamount.SourceColumn = SalesPlanDetailData.SALESAMOUNT_FIELD; 
			parm_salesamount.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salesamount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char);
			parm_unit.SourceColumn = SalesPlanDetailData.UNIT_FIELD; 
			parm_unit.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_unit);

			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changerate.SourceColumn = SalesPlanDetailData.CHANGERATE_FIELD; 
			parm_changerate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_changerate);

			SqlParameter parm_salesprice= new SqlParameter(SALESPRICE_PARM, SqlDbType.Decimal);
			parm_salesprice.SourceColumn = SalesPlanDetailData.SALESPRICE_FIELD; 
			parm_salesprice.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salesprice);

			SqlParameter parm_salessum = new SqlParameter(SALESSUM_PARM, SqlDbType.Decimal);
			parm_salessum.SourceColumn = SalesPlanDetailData.SALESSUM_FIELD; 
			parm_salessum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_salessum);


			SqlParameter parm_timelimit = new SqlParameter(TIMELIMIT_PARM, SqlDbType.Char);
			parm_timelimit.SourceColumn = SalesPlanDetailData.TIMELIMIT_FIELD; 
			parm_timelimit.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_timelimit);

			SqlParameter parm_mode = new SqlParameter(MODE_PARM, SqlDbType.Char);
			parm_mode.SourceColumn = SalesPlanDetailData.MODE_FIELD; 
			parm_mode.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_mode);

			SqlParameter parm_stationofdispatch = new SqlParameter(STATIONOFDISPATCH_PARM, SqlDbType.Char);
			parm_stationofdispatch.SourceColumn = SalesPlanDetailData.STATIONOFDISPATCH_FIELD; 
			parm_stationofdispatch.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_stationofdispatch);

			SqlParameter parm_currentstock = new SqlParameter(CURRENTSTOCK_PARM, SqlDbType.Decimal);
			parm_currentstock.SourceColumn = SalesPlanDetailData.CURRENTSTOCK_FIELD; 
			parm_currentstock.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_currentstock);

			SqlParameter parm_deliverytime = new SqlParameter(DELIVERYTIME_PARM, SqlDbType.DateTime);
			parm_deliverytime.SourceColumn = SalesPlanDetailData.DELIVERYTIME_FIELD; 
			parm_deliverytime.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_deliverytime);


			SqlParameter parm_precarriage = new SqlParameter(PRECARRIAGE_PARM, SqlDbType.SmallInt);
			parm_precarriage.SourceColumn = SalesPlanDetailData.PRECARRIAGE_FIELD; 
			parm_precarriage.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_precarriage);

			SqlParameter parm_description= new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar);
			parm_description.SourceColumn = SalesPlanDetailData.DESCRIPTION_FIELD; 
			parm_description.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;
		}
		#endregion

		#region 删除记录-----销售计划明细

		public bool DeleteSalesPlanDetail(string customer ,string materialid ,string salesplanid,string departid)
		{
		    SqlCommand  deletecommand = GetDeleteCommand();
			deletecommand.Parameters[CUSTOMER_PARM].Value		= customer;
			deletecommand.Parameters[MATERIALID_PARM].Value		= materialid;
			deletecommand.Parameters[SALESPLANID_PARM].Value	= salesplanid;
			deletecommand.Parameters[DEPARTMENTID_PARM].Value	= departid;

			try
			{
				deletecommand.Connection.Open();
				if(deletecommand.ExecuteNonQuery()>0)
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
				deletecommand.Connection.Close();
				deletecommand.Connection.Dispose();
				deletecommand.Dispose();
			}
		}

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand delete = new SqlCommand("D_SalesPlanDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;	

			SqlParameter parm_customer = new SqlParameter(CUSTOMER_PARM, SqlDbType.Char);
			parm_customer.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_customer);
			
			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_materialid);

			SqlParameter parm_salesplanid = new SqlParameter(SALESPLANID_PARM, SqlDbType.Char);
			parm_salesplanid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_salesplanid);
			
			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM, SqlDbType.Char);
			parm_departid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_departid);

			return delete;
		}
		#endregion
	}
}
