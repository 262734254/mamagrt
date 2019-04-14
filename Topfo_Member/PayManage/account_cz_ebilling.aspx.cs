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

public partial class PayManage_account_cz_ebilling : System.Web.UI.Page
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
        btnNext.Attributes.Add("onclick", "return chkInPut();");
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
        if (!Page.IsPostBack)
        {
            tabOrderNext.Visible = false;
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
                //lblLoginName.Text = tzWeb.LoginInfo.GetLoginUserName(0);
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
        Tz888.Model.StrikeOrder model = new Tz888.Model.StrikeOrder();
        Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();

        model.PayTypeCode = "ebilling";
        model.LoginName = Page.User.Identity.Name;//充值人
        model.StrikeLoginName = lblLoginName.Text;//充值帐户
        model.TotalCount = Convert.ToDouble(lblMoney.Text);

        int orderno = dal.CreateStrikeOrder(model);
        if (orderno>0)
        {
            string postForm = OnlineStrike.ebillingForm(orderno.ToString(), lblMoney.Text.Trim(), lblLoginName.Text.Trim());
            Response.Write(postForm);
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
