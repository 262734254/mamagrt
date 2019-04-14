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
using System.Drawing;


public partial class helper_InfoComment_commentReceive : Tz888.Common.Pager.BasePage
{
    private int commentFrom = 0;
    private int commentType = 4;
    public string loginname = "";
    DataTable outDataTable = null;
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_InfoComment_commentReceive));
        if (Page.User.IsInRole("GT1002"))//判断用户是否拓富通会员
        {
            panelClue.Style.Add("display", "none");
        }
        else
        {
            panelClue.Style.Add("display", "block");
        }
        if (!IsPostBack)
        {
            ViewState["pagesize"] = 10;
            ViewState["CurrPage"] = 1;
        }
        getList();

    }
    public void getList()
    {
        string strWhere = "";
        loginname = Page.User.Identity.Name;//"aaaaaa";
        loginname = "cn001";
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        switch (commentType)
        {
            case 4:  //--默认
                strWhere = "infoOwner='" + loginname + "' and fatherId= '0' and IsDelete= '0'";
                //strWhere = "loginName='" + loginname + "' and fatherId= '0'and IsDelete= '0'";
                break;
            case 0://新留言
                strWhere = "infoOwner='" + loginname + "' and fatherId= '0' and IsDelete= '0' and IsResponse= '0' and IsAudit= '0'";
                break;
            case 1: //已阅读
                strWhere = "(infoOwner='" + loginname + "' and fatherId= '0' and IsDelete= '0' and IsResponse= '1' ) or ( IsAudit!= '0'" + " and infoOwner='" + loginname
                     +"' and fatherId= '0' and IsDelete= '0')";
                break;
            case 2: //已回复
                strWhere = "infoOwner='" + loginname + "' and fatherId= '0' and IsDelete= '0' and IsResponse= '1' ";
                break;
            case 3: //已公开
                strWhere = "infoOwner='" + loginname + "' and fatherId= '0' and IsDelete= '0' and IsAudit!= '0' ";
                break;
        }
        if (ddlCommentTime.SelectedValue == "0")
        {
            strWhere += "";
        }
        else if (ddlCommentTime.SelectedValue == "91")
        {
            strWhere += " and DateDiff(d,CommentTime,getdate())>90 ";
        }
        else 
        {
            strWhere += " and DateDiff(d,CommentTime,getdate())<" + Convert.ToInt32(ddlCommentTime.SelectedValue);
        }
        if (this.txtCommentSelect.Text.Trim() != "")
        {
            strWhere += " and (CHARINDEX('" + this.txtCommentSelect.Text.Trim() + "'," + "commentContent" + ")>0)";
        }
        DataTable dt = dal.GetList("InfoCommentManagerVIW", "InfoID", "LoginName,InfoID,Title,CommentContent,CommentTime,ID,IsAudit,IsResponse",
            strWhere, "CommentTime desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        outDataTable = dt;
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        rptCommentReceive.DataSource = dt;
        rptCommentReceive.DataBind();
        if (TotalCount <= 0)
        {
            rptCommentReceive.Visible = false;
            lbMessage.Text = "您还没有收到任何留言！";
            lbMessage.Visible = true;
        }
        else
        {
            lbMessage.Visible = false;
            rptCommentReceive.Visible = true;
        }
    }
    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        getList();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        getList();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        getList();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        getList();
    }
    protected void btnGo_ServerClick(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = txtPage.Value.Trim();
        getList();
    }
    protected void PageSize10_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 10;
        PageSize10.ForeColor = System.Drawing.Color.Red;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void PageSize20_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 20;
        PageSize20.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void PageSize30_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 30;
        PageSize30.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    #region 点击查询按钮
    protected void btnCommentSelect_Click(object sender, EventArgs e)
    {
        commentFrom = Convert.ToInt32(this.ddlCommentFrom.SelectedValue);
        commentType = Convert.ToInt32(this.ddlCommentType.SelectedValue);
        getList();
    }
    #endregion


    [AjaxPro.AjaxMethod]
    public string ToRecycle(string idList)
    {
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        string userName = Page.User.Identity.Name;
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                int Id = Convert.ToInt32(s[i].Trim());
                leaveMsgBll.DeleteLeaveMsg(Id, 0);
            }
        }
        return "ok";
    }
    [AjaxPro.AjaxMethod]
    public string ToPublic(string idList)
    {
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        string userName = Page.User.Identity.Name;
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                int Id = Convert.ToInt32(s[i].Trim());
                model.CommentId = Id;
                model.IsAudit = 1;
                model.AuditMan = loginname;
                model.AuditTime = DateTime.Now;
                bool result = leaveMsgBll.PublishManageLeaveMsg(model);
            }
        }
        return "ok";
    }
    protected void rptCommentReceive_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView view = e.Item.DataItem as DataRowView;//定义一个DataRowView的实例
        int id = Convert.ToInt32(view["id"]);
        Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg msg = new Tz888.Model.LeaveMsg();
        Tz888.Model.LeaveMsg resMsg = new Tz888.Model.LeaveMsg();
        string result = "";
        Label lb = new Label();
        LinkButton btn = new LinkButton();

        msg = msgBll.GetComment(id, 0);
        if (msgBll != null)
        {
            if (msg.IsResponse == 1)
            {
                Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
                string strWhere = "";
                strWhere = "fatherId='" + id + "'";
                long i = 1;
                long j = 1;
                long k = 1;
                DataTable dt = dal.GetList("infocommentTab", "id", "commentContent", strWhere, "id", ref i, k, ref j);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = dt.Rows[0][0].ToString();
                }
                System.Web.UI.HtmlControls.HtmlGenericControl divOnline = (HtmlGenericControl)e.Item.FindControl("divResView");
                if (divOnline != null)
                {
                    divOnline.Style.Add("display", "block");
                }
                btn = (LinkButton)e.Item.FindControl("btnRes");     
                btn.Enabled = false;
            }
            else
            {
                System.Web.UI.HtmlControls.HtmlGenericControl divOnline = (HtmlGenericControl)e.Item.FindControl("divResView");
                if (divOnline != null)
                {
                    divOnline.Style.Add("display", "none");
                }
            }
        }

        lb = (Label)e.Item.FindControl("ResView");

        lb.Text = result;
        //return result;
    }

    public string status(object view)
    {
        if (view.ToString() == "0")
        {
            return "公开留言";
        }
        else
        {
            return "关闭留言";
        }

    }
    //回复显示
    public string view(object view)
    {
        int id = Convert.ToInt32(view);
        Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg msg = new Tz888.Model.LeaveMsg();
        Tz888.Model.LeaveMsg resMsg = new Tz888.Model.LeaveMsg();
        string result = "";

        //msg = msgBll.GetComment(id, 0);
        //if (msgBll != null)
        //{
        //    if (msg.IsResponse == 1)
        //    {
        //        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        //        string strWhere = "";
        //        strWhere = "fatherId='" + id + "'";
        //        long i = 1;
        //        long j = 1;
        //        long k = 1;
        //        DataTable dt = dal.GetList("infocommentTab", "id", "commentContent", strWhere, "id", ref i, k, ref j);
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            result = dt.Rows[0][0].ToString();
        //        }
        //        System.Web.UI.HtmlControls.HtmlGenericControl divOnline = (HtmlGenericControl)this.rptCommentReceive.FindControl("divResView");
        //        if (divOnline != null)
        //        {
        //            divOnline.Style.Add("display", "block");
        //        }
        //    }
        //    else
        //    {
        //        System.Web.UI.HtmlControls.HtmlGenericControl divOnline = (HtmlGenericControl)this.rptCommentReceive.FindControl("divResView");
        //        if (divOnline != null)
        //        {
        //            divOnline.Style.Add("display", "none");
        //        }
        //    }
        //}
        return result;
    }
    //回复
    protected void brnRes_Click(object sender, EventArgs e)
    {
        LinkButton btn = new LinkButton();
        int Id;
        btn = (LinkButton)sender;
        Id = Convert.ToInt32(btn.CommandName.Trim());
        Response.Redirect("commentResponse.aspx?commentId=" + Id.ToString());

    }

    protected void brnFriend_Click(object sender, EventArgs e)
    {
        LinkButton btn = new LinkButton();
        btn = (LinkButton)sender;
        loginname = btn.CommandName.Trim();

        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();

        Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
        model.LoginName = Page.User.Identity.Name;//"sunray";
        model.ContactName = loginname;
        model.GroupId = 1;
        friendBll.AddFriend(model);
        //string url="../FriendManager/addsuccess.aspx?name="+loginname;
        Response.Redirect("../FriendManager/addsuccess.aspx?name=" + loginname);
    }

    protected void brnPublic_Click(object sender, EventArgs e)
    {
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        string userName = Page.User.Identity.Name;
        LinkButton btn = new LinkButton();
        int Id;
        btn = (LinkButton)sender;
        Id = Convert.ToInt32(btn.CommandName.Trim());

        if (btn.Text.Trim() == "公开留言")
        {
            model.IsAudit = 1;
        }
        else if (btn.Text.Trim() == "关闭留言")
        {
            model.IsAudit = 0;
        }
        model.CommentId = Id;
        model.AuditMan = loginname;
        model.AuditTime = DateTime.Now;
        bool result = leaveMsgBll.PublishManageLeaveMsg(model);
        getList();
    }

    protected void brnDelete_Click(object sender, EventArgs e)
    {

        Tz888.BLL.LeaveMsg msgBLL = new Tz888.BLL.LeaveMsg();
        LinkButton btn = new LinkButton();
        int Id;
        btn = (LinkButton)sender;
        Id = Convert.ToInt32(btn.CommandName.Trim());

        bool result = msgBLL.DeleteLeaveMsg(Id, 0);//0 虚拟删除留言  1 永远删除留言
        getList();
    }
    //留言的导出
    protected void btnOut_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.DataGrid dgExport = null;
        // 当前对话 
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        // IO用于导出并返回excel文件 
        System.IO.StringWriter strWriter = null;
        System.Web.UI.HtmlTextWriter htmlWriter = null;


        // 设置编码和附件格式 
        curContext.Response.ContentType = "application/vnd.ms-excel";
        curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        curContext.Response.Charset = "";

        // 导出excel文件 
        strWriter = new System.IO.StringWriter();
        htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);


        dgExport = new System.Web.UI.WebControls.DataGrid();
        string filename = "leaveMsgReceive";
        dgExport.DataSource = outDataTable;
        dgExport.AllowPaging = false;
        dgExport.DataBind();

        // 返回客户端 
        dgExport.RenderControl(htmlWriter);
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
        curContext.Response.Write(strWriter.ToString());
        curContext.Response.End(); 
    }
    #region 设置绑定查询条件
    public void InfoCommentMakeCriteria(ref StringBuilder Criteria)
    {
        //设置绑定查询条件
        //string infoOwner = Session["LoginName"].ToString();
        string commentTime = "91";
        commentTime = this.ddlCommentTime.SelectedValue;
        if (commentType == 4)//--默认
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "infoOwner=", loginname, true, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsDelete=", "0", false, false);
            //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CommentTime", DateTime.Today.Subtract(new TimeSpan(Convert.ToInt32(commentTime), 0, 0, 0)).ToString(), DateTime.Today.ToString());
        }
        else if (commentType == 0)  //新留言  
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "infoOwner=", loginname, true, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsDelete=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsResponse=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsAudit=", "0", false, false);
            //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CommentTime", DateTime.Today.Subtract(new TimeSpan(Convert.ToInt32(commentTime), 0, 0, 0)).ToString(), DateTime.Today.ToString());
        }
        else if (commentType == 1)//已阅读 //有问题
        {
            System.Text.StringBuilder strBuild = new StringBuilder();
            string strCondition = "";
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "infoOwner=", loginname, true, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsDelete=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsAudit!=", "0", false, false);
            Tz888.Common.MakeCriteria.AddORCriteria(ref strBuild, "IsResponse=", "1", false, false);
            strCondition = strBuild.ToString();
            Tz888.Common.MakeCriteria.AddTwoCriteria(ref Criteria, strCondition, false);
            //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CommentTime", DateTime.Today.Subtract(new TimeSpan(Convert.ToInt32(commentTime), 0, 0, 0)).ToString(), DateTime.Today.ToString());
        }
        else if (commentType == 2) //已回复  
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "infoOwner=", loginname, true, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsResponse=", "1", false, false);
            //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CommentTime", DateTime.Today.Subtract(new TimeSpan(Convert.ToInt32(commentTime), 0, 0, 0)).ToString(), DateTime.Today.ToString());

        }
        else if (commentType == 3)//已公开
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "infoOwner=", loginname, true, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsAudit=", "1", false, false);
            //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CommentTime", DateTime.Today.Subtract(new TimeSpan(Convert.ToInt32(commentTime), 0, 0, 0)).ToString(), DateTime.Today.ToString());
        }
        //Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "fatherId", "0", true, true);
        //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "ReceivedTime", DateTime.Today.Subtract(new TimeSpan(timeSpan, 0, 0, 0)).ToString(), DateTime.Today.ToString());
    }
    #endregion



    #region 公开关闭留言
    void btnPublish_Click(object sender, EventArgs e)
    {
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        Tz888.BLL.LeaveMsg msgBLL = new Tz888.BLL.LeaveMsg();
        Button btn = new Button();
        string commentId = "";
        btn = (Button)sender;
        commentId = btn.ID.Substring(btn.ID.LastIndexOf("_") + 1);

        if (btn.Text.Trim() == "公开留言")
        {
            model.IsAudit = 1;
            //btn.Text = "关闭留言";
            Response.Write("<script   language=javascript>alert('公开此留言！');</script>");
        }
        else
        {
            model.IsAudit = 0;
            //btn.Text = "发布留言";
            Response.Write("<script   language=javascript>alert('关闭此留言！');</script>");
        }

        model.CommentId = Convert.ToInt32(commentId);
        //model.AuditMan = Session["loginName"];
        model.AuditMan = loginname;
        model.AuditTime = DateTime.Now;
        bool result = msgBLL.PublishManageLeaveMsg(model);

        //getList();
        Response.Redirect("commentReceive.aspx");
    }
    #endregion

    #region 点击条目的删除按钮
    void btnDelete_Click(object sender, EventArgs e)
    {
        Tz888.BLL.LeaveMsg msgBLL = new Tz888.BLL.LeaveMsg();
        Button btn = new Button();
        string commentId = "";
        btn = (Button)sender;
        commentId = btn.ID.Substring(btn.ID.LastIndexOf("_") + 1);

        bool result = msgBLL.DeleteLeaveMsg(Convert.ToInt32(commentId), 0);//0 虚拟删除留言  1 永远删除留言
        getList();
    }
    #endregion

    #region 点击回复按钮
    void btnRes_Click(object sender, EventArgs e)
    {
        getList();
        Button btnRes = new Button();
        //Panel panelResponse = new Panel();
        btnRes = (Button)sender;
        string btnSubName = "";
        btnSubName = btnRes.ID.Substring(btnRes.ID.IndexOf("_") + 1);

        TextBox tbText = new TextBox();
        tbText = (TextBox)btnRes.Parent.FindControl("txtRes_" + btnSubName);
        tbText.Visible = true;

        Button btn = new Button();
        btn = (Button)btnRes.Parent.FindControl("btnResOk_" + btnSubName);
        btn.Visible = true;

        Button btnCancel = new Button();
        btnCancel = (Button)btnRes.Parent.FindControl("btnResCancel_" + btnSubName);
        btnCancel.Visible = true;

        tbText.Focus();
    }
    #endregion

    #region 点击确认按钮
    void btnResOk_Click(object sender, EventArgs e)
    {
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        Tz888.BLL.LeaveMsg msgBLL = new Tz888.BLL.LeaveMsg();
        Button btn = new Button();
        string infoId = "";
        string commentId = "";
        btn = (Button)sender;
        string btnSubName = btn.ID.Substring(btn.ID.IndexOf("_") + 1);
        TextBox tbText = new TextBox();
        tbText = (TextBox)btn.Parent.FindControl("txtRes_" + btnSubName);



        infoId = btn.ID.Substring(btn.ID.IndexOf("_") + 1, btn.ID.LastIndexOf("_") - btn.ID.IndexOf("_") - 1);
        commentId = btn.ID.Substring(btn.ID.LastIndexOf("_") + 1);

        model.CommentContent = tbText.Text;
        //当前用户名称
        model.LoginName = loginname;
        //
        model.InfoID = Convert.ToInt32(infoId);
        model.FatherID = Convert.ToInt32(commentId);
        model.CommentTime = DateTime.Now;

        bool result = msgBLL.SetResponse(model);

        //Response.Redirect("commentReceive.aspx");
        Response.Redirect("commentReceive.aspx?infoId=" + infoId + "&commentId=" + commentId + "&content=" + tbText.Text);
    }
    #endregion

    #region 点击取消按钮
    void btnResCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("commentReceive.aspx");
    }
    #endregion

    #region 点击全体删除按钮
    protected void btnDeleteSelect_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lb;
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        for (int i = 0; i < this.rptCommentReceive.Items.Count; i++)
        {
            chk = (CheckBox)this.rptCommentReceive.Items[i].FindControl("chkCommentSelect");
            lb = (Label)this.rptCommentReceive.Items[i].FindControl("lbCommentID");
            if (chk.Checked)
            {
                leaveMsgBll.DeleteLeaveMsg(Convert.ToInt32(lb.Text), 0);
            }
        }
        getList();
    }
    #endregion



    #region  群公开留言
    protected void btnPublist_Click(object sender, EventArgs e)
    {
        CheckBox chk;
        Label lb;
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        for (int i = 0; i < this.rptCommentReceive.Items.Count; i++)
        {
            chk = (CheckBox)this.rptCommentReceive.Items[i].FindControl("chkCommentSelect");
            lb = (Label)this.rptCommentReceive.Items[i].FindControl("lbCommentID");
            if (chk.Checked)
            {
                model.CommentId = Convert.ToInt32(lb.Text.Trim());
                //model.AuditMan = Session["loginName"];
                model.AuditMan = loginname;
                model.AuditTime = DateTime.Now;
                bool result = leaveMsgBll.PublishManageLeaveMsg(model);
            }
        }
    }
    public string GetStr(object str, int length)
    {
        if (str.ToString().Length > length)
        {
            return str.ToString().Substring(0, length) + "……";
        }
        else
        {
            return "";
        }
    }
    #endregion



}
