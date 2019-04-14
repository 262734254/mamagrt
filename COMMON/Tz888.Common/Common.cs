using System;
using System.Text;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
namespace Tz888.Common
{

    public class Common
    {
        #region 创建上传文件的文件名
        /// <summary>
        /// 创建上传文件的文件名
        /// 文件名规则
        /// 年月日时分秒+５位随机数［共１９位］
        /// </summary>
        /// <param name="InfoTypeID">信息的类型</param>
        /// <returns></returns>
        public static string CreateFileName()
        {
            DateTime CurrentTime = DateTime.Now;
            string TimeName = CurrentTime.ToString("yyyyMMddhhmmss");
            int seed = DateTime.Now.Second;
            Random rnd = new Random(seed);
            TimeName += rnd.Next(100000).ToString("00000");
            return TimeName;
        }
        #endregion

        #region 获取文件上传目录的服务器磁盘路径
        public static string GetUploadFileRootPath()
        {
            string ServerPath = (string)ConfigurationManager.AppSettings["FileServerPath"];
            return ServerPath;
        }
        #endregion

        #region 获取文件上传目录的相对路径
        public static string GetUploadFilePath()
        {
            string FilePath = (string)ConfigurationManager.AppSettings["UploadFilePath"];
            return FilePath;
        }
        #endregion

        #region 获取文件上传目录的相对路径
        public static string GetFileServerURL()
        {
            string FilePath = (string)ConfigurationManager.AppSettings["FileServerURL"];
            return FilePath;
        }
        #endregion

        #region 获取某信息类型的文件的存储路径
        /// <summary>
        /// 获取某信息类型的文件的存储路径
        /// </summary>
        /// <param name="FileType">文件类型如：[Image]</param>
        /// <param name="InfoType">信息类型：[Project]</param>
        /// <param name="IsFullPath">是否返回完整路径</param>
        /// <returns>返回d:\UploadFile\Image\Project\200708\</returns>
        public static string GetUploadFilePath(string FileType, string InfoType, bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["FileServerPath"];
            ServerPath = "UploadFile\\" + FileType + "\\" + InfoType;
            DateTime timeC = DateTime.Now;
            ServerPath += "\\" + timeC.ToString("yyyyMM") + "\\";
            //根据当前月创建文件夹
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion

        #region 获取某信息类型的文件的临时文件路径
        /// <summary>
        /// 获取某信息类型的文件的临时文件路径
        /// </summary>
        /// <param name="FileType">文件类型如：[Image]</param>
        /// <param name="InfoType">信息类型：[Project]</param>
        /// <param name="IsFullPath">是否是全路径</param>
        /// <returns>返回d:\UploadFile\Image\Project\TmpFile\</returns>
        public static string GetTmpUploadFilePath(string FileType, string InfoType, bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["FileServerPath"];
            ServerPath = "UploadFile\\" + FileType + "\\" + InfoType + "\\TmpFile\\";
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion

        #region 获取图片的域名
        public static string GetImageDomain()
        {
            string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
            return ImageDomain;
        }
        #endregion

        #region 获取文件的域名
        public static string GetFileDomain()
        {
            string FileDomain = (string)ConfigurationManager.AppSettings["FileDomain"];
            return FileDomain;
        }
        #endregion

        #region 获取会员的域名
        public static string GetMemberDomain()
        {
            string MemberDomain = (string)ConfigurationManager.AppSettings["MemberDomain"];
            return MemberDomain;
        }
        #endregion

        #region 获取网站前台的域名
        public static string GetWWWDomain()
        {
            string wwwDomain = (string)ConfigurationManager.AppSettings["wwwDomain"];
            return wwwDomain;
        }
        #endregion

        #region 获取信息的域名
        public static string GetInfoDomain()
        {
            string InfoDomain = (string)ConfigurationManager.AppSettings["InfoDomain"];
            return InfoDomain;
        }
        #endregion

        #region 获取搜索的域名
        public static string GetSearchDomain()
        {
            string SearchDomain = (string)ConfigurationManager.AppSettings["SearchDomain"];
            return SearchDomain;
        }
        #endregion

        #region 获取图片默认文字水印的内容
        public static string GetWaterFont()
        {
            string Font = (string)ConfigurationManager.AppSettings["ImageWaterFont"];
            return Font;
        }
        #endregion

        #region 获取默认水印图片的地址
        public static string GetWaterImage()
        {
            string Path = (string)ConfigurationManager.AppSettings["ImageWaterImage"];
            return Path;
        }
        #endregion

        #region 注册日历
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Field">文本框</param>
        /// <returns>返回一个javascript的代码</returns>

        public static string InvokePopupCal(System.Web.UI.WebControls.TextBox Field)
        {
            //' Define character array to trim from language strings
            char[] TrimChars = new char[] { ',', ' ' };

            //' Get culture array of month names and convert to string for
            //' passing to the popup calendar
            string MonthNameString = "";
            // string Month ;
            foreach (string Month in DateTimeFormatInfo.CurrentInfo.MonthNames)
            {
                MonthNameString += Month + ",";
            }

            MonthNameString = MonthNameString.TrimEnd(TrimChars);

            // ' Get culture array of day names and convert to string for
            // ' passing to the popup calendar
            string DayNameString = "";

            foreach (string Day in DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames)
            {
                DayNameString += Day + ",";

            }

            DayNameString = DayNameString.TrimEnd(TrimChars);

            //' Get the short date pattern for the culture
            string FormatString = DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString();
            if (!Field.Page.IsClientScriptBlockRegistered("PopupCalendar"))
            {
                Field.Page.RegisterClientScriptBlock("PopupCalendar", @"<script src=""..\js\PopupCalendar.js""></script>");
            }


            // return "javascript:popupCal('Cal','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "今天" + "','" + "关闭" + "','" + "日历" + "'," + DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek + ");";
            return "javascript:popupCal('\\\\javascript\\\\','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "今天" + "','" + "关闭" + "','" + "日历" + "');";
        }
        #endregion

        #region 行业
        public static string GetIndustry(string IndustryBID)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (IndustryBID != "")
            {
                string[] bid = IndustryBID.Split(',');
                string BID = bid[0].Trim();

                DataTable dt = DAL.GetList("SetIndustrybTab", "IndustryBName", "IndustryBid", 1, 1, 0, 1, "IndustryBID='" + BID + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["IndustryBName"].ToString();
                }
                else
                {
                    return "不限";
                }
            }
            else
            {
                return "不限";
            }
        }
        #endregion

        #region 合作方式
        public static string CooprationType(string TypeID)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (TypeID != "")
            {
                string[] typeid = TypeID.Split(',');
                string TYPEID = typeid[0].Trim();
                DataTable dt = DAL.GetList("SetCooperationDemandTypeTab", "CooperationDemandName", "CooperationDemandTypeID", 1, 1, 0, 1, "CooperationDemandTypeID=" + Convert.ToInt32(TYPEID));
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CooperationDemandName"].ToString();
                }
                else
                {
                    return "不限";
                }
            }
            else
            {
                return "不限";
            }
        }
        #endregion

        #region 区域

        #region 取国家
        /// <summary>
        /// 根据ID取Name
        /// </summary>
        /// <param name="CountryCode"></param>
        /// <returns></returns>
        public static string GetCountryName(string CountryCode)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (CountryCode != "")
            {
                string[] code = CountryCode.Split(',');
                string CODE = code[0].Trim();
                DataTable dt = DAL.GetList("SetCountryTab", "CountryName", "id", 1, 1, 0, 1, "CountryCode='" + CODE + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CountryName"].ToString().Trim();
                }
                else
                {
                    return "不限";
                }
            }
            else
            {
                return "不限";
            }
        }
        /// <summary>
        /// 根据Name取ID
        /// </summary>
        /// <param name="CountryCode"></param>
        /// <returns></returns>
        public static string GetCountryCode(string CountryName)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (CountryName != "")
            {
                DataTable dt = DAL.GetList("SetCountryTab", "CountryCode", "id", 1, 1, 0, 1, "CountryName='" + CountryName + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CountryCode"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 取省份
        /// <summary>
        /// 根据省份ID取Name
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public static string GetProviveName(string ProvinceID)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (ProvinceID != "")
            {
                string[] pid = ProvinceID.Split(',');
                string PID = pid[0].Trim();

                DataTable dt = DAL.GetList("SetProvinceTab", "ProvinceName", "ProvinceID", 1, 1, 0, 1, "ProvinceID='" + PID + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ProvinceName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 根据省份Name取ID
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <returns></returns>
        public static string GetProviveID(string ProvinceName)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (ProvinceName != "")
            {
                DataTable dt = DAL.GetList("SetProvinceTab", "ProvinceID", "ProvinceID", 1, 1, 0, 1, "ProvinceName='" + ProvinceName + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ProvinceID"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 市
        /// <summary>
        /// 根据ID取城市名称
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public static string GetCityName(string CityID)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (CityID != "")
            {
                string[] cityid = CityID.Split(',');
                string CID = cityid[0].Trim();

                DataTable dt = DAL.GetList("SetCityTab", "CityName", "CityID", 1, 1, 0, 1, "CityID='" + CID + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CityName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 根据城市Name取ID
        /// </summary>
        /// <param name="CityName"></param>
        /// <returns></returns>
        public static string GetCityID(string CityName)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (CityName != "")
            {
                DataTable dt = DAL.GetList("SetCityTab", "CityID", "CityID", 1, 1, 0, 1, "CityName='" + CityName + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CityID"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 镇
        /// <summary>
        /// 根据镇ID取Name
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public static string GetCountyName(string CountyID)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (CountyID != "")
            {
                string[] countyid = CountyID.Split(',');
                string CTID = countyid[0].Trim();

                DataTable dt = DAL.GetList("SetCountyTab", "CountyName", "CountyID", 1, 1, 0, 1, "CountyID='" + CTID + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CountyName"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 根据镇Name取ID
        /// </summary>
        /// <param name="CountyName"></param>
        /// <returns></returns>
        public static string GetCountyID(string CountyName)
        {
            Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
            if (CountyName != "")
            {
                DataTable dt = DAL.GetList("SetCountyTab", "CountyID", "CountyID", 1, 1, 0, 1, "CountyName='" + CountyName + "'");
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CountyID"].ToString().Trim();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        #endregion

        #endregion

        #region 会员图标
        public static string GetIco(string MemberGradeID)
        {
            if (MemberGradeID.Trim() == "1002")
            {
                return "<img src='http://www.topfo.com/Web13/images/home/tfzs.gif' border='0' alt='拓富通会员'></img>";
            }
            else
            {
                return "";
            }
        }
        #endregion
       #region  提示信息函数
		public static void ShowMessage( 
			System.Web.UI.Page page,
			string Msg)
		{
			string script="<script language='javascript'>alert('" + Msg + "');</script>";
			page.RegisterClientScriptBlock("SetList",script);
		}

		public static void ShowMessage( 
			System.Web.HttpResponse response,
			string Msg)
		{
            
			response.Write("<script language='javascript'> \n window.alert('" + Msg + "');\n</script>\n");
		}
		public static void ShowMessage( 
			System.Web.UI.Page page,
			string Msg,
			string Url)
		{
			page.Response.Write("<script language='javascript'> \n window.alert('" + Msg + "');location.href='" + Url + "';</script>");
		}

		public static bool SessionLose(
			System.Web.UI.Page page,
			string Url)
		{
			//SESSION丢失
			string returnUrl = Url + "?url=" + page.Request.Url.ToString();

			if(page.Session.Count==0 ||
				(page.Session["valationNo"] !=null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('操作已经超时，请重新登陆系统，谢谢！');location.href='" + returnUrl + "';</script>");
				return false ;
			}
			else
			{
				return true;
			}
		}

		public static bool ExceptSessionLose(
			System.Web.UI.Page page,
			string Url)
		{
			//SESSION丢失
			string returnUrl = Url + "?url=" + page.Request.Url.ToString();

			if(page.Session.Count==0 ||
				(page.Session["valationNo2"] ==null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('操作已经超时，请重新登陆系统，谢谢！');location.href='" + returnUrl + "';</script>");
				return false ;
			}
			else
			{
				return true;
			}
		}

		public static bool CheckSessionLose(
			System.Web.UI.Page page)
		{
			//SESSION丢失
			if(page.Session.Count==0 ||
				(page.Session["valationNo"] !=null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('你还没有登录或操作超时！请重新登陆！');</script>");
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool CheckSessionLose(
			System.Web.UI.Page page,
			string Url)
		{
			//SESSION丢失
			string returnUrl = Url + "?url=" + page.Request.Url.ToString();
			if(page.Session.Count==0 ||
				(page.Session["valationNo"] !=null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('你还没有登录或操作超时！请重新登陆！');location.href='" + returnUrl + "';</script>");
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

        #region 支付方式
        public static string GetPayType(string payCode)
        {
            if (payCode.Trim() == "account")
                return "帐户余额";
            if (payCode.Trim() == "alipay")
                return "支付宝";
            if (payCode.Trim() == "bank")
                return "银行汇款";
            if (payCode.Trim() == "Card")
                return "充值卡";
            if (payCode.Trim() == "ebilling")
                return "ebilling电话";
            if (payCode.Trim() == "pnr")
                return "天天付";
            if (payCode.Trim() == "PostOffice")
                return "邮局汇款";
            if (payCode.Trim() == "szx")
                return "神州行";
            if (payCode.Trim() == "yeepay")
                return "yeepay电话";
            if (payCode.Trim() == "Quick")
                return "银联";
            return "未选择";

        }
        #endregion

        #region 按指定长度截断字符串
        public static string ShortenString(int intLength, string strString)
        {
            if (intLength == 0)
            {
                return strString;
            }
            strString = strString.Replace("&nbsp;", "");
            if (strString.Length > 0 && strString.Length > intLength)
            {
                if (intLength >= 25)
                {
                    strString = strString.Substring(0, intLength);
                }
                else
                {
                    string str = "";
                    if (strString.Length > 30)
                    {
                        str = strString.Substring(0, 30);
                    }
                    else
                    {
                        str = strString;
                    }
                    System.Text.Encoding encoder = System.Text.Encoding.Default;
                    byte[] bytes = encoder.GetBytes(str);
                    if (bytes.Length > intLength * 2)
                    {
                        str = encoder.GetString(bytes, 0, intLength * 2);
                    }
                    strString = str.TrimEnd();
                }


            }
            return strString;

        }
        #endregion

        #region 获取口碑网的信息
        public static string GetKoubei_partner_id()
        {
            string partner_id = (string)ConfigurationManager.AppSettings["partner_id"];
            return partner_id;
        }
        public static string GetKoubei_sign_key()
        {
            string sign_key = (string)ConfigurationManager.AppSettings["sign_key"];
            return sign_key;
        }
        public static string GetKoubei_category_id()
        {
            string category_id = (string)ConfigurationManager.AppSettings["category_id"];
            return category_id;
        }
        public static string GetKoubei_debug()
        {
            string debug = (string)ConfigurationManager.AppSettings["debug"];
            return debug;
        }
        public static string GetKoubei_contact_person()
        {
            string contact_person = (string)ConfigurationManager.AppSettings["contact_person"];
            return contact_person;
        }
        public static string GetKoubei_contact_phone1()
        {
            string contact_phone1 = (string)ConfigurationManager.AppSettings["contact_phone1"];
            return contact_phone1;
        }
        #endregion
        #region 绑定列表控件

        /// <summary>
        /// 绑定列表控件
        /// </summary>
        /// <param name="Ct">列表控件名称</param>
        /// <param name="datasource">数据源</param>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        public static void ToBind(Control Ct, object datasource, string text, string value)
        {
            if (Ct is DropDownList)
            {
                DropDownList Control = Ct as DropDownList;
                Control.DataSource = datasource;
                Control.DataTextField = text;
                Control.DataValueField = value;
                Control.DataBind();
            }
        }

#endregion


        #region 购买减去用户余额
        /// <summary>
        /// 购买减去用户余额
        /// </summary>
        /// <param name="WorthPoint">用户余额</param>
        /// <param name="LoginName">登录名</param>
        /// <returns></returns>
        public int CreateCardUser(string WorthPoint, string LoginName)
        {

            string sql = "Update CreateCardTab set WorthPoint=@WorthPoint where LoginName=@LoginName ";
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter ("@WorthPoint",WorthPoint)
                    ,new SqlParameter ("@LoginName",LoginName),                
            };
            int result = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        } 
        #endregion
    }
}
