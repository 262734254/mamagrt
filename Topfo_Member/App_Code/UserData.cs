using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Tz888.BLL;
using Tz888.BLL.Login;
using Tz888.Model;
using System.Data;
using System.IO;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI;

/// <summary>
/// UserData 的摘要说明



/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class UserData : System.Web.Services.WebService
{
    public UserData()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    /// <summary>
    ///  得到登陆用户基本信息
    /// </summary>
    /// <returns>会员等级_会员类别_已发信息_新收信息_全部收信息_积分余额_点数余额_用户名</returns>
    [WebMethod]
    public string GetUserData()
    {
        string str = "";

        string loginName = LoginInfoBLL.GetLoginUserNickName();
        if (loginName != "")
        {
            string sT = "";
            if (User.IsInRole("1001"))
            {
                sT = "1001";

            }
            else
            {
                sT = "1002";

            }

            str = GetLoginStrByLoginName(loginName);
            //str = "0_1001_0_0_0_40_1000_123";
        }
        return str;
    }
    /// <summary>
    /// 我的短消息



    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string dgGetInner()
    {
        try
        {
            //DataSet ds;
            //return ds.GetXml();

            StringWriter wr = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(wr);
            DataGrid dg = new DataGrid();
            StringBuilder sb = new StringBuilder();

            //读取用户的身份信息
            string LoginName = LoginInfoBLL.GetCookieContentByCookieType(0);

            Tz888.BLL.InnerInfo bll = new Tz888.BLL.InnerInfo();
            bll.CheckNewGroupMsg(LoginName);

            if (LoginName.Trim() != "")
            {
                Tz888.BLL.Conn conn = new Conn();
                Tz888.BLL.InnerInfoBLL bllInner = new InnerInfoBLL();
                string strWhere = "ReceivedName='" + LoginName + "' and isReaded=0";
                DataTable dt = conn.GetList("InnerInfoReceivedTab", "*", "ReceivedID", 3, 1, 0, 1, strWhere);
                DataTable dtCount = conn.GetList("InnerInfoReceivedTab", "ReceivedID", "ReceivedID", 1, 1, 1, 1, strWhere);
                
                //long lgPageCount = 0;
                //DataView dv = bllInner.dsGetAllInnerNoRead(LoginName, ref lgPageCount);

                sb.Append("<div class='notemsg1'>您共收到 <a href='/InnerInfo/inbox2.aspx' class='chenglink'>" +dtCount.Rows[0].ItemArray[0].ToString()+ "条</a>新短消息</div>");
                sb.Append("<table width=100% border=0 cellpadding=0 cellspacing=0 >");
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("<tr><td>标题</td><td>发件人</td><td>时间</td></tr>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        sb.Append("<tr>");
                        sb.Append("<td width=53%><a href='InnerInfo/infoView.aspx?Ac=1&ReceivedID=" + dt.Rows[i]["ReceivedID"].ToString() + "'>" + GetStr(dt.Rows[i]["Topic"].ToString().Trim(),13) + "</a></td>");
                        sb.Append("<td width=25%>" + dt.Rows[i]["SendedMan"].ToString().Trim() + "</td>");
                        sb.Append("<td width=23%>" + Convert.ToDateTime(dt.Rows[i]["ReceivedTime"].ToString().Trim()).ToString("yyyy-MM-dd") + "</td>");
                        sb.Append("</tr>");
                        if (i >4)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    sb.Append("<tr><td>您没有收到新的短消息！</td></tr>");
                }


                sb.Append("</table>");
                sb.Append("<div class='entermail'><a href='/InnerInfo/inbox2.aspx'  class='blue'>&gt;&gt;进入我的收件箱</a></div></div>");
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            err = "";
            return err;
        }
    }

    /// <summary>
    /// 给我的留言
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string dgGetRecieveMsg()
    {
        try
        {
            //DataSet ds;
            //return ds.GetXml();

            StringWriter wr = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(wr);
            DataGrid dg = new DataGrid();
            StringBuilder sb = new StringBuilder();

            //读取用户的身份信息


            string LoginName = LoginInfoBLL.GetCookieContentByCookieType(0);
            if (LoginName.Trim() != "")
            {
                Tz888.BLL.Login.LoginInfoBLL bllLoginInfo = new LoginInfoBLL();
                DataTable dt = new DataTable();
                //dt = bllInner.GetInfoListForUserCenter(LoginName, 0, 3, 1, 0);              
                long lgPageCount = 0;
                DataView dv = bllLoginInfo.dsGetAllMsgToMe(LoginName, ref lgPageCount);

                sb.Append("<div class='notemsg1'>您共收到 <a href='/helper/InfoComment/commentReceive.aspx' class='chenglink'>" + lgPageCount.ToString().Trim() + "条</a>的留言</div>");
                sb.Append("<table width=100% border=0 cellpadding=0 cellspacing=0 >");
                dt = dv.Table;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr><td>" + dt.Rows[i]["RealName"].ToString().Trim() + "在" + dt.Rows[i]["CommentTime"].ToString().Trim() + "给您留言</td><td><a href='#'>查看留言</a></td></tr>");
                        if (i > 5)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    sb.Append("<tr><td>当前没有任何留言信息！</td></tr>");
                }


                sb.Append("</table>");
                sb.Append("<div class='entermail'><a href='/helper/InfoComment/commentReceive.aspx'  class='blue'>&gt;&gt;我收到的留言</a></div></div>");
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            err = "";
            return err;
        }
    }

    public string GetStr(string str,int lenght)
    {
        if (str.Length > lenght)
        {
            return str.Substring(0, lenght) + "...";
        }
        else
        {
            return str;
        }
    }
    /// <summary>
    /// 我的订阅
    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string dgGetDingYue()
    {
        try
        {
            StringWriter wr = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(wr);
            StringBuilder sb = new StringBuilder();

            //读取用户的身份信息



            string LoginName = LoginInfoBLL.GetCookieContentByCookieType(0);
            if (LoginName.Trim() != "")
            {
                string sResult = GetDingYueCondition(LoginName.Trim());
                sb.Append(sResult);
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            err = "";
            return " ";
        }
    }



    /// <summary>
    /// 谁在关注我

    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string dgGetFocuseMe()
    {
        StringWriter wr = new StringWriter();
        HtmlTextWriter writer = new HtmlTextWriter(wr);
        StringBuilder sb = new StringBuilder();
        //读取用户的身份信息
        string LoginName = Tz888.BLL.Login.LoginInfoBLL.GetCookieContentByCookieType(0);
        if (LoginName.Trim() != "")
        {
            Tz888.BLL.Conn bllComm = new Tz888.BLL.Conn();
            DataTable dt = new DataTable();
            long CurrPage = 1;
            long AllCount = 0;
            dt = bllComm.GetList("innerinfocontactTab", "loginName", "*", "ContactName='" + LoginName + "' and groupid = 1", "ContactID", ref CurrPage, 4, ref AllCount);
            if (AllCount > 0)
            {
                sb.Append("<div class='notemsg1'>共有<a href='/helper/InfoCollection.aspx' class='chenglink'><span id='focusme'>" + AllCount.ToString() + "</span></a> 位用户将您添加为好友</div>");
            }
            else
            {
                sb.Append("<div class='notemsg1'>没有新用户将您添加为好友！</div>");
            }


            sb.Append("<table width=100% border=0 cellpadding=0 cellspacing=0 class='none'>");

            Tz888.BLL.Register.MemberInfoBLL member = new Tz888.BLL.Register.MemberInfoBLL();
            sb.Append("<tr>");
            string tdName = "";
            if (dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtMember = bllComm.GetList("LoginInfoTAB", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + dt.Rows[i]["loginName"].ToString().Trim() + "'");
                    string headImg = "";
                    //if (modelMem.HeadPortrait != "")
                    //    headImg = "http://images.topfo.com/" + modelMem.HeadPortrait;
                    //else
                    headImg = "../images/MemberData/nopic.gif";

                    sb.Append("<td width=28%><a target='_blank' href='/Register/MemberMessage_P.aspx?LoginName=" + dtMember.Rows[0]["LoginName"].ToString() + "'><img src='" + headImg + "' border='0' width='50' height='50' /></a></td>");
                    tdName += "<td><a target='_blank' href='/Register/MemberMessage_P.aspx?LoginName=" + dtMember.Rows[0]["LoginName"].ToString() + "'>" + dtMember.Rows[0]["NickName"].ToString() + "</a></td>";
                }
            sb.Append("</tr><tr>");
            sb.Append(tdName);
            sb.Append("</tr></table>");
            sb.Append("<div class='entermail'><a href='helper/FriendManager/FriendAttention.aspx'  class='blue'>&gt;&gt;进入我的关注信息</a></div></div>");
        }
        return sb.ToString();

    }

    ///好友更新
    ///
    [WebMethod]
    public string dgGetRefresh()
    {
        StringBuilder sb = new StringBuilder();
        string LoginName = Tz888.BLL.Login.LoginInfoBLL.GetCookieContentByCookieType(0);
        int allRefresh = 0;
        string nickName = "";
        if (LoginName.Trim() != "")
        {
            Tz888.BLL.Conn bllComm = new Tz888.BLL.Conn();
            DataTable dt = new DataTable();
            long CurrPage = 1;
            long AllCount = 0;
            dt = bllComm.GetList("innerinfocontactTab", "*", "ContactID", 4, 1, 0, 1, "loginName='" + LoginName + "' and groupid = 1");
            if (dt.Rows.Count == 0)
            {
                sb.Append("<div class='notemsg1'>您还没有添加好友！</div>");
            }
            sb.Append("<table width=100% border=0 cellpadding=0 cellspacing=0 class='none'>");
            sb.Append("<tr><td>更新内容</td><td>更新时间</td></tr>");
            Tz888.BLL.GoodFriend friendbll = new Tz888.BLL.GoodFriend();
            Tz888.Model.GoodFriend friend = new Tz888.Model.GoodFriend();
            DataTable dtInfo = new DataTable();
            DataTable dtMemberInfo = new DataTable();

            #region --获得用户昵称--



            #endregion

            #region
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                friend.LoginName = LoginName;
                friend.ContactName = dt.Rows[i]["contactName"].ToString().Trim();
                dtInfo = friendbll.ResourceRefreshDT(friend);

                string strWhere1 = "loginName='" + friend.ContactName + "'";
                DataTable dt2 = bllComm.GetList("loginInfoTab", "nickName", "nickName", 1, 1, 0, 1, strWhere1);

                if (dt2.Rows.Count > 0)
                {
                    nickName = dt2.Rows[0]["NickName"].ToString();
                }
                if (allRefresh > 3)
                {
                    break;
                }
                if (dtInfo.Rows.Count > 0)
                {
                    allRefresh += dtInfo.Rows.Count;
                    for (int j = 0; j < dtInfo.Rows.Count; j++)
                    {
                        if (allRefresh > 3)
                        {
                            break;
                        }
                        sb.Append("<tr>");
                        sb.Append("<td width=58%><a target='_blank' title='" + dtInfo.Rows[i]["title"].ToString().Trim() +
                            "' href='http://www.topfo.com/" + dtInfo.Rows[i]["HtmlFile"].ToString().Trim() + "'>"
                            + nickName + "发布了1个需求" + "</a></td>");
                        sb.Append("<td width=20%>" + dtInfo.Rows[i]["approveTime"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                }
                dtMemberInfo = friendbll.MemberInfoRefreshDt(friend);
                if (dtMemberInfo.Rows.Count > 0)
                {
                    allRefresh += dtInfo.Rows.Count;
                    string strLink = "";
                    #region --查看用户资料页面--
                    string name = friend.ContactName;
                    string manageType = "";
                    string result = "";
                    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
                    string strWhere = "";
                    strWhere = "loginName='" + name.Trim() + "'";
                    long m = 1;
                    long n = 1;
                    long k = 1;
                    DataTable dt1 = bllComm.GetList("loginInfoTab", "loginName", "manageTypeId", strWhere, "loginName", ref m, k, ref n);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        manageType = dt1.Rows[0][0].ToString();
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
                    strLink = result;
                    #endregion

                    for (int j = 0; j < dtMemberInfo.Rows.Count; j++)
                    {
                        if (allRefresh > 3)
                        {
                            break;
                        }
                        sb.Append("<tr>");
                        sb.Append("<td width=58%><a target='_blank' title='" + dtMemberInfo.Rows[i]["Remarks"].ToString().Trim() +
                            "' href='" + strLink + "'>"
                            + nickName + "修改了" + dtMemberInfo.Rows[i]["Remarks"].ToString().Trim() + "</a></td>");
                        sb.Append("<td width=20%>" + dtMemberInfo.Rows[i]["updated"].ToString() + "</td>");
                        sb.Append("</tr>");
                    }
                }
            }
            sb.Append("</table>");
            sb.Append("<div class='entermail'><a href='/helper/FriendManager/FriendList.aspx'  class='blue'>&gt;&gt;进入好友更新列表</a></div></div>");
            if (AllCount == 0)
            {
                sb.Insert(0, "<div class='notemsg1'>您没有好友更新信息！</div>");
            }
            #endregion

        }
        return sb.ToString();
    }


    /// <summary>
    /// 我的购物车



    /// </summary>
    /// <returns></returns>
    [WebMethod]
    public string dgGetCart()
    {
        try
        {
            //DataSet ds;
            //return ds.GetXml();

            StringWriter wr = new StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(wr);
            StringBuilder sb = new StringBuilder();


            //读取用户的身份信息



            string LoginName = LoginInfoBLL.GetCookieContentByCookieType(0);
            if (LoginName.Trim() != "")
            {
                Tz888.BLL.Common.CommonFunction bllComm = new Tz888.BLL.Common.CommonFunction();
                DataTable dt = new DataTable();
                //dt = bllInner.GetInfoListForUserCenter(LoginName, 0, 3, 1, 0);
                long CurrPage = 1;
                long AllCount = 0;
                dt = bllComm.GetDTFromTableOrView("shopcarViw", "ShopCarID", "*", "LoginName='" + LoginName.Trim() + "'", "ShopCarID", ref CurrPage, 3, ref AllCount);

                //dg.AutoGenerateColumns = false;
                //dg.Columns[0].HeaderText = "发送人";
                //dg.Columns[1].HeaderText = "主题发送时间";
                //dg.Columns[2].HeaderText = "主题";
                //dg.ShowHeader = false;
                //dg.DataSource = dt.DefaultView;
                //dg.Width = 588;
                //dg.DataBind();

                sb.Append("<div class='notemsg1'>您的购物车中共有<a href='/PayManage/trade_info_wait.aspx' class='chenglink'><span id='shopCartCount'>" + AllCount + "</span>条</a>未付款的资源</div>");

                sb.Append("<table width=100% border=0 cellpadding=0 cellspacing=0 >");
                sb.Append("<tr><td>资源标题</td><td>价格(元)</td></tr>");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td width=58%><a target='_blank' title='" + dt.Rows[i]["SourceType"].ToString().Trim() + "' href='http://www.topfo.com/" + dt.Rows[i]["HtmlFile"].ToString().Trim() + "'>" + GetStr(dt.Rows[i]["SourceType"].ToString().Trim(),18) + "</a></td>");
                    sb.Append("<td width=20%>" + Convert.ToInt32( dt.Rows[i]["WorthPoint"].ToString())*0.8 + "</td>");
                    sb.Append("</tr>");
                    if (i > 5)
                    {
                        break;
                    }
                }
                sb.Append("</table>");
                sb.Append("<div class='entermail'><a href='/PayManage/trade_info_wait.aspx'  class='blue'>&gt;&gt;进入我的购物车</a></div></div>");
            }
            return sb.ToString();
        }
        catch (Exception ex)
        {
            string err = ex.Message.ToString();
            err = "";
            return err;
        }
    }

    /// <summary>
    /// 通过LoginName 得到用户登录时所需要的信息字符串



    /// </summary>
    /// <param name="LoginName"></param>
    /// <returns></returns>
    public string GetLoginStrByLoginName(string LoginName)
    {
        string str = "";
        string loginName = LoginInfoBLL.GetCookieContentByCookieType(0);
        if (loginName != "")
        {
            Tz888.BLL.Login.LoginInfoBLL LoginInfoBll = new LoginInfoBLL();

            DataTable dtLogin = LoginInfoBll.GetLoginInfoByLoginName(LoginName);
            if (dtLogin != null && dtLogin.Rows.Count > 0)
            {
                //等级信息 星级
                str += dtLogin.Rows[0]["MemberGradeParamID"].ToString().Trim();
                //会员类别,普通\VIP
                str += "_" + dtLogin.Rows[0]["MemberGradeID"].ToString().Trim();

                //内部信箱收发信息
                long CountNoReaded = 0;
                long CountReceived = 0;
                if (dtLogin.Rows[0]["CountNoReaded"] != null && dtLogin.Rows[0]["CountNoReaded"].ToString().Trim() != "")
                {
                    CountNoReaded = Convert.ToInt32(dtLogin.Rows[0]["CountNoReaded"].ToString().Trim());
                }
                if (dtLogin.Rows[0]["CountReceived"] != null && dtLogin.Rows[0]["CountReceived"].ToString().Trim() != "")
                {
                    CountReceived = Convert.ToInt32(dtLogin.Rows[0]["CountReceived"].ToString().Trim());
                }

                //发布信息                
                int iInfoPublishFreeCount = 0;
                int iInfoPublishNoFreeCount = 0;
                int publishCount = 0;

                if (dtLogin.Rows[0]["InfoPublishFreeCount"] != null && dtLogin.Rows[0]["InfoPublishFreeCount"].ToString().Trim() != "")
                {
                    iInfoPublishFreeCount = Convert.ToInt32(dtLogin.Rows[0]["InfoPublishFreeCount"].ToString().Trim());
                }
                if (dtLogin.Rows[0]["InfoPublishNoFreeCount"] != null && dtLogin.Rows[0]["InfoPublishNoFreeCount"].ToString().Trim() != "")
                {
                    iInfoPublishNoFreeCount = Convert.ToInt32(dtLogin.Rows[0]["InfoPublishNoFreeCount"].ToString().Trim());
                }
                publishCount = iInfoPublishFreeCount + iInfoPublishNoFreeCount;

                //帐户余额及点数



                double fIntegralSum = 0;
                double fWorthPoint = 0;

                if (dtLogin.Rows[0]["IntegralSum"] != null && dtLogin.Rows[0]["IntegralSum"].ToString().Trim() != "")
                {
                    fIntegralSum = Convert.ToDouble(dtLogin.Rows[0]["IntegralSum"].ToString().Trim());
                }
                if (dtLogin.Rows[0]["WorthPoint"] != null && dtLogin.Rows[0]["WorthPoint"].ToString().Trim() != "")
                {
                    fWorthPoint = Convert.ToDouble(dtLogin.Rows[0]["WorthPoint"].ToString().Trim());
                }


                //收发信息
                str += "_" + publishCount.ToString() + "_" + CountNoReaded.ToString() + "_" + CountReceived.ToString();

                //帐户余额
                str += "_" + fIntegralSum + "_" + fWorthPoint;
                str += "_" + LoginName;
                str += "_" + dtLogin.Rows[0]["NickName"].ToString();

            }
        }
        return str;
    }



    #region 获取查询结果
    /// <summary>
    /// 获取查询结果
    /// </summary>
    /// <param name="LoginName"></param>
    /// <returns></returns>
    private string GetDingYueCondition(string LoginName)
    {
        string SelectCol = "*";
        string Criteria = " LoginName='" + LoginName + "'";
        Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
        DataTable dt = obj.GetList("CustomInfoTab", "*", "ID", 1, 1, 0, 1, Criteria);
        StringBuilder sb = new StringBuilder();
        StringBuilder sbTemp = new StringBuilder();
        long iAllCount = 0;
        string str = "";
        if (dt.Rows.Count > 0)//已设置订阅
        {
            sbTemp.Append("<table width=100% border=0 cellpadding=0 cellspacing=0 >");
            sbTemp.Append("<tr><td >资源名称</td><td>发布时间</td></tr>");
           for (int i = 0; i < dt.Rows.Count; i++)
           {
                //查询条件
                string sCondtion = SetDingYueCondition(dt.Rows[i]);
                //数据源名称
                string sViewName = GetViewNameByCustomType(dt.Rows[i]["CustomType"].ToString().Trim());

                Tz888.BLL.Common.CommonFunction bllComm = new Tz888.BLL.Common.CommonFunction();
                DataTable dtResult = new DataTable();
                long CurrPage = 1;
                long AllCount = 0;
                dtResult = bllComm.GetDTFromTableOrView(sViewName, "InfoID", "*", sCondtion, "InfoID", ref CurrPage, 10, ref AllCount);

                if (dtResult.Rows.Count>0)
                    for (int m = 0; m < 3; m++)
                    {
                        string title = dtResult.Rows[m]["title"].ToString();
                        if(title.Length > 16)
                             title = title.Substring(0, 16) + "...";
                        DateTime date = Convert.ToDateTime(dtResult.Rows[m]["publishT"].ToString());
        
                        sbTemp.Append("<tr>");
                        sbTemp.Append("<td><a href='http://www.topfo.com/"+ dtResult.Rows[m]["HtmlFile"].ToString() +"' target='_blank'>" + title + "</a></td>");
                        sbTemp.Append("<td>" + date.ToShortDateString()+ "</td>");
                        sbTemp.Append("</tr>");
                    }
                iAllCount = iAllCount + AllCount;
            }


            sbTemp.Append("</table>");

            sb.Append("<div class='notemsg1'>您共有<a href='helper/MachingMessage.aspx?ID=" + dt.Rows[0]["id"] + "' class='blue'><span id='diyueCount'>" + iAllCount.ToString() + "</span></a>条订阅信息</div>");
            sb.Append(sbTemp.ToString().Trim());
            sb.Append("<div class='entermail'><a href='helper/MachingMessage.aspx?ID="+ dt.Rows[0]["id"].ToString() +"' class='blue'>&gt;&gt;查看更多订阅资源</a></div></div>");
            str=sb.ToString();
        }
        else
        {
            sb.Append("<div>您没有新的订阅资源</div>");
            sb.Append("<table><tr><td>您还没有设置任何订阅条件，<a href='helper/MatchingInfo.aspx'>点此立即设置</a></td></tr></table>");
            str=sb.ToString().Trim();
        }
        return str;
    }
    #endregion




    #region 获取查询条件

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dr"></param>
    /// <returns></returns>

    private string SetDingYueCondition(DataRow dr)
    {
        string strCustomType = dr["CustomType"].ToString(); //this.ViewState[ "CustomType" ].ToString();		

        //对已经取得的查询条件不再取


        string strCriteria = "";

        if (strCustomType.Trim() != "")
        {

            Tz888.Model.CustomInfoModel CustomInfo = new Tz888.Model.CustomInfoModel();

            if (dr["Calling"] != null)
            {
                CustomInfo.Calling = dr["Calling"].ToString();
            }
            if (dr["CustomType"] != null)
            {
                CustomInfo.CustomType = Convert.ToInt32(dr["CustomType"].ToString());
            }
            if (dr["Genre"] != null)
            {
                CustomInfo.Genre = dr["Genre"].ToString();
            }
            if (dr["Keyword"] != null)
            {
                CustomInfo.Keyword = dr["Keyword"].ToString();
            }

            if (dr["LoginName"] != null)
            {
                CustomInfo.LoginName = dr["LoginName"].ToString();
            }
            if (dr["Money"] != null)
            {
                CustomInfo.Money = dr["Money"].ToString();
            }
            if (dr["SmallCalling"] != null)
            {
                CustomInfo.SmallCalling = dr["SmallCalling"].ToString();
            }
            if (dr["Type"] != null)
            {
                CustomInfo.Type = dr["Type"].ToString();
            }
            if (dr["City"] != null)
            {
                CustomInfo.City = dr["City"].ToString();
            }

            if (dr["CooperationDemandTypeID"] != null)
            {
                CustomInfo.CooperationDemandTypeID = dr["CooperationDemandTypeID"].ToString();
            }
            else
            {
                CustomInfo.CooperationDemandTypeID = "";
            }


            //招商
            if (strCustomType == "0")
            {
                if (CustomInfo.Type.Trim() != "")
                {
                    strCriteria = "MerchantTypeID IN(";
                    string[] arrType = CustomInfo.Type.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND (";
                    }
                    else
                    {
                        strCriteria = " (";
                    }
                    string[] arrType = CustomInfo.Calling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "IndustryClassList like '%" + arrType[i] + "%' OR ";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 4) + ")";
                }

                if (CustomInfo.City != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND ProvinceID IN (";
                    }
                    else
                    {
                        strCriteria = " ProvinceID IN (";
                    }

                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }


                if (CustomInfo.CooperationDemandTypeID != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND CooperationDemandType IN (";
                    }
                    else
                    {
                        strCriteria = " CooperationDemandType IN (";
                    }

                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND Keyword like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "Keyword like '%" + CustomInfo.Keyword + "%'";
                    }
                }
            }
            //投资
            else if (strCustomType == "1")
            {
                if (CustomInfo.Genre.Trim() != "")
                {
                    strCriteria = "CapitalTypeID IN(";
                    string[] arrType = CustomInfo.Genre.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Money.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND CapitalID IN (";
                    }
                    else
                    {
                        strCriteria = " CapitalID IN (";
                    }

                    strCriteria = "CapitalID IN(";
                    string[] arrType = CustomInfo.Money.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryBID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryBID IN (";
                    }
                    string[] arrType = CustomInfo.Calling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.SmallCalling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryMID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryMID IN (";
                    }

                    string[] arrType = CustomInfo.SmallCalling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }


                if (CustomInfo.CooperationDemandTypeID != "")
                {

                }

                if (CustomInfo.Keyword != "")
                {

                }

            }
            //融资
            else if (strCustomType == "2")
            {
                if (CustomInfo.Money.Trim() != "")
                {
                    strCriteria = "CapitalID IN(";
                    string[] arrType = CustomInfo.Money.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryBID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryBID IN (";
                    }
                    string[] arrType = CustomInfo.Calling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.SmallCalling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryMID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryMID IN (";
                    }

                    string[] arrType = CustomInfo.SmallCalling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.City != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND ProvinceID IN (";
                    }
                    else
                    {
                        strCriteria = " ProvinceID IN (";
                    }

                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.CooperationDemandTypeID != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND CooperationDemandType IN (";
                    }
                    else
                    {
                        strCriteria = " CooperationDemandType IN (";
                    }

                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "")
                        {
                            strCriteria = strCriteria + "'" + arrType[i] + "',";
                        }
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }


                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND ProjectAbout like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "ProjectAbout like '%" + CustomInfo.Keyword + "%'";
                    }
                }
            }


                //创业
            else if (strCustomType == "3")
            {
                if (CustomInfo.Money.Trim() != "")
                {
                    strCriteria = "CapitalID IN(";
                    string[] arrType = CustomInfo.Money.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryCarveOutID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryCarveOutID IN (";
                    }
                    string[] arrType = CustomInfo.Calling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.SmallCalling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryCarveOutID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryCarveOutID IN (";
                    }

                    string[] arrType = CustomInfo.SmallCalling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.City != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND ProvinceID IN (";
                    }
                    else
                    {
                        strCriteria = " ProvinceID IN (";
                    }

                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }


                if (CustomInfo.CooperationDemandTypeID != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND CooperationDemandType IN (";
                    }
                    else
                    {
                        strCriteria = " CooperationDemandType IN (";
                    }

                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }
                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND Title like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "Title like '%" + CustomInfo.Keyword + "%'";
                    }
                }
            }


            //商机
            else if (strCustomType == "4")
            {

                if (CustomInfo.Type.Trim() != "")
                {
                    strCriteria = "OpportunityType IN(";
                    string[] arrType = CustomInfo.Type.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }


                if (CustomInfo.Calling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryOpportunityID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryOpportunityID IN (";
                    }
                    string[] arrType = CustomInfo.Calling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.SmallCalling.Trim() != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND IndustryOpportunityID IN (";
                    }
                    else
                    {
                        strCriteria = " IndustryOpportunityID IN (";
                    }

                    string[] arrType = CustomInfo.SmallCalling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.City != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND ProvinceID IN (";
                    }
                    else
                    {
                        strCriteria = " ProvinceID IN (";
                    }

                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND Title like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "Title like '%" + CustomInfo.Keyword + "%'";
                    }
                }
            }
            //资讯
            else if (strCustomType == "5")
            {
                if (CustomInfo.Type.Trim() != "")
                {
                    strCriteria = "NewsTypeID IN(";
                    string[] arrType = CustomInfo.Type.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }


                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND Title like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "Title like '%" + CustomInfo.Keyword + "%'";
                    }
                }
                strCriteria = "Title like '%" + CustomInfo.Keyword + "%'";
            }
        }
        return strCriteria;
    }
    #endregion

    #region 获取查询的视图名称


    /// <summary>
    /// 
    /// </summary>
    /// <param name="CustomType"></param>
    /// <returns></returns>
    private string GetViewNameByCustomType(string strCustomType)
    {
        string ViewName = "";
        if (strCustomType == "0")
        {
            ViewName = "MerchantInfo_VIW_noindex";//"MerchantInfo_VIW";
        }
        else if (strCustomType == "1")
        {
            ViewName = "ProjectInfo_VIW_noindex";// "CapitalInfo_VIW";
        }
        else if (strCustomType == "2")
        {
            ViewName = "ProjectInfo_noindex";// "ProjectInfo_VIW";
        }

        else if (strCustomType == "3")
        {
            ViewName = "CarveOutInfo_Front_VIW";
        }

        else if (strCustomType == "4")
        {
            ViewName = "OpportunityInfo_Front_VIW";
        }
        else if (strCustomType == "5")
        {
            ViewName = "News_Front_VIW";
        }
        return ViewName;
    }
    #endregion
}

