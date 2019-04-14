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

public partial class testpay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       // string d = DateTime.Now.ToString("yyyyMMddHHmmss");

       // Response.Write(d);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string htmlFile = "";
        string url = "http://www.topfo.com/";
        string shopName = "";
        int WorthPoint = 0;
        Tz888.BLL.GetDataList bll = new Tz888.BLL.GetDataList();

        string strWhere = "OrderNo=1000005778";

        DataTable dt = bll.GetList("ShopCarVIW", "HtmlFile,SourceType,WorthPoint", "ShopCarID", 1, 1, 0, 1, strWhere);

        if (dt.Rows.Count > 0)
        {
            htmlFile =url+dt.Rows[0]["HtmlFile"].ToString().Trim();
            shopName = dt.Rows[0]["SourceType"].ToString().Trim();
            WorthPoint =Convert.ToInt32( dt.Rows[0]["WorthPoint"].ToString().Trim());

        }

        int money = WorthPoint * 100;


        QuickPaySample quick = new QuickPaySample();
        quick.ProcessRequest(htmlFile, "中国招商投资网资源信息", "1000005778", Convert.ToString(money), "cn001");
       //quick.ProcessRequest();
       // string d = DateTime.Now.ToString("yyyyMMddHHmmss");

       // Response.Write(d);
    }
}
