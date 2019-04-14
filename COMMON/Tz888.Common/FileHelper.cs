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

        #region 上传小文件
        /// <summary>
        /// 上传小文件
        /// </summary>
        /// <param name="LoginName">登陆名</param>
        /// <param name="postedFile">上传文件控件</param>
        /// <param name="path">物理路径,为空则使用webconfig里的路径</param>
        /// <param name="size">文件大小,0为不限制</param>
        /// <param name="filetype">可上传的文件类型，格式：".gif|.jpg|.png",留空为不限制,"default"即默认".gif|.jpg|.png"类型</param>
        /// <param name="dt">当前时间</param>
        /// <returns>上传后文件的名称 返回1:文件类型不对 返回2:大小超出限制 返回3:无文件</returns>
        public static string UploadFile(string LoginName, System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype, DateTime dt)
        {
            try
            {
                Random r = new Random(); 
                string randomName = r.Next(100).ToString();
                string strAllPath = postedFile.PostedFile.FileName;//上传文件的完整原始物理路径                
                string strAllName = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//原文件名（包括格式）
                string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
                string strName = System.IO.Path.GetFileNameWithoutExtension(postedFile.PostedFile.FileName);//文件名（不包含格式）
                string strSaveName = dt.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + randomName + strtype;//上传后的文件名称
                if (path == "")
                {
                    path = System.Web.HttpRuntime.AppDomainAppPath + @"UploadPic\" + LoginName + "\\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //如果没就创建一个目录；
                   
                }
                else
                {
                    path = path + @"UploadPic\" + LoginName + "\\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //如果没就创建一个目录；  

                }
                string strSavePath = path + strSaveName;
                int fileSize = postedFile.PostedFile.ContentLength / 1024; ;


                long contentLen = postedFile.PostedFile.ContentLength;
                if (contentLen == 0)
                    return "3";
                int intStartCut = postedFile.PostedFile.FileName.LastIndexOf(".");
                if (intStartCut < 1)
                    return "3";
                //是否限制文件类型
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

                //是否限制大小
                if (size > 0)
                {
                    if (fileSize <= size)
                    {
                        postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                        return strSaveName;
                        //Page.RegisterClientScriptBlock("", "<script>alert('上传成功!');</script>");
                    }
                    else
                    {
                        //上传的文件大小超出
                        return "2";
                    }
                }
                else
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
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
                string strAllPath = postedFile.PostedFile.FileName;//上传文件的完整原始物理路径                
                string strAllName = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//原文件名（包括格式）
                string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名

                string strName = System.IO.Path.GetFileNameWithoutExtension(postedFile.PostedFile.FileName);//文件名（不包含格式）
                string strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;//上传后的文件名称
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
                        System.IO.Directory.CreateDirectory(path); //如果没就创建一个目录；
                }
                else
                {
                    path = ConfigurationManager.AppSettings["FileServerPath"].ToString() + UseName + @"/" + pathA + @"/";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //如果没就创建一个目录；
                }
                string strSavePath = path + strSaveName;//为文件获取保存路径

                string filePath = UseName + @"/" + pathA + @"/" + strSaveName;//文件短路径

                int fileSize = postedFile.PostedFile.ContentLength / 1024; ;

                //是否限制文件类型
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

                //是否限制大小
                if (size > 0)
                {
                    if (fileSize <= size)
                    {
                        postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径

                        return filePath + "|" + fileSize.ToString();
                    }
                    else
                    {
                        //上传的文件大小超出

                        return "2";
                    }
                }
                else
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径

                    return filePath + "|" + fileSize.ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
 

        #region 上传大文件
        /// <summary>
        /// 上传大文件
        /// </summary>
        /// <param name="cox">radupload控件</param>
        /// <param name="LoginName">登陆名</param>
        /// <param name="dt">当前时间</param>
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
                            return "1"; //文件超过指定大小
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
                        return "2"; // 只允许上传类型的文件不在范围内
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
                return "3"; // 其他错误
            }
            return filename + ext;
        }
        #endregion

        #region 上传大文件
        /// <summary>
        /// 上传大文件
        /// </summary>
        /// <param name="cox">radupload控件</param>
        /// <param name="LoginName">登陆名</param>
        /// <param name="dt">当前时间</param>
        /// <param name="Path">保存路径, 默认为空</param>
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
                            return "1"; //文件超过指定大小
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
                        return "2"; // 只允许上传类型的文件不在范围内
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
                return "3"; // 其他错误
            }
            return filename + ext;
        }
        #endregion

        /// <summary>
        /// 上传文件,不限制大小和类型并上传到默认UploadFile目录
        /// </summary>
        /// <param name="postedFile">上传文件控件</param>
        /// <returns>上传后文件的名称</returns>
        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile)
        {
            return UploadFile(postedFile, "", 0, "");
        }

        /// <summary>
        /// 上传文件,不限制大小和类型并上传到自定义路径
        /// </summary>
        /// <param name="postedFile"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path)
        {
            return UploadFile(postedFile, path, 0, "");
        }


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="postedFile">上传文件控件</param>
        /// <param name="path">存入的物理路径,留空则为根目录下 UploadFile 目录</param>
        /// <param name="size">文件大小,0为不限制</param>
        /// <param name="filetype">可上传的文件类型，格式：".gif|.jpg|.png",留空为不限制,"default"即默认".gif|.jpg|.png"类型</param>
        /// <returns>上传后文件的名称 返回1:文件类型不对 返回2:大小超出限制</returns>
        public static string UploadFile(System.Web.UI.WebControls.FileUpload postedFile, string path, int size, string filetype)
        {
            try
            {
                Random r = new Random();
                string randomName = r.Next(100).ToString();
                string strAllPath = postedFile.PostedFile.FileName;//上传文件的完整原始物理路径                
                string strAllName = System.IO.Path.GetFileName(postedFile.PostedFile.FileName);//原文件名（包括格式）
                string strtype = System.IO.Path.GetExtension(postedFile.PostedFile.FileName);//扩展名
                string strName = System.IO.Path.GetFileNameWithoutExtension(postedFile.PostedFile.FileName);//文件名（不包含格式）
                string strSaveName = System.DateTime.Now.ToLocalTime().ToString().Replace(":", "").Replace("-", "").Replace(" ", "").Replace("/", "") + strtype;//上传后的文件名称
                if (path == "")
                {
                    path = System.Web.HttpRuntime.AppDomainAppPath + @"UploadFile\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //如果没就创建一个目录；
                }
                else
                {
                    path = ConfigurationManager.AppSettings["FileServerPath"].ToString() + @"UploadFile\";
                    if (System.IO.Directory.Exists(path) == false)
                        System.IO.Directory.CreateDirectory(path); //如果没就创建一个目录；
                }
                string strSavePath = path + strSaveName;//为文件获取保存路径
                int fileSize = postedFile.PostedFile.ContentLength / 1024; ;

                //是否限制文件类型
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

                //是否限制大小
                if (size > 0)
                {
                    if (fileSize <= size)
                    {
                        postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                        return strSaveName;
                        //Page.RegisterClientScriptBlock("", "<script>alert('上传成功!');</script>");
                    }
                    else
                    {
                        //上传的文件大小超出
                        return "2";
                    }
                }
                else
                {
                    postedFile.PostedFile.SaveAs(strSavePath);//保存上传的文件到指定的路径
                    return strSaveName;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
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
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
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

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
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
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_sy">生成的带文字水印的图片路径</param>
        /// <param name="addText">生成的文字</param>
        /// <param name="IsDeleteOld">是否删除旧图片</param>
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
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        /// <param name="IsDeleteOld">是否删除旧图片</param>
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
        ///检查文件类型是否允许上传
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
        /// 判断上传文件大小是否超过设置的最大值
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
