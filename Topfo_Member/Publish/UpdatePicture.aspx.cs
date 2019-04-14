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

public partial class UpdatePicture : System.Web.UI.Page
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
                //ViewState["strSavePath"] = "UploadPic/y/";
                ViewState["strSavePath"] = "UploadPic/" + Page.User.Identity.Name.ToString() + "/";

                Tz888.SQLServerDAL.TPPicture objtp = new Tz888.SQLServerDAL.TPPicture();
                string infoid = Request.QueryString["id"].ToString();

                DataSet ds = objtp.GetOnePicMess(infoid);
                this.txtTitle.Value = ds.Tables[0].Rows[0]["subTitle"].ToString();
                this.txtContent.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(ds.Tables[0].Rows[0]["Content"].ToString()); 
                this.txtKeyWord.Value = ds.Tables[0].Rows[0]["KeyWord"].ToString();
                string strOrigin = ds.Tables[0].Rows[0]["Origin"].ToString().Trim();
                ZoneSelectControl1.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim();
                ZoneSelectControl1.CityID = ds.Tables[0].Rows[0]["CityID"].ToString().Trim();
                ZoneSelectControl1.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString().Trim();  
                switch (strOrigin)
                {
                    case "转载":
                        System.Web.UI.HtmlControls.HtmlInputRadioButton obj1 = (System.Web.UI.HtmlControls.HtmlInputRadioButton)this.Form.FindControl("radioType1");
                        if (obj1 != null)
                        {
                            obj1.Checked = true;
                        }
                        break;
                    case "原创":
                        System.Web.UI.HtmlControls.HtmlInputRadioButton obj2 = (System.Web.UI.HtmlControls.HtmlInputRadioButton)this.Form.FindControl("radioType2");
                        if (obj2 != null)
                        {
                            obj2.Checked = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                Response.Write("<script>alert('请重新选择要修改的数据!');window.close();</script>");  
            }
        }
        this.BtnAddPic.Attributes.Add("onclick", "return chkInput();");
    }
    protected void BtnAddPic_Click(object sender, EventArgs e)
    { 
        if (!this.chkYes.Checked)
        {
            Response.Write("<script>alert('请确认你的文件符合Topfo的上传条款,请勾上最下方复选框!'); </script>");
            return;
        }

        string picTitle = "";
        string MiniaturePath = "";
        DateTime dt = DateTime.Now;
        if (this.FileUploadPic.HasFile)
        {
            string Path = ConfigurationManager.AppSettings["FileServerPath"].ToString();
            //picTitle = FileHelper.UploadFile("y", FileUploadPic, Path, 500, ".gif|.jpg", dt);
            picTitle = FileHelper.UploadFile(Page.User.Identity.Name.ToString(), FileUploadPic, Path, 500, ".gif|.jpg", dt);
            switch (picTitle)
            {
                case "1": Response.Write("<script>alert('图片类型不对');location.href='UpdatePicture.aspx'</script>"); Response.End(); break;
                case "2": Response.Write("<script>alert('图片大小超出200K');location.href='UpdatePicture.aspx'</script>"); Response.End(); break;
                case "3": Response.Write("<script>alert('请选择上传图片');location.href='UpdatePicture.aspx'</script>"); Response.End(); break;
                default:
                    MiniaturePath = "Mini" + picTitle;
                    FileHelper.MakeThumbnail(Path + @"UploadPic\" +  Page.User.Identity.Name.ToString() + "\\" + picTitle, Path + @"UploadPic\" +  Page.User.Identity.Name.ToString() + "\\" + MiniaturePath, 70, 56, "Cut"); break;
                   // FileHelper.MakeThumbnail(Path + @"UploadPic\y\" + picTitle, Path + @"UploadPic\y\" + MiniaturePath, 70, 56, "Cut"); break;
            }

        }
        else
        {
            RegisterStartupScript("alertMessage", "<script>alert('请选择上传的图片!');</script>"); 
        }

        if (picTitle != "")
        {

            Tz888.Model.TPPicture TPPicModel = new Tz888.Model.TPPicture();
            TPPicModel.infoID = Convert.ToInt64(Request.QueryString["id"].ToString());
            TPPicModel.Title = this.txtTitle.Value.Trim();
            TPPicModel.publishT = System.DateTime.Now;
            TPPicModel.Descript = "";
            TPPicModel.InfoCode = "Images";
            TPPicModel.infotypeID = "Images";
            //TPPicModel.LoginName = "y";
            TPPicModel.LoginName = Page.User.Identity.Name.ToString();
            TPPicModel.subTitle = this.txtTitle.Value.Trim();
            TPPicModel.HtmlURL = "UploadPic/" + TPPicModel.LoginName + "/" + picTitle;
            TPPicModel.MiniatureUrl = "UploadPic/" + TPPicModel.LoginName + "/" + MiniaturePath;
            TPPicModel.Author = "";
            TPPicModel.Origin = this.hidradioType.Value.Trim();
            TPPicModel.Content = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtContent.Value.Trim());
            TPPicModel.ProvinceID = this.ZoneSelectControl1.ProvinceID.Trim();
            TPPicModel.CityID = this.ZoneSelectControl1.CityID.Trim();
            TPPicModel.CountyID = this.ZoneSelectControl1.CountyID.Trim();
            TPPicModel.IsRedirect = 0;
            TPPicModel.RedirectUrl = "";
            TPPicModel.Created = System.DateTime.Now;
            TPPicModel.Createby = TPPicModel.LoginName;
            TPPicModel.strRemark = "";
            TPPicModel.Summary = "";
            TPPicModel.KeyWord = this.txtKeyWord.Value.Trim();
            TPPicModel.AuditingRemark = "";

            Tz888.SQLServerDAL.TPPicture tpm = new Tz888.SQLServerDAL.TPPicture();
            bool infoID = tpm.UpdatePicMess(TPPicModel);
            if (infoID == true)
            {

                Response.Redirect("PictureAudit.aspx");
            }
            else
            {
                Response.Write("<script>alert('更新失败!'); </script>");
            }

        }
    }
}
