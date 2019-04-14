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
        #region �����ϴ��ļ����ļ���
        /// <summary>
        /// �����ϴ��ļ����ļ���
        /// �ļ�������
        /// ������ʱ����+��λ������۹�����λ��
        /// </summary>
        /// <param name="InfoTypeID">��Ϣ������</param>
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

        #region ��ȡ�ļ��ϴ�Ŀ¼�ķ���������·��
        public static string GetUploadFileRootPath()
        {
            string ServerPath = (string)ConfigurationManager.AppSettings["FileServerPath"];
            return ServerPath;
        }
        #endregion

        #region ��ȡ�ļ��ϴ�Ŀ¼�����·��
        public static string GetUploadFilePath()
        {
            string FilePath = (string)ConfigurationManager.AppSettings["UploadFilePath"];
            return FilePath;
        }
        #endregion

        #region ��ȡ�ļ��ϴ�Ŀ¼�����·��
        public static string GetFileServerURL()
        {
            string FilePath = (string)ConfigurationManager.AppSettings["FileServerURL"];
            return FilePath;
        }
        #endregion

        #region ��ȡĳ��Ϣ���͵��ļ��Ĵ洢·��
        /// <summary>
        /// ��ȡĳ��Ϣ���͵��ļ��Ĵ洢·��
        /// </summary>
        /// <param name="FileType">�ļ������磺[Image]</param>
        /// <param name="InfoType">��Ϣ���ͣ�[Project]</param>
        /// <param name="IsFullPath">�Ƿ񷵻�����·��</param>
        /// <returns>����d:\UploadFile\Image\Project\200708\</returns>
        public static string GetUploadFilePath(string FileType, string InfoType, bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["FileServerPath"];
            ServerPath = "UploadFile\\" + FileType + "\\" + InfoType;
            DateTime timeC = DateTime.Now;
            ServerPath += "\\" + timeC.ToString("yyyyMM") + "\\";
            //���ݵ�ǰ�´����ļ���
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion

        #region ��ȡĳ��Ϣ���͵��ļ�����ʱ�ļ�·��
        /// <summary>
        /// ��ȡĳ��Ϣ���͵��ļ�����ʱ�ļ�·��
        /// </summary>
        /// <param name="FileType">�ļ������磺[Image]</param>
        /// <param name="InfoType">��Ϣ���ͣ�[Project]</param>
        /// <param name="IsFullPath">�Ƿ���ȫ·��</param>
        /// <returns>����d:\UploadFile\Image\Project\TmpFile\</returns>
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

        #region ��ȡͼƬ������
        public static string GetImageDomain()
        {
            string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
            return ImageDomain;
        }
        #endregion

        #region ��ȡ�ļ�������
        public static string GetFileDomain()
        {
            string FileDomain = (string)ConfigurationManager.AppSettings["FileDomain"];
            return FileDomain;
        }
        #endregion

        #region ��ȡ��Ա������
        public static string GetMemberDomain()
        {
            string MemberDomain = (string)ConfigurationManager.AppSettings["MemberDomain"];
            return MemberDomain;
        }
        #endregion

        #region ��ȡ��վǰ̨������
        public static string GetWWWDomain()
        {
            string wwwDomain = (string)ConfigurationManager.AppSettings["wwwDomain"];
            return wwwDomain;
        }
        #endregion

        #region ��ȡ��Ϣ������
        public static string GetInfoDomain()
        {
            string InfoDomain = (string)ConfigurationManager.AppSettings["InfoDomain"];
            return InfoDomain;
        }
        #endregion

        #region ��ȡ����������
        public static string GetSearchDomain()
        {
            string SearchDomain = (string)ConfigurationManager.AppSettings["SearchDomain"];
            return SearchDomain;
        }
        #endregion

        #region ��ȡͼƬĬ������ˮӡ������
        public static string GetWaterFont()
        {
            string Font = (string)ConfigurationManager.AppSettings["ImageWaterFont"];
            return Font;
        }
        #endregion

        #region ��ȡĬ��ˮӡͼƬ�ĵ�ַ
        public static string GetWaterImage()
        {
            string Path = (string)ConfigurationManager.AppSettings["ImageWaterImage"];
            return Path;
        }
        #endregion

        #region ע������
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Field">�ı���</param>
        /// <returns>����һ��javascript�Ĵ���</returns>

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


            // return "javascript:popupCal('Cal','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "����" + "','" + "�ر�" + "','" + "����" + "'," + DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek + ");";
            return "javascript:popupCal('\\\\javascript\\\\','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "����" + "','" + "�ر�" + "','" + "����" + "');";
        }
        #endregion

        #region ��ҵ
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
                    return "����";
                }
            }
            else
            {
                return "����";
            }
        }
        #endregion

        #region ������ʽ
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
                    return "����";
                }
            }
            else
            {
                return "����";
            }
        }
        #endregion

        #region ����

        #region ȡ����
        /// <summary>
        /// ����IDȡName
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
                    return "����";
                }
            }
            else
            {
                return "����";
            }
        }
        /// <summary>
        /// ����NameȡID
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

        #region ȡʡ��
        /// <summary>
        /// ����ʡ��IDȡName
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
        /// ����ʡ��NameȡID
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

        #region ��
        /// <summary>
        /// ����IDȡ��������
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
        /// ���ݳ���NameȡID
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

        #region ��
        /// <summary>
        /// ������IDȡName
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
        /// ������NameȡID
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

        #region ��Աͼ��
        public static string GetIco(string MemberGradeID)
        {
            if (MemberGradeID.Trim() == "1002")
            {
                return "<img src='http://www.topfo.com/Web13/images/home/tfzs.gif' border='0' alt='�ظ�ͨ��Ա'></img>";
            }
            else
            {
                return "";
            }
        }
        #endregion
       #region  ��ʾ��Ϣ����
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
			//SESSION��ʧ
			string returnUrl = Url + "?url=" + page.Request.Url.ToString();

			if(page.Session.Count==0 ||
				(page.Session["valationNo"] !=null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('�����Ѿ���ʱ�������µ�½ϵͳ��лл��');location.href='" + returnUrl + "';</script>");
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
			//SESSION��ʧ
			string returnUrl = Url + "?url=" + page.Request.Url.ToString();

			if(page.Session.Count==0 ||
				(page.Session["valationNo2"] ==null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('�����Ѿ���ʱ�������µ�½ϵͳ��лл��');location.href='" + returnUrl + "';</script>");
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
			//SESSION��ʧ
			if(page.Session.Count==0 ||
				(page.Session["valationNo"] !=null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('�㻹û�е�¼�������ʱ�������µ�½��');</script>");
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
			//SESSION��ʧ
			string returnUrl = Url + "?url=" + page.Request.Url.ToString();
			if(page.Session.Count==0 ||
				(page.Session["valationNo"] !=null &&
				page.Session.Count==1))
			{
				page.Response.Write("<script>alert('�㻹û�е�¼�������ʱ�������µ�½��');location.href='" + returnUrl + "';</script>");
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

        #region ֧����ʽ
        public static string GetPayType(string payCode)
        {
            if (payCode.Trim() == "account")
                return "�ʻ����";
            if (payCode.Trim() == "alipay")
                return "֧����";
            if (payCode.Trim() == "bank")
                return "���л��";
            if (payCode.Trim() == "Card")
                return "��ֵ��";
            if (payCode.Trim() == "ebilling")
                return "ebilling�绰";
            if (payCode.Trim() == "pnr")
                return "���츶";
            if (payCode.Trim() == "PostOffice")
                return "�ʾֻ��";
            if (payCode.Trim() == "szx")
                return "������";
            if (payCode.Trim() == "yeepay")
                return "yeepay�绰";
            if (payCode.Trim() == "Quick")
                return "����";
            return "δѡ��";

        }
        #endregion

        #region ��ָ�����Ƚض��ַ���
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

        #region ��ȡ�ڱ�������Ϣ
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
        #region ���б�ؼ�

        /// <summary>
        /// ���б�ؼ�
        /// </summary>
        /// <param name="Ct">�б�ؼ�����</param>
        /// <param name="datasource">����Դ</param>
        /// <param name="text">�ı�</param>
        /// <param name="value">ֵ</param>
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


        #region �����ȥ�û����
        /// <summary>
        /// �����ȥ�û����
        /// </summary>
        /// <param name="WorthPoint">�û����</param>
        /// <param name="LoginName">��¼��</param>
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
