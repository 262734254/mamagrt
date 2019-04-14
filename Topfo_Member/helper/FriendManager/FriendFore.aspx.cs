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

public partial class helper_FriendManager_FriendFore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            return;
        }

        if (Request.QueryString["name"] != null && Request.QueryString["name"].ToString() != "")
        {
            long m = 1;
            long j = 1;
            long k = 1;
            string nickName = "";
            string strWhere = "";
            string memberGrade = "";
            string manageType = "";
            string intent = "";
            string name = "";
            bool grade = false;
            bool type = false;
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            name = Request.QueryString["name"].ToString().Trim();
             //name = "kiki";
            strWhere = "loginName='" + name + "'";
            //strWhere = "nickName='" + name + "'";
            DataTable dt = dal.GetList("loginInfoTab", "loginName", "nickName", strWhere, "loginName", ref m, k, ref j);
            if (dt != null && dt.Rows.Count > 0)
            {
                nickName = dt.Rows[0][0].ToString();
            }
            //strWhere = "loginName= ' " + Page.User.Identity.Name + "'";
            strWhere = "loginName= ' " + name + "'";
            dt = null;
            dt = dal.GetList("loginInfoTab", "loginName", "MemberGradeId,ManageTypeId,requirInfo", strWhere, "loginName", ref m, k, ref j);
            if (dt != null && dt.Rows.Count > 0)
            {
                memberGrade = dt.Rows[0][0].ToString();
                manageType = dt.Rows[0][1].ToString();
                intent = dt.Rows[0][2].ToString();
            }
            Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
            Tz888.Model.GoodFriend set = new Tz888.Model.GoodFriend();

            bool IsBlack = friendBll.IsSpecies(name, Page.User.Identity.Name, 3);
            //bool IsBlack = friendBll.IsSpecies("huangleon", "beckycheng", 3);
            if (IsBlack)
            {
                Response.Write("<script>alert('添加好友失败！您被加入黑名单');window.close();</script>");
                return;
            }
            bool IsFriend = friendBll.IsSpecies(Page.User.Identity.Name,name , 1);
            //bool IsFriend = friendBll.IsSpecies("huangleon", "beckycheng", 1);
            if (IsFriend)
            {
                Response.Write("<script>alert('添加好友失败！用户已在好友列表中');window.close();</script>");
                return;
            }

            if (name.Trim() == Page.User.Identity.Name.Trim())
            {
                Response.Write("<script>alert('添加好友失败！不能添加自己为好友');window.close();</script>");
                return;
            }
            //loginName = "kittycat";

            set = friendBll.GetFriendSet(name);
            if (set != null)
            {
                if (set.MemberGrade == 2)
                {
                    if (memberGrade == "1001")
                    {
                        grade = true;
                    }
                }
                else if (set.MemberGrade == 0)
                {
                    grade = true;
                }
                if (grade)
                {
                    if (set.MemberType == 0)
                    {

                        type = true;

                    }
                    else if (set.MemberType == 1)
                    {
                        if (manageType.Trim() == "1004")
                        {
                            type = true;
                        }
                    }
                    else if (set.MemberType == 2)
                    {
                        if (manageType.Trim() == "1003")
                        {
                            type = true;
                        }
                    }
                    else if (set.MemberType == 3)
                    {
                        if (manageType.Trim() == "1001")
                        {
                            type = true;
                        }
                    }
                }
            }
            else
            {
                type =true;
            }
            if (type)
            {
                Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
                model.LoginName = Page.User.Identity.Name;
                model.ContactName = name;
                model.GroupId = 1;
                friendBll.AddFriend(model);
                this.hplName.Text = "恭喜，您已经成功添加" + nickName + "为您的好友了！";
                this.hplList.Text = "查看您的好友列表";
                this.hplList.NavigateUrl = "friendList.aspx";
                this.hplSendInfo.Text = "给" + nickName + "发送站内短信";
                this.hplSendInfo.NavigateUrl = "../../innerinfo/SendView.aspx?Ac=0&name=" + nickName;
            }
            else
            {
                this.hplName.Text = "对不起，" + name + "  设置只有拓富通会员才能将他加为好友！";
                this.hplList.Text = "了解一下拓富通会员服务";
                this.hplList.NavigateUrl = "http://www.topfo.com/help/TopfoServer.shtml#a5";
                this.hplSendInfo.Text = "立即申请拓富通会员服务";
                this.hplSendInfo.NavigateUrl = "http://member.topfo.com/Register/VIPMemberRegister_In.aspx";
            }
        }
    }
}
