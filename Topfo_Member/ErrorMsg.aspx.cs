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

public partial class ErrorMsg : System.Web.UI.Page
{
    protected bool IsShowErrMsg = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.IsShowErrMsg = bool.Parse(ConfigurationManager.AppSettings["IsShowErrMsg"]);
        }
        catch
        {

        }
        if (!IsShowErrMsg)
        {
            this.lblDetails.Visible = false;
            this.lblMsg.Visible = true;
        }
        else
        {
            this.lblDetails.Visible = true;
            this.lblMsg.Visible = false;
        }
        if (!Page.IsPostBack)
        {
            lblMsg.Text = "<br>所访问的资源不存在, 请确认输入的地址是否正确, 如果仍然存在问题, 请与管理员联系。";

            Exception ex = Server.GetLastError();
            try
            {
                lblDetails.Text = ex.Message;
            }
            catch { }
            //lblMsgDetails.Text = ex.InnerException.StackTrace;
            Server.ClearError();
        }
    }
}
