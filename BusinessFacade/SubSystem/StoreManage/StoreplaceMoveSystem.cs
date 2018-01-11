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
	/// ʱ�䣺2005-7-29
	/// �����ߣ�κ�׽�
	/// StoreplaceMoveSystem ��ժҪ˵����
	/// </summary>
	public class StoreplaceMoveSystem
	{
		#region ������
		public StoreplaceMoveData LoadStoreplaceMove()
		{
			using(StoreplaceMoves load = new StoreplaceMoves())
			{
				return load.LoadStoreplaceMove();
			}
		}
		#endregion

		#region �������
		public bool InsertStoreplacefMove(StoreplaceMoveData data)
		{
			using(StoreplaceMoves access = new StoreplaceMoves())
			{
				return access.InsertStoreplaceMove(data);
			}
		}
		#endregion

		#region ��������
		public bool UpdateStoreplaceMove(StoreplaceMoveData data)
		{
			using(StoreplaceMoves access = new StoreplaceMoves())
			{
				return access.UpdateStoreplaceMove(data);
			}
		}
		#endregion

		#region ɾ������
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
