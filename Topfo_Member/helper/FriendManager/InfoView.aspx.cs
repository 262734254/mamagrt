﻿using System;
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
using AdSystem;

public partial class helper_FriendManager_InfoView : Tz888.Common.Pager.BasePage
{
    public AdSystem.Logic loc;
    protected int pointTotal = 0;
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_FriendManager_InfoView));

        loc = new AdSystem.Logic();

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
        string username = Page.User.Identity.Name;//  "mengfeitz";  //
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        strWhere = "Info_loginName= '" + username + "' ";
        DataTable dt = dal.GetList("InfoViewViw", "View_ID",
            "*", strWhere, "View_AddTime desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lbCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        friendAttentionGridView.DataSource = dt;
        friendAttentionGridView.DataBind();

    }

    protected void friendAttentionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView view = e.Row.DataItem as DataRowView;//定义一个DataRowView的实例

        Image img = new Image();
        Button btn = new Button();
        btn = (Button)e.Row.FindControl("btnAddFriend");

        ///------------------------------
        ///--design by AdSystem_20090623
        ///------------------------------
        Button btn1 = (Button)e.Row.FindControl("Button1");


        img = (Image)e.Row.FindControl("imgTopfo");
        if (view != null)
        {
            btn1.CommandName = view["View_ID"].ToString().Trim() + "_" + view["MainPointCount"].ToString() + "_" + view["loginName"].ToString().Trim();
            btn1.Text = loc.ViewInfo_IsBuy(Convert.ToInt64(view["View_ID"].ToString().Trim()), view["loginName"].ToString().Trim()) ? "已购买" : "购买";
            if (btn1.Text == "购买")
            {
                string userLoginname = view["loginName"].ToString().Trim();

                //开始计算点数总和
                pointTotal = 0;

                DataTable dtuser = getUserInfoPrice(userLoginname);
                DataTable dtcom = getCompanyInfo(userLoginname);

                if (dtcom.Rows[0]["Tel"].ToString() != "")
                    pointTotal += 1;
                if (dtcom.Rows[0]["Email"].ToString() != "")
                    pointTotal += 1;
                if(dtuser.Rows.Count>0)
                {
                if (dtuser.Rows[0]["Address"].ToString() != "")
                    pointTotal += 2;
                    }
                if (dtcom.Rows[0]["CompanyName"].ToString() != "")
                    pointTotal += 5;

                btn1.Attributes.Add("onclick", "Javascript:return confirm('查看此用户信息需花费" + pointTotal.ToString() + "元，是否要购买');");
            }
            else
            {
                //btn1.Attributes.Add("onclick", "Javascript:alert('此信息已购买..'); return false;");
                btn1.Attributes.Add("onclick", "Javascript:return false;");
                btn1.Style.Add("color", "gray");
                btn1.Style.Add("text-decoration", "none");
            }

            // OnClientClick="return confirm('查看此用户信息需要花费1元，是否要购买');"

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
            //会员意向
            string[] requireInfo = view["requirInfo"].ToString().Trim().Split(',');
            string reqInfo = "";
            int reqCount = 0;
            string other = "";
            if (requireInfo.Length > 3)
            {
                reqCount = 3;
                other = "...";
            }
            else
            {
                reqCount = requireInfo.Length;
                other = "";
            }
            for (int i = 0; i < reqCount; i++)
            {
                if (requireInfo[i].Trim() != "")
                {
                    switch (requireInfo[i].Trim())
                    {
                        case "1001":
                            reqInfo += "政府招商 ";
                            break;
                        case "1002":
                            reqInfo += "企业招商 ";
                            break;
                        case "1003":
                            reqInfo += "项目融资 ";
                            break;
                        case "1004":
                            reqInfo += "项目投资 ";
                            break;
                        case "1005":
                            reqInfo += "创业合作 ";
                            break;
                        default:
                            break;
                    }
                }
            }
            e.Row.Cells[3].Text = reqInfo + other;

            //来自何处
            e.Row.Cells[4].Text = view["provinceName"].ToString() + " " + view["cityName"].ToString() + " " + view["countyName"].ToString();
            e.Row.Cells[5].Text = view["View_AddTime"].ToString();

            btn.CommandName = view["loginName"].ToString().Trim() + "_";
            if (view["memberGradeId"].ToString().Trim() != "")
            {
                btn.CommandName += view["memberGradeId"].ToString().Trim();
            }
            else
            {
                btn.CommandName += "0000";
            }
            btn.CommandName += "%";
            if (view["manageTypeId"].ToString().Trim() != "")
            {
                btn.CommandName += view["manageTypeId"].ToString().Trim();
            }
            else
            {
                btn.CommandName += "0000";
            }
            btn.CommandName += "$";
            if (view["requirInfo"].ToString().Trim() != "")
            {
                btn.CommandName += view["requirInfo"].ToString().Trim();
            }
            else
            {
                btn.CommandName += "0000";
            }
            //会员门户或个人信息
            long m = 1;
            long j = 1;
            long k = 1;
            string memberGrade = "";
            string strWhere = "";
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            strWhere = "loginName='" + view["loginName"].ToString().Trim() + "'";
            DataTable dt = dal.GetList("loginInfoTab", "loginName", "memberGradeId", strWhere, "loginName", ref m, k, ref j);
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

    #region view
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
                result = "/Register/MemberMessage_P.aspx?LoginName=" + name;
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
        return result.Trim();
    }

    public string viewLink(object view,object view2)
    {
        string name = view.ToString();
        string viewid = view2.ToString();
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
                result = "/Register/MemberMessage_P.aspx?LoginName=" + name.Trim() + "&v=" + viewid.Trim();
                break;
            case "1003":
                result = "http://member.topfo.com/Register/MemberMessage_E.aspx?LoginName=" + name.Trim() + "&v=" + viewid.Trim();
                break;
            case "1004":
                result = "http://member.topfo.com/Register/MemberMessage_G.aspx?LoginName=" + name.Trim() + "&v=" + viewid.Trim();
                break;
            default:
                result = "http://member.topfo.com/Register/MemberMessage_P.aspx?LoginName=" + name.Trim() + "&v=" + viewid.Trim();
                break;
        }
        return result.Trim();
    }
    #endregion

    #region page
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
    #endregion

    protected void Button1_Click(object sender, EventArgs e)
    {
        ///------------------------------
        ///--design by AdSystem_20090623
        ///------------------------------
        Button btn;
        btn = (Button)sender;
        long Viewid = Convert.ToInt32(btn.CommandName.Split('_')[0]);
        string MainPointCount = btn.CommandName.Split('_')[1];
        string loginname = btn.CommandName.Split('_')[2];

        Tz888.BLL.Pay dal = new Tz888.BLL.Pay();

        //生成订单ID
        int orderno = dal.CreateUserInfoOrder(loginname, pointTotal);

        if (orderno != 0)
        {
            //取得用户账户余额
            double userpoint = OnlineStrike.getUserPoint(loginname);

            if (userpoint < Convert.ToDouble(pointTotal))
            {
                Response.Write("<script>alert('点数不够')</script>");
            }
            else
            {
                int state = dal.ConsumePayUserInfo(orderno, Viewid, loginname, pointTotal, "account");

                if (state == 0)
                {
                    
                }

                else
                {
                    Response.Write("<script>alert('用户信息购买失败')</script>");
                }
            }
        }

        #region 原处理方法
        //int state = 0;
        //try
        //{
        //    state = loc.ViewInfo_Buy(Convert.ToInt64(Viewid));//, Convert.ToInt32(MainPointCount)
        //    string retStr = "";
        //    if (state == 1)
        //    {
        //        retStr = "购买成功";
        //    }
        //    else if (state == 0)
        //        retStr = "无此浏览信息";
        //    else if (state == 2)
        //        retStr = "您的点数不够";
        //    else
        //        retStr = "您购买失败，请重试";
        //    Response.Write("<script   language='JavaScript'>alert('" + retStr + "');</script>");
        //}
        //catch
        //{
        //    Response.Write("<script   language='JavaScript'>alert('购买失败');</script>");
        //}
        #endregion
    }

    /// <summary>
    /// 获取用户信息的价格
    /// </summary>
    /// <param name="useID">用户ID</param>
    /// <returns>用户信息</returns>
    protected DataTable getUserInfoPrice(string loginname)
    {
        string strwhere = "loginName='" + loginname.Trim() + "'";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("memberinfotab", "loginName", "*", strwhere, "loginName", ref i, k, ref j);

        return dt;
    }

    protected DataTable getCompanyInfo(string loginname)
    {
        string strwhere = "loginName='" + loginname.Trim() + "'";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("logininfotab", "loginName", "*", strwhere, "loginName", ref i, k, ref j);

        return dt;
    }

    protected void btnAddFriend_Click(object sender, EventArgs e)
    {

        Button btn;
        btn = (Button)sender;
        bool blSuccess = false;
        bool grade = false;
        bool type = false;
        string name = btn.CommandName.Substring(0, btn.CommandName.IndexOf("_"));        
        string memberGrade = btn.CommandName.Substring(btn.CommandName.IndexOf("_") + 1, btn.CommandName.IndexOf("%") - btn.CommandName.IndexOf("_") - 1);
        string manageType = btn.CommandName.Substring(btn.CommandName.IndexOf("%") + 1, btn.CommandName.IndexOf("$") - btn.CommandName.IndexOf("%") - 1);
        string memberIntent = btn.CommandName.Substring(btn.CommandName.IndexOf("$") + 1);
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        Tz888.Model.GoodFriend set = new Tz888.Model.GoodFriend();

        bool IsBlack = friendBll.IsSpecies(name, Page.User.Identity.Name, 3);
        //bool IsBlack = friendBll.IsSpecies("huangleon", "beckycheng", 3);
        if (IsBlack)
        {
            Response.Write("<script>alert('添加好友失败！您被加入黑名单')</script>");
            return;
        }
        bool IsFriend = friendBll.IsSpecies(Page.User.Identity.Name, name, 1);
        //bool IsFriend = friendBll.IsSpecies("huangleon", "beckycheng", 1);
        if (IsFriend)
        {
            Response.Write("<script>alert('添加好友失败！用户已在好友列表中')</script>");
            return;
        }
        if (name.Trim() == Page.User.Identity.Name.Trim())
        {
            Response.Write("<script>alert('添加好友失败！不能添加自己为好友')</script>");
            return;
        }

        set = friendBll.GetFriendSet(name);
        if (set != null)
        {
            if (set.MemberGrade == 2)
            {
                if (memberGrade == "1001")
                {
                    grade = true;
                }
                else if (Page.User.IsInRole("GT1002"))
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
            if (type)
            {
                //if (set.MemberIntent == 0)
                //{
                //    if (memberIntent == "1001")
                //    {
                //        blSuccess = true;
                //    }
                //}
                //else if (set.MemberIntent == 1)
                //{
                //    if (memberIntent == "1002")
                //    {
                //        blSuccess = true;
                //    }
                //}
                //else
                //{
                    blSuccess = true;//测试用
                //}
            }
        }
        else
        {
            blSuccess = true;
        }

        string nickName = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "nickName", strWhere, "loginName", ref i, k, ref j);
        if (dt != null && dt.Rows.Count > 0)
        {
            nickName = dt.Rows[0][0].ToString();
        }

        if (blSuccess)
        {
            Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
            model.LoginName = Page.User.Identity.Name;
            //model.LoginName = "sunray";
            model.ContactName = name;
            model.GroupId = 1;
            friendBll.AddFriend(model);
            Response.Write("<script   language='JavaScript'>window.open('addsuccess.aspx?name=" + Server.UrlEncode(nickName) + "');</script>");
        }
        else
        {
            Response.Write("<script   language='JavaScript'>window.open('adderror.aspx?name=" + Server.UrlEncode(nickName) + "');</script>");
        }
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
                friendBll.BlackListManage(Convert.ToInt32(s[i]), 0);
            }
        }
        return "ok";
    }
}
