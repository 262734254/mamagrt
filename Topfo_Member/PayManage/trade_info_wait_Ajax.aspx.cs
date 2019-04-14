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
using Tz888.BLL.MeberLogin;

public partial class PayManage_trade_info_wait_Ajax : System.Web.UI.Page
{
    MemberIndexBLL member = new MemberIndexBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Request["name"];
        int str = Convert.ToInt32(Request["Strike"]);
        int pageI = Convert.ToInt32(Request["page"]);
        int Type = Convert.ToInt32(Request["Type"]);
        string InfoType = Request["InfoType"];
        string time = Request["BegTime"];
        if (!IsPostBack)
        {
            if (Type == 1)
            {
                if (str == 0)
                {
                    string wait = member.SelWaitState(name, pageI, time, InfoType);
                    Response.Write(wait);
                }
                else if(str==1)
                {
                    string list = member.SelListStats(name, pageI, time, InfoType);
                    Response.Write(list);
                }
            }
            else
            {
                if (str == 0)
                {
                    string pageWait = member.PageIndexWait(name,pageI,time,InfoType);
                    Response.Write(pageWait);
                }
                else if (str == 1)
                {
                    string pageList = member.PageIndexList(name,pageI,time,InfoType);
                    Response.Write(pageList);
                }
            }
        }

    }
}
