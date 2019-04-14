using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web;

namespace Tz888.Common.Utility
{
    /// <summary>
    /// ҳ������У����
    /// </summary>
    public class PageValidate
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //�ȼ���^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(cn|com|net|org|edu|mil|tv|biz|info)$");//w Ӣ����ĸ�����ֵ��ַ������� [a-zA-Z0-9] �﷨һ�� 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegHTML = new Regex("<(.[^>]*)>");
        private static string Sql_injdata = @"select |insert |delete from |count\(|drop table|update |truncate |asc\(|mid\(|char\(|xp_cmdshell|exec master|net localgroup administrators|:|net user|""|\'| or ";
        public PageValidate()
        {
        }
        #region �����ַ������

        /// <summary>
        /// ���Request��ѯ�ַ����ļ�ֵ���Ƿ������֣���󳤶�����
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request�ļ�ֵ</param>
        /// <param name="maxLen">��󳤶�</param>
        /// <returns>����Request��ѯ�ַ���</returns>
        public static string FetchInputDigit(HttpRequest req, string inputKey, int maxLen)
        {
            string retVal = string.Empty;
            if (inputKey != null && inputKey != string.Empty)
            {
                retVal = req.QueryString[inputKey];
                if (null == retVal)
                    retVal = req.Form[inputKey];
                if (null != retVal)
                {
                    retVal = SqlText(retVal, maxLen);
                    if (!IsNumber(retVal))
                        retVal = string.Empty;
                }
            }
            if (retVal == null)
                retVal = string.Empty;
            return retVal;
        }
        /// <summary>
        /// �Ƿ������ַ���
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// �Ƿ������ַ��� �ɴ�������
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// �Ƿ��Ǹ�����
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// �Ƿ��Ǹ����� �ɴ�������
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region �ı������������

        /// <summary>
        /// ����Σ���ַ���
        /// </summary>
        /// <param name="chr">Ҫ���˵��ַ���</param>
        /// <returns>���ع��˺���ַ���</returns>
        public static string ReplaceStr(string chr)
        {
            if (chr == null)
                return "";
            chr = chr.Replace("<", "");
            chr = chr.Replace(">", "");
            chr = chr.Replace("\n", "");
            chr = chr.Replace("\"", "");
            chr = chr.Replace("'", "");
            chr = chr.Replace(" ", "");
            chr = chr.Replace("\r", "");
            chr = chr.Replace("--", "");
            return (chr);

        }

        /// <summary>
        /// �滻html�е������ַ�
        /// </summary>
        /// <param name="theString">��Ҫ�����滻���ı���</param>
        /// <returns>�滻����ı���</returns>
        public static string HtmlEncode(string theString)
        {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace("  ", " &nbsp;");
            theString = theString.Replace("  ", " &nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("\'", "&#39;");
            theString = theString.Replace("\n", "<br/> ");
            return theString;
        }

        /// <summary>
        /// �ָ�html�е������ַ�
        /// </summary>
        /// <param name="theString">��Ҫ�ָ����ı���</param>
        /// <returns>�ָ��õ��ı���</returns>
        public static string HtmlDiscode(string theString)
        {
            theString = theString.Replace("&gt;", ">");
            theString = theString.Replace("&lt;", "<");
            theString = theString.Replace("&nbsp;", " ");
            theString = theString.Replace(" &nbsp;", "  ");
            theString = theString.Replace("&quot;", "\"");
            theString = theString.Replace("&#39;", "\'");
            theString = theString.Replace("<br/> ", "\n");
            return theString;
        }

        #endregion

        #region ��������ı��ַ���ת����HTML����
        /// <summary>
        /// ��������ı��ַ���ת����HTML���룬ת�������ַ�
        /// "\n\b" -> "<br>"
        /// </summary>
        /// <param name="strTxt">�����ı�����ַ���</param>
        /// <returns>����HTML��ʶ���ַ���</returns>
        public static string TxtToHtml(string strTxt)
        {
            string strTmp = strTxt;
            strTmp = strTmp.Replace("<", "&lt;");
            strTmp = strTmp.Replace(">", " &gt;");
            //strTmp = strTmp.Replace(" ","&nbsp;");   ��ʱȥ������Ϊ����������Ӣ���ı�����ʾ��ʽ���⣬������������������취���
            strTmp = strTmp.Replace("\r\n", "<br>");
            return strTmp;
        }
        #endregion

        #region �������HTMLת��Ϊ���Ա��ı���ʶ��ĸ�ʽ
        /// <summary>
        /// �������HTMLת��Ϊ���Ա��ı���ʶ��ĸ�ʽ
        /// </summary>
        /// <param name="strHtml">����HTML���ַ���</param>
        /// <returns></returns>
        public static string HtmlToTxt(string strHtml)
        {
            string strTmp = strHtml;
            strTmp = strTmp.Replace("<br>", "\r\n");
            strTmp = strTmp.Replace("&lt;", "<");
            strTmp = strTmp.Replace("&gt;", ">");
            strTmp = strTmp.Replace("&nbsp;", " ");
            strTmp = strTmp.Replace("&nbsp", " ");
            return strTmp;
        }
        #endregion

        #region ���ļ��

        /// <summary>
        /// ����Ƿ��������ַ�
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region �ʼ���ַ
        /// <summary>
        /// �Ƿ��ǵ����ʼ���ַ
        /// </summary>
        /// <param name="inputData">�����ַ���</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        #region GET/POST�ύ���(��SQLע��)

        /// <summary>
        /// GET��ʽ�ύ���
        /// </summary>
        /// <param name="page">��Ҫ����ҳ��</param>
        /// <returns></returns>
        public static bool CheckGetString(System.Web.UI.Page page)
        {
            string str = page.Request.QueryString.ToString();
            if (str.Trim() == "" || str == null)
                return true;
            else
            {
                Regex re = new Regex(@"\s");
                str = str.Replace("%20", " ");
                str = re.Replace(str, " ");
                if (Regex.IsMatch(str, Sql_injdata))
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// POS��ʽ�ύ���
        /// </summary>
        /// <param name="page">��Ҫ����ҳ��</param>
        /// <returns></returns>
        public static bool CheckPostString(System.Web.UI.Page page)
        {
            string str = page.Request.Form.ToString();
            if (str.Trim() == "" || str == null)
                return true;
            else
            {
                Regex re = new Regex(@"\s");
                str = str.Replace("%20", " ");
                str = re.Replace(str, " ");
                if (Regex.IsMatch(str, Sql_injdata))
                    return false;
                else
                    return true;
            }
        }


        #endregion

        /// <summary>
        /// �������ַ����е�HTML����޳�
        /// </summary>
        public static string FiltrateHTMLTag(string input)
        {
            return RegHTML.Replace(input, "");
        }

        /// <summary>
        /// ��ָ���ַ���ȡָ�����ȣ�������ȫ�ǰ�ǵ�����
        /// </summary>
        public static string StringSub(string str, int len)
        {
            string temp = "";
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int i = 0;
            int j = 0;
            while (i < len && j < b.Length)
            {
                temp += str.Substring(0, 1);
                str = str.Substring(1);
                if (b[j] >= 63)
                    i = i + 2;
                else
                    i++;
                j++;
            }
            return temp;
        }

        #region ����

        /// <summary>
        /// ����ַ�����󳤶ȣ�����ָ�����ȵĴ�
        /// </summary>
        /// <param name="sqlInput">�����ַ���</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <returns></returns>			
        public static string SqlText(string sqlInput, int maxLength)
        {
            if (sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)//����󳤶Ƚ�ȡ�ַ���
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }

        /// <summary>
        /// ����Label��ʾEncode���ַ���
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="txtInput"></param>
        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = HtmlEncode(txtInput);
        }
        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }

        #endregion

        #region �ػ񶨳����ַ���
        /// <summary>
        /// �ػ񶨳����ַ���
        /// </summary>
        /// <param name="source">Դ�ַ���</param>
        /// <param name="length">��Ҫ�ػ�ĳ���</param>
        /// <param name="postfix">����ַ������ض̣���Ҫ���ʲô���ĺ�׺</param>
        /// <returns>�ػ����ַ���</returns>
        public static string FixLenth(string source, int length, string postfix)
        {
            int postfixLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(postfix);
            int srcLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(source);

            if (srcLength > length)
            {
                for (int i = source.Length; i > 0; i--)
                {
                    srcLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(source.Substring(0, i));

                    if (srcLength <= length - postfixLength)
                        return source.Substring(0, i) + postfix;
                }
                return "";
            }
            else
                return source;
        }
        #endregion
    }
}
