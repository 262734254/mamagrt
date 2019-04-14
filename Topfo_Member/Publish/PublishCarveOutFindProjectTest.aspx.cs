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
using System.Data.SqlClient;

using System.Collections.Generic;

public partial class Publish_PublishCarveOutFindProjectTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Page.User.Identity.Name))
        //{
        //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        //}

      
        if (!Page.IsPostBack)
        {
            BindXinYe();
            this.rdbtXM.SelectedIndex = 0;
            SetValid();//时效           
            this.BindSetCapital();//绑定金额
            this.BindCurrency();//绑定货币种类
            //SetOpportun();//类别
            InitInfoContact();
            ViewState["strSavePath"] = "";

        }
    }
    /// <summary>
    /// 绑定行页信息
    /// </summary>
    private void BindXinYe()
    {
        Tz888.SQLServerDAL.Info.MainInfoDAL objtp = new Tz888.SQLServerDAL.Info.MainInfoDAL();
        DataSet dv = objtp.IndustryList();

        this.ddlIndustry.DataSource = dv;
        this.ddlIndustry.DataTextField = "IndustryCarveOutName";
        this.ddlIndustry.DataValueField = "IndustryCarveOutID";
        this.ddlIndustry.DataBind();
    }

    /// <summary>
    /// 绑定货币种类
    /// </summary>
    private void BindCurrency()
    {
        Tz888.BLL.Common.SetCurrencyBLL bll = new Tz888.BLL.Common.SetCurrencyBLL();
        DataView dv = bll.GetList();
        //this.ddlCapitalCurrency.DataSource = dv;
        //this.ddlCapitalCurrency.DataTextField = "CurrencyName";
        //this.ddlCapitalCurrency.DataValueField = "CurrencyID";
        //this.ddlCapitalCurrency.DataBind();

        this.ddlMerchantCurrency.DataSource = dv;
        this.ddlMerchantCurrency.DataTextField = "CurrencyName";
        this.ddlMerchantCurrency.DataValueField = "CurrencyID";
        this.ddlMerchantCurrency.DataBind();
    }

    /// <summary>
    /// 绑定金额
    /// </summary>
    private void BindSetCapital()
    {
        Tz888.BLL.Common.SetCapitalBLL bll = new Tz888.BLL.Common.SetCapitalBLL();
        this.ddlMerchantTotal.DataSource = bll.GetList();
        this.ddlMerchantTotal.DataTextField = "CapitalName";
        this.ddlMerchantTotal.DataValueField = "CapitalID";
        this.ddlMerchantTotal.DataBind();
    }

    /// <summary>
    /// 类别
    /// </summary>
    //private void SetOpportun()
    //{
    //    Tz888.BLL.Info.OpportunityInfoBLL opp = new Tz888.BLL.Info.OpportunityInfoBLL();
    //    this.ddlOpportunityType.DataSource = opp.GetOpportun();
    //    this.ddlOpportunityType.DataValueField = "OpportunityTypeID";
    //    this.ddlOpportunityType.DataTextField = "OpportunityTypeName";
    //    this.ddlOpportunityType.DataBind();
    //}
    /// <summary>
    /// 有效期
    /// </summary>
    private void SetValid()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='xmyxqxx' ");
        this.rdbtXM.DataTextField = "cdictname";
        this.rdbtXM.DataValueField = "idictvalue";
        this.rdbtXM.DataSource = dt;
        this.rdbtXM.DataBind();
    }

    /// <summary>
    /// 加载用户联系信息
    /// </summary>
    public void InitInfoContact()
    {

        Tz888.Model.Register.OrgContactModel org = new Tz888.Model.Register.OrgContactModel();
        Tz888.BLL.Info.MarchantInfoBLL mar = new Tz888.BLL.Info.MarchantInfoBLL();
        //org = mar.SelLoginName(Page.User.Identity.Name);
        org = mar.SelLoginName("262734254");
        this.txtComName.Text = org.OrganizationName;
        this.txtLinkMan.Text = org.Name;
        this.txtTelCountry.Text = org.TelCountryCode;
        this.txtTelZoneCode.Text = org.TelStateCode;
        this.txtTelNumber.Text = org.TelNum;
        this.txtMobile.Text = org.Mobile;
        this.txtAddress.Text = org.address;
        this.txtEmail.Text = org.Email;
        this.txtPostCode.Text = org.PostCode;
        this.txtWebSite.Text = org.Website;
    }
    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表
        string Indus= this.ddlIndustry.SelectedValue.ToString().Trim();
        int Hit = 0;
        Random rnd = new Random();
        Hit = rnd.Next(25) + 5;
        Tz888.Model.Info.MainInfoModel main = new Tz888.Model.Info.MainInfoModel();//主表
        Tz888.Model.Info.CarveOutInfoTabModel CarveModel = new Tz888.Model.Info.CarveOutInfoTabModel();//创业信息表
        Tz888.Model.Info.ShortInfoModel shortInfoRule = new Tz888.Model.Info.ShortInfoModel();//短消息表
        #region 主表

        main.Title = txtTitle.Text.Trim();
        main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Carve", Indus, this.ZoneSelectControl2.CountryID, DateTime.Now);
        //main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Carve", industryModels[0].IndustryBID, this.ZoneSelectControl2.CountryID, DateTime.Now);
        main.publishT = Convert.ToDateTime(DateTime.Now);
        main.Hit = Hit;
         main.LoginName = "262734254";
        //main.LoginName = Page.User.Identity.Name;
        main.InfoOriginRoleName = "0";

        main.KeyWord = txtKeyWord.Text.Trim();
        main.Descript = txtDescript.Text.Trim();
        main.DisplayTitle = txtDisplayTitle.Text.Trim();
        main.FrontDisplayTime = Convert.ToDateTime(DateTime.Now);
        main.ValidateStartTime = Convert.ToDateTime(DateTime.Now);
        main.ValidateTerm = Convert.ToInt32(this.rdbtXM.SelectedValue.Trim()); ;
        main.TemplateID = "001";
        main.HtmlFile = "";
        #endregion


        #region 创业信息表
        CarveModel.AdTitle = txtAdTitle.Text.Trim();
        CarveModel.CarveOutInfoType ="1"; //1代表是资金找项目
        CarveModel.CountryCode = ZoneSelectControl2.CountryID.ToString().Trim();
        CarveModel.ProvinceID = ZoneSelectControl2.ProvinceID.ToString().Trim();
        CarveModel.CountyID = ZoneSelectControl2.CountyID.ToString().Trim();
        CarveModel.CityID = ZoneSelectControl2.CityID.ToString().Trim();
        CarveModel.CapitalID = ddlMerchantTotal.SelectedValue.ToString().Trim();//投资金额
        CarveModel.IndustryCarveOutID =ddlIndustry.SelectedValue;//行页
        CarveModel.ValidateID = this.rdbtXM.SelectedValue.Trim() ;

        //CarveModel.ValidateID = this.rdbtXM.SelectedValue.Trim(); //有效期
        CarveModel.InvestObject = rblInvestObject.SelectedIndex.ToString().Trim();//合作对象
        CarveModel.Pic1 = Convert.ToString(ViewState["strSavePath"]);// FilesUploadControl2.UploadImageURL;
        // pOpportunity.Pic1 = "";                   //图片
        CarveModel.Content = txtContent.Text;          //创业内容
        CarveModel.InvestReturn = txtInvestReturn.Text.Trim();
        CarveModel.Remark = txtRemark.Text;           //备注

        CarveModel.ComName = txtComName.Text.Trim();   //公司名称
        CarveModel.LinkMan = txtLinkMan.Text.Trim();   //联系人
        CarveModel.Tel = txtTelCountry.Text.Trim() + "－" + txtTelZoneCode.Text.Trim() + "－" + txtTelNumber.Text.Trim();  //电话
        CarveModel.Fax = "";
        CarveModel.Mobile = txtMobile.Text.Trim();  //手机    
        CarveModel.Address = txtAddress.Text.Trim();//地址
        CarveModel.PostCode = txtPostCode.Text.Trim();//邮编
        CarveModel.Email = txtEmail.Text.Trim();//邮箱
        CarveModel.WebSite = txtWebSite.Text.Trim();//网站
        #endregion

        #region  短内容信息表

        shortInfoRule.ShortInfoControlID = "CarveOutIndex1";
        shortInfoRule.ShortTitle = txtShortTitle.Text.Trim();
        shortInfoRule.ShortContent = txtShortContent.Text.Trim();
        shortInfoRule.Remark = "";
        #endregion
         //插入数据
        Tz888.BLL.Info.CarveOutInformationBLL bll = new Tz888.BLL.Info.CarveOutInformationBLL();
        long InfoID = bll.Insert(main, CarveModel, shortInfoRule);

        if (InfoID != 0)
        {
            Response.Write("<script>alert('添加成功')</script>");
        }
        else
        {
            Response.Write("<script language=\"javascript\">alert('添加失败');window.location.href='/PublishCarveOutFindProject.aspx';</script>");
        }

    }
    #region 将输入的文本字符串转换成HTML代码
    /// <summary>
    /// 将输入的文本字符串转换成HTML代码，转换以下字符
    /// </summary>
    /// <param name="strTxt">来自文本框的字符串</param>
    /// <returns>返回HTML可识别字符串</returns>
    public static string TxtToHtml(string strTxt)
    {
        string strTmp = strTxt;
        strTmp = strTmp.Replace("<", "&lt;");
        strTmp = strTmp.Replace(">", " &gt;");
        strTmp = strTmp.Replace(" ", "&nbsp;");
        strTmp = strTmp.Replace("\r\n", "<br>");
        return strTmp;
    }
    #endregion
    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            picTitle = Tz888.Common.FileHelper.UploadFile(uploadPic, "", 500, "default");
            switch (picTitle)
            {
                case "1": Response.Write("<script>alert('图片类型不对');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出500K');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                default:
                    ViewState["strSavePath"] = "UploadFile/" + picTitle;
                    this.LblMessage2.Text = "上传图片成功"; break;
            }

        }
        else
        {
            RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!'); </script>");
        }


    

    }
}
