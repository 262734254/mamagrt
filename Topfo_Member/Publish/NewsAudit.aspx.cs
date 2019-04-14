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


public partial class NewsAudit : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
        Page.MasterPageFile = "../indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "~/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == "")
        {
            Response.Redirect("../Login.aspx");
        }

 
        if (!IsPostBack)
        {
            //ViewState["Criteria"] = "AuditingStatus=0 and LoginName='huangleon'";
            ViewState["Criteria"] = "AuditingStatus=0 and LoginName='" + Page.User.Identity.Name.ToString() + "'";//审核中的资讯
            this.AspNetPager.CurrentPageIndex = 1;
            this.AspNetPager.PageSize = 10;
            this.ViewState["TotalNumCount"] = 1;
            this.ViewState["SortBy"] = "";
            
            GetInfoNews();
            GetNewsType();
        }
        if (Request.RawUrl.IndexOf("?op=del") > 0)
        {
            BathchDelete();
        }
    }

    #region 获取资讯类型
    private void GetNewsType()
    {
        Tz888.SQLServerDAL.TPMerchant Newsobj = new Tz888.SQLServerDAL.TPMerchant();
        DataSet ds = Newsobj.GetNewsType();
        this.ddlType.DataSource = ds;
        this.ddlType.DataBind();
        ListItem li = new ListItem();
        li = new ListItem("资讯类型", "资讯类型");
        ddlType.Items.Add(li);
        ddlType.Items[ddlType.Items.Count - 1].Selected = true;
    }
    #endregion
    #region 批量删除
    private void BathchDelete()
    {
        string idLst = Request.Form["chk"];
        if (idLst.Length > 0)
        {
            Tz888.BLL.TPMerchant bllobj = new Tz888.BLL.TPMerchant();
            bool isSuccess = false;
            isSuccess = bllobj.DeleteMerchantNews(idLst);

            if (isSuccess)
            {
                Response.Redirect(Request.RawUrl.Substring(0, Request.RawUrl.IndexOf("?")));
            }
            else
            {
                Response.Write("<script>alert('部分删除操作失败。'); </script>");
            }

        }
    }

    #endregion

    #region 获取资讯
    private void GetInfoNews()
    {
        string strCriteria = ViewState["Criteria"].ToString();
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;

        Tz888.BLL.TPMerchant srvSI = new Tz888.BLL.TPMerchant();

        DataSet ds = srvSI.dsGetNewsList("*", strCriteria, "publishT desc", CurrentPage, PageNum, out TotalCount);
        DataTable dtdata = MakeTable();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DataRow drs = dtdata.NewRow();
            drs["InfoID"] = dr["InfoID"].ToString(); 
            drs["Title"] = dr["Title"].ToString();
            drs["Pic1"] = dr["Pic1"].ToString();
            drs["MemberGradeID"] = dr["MemberGradeID"].ToString();
            drs["publishT"] = dr["publishT"].ToString();
            drs["IsCore"] = dr["IsCore"].ToString();
            drs["NewsTypeName"] = dr["NewsTypeName"].ToString();
            drs["LoginName"] = dr["LoginName"].ToString();
            drs["AuditingStatusDesc"] = dr["AuditingStatusDesc"].ToString();
            if (dr["NewsTypeID"].ToString().Trim() == "67")
            {
                drs["strHref"] = "UpdateNews2.aspx?id=" + dr["InfoID"].ToString(); 
            }
            else
            {
                drs["strHref"] = "UpdateNews.aspx?id=" + dr["InfoID"].ToString();
            }
            dtdata.Rows.Add(drs);
        }
        this.AspNetPager.RecordCount = Convert.ToInt32(TotalCount);
        GridView1.DataSource = dtdata.DefaultView;

        this.GridView1.DataBind();
        if (TotalCount % PageNum > 0)
            PageCount = TotalCount / PageNum + 1;
        else
            PageCount = TotalCount / PageNum;

        this.pinfo.InnerText = "共" + PageCount + "页";
        this.LblCount.Text = TotalCount.ToString();


        if (ds.Tables[0].Rows.Count <= 0)
        {
            this.NoMessage.Style.Value = "display:block";
            this.dvCheck.Style.Value = "display:none";
            this.pinfo2.Style.Value = "display:none";
        }
        else
        {
            this.NoMessage.Style.Value = "display:none";
            this.dvCheck.Style.Value = "display:block";
            this.pinfo2.Style.Value = "display:block";
        }

    }
    #endregion

    #region 临时表
    private DataTable MakeTable()
    {
        // 创建一个新表
        DataTable namesTable = new DataTable("NewsTable");

        // 添加行

        DataColumn InfoIDColumn = new DataColumn();
        InfoIDColumn.DataType = System.Type.GetType("System.String");
        InfoIDColumn.ColumnName = "InfoID";
        namesTable.Columns.Add(InfoIDColumn);

        DataColumn TitleColumn = new DataColumn();
        TitleColumn.DataType = System.Type.GetType("System.String");
        TitleColumn.ColumnName = "Title";
        namesTable.Columns.Add(TitleColumn);


        DataColumn Pic1Column = new DataColumn();
        Pic1Column.DataType = System.Type.GetType("System.String");
        Pic1Column.ColumnName = "Pic1";
        namesTable.Columns.Add(Pic1Column);

        DataColumn LoginNameColumn = new DataColumn();
        LoginNameColumn.DataType = System.Type.GetType("System.String");
        LoginNameColumn.ColumnName = "LoginName";
        namesTable.Columns.Add(LoginNameColumn);

        DataColumn MemberGradeIDColumn = new DataColumn();
        MemberGradeIDColumn.DataType = System.Type.GetType("System.String");
        MemberGradeIDColumn.ColumnName = "MemberGradeID";
        namesTable.Columns.Add(MemberGradeIDColumn);

        DataColumn publishTColumn = new DataColumn();
        publishTColumn.DataType = System.Type.GetType("System.String");
        publishTColumn.ColumnName = "publishT";
        namesTable.Columns.Add(publishTColumn);

        DataColumn IsCoreColumn = new DataColumn();
        IsCoreColumn.DataType = System.Type.GetType("System.String");
        IsCoreColumn.ColumnName = "IsCore";
        namesTable.Columns.Add(IsCoreColumn);

        DataColumn strHrefColumn = new DataColumn();
        strHrefColumn.DataType = System.Type.GetType("System.String");
        strHrefColumn.ColumnName = "strHref";
        namesTable.Columns.Add(strHrefColumn);


        DataColumn NewsTypeIDColumn = new DataColumn();
        NewsTypeIDColumn.DataType = System.Type.GetType("System.String");
        NewsTypeIDColumn.ColumnName = "NewsTypeID";
        namesTable.Columns.Add(NewsTypeIDColumn);

        DataColumn NewsTypeNameColumn = new DataColumn();
        NewsTypeNameColumn.DataType = System.Type.GetType("System.String");
        NewsTypeNameColumn.ColumnName = "NewsTypeName";
        namesTable.Columns.Add(NewsTypeNameColumn);

        DataColumn AuditingStatusDescColumn = new DataColumn();
        AuditingStatusDescColumn.DataType = System.Type.GetType("System.String");
        AuditingStatusDescColumn.ColumnName = "AuditingStatusDesc";
        namesTable.Columns.Add(AuditingStatusDescColumn);
        //返回
        return namesTable;
    }
    #endregion 

    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        GetInfoNews();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region--删除
        if (e.CommandName == "cmdDelete")
        {
            Tz888.BLL.TPMerchant bllobj = new Tz888.BLL.TPMerchant();
            bool isSuccess = false;
            isSuccess = bllobj.DeleteMerchantNews(e.CommandArgument.ToString());
            if (isSuccess)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Response.Write("<script>alert('对编号为" + e.CommandArgument.ToString() + "的删除操作失败。'); </script>");
                return;
            }
        }
        #endregion
    }
 
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder strCriteria = new System.Text.StringBuilder();
        strCriteria.Append("AuditingStatus=0 and LoginName='" + Page.User.Identity.Name.ToString() + "'"); 
        if (this.txtKeyWord.Value.Trim() != "" && this.ddlKind.SelectedValue == "1")
            strCriteria.Append(" and Title like  '%" + this.txtKeyWord.Value.Trim() + "%' or Content like '%" + this.txtKeyWord.Value.Trim() + "%' or KeyWord like '%" + this.txtKeyWord.Value.Trim() + "%'");
        if (this.txtKeyWord.Value.Trim() != "" && this.ddlKind.SelectedValue == "2")
            strCriteria.Append(" and Title like '%" + this.txtKeyWord.Value.Trim() + "%'");

        switch (this.ddlTime.SelectedValue.ToString().Trim())
        {
            case "1":
                strCriteria.Append(" and publishT >= dateadd(d,-3 ,GETDATE())");
                break;
            case "2":
                strCriteria.Append(" and publishT >= dateadd(m,-1 ,GETDATE())");
                break;
            case "3":
                strCriteria.Append(" and publishT >= dateadd(m,-3 ,GETDATE())");
                break;
            case "4":
                strCriteria.Append(" and publishT <= dateadd(m,-3 ,GETDATE())");
                break;
            default:
                break;
        }
        if (this.ddlType.SelectedValue.ToString().Trim() != "资讯类型")
        {
            strCriteria.Append(" and NewsTypeID=" + this.ddlType.SelectedValue.ToString().Trim());
        }

        ViewState["Criteria"] = strCriteria.ToString();
        GetInfoNews();

    }
}
