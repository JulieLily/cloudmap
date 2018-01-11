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
	/// RequirementPlanSystem ��ժҪ˵����
	///  �����ˣ�   �콨��
	///  �������ڣ� 2005-8-9
	/// </summary>
	public class RequirementPlanSystem
	{
		public RequirementPlanSystem()
		{
		 
		}

		// ���� TBL_RequirementPlan ����
		#region  ���� TBL_RequirementPlan ����
 
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

		// �ӱ� TBL_RequirementPlanDetail ����
		#region �ӱ� TBL_RequirementPlanDetail ����
 
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



		// ���տ�ʼ���ںͽ������ڽ���-------����ƻ�����  2005 -8-15
		#region ���տ�ʼ���ںͽ������ڽ��� --------����ƻ�����

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


		//�����ύ����
		//---(��¼)����ƻ��ύ ///2005-9-13
		public bool SubmitRequirementPlan(DataRow row,string department, out string error)
		{
			string recordName = "����ƻ�";
			string id   =  row[RequirementPlanData.REQUIREMENTPLANID_FIELD].ToString().Trim();
			string user = row[RequirementPlanData.DRAWPERSON_FIELD].ToString().Trim();
			string parameter = "REQUIREMENTPLANID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}

		//���������ݹ�������
		// modify by Xujiansong 2005- 9- 20
		public string GetRequirementPlanFilter(string department,string user)  
		{
			if(department!=""&&user!="")
			{
				string recordName = "����ƻ�";
				return (new ApproveFlowSystem()).GetRecordFilter(recordName,department,user);
			}
			else
				return null; 
		}

	}
}
