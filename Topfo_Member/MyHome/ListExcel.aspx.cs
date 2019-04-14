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
using System.Text;
using System.Drawing;
using System.IO;
public partial class MyHome_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }
    private void Bind()
    {
        HomeLinkManager manger = new HomeLinkManager();

        string LoginName = Page.User.Identity.Name;
        GridViewE.DataSource = manger.GetAllhome(LoginName);
        GridViewE.DataBind();

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.GridViewE.RenderControl(hw);

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        GridViewE.Page.EnableViewState = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"MyHome.xls");
        Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=UTF8\"><title> adsf</title></head><body><table><tr><td> 名称</td><td>网站</td><td>网站类型</td><td>创建时间</td></tr>");
        Response.Write(sw.ToString());
        Response.Write("</table></body></html>");
        Response.End();
    }
    #region 获取类别
    /// <summary>
    /// 显示类别
    /// </summary>
    /// <param name="Id">Id</param>
    /// <returns></returns>
    public string ShowUserName(string UserId)
    {
        HomeTypeManager mbll = new HomeTypeManager();
        MyHomeType model = new MyHomeType();
        model = mbll.GetAllTypeById(Convert.ToInt32(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.TypeName;
        return strTemp;
    }
    #endregion
}
