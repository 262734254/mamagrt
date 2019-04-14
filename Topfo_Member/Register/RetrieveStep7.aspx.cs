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

public partial class Register_RetrieveStep7 : System.Web.UI.Page
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

    protected void BtnConfirmMoible_Click(object sender, EventArgs e)
    {
        MemberInfoDAL obj = new MemberInfoDAL();
        try
        {
            string phone = obj.GetMobileByName(Request.Cookies["RePwdName"].Value.ToString());
            if (phone.Length == 11 && phone.IndexOf("-", 0) == -1)
            {
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
                    Response.Redirect("RetrieveStep9.aspx");
                }
            }
            else
            {
                Response.Redirect("Errortelephone.aspx");
            }
        }
        catch
        {
            Response.Write("<script>alert('发送验证码失败,请重试!');</script>");
        }
    }
}
