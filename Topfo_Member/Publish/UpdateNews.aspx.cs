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

public partial class UpdateNews : System.Web.UI.Page
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
            try
            {
                Tz888.SQLServerDAL.TPMerchant objtp = new Tz888.SQLServerDAL.TPMerchant();
                string infoid = Request.QueryString["id"].ToString();
                DataSet ds = objtp.GetOneNewsList(infoid);
                this.txtTitle.Value = ds.Tables[0].Rows[0]["Title"].ToString(); 
                this.txtContent.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(ds.Tables[0].Rows[0]["Content"].ToString());
                this.txtInstruction.Value = ds.Tables[0].Rows[0]["PicAbout"].ToString(); 
                this.txtSource.Value = ds.Tables[0].Rows[0]["Origin"].ToString(); 
                ZoneSelectControl1.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim();
                ZoneSelectControl1.CityID = ds.Tables[0].Rows[0]["CityID"].ToString().Trim() ;
                ZoneSelectControl1.CountyID =ds.Tables[0].Rows[0]["CountyID"].ToString().Trim();   
                string strNewsType = "radioType" + ds.Tables[0].Rows[0]["NewsTypeID"].ToString().Trim();
                ViewState["NewsType"] = ds.Tables[0].Rows[0]["NewsTypeID"].ToString().Trim();
                System.Web.UI.HtmlControls.HtmlInputRadioButton obj = (System.Web.UI.HtmlControls.HtmlInputRadioButton)this.tbNews.FindControl(strNewsType);
                if (obj != null)
                {
                    obj.Checked = true;
                }
            }
            catch
            {
                Response.Write("<script>alert('请重新选择要修改的数据!');window.close();</script>"); 
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
                case "1": Response.Write("<script>alert('图片类型不对');location.href='UpdateNews.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出500K');location.href='UpdateNews.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='UpdateNews.aspx'</script>"); Response.End(); break;
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
        TPMerchantModel.publishT = System.DateTime.Now;
        TPMerchantModel.KeyWord = "";
        TPMerchantModel.Descript = "";
        TPMerchantModel.DisplayTitle = "";
        TPMerchantModel.HtmlFile = "";
        TPMerchantModel.Hit = 0;
        TPMerchantModel.Title = this.txtTitle.Value.Trim();
        TPMerchantModel.LoginName = Page.User.Identity.Name.ToString();
        TPMerchantModel.Author = "";
        TPMerchantModel.IsCore = 0;
        TPMerchantModel.Origin = this.txtSource.Value.Trim();
        TPMerchantModel.Content = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtContent.Value.Trim());
        TPMerchantModel.Pic1 = Convert.ToString(ViewState["strSavePath"]);
        TPMerchantModel.PicAbout = this.txtInstruction.Value.Trim();
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
        TPMerchantModel.subTitle = this.txtTitle.Value.Trim();
        TPMerchantModel.ShortTitle = this.txtTitle.Value.Trim();
        TPMerchantModel.ShortContent = "";
        if (this.txtContent.Value.Trim().Length > 100)
        {
            TPMerchantModel.ShortContent = this.txtContent.Value.Trim().Substring(0, 100);
        }
        TPMerchantModel.PageStatus = 0;
        TPMerchantModel.ShortInfoControlID = "";
        TPMerchantModel.InfoCode = "ZSNEWS";
        TPMerchantModel.auditingstatus = 0;
        TPMerchantModel.AuditingRemark = "";

       Tz888.SQLServerDAL.TPMerchant tpm = new Tz888.SQLServerDAL.TPMerchant();
        bool infoID = tpm.UpdateMerchantNews(TPMerchantModel);
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
