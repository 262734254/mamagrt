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
/// 发布专业服务需求
/// </summary>
public partial class Publish_Professional_PublishProfessional : System.Web.UI.Page
{
    ProfessionalTypeBLL bll = new ProfessionalTypeBLL();
    ProfessionalviewBLL viewbll = new ProfessionalviewBLL();

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

        } btnSubmit.Attributes.Add("onclick", "return CheckForm();");
    }
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
    }
    //申请
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txtTitle.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写标题!");
            return;
        }
        if (string.IsNullOrEmpty(this.ddlServiceType.SelectedValue))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请选择服务大类！");
            return;
        }
        //if (string.IsNullOrEmpty(this.slServerMDrop.SelectedValue))
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "请选择服务小类！");
        //    return;
        //}
        if (string.IsNullOrEmpty(this.txtContent.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写说明!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtLinkMan.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写申请人!");
            return;
        }
        if (string.IsNullOrEmpty(this.txtCompany.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写单位名称!");
            return;
        }


        //if (string.IsNullOrEmpty(this.txtTel.Text))
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "请填写联系电话!");
        //    return;
        //}
        if (txtTel.Text.Trim() == "" && txtPhone.Text.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系人电话和手机至少填一个！");
            return;
        }
        else
        {
            if (txtTel.Text.Trim() != "")
            {
                if (!PageValidate.IsNumber(txtTel.Text.Trim()))
                {
                    Tz888.Common.MessageBox.Show(this.Page, "联系人电话格式错误！");
                    return;
                }
            }
        }
        //if (string.IsNullOrEmpty(this.txtFax.Text))
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "请填写传真号码!");
        //    return;
        //}
        if (txtEmail.Text.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "Email不能为空！！");
            return;
        }
        if (txtEmail.Text.Trim() != "")
        {
            if (!PageValidate.IsEmail(txtEmail.Text.ToLower().Trim()))
            {
                Tz888.Common.MessageBox.Show(this.Page, "Email地址格式错误！");
                return;
            }

        }
        ProfessionalinfoTab MainInfo = new ProfessionalinfoTab();
        Professionalview viewInfo = new Professionalview();
        ProfessionalLink personInfo = new ProfessionalLink();

        MainInfo.LoginName = Page.User.Identity.Name;
        MainInfo.Titel = txtTitle.Text.Trim();
        MainInfo.typeID = 1;
        //MainInfo.auditId = 0; MainInfo.stateId = 0; MainInfo.chargeId = 0;MainInfo.clickId = 0;
        //MainInfo.creatgeDate = Convert.ToDateTime(DateTime.Now.ToString());MainInfo.refreshTime=
        MainInfo.htmlUrl = "";
        MainInfo.FromId = 1;
        MainInfo.recommendId = 0;
        MainInfo.price = 0; //Convert.ToDecimal(txtPrice.Text.Trim());

        viewInfo.CountryCode = this.ZoneSelectControl1.CountryID;
        viewInfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        viewInfo.CityID = this.ZoneSelectControl1.CityID;
        viewInfo.CountyID = this.ZoneSelectControl1.CountyID;
        viewInfo.description = txtContent.Text.Trim();
        viewInfo.title = ""; //txtTitle.Text.Trim();
        viewInfo.keywords = "";//txtKeyword1.Text.Trim();
        viewInfo.Webdescription = ""; //txtWebDesr.Text.Trim();
        viewInfo.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());
        viewInfo.typeID = int.Parse(ddlServiceType.SelectedValue.ToString());

        personInfo.Address = txtAddress.Text.Trim();

        personInfo.CompanyName = txtCompany.Text.Trim();
        personInfo.Email = txtEmail.Text.Trim();
        personInfo.Fax = txtFax.Text.Trim();
        personInfo.phone = txtPhone.Text.Trim();

        string tel = string.Empty;
        if (!string.IsNullOrEmpty(txtcontactsTel.Text.Trim()))
        {
            tel = txtcontactsTel.Text.Trim() + ",";
        }
        else
        {
            tel = ",";
        }
        if (!string.IsNullOrEmpty(txtTel.Text.Trim()))
        {
            tel += txtTel.Text.Trim() + ",";
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
        personInfo.Tel = tel;
        personInfo.UserName = txtLinkMan.Text.Trim();//之前没改过来
        personInfo.Site = txtSite.Text.Trim();
        personInfo.phone = txtPhone.Text.Trim();

        if (viewbll.InsertProFessionlView(MainInfo, viewInfo, personInfo))
        {
            Response.Write("<script>alert('发布成功！');document.location='ServiesManage.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }
}
