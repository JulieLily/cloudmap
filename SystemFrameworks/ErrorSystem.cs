using System;

namespace TOPSUN.ERP.SystemFrameworks
{
	/// <summary>
	/// ErrorSystem ��ժҪ˵����
	/// </summary>
	public class ErrorSystem
	{
		public ErrorSystem()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
