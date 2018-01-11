using System;
using System.Collections;

namespace TOPSUN.ERP.Common.Utilities
{
    /// <summary>
    /// StringUtil用来进行程序中的字符串处理
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// 将字符串数组列表转换成字符串数组
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public static string[] ArrayListToStringArray(ArrayList al)
        {
            if (al.Count > 0)
            {
                string[] obj = new string[al.Count];
                for (int i = 0; i < al.Count; i++)
                    obj[i] = al[i].ToString();
                return obj;
            }
            else
                return null;
        }

        public static string[][] ArrayListToStringArray2(ArrayList al)
        {
            if (al.Count > 0)
            {
                string[][] obj = new string[al.Count][];
                for (int i = 0; i < al.Count; i++)
                {
                    obj[i] = (string[])al[i];
                }
                return obj;
            }
            else
                return null;
        }

        public static string ArrayListToString(ArrayList al, string delimiter)
        {
            if (al.Count > 0)
            {
                string obj = "";
                for (int i = 0; i < al.Count; i++)
                    obj += delimiter + al[i].ToString();
                return obj.Substring(1, obj.Length - 1);
            }
            else
                return "";
        }

        /// <summary>
        /// 将字符串数组通过分隔符连接成字符串
        /// </summary>
        /// <param name="al"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string StringListToString(string[] al, string delimiter)
        {
            if (al.Length > 0)
            {
                string obj = "";
                for (int i = 0; i < al.Length; i++)
                    obj += delimiter + al[i];
                return obj.Substring(1, obj.Length - 1);
            }
            else
                return "";
        }

        public static ArrayList StringArrayToArrayList(string[] strArray)
        {
            ArrayList result = new ArrayList();
            foreach (string str in strArray)
            {
                result.Add(str);
            }
            return result;
        }

        public static string ArrayToString(string[] array, string delimiter)
        {
            if (array != null && array.Length > 0)
            {
                string obj = "";
                for (int i = 0; i < array.Length; i++)
                    obj += delimiter + array[i].ToString();
                return obj.Substring(1, obj.Length - 1);
            }
            else
                return "";
        }


        /// <summary>
        /// 字符串中包含给定字符的数量
        /// </summary>
        /// <param name="str"></param>
        /// <param name="istart"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static int NumberOfIndex(string str, int istart, char delimiter)
        {
            if (str == null)
                return 0;
            int sl = str.Length;
            int n = 0;
            for (int v = istart; v < sl; v++)
                if (str[v] == delimiter)
                    n++;
            return n;
        }

        public static int NumberOfIndex(string str, char delimiter)
        {
            return NumberOfIndex(str, 0, delimiter);
        }

        public static int NumberOfIndex(string str, int istart, string delimiter)
        {
            if (str == null)
                return 0;
            int sl = str.Length;
            int n = 0;
            int v = str.IndexOf(delimiter, istart);
            while (v >= 0)
            {
                n++;
                v = str.IndexOf(delimiter, v + 1);
            }
            return n;
        }

        public static int NumberOfIndex(string str, string delimiter)
        {
            return NumberOfIndex(str, 0, delimiter);
        }

        #region 将一个字符串从某位置开始以某字符作为分隔符进行分隔(得到每段作为字符串的字符串数组).
        /// <summary>
        /// 将一个字符串从某位置开始以某字符作为分隔符进行分隔(得到每段作为字符串的字符串数组).
        /// </summary>
        /// <param name="str">被分隔的字符串</param>
        /// <param name="istart">开始位置</param>
        /// <param name="delimiter">分隔符</param>
        /// <returns>分隔结果</returns>
        public static String[] splitString(String str, int istart, char delimiter)
        {
            if (str == null)
                return null;
            int sl = str.Length;
            int n = 0;
            for (int v = istart; v < sl; v++)
                if (str[v] == delimiter)
                    n++;
            String[] sa = new String[n + 1];
            int i = istart, j = 0;
            for (; i < sl; )
            {
                int iend = str.IndexOf(delimiter, i);
                if (iend < 0)
                    break;
                sa[j++] = str.Substring(i, iend - i);
                i = iend + 1;
            }
            sa[j++] = str.Substring(i);
            return sa;
        }

        /// <summary>
        /// 将一个字符串以某字符作为分隔符进行分隔(得到每段作为字符串的字符串数组).
        /// </summary>
        /// <param name="str">被分隔字符串</param>
        /// <param name="delimiter">分隔符</param>
        /// <returns>分隔结果</returns>
        public static String[] splitString(String str, char delimiter)
        {
            //return splitString(str,0,delimiter);
            return str.Split(delimiter);
        }

        /// <summary>
        /// 将一个字符串以某两字符作为分隔符进行分隔(得到每段作为字符串的字符串数组).
        /// </summary>
        /// <param name="str">被分隔字符串</param>
        /// <param name="delimiter1">分隔符1</param>
        /// <param name="delimiter2">分隔符2</param>
        /// <returns>分隔结果</returns>
        public static String[][] splitString(String str, char delimiter1, char delimiter2)
        {
            String[] a1 = splitString(str, delimiter1);
            if (a1 == null)
                return null;
            String[][] a2 = new String[a1.Length][];
            for (int i = 0; i < a1.Length; i++)
            {
                a2[i] = splitString(a1[i], delimiter2);
            }
            return a2;
        }

        /// <summary>
        /// 将一个字符串以一组分隔符分割成字符串数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string[] splitString(string str, char[] delimiter, int istart)
        {
            if (str == null)
                return null;
            int strlenght = str.Length;
            int n = 0;
            foreach (char del in delimiter)
            {
                for (int v = istart; v < strlenght; v++)
                    if (str[v] == del)
                        n++;
            }
            String[] result = new String[n + 1];
            int i = istart, j = 0;
            for (; i < strlenght; )
            {
                int iend = MinIndexOf(str, delimiter, i);
                if (iend < 0)
                    break;
                result[j++] = str.Substring(i, iend - i);
                i = iend + 1;
            }
            result[j++] = str.Substring(i);
            Array.Sort(result);
            return result;
        }

        /// <summary>
        /// 将一个字符串以一组分隔符分割成字符串数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string[] splitString(string str, char[] delimiter)
        {
            //return splitString(str,delimiter,0);
            return str.Split(delimiter);
        }

        public static string[] splitStringWithoutDuplicate(string str, char[] delimiter, int startIndex)
        {
            string[] tmpResult = splitString(str, delimiter, startIndex);
            return RemoveDuplicate(tmpResult);
        }

        public static string[] splitStringWithoutDuplicate(string str, char[] delimiter)
        {
            return splitStringWithoutDuplicate(str, delimiter, 0);
        }
        #endregion

        #region 去除字符串数组中的重复项
        /// <summary>
        /// 去除字符串数组中的重复项
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] RemoveDuplicate(string[] str)
        {
            if (str != null && str.Length > 0)
            {
                int length = str.Length;
                if (length == 1)
                    return str;
                else
                {
                    Array.Sort(str);
                    ArrayList tmpStr = new ArrayList();
                    tmpStr.Add(str[0]);
                    for (int i = 1; i < length; i++)
                    {
                        if (str[i - 1] != str[i])
                            tmpStr.Add(str[i]);
                    }
                    string[] result = new string[tmpStr.Count];
                    for (int i = 0; i < tmpStr.Count; i++)
                        result[i] = tmpStr[i].ToString();
                    return result;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// 在二维字符串数组中移除相等项
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public static string[][] RemoveDuplicate(string[][] strArray)
        {
            int length = strArray.GetLength(0);
            if (length == 1)
                return strArray;
            else
            {

                ArrayList tmpStr = new ArrayList();
                tmpStr.Add(strArray[0]);
                for (int i = 1; i < length; i++)
                {
                    bool flag = true;
                    for (int j = 0; j < tmpStr.Count; j++)
                    {
                        if (Equals(strArray[i], ToStringArray(tmpStr[j])))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                        tmpStr.Add(strArray[i]);
                }
                string[][] result = new string[tmpStr.Count][];
                for (int i = 0; i < tmpStr.Count; i++)
                    result[i] = ToStringArray(tmpStr[i]);
                return result;
            }
        }

        /// <summary>
        /// 判断两字符串数组是否相等
        /// </summary>
        /// <param name="strArray1"></param>
        /// <param name="strArray2"></param>
        /// <returns></returns>
        public static bool Equals(string[] strArray1, string[] strArray2)
        {
            int length1 = strArray1.Length;
            int length2 = strArray2.Length;
            if (length1 != length2)
                return false;
            else
            {
                for (int i = 0; i < length1; i++)
                    if (strArray1[i] != strArray2[i])
                        return false;
                return true;
            }
        }

        /// <summary>
        /// 采用冒泡排序法对二维字符串数组进行排序
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public static string[][] Sort(string[][] strArray)
        {
            int length = strArray.GetLength(0);
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < length - 1; i++)
                {
                    if (strArray[i][0].CompareTo(strArray[i + 1][0]) > 0)
                    {
                        string[] tmpstr = strArray[i + 1];
                        strArray[i + 1] = strArray[i];
                        strArray[i] = tmpstr;
                    }
                }
            }
            return strArray;
        }

        #endregion

        /// <summary>
        /// 将object类型转换成字符串数组
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string[] ToStringArray(object obj)
        {
            object[] tmpobj = (object[])obj;
            int length = tmpobj.Length;
            string[] result = new string[length];
            for (int i = 0; i < length; i++)
                result[i] = tmpobj[i].ToString();
            return result;
        }

        public static string[] StringArray2ToArray(string[][] str2)
        {
            object[][] obj2 = (object[][])str2;
            object[] obj1 = ArrayUtil.Array2ToArray(obj2);
            object obj = (object[])obj1;
            return ToStringArray(obj);
        }

        #region 确定一组标识字符在字符串中最小的索引
        /// <summary>
        /// 确定一组标识字符在字符串中最小的索引
        /// </summary>
        /// <param name="str"></param>
        /// <param name="charvalue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int MinIndexOf(string str, char[] charvalue, int startIndex)
        {
            int length = charvalue.Length;
            int result = str.IndexOf(charvalue[0], startIndex);
            int tmp;
            for (int i = 1; i < length; i++)
            {
                tmp = str.IndexOf(charvalue[i], startIndex);
                if (tmp < 0)
                    continue;
                else
                {
                    if (result < 0)
                        result = tmp;
                    else
                        result = System.Math.Min(result, tmp);
                }
            }
            return result;
        }

        public static int MinIndexOf(string str, char[] charvalue)
        {
            return MinIndexOf(str, charvalue, 0);
        }
        #endregion

        #region 确定一组标识字符在字符串中最大的索引
        /// <summary>
        /// 确定一组标识字符在字符串中最大的索引
        /// </summary>
        /// <param name="str"></param>
        /// <param name="charvalue"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int MaxIndexOf(string str, char[] charvalue, int startIndex)
        {
            int length = charvalue.Length;
            int[] index = new int[length];
            for (int i = 0; i < length; i++)
                index[i] = str.IndexOf(charvalue[i], startIndex);
            return (int)Math.Max(index);
        }

        public static int MaxIndexOf(string str, char[] charvalue)
        {
            return MaxIndexOf(str, charvalue, 0);
        }
        #endregion

        #region 将一个字符串以某字符作为分隔符进行分隔后取其中某一段.
        /// <summary>
        /// 将一个字符串以某字符作为分隔符进行分隔后取其中某一段.
        /// </summary>
        /// <param name="str">被分隔的字符串</param>
        /// <param name="istart">开始位置</param>
        /// <param name="delimiter">分隔符</param>
        /// <param name="index">分隔后的子串数组下标</param>
        /// <returns>第 index 个子串</returns>
        public static String SubSplitString(String str, int istart, char delimiter, int index)
        {
            if (str == null) return null;
            int sl = str.Length;
            int i = istart, j = 0;
            for (; i < sl; )
            {
                int iend = str.IndexOf(delimiter, i);
                if (iend < 0)
                    break;
                if (j++ == index) return str.Substring(i, iend - i);
                i = iend + 1;
            }
            return j == index ? str.Substring(i) : null;
        }

        /// <summary>
        /// 将一个字符串以某字符作为分隔符进行分隔后取其中某一段.
        /// </summary>
        /// <param name="str">被分隔的字符串</param>
        /// <param name="delimiter">分隔符</param>
        /// <param name="index">分隔后的子串数组下标</param>
        /// <returns>第 index 个子串</returns>
        public static String SubSplitString(String str, char delimiter, int index)
        {
            return SubSplitString(str, 0, delimiter, index);
        }
        #endregion

        #region 将一个字符串头尾的括号去掉.
        /// <summary>
        /// 将一个字符串头尾的括号去掉.
        /// </summary>
        /// <param name="text">头尾带括号的字符串</param>
        /// <param name="head">头括号字符,如 '[','(','{' 等</param>
        /// <param name="tail">尾括号字符,如 ']',')','}' 等</param>
        /// <returns>text头尾去掉括号后的结果(中间的括号忽略)</returns>
        /// <example>本示例说明如何将字符串头尾的"[]"去除。
        /// <code>String text = removeBrackets("[abcdefg]",'[',']');</code>
        /// 返回结果为 "abcdefg"
        /// </example>
        public static String removeBrackets(String text, char head, char tail)
        {
            if (text == null)
                return text;
            int len = text.Length;
            return text[0] == head && text[len - 1] == tail ? text.Substring(1, len - 1) : text;
        }
        #endregion

        #region 将一个字符串中某字符替换为另外一个字符.
        /// <summary>
        /// 将一个字符串中某字符替换为另外一个字符.
        /// </summary>
        /// <param name="text">被替换的字符串</param>
        /// <param name="charFrom">text中被替换的字符</param>
        /// <param name="charTo">替换的字符</param>
        /// <returns>替换后的结果字符串</returns>
        public static String replaceChar(String text, char charFrom, char charTo)
        {
            if (text == null || text.IndexOf(charFrom) < 0)
                return text;
            String str = "";
            for (int i0 = 0; i0 < text.Length; )
            {
                int i = text.IndexOf(charFrom, i0);
                if (i < 0)
                {
                    str += text.Substring(i0);
                    break;
                }
                else
                {
                    str += text.Substring(i0, i - i0);
                    str += charTo;
                    i0 = i + 1;
                }
            }
            return str;
        }
        #endregion

        #region 将一个字符串中某子串替换为另外一个子串.
        /// <summary>
        /// 将一个字符串中某字符替换为另外一个字符.
        /// </summary>
        /// <param name="text">被替换的字符串</param>
        /// <param name="charFrom">text中被替换的字符</param>
        /// <param name="charTo">替换的字符</param>
        /// <returns>替换后的结果字符串</returns>
        public static String ReplaceString(String text, string stringFrom, string stringTo)
        {
            if (text == null || text.IndexOf(stringFrom) < 0)
                return text;
            String str = "";
            for (int i0 = 0; i0 < text.Length; )
            {
                int i = text.IndexOf(stringFrom, i0);
                if (i < 0)
                {
                    str += text.Substring(i0);
                    break;
                }
                else
                {
                    str += text.Substring(i0, i - i0);
                    str += stringTo;
                    i0 = i + stringFrom.Length;
                }
            }
            return str;
        }
        #endregion

        /// <summary>
        /// 移除字符串中所有空格
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string TrimAll(string text)
        {
            char nullChar = ' ';
            if (text == null || text.IndexOf(nullChar) < 0)
                return text;
            String str = "";
            for (int i0 = 0; i0 < text.Length; )
            {
                int i = text.IndexOf(nullChar, i0);
                if (i < 0)
                {
                    str += text.Substring(i0);
                    break;
                }
                else
                {
                    str += text.Substring(i0, i - i0);
                    i0 = i + 1;
                }
            }
            return str;
        }

        /// <summary>
        /// 将日期字符串格式化
        /// </summary>
        /// <param name="datestring"></param>
        /// <returns></returns>
        public static string FormatDateString(string datestring)
        {
            if (datestring != "" && datestring != null)
                return DateTime.Parse(datestring).ToString("yyyy-MM-dd");
            else
                return "";
        }

        #region 判断字符串是否为null
        /// <summary>
        /// 判断字符串是否为null
        /// </summary>
        /// <param name="str">被判断的字符串</param>
        /// <returns>如果字符串为空，返回null，否则返回该字符串</returns>
        public static string StringIsNull(string str)
        {
            str = str.Trim();
            if (str != "")
                return str;
            else
                return null;
        }
        #endregion

        public static DBNull DateTimeIsNull(string str)
        {
            return DBNull.Value;
        }
    }
}
