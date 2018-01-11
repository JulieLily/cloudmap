using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.SalesManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.SalesManage;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.SalesManage
{
	/// <summary>
	/// CraftBrotherInfoSystem ��ժҪ˵����
	/// ʱ�䣺2005-8-29 κ�׽� 
	/// ģ�飺ͬ����Ϣά��
	/// </summary>
	public class CraftBrotherInfoSystem
	{
		#region ��ȡ��������
		public CraftBrotherInfoData LoadCraftBrotherInfo()
		{
			using(CraftBrotherInfos access = new CraftBrotherInfos())
			{
				return access.LoadCraftBrotherInfo();
			}
		}
		#endregion

		#region ��ȡ�ӱ�����
		public CraftBrotherSalesAnalysisData LoadCraftBrotherSalesAnalysis(string craftbrotherid,string departmentid)
		{
			using(CraftBrotherSalesAnalysiss access = new CraftBrotherSalesAnalysiss())
			{
				return access.LoadCraftBrotherSalesAnalysis(craftbrotherid,departmentid); 
			}
		}
		#endregion
      
		#region ��ȡ�������
		public AreaData LoadArea()
		{
			using(Areas access = new Areas())
			{
				return access.LoadArea();
			}
		}
		#endregion

		#region ���������ɾ����
		public bool InsertCraftBrotherInfo(CraftBrotherInfoData data)
		{
			using(CraftBrotherInfos access = new CraftBrotherInfos())
			{
				return access.InsertCraftBrotherInfo(data);
			}
		}

		public bool UpdateCraftBrotherInfo(CraftBrotherInfoData data)
		{
			using(CraftBrotherInfos access = new CraftBrotherInfos())
			{
				return access.UpdateCraftBrotherInfo(data);
			}
		}

		public bool DeleteCraftBrotherInfo(string departmentid,string craftbrotherid)
		{
			using(CraftBrotherInfos access = new CraftBrotherInfos())
			{
				return access.DeleteCraftBrotherInfo(departmentid,craftbrotherid);
			}
		}
		#endregion

		#region �ӱ������ɾ����
		public bool InsertCraftBrotherSalesAnalysis(CraftBrotherSalesAnalysisData data)
		{
			using(CraftBrotherSalesAnalysiss access = new CraftBrotherSalesAnalysiss())
			{
				return access.InsertCraftBrotherSalesAnalysis(data);
			}
		}

		public bool UpdateCraftBrotherSalesAnalysis(CraftBrotherSalesAnalysisData data)
		{
			using(CraftBrotherSalesAnalysiss access = new CraftBrotherSalesAnalysiss())
			{
				return access.UpdateCraftBrotherSalesAnalysis(data);
			}
		}

		public bool DeleteCraftBrotherSalesAnalysis(string areaid, string craftbrotherid, string departmentid, System.DateTime begindate,string productname )
		{
			using(CraftBrotherSalesAnalysiss access = new CraftBrotherSalesAnalysiss())
			{
				return access.DeleteCraftBrotherSalesAnalysis(areaid,craftbrotherid,departmentid,begindate,productname);
			}
		}
		#endregion
	}
}
