using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.StoreManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.StoreManage;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.StoreManage
{
	/// <summary>
	/// StoreplaceSystem 的摘要说明。
	/// </summary>
	public class StoreplaceSystem
	{
		public StoreplaceData LoadStoreplace(string departmentid,string houseid)
		{
			using(Storeplaces access = new Storeplaces())
			{
				return access.LoadStoreplace(departmentid,houseid);
			}
		}

		public StoreplaceData LoadStoreplace(string departmentid)
		{
			using(Storeplaces access = new Storeplaces())
			{
				return access.LoadStoreplace(departmentid);
			}
		}

		public bool InsertStoreplace(StoreplaceData data)
		{
			using(Storeplaces access = new Storeplaces())
			{
				return access.InsertStoreplace(data);
			}
		}

		public bool UpdateStoreplace(StoreplaceData data)
		{
			using(Storeplaces access = new Storeplaces())
			{
				return access.UpdateStoreplace(data);
			}
		}

		public bool DeleteStoreplace(string departmentid,string houseid,string placeid)
		{
			using(Storeplaces access = new Storeplaces())
			{
				return access.DeleteStoreplace(departmentid,houseid,placeid);
			}
		}
	}
}
