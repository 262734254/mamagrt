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
using Tz888.BLL;
using Tz888.BLL.Professional;
using Tz888.Common;
public partial class Publish_Professional_ServiesManage : System.Web.UI.Page
{
    string pageID = "";
    string type = "";
    string name = "";
    ProfessionalviewBLL bll = new ProfessionalviewBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Publish_Professional_ServiesManage));
        //name = "longbin";
        type = this.statuId1.Value == "" ? "" : this.statuId1.Value;
        pageID = this.txtPageID.Value == "" ? "" : this.txtPageID.Value;
        string name = Page.User.Identity.Name;
        NameID.Value = name;
        //getbind(pageID, name);
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        //if (!JudgeCompetence())
        //{
        //    MessageBox.Go("您无此权限", true);
        //}

        if (!IsPostBack)
        {
        }
    }
    [AjaxPro.AjaxMethod]
    public void DeleteID(int ID)
    {
        this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入标题');", true);
        //string msg = "";
        //ProfessionalinfoBLL infobll = new ProfessionalinfoBLL();
        //int ErrorID = 0;
        //string ErrorMsg = "";
        //if (!infobll.UpdateAuditIdByID(ID))
        //    msg += "[" + ID.ToString() + "]删除失败！" + ErrorMsg + "\n";


    }

}
