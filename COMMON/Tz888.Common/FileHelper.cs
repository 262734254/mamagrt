using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;

namespace Tz888.Common
{
    public class FileHelper
    {

        #region �ϴ�С�ļ�
        /// <summary>
        /// �ϴ�С�ļ�
        /// </summary>
        /// <param name="LoginName">��½��</param>
        /// <param name="postedFile">�ϴ��ļ��ؼ�</param>
        /// <param name="path">����·��,Ϊ����ʹ��webconfig���·��</param>
        /// <param name="size">�ļ���С,0Ϊ������</param>
        /// <param name="filetype">���ϴ����ļ����ͣ���ʽ��".gif|.jpg|.png",����Ϊ������,"default"��Ĭ��".gif|.jpg|.png"����</param>
        /// <param name="dt">��ǰʱ��</param>
        /// <returns>�ϴ����ļ������� ����1:�ļ����Ͳ��� ����2:��С�������� ����3:���ļ�</returns>
        public static string UploadFile(string LoginName, System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype, DateTime dt)
        {
            try
            {
                Random r = new Random(); 
                string randomName = r.Next(100).ToString();
                string strAllPath = postedFile.PostedFile.FileName;//�ϴ��ļ�������ԭʼ����·��                
                string strAllName = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//ԭ�ļ�����������ʽ��
                string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//��չ��
                string strName = System.IO.Path.GetFileNameWithoutExtension(postedFile.PostedFile.FileName);//�ļ�������������ʽ��
                string strSaveName = dt.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + randomName + strtype;//�ϴ�����ļ�����
                if (path == "")
                {
                    path = System.Web.HttpRuntime.AppDomainAppPath + @"UploadPic\" + LoginName + "\\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //���û�ʹ���һ��Ŀ¼��
                   
                }
                else
                {
                    path = path + @"UploadPic\" + LoginName + "\\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //���û�ʹ���һ��Ŀ¼��  

                }
                string strSavePath = path + strSaveName;
                int fileSize = postedFile.PostedFile.ContentLength / 1024; ;


                long contentLen = postedFile.PostedFile.ContentLength;
                if (contentLen == 0)
                    return "3";
                int intStartCut = postedFile.PostedFile.FileName.LastIndexOf(".");
                if (intStartCut < 1)
                    return "3";
                //�Ƿ������ļ�����
                if (filetype.Length > 0)
                {
                    if (filetype.ToLower().Equals("default"))
                    {
                        if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".png" && strtype.ToLower() != ".gif")
                            return "1";
                    }
                    else
                    {
                        string[] uploadType = filetype.Split('|');
                        bool isPass = false;
                        foreach (string type in uploadType)
                        {
                            if (strtype.ToLower() == type)
                                isPass = true;
                        }
                        if (!isPass) { return "1"; }
                    }
                }

                //�Ƿ����ƴ�С
                if (size > 0)
                {
                    if (fileSize <= size)
                    {
                        postedFile.PostedFile.SaveAs(strSavePath);//�����ϴ����ļ���ָ����·��
                        return strSaveName;
                        //Page.RegisterClientScriptBlock("", "<script>alert('�ϴ��ɹ�!');</script>");
                    }
                    else
                    {
                        //�ϴ����ļ���С����
                        return "2";
                    }
                }
                else
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//�����ϴ����ļ���ָ����·��
                    return strSaveName;
                }
            }
            catch
            {
                return "3";
            }
        }

        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string UseName, string path, int size, int filetype)
        {
            try
            {
                Random r = new Random();
                string randomName = r.Next(100).ToString();
                string strAllPath = postedFile.PostedFile.FileName;//�ϴ��ļ�������ԭʼ����·��                
                string strAllName = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//ԭ�ļ�����������ʽ��
                string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//��չ��

                string strName = System.IO.Path.GetFileNameWithoutExtension(postedFile.PostedFile.FileName);//�ļ�������������ʽ��
                string strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;//�ϴ�����ļ�����
                string pathA = "";
                if (filetype == 1)
                {
                    pathA = "Images";
                }
                if (filetype == 2)
                {
                    pathA = "File";
                }
                if (path == "")
                {
                    path = System.Web.HttpRuntime.AppDomainAppPath + @"UploadFile/" + UseName + @"/" + pathA + @"/";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //���û�ʹ���һ��Ŀ¼��
                }
                else
                {
                    path = ConfigurationManager.AppSettings["FileServerPath"].ToString() + UseName + @"/" + pathA + @"/";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //���û�ʹ���һ��Ŀ¼��
                }
                string strSavePath = path + strSaveName;//Ϊ�ļ���ȡ����·��

                string filePath = UseName + @"/" + pathA + @"/" + strSaveName;//�ļ���·��

                int fileSize = postedFile.PostedFile.ContentLength / 1024; ;

                //�Ƿ������ļ�����
                if (filetype > 0)
                {
                    if (filetype == 1)
                    {
                        if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".png" && strtype.ToLower() != ".gif")
                            return "1";
                    }
                    if (filetype == 2)
                    {
                        if (strtype.ToLower() != ".doc" && strtype.ToLower() != ".pdf" && strtype.ToLower() != ".txt" && strtype.ToLower() != ".rar" && strtype.ToLower() != ".ppt" && strtype.ToLower() != ".zip")
                            return "1";
                    }
                }

                //�Ƿ����ƴ�С
                if (size > 0)
                {
                    if (fileSize <= size)
                    {
                        postedFile.PostedFile.SaveAs(strSavePath);//�����ϴ����ļ���ָ����·��

                        return filePath + "|" + fileSize.ToString();
                    }
                    else
                    {
                        //�ϴ����ļ���С����

                        return "2";
                    }
                }
                else
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//�����ϴ����ļ���ָ����·��

                    return filePath + "|" + fileSize.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
 

        #region �ϴ����ļ�
        /// <summary>
        /// �ϴ����ļ�
        /// </summary>
        /// <param name="cox">radupload�ؼ�</param>
        /// <param name="LoginName">��½��</param>
        /// <param name="dt">��ǰʱ��</param>
        /// <returns></returns>
        public static string UploadLargeFile(Telerik.WebControls.RadUploadContext cox, string LoginName, DateTime dt, string extension, int FileSize)
        {
            string Path = ConfigurationManager.AppSettings["FileServerPath"].ToString() + @"UploadVideo\";
            string filename = "";
            string ext = "";
            try
            {
                foreach (Telerik.WebControls.UploadedFile file in Telerik.WebControls.RadUploadContext.Current.UploadedFiles)
                {
                    if (FileSize != 0)
                    {
                        if (file.ContentLength > FileSize)
                        {
                            return "1"; //�ļ�����ָ����С
                        }
                    }
                    bool isPass = false;
                    foreach (string str in extension.Split(','))
                    {
                        if (file.GetExtension().ToString() == str.Trim().ToLower())
                        {
                            isPass = true;
                        }
                    }
                    if (!isPass)
                    {
                        return "2"; // ֻ�����ϴ����͵��ļ����ڷ�Χ��
                    }
                    filename = dt.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + new Random().Next(1000).ToString();
                    string tempPath = Path + "temp\\" + filename + file.GetExtension();
                    string realPath = Path + LoginName + "\\" + filename + file.GetExtension();
                    ext = file.GetExtension();
                    if (!System.IO.Directory.Exists(Path + LoginName + "\\"))
                    {
                        System.IO.Directory.CreateDirectory(Path + LoginName + "\\");
                    }
                    file.SaveAs(realPath, true);
                    Video v = new Video();
                    System.Drawing.Bitmap bmp = v.GetFrameFromVideo(realPath, 0.2d, new System.Drawing.Size(160, 120));
                    bmp.Save(Path + LoginName + "\\" + filename + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch
            {
                if (System.IO.Directory.Exists(Path + "temp"))
                {
                    foreach (string f in System.IO.Directory.GetFiles(Path + "temp"))
                    {
                        System.IO.File.Delete(f);
                    }
                }
                return "3"; // ��������
            }
            return filename + ext;
        }
        #endregion

        #region �ϴ����ļ�
        /// <summary>
        /// �ϴ����ļ�
        /// </summary>
        /// <param name="cox">radupload�ؼ�</param>
        /// <param name="LoginName">��½��</param>
        /// <param name="dt">��ǰʱ��</param>
        /// <param name="Path">����·��, Ĭ��Ϊ��</param>
        /// <returns></returns>
        public static string UploadLargeFile(Telerik.WebControls.RadUploadContext cox, string LoginName, bool AnotherPath, DateTime dt, string extension, int FileSize)
        {
            string ampath = "";
            if (AnotherPath)
            {

                ampath = ConfigurationManager.AppSettings["FileServerPath"].ToString(); 

            }
            else
            {
                ampath = System.Web.HttpRuntime.AppDomainAppPath + @"UploadFile\";
            }
            string filename = "";
            string ext = "";
            try
            {
                foreach (Telerik.WebControls.UploadedFile file in Telerik.WebControls.RadUploadContext.Current.UploadedFiles)
                {
                    if (FileSize != 0)
                    {
                        if (file.ContentLength > FileSize)
                        {
                            return "1"; //�ļ�����ָ����С
                        }
                    }
                    bool isPass = false;
                    foreach (string str in extension.Split(','))
                    {
                        if (file.GetExtension().ToString() == str.Trim().ToLower())
                        {
                            isPass = true;
                        }
                    }
                    if (!isPass)
                    {
                        return "2"; // ֻ�����ϴ����͵��ļ����ڷ�Χ��
                    }
                    filename = dt.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + new Random().Next(1000).ToString();
                    string tempPath = ampath + "temp\\" + filename + file.GetExtension();
                    string realPath = ampath + LoginName + "\\" + filename + file.GetExtension();
                    ext = file.GetExtension();
                    if (!System.IO.Directory.Exists(ampath + LoginName + "\\"))
                    {
                        System.IO.Directory.CreateDirectory(ampath + LoginName + "\\");
                    }
                    file.SaveAs(tempPath, true);
                    Video v = new Video();
                    System.Drawing.Bitmap bmp = v.GetFrameFromVideo(tempPath, 0.2d, new System.Drawing.Size(160, 120));
                    bmp.Save(ampath + LoginName + "\\" + filename + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.IO.File.Copy(tempPath, realPath);
                    System.IO.File.Delete(tempPath);
                }
            }
            catch
            {
                if (System.IO.Directory.Exists(ampath + "temp"))
                {
                    foreach (string f in System.IO.Directory.GetFiles(ampath + "temp"))
                    {
                        System.IO.File.Delete(f);
                    }
                }
                return "3"; // ��������
            }
            return filename + ext;
        }
        #endregion

        /// <summary>
        /// �ϴ��ļ�,�����ƴ�С�����Ͳ��ϴ���Ĭ��UploadFileĿ¼
        /// </summary>
        /// <param name="postedFile">�ϴ��ļ��ؼ�</param>
        /// <returns>�ϴ����ļ�������</returns>
        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile)
        {
            return UploadFile(postedFile, "", 0, "");
        }

        /// <summary>
        /// �ϴ��ļ�,�����ƴ�С�����Ͳ��ϴ����Զ���·��
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path)
        {
            return UploadFile(postedFile, path, 0, "");
        }


        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="postedFile">�ϴ��ļ��ؼ�</param>
        /// <param name="path">���������·��,������Ϊ��Ŀ¼�� UploadFile Ŀ¼</param>
        /// <param name="size">�ļ���С,0Ϊ������</param>
        /// <param name="filetype">���ϴ����ļ����ͣ���ʽ��".gif|.jpg|.png",����Ϊ������,"default"��Ĭ��".gif|.jpg|.png"����</param>
        /// <returns>�ϴ����ļ������� ����1:�ļ����Ͳ��� ����2:��С��������</returns>
        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype)
        {
            try
            {
                Random r = new Random();
                string randomName = r.Next(100).ToString();
                string strAllPath = postedFile.PostedFile.FileName;//�ϴ��ļ�������ԭʼ����·��                
                string strAllName = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//ԭ�ļ�����������ʽ��
                string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//��չ��
                string strName = System.IO.Path.GetFileNameWithoutExtension(postedFile.PostedFile.FileName);//�ļ�������������ʽ��
                string strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;//�ϴ�����ļ�����
                if (path == "")
                {
                    path = System.Web.HttpRuntime.AppDomainAppPath + @"UploadFile\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //���û�ʹ���һ��Ŀ¼��
                }
                else
                {
                    path = ConfigurationManager.AppSettings["FileServerPath"].ToString() + @"UploadFile\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //���û�ʹ���һ��Ŀ¼��
                }
                string strSavePath = path + strSaveName;//Ϊ�ļ���ȡ����·��
                int fileSize = postedFile.PostedFile.ContentLength / 1024; ;

                //�Ƿ������ļ�����
                if (filetype.Length > 0)
                {
                    if (filetype.ToLower().Equals("default"))
                    {
                        if (strtype.ToLower() != ".jpg" && strtype.ToLower() != ".png" && strtype.ToLower() != ".gif")
                            return "1";
                    }
                    else
                    {
                        string[] uploadType = filetype.Split('|');
                        foreach (string type in uploadType)
                        {
                            if (strtype.ToLower() != type)
                                return "1";
                        }
                    }
                }

                //�Ƿ����ƴ�С
                if (size > 0)
                {
                    if (fileSize <= size)
                    {
                        postedFile.PostedFile.SaveAs(strSavePath);//�����ϴ����ļ���ָ����·��
                        return strSaveName;
                        //Page.RegisterClientScriptBlock("", "<script>alert('�ϴ��ɹ�!');</script>");
                    }
                    else
                    {
                        //�ϴ����ļ���С����
                        return "2";
                    }
                }
                else
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//�����ϴ����ļ���ָ����·��
                    return strSaveName;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="originalImagePath">Դͼ·��������·����</param>
        /// <param name="thumbnailPath">����ͼ·��������·����</param>
        /// <param name="width">����ͼ���</param>
        /// <param name="height">����ͼ�߶�</param>
        /// <param name="mode">��������ͼ�ķ�ʽ</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://ָ���߿����ţ����ܱ��Σ�                
                    break;
                case "W"://ָ�����߰�����                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://ָ���ߣ�������
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://ָ���߿�ü��������Σ�                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //�½�һ��bmpͼƬ
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //�½�һ������
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //���ø�������ֵ��
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //���ø�����,���ٶȳ���ƽ���̶�
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //��ջ�������͸������ɫ���
            g.Clear(System.Drawing.Color.Transparent);

            //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //��jpg��ʽ��������ͼ
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// ��ͼƬ����������ˮӡ
        /// </summary>
        /// <param name="Path">ԭ������ͼƬ·��</param>
        /// <param name="Path_sy">���ɵĴ�����ˮӡ��ͼƬ·��</param>
        /// <param name="addText">���ɵ�����</param>
        /// <param name="IsDeleteOld">�Ƿ�ɾ����ͼƬ</param>
        public static void AddWater(string Path, string Path_sy, string addText,bool IsDeleteOld)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 16);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.GreenYellow);

            g.DrawString(addText, f, b,10, 10);
            g.Dispose();

            image.Save(Path_sy);
            image.Dispose();

            if (IsDeleteOld && File.Exists(Path))
                File.Delete(Path);
        }

        /// <summary>
        /// ��ͼƬ������ͼƬˮӡ
        /// </summary>
        /// <param name="Path">ԭ������ͼƬ·��</param>
        /// <param name="Path_syp">���ɵĴ�ͼƬˮӡ��ͼƬ·��</param>
        /// <param name="Path_sypf">ˮӡͼƬ·��</param>
        /// <param name="IsDeleteOld">�Ƿ�ɾ����ͼƬ</param>
        public static void AddWaterPic(string Path, string Path_syp, string Path_sypf, bool IsDeleteOld)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();

            image.Save(Path_syp);
            image.Dispose();

            if (IsDeleteOld && File.Exists(Path))
                File.Delete(Path);
        }

        ///<summary>
        ///����ļ������Ƿ������ϴ�
        ///</summary>
        public static bool IsAllowedExtension(System.Web.UI.WebControls.FileUpload Controls, string ConfigNodeName)
        {
            string FileExtension = "";
            string[] FileConfig = ConfigurationManager.AppSettings[ConfigNodeName].ToString().Split('|');

            if (!string.IsNullOrEmpty(Controls.PostedFile.FileName))
            {
                FileExtension = System.IO.Path.GetExtension(Controls.PostedFile.FileName);
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

        /// <summary>
        /// �ж��ϴ��ļ���С�Ƿ񳬹����õ����ֵ
        /// </summary>
        public static bool IsAllowedLength(System.Web.UI.WebControls.FileUpload Controls)
        {
            int MaxLength = 100;
            try
            {
                MaxLength = Convert.ToInt32(ConfigurationManager.AppSettings["FileMaxLength"]);
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
    }
}
