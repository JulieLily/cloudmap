using System;

namespace TOPSUN.ERP.SystemFrameworks
{
	/// <summary>
	/// ErrorSystem 的摘要说明。
	/// </summary>
	public class ErrorSystem
	{
		public ErrorSystem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static String GetErrorMessageByID(int errorID)
		{
			String ErrorText = error.GetErrorMessage(errorID);
			return ErrorText;
		}

		public static String GetErrorMessageByName(String errorName)
		{
			String ErrorText = error.GetErrorMessage(errorName);
			return ErrorText;
		}
	}
}
