using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.StoreManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.StoreManage;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.BusinessRules.BaseSystem;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.StoreManage
{
	/// <summary>
	/// InStoreSystem 的摘要说明。
	/// </summary>
	public class InStoreSystem
	{
		
		public InStoreData LoadInStoreRecord(string filter)
		{
			using(InStores access = new InStores())
			{
				return access.LoadInStore(filter);
			}
		}

		public InStoreDetailData LoadInStoreDetailRecord(string isrid)
		{
			using(InStoreDetails access = new InStoreDetails())
			{
				return access.LoadInStoreDetail(isrid);
			}
		}

		public bool InsertInStoreRecord(InStoreData data)
		{
			using(InStores access = new InStores())
			{
				return access.InsertInStore(data);
			}
		}

		public bool UpdateInStoreRecord(InStoreData data)
		{
			using(InStores access = new InStores())
			{
				return access.UpdateInStore(data);
			}
		}

		public bool DeleteInStoreRecord(string isrid)
		{
			using(InStores access = new InStores())
			{
				return access.DeleteInStore(isrid);
			}
		}

		public bool InsertInStoreDetailRecord(InStoreDetailData data)
		{
			using(InStoreDetails access = new InStoreDetails())
			{
				return access.InsertInStoreDetail(data);
			}
		}

		public bool UpdateInStoreDetailRecord(InStoreDetailData data)
		{
			using(InStoreDetails access = new InStoreDetails())
			{
				return access.UpdateInStoreDetail(data);
			}
		}

		public bool DeleteInStoreDetailRecord(string isrid, string materialid, string batchno, string attribute)
		{
			using(InStoreDetails access = new InStoreDetails())
			{
				return access.DeleteInStoreDetail(isrid,materialid,batchno,attribute);
			}
		}

		//Begin of Added by YiChangxin 2005-8-30
		public InStoreData LoadReturnPurchaseInvoice()
		{
			using(InStores access = new InStores())
			{
				return access.LoadReturnPurchaseInvoice();
			}
		}

		public InStoreDetailData LoadsInStoreDetailRecord(string filter)
		{
			using(InStoreDetails access = new InStoreDetails())
			{
				return access.LoadsInStoreDetail(filter);
			}
		}
		//End of Added by YiChangxin 2005-8-30

		#region 入库单据提交审批
		//Added by WangZhi 2005-9-19
		public bool SubmitInStoreRecord(DataRow row,string department,string user, out string error)
		{
			string recordName = "审批入库"; //通用出库单审批
			string id   =  row[InStoreData.ISRID_FIELD].ToString().Trim();
			string parameter = "ISRID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}
		#endregion

		//获得用户可审批单据的过滤条件
		public string GetInStoreRecordApproveFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "审批入库";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}
	}
}
