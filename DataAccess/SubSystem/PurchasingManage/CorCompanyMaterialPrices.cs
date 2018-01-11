using System;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.Common.Data;
using TOPSUN.ERP.Common.Data.PurchasingManage;
using TOPSUN.ERP.SystemFrameworks;

namespace TOPSUN.ERP.DataAccess.SubSystem.PurchasingManage
{
	
	public class CorCompanyMaterialPrices:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const string CORCOMPANYID_PARM			    ="@corcompanyid";
		private const string DEPARTMENTID_PARM				="@departmentid";
		private const string TYPE_PARM						="@type";
		private const string QUOTEDATE_PARM				    ="@quotedate";
		private const string MATERIALID_PARM				="@materialid";
		
		private const string PRICES_PARM					="@prices";
		private const string TAXRATE_PARM					="@taxrate";
		private const string DRAWDEPARTMENT_PARM			="@drawdepartment";
		private const string DRAWDATE_PARM					="@drawdate";
		private const string DRAWPERSON_PARM				="@drawperson";

		private const string DESCRIPTION_PARM				="@description";
		private const string STATUS_PARM					="@status";

		private const string OLDCORCOMPANYID_PARM			    ="@oldcorcompanyid";
		private const string OLDDEPARTMENTID_PARM				="@olddepartmentid";
		private const string OLDTYPE_PARM						="@oldtype";
		private const string OLDQUOTEDATE_PARM				    ="@oldquotedate";
		private const string OLDMATERIALID_PARM					="@oldmaterialid";


		public CorCompanyMaterialPrices()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",CorCommpanyMaterialPriceData.CORCOMPANYMATERIALPRICE_TABLE);

		}
		#region  释放资源
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected virtual void Dispose(bool disposing)
		{
			if( ! disposing)
				return;
			if(dsCommand!=null)
			{
				if(dsCommand.SelectCommand!=null)
				{
					if(dsCommand.SelectCommand.Connection!=null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				}
				if(dsCommand.InsertCommand!=null)
				{
					if(dsCommand.InsertCommand.Connection!=null)
					{
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}
				if(dsCommand.UpdateCommand!=null)
				{
					if(dsCommand.UpdateCommand.Connection!=null)
					{
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}
				if(dsCommand.DeleteCommand!=null)
				{
					if(dsCommand.DeleteCommand.Connection!=null)
					{
						dsCommand.DeleteCommand.Connection.Dispose();
					}
					dsCommand.DeleteCommand.Dispose();
				}
				dsCommand.Dispose();
				dsCommand=null;
			}
		}
		#endregion

		#region  Load  Data
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_CorCompanyMaterialPrice",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public CorCommpanyMaterialPriceData LoadCorCommpanyMaterialPrice()
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			CorCommpanyMaterialPriceData  data = new CorCommpanyMaterialPriceData();
			dsCommand.SelectCommand=GetLoadCommand();
			try
			{
				dsCommand.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region  Load  Data 2005-8-10 魏套江
		private SqlCommand GetLoadByFilterCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_CorCompanyMaterialPriceMX",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter(CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.Direction = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.SourceColumn = CorCommpanyMaterialPriceData.TYPE_FIELD;
			parm_type.Direction = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_type);

			SqlParameter parm_materialid= new SqlParameter(MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			loadCommand.Parameters.Add(parm_materialid);

			return loadCommand;
		}
		public CorCommpanyMaterialPriceData LoadCorCommpanyMaterialPrice(string corcompanyid,string departmentid,string type,string materialid)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			CorCommpanyMaterialPriceData  data = new CorCommpanyMaterialPriceData();
			dsCommand.SelectCommand = GetLoadByFilterCommand();

			dsCommand.SelectCommand.Parameters[CORCOMPANYID_PARM].Value = corcompanyid;
			dsCommand.SelectCommand.Parameters[DEPARTMENTID_PARM].Value = departmentid;
			dsCommand.SelectCommand.Parameters[TYPE_PARM].Value         = type;
			dsCommand.SelectCommand.Parameters[MATERIALID_PARM].Value   = materialid;


			try
			{
				dsCommand.Fill(data);
				return data;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region  Insert  Data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_CorCompanyMaterialPrice",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = CorCommpanyMaterialPriceData.CORCOMPANYID_FIELD;
			parm_corcompanyid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = CorCommpanyMaterialPriceData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.SourceColumn = CorCommpanyMaterialPriceData.TYPE_FIELD;
			parm_type.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_type);

			SqlParameter parm_quotedate= new SqlParameter  (QUOTEDATE_PARM,SqlDbType.DateTime);
			parm_quotedate.SourceColumn = CorCommpanyMaterialPriceData.QUOTEDATE_FIELD;
			parm_quotedate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_quotedate);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = CorCommpanyMaterialPriceData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_prices= new SqlParameter  (PRICES_PARM,SqlDbType.Char);
			parm_prices.SourceColumn = CorCommpanyMaterialPriceData.PRICES_FIELD;
			parm_prices.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_prices);

			SqlParameter parm_taxrate= new SqlParameter  (TAXRATE_PARM,SqlDbType.Char);
			parm_taxrate.SourceColumn = CorCommpanyMaterialPriceData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_taxrate);

			SqlParameter parm_DRAWdepartment= new SqlParameter  (DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_DRAWdepartment.SourceColumn = CorCommpanyMaterialPriceData.DRAWDEPARTMENT_FIELD;
			parm_DRAWdepartment.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DRAWdepartment);

			SqlParameter parm_DRAWdate= new SqlParameter  (DRAWDATE_PARM,SqlDbType.Char);
			parm_DRAWdate.SourceColumn = CorCommpanyMaterialPriceData.DRAWDATE_FIELD;
			parm_DRAWdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DRAWdate);

			SqlParameter parm_DRAWperson= new SqlParameter  (DRAWPERSON_PARM,SqlDbType.Char);
			parm_DRAWperson.SourceColumn = CorCommpanyMaterialPriceData.DRAWPERSON_FIELD;
			parm_DRAWperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DRAWperson);

			SqlParameter parm_description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.SourceColumn = CorCommpanyMaterialPriceData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_status= new SqlParameter  (STATUS_PARM,SqlDbType.Char);
			parm_status.SourceColumn = CorCommpanyMaterialPriceData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_status);
			return insertCommand;
		}
		public bool insertCorCommpanyMaterialPrice(CorCommpanyMaterialPriceData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			try
			{
				dsCommand.Update(data,CorCommpanyMaterialPriceData.CORCOMPANYMATERIALPRICE_TABLE);
				if(data.HasErrors)
				{
					data.Tables[CorCommpanyMaterialPriceData.CORCOMPANYMATERIALPRICE_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				data.AcceptChanges();
				return true;
			}
			catch
			{
				return false;

			}
		}

		#endregion

		//Modified by WeiTaojiang 2005-9-1
		#region  Update  Data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_CorCommpanyMaterialPrice",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType= CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = CorCommpanyMaterialPriceData.CORCOMPANYID_FIELD;
			parm_corcompanyid.SourceVersion = DataRowVersion.Current;
			parm_corcompanyid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = CorCommpanyMaterialPriceData.DEPARTMENTID_FIELD;
			parm_departmentid.SourceVersion = DataRowVersion.Current;
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.SourceColumn = CorCommpanyMaterialPriceData.TYPE_FIELD;
			parm_type.SourceVersion = DataRowVersion.Current;
			parm_type.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_type);

			SqlParameter parm_quotedate= new SqlParameter  (QUOTEDATE_PARM,SqlDbType.DateTime);
			parm_quotedate.SourceColumn = CorCommpanyMaterialPriceData.QUOTEDATE_FIELD;
			parm_quotedate.SourceVersion = DataRowVersion.Current;
			parm_quotedate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_quotedate);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = CorCommpanyMaterialPriceData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_oldquotedate= new SqlParameter  (OLDQUOTEDATE_PARM,SqlDbType.DateTime);
			parm_oldquotedate.SourceColumn = CorCommpanyMaterialPriceData.QUOTEDATE_FIELD;
			parm_oldquotedate.SourceVersion = DataRowVersion.Original;
			parm_oldquotedate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_oldquotedate);

			SqlParameter parm_prices= new SqlParameter  (PRICES_PARM,SqlDbType.Char);
			parm_prices.SourceColumn = CorCommpanyMaterialPriceData.PRICES_FIELD;
			parm_prices.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_prices);

			SqlParameter parm_taxrate= new SqlParameter  (TAXRATE_PARM,SqlDbType.Char);
			parm_taxrate.SourceColumn = CorCommpanyMaterialPriceData.TAXRATE_FIELD;
			parm_taxrate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_taxrate);

			SqlParameter parm_DRAWdepartment= new SqlParameter  (DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_DRAWdepartment.SourceColumn = CorCommpanyMaterialPriceData.DRAWDEPARTMENT_FIELD;
			parm_DRAWdepartment.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DRAWdepartment);

			SqlParameter parm_DRAWdate= new SqlParameter  (DRAWDATE_PARM,SqlDbType.Char);
			parm_DRAWdate.SourceColumn = CorCommpanyMaterialPriceData.DRAWDATE_FIELD;
			parm_DRAWdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DRAWdate);

			SqlParameter parm_DRAWperson= new SqlParameter  (DRAWPERSON_PARM,SqlDbType.Char);
			parm_DRAWperson.SourceColumn = CorCommpanyMaterialPriceData.DRAWPERSON_FIELD;
			parm_DRAWperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DRAWperson);

			SqlParameter parm_description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.Char);
			parm_description.SourceColumn = CorCommpanyMaterialPriceData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);

			SqlParameter parm_status= new SqlParameter  (STATUS_PARM,SqlDbType.Char);
			parm_status.SourceColumn = CorCommpanyMaterialPriceData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);
			return updateCommand;

		}
		public bool UpdateCorCommpanyMaterialPrice(CorCommpanyMaterialPriceData data)
		{
			if(dsCommand==null)
			{

				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.UpdateCommand = GetUpdateCommand();
			try 
			{
				dsCommand.Update(data,CorCommpanyMaterialPriceData.CORCOMPANYMATERIALPRICE_TABLE);
				if(data.HasErrors)
				{
					data.Tables[CorCommpanyMaterialPriceData.CORCOMPANYMATERIALPRICE_TABLE].GetErrors()[0].ClearErrors();
					return false;
				}
				else
				{
					data.AcceptChanges();
					return true;
				}
			}
			catch 
			{
				return false;
			}
		}

		#endregion

		#region  Delete Data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_CorCommpanyMaterialPrice",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = CorCommpanyMaterialPriceData.CORCOMPANYID_FIELD;
			parm_corcompanyid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = CorCommpanyMaterialPriceData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.SourceColumn = CorCommpanyMaterialPriceData.TYPE_FIELD;
			parm_type.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_type);

			SqlParameter parm_quotedate= new SqlParameter  (QUOTEDATE_PARM,SqlDbType.DateTime);
			parm_quotedate.SourceColumn = CorCommpanyMaterialPriceData.QUOTEDATE_FIELD;
			parm_quotedate.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_quotedate);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = CorCommpanyMaterialPriceData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);
				
			return deleteCommand;

		}

		public bool DeleteCorCommpanyMaterialPrice(string CorCommandid,string departmentid,string type,string quotedate,string materialid)
		{
			
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[CORCOMPANYID_PARM].Value = CorCommandid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value  = departmentid;
			deleteCommand.Parameters[TYPE_PARM].Value = type;
			deleteCommand.Parameters[QUOTEDATE_PARM].Value = quotedate;
			deleteCommand.Parameters[MATERIALID_PARM].Value = materialid;
			try
			{
				deleteCommand.Connection.Open ();
				int i = deleteCommand.ExecuteNonQuery();
				deleteCommand.Connection.Close();
				if(i>=1)
					return true;
				else
					return false;
		
			}
			catch
			{
				return false;
			}

		}
		#endregion
			
	}
}
