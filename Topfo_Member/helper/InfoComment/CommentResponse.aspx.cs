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

public partial class helper_InfoComment_CommentResponse : System.Web.UI.Page
{
    private int infoId;
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
        string strWhere = "";
        
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        if (Request.QueryString["commentId"] != null && Request.QueryString["commentId"].ToString().Trim() != "")
        {
            long i = 1;
            long j = 1;
            strWhere = "id= ' " + Request.QueryString["commentId"].ToString().Trim() + " '";
            DataTable dt = dal.GetList("InfoCommentManagerVIW", "InfoID", "LoginName,InfoID,Title,CommentContent",
                strWhere, "CommentTime desc", ref i, 1, ref j);
            if (dt != null)
            {
                this.commentName.Text = dt.Rows[0][0].ToString();
                infoId = Convert.ToInt32(dt.Rows[0][1]);
                this.commentTile.Text = dt.Rows[0][2].ToString();
                this.commentText.Text = dt.Rows[0][3].ToString();
            }
            this.commentRes.Focus();

        }
    }
    protected void btnRes_Click(object sender, EventArgs e)
    {

        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        Tz888.BLL.LeaveMsg msgBLL = new Tz888.BLL.LeaveMsg();
        model.CommentContent = this.commentRes.Text;
        //当前用户名称
        model.LoginName = Page.User.Identity.Name;//"sunray";
        //
        model.InfoID = infoId;
        model.FatherID = Convert.ToInt32(Request.QueryString["commentId"]);
        model.CommentTime = DateTime.Now;
        bool result=msgBLL.SetResponse(model);
        Response.Redirect("CommentReceive.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CommentReceive.aspx");
    }
}
