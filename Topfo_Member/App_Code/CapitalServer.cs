using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Text;
using System.Data;

/// <summary>
/// CapitalServer 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
public class CapitalServer : System.Web.Services.WebService
{

    public CapitalServer()
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

        long lgCurrentPage = 1;
        long lgPageSize = 0;
        long lgPageCount = 0;

        decimal MainPointCount = 0;

        StringBuilder sOut = new StringBuilder();

        string CurrentUserName = "";
        CurrentUserName = LoginName;

        //用户会员资料展示页面
        string MemberURL = "";

        //用户是否是拓富通会员


        bool bIsTofMember = false;
        if (User.IsInRole("GT1002"))
        {
            //拓富通会员


            if (CurrentUserName.Trim() != "")
            {
                bIsTofMember = true;
            }
        }

        #region 用户的联系方式信息
        string PublishMan = "";
        string NickName = "";
        string SelfWebDomain = "";//网上展厅域名
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
            DataTable domain = con.GetWebSiteList("SelfCreateWebInfo", "Domain", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (domain.Rows.Count > 0)
            {
                SelfWebDomain = domain.Rows[0]["Domain"].ToString();
            }
        }

        string sContract = "";

        //免费或已购买的信息的内容
        string sFree = "<ul><li><a href=\"javascript:GetContactDetail('" + InfoID + "');\"><img src=\"http://images.topfo.com/Info/Capital/1/images/zibc_23.jpg\" width=\"183\" height=\"30\" /></a>&nbsp;&nbsp;&nbsp;&nbsp;<span>提示：您需要登陆后才能查看联系方式</span></li></ul>";

        //收费的信息内容（需要购买才能看）

        string payDomain = System.Configuration.ConfigurationManager.AppSettings["payDomain"];

        Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
        Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
        objDic = diBll.GetModel("1");
        string strMainPointCount = MainPointCount.ToString("c");
        string strMainPointCountVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * MainPointCount)).ToString("c");

        //收费的信息类容
        string sChange = "<ul><li>资源价格：<span class=\"orange01\"><strong>" + strMainPointCount + "</strong></span>元（拓富通会员价：<span class=\"orange01\"><strong>" + strMainPointCountVip + "</strong></span>元）</li>" +
        "<li><a href=\"" + payDomain + "/order_item.aspx?InfoID=" + InfoID
            + "\" class=\"spaces\"><img src=\"http://images.topfo.com/Info/Capital/1/images/tiem_03.jpg\" /></a>&nbsp;<a href=\"http://membertest.topfo.com/PayManage/shopcar.aspx?InfoID=" + InfoID 
            + "\" class=\"spaces\" target=\"_blank\"><img src=\"http://images.topfo.com/Info/Capital/1/images/tiem_05.jpg\" width=\"162\" height=\"36\" /></a></li>" +
        "<li><font color=\"#CCCCCC\">支持多种支付方式，资源若无效经中国招商投资网确认后可全额返还所付款项，请放心购买</font></li></ul>";
        #endregion

        //sOut.Append(sContract);
        //多少人关注
        string Hits = "0";
        //if (dv != null && dv.Table.Rows.Count > 0)
        if (dt != null && dt.Rows.Count > 0)
        {

            Hits = dt.Rows[0]["hit"].ToString().Trim();
        }
        //sOut.Append("|");
        sOut.Append(Hits.Trim());

        //多少人收藏,同时更新浏览次数
        string ViewCollection = "0";
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
        sOut.Append("|");
        sOut.Append(ViewCollection.Trim());

        //推荐次数
        sOut.Append("|");
        sOut.Append("3");
        //留言条数
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        int c = dal.GetCount("InfoCommentTab", "InfoID", "InfoID=" + InfoID);

        sOut.Append("|");
        sOut.Append(c.ToString());

        sOut.Append("|");
        if (MainPointCount > 0 && FixPriceID > 1)
        {
            //这是一条收费信息
            bool bIsBuy = false;
            Tz888.BLL.Info.CapitalInfoBLL ciBll = new Tz888.BLL.Info.CapitalInfoBLL();
            bIsBuy = ciBll.bIsBuyInfoOfUser(CurrentUserName, InfoID);
            if (bIsBuy)
            {
                sContract = sFree;
            }
            else
            {
                sContract = sChange;
            }
        }
        else
        {
            sContract = sFree;
        }

        sOut.Append(sContract);
        return sOut.ToString().Trim();

    }
    #endregion

    #region 获取类似的资源
    /// <summary>
    /// 类似的资源
    /// </summary>
    /// <param name="InfoID"></param>
    /// <returns></returns>
    [WebMethod]
    public string GetOtherResource(string InfoID)
    {
        StringBuilder sOut = new StringBuilder();
        string doMainUrl = Tz888.Common.Common.GetWWWDomain();
        Tz888.BLL.Info.MatchInfoBLL miBll = new Tz888.BLL.Info.MatchInfoBLL();
        long CurrentPage = 1;
        long TotalCount = 10;
        DataView dv = miBll.GetMatchList("CC", Convert.ToInt64(InfoID), "InfoID", "", "degree asc", ref CurrentPage, 10, ref TotalCount);
        int IsVip = this.GetUserGrad(InfoID);
        if (IsVip == 0)
        {
            if (dv != null && dv.Table.Rows.Count > 0)
            {
                sOut.Append("<table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
                        "<tr>" +
                            "<td width=\"52%\" align=\"left\">" +
                                "<font color=\"#888888\"><b>项目名称</b></font></td>" +
                            "<td width=\"16%\" align=\"left\">" +
                                "<font color=\"#888888\"><b>融资金额</b></font></td>" +
                            "<td width=\"32%\" align=\"left\">" +
                                "<font color=\"#888888\"><b>所属行业</b></font></td>" +
                        "</tr>");
                Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();
                for (int i = 0; i < dv.Table.Rows.Count; i++)
                {
                    long tmpId = Convert.ToInt64(dv.Table.Rows[i]["InfoID"]);
                    Tz888.Model.Info.V124.CapitalSetModel model = bll.GetIntegrityModel(tmpId);
                    string industryname = "";

                    for (int j = 0; j < model.CapitalInfoModel.IndustryBName.Count; j++)
                    {
                        string temp = model.CapitalInfoModel.IndustryBName[j];
                        if (!string.IsNullOrEmpty(temp))
                        {
                            if (j != (model.CapitalInfoModel.IndustryBName.Count - 1))
                                industryname += temp + " ";
                            else
                                industryname += temp;
                        }
                    }
                    sOut.Append("<tr>" +
                            "<td align=\"left\" bgcolor=\"#f6f6f6\">" +
                                "·<a href=\"" + doMainUrl + "/" + model.MainInfoModel.HtmlFile + "\">" + model.MainInfoModel.Title + "</a> " + model.MainInfoModel.publishT.ToString("yyyy-MM-dd") +
                            "</td>" +
                            "<td align=\"left\" bgcolor=\"#f6f6f6\">" +
                                model.CapitalInfoModel.CapitalName +
                            "</td>" +
                            "<td align=\"left\" bgcolor=\"#f6f6f6\">" +
                                industryname + "</td>" +
                        "</tr>");
                }
                sOut.Append("</table>");
            }
            else
            {
                sOut.Append("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"listtab\"><tr><td align=\"center\" class=\"title\">没有相关资源</td></tr></table>");
            }
        }
        else if (IsVip == 1)
        {
            if (dv != null && dv.Table.Rows.Count > 0)
            {
                sOut.Append("<div class=\"leftbox\"><ul>");
                Tz888.BLL.Info.V124.CapitalInfoBLL bll = new Tz888.BLL.Info.V124.CapitalInfoBLL();

                string RowModel = "<li>·<a href=\"{0}\">{1} </a>{2} <span>{3}</span></li>";
                for (int i = 0; i < dv.Table.Rows.Count; i++)
                {
                    long tmpId = Convert.ToInt64(dv.Table.Rows[i]["InfoID"]);
                    Tz888.Model.Info.V124.CapitalSetModel model = bll.GetIntegrityModel(tmpId);

                    string HtmlFile = doMainUrl + "/" + model.MainInfoModel.HtmlFile;
                    string Title = model.MainInfoModel.Title;
                    string PublishTime = model.MainInfoModel.publishT.ToString("yyyy-MM-dd");
                    string CapitalName = model.CapitalInfoModel.CapitalName;
                    if (i == 5)
                    {
                        sOut.Append("</ul></div><div class=\"leftbox\"><ul>");
                    }
                    sOut.Append(string.Format(RowModel, HtmlFile, Title, PublishTime, CapitalName));
                }
                sOut.Append("</ul></div>");
            }
            else
                sOut.Append("");
        }
        if (string.IsNullOrEmpty(sOut.ToString()))
            sOut.Append("没有相关的资源");
        return sOut.ToString().Trim();
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
        sbContact.Append("<td class='T' align='right'>投资机构：</td>");
        sbContact.Append("<td align='left'>" + model.OrganizationName.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>联系人：</td>");
        sbContact.Append("<td align='left'>" + model.Name.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>职位：</td>");
        sbContact.Append("<td align='left'>" + model.Career.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>固定电话：</td>");
        sbContact.Append("<td align='left'>" + model.TelStateCode + "-" + model.TelNum.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>手机：</td>");
        sbContact.Append("<td align='left'>" + model.Mobile.Trim() + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>电子邮箱：</td>");
        sbContact.Append("<td align='left'>" + model.Email + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>联系地址：</td>");
        sbContact.Append("<td align='left'>" + model.Address + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append("<tr>");
        sbContact.Append("<td class='T' align='right'>公司网址：</td>");
        sbContact.Append("<td align='left'>" + model.WebSite + "</td>");
        sbContact.Append("</tr>");
        sbContact.Append(" </table>");
        return sbContact.ToString().Trim();

    }

    #endregion

    #region 判断信息发布者身份
    private int GetUserGrad(string InfoID)
    {
        Tz888.BLL.Conn Conobj = new Tz888.BLL.Conn();
        DataTable dt = Conobj.GetList("MainInfoTab", "LoginName", "InfoID", 1, 1, 0, 0, "infoid=" + InfoID);
        if (dt != null && dt.Rows.Count > 0)
        {
            string LoginName = Convert.ToString(dt.Rows[0]["LoginName"]);
            Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
            string UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(LoginName);
            if (UserGradeTypeID == "1001")
            {
                //普通用户模板
                return 0;
            }
            else
            {
                //VIP会员模板
                return 1;
            }
        }
        return -1;
    }
    #endregion

}

