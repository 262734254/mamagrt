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

public partial class helper_TestMatchingInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        this.ViewState["MemberLoginName"] = "topfo001";
        forPageLoad();
    }

    //protected void btnAdd_Click(object sender, EventArgs e)
    //{

    //    string Criteria = "LoginName ='" + Page.User.Identity.Name.Trim() + "'";
    //    Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
    //    DataTable dt = obj.GetList("CustomInfoTab", "*", "LoginName", 1, 1, 0, 1, Criteria);
    //    Response.Redirect("MyMatching.aspx?tag=Add");
    //}
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        DataControlRowType objItemType = e.Row.RowType;
        if (objItemType == DataControlRowType.DataRow)
        {
            LinkButton hlDel = (LinkButton)e.Row.FindControl("hlDel");
            hlDel.Attributes.Add("onClick", "return confirm('是否真的要删除?');");
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Tz888.BLL.CustomInfoBLL CustomInfo = new Tz888.BLL.CustomInfoBLL();
        int index = Convert.ToInt32(e.CommandArgument);
        CustomInfo.Delete(index);
        forPageLoad();

    }

    #region 所有信息显示



    private void forPageLoad()
    {
        //会员类型不同提示不同
        if (Page.User.IsInRole("GT1001"))
        {

            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                          " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                               "搜索订阅可以让您第一时间掌握先机，获得对口资源和资讯,这是中国招商投资网专门为您提供的一项增值服务。</p> <br />" +
                               " <p class=\"f_black\">" +
                                   "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";



            // forReg.InnerHtml = "您最多可以有<strong class='chengcu'>5</strong>个，还可以保存并订阅<strong class='chengcu'>" + this.ViewState["count"].ToString() + "</strong>条";  
            btnAdd.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            forTFT.Visible = false;
            showMessage.Attributes["class"] = "manage";
        }
        else
        {
            string Criteria = "LoginName = 'topfo001'";
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("CustomInfoTab", "*", "ID", 10, 1, 0, 1, Criteria);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            showMessage.Attributes["class"] = "jl-wxts";
            showMessage.InnerHtml = "<h3><img src=\"http://img2.topfo.com/member/img/icon_tishi.gif\" align=\"absmiddle\" /> 如何设置搜索订阅</h3> "
                + "<p>·如果您无暇上网，又担心错过了好机会，请进行免费订阅设置。<br />·第一时间抢占先机，万千财富滚滚来！ <br />"
                + "·您是拓富通会员，享有无限数量的免费订阅权限  </p>";

        }

    }
    #endregion

    //政府招商 资 本 项 目 创 业 商 机 资 讯 (没有参数表)
    /*原项目说明：<asp:ListItem Value="0" Selected="True">招商信息</asp:ListItem>
                   <asp:ListItem Value="1">投资信息</asp:ListItem>
                   <asp:ListItem Value="2">融资信息</asp:ListItem>
                   <asp:ListItem Value="3">创业信息</asp:ListItem>
                   <asp:ListItem Value="4">商机信息</asp:ListItem>
                   <asp:ListItem Value="5">资讯信息</asp:ListItem>
               </asp:dropdownlist></span></td>*/

    public string GetCustomType(object Vali)
    {
        if (Vali.ToString() == "0")
        {
            return "政府招商";
        }
        else if (Vali.ToString() == "1")
        {
            return "资本资源";
        }
        else if (Vali.ToString() == "2")
        {
            return "企业项目";
        }
        else if (Vali.ToString() == "3")
        {
            return "资讯";
        }
        else
        {
            return "";
        }
    }
    public string GetStr(object Vali)
    {
        if (Vali.ToString() == "0")
        {
            return "一天";
        }
        else if (Vali.ToString() == "1")
        {
            return "三天";
        }
        else if (Vali.ToString() == "2")
        {
            return "一周";
        }
        else
        {
            return "";
        }
    }

    public string GetUrl(object id, object customType)
    {
        return "MyMatching.aspx?ID=" + id + "&tag=update&CustomType=" + customType;
    }
    public string GetTitleUrl(object id, object customType)
    {
        if (customType.ToString() == "3")
        {
            return "MachingMessageNews.aspx?ID=" + id + "&type=" + customType;
        }
        else
        {
            return "TestMachingMessage.aspx?ID=" + id + "&type=" + customType;
        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    public string GetMatchingCount(object id)
    {
        return SearchInfoSelect(Convert.ToInt32(id));
    }
    #region  查询匹配条数 -----------
    private string SearchInfoSelect(int id)
    {
        DataTable dt;
        string TableViewName = "";
        string strCriteria = "";

        string Criteria = "LoginName ='topfo001'";
        Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
        DataTable dt1 = obj.GetList("CustomInfoTab", "*", "ID", 1, 1, 0, 1, "ID=" + id);
        DataRow dr = dt1.Rows[0];
        string strCustomType = dr["CustomType"].ToString();

        if (strCustomType.Trim() != "")
        {
            #region-- 取条件并组织 ----------------
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
            //if (dr["currency"] != null)
            //{
            //    CustomInfo.currency = dr["currency"].ToString().Trim();
            //}
            if (dr["CooperationDemandTypeID"] != null)
            {
                CustomInfo.CooperationDemandTypeID = dr["CooperationDemandTypeID"].ToString();
            }
            else
            {
                CustomInfo.CooperationDemandTypeID = "";
            }

            #region 政府招商
            //招商  政府招商
            if (strCustomType == "0")
            {
                if (CustomInfo.Type.Trim() != "")   //招商类别
                {
                    strCriteria = "MerchantTypeID IN(";
                    string[] arrType = CustomInfo.Type.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling != "") //所属行业
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

                if (CustomInfo.City != "") //投资区域
                {
                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " AND ProvinceID like '%" + arrType[i].Trim() + "%'";
                        }
                        else if (arrType[i].Trim() != "" && i != 0)
                        {
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%'";
                        }

                    }
                }

                //if (CustomInfo.currency.Trim() != "")
                //{
                //    if (strCriteria != "")
                //    {
                //        strCriteria = strCriteria + " AND CapitalCurrency='" + CustomInfo.currency+"'";
                //    }
                //    else
                //    {
                //        strCriteria = " CapitalCurrency ='" + CustomInfo.currency + "'";
                //    }
                //}
                if (CustomInfo.CooperationDemandTypeID != "") //合作方式
                {
                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " AND CooperationDemandType like '%" + arrType[i] + "%'";
                        }
                        else if (arrType[i].Trim() != "" && i != 0)
                        {
                            strCriteria = strCriteria + " or CooperationDemandType like '%" + arrType[i] + "%'";
                        }
                    }
                }

                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND KeyWord like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "KeyWord like '%" + CustomInfo.Keyword + "%'";
                    }
                }

                if (strCriteria.Trim() != "")
                {
                    strCriteria = strCriteria + " and AuditStatus =1";
                }
                else
                {
                    strCriteria = strCriteria + " AuditStatus =1";
                }
            }
            #endregion

            #region 投资   企业项目
            else if (strCustomType == "2")
            {

                if (CustomInfo.Money.Trim() != "")//投资金额
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND CapitalID IN (";
                    }
                    else
                    {
                        strCriteria = " CapitalID IN (";
                    }

                    // strCriteria = "CapitalID IN(";
                    string[] arrType = CustomInfo.Money.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling.Trim() != "") //投资行业
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
                        strCriteria = strCriteria + "IndustryBID like '%" + arrType[i] + "%' OR ";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 4) + ")";

                    // string[] arrType = CustomInfo.Calling.Split('|');
                    //string[] arrType = CustomInfo.Calling.Split('|');
                    //for (int i = 0; i < arrType.Length; i++)
                    //{
                    //    if (arrType[i].Trim() != "" && i == 0)
                    //    {
                    //        strCriteria = strCriteria + " AND IndustryBID like '%" + arrType[i].Trim() + "%'";
                    //    }
                    //    else if (arrType[i].Trim() != "" && i == 0)
                    //    {
                    //        strCriteria = strCriteria + " or IndustryBID like '%" + arrType[i].Trim() + "%'";
                    //    }
                    //}
                }
                if (CustomInfo.City != "") //投资区域
                {
                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " AND ProvinceID like '%" + arrType[i].Trim() + "%'";
                        }
                        else if (arrType[i].Trim() != "" && i != 0)
                        {
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%'";
                        }

                    }
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

                if (CustomInfo.CooperationDemandTypeID != "") //合作方式
                {
                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " AND CooperationDemandType like '%" + arrType[i] + "%'";
                        }
                        else if (arrType[i].Trim() != "" && i != 0)
                        {
                            strCriteria = strCriteria + " or CooperationDemandType like '%" + arrType[i] + "%'";
                        }
                    }
                }
                if (CustomInfo.Type != "")
                {
                    string typeid = CustomInfo.Type.ToString().Trim();
                    if (typeid == "0")
                    {
                        typeid = "10";
                    }
                    if (typeid == "0|1")
                    {
                        typeid = "10";
                    }
                    else
                    {
                        typeid = "9";
                    }
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND CooperationDemandType like '%" + typeid + "%'";
                    }
                    else
                    {
                        strCriteria = " title CooperationDemandType '%" + typeid + "%'";
                    }
                }
                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND KeyWord like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = " title KeyWord '%" + CustomInfo.Keyword + "%'";
                    }
                }
                if (strCriteria.Trim() != "")
                {
                    strCriteria = strCriteria + " and AuditStatus =1";
                }
                else
                {
                    strCriteria = strCriteria + " AuditStatus =1";
                }

            }
            #endregion

            #region 融资 资本资源
            else if (strCustomType == "1")
            {
                if (CustomInfo.Money.Trim() != "")  //投资金额
                {
                    strCriteria = "CapitalID IN(";
                    string[] arrType = CustomInfo.Money.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        strCriteria = strCriteria + "'" + arrType[i] + "',";
                    }
                    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                }

                if (CustomInfo.Calling.Trim() != "") //投资行业
                {
                    string[] arrType = CustomInfo.Calling.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " AND IndustryBID like '%" + arrType[i].Trim() + "%'";
                        }
                        else if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " or IndustryBID like '%" + arrType[i].Trim() + "%'";
                        }
                    }
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

                if (CustomInfo.City != "") //投资区域
                {
                    string[] arrType = CustomInfo.City.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (arrType[i].Trim() != "" && i == 0)
                        {
                            strCriteria = strCriteria + " AND ProvinceID like '%" + arrType[i].Trim() + "%'";
                        }
                        else if (arrType[i].Trim() != "" && i != 0)
                        {
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%'";
                        }

                    }
                }
                if (CustomInfo.CooperationDemandTypeID != "") //合作方式
                {
                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    for (int i = 0; i < arrType.Length; i++)
                    {
                        if (strCriteria.Trim() != "")
                        {

                            if (arrType[i].Trim() != "" && i == 0)
                            {
                                strCriteria = strCriteria + " AND CooperationDemandType like '%" + arrType[i] + "%'";
                            }
                            else if (arrType[i].Trim() != "" && i != 0)
                            {
                                strCriteria = strCriteria + " or CooperationDemandType like '%" + arrType[i] + "%'";
                            }
                        }
                        else
                        {
                            if (arrType[i].Trim() != "" && i == 0)
                            {
                                strCriteria = strCriteria + " CooperationDemandType like '%" + arrType[i] + "%'";
                            }
                            else if (arrType[i].Trim() != "" && i != 0)
                            {
                                strCriteria = strCriteria + " or CooperationDemandType like '%" + arrType[i] + "%'";
                            }
                        }
                    }
                }


                if (CustomInfo.Keyword != "")
                {
                    if (strCriteria != "")
                    {
                        strCriteria = strCriteria + " AND KeyWord like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = " KeyWord like '%" + CustomInfo.Keyword + "%'";
                    }
                }
                if (strCriteria.Trim() != "")
                {
                    strCriteria = strCriteria + " and AuditStatus =1";
                }
                else
                {
                    strCriteria = strCriteria + " AuditStatus =1";
                }
            }
            #endregion

            //创业  资讯
            #region 资讯
            else if (strCustomType == "3")
            {
                if (CustomInfo.Type.Trim() != "")  //资讯类型
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
                if (strCriteria.Trim() != "")
                {
                    strCriteria = strCriteria + "and NewsLblStatus=1";
                }
                else
                {
                    strCriteria = strCriteria + " NewsLblStatus=1";
                }
            }
            #endregion



            #endregion-- 取条件并组织 ----------------

            this.ViewState["Criteria"] = strCriteria;
        }

        try
        {
            if (strCustomType == "0")
            {
                TableViewName = "MerchantInfo_Viw2"; //政府招商
            }
            else if (strCustomType == "1")
            {
                TableViewName = "CapitalInfo_Viw2"; //资本资源
            }
            else if (strCustomType == "2")
            {
                TableViewName = "ProjectInfoTab_Viw2"; //企业项目
            }

            else if (strCustomType == "3")
            {
                TableViewName = "NewsTab_Viw2";
            }
            else
            {
                return "";
            }
            Tz888.SQLServerDAL.Conn objCount = new Tz888.SQLServerDAL.Conn();

            return Convert.ToInt32(objCount.GetList(TableViewName, "LoginTime", "InfoID", 1, 1, 1, 1, this.ViewState["Criteria"].ToString()).Rows[0][0]).ToString();
        }
        catch
        {
            return "0";
        }

    }
    #endregion

    protected void btnAdd_ServerClick(object sender, EventArgs e)
    {

    }
}
