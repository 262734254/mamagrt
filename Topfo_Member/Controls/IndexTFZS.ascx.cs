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

public partial class Controls_IndexTFZS : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("TopListTab ", "HtmlFile,Title,TopValue", "TopValue", 10, 1, 0, 1, "toptype like '%TFZS%'");
        myList.DataSource = dt;
        myList.DataBind();
        for (int i = 0; i < myList.Items.Count; i++)
        {
            Label l1 = (Label)myList.Items[i].FindControl("lblID");
            l1.Text = (i + 1).ToString();
        }
    }
    public string GetStr(object str)
    {
        if (str.ToString().Length > 12)
            return str.ToString().Substring(0, 12);
        else
            return str.ToString();
    }
}
