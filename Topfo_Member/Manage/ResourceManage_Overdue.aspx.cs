﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ResourceManage_Overdue : Tz888.Common.Pager.BasePage
{
    private string remindModel = "您共有 <span class='hong'>{0}</span> 条{1}的需求";
    private int _myPageSize = 10;
    private string _criteria;
    private const string CON_LoginName = "liyanlili";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        PagerBase = this.Pager1;
        RepeaterBase = this.RfList;
        this.SetPagerParameters();
        if (!IsPostBack)
        {
            this.BindInfoType();
            this.Pager1.DataBind();
        }
        this.btnDelete.Attributes.Add("onclick", "return confirm('这将不可恢复，真的要删除吗？');");
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

    private void BindInfoType()
    {
        ListItem li1 = new ListItem("所有需求", "All");
        this.ddlInfoType.Items.Add(li1);
        ListItem li2 = new ListItem("投资需求", "Capital");
        this.ddlInfoType.Items.Add(li2);
        ListItem li3 = new ListItem("政府招商", "Merchant");
        this.ddlInfoType.Items.Add(li3);
        ListItem li4 = new ListItem("融资需求", "Project");
        this.ddlInfoType.Items.Add(li4);
        ListItem li5 = new ListItem("创业需求", "CarveOut");
        this.ddlInfoType.Items.Add(li5);
        ListItem li6 = new ListItem("商机", "Oppor");
        this.ddlInfoType.Items.Add(li6);
        this.ddlInfoType.SelectedIndex = 0;
    }

    protected void RfList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ListItemType objItemType = e.Item.ItemType;

        if (objItemType == ListItemType.Item || objItemType == ListItemType.AlternatingItem)
        {
            //DataRowView drvData = (DataRowView)e.Item.DataItem;
            //HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");

            //string InfoOriginRoleName = drvData["InfoOriginRoleName"].ToString().Trim();
            //string MemberGradeID = drvData["MemberGradeID"].ToString().Trim();
            //string Title = "";
            //switch (InfoOriginRoleName)
            //{
            //    case "0":
            //        if (MemberGradeID == "1001")
            //            Title += "<font color='#FF9933'>[会员]</font>";
            //        else
            //            Title += "<img src='http://www.topfo.com/Web13/images/home/tfzs.gif' border='0' alt='拓富通会员'></img>";
            //        break;
            //    case "1":
            //        Title += "<font color='#FF00CC'>[分站]</font>";
            //        break;
            //    default:
            //        break;
            //}
            //hlTitle.Text = drvData["Title"].ToString() + Title;
            //if (drvData["HtmlFile"] != null && !string.IsNullOrEmpty(drvData["HtmlFile"].ToString().Trim()))
            //    hlTitle.NavigateUrl = Tz888.Common.Common.GetWWWDomain() + @"/" + drvData["HtmlFile"].ToString();
            //else
            //    hlTitle.NavigateUrl = "./CapitalModify.aspx?id=" + drvData["InfoID"].ToString();

            //hlTitle.Target = "_blank";
        }
    }

    private void SetPagerParameters()
    {
        if (ViewState["MyPageSize"] != null)
            this._myPageSize = Convert.ToInt32(ViewState["MyPageSize"]);
        else
            ViewState["MyPageSize"] = this._myPageSize;

        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;

        if (ViewState["Criteria"] == null)
        {
            this._criteria = "LoginName = '" + loginName + "' And InfoOriginRoleName = '0' And DelStatus <> 1 And OverdueFlag = 1"+" and InfoTypeID in ('Merchant','Project','Capital','CarveOut','Oppor')";
            ViewState["Criteria"] = this._criteria;
        }
        else
            this._criteria = ViewState["Criteria"].ToString();

        this.Pager1.PageSize = this._myPageSize;
        this.Pager1.StrWhere = this._criteria;
        this.Pager1.TableViewName = "MainInfoVIW";
        this.Pager1.SelectColumns = "*";
        this.Pager1.SortColumn = "PublishT";
        this.Pager1.SortType = Tz888.Common.Pager.SortType.DESC;
    }

    protected int GetCount(Tz888.BLL.Common.AuditStatus Type)
    {
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        return bll.GetCount(Type, loginName, "0");
    }


    protected string GetRemind()
    {
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;
        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        return bll.GetRemind(loginName,"0" ,this.remindModel, Tz888.BLL.Common.AuditStatus.Overdue);
    }

    protected void lbtn10_Click(object sender, EventArgs e)
    {
        this.ViewState["MyPageSize"] = 10;
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
    protected void lbtn20_Click(object sender, EventArgs e)
    {
        this.ViewState["MyPageSize"] = 20;
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
    protected void lbtn30_Click(object sender, EventArgs e)
    {
        this.ViewState["MyPageSize"] = 30;
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;
        this._criteria = "LoginName = '" + loginName + "' And InfoOriginRoleName = '0' And DelStatus <> 1 And OverdueFlag = 1";
        if (!string.IsNullOrEmpty(this.txtConditions.Text.Trim()))
            this._criteria += " And Title like '%" + this.txtConditions.Text.Trim() + "%'";
        if (this.ddlInfoType.SelectedValue.Trim().ToLower() != "all")
            this._criteria += " And InfoTypeID = '" + this.ddlInfoType.SelectedValue.Trim() + "'";
        this.ViewState["Criteria"] = this._criteria;
        this.SetPagerParameters();
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

    protected string GetAuditingStatusDesc(int AuditingStatus)
    {
        string request = "";
        switch (AuditingStatus)
        {
            case 0:
                request = "未审核";
                break;
            case 1:
                request = "审核通过";
                break;
            case 2:
                request = "审核未通过";
                break;
            default:
                request = "未知";
                break;
        }
        return request;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string[] values = Request.Form.GetValues("cbxSelect");
        string msg = "";
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;
        if (values == null || values.Length < 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择要删除的资源!");
            return;
        }

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        foreach (string str in values)
        {
            long InfoID = Convert.ToInt64(str);
            int ErrorID = 0;
            string ErrorMsg = "";
            if (!bll.UserDelete(InfoID, loginName, ref ErrorID, ref ErrorMsg))
                msg += "[" + InfoID.ToString() + "]删除失败！" + ErrorMsg + "\n";
        }
        if (!string.IsNullOrEmpty(msg))
            Tz888.Common.MessageBox.Show(this.Page, msg);
        this.SetPagerParameters();
        this.Pager1.DataBind();
    }
}
