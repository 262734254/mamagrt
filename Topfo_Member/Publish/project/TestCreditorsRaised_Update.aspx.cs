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
public partial class Publish_project_TestCreditorsRaised_Update : System.Web.UI.Page
{
    protected long _infoID2 = 2397079;
    #region 加载母板页面 在本地调试时不启用


  
    protected long infoID;
    protected long _infoID;
    string strLoginName = ""; //#
    /// <summary>
    /// 加载母板页面 在本地调试时不启用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    bool isTof = Page.User.IsInRole("GT1002");

    //    if (isTof)
    //    {
    //        Page.MasterPageFile = "/indexTof.master";
    //    }
    //    else
    //    {
    //        Page.MasterPageFile = "/MasterPage.master";
    //    }
    //}
    #endregion

    #region 页面加载
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (string.IsNullOrEmpty(Page.User.Identity.Name))
        //{
        //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //}
        strLoginName = "topfo001";// Page.User.Identity.Name.Trim();
        _infoID2 = 2397079; //本地调试时默认值        
        _infoID2 = 2397079;//Convert.ToInt64(Request.QueryString["InfoID"]);
   
        if (!Page.IsPostBack)
        {
      
            //BindSetCapital();
            //bindReturn();
   
            Xmyxqxx();
   
       

     
            Yqzjdwqk();
            GetInfoModel();
        }

       
    }
    #endregion



  
   
    //要求资金到位情况
    public void Yqzjdwqk()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='Yqzjdwqk' ");
        rblYqzjdwqk.DataTextField = "cdictname";
        rblYqzjdwqk.DataValueField = "idictvalue";
        rblYqzjdwqk.DataSource = dt;
        rblYqzjdwqk.DataBind();
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
        //string loginName = Page.User.Identity.Name;\
        string loginName = strLoginName; //#
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


        txtWebSite.Value = model.Website.Trim();
        txtEmail.Value = model.Email.Trim();
        txtAddress.Value = model.address.Trim();
        txtCareer.Value = model.Career.Trim();

    }

    #region 控件赋值


    /// <summary>
    /// 控件赋值


    /// </summary>
    public void GetInfoModel()
    {

        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.ProjectSetModel model = bll.GetIntegrityModel(_infoID2);


        if (model == null)
            return;
        if (model.ProjectInfoModel == null)
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
           this.txtCapitalTotal.Value = model.ProjectInfoModel.CapitalTotal.ToString();
        //要求资金到位情况
        if (model.ProjectInfoModel.iZqYqjjdwqk != null)
        {
            for (int i = 0; i < rblYqzjdwqk.Items.Count; i++)
            {
                if (model.ProjectInfoModel.iZqYqjjdwqk.ToString() == rblYqzjdwqk.Items[i].Value)
                {
                    rblYqzjdwqk.Items[i].Selected = true;
                }
            }
        }
        //项目有效期限
        if (model.ProjectInfoModel.iZqXmyxqs != null)
        {
            for (int i = 0; i < rblXmyxqxx.Items.Count; i++)
            {
                if (model.ProjectInfoModel.iZqXmyxqs.ToString() == rblXmyxqxx.Items[i].Value)
                {
                    rblXmyxqxx.Items[i].Selected = true;
                }
            }
        }
        //this.txtProIntro.Value = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(Tz888.Common.Utility.PageValidate.HtmlToTxt(model.ProjectInfoModel.ComAbout));

        //if (model.ProjectInfoModel.financingID.ToString() != "")
        //    rbtnObj.SelectedValue = model.ProjectInfoModel.financingID.ToString();
     
 

        //融资计划及还款能力


        //投资回报期


     

      

        //model.ProjectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
    
        //项目详细描述
        tbXmqxms.Value = model.ProjectInfoModel.ComAbout;
 

        


        //if (model.ProjectInfoModel.CapitalID != "")
        //    rbtnCapital.SelectedValue = model.ProjectInfoModel.CapitalID;
        //新属性


        //-----------------201006资源超市第二次改版，----------------------//
    

        
        //联系信息
        if (model.InfoContactModel != null)
        {
            this.txtCompanyName.Value = model.InfoContactModel.OrganizationName;
            this.txtLinkMan.Value = model.InfoContactModel.Name;
            this.txtCareer.Value = model.InfoContactModel.Career;
            this.txtTelStateCode.Value = model.InfoContactModel.TelStateCode.Trim();
            this.txtTel.Value = model.InfoContactModel.TelNum;
            this.txtMobile.Value = model.InfoContactModel.Mobile;
            this.txtEmail.Value = model.InfoContactModel.Email;
            this.txtAddress.Value = model.InfoContactModel.Address;
            this.txtWebSite.Value = model.InfoContactModel.WebSite;
        }
        //this.rbtnValiDate.SelectedValue = model.ProjectInfoModel.iZqXmyxqs.ToString();

        ViewState["PublishT"] = model.MainInfoModel.publishT;
        ViewState["InfoID"] = model.MainInfoModel.InfoID;
        ViewState["HtmlFile"] = model.MainInfoModel.HtmlFile;
        ViewState["ProjectNameBrief"] = model.ProjectInfoModel.ProjectNameBrief;
        ViewState["ShortTitle"] = model.ShortInfoModel.ShortTitle;
        ViewState["ShortContent"] = model.ShortInfoModel.ShortContent;
        ViewState["ShortInfoControlID"] = model.ShortInfoModel.ShortInfoControlID;
    }
    #endregion

    #region 确认修改信息
    /// <summary>
    /// 确认修改信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    #endregion
    //第二步，确认联络方式
    private int ConfirmContact()
    {
        Tz888.BLL.Info.InfoContact dal = new Tz888.BLL.Info.InfoContact();
        Tz888.Model.Info.InfoContactModel model = new Tz888.Model.Info.InfoContactModel();
        int returnValue = 0;
        model.InfoID = _infoID2;
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
        bool b = dal.Update(model);     //修改联络方式信息
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
            //Response.Redirect("/Publish/Publishproject3.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(_infoID.ToString() + "|Project|" + title));
            //Tz888.Common.MessageBox.Show(this.Page, "发布资源成功!");
            returnValue = 1;
        }
        else
        {
            //Tz888.Common.MessageBox.Show(this.Page, "联系信息添加失败，请检查！");
        }
        return returnValue;
    }


    /// <summary>
    ///   //获取信息完整度


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
    protected void btnIssueOK_Click(object sender, EventArgs e)
    {
        ////20090811 判断权限
        //Tz888.BLL.Login.LoginInfoBLL loginbll = new Tz888.BLL.Login.LoginInfoBLL();
        //bool yanzheng = loginbll.yanzheng(Page.User.Identity.Name);
        //if (!yanzheng)
        //{
        //    Tz888.Common.MessageBox.Show(this.Page, "发布失败,你没有发布信息的权限！\\n可能是你发布违规信息帐户被锁定了。\\n详情请联系客服。");
        //    return;
        //}
        ////-----end-

        Tz888.Model.Info.ProjectSetModel model = new Tz888.Model.Info.ProjectSetModel();
        //判断电话与手机号
        if (txtTel.Value.Trim() == "" && txtMobile.Value.Trim() == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "固定电话或手机至少填写一项，请检查！");
            return;
        }

        string IPAddress = String.Empty;
        IPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (null == IPAddress || IPAddress == String.Empty)
        {
            IPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (null == IPAddress || IPAddress == String.Empty)
        {
            IPAddress = HttpContext.Current.Request.UserHostAddress;
        }

        ipAddressForInfo.ipAddressForInfo obj = new ipAddressForInfo.ipAddressForInfo();

        DataSet ds = new DataSet();

        //## ds = obj.readIPAddress(Page.User.Identity.Name, IPAddress);
        //ds = obj.readIPAddress(strLoginName, IPAddress);

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

        Tz888.BLL.Info.ProjectInfoBLL projectObj = new Tz888.BLL.Info.ProjectInfoBLL();
        Tz888.Model.Info.MainInfoModel mainInfoModel = new Tz888.Model.Info.MainInfoModel();  //创建主体信息实体
        Tz888.Model.Info.ProjectInfoModel projectInfoModel = new Tz888.Model.Info.ProjectInfoModel(); //创建融资信息实体
        Tz888.Model.Info.ShortInfoModel sortInfoModel = new Tz888.Model.Info.ShortInfoModel(); //创建短信息实体
        List<Tz888.Model.Info.InfoResourceModel> infoResourceModels = new List<Tz888.Model.Info.InfoResourceModel>(); //上传文件


        List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        DateTime time_Now = DateTime.Now;

        industryModels = this.SelectIndustryControl1.IndustryModels;

        model.ProjectInfoModel.CountryCode = this.ZoneSelectControl1.CountryID;
        model.ProjectInfoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID;
        model.ProjectInfoModel.CityID = this.ZoneSelectControl1.CityID;
        model.ProjectInfoModel.CountyID = this.ZoneSelectControl1.CountyID;
        model.ProjectInfoModel.ProjectName = this.txtProjectName.Value.Trim();
        model.ProjectInfoModel.RecTime = DateTime.Now;
        model.ProjectInfoModel.CapitalCurrency = "CNY";
        model.ProjectInfoModel.ProjectCurrency = "CNY";
     
        //投资总额

        model.ProjectInfoModel.CapitalTotal = Convert.ToDecimal(this.txtCapitalTotal.Value.Trim());

        //借钱金额
        model.ProjectInfoModel.CapitalID ="1";
        //项目详细描述
        model.ProjectInfoModel.ComAbout = Tz888.Common.Utility.PageValidate.TxtToHtml(this.tbXmqxms.Value.Trim());
        //行业
        foreach (Tz888.Model.Common.IndustryModel models in industryModels)
        {
            model.ProjectInfoModel.IndustryBID += models.IndustryBID + ",";
        }
        model.ProjectInfoModel.CooperationDemandType = "9";//债券融资

        //融资对象
        model.ProjectInfoModel.financingID = "";
        //融资计划及还款能力


        model.ProjectInfoModel.warrant ="1";



        //-----------------201006资源超市第二次改版，----------------------//
        //项目立项情况
        model.ProjectInfoModel.cZqXmlxqkb = "";
        //企业发展阶段
        model.ProjectInfoModel.cZqQyfzjd = "1";

        //要求资金到位情况
        model.ProjectInfoModel.iZqYqjjdwqk = Tz888.Common.Text.FormatData(rblYqzjdwqk.SelectedValue.Trim());
        //产品市场增长率        
        model.ProjectInfoModel.iZqCpsczzl = Tz888.Common.Text.FormatData("");

        //产品市场容量
        model.ProjectInfoModel.iZqCpscYl = Tz888.Common.Text.FormatData("");
        //资产负债率
        model.ProjectInfoModel.iZqZcfzl = Tz888.Common.Text.FormatData("");
        //流动比率
        model.ProjectInfoModel.iZqYdbl = Tz888.Common.Text.FormatData("");
        //投资收益率


        model.ProjectInfoModel.iZqTzsl = Tz888.Common.Text.FormatData("");
        //销售利润率
        model.ProjectInfoModel.iZqXslyl = Tz888.Common.Text.FormatData("");
        //投资回报期


        model.ProjectInfoModel.iZqTzfbq = Tz888.Common.Text.FormatData("");
        //项目有效期限
        //model.ProjectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        model.ProjectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim());
        //项目摘要
        model.ProjectInfoModel.ComBrief = "";

        //项目关键字 textbox

        model.ProjectInfoModel.cZqXmgjz = "债券";

        model.ProjectInfoModel.nDwlyysy = Convert.ToDecimal(1);//单位年营业收入
        model.ProjectInfoModel.nDwljly = Convert.ToDecimal(1); //单位年净利润
        model.ProjectInfoModel.nDwzzc = Convert.ToDecimal(1);//单位总资产
        model.ProjectInfoModel.nDwzfz = Convert.ToDecimal(1); //单位总负债
        //产品概述
        model.ProjectInfoModel.cZqCpks = "";
        //市场前景
        model.ProjectInfoModel.marketAbout = "";
        //竞争分析
        model.ProjectInfoModel.cZqJzfx = "";
        //商业模式
        model.ProjectInfoModel.cZqSyms = "";
        //管理团队
        model.ProjectInfoModel.cZqGltd = "";

        //信息完整度


        model.ProjectInfoModel.InformationIntegrity = GetInformationIntegrity();
        //-----------------END--------------------------------------------




        //-----------------------------------主表信息-------------
        if (!string.IsNullOrEmpty(this.txtProjectName.Value))
            model.MainInfoModel.Title = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value);

        string str = industryModels[0].IndustryBID;
        model.MainInfoModel.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Project", industryModels[0].IndustryBID, this.ZoneSelectControl1.CountryID, time_Now);
        model.MainInfoModel.publishT = time_Now;
        model.MainInfoModel.Hit = 0;
        model.MainInfoModel.InfoID = _infoID2;
        model.MainInfoModel.IsCore = true;
        //##mainInfoModel.LoginName = Page.User.Identity.Name;
        model.MainInfoModel.LoginName = strLoginName;
        model.MainInfoModel.InfoOriginRoleName = "0"; //用户角色
        model.MainInfoModel.GradeID = "0";
        model.MainInfoModel.FixPriceID = "1";
        model.MainInfoModel.FeeStatus = 0;
        //model.ProjectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限

        model.MainInfoModel.Descript = "";
        if (!string.IsNullOrEmpty(this.txtProjectName.Value.Trim()))
            model.MainInfoModel.DisplayTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.MainInfoModel.FrontDisplayTime = time_Now;
        model.MainInfoModel.ValidateStartTime = time_Now;
        model.ProjectInfoModel.iZqXmyxqs = Tz888.Common.Text.FormatData(rblXmyxqxx.SelectedValue.Trim()); //*项目有效期限

        model.MainInfoModel.TemplateID = "001";
        model.MainInfoModel.HtmlFile = "";

        //------------------------
        model.ShortInfoModel.ShortInfoControlID = "ProjectIndex1";
        model.ShortInfoModel.ShortTitle = Tz888.Common.Utility.PageValidate.FiltrateHTMLTag(this.txtProjectName.Value.Trim());
        model.ShortInfoModel.ShortContent = "";
        model.ShortInfoModel.Remark = "";

        string theURL = Request.CurrentExecutionFilePath;

        ////联系信息
        model.InfoContactModel.OrganizationName = txtCompanyName.Value.Trim();
        model.InfoContactModel.Name = txtLinkMan.Value.Trim();
        model.InfoContactModel.Career = txtCareer.Value.Trim();
        model.InfoContactModel.TelStateCode = txtTelStateCode.Value.Trim();
        model.InfoContactModel.TelNum = txtTel.Value.Trim();
        model.InfoContactModel.Mobile = txtMobile.Value.Trim();
        model.InfoContactModel.Email = txtEmail.Value.Trim();
        model.InfoContactModel.Address = txtAddress.Value.Trim();
        model.InfoContactModel.WebSite = txtWebSite.Value.Trim();



        //上传文件
        //infoResourceModels = FilesUploadControl1.InfoList;

        Tz888.BLL.Info.ProjectInfoBLL bll = new Tz888.BLL.Info.ProjectInfoBLL();

        int returnValue = ConfirmContact();      //确认联络方式
        if (returnValue == 1)
        {
            if (bll.ProjectInfoZQ_Update(model, infoResourceModels))
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
                Tz888.Common.MessageBox.ShowAndHref("修改信息成功！", Request.Url.ToString());

            }
            else
                Tz888.Common.MessageBox.ShowAndHref("修改信息失败！", Request.Url.ToString());
        }
    }
    

    
}
