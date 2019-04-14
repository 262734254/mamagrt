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
public partial class Publish_Professional_ModefiyProOrg : System.Web.UI.Page
{
    ProfessionalinfoBLL infoBll = new ProfessionalinfoBLL();
    ProfessionalLinkBLL linkBll = new ProfessionalLinkBLL();
    ProfessionalPleaseBLL plBll = new ProfessionalPleaseBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (string.IsNullOrEmpty(Page.User.Identity.Name))
            {
                Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
            }

            databind();
            if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
            {
                int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
                databindList(ProfessionalID);
            }
        } btnOk.Attributes.Add("onclick", "return chkPost();");
    }
    protected void databindList(int ProfessionalID)
    {
        
        ProfessionalPlease plModel = plBll.GetModel(ProfessionalID);
        ProfessionalLink linkModel = linkBll.GetModel(ProfessionalID);
        ProfessionalinfoTab inModel = infoBll.GetModel(ProfessionalID);
        txtTitle.Text = inModel.Titel.ToString();
        this.ZoneSelectControl1.CountryID = plModel.CountryCode;
        this.ZoneSelectControl1.ProvinceID = plModel.ProvinceID;
        this.ZoneSelectControl1.CityID = plModel.CityID;
        this.ZoneSelectControl1.CountyID = plModel.CountyID;
        txtBusinesDetails.Text = plModel.description;
        txtRegistYear.Text = plModel.companydate.ToString("yyyy-MM-dd");
        ddlServiceType.SelectedValue = plModel.servicetypeID.ToString();//服务类型
        DropIndustry.SelectedValue = plModel.institutionsID.ToString();//机构类别
        txtEmployeeCount.Value = plModel.Enterprisesize;//企业规模
        txtRegistMoeny.Value = plModel.funds;//注册资金
        txtTurnover.Value = plModel.turnover;//营业额
        rdlValiditeTerm.SelectedValue = plModel.validityID.ToString();//有效期
        txtAddress.Text = linkModel.Address;
        txtLinkMan.Value = linkModel.UserName;
        txtPhone.Text = linkModel.phone;
        txtCompanyName.Value = linkModel.CompanyName;
        
        txtEmail.Value = linkModel.Email;
        txtLinkFax.Value = linkModel.Fax;
        txtLinkTel.Value = linkModel.Tel;
        txtWebSite.Value = linkModel.Site;
    }
    private void databind()
    {
        ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
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
        //    Tz888.Common.MessageBox.Show(this.Page, "创建时间请填写！");
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
        if (txtLinkTel.Value.Trim() == "" && txtPhone.Text.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系人电话和手机至少填一个！");
            return;
        }
        else
        {
            if (txtLinkTel.Value.Trim() != "")
            {
                if (!PageValidate.IsNumber(txtLinkTel.Value.Trim()))
                {
                    Tz888.Common.MessageBox.Show(this.Page, "联系人电话格式错误！");
                    return;
                }
            }
        }
        if (txtEmail.Value.Trim() != "")
        {
            if (!PageValidate.IsEmail(txtEmail.Value.ToLower().Trim()))
            {
                Tz888.Common.MessageBox.Show(this.Page, "Email地址格式错误！");
                return;
            }

        }
        ProfessionalPlease please = new ProfessionalPlease();
        ProfessionalinfoTab MainInfo=new ProfessionalinfoTab();
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
        }
        ProfessionalLink link = new ProfessionalLink();
        please.CountryCode = this.ZoneSelectControl1.CountryID;
        please.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        please.CityID = this.ZoneSelectControl1.CityID;
        please.CountyID = this.ZoneSelectControl1.CountyID;
        please.description = txtBusinesDetails.Text.Trim();
        please.companydate = Convert.ToDateTime(txtRegistYear.Text.Trim().ToString());
        please.servicetypeID = int.Parse(ddlServiceType.SelectedValue.ToString());//服务类型
        please.institutionsID = int.Parse(DropIndustry.SelectedValue.ToString());//机构类别
        please.Enterprisesize = txtEmployeeCount.Value.Trim();//企业规模
        please.funds = txtRegistMoeny.Value.Trim();//注册资金
        please.turnover = txtTurnover.Value.Trim();//营业额
        please.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());//有效期
        link.CompanyName = txtCompanyName.Value.Trim();
        link.Email = txtEmail.Value.Trim();
        link.Fax = txtLinkFax.Value.Trim();
        link.Tel = txtLinkTel.Value.Trim();
        link.UserName = txtLinkMan.Value.Trim();
        link.Site = txtWebSite.Value.Trim();
        link.Address = txtAddress.Text.Trim();
        link.phone = txtPhone.Text.Trim();
        MainInfo.Titel = txtTitle.Text.Trim();
        MainInfo.LoginName = Page.User.Identity.Name;
        if (plBll.UpdateProFessionlView(MainInfo, please, link))
        {
            Response.Write("<script>alert('修改成功！');document.location='ServiesManage.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "修改失败！");
        }
    }
}
