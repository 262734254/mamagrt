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

public partial class PublishVideo : System.Web.UI.Page
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
            //ViewState["strSavePath"] = "UploadVideo/huangleon/";
            ViewState["strSavePath"] = "UploadVideo/" + Page.User.Identity.Name.ToString() + "/";
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
        //string result = Tz888.Common.FileHelper.UploadLargeFile(Telerik.WebControls.RadUploadContext.Current, "huangleon", dt, ".wmv,.rm", 20480000);
        string result = Tz888.Common.FileHelper.UploadLargeFile(Telerik.WebControls.RadUploadContext.Current, Page.User.Identity.Name.ToString(), dt, ".wmv,.rm", 200000000);
        switch (result)
        {
            case "1": Response.Write("<script>alert('文件超过指定大小');location.href='PublishVideo.aspx';</script>"); Response.End(); break;
            case "2": Response.Write("<script>alert('只允许上传.wmv,.rm类型的文件');location.href='PublishVideo.aspx';</script>"); Response.End(); break;
            case "3": Response.Write("<script>alert('未上传成功');location.href='PublishVideo.aspx';</script>"); Response.End(); break;
        }
        if (result != "")
        {

            Tz888.Model.TPVideo TPVideoModel = new Tz888.Model.TPVideo();
            TPVideoModel.infoID = 0;
            TPVideoModel.Title = this.txtTitle.Value.Trim();
            TPVideoModel.publishT = System.DateTime.Now;
            TPVideoModel.Hit = 0;
            TPVideoModel.Descript = "";
            TPVideoModel.InfoCode = "Video";
            TPVideoModel.infotypeID = "Video";
            //TPVideoModel.LoginName = "huangleon";
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
            TPVideoModel.Createby = TPVideoModel.LoginName;
            TPVideoModel.strRemark = "";
            TPVideoModel.Summary = "";
            TPVideoModel.KeyWord = this.txtKeyWord.Value.Trim();
            TPVideoModel.IsCore = 0;
            TPVideoModel.AuditingStatus = 0;

            Tz888.SQLServerDAL.TPVideo tpm = new Tz888.SQLServerDAL.TPVideo();
            bool infoID = tpm.InsertVideoMess(TPVideoModel);
            if (infoID == true)
            {

                Response.Redirect("VideoSuccess.aspx");
            }
            else
            {
                RegisterStartupScript("alertMessage", "<script>alert('发布失败!'); </script>");
            }
        }
    }
}
