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
using System.Text;

public partial class Register_RetrieveStep2 : System.Web.UI.Page
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

    private string GetEmailByLoginName()
    { 
        string strEmail = "";
        MemberInfoDAL obj = new MemberInfoDAL();
        strEmail = obj.GetEmail(Request.Cookies["RePwdName"].Value.ToString()); 
        return strEmail; 
    }

    protected void BtnSendmail_Click(object sender, EventArgs e)
    {
        //判断用户名与使用邮箱是否匹配
        string mail = this.txtEmail.Text.Trim().ToString();
        string name=Request.Cookies["RePwdName"].Value.ToString();
        string strmail=GetEmailByLoginName();
        string pwd = "";
        //try
        //{
            if (strmail.Trim().Length > 0)
            {
                if (strmail == mail)
                { 
                    MemberInfoDAL obj = new MemberInfoDAL();
                    //try
                    //{
                        //发送密码设置页
                        RegisterMail mailB = new RegisterMail();
                        string url = mailB.GetMailResetTemplateUrl();
                        string domain = "http://" + Request.ServerVariables["SERVER_NAME"].ToString();
                        string validurl = domain + Request.RawUrl.Replace("RetrieveStep2.aspx", "RetrieveStep3.aspx");

                        mailB.SendResetMail(Server.MapPath(url), name, pwd, mail, validurl, domain);
                        Response.Redirect("succeedByemail.aspx?Email=" + mail + "");
                    //}
                    //catch (Exception ex)
                    //{
                    //    Response.Write("<script>alert('请重试!" + ex.Message + "'); </script>");
                    //}  
                }
                else
                {
                    Response.Redirect("RetrieveStep4.aspx");
                }
            }
        //}
        //catch 
        //{

        //}



    }
}
