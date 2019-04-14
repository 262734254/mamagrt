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

public partial class helper_PromotionServer : System.Web.UI.Page
{
    protected bool bR;
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
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
        //210-06-14新增
        if (Request.QueryString["count"] != null || Request.QueryString["count"]!="")
        {
            txtcount.Value =Server.UrlDecode(Request.QueryString["count"]);
        }
        //end
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_PromotionServer));
        bR = Page.User.IsInRole("1002");

        DataTable dtCount = dal.GetList("UserParametersTab", "PromotionCount", "parID", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name + "'");
        if (dtCount.Rows.Count > 0)
        {
            lblPromotionCount.Text =dtCount.Rows[0]["PromotionCount"].ToString();
        }
    }

    //返回价格lblPromotionCount
    [AjaxPro.AjaxMethod]
    public string getDis(int count)
    {
        
        DataTable dt = dal.GetList("DictionaryInfoTab", "DictionaryInfoParam", "DictionaryInfoID", 2, 1, 0, 0, "DictionaryCode='Promotion' or DictionaryCode='DisPromotion'");
        if (dt.Rows.Count > 0)
        {
            double m1 = Convert.ToDouble(dt.Rows[0]["DictionaryInfoParam"]);//单价
            double m2 = Convert.ToDouble(dt.Rows[1]["DictionaryInfoParam"]);//折扣率  
            double m = m1 * m2 * count;//topfo价格
            double p = m1 * count;//普通价格
            return p.ToString() + "|" + m.ToString() + "|" + bR.ToString();
        }
        else
        {
            return "0";
        }
    }
}
