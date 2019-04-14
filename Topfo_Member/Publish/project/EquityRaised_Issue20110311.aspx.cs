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
using Tz888.Common;
public partial class Publish_project_EquityRaised_Issue : System.Web.UI.Page
{
    protected long _infoID;
    protected string cooperationDemandType;

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
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }

        if (!Page.IsPostBack)
        {
            this.ViewState["LoginMemberName"] = Page.User.Identity.Name;
            //会员信息表
            Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();
            Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();
            model3 = obj3.GetModel("LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'");
            this.ZoneSelectControl1.CountryID = model3.CountryCode.ToString().Trim();//国别
            ZoneSelectControl1.CityID = model3.CityID.ToString().Trim();//市
            ZoneSelectControl1.ProvinceID = model3.ProvinceID.ToString().Trim();//省
            ZoneSelectControl1.CountyID = model3.CountyID.ToString().Trim(); //县
            //显示联络人信息
            InitInfoContact();

            BindSetCapital();// 绑定融资金额

            Xmyxqxx();//项目有效期限

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
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();
        Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
        DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'", "LoginName");
        model = bll.getContactModel(loginName);
        if (model == null)
            return;

        txtCompanyName.Value = model.OrganizationName.Trim();
        txtLinkMan.Value = model.Name.Trim();
        txtMobile.Value = model.Mobile.Trim();
        //telArea1.Value = model.TelCountryCode.Trim(); //国际号
        //txtTelStateCode.Value = model.TelStateCode.Trim();  //区号 
        //txtTel.Value = model.TelNum.Trim(); //电话号
        // txtWebSite.Value = model.Website.Trim();
        txtEmail.Value = model.Email.Trim();
        txtAddress.Value = model.address.Trim();
        txtCareer.Value = model.Career.Trim();

        if (dt1.Rows.Count > 0)
        {


            if (dt1.Rows[0]["Tel"] != DBNull.Value && dt1.Rows[0]["Tel"].ToString() != "")
            {
                try
                {
                    string[] tel = dt1.Rows[0]["Tel"].ToString().Split('-');
                    telArea1.Value = tel[0].ToString();
                    txtTelStateCode.Value = tel[1].ToString();
                    txtTel.Value = tel[2].ToString();

                }
                catch
                {
                    telArea1.Value = "+86";
                    txtTelStateCode.Value = "";
                    //因以前数据格式不同原因，没有用‘-’分格
                    txtTel.Value = dt1.Rows[0]["Tel"].ToString();
                }
            }
        }

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

        //if (Session["valationNo"] == null || ImageCode.Text.ToUpper().Trim() != Session["valationNo"].ToString().ToUpper().Trim() || Session["valationNo"].ToString().Trim() == "")
        //{
        //    //Tz888.Common.MessageBox.Show(this.Page, "验证码错误！");
        //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('验证码错误！');", false);
        //    //Response.Write("<script>javascript:ValidErr();</script>");
        //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('请检查！');", false);

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "ValidErr();", true);

        //    return;
        //}

        Response.Write("");
        //第一步，写入数据库中
        InsertData();
    }

    //第一步，写入数据库中
    private void InsertData()
    {
        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件

        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;

        projectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID; //*国家代码
        projectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID; //*省
        projectInfoModel.CityID = this.ZoneSelectControl1.CityID; //*州或城市
        projectInfoModel.CountyID = this.ZoneSelectControl1.CountyID; //*县

        //*项目名称
        projectInfoModel.ProjectName = this.txtProjectName.Value.Trim();

        projectInfoModel.RecTime = DateTime.Now;
        projectInfoModel.CapitalCurrency = "CNY"; //*资本金币种
        projectInfoModel.ProjectCurrency = "CNY"; //*资本金币种

        //*项目投资总额
        if (!string.IsNullOrEmpty(txtCapitalTotal.Value.Trim()))
            projectInfoModel.CapitalTotal = Convert.ToDecimal(txtCapitalTotal.Value.Trim());

        //*融资金额
        projectInfoModel.CapitalID = this.rbtnCapital.SelectedValue.Trim();

        //项目说明        
        projectInfoModel.ComBrief = Tz888.Common.Utility.PageValidate.TxtToHtml(txtProIntro.Value.Trim());

        //行业
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            projectInfoModel.IndustryBID += model.IndustryBID + ",";
        }

        //股权融资
        projectInfoModel.CooperationDemandType = "10";

        //*融资对像

        projectInfoModel.financingID = "";

        //*融资额占股份比重
        projectInfoModel.SellStockShare = 1;


        //##20100603新加入字段
        //*项目立项情况 checkboxlist
        projectInfoModel.sXmlxqk = "";
        //*项目关键字 textbox
        //string strXmgjz = "";
        //if (Xmgjz1.Value.Trim() != "")
        //{
        //    strXmgjz = Xmgjz1.Value.Trim() + ",";
        //}
        //if (Xmgjz2.Value.Trim() != "")
        //{
        //    strXmgjz += Xmgjz2.Value.Trim() + ",";
        //}
        //if (Xmgjz3.Value.Trim() != "")
        //{
        //    strXmgjz += Xmgjz3.Value.Trim();
        //}
        projectInfoModel.sXmgjz = "融资";
        //*退出方式
        projectInfoModel.ReturnModeID = "";
        //*企业发展阶段
        projectInfoModel.sQyfzjd = "";
        //*要求资金到位情况
        projectInfoModel.iYqzjdwqk = 1;
        //*市场占有率(份额)
        projectInfoModel.iSczylfy = 1;
        //*行业市场增长率
        projectInfoModel.iHysczzl = 1;
        //*资产负债率
        projectInfoModel.iZcfzl = 1;
        //*项目投资回报周期
        projectInfoModel.iXmtzfbzq = 1;
        //*项目详细描术
        projectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtXmqxms.Value.Trim());


        //##项目详细资料
        //*单位年营业收入
        projectInfoModel.nDwlyysy = 1;
        //*单位年净利润
        projectInfoModel.nDwljly = 1;
        //*单位总资产
        projectInfoModel.nDwzzc = 1;
        //*单位总负债
        projectInfoModel.nDwzfz = 1;

        //产品概述
        projectInfoModel.ProjectAbout = "";
        //市场前景
        projectInfoModel.marketAbout = "";
        //竞争分析
        projectInfoModel.competitioAbout = "";
        //商业模式
        projectInfoModel.BussinessModeAbout = "";
        //管理团队
        projectInfoModel.ManageTeamAbout = txtManageTeamAbout.Value.Trim();
        //信息完整度得分
        projectInfoModel.InformationIntegrity = GetInformationIntegrity();

        //-----------------------------------主表信息-------------
        //项目标题
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        mainInfoModel.LoginName = Page.User.Identity.Name;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;
        mainInfoModel.Descript = "";

        //项目标题
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            mainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());

        mainInfoModel.FrontDisplayTime = time_Now;
        mainInfoModel.ValidateStartTime = time_Now;
        mainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限
        mainInfoModel.TemplateID = "001";
        mainInfoModel.HtmlFile = "";

        //------------------------
        sortInfoModel.ShortInfoControlID = "ProjectIndex1";
        sortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        sortInfoModel.ShortContent = "";
        sortInfoModel.Remark = "";

        //上传文件
        infoResourceModels = FilesUploadControl1.InfoList;

        long infoID = projectObj.PublishProjectGQ1(mainInfoModel, projectInfoModel, sortInfoModel, infoResourceModels);
        _infoID = infoID;

        if (infoID > 0)
        {
            //bool isTof = Page.User.IsInRole("GT1002");
            //if (isTof)
            //{
            string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", mainInfoModel.InfoCode, infoID);
            Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
            mainBll.HasHtmlFile(infoID, HtmlFile);
            //}
            //Response.Redirect("gq2.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(infoID.ToString() + "|Project|" + this.txtProjectName.Value.Trim() + "|" + projectInfoModel.CooperationDemandType));

            //第二步，确认联络方式
            ConfirmContact();
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }
    }

    //第二步，确认联络方式
    private void ConfirmContact()
    {
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();

        model.InfoID = _infoID;
        model.OrganizationName = txtCompanyName.Value.Trim();
        model.Name = txtLinkMan.Value.Trim();
        model.Career = txtCareer.Value.Trim();
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
        bool b = dal.Add(model);
        if (b)
        {
            //用于生成静态页，暂不用
            Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();
            Tz888.BLL.Info.MainInfoBLL mainDAL = new Tz888.BLL.Info.MainInfoBLL();
            mainInfoModel = mainDAL.GetModel(_infoID);
            string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", mainInfoModel.InfoCode, _infoID);
            Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
            mainBll.HasHtmlFile(_infoID, HtmlFile);
            string actionMsg = "";
            Tz888.BLL.PageStatic.ProjectPageStatic dalPage = new Tz888.BLL.PageStatic.ProjectPageStatic();
            dalPage.CreateStaticPageProject_V3(_infoID.ToString(), ref actionMsg);

            Response.Redirect("/Publish/Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(_infoID.ToString() + "|Project|" + txtProjectName.Value.Trim()));
            //Tz888.Common.MessageBox.Show(this.Page,"发布资源成功!");
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


        iScore += 3;
        if (txtCareer.Value.Trim() != "") //职位
            iScore += 1;
        if (txtAddress.Value.Trim() != "")//单位地址
            iScore += 1;
        if (txtWebSite.Value.Trim() != "") //单位网址
            iScore += 1;

        if (iScore > 100)
            iScore = 100;

        return iScore;
    }

}
