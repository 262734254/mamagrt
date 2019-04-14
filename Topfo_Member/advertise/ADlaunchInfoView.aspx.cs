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
using System.Text;
public partial class advertise_ADlaunchInfoView : Tz888.Common.Pager.BasePage
{
    private int _myPageSize = 10;
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
       
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;

        if (ViewState["Criteria"] == null)
        {
            this._criteria = " LoginName='"+Page.User.Identity.Name+"'";
            ViewState["Criteria"] = this._criteria;
        }
        else
            this._criteria = ViewState["Criteria"].ToString();

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = this._criteria;
        this.Pager1.TableViewName = "ADMessage_launchInfo";
        this.Pager1.KeyColumn = "Stardate";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "Stardate";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
    }

    /// <summary>
    /// 翻译成频道名称
    /// </summary>
    /// <returns></returns>
    protected string SelBName(int id)
    {
        Tz888.BLL.advertise.ADlaunchInfoBLL launch = new Tz888.BLL.advertise.ADlaunchInfoBLL();
        string name = "";
        name = launch.SelBName(id);
        return name;
    }
    /// <summary>
    /// 截取时间
    /// </summary>
    /// <returns></returns>
    protected string selTime(DateTime time)
    {
        string name = "";
        name = time.ToString("yyyy-MM-dd");
        return name;
    }
    /// <summary>
    /// 截取字符串个数
    /// </summary>
    /// <returns></returns>
    protected string StrLength(object title)
    {
        string name = "";
        name = title.ToString();
        if (name.Length > 15)
        {
            name = name.Substring(0, 14) + "...";
        }
        return name;
    }
}
