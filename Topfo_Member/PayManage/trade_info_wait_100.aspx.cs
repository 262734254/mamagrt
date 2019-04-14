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

public partial class PayManage_trade_info_wait_100 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = "topfo001";
        LgName.Value = name;
        lblUserPoint.Text = OnlineStrike.getUserPoint(name).ToString();
        if (!IsPostBack)
        { 
        
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Tz888.BLL.Pay dal = new Tz888.BLL.Pay();
        string[] values = Request.Form.GetValues("cbxSelect");
        string sdt = "";
        string com = "";
        bool b = true;
        foreach (string str in values)
        {
            b = dal.ShopCar_Delete(Convert.ToInt64(str));
            if (b)
            {
                com += "物品:" + str + "删除成功 \\n";
            }
            else
            {
                sdt += "物品:" + str + "删除失败 \\n";
            }

        }
        if (com.Length > 0)
        {
            Response.Write("<script>alert('" + com + "');</script>");
        }
        if (sdt.Length > 0)
        {
            Response.Write("<script>alert('" + sdt + "');</script>");
        }
    }
}
