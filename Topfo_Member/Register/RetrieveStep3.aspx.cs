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

public partial class Register_RetrieveStep3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["RePwdName"] != null)
                {
                    this.LblUserName.Text = "您的用户名为：" + Request.Cookies["RePwdName"].Value.ToString();
                }
                else
                {
                    this.LblMessage.Text = "此页面已过期，请重新找回密码！";
                    this.BtnUpdatePwd.Enabled = false;
                    this.BtnCancel.Enabled = false;
                }
            }
            catch
            {
                this.LblMessage.Text = "此页面已过期，请重新找回密码！";
                this.BtnUpdatePwd.Enabled = false;
                this.BtnCancel.Enabled = false;
            }
        } 
    }
    protected void BtnUpdatePwd_Click(object sender, EventArgs e)
    {
        //验证用户名与密码是否正确 
        string strLoginName = this.LblUserName.Text.Trim();
        string strPassword = this.TxtPwd.Text.Trim();
        Tz888.SQLServerDAL.LoginInfo.LoginInfo obj2 = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();

        string strNewPassword = this.TxtRePwd.Text.Trim();
        if (strNewPassword == "")
        {
            return;
        }
        //修改密码
        if (obj2.ChangePassword(strLoginName, strNewPassword))
        {
            Response.Write("<script>alert('修改成功！');window.open('http://member.topfo.com/','_self');</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "修改失败！请重试！");
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        this.TxtPwd.Text = "";
        this.TxtRePwd.Text = "";
    }
}
