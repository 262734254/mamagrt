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
using Tz888.BLL;
public partial class helper_OrgCollection : Tz888.Common.Pager.BasePage
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_OrgCollection));
        PagerBase = Pager1;
        GridViewBase = dgCollection;

        if (!Page.IsPostBack)
        {
            getList();
        }
        tbKey.Attributes.Add("onfocus", "this.value=''");
    }

    #region  信息收藏夹列表显示


    public void getList()
    {
        System.Text.StringBuilder Criteria = new System.Text.StringBuilder();
        MakeCriteria(ref Criteria);
        string strCriteria = Criteria.ToString();
        PagerBase.StrWhere = strCriteria;
        PagerBase.DataBind();
        if (PagerBase.PageCount <= 0)
        {
            dgCollection.Visible = false;
            lbMessage.Text = "您在此段时间内没有收藏任何公司 <a href='http://www.topfo.com' target=\"_blank\">点此查看 说不定就有合适您的</a>";
            lbMessage.Visible = true;
        }
        else
        {
            dgCollection.Visible = true;
            lbMessage.Visible = false;
        }
    }
    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {
        string str = "loginName='" + Page.User.Identity.Name + "'"; //DeleteStatus  0:显示   1:浏览删除    2:收藏删除
        //string str = "loginName='" + "kittycat" + "'"; 
        Criteria.Append(str);

        string key = tbKey.Text.Trim();//资源名称、发布者、类型


        if (key != "请输入公司名称、发布者等" && key != "")
        {
            string strKey = " AND (CollectOrgName like '%" + key + "%' OR ContactLoginName like '%" + key + "%')";
            Criteria.Append(strKey);
        }

        //三天内、七天内、一个月内、三个月内、三个月以


        switch (this.ddCreateTime.SelectedValue.Trim())
        {
            case "91":
                string strDays = " AND CreateDate<='" + DateTime.Now.AddDays(-90).ToShortDateString() + "'";
                Criteria.Append(strDays);
                break;
            default:
                Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CreateDate", DateTime.Now.AddDays(-Convert.ToDouble(this.ddCreateTime.SelectedValue.Trim())).ToShortDateString(), DateTime.Now.AddDays(1).ToShortDateString());
                break;
        }
    }
    #endregion



    public string SetAddress(object str1, object str2, object str3, object str4)
    {
        Tz888.BLL.Common.ZoneSelectBLL objZone = new Tz888.BLL.Common.ZoneSelectBLL();
        string s1 = ""; if (str1.ToString() != "") s1 = objZone.GetCountryNameByCode(str1.ToString().Trim());
        string s2 = ""; if (str2.ToString() != "") s2 = objZone.GetProvinceNameByCode(str2.ToString().Trim());
        string s3 = ""; if (str3.ToString() != "") s3 = objZone.GetCityNameByCode(str3.ToString().Trim());
        string s4 = ""; if (str4.ToString() != "") s4 = objZone.GetCountyNameByCode(str4.ToString().Trim());

        string str = s1 + " " + s2 + " " + s3 + " " + s4;
        return (str);
    }

    public string GetMember(object obj)
    {
        string name = obj.ToString().Trim();
        Tz888.BLL.Register.LoginInfoBLL objMember = new Tz888.BLL.Register.LoginInfoBLL();
        string strMG = objMember.GetMemberGradeID(name);
        string strMT = objMember.GetManagerType(name);

        string MG = "";
        string MT = "";
        switch (strMG.Trim())
        {
            case "1002":
                MG = "<font color='red'>[拓富通]</font>";
                break;
            default:
                break;
        }
        switch (strMT.Trim())
        {
            case "企业单位":
                MT = "http://member.topfo.com/Register/MemberMessage_E.aspx?LoginName=" + name;
                break;
            case "政府机构":
                MT = "http://member.topfo.com/Register/MemberMessage_G.aspx?LoginName=" + name;
                break;
            case "个人":
                MT = "http://member.topfo.com/Register/MemberMessage_P.aspx?LoginName=" + name;
                break;

        }
        return "<a href='" + MT + "' target='_blank' >" + name + MG + "</a>";



    }
    public string GetIndustry(object obj)
    {
        string str = obj.ToString().Trim();
        string strIndustry = "无";
        if (str != "")
        {
            string[] strList = str.Split(',');
            Tz888.BLL.Common.IndustryBLL objI = new Tz888.BLL.Common.IndustryBLL();
            strIndustry = "";
            for (int i = 0; i < strList.Length; i++)
            {
                if (strList[i] != "")
                {
                    strIndustry = strIndustry + objI.GetNameByID(strList[i])+";";
                }
            }
            strIndustry = strIndustry.Substring(0, strIndustry.Length - 1);
        }
        return strIndustry;
    }
    protected void ddCreateTime_SelectedIndexChanged(object sender, EventArgs e)
    {
        getList();
    }
    protected void btSearch_Click(object sender, EventArgs e)
    {
        getList();
    }
    [AjaxPro.AjaxMethod]
    public string ToRecycle(string idList)
    {
        string userName = Page.User.Identity.Name;
        Tz888.BLL.CollectionBLL obj = new Tz888.BLL.CollectionBLL();
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                long ID = Convert.ToInt64(s[i].Trim());
                bool b = obj.OrgDelete(Page.User.Identity.Name, ID);
            }
        }
        return "ok";
    }
    protected void lbtn10_Click(object sender, EventArgs e)
    {
        Pager1.PageSize = 10;
        getList();
    }
    protected void lbtn20_Click(object sender, EventArgs e)
    {
        Pager1.PageSize = 20;
        getList();
    }
    protected void lbtn30_Click(object sender, EventArgs e)
    {
        Pager1.PageSize = 30;
        getList();
    }
}
