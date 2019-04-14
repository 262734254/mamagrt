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

public partial class PayManage_ShopCarMany : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strInfoidList = "";
        if (Request.QueryString["InfoIDList"] != null && Request.QueryString["InfoIDList"].ToString().Trim() != "")
        {
            strInfoidList = Request.QueryString["InfoIDList"].ToString().Trim();

            string[] arr = FormatDh(strInfoidList, ",").Split(',');

            string loginname = Page.User.Identity.Name;
            if (loginname == "")
            {
                Response.Redirect("http://member.topfo.com/login.aspx?ReturnURL=" + Request.Url.ToString());
                return;
            }

            Tz888.BLL.Pay dal = new Tz888.BLL.Pay();
            try
            {
                int iCount = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if(dal.ShopCar_Add(Convert.ToInt64(arr[i].ToString().Trim()),loginname))
                        iCount += 1;
                }
                if(iCount==arr.Length)
                    Response.Redirect("trade_info_wait.aspx");
            }
            catch
            {
                Response.Redirect("trade_info_wait.aspx");
            }
        }
    }

    private  string FormatDh(string strDh, string strFh)
    {
        if (strDh.Length > 1)
        {
            //strDh = strDh.Replace(",,", ",");
            if (strDh.Substring(0, 1) == strFh)
                strDh = strDh.Substring(1);
            if (strDh.Substring(strDh.Length - 1) == strFh)
                strDh = strDh.Substring(0, strDh.Length - 1);
        }
        return strDh;
    }

}
