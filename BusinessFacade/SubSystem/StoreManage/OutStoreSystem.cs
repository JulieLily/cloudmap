using System;
using System.Data;
using System.Collections;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data.BaseSystem;
using TOPSUN.ERP.Common.Data.StoreManage;

using TOPSUN.ERP.DataAccess.BaseSystem;
using TOPSUN.ERP.DataAccess.SubSystem.StoreManage;
using TOPSUN.ERP.BusinessFacade.BaseSystem;
using TOPSUN.ERP.BusinessRules.BaseSystem;

namespace TOPSUN.ERP.BusinessFacade.SubSystem.StoreManage
{
	/// <summary>
	/// OutStoreSystem ��ժҪ˵����
	/// ������ �콨��
	/// ���� ��2005-8-04
	/// </summary>
	public class OutStoreSystem
	{
		// ���� TBL_OutStore ����
		#region  ���� TBL_OutStore ����

		/// <summary>
		/// ��ȡ��ͨ���ⵥ��Ϣ
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public OutStoreData LoadOutStoreRecord(string filter)
		{
			using(OutStores filterload = new OutStores())
			{
				return filterload.LoadOutStoreRecord(filter);
			}
		}

		/// <summary>
		/// ��ȡ���۳��ⵥ��Ϣ
		/// </summary>
		/// <returns></returns>
		public OutStoreData LoadSalesOutRecord(string filter)
		{
			using(OutStores access = new OutStores())
			{
				return access.LoadSalesOutRecord(filter);
			}
		}

		/// <summary>
		/// ��ȡ�����˻�����Ϣ
		/// </summary>
		/// <returns></returns>
		public OutStoreData LoadSalesReturnRecord()
		{
			using(OutStores access = new OutStores())
			{
				return access.LoadSalesReturnRecord();
			}
		}

		/// <summary>
		/// ��ȡ�ƿ���ⵥ��Ϣ
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public OutStoreData LoadMoveOutRecord(string filter)
		{
			using(OutStores filterload = new OutStores())
			{
				return filterload.LoadMoveOutRecord(filter);
			}
		}

		public bool InsertOutStoreRecord(OutStoreData data)
		{
			using(OutStores insert = new OutStores())
			{
				return insert.InsertOutstore(data);
			}
		}

		public bool UpdateOutStoreRecord(OutStoreData data)
		{
			using(OutStores update =new OutStores())
			{
				return update.UpdateOutstore(data);
			}
		}

		public bool DeleteOutStoreRecord(string osrid)
		{
			using(OutStores delete = new OutStores())
			{
				return delete.DeleteOutstore(osrid);
			}
		}

		#endregion


		// �ӱ� TBL_OutStoreDetail ����
		#region  // �ӱ� TBL_OutStoreDetail ����

		public OutStoreDetailData LoadOutStoreDetailRecord(string osrid)
		{
			using (OutStoreDetails load  = new OutStoreDetails())
			{
				return load.loadOutStoreDetail(osrid);
			}
		}

		public OutStoreDetailData LoadsOutStoreDetailRecord(string filter)
		{
			using(OutStoreDetails access = new OutStoreDetails())
			{
				return access.LoadsOutStoreDetail(filter);
			}
		}

		public bool InsertOutStoreDetailRecord(OutStoreDetailData data)
		{
			using(OutStoreDetails insert = new OutStoreDetails())
			{
				return insert.InsertOutStoreDetail(data);
			}
		}

 		public bool UpdateOutStoreDetailRecord(OutStoreDetailData data)
		{
			using (OutStoreDetails update = new OutStoreDetails())
			{
				return update.UpdateOutStoreDetail(data);
			}
		}

		public bool DeleteOutStoreDetailRecord(string osrid, string materialid, string batchno, string attribute)
		{
			using (OutStoreDetails delete = new OutStoreDetails())
			{
				return delete.DeleteOutStoreDetail(osrid,materialid,batchno,attribute);
			}
		}
		#endregion


		//�����ύ����---(��¼)�ƿ�����ύ ///2005-9-15
		public bool SubmitOutStoreRecord(DataRow row,string department,string user, out string error)
		{
			string recordName = "��������";
			string id   =  row[OutStoreData.OSRID_FIELD].ToString().Trim();
			string parameter = "OSRID:" + id;
			return (new ApproveFlowSystem()).InitializeApproveFlowCase( recordName, department, user, parameter, out error);
		}

		//����û����������ݵĹ�������
		public string GetOutStoreRecordApproveFilter(string department,string user)
		{
			if(department!=""&&user!="")
			{
				string recordName = "��������";
				return (new ApproveFlow()).GetRecordFilter(recordName,department,user);
			}
			else
				return null;
		}

		#region �����ύ����״̬
		public bool UpdateOutStoreRecordStatus(string osrid,string status)
		{
			using (OutStores Access = new OutStores())
			{
				return  Access.UpdateOutStoreRecordStatus(osrid,status);
			}
		}
		#endregion

		
	}
}
