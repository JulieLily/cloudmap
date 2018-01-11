using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.SalesManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.SalesManage;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
namespace TOPSUN.ERP.BusinessFacade.SubSystem.SalesManage
{
	/// <summary>
	/// SalesOrderFormSystem 的摘要说明。
	/// </summary>
	public class SalesOrderFormSystem
	{
		public SalesOrderFormSystem()
		{
			 
		}
		// 销售定单主表操作
		#region 销售定单主表操作

		public SalesOrderFormData LoadSalesOrderForm(string filter)
		{
			using(SalesOrderForms load = new SalesOrderForms())
			{
				return load.LoadSalesOrderForm(filter);
			}
		}


		public bool InsertSalesOrderForm(SalesOrderFormData data)
		{
			using(SalesOrderForms insert = new SalesOrderForms())
			{
				return insert.InsertSalesOrderForm(data);
			}
		}

		public bool UpdateSalesOrderForm(SalesOrderFormData data)
		{
			using(SalesOrderForms update = new SalesOrderForms())
			{
				return update.UpdateSalesOrderForm(data);
			}
		}

		public bool DeleteSalesOrderForm(string orderformid)
		{
			using(SalesOrderForms delete = new SalesOrderForms())
			{
				return delete.DeleteSalesOrderForm(orderformid);
			}
		}
		#endregion



		// 销售定单明细操作
		#region 销售定单明细操作

		public SalesOrderFormDetailData LoadSalesOrderFormDetail(string orderformid)
		{
			using (SalesOrderFormDetails load = new SalesOrderFormDetails())
			{
				return load.LoadSalesOrderFormDetail(orderformid);
			}
		}


		public bool InsertSalesOrderFormDetail(SalesOrderFormDetailData data)
		{
			using (SalesOrderFormDetails insert = new SalesOrderFormDetails())
			{
				return insert.InsertSalesOrderFormDetail(data);
			}
		}

		public bool UpdateSalesOrderFormDetail(SalesOrderFormDetailData data)
		{
			using(SalesOrderFormDetails update = new SalesOrderFormDetails())
			{
				return  update.UpdateSalesOrderFormDetail(data);
			}
		}

		public bool DeleteSalesOrderFormDetail(string orderformid,string materialid)
		{
			using(SalesOrderFormDetails delete = new SalesOrderFormDetails())
			{
				return delete.DeleteSalesOrderFormDetail(orderformid,materialid);
			}
		}
		#endregion


		//单据提交审批---(记录)销售定单 
		public bool SubmitSalesOrderForm(DataRow row,string department, out string error)
		{
			string recordName = "销售定单制定";
			string id   =  row[SalesOrderFormData.ORDERFORMID_FIELD].ToString().Trim();
			string user = row[SalesOrderFormData.DRAWPERSON_FIELD].ToString().Trim();
			string parameter = "ORDERFORMID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}

		//待审批单据过滤条件
		// modify by Xujiansong 2005- 9- 20
		public string GetSalesOrderFormFilter(string department,string user)  
		{
			if(department!=""&&user!="")
			{
				string recordName = "销售定单制定";
				return (new ApproveFlowSystem()).GetRecordFilter(recordName,department,user);
			}
			else
				return null; 
		}
	}
}
