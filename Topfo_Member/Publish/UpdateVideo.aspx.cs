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

public partial class UpdateVideo : System.Web.UI.Page
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

            //ViewState["strSavePath"] = "UploadVideo/y/";
            ViewState["strSavePath"] = "UploadVideo/" + Page.User.Identity.Name + "/";
            try
            {
                Tz888.SQLServerDAL.TPVideo objtp = new Tz888.SQLServerDAL.TPVideo();
                string infoid = Request.QueryString["id"].ToString();
                DataSet ds = objtp.GetOneVideoMess(infoid);
                this.txtTitle.Value = ds.Tables[0].Rows[0]["subTitle"].ToString();
                this.txtContent.Value = Tz888.Common.Utility.PageValidate.HtmlToTxt(ds.Tables[0].Rows[0]["Content"].ToString());
                this.txtAuthor.Value = ds.Tables[0].Rows[0]["Author"].ToString();
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
                Response.Write("<script>alert('请重新选择要修改的数据!'); window.close();</script>");  
            }
        }
        this.BtnAddVideo.Attributes.Add("onclick", "return chkInput();");
    }
    protected void BtnAddVideo_Click(object sender, EventArgs e)
    { 
        if (!this.chkYes.Checked)
        {
            RegisterStartupScript("alertMessage", "<script>alert('请确认你的文件符合Topfo的上传条款,请勾上最下方复选框!'); </script>");
            return;
        }
        DateTime dt = DateTime.Now;
        //string result = Tz888.Common.FileHelper.UploadLargeFile(Telerik.WebControls.RadUploadContext.Current, "y", dt, ".wmv,.rm", 20480000);
        string result = Tz888.Common.FileHelper.UploadLargeFile(Telerik.WebControls.RadUploadContext.Current, Page.User.Identity.Name.ToString(), dt, ".wmv,.rm", 20480000);
        switch (result)
        {
            case "1": Response.Write("<script>alert('文件超过指定大小');location.href='UpdateVideo.aspx';</script>"); Response.End(); break;
            case "2": Response.Write("<script>alert('只允许上传.wmv,.rm类型的文件');location.href='UpdateVideo.aspx';</script>"); Response.End(); break;
            case "3": Response.Write("<script>alert('未上传成功');location.href='UpdateVideo.aspx';</script>"); Response.End(); break;
        }
        if (result != "")
        {

            Tz888.Model.TPVideo TPVideoModel = new Tz888.Model.TPVideo();
            TPVideoModel.infoID = Convert.ToInt64(Request.QueryString["id"].ToString());
            TPVideoModel.Title = this.txtTitle.Value.Trim();
            TPVideoModel.publishT = System.DateTime.Now;
            TPVideoModel.Descript = "";
            TPVideoModel.InfoCode = "Video";
            TPVideoModel.infotypeID = "Video";
            TPVideoModel.LoginName = Page.User.Identity.Name.ToString();
            TPVideoModel.subTitle = this.txtTitle.Value.Trim();
            TPVideoModel.HtmlURL = ViewState["strSavePath"].ToString() + result;
            TPVideoModel.MiniatureUrl = ViewState["strSavePath"].ToString() + result.Substring(0, result.IndexOf(".", 0)) + ".jpg";
            TPVideoModel.Author = this.txtAuthor.Value.Trim();
            if (this.txtAuthor.Value.Trim() == "请填写该视频的版权所有者")
            {
                TPVideoModel.Author = "";
            }
            TPVideoModel.Origin = this.hidradioType.Value.Trim();
            TPVideoModel.Content = Tz888.Common.Utility.PageValidate.TxtToHtml(this.txtContent.Value.Trim());
            TPVideoModel.ProvinceID = this.ZoneSelectControl1.ProvinceID.Trim();
            TPVideoModel.CityID = this.ZoneSelectControl1.CityID.Trim();
            TPVideoModel.CountyID = this.ZoneSelectControl1.CountyID.Trim();
            TPVideoModel.IsRedirect = 0;
            TPVideoModel.RedirectUrl = "";
            TPVideoModel.Created = System.DateTime.Now;
            TPVideoModel.Createby = Page.User.Identity.Name.ToString();
            TPVideoModel.strRemark = "";
            TPVideoModel.Summary = "";
            TPVideoModel.KeyWord = this.txtKeyWord.Value.Trim();
            TPVideoModel.AuditingRemark = "";

            Tz888.SQLServerDAL.TPVideo tpm = new Tz888.SQLServerDAL.TPVideo();
            bool infoID = tpm.UpdateVideoMess(TPVideoModel);
            if (infoID == true)
            {

                Response.Redirect("VideoSuccess.aspx");
            }
            else
            {
                RegisterStartupScript("alertMessage", "<script>alert('更新失败!'); </script>");
            }
        }
    }
}
