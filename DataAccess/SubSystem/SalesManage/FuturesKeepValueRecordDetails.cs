using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// FuturesKeepValueRecordDetails 的摘要说明。
	/// </summary>
	public class FuturesKeepValueRecordDetails :IDisposable
	{

		private SqlDataAdapter da;

		private const String OLDMATERIALID_PARM						=	"@oldMaterialID";
		private const String OLDFKVRID_PARM							=	"@oldFKVRID";

		private const String MATERIALID_PARM						=	"@MaterialID";
		private const String FKVRID_PARM							=	"@FKVRID";
		private const String PRICEMODE_PARM							=	"@PriceMode";
		private const String AMOUNT_PARM							=	"@Amount";
		private const String ITEMCONTEXT_PARM						=	"@ItemContext";

		private const String UNIT_PARM								=	"@Unit";
		private const String CHANGERATE_PARM						=	"@ChangeRate";
		private const String PRICE_PARM								=	"@Price";
		private const String SUM_FILD								=	"@Sum";
		private const String DESCRIPTION_PARM						=	"@Description";


		public FuturesKeepValueRecordDetails()
		{
		    da = new SqlDataAdapter();
			da.TableMappings.Add("Table",FuturesKeepValueRecordDetailData.FUTURESKEEPVALUERECORDDETAIL_TABLE);
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

		#region 通过主表ID读取记录
		public FuturesKeepValueRecordDetailData LoadFuturesKeepValueRecordDetails(string fkvrid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			FuturesKeepValueRecordDetailData data =  new FuturesKeepValueRecordDetailData();
			da.SelectCommand = GetLoadCommand();
			da.SelectCommand.Parameters[FKVRID_PARM].Value = fkvrid;
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
			SqlCommand load = new SqlCommand("Q_FuturesKeepValueRecordDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM, SqlDbType.Char,28);
			parm_fkvrid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_fkvrid);

			return load;
		}
		#endregion

		#region 条件读取记录
		//YiChangxin 做了修改 2005-9-21
		public FuturesKeepValueRecordDetailData LoadFuturesKeepValueRecordDetail(string filter)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			FuturesKeepValueRecordDetailData data =  new FuturesKeepValueRecordDetailData();
			da.SelectCommand = GetLoadCommand(filter);
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

		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)
				strsql = "select t.*,m.MaterialName MaterialName,m.Model Model,m.StandardUnit "
					+ "from (select * from TBL_FuturesKeepValueRecordDetail where " + filter + ") t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid ";

			else 

				strsql = "select t.*,m.MaterialName MaterialName,m.Model Model  ,m.StandardUnit"
					+ "from TBL_FuturesKeepValueRecordDetail t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid ";
			SqlCommand loadCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.Text;

			return loadCommand;
		}
		#endregion

		#region 添加记录-----期货保值单明细

		public bool InsertFuturesKeepValueRecordDetail(FuturesKeepValueRecordDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand = GetInsertCommand();
			da.Update(data ,FuturesKeepValueRecordDetailData.FUTURESKEEPVALUERECORDDETAIL_TABLE);
			if(data.HasErrors)
			{
				data.Tables[FuturesKeepValueRecordDetailData.FUTURESKEEPVALUERECORDDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand insert = new SqlCommand("I_FuturesKeepValueRecordDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.SourceColumn = FuturesKeepValueRecordDetailData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_materialid);

			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM, SqlDbType.Char);
			parm_fkvrid.SourceColumn = FuturesKeepValueRecordDetailData.FKVRID_FIELD;
			parm_fkvrid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_fkvrid);

			SqlParameter parm_pricemode = new SqlParameter(PRICEMODE_PARM, SqlDbType.Char);
			parm_pricemode.SourceColumn = FuturesKeepValueRecordDetailData.PRICEMODE_FIELD;
			parm_pricemode.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_pricemode);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM, SqlDbType.Decimal);
			parm_amount.SourceColumn = FuturesKeepValueRecordDetailData.AMOUNT_FIELD;
			parm_amount.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_amount);
			
			SqlParameter parm_itemcontext = new SqlParameter(ITEMCONTEXT_PARM, SqlDbType.VarChar);
			parm_itemcontext.SourceColumn = FuturesKeepValueRecordDetailData.ITEMCONTEXT_FIELD;
			parm_itemcontext.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_itemcontext);



			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char);
			parm_unit.SourceColumn = FuturesKeepValueRecordDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_unit);

			SqlParameter parm_changrate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changrate.SourceColumn = FuturesKeepValueRecordDetailData.CHANGERATE_FIELD;
			parm_changrate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_changrate);

			SqlParameter parm_price = new SqlParameter(PRICE_PARM, SqlDbType.Decimal);
			parm_price.SourceColumn = FuturesKeepValueRecordDetailData.PRICE_FIElD;
			parm_price.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_price);

			SqlParameter parm_sum = new SqlParameter(SUM_FILD, SqlDbType.Decimal);
			parm_sum.SourceColumn = FuturesKeepValueRecordDetailData.SUM_FILD;
			parm_sum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_sum);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar);
			parm_description.SourceColumn = FuturesKeepValueRecordDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		#endregion

		#region  更新记录 ----期货保值单明细

		public bool UpdateFuturesKeepValueRecordDetail(FuturesKeepValueRecordDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand = GetUpdateCommand();
			da.Update(data ,FuturesKeepValueRecordDetailData.FUTURESKEEPVALUERECORDDETAIL_TABLE );
			if(data.HasErrors)
			{
				data.Tables[FuturesKeepValueRecordDetailData.FUTURESKEEPVALUERECORDDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand update = new SqlCommand("U_FuturesKeepValueRecordDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM, SqlDbType.Char);   //   old MaterialID  
			parm_oldmaterialid.SourceColumn = FuturesKeepValueRecordDetailData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			parm_oldmaterialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.SourceColumn = FuturesKeepValueRecordDetailData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_materialid);

			
			SqlParameter parm_oldfkvrid = new SqlParameter(OLDFKVRID_PARM, SqlDbType.Char);     // old  FKVRID 
			parm_oldfkvrid.SourceColumn = FuturesKeepValueRecordDetailData.FKVRID_FIELD;
			parm_oldfkvrid.SourceVersion = DataRowVersion.Original;
			parm_oldfkvrid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldfkvrid);

			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM, SqlDbType.Char);
			parm_fkvrid.SourceColumn = FuturesKeepValueRecordDetailData.FKVRID_FIELD;
			parm_fkvrid.SourceVersion = DataRowVersion.Current;
			parm_fkvrid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_fkvrid);

			SqlParameter parm_pricemode = new SqlParameter(PRICEMODE_PARM, SqlDbType.Char);
			parm_pricemode.SourceColumn = FuturesKeepValueRecordDetailData.PRICEMODE_FIELD;
			parm_pricemode.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_pricemode);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM, SqlDbType.Decimal);
			parm_amount.SourceColumn = FuturesKeepValueRecordDetailData.AMOUNT_FIELD;
			parm_amount.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_amount);
			
			SqlParameter parm_itemcontext = new SqlParameter(ITEMCONTEXT_PARM, SqlDbType.VarChar);
			parm_itemcontext.SourceColumn = FuturesKeepValueRecordDetailData.ITEMCONTEXT_FIELD;
			parm_itemcontext.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_itemcontext);



			SqlParameter parm_unit = new SqlParameter(UNIT_PARM, SqlDbType.Char);
			parm_unit.SourceColumn = FuturesKeepValueRecordDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_unit);

			SqlParameter parm_changrate = new SqlParameter(CHANGERATE_PARM, SqlDbType.Real);
			parm_changrate.SourceColumn = FuturesKeepValueRecordDetailData.CHANGERATE_FIELD;
			parm_changrate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_changrate);

			SqlParameter parm_price = new SqlParameter(PRICE_PARM, SqlDbType.Decimal);
			parm_price.SourceColumn = FuturesKeepValueRecordDetailData.PRICE_FIElD;
			parm_price.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_price);

			SqlParameter parm_sum = new SqlParameter(SUM_FILD, SqlDbType.Decimal);
			parm_sum.SourceColumn = FuturesKeepValueRecordDetailData.SUM_FILD;
			parm_sum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_sum);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM, SqlDbType.VarChar);
			parm_description.SourceColumn = FuturesKeepValueRecordDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;
		}
		#endregion

		#region 删除记录----期货保值单明细

		public bool  DelteFuturesKeepValueRecordDetail(string materialid ,string fkvrid)
		{
			SqlCommand deletecommand  = GetDeleteCommand();
			deletecommand.Parameters[MATERIALID_PARM].Value	= materialid;
			deletecommand.Parameters[FKVRID_PARM].Value	= fkvrid;

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
			SqlCommand delete = new SqlCommand("D_FuturesKeepValueRecordDetail" , new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure;


			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM, SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_materialid);


			SqlParameter parm_fkvrid = new SqlParameter(FKVRID_PARM, SqlDbType.Char);
			parm_fkvrid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_fkvrid);

			return delete;
		}
		#endregion 
	}
}
