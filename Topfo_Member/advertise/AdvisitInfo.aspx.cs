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

public partial class advertise_AdvisitInfo : Tz888.Common.Pager.BasePage
{
    private int _myPageSize = 20;
    private string _criteria;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        SetPagerParameters();
        if (!IsPostBack)
        {
            this.Pager1.DataBind();
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
    private void SetPagerParameters()
    {
        int name = Convert.ToInt32(Request["adv"].ToString());
        AdvId.Value =Convert.ToString(name);
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;

        if (ViewState["Criteria"] == null)
        {
            this._criteria = " advertiserID='" + name + "'";
            ViewState["Criteria"] = this._criteria;
        }
        else
            this._criteria = ViewState["Criteria"].ToString();

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = this._criteria;
        this.Pager1.TableViewName = "ADlaunch_AdvisitInfo";
        this.Pager1.KeyColumn = "advertiserID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "VDate";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
    }
    
}
