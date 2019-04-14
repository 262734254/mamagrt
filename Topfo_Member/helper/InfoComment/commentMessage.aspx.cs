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

public partial class helper_InfoComment_commentMessage : System.Web.UI.Page
{
    int infoId;
    string loginname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name != null && Page.User.Identity.Name.Trim() != "")
        {
            this.txtName.Value = Page.User.Identity.Name.Trim();
            divLogin.Style.Add("display", "none");

        }
        else
        {
            divLogin.Style.Add("display", "block");
        }
        if (Request.QueryString["infoId"] != null && Request.QueryString["infoId"].ToString() != "")
        {
            infoId = Convert.ToInt32(Request.QueryString["infoId"]);

            long i = 1;
            long j = 1;
            long k = 1;
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            string strWhere = "infoId='" + infoId + "'";
            DataTable dt = dal.GetList("maininfoTab", "loginName", "loginName,infoTypeID", strWhere, "loginName", ref i, k, ref j);

            if (dt != null && dt.Rows.Count > 0)
            {
                loginname = dt.Rows[0][0].ToString();
                string infotype = dt.Rows[0][1].ToString().Trim();
                //switch (infotype)
                //{
                //    case "Capital":
                //        h1.InnerText = "给投资方留言";
                //        break;
                //    case "Project":
                //        h1.InnerText = "给项目方留言";
                //        break;
                //    case "Merchant":
                //        h1.InnerText = "给招商机构留言";
                //        break;
                //    default:
                //        break;
                //}
                Tz888.BLL.LeaveMsg lvBll = new Tz888.BLL.LeaveMsg();
                int count = lvBll.GetCount(infoId);
                string countModel = "<a href=\"http://member.topfo.com/helper/InfoComment/CommentForeList.aspx?id={0}\" target=\"_blank\">共有留言<span class=\"orange01\">{1}</span>条</a>";
                if (count > 0)
                    this.ltCount.Text = string.Format(countModel, infoId.ToString(), count.ToString());
                else
                    this.ltCount.Text = "";
            }

        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string commentName = "";
        if (this.txtName.Value.Trim() == "")
        {
            commentName = "游客";
            //Response.Write("<script>alert('姓名不能为空')</script>");
        }
        else
        {
            commentName = this.txtName.Value.Trim();
        }
        if (this.txtComment.Value.Trim() == "")
        {
            Response.Write("<script>alert('评论不能为空')</script>");
        }
        else
        {
            Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            model.CommentTime = DateTime.Now;
            model.InfoID = infoId;
            model.FatherID = 0;
            model.CommentContent = this.txtComment.Value;
            //model.LoginName = loginname;
            model.LoginName = commentName;
            bool result = msgBll.SetResponse(model);
            Response.Write("<script>alert('留言成功')</script>");

            this.txtComment.Value = "";
            this.txtEmail.Value = "";
            this.txtName.Value = "";
            this.txtTel.Value = "";
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        this.txtComment.Value = "";
        this.txtEmail.Value = "";
        this.txtName.Value = "";
        this.txtTel.Value = "";
    }
}
