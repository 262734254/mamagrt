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

public partial class PayManage_account_paypwd_question : System.Web.UI.Page
{
    Tz888.BLL.Conn dalCon = new Tz888.BLL.Conn();
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
        btnEnter.Attributes.Add("onclick", "return chkQuestion();");
        if (!Page.IsPostBack)
        {
            isAsk();
        }
    }
    //是否已经设置过支付密码保护
    public void isAsk()
    {
       string question=dal.isAsk(loginname);
       if (question != "")
        {
            lblquestion.Text = question;
            divQuestion.Visible = false;
            divAnswer.Visible = true;
        }
        else
        {
            divAnswer.Visible = false;
            divQuestion.Visible = true;
        }
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        string question = txtQuestion.Value.Trim();
        string answer = txtAnswer.Value.Trim();
        string email = txtEmail.Value.Trim();
        if (!Tz888.Common.Utility.PageValidate.IsEmail(email))
        {
            Tz888.Common.MessageBox.Show(this.Page, "邮箱格式错误!");
            return;
        }
        bool b = dal.setPwdQuestion(loginname, question, answer, email);
        if (b)
        {
            Tz888.Common.MessageBox.Show(this.Page, "设置成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "密码保护设置失败,请重试!");
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        //核对密码保护
        DataTable dt = dalCon.GetList("paypwdtab", "loginname,question,answer", "QID", 1, 1, 0, 1, "question ='" + lblquestion.Text + "' and Answer='" + txtAsk.Value.Trim() + "' and LoginName='"+loginname+"'");
        if (dt.Rows.Count > 0)
        {
            divQuestion.Visible = true;
            divAnswer.Visible = false;
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"密码保护答案错误!");
        }
    }
}
