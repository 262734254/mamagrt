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

public partial class Controls_UpFileControl : System.Web.UI.UserControl
{
    public  long infoid;
    public long InfoID
    {
        get { return infoid; }
        set { infoid = value; }
    }
    public string infotype;
    public string InfoType
    {
        get { return infotype; }
        set { infotype = value; }
    }
    public string querycode;
    public string QueryCode
    {
        get { return querycode; }
        set { querycode = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(Controls_UpFileControl));
    }
    [AjaxPro.AjaxMethod]
    public bool DeleteRes(long id)
    {
        Tz888.BLL.Info.InfoResourceBLL dal = new Tz888.BLL.Info.InfoResourceBLL();
        bool b = dal.Delete(id);
        return b;
    }

   
   
}
