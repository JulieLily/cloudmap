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
	
	public class FuturesKeepValueRecordSystem
	{
		public FuturesKeepValueRecordData LoadsFuturesKeepValueRecord(string filter)
		{
			using(FuturesKeepValueRecords access = new FuturesKeepValueRecords  ())
			{
				return access.LoadsFuturesKeepValueRecord(filter);
			}
		}
	
		public bool InsertFuturesKeepValueRecord(FuturesKeepValueRecordData data)
		{
			using(FuturesKeepValueRecords access = new FuturesKeepValueRecords ())
			{
				return access.InsertFuturesKeepValueRecord(data);
			}
		}

		public bool UpdateFuturesKeepValueRecord(FuturesKeepValueRecordData data)
		{
			using(FuturesKeepValueRecords access = new FuturesKeepValueRecords())
			{
				return access.UpdateFuturesKeepValueRecord(data);
			}
		}

		public bool DeleteFuturesKeepValueRecord(string fkvrid)
		{
			using(FuturesKeepValueRecords access = new FuturesKeepValueRecords())
			{
				return access.DeleteFuturesKeepValueRecord(fkvrid);
			}
		}

		public SalesContractData LoadsSalesContract(string filter)
		{
			using(SalesContracts access = new SalesContracts ())
			{
				return access.LoadsSalesContract(filter);
			}
		}

		//FuturesKeepValueRecordDetail
		public FuturesKeepValueRecordDetailData LoadFuturesKeepValueRecordDetailRecords(string fkvrid)
		{
			using(FuturesKeepValueRecordDetails access = new FuturesKeepValueRecordDetails ())
			{
				return access.LoadFuturesKeepValueRecordDetails(fkvrid);
			}
		}

		public FuturesKeepValueRecordDetailData LoadFuturesKeepValueRecordDetailRecord(string filter)
		{
			using(FuturesKeepValueRecordDetails access = new FuturesKeepValueRecordDetails ())
			{
				return access.LoadFuturesKeepValueRecordDetail(filter);
			}
		}
		
		public bool InsertFuturesKeepValueRecordDetailRecord(FuturesKeepValueRecordDetailData data)
		{
			using(FuturesKeepValueRecordDetails access = new FuturesKeepValueRecordDetails ())
			{
				return access.InsertFuturesKeepValueRecordDetail(data);
			}
		}

		public bool UpdateFuturesKeepValueRecordDetailRecord(FuturesKeepValueRecordDetailData data)
		{
			using(FuturesKeepValueRecordDetails access = new FuturesKeepValueRecordDetails ())
			{
				return access.UpdateFuturesKeepValueRecordDetail(data);
			}
		}

		public bool DeleteFuturesKeepValueRecordDetailRecord(string fkvrid, string materialid)
		{
			using(FuturesKeepValueRecordDetails access = new FuturesKeepValueRecordDetails())
			{
				return access.DelteFuturesKeepValueRecordDetail(fkvrid,materialid);
			}
		}

		//begin add by YiChangxin 2005-9-13
		public bool SubmitFuturesKeepValue(DataRow row,string department, string user,out string error)
		{
			string recordName = "期货保值单";
			string id = row[FuturesKeepValueRecordData.FKVRID_FIELD].ToString().Trim();
			string parameter = "FKVRID:" + id;
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}

		public string GetFuturesKeepValueFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "期货保值单";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}
		//end 2005-9-13
	}
}
