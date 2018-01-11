using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.SalesManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.SalesManage;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.BusinessRules.BaseSystem;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.SalesManage
{
	/// <summary>
	/// SalePlanSystem 的摘要说明。
	/// 时间：2005-8-22 魏套江 
	/// 模块：销售计划制定
	/// </summary>
	public class SalesPlanSystem
	{
		#region 读取主表数据
		public SalesPlanData LoadSalesPlan(string filter)
		{
			using(SalesPlans access = new SalesPlans())
			{
				return access.LoadSalesPlan(filter);
			}
		}
		#endregion

		#region 从表的物料等选择
		public SalesPlanDetailData LoadSalesPlanDetail(string filter)
		{
			using(SalesPlanDetails access = new SalesPlanDetails())
			{
				return access.LoadSalesPlanDetail(filter);
			}
		}
		#endregion

		public SalesPlanDetailData LoadSalesPlanDetailData(string salesplanID)
		{
			using(SalesPlanDetails access = new SalesPlanDetails())
			{
				return access.GetLoadSalesPlanDetail(salesplanID);
			}
		}
		#region  获得当前库存
		public SalesPlanDetailData GetCurrentStock(string materialid)
		{
			using(SalesPlanDetails access = new SalesPlanDetails())
			{
				return access.GetCurrentStock(materialid);
			}
		}
		#endregion

		#region 主表的增、删、改
		public bool InsertSalesPlan(SalesPlanData data)
		{
			using(SalesPlans access = new SalesPlans())
			{
				return access.InsertSalesPlan(data);
			}
		}

		public bool UpdateSalesPlan(SalesPlanData data)
		{
			using(SalesPlans access = new SalesPlans())
			{
				return access.UpdateSalesPlan(data);
			}
		}

		public bool DeleteSalesPlan(string salesplanid)
		{
			using(SalesPlans access = new SalesPlans())
			{
				return access.DeleteSalesPlan(salesplanid);
			}
		}
		#endregion

		#region 从表的增、删、改
		public bool InsertSalesPlanDetail(SalesPlanDetailData data)
		{
			using(SalesPlanDetails access = new SalesPlanDetails())
			{
				return access.InsertSalesPlanDetail(data);
			}
		}

		public bool UpdateSalesPlanDetail (SalesPlanDetailData data)
		{
			using(SalesPlanDetails access = new SalesPlanDetails())
			{
				return access.UpdateSalesPlanDetail(data);
			}
		}

		public bool DeleteSalesPlanDetail(string customer, string materialid, string salesplanid, string departid)
		{
			using(SalesPlanDetails access = new SalesPlanDetails())
			{
				return access.DeleteSalesPlanDetail(customer,materialid,salesplanid,departid);
			}
		}
		#endregion

		#region 单据提交审批操作
		//2005-9-13 魏套江添加
		/// <summary>
		/// 单据提交审批操作
		/// </summary>
		/// <param name="row"></param>
		/// <param name="department"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		//string department,string user,--------------2005-9-20 wtj 修改
		public bool SubmitSalesPlanRecord(DataRow row, out string error)
		{
			string recordName = "销售计划审批";
			string salesplanid = row[SalesPlanData.SALESPLANID_FIELD].ToString().Trim(); 
			string department = row[SalesPlanData.DRAWDEPARTMENT_FIELD].ToString().Trim();
			string user= row[SalesPlanData.DRAWPERSON_FIELD].ToString().Trim();
			string parameter="SALESPLANID:" + salesplanid + "";			
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}		
		#endregion

		#region 更新提交单的状态
		public bool UpdateSalesPlanRecordStatus(string salesplanid,string status)
		{
			using (SalesPlans Access = new SalesPlans())
			{
				return  Access.UpdateSalesPlanRecordStatus(salesplanid,status);
			}
		}
		#endregion
	}
}
