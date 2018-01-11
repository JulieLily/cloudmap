using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.BusinessFacade.SubSystem;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.Common.Data.StoreManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.BusinessRules.BaseSystem;
 

namespace TOPSUN.ERP.BusinessFacade.SubSystem.PurchasingManage
{
	/// <summary>
	/// StoreInRecordSystem 的摘要说明。
	/// 开发：徐建松 
	/// 日期：2005-7-27
	/// </summary>
	/// 
	public class PurchasingContractSystem : MarshalByRefObject
	{
		public PurchasingContractSystem()
		{
			
		}

		//Begin of Added by YiChangxin 2005-8-30
		public PurchasingContractData LoadsPurchasingContractRecord(string filter)
		{
			using(PurchasingContracts access = new PurchasingContracts ())
			{
				return access.LoadsPurchasingContract(filter);
			}
		}

		public bool InsertPurchasingContractRecord(PurchasingContractData data)
		{
			using(PurchasingContracts access = new PurchasingContracts ())
			{
				return access.InsertPurchasingContract(data);
			}
		}

		public bool UpdatePurchasingContractRecord(PurchasingContractData data)
		{
			using(PurchasingContracts access = new PurchasingContracts())
			{
				return access.UpdatePurchasingContract(data);
			}
		}

		public bool DeletePurchasingContractRecord(string contractid)
		{
			using(PurchasingContracts access = new PurchasingContracts())
			{
				return access.DeletePurchasingContract(contractid);
			}
		}

		//PurchasingContractDetail
		public PurchasingContractDetailData LoadPurchasingContractDetailRecords(string contractid)
		{
			using(PurchasingContractDetails access = new PurchasingContractDetails())
			{
				return access.LoadPurchasingContractDetails(contractid);
			}
		}

		public PurchasingContractDetailData LoadPurchasingContractDetailRecord(string filter)
		{
			using(PurchasingContractDetails access = new PurchasingContractDetails())
			{
				return access.LoadPurchasingContractDetail(filter);
			}
		}

		public bool InsertPurchasingContractDetailRecord(PurchasingContractDetailData data)
		{
			using(PurchasingContractDetails access = new PurchasingContractDetails ())
			{
				return access.InsertPurchasingContractDetail(data);
			}
		}

		public bool UpdatePurchasingContractDetailRecord(PurchasingContractDetailData data)
		{
			using(PurchasingContractDetails access = new PurchasingContractDetails ())
			{
				return access.UpdatePurchasingContractDetail(data);
			}
		}

		public bool DeletePurchasingContractDetailRecord(string contractid, string materialid)
		{
			using(PurchasingContractDetails access = new PurchasingContractDetails())
			{
				return access.DeletePurchasingContractDetail(contractid,materialid);
			}
		}

		// PurchasingContractDelivery
		public PurchasingContractDeliveryData LoadPurchasingContractdeliveryRecord(string contractid,string Material)
		{
			using(PurchasingContractDeliverys access = new PurchasingContractDeliverys ())
			{
				return access.LoadPurchasingContractDelivery(contractid,Material);
			}
		}

		public bool InsertPurchasingContractDeliveryRecord(PurchasingContractDeliveryData data)
		{
			using(PurchasingContractDeliverys access = new PurchasingContractDeliverys ())
			{
				return access.InsertPurchasingContractDelivery(data);
			}
		}

		public bool UpdatePurchasingContractDeliveryRecord(PurchasingContractDeliveryData data)
		{
			using(PurchasingContractDeliverys access = new PurchasingContractDeliverys ())
			{
				return access.UpdatePurchasingContractDelivery(data);
			}
		}

		public bool DeletePurchasingContractDeliveryRecord(string contractid, string materialid ,string DeliveryDate)
		{
			using(PurchasingContractDeliverys access = new PurchasingContractDeliverys ())
			{
				return access.DeletePurchasingContractDelivery(contractid,materialid,DeliveryDate);
			}
		}
		//End of Added by YiChangxin 2005-8-30
		
		#region  读取主表ContractID 的合同详细表 所对应的物料编号和名称
		/// <summary>
		/// 读取主表ContractID 的合同详细表 所对应的物料编号和名称
		/// Added by XuJiansong 2005-8-29		
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public PurchasingContractDetailData LoadMaterialName(string filter)
		{
			using (PurchasingContractDetails  loadMaterialName = new PurchasingContractDetails())
			{
				return loadMaterialName.LoadMaterialNameByContractID(filter);
			}
		}

		#endregion

		#region 通过协议合同的选择带出 合同ID 和合同名称
		/// <summary>
		/// 通过协议合同的选择带出 合同ID 和合同名称
		/// Added by XuJiansong 2005-8-29		
		/// </summary>
		/// <returns></returns>
		public PurchasingContractData  LoadPurchasingContract()
		{
			PurchasingContractData data=new  PurchasingContractData();
			using (PurchasingContracts load = new PurchasingContracts())
			{
				return load.LoadPurchasingContract();
			}
		}
		#endregion

		//begin add by YiChangxin 2005-9-12
		public bool SubmitPurchasingContract(DataRow row,string department, string user,out string error)
		{
			string recordName = "采购合同单";
			string id = row[PurchasingContractData.CONTRACTID_FIELD].ToString().Trim();
			string parameter = "CONTRACTID:" + id;
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}

		public string GetPurchasingContractFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "采购合同单";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}

		//end 2005-9-12


	}
}
