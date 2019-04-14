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
using Tz888.Common.DEncrypt;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
public partial class Company_CompanyShow : System.Web.UI.Page
{
    Tz888.BLL.MeberLogin.MemberIndexBLL member = new Tz888.BLL.MeberLogin.MemberIndexBLL();
    Tz888.Model.Company.CompanyShow company = new Tz888.Model.Company.CompanyShow();
    Tz888.BLL.Company.CompanyShowBLL show = new Tz888.BLL.Company.CompanyShowBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            string name = Page.User.Identity.Name;
            DataSet ds = show.GetMemberInfoByName(name);
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                ZoneSelectControl1.CountryID = ds.Tables[0].Rows[0]["countrycode"].ToString().Trim();
                ZoneSelectControl1.ProvinceID = ds.Tables[0].Rows[0]["provinceid"].ToString().Trim();
                ZoneSelectControl1.CityID = ds.Tables[0].Rows[0]["cityid"].ToString().Trim();
                ZoneSelectControl1.CountyID = ds.Tables[0].Rows[0]["countyid"].ToString().Trim();
            }

            int num = show.IfUserName(name);

            if (num <= 0)
            {
                CompanyAdd.Visible = true;
                PointOut.Visible = false;
            }
            else
            {
                int com = show.IfAudit(name);
                if (com == 1)
                {
                    CompanyAdd.Visible = false;
                    PointOut.Visible = true;
                    SpanMessage.InnerHtml = "您的招商拓富通已经存在，请点此进入<a href=\"http://" + name + ".topfo.com\" class=\"lan1\" target=\"_blank\">http://" + name + ".topfo.com</a><br/>您的招商拓富通后台管理，请点此进入<a href=\"http://dp.topfo.com/Login.aspx\" class=\"lan1\" target=\"_blank\" >http://dp.topfo.com/Login.aspx</a>";
                }
                else if (com == 0)
                {
                    CompanyAdd.Visible = false;
                    PointOut.Visible = true;
                    SpanMessage.InnerHtml = "您的招商拓富通已经发布，正处在审核中，如果想尽快得到招商拓富通首页，请拨打客服热线：<span class='lan1'>0755-89805588</span>";
                }
                else if (com == 2)
                {
                    CompanyAdd.Visible = false;
                    PointOut.Visible = true;
                    SpanMessage.InnerHtml = "您的招商拓富通已经发布，不过审核没有通过，如果想得知原因，请拨打客服热线：<span class='lan1'>0755-89805588</span>";
                }
                else
                {
                    CompanyAdd.Visible = false;
                    PointOut.Visible = true;
                    SpanMessage.InnerHtml = "您的招商拓富通已经发布，并已过期，如果想得知原因，请拨打客服热线：<span class='lan1'>0755-89805588</span>";
                }
            }

            txtUserName.InnerHtml = name;// Page.User.Identity.Name;
        }
    }
    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表


        SHA1 sha1 = SHA1.Create();
        byte[] passWord2 = sha1.ComputeHash(Encoding.Unicode.GetBytes(this.txtUserPwd.Value.ToString().Trim()));
        string name = Page.User.Identity.Name;
        string[] num = member.SelMemberNews(name).Split('&');
        company.UserName = name;//用户名
        company.UserPwd = passWord2;//密码
        company.TelPhone = txtTelCountry.Value.ToString().Trim() + "-" + txtTelZoneCode.Value.ToString().Trim() + "-" + txtTelNumber.Value.ToString().Trim();//电话号码 
        company.Mobile = txtMobile.Value.ToString().Trim();//手机号码
        company.Email = txtEmail.Value.ToString().Trim();//电子邮箱
        company.Audit = 0;//审核状态
        company.StartTime = DateTime.Now;//发布时间
        company.Valid = 0;//展厅有效期
        company.CompanyName = txtCompanyName.Value.ToString().Trim();//企业名称
        company.Typename = num[6].ToString();//所属类型
        company.Countrycode = ZoneSelectControl1.CountryID;
        company.Provinceid = ZoneSelectControl1.ProvinceID;
        company.Cityid = ZoneSelectControl1.CityID;
        company.Countyid = ZoneSelectControl1.CountyID;
        company.OrderId = 0;
        company.Recomm = "推荐地方";
        industryModels = SelectIndustryControl1.IndustryModels;

        //结束处
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            company.Industry += model.IndustryBID + ",";
        }
        int add = show.AddShow(company);
        if (add != 1)
        {
            Tz888.Common.MessageBox.Show(this.Page, "添加失败");
        }
        else
        {
            Tz888.Common.MessageBox.ShowAndHref("添加成功", "PostCompanyShow.aspx");
        }
    }
}
