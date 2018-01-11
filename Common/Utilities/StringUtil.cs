using System;
using System.Collections;

namespace TOPSUN.ERP.Common.Utilities
{
    /// <summary>
    /// StringUtil�������г����е��ַ�������
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// ���ַ��������б�ת�����ַ�������
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
        /// ���ַ�������ͨ���ָ������ӳ��ַ���
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
        /// �ַ����а��������ַ�������
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

        #region ��һ���ַ�����ĳλ�ÿ�ʼ��ĳ�ַ���Ϊ�ָ������зָ�(�õ�ÿ����Ϊ�ַ������ַ�������).
        /// <summary>
        /// ��һ���ַ�����ĳλ�ÿ�ʼ��ĳ�ַ���Ϊ�ָ������зָ�(�õ�ÿ����Ϊ�ַ������ַ�������).
        /// </summary>
        /// <param name="str">���ָ����ַ���</param>
        /// <param name="istart">��ʼλ��</param>
        /// <param name="delimiter">�ָ���</param>
        /// <returns>�ָ����</returns>
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
        /// ��һ���ַ�����ĳ�ַ���Ϊ�ָ������зָ�(�õ�ÿ����Ϊ�ַ������ַ�������).
        /// </summary>
        /// <param name="str">���ָ��ַ���</param>
        /// <param name="delimiter">�ָ���</param>
        /// <returns>�ָ����</returns>
        public static String[] splitString(String str, char delimiter)
        {
            //return splitString(str,0,delimiter);
            return str.Split(delimiter);
        }

        /// <summary>
        /// ��һ���ַ�����ĳ���ַ���Ϊ�ָ������зָ�(�õ�ÿ����Ϊ�ַ������ַ�������).
        /// </summary>
        /// <param name="str">���ָ��ַ���</param>
        /// <param name="delimiter1">�ָ���1</param>
        /// <param name="delimiter2">�ָ���2</param>
        /// <returns>�ָ����</returns>
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
        /// ��һ���ַ�����һ��ָ����ָ���ַ�������
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
        /// ��һ���ַ�����һ��ָ����ָ���ַ�������
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

        #region ȥ���ַ��������е��ظ���
        /// <summary>
        /// ȥ���ַ��������е��ظ���
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
        /// �ڶ�ά�ַ����������Ƴ������
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
        /// �ж����ַ��������Ƿ����
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
        /// ����ð�����򷨶Զ�ά�ַ��������������
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
        /// ��object����ת�����ַ�������
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

        #region ȷ��һ���ʶ�ַ����ַ�������С������
        /// <summary>
        /// ȷ��һ���ʶ�ַ����ַ�������С������
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

        #region ȷ��һ���ʶ�ַ����ַ�������������
        /// <summary>
        /// ȷ��һ���ʶ�ַ����ַ�������������
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

        #region ��һ���ַ�����ĳ�ַ���Ϊ�ָ������зָ���ȡ����ĳһ��.
        /// <summary>
        /// ��һ���ַ�����ĳ�ַ���Ϊ�ָ������зָ���ȡ����ĳһ��.
        /// </summary>
        /// <param name="str">���ָ����ַ���</param>
        /// <param name="istart">��ʼλ��</param>
        /// <param name="delimiter">�ָ���</param>
        /// <param name="index">�ָ�����Ӵ������±�</param>
        /// <returns>�� index ���Ӵ�</returns>
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
        /// ��һ���ַ�����ĳ�ַ���Ϊ�ָ������зָ���ȡ����ĳһ��.
        /// </summary>
        /// <param name="str">���ָ����ַ���</param>
        /// <param name="delimiter">�ָ���</param>
        /// <param name="index">�ָ�����Ӵ������±�</param>
        /// <returns>�� index ���Ӵ�</returns>
        public static String SubSplitString(String str, char delimiter, int index)
        {
            return SubSplitString(str, 0, delimiter, index);
        }
        #endregion

        #region ��һ���ַ���ͷβ������ȥ��.
        /// <summary>
        /// ��һ���ַ���ͷβ������ȥ��.
        /// </summary>
        /// <param name="text">ͷβ�����ŵ��ַ���</param>
        /// <param name="head">ͷ�����ַ�,�� '[','(','{' ��</param>
        /// <param name="tail">β�����ַ�,�� ']',')','}' ��</param>
        /// <returns>textͷβȥ�����ź�Ľ��(�м�����ź���)</returns>
        /// <example>��ʾ��˵����ν��ַ���ͷβ��"[]"ȥ����
        /// <code>String text = removeBrackets("[abcdefg]",'[',']');</code>
        /// ���ؽ��Ϊ "abcdefg"
        /// </example>
        public static String removeBrackets(String text, char head, char tail)
        {
            if (text == null)
                return text;
            int len = text.Length;
            return text[0] == head && text[len - 1] == tail ? text.Substring(1, len - 1) : text;
        }
        #endregion

        #region ��һ���ַ�����ĳ�ַ��滻Ϊ����һ���ַ�.
        /// <summary>
        /// ��һ���ַ�����ĳ�ַ��滻Ϊ����һ���ַ�.
        /// </summary>
        /// <param name="text">���滻���ַ���</param>
        /// <param name="charFrom">text�б��滻���ַ�</param>
        /// <param name="charTo">�滻���ַ�</param>
        /// <returns>�滻��Ľ���ַ���</returns>
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

        #region ��һ���ַ�����ĳ�Ӵ��滻Ϊ����һ���Ӵ�.
        /// <summary>
        /// ��һ���ַ�����ĳ�ַ��滻Ϊ����һ���ַ�.
        /// </summary>
        /// <param name="text">���滻���ַ���</param>
        /// <param name="charFrom">text�б��滻���ַ�</param>
        /// <param name="charTo">�滻���ַ�</param>
        /// <returns>�滻��Ľ���ַ���</returns>
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
        /// �Ƴ��ַ��������пո�
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
        /// �������ַ�����ʽ��
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

        #region �ж��ַ����Ƿ�Ϊnull
        /// <summary>
        /// �ж��ַ����Ƿ�Ϊnull
        /// </summary>
        /// <param name="str">���жϵ��ַ���</param>
        /// <returns>����ַ���Ϊ�գ�����null�����򷵻ظ��ַ���</returns>
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
