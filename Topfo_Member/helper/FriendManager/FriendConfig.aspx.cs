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

public partial class helper_FriendManager_FriendConfig : System.Web.UI.Page
{
    public string loginname = "";
    public bool bR;
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
        loginname = Page.User.Identity.Name;
        this.lbSetText.Text = "";
        bR = Page.User.IsInRole("GT1002");
        if (bR)  //拓富通会员
        {
            this.panelSet.Visible = true;
            Tz888.Model.GoodFriend set = new Tz888.Model.GoodFriend();
            Tz888.BLL.GoodFriend friend = new Tz888.BLL.GoodFriend();
            //set = friend.GetFriendSet("1234");
            set = friend.GetFriendSet(loginname);
            if (set != null)
            {
                switch (set.MemberGrade)
                {
                    case 0:
                        this.lbSetText.Text += "会员身份：不限";
                        this.ddlMemberGrade.SelectedValue = "0";
                        break;
                    case 1:
                        this.lbSetText.Text += "会员身份：拓富通会员";
                        this.ddlMemberGrade.SelectedValue = "1";
                        break;
                    case 2:
                        this.lbSetText.Text += "会员身份：普通会员";
                        this.ddlMemberGrade.SelectedValue = "2";
                        break;
                }


                switch (set.MemberType)
                {
                    case 0:
                        this.lbSetText.Text += "  会员类型：不限";                        
                        break;
                    case 1:
                        this.lbSetText.Text += "   会员类型：政府机构";
                        break;
                    case 2:
                        this.lbSetText.Text += "   会员类型：企业单位";
                        break;
                    case 3:
                        this.lbSetText.Text += "   会员类型：个人经营";
                        break;
                    case 4:
                        this.lbSetText.Text += "   会员类型：个人";
                        break;
                }
                switch (set.MemberIntent)
                {
                    case 0:
                        this.lbSetText.Text += "  会员意向：不限";
                        this.ddlMemberType.SelectedValue = "0";
                        break;
                    case 1:
                        this.lbSetText.Text += "   会员意向：政府机构";
                        this.ddlMemberType.SelectedValue = "1";
                        break;
                    case 2:
                        this.lbSetText.Text += "   会员意向：企业单位";
                        this.ddlMemberType.SelectedValue = "2";
                        break;
                    case 3:
                        this.lbSetText.Text += "   会员意向：个人经营";
                        this.ddlMemberType.SelectedValue = "3";
                        break;
                    case 4:
                        this.lbSetText.Text += "   会员意向：个人";
                        this.ddlMemberType.SelectedValue = "4";
                        break;
                }
                this.lbSetText.Text += "  可以加您为好友";
            }
        }
        else
        {
            linktopf.Visible = true;
        }


    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        bool bR = Page.User.IsInRole("GT1002");
        if (bR)
        {
            Tz888.BLL.GoodFriend goodFriend = new Tz888.BLL.GoodFriend();
            Tz888.Model.GoodFriend set = new Tz888.Model.GoodFriend();
            set.LoginName = loginname;
            set.MemberType = Convert.ToInt32(this.ddlMemberType.SelectedValue);
            set.MemberGrade = Convert.ToInt32(this.ddlMemberGrade.SelectedValue);
            set.MemberIntent = Convert.ToInt32(this.ddlMemberIntent.SelectedValue);
            goodFriend.SetFriendSet(set);
            Tz888.Common.MessageBox.Show(this.Page, "设置成功!");
        }
        else
        {
            Response.Write("<script>window.open('FriendSetClue.htm');</script>");
        }
    }
    protected void ddlMemberType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlMemberType.SelectedValue == "0")
        {
            this.ddlMemberIntent.Items.Clear();
            this.ddlMemberIntent.Items.Add(new ListItem("不限", "0"));
            this.ddlMemberIntent.Items.Add(new ListItem("政府招商", "1"));
            this.ddlMemberIntent.Items.Add(new ListItem("产品招商", "2"));
            this.ddlMemberIntent.Items.Add(new ListItem("项目融资", "3"));
            this.ddlMemberIntent.Items.Add(new ListItem("项目投资", "4"));
            this.ddlMemberIntent.Items.Add(new ListItem("创业合作", "5"));
            this.ddlMemberIntent.Items.Add(new ListItem("产品供求", "6"));
        }
        else if (this.ddlMemberType.SelectedValue == "1")
        {
            this.ddlMemberIntent.Items.Clear();
            this.ddlMemberIntent.Items.Add(new ListItem("不限", "0"));
            this.ddlMemberIntent.Items.Add(new ListItem("政府招商", "1"));
        }
        else
        {
            this.ddlMemberIntent.Items.Clear();
            this.ddlMemberIntent.Items.Add(new ListItem("不限", "0"));
            this.ddlMemberIntent.Items.Add(new ListItem("产品招商", "2"));
            this.ddlMemberIntent.Items.Add(new ListItem("项目融资", "3"));
            this.ddlMemberIntent.Items.Add(new ListItem("项目投资", "4"));
            this.ddlMemberIntent.Items.Add(new ListItem("创业合作", "5"));
            this.ddlMemberIntent.Items.Add(new ListItem("产品供求", "6"));
        }
        
    }
}
