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
	/// StorehouseStockAccountSystem 的摘要说明。
	/// </summary>
	public class StorehouseStockAccountSystem
	{
		public StorehouseStockAccountSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        #region 通过物料id 汇总当前的物料的库存量
		/// <summary>
		/// 通过物料id 汇总当前的物料的库存量
		/// Added by XuJiansong 2005-8-29
		/// </summary>
		/// <param name="materialid"></param>
		/// <returns></returns>
		public StorehouseStockAccountData GetMaterialStock(string materialid)
		{
			using(StorehouseStockAccounts loadstock = new StorehouseStockAccounts())
			{
				return loadstock.LoadStorehouseMaterialStock(materialid);
			}
		}
		#endregion
	}
}
