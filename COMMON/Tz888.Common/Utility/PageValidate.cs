using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web;

namespace Tz888.Common.Utility
{
    /// <summary>
    /// 页面数据校验类
    /// </summary>
    public class PageValidate
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(cn|com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
        private static Regex RegHTML = new Regex("<(.[^>]*)>");
        private static string Sql_injdata = @"select |insert |delete from |count\(|drop table|update |truncate |asc\(|mid\(|char\(|xp_cmdshell|exec master|net localgroup administrators|:|net user|""|\'| or ";
        public PageValidate()
        {
        }
        #region 数字字符串检查

        /// <summary>
        /// 检查Request查询字符串的键值，是否是数字，最大长度限制
        /// </summary>
        /// <param name="req">Request</param>
        /// <param name="inputKey">Request的键值</param>
        /// <param name="maxLen">最大长度</param>
        /// <returns>返回Request查询字符串</returns>
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
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 文本输入输出处理

        /// <summary>
        /// 过滤危险字符串
        /// </summary>
        /// <param name="chr">要过滤的字符串</param>
        /// <returns>返回过滤后的字符串</returns>
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
        /// 替换html中的特殊字符
        /// </summary>
        /// <param name="theString">需要进行替换的文本。</param>
        /// <returns>替换完的文本。</returns>
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
        /// 恢复html中的特殊字符
        /// </summary>
        /// <param name="theString">需要恢复的文本。</param>
        /// <returns>恢复好的文本。</returns>
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

        #region 将输入的文本字符串转换成HTML代码
        /// <summary>
        /// 将输入的文本字符串转换成HTML代码，转换以下字符
        /// "\n\b" -> "<br>"
        /// </summary>
        /// <param name="strTxt">来自文本框的字符串</param>
        /// <returns>返回HTML可识别字符串</returns>
        public static string TxtToHtml(string strTxt)
        {
            string strTmp = strTxt;
            strTmp = strTmp.Replace("<", "&lt;");
            strTmp = strTmp.Replace(">", " &gt;");
            //strTmp = strTmp.Replace(" ","&nbsp;");   暂时去掉，因为这样会引起英文文本的显示格式问题，关于首行缩进另外想办法解决
            strTmp = strTmp.Replace("\r\n", "<br>");
            return strTmp;
        }
        #endregion

        #region 将输入的HTML转换为可以被文本框识别的格式
        /// <summary>
        /// 将输入的HTML转换为可以被文本框识别的格式
        /// </summary>
        /// <param name="strHtml">输入HTML的字符串</param>
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

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 邮件地址
        /// <summary>
        /// 是否是电子邮件地址
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        #region GET/POST提交检查(防SQL注入)

        /// <summary>
        /// GET方式提交检查
        /// </summary>
        /// <param name="page">需要检查的页面</param>
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
        /// POS方式提交检查
        /// </summary>
        /// <param name="page">需要检查的页面</param>
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
        /// 将输入字符串中的HTML标记剔除
        /// </summary>
        public static string FiltrateHTMLTag(string input)
        {
            return RegHTML.Replace(input, "");
        }

        /// <summary>
        /// 对指定字符串取指定长度，考虑了全角半角的问题
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

        #region 其他

        /// <summary>
        /// 检查字符串最大长度，返回指定长度的串
        /// </summary>
        /// <param name="sqlInput">输入字符串</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>			
        public static string SqlText(string sqlInput, int maxLength)
        {
            if (sqlInput != null && sqlInput != string.Empty)
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength)//按最大长度截取字符串
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }

        /// <summary>
        /// 设置Label显示Encode的字符串
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

        #region 截获定长的字符串
        /// <summary>
        /// 截获定长的字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="length">需要截获的长度</param>
        /// <param name="postfix">如果字符串被截短，需要添加什么样的后缀</param>
        /// <returns>截获后的字符串</returns>
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
