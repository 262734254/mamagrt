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

public partial class PayManage_ticket_exchange : System.Web.UI.Page
{
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManage_ticket_exchange));
        btnChange.Attributes.Add("onclick", "return chkpost();");
        if (!Page.IsPostBack)
        {
            changeinfo();
        }
    }
    //兑换参数信息
    public void changeinfo()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("DictionaryInfoTab", "DictionaryInfoParam", "DictionaryInfoID", 3, 1, 0, 0, "DictionaryCode='VRate' or DictionaryCode='ExLimit' or DictionaryCode='VTerms'");
        if (dt.Rows.Count > 0)
        {
            lbVRate.Text = dt.Rows[0][0].ToString().Trim(); //兑换比率
            hidB.Value = dt.Rows[0][0].ToString().Trim(); //兑换比率
            lbExLimit.Text = dt.Rows[1][0].ToString().Trim();//每天兑换限额
            lbVTerms.Text = dt.Rows[2][0].ToString().Trim();//有效期
            lbVTerms2.Text = dt.Rows[2][0].ToString().Trim();//有效期
        }
        DataTable jifen = dal.GetList("CreateCardTab","IntegralCount","id",1,1,0,1,"LoginName='"+loginname+"'");
        if (jifen.Rows.Count > 0)
        {
            string ower=jifen.Rows[0]["IntegralCount"].ToString().Trim();
            string rate = lbVRate.Text == "" ? "0" : lbVRate.Text;
            lblOwnerCount.Text = ower == "" ? "0" : ower;
            lblExCount.Text = (Convert.ToDouble(ower) / Convert.ToDouble(rate)).ToString();
        }
        DataTable ticket = dal.GetList("MemberVoucherInfoTab", "LeftBalanceSum", "LeftBalanceSum", 1, 1, 0, 1, "LoginName='"+loginname+"'");
        if (ticket.Rows.Count > 0)
        {
            lblLeft.Text = ticket.Rows[0]["LeftBalanceSum"].ToString().Trim();//剩余购物券
        }
       
    }
    [AjaxPro.AjaxMethod]
    public string exChange(int count)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("DictionaryInfoTab", "DictionaryInfoParam", "DictionaryInfoID", 1, 1, 0, 1, "DictionaryCode='VRate'");
        if (dt.Rows.Count > 0)
        {
            double m = Convert.ToDouble(dt.Rows[0]["DictionaryInfoParam"]);//折扣率
            double p = count/m;//普通价格
            return p.ToString();
        }
        else
        {
            return "0";
        }
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {

        Tz888.BLL.VoucherConvert dal = new Tz888.BLL.VoucherConvert();
        int jifen=Convert.ToInt32(txtExCount.Value.Trim());
        int result = dal.ConvertTicket(loginname, jifen, loginname);
        switch (result)
        {
            case 0:
               Tz888.Common.MessageBox.Show(this.Page, "兑换成功!");
               Tz888.Common.MessageBox.Location();
                break;
            case 1:
                Tz888.Common.MessageBox.Show(this.Page, "失败，超出每天的最大兑换额!");
                break;
            case 2:
                Tz888.Common.MessageBox.Show(this.Page, "兑换失败!");
                break;
            default:
                
                break;
        }

    }
}
