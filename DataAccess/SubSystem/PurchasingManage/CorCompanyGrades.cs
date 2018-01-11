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
	

	public class CorCompanyGrades:IDisposable
	{
		private SqlDataAdapter dsCommand;

		private const string CORCOMPANYID_PARM			    ="@corcompanyid";
		private const string DEPARTMENTID_PARM				="@departmentid";
		private const string TYPE_PARM						="@type";
		private const string MATERIALID_PARM				="@materialid";
		private const string PRODUCTID_PARM					="@productid";

		private const string MANUFACTURER_PARM				= "@manufacturer";
		private const string BRAND_PARM						= "@brand";
		private const string SUPPLYCYCLE_PARM				="@supplycycle";
		private const string PROVIDEABILITY_PARM			="@provideAbility";
		private const string SUPPLYRANK_PARM				="@supplyrank";

		private const string PRICERANK_PARM					="@pricerank";
		private const string QUALITYRANK_PARM				= "@qualityrank";
		private const string PUB_CORRANK_PARM				="@pub_corrank";
		private const string DRAWDEPARTMENT_PARM			="@DRAWdepartment";
		private const string DRAWDATE_PARM					="@DRAWdate";

		
		private const string DRAWPERSON_PARM				="@DRAWperson";
		private const string APPLICATIONDATE_PARM			="@applicationdate";
		private const string DESCRIPTION_PARM				="@description";
		private const string STATUS_PARM					="@status";

		private const string OLDCORCOMPANYID_PARM			    ="@oldcorcompanyid";
		private const string OLDDEPARTMENTID_PARM				="@olddepartmentid";
		private const string OLDTYPE_PARM						="@oldtype";
		private const string OLDMATERIALID_PARM				    ="@oldmaterialid";

		public CorCompanyGrades()
		{
			dsCommand = new SqlDataAdapter();
			dsCommand.TableMappings.Add("Table",CorCompanyGradeData.CORCOMPANYGRADE_TABLE);

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

		private SqlCommand GetloadCommand()
		{
			SqlCommand loadCommand = new SqlCommand("Q_CorCompanyGrade",new SqlConnection(ERPConfiguration.ConnectionString));
			loadCommand.CommandType = CommandType.StoredProcedure;

			return loadCommand;
		}
		public CorCompanyGradeData LoadCorCompanyGrade()
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);

			}
			CorCompanyGradeData  data = new CorCompanyGradeData();
			dsCommand.SelectCommand=GetloadCommand();
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

		#region 通过条件读取------------------------------------------------------------2005-9-12 魏套江修改 
		/// <summary>
		/// Added by WeiTaojiang 2005-8-9	
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>

		private SqlCommand GetLoadCommand(string filter)
		{
			string strsql;
			if(filter!="使用"&&filter!=""&&filter!=null)
			{
				strsql = "select g.*,c.name CorCompanyname,c1.Name ManufacturerName,m.materialName,m.model,d1.name departmentName,d2.name DrawDepartmentname,s1.Name DrawPersonName "
					+ "from (select * from tbl_corcompanygrade where " + filter + " and Type='供应商') g "			
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =g.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =g.DrawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =g.DrawPerson "
					+ "left JOIN TBL_CorrespondentCompany c ON c.CompanyID=g.CorCompanyID and g.departmentid=c.departmentid and c.Pub_Category='供应商' "
					+ "left JOIN TBL_CorrespondentCompany c1 ON c1.CompanyID =g.Manufacturer and g.departmentid=c1.departmentid and c1.pub_Category='制造商' "
					+ "left JOIN TBL_Material m on m.MaterialID=g.MaterialID " ;	
			}
			else if(filter=="使用")
			{
				strsql=" select * from tbl_material where enable='使用' ";
			}
			else 
			{
				strsql = "select g.*,c.name CorCompanyname,c1.Name ManufacturerName,m.materialName,m.model,d1.name departmentName,d2.name DrawDepartmentname,s1.Name DrawPersonName "
					+ "from (select * from tbl_corcompanygrade where Type='供应商') g "			
					+ "left JOIN TBL_DepartmentInfo d1  ON d1.DepartmentID =g.DepartmentID "
					+ "left JOIN TBL_DepartmentInfo d2  ON d2.DepartmentID =g.DrawDepartment "
					+ "left JOIN TBL_StaffInfo s1  ON s1.id =g.DrawPerson "
					+ "left JOIN TBL_CorrespondentCompany c ON c.CompanyID=g.CorCompanyID and g.departmentid=c.departmentid and c.Pub_Category='供应商' "
					+ "left JOIN TBL_CorrespondentCompany c1 ON c1.CompanyID =g.Manufacturer and g.departmentid=c1.departmentid and c1.pub_Category='制造商' "
					+ "left JOIN TBL_Material m on m.MaterialID=g.MaterialID " ;				
			}
			SqlCommand	loadsCommand = new SqlCommand(strsql,new SqlConnection(ERPConfiguration.ConnectionString));
			loadsCommand.CommandType = CommandType.Text;				
            
			return loadsCommand;
		}

		public CorCompanyGradeData LoadCorCompanyGrade(string filter)
		{
			if ( dsCommand == null )
			{
				throw new System.ObjectDisposedException( GetType().FullName );
			}            
			CorCompanyGradeData data = new CorCompanyGradeData();
			
			dsCommand.SelectCommand = GetLoadCommand(filter);
			
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
			SqlCommand insertCommand = new SqlCommand("I_CorCompanyGrade",new SqlConnection(ERPConfiguration.ConnectionString));
			insertCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = CorCompanyGradeData.CORCOMPANYID_FIELD;
			parm_corcompanyid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = CorCompanyGradeData.DEPARTMENTID_FIELD;
			parm_departmentid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.SourceColumn = CorCompanyGradeData.TYPE_FIELD;
			parm_type.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_type);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = CorCompanyGradeData.MATERIALID_FIELD;
			parm_materialid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_productid= new SqlParameter  (PRODUCTID_PARM,SqlDbType.VarChar);
			parm_productid.SourceColumn = CorCompanyGradeData.PRODUCTID_FIELD;
			parm_productid.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_productid);

			SqlParameter parm_manufacturer= new SqlParameter  (MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.SourceColumn = CorCompanyGradeData.MANUFACTURER_FIELD;
			parm_manufacturer.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_brand= new SqlParameter  (BRAND_PARM,SqlDbType.VarChar);
			parm_brand.SourceColumn = CorCompanyGradeData.BRAND_FIELD;
			parm_brand.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_brand);

			SqlParameter parm_supplycycle= new SqlParameter  (SUPPLYCYCLE_PARM,SqlDbType.Int);
			parm_supplycycle.SourceColumn = CorCompanyGradeData.SUPPLYCYCLE_FIELD;
			parm_supplycycle.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_supplycycle);

			SqlParameter parm_provideAbility= new SqlParameter  (PROVIDEABILITY_PARM,SqlDbType.VarChar);
			parm_provideAbility.SourceColumn = CorCompanyGradeData.PROVIDEABILITY_FIELD;
			parm_provideAbility.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_provideAbility);

			SqlParameter parm_supplyrank= new SqlParameter  (SUPPLYRANK_PARM,SqlDbType.Int);
			parm_supplyrank.SourceColumn = CorCompanyGradeData.SUPPLYRANK_FIELD;
			parm_supplyrank.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_supplyrank);


			SqlParameter parm_pricerank= new SqlParameter  (PRICERANK_PARM,SqlDbType.Int);
			parm_pricerank.SourceColumn = CorCompanyGradeData.PRICERANK_FIELD;
			parm_pricerank.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_pricerank);

			SqlParameter parm_qualityrank= new SqlParameter  (QUALITYRANK_PARM,SqlDbType.Int);
			parm_qualityrank.SourceColumn = CorCompanyGradeData.QUALITYRANK_FIELD;
			parm_qualityrank.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_qualityrank);

			SqlParameter parm_pub_corrank= new SqlParameter  (PUB_CORRANK_PARM,SqlDbType.Char);
			parm_pub_corrank.SourceColumn = CorCompanyGradeData.PUB_CORRANK_FIELD;
			parm_pub_corrank.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_pub_corrank);

			SqlParameter parm_DRAWdepartment= new SqlParameter  (DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_DRAWdepartment.SourceColumn = CorCompanyGradeData.DRAWDEPARTMENT_FIELD;
			parm_DRAWdepartment.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DRAWdepartment);

			SqlParameter parm_DRAWdate= new SqlParameter  (DRAWDATE_PARM,SqlDbType.DateTime);
			parm_DRAWdate.SourceColumn = CorCompanyGradeData.DRAWDATE_FIELD;
			parm_DRAWdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DRAWdate);


			SqlParameter parm_DRAWperson= new SqlParameter  (DRAWPERSON_PARM,SqlDbType.Char);
			parm_DRAWperson.SourceColumn = CorCompanyGradeData.DRAWPERSON_FIELD;
			parm_DRAWperson.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_DRAWperson);

			SqlParameter parm_applicationdate= new SqlParameter  (APPLICATIONDATE_PARM,SqlDbType.DateTime);
			parm_applicationdate.SourceColumn = CorCompanyGradeData.APPLICATIONDATE_FIELD;
			parm_applicationdate.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_applicationdate);

			SqlParameter parm_description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.SourceColumn = CorCompanyGradeData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_description);

			SqlParameter parm_status= new SqlParameter  (STATUS_PARM,SqlDbType.Char);
			parm_status.SourceColumn = CorCompanyGradeData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			insertCommand.Parameters.Add(parm_status);

			return insertCommand;


		}
		public bool InsertCorCompanyGrade(CorCompanyGradeData data)
		{
			if(dsCommand==null)
			{
				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.InsertCommand = GetInsertCommand();
			try
			{
				dsCommand.Update(data,CorCompanyGradeData.CORCOMPANYGRADE_TABLE);
				if(data.HasErrors)
				{
					data.Tables[CorCompanyGradeData.CORCOMPANYGRADE_TABLE].GetErrors()[0].ClearErrors();
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

		#region 修改提交单状态 @@@@@--------------------------------2005-9-8 魏套江添加
		private SqlCommand GetUpdateSupplyRecordStatusCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_SupplyRecordStatus",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_type);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_status = new SqlParameter(STATUS_PARM, SqlDbType.Char);
			parm_status.Direction=ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);
            
			return updateCommand;
		}
		public bool UpdateSupplyRecordStatus(string CorCompanyid,string departmentid,string type,string materialid,string status)
		{
			SqlCommand updateCommand = GetUpdateSupplyRecordStatusCommand();
			updateCommand.Parameters[CORCOMPANYID_PARM].Value = CorCompanyid;
			updateCommand.Parameters[DEPARTMENTID_PARM].Value  = departmentid;
			updateCommand.Parameters[TYPE_PARM].Value = type;
			updateCommand.Parameters[MATERIALID_PARM].Value = materialid;

			updateCommand.Parameters[STATUS_PARM].Value = status;

			try
			{
				updateCommand.Connection.Open();
				if(updateCommand.ExecuteNonQuery()>0)
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
				updateCommand.Connection.Close();
				updateCommand.Connection.Dispose();
				updateCommand.Dispose();
			}
		}
		#endregion

		//Modified by WeiTaojiang 2005-9-1
		#region  Update  Data
		private SqlCommand GetUpdateCommand()
		{
			SqlCommand updateCommand = new SqlCommand("U_CorCompanyGrade",new SqlConnection(ERPConfiguration.ConnectionString));
			updateCommand.CommandType= CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.SourceColumn = CorCompanyGradeData.CORCOMPANYID_FIELD;
			parm_corcompanyid.SourceVersion = DataRowVersion.Current;
			parm_corcompanyid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.SourceColumn = CorCompanyGradeData.DEPARTMENTID_FIELD;
			parm_departmentid.SourceVersion = DataRowVersion.Current;
			parm_departmentid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.SourceColumn = CorCompanyGradeData.TYPE_FIELD;
			parm_type.SourceVersion = DataRowVersion.Current;
			parm_type.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_type);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.SourceColumn = CorCompanyGradeData.MATERIALID_FIELD;
			parm_materialid.SourceVersion = DataRowVersion.Current;
			parm_materialid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_materialid);

			SqlParameter parm_productid= new SqlParameter  (PRODUCTID_PARM,SqlDbType.VarChar);
			parm_productid.SourceColumn = CorCompanyGradeData.PRODUCTID_FIELD;
			parm_productid.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_productid);

			SqlParameter parm_manufacturer= new SqlParameter  (MANUFACTURER_PARM,SqlDbType.Char);
			parm_manufacturer.SourceColumn = CorCompanyGradeData.MANUFACTURER_FIELD;
			parm_manufacturer.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_manufacturer);

			SqlParameter parm_brand= new SqlParameter  (BRAND_PARM,SqlDbType.VarChar);
			parm_brand.SourceColumn = CorCompanyGradeData.BRAND_FIELD;
			parm_brand.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_brand);

			SqlParameter parm_supplycycle= new SqlParameter  (SUPPLYCYCLE_PARM,SqlDbType.Int);
			parm_supplycycle.SourceColumn = CorCompanyGradeData.SUPPLYCYCLE_FIELD;
			parm_supplycycle.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_supplycycle);

			SqlParameter parm_provideAbility= new SqlParameter  (PROVIDEABILITY_PARM,SqlDbType.Char);
			parm_provideAbility.SourceColumn = CorCompanyGradeData.PROVIDEABILITY_FIELD;
			parm_provideAbility.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_provideAbility);

			SqlParameter parm_supplyrank= new SqlParameter  (SUPPLYRANK_PARM,SqlDbType.VarChar);
			parm_supplyrank.SourceColumn = CorCompanyGradeData.SUPPLYRANK_FIELD;
			parm_supplyrank.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_supplyrank);


			SqlParameter parm_pricerank= new SqlParameter  (PRICERANK_PARM,SqlDbType.Int);
			parm_pricerank.SourceColumn = CorCompanyGradeData.PRICERANK_FIELD;
			parm_pricerank.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_pricerank);

			SqlParameter parm_qualityrank= new SqlParameter  (QUALITYRANK_PARM,SqlDbType.Int);
			parm_qualityrank.SourceColumn = CorCompanyGradeData.QUALITYRANK_FIELD;
			parm_qualityrank.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_qualityrank);

			SqlParameter parm_pub_corrank= new SqlParameter  (PUB_CORRANK_PARM,SqlDbType.Char);
			parm_pub_corrank.SourceColumn = CorCompanyGradeData.PUB_CORRANK_FIELD;
			parm_pub_corrank.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_pub_corrank);

			SqlParameter parm_DRAWdepartment= new SqlParameter  (DRAWDEPARTMENT_PARM,SqlDbType.Char);
			parm_DRAWdepartment.SourceColumn = CorCompanyGradeData.DRAWDEPARTMENT_FIELD;
			parm_DRAWdepartment.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DRAWdepartment);

			SqlParameter parm_DRAWdate= new SqlParameter  (DRAWDATE_PARM,SqlDbType.DateTime);
			parm_DRAWdate.SourceColumn = CorCompanyGradeData.DRAWDATE_FIELD;
			parm_DRAWdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DRAWdate);


			SqlParameter parm_DRAWperson= new SqlParameter  (DRAWPERSON_PARM,SqlDbType.Char);
			parm_DRAWperson.SourceColumn = CorCompanyGradeData.DRAWPERSON_FIELD;
			parm_DRAWperson.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_DRAWperson);

			SqlParameter parm_applicationdate= new SqlParameter  (APPLICATIONDATE_PARM,SqlDbType.DateTime);
			parm_applicationdate.SourceColumn = CorCompanyGradeData.APPLICATIONDATE_FIELD;
			parm_applicationdate.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_applicationdate);

			SqlParameter parm_description= new SqlParameter  (DESCRIPTION_PARM,SqlDbType.VarChar);
			parm_description.SourceColumn = CorCompanyGradeData.DESCRIPTION_FIELD;
			parm_description.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_description);

			SqlParameter parm_status= new SqlParameter  (STATUS_PARM,SqlDbType.Char);
			parm_status.SourceColumn = CorCompanyGradeData.STATUS_FIELD;
			parm_status.Direction = ParameterDirection.Input;
			updateCommand.Parameters.Add(parm_status);

			return updateCommand;

		}

		public bool UpdateCorCompanyGrade(CorCompanyGradeData data)
		{
			if(dsCommand==null)
			{

				throw new System.ObjectDisposedException(GetType().FullName);
			}
			dsCommand.UpdateCommand = GetUpdateCommand();
			try 
			{
				dsCommand.Update(data,CorCompanyGradeData.CORCOMPANYGRADE_TABLE);
				if(data.HasErrors)
				{
					data.Tables[CorCompanyGradeData.CORCOMPANYGRADE_TABLE].GetErrors()[0].ClearErrors();
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

		#region  Delete  Data
		private SqlCommand GetDeleteCommand()
		{
			SqlCommand deleteCommand = new SqlCommand("D_CorCompanyGrade",new SqlConnection(ERPConfiguration.ConnectionString));
			deleteCommand.CommandType = CommandType.StoredProcedure;

			SqlParameter parm_corcompanyid= new SqlParameter  (CORCOMPANYID_PARM,SqlDbType.Char);
			parm_corcompanyid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_corcompanyid);

			SqlParameter parm_departmentid= new SqlParameter  (DEPARTMENTID_PARM,SqlDbType.Char);
			parm_departmentid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_departmentid);

			SqlParameter parm_type= new SqlParameter  (TYPE_PARM,SqlDbType.Char);
			parm_type.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_type);

			SqlParameter parm_materialid= new SqlParameter  (MATERIALID_PARM,SqlDbType.Char);
			parm_materialid.Direction = ParameterDirection.Input;
			deleteCommand.Parameters.Add(parm_materialid);

			return deleteCommand;

		}

		public bool DeleteCorCompanyGradeData(string CorCommandid,string departmentid,string type,string materialid)
		{
			
			SqlCommand deleteCommand = GetDeleteCommand();
			deleteCommand.Parameters[CORCOMPANYID_PARM].Value = CorCommandid;
			deleteCommand.Parameters[DEPARTMENTID_PARM].Value  = departmentid;
			deleteCommand.Parameters[TYPE_PARM].Value = type;
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
