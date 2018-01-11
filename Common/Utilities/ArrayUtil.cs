using System;
using System.Collections;

namespace TOPSUN.ERP.Common.Utilities
{
    /// <summary>
    /// ArrayUtil 的摘要说明。
    /// </summary>
    public class ArrayUtil
    {
        public static Object[,] Multiply(Object[] array1, Object[] array2)
        {
            int length1 = array1.Length;
            int length2 = array2.Length;
            Object[,] array = new Object[length1 * length2, 2];
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    array[i * length2 + j, 0] = array1[i];
                    array[i * length2 + j, 1] = array2[j];
                }
            }
            return array;
        }

        public static string[,] Multiply(string[] array1, string[] array2)
        {
            int length1 = array1.Length;
            int length2 = array2.Length;
            string[,] array = new string[length1 * length2, 2];
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    array[i * length2 + j, 0] = array1[i];
                    array[i * length2 + j, 1] = array2[j];
                }
            }
            return array;
        }

        public static Object[][] MultiplyX(Object[] array1, Object[] array2)
        {
            int length1 = array1.Length;
            int length2 = array2.Length;
            Object[][] array = new Object[length1 * length2][];
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    array[i * length2 + j] = new Object[2];
                    array[i * length2 + j][0] = array1[i];
                    array[i * length2 + j][1] = array2[j];
                }
            }
            return array;
        }

        public static Object[][] MultiplyX(Object[] array1, Object array2)
        {
            int length1 = array1.Length;
            Object[][] array = new Object[length1][];
            for (int i = 0; i < length1; i++)
            {
                array[i] = new Object[2];
                array[i][0] = array1[i];
                array[i][1] = array2;
            }
            return array;
        }

        public static Object[][] MultiplyX(Object[] array1, Object array2, Object array3)
        {
            int length1 = array1.Length;
            Object[][] array = new Object[length1][];
            for (int i = 0; i < length1; i++)
            {
                array[i] = new Object[3];
                array[i][0] = array1[i];
                array[i][1] = array2;
                array[i][2] = array3;
            }
            return array;
        }

        public static string[][] MultiplyX(string[] array1, string array2, string array3)
        {
            int length1 = array1.Length;
            string[][] array = new string[length1][];
            for (int i = 0; i < length1; i++)
            {
                array[i] = new string[3];
                array[i][0] = array1[i];
                array[i][1] = array2;
                array[i][2] = array3;
            }
            return array;
        }

        public static Object[][] MultiplyX(Object array1, Object[] array2)
        {
            int length2 = array2.Length;
            Object[][] array = new Object[length2][];
            for (int j = 0; j < length2; j++)
            {
                array[j] = new Object[2];
                array[j][0] = array1;
                array[j][1] = array2[j];

            }
            return array;
        }

        public static string[][] MultiplyX(string[] array1, string[] array2)
        {
            int length1 = array1.Length;
            int length2 = array2.Length;
            string[][] array = new string[length1 * length2][];
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    array[i * length2 + j] = new string[2];
                    array[i * length2 + j][0] = array1[i];
                    array[i * length2 + j][1] = array2[j];
                }
            }
            return array;
        }

        public static string[][] MultiplyX(string[] array1, string array2)
        {
            int length1 = array1.Length;
            string[][] array = new string[length1][];
            for (int i = 0; i < length1; i++)
            {
                array[i] = new string[2];
                array[i][0] = array1[i];
                array[i][1] = array2;
            }
            return array;
        }

        public static string[][] MultiplyX(string array1, string[] array2)
        {
            int length2 = array2.Length;
            string[][] array = new string[length2][];
            for (int j = 0; j < length2; j++)
            {
                array[j] = new string[2];
                array[j][0] = array1;
                array[j][1] = array2[j];

            }
            return array;
        }

        public static Object[] Add(Object[] array1, Object[] array2)
        {
            Object[] array = new Object[array1.Length + array2.Length];
            array1.CopyTo(array, 0);
            array2.CopyTo(array, array1.Length);
            return array;
        }

        public static string[] Add(string[] array1, string[] array2)
        {
            string[] array = new string[array1.Length + array2.Length];
            array1.CopyTo(array, 0);
            array2.CopyTo(array, array1.Length);
            return array;
        }



        public static string[][] Add(string[][] array1, string[][] array2)
        {
            int array1length = array1.GetLength(0);
            int array2length = array2.GetLength(0);
            string[][] array = new string[array1length + array2length][];
            for (int i = 0; i < array1length; i++)
            {
                int length = array1[i].Length;
                array[i] = new string[length];
                array1[i].CopyTo(array[i], 0);
            }
            for (int i = 0; i < array2length; i++)
            {
                int length = array2[i].Length;
                array[array1length + i] = new string[length];
                array2[i].CopyTo(array[array1length + i], 0);
            }
            return array;
        }

        public static object[] ArrayListToArray(ArrayList al)
        {
            object[] obj = new object[al.Count];
            for (int i = 0; i < al.Count; i++)
                obj[i] = al[i];
            return obj;
        }

        public static object[] Array2ToArray(object[][] obj)
        {
            if (obj.Length == 0)
                return null;

            object[] result = new object[0];
            for (int i = 0; i < obj.Length; i++)
            {
                result = Add(result, obj[i]);
            }
            return result;
        }

        #region 去除ArrayList中的重复项
        /// <summary>
        /// 去除字符串数组中的重复项
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ArrayList RemoveDuplicate(ArrayList al)
        {
            if (al != null && al.Count > 0)
            {
                int length = al.Count;
                if (length == 1)
                    return al;
                else
                {
                    al.Sort();
                    ArrayList tmpStr = new ArrayList();
                    tmpStr.Add(al[0]);
                    for (int i = 1; i < length; i++)
                    {
                        if (al[i - 1].ToString().Trim() != al[i].ToString().Trim())
                            tmpStr.Add(al[i]);
                    }
                    return tmpStr;
                }
            }
            else
                return null;
        }
        #endregion
    }
}
