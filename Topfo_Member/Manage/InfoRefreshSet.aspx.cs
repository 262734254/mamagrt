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

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }

        if (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"))
        {
            this.plRefreshSet_Topfo.Visible = true;
            this.plRefreshSet_General.Visible = false;
        }
        else
        {
            this.plRefreshSet_Topfo.Visible = false;
            this.plRefreshSet_General.Visible = true;
        }

            if (!IsPostBack)
            {
                Tz888.BLL.Login.MemberBLL bll = new Tz888.BLL.Login.MemberBLL();
                string LoginName = Page.User.Identity.Name;
                //string LoginName = "liyanlili";       
                string strCriteria = "LoginName='" + LoginName + "'";
                long intCurrentPage = 1;
                long intCurrentPageSize = 1;
                long intTotalCount = 0;
                DataView dv = bll.GetMerberInfo("LoginName,IsRefresh", strCriteria,"", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);
                int strDayMsg = 0;
                if (dv != null && dv.Count > 0)
                {
                    strDayMsg = Convert.ToInt32(dv.Table.Rows[0]["IsRefresh"]);
                }

                if (strDayMsg == 0)
                {
                    this.RbtnDel.Checked = true;
                }
                else
                {
                    this.RbtnSet.Checked = true;
                }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.BLL.Login.MemberBLL bll = new Tz888.BLL.Login.MemberBLL();
        string LoginName = Page.User.Identity.Name;
        //string LoginName = "liyanlili";  

        if(!Tz888.Common.Utility.PageValidate.IsNumber("5"))
        {
            Tz888.Common.MessageBox.Show(this.Page,"刷新时间输入不正确!");
            return ;
        }

        int IsRefresh = 0;

        if (this.RbtnSet.Checked == true)
        {
            IsRefresh = 5;
        }

        bool HasLoad = bll.RefreshMemberInfo(LoginName, IsRefresh);
        if (!HasLoad)
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息刷新提醒设置失败!");
            return;
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息刷新提醒设置成功!");
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Tz888.BLL.Login.MemberBLL bll = new Tz888.BLL.Login.MemberBLL();

        string LoginName = Page.User.Identity.Name;
        //string LoginName = "liyanlili";

        int IsRefresh = 0;

        bool HasLoad = bll.RefreshMemberInfo(LoginName, IsRefresh);
        if (!HasLoad)
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息刷新提醒关闭失败!");
            this.RbtnDel.Checked = false;
            return;
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息刷新提醒已关闭!");
            this.RbtnDel.Checked = true;
            return;
        }
    }
}
