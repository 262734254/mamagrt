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
using System.Text;
using Tz888.DBUtility;
using System.Data.SqlClient;

public partial class Manage_Ajax : System.Web.UI.Page
{
    Tz888.BLL.MeberLogin.MemberIndex member = new Tz888.BLL.MeberLogin.MemberIndex();
    string name = "";
    int status = 0;
    int Paged = 0;
    string infoType = "";
    string title = "";
    StringBuilder sb = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        name = Request["name"];
        status = Convert.ToInt32(Request["Status"]);
        Paged = Convert.ToInt32(Request["Page"]);
        int type = Convert.ToInt32(Request["Type"]);
        infoType = Request["InfoType"].ToString() == "All" ? "All" : Request["InfoType"].ToString();
        title = Request["Title"].ToString() == "" ? "" : Request["Title"].ToString();
        if (!IsPostBack)
        {
            if (type == 1)
            {
                string a = member.AjaxStatus(name, status, Paged, infoType, title);
                Response.Write(a);
            }
            else if(type==2)
            {
                string b = member.pageCont(name, status, Paged,infoType,title);
               Response.Write(b);
            }
            else if (type == 3)
            {
                string index = "";
                for (int i = 0; i <= 3; i++)
                {
                    index += member.pageIndex(name, i, infoType, title)+"$";
                }
                Response.Write(index);
            }
            
            
        }
        
    }

 
}
