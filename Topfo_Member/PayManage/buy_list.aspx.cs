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

public partial class PayManage_buy_list : System.Web.UI.Page
{
    Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.htm");
        }
        if (!Page.IsPostBack)
        {
            ViewState["infotype"] = ddltype.Value.Trim();
            ViewState["diff"] = Convert.ToInt32(ddldiff.Value.Trim());
            bindList();
        }
    }
    public void bindList()
    {
       
        string strWhere = "";
        string LoginName = Page.User.Identity.Name;
        if (ViewState["infotype"].ToString() == "all")
        {
            strWhere = "LoginName='" + LoginName + "' and DateDiff(d,PackDate,getdate())<" + ViewState["diff"];
        }
        else
        {
            strWhere = "LoginName='" + LoginName + "' and InfoTypeID='" + ViewState["infotype"].ToString() + "' and DateDiff(d,PackDate,getdate())<" + ViewState["diff"];
        }
      
        DataTable dt = bll.GetList("ShopCarVIW", "*", "ShopCarID", 10, 1, 0, 1, strWhere);
        DataTable dtCount = bll.GetList("ShopCarVIW", "ShopCarID", "ShopCarID", 1, 1, 1, 1, strWhere);
        //lblCount.Text = dtCount.Rows[0].ItemArray[0].ToString();
        //lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(lblCount.Text) / Convert.ToDouble(20)).ToString();
        myList.DataSource = dt.DefaultView;
        myList.DataBind();
    }
    protected void button_ServerClick(object sender, EventArgs e)
    {
        ViewState["infotype"] = ddltype.Value.Trim();
        ViewState["diff"] = Convert.ToInt32(ddldiff.Value.Trim());
        bindList();
        
    }
    protected void btnbytEnd_Click(object sender, EventArgs e)
    {
        libuyEnd.Style.Add("className", "");
        libuy.Style.Add("className", "");
    }
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        libuyEnd.Style.Add("className", "");
        libuy.InnerHtml = "123";
    }
}
