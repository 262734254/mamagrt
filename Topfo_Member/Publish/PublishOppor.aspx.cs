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

public partial class Publish_PublishOppor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!IsPostBack)
        {
            SetOpportun();
            GetIndustry();
            SetValid();
            InitInfoContact();
            ViewState["strSavePath"] = "";
        }

    }
    /// <summary>
    /// 商机类别
    /// </summary>
    private void SetOpportun()
    {
        Tz888.BLL.Info.OpportunityInfoBLL opp = new Tz888.BLL.Info.OpportunityInfoBLL();
        this.ddlOpportunityType.DataSource = opp.GetOpportun();
        this.ddlOpportunityType.DataValueField = "OpportunityTypeID";
        this.ddlOpportunityType.DataTextField = "OpportunityTypeName";
        this.ddlOpportunityType.DataBind();
    }
    /// <summary>
    /// 所属行业
    /// </summary>
    private void GetIndustry()
    {
        Tz888.BLL.Info.OpportunityInfoBLL opp = new Tz888.BLL.Info.OpportunityInfoBLL();
        this.ddlIndustry.DataSource = opp.GetIndustry();
        this.ddlIndustry.DataValueField = "IndustryOpportunityID";
        this.ddlIndustry.DataTextField = "IndustryOpportunityName";
        this.ddlIndustry.DataBind();
    }
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
        org = mar.SelLoginName(Page.User.Identity.Name);
        //org = mar.SelLoginName("8ming");
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
        //这里是判断验证码
        try//验证验证码
        {
            if (Session["valationNo"] == null || ImageCode.Text.ToUpper().Trim() != Session["valationNo"].ToString().ToUpper().Trim() || Session["valationNo"].ToString().Trim() == "")
            {
                Tz888.Common.MessageBox.Show(this.Page, "验证码错误!");
                return;
            }
        }
        catch
        {
            Tz888.Common.MessageBox.Show(this.Page, "未知错误!");
        }
        #region 参数

        //List<Tz888.Model.Common.IndustryModel> industryModels = new List<Tz888.Model.Common.IndustryModel>(); //融资行业实体列表

        //industryModels = this.SelectIndustryControl1.IndustryModels;

        #endregion
        int Hit = 0;
        Random rnd = new Random();
        Hit = rnd.Next(25) + 5;
        #region 创建实例，将数据传入系统
        #region 插入数据
        //OpportunityInformation pOpportunity = new OpportunityInformation();
        Tz888.Model.Info.MainInfoModel main = new Tz888.Model.Info.MainInfoModel();//主表
        Tz888.Model.Info.OpportunityInfoModel pOpportunity = new Tz888.Model.Info.OpportunityInfoModel();//商机信息表
        Tz888.Model.Info.ShortInfoModel shortInfoRule = new Tz888.Model.Info.ShortInfoModel();//短消息表
        #region 主表

        main.Title = txtTitle.Text.Trim();
        main.InfoCode = Tz888.BLL.Info.Common.CreateInfoCode("Oppor",ddlIndustry.SelectedValue.ToString().Trim(), this.ZoneSelectControl2.CountryID, DateTime.Now);
        main.publishT = Convert.ToDateTime(DateTime.Now);
        main.Hit = Hit;
       // main.LoginName = "8ming";
        main.LoginName = Page.User.Identity.Name;
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

        #region 商机信息表
        pOpportunity.AdTitle = txtAdTitle.Text.Trim();
        pOpportunity.OpportunityType = ddlOpportunityType.SelectedValue.ToString().Trim();
        pOpportunity.CountryCode = ZoneSelectControl2.CountryID;
        pOpportunity.ProvinceID = ZoneSelectControl2.ProvinceID;
        pOpportunity.CountyID = ZoneSelectControl2.CountyID;

        pOpportunity.IndustryOpportunityID = ddlIndustry.SelectedValue.ToString().Trim();
        pOpportunity.ValidateID = this.rdbtXM.SelectedValue.Trim();

        //pOpportunity.Pic1 = FilesUploadControl2.UploadImageURL;
        pOpportunity.Pic1 = Convert.ToString(ViewState["strSavePath"]);
        // pOpportunity.Pic1 = "";                   //图片

        pOpportunity.Content = txtContent.Text;          //商机内容
        pOpportunity.Analysis = txtAnalysis.Text;          //商机分析
        pOpportunity.Request = txtRequest.Text;          //商机需求
        pOpportunity.Flow = txtFlow.Text;            //商机流程
        pOpportunity.Remark = txtRemark.Text;           //备注

        pOpportunity.ComName = txtComName.Text.Trim();   //公司名称
        pOpportunity.LinkMan = txtLinkMan.Text.Trim();   //联系人
        pOpportunity.Tel = txtTelCountry.Text.Trim() + "－" + txtTelZoneCode.Text.Trim() + "－" + txtTelNumber.Text.Trim();  //电话
        pOpportunity.Fax = "";
        pOpportunity.Mobile = txtMobile.Text.Trim();  //手机    
        pOpportunity.Address = txtAddress.Text.Trim();//地址
        pOpportunity.PostCode = txtPostCode.Text.Trim();//
        pOpportunity.Email = txtEmail.Text.Trim();//邮箱
        pOpportunity.WebSite = txtWebSite.Text.Trim();//
        #endregion

        #region  短内容信息表

        shortInfoRule.ShortInfoControlID = "OpporIndex1";
        shortInfoRule.ShortTitle = txtShortTitle.Text.Trim();
        shortInfoRule.ShortContent = txtShortContent.Text.Trim();
        shortInfoRule.Remark = "";
        #endregion

        //插入数据
        Tz888.BLL.Info.OpportunityInfoBLL opportun = new Tz888.BLL.Info.OpportunityInfoBLL();
        long InfoID = opportun.Insert(main, pOpportunity, shortInfoRule);
        #endregion
        #endregion

        if (InfoID != 0)
        {
            Response.Write("<script>alert('添加成功')</script>");
        }
        else
        {
            Response.Write("<script language=\"javascript\">alert('添加失败');window.location.href='/PublishOppor.aspx';</script>");
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
    protected void btnUpload_Click(object sender, EventArgs e)
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
                    ViewState["strSavePath"] += "UploadFile/" + picTitle + ",";
                    this.LblMessage.Text = "上传图片成功"; break;
            }

        }
        else
        {
            // RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!'); </script>");
            Response.Write("<scrpit>alert('请选择上传的图片')</script>");
        }
    }

}
