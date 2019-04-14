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

public partial class MemberFollow : Tz888.Common.Pager.BasePage
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

        PagerBase = this.Pager1;
        this.RepeaterBase = this.RfUser;
        if (!IsPostBack)
        {
            this.BindInfoData();
            this.GetUserInfo();
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

    private void BindInfoData()
    {
        this._infoID = Convert.ToInt64(ViewState["InfoID"]);
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        long intCurrentPage = 1;                   
        long intCurrentPageSize = 1;
        long intTotalCount = 1;
        this.RfInfo.DataSource =  bll.GetMainInfoViewList("*", "InfoID = " + this._infoID.ToString(), "", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);
        this.RfInfo.DataBind();
    }

    private void GetUserInfo()
    {
        this._infoID = Convert.ToInt64(ViewState["InfoID"]);

        this.Pager1.PageSize = 10;
        this.Pager1.StrWhere = "InfoID=" + this._infoID + " AND DeleteStatus<>1";
        this.Pager1.TableViewName = "InfoViewCollectionVIW";
        this.Pager1.KeyColumn = "ID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "CreateDate";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();
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

    protected string GetZoneInfo(object countryName,object proName,object cityName,object countyName)
    {
        string request = "未知";
        if(countryName!= null&&!string.IsNullOrEmpty(countryName.ToString()))
        {
            request += " " + countryName.ToString().Trim();
            if (proName != null && !string.IsNullOrEmpty(proName.ToString()))
            {
                request += " " + proName.ToString();
                if (cityName != null && !string.IsNullOrEmpty(cityName.ToString()))
                {
                    request += " " + cityName.ToString();
                    if(countyName != null & !string.IsNullOrEmpty(countyName.ToString()))
                        request += " " + countyName.ToString();
                }
            }
        }
        return request;
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
