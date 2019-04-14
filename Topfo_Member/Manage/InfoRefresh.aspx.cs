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


/*
 * ValidateStartTime 生效时间
 * FrontDisplayTime 资源前台展示排序时间
 * 
 * 
 * 
 * 
 * 
 * 
*/

public partial class Manage_InfoRefresh : System.Web.UI.Page
{
    long intCurrentPage = 1;
    long intCurrentPageSize = 1;
    long intTotalCount = 0;
    protected string InfoType = "All";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }

        if (ViewState["InfoType"] == null)
        {
            if (Page.Request.QueryString["type"] != null)
            {
                this.InfoType = Page.Request.QueryString["type"].ToString().Trim();
                if (this.InfoType != "All" && this.InfoType != "Merchant" 
                            && this.InfoType != "Capital" && this.InfoType != "Project"
                            && this.InfoType != "Carveout" && this.InfoType != "Oppor")
                    this.InfoType = "All";
            }
            else
                this.InfoType = "All";
            ViewState["InfoType"] = this.InfoType;
        }
        else
        {
            this.InfoType = ViewState["InfoType"].ToString();
        }

        if (!IsPostBack)
        {
            Tz888.BLL.Login.MemberBLL bll = new Tz888.BLL.Login.MemberBLL();

            string LoginName = Page.User.Identity.Name;
            //string LoginName = "liyanlili";

            string strCriteria = "LoginName='" + LoginName + "'";
            DataView dv = bll.GetMerberInfo("LoginName,IsRefresh", strCriteria, "", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);
            if (dv == null || dv.Table.Rows.Count == 0)
            {
                //Tz888.Common.MessageBox.Show(this.Page, "已经设置为：以后不再提醒！");
                Tz888.Common.MessageBox.Show(this.Page, "用户信息异常!");
                //this.Page.Response.Flush();
                //this.Page.Response.End();
                return;
            }
            int strDayMsg = Convert.ToInt32(dv.Table.Rows[0]["IsRefresh"]);
            if (strDayMsg == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "当前设置为不提醒!");
            }
            else
            {
                ViewState["InfoType"] = InfoType;
                RefreshList();
            }
        }
    }

    public void RefreshList()
    {
        Tz888.BLL.Login.MemberBLL bll = new Tz888.BLL.Login.MemberBLL();
        this.InfoType = ViewState["InfoType"].ToString();
        string LoginName = Page.User.Identity.Name;
        //string LoginName = "heyi";
        dlrefresh.DataSource = bll.GetRefreshList(LoginName, this.InfoType);
        dlrefresh.DataBind();
    }
    protected void dlrefresh_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item ||
            objItemType == ListItemType.AlternatingItem)
        {
            string strTitle = "";
            string strString = "";
            DataRowView drvData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            Label lblInfo = (Label)e.Item.FindControl("lblInfo");
            CheckBox chkSelect = (CheckBox)e.Item.FindControl("chkSelect");
            strString = drvData["Title"].ToString().Trim();
            strTitle = strString;
            lblInfo.Text = drvData["InfoID"].ToString().Trim();
            lnkTitle.Text = strTitle.ToString().Trim();
            lnkTitle.ToolTip = drvData["Title"].ToString().Trim();
            lnkTitle.NavigateUrl = @"/" + drvData["HtmlFile"].ToString().Trim();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (chkRefreshMsg.Checked == true)
        {
            Tz888.BLL.Login.MemberBLL bll = new Tz888.BLL.Login.MemberBLL();
            string LoginName = Page.User.Identity.Name;
            //string LoginName = "heyi";
            int IsRefresh = 0;
            bool HasLoad = bll.RefreshMemberInfo(LoginName, IsRefresh);
            if (!HasLoad)
            {
                Tz888.Common.MessageBox.Show(this.Page, "没有找到您需要的数据！");
                return;
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "已经设置为：以后不再提醒！");
                btnClose.Visible = true;
                return;
            }
        }
        else
        {
            int intSelect = 0;
            int intSuccess = 0;
            CheckBox chkSelect;
            Label lblInfo;
            Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();

            for (int i = 0; i < dlrefresh.Items.Count; i++)
            {
                chkSelect = (CheckBox)dlrefresh.Items[i].FindControl("chkSelect");
                lblInfo = (Label)dlrefresh.Items[i].FindControl("lblInfo");
                if (chkSelect.Checked)
                {
                    intSelect++;
                    //将选中的信息的时间更新为此刻时间
                    long InfoID = Convert.ToInt64(lblInfo.Text.Trim());
                    if (bll.UpdateRefresh(InfoID))
                        intSuccess++;
                }
            }
            if (intSelect.ToString().Trim() == "0")
            {
                Tz888.Common.MessageBox.Show(this.Page, "您没有选择信息！");
                return;
            }
            else
            {
                //报告操作成功
                Tz888.Common.MessageBox.Show(this.Page, "选择信息" + intSelect.ToString() + "条，实际更新 " + intSuccess.ToString() + "条");
            }
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.close();</script>");
    }
}
