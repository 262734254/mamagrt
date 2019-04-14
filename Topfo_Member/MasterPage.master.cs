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
using Tz888.BLL.Login;
using Tz888.BLL;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string domain = "";
    Tz888.BLL.Conn dal = new Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["MemberObj"] != null)
        {
        string[] obj = (string[])Session["MemberObj"];
        ltMenu.Text = GenMenu(obj[1].ToString(), obj[2].ToString());//菜单
        DateTime time = DateTime.Now;
        lblTime.Text = time.ToString("yyyy/MM/dd");
        SetTopInfo();
        }
        else
        {
            Response.Redirect("http://member.topfo.com/Login.aspx");
        }
    }
    private void SetTopInfo()
    {
        //string name = "liulixing";
       
  string name = Page.User.Identity.Name;
        DataTable dtUser = dal.GetList("LoginInfoTab", "NickName,ManageTypeID,MemberGradeID", "LoginId", 1, 1, 0, 1, "LoginName='" + name + "'");

        if (!string.IsNullOrEmpty(dtUser.Rows[0]["NickName"].ToString()))
        {
            lblUserName.Text = dtUser.Rows[0]["NickName"].ToString();
        }
        else { lblUserName.Text = name.Trim(); }

        DataTable dt = new DataTable();
        Tz888.BLL.Login.LoginInfoBLL bllLoginInfo = new Tz888.BLL.Login.LoginInfoBLL();
        dt = bllLoginInfo.GetLoginInfoByLoginName(name.Trim());
        try
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                lblInfoCount.Text = "(" + dt.Rows[0]["TodayInfoCount"].ToString().Trim() + ")";
                lblMemberCount.Text = "(" + dt.Rows[0]["TodayMemberCount"].ToString().Trim() + ")";  
            }
        }
        catch { }
    }
    //菜单列

    protected string GenMenu(string managetype, string membergradeid)
    {
        StringBuilder strb = new StringBuilder();
        CompetenceBase cpb = new CompetenceBase();
        string str = cpb.MemberCompetence;
        string code = "";
        string[] a = str.Split(',');

        if (a.Length > 0)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (string.IsNullOrEmpty(code))
                {
                    code = "MCode='" + a[i] + "'";
                }
                else { code += " OR  MCode='" + a[i] + "'"; }
            }
        }
        if (a.Length > 0)
        {
            DataRow[] dr = cpb.GetMenuCompetence().Select("MParentCode=0 and (" + code + ")", "Sort ASC");
            if (dr != null)
            {
                DataRow[] dr1 = null;
                int count = dr.GetLength(0);
                for (int j = 0; j < count; j++)
                {
                    dr1 = cpb.GetMenuCompetence().Select("MParentCode=" + dr[j]["MID"].ToString().Trim() + " and (" + code + ")", "Sort ASC");
                    if (dr1 != null && dr1.Length > 0)
                    {

                      //  strb.Append(@"<div class='menu-tltle' onclick=""SetVisible1('Menu" + dr[j]["MID"].ToString().Trim() + "','changeimage" + dr[j]["MID"].ToString().Trim() + "');\"><a href=\"#\"   class=\"on\" id='changeimage" + dr[j]["MID"].ToString().Trim() + "' tabindex=\"1\">");
                        strb.Append(@"<div class='menu-tltle' onclick=""menuuu(" + dr[j]["MID"].ToString().Trim() + ");\"><a href=\"#\"   class=\"on\" id='changeimage" + dr[j]["MID"].ToString().Trim() + "' tabindex=\"1\">");
                        strb.Append(dr[j]["MName"].ToString().Trim());
                        strb.Append("</a></div>");
                        //添加二级菜单
                        strb.Append("<div class='list' id='Menu" + dr[j]["MID"].ToString().Trim() + "'>");
                        strb.Append(@"<ul>");

                        for (int z = 0; z < dr1.GetLength(0); z++)
                        {
                            strb.Append(@"<li>");
                            strb.Append("<a target='" + dr1[z]["target"].ToString().Trim() + "' href='" + dr1[z]["Murl"].ToString().Trim() + "'>" + dr1[z]["MName"].ToString() + "</a>");
                            strb.Append(@"</li>");
                        }

                        strb.Append(@"</ul>");
                        strb.Append("</div>");
                        strb.Append(@"<script></script>");
                    }

                }

            }
        }

        return strb.ToString();

    }
}
