using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.SalesManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.SalesManage;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.SalesManage
{
	/// <summary>
	/// CraftBrotherInfoSystem 的摘要说明。
	/// 时间：2005-8-29 魏套江 
	/// 模块：同行信息维护
	/// </summary>
	public class CraftBrotherInfoSystem
	{
		#region 读取主表数据
		public CraftBrotherInfoData LoadCraftBrotherInfo()
		{
			using(CraftBrotherInfos access = new CraftBrotherInfos())
			{
				return access.LoadCraftBrotherInfo();
			}
		}
		#endregion

		#region 读取从表数据
		public CraftBrotherSalesAnalysisData LoadCraftBrotherSalesAnalysis(string craftbrotherid,string departmentid)
		{
			using(CraftBrotherSalesAnalysiss access = new CraftBrotherSalesAnalysiss())
			{
				return access.LoadCraftBrotherSalesAnalysis(craftbrotherid,departmentid); 
			}
		}
		#endregion
      
		#region 读取区域编码
		public AreaData LoadArea()
		{
			using(Areas access = new Areas())
			{
				return access.LoadArea();
			}
		}
		#endregion

		#region 主表的增、删、改
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

		#region 从表的增、删、改
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
