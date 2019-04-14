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
using Tz888.BLL;
using Tz888.BLL.Professional;
using Tz888.Common;
public partial class Publish_Professional_AajxStr : System.Web.UI.Page
{
    ProfessionalviewBLL bll = new ProfessionalviewBLL();
    string name = "";
    string type = "";
    string title = "";
    int page = 0;
    int statu = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        //name = "longbin";
        name = Page.User.Identity.Name;
        page = Convert.ToInt32(Request["page"]);
        statu = Convert.ToInt32(Request["auditID"]);
        int index = Convert.ToInt32(Request["index"]);
        type = Request["type"].ToString() == "All" ? "All" : Request["type"].ToString();

        title = Request["title"].ToString() == "" ? "" : Request["title"].ToString();
        if (!IsPostBack)
        {
            if (index == 1)
            {
                string Rec = bll.strService(name, statu, page, type, title);
                Response.Write(Rec);
            }
            else if (index == 2)
            {
                string indexStr1 = bll.PageRecIndex(name,statu, page, type, title);
                Response.Write(indexStr1);
            }
            else if (index == 3)
            {
                string inde = "";
                for (int i = 0; i < 3; i++)
                {
                    inde += bll.pageIndex(name, i, type, title) + "$";
                }
                Response.Write(inde);
            }
            

        }
    }

}
