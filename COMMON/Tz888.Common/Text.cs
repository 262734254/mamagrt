using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace Tz888.Common
{
    /// <summary>
    /// 字符串处理类
    /// </summary>
    public class Text
    {
        #region 成员字段/构造函数




        public Text()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 字符串 加/解 密



        /// <summary>
        /// 字符串加密



        /// </summary>
        /// <param name="strText">要加密的字符串</param>
        /// <param name="strEncrKey">密钥</param>
        /// <returns>返回加密后的字符串</returns>
        public static string DesEncrypt(string strText, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, strEncrKey.Length));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception error)
            {
                return "error:" + error.Message + "\r";
            }
        }
        /// <summary>
        /// 字符串解密



        /// </summary>
        /// <param name="strText">要解密的字符串</param>
        /// <param name="sDecrKey">密钥</param>
        /// <returns>返回解密后的字符串</returns>
        public static string DesDecrypt(string strText, string sDecrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[strText.Length];
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception error)
            {
                return "error:" + error.Message + "\r";
            }

        }
        #endregion

        #region 字符串精确截取


        /// <summary>
        /// 字符串精确截取函数
        /// </summary>
        /// <param name="aSrcStr">要截取的字符串</param>
        /// <param name="aLimitedNum">要截取的长度</param>
        /// <returns>返回截取后的字符串</returns>
        public static string GetLenghtStr2(string aSrcStr, int aLimitedNum)
        {

            string temp;
            int n = 0;//中文的个数
            foreach (char c in aSrcStr)
            {
                if (c >= 0x4e00 && c <= 0x9fa5)
                    n++;
            }

            if (aSrcStr.Length > aLimitedNum)
            {
                temp = aSrcStr.Substring(0, aLimitedNum - 1+50000);
                temp += "..";
            }
            else
            {
                temp = aSrcStr;
            }                      
            return temp ;
        }



        /// <summary>
        /// 字符串精确截取函数2
        /// </summary>
        /// <param name="aSrcStr">要截取的字符串</param>
        /// <param name="aLimitedNum">要截取的长度</param>
        /// <returns>返回截取后的字符串</returns>
        public static string GetLenghtStr(string aSrcStr, int aLimitedNum)
        {
            if (aSrcStr.Length > aLimitedNum)
            {
                aSrcStr = aSrcStr.Substring(0, aSrcStr.Length - 1);
            }

            if (aLimitedNum <= 0) return aSrcStr;
            String TmpStr = aSrcStr;
            byte[] TmpStrBytes = System.Text.Encoding.GetEncoding("GB2312").GetBytes(TmpStr);
            if (TmpStrBytes.Length <= aLimitedNum)
            {
                return aSrcStr;
            }
            else
            {
                byte[] LStrBytes = null;
                int NeedStrNum = 0;
                if (TmpStrBytes[aLimitedNum] > 127)
                {
                    LStrBytes = new byte[aLimitedNum + 1];
                    NeedStrNum = aLimitedNum + 1;
                }
                else
                {
                    LStrBytes = new byte[aLimitedNum];
                    NeedStrNum = aLimitedNum;
                }
                Array.Copy(TmpStrBytes, LStrBytes, NeedStrNum);
                string temp = System.Text.Encoding.GetEncoding("GB2312").GetString(LStrBytes);
                if (temp.Substring(temp.Length - 1, 1) == "?")
                    temp = temp.Substring(0, temp.Length - 1) + "";
                return temp + System.Text.Encoding.ASCII.GetString(System.Text.Encoding.ASCII.GetBytes(".."));
            }
        }

        /// <summary>
        /// 字符串精确截取函数2
        /// </summary>
        /// <param name="aSrcStr">要截取的字符串</param>
        /// <param name="aLimitedNum">要截取的长度</param>
        /// <returns>返回截取后的字符串</returns>
        public static string GetLenghtStr3(string aSrcStr, int aLimitedNum)
        {
            if (aSrcStr.Length > aLimitedNum)
            {
                aSrcStr = aSrcStr.Substring(0, aSrcStr.Length - 1);
            }

            if (aLimitedNum <= 0) return aSrcStr;
            String TmpStr = aSrcStr;
            byte[] TmpStrBytes = System.Text.Encoding.GetEncoding("GB2312").GetBytes(TmpStr);
            if (TmpStrBytes.Length <= aLimitedNum)
            {
                return aSrcStr;
            }
            else
            {
                byte[] LStrBytes = null;
                int NeedStrNum = 0;
                if (TmpStrBytes[aLimitedNum] > 127)
                {
                    LStrBytes = new byte[aLimitedNum + 1];
                    NeedStrNum = aLimitedNum + 1;
                }
                else
                {
                    LStrBytes = new byte[aLimitedNum];
                    NeedStrNum = aLimitedNum;
                }
                Array.Copy(TmpStrBytes, LStrBytes, NeedStrNum);
                string temp = System.Text.Encoding.GetEncoding("GB2312").GetString(LStrBytes);
                if (temp.Substring(temp.Length - 1, 1) == "?")
                    temp = temp.Substring(0, temp.Length - 1) + "";
                return temp;
            }
        }
       

        /// </summary>
        /// <param name="aSrcStr">要截取的字符串</param>
        /// <param name="aLimitedNum">要截取的长度</param>
        /// <returns>返回截取后的字符串</returns>
        public static string GetLenghtStr(string aSrcStr, int aLimitedNum,int DotCount)
        {
            if (aLimitedNum <= 0) return aSrcStr;
            String TmpStr = aSrcStr;
            byte[] TmpStrBytes = System.Text.Encoding.GetEncoding("GB2312").GetBytes(TmpStr);
            if (TmpStrBytes.Length <= aLimitedNum)
            {
                return aSrcStr;
            }
            else
            {
                byte[] LStrBytes = null;
                int NeedStrNum = 0;
                if (TmpStrBytes[aLimitedNum] > 127)
                {
                    LStrBytes = new byte[aLimitedNum + 1];
                    NeedStrNum = aLimitedNum + 1;
                }
                else
                {
                    LStrBytes = new byte[aLimitedNum];
                    NeedStrNum = aLimitedNum;
                }
                Array.Copy(TmpStrBytes, LStrBytes, NeedStrNum-1);
                string temp = System.Text.Encoding.GetEncoding("GB2312").GetString(LStrBytes);
                if (temp.Substring(temp.Length - 1, 1) == "?" || temp.Substring(temp.Length - 1, 1) == "？")
                    temp = temp.Substring(0, temp.Length - 1) + "";
                //temp=temp.Replace("?","").Replace("？","");
                string strDot = string.Empty;

                for (int i = 0; i < DotCount; i++)
                {
                    strDot += ".";
                }
                return temp + strDot;
            }
        }
        #endregion


        #region 过滤不安全字符



        /// <summary>
        /// 过滤不安全字符



        /// </summary>
        /// <param name="sStr">要过滤的字符串</param>
        /// <returns>过滤的字符串</returns>
        public static string GetSafetyStr(string sStr)
        {
            string returnStr = sStr;
            returnStr = returnStr.Replace("&", "&amp;");
            returnStr = returnStr.Replace("'", "’");
            returnStr = returnStr.Replace("\"", "&quot;");
            returnStr = returnStr.Replace(" ", "&nbsp;");
            returnStr = returnStr.Replace("<", "&lt;");
            returnStr = returnStr.Replace(">", "&gt;");
            returnStr = returnStr.Replace("\n", "<br>"); 

            return returnStr;//Globals.GetOutString(returnStr);
        }
        #endregion

        #region 去除HTML标记
        public static string ThrowHtml(string sStr)
        {
            //使用正则表达式替换
            Regex x = new Regex("<(.[^>]*)>");
            return x.Replace(sStr, "").Replace("'", "''");
        }
        #endregion

        #region MD5加密
        public static string Md5(string str, int code)
        {
            if (code == 16) //16位MD5加密（取32位加密的9~25字符） 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
            }
            else//32位加密 
            {
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            }
        }
        #endregion

        #region 要输入的文字[换行]
        public static string ReplaceBR(string sStr)
        {
            return sStr.Replace("\r", "<br>");
        }
        #endregion

        #region 给指定的字标上颜色



        public static string ReplaceColor(string word, string str, string color, bool isbold)
        {
            return word.Replace(str, (isbold ? "<b>" : "") + "<font color=" + color + ">" + str + "" + (isbold ? "</b>" : ""));
        }
        public static string ReplaceColor(string word, string str, string color)
        {
             return word.Replace(str, "<font color=" + color + ">" + str + "");
        }
        #endregion

        //#region 获取上传文件自动生成的文件名
        //public static string GetFileName(string str, string eve)
        //{
        //    try
        //    {

        //        string name = str.ToLower().Substring(str.LastIndexOf(".") + 1);
        //        if (eve.IndexOf(name) != -1)
        //        {
        //            System.Random rd = new Random();

        //            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + DateTime.Now.Millisecond.ToString() + rd.Next(1111, 9999).ToString() + "." + name;
        //            return filename;
        //        }
        //        else
        //        {
        //            JS.MsgBox("上传文件格式错误");
        //            JS.Back();
        //            System.Web.HttpContext.Current.Response.End();
        //        }
        //    }
        //    catch
        //    {
        //        JS.MsgBox("上传文件出错");
        //        JS.Back();
        //        System.Web.HttpContext.Current.Response.End();
        //        return "";
        //    }
        //    return "";
        //}
        //#endregion

		#region 防SQL注入式攻击


		public static void ModSQL()
		{
			System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
			System.Web.HttpRequest Request = System.Web.HttpContext.Current.Request;
			foreach(string i in Request.Form)
			{
				if(i=="__VIEWSTATE")continue;
				if(!modSQL(Request.Form[i].ToString()))
				{
                    //string tmpPath = System.Web.HttpContext.Current.Server.MapPath("~/log.js");
                    //FileInfo fi = new FileInfo(tmpPath);
                    //StreamWriter sw = fi.CreateText();
                    //sw.Write("IP operation：" + Request.UserHostAddress);
                    //sw.Write("Time：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //sw.Write("Page：" + Request.Url.ToString());
                    //sw.Write("Parameters：" + i + "");
                    //sw.Write("Data：" + Request.QueryString[i]);
                    //sw.Flush();
                    //sw.Close();
					Response.Write("<table width=80% align='center' cellpadding='0' cellspacing='0'>");
					Response.Write("<tr><td><BR><BR><BR><BR>hackers : Please do not try to inject attack site, the site has implemented safety control, lawless elements will crack down！</td></tr>");
					Response.Write("<tr><td>Keep your system has been operational records law：<br></td></tr>");
					Response.Write("<tr><td><br>IP operation："+Request.UserHostAddress+"<br></td></tr>");
					Response.Write("<tr><td>Time："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"<br></td></tr>");
					Response.Write("<tr><td>Page："+Request.Url.ToString()+"<br></td></tr>");
					Response.Write("<tr><td>Submit Type：POST<br></td></tr>");
					Response.Write("<tr><td>Parameters："+i+"<br></td></tr>");
					Response.Write("<tr><td>Data："+Request.Form[i]);
					Response.Write("</td></tr></table>");
					Response.End();
				}
			}
			foreach(string i in Request.QueryString)
			{
				if(!modSQL(Request.QueryString[i].ToString()))
				{
					Response.Write("<table width=80% align='center' cellpadding='0' cellspacing='0'>");
					Response.Write("<tr><td><BR><BR><BR><BR>hackers : Please do not try to inject attack site, the site has implemented safety control, lawless elements will crack down！</td></tr>");
					Response.Write("<tr><td>Keep your system has been operational records law：<br></td></tr>");
					Response.Write("<tr><td><br>IP operation："+Request.UserHostAddress+"<br></td></tr>");
					Response.Write("<tr><td>Time："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"<br></td></tr>");
					Response.Write("<tr><td>Page："+Request.Url.ToString()+"<br></td></tr>");
					Response.Write("<tr><td>Sumbit Type：GET<br></td></tr>");
					Response.Write("<tr><td>Parameters："+i+"<br></td></tr>");
					Response.Write("<tr><td>Data："+Request.QueryString[i]);
					Response.Write("</td></tr></table>");                   
					Response.End();
				}
			}
		
		
		}

		private static bool modSQL(string qs)
		{
            
            //Sql注入时,可能出现的sql关键字,可根据自己的实际情况进行初始化,每个关键字由'|'分隔开来
            //Sql注入时,可能出现的特殊符号,,可根据自己的实际情况进行初始化,每个符号由'|'分隔开来
            //private const string StrRegex = @"-|;|,|/|(|)|[|]|}|{|%|@|*|!|'";
            string sql = @"select|insert|delete|from|drop table|update|truncate|exec master|netlocalgroup administrators|net user|and";
            sql += @"=|!|'|;|script";
            //string sql = "exec 防declare 防insert 防select 防execute 防where 防like 防drop 防create 防rename 防delete 防update 防exists 防; 防' 防\" 防-- 防== 防< 防>";
			//string[] sql2 = sql.Split('防');
            string[] sql2 = sql.Split('|');
			bool t = true;
			for(int i=0;i<sql2.Length;i++)
			{
                if (qs.ToLower().IndexOf(sql2[i]) != -1 || qs.ToLower().IndexOf(sql2[i].Replace(" ", "")) != -1 || qs.ToLower().IndexOf("script".ToLower()) != -1)
				{
					t = false;
				}
			}
			return t;
		}
		#endregion

		#region 获取正确的时间格式


		public static string GetDate(DateTime dt)
		{
			return dt.Year.ToString()+"/"+dt.Month.ToString()+"/"+dt.Day.ToString()+" "+dt.Hour.ToString()+":"+dt.Minute.ToString()+":"+dt.Second.ToString();
		}
		#endregion

        #region 从XML文件中获取数据



        /// <summary>
        /// 从XML文件中获取数据



        /// </summary>
        /// <param name="id">标识值</param>
        /// <param name="path">文件路径</param>
        /// <param name="node">节点名称</param>
        /// <param name="pname">标识名称</param>
        /// <returns></returns>
        /// 
        /// p.s:
        /// <Path id="Config">~/Config/WuhanCN.config</Path>
        /// <Path id="Errors">~/Config/Errors.xml</Path>
        /// ReadXML("Config","xml/xs.xml","Path","id");
        public static string ReadXML(string id, string path, string node, string pname)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(System.Web.HttpContext.Current.Server.MapPath(path));
            XmlElement xe = xd.DocumentElement;
            XmlNodeList xnList = xe.GetElementsByTagName(node);
            foreach (XmlNode xn in xnList)
            {
                if (xn.Attributes[pname].Value == id)
                {
                    return xn.InnerText;
                }
            }
            return null;
        }
        #endregion

        #region 判断整数
        public static bool IsInt(string num)
        {
            Regex reg = new Regex(@"^\d+$");
            return reg.IsMatch(num);
        }
        #endregion

        #region 查出中文字符串对应的拼音缩写，如“1中国c”返回"1ZGc",如果是非中文，则返回本身

        public static string GetCNLetter(string chineseStr)
        {
            byte[] _cBs = System.Text.Encoding.Default.GetBytes(chineseStr);

            if(_cBs.Length<2)
                return chineseStr;

            byte ucHigh, ucLow;
            int  nCode;

            string strFirstLetter = string.Empty;
            for (int i = 0; i < _cBs.Length; i++)
            {
                //1个中文字符的的2个字节都必须大于的128，非中文字符返回本身
               if (_cBs[i] < 0x80)
                {
                    strFirstLetter += Encoding.Default.GetString(_cBs, i, 1);
                    continue;
                }

                ucHigh = (byte)_cBs[i];//中文字符的第1个字节
                ucLow = (byte)_cBs[i + 1];//中文字符的第2个字节
                //1个中文字符的2个字节都必须大于161，否则是无效中文
                if ( ucHigh < 0xa1 || ucLow < 0xa1)
                    continue;
                else
                // Treat code by section-position as an int type parameter,
                //获得一个中文字符的Asc码值 so make following change to nCode.
                    nCode = (ucHigh - 0xa0) * 100 + ucLow - 0xa0;

                string str = FirstLetter(nCode);
                strFirstLetter += str != string.Empty ? str : Encoding.Default.GetString(_cBs, i, 2);//如果没有查询出该中文字符的字母则返回该中文
                i++;
            }
            return strFirstLetter;
        }

        /// <summary>
        /// Get the first letter of pinyin according to specified Chinese character code
        /// </summary>
        /// <param name="nCode">the code of the chinese character</param>
        /// <returns>receive the string of the first letter</returns>
        public static string FirstLetter(int nCode)
        {
            string strLetter = string.Empty;

            if(nCode >= 1601 && nCode < 1637) strLetter = "A";
           if(nCode >= 1637 && nCode < 1833) strLetter = "B";
            if(nCode >= 1833 && nCode < 2078) strLetter = "C";
            if(nCode >= 2078 && nCode < 2274) strLetter = "D";
            if(nCode >= 2274 && nCode < 2302) strLetter = "E";
            if(nCode >= 2302 && nCode < 2433) strLetter = "F";
            if(nCode >= 2433 && nCode < 2594) strLetter = "G";
            if(nCode >= 2594 && nCode < 2787) strLetter = "H";
            if(nCode >= 2787 && nCode < 3106) strLetter = "J";
            if(nCode >= 3106 && nCode < 3212) strLetter = "K";
            if(nCode >= 3212 && nCode < 3472) strLetter = "L";
            if(nCode >= 3472 && nCode < 3635) strLetter = "M";
            if(nCode >= 3635 && nCode < 3722) strLetter = "N";
            if(nCode >= 3722 && nCode < 3730) strLetter = "O";
            if(nCode >= 3730 && nCode < 3858) strLetter = "P";
            if(nCode >= 3858 && nCode < 4027) strLetter = "Q";
            if(nCode >= 4027 && nCode < 4086) strLetter = "R";
            if(nCode >= 4086 && nCode < 4390) strLetter = "S";
            if(nCode >= 4390 && nCode < 4558) strLetter = "T";
           if(nCode >= 4558 && nCode < 4684) strLetter = "W";
            if(nCode >= 4684 && nCode < 4925) strLetter = "X";
            if(nCode >= 4925 && nCode < 5249) strLetter = "Y";
           if(nCode >= 5249 && nCode < 5590) strLetter = "Z";

            //if (strLetter == string.Empty)
           //    System.Windows.Forms.MessageBox.Show(String.Format("信息：\n{0}为非常用字符编码,不能为您解析相应匹配首字母！",nCode));
            return strLetter;
        }
        #endregion
        
        #region 获取用户登录IP
        /// <summary>
        /// 获取用户登录IP
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string userIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (userIP == null || userIP == "")
            {
                userIP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return userIP;
        }
        #endregion

        #region 获取Html
        /// <summary>
        /// 传入URL返回网页的html代码
        /// </summary>
        /// <param name="Url">URL</param>
        /// <returns></returns>
        public static string GetUrltoHtml(string Url)
        {
            string errorMsg = "";
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
                // Get the response instance.
                System.Net.WebResponse wResp = wReq.GetResponse();
                // Read an HTTP-specific property
                //if (wResp.GetType() ==HttpWebResponse)
                //{
                //DateTime updated   =((System.Net.HttpWebResponse)wResp).LastModified;
                //}
                // Get the response stream.
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                //System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("gb2312"));
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.UTF8);
                return reader.ReadToEnd();
            }
            catch (System.Exception ex)
            {
                errorMsg = ex.Message;
            }
            return "";
        }
#endregion    

       
        /// <summary>
        /// 去掉字符串前后逗号
        /// </summary>
        /// <param name="strDh">要去掉的字符</param>
        /// <param name="strFh">符号</param>
        /// <returns></returns>
        public static string FormatDh(string strDh, string strFh)
        {
            if (strDh.Length > 1)
            {
                //strDh = strDh.Replace(",,", ",");
                if (strDh.Substring(0, 1) == strFh)
                    strDh = strDh.Substring(1);
                if (strDh.Substring(strDh.Length - 1) == strFh)
                    strDh = strDh.Substring(0, strDh.Length - 1);
            }
            return strDh;
        }

        /// <summary>
        /// 转换成数值型
        /// </summary>
        /// <param name="strData">要转换的字符型数值</param>
        /// <returns></returns>
        public static int FormatData(string strData)
        {
            int iData = 0;
            if (strData.Trim() == "")
                iData = 0;
            try
            {
                iData = Convert.ToInt32(strData);
            }
            catch
            {
                iData = 0;
            }
            return iData;
        }


        /// <summary>
        /// 转换成Double
        /// </summary>
        /// <param name="strData">要转换的字符型参数</param>
        /// <returns></returns>
        public static decimal FormatDecimal(string strData)
        {
            decimal iDecimal = 0;
            if (strData.Trim() == "")
                iDecimal = 0;
            try
            {
                iDecimal = Convert.ToDecimal(strData);
            }
            catch
            {
                iDecimal = 0;
            }
            return iDecimal;
        }


        /// <summary>
        /// 格式化日期及时间，
        /// </summary>
        /// <param name="strDate">转入的字符串</param>
        /// <param name="iType">为类型，1表示为2010年4月14日;2为2010年4月14日 9时8分25秒</param>
        /// <returns></returns>
        public static  string FormatDate(string strDate,int iType)
        {
            if (strDate.Trim() == "")
                return "";

            string str = "";
            try
            {
                DateTime  dt = Convert.ToDateTime(strDate);

                if (iType==1)
                {
                    str += dt.Year.ToString() + "年";
                    str += dt.Month.ToString() + "月";
                    str += dt.Day.ToString() + "日";
                }
                else if (iType == 2)
                {
                    str += dt.Year.ToString() + "年";
                    str += dt.Month.ToString() + "月";
                    str += dt.Day.ToString() + "日 ";
                    str += dt.Hour.ToString() + "时";
                    str += dt.Minute.ToString() + "分";
                    str += dt.Second.ToString() + "秒";
                }
            }
            catch
            {
                str = "";
            }
            return str;
        }


        /// <summary>
        /// 格式化金额
        /// </summary>
        /// <param name="strJy">转入要转换的字符</param>
        /// <param name="iType">为类型，1表示为425.40元，2表示￥425.40元</param>
        /// <returns></returns>
        public static string FormatJy(string strJy,int iType)
        {
            if (strJy.Trim() == "")
                return "";

            string str = "";
            try
            {
                double dNum = Convert.ToDouble(strJy);
                if(iType==1)
                {
                    str = dNum.ToString("N");
                }
                else if (iType == 2)
                {
                    str = dNum.ToString("C");
                }
            }
            catch
            {
            }
            return str;
        }

        /// <summary>
        /// 转换成性别
        /// </summary>
        /// <param name="strSex">要转换的字符，如1表示男，2表示女，0表示性别不限</param>
        /// <returns></returns>
        public static string FormatSex(string strSex)
        {
            if (strSex.Trim() == "")
                return "";
            if (strSex.Trim() == "0")
                return "性别不限";
            else if (strSex.Trim() == "1")
                return "男";
            else if (strSex.Trim() == "2")
                return "女";
            else
                return "";
        }

       
        ///// <summary>
        ///// 格式化投入状态
        ///// </summary>
        ///// <param name="strType">1预购买，2确认，3正在投放，4投放结束</param>
        ///// <returns></returns>
        //public static string FormatRelease(string  strType)
        //{
        //    int iType = 0;
        //    try
        //    {
        //        iType = Convert.ToInt32(strType);
        //    }
        //    catch
        //    {
        //        return "";
        //    }

        //    string str = "";
        //    if (iType==1)
        //    {
        //        str="预购买";
        //    }
        //    else if(iType==2)
        //    {
        //        str="确认";
        //    }
        //    else if(iType==3)
        //    {
        //        str="正在投放";
        //    }
        //    else if(iType==4)
        //    {
        //        str="投放结束";
        //    }
        //    else 
        //    {
        //        str="";
        //    }
        //    return str;
        //}


        /// <summary>
        /// 两个日期相减，第二个减第一个，得出天数
        /// </summary>
        /// <param name="strDateS">开始日期</param>
        /// <param name="strDateE">结束日期</param>
        /// <returns></returns>
        public static string FormatDateSubtract(string strDateS,string strDateE)
        {
            if (strDateS.Trim() == "" || strDateE.Trim() == "")
            {
                return "";
            }

            TimeSpan ts;
            int days=0;
            try
            {
                DateTime dtS = Convert.ToDateTime(strDateS);
                DateTime dtE = Convert.ToDateTime(strDateE);

                ts=dtE-dtS;

                days = ((int)ts.Days)+1;
            }
            catch
            {
            }

            return days.ToString();
        }

        //获取checkboxlist列表中的值，以逗号分开
        public static string GetCheckBoxList(CheckBoxList cbl)
        {
            string strValue = "";
            try
            {
                for (int i = 0; i < cbl.Items.Count; i++)
                {
                    if (cbl.Items[i].Selected)
                    {
                        strValue = strValue + cbl.Items[i].Value.Trim() + ",";
                    }
                }
            }
            catch
            {
            }
            return strValue;
        }

        /// <summary>
        /// 判断checkboxlist是否为空
        /// </summary>
        /// <param name="cbl"></param>
        /// <returns>返回true表示为空，false表示为有选上的项目</returns>
        public static bool IsNullCheckBoxList(CheckBoxList cbl)
        {
            bool flg = true;
            try
            {
                for (int i = 0; i < cbl.Items.Count; i++)
                {
                    if (cbl.Items[i].Selected) //选上
                    {
                        flg = false;
                    }
                }
            }
            catch
            {
            }
            return flg;
        }

        /// <summary>
        /// 判断RadioButtonList是否选上
        /// </summary>
        /// <param name="rbl"></param>
        /// <returns>返回true表示为空，false表示为有选上的项目</returns>
        public static bool IsNullRadioButtonList(RadioButtonList rbl)
        {
            bool flg = true;
            try
            {
                for (int i = 0; i < rbl.Items.Count; i++)
                {
                    if (rbl.Items[i].Selected)//选上
                    {
                        flg = false;
                    }
                }   
            }
            catch
            {
            }
            return flg;
        }

    }
}
