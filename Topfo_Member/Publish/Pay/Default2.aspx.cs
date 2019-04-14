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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ViewState["page"] = 1;
        }
        bind();



    }
    public void bind()
    {
        Tz888.BLL.Conn myConn = new Tz888.BLL.Conn();
        try
        {
            DataTable dt = myConn.GetList("MainInfoTab", "*", "InfoID", 100, Convert.ToInt32(ViewState["page"]), 0, 0, "");
            myDataList.DataSource = dt;
            myDataList.DataBind();
        }
        catch (Exception e)
        {
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.ViewState["page"] = Convert.ToInt32(ViewState["page"]) - 1;
        bind();
        Response.Write(this.ViewState["page"].ToString());
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        this.ViewState["page"] = Convert.ToInt32(ViewState["page"]) + 1;
        bind();
        Response.Write(this.ViewState["page"].ToString());
    }
}
