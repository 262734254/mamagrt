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

public partial class Register_RetrieveStep5 : System.Web.UI.Page
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

            MemberInfoDAL obj = new MemberInfoDAL();
            this.LblQuestion.Text = obj.GetQuestionByEmail(Request.Cookies["RePwdName"].Value.ToString());
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
        string pwd = "";
        string name = Request.Cookies["RePwdName"].Value.ToString();
        MemberInfoDAL obj = new MemberInfoDAL();
        string answer = obj.GetAnswerByEmail(Request.Cookies["RePwdName"].Value.ToString());
        if (answer.Length < 1)
        {
            Response.Redirect("ErrorPassword.aspx");
        }
        else
        {
            if (answer == this.TxtAnswer.Text.ToString())
            {
                try
                {
                    //发送密码设置页  
                    string mail = GetEmailByLoginName();
                    RegisterMail mailB = new RegisterMail();
                    string url = mailB.GetMailResetTemplateUrl();
                    string domain = "http://" + Request.ServerVariables["SERVER_NAME"].ToString();
                    string validurl = domain + Request.RawUrl.Replace("RetrieveStep5.aspx", "RetrieveStep3.aspx");

                    mailB.SendResetMail(Server.MapPath(url), name, pwd, mail, validurl, domain);
                    Response.Redirect("succeedByqu.aspx?Email=" + mail + ""); 
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('请重试!" + ex.Message + "'); </script>");
                }
            }
            else
            {
                Response.Redirect("RetrieveStep6.aspx");
            }
        } 
       
    }
}
