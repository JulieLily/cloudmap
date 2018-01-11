using System;
using System.Data;
using System.Data.OleDb;


namespace TOPSUN.ERP.SystemFrameworks
{
	/// <summary>
	/// error 的摘要说明。
	/// </summary>
	public class error
	{
		public error()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static String GetErrorMessage(int errorId)
		{
			try
			{
				using(OleDbConnection AccessConnection = new OleDbConnection(ApplicationConfiguration.SysInformationConnectionString))
				{
					AccessConnection.Open();
					String SQLString = "select displaytext from errorinfo where (errorid=:errorparameter)";
					OleDbCommand AccessCommand = new OleDbCommand(SQLString,AccessConnection);
					AccessCommand.CommandType = CommandType.Text;

					OleDbParameter ErrorParm = new OleDbParameter("errorparameter",OleDbType.Integer);
					ErrorParm.Value = errorId;
					AccessCommand.Parameters.Add(ErrorParm);

					OleDbDataReader ErrorReader  = AccessCommand.ExecuteReader();

					if (ErrorReader.HasRows)
					{
						ErrorReader.Read();
						String DisplayText = ErrorReader.GetString(0);
						return DisplayText;
					}
					else
					{
						return "无法获得该出错信息";
					}
				}
			}
			catch
			{
				return "无法获得该出错信息";
			}
			finally
			{
			}
			
		}	

		public static String GetErrorMessage(String errorName)
		{
			try
			{
				using(OleDbConnection AccessConnection = new OleDbConnection(ApplicationConfiguration.SysInformationConnectionString))
				{

					String SQLString = "select displaytext from errorinfo where errorname=:errorparameter";
					OleDbCommand AccessCommand = new OleDbCommand(SQLString,AccessConnection);
					AccessCommand.CommandType = CommandType.Text;

					OleDbParameter ErrorParm = new OleDbParameter("errorparameter",OleDbType.VarWChar);
					ErrorParm.Value = errorName;
					AccessCommand.Parameters.Add(ErrorParm);

					OleDbDataReader ErrorReader  = AccessCommand.ExecuteReader();

					if (ErrorReader.HasRows)
					{
						String DisplayText = ErrorReader.GetString(0);
						return DisplayText;
					}
					else
					{
						return "无法获得该出错信息";
					}
				}
			}
			catch
			{
				return "无法获得该出错信息";
			}
			finally
			{
			}
			
		}
		
	}
}
