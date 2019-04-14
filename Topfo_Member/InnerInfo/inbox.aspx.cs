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

public partial class InnerInfo_inbox : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(InnerInfo_inbox));
       
            bind();
        
    }
    public void bind()
    {
        string strWhere = "";
        if (infoReceiveTime.SelectedValue == "0")
        {
            strWhere = "";
        }
        if (infoReceiveTime.SelectedValue == "91")
        {
            strWhere = "DateDiff(d,ReceivedTime,getdate())>90";
        }
        else
        {
            strWhere = "DateDiff(d,ReceivedTime,getdate())<" + Convert.ToInt32(infoReceiveTime.SelectedValue);
        }
        DataTable dt = dal.GetList("InnerInfoReceivedTab", "*", "ReceivedID", 10, 1, 0, 1, strWhere);
        DataTable dtCount = dal.GetList("InnerInfoReceivedTab", "ReceivedID", "ReceivedID", 1, 1, 1, 1, strWhere);
        myList.DataSource = dt;
        myList.DataBind();
    }
    //删除
    [AjaxPro.AjaxMethod]
    public string ToRecycle(string idList)
    {
        Tz888.BLL.InnerInfo infoBll = new Tz888.BLL.InnerInfo();
        string[] s = idList.Split(',');
        for(int i=0;i<s.Length;i++)
        {
            if (s[i].Trim() != "")
            {
                bool b = infoBll.InfoVirtualDelete("huanglelou", Convert.ToInt32(s[i]), 0, "");
            }
        }
        return "ok";
    }
    protected void infoReceiveTime_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}