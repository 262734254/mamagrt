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
using Tz888.Common.Utility;
using Tz888.Common;

public partial class PublishNavigateH2 : System.Web.UI.Page
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
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["alt"] == "1")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["InfoID"]))
                {
                    btnOk.Visible = false; getModel(int.Parse(Request.QueryString["InfoID"]));
                }
            }
            else { btnUpdate.Visible = false; }
            SelectIndustry();
            btnOk.Attributes.Add("onclick", "return chkPost();");
        }
    }
    //机构类型
    private void SelectIndustry()
    {
        Tz888.BLL.BusinesProcess bll = new Tz888.BLL.BusinesProcess();
        this.DropIndustry.DataSource = bll.SelectIndustry(0);
        this.DropIndustry.DataTextField = "StructureName";
        this.DropIndustry.DataValueField = "StructureID";
        this.DropIndustry.DataBind();
    }
    protected void getModel(int id)
    {
        Tz888.BLL.UserInfoH dal = new Tz888.BLL.UserInfoH();
        Tz888.Model.UserInfoZ model = dal.getModel(id);
        if(model!=null)
        {
        txtCompanyName.Value = model.CompanyName.ToString();
        ZoneSelectControl1.CountryID = model.CountryCode.ToString();
        ZoneSelectControl1.ProvinceID = model.ProvinceID.ToString();
        ZoneSelectControl1.CityID = model.CityID.ToString();
        ZoneSelectControl1.CountyID = model.CountyID.ToString();

        if (!string.IsNullOrEmpty(model.Structid.ToString()))
        { DropIndustry.SelectedValue =model.Structid.ToString();

        }
       
        ServiesMoreControl1.ServiesBString =model.ServiesBID.ToString()+"|"+ model.ServiesMID.ToString();
        txtEmployeeCount.Value = model.EmployeeCount.ToString();
        txtRegistMoeny.Value = model.RegistMoeny.ToString();
        txtRegistYear.Value = model.RegistYear.ToString();
        txtTurnover.Value = model.Turnover.ToString();
        txtBusinesDetails.Text = model.BusinesDetails.ToString();
        txtWebSite.Value = model.WebSite.ToString();
        txtLinkFax.Value = model.LinkFax.ToString();
        txtLinkMan.Value = model.LinkMan.ToString();
        txtLinkTel.Value = model.LinkTel.ToString();
        txtEmail.Value = model.Email.ToString();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        Tz888.Model.UserInfoZ model = new Tz888.Model.UserInfoZ();
        Tz888.BLL.UserInfoH dal = new Tz888.BLL.UserInfoH();
        if (chkPost() != "")
        {
            MessageBox.Show(this.Page, chkPost());
            return;
        }
        model.InfoID = int.Parse(Request.QueryString["InfoID"]);
        model.CompanyName = this.txtCompanyName.Value.Trim();
        model.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.CityID = this.ZoneSelectControl1.CityID;
        model.CountyID = this.ZoneSelectControl1.CountyID;
        model.Structid = this.DropIndustry.SelectedValue;
        
       
        model.ServiesBID  =this.ServiesMoreControl1.ServicesBID;
        model.ServiesMID = this.ServiesMoreControl1.ServicesMID;

        model.EmployeeCount = 0;
        if (this.txtEmployeeCount.Value.Trim() != "")
        {
            model.EmployeeCount = Convert.ToInt32(this.txtEmployeeCount.Value.Trim());
        }
        model.RegistMoeny = 0;
        if (this.txtRegistMoeny.Value.Trim() != "")
        {
            model.RegistMoeny = Convert.ToDecimal(this.txtRegistMoeny.Value.Trim());
        }
        model.RegistYear = 0;
        if (this.txtRegistYear.Value.Trim() != "")
        {
            model.RegistYear = Convert.ToDecimal(this.txtRegistYear.Value.Trim());
        }
        model.Turnover = 0;
        if (this.txtTurnover.Value.Trim() != "")
        {
            model.Turnover = Convert.ToDecimal(this.txtTurnover.Value.Trim());
        }
        model.BusinesDetails = this.txtBusinesDetails.Text.Trim();
        model.WebSite = this.txtWebSite.Value.Trim();
        model.LinkMan = this.txtLinkMan.Value.Trim();
        model.LinkTel = this.txtLinkTel.Value.Trim();
        model.LinkFax = this.txtLinkFax.Value.Trim();
        model.Email = this.txtEmail.Value.Trim();
        //-----------------------------------主表信息-------------
        DateTime time_Now = DateTime.Now;
        mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCompanyName.Value);
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Offer", this.ServiesMoreControl1.ServicesBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.Descript = this.txtBusinesDetails.Text.Trim();

        //------------------------
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCompanyName.Value);


        bool b = dal.update(mainInfoModel, model, sortInfoModel);

        if (b)
        { MessageBox.ShowAndHref("更新成功!", "../PayManage/StructManage.aspx"); }
        else { Tz888.Common.MessageBox.Show(this.Page, "更改失败！"); }


    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        Tz888.Model.UserInfoZ model = new Tz888.Model.UserInfoZ();//申请提供专业服务实体
        Tz888.BLL.UserInfoH dal = new Tz888.BLL.UserInfoH();


       
        if (chkPost() != "")
        {
            MessageBox.Show(this.Page, chkPost());
            return;
        }

 //-----------------------------------申请提供专业服务信息-------------
       
        string userName = Page.User.Identity.Name; //获得用户名
        model.UserName = userName;
        model.CompanyName = this.txtCompanyName.Value.Trim();
        model.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.CityID = this.ZoneSelectControl1.CityID;
        model.CountyID = this.ZoneSelectControl1.CountyID;
        model.Structid = this.DropIndustry.SelectedValue;
        model.ServiesBID = this.ServiesMoreControl1.ServicesBID;
        model.ServiesMID = this.ServiesMoreControl1.ServicesMID;
        model.EmployeeCount = 0;
        if (this.txtEmployeeCount.Value.Trim() != "")
        {
            model.EmployeeCount = Convert.ToInt32(this.txtEmployeeCount.Value.Trim());
        }
        model.RegistMoeny = 0;
        if (this.txtRegistMoeny.Value.Trim() != "")
        {
            model.RegistMoeny = Convert.ToDecimal(this.txtRegistMoeny.Value.Trim());
        }
        model.RegistYear = 0;
        if (this.txtRegistYear.Value.Trim() != "")
        {
            model.RegistYear = Convert.ToDecimal(this.txtRegistYear.Value.Trim());
        }
        model.Turnover = 0;
        if (this.txtTurnover.Value.Trim() != "")
        {
            model.Turnover = Convert.ToDecimal(this.txtTurnover.Value.Trim());
        }
        model.BusinesDetails = this.txtBusinesDetails.Text.Trim();
        model.WebSite = this.txtWebSite.Value.Trim();
        model.LinkMan = this.txtLinkMan.Value.Trim();
        model.LinkTel = this.txtLinkTel.Value.Trim();
        model.LinkFax = this.txtLinkFax.Value.Trim();
        model.Email = this.txtEmail.Value.Trim();

        //-----------------------------------主表信息-------------

        mainInfoModel.Title = this.txtCompanyName.Value;
        DateTime time_Now = DateTime.Now;
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Offer", this.ServiesMoreControl1.ServicesBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;
        mainInfoModel.IsCore = true;
        mainInfoModel.LoginName = Page.User.Identity.Name;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;
        string keyword = "";
        mainInfoModel.Descript = this.txtBusinesDetails.Text.Trim();
        if (!string.IsNullOrEmpty(this.txtCompanyName.Value.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCompanyName.Value.Trim());
        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = 3;
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";


        //------------------------
        sortInfoModel.ShortInfoControlID = "OfferIndex1";
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtCompanyName.Value);
        sortInfoModel.ShortContent = "";
        sortInfoModel.Remark = "";



        long infoID = dal.OfferInsert(mainInfoModel, model, sortInfoModel);
        if (infoID>0)
            MessageBox.ShowAndHref("申请提交成功!", "../PayManage/StructManage.aspx");
    }
    public string chkPost()
    {
        string strErr = "";
        if (txtCompanyName.Value.Trim() == "")
        {
            strErr += "公司名称不能为空！\\n";
        }
        if (this.DropIndustry.SelectedValue == "" || this.DropIndustry.SelectedValue == "0")
        {
            strErr += "行业不能为空！\\n";
        }
        if (this.ServiesMoreControl1.ServiesBString == "")
        {
            strErr += "服务类别不能为空！\\n";
        }
        if (txtEmployeeCount.Value != "")
        {
            if (!PageValidate.IsNumber(txtEmployeeCount.Value))
            {
                strErr += "企业规模请填写数字！\\n";
            }
        }
        if (txtRegistMoeny.Value != "")
        {
            if (!PageValidate.IsNumber(txtRegistMoeny.Value))
            {
                strErr += "注册资金请填写数字！\\n";
            }
        }
        if (txtRegistYear.Value != "")
        {
            if (!PageValidate.IsNumber(txtRegistYear.Value))
            {
                strErr += "注册年数请填写数字！\\n";
            }
        }
        if (txtTurnover.Value != "")
        {
            if (!PageValidate.IsNumber(txtTurnover.Value))
            {
                strErr += "营业额请填写数字！\\n";
            }
        }

        if (txtLinkMan.Value.Trim() == "")
        {
            strErr += "联系人不能为空！\\n";
        }
        if (txtLinkTel.Value.Trim() == "")
        {
            strErr += "联系人电话不能为空！\\n";
        }
        if (!PageValidate.IsNumber(txtLinkTel.Value.Trim()))
        {
            strErr += "联系人电话格式错误！\\n";
        }
        if (txtEmail.Value.Trim() == "")
        {
            strErr += "Email不能为空！\\n";
        }
        if (!PageValidate.IsEmail(txtEmail.Value.ToLower().Trim()))
        {
            strErr += "Email地址格式错误\\n";
        }

        return strErr;
    }
    
}
