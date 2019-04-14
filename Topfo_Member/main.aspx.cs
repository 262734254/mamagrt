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

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
        bool b = dal.StrikeSuccess("1000000338", "pnr", "2005", "huanglelou");
    }
}
