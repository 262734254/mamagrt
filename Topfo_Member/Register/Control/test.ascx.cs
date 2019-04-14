
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections;
using System.IO;
using System.Configuration;
using Tz888.BLL.Register;

public partial class Register_Control_test : System.Web.UI.UserControl
{
    #region Field

    private string m_FileType = ".jpg|.jpeg|.jpe|.gif|.png";//用"|"隔开的文件后缀名

    private ArrayList m_ErrorMsg = new ArrayList();
    private bool m_IsCreateThumbnailImages = false;//是否创造缩略图
    private int m_MaxPics = 1;//最大允许上传文件数
    private int m_ImgHeight = 100;
    private string m_ImgWidth = "100";
    //private ArrayList m_InitFiles = new ArrayList();
    private int m_UploadedCount = 0;//已经上传的文件数
    private string m_buttonName = "";
    private string _isUp = "1";//是否有上传按钮
    private string _isCancel = "0";//是否有取消按钮

    private string m_img = "";
    private string m_infoType = "";//上传图片类型 文件夹名称       

    /// <summary>
    /// 已经上传的文件数
    /// </summary>
    public int UploadedCount
    {
        get
        {
            return m_UploadedCount;
        }

    }
    public string IsCancel
    {
        get
        {
            return _isCancel;
        }
        set
        {
            _isCancel = value;
        }

    }
    public int ImgHeight
    {
        get
        {
            return m_ImgHeight;
        }
        set
        {
            m_ImgHeight = value;
        }

    }
    public string ImgWidth
    {
        get
        {
            return m_ImgWidth;
        }
        set
        {
            m_ImgWidth = value;
        }
    }
    public string InfoType
    {
        get
        {
            return m_infoType;
        }
        set
        {
            m_infoType = value;
        }

    }

    public string IsUp
    {
        get
        {
            return _isUp;
        }
        set
        {
            _isUp = value;
        }

    }
    public string ButtonName
    {
        get
        {
            return m_buttonName;
        }
        set
        {
            m_buttonName = value;
        }

    }
    public string Img
    {
        get
        {
            return m_img;
        }
        set
        {
            m_img = value;
        }

    }
    public ArrayList InitFiles
    {
        set
        {
            string strTmp = @"<span id=""{0}"" align=""center"" style=""width:{6}px;height:{5}px;margin-right:10px; margin-bottom:10px"" ><a href=""{1}"" target=""_blank""><img id=""{2}"" width=""{6}"" height=""{4}"" src=""{1}"" border=""0""  /></a><input type=""button"" onclick=""{7}removeFile('{0}','{3}');"" value=""删除"" style=""border:solid; border-width:1px"" /></span>";

            string imageRoot = common.GetImageDomain();

            string fileList = "";
            StringBuilder sb = new StringBuilder();
            ArrayList initFiles = value;
            for (int i = 0; i < initFiles.Count; i++)
            {
                string fileName = (string)initFiles[i];
                if (fileName.Trim() != "")
                {
                    fileName = fileName.Replace("\\", "/");
                    sb.Append(String.Format(strTmp, "divFile" + i.ToString(), imageRoot + fileName, "fileChecker" + i.ToString(), fileName, m_ImgHeight, m_ImgHeight + 20, m_ImgWidth, this.ClientID + "_uploader."));
                    m_UploadedCount++;
                    fileList += "|" + fileName;
                }
            }
            if (fileList.Length > 0)
            {
                fileList = fileList.Remove(0, 1);
            }
            initFileList.Value = fileList;
            divInitFile.InnerHtml = sb.ToString();//+ UploadFiles.InnerHtml;
        }
    }
    /// <summary>
    /// 错误信息
    /// </summary>
    public ArrayList ErrorMsg
    {
        get
        {
            return m_ErrorMsg;
        }
    }
    /// <summary>
    /// 允许的文件类型

    /// </summary>
    public string FileType
    {
        get
        {
            return m_FileType;
        }
        set
        {
            if (value != "")
            {
                m_FileType = value;
            }
        }
    }
    /// <summary>
    /// 是否创建缩略图

    /// </summary>
    public bool IsCreateThumbnailImages
    {
        get
        {
            return m_IsCreateThumbnailImages;
        }
        set
        {

            m_IsCreateThumbnailImages = value;

        }
    }
    /// <summary>
    /// 上传的最大图片数
    /// </summary>
    public int MaxPics
    {
        get
        {
            return m_MaxPics;
        }
        set
        {
            if (value > 0 && value < 20)
            {
                m_MaxPics = value;
            }

        }
    }
    #endregion

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            int imageContentLength = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ImageContentLength"]);
            hfMaxFile.Value = imageContentLength.ToString();
        }

        Control parent = this.Parent;
        HtmlForm form = parent as HtmlForm;
        while (form == null && parent != null)
        {
            parent = parent.Parent;
            form = parent as HtmlForm;
        }
        if (form != null)
        {
            form.Attributes.Add("enctype", "multipart/form-data");
        }
        else
        {
            throw new Exception("上传用户控件FileUploader没有包含在Form内,或者Form没有runat=\"server\"属性.");
        }
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。

        //
        InitializeComponent();
        base.OnInit(e);

    }

    /// <summary>
    ///		设计器支持所需的方法 - 不要使用代码编辑器

    ///		修改此方法的内容。

    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion
    /// <summary>
    /// 保存上传的图片

    /// </summary>
    /// <param name="infoType">信息类型ID</param>
    /// <returns></returns>
    public string[] SaveImages(string infoType)
    {
        string uploadDir = common.GetUploadPath(infoType, true);//保存位置
        return SaveImagesToDst(uploadDir);
    }
    /// <summary>
    /// 保存上传的图片
    /// </summary>
    /// <param name="uploadDir">要保存的路径</param>
    /// <returns></returns>
    public string[] SaveImagesToDst(string uploadDir)
    {
        ArrayList savedFileName = new ArrayList();//保存的文件名
        int savedFileCount = 0;//成功保存的文件数
        //string uploadDir = common.GetUploadPath(infoType,true);//保存位置
        string rootPath = common.GetUploadRootPath();//图片域名的物理目录

        string[] deletedFileStrList = deletedFileList.Value.Split(new char[] { '|' });
        string[] initFileStrList = initFileList.Value.Split(new char[] { '|' });
        for (int i = 0; i < deletedFileStrList.Length; i++)
        {
            if (deletedFileStrList[i] != "")
            {
                for (int j = 0; j < initFileStrList.Length; j++)
                {
                    if (deletedFileStrList[i] == initFileStrList[j])
                    {
                        if (DeleteImage(rootPath + deletedFileStrList[i]))
                        {
                            initFileStrList[j] = "";
                            break;
                        }
                    }
                }
            }
        }
        for (int j = 0; j < initFileStrList.Length; j++)
        {
            if (initFileStrList[j] != "")
            {
                savedFileName.Add(initFileStrList[j]);
            }
        }
        HttpFileCollection allFiles = HttpContext.Current.Request.Files;
        ArrayList files = new ArrayList();
        foreach (string key in allFiles.Keys)
        {
            if (key.StartsWith(this.ClientID))
            {

                files.Add(allFiles[key]);
            }
        }
        for (int i = 0; i < files.Count; i++)
        {
            HttpPostedFile postedFile = files[i] as HttpPostedFile;

            //检查文件是否符合要求

            if (CheckPostedFile(postedFile) == false)
            {
                continue;
            }
            //保存图像及缩略图
            //公司资料页面 EnterpriseRegisterResult.aspx（228, 120）

            string fileFullName = UploadFileWithThumbnail(postedFile, uploadDir, m_IsCreateThumbnailImages, 120, 120, 40);
            savedFileName.Add(fileFullName.Replace(rootPath, ""));//将图片域名的物理路径替换
            savedFileCount++;
        }
        string[] tmpFiles = new string[savedFileName.Count];
        savedFileName.CopyTo(tmpFiles);
        return tmpFiles;
    }
    /// <summary>
    /// 检查文件是否符合要求

    /// </summary>
    /// <param name="postedFile"></param>
    /// <returns></returns>
    private bool CheckPostedFile(HttpPostedFile postedFile)
    {

        string fileName = postedFile.FileName;

        if (fileName == "")
        {
            //没有上传图片
            //m_ErrorMsg.Add("文件名为空。");
            return false;
        }
        //检查文件长度是否为0
        long contentLen = postedFile.ContentLength;
        if (contentLen == 0)
        {
            m_ErrorMsg.Add(fileName + "文件内容为空。");
            return false;
        }
        string extType = Path.GetExtension(fileName).ToLower();
        if (m_FileType.IndexOf(extType) >= 0) //if (extType == ".gif" || extType == ".jpg"  || extType == ".png")
        {
            int imageContentLength = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["ImageContentLength"]); //文件要求的大小

            if (contentLen < (imageContentLength * 1024))
            {
                return true;
            }
            else
            {
                //文件过大
                m_ErrorMsg.Add(fileName + "文件超过" + imageContentLength + "KB限制。");
                return false;
            }
        }
        else
        {
            //文件类型不符合要求

            m_ErrorMsg.Add(fileName + "文件类型不是" + m_FileType);
            return false;
        }
    }

    /// <summary>
    /// 删除图片文件
    /// </summary>
    /// <param name="fileFullPath">图片文件全路径</param>
    /// <returns></returns>
    private bool DeleteImage(string fileFullPath)
    {
        string tmpFileNameMin = "";
        if (fileFullPath != "")
        {
            try
            {
                //tmpFileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                if (File.Exists(fileFullPath))
                {
                    File.Delete(fileFullPath);
                }
                tmpFileNameMin = fileFullPath.Insert(fileFullPath.LastIndexOf("."), "_s");
                if (File.Exists(tmpFileNameMin))
                {
                    File.Delete(tmpFileNameMin);
                }
            }
            catch
            {
                return false;
            }


        }
        return true;

    }
    private string UploadFileWithThumbnail(HttpPostedFile postedFile, string uploadDir,
        bool isCreateThumbnailImages, int width, int height, int quality)
    {
        //保证控件存在[没有使用转向链接]]时获得文件名
        string fileName = postedFile.FileName;
        string extType = Path.GetExtension(fileName);

        //可以上传
        bool isFileExist = true;
        string fileFullName = "";
        string uploadFileName = "";
        while (isFileExist)
        {
            uploadFileName = common.CreatePicName();
            fileFullName = uploadDir + uploadFileName + extType;
            isFileExist = File.Exists(fileFullName);
        }
        postedFile.SaveAs(fileFullName);


        if (isCreateThumbnailImages)	//生成缩略图片
        {
            string originPicName = uploadFileName + extType;
            string minPicName = uploadFileName + "_s" + extType;
            string serverMinPath = uploadDir + uploadFileName + "_s" + extType;
            ToThumbnailImages(fileFullName, serverMinPath, width, height, quality);
        }

        return fileFullName;

    }

    /// <summary>
    /// 获取图像编码解码器的所有相关信息

    /// </summary>
    /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
    /// <returns>返回图像编码解码器的所有相关信息</returns>
    private ImageCodecInfo GetCodecInfo(string mimeType)
    {
        ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
        foreach (ImageCodecInfo ici in CodecInfo)
        {
            if (ici.MimeType == mimeType) return ici;
        }
        return null;
    }

    /// <summary>
    /// 保存图片
    /// </summary>
    /// <param name="image">Image 对象</param>
    /// <param name="savePath">保存路径</param>
    /// <param name="ici">指定格式的编解码参数</param>
    private void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici, int Quality)
    {
        //设置 原图片 对象的 EncoderParameters 对象
        EncoderParameters parameters = new EncoderParameters(1);
        parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
        image.Save(savePath, ici, parameters);
        parameters.Dispose();
    }

    /// <summary>
    /// 生成缩略图

    /// </summary>
    /// <param name="sourceImagePath">原图片路径(相对路径)</param>
    /// <param name="thumbnailImagePath">生成的缩略图路径,如果为空则保存为原图片路径(相对路径)</param>
    /// <param name="thumbnailImageWidth">缩略图的宽度</param>
    /// <param name="thumbnailImageHeight">缩略图的高度</param>
    private void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, int Quality)
    {
        Hashtable htmimes = new Hashtable();
        htmimes[".jpe"] = "image/jpeg";
        htmimes[".jpeg"] = "image/jpeg";
        htmimes[".jpg"] = "image/jpeg";
        htmimes[".png"] = "image/png";
        htmimes[".tif"] = "image/tiff";
        htmimes[".tiff"] = "image/tiff";
        htmimes[".bmp"] = "image/bmp";
        htmimes[".gif"] = "image/gif";

        string SourceImagePath = sourceImagePath;
        string ThumbnailImagePath = thumbnailImagePath;
        int ThumbnailImageWidth = thumbnailImageWidth;
        string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
        if (SourceImagePath.ToString() == System.String.Empty) throw new NullReferenceException("SourceImagePath is null!");

        //从 原图片 创建 Image 对象
        System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);

        if ((ThumbnailImageWidth < 1) || (thumbnailImageHeight < 1))
        {
            return;
        }
        //用指定的大小和格式初始化 Bitmap 类的新实例

        Bitmap bitmap = new Bitmap(ThumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
        //从指定的 Image 对象创建新 Graphics 对象
        Graphics graphics = Graphics.FromImage(bitmap);
        //清除整个绘图面并以透明背景色填充

        graphics.Clear(Color.Transparent);
        //在指定位置并且按指定大小绘制 原图片 对象
        graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, thumbnailImageHeight));
        image.Dispose();
        try
        {
            //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件	
            string savepath = (ThumbnailImagePath == null ? SourceImagePath : ThumbnailImagePath);
            SaveImage(bitmap, savepath, GetCodecInfo((string)htmimes[sExt]), Quality);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            bitmap.Dispose();
            graphics.Dispose();
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Tz888.SQLServerDAL.MemberResourceDAL objSendImage = new Tz888.SQLServerDAL.MemberResourceDAL();
            Tz888.Model.MemberResourceModel ResourceModel = new Tz888.Model.MemberResourceModel();
            //保存上传图片
            string[] UploadImgFileName = SaveImages(this.InfoType);
            string Pic1 = "";
            if (UploadImgFileName.Length > 0)
            {
                Pic1 = UploadImgFileName[0];

                //图片加载
                this.Img = Tz888.Common.Common.GetImageDomain() + "/" + Pic1;
                // ConfigurationManager.AppSettings["ImageDomain"].ToString() 
                this.ButtonName = "";

                //图片上传
                ResourceModel.ResourceID = 0;
                ResourceModel.LoginName = Page.User.Identity.Name;
                ResourceModel.ResourceName = "登记介绍";
                ResourceModel.ResourceTitle = "登记介绍";
                ResourceModel.ResourceDescrib = "登记介绍";
                ResourceModel.ResourceType = 1;
                ResourceModel.ResourceAddr = Pic1;
                ResourceModel.ResourceProperty = 0;
                ResourceModel.ResourcePassword = null;// Convert.ToByte("");
                ResourceModel.UpDate = DateTime.Now;
                ResourceModel.IsDel = false;
                ResourceModel.remark = "Result.aspx页面添加";

                objSendImage.AddFromResult(ResourceModel);
                Tz888.Common.MessageBox.Show(this.Page, "上传成功！");
            }
        }
        catch { }
    }
}
