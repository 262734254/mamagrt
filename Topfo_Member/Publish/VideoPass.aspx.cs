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

public partial class VideoPass : System.Web.UI.Page
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
            ViewState["Criteria"] = "AuditingStatus=1 and LoginName='" + Page.User.Identity.Name.ToString() + "'";//通过审核的视频
            this.AspNetPager.CurrentPageIndex = 1;
            this.AspNetPager.PageSize = 10;
            this.ViewState["TotalNumCount"] = 1; 
            this.ViewState["SortBy"] = "";
            
            GetInfoVideo();
        }
        if (Request.RawUrl.IndexOf("?op=del") > 0)
        {
            BathchDelete();
        }
    }

    #region 批量删除
    private void BathchDelete()
    {
        string idLst = Request.Form["chk"];
        if (idLst.Length > 0)
        {
            Tz888.BLL.TPVideo bllobj = new Tz888.BLL.TPVideo();
            string[] lst = idLst.Split(',');
            for (int i = 0; i < lst.Length; i++)
            {
                Tz888.SQLServerDAL.TPVideo tpobj = new Tz888.SQLServerDAL.TPVideo();
                DataSet ds = tpobj.GetOneVideoMess(lst[i].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        string strHtmlURL = ds.Tables[0].Rows[0]["HtmlURL"].ToString();
                        Tz888.Common.FileManage.FileDelete(strHtmlURL);
                    }
                    catch { }
                }
            }

            bool isSuccess = false;
            isSuccess = bllobj.DeleteVideoMess(idLst);

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

    #region 获取视频
    private void GetInfoVideo()
    {
        long CurrentPage = Convert.ToInt64(this.AspNetPager.CurrentPageIndex);
        long PageNum = Convert.ToInt64(this.AspNetPager.PageSize);
        long TotalCount = 0;
        long PageCount = 1;
        string MerchantDomain = (string)ConfigurationManager.AppSettings["MerchantDomain"];
        Tz888.BLL.TPVideo srvSI = new Tz888.BLL.TPVideo();

        DataSet ds = srvSI.dsGetVideoMess("*", ViewState["Criteria"].ToString(), "publishT desc", CurrentPage, PageNum, out TotalCount);
        DataTable dtdata = MakeTable();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DataRow drs = dtdata.NewRow();
            drs["InfoID"] = dr["InfoID"].ToString();
            drs["href"] = MerchantDomain + "/videodetails.aspx?id=" + dr["InfoID"].ToString(); 
            drs["Title"] = dr["Title"].ToString();
            drs["GradeID"] = dr["GradeID"].ToString();
            drs["publishT"] = dr["publishT"].ToString();
            drs["LoginName"] = dr["LoginName"].ToString();
            drs["Origin"] = dr["Origin"].ToString();
            drs["IsCore"] = dr["IsCore"].ToString();
            drs["AuditingStatusDesc"] = dr["AuditingStatusDesc"].ToString();
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
        DataTable namesTable = new DataTable("videoTable");

        // 添加行

        DataColumn InfoIDColumn = new DataColumn();
        InfoIDColumn.DataType = System.Type.GetType("System.String");
        InfoIDColumn.ColumnName = "InfoID";
        namesTable.Columns.Add(InfoIDColumn);

        DataColumn hrefColumn = new DataColumn();
        hrefColumn.DataType = System.Type.GetType("System.String");
        hrefColumn.ColumnName = "href";
        namesTable.Columns.Add(hrefColumn);

        DataColumn TitleColumn = new DataColumn();
        TitleColumn.DataType = System.Type.GetType("System.String");
        TitleColumn.ColumnName = "Title";
        namesTable.Columns.Add(TitleColumn);


        DataColumn LoginNameColumn = new DataColumn();
        LoginNameColumn.DataType = System.Type.GetType("System.String");
        LoginNameColumn.ColumnName = "LoginName";
        namesTable.Columns.Add(LoginNameColumn);


        DataColumn IsCoreColumn = new DataColumn();
        IsCoreColumn.DataType = System.Type.GetType("System.String");
        IsCoreColumn.ColumnName = "IsCore";
        namesTable.Columns.Add(IsCoreColumn);

        DataColumn MemberGradeIDColumn = new DataColumn();
        MemberGradeIDColumn.DataType = System.Type.GetType("System.String");
        MemberGradeIDColumn.ColumnName = "GradeID";
        namesTable.Columns.Add(MemberGradeIDColumn);

        DataColumn publishTColumn = new DataColumn();
        publishTColumn.DataType = System.Type.GetType("System.String");
        publishTColumn.ColumnName = "publishT";
        namesTable.Columns.Add(publishTColumn);

        DataColumn OriginColumn = new DataColumn();
        OriginColumn.DataType = System.Type.GetType("System.String");
        OriginColumn.ColumnName = "Origin";
        namesTable.Columns.Add(OriginColumn);


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
        GetInfoVideo();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region--删除
        if (e.CommandName == "cmdDelete")
        {
            Tz888.BLL.TPVideo bllobj = new Tz888.BLL.TPVideo();
            Tz888.SQLServerDAL.TPVideo tpobj = new Tz888.SQLServerDAL.TPVideo();

            DataSet ds = tpobj.GetOneVideoMess(e.CommandArgument.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string strHtmlURL = ds.Tables[0].Rows[0]["HtmlURL"].ToString();
                    Tz888.Common.FileManage.FileDelete(strHtmlURL);
                }
                catch { }
            }

            bool isSuccess = false;
            isSuccess = bllobj.DeleteVideoMess(e.CommandArgument.ToString());
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
        ViewState["Criteria"] = "AuditingStatus=1 and LoginName='" + Page.User.Identity.Name.ToString() + "'";
        switch (this.ddlVideoType.SelectedValue.ToString().Trim())
        { 
            case "1":
                ViewState["Criteria"] += " and Origin='原创' or Origin='转载'";
                break;
            case "2":
                ViewState["Criteria"] += " and Origin='原创'";
                break;
            case "3":
                ViewState["Criteria"] += " and Origin='转载'";
                break; 
            default:
                break;
        }

        switch (this.ddlTime.SelectedValue.ToString().Trim())
        {
            case "1":
                ViewState["Criteria"] += " and publishT >= dateadd(d,-3 ,GETDATE())";
                break;
            case "2":
                ViewState["Criteria"] += " and publishT >= dateadd(m,-1 ,GETDATE())";
                break;
            case "3":
                ViewState["Criteria"] += " and publishT >= dateadd(m,-3 ,GETDATE())";
                break;
            case "4":
                ViewState["Criteria"] += " and publishT <= dateadd(m,-3 ,GETDATE())";
                break;
            default:
                break;
        }

        switch (this.ddlKind.SelectedValue.ToString().Trim())
        {
            case "1":
                ViewState["Criteria"] += " and subTitle like '%" + this.txtKeyWord.Value.Trim() + "%'";
                break;
            case "2":
                ViewState["Criteria"] += " and Content like '%" + this.txtKeyWord.Value.Trim() + "%'";
                break;
            case "3":
                ViewState["Criteria"] += " and KeyWord like '%" + this.txtKeyWord.Value.Trim() + "%'";
                break;
            default:
                break;
        }

        GetInfoVideo();

    }
}
