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
public partial class helper_test : System.Web.UI.Page
{
    Tz888.BLL.SendNotice send = new Tz888.BLL.SendNotice();
    public long InfoID;
    bool site = false; //站内短信是否执行
    bool phone = false;//手机短信是否执行
    bool email = false;//Email短信是否执行
    protected string loginname = "";
    public string SubType = "";//推广类型
    string descript = "";
    string infotypeid = "";
    string htmlFile = "";
    string[] SubscribeType = new string[] { };
    public int id = 0;
    int recId = 0;
    string title = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (Request.QueryString["id"] != null && Request.QueryString["id"].Trim() != "")
        {
            //推广
            id = Convert.ToInt32(Request.QueryString["id"].Trim().ToString());
        }
        if (Request.QueryString["recId"] != null && Request.QueryString["recId"].Trim() != "")
        {
            //订单详情
            recId = Convert.ToInt32(Request.QueryString["recId"].Trim().ToString());
        }
        loginname = Page.User.Identity.Name;
        if (!Page.IsPostBack)
        {
            Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
            ViewState["CurrPage"] = 1;
            bind();
            bll.Update(id, ViewState["SubType"].ToString());
            bool statu = bll.UpdateSmsConsumeRecTab(recId);
            if (statu)
            {
                Response.Write("<script>alert('恭喜您！推广成功！');location.href='myPromotion.aspx';</script>");
            }
        }
    }
    private void PromotionType()
    {
        Tz888.Model.SubscribeSet model = new Tz888.Model.SubscribeSet();
        Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
        model = bll.GetModels(id, out infotypeid, out htmlFile);
        SubscribeType = model.SubscribeType.Split(new char[] { ',' });    //推广类型
    }
    private void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        Tz888.Model.InnerInfo infomodel = new Tz888.Model.InnerInfo();
        Tz888.Model.SubscribeSet model = new Tz888.Model.SubscribeSet();
        model = bll.GetModels(id, out infotypeid, out htmlFile);
        InfoID = model.InfoID;
        title = model.Title;
        bll.GetDescript(InfoID, infotypeid.Trim(), out descript);
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        string[] countryCode = model.CountryCode.Split(new char[] { ',' });
        string[] provinceID = model.ProvinceID.Split(new char[] { ',' });
        string[] cityid = model.CityID.Split(new char[] { ',' });
        string[] countyId = model.CountyID.Split(new char[] { ',' });
        string[] objectGradeID = model.objectGradeID.Split(new char[] { ',' });
        string[] ManageTypeId = model.ManageTypeId.Split(new char[] { ',' });
        string[] Promotioncount = model.Promotioncount.Split(new char[] { ',' });  //推广条数
        SubscribeType = model.SubscribeType.Split(new char[] { ',' });    //推广类型

        SubType = model.SubscribeType;
        ViewState["SubType"] = SubType;
        string strWhere = "";
        int countTatol = 0;
        for (int i = 0; i < countryCode.Length - 1; i++)
        {
            if (objectGradeID[i] != "")
            {
                strWhere += " memberGradeId='" + objectGradeID[i] + "'";//'1001'";
            }
            if (ManageTypeId[i] != "")
            {
                strWhere += " and ManageTypeId='" + ManageTypeId[i] + "'";//'2003'"
            }
            ViewState["strWhere"] = strWhere;
            if (provinceID[i] != "")
            {
                if (countyId[i] != "" && cityid[i] != "") //区
                {
                    strWhere += " and countyId='" + countyId[i] + "'";
                    SendSummey(dal, descript, htmlFile, ref CurrPage, ref TotalCount, Promotioncount, SubscribeType, ref strWhere, ref countTatol);
                }
                if (!site || !email || !phone)
                {
                    if (cityid[i] != "")//市
                    {
                        strWhere += " and CityId='" + cityid[i] + "'";
                        SendSummey(dal, descript, htmlFile, ref CurrPage, ref TotalCount, Promotioncount, SubscribeType, ref strWhere, ref countTatol);
                    }
                }
            }
            if (!site || !email || !phone)
            {
                if (provinceID[i] != "")//省
                {
                    strWhere += " and provinceID='" + provinceID[i] + "'";
                    SendSummey(dal, descript, htmlFile, ref CurrPage, ref TotalCount, Promotioncount, SubscribeType, ref strWhere, ref countTatol);
                }
            }
            if (!site || !email || !phone)
            {
                if (countryCode[i] != "")
                {
                    strWhere += " countryCode='" + countryCode[i] + "'";//国家
                    SendSummey(dal, descript, htmlFile, ref CurrPage, ref TotalCount, Promotioncount, SubscribeType, ref strWhere, ref countTatol);
                }
            }
            if (!site || !email || !phone)
            {
                SendSummey(dal, descript, htmlFile, ref CurrPage, ref TotalCount, Promotioncount, SubscribeType, ref strWhere, ref countTatol);

            }
            break;
        }
    }
    /// <summary>
    /// 判断发送消息的类型
    /// </summary>
    /// <param name="dal">业务层</param>
    /// <param name="descript">发送内容</param>
    /// <param name="htmlFile">显示的地址</param>
    /// <param name="CurrPage">当前页</param>
    /// <param name="TotalCount">总记录数</param>
    /// <param name="Promotioncount">推广的数量</param>
    /// <param name="SubscribeType">推广的类型</param>
    /// <param name="strWhere">推广的条件</param>
    /// <param name="countTatol">推广提取的条数</param>
    private void SendSummey(Tz888.BLL.Conn dal, string descript, string htmlFile, ref long CurrPage, ref long TotalCount, string[] Promotioncount, string[] SubscribeType, ref string strWhere, ref int countTatol)
    {
        string type = "";
        Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
        for (int j = 0; j < SubscribeType.Length - 1; j++)
        {
            if (SubscribeType[j].Equals("1") && SubscribeType[j] != "") //判断是属于哪个类型(站内短信)
            {
                if (Promotioncount[j] != "")
                {
                    countTatol = Convert.ToInt32(Promotioncount[j]);  //得到哪种类型下的推广数量
                    DataTable dt = dal.GetList("showLoginMember_getList", "loginID", "*", strWhere, "NEWID()", ref CurrPage, countTatol, ref TotalCount);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (countTatol <= dt.Rows.Count)
                            {
                                SendLoginNameShort(descript, dt);
                                //执行成功之后更改推广类型，是为了避免下次再次发信息
                                site = true;
                                if (email && phone)//最后一次
                                {
                                    type = ",,,";
                                }
                                else if (email)//第二次
                                {
                                    type = ",,3,";
                                }
                                else if (phone)
                                {
                                    type = ",2,,";
                                }
                                else
                                {
                                    type = SubType.Substring(SubType.IndexOf(","));

                                }
                                bll.Update(id, type);
                                type = "";
                            }
                        }
                    }
                }
            }
            if (SubscribeType[j].Equals("2") && SubscribeType[j] != "") //判断是属于哪个类型(Email)
            {
                if (Promotioncount[j] != "")
                {
                    countTatol = Convert.ToInt32(Promotioncount[j]); //得到哪种类型下的推广数量
                    DataTable dt = dal.GetList("showLoginMember_getList", "loginID", "*", strWhere, "NEWID()", ref CurrPage, countTatol, ref TotalCount);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (countTatol <= dt.Rows.Count)
                            {
                                SendEmailShort(descript, htmlFile, dt);
                                email = true;
                                if (site && phone) //最后一次
                                {
                                    type = ",,,";
                                }
                                else if (site)//如果是第二次
                                {
                                    type = ",,3,";
                                }
                                else if (phone)
                                {
                                    type = "1,,,";
                                }
                                else //第一次
                                {    //1,,3,
                                    type = SubType.Substring(0, SubType.IndexOf("2")) + SubType.Substring(SubType.IndexOf("2") + 1, 2);
                                }
                                bll.Update(id, type);
                                type = "";
                            }
                        }
                    }
                }
            }
            if (SubscribeType[j].Equals("3") && SubscribeType[j] != "") //判断是属于哪个类型(phone)
            {
                if (Promotioncount[j] != "")
                {
                    countTatol = Convert.ToInt32(Promotioncount[j]); //得到哪种类型下的推广数量
                    DataTable dt = dal.GetList("showLoginMember_getList", "loginID", "*", strWhere, "NEWID()", ref CurrPage, countTatol, ref TotalCount);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            if (countTatol <= dt.Rows.Count)
                            {
                                SendPhoneShort(descript, dt);
                                phone = true;
                                if (site && email) //在本次循环中是最后一次执行
                                {
                                    type = ",,,";
                                }
                                else if (site)  //在本次循环中是第二次执行
                                {
                                    type = ",2,,";
                                }
                                else if (email)
                                {
                                    type = "1,,,";
                                }
                                else
                                {
                                    type = SubType.Substring(0, SubType.IndexOf("3")) + ",";
                                }
                                bll.Update(id, type);
                                type = "";
                            }
                        }
                    }
                }
            }
        }
        PromotionType();
        strWhere = "";
        strWhere = ViewState["strWhere"].ToString();
    }
    /// <summary>
    /// 发送手机短信
    /// </summary>
    private void SendPhoneShort(string descript, DataTable dt)
    {
        foreach (DataRow dataRow in dt.Rows)
        {
            StringBuilder str = new StringBuilder();
            string MialAddress = dataRow["tel"].ToString().Trim();//"13537706502";
            string MailMessage = descript;
            int a = send.SendSms(MialAddress, MailMessage);
            if (a > 0)
            {
                Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
                Tz888.Model.SubscribeSetTabLog model = new Tz888.Model.SubscribeSetTabLog();
                model.LoginName = dataRow["loginname"].ToString().Trim();
                model.SubType = "手机短信";
                model.Sid = id;
                bll.Insert(model);
            }

        }
    }
    /// <summary>
    /// 发送Email短信
    /// </summary>
    private void SendEmailShort(string descript, string htmlFile, DataTable dt)
    {
        foreach (DataRow dataRow in dt.Rows)
        {
            #region 构建发邮件的格式
            StringBuilder str = new StringBuilder();
            str.Append("<html>");
            str.Append("<heat>");
            str.Append("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=gb2312>");
            str.Append("<title>邮件推广信息</title>");
            str.Append("<body bgcolor=\"#FFFFFF\" leftmargin=\"0\" topmargin=\"0\" marginwidth=\"0\" marginheight=\"0\">");
            str.Append("<table width=\"668\" height=\"705\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
            str.Append("<tr>");
            str.Append("<td colspan=\"3\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_01.jpg\" width=\"668\" height=\"1\" alt=\"\"></td>");
            str.Append("</tr>");
            str.Append("</tr><tr><td colspan=\"3\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_02.jpg\" alt=\"\" width=\"668\" height=\"146\" border=\"0\" usemap=\"#Map\"></td>");
            str.Append("</tr>");
            str.Append("<tr><td colspan=\"3\" valign=\"top\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_03.jpg\" width=\"668\" height=\"188\" alt=\"\"></td>");
            str.Append("</tr><tr valign=\"middle\">");
            str.Append("<td width=\"25\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_04.jpg\" width=\"25\" height=\"82\" alt=\"\"></td>");
            str.Append("<td width=\"614\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr>");
            str.Append("<td height=\"25\" colspan=\"2\" style=\"color:#333333; font-size: 13px; font-weight:bolder;\">");
            str.Append("尊敬的用户：中国招商投资网（Http://www.topfo.com）提醒您：您收到推荐资源。</td></tr> <tr>");
            str.Append("<td width=\"76%\" height=\"25\" style=\"color:#333333; font-size: 13px; font-weight:bolder;\">");
            str.Append("推荐的资源与您的需求非常匹配，请及时把握商机。</td>");
            str.Append(" <td width=\"24%\"><a href=\"http://member.topfo.com/Login.aspx?ReturnUrl=%2fPublish%2fpublishNavigate.aspx\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/tt_08.jpg\" width=\"100\" border=\"0\" height=\"25\"></a></td>");
            str.Append("</tr></table></td><td>");
            str.Append("<div align=\"right\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_06.jpg\" width=\"29\" height=\"82\" alt=\"\">");
            str.Append("</div></td>");
            str.Append("</tr><tr>");
            str.Append("<td colspan=\"3\" valign=\"top\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_07.jpg\" width=\"668\" height=\"21\" alt=\"\">");
            str.Append("</td></tr><tr><td colspan=\"3\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_08.jpg\" width=\"668\" height=\"38\" alt=\"\">");
            str.Append("</td></tr><tr><td>");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_09.jpg\" width=\"25\" height=\"124\" alt=\"\">");
            str.Append("<td background=\"http://www.topfo.com/ADPage/yjtg/index_10.jpg\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            str.Append("<tr><td style=\"color:#b40000; font-size:16px; font-weight:bolder;\">" + title + "</td></tr>");
            str.Append("<tr><td style=\"font-size:12px; line-height:18px; padding-top:5px;\">");
            str.Append("<strong>项目摘要:</strong>");
            str.Append(descript);
            str.Append("<span style=\"padding-left:30px;\"><a href=\"http://www.topfo.com/" + htmlFile + "\"><img src=\"http://www.topfo.com/ADPage/yjtg/tt_17.jpg\" width=\"74\" height=\"21\"></a></span>");
            str.Append("</td></tr> </table></td>");
            str.Append("<td><div align=\"right\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_17.jpg\" width=\"29\" height=\"124\" alt=\"\">");
            str.Append("</div></td></tr><tr><td colspan=\"3\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_13.jpg\" width=\"668\" height=\"28\" alt=\"\">");
            str.Append("</td></tr><tr><td colspan=\"3\">");
            str.Append("<img src=\"http://www.topfo.com/ADPage/yjtg/index_19.jpg\" width=\"668\" height=\"80\" alt=\"\">");
            str.Append("</td></tr></table><map name=\"Map\">");
            str.Append("<area shape=\"rect\" coords=\"10,9,209,68\" href=\"www.topfo.com\"><area shape=\"rect\" coords=\"170,72,527,153\" href=\"www.topfo.com\">");
            str.Append("</map></body></html>");
            str.Append("</body>");
            str.Append("</heat>");
            str.Append("</html>");
            #endregion
            string MialAddress = dataRow["email"].ToString().Trim(); //"longb@tz888.cn";
            string Mailtitle = title;
            string MailMessage = str.ToString();
            bool statu = send.SendEmailMsg(MialAddress, Mailtitle, MailMessage);
            if (statu)
            {
                Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
                Tz888.Model.SubscribeSetTabLog model = new Tz888.Model.SubscribeSetTabLog();
                model.LoginName = dataRow["loginname"].ToString().Trim();
                model.SubType = "email短信";
                model.Sid = id;
                bll.Insert(model);
            }
            str.Remove(0, str.Length);
        }
    }
    /// <summary>
    /// 发送站内短信
    /// </summary>
    private void SendLoginNameShort(string descript, DataTable dt)
    {
        Tz888.BLL.InnerInfo infoBLL = new Tz888.BLL.InnerInfo();
        Tz888.Model.InnerInfo infomodel = new Tz888.Model.InnerInfo();
        foreach (DataRow dataRow in dt.Rows)
        {
            infomodel.SendName = loginname; //"020bluemax";//发件人 
            infomodel.Topic = "推广信息:" + title;
            infomodel.SendName =loginname;//dataRow["loginname"].ToString().Trim();
            infomodel.Context = descript;
            infomodel.InfoTime = DateTime.Now;
            infomodel.ReceiveName = dataRow["loginname"].ToString().Trim(); //收件人"hellocindy";
            infomodel.ChangeBy = loginname; //"020bluemax";//修改人
            bool statu = infoBLL.SendInfoBLL(infomodel, true);
            if (statu)
            {
                Tz888.BLL.SubscribeSet bll = new Tz888.BLL.SubscribeSet();
                Tz888.Model.SubscribeSetTabLog model = new Tz888.Model.SubscribeSetTabLog();
                model.LoginName = dataRow["loginname"].ToString().Trim();
                model.SubType = "站内短信";
                model.Sid = id;
                bll.Insert(model);
            }
        }
    }
}
