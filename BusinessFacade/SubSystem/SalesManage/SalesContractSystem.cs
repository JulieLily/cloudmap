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
	
	public class SalesContractSystem
	{
		public SalesContractData LoadsSalesContractRecord(string filter)
		{
			using(SalesContracts access = new SalesContracts ())
			{
				return access.LoadsSalesContract(filter);
			}
		}
	
		public bool InsertSalesContractRecord(SalesContractData data)
		{
			using(SalesContracts access = new SalesContracts ())
			{
				return access.InsertSalesContract(data);
			}
		}

		public bool UpdateSalesContractRecord(SalesContractData data)
		{
			using(SalesContracts access = new SalesContracts())
			{
				return access.UpdateSalesContract(data);
			}
		}

		public bool DeleteSalesContractRecord(string contractid)
		{
			using(SalesContracts access = new SalesContracts())
			{
				return access.DeleteSalesContract(contractid);
			}
		}
		
		//SalesContractDetail
		public SalesContractDetailData LoadSalesContractDetailRecords(string contractid)
		{
			using(SalesContractDetails access = new SalesContractDetails())
			{
				return access.LoadSalesContractDetails(contractid);
			}
		}

		public SalesContractDetailData LoadSalesContractDetailRecord(string filter)
		{
			using(SalesContractDetails access = new SalesContractDetails())
			{
				return access.LoadSalesContractDetail(filter);
			}
		}
		
		public bool InsertSalesContractDetailRecord(SalesContractDetailData data)
		{
			using(SalesContractDetails access = new SalesContractDetails ())
			{
				return access.InsertSalesContractDetail(data);
			}
		}

		public bool UpdateSalesContractDetailRecord(SalesContractDetailData data)
		{
			using(SalesContractDetails access = new SalesContractDetails ())
			{
				return access.UpdateSalesContractDetail(data);
			}
		}

		public bool DeleteSalesContractDetailRecord(string contractid, string materialid)
		{
			using(SalesContractDetails access = new SalesContractDetails())
			{
				return access.DeleteSalesContractDetail(contractid,materialid);
			}
		}
	
		// SalesContractDelivery
		public SalesContractDeliveryData LoadSalesContractDeliveryRecord(string contractid,string Material)
		{
			using(SalesContractDeliverys access = new SalesContractDeliverys ())
			{
				return access.LoadSalesContractDelivery(contractid,Material);
			}
		}

		public bool InsertSalesContractDeliveryRecord(SalesContractDeliveryData data)
		{
			using(SalesContractDeliverys access = new SalesContractDeliverys ())
			{
				return access.InsertSalesContractDelivery(data);
			}
		}

		public bool UpdateSalesContractDeliveryRecord(SalesContractDeliveryData data)
		{
			using(SalesContractDeliverys access = new SalesContractDeliverys ())
			{
				return access.UpdateSalesContractDelivery(data);
			}
		}

		public bool DeleteSalesContractDeliveryRecord(string contractid, string materialid ,string DeliveryDate)
		{
			using(SalesContractDeliverys access = new SalesContractDeliverys ())
			{
				return access.DeleteSalesContractDelivery(contractid,materialid,DeliveryDate);
			}
		}

		public bool SubmitSalesContract(DataRow row,string department,string user, out string error)
		{
			string recordName = "销售合同单";
			string id = row[SalesContractData.CONTRACTID_FIELD].ToString().Trim();
			string parameter = "CONTRACTID:" + id;
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}

		public string GetSalesContractFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "销售合同单";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}
	}
}
