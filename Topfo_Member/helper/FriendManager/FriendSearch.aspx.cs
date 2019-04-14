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


public partial class helper_FriendManager_FriendSearch : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("/Login.aspx");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string url = "FriendAdd.aspx";
        if (this.Radio2.Checked)
        {
            string memberIntent = "";
            //string memberIndutry = "";  //行业
            //string memberZone = "";     //地区
            //string memberCountry = "";
            for (int i = 0; i < this.cklIntent.Items.Count; i++)
            {
                if (this.cklIntent.Items[i].Selected)
                {
                    memberIntent += "1%";
                }
                else
                {
                    memberIntent += "0%";
                }
            }
            url += "?Mg=" + this.rblMemberGrade.SelectedValue + "&Mt=" + this.rblMemberType.SelectedValue + "&Mi=" + memberIntent +
                "&province=" + this.ZoneSelectControl1.ProvinceID.ToString() + "&city=" + this.ZoneSelectControl1.CityID + "&county=" +
                this.ZoneSelectControl1.CountyID;
            Response.Redirect(url);
        }
        else
        {
            url += "?Flag=" + Server.UrlEncode( this.tboxMemberName.Text.Trim());
            Response.Redirect(url);
        }

    }

}
