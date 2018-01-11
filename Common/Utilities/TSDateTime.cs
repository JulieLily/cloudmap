using System;

namespace TOPSUN.ERP.Common.Utilities
{
	/// <summary>
	/// DateTimeUtil ��ժҪ˵����
	/// </summary>
	public class TSDateTime
	{
		private System.DateTime dateTime;

		public TSDateTime()
		{
			dateTime = DateTime.Now;
		}
		
		public TSDateTime(string str)
		{
			try
			{
				dateTime = DateTime.Parse(str);
			}
			catch
			{
				dateTime = DateTime.Now;
			}
		}

		public TSDateTime(DateTime dt)
		{
			dateTime = dt;
		}

		public string GetDateTimeString()
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm");
		}

		public DateTime GetDateTime()
		{
			return DateTime.Parse(this.GetDateTimeString());
		}

		#region ���ʱ���
		public string GetTimeStamp(int length)
		{
			string format = "yyyyMMddHHmmssfffffff";
			if(length < 21)
				format = format.Substring(0,length);
			return dateTime.ToString(format);
		}

		public string GetTimeStamp()
		{
			return GetTimeStamp(18);
		}
		#endregion
	}
}
