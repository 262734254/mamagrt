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

public partial class TestManager : System.Web.UI.Page
{
    public string domain = "";
    Tz888.BLL.Conn dal = new Conn();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["MemberObj"] != null)
            {
                string[] obj = (string[])Session["MemberObj"];
                ltMenu.Text = GenMenu(obj[1].ToString(), obj[2].ToString());//菜单
                SetTopInfo();
            }
            else
            {
                Response.Redirect("http://member.topfo.com/Login.aspx");
            }


        }
    }

    private void SetTopInfo()
    {
        DataTable dtUser = dal.GetList("LoginInfoTab", "NickName,ManageTypeID,MemberGradeID", "LoginId", 1, 1, 0, 1, "LoginName='262734254'");

        if (!string.IsNullOrEmpty(dtUser.Rows[0]["NickName"].ToString()))
        {
            lblUserName.Text = dtUser.Rows[0]["NickName"].ToString();
        }
        else { lblUserName.Text = Page.User.Identity.Name.Trim(); }

        //try
        //{
        //    if (!string.IsNullOrEmpty(dtUser.Rows[0]["NickName"].ToString()))
        //    {
        //        lblUserName.Text = dtUser.Rows[0]["NickName"].ToString();
        //    }
        //    else { lblUserName.Text = Page.User.Identity.Name.Trim(); }

        //    if (dtUser.Rows[0]["MemberGradeID"].ToString() == "1")
        //    {
        //        lblMemberGrade.Text = "拓富通试用会员";
        //    }
        //    //else
        //    //{
        //    //    lblMemberGrade.Text = "拓富通会员";
        //    //    if (memgrade == "3")
        //    //    {
        //    //        lblMemberGrade.Text = "拓富通银牌会员";
        //    //    }
        //    //    if (memgrade == "4")
        //    //    {
        //    //        lblMemberGrade.Text = "拓富通金牌会员";
        //    //    }
        //    //    if (memgrade == "5")
        //    //    {
        //    //        lblMemberGrade.Text = "拓富通钻石会员";
        //    //    }

        //    //}
        //}
        //catch { lblUserName.Text = Page.User.Identity.Name.Trim(); }
        DataTable dt = new DataTable();
        Tz888.BLL.Login.LoginInfoBLL bllLoginInfo = new Tz888.BLL.Login.LoginInfoBLL();
        dt = bllLoginInfo.GetLoginInfoByLoginName("262734254");
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
                        strb.Append(@"<div class='mainli'  style='cursor:pointer' onclick=""SetVisible1('Menu" + dr[j]["MID"].ToString().Trim() + "','changeimage" + dr[j]["MID"].ToString().Trim() + "');\"><img id='changeimage" + dr[j]["MID"].ToString().Trim() + "' src='/images_fhy/collapse.gif' align='absmiddle' />");
                        strb.Append(dr[j]["MName"].ToString().Trim());
                        strb.Append("</div>");
                        //添加二级菜单
                        strb.Append("<div class='menulist' id='Menu" + dr[j]["MID"].ToString().Trim() + "'>");
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
                    else
                    {
                        strb.Append(@"<div class='mainli' style='   :pointer'><img src='/images_fhy/collapse.gif' align='absmiddle' />");
                        strb.Append("<a target='" + dr[j]["target"].ToString().Trim() + "' href='" + dr[j]["Murl"].ToString().Trim() + "'><font color='#ffffff'>" + dr[j]["MName"].ToString().Trim() + "</font></a>");
                        strb.Append("</div>");
                    }
                }


            }
        }

        return strb.ToString();

    }
}
