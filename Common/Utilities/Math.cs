using System;

namespace TOPSUN.ERP.Common.Utilities
{
    /// <summary>
    /// Math ��ժҪ˵����
    /// </summary>
    public class Math
    {
        public static int Min(int[] obj)
        {
            int result = obj[0];
            foreach (int tmpobj in obj)
            {
                result = System.Math.Min(result, tmpobj);
            }
            return result;
        }

        public static int Max(int[] obj)
        {
            int result = obj[0];
            foreach (int tmpobj in obj)
            {
                result = System.Math.Max(result, tmpobj);
            }
            return result;
        }
    }
}
