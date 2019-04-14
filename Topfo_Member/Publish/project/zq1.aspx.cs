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

public partial class Publish_project_zq1 : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        //if (isTof)
        //{
        //    Page.MasterPageFile = "/indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "/MasterPage.master";
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Page.User.Identity.Name))
        //{
        //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //}
        BtnOk.Attributes.Add("onclick", "return chkpost()");
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
        //20090811 判断权限
        Tz888.BLL.Login.LoginInfoBLL loginbll = new Tz888.BLL.Login.LoginInfoBLL();
        bool yanzheng = loginbll.yanzheng(Page.User.Identity.Name);
        if (!yanzheng)
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败,你没有发布信息的权限！\\n可能是你发布违规信息帐户被锁定了。\\n详情请联系客服。");
            return;
        }
        //-----end-


        ///--------------------------------------------------
        ///--验证提交的验证码并清空验证码
        ///--------------------------------------------------
        string vercode = Request.Form["vercode"];
        string strRndNum = "";
        //SESSION丢失
        if (Session["valationNo"] == null)
        {
            Response.Write("<script>alert('操作超时！请刷新页面！');</script>");
            return;
        }
        else
        {
            if (vercode.Trim() == "")
            {
                Response.Write("<script>alert('验证码不能为空，请重新提交！');</script>");
                return;
            }
            else
            {
                strRndNum = Session["valationNo"].ToString();
                if (vercode.Trim() != "" && vercode.Trim().ToLower() == strRndNum.ToLower())
                {
                    Session["valationNo"] = "";
                }
                else
                {
                    Response.Write("<script>alert('验证码错误，请重新提交！');</script>");
                    return;
                }
            }
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

        ds = obj.readIPAddress(Page.User.Identity.Name, IPAddress );

        if (ds.Tables["projectinfoIP"].Rows.Count != 0)
        {
            DateTime dtForDB = Convert.ToDateTime(ds.Tables["projectinfoIP"].Rows[0]["postdate"].ToString());
            DateTime dtForClient = Convert.ToDateTime(DateTime.Now);

            TimeSpan ts = dtForClient - dtForDB;

            if ((int)ts.TotalMinutes <= 3)
            {
                Response.Write("三分钟内不允许重复发布信息!");
                Response.End();
            }

            //if (ds.Tables["projectinfoIP"].Rows.Count >= 5)
            //{
            //    Response.Write("当天只能发布5条记录");
            //    Response.End();
            //}
        }

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
        
            projectInfoModel.financingID = rbtnObj.SelectedValue;
         
        projectInfoModel.warrant = txtWarrant.Value.Trim();//融资担保
        
            projectInfoModel.financingID=rbtnObj.SelectedValue;//融资对象
        
        //-----------------------------------主表信息-------------
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

        string theURL = Request .CurrentExecutionFilePath;

        long infoID = projectObj.PublishProjectZQ1(mainInfoModel, projectInfoModel,  sortInfoModel);

        obj.insertIPAddress(infoID, Page.User.Identity.Name, theURL, IPAddress, DateTime.Now); //将用户IP地址入库

        if (infoID > 0)
        {
            bool isTof = Page.User.IsInRole("GT1002");
            if (isTof)
            {
                string HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("Project", mainInfoModel.InfoCode, infoID);
                Tz888.BLL.Info.MainInfoBLL mainBll = new Tz888.BLL.Info.MainInfoBLL();
                mainBll.HasHtmlFile(infoID, HtmlFile);
                string actionMsg = "";
                Tz888.BLL.PageStatic.ProjectPageStatic staticobj = new Tz888.BLL.PageStatic.ProjectPageStatic();
                staticobj.CreateStaticPageProject(infoID.ToString(), ref actionMsg);
            }
            Response.Redirect("zq2.aspx?code=" + Tz888.Common.DEncrypt.DESEncrypt.Encrypt(infoID.ToString() + "|Project|" + this.txtProjectName.Value.Trim() + "|" + projectInfoModel.CooperationDemandType));
        }
        else
        {
            Tz888.Common.MessageBox.Show(this.Page, "发布失败！");
        }

    }
}
