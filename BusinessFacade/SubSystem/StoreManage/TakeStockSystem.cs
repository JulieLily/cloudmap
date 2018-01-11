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
	/// TakeStockSystem 的摘要说明。
	/// </summary>
	public class TakeStockSystem
	{
		public TakeStockData LoadTakeStockRecord(string filter)
		{
			using(TakeStocks access = new TakeStocks())
			{
				return access.LoadTakeStock(filter);
			}
		}

		public TakeStockDetailData LoadTakeStockDetailRecord(string tsrid)
		{
			using(TakeStockDetails access = new TakeStockDetails())
			{
				return access.LoadTakeStockDetail(tsrid);
			}
		}

		public bool InsertTakeStockRecord(TakeStockData data)
		{
			using(TakeStocks access = new TakeStocks())
			{
				return access.InsertTakeStock(data);
			}
		}

		public bool UpdateTakeStockRecord(TakeStockData data)
		{
			using(TakeStocks access = new TakeStocks())
			{
				return access.UpdateTakeStock(data);
			}
		}

		public bool DeleteTakeStockRecord(string tsrid)
		{
			using(TakeStocks access = new TakeStocks ())
			{
				return access.DeleteTakeStock(tsrid);
			}
		}
		public bool InsertTakeStockDetailRecord(TakeStockDetailData data)
		{
			using(TakeStockDetails access = new TakeStockDetails ())
			{
				return access.InsertTakeStockDetail(data);
			}
		}

		public bool UpdateTakeStockDetailRecord(TakeStockDetailData data)
		{
			using(TakeStockDetails access = new TakeStockDetails())
			{
				return access.UpdateTakeStockDetail(data);
			}
		}

		//begin add by YiChangxin 2005-9-13
		public bool SubmitTakeStock(DataRow row,string department,string user, out string error)
		{
			string recordName = "盘点单";
			string id = row[TakeStockData.TSRID_FIELD].ToString().Trim();
			string parameter = "TSRID:" + id;
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}

		public string GetTakeStockFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "盘点单";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}
		//end 2005-9-13
	}	 
}
