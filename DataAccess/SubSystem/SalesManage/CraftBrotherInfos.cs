using System;
using System.Data;
using System.Data.SqlClient;

using TOPSUN.ERP.Common;
using TOPSUN.ERP.SystemFrameworks;
using TOPSUN.ERP.Common.Data.SalesManage;

namespace TOPSUN.ERP.DataAccess.SubSystem.SalesManage
{
	/// <summary>
	/// CraftBrotherInfos 的摘要说明。
	/// </summary>
	public class CraftBrotherInfos:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const String DEPARTMENTID_PARM        = "@departmentid";
		private const String CRAFTBROTHERID_PARM      = "@craftbrotherid";
		private const String CRAFTBROTHERNAME_PARM    = "@craftbrothername";
		private const String LEGALREPRESENTATIVE_PARM = "@legalrepresentative";
		private const String AREAID_PARM              = "@areaid";
		private const String PHONE_PARM               = "@phone";
		private const String ADDRESS_PARM             = "@address";
		private const String SALEPRINCIPAL_PARM       = "@saleprincipal";
		private const String ENJOYPOLICY_PARM         = "@enjoypolicy";
		private const String PRODUCTIONCAPACITY_PARM  = "@productioncapacity";
		private const String SALEINCOME_PARM          = "@saleincome";
		private const String SALEPROFIT_PARM          = "@saleprofit";
		private const String DRAWDEPARTMENT_PARM      = "@drawdepartment";
		private const String DRAWPERSON_PARM          = "@drawperson";
		private const String DRAWDATE_PARM            = "@drawdate";
		private const String DESCRIPTION_PARM         = "@description";

        #region Create Adapter
		public CraftBrotherInfos()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",CraftBrotherInfoData.CRAFTBROTHERINFO_TABLE);
		}
		#endregion
		#region 释放资源
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected virtual void Dispose(bool disposing)
		{
			if(!disposing)
				return;
			if(dsCommand != null)
			{
				if(dsCommand.SelectCommand != null)
				{
					if(dsCommand.SelectCommand.Connection != null)
					{
						dsCommand.SelectCommand.Connection.Dispose();
					}
					dsCommand.SelectCommand.Dispose();
				}
				if(dsCommand.InsertCommand != null)
				{
					if(dsCommand.InsertCommand.Connection != null)
					{
						dsCommand.InsertCommand.Connection.Close();
						dsCommand.InsertCommand.Connection.Dispose();
					}
					dsCommand.InsertCommand.Dispose();
				}
				if(dsCommand.UpdateCommand != null)
				{
					if(dsCommand.UpdateCommand.Connection != null)
					{
						dsCommand.UpdateCommand.Connection.Close();
						dsCommand.UpdateCommand.Connection.Dispose();
					}
					dsCommand.UpdateCommand.Dispose();
				}
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion
		#region Read data
		private SqlCommand GetLoadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_CraftBrotherInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public CraftBrotherInfoData LoadCraftBrotherInfo()
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get load command and read data
			//
			CraftBrotherInfoData data = new CraftBrotherInfoData();

			dsCommand.SelectCommand = GetLoadCommand();
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
		#region Insert data
		private SqlCommand GetInsertCommand()
		{
			SqlCommand insertCommand = new SqlCommand("I_CraftBrotherInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = CraftBrotherInfoData.DEPARTMENTID_FIELD;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			parm_craftbrotherid.SourceColumn = CraftBrotherInfoData.CRAFTBROTHERID_FIELD;
			insertCommand.Parameters.Add(parm_craftbrotherid);

			
			SqlParameter parm_craftbrothername = new SqlParameter(CRAFTBROTHERNAME_PARM,SqlDbType.VarChar);
			parm_craftbrothername.Direction    = ParameterDirection.Input;
			parm_craftbrothername.SourceColumn = CraftBrotherInfoData.CRAFTBROTHERNAME_FIELD;
			insertCommand.Parameters.Add(parm_craftbrothername);

			SqlParameter parm_legalrepresentative = new SqlParameter(LEGALREPRESENTATIVE_PARM,SqlDbType.Char);
			parm_legalrepresentative.Direction    = ParameterDirection.Input;
			parm_legalrepresentative.SourceColumn = CraftBrotherInfoData.LEGALREPRESENTATIVE_FIELD;
			insertCommand.Parameters.Add(parm_legalrepresentative);

			SqlParameter parm_areaid = new SqlParameter(AREAID_PARM,SqlDbType.Char);
			parm_areaid.Direction    = ParameterDirection.Input;
			parm_areaid.SourceColumn = CraftBrotherInfoData.AREAID_FIELD;
			insertCommand.Parameters.Add(parm_areaid);

			SqlParameter parm_phone = new SqlParameter(PHONE_PARM,SqlDbType.Char);
			parm_phone.Direction    = ParameterDirection.Input;
			parm_phone.SourceColumn = CraftBrotherInfoData.PHONE_FIELD;
			insertCommand.Parameters.Add(parm_phone);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM,SqlDbType.VarChar);
			parm_address.Direction    = ParameterDirection.Input;
			parm_address.SourceColumn = CraftBrotherInfoData.ADDRESS_FIELD;
			insertCommand.Parameters.Add(parm_address);

			SqlParameter parm_saleprincipal = new SqlParameter(SALEPRINCIPAL_PARM,SqlDbType.Char);
			parm_saleprincipal.Direction    = ParameterDirection.Input;
			parm_saleprincipal.SourceColumn = CraftBrotherInfoData.SALEPRINCIPAL_FIELD;
			insertCommand.Parameters.Add(parm_saleprincipal);

			SqlParameter parm_enjoypolicy = new SqlParameter(ENJOYPOLICY_PARM,SqlDbType.VarChar);
			parm_enjoypolicy.Direction    = ParameterDirection.Input;
			parm_enjoypolicy.SourceColumn = CraftBrotherInfoData.ENJOYPOLICY_FIELD;
			insertCommand.Parameters.Add(parm_enjoypolicy);

			SqlParameter parm_productioncapacity = new SqlParameter(PRODUCTIONCAPACITY_PARM,SqlDbType.VarChar);
			parm_productioncapacity.Direction    = ParameterDirection.Input;
			parm_productioncapacity.SourceColumn = CraftBrotherInfoData.PRODUCTIONCAPACITY_FIELD;
			insertCommand.Parameters.Add(parm_productioncapacity);

			SqlParameter parm_saleincome = new SqlParameter(SALEINCOME_PARM,SqlDbType.VarChar);
			parm_saleincome.Direction    = ParameterDirection.Input;
			parm_saleincome.SourceColumn = CraftBrotherInfoData.SALEINCOME_FIELD;
			insertCommand.Parameters.Add(parm_saleincome);

			SqlParameter parm_saleprofit = new SqlParameter(SALEPROFIT_PARM,SqlDbType.VarChar);
			parm_saleprofit.Direction    = ParameterDirection.Input;
			parm_saleprofit.SourceColumn = CraftBrotherInfoData.SALEPROFIT_FIELD;
			insertCommand.Parameters.Add(parm_saleprofit);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = CraftBrotherInfoData.DRAWDEPARTMENT_FIELD;
			insertCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = CraftBrotherInfoData.DRAWPERSON_FIELD;
			insertCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = CraftBrotherInfoData.DRAWDATE_FIELD;
			insertCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = CraftBrotherInfoData.DESCRIPTION_FIELD;
			insertCommand.Parameters.Add(parm_description);

			return insertCommand;

		}
		public bool InsertCraftBrotherInfo(CraftBrotherInfoData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get insert command and update database
			//
			dsCommand.InsertCommand = GetInsertCommand();
			dsCommand.Update(info,CraftBrotherInfoData.CRAFTBROTHERINFO_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[CraftBrotherInfoData.CRAFTBROTHERINFO_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion
		#region Update data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_CraftBrotherInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			parm_departmentid.SourceColumn = CraftBrotherInfoData.DEPARTMENTID_FIELD;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			parm_craftbrotherid.SourceColumn = CraftBrotherInfoData.CRAFTBROTHERID_FIELD;
			updateCommand.Parameters.Add(parm_craftbrotherid);

			
			SqlParameter parm_craftbrothername = new SqlParameter(CRAFTBROTHERNAME_PARM,SqlDbType.VarChar);
			parm_craftbrothername.Direction    = ParameterDirection.Input;
			parm_craftbrothername.SourceColumn = CraftBrotherInfoData.CRAFTBROTHERNAME_FIELD;
			updateCommand.Parameters.Add(parm_craftbrothername);

			SqlParameter parm_legalrepresentative = new SqlParameter(LEGALREPRESENTATIVE_PARM,SqlDbType.Char);
			parm_legalrepresentative.Direction    = ParameterDirection.Input;
			parm_legalrepresentative.SourceColumn = CraftBrotherInfoData.LEGALREPRESENTATIVE_FIELD;
			updateCommand.Parameters.Add(parm_legalrepresentative);

			SqlParameter parm_areaid = new SqlParameter(AREAID_PARM,SqlDbType.Char);
			parm_areaid.Direction    = ParameterDirection.Input;
			parm_areaid.SourceColumn = CraftBrotherInfoData.AREAID_FIELD;
			updateCommand.Parameters.Add(parm_areaid);

			SqlParameter parm_phone = new SqlParameter(PHONE_PARM,SqlDbType.Char);
			parm_phone.Direction    = ParameterDirection.Input;
			parm_phone.SourceColumn = CraftBrotherInfoData.PHONE_FIELD;
			updateCommand.Parameters.Add(parm_phone);

			SqlParameter parm_address = new SqlParameter(ADDRESS_PARM,SqlDbType.VarChar);
			parm_address.Direction    = ParameterDirection.Input;
			parm_address.SourceColumn = CraftBrotherInfoData.ADDRESS_FIELD;
			updateCommand.Parameters.Add(parm_address);

			SqlParameter parm_saleprincipal = new SqlParameter(SALEPRINCIPAL_PARM,SqlDbType.Char);
			parm_saleprincipal.Direction    = ParameterDirection.Input;
			parm_saleprincipal.SourceColumn = CraftBrotherInfoData.SALEPRINCIPAL_FIELD;
			updateCommand.Parameters.Add(parm_saleprincipal);

			SqlParameter parm_enjoypolicy = new SqlParameter(ENJOYPOLICY_PARM,SqlDbType.VarChar);
			parm_enjoypolicy.Direction    = ParameterDirection.Input;
			parm_enjoypolicy.SourceColumn = CraftBrotherInfoData.ENJOYPOLICY_FIELD;
			updateCommand.Parameters.Add(parm_enjoypolicy);

			SqlParameter parm_productioncapacity = new SqlParameter(PRODUCTIONCAPACITY_PARM,SqlDbType.VarChar);
			parm_productioncapacity.Direction    = ParameterDirection.Input;
			parm_productioncapacity.SourceColumn = CraftBrotherInfoData.PRODUCTIONCAPACITY_FIELD;
			updateCommand.Parameters.Add(parm_productioncapacity);

			SqlParameter parm_saleincome = new SqlParameter(SALEINCOME_PARM,SqlDbType.VarChar);
			parm_saleincome.Direction    = ParameterDirection.Input;
			parm_saleincome.SourceColumn = CraftBrotherInfoData.SALEINCOME_FIELD;
			updateCommand.Parameters.Add(parm_saleincome);

			SqlParameter parm_saleprofit = new SqlParameter(SALEPROFIT_PARM,SqlDbType.VarChar);
			parm_saleprofit.Direction    = ParameterDirection.Input;
			parm_saleprofit.SourceColumn = CraftBrotherInfoData.SALEPROFIT_FIELD;
			updateCommand.Parameters.Add(parm_saleprofit);

			SqlParameter parm_drawdepartment = new SqlParameter(DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_drawdepartment.Direction    = ParameterDirection.Input;
			parm_drawdepartment.SourceColumn = CraftBrotherInfoData.DRAWDEPARTMENT_FIELD;
			updateCommand.Parameters.Add(parm_drawdepartment);

			SqlParameter parm_drawperson = new SqlParameter(DRAWPERSON_PARM,SqlDbType.Char);
			parm_drawperson.Direction    = ParameterDirection.Input;
			parm_drawperson.SourceColumn = CraftBrotherInfoData.DRAWPERSON_FIELD;
			updateCommand.Parameters.Add(parm_drawperson);

			SqlParameter parm_drawdate = new SqlParameter(DRAWDATE_PARM,SqlDbType.DateTime);
			parm_drawdate.Direction    = ParameterDirection.Input;
			parm_drawdate.SourceColumn = CraftBrotherInfoData.DRAWDATE_FIELD;
			updateCommand.Parameters.Add(parm_drawdate);

			SqlParameter parm_description = new SqlParameter(DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.Direction    = ParameterDirection.Input;
			parm_description.SourceColumn = CraftBrotherInfoData.DESCRIPTION_FIELD;
			updateCommand.Parameters.Add(parm_description);

			return updateCommand;
		}
		public bool UpdateCraftBrotherInfo(CraftBrotherInfoData info)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get update command and update database
			//
			dsCommand.UpdateCommand = GetUpdateCommand();

			dsCommand.Update(info,CraftBrotherInfoData.CRAFTBROTHERINFO_TABLE);
			//
			// Check it if it update failed
			//
			if(info.HasErrors)
			{
				info.Tables[CraftBrotherInfoData.CRAFTBROTHERINFO_TABLE].GetErrors()[0].ClearErrors();
				return false;
			}
			else 
			{
				info.AcceptChanges();
				return true;
			}
		}
		#endregion
		#region Delete data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_CraftBrotherInfo",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_departmentid = new SqlParameter(DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_craftbrotherid = new SqlParameter(CRAFTBROTHERID_PARM,SqlDbType.VarChar);
			parm_craftbrotherid.Direction    = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_craftbrotherid);

			return deleteCommand;
		}
		public bool DeleteCraftBrotherInfo(string departmentid,string craftbrotherid)
		{
			if(dsCommand == null)
			{
				throw new System.EntryPointNotFoundException(GetType().FullName);
			}
			//
			// Get Delete command and update dataBase
			//
			SqlCommand deleteCommand = GetDeleteCommand();

			deleteCommand.Parameters[DEPARTMENTID_PARM].Value   = departmentid;
			deleteCommand.Parameters[CRAFTBROTHERID_PARM].Value = craftbrotherid;

			//
			//  Check it if it is update failed
			//
			try
			{
				deleteCommand.Connection.Open();
				if(deleteCommand.ExecuteNonQuery()>0)
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
				deleteCommand.Connection.Close();
				deleteCommand.Dispose();
				dsCommand.Dispose();
				dsCommand = null;
			}
		}
		#endregion
	}
}
