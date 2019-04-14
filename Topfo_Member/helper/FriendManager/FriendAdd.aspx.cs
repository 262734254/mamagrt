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

public partial class helper_FriendManager_FriendAdd : Tz888.Common.Pager.BasePage
{
    private int manageGrade = 0;
    private int memberType = 0;
    private int flag = 0;
    private string memberName = "";
    private string memberIntent = "";
    private int provinceId = 0;
    private int cityId = 0;
    private int countyId = 0;
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
        memberName = Page.User.Identity.Name;

        if ((Request.QueryString["Flag"] != null) && (Request.QueryString["Flag"] != ""))
        {
            flag = 0;//精确查找
            memberName = Request.QueryString["Flag"].ToString();
        }
        else if ((Request.QueryString["Mg"] != null) && (Request.QueryString["Mg"] != ""))
        {
            flag = 1;//高级查找
            manageGrade = Convert.ToInt32(Request.QueryString["Mg"]);
            memberType = Convert.ToInt32(Request.QueryString["Mt"]);

            memberIntent = Request.QueryString["Mi"].ToString();
            if ((Request.QueryString["province"] != null) && (Request.QueryString["province"] != ""))
            {
                provinceId = Convert.ToInt32(Request.QueryString["province"]);
            }
            if ((Request.QueryString["city"] != null) && (Request.QueryString["city"] != ""))
            {
                cityId = Convert.ToInt32(Request.QueryString["city"]);
            }
            if ((Request.QueryString["county"] != null) && (Request.QueryString["county"] != ""))
            {
                countyId = Convert.ToInt32(Request.QueryString["county"]);
            }
        }
        if (Page.User.IsInRole("GT1002"))//判断用户是否拓富通会员
        {

            divhelp.Style.Add("display", "none");
        }
        else
        {
            divhelp.Style.Add("display", "block");
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

        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();

        if (flag == 0)
        {
            strWhere = "nickName= '" +Server.UrlDecode( memberName) + "'";
        }
        else if (flag == 1)
        {


            switch (memberType)
            {
                case 0:
                    strWhere = "manageTypeId= '1004'";
                    break;
                case 1:
                    strWhere = "manageTypeId= '1003'";
                    break;
                case 2:
                    strWhere = "manageTypeId= '1001'";
                    break;
            }
            if (manageGrade == 1)
            {
                strWhere += " and memberGradeId= '1001'";
            }
            else if (manageGrade == 2)
            {
                strWhere += " and memberGradeId= '1002'";

            }
            //意向处理
            if (memberIntent.Trim() != "")
            {
                if (memberIntent.IndexOf("%") > -1)
                {
                    string[] temp = memberIntent.Split('%');
                    if (temp[0].Trim() != "")
                    {
                        switch (temp[0].Trim())
                        {
                            case "0":
                                strWhere += " and (CHARINDEX('" + "1001" + "'," + "requirInfo" + ")>0)";
                                break;
                            case "1":
                                strWhere += " and (CHARINDEX('" + "1002" + "'," + "requirInfo" + ")>0)";
                                break;
                            case "2":
                                strWhere += " and (CHARINDEX('" + "1002" + "'," + "requirInfo" + ")>0)";
                                break;
                            case "3":
                                strWhere += " and (CHARINDEX('" + "1003" + "'," + "requirInfo" + ")>0)";
                                break;
                            case "4":
                                strWhere += " and (CHARINDEX('" + "1004" + "'," + "requirInfo" + ")>0)";
                                break;
                            case "5":
                                strWhere += " and (CHARINDEX('" + "1005" + "'," + "requirInfo" + ")>0)";
                                break;
                        }

                    }
                }
            }
            if (provinceId != 0)
            {
                strWhere += " and ProvinceID= '" + provinceId + "'";
            }
            if (cityId != 0)
            {
                strWhere += " and CityID= '" + cityId + "'";
            }
            if (countyId != 0)
            {
                strWhere += " and CountyID= '" + countyId + "'";
            }
        }

        //strWhere = "memberGradeId='1001'";//测试用


        DataTable dt = dal.GetList("MemberInfoVIW", "loginName",
            "loginName,MemberGradeId,ManageTypeId,requirInfo,provinceName,cityName,countyName", strWhere, "MemberGradeId desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        friendAddGridView.DataSource = dt;
        friendAddGridView.DataBind();
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
    protected void friendAddGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView view = e.Row.DataItem as DataRowView;//定义一个DataRowView的实例
        Image img = new Image();
        Button btn = new Button();
        btn = (Button)e.Row.FindControl("btnAddFriend");
        img = (Image)e.Row.FindControl("imgTopfo");
        if (view != null)
        {
            //2会员类型，3会员周期，6付费状态，7审核状态
            switch (view["ManageTypeId"].ToString().Trim())
            {
                case "1001":
                    e.Row.Cells[1].Text = "个人会员";
                    break;
                case "1003":
                    e.Row.Cells[1].Text = "企业会员";
                    break;
                case "1004":
                    e.Row.Cells[1].Text = "政府会员";
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
                other="...";
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
            e.Row.Cells[2].Text = reqInfo+other;

            //来自何处
            e.Row.Cells[3].Text = view["provinceName"].ToString() + " " + view["cityName"].ToString() + " " + view["countyName"].ToString();

            btn.CommandName = view["loginName"].ToString().Trim()+"_";
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
            //btn.CommandName = view["loginName"].ToString().Trim() + "_" + view["memberGradeId"].ToString().Trim() + "%" + view["manageTypeId"].ToString().Trim() + 
            //    "$" + view["requirInfo"].ToString().Trim();
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

    protected void btnAddFriend_Click(object sender, EventArgs e)
    {
        Button btn;
        btn = (Button)sender;
        bool blSuccess = false;
        bool grade = false;
        bool type = false;
        string name = btn.CommandName.Substring(0, btn.CommandName.IndexOf("_"));
        string memberGrade = btn.CommandName.Substring(btn.CommandName.IndexOf("_") + 1, btn.CommandName.IndexOf("%") - btn.CommandName.IndexOf("_")-1);
        string manageType = btn.CommandName.Substring(btn.CommandName.IndexOf("%") + 1, btn.CommandName.IndexOf("$") - btn.CommandName.IndexOf("%")-1);
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
        bool IsFriend = friendBll.IsSpecies(Page.User.Identity.Name,name , 1);
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
            else if(set.MemberGrade==0)
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
            model.ContactName = name;
            model.GroupId = 1;
            friendBll.AddFriend(model);
            //Response.Redirect("addsuccess.aspx?name=" + name);
            Response.Write("<script   language='JavaScript'>window.open('addsuccess.aspx?name=" +Server.UrlEncode( nickName) + "');</script>");
        }
        else
        {
            //Response.Redirect("adderror.aspx?name=" + name);
            Response.Write("<script   language='JavaScript'>window.open('adderror.aspx?name=" + Server.UrlEncode(nickName) + "');</script>");
        }
    }
    protected void ButtonOutExcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendList.aspx");
    }
    protected void ButtonInfoDelete_Click(object sender, EventArgs e)
    {
        Response.Redirect("FriendSearch.aspx");
    }
}
