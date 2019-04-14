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
using Tz888.Common;

public partial class Publish_Test3 : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        //if (isTof)
        //{
        //    Page.MasterPageFile = "../indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "~/MasterPage.master";
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.User.Identity.Name == "")
        //{
        //    Response.Redirect("../Login.aspx");
        //}
        //if (!IsPostBack)
        //{
        //    ViewState["strSavePath"] = "";
        //}

        btnOK.Attributes.Add("onclick", "return chkInput();");
        this.LblMessage.Text = "";
        this.LblMessage2.Text = "";
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (this.hidradioType.Value != "67")
        {
            Tz888.Model.TPMerchant TPMerchantModel = new Tz888.Model.TPMerchant();
            TPMerchantModel.infoID = 0;
            TPMerchantModel.NewsTypeID = this.hidradioType.Value.Trim();
            TPMerchantModel.Title = this.txtTitle.Value.Trim();  //标题
            TPMerchantModel.KeyWord = "";
            TPMerchantModel.Descript = "";
            TPMerchantModel.publishT = System.DateTime.Now;     //时间
            TPMerchantModel.Hit = 0;
            TPMerchantModel.LoginName ="262734254";// Page.User.Identity.Name.ToString();
            TPMerchantModel.Author = "";
            TPMerchantModel.Origin = this.txtSource.Value.Trim(); //来源
            TPMerchantModel.Content = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtContent.Value.Trim());  //正文
            TPMerchantModel.Pic1 = Convert.ToString(ViewState["strSavePath"]);
            TPMerchantModel.PicAbout = this.txtInstruction.Value.Trim();           //图片说明
            TPMerchantModel.ProvinceID = this.ZoneSelectControl1.ProvinceID.Trim();
            TPMerchantModel.CityID = this.ZoneSelectControl1.CityID.Trim();
            TPMerchantModel.CountyID = this.ZoneSelectControl1.CountyID.Trim();
            TPMerchantModel.IsRedirect = 0;
            TPMerchantModel.NewsLblStatus = "";
            TPMerchantModel.NewsIndustryID = "*";
            TPMerchantModel.PageCharCount = 0;
            TPMerchantModel.RedirectUrl = "";
            TPMerchantModel.ResearchSpot = "";
            TPMerchantModel.strRemark = "";
            TPMerchantModel.Summary = "";
            TPMerchantModel.subTitle = this.txtTitle.Value.Trim();  //标题
            TPMerchantModel.ShortTitle = this.txtTitle.Value.Trim(); //标题
            TPMerchantModel.ShortContent = "";
            if (this.txtContent.Value.Trim().Length > 100)
            {
                TPMerchantModel.ShortContent = this.txtContent.Value.Trim().Substring(0, 100);
            }
            TPMerchantModel.PageStatus = 0;
            TPMerchantModel.ShortInfoControlID = "";
            TPMerchantModel.IsCore = 0;
            TPMerchantModel.InfoCode = "ZSNEWS";
            TPMerchantModel.auditingstatus = 0;

            Tz888.SQLServerDAL.TPMerchant tpm = new Tz888.SQLServerDAL.TPMerchant();
            bool infoID = tpm.InsertMerchantNews(TPMerchantModel);
            if (infoID == true)
            {
                RegisterStartupScript("alertMessage", "<script>alert('发布成功!'); </script>");
                //Response.Redirect("NewsSuccess.aspx");
            }
            else
            {
                RegisterStartupScript("alertMessage", "<script>alert('发布失败!'); </script>");
            }
        }
        else
        {
            Tz888.Model.TPMerchant TPMerchantModel = new Tz888.Model.TPMerchant();
            TPMerchantModel.infoID = 0;
            TPMerchantModel.NewsTypeID = this.hidradioType.Value.Trim();
            TPMerchantModel.Title = this.txtName.Value.Trim();
            TPMerchantModel.publishT = System.DateTime.Now;
            TPMerchantModel.Hit = 0;
            TPMerchantModel.KeyWord = "";
            TPMerchantModel.Descript = "";
            TPMerchantModel.LoginName = Page.User.Identity.Name.ToString();
            TPMerchantModel.Author = "";
            TPMerchantModel.Origin = "";
            TPMerchantModel.Content = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtContent2.Value.Trim());
            TPMerchantModel.Pic1 = Convert.ToString(ViewState["strSavePath"]);
            TPMerchantModel.PicAbout = this.txtRemarks.Value.Trim();
            TPMerchantModel.ProvinceID = this.ZoneSelectControl1.ProvinceID.Trim();
            TPMerchantModel.CityID = this.ZoneSelectControl1.CityID.Trim();
            TPMerchantModel.CountyID = this.ZoneSelectControl1.CountyID.Trim();
            TPMerchantModel.IsRedirect = 0;
            TPMerchantModel.NewsLblStatus = "";
            TPMerchantModel.NewsIndustryID = "*";
            TPMerchantModel.PageCharCount = 0;
            TPMerchantModel.RedirectUrl = "";
            TPMerchantModel.ResearchSpot = "";
            TPMerchantModel.strRemark = "";
            TPMerchantModel.Summary = "";
            TPMerchantModel.subTitle = this.txtName.Value.Trim();
            TPMerchantModel.ShortTitle = this.txtName.Value.Trim();
            TPMerchantModel.ShortContent = "";
            if (this.txtContent.Value.Trim().Length > 100)
            {
                TPMerchantModel.ShortContent = this.txtContent.Value.Trim().Substring(0, 100);
            }
            TPMerchantModel.PageStatus = 0;
            TPMerchantModel.ShortInfoControlID = "";

            TPMerchantModel.activeAdress = this.txtAddress.Value.Trim();
            TPMerchantModel.activeDateFrom = this.stime.Value.Trim();
            TPMerchantModel.activeDateTo = "";
            TPMerchantModel.mainUnit = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtHostUnit.Value.Trim());
            TPMerchantModel.secondUnit = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtHandleUnit.Value.Trim());
            TPMerchantModel.OrganizationName = "";
            TPMerchantModel.Name = this.txtNam.Value.Trim() + " " + this.txtNam1.Value.Trim() + " " + this.txtNam2.Value.Trim() + " " + this.txtNam3.Value.Trim() + " " + this.txtNam4.Value.Trim() + " " + this.txtNam5.Value.Trim();
            TPMerchantModel.Mobile = this.txtPhone.Value.Trim() + " " + this.txtPhone1.Value.Trim() + " " + this.txtPhone2.Value.Trim() + " " + this.txtPhone3.Value.Trim() + " " + this.txtPhone4.Value.Trim() + " " + this.txtPhone5.Value.Trim();
            TPMerchantModel.TelCountryCode = this.txtPhoneCountryCode.Value.Trim();
            TPMerchantModel.TelStateCode = this.txtPhoneCityCode.Value.Trim();
            TPMerchantModel.TelNum = this.txtPhoneNum.Value.Trim();
            TPMerchantModel.FaxCountryCode = this.txtFaxCountryCode.Value.Trim();
            TPMerchantModel.FaxStateCode = this.txtFaxCityCode.Value.Trim();
            TPMerchantModel.FaxNum = this.txtFaxNum.Value.Trim();
            TPMerchantModel.address = this.txtAddres.Value.Trim();
            TPMerchantModel.WebSite = this.txtNet.Value.Trim();
            TPMerchantModel.PostCode = this.txtZipCode.Value.Trim();
            TPMerchantModel.Email = this.txtEmail.Value.Trim();
            TPMerchantModel.IsCore = 0;
            TPMerchantModel.auditingstatus = 0;

            Tz888.SQLServerDAL.TPMerchant tpm = new Tz888.SQLServerDAL.TPMerchant();
            bool infoID = tpm.InsertMerchantActiveNews(TPMerchantModel);
            if (infoID == true)
            {
                RegisterStartupScript("alertMessage", "<script>alert('发布成功!'); </script>");
                //Response.Redirect("NewsSuccess.aspx");
            }
            else
            {
                RegisterStartupScript("alertMessage", "<script>alert('发布失败!'); </script>");
            }
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            picTitle = FileHelper.UploadFile(uploadPic, "", 500, "default");
            switch (picTitle)
            {
                case "1": Response.Write("<script>alert('图片类型不对');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出500K');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='PublishNews.aspx'</script>"); Response.End(); break;
                default:
                    ViewState["strSavePath"] = "UploadFile/" + picTitle;
                    this.LblMessage.Text = "上传图片成功"; break;
            }

        }
        else
        {
            RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!'); </script>");
        }

        tb1.Style.Value = "display:block;";
        dvpublish2.Style.Value = "display:none;";
    }

    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic2.HasFile)
        {
            picTitle = FileHelper.UploadFile(uploadPic2, "", 500, "default");
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

        radioType67.Checked = true;
        tb1.Style.Value = "display:none;";
        dvpublish2.Style.Value = "display:block;";
    }

}
