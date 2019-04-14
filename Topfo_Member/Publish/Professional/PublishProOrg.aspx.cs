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
using Tz888.BLL.Professional;
using Tz888.Model.Professional;
using Tz888.Common.Utility;
using Tz888.Common;
/// <summary>
/// 专业服务机构
/// </summary>
public partial class Publish_Professional_PublishProOrg : System.Web.UI.Page
{
    ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
    ProfessionalPleaseBLL bllPlease = new ProfessionalPleaseBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (string.IsNullOrEmpty(Page.User.Identity.Name))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }
            this.rdlValiditeTerm.SelectedIndex = 0;
            databind();

        } btnOk.Attributes.Add("onclick", "return chkPost();");
    }
    private void databind()
    {
        ddlServiceType.DataSource = bll.GetTypeAll();
        ddlServiceType.DataTextField = "typeName";
        ddlServiceType.DataValueField = "typeId";
        ddlServiceType.DataBind();

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdlValiditeTerm.DataTextField = "cdictname";
        this.rdlValiditeTerm.DataValueField = "idictvalue";
        this.rdlValiditeTerm.DataSource = dt;
        this.rdlValiditeTerm.DataBind();
        //机构类别
        OrganizationTypeBLL orgBll = new OrganizationTypeBLL();
        this.DropIndustry.DataSource = orgBll.GetList("");
        this.DropIndustry.DataTextField = "TypeName";
        this.DropIndustry.DataValueField = "institutionsID";
        this.DropIndustry.DataBind();
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtTitle.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写标题!");
            return;
        }

        if (this.DropIndustry.SelectedValue == "" || this.DropIndustry.SelectedValue == "0")
        {
            Tz888.Common.MessageBox.Show(this.Page, "行业不能为空！");
            return;
        }
        if (this.ddlServiceType.SelectedValue == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "服务类别不能为空！");
            return;
        }
        if (txtEmployeeCount.Value != "")
        {
            if (!PageValidate.IsNumber(txtEmployeeCount.Value))
            {
                Tz888.Common.MessageBox.Show(this.Page, "企业规模请填写数字！");
                return;
            }
        }
        if (txtRegistMoeny.Value != "")
        {
            if (!PageValidate.IsNumber(txtRegistMoeny.Value))
            {
                Tz888.Common.MessageBox.Show(this.Page, "注册资金请填写数字！");
                return;
            }
        }
        //if (txtRegistYear.Text == "")
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "注册年数请填写！");
        //    return;

        //}
        if (txtTurnover.Value != "")
        {
            if (!PageValidate.IsNumber(txtTurnover.Value))
            {
                Tz888.Common.MessageBox.Show(this.Page, "营业额请填写数字！");
                return;
            }
        }

        if (txtLinkMan.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系人不能为空！");
            return;
        }
        if (txtCompanyName.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "公司名称不能为空！");
            return;
        }
        //if (txtLinkTel.Value.Trim() == "")
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "联系人电话不能为空！");
        //    return;
        //}
        if (txtLinkTel.Text.Trim() == "" && txtPhone.Text.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系人电话和手机至少填一个！");
            return;
        }
        else
        {
            if (txtLinkTel.Text.Trim() != "")
            {
                if (!PageValidate.IsNumber(txtLinkTel.Text.Trim()))
                {
                    Tz888.Common.MessageBox.Show(this.Page, "联系人电话格式错误！");
                    return;
                }
            }

        }
        if (txtEmail.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "Email不能为空！！");
            return;
        }
        if (txtEmail.Value.Trim() != "")
        {
            if (!PageValidate.IsEmail(txtEmail.Value.ToLower().Trim()))
            {
                Tz888.Common.MessageBox.Show(this.Page, "Email地址格式错误！");
                return;
            }

        }
        ProfessionalinfoTab MainInfo = new ProfessionalinfoTab();
        ProfessionalPlease please = new ProfessionalPlease();
        ProfessionalLink link = new ProfessionalLink();
        MainInfo.LoginName = Page.User.Identity.Name;
        MainInfo.htmlUrl = "";
        MainInfo.Titel = txtTitle.Text.Trim();
        MainInfo.typeID = 2;
        MainInfo.FromId = 1;
        MainInfo.recommendId = 0;
        MainInfo.price = 0;
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
        }
        please.CountryCode = this.ZoneSelectControl1.CountryID;
        please.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        please.CityID = this.ZoneSelectControl1.CityID;
        please.CountyID = this.ZoneSelectControl1.CountyID;
        please.description = txtBusinesDetails.Text.Trim();
        please.companydate = Convert.ToDateTime(DateTime.Now.ToString());//Convert.ToDateTime(txtRegistYear.Text.Trim().ToString());
        please.servicetypeID = int.Parse(ddlServiceType.SelectedValue.ToString());//服务类型
        please.institutionsID = int.Parse(DropIndustry.SelectedValue.ToString());//机构类别
        please.Enterprisesize = txtEmployeeCount.Value.Trim();//企业规模
        please.funds = txtRegistMoeny.Value.Trim();//注册资金
        please.turnover = txtTurnover.Value.Trim();//营业额
        please.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());//有效期
        link.CompanyName = txtCompanyName.Value.Trim();
        link.Email = txtEmail.Value.Trim();
        link.Fax = txtLinkFax.Value.Trim();

        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim() + ",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtLinkTel.Text.Trim()))
        {
            tel += txtLinkTel.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        if (!string.IsNullOrEmpty(txttel2.Text.Trim()))
        {
            tel += txttel2.Text.Trim() + ",";
        }
        else
        {
            tel += ",";
        }
        link.Tel = tel;

        link.UserName = txtLinkMan.Value.Trim();
        link.Site = txtWebSite.Value.Trim();
        link.Address = txtAddress.Text;
        link.phone = txtPhone.Text.Trim();
        if (bllPlease.InsertProFessionlView(MainInfo, please, link))
        {
            Response.Write("<script>alert('发布成功！');document.location='ServiesManage.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }

}
