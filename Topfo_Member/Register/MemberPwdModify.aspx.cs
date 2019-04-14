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

public partial class Register_MemberPwdModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        }
    }
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
    protected void btnModifyPwd_Click(object sender, EventArgs e)
    {
        //验证用户名与密码是否正确
        int ErrorID = 0;
        string ErrorMsg = "";
        DataTable dt = new DataTable();
        string strLoginName =Page.User.Identity.Name;
        string strPassword =  txtOldPwd.Text.Trim();

         Tz888.BLL.Login.LoginInfoBLL obj = new Tz888.BLL.Login.LoginInfoBLL();
         Tz888.SQLServerDAL.LoginInfo.LoginInfo obj2 = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
        dt = obj.Authenticate(strLoginName, 0, strPassword, true, ref ErrorID, ref ErrorMsg);

        if (dt.Rows.Count > 0)
        { 
            string strNewPassword = txtNewPwd.Text.Trim();
            //修改密码
            if (obj2.ChangePassword(strLoginName, strNewPassword))
                Tz888.Common.MessageBox.Show(this.Page, "修改成功！");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page,"您输入的旧密码不正确！");
        }
    }
    protected void btClear_Click(object sender, EventArgs e)
    {
        txtOldPwd.Text = "";
        txtNewPwd.Text = "";
        txtConfirmPwd.Text = "";
    }
}
