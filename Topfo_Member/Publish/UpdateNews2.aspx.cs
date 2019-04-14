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

public partial class UpdateNews2 : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "../indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "~/MasterPage.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == "")
        {
            Response.Redirect("../Login.aspx");
        }  
        if (!IsPostBack)
        {
            ViewState["strSavePath"] = ""; 
            try
            {

                Tz888.SQLServerDAL.TPMerchant objtp = new Tz888.SQLServerDAL.TPMerchant();
                string infoid = Request.QueryString["id"].ToString();
                DataSet ds = objtp.GetOneNewsList(infoid);
                this.txtName.Value = ds.Tables[0].Rows[0]["Title"].ToString();
                this.txtAddress.Value = ds.Tables[0].Rows[0]["activeAdress"].ToString();
                this.stime.Value = ds.Tables[0].Rows[0]["activeDateFrom"].ToString(); 
                this.txtRemarks.Value = ds.Tables[0].Rows[0]["DesCript"].ToString();
                this.txtHostUnit.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(ds.Tables[0].Rows[0]["mainUnit"].ToString());
                this.txtHandleUnit.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(ds.Tables[0].Rows[0]["secondUnit"].ToString());
                this.txtRemarks.Value = ds.Tables[0].Rows[0]["picAbout"].ToString(); 
                string strName = ds.Tables[0].Rows[0]["Name"].ToString();
                string strMobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                string[] strnam = strName.Split(' ');
                string[] strmob = strMobile.Split(' ');
                this.txtNam.Value = strnam[0].ToString();
                this.txtPhone.Value = strmob[0].ToString();
                if (strnam.Length > 1)
                {
                    this.txtNam1.Value = strnam[1].ToString();
                    this.txtPhone1.Value = strmob[1].ToString();
                }
                if (strnam.Length > 2)
                {
                    this.txtNam2.Value = strnam[2].ToString();
                    this.txtPhone2.Value = strmob[2].ToString();
                }
                if (strnam.Length > 3)
                {
                    this.txtNam3.Value = strnam[3].ToString();
                    this.txtPhone3.Value = strmob[3].ToString();
                }
                if (strnam.Length > 4)
                {
                    this.txtNam4.Value = strnam[4].ToString();
                    this.txtPhone4.Value = strmob[4].ToString();
                }
                if (strnam.Length > 5)
                {
                    this.txtNam5.Value = strnam[5].ToString();
                    this.txtPhone5.Value = strmob[5].ToString();
                }
                ZoneSelectControl1.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim();
                ZoneSelectControl1.CityID = ds.Tables[0].Rows[0]["CityID"].ToString().Trim();
                ZoneSelectControl1.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString().Trim();  
                this.txtZipCode.Value = ds.Tables[0].Rows[0]["PostCode"].ToString();
                this.txtAddres.Value = ds.Tables[0].Rows[0]["address"].ToString();
                this.txtEmail.Value = ds.Tables[0].Rows[0]["Email"].ToString();
                this.txtNet.Value = ds.Tables[0].Rows[0]["WebSite"].ToString(); 
                this.txtContent.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(ds.Tables[0].Rows[0]["Content"].ToString());
                this.txtPhoneCountryCode.Value = ds.Tables[0].Rows[0]["TelCountryCode"].ToString().Trim();
                this.txtPhoneCityCode.Value = ds.Tables[0].Rows[0]["TelStateCode"].ToString().Trim();
                this.txtPhoneNum.Value = ds.Tables[0].Rows[0]["TelNum"].ToString().Trim();
                this.txtFaxCountryCode.Value = ds.Tables[0].Rows[0]["FaxCountryCode"].ToString().Trim();
                this.txtFaxCityCode.Value = ds.Tables[0].Rows[0]["FaxStateCode"].ToString().Trim();
                this.txtFaxNum.Value = ds.Tables[0].Rows[0]["FaxNum"].ToString().Trim(); 
                string strNewsType = "radioType" + ds.Tables[0].Rows[0]["NewsTypeID"].ToString().Trim();
                ViewState["NewsType"] = ds.Tables[0].Rows[0]["NewsTypeID"].ToString().Trim();
                string strIsPage = "radPage" + ds.Tables[0].Rows[0]["pagestatus"].ToString().Trim();
                string strAuditingStatus = "radAuditingStatus" + ds.Tables[0].Rows[0]["AuditingStatus"].ToString().Trim();
                System.Web.UI.HtmlControls.HtmlInputRadioButton obj = (System.Web.UI.HtmlControls.HtmlInputRadioButton)this.Form.FindControl(strNewsType);
                if (obj != null)
                {
                    obj.Checked = true;

                }
                System.Web.UI.HtmlControls.HtmlInputRadioButton obj1 = (System.Web.UI.HtmlControls.HtmlInputRadioButton)this.Form.FindControl(strIsPage);
                if (obj1 != null)
                {
                    obj1.Checked = true;
                }
                System.Web.UI.HtmlControls.HtmlInputRadioButton obj2 = (System.Web.UI.HtmlControls.HtmlInputRadioButton)this.Form.FindControl(strAuditingStatus);
                if (obj2 != null)
                {
                    obj2.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('请重新选择要修改的数据!');window.close();</script>");
            }
        }
        btnOK.Attributes.Add("onclick", "return chkInput();");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string picTitle = "";
        if (this.uploadPic.HasFile)
        {
            picTitle = FileHelper.UploadFile(uploadPic, "", 500, "default");
            switch (picTitle)
            {
                case "1": Response.Write("<script>alert('图片类型不对');location.href='UpdateNews2.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出500K');location.href='UpdateNews2.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='UpdateNews2.aspx'</script>"); Response.End(); break;
                default:
                    ViewState["strSavePath"] = "UploadFile/" + picTitle;
                    this.LblMessage.Text = "上传图片成功"; break;
            }

        }
        else
        {
            RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!'); </script>");
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    { 
        Tz888.Model.TPMerchant TPMerchantModel = new Tz888.Model.TPMerchant();
        TPMerchantModel.infoID = Convert.ToInt64(Request.QueryString["id"].ToString());
        TPMerchantModel.NewsTypeID = ViewState["NewsType"].ToString();
        TPMerchantModel.Title = this.txtName.Value.Trim();
        TPMerchantModel.LoginName = Page.User.Identity.Name.ToString();
        TPMerchantModel.publishT = System.DateTime.Now;
        TPMerchantModel.Hit = 0;
        TPMerchantModel.ShortTitle = this.txtName.Value.Trim();
        TPMerchantModel.KeyWord = "";
        TPMerchantModel.Descript = this.txtRemarks.Value.Trim();
        TPMerchantModel.HtmlFile = Convert.ToString(ViewState["strSavePath"]);
        TPMerchantModel.PageStatus = 0;
        TPMerchantModel.auditingstatus = 0;
        TPMerchantModel.DisplayTitle = this.txtName.Value.Trim();
        TPMerchantModel.Author = "";
        TPMerchantModel.Content = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtContent.Value.Trim());
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
        TPMerchantModel.InfoCode = "ZSNEWS";
        TPMerchantModel.activeAdress = this.txtAddress.Value.Trim();
        TPMerchantModel.activeDateFrom = this.stime.Value.Trim();
        TPMerchantModel.activeDateTo = ""; 
        TPMerchantModel.mainUnit = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtHostUnit.Value.Trim());
        TPMerchantModel.secondUnit = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtHandleUnit.Value.Trim());
        TPMerchantModel.TelCountryCode = this.txtPhoneCountryCode.Value.Trim();
        TPMerchantModel.TelStateCode = this.txtPhoneCityCode.Value.Trim();
        TPMerchantModel.TelNum = this.txtPhoneNum.Value.Trim();
        TPMerchantModel.FaxCountryCode = this.txtFaxCountryCode.Value.Trim();
        TPMerchantModel.FaxStateCode = this.txtFaxCityCode.Value.Trim();
        TPMerchantModel.FaxNum = this.txtFaxNum.Value.Trim(); 
        TPMerchantModel.Name = this.txtNam.Value.Trim() + " " + this.txtNam1.Value.Trim() + " " + this.txtNam2.Value.Trim() + " " + this.txtNam3.Value.Trim() + " " + this.txtNam4.Value.Trim() + " " + this.txtNam5.Value.Trim();
        TPMerchantModel.Mobile = this.txtPhone.Value.Trim() + " " + this.txtPhone1.Value.Trim() + " " + this.txtPhone2.Value.Trim() + " " + this.txtPhone3.Value.Trim() + " " + this.txtPhone4.Value.Trim() + " " + this.txtPhone5.Value.Trim();
        TPMerchantModel.address = this.txtAddres.Value.Trim();
        TPMerchantModel.WebSite = this.txtNet.Value.Trim();
        TPMerchantModel.PostCode = this.txtZipCode.Value.Trim();
        TPMerchantModel.Email = this.txtEmail.Value.Trim();
        TPMerchantModel.OrganizationName = "";
        TPMerchantModel.IsCore = 0;
        TPMerchantModel.AuditingRemark = "";

        Tz888.SQLServerDAL.TPMerchant tpm = new Tz888.SQLServerDAL.TPMerchant();
        bool infoID = tpm.UpdateActiveMerchantNews(TPMerchantModel);
        if (infoID == true)
        {

            Response.Write("<script>alert('更新成功!');window.close();</script>");
        }
        else
        {
            RegisterStartupScript("alertMessage", "<script>alert('更新失败!'); </script>");
        }
    }
}
