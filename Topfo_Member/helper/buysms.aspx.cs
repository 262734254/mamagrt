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

public partial class helper_buysms : System.Web.UI.Page
{
    protected bool bR;
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
        bR = Page.User.IsInRole("GT1002");
        if (bR)
        {
            imgVip.Visible=false;
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_buysms));

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string loginname = Page.User.Identity.Name;
        DataTable dt = dal.GetList("UserParametersTab", "MobileCount", "parID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
        if (dt.Rows.Count > 0)
        {
            lblMobileCount.Text = dt.Rows[0]["MobileCount"].ToString();
        }
    }
    
    //返回价格
    [AjaxPro.AjaxMethod]
    public string getDis(int count)
    {
        Tz888.BLL.Conn dal=new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("DictionaryInfoTab", "DictionaryInfoParam", "DictionaryInfoID", 2, 1, 0, 1, "DictionaryCode='sms' or DictionaryCode='smsmoney'");
        if (dt.Rows.Count > 0)
        {
            double m1= Convert.ToDouble(dt.Rows[0]["DictionaryInfoParam"]);//单价
            double m2= Convert.ToDouble(dt.Rows[1]["DictionaryInfoParam"]);//折扣率
            double m = m1 * m2 * count;//topfo价格
            double p = m1 * count;//普通价格

            return m.ToString() + "|" + p.ToString() + "|" + Page.User.IsInRole("GT1002").ToString();
        }
        else
        {
            return "0";
        }
    }
}
