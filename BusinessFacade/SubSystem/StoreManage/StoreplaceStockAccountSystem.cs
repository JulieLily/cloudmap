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
	/// StoreplaceStockAccountSystem 的摘要说明。
	/// </summary>
	public class StoreplaceStockAccountSystem
	{
		//Begin of Add by YiChangxin 2005-8-23
		public StoreplaceStockAccountData LoadStoreplaceStockAccount(string departmentid,string houseid)
		{
			using(StoreplaceStockAccounts access = new StoreplaceStockAccounts ())
			{
				return access.LoadStoreplaceStockAccount( departmentid, houseid);
			}
		}
		//End of Added By YiChangin 2005-8-23

		//Begin of Added by WeiTaojiang 2005-7-29
		public StoreplaceStockAccountData LoadStoreplaceStockAccount(string filter)
		{
			using(StoreplaceStockAccounts load = new StoreplaceStockAccounts())
			{
				return load.LoadStoreplaceStockAccount(filter);
			}
		}
		//End of Added by WeiTaojiang 2005-7-29
	}
}
