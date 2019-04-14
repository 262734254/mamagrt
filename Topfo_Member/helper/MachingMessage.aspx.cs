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
using Tz888.Model;

public partial class helper_MachingMessage : Tz888.Common.Pager.BasePage
{
    protected DataRow dr;
    protected DataSet ds;
    string infoTypeID = "";
    protected int ID;
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
        if (Page.User.Identity.Name.Trim() == null || Page.User.Identity.Name.Trim().Trim() == "")
        {
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));

        }

        //会员类型 
        if (Page.User.IsInRole("GT1001"))
        {
            pt.Visible = true;
            tft.Visible = false;
        }
        if (Page.User.IsInRole("GT1002") || Page.User.IsInRole("GT1003"))
        {
            tft.Visible = true;
            pt.Visible = false;
        }

        //页面跳转
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"].ToString() == "3")
            {
                Response.Redirect("MachingMessageNews.aspx?type=3");
            }
        }
        if (!Page.IsPostBack)
        {
            this.ViewState["CustomType"] = "";
            try
            {
                ID = Convert.ToInt32(Request.QueryString["ID"]);

                //if (ID == 0)//查询进来
                //{
                //    //Session[""]建立dr						
                //    ds = (DataSet)Session["CustomInfo"];

                //    ViewState["dt"] = ds.Tables[0];
                //}
                //else//链接进来
                //{
                string SelectCol = "*";
                string Criteria = " id=" + ID;
                Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
                DataTable dt = obj.GetList("CustomInfoTab", "*", "ID", 1, 1, 0, 1, Criteria);

                if (dt.Rows.Count > 0)
                {
                    ViewState["dt"] = dt;
                }
                //}

                //显示信息	
                PagerBase = Pager1;
                RepeaterBase = dgMatching;
                if (Session["customInfo"] != null)
                {
                    Tz888.Model.CustomInfoModel customInfo = (Tz888.Model.CustomInfoModel)Session["customInfo"];
                   
                    this.Pager1.StrWhere = getStrWhere(customInfo);
                    this.Pager1.DataBind();
                }
                else
                {
                    SearchInfoSelect();
                }
            }
            catch
            {
                //Tz888.Common.MessageBox.Show(this.Page, "操作超时！");
            }

        }
    }
    #region  订制信息查询 -----------  --2010-06-21修改
    private void SearchInfoSelect()
    {
        DataView dv;
        DataTable dt;

        DataTable dt1 = (DataTable)this.ViewState["dt"];
        DataRow dr = dt1.Rows[0];
        string strCustomType = dr["CustomType"].ToString(); //this.ViewState[ "CustomType" ].ToString();		
        string strCriteria = "";
        //对已经取得的查询条件不在取

        if (strCustomType.Trim() != "")
        {

            //#endregion-- 取条件并组织 ----------------

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
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%',";
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
                //if (CustomInfo.CooperationDemandTypeID != "") //合作方式
                //{
                //    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                //    if (arrType[0].Trim() != "")
                //    {
                //        if (strCriteria != "")
                //        {
                //            strCriteria = strCriteria + " AND CooperationDemandType IN (";
                //        }
                //        else
                //        {
                //            strCriteria = " CooperationDemandType IN (";
                //        }

                //        for (int i = 0; i < arrType.Length; i++)
                //        {
                //            strCriteria = strCriteria + "'" + arrType[i] + "',";
                //        }
                //        strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
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
                        strCriteria = strCriteria + " AND Remark like '%" + CustomInfo.Keyword + "%'";
                    }
                    else
                    {
                        strCriteria = "Remark like '%" + CustomInfo.Keyword + "%'";
                    }
                }
                strCriteria = strCriteria + " and AuditStatus =1";
            }
            #endregion
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
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%',";
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

            #region 投资   企业项目
            else if (strCustomType == "2")
            {
                //if (CustomInfo.Genre.Trim() != "") 
                //{
                //    strCriteria = "CapitalTypeID IN(";
                //    string[] arrType = CustomInfo.Genre.Split('|');
                //    for (int i = 0; i < arrType.Length; i++)
                //    {
                //        strCriteria = strCriteria + "'" + arrType[i] + "',";
                //    }
                //    strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                //}

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

                //if (CustomInfo.currency != "")
                //{
                //    if (strCriteria != "")
                //    {
                //        strCriteria = strCriteria + " AND currency='" + CustomInfo.currency+"'";
                //    }
                //    else
                //    {
                //        strCriteria = " currency='" + CustomInfo.currency + "'";
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
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%',";
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

        // Label1.Text = this.ViewState["Criteria"].ToString();

        try
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();

            if (strCustomType == "0")
            {
                this.Pager1.TableViewName = "MerchantInfo_Viw2"; //政府招商
                if (this.ViewState["Criteria"].ToString().Trim() != "")
                {
                    this.Pager1.StrWhere = this.ViewState["Criteria"].ToString();
                }

            }
            else if (strCustomType == "1")
            {
                this.Pager1.TableViewName = "CapitalInfo_Viw2"; //资本资源
                if (this.ViewState["Criteria"].ToString().Trim() != "")
                {
                    this.Pager1.StrWhere = this.ViewState["Criteria"].ToString();
                }
            }
            else if (strCustomType == "2")
            {
                this.Pager1.TableViewName = "ProjectInfoTab_Viw2"; //企业项目
                if (this.ViewState["Criteria"].ToString().Trim() != "")
                {
                    this.Pager1.StrWhere = this.ViewState["Criteria"].ToString();
                }
            }

            else if (strCustomType == "3")
            {
                this.Pager1.TableViewName = "NewsTab_Viw2";
                if (this.ViewState["Criteria"].ToString().Trim() != "")
                {
                    this.Pager1.StrWhere = this.ViewState["Criteria"].ToString();
                }
            }
            else
            {

            }
            ////通过session接收搜索条件，判断session["Criteria"] if为空，为空则显示与订阅条件匹配数据else搜索条件匹配数据
            //if (Session["customInfo"] != null)
            //{
            //    Tz888.Model.CustomInfoModel customInfo = (Tz888.Model.CustomInfoModel)Session["customInfo"];
            //    this.Pager1.StrWhere = getStrWhere(customInfo);
            //}
            this.Pager1.DataBind();

        }
        catch { }
    }
    #endregion


    public string getNickName(object obj)
    {
        string log = obj.ToString();
        Tz888.BLL.Register.MemberInfoBLL objLog = new Tz888.BLL.Register.MemberInfoBLL();
        return objLog.getNickName(log);
    }

    //订阅类型
    public string getCustomType()
    {
        if (Request.QueryString["Type"] != null)
        {
            return Request.QueryString["Type"].ToString();
        }
        else
        {
            return "1";
        }
    }

    #region 绑定数据判断是否为免费
    public string isMianFei(object obj, object isA, object InfoID)
    {
        string returnStr = "";
        if (obj != null)
        {
            if (obj.ToString().Trim() == "0")
            {
                if (isA.ToString() == "a")
                {
                    returnStr = "--";
                }
                else
                {
                    returnStr = "免费";
                }

            }
            else
            {
                if (isA.ToString() == "a")
                {
                    returnStr = "<a style='text-decoration:none;' id='hlType2' target='_blank' href=' http://pay.topfo.com/order_item.aspx?InfoID=" + InfoID + "'>立即购买</a>";
                }
                else
                {
                    returnStr = obj.ToString() + ".00";
                }

            }

        }
        return returnStr;
    }
    #endregion

    //获取搜索条件
    public string getStrWhere(Tz888.Model.CustomInfoModel CustomInfo)
    {
        string strWhere = "";
        DataTable dt1 = (DataTable)this.ViewState["dt"];

        string strCriteria = "";
        //对已经取得的查询条件不在取
        string strCustomType = CustomInfo.CustomType.ToString();
        if (strCustomType.Trim() != "")
        {
            #region-- 取条件并组织 ----------------

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
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%',";
                        }

                    }
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
                this.Pager1.TableViewName = "MerchantInfo_Viw2"; //政府招商
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

                //if (CustomInfo.currency != "")
                //{
                //    if (strCriteria != "")
                //    {
                //        strCriteria = strCriteria + " AND currency='" + CustomInfo.currency+"'";
                //    }
                //    else
                //    {
                //        strCriteria = " currency='" + CustomInfo.currency + "'";
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
                this.Pager1.TableViewName = "ProjectInfoTab_Viw2"; //企业项目
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
                            strCriteria = strCriteria + " or ProvinceID like '%" + arrType[i].Trim() + "%',";
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
                this.Pager1.TableViewName = "CapitalInfo_Viw2"; //资本资源
            }
            #endregion

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

                this.Pager1.TableViewName = "NewsTab_Viw2";
            }
            #endregion
            #endregion-- 取条件并组织 ----------------

            strWhere = strCriteria;
        }

        if (strCustomType == "3")
        {
            Session["strWhere"] = strWhere;
            Response.Redirect("MachingMessageNews.aspx?type=3");
        }
        return strWhere;
    }

}
