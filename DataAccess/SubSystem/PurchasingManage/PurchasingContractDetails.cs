using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	/// <summary>
	/// PurchasingContractDetails 的摘要说明。
	/// </summary>
	  

	public class PurchasingContractDetails :IDisposable
	{
		private SqlDataAdapter da;

		private const String OLDMATERIALID_PARM					= "@oldMaterialID";
		private const String OLDCONTRACTID_PARM					= "@oldContractID";


		private const String CONTRACTID_PARM					= "@ContractID";
		private const String PRICEMODE_PARM						= "@PriceMode";
		private const String MATERIALID_PARM					= "@MaterialID";
		private const String AMOUNT_PARM						= "@Amount";
		private const String UNIT_PARM							= "@Unit";

		private const String CHANGERATE_PARM					= "@ChangeRate";
		private const String PRICE_PARM							= "@Price";
		private const String TAXRATE_PARM						= "@TaxRate";
		private const String DISCOUNTRATE_PARM					= "@DiscountRate";
		private const String DISCOUNTSUM_PARM					= "@DiscountSum";
		
		private const String ALLSUM_PARM						= "@AllSum";
		private const String WITHOUTTAXSUM_PARM					= "@WithoutTaxSum";
		private const String TAXSUM_PARM						= "@TaxSum";
		private const String ITEMCONTEXT_PARM					= "@ItemContext";
		private const String DESCRIPTION_PARM					= "@Description";

		public PurchasingContractDetails()
		{
			da =new SqlDataAdapter();
			da.TableMappings.Add("Table",PurchasingContractDetailData.PURCHARINGCONTRACTDETAIL_TABLE);
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

		#region 读取数据----采购合同明细
		//begin of Modified by YiChangXin  2005-8-26		
		public PurchasingContractDetailData LoadPurchasingContractDetails(string contractid)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}	
			PurchasingContractDetailData data = new PurchasingContractDetailData();
			da.SelectCommand = GetLoadCommand();
			da.SelectCommand.Parameters[CONTRACTID_PARM].Value = contractid;
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

		private SqlCommand GetLoadCommand ()
		{
			SqlCommand load = new SqlCommand("Q_PurchasingContractDetail" ,new SqlConnection(ERPConfiguration.ConnectionString));
			load.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM, SqlDbType.Char,28);
			parm_contractid.Direction = ParameterDirection.Input;
			load.Parameters.Add(parm_contractid);
			return load;
		}
		//end of Modified 2005-8-26
		#endregion

		//Modified by XuJiansong 2005-9-2
		#region 条件读取信息		
		//Begin of Added by YiChangxin 2005-8-30
		private SqlCommand GetLoadsCommand(string filter)
		{
			string strsql;

			if(filter!=""&&filter!=null)

				strsql = "select t.*,m.MaterialName MaterialName,m.Model Model,m.StandardUnit "
					+ "from (select * from TBL_PurchasingContractdetail where " + filter + ") t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid ";
				// Modify  by  Xujiansong  Add FIELD ----------- M.StandardUnit

			else 

				
		
				strsql = "select t.*,m.MaterialName MaterialName,m.Model Model  ,m.StandardUnit"
					+ "from TBL_PurchasingContractdetail t "
					+ "left JOIN TBL_Material m ON m.Materialid =t.Materialid ";
	
			
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public PurchasingContractDetailData LoadPurchasingContractDetail(string filter)
		{
			if ( da == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			PurchasingContractDetailData data = new PurchasingContractDetailData  ();
			
			da.SelectCommand = GetLoadsCommand(filter);
			
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
		//End of Add 2005-8-30
		#endregion		

		#region 添加数据----采购合同明细
		//begin of Modified by YiChangXin  2005-8-26
		public bool InsertPurchasingContractDetail(PurchasingContractDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.InsertCommand =GetInsertCommand ();
			da.Update(data ,PurchasingContractDetailData.PURCHARINGCONTRACTDETAIL_TABLE);
			if(data.HasErrors)
			{
				data.Tables[PurchasingContractDetailData.PURCHARINGCONTRACTDETAIL_TABLE].GetErrors()[0].ClearErrors();
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
			SqlCommand  insert = new SqlCommand("I_PurchasingContractDetail" ,new SqlConnection(ERPConfiguration.ConnectionString));
			insert.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.SourceColumn = PurchasingContractDetailData.CONTRACTID_FIELD;
			parm_contractid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_contractid);

			SqlParameter parm_pricemode = new SqlParameter(PRICEMODE_PARM,SqlDbType.Char);
			parm_pricemode.SourceColumn = PurchasingContractDetailData.PRICEMODE_FIELD;
			parm_pricemode.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_pricemode);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = PurchasingContractDetailData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_materialid);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.SourceColumn = PurchasingContractDetailData.AMOUNT_FIELD;//YCX	修改 2005-8-26
			parm_amount.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_amount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.SourceColumn = PurchasingContractDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_unit);


			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.SourceColumn = PurchasingContractDetailData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_changerate);

			SqlParameter parm_price = new SqlParameter(PRICE_PARM,SqlDbType.Decimal);
			parm_price.SourceColumn = PurchasingContractDetailData.PRICE_FIELD;
			parm_price.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_price);

			SqlParameter parm_taxrate = new SqlParameter(TAXRATE_PARM,SqlDbType.Decimal);
			parm_taxrate.SourceColumn = PurchasingContractDetailData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_taxrate);

			SqlParameter parm_discountrate = new SqlParameter(DISCOUNTRATE_PARM,SqlDbType.Decimal);
			parm_discountrate.SourceColumn = PurchasingContractDetailData.DISCOUNTRATE_FIELD;
			parm_discountrate.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_discountrate);

			SqlParameter parm_discountsum = new SqlParameter(DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_discountsum.SourceColumn = PurchasingContractDetailData.DISCOUNTSUM_FIELD;
			parm_discountsum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_discountsum);


			SqlParameter parm_allsum = new SqlParameter(ALLSUM_PARM,SqlDbType.Decimal);
			parm_allsum.SourceColumn = PurchasingContractDetailData.ALLSUM_FIELD;
			parm_allsum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_allsum);

			SqlParameter parm_withouttaxsum = new SqlParameter(WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_withouttaxsum.SourceColumn = PurchasingContractDetailData.WITHOUTTAXSUM_FIELD;
			parm_withouttaxsum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_withouttaxsum);

			SqlParameter parm_taxsum = new SqlParameter(TAXSUM_PARM,SqlDbType.Decimal);
			parm_taxsum.SourceColumn = PurchasingContractDetailData.TAXSUM_FIELD;
			parm_taxsum.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_taxsum);

			SqlParameter parm_itemcontext = new SqlParameter(ITEMCONTEXT_PARM,SqlDbType.VarChar);
			parm_itemcontext.SourceColumn = PurchasingContractDetailData.ITEMCONTEXT_FIELD;
			parm_itemcontext.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_itemcontext);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.SourceColumn = PurchasingContractDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insert.Parameters.Add(parm_description);

			return insert;
		}
		//end of Modified 2005-8-26
		#endregion
		
		#region 更新数据----采购合同明细
		//begin of Modified by YiChangXin  2005-8-26
		public bool UpdatePurchasingContractDetail(PurchasingContractDetailData data)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			da.UpdateCommand = GetUpdateCommand();
			da.Update(data,PurchasingContractDetailData.PURCHARINGCONTRACTDETAIL_TABLE);
			if(data.HasErrors)
			{
				data.Tables[PurchasingContractDetailData.PURCHARINGCONTRACTDETAIL_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				data.AcceptChanges();
				return true;
			}
		}

		private SqlCommand GetUpdateCommand()
		{
			SqlCommand  update = new SqlCommand("U_PurchasingContractDetail" ,new SqlConnection(ERPConfiguration.ConnectionString));
			update.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_oldcontractid = new SqlParameter(OLDCONTRACTID_PARM,SqlDbType.Char);   
			parm_oldcontractid.SourceColumn = PurchasingContractDetailData.CONTRACTID_FIELD;
			parm_oldcontractid.SourceVersion = DataRowVersion.Original;
			parm_oldcontractid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldcontractid);

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.SourceColumn = PurchasingContractDetailData.CONTRACTID_FIELD;
			parm_contractid.SourceVersion = DataRowVersion.Current;
			parm_contractid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_contractid);

			SqlParameter parm_pricemode = new SqlParameter(PRICEMODE_PARM,SqlDbType.Char);   
			parm_pricemode.SourceColumn = PurchasingContractDetailData.PRICEMODE_FIELD;
			parm_pricemode.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_pricemode);

			SqlParameter parm_oldmaterialid = new SqlParameter(OLDMATERIALID_PARM,SqlDbType.Char);   
			parm_oldmaterialid.SourceColumn = PurchasingContractDetailData.MATERIALID_FIELD;
			parm_oldmaterialid.SourceVersion = DataRowVersion.Original;
			parm_oldmaterialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_oldmaterialid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char); 
			parm_materialid.SourceColumn = PurchasingContractDetailData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_materialid);

			SqlParameter parm_amount = new SqlParameter(AMOUNT_PARM,SqlDbType.Decimal);
			parm_amount.SourceColumn = PurchasingContractDetailData.AMOUNT_FIELD;              //YCX	修改 2005-8-26
			parm_amount.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_amount);

			SqlParameter parm_unit = new SqlParameter(UNIT_PARM,SqlDbType.Char);
			parm_unit.SourceColumn = PurchasingContractDetailData.UNIT_FIELD;
			parm_unit.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_unit);


			SqlParameter parm_changerate = new SqlParameter(CHANGERATE_PARM,SqlDbType.Real);
			parm_changerate.SourceColumn = PurchasingContractDetailData.CHANGERATE_FIELD;
			parm_changerate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_changerate);

			SqlParameter parm_price = new SqlParameter(PRICE_PARM,SqlDbType.Decimal);
			parm_price.SourceColumn = PurchasingContractDetailData.PRICE_FIELD;
			parm_price.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_price);

			SqlParameter parm_taxrate = new SqlParameter(TAXRATE_PARM,SqlDbType.Decimal);
			parm_taxrate.SourceColumn = PurchasingContractDetailData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_taxrate);

			SqlParameter parm_discountrate = new SqlParameter(DISCOUNTRATE_PARM,SqlDbType.Decimal);
			parm_discountrate.SourceColumn = PurchasingContractDetailData.DISCOUNTRATE_FIELD;
			parm_discountrate.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_discountrate);

			SqlParameter parm_discountsum = new SqlParameter(DISCOUNTSUM_PARM,SqlDbType.Decimal);
			parm_discountsum.SourceColumn = PurchasingContractDetailData.DISCOUNTSUM_FIELD;
			parm_discountsum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_discountsum);


			SqlParameter parm_allsum = new SqlParameter(ALLSUM_PARM,SqlDbType.Decimal);
			parm_allsum.SourceColumn = PurchasingContractDetailData.ALLSUM_FIELD;
			parm_allsum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_allsum);

			SqlParameter parm_withouttaxsum = new SqlParameter(WITHOUTTAXSUM_PARM,SqlDbType.Decimal);
			parm_withouttaxsum.SourceColumn = PurchasingContractDetailData.WITHOUTTAXSUM_FIELD;
			parm_withouttaxsum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_withouttaxsum);

			SqlParameter parm_taxsum = new SqlParameter(TAXSUM_PARM,SqlDbType.Decimal);
			parm_taxsum.SourceColumn = PurchasingContractDetailData.TAXSUM_FIELD;
			parm_taxsum.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_taxsum);

			SqlParameter parm_itemcontext = new SqlParameter(ITEMCONTEXT_PARM,SqlDbType.VarChar);
			parm_itemcontext.SourceColumn = PurchasingContractDetailData.ITEMCONTEXT_FIELD;
			parm_itemcontext.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_itemcontext);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.SourceColumn = PurchasingContractDetailData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			update.Parameters.Add(parm_description);

			return update;
		}
		//end of Modified 2005-8-26
		#endregion
		
		#region 删除记录----采购明细

		public bool  DeletePurchasingContractDetail(string contractid ,string materialid)
		{
			SqlCommand deletecommand = GetDeleteCommand();
			deletecommand.Parameters[CONTRACTID_PARM].Value		=  contractid;
			deletecommand.Parameters[MATERIALID_PARM].Value		=  materialid;
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
		private SqlCommand  GetDeleteCommand ()
		{
			SqlCommand  delete = new SqlCommand("D_PurchasingContractDetail" ,new SqlConnection(ERPConfiguration.ConnectionString));
			delete.CommandType = CommandType.StoredProcedure ;

			SqlParameter parm_contractid = new SqlParameter(CONTRACTID_PARM,SqlDbType.Char);
			parm_contractid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_contractid);

			SqlParameter parm_materialid = new SqlParameter(MATERIALID_PARM,SqlDbType.Char); 
			parm_materialid.Direction = ParameterDirection.Input;
			delete.Parameters.Add(parm_materialid);

			return delete;
		}
		#endregion

		#region  读取主表ContractID 的合同详细表 所对应的物料编号和名称  
		// Begin of Added by XuJiansong 2005-8-29
		private SqlCommand GetLoadMaterialNameCommand(string filter) 
		{
			string sql;
			if(filter!="" && filter!=null)
			{
				sql=" SELECT ContractID  , MaterialID  , MaterialName   ,Model   FROM "
					+" (SELECT p.ContractID  , p.MaterialID , m.MaterialName  , m.Model   FROM TBL_PurchasingContractDetail p LEFT JOIN "
					+" TBL_Material m ON p.MaterialID = m.MaterialID) tbl_material "
					+" WHERE ("+filter.Trim()+") ";
			}
			else
			{
				sql=" SELECT *  FROM  "   
					+" (SELECT p.ContractID, p.MaterialID, m.MaterialName  ,m.Model  FROM TBL_PurchasingContractDetail p LEFT JOIN "  
					+" TBL_Material m ON p.MaterialID = m.MaterialID) tbl_material " ;
			}
			SqlCommand  loadsCommand = new SqlCommand(sql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;
			return loadsCommand;
		}
		public PurchasingContractDetailData LoadMaterialNameByContractID(string filter)
		{
			if(da==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}

			PurchasingContractDetailData data = new PurchasingContractDetailData();
			da.SelectCommand = GetLoadMaterialNameCommand(filter);
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

		//End of Add 2005-8-29
		#endregion
	}
}
