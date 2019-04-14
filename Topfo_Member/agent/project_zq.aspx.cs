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
using System.Collections.Generic;
public partial class agent_project_zq : System.Web.UI.Page
{
    private string fz_LoginName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.ImageUploadControl1.InfoType = "Project";
        this.ImageUploadControl1.NoneCount = 3;
        this.ImageUploadControl1.Count = 3;
        BtnOk.Attributes.Add("onclick", "return chkpost()");
        fz_LoginName = Request.QueryString["fzname"].ToString();
        if (!Page.IsPostBack)
        {
            bindObj();
            BindSetCapital();
        }
    }
    /// 绑定融资金额
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        rbtnCapital.DataSource = bll.GetList();
        rbtnCapital.DataTextField = "CapitalName";
        rbtnCapital.DataValueField = "CapitalID";
        rbtnCapital.DataBind();
        rbtnCapital.SelectedIndex = 0;
    }
    //融资对象
    public void bindObj()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("SETfinancingTargetTab", "*", "financingID", 10, 1, 0, 0, "");
        rbtnObj.DataTextField = "financingName";
        rbtnObj.DataValueField = "financingID";
        rbtnObj.DataSource = dt;
        rbtnObj.DataBind();
        rbtnObj.SelectedIndex = 0;
    }
    protected void BtnOk_Click(object sender, ImageClickEventArgs e)
    {
        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;

        projectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        projectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        projectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        projectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        projectInfoModel.ProjectName = this.txtProjectName.Value.Trim();
        projectInfoModel.RecTime = DateTime.Now;
        projectInfoModel.CapitalCurrency = "CNY";
        projectInfoModel.ProjectCurrency = "CNY";

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            projectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());//投资总额
        projectInfoModel.CapitalID = this.rbtnCapital.SelectedValue.Trim();//融资金额
        //项目说明
        projectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtProIntro.Value.Trim());
        //行业
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            projectInfoModel.IndustryBID += model.IndustryBID + ",";
        }
        projectInfoModel.CooperationDemandType = "9";//债券融资
       projectInfoModel.financingID =rbtnObj.SelectedValue;
        projectInfoModel.warrant = txtWarrant.Value.Trim();//融资担保
        if (rbtnObj.SelectedValue != "")
        {
            projectInfoModel.financingID = rbtnObj.SelectedValue.Trim();//融资对象
        }
        //-----------------------------------主表信息-------------
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        mainInfoModel.LoginName = fz_LoginName;
        mainInfoModel.InfoOriginRoleName = "1"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;
        mainInfoModel.ValidateTerm = Convert.ToInt32(rbtnValiDate.SelectedValue);
        string keyword = "";

        mainInfoModel.Descript = "";
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = Convert.ToInt32(this.rbtnValiDate.SelectedValue.Trim());
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";

        //------------------------
        sortInfoModel.ShortInfoControlID = "ProjectIndex1";
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        sortInfoModel.ShortContent = "";
        sortInfoModel.Remark = "";

        long infoID = projectObj.PublishProjectZQ1(mainInfoModel, projectInfoModel, sortInfoModel);

        if (infoID > 0)
        {
            //补充信息
            projectInfoModel.marketAbout = txtMarketAbout.Value.Trim();
            decimal CompanyNG = 0;
            if (Tz888.Common.Utility.PageValidate.IsNumber(txtCompanyNG.Value.Trim()))
            {
                CompanyNG = Convert.ToDecimal(txtCompanyNG.Value.Trim());
            }
            projectInfoModel.CompanyNG = CompanyNG;
            decimal CompanyTotalDebet = 0;
            if (Tz888.Common.Utility.PageValidate.IsNumber(txtCompanyTotalDebet.Value.Trim()))
            {
                CompanyTotalDebet = Convert.ToDecimal(txtCompanyTotalDebet.Value.Trim());
            }
            projectInfoModel.CompanyTotalDebet = CompanyTotalDebet;


            decimal CompanyYearIncome = 0;
            if (Tz888.Common.Utility.PageValidate.IsNumber(txtCompanyYearIncome.Value.Trim()))
            {
                CompanyYearIncome = Convert.ToDecimal(txtCompanyYearIncome.Value.Trim());
            }
            projectInfoModel.CompanyYearIncome = CompanyYearIncome;

            decimal CompanyTotalCapital = 0;
            if (Tz888.Common.Utility.PageValidate.IsNumber(txtCompanyTotalCapital.Value.Trim()))
            {
                CompanyYearIncome = Convert.ToDecimal(txtCompanyTotalCapital.Value.Trim());
            }
            projectInfoModel.CompanyTotalCapital = CompanyTotalCapital;

            projectInfoModel.InfoID = infoID;
            projectObj.PublishProjectZQ2(projectInfoModel);


            //添加附件
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>();
            infoResourceModels = this.ImageUploadControl1.InfoList;
            if (infoResourceModels != null)
            {
                Tz888.SQLServerDAL.Info.InfoResourceDAL obj2 = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                foreach (Tz888.Model.Info.InfoResourceModel ResModel in infoResourceModels)
                {
                    ResModel.InfoID = infoID;
                    obj2.Insert(ResModel);
                }
            }

            //联系信息
            Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
            Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();

            model.InfoID = infoID;
            model.OrganizationName = txtCompanyName.Value.Trim();
            model.Name = txtLinkMan.Value.Trim();
            model.Career = txtCareer.Value.Trim();
            model.TelStateCode = txtTelStateCode.Value.Trim();
            model.TelNum = txtTel.Value.Trim();
            model.Mobile = txtMobile.Value.Trim();
            model.Address = txtAddress.Value.Trim();
            model.WebSite = txtWebSite.Value.Trim();
            model.Email = txtEmail.Value.Trim();
            bool b = dal.Add(model);
            {
                Tz888.Common.MessageBox.Show(this.Page, "发布成功！");
            }
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }
}
