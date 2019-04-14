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

public partial class Member_p_upload_file : System.Web.UI.Page
{
    private int _id;
    private long _infoid;
    private string _parentIframe = "iframe1";

    public string ParentIframe
    {
        get { return _parentIframe; }
        set { _parentIframe = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.Request.QueryString["id"] == null || this.Page.Request.QueryString["code"] == null || this.Page.Request.QueryString["frm"] == null)
        {
            Response.End();
        }
        this._id = Convert.ToInt32(Request.QueryString["id"]);
        this._infoid = Convert.ToInt64(Request.QueryString["code"]);
        this._parentIframe = Convert.ToString(Request.QueryString["frm"]);

        this.ViewState["ID"] = this._id;
        this.ViewState["InfoID"] = this._infoid;

        if (this._infoid == -1)
        {
            this.plupload.Visible = true;
            this.pldisplay.Visible = false;
        }
        else
        {
            this.plupload.Visible = false;
            this.pldisplay.Visible = true;
        }
    }
    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (!IsAllowedExtension(this.fileuploadothers, "UploadImageType"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('文件类型不允许上传!')");
            return;
        }
        if (IsAllowedLength(this.fileuploadothers, "UploadImageMaxLength"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('文件大小超出限制!')");
            return;
        }

        //if (this.ViewState["JsObj"] != null)
        //    this._loadFileObjID = this.ViewState["JsObj"].ToString();
        //if (this.ViewState["ID"] != null)
        //    this._uploadFileID = Convert.ToInt32(this.ViewState["ID"]);
        //if (this.ViewState["InfoType"] != null)
        //    this._fileType = this.ViewState["InfoType"].ToString();

        //string UploadPath = Tz888.Common.Common.GetTmpUploadFilePath("Image", this._fileType, false);
        ////上传图片至服务器,返回保存的图片相对路径名称
        //string FullFilePath = FileManage.SaveFile(this.fileuploadothers, UploadPath, false);
        //string NewPath = FullFilePath;
        //NewPath = NewPath.Replace("\\", "/");

        //string desc = this.txtImgDesc.Value;
        //string FileDomain = Tz888.Common.Common.GetMemberDomain();
        ////上传操作完成,返回
        //Tz888.Common.MessageBox.ResponseScript(this.Page, "parent." + this._loadPicJsObjID + ".showloadPic('" + FileDomain + "/','" + NewPath + "','" + this._uploadPicID.ToString() + "','" + desc + "')");
    }
    protected void lblDisplay_Click(object sender, EventArgs e)
    {

    }
    protected void lblUpdate_Click(object sender, EventArgs e)
    {

    }
    protected void lblDelete_Click(object sender, EventArgs e)
    {

    }
    #region 检查文件类型是否允许上传
    ///<summary>
    ///检查文件类型是否允许上传
    ///</summary>
    public static bool IsAllowedExtension(HtmlInputFile Controls, string ConfigNodeName)
    {
        string FileExtension = "";
        string[] FileConfig = ConfigurationManager.AppSettings[ConfigNodeName].ToString().Split('|');

        if (!string.IsNullOrEmpty(Controls.PostedFile.FileName))
        {
            FileExtension = Controls.PostedFile.FileName.ToLower();
            FileExtension = FileExtension.Substring(FileExtension.LastIndexOf('.'));
            for (int i = 0; i < FileConfig.Length; i++)
            {
                if (FileExtension.Equals(FileConfig[i]))
                {
                    return true;
                }
            }
        }
        return false;
    }

    #endregion

    #region 判断上传文件大小是否超过设置的最大值
    /// <summary>
    /// 判断上传文件大小是否超过设置的最大值
    /// </summary>
    public static bool IsAllowedLength(HtmlInputFile Controls, string ConfigNodeName)
    {
        int MaxLength = 1000;
        try
        {
            MaxLength = Convert.ToInt32(ConfigurationManager.AppSettings[ConfigNodeName]);
        }
        catch
        {
            MaxLength = 100;
        }

        MaxLength = MaxLength * 1024;

        if (Controls.PostedFile.ContentLength > MaxLength)
        {
            return true;
        }
        return false;
    }

    #endregion
}
