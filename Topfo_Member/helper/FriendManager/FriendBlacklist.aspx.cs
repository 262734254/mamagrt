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

public partial class helper_FriendManager_FriendBlacklist : Tz888.Common.Pager.BasePage
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_FriendManager_FriendBlacklist));

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
        strWhere = "loginName= '" + username + "' and groupId= '3'";
        DataTable dt = dal.GetList("innerInfoContactManInfoVIW", "ContactId",
            "contactName,MemberGradeId,ManageTypeId,provinceName,cityName,countyName,ContactId", strWhere, "ContactId desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lbCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        friendBlackListGridView.DataSource = dt;
        friendBlackListGridView.DataBind();
    }

    protected void friendBlackListGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView view = e.Row.DataItem as DataRowView;//定义一个DataRowView的实例
        HyperLink hpl = new HyperLink();
        Image img = new Image();
        Button btn = new Button();
        btn = (Button)e.Row.FindControl("btnAddFriend");
        //hpl = (HyperLink)e.Row.FindControl("hplContactName");
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
            e.Row.Cells[3].Text = view["provinceName"].ToString() + " " + view["cityName"].ToString() + " " + view["countyName"].ToString();
            //hpl.Text = view["ContactName"].ToString();
             btn.CommandName = view["contactId"].ToString()  ;
            //会员门户或个人信息
             long i = 1;
             long j = 1;
             long k = 1;
             string memberGrade = "";
             string strWhere = "";
             Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
             strWhere = "loginName='" + view["contactName"].ToString().Trim() + "'";
             DataTable dt = dal.GetList("loginInfoTab", "loginName", "memberGradeId", strWhere, "loginName", ref i, k, ref j);
             if (dt != null && dt.Rows.Count > 0)
             {
                 memberGrade = dt.Rows[0][0].ToString();
             }
             bool bl = (memberGrade.Trim() == "1002");
            if (bl)
            {
                img.Visible = true;
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
        if (dt != null && dt.Rows.Count > 0)
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
    protected void btnAddFriend_Click(object sender, EventArgs e)
    {
        Button btn;
        btn = (Button)sender;
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        friendBll.BlackListManage(Convert.ToInt32(btn.CommandName.Trim()), 1);
        getList();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chk;

        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();

        for (int i = 0; i < this.friendBlackListGridView.Rows.Count; i++)
        {
            chk = (CheckBox)this.friendBlackListGridView.Rows[i].Cells[0].FindControl("chkSelect");

            if (chk != null)
            {
                if (chk.Checked)
                {
                    //将选中的信息册除
                    int contactID = Convert.ToInt32(this.friendBlackListGridView.DataKeys[i].Value);
                    friendBll.DeleteFriend(contactID);
                }
            }
        }
        getList();
    }
    protected void btnOpen_Click(object sender, EventArgs e)
    {
        CheckBox chk;

        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();

        for (int i = 0; i < this.friendBlackListGridView.Rows.Count; i++)
        {
            chk = (CheckBox)this.friendBlackListGridView.Rows[i].Cells[0].FindControl("chkSelect");

            if (chk != null)
            {
                if (chk.Checked)
                {

                    int contactID = Convert.ToInt32(this.friendBlackListGridView.DataKeys[i].Value);
                    friendBll.BlackListManage(contactID, 1);
                }
            }
        }
        getList();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
        if (this.tboxName.Text.IndexOf(",") > -1)
        {
            string[] names = this.tboxName.Text.Trim().Split(',');
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].Trim() != "")
                {

                    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
                    string strWhere = "";
                    strWhere = "nickName='" + names[i].Trim() + "'";
                    long m = 1;
                    long j = 1;
                    long k = 1;
                    DataTable dt = dal.GetList("loginInfoTab", "loginName", "loginName", strWhere, "loginName", ref m, k, ref j);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        model.LoginName = Page.User.Identity.Name;
                        //model.LoginName = "kiki";
                        model.ContactName = dt.Rows[0][0].ToString();
                        model.GroupId = 3;
                        friendBll.AddFriend(model);
                    }
                    else
                    {
                        Response.Write("<script>alert('用户不存在')</script>");
                    }

                }
            }
        }
        else
        {
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            string strWhere = "";
            strWhere = "nickName='" + this.tboxName.Text.Trim() + "'";
            long i = 1;
            long j = 1;
            long k = 1;
            DataTable dt = dal.GetList("loginInfoTab", "loginName", "loginName", strWhere, "loginName", ref i, k, ref j);
            if (dt != null && dt.Rows.Count > 0)
            {
                model.LoginName = Page.User.Identity.Name;
                //model.LoginName = "kiki";
                model.ContactName = dt.Rows[0][0].ToString();
                model.GroupId = 3;
                friendBll.AddFriend(model);
            }
            else
            {
                Response.Write("<script>alert('用户不存在')</script>");
            }

        }
        getList();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        this.tboxName.Text = "";
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
    public string GoFriend(string idList)
    {
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        string userName = Page.User.Identity.Name;
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                int contactID = Convert.ToInt32(s[i].Trim());
                friendBll.BlackListManage(contactID, 1);
            }
        }
        return "ok";
    }
}
