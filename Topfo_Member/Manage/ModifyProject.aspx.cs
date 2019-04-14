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

public partial class Manage_ModifyProject : System.Web.UI.Page
{
    private long _infoID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!this.Page.IsPostBack)
        {
            if (this.Page.Request.QueryString["id"] != null)
            {
                try
                {
                    this._infoID = Convert.ToInt64(this.Page.Request.QueryString["id"]);
                }
                catch
                {
                    this._infoID = 0;
                }
            }

            if (this._infoID == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "请通过正常的途径访问！");
                Response.Flush();
                Response.End();
                return;
            }

            //LoadInfo(1477162);
           LoadInfo(this._infoID);

        }
    }   
    private void LoadInfo(long InfoID)
    {
        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.ProjectSetModel model = bll.GetIntegrityModel(InfoID);
        if (model == null)
        {
            Tz888.Common.MessageBox.Show(this.Page, "未找到资源信息！");
            Response.Flush();
            Response.End();
            return;
        }

        if (model.ProjectInfoModel.CooperationDemandType.Trim() == "10")//股权融资
        {
            Response.Redirect("../Publish/project/EquityRaised_Update.aspx?InfoID=" + _infoID);
        }
        else
        {
            Response.Redirect("../Publish/project/CreditorsRaised_Update.aspx?InfoID=" + _infoID);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
    }
}
