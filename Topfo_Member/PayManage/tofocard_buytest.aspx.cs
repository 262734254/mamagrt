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

public partial class PayManage_tofocard_buytest : System.Web.UI.Page
{
    protected string loginname = "azhuangge";
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //bool isTof = Page.User.IsInRole("GT1002");
        //if (isTof)
        //{
        //    Page.MasterPageFile = "/indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "/MasterPage.master";
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        //{
        //    Response.Redirect("../Login.aspx");
        //}
        //loginname = Page.User.Identity.Name;
        btnSend.Attributes.Add("onclick", "return chkInput();");
        if (!Page.IsPostBack)
        {
            bindUserInfo();
        }
    }
    public void bindUserInfo()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("LoginInfoTab", "*", "LoginID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
        if (dt.Rows.Count > 0)
        {
            txtrealname.Value = dt.Rows[0]["RealName"].ToString();
            txtTel.Value = dt.Rows[0]["Tel"].ToString();
            txtEmail.Value = dt.Rows[0]["Email"].ToString();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (!Tz888.Common.Utility.PageValidate.IsEmail(txtEmail.Value.Trim()))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请输入正确的邮件地址");
            return;
        }
        int card1 = 0;
        int card2 = 0;
        int card3 = 0;
        int card4 = 0;
        if (txtwushi.Value.Trim() != "")
        {
            card1 = Convert.ToInt32(txtwushi.Value.Trim());
        }
        if (txtbai.Value.Trim() != "")
        {
            card2 = Convert.ToInt32(txtbai.Value.Trim());
        }
        if (txttwobai.Value.Trim() != "")
        {
            card3 = Convert.ToInt32(txttwobai.Value.Trim());
        }
        if (txtfivebai.Value.Trim() != "")
        {
            card4 = Convert.ToInt32(txtfivebai.Value.Trim());
        }

        Tz888.BLL.Pay dal = new Tz888.BLL.Pay();
        Tz888.Model.Pay model = new Tz888.Model.Pay();
        model.LoginName = loginname;
        model.RealName = txtrealname.Value.Trim();
        model.Email = txtEmail.Value.Trim();
        model.OtherInfo = txtAddress.Value.Trim() + "|" + txtCode.Value.Trim();
        model.Tel = txtTel.Value.Trim();
        model.MobileNo = txtMobile.Value.Trim();
        model.card1 = card1;
        model.card2 = card2;
        model.card3 = card3;
        model.card4 = card4;
        int orderno = dal.CreateCardOrder(model);
        Tz888.Common.MessageBox.Show(this.Page, orderno.ToString());
        if (orderno != 0)
        {
            double orderpoint = OnlineStrike.getOrderPoint(Convert.ToInt64(orderno));//订单金额
            double userpoint = OnlineStrike.getUserPoint(loginname);//用户金额
            if (userpoint < orderpoint)
            {
                Response.Redirect(DomainName.PayDomain() + "/otherpay.aspx?order_no=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(orderno.ToString(), "pay888"));
            }
            else
            {
                Response.Redirect(DomainName.PayDomain() + "/account/accountpay.aspx?order_no=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(orderno.ToString(), "pay888"));
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "订单创建失败!");
        }

    }
}
