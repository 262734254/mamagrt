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
    private string _userName;
    private int _uploadFileID;
    private string _loadFileObjID;
    private string _fileType = "";
    private string _parentIframe = "iframe1";

    public string ParentIframe
    {
        get { return _parentIframe; }
        set { _parentIframe = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Page.Request.QueryString["id"] != null)
            this._uploadFileID = Convert.ToInt32(Request.QueryString["id"]);
        if (this.Page.Request.QueryString["u"] != null)
            this._userName = Convert.ToString(Request.QueryString["u"]);
        if (this.Page.Request.QueryString["obj"] != null)
            this._loadFileObjID = Convert.ToString(Request.QueryString["obj"]);
        if (this.Page.Request.QueryString["type"] != null)
            this._fileType = Convert.ToString(Request.QueryString["type"]);
        if (this.Page.Request.QueryString["frm"] != null)
            this._parentIframe = Convert.ToString(Request.QueryString["frm"]);

        else
            this._fileType = "File";

        this.ViewState["ID"] = this._uploadFileID;
        this.ViewState["UserName"] = this._userName;
        this.ViewState["JsObj"] = this._loadFileObjID;
        this.ViewState["FileType"] = this._fileType;
    }
    protected void btnSubmit_ServerClick(object sender, EventArgs e)
    {
        if (!Tz888.Common.FileManage.IsAllowedExtension(this.fileuploadothers, "UploadImageType"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('文件类型不允许上传!')");
            return;
        }
        if (Tz888.Common.FileManage.IsAllowedLength(this.fileuploadothers, "UploadImageMaxLength"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('文件大小超出限制!')");
            return;
        }

        if (this.ViewState["JsObj"] != null)
            this._loadFileObjID = this.ViewState["JsObj"].ToString();
        if (this.ViewState["ID"] != null)
            this._uploadFileID = Convert.ToInt32(this.ViewState["ID"]);
        if (this.ViewState["InfoType"] != null)
            this._fileType = this.ViewState["InfoType"].ToString();

        string UploadPath = Tz888.Common.Common.GetTmpUploadFilePath("Image", this._fileType, false);
        //上传图片至服务器,返回保存的图片相对路径名称
        string FullFilePath = FileManage.SaveFile(this.fileuploadothers, UploadPath, false);
        //string NewPath = FullFilePath;
        //NewPath = NewPath.Replace("\\", "/");

        //string desc = this.txtImgDesc.Value;
        //string FileDomain = Tz888.Common.Common.GetMemberDomain();
        ////上传操作完成,返回
        //Tz888.Common.MessageBox.ResponseScript(this.Page, "parent." + this._loadPicJsObjID + ".showloadPic('" + FileDomain + "/','" + NewPath + "','" + this._uploadPicID.ToString() + "','" + desc + "')");
    }
}
