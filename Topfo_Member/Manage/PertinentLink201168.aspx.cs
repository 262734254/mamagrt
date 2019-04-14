using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class PertinentLink : System.Web.UI.Page
{
    private long _infoID;
    private string _infoType;
    protected string wwwdomain;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.wwwdomain = Tz888.Common.Common.GetWWWDomain();
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }

        if (Page.Request.QueryString["id"] == null || Page.Request.QueryString["type"] == null)
            return;
        try
        {
            this._infoID = Convert.ToInt64(Page.Request.QueryString["id"]);
            ViewState["InfoID"] = this._infoID;
        }
        catch
        {
            return;
        }
        try
        {
            this._infoType = Page.Request.QueryString["type"].ToString();
            ViewState["InfoType"] = this._infoType;
        }
        catch
        {
            return;
        }

        if (this._infoType.ToLower() != "merchant" && this._infoType.ToLower() != "capital" && this._infoType.ToLower() != "project")
            return;

        if (!IsPostBack)
        {
            this.BindInfoData();
            this.LoadMatch();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }

    protected string GetValiditeInfo(object time)
    {
        DateTime dt = new DateTime();
        string request = "";
        try
        {
            dt = Convert.ToDateTime(time);
            request = "有效期至:" + dt.ToString("yyyy-MM-dd hh:mm:ss");
        }
        catch
        {
            request = "未设置有效期";
        }
        return request;
    }

    private void BindInfoData()
    {
        this._infoID = Convert.ToInt64(ViewState["InfoID"]);
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        long intCurrentPage = 1;
        long intCurrentPageSize = 1;
        long intTotalCount = 1;
        this.RfInfo.DataSource = bll.GetMainInfoViewList("*", "InfoID = " + this._infoID.ToString(), "", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);
        this.RfInfo.DataBind();
    }

    private void LoadMatch()
    {
        this._infoType = ViewState["InfoType"].ToString().ToLower();
        this._infoID = Convert.ToInt64(ViewState["InfoID"]);
        switch (this._infoType)
        {
            case "merchant":
                this.MatchInfoList1.InfoID = this._infoID;
                this.MatchInfoList1.MatchType = "MC";
                this.MatchInfoList1.Visible = true;
                this.MatchInfoList2.InfoID = this._infoID;
                this.MatchInfoList2.MatchType = "MP";
                this.MatchInfoList2.Visible = true;
                break;
            case "capital":
                this.MatchInfoList1.InfoID = this._infoID;
                this.MatchInfoList1.MatchType = "CP";
                this.MatchInfoList1.Visible = true;
                this.MatchInfoList2.InfoID = this._infoID;
                this.MatchInfoList2.MatchType = "CM";
                this.MatchInfoList2.Visible = true;
                break;
            case "project":
                this.MatchInfoList1.InfoID = this._infoID;
                this.MatchInfoList1.MatchType = "PC";
                this.MatchInfoList1.Visible = true;
                this.MatchInfoList2.InfoID = this._infoID;
                this.MatchInfoList2.MatchType = "PM";
                this.MatchInfoList2.Visible = true;
                break;
        }
    }

    protected string GetTitle(object htmlfile, object infoType, object infoid)
    {
        string request = "";
        if (!string.IsNullOrEmpty(htmlfile.ToString().Trim()))
        {
            request = this.wwwdomain + @"/" + htmlfile.ToString().Trim();
        }
        else
        {
            switch (infoType.ToString().Trim().ToLower())
            {
                case "merchant":
                    request = "./ModifyMerchant.aspx?id=" + infoid.ToString().Trim() + "&type=" + infoType.ToString().Trim();
                    break;
                case "project":
                    request = "./ModifyProject.aspx?id=" + infoid.ToString().Trim() + "&type=" + infoType.ToString().Trim();
                    break;
                case "capital":
                    request = "./ModifyCapital.aspx?id=" + infoid.ToString().Trim() + "&type=" + infoType.ToString().Trim();
                    break;
                default:
                    break;
            }
        }
        return request;
    }
}
