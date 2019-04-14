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
using System.Collections.Generic;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
using Tz888.BLL.MyHome;
using Tz888.Pager;

public partial class MyHome_Index : System.Web.UI.Page
{
    MyHomeLink model = new MyHomeLink();
    HomeLinkManager manger = new HomeLinkManager();
    HomeTypeManager type = new HomeTypeManager();
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        
        
    }
    #region 分类代码绑定
    public string GetAllType()
    {
        string LoginName = Page.User.Identity.Name;
        return manger.SelectType(LoginName);
    } 
    #endregion

 

}
