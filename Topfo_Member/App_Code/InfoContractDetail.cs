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
/// InfoContractDetail 的摘要说明

/// </summary>
[WebService(Namespace = "http://www.topfo.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
public class InfoContractDetail : System.Web.Services.WebService
{

    public InfoContractDetail()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    #region 获取页面联系方式信息
    [WebMethod]
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

        #region 信息参数说明
        StringBuilder sOut = new StringBuilder();
        long lgCurrentPage = 1;
        long lgPageSize = 0;
        long lgPageCount = 0;
        decimal MainPointCount = 0;
        string CurrentUserName = "";
        CurrentUserName = LoginName;
        string MemberURL = "";              //用户会员资料展示页面

        bool bIsTofMember = false;          //用户是否是拓富通会员
        if (User.IsInRole("GT1002"))
        {
            //拓富通会员
            if (CurrentUserName.Trim() != "")
            {
                bIsTofMember = true;
            }
        }

        string sContract = "";              //1,用户的联系方式信息 | 2,type
        #endregion

        #region 获取用户的联系方式信息
        string PublishMan = "";
        string NickName = "";
        string SelfWebDomain = "";          //网上展厅域名
        string InfoTypeName = "";
        int FixPriceID = 0;
        string InfoOriginRoleName = "0";
        string ManageTypeID = "";
        Tz888.BLL.Common.CommonFunction cf = new Tz888.BLL.Common.CommonFunction();
        DataTable dt = cf.GetDTFromTableOrView("MainInfoViw", "infoid", "*", " infoid=" + InfoID, "InfoID", ref lgCurrentPage, lgPageSize, ref lgPageCount);
        if (dt != null && dt.Rows.Count > 0)
        {
            FixPriceID = Convert.ToInt32(dt.Rows[0]["FixPriceID"].ToString().Trim());
            MainPointCount = Convert.ToDecimal(dt.Rows[0]["MainPointCount"].ToString().Trim());
            InfoOriginRoleName = dt.Rows[0]["InfoOriginRoleName"].ToString().Trim();
            PublishMan = dt.Rows[0]["LoginName"].ToString().Trim();
            ManageTypeID = dt.Rows[0]["ManageTypeID"].ToString().Trim();
            Tz888.BLL.Conn con = new Tz888.BLL.Conn();
            DataTable domain = con.GetWebSiteList("SelfCreateWebInfo", "Domain", "LoginName", 1, 1, 0, 1, "LoginName='" + PublishMan + "'");
            if (domain.Rows.Count > 0)
            {
                SelfWebDomain = domain.Rows[0]["Domain"].ToString();
            }
        }
        string ToSelfWebDomain = "";
        string href = "";
        if (SelfWebDomain != "")
        {
            if (ManageTypeID == "2004")
            {
                href = "http://" + SelfWebDomain + ".gov.topfo.com";
            }
            else
            {
                href = "http://" + SelfWebDomain + ".co.topfo.com";
            }
            ToSelfWebDomain = "<a href='" + href + "' target='_blank'><img src='/images/huiy_23.jpg' width='206' height='30' /></a>";

        }
        //总站发布的信息
        string sManage = "<a href='#88' onclick=\"javascript:GetContactDetail(" + InfoID + ");\" class='spaces' ><img src='/web13/images/project/button_cklxfs.gif' width='150' height='30' align='absmiddle' /></a>&nbsp;&nbsp;" + ToSelfWebDomain + "|1";
        //免费的信息的内容
        string sFree = "<a href='#88' onclick=\"javascript:GetContactDetail(" + InfoID + ");\" class='spaces' ><img src='/web13/images/project/button_cklxfs.gif' width='150' height='30' align='absmiddle' /></a>&nbsp;&nbsp;" + ToSelfWebDomain + "|1";
        //收费的信息内容（需要购买才能看）
        string payDomain = System.Configuration.ConfigurationManager.AppSettings["payDomain"];
        string sChange = "<a href=\"" + payDomain + "/order_item.aspx?InfoID=" + InfoID
            + "\" class=\"spaces\"><img src='/web13/images/project/button_ljgm.gif' width=\"130\" height=\"30\" border=\"0\" align=\"absmiddle\" /></a>&nbsp;<a href=\"http://member.topfo.com/PayManage/shopcar.aspx?InfoID=" + InfoID
            + "\" class=\"spaces\" target=\"_blank\"><img src=\"/web13/images/project/button_flgwc.gif\" width=\"150\" height=\"30\" border=\"0\" align=\"absmiddle\" /></a><br /><font color='#CCCCCC'>支持多种支付方式，资源若无效经中国招商投资网确认后可全额返还所付款项，请放心购买</font><br>" + ToSelfWebDomain + "|2";
        if (MainPointCount > 0 && FixPriceID > 1)       //当前用户名
        {
            bool bIsBuy = false;                        //这是一条收费信息   
            Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
            bIsBuy = ciBll.bIsBuyInfoOfUser(CurrentUserName, InfoID);
            if (bIsBuy)
            {
                if (InfoOriginRoleName == "0")
                    sContract = sFree;
                else
                    sContract = sManage;
            }
            else
            {
                if (bIsTofMember)
                {
                    //拓富通会员购买了此信息
                    if (InfoOriginRoleName == "0")
                        sContract = sFree;
                    else
                        sContract = sManage;
                }
                else
                {
                    //拓富通会员没有购买了此信息
                    sContract = sChange;
                }
            }
        }
        else
        {
            //这是一条免费信息
            if (InfoOriginRoleName == "0")
                sContract = sFree;
            else
                sContract = sManage;
        }
        #endregion

        sOut.Append(sContract.Trim());
        sOut.Append("|");                   //3,null

        #region 点击量
        string Hits = "0";                  //4,多少人关注
        //if (dv != null && dv.Table.Rows.Count > 0)
        if (dt != null && dt.Rows.Count > 0)
        {
            Hits = dt.Rows[0]["hit"].ToString().Trim();
        }
        #endregion

        sOut.Append("|");
        sOut.Append(Hits.Trim());

        #region 收藏与浏览量
        string ViewCollection = "0";        //5,多少人收藏,同时更新浏览次数

        if (MainPointCount > 0 && FixPriceID > 1)
        {
            Tz888.BLL.Info.MatchInfoBLL miBLL = new Tz888.BLL.Info.MatchInfoBLL();
            miBLL.dvViewCollectionCount(InfoID);//更新浏览次数
            Tz888.BLL.Info.MainInfoBLL mainBLL = new Tz888.BLL.Info.MainInfoBLL();
            ViewCollection = mainBLL.GetInfoBuyersCount(Convert.ToInt64(InfoID)).ToString();
        }
        else
        {
            Tz888.BLL.Info.MatchInfoBLL miBLL = new Tz888.BLL.Info.MatchInfoBLL();
            DataView dvViewCollection = miBLL.dvViewCollectionCount(InfoID);
            if (dvViewCollection != null && dvViewCollection.Table.Rows.Count > 0)
            {
                ViewCollection = Convert.ToInt32(dvViewCollection.Table.Rows[0][0]).ToString();
            }
        }
        #endregion

        sOut.Append("|");
        sOut.Append(ViewCollection.Trim());

        #region 查询推荐的次数
        ///------------------------------------------
        ///-- 20090601 ----------------     6,查询推荐的次数
        ///------------------------------------------
        Tz888.BLL.CommendBLL com = new Tz888.BLL.CommendBLL();
        long currpage = 1;
        long pagecount = 1;
        int count = com.GetListCount("*", "InfoID=" + InfoID.ToString(), "", ref currpage, 1, ref pagecount);
        #endregion

        sOut.Append("|");
        sOut.Append(count.ToString().Trim());

        #region 附件列表
        string fujianStr = "";              //7,附件列表
        fujianStr = getInfoResourceById(Convert.ToInt64(InfoID), InfoOriginRoleName, MainPointCount, FixPriceID, bIsTofMember);
        #endregion

        sOut.Append("|");
        sOut.Append(fujianStr.Trim());

        sOut.Append("|");                   //8,资源价格
        sOut.Append(MainPointCount.ToString());

        sOut.Append("|");
        if (MainPointCount > 0 && FixPriceID > 1)//9,判断是否为收费资源
            sOut.Append("收费");
        else
            sOut.Append("免费");

        return sOut.ToString().Trim();
    }
    #endregion

    #region 获取资源的联系方式
    /// <summary>
    /// 根据InfoID,显示信息的联系方式
    /// </summary>
    /// <param name="InfoID"></param>
    /// <returns></returns>
    [WebMethod]
    public string GetInfoContractDetail(string InfoID)
    {
        string cacheStr = "ContractDetail_" + InfoID;
        if (HttpContext.Current.Cache[cacheStr] != null)
        {
            return HttpContext.Current.Cache[cacheStr].ToString().Trim();
        }
        else
        {
            #region 获取资源的联系方式

            //最终显示的信息
            string sOut = "";
            //免费的信息的内容
            string sFree = "<a href='#88' onclick=\"javascript:GetContactDetail(" + InfoID + ");\" class='spaces' ><img src='/Web13/images/project/button_cklxfs.gif' width='150' height='30' align='absmiddle' /></a> <i></i>我的MSN在线，联系我：<img src='/web13/images/project/icon_msn.gif' width='29' height='26' align='absmiddle' /><i></i>或<i></i><a href=\"Javascript:alert('系统升级中。。。');\"> 给项目方留言&gt;</a><p>发布者：<a href='#'>1234</a><i></i><img src='/web13/images/project/icon_05.gif' width='15' height='12' /> <i></i> <a href=\"javascript:alert('系统升级中。。。');\">加为好友</a></p>|1";
            //收费的信息内容

            string sChange = "<a href=\"http://pay.topfo.com/order_item.aspx?InfoID=" + InfoID + "\" class=\"spaces\"><img src=\"/web13/images/project/button_ljgm.gif\" width=\"130\" height=\"30\" border=\"0\" align=\"absmiddle\" /></a><i></i><a href=\"http://member.topfo.com/PayManage/shopcar.aspx?InfoID=" + InfoID + "\" class=\"spaces\"><img src=\"/web13/images/project/button_flgwc.gif\" width=\"150\" height=\"30\" border=\"0\" align=\"absmiddle\" /></a><p color='#CCCCCC'>支持多种支付方式，资源若无效经中国招商投资网确认后可全额返还所付款项，请放心购买。</p>|2";

            //当前用户名

            string CurrentUserName = "";
            CurrentUserName = User.Identity.Name.Trim();

            //用户是否是拓富通会员


            bool bIsTofMember = false;
            if (User.IsInRole("GT1002"))
            {
                if (CurrentUserName.Trim() != "")
                {
                    bIsTofMember = true;
                }
            }
            Tz888.Model.Info.CapitalSetModel objCSM = new Tz888.Model.Info.CapitalSetModel();
            Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
            objCSM = ciBll.GetIntegrityModel(long.Parse(InfoID));

            if (objCSM.MainInfoModel.MainPointCount > 0)
            {
                //这是一条收费信息                
                if (bIsTofMember)
                {
                    //是拓富通会员

                    bool bIsBuy = false;
                    bIsBuy = ciBll.bIsBuyInfoOfUser(CurrentUserName, InfoID);

                    if (bIsBuy)
                    {
                        //拓富通会员购买了此信息

                        sOut = sFree;
                    }
                    else
                    {
                        //拓富通会员没有购买了此信息

                        sOut = sChange;
                    }
                }
                else
                {
                    //非拓富通会员

                    sOut = sChange;
                }
            }
            else
            {
                //这是一条免费信息

                sOut = sFree;
            }
            //return sOut;
            #endregion

            HttpContext.Current.Cache.Insert(cacheStr, sOut.ToString().Trim(), null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(7));

            return sOut.ToString().Trim();
        }
    }

    #endregion

    #region 获取附件列表
    //[WebMethod]
    public string getInfoResourceById(long infoID, string InfoOriginRoleName, decimal MainPointCount, int FixPriceID, bool bIsTofMember)
    {
        string resStr = "";
        string tempStr = "<li>[#ResType]<a href='#ResURL' alt='#ResT2'>#ResTitle</a>——#ResDec</li>";
        Tz888.SQLServerDAL.Info.InfoResourceDAL bll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
        List<Tz888.Model.Info.InfoResourceModel> models = bll.GetModelList(infoID);
        if (models != null)
        {
            int nameNum = 0;
            foreach (Tz888.Model.Info.InfoResourceModel ResModel in models)
            {
                nameNum++;

                if (ResModel.ResourceDescrib.Trim() == "")
                    ResModel.ResourceDescrib = "文件" + nameNum.ToString();
                if (ResModel.ResourceTitle.Trim() == "")
                    ResModel.ResourceTitle = "文件" + nameNum.ToString();

                string temp = tempStr;
                string restype = "image";
                string fileName = ResModel.ResourceAddr.Trim();
                if (fileName != "")
                {
                    fileName = "http://images.topfo.com/" + ResModel.ResourceAddr;
                }
                if (fileName.IndexOf(".doc") > 0 || fileName.IndexOf(".ppt") > 0 || fileName.IndexOf(".pdf") > 0)
                {
                    restype = "file";
                }

                if (MainPointCount > 0 && FixPriceID > 1)//收费资源
                {
                    temp = temp.Replace("#ResType", restype == "image" ? "图片" : "文件");
                    //temp = temp.Replace("#ResT2", restype == "image" ? "点击查看图片" : "点击下载文件");
                    if (bIsTofMember == true)//是否登录
                    {
                        if (InfoOriginRoleName == "0")//判断是否购买
                        {
                            temp = temp.Replace("#ResURL", "#");
                            temp = temp.Replace("#ResT2", "购买后才能下载");
                        }
                        else
                        {
                            temp = temp.Replace("#ResURL", fileName.Trim());
                            temp = temp.Replace("#ResT2", restype == "image" ? "点击查看图片" : "点击下载文件");
                        }
                    }
                    else
                    {
                        temp = temp.Replace("#ResURL", "#");
                        temp = temp.Replace("#ResT2", "登录后才能下载");
                    }
                    temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
                    temp = temp.Replace("#ResTitle", ResModel.ResourceTitle);
                }
                else//免费资源
                {
                    temp = temp.Replace("#ResType", restype == "image" ? "图片" : "文件");
                    temp = temp.Replace("#ResT2", restype == "image" ? "点击查看图片" : "点击下载文件");
                    temp = temp.Replace("#ResURL", fileName.Trim());
                    temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
                    temp = temp.Replace("#ResTitle", ResModel.ResourceTitle);
                }
                resStr += temp;
            }
        }
        if (resStr.Trim() == "")
        {
            resStr = "<li>无相关附件</li>";
        }
        //resStr = "<div class=\"lcontentbox\"><div class=\"ctop\"><ul><li>相关附件 </li></ul></div><div class=\"introbox\"><ul style=\" margin-left:20px;\">" + resStr;
        //resStr += "</ul></div></div>";

        return resStr;
    }
    #endregion

    #region 获取用户发布的其他信息
    /// <summary>
    /// 用户发布的其他资源

    /// </summary>
    /// <param name="InfoID"></param>
    /// <returns></returns>
    [WebMethod]
    public string GetOtherResource(string InfoID)
    {
        string xmlpath = "J:\\topfo\\tzWeb\\xml\\UserOtherData\\" + InfoID + ".xml";
        if (!File.Exists(xmlpath))
        {
            new BatchCreateXml().createUserDataXml(InfoID);
        }

        #region 原来的类似资源获取（已注释）
        //else
        //{
        //    #region 用户发布的其他资源
        //    StringBuilder sOut = new StringBuilder();
        //    string doMainUrl = Tz888.Common.Common.GetWWWDomain();

        //    Tz888.BLL.Info.MatchInfoBLL miBll = new Tz888.BLL.Info.MatchInfoBLL();
        //    DataView dv = miBll.dvGetOtherInfoOfUser(InfoID);
        //    if (dv != null && dv.Table.Rows.Count > 0)
        //    {
        //        sOut.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"listtab\"><tr><td width=\"7%\" class=\"title\">&nbsp;</td><td width=\"15%\" class=\"title\" align=\"center\">资源类型</td><td width=\"50%\" class=\"title\" align=\"center\">标题</td><td width=\"28%\" align=\"center\" class=\"title\">发布时间</td></tr>");

        //        for (int i = 0; i < dv.Table.Rows.Count; i++)
        //        {
        //            sOut.Append("<tr><td class=\"font14\"><label><input type=\"checkbox\" name=\"checkbox\" value=\"" + dv.Table.Rows[i]["InfoID"].ToString().Trim() + "\" /></label></td>");
        //            sOut.Append("<td align=\"center\">" + dv.Table.Rows[i]["InfoTypeName"] + "</td>");
        //            sOut.Append("<td align=\"left\"><a href=\"" + doMainUrl + @"/" + dv.Table.Rows[i]["HtmlFile"].ToString().Trim() + "\">" + dv.Table.Rows[i]["title"].ToString().Trim() + "</a></td>");
        //            sOut.Append("<td align=\"center\">" + dv.Table.Rows[i]["PublishT"].ToString().Trim() + "</td>");
        //            sOut.Append("</tr>");
        //        }
        //        sOut.Append("</table>");
        //    }
        //    else
        //    {
        //        sOut.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"listtab\"><tr><td align=\"center\" class=\"title\">该会员未发布其它资源</td></tr></table>");
        //    }
        //    #endregion

        //    return sOut.ToString().Trim();
        //}
        #endregion

        string content = "";
        XmlTextReader reader = new XmlTextReader(xmlpath);

        while (reader.Read())
        {
            if (reader.Name == "string")
            {
                content = reader.ReadString();
            }
        }
        return content;
    }

    #endregion

    #region 获取匹配资源列表

    /// <summary>
    /// 类似的资源

    /// </summary>
    /// <param name="InfoID"></param>
    /// <returns></returns>
    [WebMethod]
    public string GetMatchInfoByInfoID(string InfoID)
    {
        string xmlpath = "J:\\topfo\\tzWeb\\xml\\MatchInfoData\\" + InfoID + ".xml";
        if (!File.Exists(xmlpath))
        {
            new BatchCreateXml().createDataListXml(InfoID);
        }

        #region 原来的类似资源获取（已注释）
        //else
        //{
        //    #region 类似的资源
        //    long lgPageCount = 5;
        //    long lgPage = 1;
        //    int lgPageSize = 5;

        //    string doMainUrl = Tz888.Common.Common.GetWWWDomain();

        //    Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        //    string InfoTypeID = bll.GetInfoTypeID(Convert.ToInt64(InfoID.Trim())).Trim();



        //    string MatchType1 = "";
        //    string MatchType2 = "";
        //    string MatchType3 = "";


        //    switch (InfoTypeID.ToLower().Trim())
        //    {
        //        case "merchant"://招商
        //            MatchType1 = "MM";
        //            MatchType2 = "MP";
        //            MatchType3 = "MC";

        //            break;
        //        case "project"://项目
        //            MatchType1 = "PM";
        //            MatchType2 = "PP";
        //            MatchType3 = "PC";
        //            break;
        //        case "capital"://资金
        //            MatchType1 = "CM";
        //            MatchType2 = "CP";
        //            MatchType3 = "CC";
        //            break;
        //        default:
        //            break;
        //    }
        //    if (InfoTypeID == "project")
        //        return "";

        //    Tz888.BLL.Info.MatchInfoBLL miBll = new Tz888.BLL.Info.MatchInfoBLL();
        //    //DataView dv = miBll.GetMatchList(MatchType, long.Parse(InfoID), "*", "", "FrontDisplayTime DESC", ref lgPage, lgPageSize, ref lgPageCount);
        //    DataView dv1 = miBll.GetMatchList(MatchType1, long.Parse(InfoID), "*", "", "FrontDisplayTime DESC", ref lgPage, lgPageSize, ref lgPageCount);
        //    DataView dv2 = miBll.GetMatchList(MatchType2, long.Parse(InfoID), "*", "", "FrontDisplayTime DESC", ref lgPage, lgPageSize, ref lgPageCount);
        //    DataView dv3 = miBll.GetMatchList(MatchType3, long.Parse(InfoID), "*", "", "FrontDisplayTime DESC", ref lgPage, lgPageSize, ref lgPageCount);


        //    StringBuilder sOut = new StringBuilder();

        //    if (dv1 != null && dv1.Table.Rows.Count > 0)
        //    {
        //        sOut.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"listtab\"><tr><td width=\"7%\" class=\"title\">&nbsp;</td><td width=\"15%\" class=\"title\" align=\"left\">发布人</td><td width=\"50%\" class=\"title\" align=\"center\">标题</td><td width=\"28%\" align=\"center\" class=\"title\">刷新时间</td></tr>");
        //        sOut.Append("<tr><td  colspan=4 style=\"width: 100%; font-weight: bold;text-align: left\">政府招商相关资源</td></tr>");
        //        for (int i = 0; i < dv1.Table.Rows.Count; i++)
        //        {
        //            sOut.Append("<tr><td class=\"font14\"><label><input type=\"checkbox\" name=\"checkbox\" value=\"" + dv1.Table.Rows[i]["InfoID"].ToString().Trim() + "\" /></label></td>");
        //            sOut.Append("<td align=\"left\">" + dv1.Table.Rows[i]["LoginName"] + "</td>");
        //            sOut.Append("<td align=\"left\"><a href=\"" + doMainUrl + @"/" + dv1.Table.Rows[i]["HtmlFile"].ToString().Trim() + "\">" + dv1.Table.Rows[i]["title"].ToString().Trim() + "</a></td>");
        //            sOut.Append("<td align=\"center\">" + dv1.Table.Rows[i]["FrontDisplayTime"].ToString().Trim() + "</td>");
        //            sOut.Append("</tr>");
        //        }
        //        sOut.Append("<tr><td  colspan=4 style=\"width: 100%; font-weight: bold;text-align: left\">企业项目相关资源</td></tr>");
        //        for (int i = 0; i < dv2.Table.Rows.Count; i++)
        //        {
        //            sOut.Append("<tr><td class=\"font14\"><label><input type=\"checkbox\" name=\"checkbox\" value=\"" + dv2.Table.Rows[i]["InfoID"].ToString().Trim() + "\" /></label></td>");
        //            sOut.Append("<td align=\"left\">" + dv2.Table.Rows[i]["LoginName"] + "</td>");
        //            sOut.Append("<td align=\"left\"><a href=\"" + doMainUrl + @"/" + dv2.Table.Rows[i]["HtmlFile"].ToString().Trim() + "\">" + dv2.Table.Rows[i]["title"].ToString().Trim() + "</a></td>");
        //            sOut.Append("<td align=\"center\">" + dv2.Table.Rows[i]["FrontDisplayTime"].ToString().Trim() + "</td>");
        //            sOut.Append("</tr>");
        //        }
        //        sOut.Append("<tr><td colspan=4 style=\"width: 100%; font-weight: bold;text-align: left\">资本相关资源</td></tr>");
        //        for (int i = 0; i < dv3.Table.Rows.Count; i++)
        //        {
        //            sOut.Append("<tr><td class=\"font14\"><label><input type=\"checkbox\" name=\"checkbox\" value=\"" + dv3.Table.Rows[i]["InfoID"].ToString().Trim() + "\" /></label></td>");
        //            sOut.Append("<td align=\"left\">" + dv3.Table.Rows[i]["LoginName"] + "</td>");
        //            sOut.Append("<td align=\"left\"><a href=\"" + doMainUrl + @"/" + dv3.Table.Rows[i]["HtmlFile"].ToString().Trim() + "\">" + dv3.Table.Rows[i]["title"].ToString().Trim() + "</a></td>");
        //            sOut.Append("<td align=\"center\">" + dv3.Table.Rows[i]["FrontDisplayTime"].ToString().Trim() + "</td>");
        //            sOut.Append("</tr>");
        //        }



        //        sOut.Append("</table>");
        //        sOut.Append("<div class=\"sbuttom\">" +
        //                "<div class=\"left\">" +
        //                "<img src=\"/Web13/images/project/icon_04.gif\" />" +
        //                "点击复选框<i></i><img src=\"/Web13/images/project/button_dbxzzy.gif\"" +
        //                    "align=\"absmiddle\" style=\"cursor:pointer;\" onclick=\"javascrpit:compare('" + InfoTypeID.ToLower().Trim() + "')\" /></div>" +
        //                "<div class=\"right\">" +
        //                "<a href=\"http://member.topfo.com/helper/MatchingInfo.aspx\" target=\"_blank\">点此订阅相关资源&gt;&gt;</a></div>" +
        //                "<div class=\"clear\"></div></div>");

        //    }
        //    else
        //    {
        //        sOut.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"listtab\"><tr><td align=\"center\" class=\"title\">对不起，没有查到类似的资源</td></tr></table>");
        //    }
        //    #endregion
        //    return sOut.ToString().Trim();
        //}
        #endregion

        string content = "";
        XmlTextReader reader = new XmlTextReader(xmlpath);
        while (reader.Read())
        {
            if (reader.Name == "string")
            {
                content = reader.ReadString();
            }
        }
        return content;
    }

    #endregion

    #region 通过InfoID获取所有联系人信息

    /// <summary>
    /// 通过InfoID获取所有联系人信息
    /// </summary>
    /// <param name="InfoID"></param>
    /// <returns></returns>
    [WebMethod]
    public string GetContactDetail(string InfoID)
    {
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        model = dal.GetModel(Convert.ToInt64(InfoID));
        StringBuilder sbContact = new StringBuilder();
        sbContact.Append("<table width='98%' class='tabContact' border='0' cellpadding='0' cellspacing='0'>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>项目建设单位：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.OrganizationName.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>联系人：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.Name.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>职位：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.Career.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>固定电话：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.TelStateCode + "-" + model.TelNum.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>手机：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.Mobile.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>电子邮箱：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.Email + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>项目单位详细地址：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.Address + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>项目单位网址：</td>");
        sbContact.Append("<td align='left'>&nbsp;" + model.WebSite + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append(" </table>");
        return sbContact.ToString().Trim();

    }
    [WebMethod]
    public string GetContactDetail_New(string InfoID, string LoginName)
    {
        //是否收费信息
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        bool b = false;
        int FixPriceID = 0;
        decimal MainPointCount = 0;
        DataTable dt = dal.GetList("MainInfoTab", "InfoID,FixPriceID,MainPointCount", "InfoID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));
        if (dt.Rows.Count > 0)
        {
            FixPriceID = Convert.ToInt32(dt.Rows[0]["FixPriceID"].ToString().Trim());
            MainPointCount = Convert.ToDecimal(dt.Rows[0]["MainPointCount"].ToString().Trim());
        }
        if (MainPointCount > 0 && FixPriceID > 1)
        {
            Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
            b = ciBll.bIsBuyInfoOfUser(LoginName, InfoID);
            if (b)
                return GetContactDetail(InfoID);
            else
                return "您需要购买此信息才能查看联系方式";
        }
        else
        {
            return GetContactDetail(InfoID);//免费
        }

    }
    #endregion

}


