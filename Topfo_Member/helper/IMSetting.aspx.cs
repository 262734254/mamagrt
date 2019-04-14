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
using Tz888.Model;
using Tz888.BLL;

public partial class helper_IMSetting : System.Web.UI.Page
{
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));

        }
        if (!IsPostBack) forShow();
        btSet.Attributes.Add("onclick", "return checkIM();");
    }

    public void forShow()
    {
        Tz888.SQLServerDAL.Conn obj1 = new Tz888.SQLServerDAL.Conn();

        DataTable dt = obj1.GetList("LoginInfoIMTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name + "'");
        if (dt.Rows.Count > 0)
        {
            switch (dt.Rows[0]["IMType"].ToString())
            {
                case "QQ":
                    radioQQ.Checked = true;
                    tbQQ.Value = dt.Rows[0]["IMAccount"].ToString();
                    tbMSN.Value = ""; tbWW.Value = ""; tbYHT.Value = "";
                    break;
                case "MSN":
                    radioMSN.Checked = true;
                    tbMSN.Value = dt.Rows[0]["IMAccount"].ToString();
                    tbQQ.Value = ""; tbWW.Value = ""; tbYHT.Value = "";
                    break;
                case "旺旺":
                    radioWW.Checked = true;
                    tbWW.Value = dt.Rows[0]["IMAccount"].ToString();
                    tbQQ.Value = ""; tbMSN.Value = ""; tbYHT.Value = "";
                    break;
                case "雅虎通":
                    radioYHT.Checked = true;
                    tbYHT.Value = dt.Rows[0]["IMAccount"].ToString();
                    tbQQ.Value = ""; tbMSN.Value = ""; tbWW.Value = "";
                    break;
            }
            cbIsDisable.Checked = Convert.ToBoolean(dt.Rows[0]["IsDisable"]);
        }
    }
    protected void btSet_Click(object sender, EventArgs e)
    {
       
        Tz888.BLL.LoginInfoIMBLL obj = new LoginInfoIMBLL();
        Tz888.Model.LoginInfoIMModel model = new LoginInfoIMModel();
        model.LoginName = Page.User.Identity.Name;

        if (radioQQ.Checked)
        {
            model.IMType = "QQ";
            model.IMAccount = tbQQ.Value.Trim();
        
        }
        if (radioMSN.Checked)
        {
            model.IMType = "MSN";
            model.IMAccount = tbMSN.Value.Trim();
         
        }
        if (radioWW.Checked)
        {
            model.IMType = "旺旺";
            model.IMAccount = tbWW.Value.Trim();
          
        }
        if (radioYHT.Checked)
        {
            model.IMType = "雅虎通";
            model.IMAccount = tbYHT.Value.Trim();
          
        }

        model.IsDisable = cbIsDisable.Checked ? 1 : 0;
        model.Remark = "";

        if (model.IMAccount != "")
        {
            obj.Add(model);
            Tz888.Common.MessageBox.Show(this.Page, "添加设置成功！");
            forShow();
        }
       
    }
   
}
