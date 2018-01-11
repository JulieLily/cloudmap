using System;
using System.Data;
using System.Data.Common;

using TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.BusinessRules.BaseSystem;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.PurchasingManage
{
	/// <summary>
	/// 时间：2005-8-9
	/// 开发者：魏套江
	/// </summary>
	/// CorCompanyGradeSystem 的摘要说明。
	/// </summary>
	public class CorCompanyGradeSystem
	{
		public CorCompanyGradeSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public CorCompanyGradeData LoadCorCompanyGrade(string filter)
		{
			using(CorCompanyGrades access = new CorCompanyGrades())
			{
				return access.LoadCorCompanyGrade(filter);
			}
		}

		public CorCommpanyMaterialPriceData LoadCorCommpanyMaterialPrice(string corcompanyid,string departmentid,string type,string materialid)
		{
			using(CorCompanyMaterialPrices access = new CorCompanyMaterialPrices())
			{
				return access.LoadCorCommpanyMaterialPrice(corcompanyid,departmentid,type,materialid);
			}
		}

		#region 主表的增、删、改
		public bool InsertCorCompanyGrade(CorCompanyGradeData data)
		{
			using(CorCompanyGrades access = new CorCompanyGrades())
			{
				return access.InsertCorCompanyGrade(data);
			}
		}

		public bool UpdateCorCompanyGrade(CorCompanyGradeData data)
		{
			using(CorCompanyGrades access = new CorCompanyGrades())
			{
				return access.UpdateCorCompanyGrade(data);
			}
		}

		public bool DeleteCorCompanyGrade(string corcompanyid,string departmentid,string type,string materialid)
		{
			using(CorCompanyGrades access = new CorCompanyGrades())
			{
				return access.DeleteCorCompanyGradeData(corcompanyid,departmentid,type,materialid);
			}
		}
		#endregion

		#region OutStoreDetail 的增、删、改
		public bool InsertCorCommpanyMaterialPrice(CorCommpanyMaterialPriceData data)
		{
			using(CorCompanyMaterialPrices access = new CorCompanyMaterialPrices())
			{
				return access.insertCorCommpanyMaterialPrice(data);
			}
		}

		public bool UpdateCorCommpanyMaterialPrice(CorCommpanyMaterialPriceData data)
		{
			using(CorCompanyMaterialPrices access = new CorCompanyMaterialPrices())
			{
				return access.UpdateCorCommpanyMaterialPrice(data);
			}
		}

		public bool DeleteCorCommpanyMaterialPrice(string corcompanyid,string departmentid,string type,string quotedate,string materialid)
		{
			using(CorCompanyMaterialPrices access = new CorCompanyMaterialPrices())
			{
				return access.DeleteCorCommpanyMaterialPrice(corcompanyid,departmentid,type,quotedate,materialid);
			}
		}
		#endregion

		#region 单据提交审批操作-----------------------------2005-9-8 魏套江添加
		/// <summary>
		/// 单据提交审批操作
		/// </summary>
		/// <param name="row"></param>
		/// <param name="department"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public bool SubmitSupplyCorCompanyRecord(DataRow row,string department,string user, out string error)
		{
			string recordName = "合格供应商评定";
			string corcompanyid = row[CorCompanyGradeData.CORCOMPANYID_FIELD].ToString().Trim();
			string departmentid = row[CorCompanyGradeData.DEPARTMENTID_FIELD].ToString().Trim();
			string materialid = row[CorCompanyGradeData.MATERIALID_FIELD].ToString().Trim();
			string type = row[CorCompanyGradeData.TYPE_FIELD].ToString().Trim();
			//			string parameter="CorCompanyID='" + corcompanyid + "' and Materialid='"+materialid + "' and Departmentid='"+departmentid +"' and Type='"+type+"' ";			
    		 
			//多主键传递，确定记录单据
			string parameter="CorCompanyID:" + corcompanyid + ";Materialid:"+materialid + ";Departmentid:"+departmentid +";Type:"+type+" ";			
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}
		#endregion

		#region 更新提交单据状态---------------------------------2005-9-8 魏套江添加
		
		/// <summary>
		/// 更新提交单据状态
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		#region 更新状态
		public bool UpdateSupplyCorCompanyRecordStatus(string CorCompanyid,string departmentid,string type,string materialid,string status)
		{
			using (CorCompanyGrades Access = new CorCompanyGrades())
			{
				return  Access.UpdateSupplyRecordStatus(CorCompanyid,departmentid,type,materialid,status);
			}
		}
		#endregion
		#endregion

	}
}
