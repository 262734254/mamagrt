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

public partial class helper_InfoComment_CommentForeList : System.Web.UI.Page
{
    int  infoID ;
    string loginname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_InfoComment_CommentForeList));
        if (!IsPostBack)
        {
            ViewState["pagesize"] = 10;
            ViewState["CurrPage"] = 1;
        }
        if (Page.User.Identity.Name != null && Page.User.Identity.Name.Trim() != "")
        {
            this.txtName.Text = Page.User.Identity.Name.Trim();
            divLogin.Style.Add("display", "none");

        }
        else
        {
            divLogin.Style.Add("display", "block");
        }
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString().Trim() != "")
        {
            infoID = Convert.ToInt32(Request.QueryString["id"].Trim());
            //infoID = 6612;
            //infoID = 6613;
            long i = 1;
            long j = 1;
            long k = 1;
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            string strWhere = "infoId=" + infoID + "";
            DataTable dt = dal.GetList("maininfoTab", "loginName", "loginName,infoTypeID", strWhere, "loginName", ref i, k, ref j);

            if (dt != null && dt.Rows.Count>0)
            {
                loginname = dt.Rows[0][0].ToString();
                string infotype = dt.Rows[0][1].ToString().Trim();
                switch (infotype)
                {
                    case "Capital":
                        h1.InnerText = "给投资方留言";
                        break;
                    case "Project":
                        h1.InnerText = "给项目方留言";
                        break;
                    case "Merchant":
                        h1.InnerText = "给招商机构留言";
                        break;
                    default:
                        break;
                }
                //this.lbInfoOwner.Text = loginame;
                Tz888.BLL.Conn conn = new Tz888.BLL.Conn();
                string strCondition = "";
                strCondition = "loginName='" + loginname.Trim() + "'";
                long m = 1;
                long n = 1;
                long v = 1;
                DataTable dataTable = conn.GetList("loginInfoTab", "loginName", "nickName", strCondition, "loginName", ref m, n, ref v);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    this.lbInfoOwner.Text = dataTable.Rows[0][0].ToString();
                }
            }
           getList();
        }
    }
    protected void brnRes_Click(object sender, EventArgs e)
    {
        LinkButton btn = new LinkButton();
        int Id;
        btn = (LinkButton)sender;
        Id = Convert.ToInt32(btn.CommandName.Trim());
        //Response.Redirect("commentResponse.aspx?commentId=" + Id.ToString());
        
    }
    public void getList()
    {
        string strWhere = "";

        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        strWhere = "infoId= " + infoID + " and IsAudit=1 and fatherId=0 and isdelete=0 ";
        //strWhere = "infoId= " + infoID + " and IsAudit=0  and isdelete=0 ";
        DataTable dt = dal.GetList("InfoCommentManagerVIW", "InfoID", "LoginName,InfoID,Title,CommentContent,CommentTime,ID,IsAudit,IsResponse,infoowner",
            strWhere, "CommentTime desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        if (dt != null && dt.Rows.Count > 0)
        {
            this.lbCount.Text = TotalCount.ToString();
            lblCount.Text = TotalCount.ToString();
            lblCurrPage.Text = CurrPage.ToString();
            lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
            rptCommentForeList.DataSource = dt;
            rptCommentForeList.DataBind();
        }
        else
        {
            lbCount.Text = "0";
            divcontentMain.Style.Add("display", "none");
            divmessageMain.Style.Add("display", "none");
        }

    }

    [AjaxPro.AjaxMethod]
    public string ToReply(string strtmp)
    {
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        Tz888.BLL.LeaveMsg msgBLL = new Tz888.BLL.LeaveMsg();
        string strComment = strtmp.Trim().Substring(strtmp.Trim().IndexOf("^") + 1);
        string strId = strtmp.Trim().Substring(0, strtmp.Trim().IndexOf("^")).Trim();
        model.CommentContent = strComment;
        //当前用户名称
        model.LoginName = "sunray";//Page.User.Identity.Name;
        //
        //model.InfoID = infoId;
        model.InfoID = 6612;
        model.FatherID = Convert.ToInt32(strId);
        model.CommentTime = DateTime.Now;
        bool result = msgBLL.SetResponse(model);
        return "ok";
    }

    public bool view(object  id)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "fatherId=" + id.ToString() + "";
        long i =0;
        long j = 0;
        long k = 0;
        bool result = false;
        DataTable dt = dal.GetList("infocommentTab", "id", "commentContent", strWhere, "id", ref i, k, ref j);
        if (dt != null && dt.Rows.Count > 0)
        {
            result = true;
        }
        return result;
    }
    protected void rptCommentForeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView view = e.Item.DataItem as DataRowView;//定义一个DataRowView的实例
        int id = Convert.ToInt32(view["id"]);
        this.lbInfoTitle.Text = view["title"].ToString(); 
        Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg msg = new Tz888.Model.LeaveMsg();
        Tz888.Model.LeaveMsg resMsg = new Tz888.Model.LeaveMsg();
        string result = "";
        Label lb = new Label();
        LinkButton btn = new LinkButton();

        msg = msgBll.GetComment(id, 0);
        if (msg != null)
        {
            //if (msg.IsResponse == 1)
            {
                Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
                string strWhere = "";
                strWhere = "fatherId=" + id + "";
                long i =0;
                long j = 0;
                long k = 0;
                DataTable dt = dal.GetList("infocommentTab", "id", "commentContent", strWhere, "id", ref i, k, ref j);
                System.Web.UI.HtmlControls.HtmlContainerControl divOnline = (HtmlContainerControl)e.Item.FindControl("aReply");
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = dt.Rows[0][0].ToString();

                    if (divOnline != null)
                    {
                        divOnline.Style.Add("display", "none");
                    }
                    btn = (LinkButton)e.Item.FindControl("btnRes");
                    lb = (Label)e.Item.FindControl("ResView");

                    lb.Text = result;
                }
                else
                {                 
                    if (divOnline != null)
                    {
                        divOnline.Style.Add("display", "block");
                    }
                }

            }
        }
        if (view["infoOwner"].ToString().Trim() != Page.User.Identity.Name)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl divRes = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("aReply");
            divRes.Style.Add("display", "none");
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



    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (this.txtName.Text.Trim() == "")
        {
            Response.Write("<script>alert('姓名不能为空')</script>");
        }
        if (this.txtComment.Text.Trim() == "")
        {
            Response.Write("<script>alert('评论不能为空')</script>");
        }
        else
        {
            Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            model.CommentTime = DateTime.Now;
            model.InfoID = infoID;
            model.FatherID = 0;
            model.CommentContent = this.txtComment.Text;
            //model.LoginName = loginname;
            model.LoginName = this.txtName.Text.Trim();
            bool result = msgBll.SetResponse(model);
            Response.Write("<script>alert('留言成功')</script>");

            this.txtComment.Text = "";
            this.txtEmail.Text = "";
            this.txtName.Text = "";
            this.txtTel.Text = "";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtComment.Text = "";
        this.txtEmail.Text = "";
        this.txtName.Text = "";
        this.txtTel.Text = "";
    }
}
