using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.PurchasingManage
{
	/// <summary>
	/// PurchasingPlanSystem 的摘要说明。
	/// </summary>
	public class PurchasingPlanSystem
	{
		public PurchasingPlanSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 主表操作 ---采购计划
		public  PurchasingPlanData LoadPurchasingPlan(string filter)
		{
			using(PurchasingPlans load = new PurchasingPlans())
			{
				return load.LoadPurchasingPlan(filter);
			}
		}

		public bool InsertPurchasingPlan(PurchasingPlanData data)
		{
			using (PurchasingPlans insert = new PurchasingPlans())
			{
				return insert.InsertPurchasingPlan(data);
			}
		}

		public bool UpdatePurchasingPlan(PurchasingPlanData data)
		{
			using (PurchasingPlans update = new PurchasingPlans())
			{
				return update.UpdatePurchasingPlan(data);
			}
		}

		public bool DeletePurchasingPlan(string purchasingplanid)
		{
			using (PurchasingPlans delete = new PurchasingPlans())
			{
				return delete.DeletePurchasingPlan(purchasingplanid);
			}
		}
		#endregion

		#region 从表操作 ---采购计划明细

		public PurchasingPlanDetailData LoadPurchasingPlanDetail(string purchasingplanid)
		{
			using (PurchasingPlanDetails load = new PurchasingPlanDetails())
			{
				return load.LoadPurchasingPlanDetail(purchasingplanid);
			}
		}

		public bool InsertPurchasingPlanDetail(PurchasingPlanDetailData data)
		{
			using (PurchasingPlanDetails insert = new PurchasingPlanDetails())
			{
				return insert.InsertPurchasingPlanDetail(data);
			}
		}

		public bool UpdatePurchasingPlanDetail(PurchasingPlanDetailData data)
		{
			using (PurchasingPlanDetails update = new PurchasingPlanDetails())
			{
				return update.UpdatePurchasingPlanDetail(data);
			}
		}

		public bool DeletePurchasingPlanDetail(string manufacturer ,string purchasingplanid,string departmentid, string materialid)
		{
			using (PurchasingPlanDetails delete  = new PurchasingPlanDetails())
			{
				return delete.DeletePurchasingPlanDetail(manufacturer ,purchasingplanid,departmentid,materialid);
			}
		}
		#endregion

		//单据提交审批---(记录)采购计划提交 ///2005-9-13
		public bool SubmitPurchasingPlan(DataRow row,string department, out string error)
		{
			string recordName = "采购计划";
			string id   =  row[PurchasingPlanData.PURCHASINGPLANID_FIELD].ToString().Trim();
			string user = row[PurchasingPlanData.DRAWPERSON_FIELD].ToString().Trim();
			string parameter = "PURCHASINGPLANID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}

		//单据审批过滤条件
		//added by Xujiansong 2005- 9- 20
		public string GetPurchasingPlanFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "采购计划";
				return (new ApproveFlowSystem()).GetRecordFilter(recordName,department,user);
			}
			else
				return null; 
		}

	} 
}
