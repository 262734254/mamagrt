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
using Tz888.SQLServerDAL.Register;
using Tz888.BLL.Register;

public partial class Register_RetrieveStep8 : System.Web.UI.Page
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
            }
            catch
            {
                Response.Write("<script>alert('页面已过期！');location.href='RetrieveStep1.aspx';</script>");
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

    protected void BtnConfirmMoible_Click(object sender, EventArgs e)
    { 
        string name = Request.Cookies["RePwdName"].Value.ToString();
        MemberInfoDAL obj = new MemberInfoDAL();
        if (Session["Proofpwd"].ToString() == this.TxtProof.Text.Trim().ToString())
        {
             Response.Redirect("RepeatSetPassword.aspx");
        }
        else
        {  
            this.LblMessage.Text = "验证码错误,请重试!";
        }
       
    }
}
