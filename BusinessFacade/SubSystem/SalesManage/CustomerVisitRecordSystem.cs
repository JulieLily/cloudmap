using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.SalesManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.SalesManage;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.SalesManage
{
	
	public class CustomerVisitRecordSystem
	{
		public CustomerVisitRecordData LoadsCustomerVisitRecord(string filter)
		{
			using(CustomerVisitRecords access = new CustomerVisitRecords())
			{
				return access.LoadCustomerVisitRecord(filter);
			}
		}
	
		public bool InsertCustomerVisitRecord(CustomerVisitRecordData data)
		{
			using(CustomerVisitRecords access = new CustomerVisitRecords ())
			{
				return access.InsertCustomerVisitRecord(data);
			}
		}

		public bool UpdateCustomerVisitRecord(CustomerVisitRecordData data)
		{
			using(CustomerVisitRecords access = new CustomerVisitRecords())
			{
				return access.UpdateCustomerVisitRecord(data);
			}
		}

		public bool DeleteCustomerVisitRecord(string cvrid)
		{
			using(CustomerVisitRecords access = new CustomerVisitRecords())
			{
				return access.DeleteCustomerVisitRecord(cvrid);
			}
		}
	}
}
