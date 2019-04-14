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
using System.Web.Mail;
using Tz888.BLL.Register;
using Tz888.SQLServerDAL.Register;


public partial class Register_RetrieveStep10 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
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
                RegisterMail mailB = new RegisterMail();
                //防止刷新而导致邮件重发  
                //string CheckUp = mailB.GetCookies("SUCCESS" + name); 
                //if (CheckUp == "" || CheckUp == string.Empty)
                //{ 　
                string url = mailB.GetEmailSucceedTemplateUrl();
                string domain = "http://" + Request.ServerVariables["SERVER_NAME"].ToString();
                string validurl = domain + Request.RawUrl.Replace("RetrieveStep10.aspx", "RetrieveStep3.aspx");

                mailB.SendSucceedMail(Server.MapPath(url), name, mail, domain); 
                //mailB.CreateCookies("SUCCESS" + name, mail, ""); 
                Response.Redirect("succeedByemail02.aspx?Email=" + mail + "");
                //}
                //else
                //{
                //    this.LblMessage.Text="用户名成功发送到您的邮箱，请查收";
                //}
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('请重试!" + ex.Message + "'); </script>");
            }
        }
        else
        {
            Response.Redirect("ErrorEmail.aspx?Email=" + mail + "");
        }
    }
 
}

