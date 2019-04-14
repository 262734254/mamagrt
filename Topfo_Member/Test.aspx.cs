using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Tz888.Common;

public partial class Test : System.Web.UI.Page
{

    private void Page_Load(object sender, System.EventArgs e)
    {
    }

    //回购方式
    public void bindReturn()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("SetReturnModeTAB", "*", "ReturnModeID", 10, 1, 0, 0, "");
        chkReturn.DataTextField = "ReturnModeName";
        chkReturn.DataValueField = "ReturnModeID";
        chkReturn.DataSource = dt;
        chkReturn.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string a = "";
        for (int i = 0; i < chkReturn.Items.Count; i++)
        {
            if (chkReturn.Items[i].Selected)
            {
              a+=chkReturn.Items[i].Value+",";
            }
        }
        Response.Write(a);
    }
}

