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
using tenpay;

public partial class PayManage_account_cz_cft : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        txtB_CzName.Text = Page.User.Identity.Name;
        txtB_ReCzName.Text = txtB_CzName.Text;
        txtB_CzName.Style.Add(HtmlTextWriterStyle.Color, "Gray");
        txtB_ReCzName.Style.Add(HtmlTextWriterStyle.Color, "Gray");
    }

    public void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        if (Session["valationNo"] != null && txtB_yz.Text.Trim().ToLower() == Session["valationNo"].ToString().ToLower())
        {
            if (txtB_Name.Text.Trim() != "")
            {
                if (txtB_CzName.Text.Trim() != "" && txtB_CzName.Text.Trim() == txtB_ReCzName.Text.Trim())
                {
                    Tz888.Model.StrikeOrder model = new Tz888.Model.StrikeOrder();
                    Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();

                    model.PayTypeCode = "tenpay";
                    model.LoginName = Page.User.Identity.Name;              //充值人
                    model.StrikeLoginName = txtB_CzName.Text.Trim();          //你的财付通充值帐户
                    model.TotalCount = Convert.ToDouble(txtB_PayPoint.Text.Trim());
                    model.BuyType = "Pre-Paid";                            //购买类型
                    model.remark = txtB_Name.Text.Trim() + "使用财付通充值" + txtB_PayPoint.Text.Trim() + "元";//备注

                    int orderno = dal.CreateStrikeOrder(model);
                    if (orderno > 0)
                    {
                        string postForm = OnlineStrike.tenForm(orderno.ToString(), txtB_PayPoint.Text.Trim(), txtB_Name.Text.Trim());
                        Response.Redirect(postForm);
                    }
                    else
                    {
                        Tz888.Common.MessageBox.Show(this.Page, "订单提交失败!请重试!");
                    }
                }
                else
                {
                    Tz888.Common.MessageBox.Show(this.Page, "充值帐号不为空或者确认充值帐号不正确!");
                    return;
                }
            }
            else
            {
                Tz888.Common.MessageBox.Show(this.Page, "财付通帐号不为空!");
                return;
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "验证码错误!");
            return;
        }
    }
}
