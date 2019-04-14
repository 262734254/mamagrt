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

public partial class PayManage_account_cz_post : System.Web.UI.Page
{
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
        btnNext.Attributes.Add("onclick", "return chkInPutMoney();");
        btnEnter.Attributes.Add("onclick", "return chkPostOrder();");
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
        if (!Page.IsPostBack)
        {
            tabOrderNext.Visible = false;
        }
    }
    public void bindUserInfo()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("LoginInfoTab", "*", "LoginID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
        if (dt.Rows.Count > 0)
        {
            txtName.Value = dt.Rows[0]["RealName"].ToString();
            txtTel.Value = dt.Rows[0]["Tel"].ToString();
            txtEmail.Value = dt.Rows[0]["Email"].ToString();
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (Session["valationNo"] != null)
        {
            if (txtValiNo.Value.Trim().ToLower() == Session["valationNo"].ToString().ToLower())
            {
                lblLoginName.Text = txtLoginName1.Value.Trim();
                tabOrder.Visible = false;
                tabOrderNext.Visible = true;
                lblMoney.Text = txtMoney.Value.Trim();
                lblTime.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                //lblLoginName.Text = tzWeb.LoginInfo.GetLoginUserName(0);
                bindUserInfo();
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "验证码错误!");
                return;
            }
        }
    }
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        if (!Tz888.Common.Utility.PageValidate.IsEmail(txtEmail.Value.Trim()))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请输入正确的邮件地址");
            return;
        }
        Tz888.Model.StrikeOrder model = new Tz888.Model.StrikeOrder();
        Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();

        model.PayTypeCode = "postOffice";
        model.LoginName = Page.User.Identity.Name;//充值人
        model.StrikeLoginName = lblLoginName.Text;//充值帐户

        model.Email = txtEmail.Value.Trim();
        model.Tel = txtTel.Value.Trim();
        model.RealName = txtName.Value.Trim();
        model.MobileNo = txtMobile.Value.Trim();

        model.TotalCount = Convert.ToDouble(txtMoney.Value);

        int orderno = dal.CreateStrikeOrder(model);
        if (orderno > 0)
        {
            Response.Redirect("strike_wait.aspx");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "订单提交失败!请重试!");
        }
    }
    protected void btnExit_Click(object sender, EventArgs e)
    {
        txtValiNo.Value = "";
        tabOrder.Visible = true;
        tabOrderNext.Visible = false;
    }
}
