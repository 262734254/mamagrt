using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Text;
using Tz888.BLL.Login;
using System.Web.Caching;
using System.Collections.Generic;
using System.Xml;


/// <summary>
/// TopfoInfoDetail 的摘要说明
/// </summary>
[WebService(Namespace = "http://www.topfo.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
public class TopfoInfoDetail : System.Web.Services.WebService
{

    public TopfoInfoDetail()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }


    /// <summary>
    /// 页面信息初始化
    /// </summary>
    /// <param name="InfoID"></param>
    /// <param name="LoginName"></param>
    /// <returns></returns>
    [WebMethod(Description = "调用客户端Session", EnableSession = true)]
    public string GetAllOtherInfoByInfoIDForStaticPage(string InfoID, string LoginName)
    {

        #region 互告跟踪记录

        ///------------------------------
        ///--design by AdSystem_20090620
        ///------------------------------
        string sitekey = "";
        AdSystem.Logic loc = new AdSystem.Logic();
        if (HttpContext.Current.Request.Cookies["S"] != null && HttpContext.Current.Request.Cookies["S"].Value.Trim() != "")
        {
            sitekey = HttpContext.Current.Request.Cookies["S"].Value.Trim();
            HttpContext.Current.Request.Cookies["S"].Expires = DateTime.Now.AddDays(-1);
            bool flag = loc.setCookie(sitekey, InfoID);
            if (flag)
            {
                loc.Hits_Add();
            }
        }
        //跟踪浏览的用户
        if (LoginName.Trim() != "")
        {
            loc.View_Add(InfoID, LoginName);
        }

        #endregion


        StringBuilder sOut = new StringBuilder();


        #region 信息参数说与基本信息获取

        long lgCurrentPage = 1;
        long lgPageSize = 0;
        long lgPageCount = 0;
        decimal MainPointCount = 0;         //资源报价  
        int FixPriceID = 0;                 //资源是否收费
        string CurrentUserName = "";        //当前登陆的查看信息的用户
        //string MemberURL = "";            //用户会员资料展示页面
        string PublishMan = "";             //发布信息的用户
        string NickName = "";               //发布信息的用户昵称
        string InfoTypeName = "";           //信息类别
        string InfoOriginRoleName = "0";    //
        string ManageTypeID = "";           //发布信息的用户类别
        string payDomain = System.Configuration.ConfigurationManager.AppSettings["payDomain"];
        string buyUrl = payDomain + "/order_item.aspx?InfoID=" + InfoID;    //资源购买的路径

        CurrentUserName = LoginName;
        BatchCreateXml bcx = new BatchCreateXml();
        Tz888.BLL.Common.CommonFunction cf = new Tz888.BLL.Common.CommonFunction();
        DataTable dt = cf.GetDTFromTableOrView("MainInfoViw", "infoid", "*", " infoid=" + InfoID, "InfoID", ref lgCurrentPage, lgPageSize, ref lgPageCount);
        if (dt != null && dt.Rows.Count > 0)
        {
            FixPriceID = Convert.ToInt32(dt.Rows[0]["FixPriceID"].ToString().Trim());
            MainPointCount = Convert.ToDecimal(dt.Rows[0]["MainPointCount"].ToString().Trim());
            InfoOriginRoleName = dt.Rows[0]["InfoOriginRoleName"].ToString().Trim();
            PublishMan = dt.Rows[0]["LoginName"].ToString().Trim();
            ManageTypeID = dt.Rows[0]["ManageTypeID"].ToString().Trim();
        }

        #endregion


        #region 资源是否购买的提示信息

        string WhetherCharges_button = "";  //按钮提示
        string WhetherCharges_Clew = "";    //提示信息
        string userState = "Charge";         // Charge购买 / Login登陆 / View查看
        //if (User.Identity.Name != null && LoginName.Trim() == User.Identity.Name.Trim())//已登陆
        //{
            if (MainPointCount > 0 && FixPriceID > 1)       //是否免费信息
            {
                bool bIsBuy = false;                        //这是一条收费信息   
                Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
                bIsBuy = ciBll.bIsBuyInfoOfUser(CurrentUserName, InfoID);
                if (bIsBuy)
                {
                    userState = "View";
                }
                else
                {
                    userState = "Charge";
                }
            }
            else
            {
                userState = "View";
            }
        //}
        switch (userState)
        {
            case "Login":   //提示登陆
                //WhetherCharges_button = "<a href=\"http://member.topfo.com\"><img src=\"/CommonV3/img/res3_btn14.gif\" alt=\"请先登陆\"></a>";
                //WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为该资源的项目核心资料，你需要登陆才能查看！</span><span class=\"btn\">" +
                //    "<a href=\"http://member.topfo.com\"><img src=\"/CommonV3/img/res3_btn14.gif\" alt=\"点击登陆\" /></a></span>" +
                //    "<div class=\"clear\"></div>";
                //break;
            case "View":    //提示查看
                WhetherCharges_button = "<a href=\"#88\" onclick=\"javascript:GetContactDetail(" + InfoID + ");\" ><img src=\"/CommonV3/img/res3_btn13.gif\" alt=\"请点击查看\"></a>";
                WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为项目核心资料，你需要购买才能查看！</span><span class=\"btn\">" +
                    "<a href=\"#88\" onclick=\"javascript:GetContactDetail(" + InfoID + ");\"><img src=\"/CommonV3/img/res3_btn13.gif\" alt=\"点击查看\" /></a></span>" +
                    "<div class=\"clear\"></div>";
                break;
            case "Charge":  //提示购买
                WhetherCharges_button = "<a href=\"" + buyUrl + "\"><img src=\"/CommonV3/img/res3_btn7.gif\" alt=\"请点击购买\"></a>";
                WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为项目核心资料，你需要购买才能查看！</span><span class=\"btn\">" +
                    "<a href=\"" + buyUrl + "\"><img src=\"/CommonV3/img/res3_btn7.gif\" alt=\"点击购买\" /></a></span>" +
                    "<div class=\"clear\"></div>";
                break;
        }

        sOut.Append(WhetherCharges_button.Trim());
        sOut.Append("|");
        sOut.Append(WhetherCharges_Clew.Trim());
        sOut.Append("|");

        #endregion


        #region 购买者评级

        //sOut.Append(getBuyerRatingById(InfoID).ToString().Trim());
        sOut.Append("");
        sOut.Append("|");

        #endregion


        #region 相关资源列表

        string list_Capital = bcx.getInfoList("Capital", InfoID);
        sOut.Append(list_Capital.Trim());
        sOut.Append("|");

        string list_Project = bcx.getInfoList("Project", InfoID);
        sOut.Append(list_Project.Trim());
        sOut.Append("|");

        string list_Merchant = bcx.getInfoList("Merchant", InfoID);
        sOut.Append(list_Merchant.Trim());
        sOut.Append("|");

        string list_Others = bcx.getInfoList("Others", InfoID);
        sOut.Append(list_Others.Trim());
        sOut.Append("|");

        string list_News = bcx.getInfoList("News", InfoID);
        sOut.Append(list_News.Trim());

        #endregion


        return sOut.ToString().Trim();
    }


    #region 页面核心信息获取
    /// <summary>
    /// 页面核心信息获取
    /// </summary>
    /// <param name="InfoID"></param>
    /// <param name="LoginName"></param>
    /// <returns></returns>
    [WebMethod]
    //public string InfoContactByID(string InfoID, string LoginName)
    public string GetContactDetail(string InfoID)
    {
        string LoginName = "";

        #region 资源是否购买的提示信息

        string WhetherCharges_button = "";  //按钮提示
        string WhetherCharges_Clew = "";    //提示信息
        int FixPriceID = 0;
        string infoTypeName = "";
        decimal MainPointCount = 0;
        string userState = "Charge";         // Charge购买 / Login登陆 / View查看
        string payDomain = System.Configuration.ConfigurationManager.AppSettings["payDomain"];
        string buyUrl = payDomain + "/order_item.aspx?InfoID=" + InfoID;    //资源购买的路径
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("MainInfoTab", "InfoID,FixPriceID,MainPointCount,InfoType", "InfoID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
        if (dt != null && dt.Rows.Count > 0)
        {
            FixPriceID = Convert.ToInt32(dt.Rows[0]["FixPriceID"].ToString().Trim());
            MainPointCount = Convert.ToDecimal(dt.Rows[0]["MainPointCount"].ToString().Trim());
            infoTypeName = dt.Rows[0]["InfoType"].ToString().Trim();
        }
        //if (User.Identity.Name != null && LoginName.Trim() == User.Identity.Name.Trim())//已登陆
        //{
            if (MainPointCount > 0 && FixPriceID > 1)       //是否免费信息
            {
                bool bIsBuy = false;                        //这是一条收费信息   
                Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
                bIsBuy = ciBll.bIsBuyInfoOfUser(LoginName, InfoID);
                if (bIsBuy)
                {
                    userState = "View";
                }
                else
                {
                    userState = "Charge";
                }
            }
            else
            {
                userState = "View";
            }
        //}
        switch (userState)
        {
            case "Login":   //提示登陆
                //WhetherCharges_button = "<a href=\"http://member.topfo.com\"><img src=\"/CommonV3/img/res3_btn14.gif\" alt=\"请先登陆\"></a>";
                //WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为该资源的项目核心资料，你需要登陆才能查看！</span><span class=\"btn\">" +
                //    "<a href=\"http://member.topfo.com\"><img src=\"/CommonV3/img/res3_btn14.gif\" alt=\"点击登陆\" /></a></span>" +
                //    "<div class=\"clear\"></div>";
                //break;
            case "View":    //提示查看
                WhetherCharges_button = "<a href=\"#88\" onclick=\"javascript:GetContactDetail(" + InfoID + ");\" ><img src=\"/CommonV3/img/res3_btn13.gif\" alt=\"请点击查看\"></a>";
                WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为项目核心资料，你需要购买才能查看！</span><span class=\"btn\">" +
                    "<a href=\"#88\" onclick=\"javascript:GetContactDetail(" + InfoID + ");\"><img src=\"/CommonV3/img/res3_btn13.gif\" alt=\"点击查看\" /></a></span>" +
                    "<div class=\"clear\"></div>";
                break;
            case "Charge":  //提示购买
                WhetherCharges_button = "<a href=\"" + buyUrl + "\"><img src=\"/CommonV3/img/res3_btn7.gif\" alt=\"请点击购买\"></a>";
                WhetherCharges_Clew = "<span class=\"tit f_tit3\">以下为项目核心资料，你需要购买才能查看！</span><span class=\"btn\">" +
                    "<a href=\"" + buyUrl + "\"><img src=\"/CommonV3/img/res3_btn7.gif\" alt=\"点击购买\" /></a></span>" +
                    "<div class=\"clear\"></div>";
                break;
        }

        #endregion

        StringBuilder sbContact = new StringBuilder();
        string cacheName = "Cache_Info_" + InfoID;
        if (userState.Trim() == "View")
        {
            if (HttpContext.Current.Cache[cacheName] != null && HttpContext.Current.Cache[cacheName].ToString() != "")
            {
                sbContact.Append(HttpContext.Current.Cache[cacheName].ToString());
            }
            else
            {
                Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();
                Tz888.BLL.Info.InfoContact dal_IC = new Tz888.BLL.Info.InfoContact();
                model = dal_IC.GetModel(Convert.ToInt64(InfoID));
                sbContact.Append("<a name='#88' id='##88'>&nbsp;</a>");
                sbContact.Append("项目建设单位：&nbsp;" + model.OrganizationName.Trim() + "<br />");
                sbContact.Append("联系人：&nbsp;" + model.Name.Trim() + "<br />");
                sbContact.Append("职位：&nbsp;" + model.Career.Trim() + "<br />");
                sbContact.Append("固定电话：&nbsp;" + model.TelStateCode + "-" + model.TelNum.Trim() + "<br />");
                sbContact.Append("手机：&nbsp;" + model.Mobile.Trim() + "<br />");
                sbContact.Append("电子邮箱：&nbsp;" + model.Email + "<br />");
                sbContact.Append("项目单位详细地址：&nbsp;" + model.Address + "<br />");
                sbContact.Append("项目单位网址：&nbsp;" + model.WebSite);
                sbContact.Append("|");

                string fujianStr = "";              //7,附件列表
                fujianStr = getInfoResourceById(Convert.ToInt64(InfoID));
                sbContact.Append(fujianStr.Trim());
                sbContact.Append("|");

                switch (infoTypeName.ToLower())
                {
                    case "merchant":
                        Tz888.IDAL.Info.IMarchantInfo dal1 = Tz888.DALFactory.DataAccess.CreateInfo_MarchantInfo();
                        Tz888.Model.Info.MerchantSetModel TheInfo1 = new Tz888.Model.Info.MerchantSetModel();
                        TheInfo1 = dal1.GetIntegrityModel(Convert.ToInt64(InfoID));
                        sbContact.Append(TheInfo1.MerchantInfoModel.ProjectStatus);  //项目现状及规划
                        sbContact.Append("|");
                        sbContact.Append(TheInfo1.MerchantInfoModel.marketAbout);    //项目优势及市场分析
                        sbContact.Append("|");
                        sbContact.Append(TheInfo1.MerchantInfoModel.Benefit);        //经济效益分析
                        break;
                    case "project":
                        Tz888.IDAL.Info.IProjectInfo dal2 = Tz888.DALFactory.DataAccess.CreateInfo_ProjectInfo();
                        Tz888.Model.Info.ProjectSetModel TheInfo2 = dal2.GetIntegrityModel(Convert.ToInt64(InfoID));
                        sbContact.Append(TheInfo2.ProjectInfoModel.nDwlyysy.ToString()); //单位年营业收入
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.nDwljly.ToString());  //单位年净利润
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.nDwzzc.ToString());   //单位总资产
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.nDwzfz.ToString());   //单位总负债
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.ProjectAbout.ToString()); //产品概述
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.marketAbout.ToString());  //市场前景
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.competitioAbout.ToString());  //竞争分析
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.BussinessModeAbout.ToString());   //商业模式
                        sbContact.Append("|");
                        sbContact.Append(TheInfo2.ProjectInfoModel.ManageTeamAbout.ToString());      //管理团队
                        break;
                    case "capital":
                        Tz888.IDAL.Info.IInfoContact dal3 = Tz888.DALFactory.DataAccess.CreateInfo_InfoContact();
                        Tz888.Model.Info.InfoContactModel TheInfo3 = dal3.GetModel(Convert.ToInt64(InfoID));
                        sbContact.Append(TheInfo3.OrgIntro.ToString());      //投资方简介
                        break;
                    default: break;
                }

                HttpContext.Current.Cache[cacheName] = sbContact.ToString();
            }
        }

        return sbContact.ToString().Trim();
    }

    #endregion


    #region 获取附件列表与购买者评级

    public string getInfoResourceById(long infoID)
    {
        string resStr = "";
        string tempStr = "<li><a href=\"#ResURL\"><div class=\"pic\"><img src=\"/CommonV3/img/res_ad2.gif\" alt=\"#ResType\"></div>#ResTitle</a></li>";
        //string tempStr = "<li>[#ResType]<a href='#ResURL' alt='#ResT2'>#ResTitle</a>——#ResDec</li>";
        Tz888.SQLServerDAL.Info.InfoResourceDAL bll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
        List<Tz888.Model.Info.InfoResourceModel> models = bll.GetModelList(infoID);
        if (models != null)
        {
            foreach (Tz888.Model.Info.InfoResourceModel ResModel in models)
            {
                string temp = tempStr;
                string restype = "image";
                string fileName = ResModel.ResourceAddr.Trim();
                if (fileName != "")
                {
                    fileName = "http://images.topfo.com/" + ResModel.ResourceAddr;
                }
                else
                {
                    fileName = "#";
                }
                if (fileName.IndexOf(".doc") > 0 || fileName.IndexOf(".ppt") > 0 || fileName.IndexOf(".pdf") > 0)
                {
                    restype = "file";
                }
                temp = temp.Replace("#ResType", restype == "image" ? "点击查看图片" : "点击下载文件");
                temp = temp.Replace("#ResURL", fileName.Trim());
                //temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
                temp = temp.Replace("#ResTitle", ResModel.ResourceTitle);
                resStr += temp;
            }
        }
        if (resStr.Trim() == "")
        {
            resStr = "<li>无相关附件</li>";
        }
        return resStr;
    }


    public int getBuyerRatingById(string infoID)
    {
        int degree = 0;
        return degree;
    }

    #endregion

}

