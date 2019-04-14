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

public partial class Controls_InfoResourceList : System.Web.UI.Page
{
    public long InfoID;
    protected void Page_Load(object sender, EventArgs e)
    {
        InfoID=Convert.ToInt64(Request.QueryString["InfoID"]);
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("InfoResourceTab", "*", "ResourceID", 5, 1, 0, 1, "InfoID=" + InfoID);
        DataTable dtCount = dal.GetList("InfoResourceTab", "*", "ResourceID", 5, 1, 1, 1, "InfoID=" + InfoID);
        txtCount.Value = dtCount.Rows[0].ItemArray[0].ToString();
        FileList.DataSource = dt;
        FileList.DataBind();
    }
    public string GetImg(object str)
    {
        int i = str.ToString().LastIndexOf('.');
        if (i > 0)
        {
            string s = str.ToString().Substring(i, str.ToString().Length - i);
            if (s != ".doc")
            {
                return Tz888.Common.Common.GetImageDomain() + "/" + str.ToString();
            }
            else
            {
                return "/images/doc.jpg";
            }
        }
        else
            return "";
    }
}
