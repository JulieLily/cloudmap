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
	/// 时间：2005-7-29
	/// 开发者：魏套江
	/// StoreplaceMoveSystem 的摘要说明。
	/// </summary>
	public class StoreplaceMoveSystem
	{
		#region 读数据
		public StoreplaceMoveData LoadStoreplaceMove()
		{
			using(StoreplaceMoves load = new StoreplaceMoves())
			{
				return load.LoadStoreplaceMove();
			}
		}
		#endregion

		#region 添加数据
		public bool InsertStoreplacefMove(StoreplaceMoveData data)
		{
			using(StoreplaceMoves access = new StoreplaceMoves())
			{
				return access.InsertStoreplaceMove(data);
			}
		}
		#endregion

		#region 更新数据
		public bool UpdateStoreplaceMove(StoreplaceMoveData data)
		{
			using(StoreplaceMoves access = new StoreplaceMoves())
			{
				return access.UpdateStoreplaceMove(data);
			}
		}
		#endregion

		#region 删除数据
		public bool DeleteStoreplaceMove(string pmrid,string materialid,string departmentid,string storehouseid,string targetplaceid,string souceplaceid)
		{
			using(StoreplaceMoves access = new StoreplaceMoves())
			{
				return access.DeleteStoreplaceMove(pmrid,materialid,departmentid,storehouseid,targetplaceid,souceplaceid);
			}
		}
		#endregion
	}
}
