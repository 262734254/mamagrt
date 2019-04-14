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
        if (!IsAllowedExtension(this.fileUpload, "UploadFileType"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('文件类型不允许上传!')");
            return;
        }
        if (IsAllowedLength(this.fileUpload, "UploadImageMaxLength"))
        {
            MessageBox.ResponseScript(this.Page, "showErrMsg('文件大小超出限制!')");
            return;
        }

        if (this.ViewState["JsObj"] != null)
            this._loadPicJsObjID = this.ViewState["JsObj"].ToString();
        if (this.ViewState["ID"] != null)
            this._uploadPicID = Convert.ToInt32(this.ViewState["ID"]);
        if(this.ViewState["InfoType"] != null)
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
