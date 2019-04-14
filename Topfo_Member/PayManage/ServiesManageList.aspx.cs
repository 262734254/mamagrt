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
using Tz888.BLL;
using Tz888.Common;
public partial class PayManage_ServiesManageList : CompetenceBase
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
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!JudgeCompetence())
        {
            MessageBox.Go("您无此权限", true);
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManage_ServiesManageList));
        if (!IsPostBack)
        {
           
            if (Page.User.Identity.Name != null && Page.User.Identity.Name.Trim() != "")
            {
                this.AspNetPager.PageSize = 10;
                this.AspNetPager.CurrentPageIndex = 1;
                ServiesBind(Page.User.Identity.Name.ToString());
                if (!string.IsNullOrEmpty(Request.QueryString["Servies"]))
                {
                    StructBind(Request.QueryString["Servies"]);
                    RCBind(int.Parse(Request.QueryString["Servies"]));
                }
                else { StructBind(); RCBind(); }
            }
        }
    }
   protected void ServiesBind(string name)
    {
        long PageSize = Convert.ToInt64(AspNetPager.PageSize);
        long CurrPage = Convert.ToInt64(AspNetPager.CurrentPageIndex);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Conn();
        DataTable dt = dal.GetList("ReleaseTabViw", "InfoID", "InfoID,Title,CreateDate,AuditStatus,ServiesBID", "  DelStatus=0 and UserName='" + name + "'", "CreateDate desc ", ref CurrPage, PageSize, ref TotalCount);
      //  DataTable dt = dal.GetList("BusinesProcessTab", "BID", "BID,Title,CreateDate,AuditStatus,ServiesBID", "AuditStatus=1" , "CreateDate desc ", ref CurrPage, PageSize, ref TotalCount);
        if (dt != null)
        {
            AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
            lblCount.Text = TotalCount.ToString();
            lblCurrPage.Text = CurrPage.ToString();
            lblPageCount.Text = AspNetPager.PageCount.ToString();
            ServiesList.DataSource = dt;
            ServiesList.DataBind();
        }
       
    }

    protected void StructBind(string ServiesBig)
    {
       
        if (!string.IsNullOrEmpty(ServiesBig))
        {
            Tz888.BLL.Conn dal = new Conn();
            DataTable dt = dal.GetList("OfferInfoTabVIW", "CompanyName,SubmitDate,AuditStatus,InfoID", "SubmitDate", 5, 1, 0, 1, "DelStatus=0 and AuditStatus=1 and UserName!='" + Page.User.Identity.Name.ToString() + "' and  ServiesBID like  '%" + ServiesBig.Trim() + "%' ");
            StructList.DataSource = dt;
            StructList.DataBind();
            string str = Request.QueryString["Title"].ToString();
            Literal1.Text = "与(" + str + ")匹配的";
        }
    }

    protected void StructBind()
    {

        Tz888.BLL.Conn dal = new Conn();
        DataTable dt = dal.GetList("OfferInfoTabVIW", "CompanyName,SubmitDate,AuditStatus,InfoID", "SubmitDate", 5, 1, 0, 1, "DelStatus=0 and AuditStatus=1 and UserName!='" + Page.User.Identity.Name.ToString() + "' ");
        StructList.DataSource = dt;
        StructList.DataBind();
        Literal1.Text = "最新五条";
    }
    protected void RCBind()
    {
        Tz888.BLL.Conn dal = new Conn();
        DataTable dt = dal.GetList("SS_ProfessionalServices", "*", "PSID", 5, 1, 0, 1, "IsChekUp=1 and LoginName!='"+Page.User.Identity.Name.ToString()+"'");
        RC.DataSource = dt;
        RC.DataBind();
        Literal2.Text = "最新五条";
    }

    protected void RCBind(int SBig)
    {
        Tz888.BLL.Conn dal = new Conn();
        DataTable dt = dal.GetList("SS_ProfessionalServices", "*", "PSID", 5, 1, 0, 1, "IsChekUp=1 and LoginName!='"+Page.User.Identity.Name.ToString()+"' and ServiceBigtype like '%" + SBig+"%'");
        RC.DataSource = dt;
        RC.DataBind();
        string str = Request.QueryString["Title"].ToString();
        Literal2.Text ="与("+ str + ")匹配的";
    }

    [AjaxPro.AjaxMethod]
    public void DeleteID(string InfoID)
    {
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        bool stat;
        int ErrorID = 0;
        string ErrorMsg = "";
        Int64 ID = Convert.ToInt64(InfoID);
        stat = bll.UserDelete(ID, Page.User.Identity.Name.ToString(), ref ErrorID, ref ErrorMsg);
        if (!stat)
        {
            Response.Write("<script>alert('" + ID+ "删除操作失败。'); </script>");
        }
    }

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
       ServiesBind(Page.User.Identity.Name.ToString());
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
        if (!string.IsNullOrEmpty(time))
        {
            return DateTime.Parse(time).ToString("yyyy-MM-dd");
        }
        else { return ""; }
    }

    protected void delete(object sender, CommandEventArgs e)
    {
        Int64 ID = Convert.ToInt64(e.CommandName);
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        bool stat;
        int ErrorID = 0;
        string ErrorMsg = "";

        stat = bll.UserDelete(ID, Page.User.Identity.Name.ToString(), ref ErrorID, ref ErrorMsg);

        if (stat)
        {
            Response.Redirect("ServiesManageList.aspx");
        }
        else { Response.Write("<script>alert('" + ID + "删除操作失败。'); </script>"); }
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
}
