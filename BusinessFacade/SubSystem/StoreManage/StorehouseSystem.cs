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
	/// StorehouseSystem 的摘要说明。
	/// </summary>
	public class StorehouseSystem
	{
		public StorehouseSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		// load all recor 
		public StorehouseData LoadStorehouse()
		{
			using(Storehouses load = new Storehouses())
			{
				return load.LoadStorehouse();
			}
		}

		public StorehouseData LoadStorehouse(string filter)
		{
			using(Storehouses load = new Storehouses())
			{
				return load.LoadStorehouse(filter);
			}
		}

		// add
		public bool  InsertStorehouse(StorehouseData data)
		{
			using(Storehouses insert = new Storehouses())
			{
				return insert.InsertStorehouse(data);
			}
		}

		// update
		public bool  UpdateStorehouse(StorehouseData data)
		{
			using(Storehouses update = new Storehouses())
			{
				return  update.UpdateStorehouse(data);
			}
		}
	
		// delete 
		public bool  DeleteStorehouse(string houseid,string departid)
		{
			using(Storehouses delete = new Storehouses())
			{
				return delete.DeleteStorehouse(houseid,departid);		
			}
		}

		public StorehouseData LoadStorehouse(string departmentid,string houseid)
		{
			using(Storehouses access = new Storehouses())
			{
				return access.LoadStorehouse(departmentid,houseid);		
			}
		}
	}
}
