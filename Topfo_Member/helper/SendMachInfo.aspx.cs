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
public partial class helper_SendMachInfo : System.Web.UI.Page
{
    protected string infoTypeID = "";
    protected int ID=0;
    protected string strCriteria = "";
    protected string TableViewName = "";
    protected int itemCount = 10;
    Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ID = Convert.ToInt32(Request.QueryString["ID"]);
            SearchInfoSelect();
        }
    }
    #region  订制信息查询 -----------
    private void SearchInfoSelect()
    {
        DataTable dt1 = obj.GetList("CustomInfoTab", "*", "ID", 1, 1, 0, 1, "ID="+ID);
        lblNickName.Text = dt1.Rows[0]["LoginName"].ToString();
        DataRow dr = dt1.Rows[0];
        string strCustomType = dt1.Rows[0]["CustomType"].ToString().Trim();
        string a = dt1.Rows[0]["itemCount"].ToString().Trim() == "" ? "10" : dt1.Rows[0]["itemCount"].ToString().Trim();
        itemCount = Convert.ToInt32(a);
        //对已经取得的查询条件不在取
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
                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    if (arrType[0].Trim() != "")
                    {
                        if (strCriteria != "")
                        {
                            strCriteria = strCriteria + " AND CooperationDemandType IN (";
                        }
                        else
                        {
                            strCriteria = " CooperationDemandType IN (";
                        }

                        for (int i = 0; i < arrType.Length; i++)
                        {
                            strCriteria = strCriteria + "'" + arrType[i] + "',";
                        }
                        strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                    }
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
                    string[] arrType = CustomInfo.CooperationDemandTypeID.Trim().Split('|');
                    if (arrType[0].Trim() != "")
                    {
                        if (strCriteria != "")
                        {
                            strCriteria = strCriteria + " AND CooperationDemandType IN (";
                        }
                        else
                        {
                            strCriteria = " CooperationDemandType IN (";
                        }

                        for (int i = 0; i < arrType.Length; i++)
                        {
                            strCriteria = strCriteria + "'" + arrType[i] + "',";
                        }
                        strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                    }
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
                    string[] arrType = CustomInfo.CooperationDemandTypeID.Split('|');
                    if (arrType[0].Trim() != "")
                    {
                        if (strCriteria != "")
                        {
                            strCriteria = strCriteria + " AND CooperationDemandType IN (";
                        }
                        else
                        {
                            strCriteria = " CooperationDemandType IN (";
                        }
                        for (int i = 0; i < arrType.Length; i++)
                        {
                            if (arrType[i].Trim() != "")
                            {
                                strCriteria = strCriteria + "'" + arrType[i] + "',";
                            }
                        }
                        strCriteria = strCriteria.Substring(0, strCriteria.Length - 1) + ")";
                    }
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
                #region

                #endregion
            }
            else
            {
            }
            #endregion-- 取条件并组织 ----------------
        }

            if (strCustomType == "0")
            {
               TableViewName = "MerchantInfo_VIW_noindex";
            }
            else if (strCustomType == "1")
            {
                TableViewName = "CapitalInfo_VIW_noindex";
            }
            else if (strCustomType == "2")
            {
                TableViewName = "ProjectInfo_noindex";
            }

            else if (strCustomType == "3")
            {
                TableViewName = "CarveOutInfo_Front_VIW";
            }

            else if (strCustomType == "4")
            {
                TableViewName = "OpportunityInfo_Front_VIW";
            }
            else if (strCustomType == "5")
            {
                TableViewName = "News_Front_VIW";
            }
            DataTable dt = obj.GetList(TableViewName, "Title,PublishT,LoginName,HtmlFile", "InfoID", itemCount, 1, 0, 1, strCriteria);
            dgMatching.DataSource = dt;
            dgMatching.DataBind();

    }
    #endregion

    public string getNickName(object obj)
    {
        string log = obj.ToString();
        Tz888.BLL.Register.MemberInfoBLL objLog = new Tz888.BLL.Register.MemberInfoBLL();
        return objLog.getNickName(log);
    }

}
