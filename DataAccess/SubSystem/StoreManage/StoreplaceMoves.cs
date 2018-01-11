using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.StoreManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.StoreManage
{
	/// <summary>
	/// StoreplaceMoves 的摘要说明。
	/// </summary>
	public class StoreplaceMoves :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDMATERIALID_PARM                   = "@oldMaterialID";
		private const String OLDDEPARTMENTID_PARM                 = "@oldDepartmentID";
		private const String OLDSTOREHOUSEID_PARM                 = "@oldStorehouseID";
		private const String OLDTARGETPLACEID_PARM                = "@oldTargetPlaceID";
		private const String OLDSOUCEPLACEID_PARM                 = "@oldSourcePlaceID";

		private const String PMRID_PARM                        = "@PMRID";
		private const String PMRNAME_PARM                      = "@PMRName";
		private const String MATERIALID_PARM                   = "@MaterialID";
		private const String DEPARTMENTID_PARM                 = "@DepartmentID";
		private const String STOREHOUSEID_PARM                 = "@StorehouseID";
		private const String TARGETPLACEID_PARM                = "@TargetPlaceID";
		private const String SOUCEPLACEID_PARM                 = "@SourcePlaceID";

		private const String PUB_ATTRIBUTE_PARM                = "@PUB_Attribute";
		private const String BATCHNO_PARM                      = "@BatchNO";
		private const String INTIME_PARM                       = "@InTime";
		private const String MOVENUMBER_PARM                   = "@MoveNumber";
		private const String UNIT_PARM                         = "@Unit";

		private const String CHANGERATE_PARM                   = "@ChangeRate";
		private const String PRICE_PARM                        = "@Price";
		private const String DRAWPERSON_PARM                   = "@DrawPerson";
		private const String DRAWDATE_PARM                     = "@DrawDate";
		private const String STATUS_PARM                       = "@Status";

		private const String ACCOUNTDEP_PARM                   = "@AccountDep";
		private const String DESCRIPTION_PARM                  = "@Description";

		public StoreplaceMoves()
		{
		
			da=new SqlDataAdapter();
			da.TableMappings.Add("Table",StoreplaceMoveData.STOREPLACEMOVE_TABLE);
		}
		#region IDisposable 成员

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (! disposing)
				return; 
			if(da!=null)
			{
				if(da.SelectCommand!=null)
				{
					if(da.SelectCommand.Connection!=null)
					{
						da.SelectCommand.Connection.Dispose();
					}
					da.SelectCommand.Dispose();
				}

				if(da.InsertCommand!=null)
				{
					if(da.InsertCommand.Connection!=null)
					{
						da.InsertCommand.Connection.Dispose();
					}
					da.InsertCommand.Dispose();
				}

				if(da.UpdateCommand!=null)
				{
					if(da.UpdateCommand.Connection!=null)
					{
						da.UpdateCommand.Connection.Dispose();
					}
					da.UpdateCommand.Dispose();
				}

				//				if(da.DeleteCommand!=null)
				//				{
				//					if(da.DeleteCommand.Connection!=null)
				//					{
				//						da.DeleteCommand.Connection.Dispose();
				//					}
				//					da.DeleteCommand.Dispose();
				//				}
				da.Dispose();
				da=null;
			}
		}

		#endregion


		#region 读取所有记录----库位移动单

		public StoreplaceMoveData LoadStoreplaceMove()
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			StoreplaceMoveData data=new StoreplaceMoveData();
			da.SelectCommand=GetLoadCommand();
			try
			{
				da.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}

		private SqlCommand GetLoadCommand()
		{
			SqlCommand load=new SqlCommand("Q_StoreplaceMove",new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType=CommandType.StoredProcedure;

			return load;
		}
		#endregion

		#region 添家记录----库位移动单

		public bool InsertStoreplaceMove(StoreplaceMoveData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand=GetInsertCommand();
			da.Update(data,StoreplaceMoveData.STOREPLACEMOVE_TABLE);
			if(data.HasErrors)
			{
				data.Tables[StoreplaceMoveData.STOREPLACEMOVE_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand GetInsertCommand()
		{
			SqlCommand insert=new SqlCommand("I_StoreplaceMove",new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_pmrid=new SqlParameter(PMRID_PARM,SqlDbType.Char,28);
			parm_pmrid.Direction=ParameterDirection.Input;
			parm_pmrid.SourceColumn=StoreplaceMoveData.PMRID_FIELD;
			insert.Parameters.Add(parm_pmrid);

			SqlParameter parm_pname=new SqlParameter(PMRNAME_PARM,SqlDbType.Char,40);
			parm_pname.Direction=ParameterDirection.Input;
			parm_pname.SourceColumn=StoreplaceMoveData.PMRNAME_FIELD;
			insert.Parameters.Add(parm_pname);

			SqlParameter parm_materid=new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);
			parm_materid.Direction=ParameterDirection.Input;
			parm_materid.SourceColumn=StoreplaceMoveData.MATERIALID_FIELD;
			insert.Parameters.Add(parm_materid);

			SqlParameter parm_departid=new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);
			parm_departid.Direction=ParameterDirection.Input;
			parm_departid.SourceColumn=StoreplaceMoveData.DEPARTMENTID_FIELD;
			insert.Parameters.Add(parm_departid);

			SqlParameter parm_storehouseid=new SqlParameter(STOREHOUSEID_PARM,SqlDbType.Char,4);
			parm_storehouseid.Direction=ParameterDirection.Input;
			parm_storehouseid.SourceColumn=StoreplaceMoveData.STOREHOUSEID_FIELD;
			insert.Parameters.Add(parm_storehouseid);

			SqlParameter parm_targetplaceid=new SqlParameter(TARGETPLACEID_PARM,SqlDbType.Char,6);
			parm_targetplaceid.Direction=ParameterDirection.Input;
			parm_targetplaceid.SourceColumn=StoreplaceMoveData.TARGETPLACEID_FIELD;
			insert.Parameters.Add(parm_targetplaceid);

			SqlParameter parm_sourceplaceid=new SqlParameter(SOUCEPLACEID_PARM,SqlDbType.Char,6);
			parm_sourceplaceid.Direction=ParameterDirection.Input;
			parm_sourceplaceid.SourceColumn=StoreplaceMoveData.SOUCEPLACEID_FIELD;
			insert.Parameters.Add(parm_sourceplaceid);



			SqlParameter parm_pub_attribute=new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,8);
			parm_pub_attribute.Direction=ParameterDirection.Input;
			parm_pub_attribute.SourceColumn=StoreplaceMoveData.PUB_ATTRIBUTE_FIELD;
			insert.Parameters.Add(parm_pub_attribute);

			SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.Direction=ParameterDirection.Input;
			parm_batchno.SourceColumn=StoreplaceMoveData.BATCHNO_FIELD;
			insert.Parameters.Add(parm_batchno);

			SqlParameter parm_intime=new SqlParameter(INTIME_PARM,SqlDbType.DateTime,8);
			parm_intime.Direction=ParameterDirection.Input;
			parm_intime.SourceColumn=StoreplaceMoveData.INTIME_FIELD;
			insert.Parameters.Add(parm_intime);

			SqlParameter parm_movenumber=new SqlParameter(MOVENUMBER_PARM,SqlDbType.Char,9);  //  SqlTypeDb="Numeric" 只能是数字类型的(9)字符
			parm_movenumber.Direction=ParameterDirection.Input;
			parm_movenumber.SourceColumn=StoreplaceMoveData.MOVENUMBER_FIELD;
			insert.Parameters.Add(parm_movenumber);

			SqlParameter parm_unit=new SqlParameter(UNIT_PARM,SqlDbType.Char,10);
			parm_unit.Direction=ParameterDirection.Input;
			parm_unit.SourceColumn=StoreplaceMoveData.UNIT_FIELD;
			insert.Parameters.Add(parm_unit);



			SqlParameter parm_changerate=new SqlParameter(CHANGERATE_PARM,SqlDbType.Real,4);
			parm_changerate.Direction=ParameterDirection.Input;
			parm_changerate.SourceColumn=StoreplaceMoveData.CHANGERATE_FIELD;
			insert.Parameters.Add(parm_changerate);

			SqlParameter parm_price=new SqlParameter(PRICE_PARM,SqlDbType.Char,9);
			parm_price.Direction=ParameterDirection.Input;
			parm_price.SourceColumn=StoreplaceMoveData.PRICE_FIELD;
			insert.Parameters.Add(parm_price);
			 
			SqlParameter parm_drawperson=new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char,18);
			parm_drawperson.Direction=ParameterDirection.Input;
			parm_drawperson.SourceColumn=StoreplaceMoveData.DRAWPERSON_FIELD;
			insert.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate=new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime,8);
			parm_drawdate.Direction=ParameterDirection.Input;
			parm_drawdate.SourceColumn=StoreplaceMoveData.DRAWDATE_FIELD;
			insert.Parameters.Add(parm_drawdate);

			SqlParameter parm_status=new SqlParameter(STATUS_PARM,SqlDbType.Char,8);
			parm_status.Direction=ParameterDirection.Input;
			parm_status.SourceColumn=StoreplaceMoveData.STATUS_FIELD;
			insert.Parameters.Add(parm_status);



			SqlParameter parm_accountdep=new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char,10);
			parm_accountdep.Direction=ParameterDirection.Input;
			parm_accountdep.SourceColumn=StoreplaceMoveData.ACCOUNTDEP_FIELD;
			insert.Parameters.Add(parm_accountdep);

			SqlParameter parm_description=new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar,200);
			parm_description.Direction=ParameterDirection.Input;
			parm_description.SourceColumn=StoreplaceMoveData.DESCRIPTION_FIELD;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		#endregion

		//Modified by WeiTaojiang 2005-9-2
		#region 更新记录-----库位移动单
		public bool UpdateStoreplaceMove(StoreplaceMoveData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			da.UpdateCommand=GetUpdateCommand();

			da.Update(data,StoreplaceMoveData.STOREPLACEMOVE_TABLE);
			if(data.HasErrors)
			{
				data.Tables[StoreplaceMoveData.STOREPLACEMOVE_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand  GetUpdateCommand()
		{
			SqlCommand update=new SqlCommand("U_StoreplaceMove",new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_pmrid=new SqlParameter(PMRID_PARM,SqlDbType.Char,28);    // update  条件  1---- PMRID
			parm_pmrid.Direction=ParameterDirection.Input;
			parm_pmrid.SourceColumn=StoreplaceMoveData.PMRID_FIELD;
			update.Parameters.Add(parm_pmrid);

			SqlParameter parm_pname=new SqlParameter(PMRNAME_PARM,SqlDbType.Char,40); 
			parm_pname.Direction=ParameterDirection.Input;
			parm_pname.SourceColumn=StoreplaceMoveData.PMRNAME_FIELD;
			update.Parameters.Add(parm_pname);

			//			SqlParameter parm_oldmaterid=new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char,20);   //  ------- old MaterialID 
			//			parm_oldmaterid.Direction=ParameterDirection.Input;
			//			parm_oldmaterid.SourceColumn=StoreplaceMoveData.MATERIALID_FIELD;
			//			parm_oldmaterid.SourceVersion=DataRowVersion.Original;
			//			update.Parameters.Add(parm_oldmaterid);

			SqlParameter parm_materid=new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);   //  -------MaterialID
			parm_materid.Direction=ParameterDirection.Input;
			parm_materid.SourceColumn=StoreplaceMoveData.MATERIALID_FIELD;
			//			parm_materid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_materid);

			//			SqlParameter parm_olddepartid=new SqlParameter(OLDDEPARTMENTID_PARM,SqlDbType.Char,10);  //-----old  DepartmentID 
			//			parm_olddepartid.Direction=ParameterDirection.Input;
			//			parm_olddepartid.SourceColumn=StoreplaceMoveData.DEPARTMENTID_FIELD;
			//			parm_olddepartid.SourceVersion=DataRowVersion.Original;
			//			update.Parameters.Add(parm_olddepartid);

			SqlParameter parm_departid=new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);      //-----DepartmentID 
			parm_departid.Direction=ParameterDirection.Input;
			parm_departid.SourceColumn=StoreplaceMoveData.DEPARTMENTID_FIELD;
			//			parm_departid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_departid);

			//			SqlParameter parm_oldstorehouseid=new SqlParameter(OLDSTOREHOUSEID_PARM,SqlDbType.Char,4); // --------old   StorehouseID
			//			parm_oldstorehouseid.Direction=ParameterDirection.Input;
			//			parm_oldstorehouseid.SourceColumn=StoreplaceMoveData.STOREHOUSEID_FIELD;
			//			parm_oldstorehouseid.SourceVersion=DataRowVersion.Original;
			//			update.Parameters.Add(parm_oldstorehouseid);

			SqlParameter parm_storehouseid=new SqlParameter(STOREHOUSEID_PARM,SqlDbType.Char,4); // -------- StorehouseID
			parm_storehouseid.Direction=ParameterDirection.Input;
			parm_storehouseid.SourceColumn=StoreplaceMoveData.STOREHOUSEID_FIELD;
			//			parm_storehouseid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_storehouseid);

			//			SqlParameter parm_oldtargetplaceid=new SqlParameter(OLDTARGETPLACEID_PARM,SqlDbType.Char,6);  //  ---------old  TargetPlaceID
			//			parm_oldtargetplaceid.Direction=ParameterDirection.Input;
			//			parm_oldtargetplaceid.SourceColumn=StoreplaceMoveData.TARGETPLACEID_FIELD;
			//			parm_oldtargetplaceid.SourceVersion=DataRowVersion.Original;
			//			update.Parameters.Add(parm_oldtargetplaceid);

			SqlParameter parm_targetplaceid = new SqlParameter(TARGETPLACEID_PARM,SqlDbType.Char,6);  //  ---------TargetPlaceID
			parm_targetplaceid.Direction=ParameterDirection.Input;
			parm_targetplaceid.SourceColumn=StoreplaceMoveData.TARGETPLACEID_FIELD;
			//			parm_targetplaceid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_targetplaceid);

			//			SqlParameter parm_oldsourceplaceid = new SqlParameter(OLDSOUCEPLACEID_PARM,SqlDbType.Char,6);  // ------- old  SourcePlaceID
			//			parm_oldsourceplaceid.Direction = ParameterDirection.Input;
			//			parm_oldsourceplaceid.SourceColumn = StoreplaceMoveData.SOUCEPLACEID_FIELD;
			//			parm_oldsourceplaceid.SourceVersion = DataRowVersion.Original;
			//			update.Parameters.Add(parm_oldsourceplaceid);

			SqlParameter parm_sourceplaceid=new SqlParameter(SOUCEPLACEID_PARM,SqlDbType.Char,6);  // --------SourcePlaceID
			parm_sourceplaceid.Direction=ParameterDirection.Input;
			parm_sourceplaceid.SourceColumn=StoreplaceMoveData.SOUCEPLACEID_FIELD;
			//			parm_sourceplaceid.SourceVersion=DataRowVersion.Current;
			update.Parameters.Add(parm_sourceplaceid);



			SqlParameter parm_pub_attribute=new SqlParameter(PUB_ATTRIBUTE_PARM,SqlDbType.Char,8);
			parm_pub_attribute.Direction=ParameterDirection.Input;
			parm_pub_attribute.SourceColumn=StoreplaceMoveData.PUB_ATTRIBUTE_FIELD;
			update.Parameters.Add(parm_pub_attribute);

			SqlParameter parm_batchno=new SqlParameter(BATCHNO_PARM,SqlDbType.Char,28);
			parm_batchno.Direction=ParameterDirection.Input;
			parm_batchno.SourceColumn=StoreplaceMoveData.BATCHNO_FIELD;
			update.Parameters.Add(parm_batchno);

			SqlParameter parm_intime=new SqlParameter(INTIME_PARM,SqlDbType.DateTime,8);
			parm_intime.Direction=ParameterDirection.Input;
			parm_intime.SourceColumn=StoreplaceMoveData.INTIME_FIELD;
			update.Parameters.Add(parm_intime);

			SqlParameter parm_movenumber=new SqlParameter(MOVENUMBER_PARM,SqlDbType.Char,9);  //  SqlTypeDb="Numeric" 只能是数字类型的(9)字符
			parm_movenumber.Direction=ParameterDirection.Input;
			parm_movenumber.SourceColumn=StoreplaceMoveData.MOVENUMBER_FIELD;
			update.Parameters.Add(parm_movenumber);

			SqlParameter parm_unit=new SqlParameter(UNIT_PARM,SqlDbType.Char,10);
			parm_unit.Direction=ParameterDirection.Input;
			parm_unit.SourceColumn=StoreplaceMoveData.UNIT_FIELD;
			update.Parameters.Add(parm_unit);

			SqlParameter parm_changerate=new SqlParameter(CHANGERATE_PARM,SqlDbType.Real,4);
			parm_changerate.Direction=ParameterDirection.Input;
			parm_changerate.SourceColumn=StoreplaceMoveData.CHANGERATE_FIELD;
			update.Parameters.Add(parm_changerate);

			SqlParameter parm_price=new SqlParameter(PRICE_PARM,SqlDbType.Char,9);
			parm_price.Direction=ParameterDirection.Input;
			parm_price.SourceColumn=StoreplaceMoveData.PRICE_FIELD;
			update.Parameters.Add(parm_price);
			 
			SqlParameter parm_drawperson=new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char,18);
			parm_drawperson.Direction=ParameterDirection.Input;
			parm_drawperson.SourceColumn=StoreplaceMoveData.DRAWPERSON_FIELD;
			update.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate=new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime,8);
			parm_drawdate.Direction=ParameterDirection.Input;
			parm_drawdate.SourceColumn=StoreplaceMoveData.DRAWDATE_FIELD;
			update.Parameters.Add(parm_drawdate);

			SqlParameter parm_status=new SqlParameter(STATUS_PARM,SqlDbType.Char,8);
			parm_status.Direction=ParameterDirection.Input;
			parm_status.SourceColumn=StoreplaceMoveData.STATUS_FIELD;
			update.Parameters.Add(parm_status);

			SqlParameter parm_accountdep=new SqlParameter(ACCOUNTDEP_PARM,SqlDbType.Char,10);
			parm_accountdep.Direction=ParameterDirection.Input;
			parm_accountdep.SourceColumn=StoreplaceMoveData.ACCOUNTDEP_FIELD;
			update.Parameters.Add(parm_accountdep);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar,200);
			parm_description.Direction = ParameterDirection.Input;
			parm_description.SourceColumn = StoreplaceMoveData.DESCRIPTION_FIELD;
			update.Parameters.Add(parm_description);

			return update;
		}
		#endregion

		#region 删除---库位移动单

		public bool DeleteStoreplaceMove(string pmrid ,string materialid,string departid,string storehouseid,string targetplaceid,string souceplaceid)
		{
			SqlCommand deletecommand = GetDeleteCommand();
			deletecommand.Parameters[PMRID_PARM].Value=pmrid;
			deletecommand.Parameters[MATERIALID_PARM].Value=materialid;
			deletecommand.Parameters[DEPARTMENTID_PARM].Value=departid;
			deletecommand.Parameters[STOREHOUSEID_PARM].Value=storehouseid;
			deletecommand.Parameters[TARGETPLACEID_PARM].Value=targetplaceid;
			deletecommand.Parameters[SOUCEPLACEID_PARM].Value=souceplaceid;
			try
			{
				deletecommand.Connection.Open();
				if(deletecommand.ExecuteNonQuery()>0)
					return true;
				else
					return false;
			}
			catch
			{

				return false;
			}
			finally
			{
				deletecommand.Connection.Close();
				deletecommand.Connection.Dispose();
				deletecommand.Dispose();
			}
		}

		private SqlCommand GetDeleteCommand()
		{
			SqlCommand delete = new SqlCommand("D_StoreplaceMove",new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType=CommandType.StoredProcedure;

			SqlParameter parm_pmrid=new SqlParameter(PMRID_PARM,SqlDbType.Char,28);    // update  条件  1---- PMRID
			parm_pmrid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_pmrid);

			SqlParameter parm_materid=new SqlParameter(MATERIALID_PARM,SqlDbType.Char,20);   //  -------MaterialID
			parm_materid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_materid);

			SqlParameter parm_departid=new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char,10);      //-----DepartmentID 
			parm_departid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_departid);

			SqlParameter parm_storehouseid=new SqlParameter(STOREHOUSEID_PARM,SqlDbType.Char,4); // -------- StorehouseID
			parm_storehouseid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_storehouseid);

			SqlParameter parm_targetplaceid = new SqlParameter(TARGETPLACEID_PARM,SqlDbType.Char,6);  //  ---------TargetPlaceID
			parm_targetplaceid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_targetplaceid);

			SqlParameter parm_sourceplaceid=new SqlParameter(SOUCEPLACEID_PARM,SqlDbType.Char,6);  // --------SourcePlaceID
			parm_sourceplaceid.Direction=ParameterDirection.Input;
			delete.Parameters.Add(parm_sourceplaceid);

			return delete;
		}
		#endregion
	}
}