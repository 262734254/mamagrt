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

public partial class helper_ResourceOver : System.Web.UI.Page
{
    public string InfoID;
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    bool isTof = Page.User.IsInRole("GT1002");

    //    if (isTof)
    //    {
    //        Page.MasterPageFile = "/indexTof.master";
    //    }
    //    else
    //    {
    //        Page.MasterPageFile = "/MasterPage.master";
    //    }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        
        if (Request.QueryString["infoId"] != null && Request.QueryString["infoId"].Trim() != "")
        {
            InfoID = Request.QueryString["infoId"].Trim();
        }
        else
        {
           Tz888.Common.MessageBox.ResponseScript(this.Page, "window.close();");
        }
        if (!Page.IsPostBack)
        {
            bind();
        }

    }
    protected void bind()
    {
        DataTable dt = dal.GetList("SubscribeSetTab", "subscribeType,title,SubscribeCount,subscribeType,SubscribeOver,infoid,objectGradeID,objectNeed,countrycode,ProvinceId,cityid,CountyId ", "ID", 1, 1, 0, 1, "InfoID=" + Convert.ToInt64(InfoID));

        string[] countrycode = dt.Rows[0]["countrycode"].ToString().Split(new char[] { ',' }); //国家代码
        string[] ProvinceId = dt.Rows[0]["ProvinceId"].ToString().Split(new char[] { ',' });//省份
        string[] cityid = dt.Rows[0]["cityid"].ToString().Split(new char[] { ',' });//城市
        string[] countyId = dt.Rows[0]["CountyId"].ToString().Split(new char[] { ',' }); //区县
        string strcountry = "";
        if (string.IsNullOrEmpty(dt.Rows[0]["countrycode"].ToString()))
        {
            lblCountry.Text = "<font color='red'>暂无推广区域</font>";
        }
        else
        {
            for (int i = 0; i < countrycode.Length - 1; i++)
            {
                if (countrycode[i] != "") //国家
                {
                    DataTable dtCountry = dal.GetList("SetCountryTab", "CountryName,countrycode", "ID", 1, 1, 0, 1, "countrycode='" + countrycode[i].Trim() + "'");
                    strcountry += dtCountry.Rows[0]["CountryName"].ToString() + "&nbsp;";
                }
                if (ProvinceId[i] != "") //省份
                {
                    DataTable dtProvince = dal.GetList("SetProvinceTab", "ProvinceName,provinceid", "provinceid", 1, 1, 0, 1, "provinceid='" + ProvinceId[i].Trim() + "'");
                    strcountry += dtProvince.Rows[0]["ProvinceName"] + "&nbsp;";
                }
                else
                {
                    strcountry += "" + "<br>";
                }
                if (ProvinceId[i] != "")//如果没有省份，下面的市、区也就没有，
                {
                    if (cityid[i] != "")
                    {
                        DataTable dtCity = dal.GetList("SetcityTab", "CityName,cityid", "cityid", 1, 1, 0, 1, "cityid='" + cityid[i].Trim() + "'");
                        strcountry += dtCity.Rows[0]["CityName"] + "&nbsp;";
                    }
                    if (countyId[i] != "" && cityid[i] != "")
                    {
                        DataTable dtCounty = dal.GetList("SetCountyTab", "CountyName,countyId", "countyId", 1, 1, 0, 1, "countyId='" + countyId[i].Trim() + "'");
                        strcountry += dtCounty.Rows[0]["CountyName"] + "&nbsp;" + "<br>";
                    }
                    else
                    {
                        strcountry += "<br>";
                    }
                }
               
            } lblCountry.Text = strcountry.ToString();
        }
        lblcount.Text = "三种一共<font color='red'>" + dt.Rows[0]["SubscribeCount"].ToString() + "</font>条";
        lblTitle.Text = dt.Rows[0]["title"].ToString();
        if (!string.IsNullOrEmpty(dt.Rows[0]["objectGradeID"].ToString()))
        {
            switch (dt.Rows[0]["objectGradeID"].ToString())
            {
                case "1001":
                    lblMember.Text = "普通会员";
                    break;
                case "1002":
                    lblMember.Text = "拓富通会员";
                    break;
                default:
                    lblMember.Text = "全部会员";
                    break;
            }
        }
        else
        {
            lblMember.Text = " ";
        }
        if (!string.IsNullOrEmpty(dt.Rows[0]["objectNeed"].ToString()))
        {
            string[] str = dt.Rows[0]["objectNeed"].ToString().Split(new char[] { ',' });
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i].ToString())
                {
                    case "Merchant":
                        lblProject.Text += "有政府招商需求用户&nbsp;";
                        break;
                    case "Project":
                        lblProject.Text += "有融资资源需求用户&nbsp;";
                        break;
                    case "Capital":
                        lblProject.Text += "有投资需求用户&nbsp;";
                        break;
                    default:
                        //lblProject.Text = "";
                        break;
                }
            }
        }
        else
        {
            lblProject.Text = "";
        }
    }
}
