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
public partial class MyHome_UpdateMyHome : System.Web.UI.Page
{
    MyHomeLink model = new MyHomeLink();
    HomeLinkManager manger = new HomeLinkManager();
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
    #region 加载绑定显示
    /// <summary>
    /// 显示信息绑定
    /// </summary>
    protected void Bind()
    {
        string LoginName = Page.User.Identity.Name;
        int id = Convert.ToInt32(Request.QueryString["Id"]);

        MyHomeLink home = manger.GetAllMyHomeById(id);
        ddlType.DataSourceID = null;
        ddlType.DataSource = type.GetHomeTypeList(LoginName);
        ddlType.DataTextField = "TypeName";
        ddlType.DataValueField = "TID";
        ddlType.DataBind();
        ddlType.SelectedValue = home.Typeid.TID.ToString();
        txtDOC.Text = home.WDoc.ToString();
        txtName.Text = home.LName.ToString();
        txtNumber.Text = home.UserName.ToString();
        txtPass.Text = home.PassWord.ToString();
        txtsorct.Text = home.WSort.ToString();
        txtWan.Text = home.Linkwww.ToString();
        if (home.States == 1)
        {
            rdostar.Checked = true;
        }
        else if (home.States == 0)
        {
            rdostop.Checked = true;
        }
    } 
    #endregion
    
     
    protected void Button1_Click(object sender, EventArgs e)
    {
        MyHomeLink home = new MyHomeLink();
        home.LID = Id;
        home.Linkwww = txtWan.Text.Trim();
        home.WDoc = txtDOC.Text.Trim();
        home.WSort = Convert.ToInt32(txtsorct.Text.Trim());
        home.LName = txtName.Text.Trim();
        home.PassWord = txtPass.Text.Trim();
        home.UserName = txtNumber.Text.Trim();
        home.LoginName = Page.User.Identity.Name.Trim();
        home.CreateTimes = DateTime.Now;//创建时间
        home.Typeid.TID = Convert.ToInt32(ddlType.SelectedValue); //类型
        home.LoginID = 1;
        if (rdostar.Checked ==true)
        {
            home.States = 1;
        }
        else if (rdostar.Checked == true)
        {
            home.States = 0;
        }
        int num = manger.UpdateMyHome(home);
        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.href='HomeList.aspx';</script>");


        }
        else
        {
            Tz888.Common.Message.back("失败");
        }

    }
}
