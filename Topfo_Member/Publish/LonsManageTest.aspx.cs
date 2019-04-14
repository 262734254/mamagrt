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
using System.Collections.Generic;

public partial class Publish_LonsManageTest : Tz888.Common.Pager.BasePage
{

    Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
    Tz888.BLL.LoansInfo loansinfobll = new Tz888.BLL.LoansInfo();
    Tz888.BLL.loanscontactsTab loanscontactstab = new Tz888.BLL.loanscontactsTab();
    private string par
    {
        get
        {
            return ViewState["par"].ToString();
        }
        set
        {
            ViewState["par"] = value;
        }
    }
    private string pars
    {
        get
        {
            return ViewState["pars"].ToString();
        }
        set
        {
            ViewState["pars"] = value;
        }
    }
    private int size
    {
        get
        {
            return Convert.ToInt32(ViewState["size"]);
        }
        set
        {
            ViewState["size"] = value;
        }
    }
    private int index
    {
        get
        {
            return Convert.ToInt32(ViewState["index"]);
        }
        set
        {
            ViewState["index"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        else
        {
            this.ViewState["LoginMemberName"] = Page.User.Identity.Name.Trim();
        }
        if (!IsPostBack)
        {
            size = 15;
            par = "";
            pars = "";
            if (Convert.ToInt32(Request["LoansInfoID"]) != 0)
            {
                int Id = Convert.ToInt32(Request["LoansInfoID"].ToString());
                DeleteLoansInfoTab(Id);

            }
            BindShow();
            NewsList.DataBind();


        }

    }
    private void DeleteLoansInfoTab(int Id)
    {

        int result1 = loansinfobll.DeleteLoansInfo(Id);
        int result2 = loanscontactstab.DeleteloanscontactsTab(Id);
        if (result1 > 0 && result2 > 0)
        {
            int result = loansinfotabbll.DeleteLoansInfoTab(Id);
            if (result > 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功");

            }
            else { Tz888.Common.MessageBox.Show(this.Page, "删除失败"); }
        }
        else { Tz888.Common.MessageBox.Show(this.Page, "删除失败"); }
    }
    public string GetType(int BorrowingType)
    {
        string par = "";
        if (BorrowingType == 0)
        {
            par = "个人";
        }
        else { par = "企业"; }
        return par;
    }
    public string GetStatu(int AuditID)
    {
        string par = "";
        if (AuditID == 0)
        {
            par = "未审核";
        }
        if (AuditID == 3)
        {
            par = "审核未通过";
        }
        if (AuditID == 1) { par = "审核"; }
        return par;
    }
    public string GetTime(string times)
    {
        return times.Substring(0, 9);
    }
    private void BindShow()
    {
        PagerBase = this.Pager1;
        RepeaterBase = this.NewsList;
        if (!string.IsNullOrEmpty(this.ViewState["LoginMemberName"].ToString()))
        {
            par = " LoginName= '" + this.ViewState["LoginMemberName"].ToString().Trim() + "'" + pars;

        }

        this.Pager1.PageSize = size;
        this.Pager1.StrWhere = par;
        this.Pager1.ContentPlaceHolder = "ContentPlaceHolder1";
        this.Pager1.TableViewName = "LoansInfoTab";
        this.Pager1.KeyColumn = "LoansInfoID";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "loansdate";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
        this.Pager1.DataBind();






    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string bianhao = "";
        string type = "";
        string statu = "";
        if (txtNuber.Value.Trim() == "")
        {
            bianhao = "";
        }
        else { bianhao = " and loansInfoID=" + txtNuber.Value.Trim() + ""; }
        if (Convert.ToInt32(ddlType.SelectedValue.Trim()) == 2)
        {
            type = "";

        }
        else
        {
            if (txtNuber.Value.Trim() == "")
            {
                type = " and BorrowingType=" + ddlType.SelectedValue.Trim();
            }
            else
            {
                type = " and BorrowingType=" + ddlType.SelectedValue.Trim();
            }
        }
        if (Convert.ToInt32(ddlStatus.SelectedValue.Trim()) == 2)
        {
            statu = "";
        }
        else
        {
            if (txtNuber.Value.Trim() == "" && Convert.ToInt32(ddlType.SelectedValue.Trim()) == 2)
            {
                statu = " and auditID=" + ddlStatus.SelectedValue.Trim();
            }
            else { statu = " and auditID=" + ddlStatus.SelectedValue.Trim(); }
        }

        if (bianhao == "" && type == "" && statu == "")
        {
            pars = "";
        }
        else
        {
            pars = "" + bianhao + type + statu;
        }
        BindShow();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        if (values == null || values.Length < 1)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择要删除的项目！');", true);
            return;
        }
        for (int i = 0; i < values.Length; i++)
        {
            int result1 = loansinfobll.DeleteLoansInfo(Convert.ToInt32(values[i].Trim()));
            int result2 = loanscontactstab.DeleteloanscontactsTab(Convert.ToInt32(values[i].Trim()));
            if (result1 > 0 && result2 > 0)
            {
                int result = loansinfotabbll.DeleteLoansInfoTab(Convert.ToInt32(values[i].Trim()));

            }

        }
        BindShow();

    }

}
