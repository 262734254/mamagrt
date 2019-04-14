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

public partial class Recommend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
            //单独调试使用默认值
            //Session["URL"] = "www.topfo.com";
           
            if(Request.QueryString["pageURL"]!=null)
            {
                string url = Request.QueryString["pageURL"].ToString();
                txtURl.Text = "www.topfo.com/" + url;
                //txtURl.Text = Session["URl"].ToString();
            }
        }
    }
}
