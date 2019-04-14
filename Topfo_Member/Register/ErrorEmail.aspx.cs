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


public partial class Register_ErrorEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LblEmail.Text = Request.QueryString["Email"].ToString();
        }
    }
    private string GetLoginNameByEmail()
    {
        string strLoginName = "";
        string strEmail = txtEmail.Text.ToString().Trim();
        MemberInfoDAL obj = new MemberInfoDAL();
        strLoginName = obj.GetLoginNameByEmail(strEmail);
        return strLoginName;

    }

    public void BtnConfirm_Click(object sender, EventArgs e)
    {
        string mail = txtEmail.Text.ToString().Trim();
        string name = GetLoginNameByEmail();
        if (name.Trim().Length > 0)
        {
            try
            {
                //发送用户名
                RegisterMail mailB = new RegisterMail();
                string url = mailB.GetEmailSucceedTemplateUrl();
                string domain = "http://" + Request.ServerVariables["SERVER_NAME"].ToString();
                string validurl = domain + Request.RawUrl.Replace("ErrorEmail.aspx", "RetrieveStep3.aspx");

                mailB.SendSucceedMail(Server.MapPath(url), name, mail, domain);
                Response.Redirect("succeedByemail02.aspx?Email=" + mail + "");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('请重试!" + ex.Message + "'); </script>");
            }  
        }
        else
        {
            this.LblMessage.Text = "如果您忘记了注册时提交的邮箱地址，我们将无法帮助你找回用户名!";
        }
    }

}

