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

public partial class PayManage_StructManage : System.Web.UI.Page
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManage_StructManage));
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Page.User.Identity.Name))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }
            if (Page.User.Identity.Name != null && Page.User.Identity.Name.Trim() != "")
            {
                this.AspNetPager.PageSize = 10;
                this.AspNetPager.CurrentPageIndex = 1;
                StructBind(Page.User.Identity.Name.Trim());
                if (!string.IsNullOrEmpty(Request.QueryString["Servies"]))
                {
                    ServiesBind(Request.QueryString["Servies"]);
                }
                else { ServiesBind(); }
            }
        }
    }

    protected void StructBind(string name)
    {
        long PageSize = Convert.ToInt64(AspNetPager.PageSize);
        long CurrPage = Convert.ToInt64(AspNetPager.CurrentPageIndex);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("OfferInfoTabVIW", "InfoID", "InfoID,CompanyName,SubmitDate,AuditStatus,ServiesBID", "DelStatus=0 and   UserName='" + name + "'", "SubmitDate desc ", ref CurrPage, PageSize, ref TotalCount);
        AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = AspNetPager.PageCount.ToString();
        StructList.DataSource = dt;
        StructList.DataBind();
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        StructBind(Page.User.Identity.Name.Trim());
    }

    protected void ServiesBind()
    {
       Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
       DataTable dt = dal.GetList("ReleaseTabViw", "InfoID,ServiesBID,ServiesMID,Title,CreateDate,Price,AuditStatus,AuditStatus", "CreateDate ", 5, 1, 0, 1, "DelStatus=0 and AuditStatus=1 and  UserName!='" + Page.User.Identity.Name.ToString() + "'");
        ServiesList.DataSource = dt;
        ServiesList.DataBind();
        Literal1.Text = "最新五条";
    }
    protected void ServiesBind(string Servies)
    {
        string len = "";
        string[] str = Servies.Split(',');
        for (int i = 0; i < str.Length; i++)
        {
            if (i == 0)
            {
                len = "(ServiesBID like  '%" + str[i].Trim() + "%'";
            }
            else if(!string.IsNullOrEmpty(str[i])){
                if (len != "")
                {
                    len += "or ServiesBID like  '%" + str[i].Trim() + "%'";
                }
                else { len = "(ServiesBID like  '%" + str[i].Trim() + "%'"; }
            
            }
        }
        len += ")";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("ReleaseTabViw", "InfoID,ServiesBID,ServiesMID,Title,CreateDate,Price,AuditStatus,AuditStatus", "CreateDate ", 5, 1, 0, 1, "DelStatus=0 and AuditStatus=1 and UserName!= '" + Page.User.Identity.Name.ToString() + "' and " + len + " ");
        ServiesList.DataSource = dt;
        ServiesList.DataBind();
        string s = Request.QueryString["company"].ToString();

        Literal1.Text ="与("+ s+")匹配的";
    }
    protected string getsetServiesBigName(string StructID)
    {
        string str = "";
        if (!string.IsNullOrEmpty(StructID))
        {
            Tz888.BLL.Union dal = new Tz888.BLL.Union();
            DataTable dt = dal.GetList("ServiesBName", "setServiesBigTab", "where ServiesBID=" + StructID, 5);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["ServiesBName"].ToString();
            }
        }
        return str;
    }
    protected string getServiesSmallName(string StructID)
    {
        string str = "";
        if (!string.IsNullOrEmpty(StructID))
        {
            Tz888.BLL.Union dal = new Tz888.BLL.Union();
            DataTable dt = dal.GetList("ServiesMName", "setServiesSmallTab", "where ServiesMID=" + StructID, 5);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["ServiesMName"].ToString();
            }
        }
        return str;
    }
    protected string getState(string StateID)
    {
        string str = "";
        if (StateID == "0")
        {
            str = "未审核";
        }
        else if (StateID == "1")
        {
            str = "审核通过";
        }
        else { str = "审核失败"; }
        return str;
    }

    protected string getDate(string time)
    {
        return DateTime.Parse(time).ToString("yyyy-MM-dd");
    }

    public void delete(object sender, CommandEventArgs e)
    {
        int BID = Convert.ToInt32(e.CommandName);

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        bool stat;
        int ErrorID = 0;
        string ErrorMsg = "";

        stat = bll.UserDelete(BID, Page.User.Identity.Name.ToString(), ref ErrorID, ref ErrorMsg);
        if (!stat)
        {
            Response.Write("<script>alert('" + BID + "删除操作失败。'); </script>");
        }
        else { Response.Redirect("StructManage.aspx"); };

     
    }
    [AjaxPro.AjaxMethod]
    public void DeleteID(string BID)
    {
        int BIDd = Convert.ToInt32(BID);

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        bool stat;
        int ErrorID = 0;
        string ErrorMsg = "";

        stat = bll.UserDelete(BIDd, Page.User.Identity.Name.ToString(), ref ErrorID, ref ErrorMsg);
        if (!stat)
        {
            Response.Write("<script>alert('" + BIDd + "删除操作失败。'); </script>");
        }

    }
}