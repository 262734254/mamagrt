using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Register;
using Tz888.Model.Register;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Register
{
    public class common
    {
        private static readonly Tz888.IDAL.Register.common  dal = DataAccess.CreateCommmonObj();
        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <returns>联系人列表</returns>
        public List<Tz888.Model.Register.OrgContactMan> GetOrgContactMan(string LoginName)
        {
            return dal.GetOrgContactMan(LoginName);
        }

        //添加联系人
        public void AddOrgContect(OrgContactModel orgModel)
        {
            dal.AddOrgContect(orgModel);
        }
        /// <summary>
        /// 获取图片资源列表
        /// </summary>
        /// <returns>图片资源</returns>
        public List<Tz888.Model.MemberResourceModel> GetMemberResourceModel(string LoginName, int ResourceProperty)
        {
            return dal.GetMemberResourceModel(LoginName, ResourceProperty);
        }


        //默认联系人（注册会员人）
        public Tz888.Model.Register.OrgContactModel getContactModel(string LoginName)
        {
            return dal.getContactModel(LoginName);
        }

      
        //审核登记
        public int AuditOrg(Tz888.Model.Register.OrgAuditModel model)
        {
            return dal.AuditOrg(model);
        }

        //会员信息修改时 添加登记默认联系人
        public long OrgContactMan_FromMemberMessage(Tz888.Model.Register.OrgContactModel model)
        {
            return dal.OrgContactMan_FromMemberMessage(model);
        }

        #region  网上展厅申请
        //添加
        public int AddSelfCreateWebInfo(string loginName, string domain)
        {
            return dal.AddSelfCreateWebInfo(loginName, domain);
        }
        //修改
        public int UpdateSelfCreateWebInfo(int webId, string loginName, string domain)
        {
            return dal.UpdateSelfCreateWebInfo(webId,loginName, domain);
        }
        //查询展厅域名是否己使用      
        public int  CheckDomain(string domain,string loginName)
        {
            return dal.CheckDomain(domain, loginName);
            
        }

        #endregion


        #region 检查等待上传的图片是否符合要求
        /// <summary>
        /// 检查等待上传的图片是否符合要求
        /// </summary>
        /// <param name="theUplPic"></param>
        /// <returns></returns>
        public static int checkUploadFile(System.Web.UI.HtmlControls.HtmlInputFile theUplPic)
        {
            //保证控件存在[没有使用转向链接]]时获得文件名
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //上传控件没有找到，或者不可用
                return 3;
            }

            if (strGetFileName == "")
            {
                //没有上传图片
                return 3;
            }
            //检查文件长度是否为0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return 3;
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return 3;
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();
            if (strExType == ".gif" || strExType == ".jpg")
            {
                int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["ImageContentLength"]); //文件要求的大小
                if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
                {
                    return 0;
                }
                else
                {
                    //文件过大
                    return 1;
                }
            }
            else
            {
                //文件过大
                return 2;
            }
        }

        /// <summary>
        /// 输入上传的控件与存储上传后图片文件名存放文本控件
        /// 上传文件到指定的信息类型的文件类型,
        /// 同时控制图片的大小[200K],和图片类型[gif,jpg]
        /// </summary>
        /// <param name="theUplPic">上传控件</param>
        /// <param name="UploadServerPath">上传文件名存放临时地点</param>
        /// <param name="IsCreateThumbnailImages">是否生成缩略图片</param>
        /// <returns>上传后的文件名</returns>
        public static string UploadFileWithThumbnail(System.Web.UI.HtmlControls.HtmlInputFile theUplPic, string UploadServerPath,
            bool IsCreateThumbnailImages, int Width, int Height, int Quality)
        {
            //保证控件存在[没有使用转向链接]]时获得文件名
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //上传控件没有找到，或者不可用
                return "";
            }
            //检查文件长度是否为0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return "";
            //没有图片上传时返回
            if (strGetFileName == "")
                return "";
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return "";
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();
            if (strExType == ".gif" || strExType == ".jpg")
            {
                //可以上传的图片类型
                int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["ImageContentLength"]); //文件要求的大小
                if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
                {
                    //可以上传
                    bool isFileExist = true;
                    string ServerPath = "";
                    string uploadFileName = "";
                    while (isFileExist)
                    {
                        uploadFileName = CreatePicName();
                        ServerPath = UploadServerPath + uploadFileName + strExType;
                        isFileExist = File.Exists(ServerPath);
                    }
                    theUplPic.PostedFile.SaveAs(ServerPath);
                    string OriginPicName = uploadFileName + strExType;
                    string MinPicName = uploadFileName + "_s" + strExType;
                    string ServerMinPath = UploadServerPath + uploadFileName + "_s" + strExType;

                    if (IsCreateThumbnailImages)	//生成缩略图片
                        ToThumbnailImages(ServerPath, ServerMinPath, Width, Height, Quality);
                    return uploadFileName + strExType; ;
                }
                else
                {
                    //文件过大
                    return "";
                }
            }
            else
            {
                //不允许上传该类图片文件
                return "";
            }
        }



        #region 附件上传

        /// <summary>
        /// 检查等待上传的附件是否符合大小要求
        /// </summary>
        /// <param name="theUplPic"></param>
        /// <returns></returns>
        public static int checkUploadFileSize(System.Web.UI.HtmlControls.HtmlInputFile theUplPic)
        {
            //保证控件存在[没有使用转向链接]]时获得文件名
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //上传控件没有找到，或者不可用
                return 3;
            }

            if (strGetFileName == "")
            {
                //没有上传
                return 3;
            }
            //检查文件长度是否为0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return 3;
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return 3;
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();

            int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["AttachContentLength"]); //文件要求的大小
            if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
            {
                return 0;
            }
            else
            {
                //文件过大
                return 1;
            }
        }

        /// <summary>
        /// 输入上传的控件与存储上传后文件名存放文本控件
        /// 上传文件到指定的信息类型的文件类型,
        /// </summary>
        /// <param name="theUplPic">上传控件</param>
        /// <returns>上传后的文件名</returns>
        public static string UploadFile(System.Web.UI.HtmlControls.HtmlInputFile theUplPic, string UploadServerPath)
        {
            //保证控件存在[没有使用转向链接]]时获得文件名
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //上传控件没有找到，或者不可用
                return "";
            }
            //检查文件长度是否为0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return "";
            //没有上传时返回
            if (strGetFileName == "")
                return "";
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return "";
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();
            int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["AttachContentLength"]); //文件要求的大小
            if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
            {
                //可以上传
                bool isFileExist = true;
                string ServerPath = "";
                string uploadFileName = "";
                while (isFileExist)
                {
                    uploadFileName = CreatePicName();
                    ServerPath = UploadServerPath + uploadFileName + strExType;
                    isFileExist = File.Exists(ServerPath);
                }
                theUplPic.PostedFile.SaveAs(ServerPath);
                return uploadFileName + strExType; ;
            }
            else
            {
                //文件过大
                return "";
            }
        }

        #endregion
        #region 创建上传文件的文件名
        /// <summary>
        /// 创建上传文件的文件名
        /// 文件名规则
        /// 年月日时分秒+５位随机数［共１９位］
        /// </summary>
        /// <param name="InfoTypeID">信息的类型</param>
        /// <returns></returns>
        public static string CreatePicName()
        {
            DateTime CurrentTime = DateTime.Now;
            string TimeName = CurrentTime.Year.ToString() + CurrentTime.Month.ToString("00")
                + CurrentTime.Day.ToString("00") + CurrentTime.Hour.ToString("00")
                + CurrentTime.Minute.ToString("00") + CurrentTime.Second.ToString("00");
            Random rnd = new Random();
            TimeName += rnd.Next(100000).ToString("00000");
            return TimeName;
        }
        #endregion

        #region 获取某信息类型的图片上传跟目录路径
        public static string GetUploadRootPath()
        {
            string ServerPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
            return ServerPath;
        }
        #endregion

        #region 获取某信息类型的图片临时文件路径
        /// <summary>
        /// 获取某信息类型的图片临时文件路径
        /// </summary>
        /// <param name="IsFullPath">是否是全路径</param>
        /// <returns>临时目录</returns>
        public static string GetTmpUploadPath(bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
            ServerPath = "TmpFile/";
            //根据当前月创建文件夹
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            #region 检查整个目录是否存在
            #endregion
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion
        #region Methods 生成缩略图  -----------------------------------
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceImagePath">原图片路径(相对路径)</param>
        /// <param name="thumbnailImagePath">生成的缩略图路径,如果为空则保存为原图片路径(相对路径)</param>
        /// <param name="thumbnailImageWidth">缩略图的宽度</param>
        /// <param name="thumbnailImageHeight">缩略图的高度</param>
        public static void ToThumbnailImages(string sourceImagePath, string thumbnailImagePath, int thumbnailImageWidth, int thumbnailImageHeight, int Quality)
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

            #region 原来求高度的代码,现在不需要
            //int num = ((ThumbnailImageWidth / 4) * 3);
            //int width = image.Width;
            //int height = image.Height;
            ////计算图片的比例
            //if ((((double) width) / ((double) height)) >= 1.3333333333333333f)
            //{
            //num = ((height * ThumbnailImageWidth) / width);
            //}
            //else
            //{
            //ThumbnailImageWidth = ((width * num) / height);
            //}
            #endregion

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
        #endregion

        #region 获取某信息类型的图片上传路径
        /// <summary>
        /// 获取某信息类型的图片上传路径
        /// </summary>
        /// <param name="InfoType">信息类型[如news]</param>
        /// <param name="IsFullPath">是否是全路径</param>
        /// <returns>返回d:\upload\News\200508\dd.gif</returns>
        public static string GetUploadPath(string InfoType, bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
            ServerPath = InfoType;
            DateTime timeC = DateTime.Now;
            ServerPath += "/" + timeC.Year.ToString() + timeC.Month.ToString() + "/";
            //根据当前月创建文件夹
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            #region 检查整个目录是否存在
            #endregion
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">Image 对象</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="ici">指定格式的编解码参数</param>
        static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici, int Quality)
        {
            //设置 原图片 对象的 EncoderParameters 对象
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
            image.Save(savePath, ici, parameters);
            parameters.Dispose();
        }
        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        #region 获取图片的域名
        public static string GetImageDomain()
        {
            string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
            return ImageDomain;
        }
        #endregion

        #endregion

        #region 获取用户的展厅资料
        /// <summary>
        /// 获取企业会员的展厅资料
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetEnterpriseInfo(string loginName)
        {
            return dal.GetEnterpriseInfo(loginName);
        }

        /// <summary>
        /// 获取招商会员的展厅资料
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetGovernmentInfo(string loginName)
        {
            return dal.GetGovernmentInfo(loginName);
        }
        #endregion

        /// <summary>
        /// 第二次写查询联系人详细信息
        /// </summary>
        /// <param name="lognName"></param>
        /// <returns></returns>
        public Tz888.Model.Register.MemberInfoModel SelorgContact(string lognName)
        {
            return dal.SelorgContact(lognName);
        }
    }
}
