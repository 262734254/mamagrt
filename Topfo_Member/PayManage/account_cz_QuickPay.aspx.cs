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

public partial class PayManage_account_cz_QuickPay : System.Web.UI.Page
{
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

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
            return;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (Session["valationNo"] != null && txtB_yz.Text.Trim().ToLower() == Session["valationNo"].ToString().ToLower())
        //{
        if (txtB_Name.Text.Trim() != "" && txtB_Name.Text.Trim() == txtB_ReName.Text.Trim())
        {
            string htmlFile = "";
            Tz888.Model.StrikeOrder model = new Tz888.Model.StrikeOrder();
            Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();

            model.PayTypeCode = "QuickPay";
            model.LoginName = Page.User.Identity.Name;              //充值人
            model.StrikeLoginName = txtB_Name.Text.Trim();          //充值帐户
            model.TotalCount = Convert.ToDouble(txtB_PayPoint.Text.Trim());
            model.BuyType = "Pre-Paid";                             //购买类型
            model.remark = txtB_Name.Text.Trim() + "使用在线充值" + txtB_PayPoint.Text.Trim() + "元";//备注

            int orderno = dal.CreateStrikeOrder(model);
            if (orderno > 0)
            {
                int money = Convert.ToInt32(txtB_PayPoint.Text.Trim());
                money = money * 100;

                QuickPaySample quick = new QuickPaySample();
                if (money > 0 || orderno >0)
                {
                    quick.ProcessRequestList(htmlFile, "中国招商投资网资源信息", Convert.ToString(orderno), Convert.ToString(money), Page.User.Identity.Name);
                }
         
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "订单提交失败!请重试!");
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "帐号不为空或者确认帐号不正确!");
            return;
        }
        //}
        //else
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "验证码错误!");
        //    return;
        //}
    }
}
