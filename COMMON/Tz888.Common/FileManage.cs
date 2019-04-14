using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Web;

namespace Tz888.Common
{
    public class FileManage
    {

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

        #region 删除指定文件
        /// <summary>
        /// 删除指定文件
        /// </summary>
        public static void Delete(string FilePath, string FileName)
        {
            if (FilePath.LastIndexOf("\\") == FilePath.Length)
            {
                if (File.Exists(FilePath + FileName))
                {
                    File.Delete(FilePath + FileName);
                }
            }
            else
            {
                if (File.Exists(FilePath + "\\" + FileName))
                {
                    File.Delete(FilePath + "\\" + FileName);
                }
            }
        }
        #endregion

        #region 删除指定文件
        /// <summary>
        /// 删除指定文件
        /// </summary>
        public static void Delete(string FileFullPath)
        {
            if (File.Exists(FileFullPath))
            {
                File.Delete(FileFullPath);
            }
        }

        #endregion

        #region 物理删除
        public static void FileDelete(string filePath)
        {
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(filePath));
        }
        #endregion

        #region 上传文件,返回服务器文件名
        /// <summary>
        /// 上传文件,返回服务器文件名
        /// </summary>
        public static string SaveFile(HtmlInputFile Controls, string FilePath,bool IsOnlyRequestFileName)
        {
            string FileName = "";
            string FullFilePath = "";
            bool IsFileNameRewrite = Tz888.Common.ConfigHelper.GetConfigBool("IsFileNameRewrite");

            if (FilePath == "")
                FilePath = "UploadFile\\TmpFile\\" + DateTime.Now.ToString("yyyyMM") + "\\"; 
        
            FullFilePath = Tz888.Common.Common.GetUploadFileRootPath() + FilePath;

            if (!Directory.Exists(FullFilePath))
                Directory.CreateDirectory(FullFilePath);

            if (!string.IsNullOrEmpty(Controls.PostedFile.FileName))
            {
                FileName = Controls.PostedFile.FileName;

                if (IsFileNameRewrite)
                {
                    FileName = FileName.Substring(FileName.LastIndexOf("."));
                    FileName = Tz888.Common.Common.CreateFileName() + FileName;
                }
                else
                {
                    FileName = FileName.Substring(FileName.LastIndexOf('\\'));
                }

                Controls.PostedFile.SaveAs(FullFilePath + FileName);
            }
            if (!IsOnlyRequestFileName)
            {
                FileName = FilePath + FileName;
            }
            return FileName;
        }

        #endregion

        #region 读取返回文件文本内容
        /// <summary>
        /// 读取返回文件文本内容
        /// </summary>
        /// <param name="fileName">读取文件路径文件名</param>
        /// <param name="encoding">编码默认为'gb2312'</param>
        /// <returns></returns>
        public static string ReadFile(string fileName, string encoding)
        {
            string Template = "";
            if (encoding == "")
            {
                encoding = "GB2312";
            }
            StreamReader srTmp = null;
            try
            {
                srTmp = new StreamReader(fileName, System.Text.Encoding.GetEncoding(encoding), true);
                Template = srTmp.ReadToEnd();
            }
            finally
            {
                if (srTmp != null)
                {
                    srTmp.Close();
                }
            }
            return Template;
        }
        #endregion

        #region 生成文件
        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="fileContent">文件内容</param>
        /// <param name="SavePath">保持路径</param>
        /// <param name="encoding">编码默认为'gb2312'</param>
        /// <returns></returns>
        public static bool WriteFile(string fileContent, string SavePath, string encoding)
        {
            if (encoding == "")
            {
                encoding = "GB2312";
            }
            StreamWriter swOutPut = null;
            try
            {
                if (File.Exists(SavePath))
                {
                    FileAttributes fa = File.GetAttributes(SavePath);

                    if ((fa & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        File.SetAttributes(SavePath, fa & ~FileAttributes.ReadOnly);
                    }
                }
                swOutPut = new StreamWriter(SavePath, false, System.Text.Encoding.GetEncoding(encoding));
                swOutPut.Write(fileContent);
                swOutPut.Flush();
            }
            catch (Exception ex)
            {
                if (swOutPut != null)
                {
                    swOutPut.Close();
                }
                return false;
            }
            finally
            {
                if (swOutPut != null)
                {
                    swOutPut.Close();
                }
            }
            return true;
        }
        #endregion

        #region 转移文件
        /// <summary>
        /// 转移文件
        /// </summary>
        /// <param name="OldFile">已有文件地址(服务器相对路径文件名)</param>
        /// <param name="NewPath">新文件保存路径(服务器相对路径不含文件名)</param>
        /// <param name="IsDeleteOld">是否删除原文件</param>
        /// <param name="IsRewriteFileName">是否重写文件名</param>
        /// <param name="IsReturnFullPath">是否返回完整路径</param>
        /// <returns>转移后的文件地址</returns>
        public static string TransferFile(string OldFile, string NewPath, bool IsDeleteOldFile, bool IsRewriteFileName,bool IsReturnFullPath)
        {
            string ServerPath = HttpRuntime.AppDomainAppPath;
            OldFile = OldFile.Replace("/", "\\");
            string FileName = OldFile.Substring(OldFile.LastIndexOf("\\") + 1);
            string NewFile = NewPath + FileName;
            if (IsRewriteFileName)
            {
                string FileExtension = FileName.Substring(FileName.LastIndexOf("."));
                string NewFileName = Tz888.Common.Common.CreateFileName() + FileExtension;
                while (File.Exists(ServerPath + NewPath + NewFileName))
                {
                    NewFileName = Tz888.Common.Common.CreateFileName() + FileExtension;
                }
                NewFile = NewPath + NewFileName;
            }
            if (File.Exists(ServerPath + OldFile))
            {
                File.Move(ServerPath + OldFile, ServerPath + NewFile);
                if (IsDeleteOldFile)
                {
                    File.Delete(ServerPath + OldFile);
                }
            }
            if (IsReturnFullPath)
                return ServerPath + NewFile;
            return NewFile;
        }
        #endregion
    }
}
