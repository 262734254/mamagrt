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

public partial class PayManage_account_cz_tofo : System.Web.UI.Page
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Tz888.Common.Ajax.AjaxMethod));
       // btnNext.Attributes.Add("onclick", "return chkInput();");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
        long cardno = Convert.ToInt64(txtToptocard.Value.Trim());
        string cardpwd = txtTopfoPwd.Value.Trim();
        string remark = "充值卡充值";
        int i = dal.CardStrike(txtLoginName1.Value.Trim(), cardno, cardpwd, loginname, remark);
        if (i == 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "充值成功");
            Response.Redirect("strike_records.aspx");
        }
        else if (i == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "卡号或密码错误!");
        }
        else if (i == 2)
        {
            Tz888.Common.MessageBox.Show(this.Page, "此卡已经被充值!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "充值失败!请重试!");
        }

    }
}
