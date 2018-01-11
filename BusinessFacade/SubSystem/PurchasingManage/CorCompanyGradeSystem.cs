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
	/// ʱ�䣺2005-8-9
	/// �����ߣ�κ�׽�
	/// </summary>
	/// CorCompanyGradeSystem ��ժҪ˵����
	/// </summary>
	public class CorCompanyGradeSystem
	{
		public CorCompanyGradeSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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

		#region ���������ɾ����
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

		#region OutStoreDetail ������ɾ����
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

		#region �����ύ��������-----------------------------2005-9-8 κ�׽����
		/// <summary>
		/// �����ύ��������
		/// </summary>
		/// <param name="row"></param>
		/// <param name="department"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public bool SubmitSupplyCorCompanyRecord(DataRow row,string department,string user, out string error)
		{
			string recordName = "�ϸ�Ӧ������";
			string corcompanyid = row[CorCompanyGradeData.CORCOMPANYID_FIELD].ToString().Trim();
			string departmentid = row[CorCompanyGradeData.DEPARTMENTID_FIELD].ToString().Trim();
			string materialid = row[CorCompanyGradeData.MATERIALID_FIELD].ToString().Trim();
			string type = row[CorCompanyGradeData.TYPE_FIELD].ToString().Trim();
			//			string parameter="CorCompanyID='" + corcompanyid + "' and Materialid='"+materialid + "' and Departmentid='"+departmentid +"' and Type='"+type+"' ";			
    		 
			//���������ݣ�ȷ����¼����
			string parameter="CorCompanyID:" + corcompanyid + ";Materialid:"+materialid + ";Departmentid:"+departmentid +";Type:"+type+" ";			
			return (new ApproveFlow()).InitApproveFlowCase( recordName, department, user, parameter, out error);
		}
		#endregion

		#region �����ύ����״̬---------------------------------2005-9-8 κ�׽����
		
		/// <summary>
		/// �����ύ����״̬
		/// </summary>
		/// <param name="id"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		#region ����״̬
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
