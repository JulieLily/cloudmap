using System;
using System.Data;
using System.Data.Common;

using TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.BaseSystem;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.PurchasingManage
{
	/// <summary>
	/// MaterialDayArrivedSystem ��ժҪ˵����
	/// </summary>
	public class MaterialDayArrivedSystem
	{
		#region ����������
		public MaterialDayArrivedData LoadMaterialDayArrived()
		{
			using(MaterialDayArriveds access = new MaterialDayArriveds())
			{
				return access.LoadMaterialDayArrived();
			}
		}
		#endregion

		#region �������
		public bool InsertMaterialDayArrived(MaterialDayArrivedData data)
		{
			using(MaterialDayArriveds access = new MaterialDayArriveds())
			{
				return access.InsertMaterialDayArrived(data);
			}
		}
		#endregion

		#region ��������
		public bool UpdateMaterialDayArrived(MaterialDayArrivedData data)
		{
			using(MaterialDayArriveds access = new MaterialDayArriveds())
			{
				return access.UpdateMaterialDayArrived(data);
			}
		}
		#endregion

		#region ɾ������
		public bool DeleteMaterialDayArrived(string vehicleno,string materialid,string provider,DateTime arrivaldate)
		{
			using(MaterialDayArriveds access = new MaterialDayArriveds())
			{
				return access.DeleteMaterialDayArrived(vehicleno,materialid,provider,arrivaldate);
			}
		}
		#endregion

	}
}
