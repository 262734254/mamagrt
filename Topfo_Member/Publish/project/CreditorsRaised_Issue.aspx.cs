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
using ipAddressForInfo;

public partial class Publish_project_CreditorsRaised_Issue : System.Web.UI.Page
{
    protected long _infoID;
    Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!Page.IsPostBack)
        {
            InitInfoContact();
            Xmyxqxx();// 项目有效期限
        }
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
    //初始化联络人信息
    private void InitInfoContact()
    {
        string loginName = Page.User.Identity.Name;
        DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + loginName + "'", "LoginName");
        Tz888.BLL.Register.common bll = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model = new Tz888.Model.Register.OrgContactModel();

        model = bll.getContactModel(loginName);
        if (model == null)
            return;
        txtCompanyName.Value = model.OrganizationName.Trim();
        txtLinkMan.Value = model.Name.Trim();
        txtMobile.Value = model.Mobile.Trim();
        //telArea1.Value = model.TelCountryCode.Trim(); //国际号
        //txtTelStateCode.Value = model.TelStateCode.Trim();  //区号 
        //txtTel.Value = model.TelNum.Trim(); //电话号

        txtWebSite.Value = model.Website.Trim();
        txtEmail.Value = model.Email.Trim();
        txtAddress.Value = model.address.Trim();
        // txtCareer.Value = model.Career.Trim();
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

        Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();
        Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();
        string name = Page.User.Identity.Name;
        model3 = obj3.GetModel(" LoginName='" + name + "'");
        this.ZoneSelectControl1.CountryID = model3.CountryCode.ToString().Trim();//国别
        ZoneSelectControl1.CityID = model3.CityID.ToString().Trim();//市
        ZoneSelectControl1.ProvinceID = model3.ProvinceID.ToString().Trim();//省
        ZoneSelectControl1.CountyID = model3.CountyID.ToString().Trim(); //县

    }



    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        //转到股权融资_发布
        Response.Redirect("EquityRaised_Issue.aspx", true);
    }
    protected void btnIssueOK_Click(object sender, EventArgs e)
    {

        //if (Session["valationNo"] == null || ImageCode.Text.ToUpper().Trim() != Session["valationNo"].ToString().ToUpper().Trim() || Session["valationNo"].ToString().Trim() == "")
        //{
        //    //Tz888.Common.MessageBox.Show(this.Page, "验证码错误！");
        //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "alert('验证码错误！');", false);

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", "ValidErr();", true);
        //    return;
        //}


        #region[暂不用]
        //string IPAddress = String.Empty;
        //IPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //if (null == IPAddress || IPAddress == String.Empty)
        //{
        //    IPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        //}
        //if (null == IPAddress || IPAddress == String.Empty)
        //{
        //    IPAddress = HttpContext.Current.Request.UserHostAddress;
        //}

        //ipAddressForInfo.ipAddressForInfo obj = new ipAddressForInfo.ipAddressForInfo();

        //DataSet ds = new DataSet();

        //ds = obj.readIPAddress(Page.User.Identity.Name, IPAddress);

        //if (ds.Tables["projectinfoIP"].Rows.Count != 0)
        //{
        //    DateTime dtForDB = Convert.ToDateTime(ds.Tables["projectinfoIP"].Rows[0]["postdate"].ToString());
        //    DateTime dtForClient = Convert.ToDateTime(DateTime.Now);

        //    TimeSpan ts = dtForClient - dtForDB;

        //    if ((int)ts.TotalMinutes <= 3)
        //    {
        //        Response.Write("三分钟内不允许重复发布信息!");
        //        Response.End();
        //    }

        //    //if (ds.Tables["projectinfoIP"].Rows.Count >= 5)
        //    //{
        //    //    Response.Write("当天只能发布5条记录");
        //    //    Response.End();
        //    //}
        //}
        #endregion

        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体

        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件

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


        //投资总额
        //if (!string.IsNullOrEmpty(txtCapitalTotal.Value.Trim()))
        //    projectInfoModel.CapitalTotal = 20;


        projectInfoModel.CapitalTotal =Convert.ToDecimal(txtCapitalTotal.Value.Trim());
        //借钱金额
        projectInfoModel.CapitalID = "0";
        //项目详细描述
        projectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.tbXmqxms.Value.Trim());
        //行业
        foreach (Tz888.Model.Common.IndustryModel model in industryModels)
        {
            projectInfoModel.IndustryBID += model.IndustryBID + ",";
        }
        projectInfoModel.CooperationDemandType = "9";//债券融资

        //融资对象
        projectInfoModel.financingID = "01,";
        //融资计划及还款能力
        projectInfoModel.warrant = "";

        //-----------------201006资源超市第二次改版，----------------------//
        //项目立项情况
        projectInfoModel.cZqXmlxqkb = "1,";
        //企业发展阶段
        projectInfoModel.cZqQyfzjd = "1";
        //要求资金到位情况
        projectInfoModel.iZqYqjjdwqk = Tz888.Common.Text.FormatData(rblYqzjdwqk.SelectedValue.Trim());
        //产品市场增长率
        projectInfoModel.iZqCpsczzl = 1;
        //产品市场容量
        projectInfoModel.iZqCpscYl = 1;
        //资产负债率
        projectInfoModel.iZqZcfzl = 1;
        //流动比率
        projectInfoModel.iZqYdbl = 1;
        //投资收益率
        projectInfoModel.iZqTzsl = 1;
        //销售利润率
        projectInfoModel.iZqXslyl = 1;
        //投资回报期
        projectInfoModel.iZqTzfbq = 1;
        //项目有效期限
        projectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
        projectInfoModel.ComBrief = "";
        //项目关键字 textbox
        string strXmgjz = "";
        projectInfoModel.cZqXmgjz = strXmgjz;


        //##项目详细资料
        //*借款单位年营业收入
        projectInfoModel.nDwlyysy = 1;
        //*借款单位年净利润
        projectInfoModel.nDwljly = 1;
        //*借款单位总资产
        projectInfoModel.nDwzzc = 1;
        //*借款单位总负债
        projectInfoModel.nDwzfz = 1;


        //产品概述
        projectInfoModel.cZqCpks = "";
        //市场前景
        projectInfoModel.marketAbout = "";
        //竞争分析
        projectInfoModel.cZqJzfx = "";
        //商业模式
        projectInfoModel.cZqSyms = "";
        //管理团队
        projectInfoModel.cZqGltd = "";

        //信息完整度
        projectInfoModel.InformationIntegrity = GetInformationIntegrity();
        //-----------------END--------------------------------------------




        //-----------------------------------主表信息-------------
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            mainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        string str = industryModels[0].IndustryBID;
        mainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        mainInfoModel.publishT = time_Now;
        mainInfoModel.Hit = 0;

        mainInfoModel.IsCore = true;
        //  mainInfoModel.LoginName = "topfo001";
        mainInfoModel.LoginName = Page.User.Identity.Name;
        mainInfoModel.InfoOriginRoleName = "0"; //用户角色
        mainInfoModel.GradeID = "0";
        mainInfoModel.FixPriceID = "1";
        mainInfoModel.FeeStatus = 0;
        mainInfoModel.ValidateTerm = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限

        mainInfoModel.Descript = "";
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

        string theURL = Request.CurrentExecutionFilePath;


        //上传文件
        // infoResourceModels = FilesUploadControl1.InfoList;


        //包括上传文件
        long infoID = projectObj.PublishProjectZQ1(mainInfoModel, projectInfoModel, sortInfoModel, infoResourceModels);
        _infoID = infoID;

        //暂不用
        //obj.insertIPAddress(infoID, Page.User.Identity.Name, theURL, IPAddress, DateTime.Now); //将用户IP地址入库

        if (infoID > 0)
        {
            //如果是会员，则生成静态页
            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                string HtmlFile = "Project/" + DateTime.Now.ToString("yyyyMM") + "/Project" + DateTime.Now.ToString("yyyyMMdd") + "_" + _infoID + ".shtml";
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(infoID, HtmlFile);
                string actionMsg = "";
                //Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                //staticobj.CreateStaticPageProject_V3(infoID.ToString(), ref actionMsg);
            }
            //Response.Redirect("zq2.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(infoID.ToString() + "|Project|" + this.txtProjectName.Value.Trim() + "|" + projectInfoModel.CooperationDemandType));

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
        model.Career = "";// txtCareer.Value.Trim();
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
        //    //用于生成静态页，暂不用
        //    Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();
        //    Tz888.BLL.Info.MainInfoBLL mainDAL = new Tz888.BLL.Info.MainInfoBLL();
        //    mainInfoModel = mainDAL.GetModel(_infoID);
            string HtmlFile = "Project/" + DateTime.Now.ToString("yyyyMM") + "/Project" + DateTime.Now.ToString("yyyyMMdd") + "_" + _infoID + ".shtml";
           Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
         mainBll.HasHtmlFile(_infoID, HtmlFile);
        //    string actionMsg = "";
        //    //Tz888.BLL.PageStatic.ProjectPageStatic dalPage = new Tz888.BLL.PageStatic.ProjectPageStatic();
        //    //dalPage.CreateStaticPageProject_New(_infoID.ToString(), ref actionMsg);

            Response.Redirect("/Publish/Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(_infoID.ToString() + "|Project|" + txtProjectName.Value.Trim()));
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

        //if (!Tz888.Common.Text.IsNullRadioButtonList(rblXmtzfbzq)) //项目投资回报期
        //    iScore += 2;
        //if (tbLdbl.Value.Trim() != "") //流动比率
        //    iScore += 2;
        //if (tbXmgjz1.Value.Trim() != "" || tbXmgjz2.Value.Trim() != "" || tbXmgjz3.Value.Trim() != "") //关键字
        //    iScore += 1;
        //if (tbJkdwlyysy.Value.Trim() != "") //借款单位年营业收入
        //    iScore += 3;
        //if (tbJkdwljly.Value.Trim() != "") //借款单位年净利润
        //    iScore += 3;
        //if (tbJkdwzzc.Value.Trim() != "") //借款单位总资产
        //    iScore += 3;
        //if (tbJkdwzfz.Value.Trim() != "") //借款单位总负债
        //    iScore += 3;    
        //if (txtCareer.Value.Trim() != "") //职位
        //    iScore += 1;
        //if (txtAddress.Value.Trim() != "")//单位地址
        //    iScore += 1;
        //if (txtWebSite.Value.Trim() != "") //单位网址
        //    iScore += 1;

        //if (iScore > 100)
        iScore = 100;

        return iScore;
    }
}
