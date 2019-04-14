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
using Tz888.BLL.Register;

public partial class Register_EnterpriseRegisterResult : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Page.User.IsInRole("MT1001"))
        {
            Tz888.Common.MessageBox.ShowAndRedirect(this.Page, "对不起，您是个人会员，不能进行公司登记", "/index.aspx");
            return;
        }
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));

        }

        //根据会员类型转向不同的登记页面
        if (Page.User.IsInRole("MT1004"))
            Response.Redirect("GovernmentRegisterResult.aspx");//机构      
        else if (Page.User.IsInRole("MT1001")) //个人
        {
            Tz888.Common.MessageBox.Show(this.Page, "对不起，个人会员不能进行登记！");
            if (Page.User.IsInRole("GT1001"))
            {
                Response.Write("index.aspx");
            }
            else
            {
                Response.Write("indexTop.aspx");
            }
        }

         Tz888.BLL.Register.EnterpriseRegisterBLL obj = new EnterpriseRegisterBLL();
         this.ViewState["MemberLoginName"] = Page.User.Identity.Name;

        /*登记审核状态(待审核0 已发布上网1 未通过审核2 己删除3 )
            FeedbackStatus  反馈状态（0 可修改 1 将删除）*/

        if (Page.User.IsInRole("GT1001"))
            divReg.InnerHtml = " <strong>重要提示：</strong>请确保您发布的公司资料真实有效，由于发布虚假信息产生的任何责任，" +
        "由发布者自行承担！ 想让您的公司介绍排在普通会员的前面被更多用户关注吗？点此<a href='VIPMemberRegister_In.aspx'>申请拓富通</a>" +
                           " 0755-82210116 82212980 在线客服";

        if (Page.User.IsInRole("GT1002"))
            divReg.InnerHtml = "";

        DataTable dt = obj.getEnterpriseModel( this.ViewState["MemberLoginName"].ToString());
        if (dt == null)
        {
            Response.Redirect("EnterpriseRegister.aspx");
            return;
        }        
        else if (dt.Rows.Count > 0)
        {
            //判断登记信息是的审核状态（AuditingStatus）1:审核状态：   2已审核(已审基本信息)，0未审核、1审核通过、
            //3审核不通过、4退款（注意：审核为拓富通会员后不出现在此列表），付费状态和审核状态无关。
            switch (Convert.ToInt32(dt.Rows[0]["AuditingStatus"]))
            {
                case 0:
                    lbMessage.Text = "您的公司资料还在审核过程中...";
                    break;
                case 1:                
                //基本信息
                    lbMessage.Text = "您的公司资料己审核通过！";                 
                    break;
                case 2:
                    //审核信息
                    lbMessage.Text = "您的公司资料审核没有通过！";
                    Tz888.SQLServerDAL.Conn objStatus = new Tz888.SQLServerDAL.Conn();
                    DataTable dtStatus = objStatus.GetList("OrgAuditTab", "*", "AuditingDate", 1, 1, 0, 1, "LoginName='" + this.ViewState["MemberLoginName"].ToString() + "'");
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
                               lbResult.Text = "原因：" + dtStatus.Rows[0]["AuditingRemark"] + "<a href='EnterpriseRegister.aspx'>马上去修改</a>";
                               break;
                           default:
                               break;
                       }
                   }
                    break;
                default :
                    break;
          }
      

          lbOrgName.Text = dt.Rows[0]["EnterpriseName"].ToString();
          lbComAboutBrief.Text =dt.Rows[0]["ComAbout"].ToString();
          

          
          string str = dt.Rows[0]["Industrylist"].ToString().Trim();
          string[] strList = str.Split(',');
          Tz888.BLL.Common.IndustryBLL obj7 = new Tz888.BLL.Common.IndustryBLL();
          string strIndustry = "";
         // Response.Write(str);
          for (int i = 0; i < strList.Length; i++)
          {
              if (strList[i] != "")
              {
                  strIndustry += obj7.GetNameByID(strList[i].Trim());
              }
          }
          lbindustry.Text = strIndustry != "" ? strIndustry : "暂无";

          lbMainProduct.Text = dt.Rows[0]["MainProduct"].ToString();
          lbManageType.Text = dt.Rows[0]["SetComTypeName"].ToString();
          lbRegisterDate.Text = Convert.ToDateTime(dt.Rows[0]["RegisterDate"]).ToShortDateString();

          string CountryName = ""; string ProvinceName = ""; string CountyName = ""; string CityName = "";
          try
          {
              Tz888.BLL.Common.ZoneSelectBLL objZone = new Tz888.BLL.Common.ZoneSelectBLL();
              CountryName = objZone.GetCountyNameByCode(dt.Rows[0]["CountryCode"].ToString());
              ProvinceName = objZone.GetProvinceNameByCode(dt.Rows[0]["ProvinceID"].ToString());
              CountyName = objZone.GetCountyNameByCode(dt.Rows[0]["CountyID"].ToString());
              CityName = objZone.GetCityNameByCode(dt.Rows[0]["CityID"].ToString());
          }
          catch { }
          lbZone.Text = (CountryName != "" ? CountryName : "") + "" + (ProvinceName != "" ? ProvinceName : "") + "" + (CountyName != "" ? CountyName : "") + "" + (CityName != "" ? CityName : "");
          lbRegCapital.Text = dt.Rows[0]["RegCapital"].ToString() +"（万)"+ dt.Rows[0]["currency"].ToString();

          //联系信息
          lbLinkMan.Text = dt.Rows[0]["Name"].ToString() != "" ? dt.Rows[0]["Name"].ToString() : "没有提供";
          lbMail.Text = dt.Rows[0]["Email"].ToString() != "" ? dt.Rows[0]["Email"].ToString() : "没有提供";
          lbSite.Text = dt.Rows[0]["Website"].ToString() != "" ? dt.Rows[0]["Website"].ToString() : "没有提供";
          lbTel.Text = dt.Rows[0]["TelCountryCode"].ToString() + "-" + dt.Rows[0]["TelStateCode"].ToString() + "-" + dt.Rows[0]["TelNum"].ToString();
          lbFax.Text = dt.Rows[0]["FaxCountryCode"].ToString() + "-" + dt.Rows[0]["FaxStateCode"].ToString() + "-" + dt.Rows[0]["FaxNum"].ToString();
          lbMobile.Text = dt.Rows[0]["Mobile"].ToString() != "" ? dt.Rows[0]["Mobile"].ToString() : "没有提供";
          lbAddress.Text = dt.Rows[0]["address"].ToString() != "" ? dt.Rows[0]["address"].ToString() : "没有提供";

          //图片信息      
          Tz888.SQLServerDAL.Conn objResource = new Tz888.SQLServerDAL.Conn();
          DataTable dtResource = objResource.GetList("MemberResourceTab", "*", "ResourceID", 1, 1, 0, 1, "LoginName='" + this.ViewState["MemberLoginName"].ToString() + "' AND ResourceProperty=0");
         if (dtResource != null && dtResource.Rows.Count>0)
         {
             FileUploader1.Img = Tz888.Common.Common.GetImageDomain() + "/" + dtResource.Rows[0]["ResourceAddr"].ToString();//ConfigurationManager.AppSettings["ImageDomain"].ToString()
             FileUploader1.ButtonName = "";             
         }
         else
         {
             FileUploader1.Img =  @"../images/publish/noneimg.gif";             
             FileUploader1.ButtonName = "添加";         
             FileUploader1.IsUp = "1";//是否通过控件上传        
             FileUploader1.InfoType = "EnterpriseRegister";
             //Response.Write("<Script>document.all('ButAdd').onclick();</script>");
         } 
        }
        else //没有进行公司登记
        {
            Response.Redirect("EnterpriseRegister.aspx");
        }
    }
}
