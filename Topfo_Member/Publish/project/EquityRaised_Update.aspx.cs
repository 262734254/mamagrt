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
using Tz888.Common.Utility;

public partial class Publish_project_EquityRaised_Update : System.Web.UI.Page
{
    protected long _infoID2;
    protected long _infoid2;
    protected string title;
    protected string cooperationDemandType;
    string strLoginName = ""; //#

    /// <summary>
    /// 加载母板页面 在本地调试时不启用


    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

    protected void Page_Error(object sender, EventArgs e)
    {

        Exception ex = Server.GetLastError();

        if (ex is HttpRequestValidationException)
        {

            Response.Write("请您输入合法字符串。");

            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。 

        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {

        bool isTof = Page.User.IsInRole("GT1002");
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        strLoginName = Page.User.Identity.Name.Trim();
        //strLoginName = "topfo001";
        //_infoid2 = 2397086; //本地调试时默认值        
        _infoid2 = Convert.ToInt64(Request.QueryString["InfoID"]);
        //this.UpFileControl1.InfoID = _infoid2;        
        if (!Page.IsPostBack)
        {
            //显示联络人信息

            InitInfoContact();
            BindSetCapital();// 绑定融资金额
            #region 改版后删除信息

            #endregion
            Xmyxqxx();//项目有效期限

            GetInfoModel();//控件负值


        }

        //以下是取得上传文件信息
        this.FilesUploadControl1.InfoType = "Project";
        this.FilesUploadControl1.NoneCount = 5;
        this.FilesUploadControl1.Count = 5;
    }

    // 绑定融资金额
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        rbtnCapital.DataSource = bll.GetList();
        rbtnCapital.DataTextField = "CapitalName";
        rbtnCapital.DataValueField = "CapitalID";
        rbtnCapital.DataBind();
        //rbtnCapital.SelectedIndex = 0; 选定第一个

    }


    //项目有效期限
    public void Xmyxqxx()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='Xmyxqxx' ");
        rblXmyxqxx.DataTextField = "cdictname";
        rblXmyxqxx.DataValueField = "idictvalue";
        rblXmyxqxx.DataSource = dt;
        rblXmyxqxx.DataBind();
    }


    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        //转到债券融资_发布
        Response.Redirect("CreditorsRaised_Issue.aspx", true);
    }


    //初始化联络人信息
    private void InitInfoContact()
    {
        string loginName = Page.User.Identity.Name;
        //string loginName = "topfo001";//strLoginName; //#
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();
        model = bll.getContactModel(loginName);
        if (model == null)
            return;
        txtCompanyName.Value = model.OrganizationName.Trim();
        txtLinkMan.Value = model.Name.Trim();
        txtMobile.Value = model.Mobile.Trim();
        telArea1.Value = model.TelCountryCode.Trim(); //国际号

        txtTelStateCode.Value = model.TelStateCode.Trim();  //区号 
        txtTel.Value = model.TelNum.Trim(); //电话号

        //txtWebSite.Value = model.Website.Trim();
        txtEmail.Value = model.Email.Trim();
        txtAddress.Value = model.address.Trim();
        //txtCareer.Value = model.Career.Trim();

    }

    #region 控件赋值

    /// <summary>
    /// 控件赋值

    /// </summary>
    public void GetInfoModel()
    {

        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.ProjectSetModel model = bll.GetIntegrityModel(_infoid2);


        if (model == null)
            return;
        this.txtProjectName.Value = model.ProjectInfoModel.ProjectName;

        this.SelectIndustryControl1.IndustryString = model.ProjectInfoModel.IndustryBID;

        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountryCode.Trim()))
            this.ZoneSelectControl1.CountryID = model.ProjectInfoModel.CountryCode.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.ProvinceID.Trim()))
            this.ZoneSelectControl1.ProvinceID = model.ProjectInfoModel.ProvinceID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CityID.Trim()))
            this.ZoneSelectControl1.CityID = model.ProjectInfoModel.CityID.Trim();
        if (!string.IsNullOrEmpty(model.ProjectInfoModel.CountyID.Trim()))
            this.ZoneSelectControl1.CountyID = model.ProjectInfoModel.CountyID.Trim();

        //this.txtProIntro.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.ProjectInfoModel.ComAbout));

        //if (model.ProjectInfoModel.financingID.ToString() != "")
        //    rbtnObj.SelectedValue = model.ProjectInfoModel.financingID.ToString();
        this.txtCapitalTotal.Text = model.ProjectInfoModel.CapitalTotal.ToString();



        //项目有效期限
        if (model.MainInfoModel.ValidateTerm != null)
        {
            for (int i = 0; i < rblXmyxqxx.Items.Count; i++)
            {
                if (model.MainInfoModel.ValidateTerm.ToString() == rblXmyxqxx.Items[i].Value)
                {
                    rblXmyxqxx.Items[i].Selected = true;
                }
            }
        }
    #endregion
        ////管理团队




        if (model.ProjectInfoModel.CapitalID != "")
            rbtnCapital.SelectedValue = model.ProjectInfoModel.CapitalID;
        ////model.MainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        ////项目摘要
        txtProIntro.Value = model.ProjectInfoModel.ComBrief.Trim();
        ////项目详细描述
        txtXmqxms.Value = model.ProjectInfoModel.ComAbout;
        txtManageTeamAbout.Value = model.ProjectInfoModel.ManageTeamAbout.Trim();



        //联系信息
        if (model.InfoContactModel != null)
        {
            this.txtCompanyName.Value = model.InfoContactModel.OrganizationName;
            this.txtLinkMan.Value = model.InfoContactModel.Name;
            //this.txtCareer.Value = model.InfoContactModel.Career;
            this.txtTelStateCode.Value = model.InfoContactModel.TelStateCode.Trim();
            this.txtTel.Value = model.InfoContactModel.TelNum;
            this.txtMobile.Value = model.InfoContactModel.Mobile;
            this.txtEmail.Value = model.InfoContactModel.Email;
            this.txtAddress.Value = model.InfoContactModel.Address;
            this.txtWebSite.Value = model.InfoContactModel.WebSite;
        }
        //this.rbtnValiDate.SelectedValue = model.MainInfoModel.ValidateTerm.ToString();

        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        //ViewState["ProjectNameBrief"] = model.ProjectInfoModel.ProjectNameBrief;
        //ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        //ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        //ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
    }


    protected void btnIssueOK_Click(object sender, EventArgs e)
    {

        //判断电话与手机号
        if (txtTel.Value.Trim() == "" && txtMobile.Value.Trim() == "")
        {
            //Tz888.Common.MessageBox.Show(this.Page, "固定电话或手机至少填写一项，请检查！");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('固定电话或手机至少填写一项，请检查！');", false);
            return;
        }


    }

    //第二步，确认联络方式
    private void ConfirmContact()
    {
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();

        model.InfoID = _infoID2;
        model.OrganizationName = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtCompanyName.Value.Trim());
        model.Name = txtLinkMan.Value.Trim();
        //model.Career = txtCareer.Value.Trim();
        model.TelCountryCode = telArea1.Value.Trim(); //新加的国际号
        model.TelStateCode = txtTelStateCode.Value.Trim(); //区号

        if (telFg.Value.Trim() != "") //如果分机号不为空
            model.TelNum = txtTel.Value.Trim() + "-" + telFg.Value.Trim();
        else
            model.TelNum = txtTel.Value.Trim(); //电话号加分机号


        model.Mobile = txtMobile.Value.Trim();
        model.Address = txtAddress.Value.Trim();
        model.WebSite = txtWebSite.Value.Trim();
        model.Email = txtEmail.Value.Trim();
        bool b = dal.Update(model);
        if (b)
        {
            //用于生成静态页，暂不用
            Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();
            Tz888.BLL.Info.MainInfoBLL mainDAL = new Tz888.BLL.Info.MainInfoBLL();
            mainInfoModel = mainDAL.GetModel(_infoID2);
            string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", mainInfoModel.InfoCode, _infoID2);
            Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
            mainBll.HasHtmlFile(_infoID2, HtmlFile);
            string actionMsg = "";
            Tz888.BLL.PageStatic.ProjectPageStatic dalPage = new Tz888.BLL.PageStatic.ProjectPageStatic();
            dalPage.CreateStaticPageProject_New(_infoID2.ToString(), ref actionMsg);
            //Response.Redirect("/Publish/Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(_infoID2.ToString() + "|Project|" + title));
            Tz888.Common.MessageBox.Show(this.Page, "发布资源成功!");
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "联系信息添加失败，请检查！");
        }
    }


    /// <summary>
    /// //获取信息完整度

    /// </summary>
    /// <returns></returns>
    private int GetInformationIntegrity()
    {
        int iScore = 80;//把必填字段填完，可得80分 ////如果上传文件2，3，4，5都不为空，则各新加2分


        if (txtAddress.Value.Trim() != "")//单位地址
            iScore += 1;
        if (txtWebSite.Value.Trim() != "") //单位网址
            iScore += 1;

        if (iScore > 100)
            iScore = 100;

        return iScore;
    }


    #region 确认修改信息
    /// <summary>
    /// 确认修改信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnOk_Click(object sender, EventArgs e)
    {
        //判断电话与手机号
        if (txtTel.Value.Trim() == "" && txtMobile.Value.Trim() == "")
        {
            //Tz888.Common.MessageBox.Show(this.Page, "固定电话或手机至少填写一项，请检查！");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('固定电话或手机至少填写一项，请检查！');", false);
            return;
        }

        Tz888.Model.Info.ProjectSetModel model = new Tz888.Model.Info.ProjectSetModel();

        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表

        model.ProjectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProjectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.ProjectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.ProjectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.ProjectInfoModel.ProjectName = this.txtProjectName.Value.Trim();
        model.ProjectInfoModel.RecTime = DateTime.Now;
        model.ProjectInfoModel.CapitalCurrency = "CNY";
        model.ProjectInfoModel.ProjectCurrency = "CNY";
        model.ProjectInfoModel.CooperationDemandType = "10";
        //新属性



        //model.ProjectInfoModel.financingID = rbtnObj.SelectedValue;
        //model.ProjectInfoModel.SellStockShare = Convert.ToInt32(txtSellStockShare.Text);
        string returnmodelid = "4";//退出方式



        //for (int i = 0; i < chkReturn.Items.Count; i++)
        //{
        //    if (chkReturn.Items[i].Selected)
        //    {
        //        returnmodelid += chkReturn.Items[i].Value + ",";
        //    }
        //}
        model.ProjectInfoModel.ReturnModeID = returnmodelid;
        model.ProjectInfoModel.ProjectAbout = "";
        model.ProjectInfoModel.marketAbout = "";
        model.ProjectInfoModel.competitioAbout = "";
        model.ProjectInfoModel.BussinessModeAbout = "";
        model.ProjectInfoModel.ManageTeamAbout = txtManageTeamAbout.Value.Trim();

        //借款单位年营业收入

        //model.ProjectInfoModel.nDwlyysy = decimal.Parse(tbDwlyysy.Value);
        model.ProjectInfoModel.nDwlyysy = 1;
        ////借款单位年净利润
        //model.ProjectInfoModel.nDwljly = decimal.Parse(tbDwljly.Value);
        model.ProjectInfoModel.nDwljly = 1;
        ////借款单位总资产
        model.ProjectInfoModel.nDwzzc = 1;
        //model.ProjectInfoModel.CompanyTotalCapital = decimal.Parse(tbDwzzc.Value);
        ////借款单位总负债

        //model.ProjectInfoModel.CompanyTotalDebet = decimal.Parse(tbDwzfz.Value);
        model.ProjectInfoModel.nDwzfz = 1;

        if (!string.IsNullOrEmpty(this.txtCapitalTotal.Text.Trim()))
            model.ProjectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Text.Trim());
        model.ProjectInfoModel.CapitalID = this.rbtnCapital.SelectedValue;

        model.ProjectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtXmqxms.Value.Trim());
        model.ProjectInfoModel.IndustryBID = this.SelectIndustryControl1.IndustryString;

        model.ProjectInfoModel.financingID = "";

        model.ProjectInfoModel.ProjectNameBrief = "";// ViewState["ProjectNameBrief"].ToString();

        model.MainInfoModel.InfoID = Convert.ToInt64(this.ViewState["InfoID"]);
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.publishT = Convert.ToDateTime(this.ViewState["PublishT"]);
        model.MainInfoModel.LoginName = Page.User.Identity.Name;
        //model.MainInfoModel.KeyWord = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(keyword);
        model.MainInfoModel.Descript = "";
        model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.FrontDisplayTime = System.DateTime.Now;
        model.MainInfoModel.ValidateStartTime = System.DateTime.Now;

        //model.MainInfoModel.ValidateTerm = Convert.ToInt32(this.rbtnValiDate.SelectedValue.Trim());
        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = ViewState["HtmlFile"].ToString();

        model.ShortInfoModel.ShortInfoControlID = "";// Convert.ToString(ViewState["ShortInfoControlID"]);
        model.ShortInfoModel.ShortTitle = "";//ViewState["ShortTitle"].ToString();
        model.ShortInfoModel.ShortContent = "";// ViewState["ShortContent"].ToString();
        model.ShortInfoModel.Remark = "";



        //联系信息
        model.InfoContactModel.OrganizationName = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtCompanyName.Value.Trim());
        model.InfoContactModel.Name = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtLinkMan.Value.Trim());
        model.InfoContactModel.Career = "";
        model.InfoContactModel.TelStateCode = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtTelStateCode.Value.Trim());
        model.InfoContactModel.TelNum = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtTel.Value.Trim());
        model.InfoContactModel.Mobile = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtMobile.Value.Trim());
        model.InfoContactModel.Email = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtEmail.Value.Trim());
        model.InfoContactModel.Address = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtAddress.Value.Trim());
        model.InfoContactModel.WebSite = txtWebSite.Value.Trim();

        //-----------------201006资源超市第二次改版，----------------------//
        //项目立项情况
        model.ProjectInfoModel.sXmlxqk = "";
        //企业发展阶段
        model.ProjectInfoModel.sQyfzjd = "";

        //要求资金到位情况
        model.ProjectInfoModel.iYqzjdwqk = Tz888.Common.Text.FormatData("1");


        //--------------------------------------------------------------
        //*市场占有率(份额)
        model.ProjectInfoModel.iSczylfy = Tz888.Common.Text.FormatData("1");
        //*行业市场增长率
        model.ProjectInfoModel.iHysczzl = Tz888.Common.Text.FormatData("1");
        //*资产负债率
        model.ProjectInfoModel.iZcfzl = Tz888.Common.Text.FormatData("1");
        //--------------------------------------------------------------
        //投资回报期
        model.ProjectInfoModel.iXmtzfbzq = Tz888.Common.Text.FormatData("1");


        //项目有效期限
        model.MainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
        model.ProjectInfoModel.ComBrief = txtProIntro.Value.Trim();

        //项目关键字 textbox

        model.ProjectInfoModel.sXmgjz = "融资";
        //产品概述
        model.ProjectInfoModel.ProjectAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //市场前景
        model.ProjectInfoModel.marketAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //竞争分析
        model.ProjectInfoModel.competitioAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //商业模式
        model.ProjectInfoModel.BussinessModeAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(" ");
        //管理团队
        model.ProjectInfoModel.ManageTeamAbout = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(txtManageTeamAbout.Value.Trim());

        //信息完整度


        model.ProjectInfoModel.InformationIntegrity = GetInformationIntegrity();
        //-----------------END--------------------------------------------

        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();

        //上传文件
        infoResourceModels = FilesUploadControl1.InfoList;

        if (bll.ProjectInfoGQ_Update(model, infoResourceModels))
        {
            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                if (string.IsNullOrEmpty(model.MainInfoModel.HtmlFile.Trim()))
                    model.MainInfoModel.HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", model.MainInfoModel.InfoCode, model.MainInfoModel.InfoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(model.MainInfoModel.InfoID, model.MainInfoModel.HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                staticobj.CreateStaticPageProject(model.MainInfoModel.InfoID.ToString(), ref actionMsg);
            }
            Response.Redirect("/Manage/ResourceManage_Pass.aspx");


        }
        else
            Tz888.Common.MessageBox.ShowAndHref("修改信息失败！", "/Manage/ResourceManage_Pass.aspx");
    }
    #endregion
}
