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

public partial class Register_p_upload_picture : System.Web.UI.Page
{
    private string _userName;
    private int _uploadPicID;
    private string _loadPicJsObjID;
    private string _infoType;

    private string _parentIframe = "iframe1";

    public string ParentIframe
    {
        get { return _parentIframe; }
        set { _parentIframe = value; }
    }

    /// <summary>
    /// 信息类型
    /// </summary>
    public string InfoType
    {
        get { return _infoType; }
        set { _infoType = value; }
    }

    /// <summary>
    /// 图片上传控件的ID,用于JavaScript调用
    /// </summary>
    public int UploadPicID
    {
        get { return _uploadPicID; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.Page.IsPostBack)
        {
            if (this.Page.Request.QueryString["id"] != null)
                this._uploadPicID = Convert.ToInt32(Request.QueryString["id"]);
            if (this.Page.Request.QueryString["u"] != null)
                this._userName = Convert.ToString(Request.QueryString["u"]);
            if (this.Page.Request.QueryString["obj"] != null)
                this._loadPicJsObjID = Convert.ToString(Request.QueryString["obj"]);
            if (this.Page.Request.QueryString["type"] != null)
                this._infoType = Convert.ToString(Request.QueryString["type"]);
            else
                this._infoType = "Default";

            if (this.Page.Request.QueryString["frm"] != null)
                this._parentIframe = Convert.ToString(Request.QueryString["frm"]);

            this.ViewState["ID"] = this._uploadPicID;
            this.ViewState["UserName"] = this._userName;
            this.ViewState["JsObj"] = this._loadPicJsObjID;
            this.ViewState["InfoType"] = this._infoType;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!Tz888.Common.FileManage.IsAllowedExtension(this.fileUpload, "UploadImageType"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('图片须为jpg或gif格式，大小不超过500k！')");
            return;
        }
        if (Tz888.Common.FileManage.IsAllowedLength(this.fileUpload, "UploadImageMaxLength"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('图片须为jpg或gif格式，大小不超过500k！')");
            return;
        }

        if (this.ViewState["JsObj"] != null)
            this._loadPicJsObjID = this.ViewState["JsObj"].ToString();
        if (this.ViewState["ID"] != null)
            this._uploadPicID = Convert.ToInt32(this.ViewState["ID"]);
        if (this.ViewState["InfoType"] != null)
            this._infoType = this.ViewState["InfoType"].ToString();

        string UploadPath = Tz888.Common.Common.GetUploadFilePath("Image", this._infoType, false);
        //上传图片至服务器,返回保存的图片相对路径名称
        string NewFilePath = FileManage.SaveFile(this.fileUpload, UploadPath, false);

        NewFilePath = NewFilePath.Replace("\\", "/");
        string desc = this.txtImgDesc.Value;
        string FileDomain = Tz888.Common.Common.GetFileServerURL();
        //上传操作完成,返回
        Tz888.Common.MessageBox.ResponseScript(this.Page, "parent." + this._loadPicJsObjID + ".showloadPic('" + FileDomain + "/','" + NewFilePath + "','" + this._uploadPicID.ToString() + "','" + desc + "')");
    }
}
