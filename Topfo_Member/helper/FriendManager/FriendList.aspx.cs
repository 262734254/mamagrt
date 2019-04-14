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

public partial class helper_FriendManager_FriendList : Tz888.Common.Pager.BasePage
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_FriendManager_FriendList));
        if (Page.User.IsInRole("GT1002"))//判断用户是否拓富通会员
        {
            this.ButtonGroupSend.Visible = true;
            divHelp.Style.Add("display", "none");
        }
        else
        {
            divHelp.Style.Add("display", "block");
            this.ButtonGroupSend.Visible = false;            
        }
        if (!IsPostBack)
        {
            ViewState["pagesize"] = 10;
            ViewState["CurrPage"] = 1;

        }
        getList();
    }
    public void getList()
    {
        string strWhere = "";
        string username = Page.User.Identity.Name;//"kiki";
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        strWhere = "loginName= '" + username + "'and groupId= '1'";
        DataTable dt = dal.GetList("innerInfoContactManInfoVIW", "ContactId",
            "contactName,MemberGradeId,ManageTypeId,provinceName,cityName,countyName,ContactId,RegisterTime,requirInfo,nickName", strWhere, "ContactId desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        friendListGridView.DataSource = dt;
        friendListGridView.DataBind();
    }

    protected void friendListGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView view = e.Row.DataItem as DataRowView;//定义一个DataRowView的实例
        Image img = new Image();
        img = (Image)e.Row.FindControl("imgTofo");
        if (view != null)
        {
            //2会员类型，3会员周期，6付费状态，7审核状态
            switch (view["ManageTypeId"].ToString().Trim())
            {
                case "1001":
                    e.Row.Cells[2].Text = "个人会员";
                    break;
                case "1003":
                    e.Row.Cells[2].Text = "企业会员";
                    break;
                case "1004":
                    e.Row.Cells[2].Text = "政府会员";
                    break;
            }
            //在线洽谈
            long m = 1;
            long n = 1;
            long v = 1;
            string strWhere = "";
            string online = "";
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            System.Web.UI.HtmlControls.HtmlGenericControl divOnline = (HtmlGenericControl)e.Row.FindControl("divOnlineTalk");
            strWhere = "loginName='" + view["contactName"].ToString().Trim() + "'";
            DataTable dataTable = dal.GetList("loginInfoIMTab", "loginName", "imType,ImAccount,isDisable", strWhere, "loginName", ref m, n, ref v);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (Convert.ToInt32(dataTable.Rows[0][2]) != 1)
                {
                    if (dataTable.Rows[0][0] != null && dataTable.Rows[0][0].ToString() != "")
                    {
                        if (dataTable.Rows[0][0].ToString().IndexOf("MSN") > -1)
                        {
                            online = "<a href=\"msnim:chat?contact=" + dataTable.Rows[0][1].ToString().Trim() + "\" title=\"请确保XP版本以上的Windows并安装好MSN，或者手动添加地址。\"   target=\"_blank\" ><img src=\"http://Search.topfo.com/Images/icon_member.gif\" border=0></a >";
                        }
                        if (dataTable.Rows[0][0].ToString().IndexOf("QQ") > -1)
                        {
                            online = "<a target='blank' href='http://wpa.qq.com/msgrd?V=1&Uin=" + dataTable.Rows[0][1].ToString().Trim() + "&Site=中国招商投资网&Menu=yes'><img border='0' SRC=http://wpa.qq.com/pa?p=1:" + dataTable.Rows[0][1].ToString().Trim() + ":6 alt='点击这里给我发消息' align='absmiddle'></a>";
                        }
                    }
                }
                divOnline.InnerHtml = online;
            }
            //会员门户或个人信息
            long i = 1;
            long j = 1;
            long k = 1;
            string memberGrade = "";
            string strWhere1 = "";
            Tz888.BLL.Conn dal1 = new Tz888.BLL.Conn();
            strWhere1 = "loginName='" + view["contactName"].ToString().Trim() + "'";
            DataTable dt = dal1.GetList("loginInfoTab", "loginName", "memberGradeId", strWhere1, "loginName", ref i, k, ref j);
            if (dt != null && dt.Rows.Count > 0)
            {
                memberGrade = dt.Rows[0][0].ToString();
            }
            bool bl = (memberGrade.Trim()=="1002");
            //bool bl = true;
            if (bl)
            {
                img.Visible = true;
            }
            HyperLink hlk = new HyperLink();
            hlk = (HyperLink)e.Row.FindControl("hlkRefresh");
            HyperLink hlkPersonRefresh = new HyperLink();
            hlkPersonRefresh = (HyperLink)e.Row.FindControl("hlkPersonRefresh");
            HyperLink hlkEnRefresh = new HyperLink();
            hlkEnRefresh = (HyperLink)e.Row.FindControl("hlkEnRefresh");
            Tz888.BLL.GoodFriend friendBll=new Tz888.BLL.GoodFriend();
            Tz888.Model.GoodFriend friend=new Tz888.Model.GoodFriend();
            friend.LoginName = Page.User.Identity.Name;//"kiki";
            friend.ContactName=view["contactName"].ToString().Trim();
            //好友资源更新
            string strRefresh = friendBll.ResourceRefresh(friend);
            if (strRefresh.IndexOf("最近无更新") > -1)
            {
                hlk.Text = strRefresh;
                hlk.NavigateUrl = "";
            }
            else if (strRefresh.IndexOf("html") > -1)
            {
                hlk.Text = "发布了1条新需求";
                hlk.NavigateUrl = "http://www.topfo.com/" + strRefresh.Trim();
            }
            else
            {
                hlk.Text = "发布了" + strRefresh.Trim() + "条新需求";
                hlk.NavigateUrl = "FriendRefresh.aspx?contact=" + view["contactName"].ToString().Trim();
            }
            //好友资料更新
            string strPerRefresh = friendBll.MemberInfoRefresh(friend);
            if (strPerRefresh.IndexOf("最近无更新") > -1)
            {
                hlkPersonRefresh.Text = strRefresh;
                hlkPersonRefresh.NavigateUrl = "";
            }
            else 
            {
                hlkPersonRefresh.Text = strPerRefresh;
                hlkPersonRefresh.NavigateUrl = viewLink(view["contactName"].ToString().Trim());
            }
            //
            string strEnRefresh = "最近无更新";
            bool blRegister = friendBll.EnterpriseResfresh(friend);
            if (!blRegister)
            {
                strEnRefresh = "最近无更新";
            }
            else
            {
                strEnRefresh = "登记了公司信息";
            }
            if (strRefresh.IndexOf("最近无更新") > -1 && strPerRefresh.IndexOf("最近无更新") > -1 && strEnRefresh.IndexOf("最近无更新") > -1)
            {
                hlkEnRefresh.Visible = false;
                hlk.Visible = false;
                hlkPersonRefresh.Visible = true;
            }
            else if (strRefresh.IndexOf("最近无更新") > -1)
            {
                hlk.Visible = false;
            }
            else if (strPerRefresh.IndexOf("最近无更新") > -1)
            {
                hlkPersonRefresh.Visible = false;
            }
            else if (strEnRefresh.IndexOf("最近无更新") > -1)
            {
                hlkEnRefresh.Visible = false;
            }
           
        }
    }
    public string view(object view)
    {
        string name = view.ToString();
        string result = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "nickName", strWhere, "loginName", ref i, k, ref j);
        if (dt != null && dt.Rows.Count>0)
        {
            result = dt.Rows[0][0].ToString();
        }
        return result;
    }

    public string viewLink(object view)
    {

        string name = view.ToString();
        string manageType = "";
        string result = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "manageTypeId", strWhere, "loginName", ref i, k, ref j);
        if (dt != null && dt.Rows.Count > 0)
        {
            manageType = dt.Rows[0][0].ToString();
        }
        switch (manageType)
        {
            case "1001":
                result = "http://member.topfo.com/Register/MemberMessage_P.aspx?LoginName=" + name;
                break;
            case "1003":
                result = "http://member.topfo.com/Register/MemberMessage_E.aspx?LoginName=" + name;
                break;
            case "1004":
                result = "http://member.topfo.com/Register/MemberMessage_G.aspx?LoginName=" + name;
                break;
            default:
                result = "http://member.topfo.com/Register/MemberMessage_P.aspx?LoginName=" + name;
                break;
        }
        return result;
    }
    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        getList();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        getList();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        getList();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        getList();
    }
    protected void btnGo_ServerClick(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = txtPage.Value.Trim();
        getList();
    }
    protected void PageSize10_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 10;
        PageSize10.ForeColor = System.Drawing.Color.Red;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void PageSize20_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 20;
        PageSize20.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void PageSize30_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 30;
        PageSize30.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void ButtonInfoDelete_Click(object sender, EventArgs e)
    {
        //删除所选
        CheckBox chk;

        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();

        for (int i = 0; i < this.friendListGridView.Rows.Count; i++)
        {
            chk = (CheckBox)this.friendListGridView.Rows[i].Cells[0].FindControl("chkSelect");

            if (chk != null)
            {
                if (chk.Checked)
                {

                    int contactID = Convert.ToInt32(this.friendListGridView.DataKeys[i].Value);
                    friendBll.DeleteFriend(contactID);
                }
            }
        }
        getList();
    }
    protected void btnBlackList_Click(object sender, EventArgs e)
    {
        CheckBox chk;

        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();

        for (int i = 0; i < this.friendListGridView.Rows.Count; i++)
        {
            chk = (CheckBox)this.friendListGridView.Rows[i].Cells[0].FindControl("checkbox2");

            if (chk != null)
            {
                if (chk.Checked)
                {

                    int contactID = Convert.ToInt32(this.friendListGridView.DataKeys[i].Value);
                    friendBll.BlackListManage(contactID, 0);
                }
            }
        }
        getList();

    }
    protected void ButtonGroupSend_Click(object sender, EventArgs e)
    {

        HtmlInputCheckBox chk;
        HyperLink hpl;
        string name = "";
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();

        for (int i = 0; i < this.friendListGridView.Rows.Count; i++)
        {
            chk = (HtmlInputCheckBox)this.friendListGridView.Rows[i].Cells[0].FindControl("checkbox2");
            hpl = (HyperLink)this.friendListGridView.Rows[i].Cells[1].FindControl("hplContactName");
            if (chk != null)
            {
                //if (chk.Checked)//判断有问题
                //{
                //    name += hpl.Text.Trim() + "%";
                //}
                if (hpl.Text.Trim() != "")
                {
                    name += hpl.Text.Trim() + ",";
                }
            }
        }
        Response.Redirect("../../innerinfo/SendView.aspx?Ac=1&Name=" + name);
    }
    [AjaxPro.AjaxMethod]
    public string ToRecycle(string idList)
    {
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        string userName = Page.User.Identity.Name;
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                int contactID = Convert.ToInt32(s[i].Trim());
                friendBll.DeleteFriend(contactID);
            }
        }
        return "ok";
    }
    [AjaxPro.AjaxMethod]
    public string ToBlackList(string idList)
    {
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        string userName = Page.User.Identity.Name;
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                int contactID = Convert.ToInt32(s[i].Trim());
                friendBll.BlackListManage(contactID, 0);
            }
        }
        return "ok";
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string strWhere = "";
        string username = Page.User.Identity.Name;//"kiki";
        string contactName = this.txtSelectFriendName.Text;
        if (contactName == "请输入好友昵称")
        {
            contactName = "";
        }
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        strWhere = "loginName= '" + username + "'and groupId= '1'";
        if (contactName != "")
        {
            strWhere += " and nickName= '" + contactName + "'";
        }
        switch (Convert.ToInt32(this.DDListMemberType.SelectedValue))
        {
            case 0:
                break;
            case 1:
                strWhere += "and manageTypeId= '1004'";
                break;
            case 2:
                strWhere += "and manageTypeId= '1003'";
                break;
            case 3:
                strWhere += " and manageTypeId= '1001'";
                break;
        }
        if (Convert.ToInt32(this.DDListMemberGrade.SelectedValue) == 1)
        {
            strWhere += " and memberGradeId= '1002'";
        }
        else if (Convert.ToInt32(this.DDListMemberGrade.SelectedValue) == 2)
        {
            strWhere += " and memberGradeId= '1001'";

        }
        DataTable dt = dal.GetList("innerInfoContactManInfoVIW", "ContactId",
            "contactName,MemberGradeId,ManageTypeId,provinceName,cityName,countyName,ContactId,RegisterTime,requirInfo,nickName", strWhere, "ContactId desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        friendListGridView.DataSource = dt;
        friendListGridView.DataBind();
    }
}
