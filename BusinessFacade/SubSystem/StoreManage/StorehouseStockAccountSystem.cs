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
	/// StorehouseStockAccountSystem ��ժҪ˵����
	/// </summary>
	public class StorehouseStockAccountSystem
	{
		public StorehouseStockAccountSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

        #region ͨ������id ���ܵ�ǰ�����ϵĿ����
		/// <summary>
		/// ͨ������id ���ܵ�ǰ�����ϵĿ����
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
