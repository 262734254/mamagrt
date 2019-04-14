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

public partial class Register_GovernmentRegisterResult : System.Web.UI.Page
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
        this.ViewState["MemberLoginName"] = Page.User.Identity.Name;
        Tz888.BLL.Register.GovernmentRegisterBLL obj = new Tz888.BLL.Register.GovernmentRegisterBLL();
       
        if (Page.User.IsInRole("MT1003"))
            Response.Redirect("EnterpriseRegisterResult.aspx");  

        if (Page.User.IsInRole("MT1001"))
        {
            Tz888.Common.MessageBox.Show(this.Page, "对不起，您是个人会员，不能进行杨机构登记！");
            return;
        }

        if (Page.User.IsInRole("GT1001")) divReg.Style.Add("display", "block");
        if (Page.User.IsInRole("GT1002") || Page.User.IsInRole("MT1003")) divReg.Style.Add("display", "none");

        /*登记审核状态(待审核0 已发布上网1 未通过审核2 己删除3 )
            FeedbackStatus  反馈状态（0 可修改 1 将删除）*/
        DataTable dt = obj.getGovernmentModel(Page.User.Identity.Name);
        if (dt == null)
        {
            Response.Redirect("GovernmentRegister.aspx");
            return;
        }
        else if (dt.Rows.Count > 0)
        {
            //判断登记信息是的审核状态（AuditingStatus）1:审核状态：   2已审核(已审基本信息)，0未审核、1审核通过、

            //3审核不通过、4退款（注意：审核为拓富通会员后不出现在此列表），付费状态和审核状态无关。

            switch (Convert.ToInt32(dt.Rows[0]["AuditingStatus"]))
            {
                case 0:
                    lbMessage.Text = "您的机构资料还在审核过程中...";
                    break;
                case 1:
                    //基本信息
                    lbMessage.Text = "您的机构资料己审核通过！";
                    break;
                case 2:
                    lbMessage.Text = "您的机构资料审核没有通过！";
                    //审核信息
                    Tz888.BLL.Conn objStatus = new Tz888.BLL.Conn();
                    DataTable dtStatus = objStatus.GetList("OrgAuditTab", "*", "AuditingDate", 1, 1, 0, 1, "LoginName='" + Page.User.Identity.Name + "'");
                   
                    if (dtStatus.Rows.Count > 0)
                    {
                        switch (dtStatus.Rows[0]["FeedbackStatus"].ToString()) //0即将删除 1可修改 2己发布

                        {
                            case "2":                              
                                lbFeedbackStatus.Text = "状态：即将删除";
                                lbResult.Text = "原因：" + dtStatus.Rows[0]["AuditingRemark"].ToString();
                                break;
                            case "1":                               
                                lbFeedbackStatus.Text = "状态：可修改";
                                lbResult.Text = "原因：" + dtStatus.Rows[0]["AuditingRemark"] + "<a href='GovernmentRegister.aspx'>马上去修改</a>";
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

            lbOrgName.Text = dt.Rows[0]["GovernmentName"].ToString();
            lbComAboutBrief.Text = dt.Rows[0]["GovAbout"].ToString();
            lbMerchantTypeName.Text = dt.Rows[0]["MerchantTypeName"].ToString();
           // lbRegisterDate.Text = Convert.ToDateTime(dt.Rows[0]["EnrolDate"]).ToShortDateString();

            string CountryName = ""; string ProvinceName = ""; string CountyName = ""; string CityName = "";
            try
            {
                Tz888.BLL.Common.ZoneSelectBLL objZone = new Tz888.BLL.Common.ZoneSelectBLL();
                CountryName = objZone.GetCountryNameByCode(dt.Rows[0]["CountryCode"].ToString().Trim());
                ProvinceName = objZone.GetProvinceNameByCode(dt.Rows[0]["ProvinceID"].ToString().Trim());
                CountyName = objZone.GetCountyNameByCode(dt.Rows[0]["CountyID"].ToString().Trim());
                CityName = objZone.GetCityNameByCode(dt.Rows[0]["CityID"].ToString().Trim());
            }
            catch { }
            lbZone.Text = (CountryName != "" ? CountryName : "") + " " + (ProvinceName != "" ? ProvinceName : "") + " " + (CountyName != "" ? CountyName : "") + " " + (CityName != "" ? CityName : "");
         
            //联系信息
            lbLinkMan.Text = dt.Rows[0]["Name"].ToString()!=""?dt.Rows[0]["Name"].ToString():"没有提供";
            lbMail.Text = dt.Rows[0]["Email"].ToString()!=""?dt.Rows[0]["Email"].ToString():"没有提供";
            lbSite.Text = dt.Rows[0]["Website"].ToString() != "" ? dt.Rows[0]["Website"].ToString() : "没有提供";
            lbTel.Text = dt.Rows[0]["TelCountryCode"].ToString() + "-" + dt.Rows[0]["TelStateCode"].ToString() + "-" + dt.Rows[0]["TelNum"].ToString();
            lbFax.Text = dt.Rows[0]["FaxCountryCode"].ToString() + "-" + dt.Rows[0]["FaxStateCode"].ToString() + "-" + dt.Rows[0]["FaxNum"].ToString();
            lbMobile.Text = dt.Rows[0]["Mobile"].ToString()!=""?dt.Rows[0]["Mobile"].ToString():"没有提供";
            lbAddress.Text = dt.Rows[0]["address"].ToString()!=""?dt.Rows[0]["address"].ToString():"没有提供";

            //图片信息      
            Tz888.BLL.Conn objResource = new Tz888.BLL.Conn();
            DataTable dtResource = objResource.GetList("MemberResourceTab", "*", "ResourceID", 1, 1, 0, 1, "LoginName='" + this.ViewState["MemberLoginName"].ToString() + "' AND ResourceProperty=0");
            if (dtResource != null && dtResource.Rows.Count > 0)
            {
                FileUploader1.Img = Tz888.Common.Common.GetImageDomain() + "/" + dtResource.Rows[0]["ResourceAddr"].ToString();//ConfigurationManager.AppSettings["ImageDomain"].ToString()
                FileUploader1.ButtonName = "";              
            }
            else
            {
                FileUploader1.Img = @"../images/publish/noneimg.gif";
                FileUploader1.ButtonName = "添加";
                FileUploader1.IsUp = "1";
                FileUploader1.InfoType = "GovernmentRegister";   
            }
        }
        else //没有进行公司登记
        {
            Response.Redirect("GovernmentRegister.aspx");
        }

    }
}

