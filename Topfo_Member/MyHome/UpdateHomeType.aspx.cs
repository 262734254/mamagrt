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

public partial class MyHome_UpdateHomeType : System.Web.UI.Page
{
    HomeTypeManager type = new HomeTypeManager();
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("HomeList.aspx");
            }
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Id = int.Parse(Request.Params["id"].ToString());
            Bind();

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        MyHomeType homeType = new MyHomeType();
        homeType.TID = Id;
        homeType.Datatimes = DateTime.Now;
        homeType.LoginID = 1;
        homeType.LoginName = Page.User.Identity.Name;
        homeType.sort = Convert.ToInt32(txtScort.Text.Trim());
        homeType.TypeName = ddlType.SelectedItem.Text;

        int num = type.UpdateHomeType(homeType);
        if (num > 0)
        {
           
            //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('修改成功！');history.go(-2);</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.href='HomeList.aspx';</script>");
            

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败！');", true);
        }

    }
    #region 加载绑定显示
    /// <summary>
    /// 显示信息绑定
    /// </summary>
    protected void Bind()
    {
        string LoginName = Page.User.Identity.Name;
        int id = Convert.ToInt32(Request.QueryString["Id"]);
        MyHomeType homeType = type.GetAllTypeById (id);
        ddlType.DataSourceID = null;
        ddlType.DataSource = type.GetHomeTypeList(LoginName);
        ddlType.DataTextField = "TypeName";
        ddlType.DataValueField = "TID";
        ddlType.DataBind();
        ddlType.Items.FindByText(homeType.TypeName).Selected = true;
        txtScort.Text = homeType.sort.ToString();
       

    }
    #endregion
    
}
