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

public partial class PayManage_getPayPwd : System.Web.UI.Page
{
    public string question;
    protected string loginname = "";
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
        Tz888.BLL.PayPwd dal = new Tz888.BLL.PayPwd();
        question = dal.isAsk(loginname);
        lblQuestion.Text = question;
        btnSetPwd.Attributes.Add("onclick", "return chkpwd();"); 
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        Tz888.BLL.Conn dalCon = new Tz888.BLL.Conn();
        DataTable dt = dalCon.GetList("paypwdtab", "email,paypassword", "QID", 1, 1, 0, 1, "question ='" + lblQuestion.Text + "' and Answer='" + txtAnswer.Value.Trim() + "' and LoginName='"+loginname+"'");
        if (dt.Rows.Count > 0)
        {
            divq.Visible = false;
            divp.Visible = true;
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "密码保护回答错误!");
        }
    }
    
    protected void btnSetPwd_Click(object sender, EventArgs e)
    {
        Tz888.BLL.PayPwd dal = new Tz888.BLL.PayPwd();
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
}
