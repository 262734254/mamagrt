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

public partial class PayManage_account_paypwd : System.Web.UI.Page
{
    Tz888.BLL.PayPwd dal = new Tz888.BLL.PayPwd();
    public string loginname = "";
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");
        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        loginname = Page.User.Identity.Name;
        //btnChangePwd.Attributes.Add("onclick", "return chkPwd();");
        //btnsetpwd.Attributes.Add("onclick", "return chksetpwd();");

        if (dal.isSetPwd(loginname))
        {
            divsetpwd.Visible = false;
            divupdatepwd.Visible = true;
        }
        else
        {
            divsetpwd.Visible = true;
            divupdatepwd.Visible = false;
        }
    }
    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        DataTable dt = dal.valiPayPwd(loginname, txtLoginPwd.Value.Trim());
        if (dt.Rows.Count > 0)//支付密码正确
        {
            bool b = dal.changePayPwd(loginname, txtPayPwd1.Value.Trim());//修改密码
            if (b)
            {
                Tz888.Common.MessageBox.Show(this.Page, "支付密码修改成功!");
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "支付密码修改失败,请重试!");
            }
        }
        else
        {
            lblMsg.Text = "密码错误!忘记了密码请点<a href='getPayPwd.aspx' class='hong'>取回</a>";
        }
    }
    protected void btnsetpwd_Click(object sender, EventArgs e)
    {
        //设置支付密码
        bool b = dal.changePayPwd(loginname, txtsetpwd1.Value.Trim());
        if (b)
        {
            Tz888.Common.MessageBox.Show(this.Page, "支付密码设置成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "支付密码设置失败,请重试!");
        }
    }
}
