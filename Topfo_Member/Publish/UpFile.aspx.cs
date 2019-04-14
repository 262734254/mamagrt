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

public partial class Publish_UpFile : System.Web.UI.Page
{
    public long _infoid;
    public string infotype;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnUp.Attributes.Add("onclick", "return chkpost();");
        if (Request.QueryString["InfoID"]!=null)
            _infoid =Convert.ToInt64(Request.QueryString["InfoID"].ToString());
        if (Request.QueryString["InfoType"] != null)
            infotype = Request.QueryString["InfoType"].ToString();
    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        string filename = "";
        if (GetExtension().ToLower() == ".jpg" || GetExtension().ToLower() == ".bmp" || GetExtension().ToLower() == ".gif")//上传图片
        {
            int MaxLength = 500;
            if (this.FileUpload1.PostedFile.ContentLength > MaxLength * 1024)
            {
                Tz888.Common.MessageBox.ResponseScript(this.Page, "alert('图片文件应小于500k')");
                return;
            }
            else
            {
                Save("Image");
            }
        }
        if (GetExtension().ToLower() == ".doc" || GetExtension().ToLower() == ".ppt" || GetExtension().ToLower() == ".pdf")//上传文件
        {
            int MaxLength = 2000;
            if (this.FileUpload1.PostedFile.ContentLength > MaxLength * 1024)
            {
                Tz888.Common.MessageBox.ResponseScript(this.Page, "alert('文件应小于2M')");
                return;
            }
            else
            {
                Save("Doc");
            }
        }
        else
        {
            Tz888.Common.MessageBox.ResponseScript(this.Page, "alert('文件格式应为:.|jpg|.bmp|.gif|.doc|.ppt|.pdf')");
            return;
        }
    }
    
    public void Save(string filetype)
    {
        string _filetype="1";
        if (filetype == "Image")
        {   
            _filetype="1";
        }
        if (filetype == "Doc")
        {
            _filetype="2";
        }
        //string ServerPath = System.Configuration.ConfigurationManager.AppSettings["FileServerPath"];
        string newpath = Tz888.Common.Common.GetUploadFilePath(filetype, this.infotype, false);
        string filename =Tz888.Common. FileManage.SaveFile(this.FileUpload1, newpath, false);
        AddRes(filename, _filetype);
    }
    public void AddRes(string filename, string filetype)
    {
        Tz888.Model.Info.InfoResourceModel model = new Tz888.Model.Info.InfoResourceModel();
        Tz888.BLL.Info.InfoResourceBLL dal = new Tz888.BLL.Info.InfoResourceBLL();
        model.InfoID = _infoid;
        model.ResourceAddr = filename;
        model.ResourceName = infotype.Trim();
        model.ResourceTitle = txtFileName.Value.Trim();
        model.ResourceType = Convert.ToInt32(filetype);
        model.UpDate = DateTime.Now;
        model.IsDel = false;
        long i = dal.Insert(model);
        if (i > 0)
        {
            Tz888.Common.MessageBox.ResponseScript(this.Page, "alert('上传成功..');parent.init();parent.Lock_CheckForm();");
        }
        else
        {
            Tz888.Common.MessageBox.ResponseScript(this.Page, "alert('上传失败..')");
        }
    }
    public string  GetExtension()
    {
        string FileExtension = "";
        if (!string.IsNullOrEmpty(this.FileUpload1.PostedFile.FileName))
        {
            FileExtension = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
        }
        return FileExtension;
    }
}
