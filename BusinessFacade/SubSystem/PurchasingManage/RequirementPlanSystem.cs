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
	/// RequirementPlanSystem 的摘要说明。
	///  开发人：   徐建松
	///  开发日期： 2005-8-9
	/// </summary>
	public class RequirementPlanSystem
	{
		public RequirementPlanSystem()
		{
		 
		}

		// 主表 TBL_RequirementPlan 操作
		#region  主表 TBL_RequirementPlan 操作
 
		public RequirementPlanData LoadRequirementPlan(string filter)
		{
			using (RequirementPlans load = new RequirementPlans())
			{
				return load.LoadRequirementPlan(filter);
			}
		}
 
		public bool  InsertRequirementPlan(RequirementPlanData data)
		{
			using (RequirementPlans insert =new RequirementPlans())
			{
				return insert.InsertRequirementPlan(data);
			}
		}
 
		public bool UpdataRequirementPlan(RequirementPlanData data)
		{
			using (RequirementPlans update = new RequirementPlans())
			{
				return update.UpdateRequirementPlan(data);
			}
		}
 
		public bool DeleteRequirementPlan(string requriementplanid)
		{
			using (RequirementPlans delete = new RequirementPlans())
			{
				return delete.DeleteRequirementPlan(requriementplanid);
			}
		}
		#endregion

		// 从表 TBL_RequirementPlanDetail 操作
		#region 从表 TBL_RequirementPlanDetail 操作
 
		public RequirementPlanDetailData LoadRequirementPlanDetail(string requirementplanid)
		{
			using (RequirementPlanDetails load = new RequirementPlanDetails())
			{
				return load.LoadRequirementPlanDetail(requirementplanid);
			}
		}
 
		public bool  InsertRequirementPlanDetail(RequirementPlanDetailData data)
		{
			using(RequirementPlanDetails insert  = new RequirementPlanDetails())
			{
				return insert.InsertRequirementPlanDetail(data);
			}
		}

	 

		public bool UpdateRequirementPlanDetail(RequirementPlanDetailData data)
		{
			using (RequirementPlanDetails update = new RequirementPlanDetails())
			{
				return update.UpdateRequirementPlanDetail(data);
			}
		}

	 
		public bool DeleteRequirementPlanDetail(string departid , string requiremntplanid ,string materialid)
		{
			using (RequirementPlanDetails delete = new RequirementPlanDetails())
			{
			   return delete.DeleteRequirementPlanDetail(departid , requiremntplanid ,materialid);
			}
		}
		#endregion



		// 按照开始日期和结束日期进行-------需求计划汇总  2005 -8-15
		#region 按照开始日期和结束日期进行 --------需求计划汇总

		public  RequirementPlanDetailData LoadRequiremntPlanDetailSumdata(string begindate ,string enddate )
		{
			RequirementPlanDetailData data = new RequirementPlanDetailData();
			using (RequirementPlanDetails loadsumdata = new RequirementPlanDetails())
			{
				data= loadsumdata.LoadSumData(begindate ,enddate);
			}
			return data;
		}
		
		#endregion


		//单据提交审批
		//---(记录)需求计划提交 ///2005-9-13
		public bool SubmitRequirementPlan(DataRow row,string department, out string error)
		{
			string recordName = "需求计划";
			string id   =  row[RequirementPlanData.REQUIREMENTPLANID_FIELD].ToString().Trim();
			string user = row[RequirementPlanData.DRAWPERSON_FIELD].ToString().Trim();
			string parameter = "REQUIREMENTPLANID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}

		//待审批单据过滤条件
		// modify by Xujiansong 2005- 9- 20
		public string GetRequirementPlanFilter(string department,string user)  
		{
			if(department!=""&&user!="")
			{
				string recordName = "需求计划";
				return (new ApproveFlowSystem()).GetRecordFilter(recordName,department,user);
			}
			else
				return null; 
		}

	}
}
