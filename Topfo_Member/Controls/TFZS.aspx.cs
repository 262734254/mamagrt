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

public partial class Controls_TFZS : System.Web.UI.Page
{
    public string indeximg = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("TopListTab ", "HtmlFile,Title,TopValue", "TopValue", 8, 1, 0, 1, "toptype like '%TFZS%'");
        myList.DataSource = dt;
        myList.DataBind();
        for (int i = 0; i < myList.Items.Count; i++)
        {
            Image l1 = (Image)myList.Items[i].FindControl("Image1");
            string a=(i + 1).ToString();
            l1.ImageUrl="http://www.topfo.com/TopfoCenter/images/exponent/btn_"+a+".gif";
        }
    }
    public string GetStr(object str)
    {
        if (str.ToString().Length > 18)
            return str.ToString().Substring(0, 18);
        else
            return str.ToString();
    }
}
