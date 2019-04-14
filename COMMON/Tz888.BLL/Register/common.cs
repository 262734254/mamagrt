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
        /// ��ȡ��ϵ���б�
        /// </summary>
        /// <returns>��ϵ���б�</returns>
        public List<Tz888.Model.Register.OrgContactMan> GetOrgContactMan(string LoginName)
        {
            return dal.GetOrgContactMan(LoginName);
        }

        //�����ϵ��
        public void AddOrgContect(OrgContactModel orgModel)
        {
            dal.AddOrgContect(orgModel);
        }
        /// <summary>
        /// ��ȡͼƬ��Դ�б�
        /// </summary>
        /// <returns>ͼƬ��Դ</returns>
        public List<Tz888.Model.MemberResourceModel> GetMemberResourceModel(string LoginName, int ResourceProperty)
        {
            return dal.GetMemberResourceModel(LoginName, ResourceProperty);
        }


        //Ĭ����ϵ�ˣ�ע���Ա�ˣ�
        public Tz888.Model.Register.OrgContactModel getContactModel(string LoginName)
        {
            return dal.getContactModel(LoginName);
        }

      
        //��˵Ǽ�
        public int AuditOrg(Tz888.Model.Register.OrgAuditModel model)
        {
            return dal.AuditOrg(model);
        }

        //��Ա��Ϣ�޸�ʱ ��ӵǼ�Ĭ����ϵ��
        public long OrgContactMan_FromMemberMessage(Tz888.Model.Register.OrgContactModel model)
        {
            return dal.OrgContactMan_FromMemberMessage(model);
        }

        #region  ����չ������
        //���
        public int AddSelfCreateWebInfo(string loginName, string domain)
        {
            return dal.AddSelfCreateWebInfo(loginName, domain);
        }
        //�޸�
        public int UpdateSelfCreateWebInfo(int webId, string loginName, string domain)
        {
            return dal.UpdateSelfCreateWebInfo(webId,loginName, domain);
        }
        //��ѯչ�������Ƿ�ʹ��      
        public int  CheckDomain(string domain,string loginName)
        {
            return dal.CheckDomain(domain, loginName);
            
        }

        #endregion


        #region ���ȴ��ϴ���ͼƬ�Ƿ����Ҫ��
        /// <summary>
        /// ���ȴ��ϴ���ͼƬ�Ƿ����Ҫ��
        /// </summary>
        /// <param name="theUplPic"></param>
        /// <returns></returns>
        public static int checkUploadFile(System.Web.UI.HtmlControls.HtmlInputFile theUplPic)
        {
            //��֤�ؼ�����[û��ʹ��ת������]]ʱ����ļ���
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //�ϴ��ؼ�û���ҵ������߲�����
                return 3;
            }

            if (strGetFileName == "")
            {
                //û���ϴ�ͼƬ
                return 3;
            }
            //����ļ������Ƿ�Ϊ0
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
                int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["ImageContentLength"]); //�ļ�Ҫ��Ĵ�С
                if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
                {
                    return 0;
                }
                else
                {
                    //�ļ�����
                    return 1;
                }
            }
            else
            {
                //�ļ�����
                return 2;
            }
        }

        /// <summary>
        /// �����ϴ��Ŀؼ���洢�ϴ���ͼƬ�ļ�������ı��ؼ�
        /// �ϴ��ļ���ָ������Ϣ���͵��ļ�����,
        /// ͬʱ����ͼƬ�Ĵ�С[200K],��ͼƬ����[gif,jpg]
        /// </summary>
        /// <param name="theUplPic">�ϴ��ؼ�</param>
        /// <param name="UploadServerPath">�ϴ��ļ��������ʱ�ص�</param>
        /// <param name="IsCreateThumbnailImages">�Ƿ���������ͼƬ</param>
        /// <returns>�ϴ�����ļ���</returns>
        public static string UploadFileWithThumbnail(System.Web.UI.HtmlControls.HtmlInputFile theUplPic, string UploadServerPath,
            bool IsCreateThumbnailImages, int Width, int Height, int Quality)
        {
            //��֤�ؼ�����[û��ʹ��ת������]]ʱ����ļ���
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //�ϴ��ؼ�û���ҵ������߲�����
                return "";
            }
            //����ļ������Ƿ�Ϊ0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return "";
            //û��ͼƬ�ϴ�ʱ����
            if (strGetFileName == "")
                return "";
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return "";
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();
            if (strExType == ".gif" || strExType == ".jpg")
            {
                //�����ϴ���ͼƬ����
                int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["ImageContentLength"]); //�ļ�Ҫ��Ĵ�С
                if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
                {
                    //�����ϴ�
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

                    if (IsCreateThumbnailImages)	//��������ͼƬ
                        ToThumbnailImages(ServerPath, ServerMinPath, Width, Height, Quality);
                    return uploadFileName + strExType; ;
                }
                else
                {
                    //�ļ�����
                    return "";
                }
            }
            else
            {
                //�������ϴ�����ͼƬ�ļ�
                return "";
            }
        }



        #region �����ϴ�

        /// <summary>
        /// ���ȴ��ϴ��ĸ����Ƿ���ϴ�СҪ��
        /// </summary>
        /// <param name="theUplPic"></param>
        /// <returns></returns>
        public static int checkUploadFileSize(System.Web.UI.HtmlControls.HtmlInputFile theUplPic)
        {
            //��֤�ؼ�����[û��ʹ��ת������]]ʱ����ļ���
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //�ϴ��ؼ�û���ҵ������߲�����
                return 3;
            }

            if (strGetFileName == "")
            {
                //û���ϴ�
                return 3;
            }
            //����ļ������Ƿ�Ϊ0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return 3;
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return 3;
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();

            int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["AttachContentLength"]); //�ļ�Ҫ��Ĵ�С
            if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
            {
                return 0;
            }
            else
            {
                //�ļ�����
                return 1;
            }
        }

        /// <summary>
        /// �����ϴ��Ŀؼ���洢�ϴ����ļ�������ı��ؼ�
        /// �ϴ��ļ���ָ������Ϣ���͵��ļ�����,
        /// </summary>
        /// <param name="theUplPic">�ϴ��ؼ�</param>
        /// <returns>�ϴ�����ļ���</returns>
        public static string UploadFile(System.Web.UI.HtmlControls.HtmlInputFile theUplPic, string UploadServerPath)
        {
            //��֤�ؼ�����[û��ʹ��ת������]]ʱ����ļ���
            string strGetFileName = "";
            try
            {
                strGetFileName = theUplPic.PostedFile.FileName;
            }
            catch
            {
                //�ϴ��ؼ�û���ҵ������߲�����
                return "";
            }
            //����ļ������Ƿ�Ϊ0
            long contentLen = theUplPic.PostedFile.ContentLength;
            if (contentLen == 0)
                return "";
            //û���ϴ�ʱ����
            if (strGetFileName == "")
                return "";
            int intStartCut = strGetFileName.LastIndexOf(".");
            if (intStartCut < 1)
                return "";
            string strExType = strGetFileName.Substring(intStartCut);
            strExType = strExType.ToLower();
            int ImageContentLength = Convert.ToInt32(ConfigurationManager.AppSettings["AttachContentLength"]); //�ļ�Ҫ��Ĵ�С
            if (theUplPic.PostedFile.ContentLength < (ImageContentLength * 1024))
            {
                //�����ϴ�
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
                //�ļ�����
                return "";
            }
        }

        #endregion
        #region �����ϴ��ļ����ļ���
        /// <summary>
        /// �����ϴ��ļ����ļ���
        /// �ļ�������
        /// ������ʱ����+��λ������۹�����λ��
        /// </summary>
        /// <param name="InfoTypeID">��Ϣ������</param>
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

        #region ��ȡĳ��Ϣ���͵�ͼƬ�ϴ���Ŀ¼·��
        public static string GetUploadRootPath()
        {
            string ServerPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
            return ServerPath;
        }
        #endregion

        #region ��ȡĳ��Ϣ���͵�ͼƬ��ʱ�ļ�·��
        /// <summary>
        /// ��ȡĳ��Ϣ���͵�ͼƬ��ʱ�ļ�·��
        /// </summary>
        /// <param name="IsFullPath">�Ƿ���ȫ·��</param>
        /// <returns>��ʱĿ¼</returns>
        public static string GetTmpUploadPath(bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
            ServerPath = "TmpFile/";
            //���ݵ�ǰ�´����ļ���
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            #region �������Ŀ¼�Ƿ����
            #endregion
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion
        #region Methods ��������ͼ  -----------------------------------
        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="sourceImagePath">ԭͼƬ·��(���·��)</param>
        /// <param name="thumbnailImagePath">���ɵ�����ͼ·��,���Ϊ���򱣴�ΪԭͼƬ·��(���·��)</param>
        /// <param name="thumbnailImageWidth">����ͼ�Ŀ��</param>
        /// <param name="thumbnailImageHeight">����ͼ�ĸ߶�</param>
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

            //�� ԭͼƬ ���� Image ����
            System.Drawing.Image image = System.Drawing.Image.FromFile(SourceImagePath);

            #region ԭ����߶ȵĴ���,���ڲ���Ҫ
            //int num = ((ThumbnailImageWidth / 4) * 3);
            //int width = image.Width;
            //int height = image.Height;
            ////����ͼƬ�ı���
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
            //��ָ���Ĵ�С�͸�ʽ��ʼ�� Bitmap �����ʵ��
            Bitmap bitmap = new Bitmap(ThumbnailImageWidth, thumbnailImageHeight, PixelFormat.Format32bppArgb);
            //��ָ���� Image ���󴴽��� Graphics ����
            Graphics graphics = Graphics.FromImage(bitmap);
            //���������ͼ�沢��͸������ɫ���
            graphics.Clear(Color.Transparent);
            //��ָ��λ�ò��Ұ�ָ����С���� ԭͼƬ ����
            graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, thumbnailImageHeight));
            image.Dispose();
            try
            {
                //���� ԭͼƬ ��ָ����ʽ����ָ���ı����������浽ָ���ļ�	
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

        #region ��ȡĳ��Ϣ���͵�ͼƬ�ϴ�·��
        /// <summary>
        /// ��ȡĳ��Ϣ���͵�ͼƬ�ϴ�·��
        /// </summary>
        /// <param name="InfoType">��Ϣ����[��news]</param>
        /// <param name="IsFullPath">�Ƿ���ȫ·��</param>
        /// <returns>����d:\upload\News\200508\dd.gif</returns>
        public static string GetUploadPath(string InfoType, bool IsFullPath)
        {
            string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
            ServerPath = InfoType;
            DateTime timeC = DateTime.Now;
            ServerPath += "/" + timeC.Year.ToString() + timeC.Month.ToString() + "/";
            //���ݵ�ǰ�´����ļ���
            if (!Directory.Exists(ServerRootPath + ServerPath))
                Directory.CreateDirectory(ServerRootPath + ServerPath);
            #region �������Ŀ¼�Ƿ����
            #endregion
            if (IsFullPath)
                return ServerRootPath + ServerPath;
            else
                return ServerPath;
        }
        #endregion

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        /// <param name="image">Image ����</param>
        /// <param name="savePath">����·��</param>
        /// <param name="ici">ָ����ʽ�ı�������</param>
        static void SaveImage(System.Drawing.Image image, string savePath, ImageCodecInfo ici, int Quality)
        {
            //���� ԭͼƬ ����� EncoderParameters ����
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
            image.Save(savePath, ici, parameters);
            parameters.Dispose();
        }
        /// <summary>
        /// ��ȡͼ���������������������Ϣ
        /// </summary>
        /// <param name="mimeType">��������������Ķ���;�����ʼ�����Э�� (MIME) ���͵��ַ���</param>
        /// <returns>����ͼ���������������������Ϣ</returns>
        static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        #region ��ȡͼƬ������
        public static string GetImageDomain()
        {
            string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
            return ImageDomain;
        }
        #endregion

        #endregion

        #region ��ȡ�û���չ������
        /// <summary>
        /// ��ȡ��ҵ��Ա��չ������
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetEnterpriseInfo(string loginName)
        {
            return dal.GetEnterpriseInfo(loginName);
        }

        /// <summary>
        /// ��ȡ���̻�Ա��չ������
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetGovernmentInfo(string loginName)
        {
            return dal.GetGovernmentInfo(loginName);
        }
        #endregion

        /// <summary>
        /// �ڶ���д��ѯ��ϵ����ϸ��Ϣ
        /// </summary>
        /// <param name="lognName"></param>
        /// <returns></returns>
        public Tz888.Model.Register.MemberInfoModel SelorgContact(string lognName)
        {
            return dal.SelorgContact(lognName);
        }
    }
}
