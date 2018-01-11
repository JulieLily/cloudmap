using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.PurchasingManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.BusinessRules.BaseSystem;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.PurchasingManage
{
	
	public class RequisitionMoneySystem
	{
		public RequisitionMoneyData LoadsRequisitionMoneyRecord(string filter)
		{
			using(RequisitionMoneys access = new RequisitionMoneys  ())
			{
				return access.LoadsRequisitionMoney(filter);
			}
		}

		public bool InsertRequisitionMoneyRecord(RequisitionMoneyData data)
		{
			using(RequisitionMoneys access = new RequisitionMoneys ())
			{
				return access.InsertRequisitionMoney(data);
			}
		}

		public bool UpdateRequisitionMoneyRecord(RequisitionMoneyData data)
		{
			using(RequisitionMoneys access = new RequisitionMoneys())
			{
				return access.updateRequisitionMoney(data);
			}
		}

		public bool DeleteRequisitionMoneyRecord(string rmrid)
		{
			using(RequisitionMoneys access = new RequisitionMoneys())
			{
				return access.DeleteRequisitionMoney(rmrid);
			}
		}
//RequisitionMoneyDetail
		public RequisitionMoneyDetailData LoadsRequisitionMoneyDetailRecords(string rmrid)
		{
			using(RequisitionMoneyDetails access = new RequisitionMoneyDetails ())
			{
				return access.LoadsRequisitionMoneyDetails(rmrid);
			}
		}

		public RequisitionMoneyDetailData LoadsRequisitionMoneyDetailRecord(string filter)
		{
			using(RequisitionMoneyDetails access = new RequisitionMoneyDetails ())
			{
				return access.LoadsRequisitionMoneyDetail(filter);
			}
		}

		public RequisitionMoneyDetailData LoadsSum(string contractid,string materialid)
		{
			using(RequisitionMoneyDetails access = new RequisitionMoneyDetails ())
			{
				return access.LoadSum(contractid,materialid);
			}
		}
		public bool InsertRequisitionMoneyDetailRecord(RequisitionMoneyDetailData data)
		{
			using(RequisitionMoneyDetails access = new RequisitionMoneyDetails ())
			{
				return access.InsertRequisitionMoneyDetail(data);
			}
		}

		public bool UpdateRequisitionMoneyDetailRecord(RequisitionMoneyDetailData data)
		{
			using(RequisitionMoneyDetails access = new RequisitionMoneyDetails())
			{
				return access.UpdateRequisitionMoneyDetail(data);
			}
		}

		public bool DeleteRequisitionMoneyDetailRecord(string rmrid,string departid ,string corcompanyid, string contractid ,string materialid)
		{
			using(RequisitionMoneyDetails access = new RequisitionMoneyDetails())
			{
				return access.DeleteRequisitionMoneyDetail(rmrid,departid,corcompanyid,contractid,materialid);
			}
		}

		//begin add by YiChangxin 2005-9-7
		public bool SubmitRequisitionMoney(DataRow row,string department, string user,out string error)
		{
			string recordName = "请款单";
			string id = row[RequisitionMoneyData.RMRID_FIELD].ToString().Trim();
			string parameter = "RMRID:" + id;
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}

		public string GetRequisitionMoneyFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "请款单";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}
		//end 2005-9-7
	}
}
