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
using Tz888.BLL;
using Tz888.BLL.Professional;
using Tz888.Common;
using Tz888.Common.Utility;
public partial class Publish_Professional_ModefiyProService : System.Web.UI.Page
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
            databind();
            if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
            {
                int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
                databindList(ProfessionalID);
            }

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
    protected void databindList(int ProfessionalID)
    {
        long PageSize = 0;
        long CurrPage = 0;
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Conn();
        DataTable dt = dal.GetList("ProfessionalService_View_List", "ProfessionalID", "Fax,Address,validityID,CompanyName,phone,ProfessionalID,CountryCode,ProvinceID,CityID,CountyID,UserName,description,typeID,Email,Titel,Site,Tel", " ProfessionalID=" + ProfessionalID + "", "CreateDate desc ", ref CurrPage, PageSize, ref TotalCount);
        if ((dt != null) && (dt.Rows.Count > 0))
        {

            txtTitle.Text = dt.Rows[0]["Titel"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtCompany.Text = dt.Rows[0]["CompanyName"].ToString();
            txtPhone.Text = dt.Rows[0]["phone"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtFax.Text = dt.Rows[0]["Fax"].ToString();
            txtContent.Text = dt.Rows[0]["description"].ToString();
            txtTel.Text = dt.Rows[0]["Tel"].ToString();
            txtSite.Text = dt.Rows[0]["Site"].ToString();
            txtLinkMan.Text = dt.Rows[0]["UserName"].ToString();
            txtPhone.Text = dt.Rows[0]["phone"].ToString();
            this.ZoneSelectControl1.CountryID = dt.Rows[0]["CountryCode"].ToString();
            this.ZoneSelectControl1.ProvinceID = dt.Rows[0]["ProvinceID"].ToString();
            this.ZoneSelectControl1.CityID = dt.Rows[0]["CityID"].ToString();
            this.ZoneSelectControl1.CountyID = dt.Rows[0]["CountyID"].ToString();
            rdlValiditeTerm.SelectedValue = dt.Rows[0]["validityID"].ToString();
            ddlServiceType.SelectedValue = dt.Rows[0]["typeId"].ToString();
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
    //修改
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
        if (string.IsNullOrEmpty(this.txtCompany.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写单位名称!");
            return;
        }
       
        if (string.IsNullOrEmpty(this.txtLinkMan.Text))
        {
            Tz888.Common.MessageBox.Show(this.Page, "请填写申请人!");
            return;
        }
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
        if (!string.IsNullOrEmpty(Request.QueryString["ProfessionalID"]))
        {
            int ProfessionalID = int.Parse(Request.QueryString["ProfessionalID"].ToString());
            MainInfo.ProfessionalID = ProfessionalID;
        }
        MainInfo.Titel = txtTitle.Text.Trim();
        viewInfo.CountryCode = this.ZoneSelectControl1.CountryID;
        viewInfo.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        viewInfo.CityID = this.ZoneSelectControl1.CityID;
        viewInfo.CountyID = this.ZoneSelectControl1.CountyID;
        viewInfo.description = txtContent.Text.Trim();
        viewInfo.validityID = int.Parse(rdlValiditeTerm.SelectedValue.ToString());
        viewInfo.typeID = int.Parse(ddlServiceType.SelectedValue.ToString());
        personInfo.Address = txtAddress.Text.Trim();
        personInfo.CompanyName = txtCompany.Text.Trim();
        personInfo.Email = txtEmail.Text.Trim();
        personInfo.Fax = txtFax.Text.Trim();
        personInfo.phone = txtPhone.Text.Trim();
        personInfo.Tel = txtTel.Text.Trim();
        personInfo.UserName = txtLinkMan.Text.Trim();
        personInfo.Site = txtSite.Text.Trim();
        personInfo.phone = txtPhone.Text.Trim();
        MainInfo.LoginName = Page.User.Identity.Name;
        if (viewbll.UpdateProFessionlView(MainInfo, viewInfo, personInfo))
        {
            Response.Write("<script>alert('更新成功！');document.location='ServiesManage.aspx'</script>");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "更新失败！");
        }
    }
}
