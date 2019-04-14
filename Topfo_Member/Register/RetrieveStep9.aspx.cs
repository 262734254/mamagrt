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

public partial class Register_RetrieveStep9 : System.Web.UI.Page
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
        try
        {
            MemberInfoDAL obj = new MemberInfoDAL();
            string phone = obj.GetMobileByName(Request.Cookies["RePwdName"].Value.ToString());
            if (phone == this.TxtMobile.Text.Trim().ToString())
            {
                string ProofPwd = obj.RndNum(6);
                //发送验证码
                Tz888.BLL.SendNotice mob = new Tz888.BLL.SendNotice();
                if (mob.SendMobileMsg(this.TxtMobile.Text.Trim().ToString(), ProofPwd))
                {
                    Session["Proofpwd"] = ProofPwd;
                    Response.Redirect("succeedByMobile.aspx");
                }
                else
                {
                    Response.Write("<script>alert('服务器发送验证码失败,请重试!');</script>");
                }
            }
            else
            {
                this.LblMessage.Text="您输入的手机号码不是注册时的手机号!";
            }
        }
        catch
        {
            Response.Write("<script>alert('发送验证码失败,请重试!');</script>");
        }

    }
}
