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
	/// OutStoreSystem 的摘要说明。
	/// 开发： 徐建松
	/// 日期 ：2005-8-04
	/// </summary>
	public class OutStoreSystem
	{
		// 主表 TBL_OutStore 操作
		#region  主表 TBL_OutStore 操作

		/// <summary>
		/// 读取普通出库单信息
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public OutStoreData LoadOutStoreRecord(string filter)
		{
			using(OutStores filterload = new OutStores())
			{
				return filterload.LoadOutStoreRecord(filter);
			}
		}

		/// <summary>
		/// 读取销售出库单信息
		/// </summary>
		/// <returns></returns>
		public OutStoreData LoadSalesOutRecord(string filter)
		{
			using(OutStores access = new OutStores())
			{
				return access.LoadSalesOutRecord(filter);
			}
		}

		/// <summary>
		/// 读取销售退货单信息
		/// </summary>
		/// <returns></returns>
		public OutStoreData LoadSalesReturnRecord()
		{
			using(OutStores access = new OutStores())
			{
				return access.LoadSalesReturnRecord();
			}
		}

		/// <summary>
		/// 读取移库出库单信息
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public OutStoreData LoadMoveOutRecord(string filter)
		{
			using(OutStores filterload = new OutStores())
			{
				return filterload.LoadMoveOutRecord(filter);
			}
		}

		public bool InsertOutStoreRecord(OutStoreData data)
		{
			using(OutStores insert = new OutStores())
			{
				return insert.InsertOutstore(data);
			}
		}

		public bool UpdateOutStoreRecord(OutStoreData data)
		{
			using(OutStores update =new OutStores())
			{
				return update.UpdateOutstore(data);
			}
		}

		public bool DeleteOutStoreRecord(string osrid)
		{
			using(OutStores delete = new OutStores())
			{
				return delete.DeleteOutstore(osrid);
			}
		}

		#endregion


		// 从表 TBL_OutStoreDetail 操作
		#region  // 从表 TBL_OutStoreDetail 操作

		public OutStoreDetailData LoadOutStoreDetailRecord(string osrid)
		{
			using (OutStoreDetails load  = new OutStoreDetails())
			{
				return load.loadOutStoreDetail(osrid);
			}
		}

		public OutStoreDetailData LoadsOutStoreDetailRecord(string filter)
		{
			using(OutStoreDetails access = new OutStoreDetails())
			{
				return access.LoadsOutStoreDetail(filter);
			}
		}

		public bool InsertOutStoreDetailRecord(OutStoreDetailData data)
		{
			using(OutStoreDetails insert = new OutStoreDetails())
			{
				return insert.InsertOutStoreDetail(data);
			}
		}

 		public bool UpdateOutStoreDetailRecord(OutStoreDetailData data)
		{
			using (OutStoreDetails update = new OutStoreDetails())
			{
				return update.UpdateOutStoreDetail(data);
			}
		}

		public bool DeleteOutStoreDetailRecord(string osrid, string materialid, string batchno, string attribute)
		{
			using (OutStoreDetails delete = new OutStoreDetails())
			{
				return delete.DeleteOutStoreDetail(osrid,materialid,batchno,attribute);
			}
		}
		#endregion


		//单据提交审批---(记录)移库出库提交 ///2005-9-15
		public bool SubmitOutStoreRecord(DataRow row,string department,string user, out string error)
		{
			string recordName = "审批出库";
			string id   =  row[OutStoreData.OSRID_FIELD].ToString().Trim();
			string parameter = "OSRID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}

		//获得用户可审批单据的过滤条件
		public string GetOutStoreRecordApproveFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "审批出库";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}

		#region 更新提交单的状态
		public bool UpdateOutStoreRecordStatus(string osrid,string status)
		{
			using (OutStores Access = new OutStores())
			{
				return  Access.UpdateOutStoreRecordStatus(osrid,status);
			}
		}
		#endregion

		
	}
}
