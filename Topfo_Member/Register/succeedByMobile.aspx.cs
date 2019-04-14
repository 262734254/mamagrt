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
using Tz888.BLL.Register;
using Tz888.SQLServerDAL.Register;

public partial class Register_succeedByMobile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["RePwdName"] == null)
                {
                    Response.Write("<script>alert('页面已过期！');location.href='RetrieveStep1.aspx';</script>");
                }
                if (Session["Proofpwd"] == null || Session["Proofpwd"].ToString() == string.Empty)
                {
                    Response.Redirect("<script>alert('连接超时或会话已结束,请重新申请找回！');location.href='RetrieveStep1.aspx");
                }
            }
            catch
            {
                Response.Redirect("<script>alert('连接超时或会话已结束,请重新申请找回！');location.href='RetrieveStep1.aspx");
            }
        }
    }

    //通过用户名获取邮箱
    private string GetEmailByLoginName()
    {
        string strEmail = "";
        MemberInfoDAL obj = new MemberInfoDAL();
        strEmail = obj.GetEmail(Request.Cookies["RePwdName"].Value.ToString());
        return strEmail;
    }

    protected void BtnConfirm_Click(object sender, EventArgs e)
    { 
        string name = Request.Cookies["RePwdName"].Value.ToString();
        if (Session["Proofpwd"].ToString() == this.TxtProof.Text.Trim().ToString())
        {
            Response.Redirect("RepeatSetPassword.aspx");
        }
        else
        {
            Response.Redirect("RetrieveStep8.aspx");
        }
}

}
