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
	/// RequisitionMoneyDetails 的摘要说明。
	/// </summary>
	public class RequisitionMoneyDetails :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDRMRID_PARM							= "@oldRMRID";
		private const String OLDDEPARTMENTID_PARM					= "@oldDepartmentID";
		private const String OLDCORCOMPANYID_PARM					= "@oldCorCompanyID";
		private const String OLDCONTRACTID_PARM						= "@oldContractID";
		private const String OLDMATERIALID_PARM						= "@oldMaterialID";

		private const String RMRID_PARM								= "@RMRID";
		private const String DEPARTMENTID_PARM						= "@DepartmentID";
		private const String CORCOMPANYID_PARM						= "@CorCompanyID";
		private const String CONTRACTID_PARM						= "@ContractID";
		private const String MATERIALID_PARM						= "@MaterialID";

		private const String SUM_PARM								= "@Sum";
		private const String PAIDSUM_PARM							= "@PaidSum";
		private const String CURRENTPAYSUM_FIELD					= "@CurrentPaySum";
		private const String DESCRIPTION_FIELD						= "@Description";

		public RequisitionMoneyDetails()
		{
			da =new SqlDataAdapter();
			da.TableMappings.Add("Table",RequisitionMoneyDetailData.REQUESISITIONMONEYDETAIL_TABLE);
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

		#region 读取数据----请款单明细

		public RequisitionMoneyDetailData LoadRequisitionMoneyDetail()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			RequisitionMoneyDetailData data = new RequisitionMoneyDetailData();
			da.SelectCommand =GetLoadCommand ();
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
			SqlCommand load = new SqlCommand("Q_RequisitionMoneyDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			return load;
		}
		#endregion

		#region 条件读取请款单明细---YiChangxin	做了修改2005-9-21
		//Begin of Add by YiChangxin 2005-8-26
		public RequisitionMoneyDetailData LoadsRequisitionMoneyDetail(string filter)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			RequisitionMoneyDetailData data = new RequisitionMoneyDetailData();
			da.SelectCommand =GetLoadsCommand (filter);
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
		private SqlCommand GetLoadsCommand(string filter)
		{
			string strsql;
			if(filter!=""&&filter!=null)

				strsql = "select t.*,m.MaterialName,m.Model,m.StandardUnit,c.name corcompanyname, p.contractname "
					+ "from (select * from TBL_RequisitionMoneyDetail where " + filter + ") t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid "
					+ "left join tbl_correspondentcompany c on t.corcompanyid=c.companyid and t.departmentid = c.departmentid "
					+ "left join tbl_purchasingcontract p on t.contractid=p.contractid ";

			else 

				strsql = "select t.*,m.MaterialName,m.Model ,m.StandardUnit,c.name corcompanyname, p.contractname"
					+ "from TBL_RequisitionMoneyDetail t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid "
					+ "left join tbl_correspondentcompany c on t.corcompanyid=c.companyid and t.departmentid = c.departmentid "
					+ "left join tbl_purchasingcontract p on t.contractid=p.contractid ";

			SqlCommand load = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.Text;

			return load;
		}
		//End of Add 2005-8-26
		#endregion

		#region 获得已付款额
		//Begin of Add by YiChangxin 2005-8-26
		public RequisitionMoneyDetailData LoadSum(string contractid,string materialid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			RequisitionMoneyDetailData data = new RequisitionMoneyDetailData();
			da.SelectCommand =GetCommand ();

			da.SelectCommand.Parameters[CONTRACTID_PARM].Value = contractid;
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
		private SqlCommand GetCommand()
		{
			SqlCommand load = new SqlCommand("Q_RequisitionMoneySum",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_ContractID = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char,28);
			parm_ContractID.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_ContractID);

			SqlParameter parm_MATERIALID = new SqlParameter(MATERIALID_PARM, SqlDbType.Char,20);
			parm_MATERIALID.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_MATERIALID);

			return load;
		}
		//End of Add 2005-8-26
		#endregion

		#region 通过主表ID读取请款单明细
		//Begin of Add by YiChangxin 2005-8-26
		//Modified by zhiz 2005-9-22
		public RequisitionMoneyDetailData LoadsRequisitionMoneyDetails(string rmrid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			RequisitionMoneyDetailData data = new RequisitionMoneyDetailData();
			da.SelectCommand =GetLoadsCommand ();
			da.SelectCommand.Parameters[RMRID_PARM].Value	= rmrid;
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
		private SqlCommand GetLoadsCommand()
		{
			SqlCommand load = new SqlCommand("Q_RequisitionMoneyDetailByid",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.VarChar);
			parm_rmrid.Direction =ParameterDirection.Input;
			load.Parameters.Add(parm_rmrid);

			return load;
		}
		//End of Add 2005-8-26
		#endregion

		#region 添加数据-----请款单明细

		public bool InsertRequisitionMoneyDetail(RequisitionMoneyDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand =GetInsertCommand();
			da.Update(data,RequisitionMoneyDetailData.REQUESISITIONMONEYDETAIL_TABLE );
			if(data.HasErrors)
			{
				data.Tables[RequisitionMoneyDetailData.REQUESISITIONMONEYDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand GetInsertCommand ()
		{
			SqlCommand insert = new SqlCommand("I_RequisitionMoneyDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.VarChar);
			parm_rmrid.SourceColumn = RequisitionMoneyDetailData.RMRID_FIELD;
			parm_rmrid.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_rmrid);

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departid.SourceColumn = RequisitionMoneyDetailData.DEPARTMENTID_FIELD;
			parm_departid.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_corcompanyid = new SqlParameter(CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = RequisitionMoneyDetailData.CORCOMPANYID_FIELD;
			parm_corcompanyid.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.SourceColumn = RequisitionMoneyDetailData.CONTRACTID_FIELD;
			parm_contractid.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_contractid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = RequisitionMoneyDetailData.MATERIALID_FIELD;
			parm_materialid.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_materialid);


			SqlParameter parm_sum = new SqlParameter(SUM_PARM,SqlDbType.Decimal);
			parm_sum.SourceColumn = RequisitionMoneyDetailData.SUM_FIELD;
			parm_sum.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_sum);

			SqlParameter parm_paidsum = new SqlParameter(PAIDSUM_PARM,SqlDbType.Decimal);
			parm_paidsum.SourceColumn = RequisitionMoneyDetailData.PAIDSUM_FIELD;
			parm_paidsum.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_paidsum);

			SqlParameter parm_currentpaysum = new SqlParameter(CURRENTPAYSUM_FIELD,SqlDbType.Decimal);
			parm_currentpaysum.SourceColumn = RequisitionMoneyDetailData.CURRENTPAYSUM_FIELD;
			parm_currentpaysum.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_currentpaysum); 

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_FIELD,SqlDbType.VarChar);
			parm_description.SourceColumn = RequisitionMoneyDetailData.DESCRIPTION_FIELD;
			parm_description.Direction =ParameterDirection.Input;
			insert.Parameters.Add(parm_description); 
 
			return insert;
		}
		#endregion

		#region 更新数据------请款单明细

		public bool UpdateRequisitionMoneyDetail(RequisitionMoneyDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand =GetUpdateCommand();
			da.Update(data,RequisitionMoneyDetailData.REQUESISITIONMONEYDETAIL_TABLE);
			if(data.HasErrors)
			{
				data.Tables[RequisitionMoneyDetailData.REQUESISITIONMONEYDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand update = new SqlCommand("U_RequisitionMoneyDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_oldrmrid = new SqlParameter(OLDRMRID_PARM,SqlDbType.VarChar);       //------old RMRID
			parm_oldrmrid.SourceColumn = RequisitionMoneyDetailData.RMRID_FIELD;
			parm_oldrmrid.SourceVersion = DataRowVersion.Original;
			parm_oldrmrid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_oldrmrid);

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.VarChar);
			parm_rmrid.SourceColumn = RequisitionMoneyDetailData.RMRID_FIELD;
			parm_rmrid.SourceVersion = DataRowVersion.Current;
			parm_rmrid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_rmrid);


			SqlParameter parm_olddepartid = new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char);   //----- old Departmentid
			parm_olddepartid.SourceColumn = RequisitionMoneyDetailData.DEPARTMENTID_FIELD;
			parm_olddepartid.SourceVersion = DataRowVersion.Original;
			parm_olddepartid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_olddepartid);

			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departid.SourceColumn = RequisitionMoneyDetailData.DEPARTMENTID_FIELD;
			parm_departid.SourceVersion = DataRowVersion.Current;
			parm_departid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_departid);


			SqlParameter parm_oldcorcompanyid = new SqlParameter(OLDCORCOMPANYID_PARM,SqlDbType.Char);  // ---- old corcompanyid
			parm_oldcorcompanyid.SourceColumn = RequisitionMoneyDetailData.CORCOMPANYID_FIELD;
			parm_oldcorcompanyid.SourceVersion = DataRowVersion.Original;
			parm_oldcorcompanyid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_oldcorcompanyid);

			SqlParameter parm_corcompanyid = new SqlParameter(CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = RequisitionMoneyDetailData.CORCOMPANYID_FIELD;
			parm_corcompanyid.SourceVersion = DataRowVersion.Current;
			parm_corcompanyid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_corcompanyid);


			
			SqlParameter parm_oldcontractid = new SqlParameter(OLDCONTRACTID_PARM,SqlDbType.Char);  // ----- old contractid
			parm_oldcontractid.SourceColumn = RequisitionMoneyDetailData.CONTRACTID_FIELD;
			parm_oldcontractid.SourceVersion = DataRowVersion.Original;
			parm_oldcontractid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_oldcontractid);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.SourceColumn = RequisitionMoneyDetailData.CONTRACTID_FIELD;
			parm_contractid.SourceVersion = DataRowVersion.Current;
			parm_contractid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_contractid);


			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char);  // ------ old MaterialID
			parm_oldmaterialid.SourceColumn = RequisitionMoneyDetailData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			parm_oldmaterialid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = RequisitionMoneyDetailData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_materialid);



			SqlParameter parm_sum = new SqlParameter(SUM_PARM,SqlDbType.Decimal);
			parm_sum.SourceColumn = RequisitionMoneyDetailData.SUM_FIELD;
			parm_sum.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_sum);

			SqlParameter parm_paidsum = new SqlParameter(PAIDSUM_PARM,SqlDbType.Decimal);
			parm_paidsum.SourceColumn = RequisitionMoneyDetailData.PAIDSUM_FIELD;
			parm_paidsum.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_paidsum);

			SqlParameter parm_currentpaysum = new SqlParameter(CURRENTPAYSUM_FIELD,SqlDbType.Decimal);
			parm_currentpaysum.SourceColumn = RequisitionMoneyDetailData.CURRENTPAYSUM_FIELD;
			parm_currentpaysum.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_currentpaysum); 

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_FIELD,SqlDbType.VarChar);
			parm_description.SourceColumn = RequisitionMoneyDetailData.DESCRIPTION_FIELD;
			parm_description.Direction =ParameterDirection.Input;
			update.Parameters.Add(parm_description); 
 
			return update;
		}
		#endregion

		#region 删除记录----请款单明细

		public bool DeleteRequisitionMoneyDetail(string rmrid,string departid ,string corcompanyid, string contractid ,string materialid)
		{
			SqlCommand deletecommand =GetDeleteCommand();
			deletecommand.Parameters[RMRID_PARM].Value				= rmrid;
			deletecommand.Parameters[DEPARTMENTID_PARM].Value		= departid;
			deletecommand.Parameters[CORCOMPANYID_PARM].Value		= corcompanyid;
			deletecommand.Parameters[CONTRACTID_PARM].Value			= contractid;
			deletecommand.Parameters[MATERIALID_PARM].Value			= materialid;

			try
			{
				deletecommand.Connection.Open();
				if(deletecommand.ExecuteNonQuery()>0)
					return true;
				else
					return  false;
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
			SqlCommand delete = new SqlCommand("D_RequisitionMoneyDetail",new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;
 

			SqlParameter parm_rmrid = new SqlParameter(RMRID_PARM,SqlDbType.VarChar);
			parm_rmrid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_rmrid);


			SqlParameter parm_departid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_departid);
 

			SqlParameter parm_corcompanyid = new SqlParameter(CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_corcompanyid);

			
			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_contractid);


			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction =ParameterDirection.Input;
			delete.Parameters.Add(parm_materialid);

			return delete;
		}
		#endregion

	}
}
