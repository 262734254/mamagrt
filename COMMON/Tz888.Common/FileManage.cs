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

        #region ����ļ������Ƿ������ϴ�
        ///<summary>
        ///����ļ������Ƿ������ϴ�
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

        #region �ж��ϴ��ļ���С�Ƿ񳬹����õ����ֵ
        /// <summary>
        /// �ж��ϴ��ļ���С�Ƿ񳬹����õ����ֵ
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

        #region ɾ��ָ���ļ�
        /// <summary>
        /// ɾ��ָ���ļ�
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

        #region ɾ��ָ���ļ�
        /// <summary>
        /// ɾ��ָ���ļ�
        /// </summary>
        public static void Delete(string FileFullPath)
        {
            if (File.Exists(FileFullPath))
            {
                File.Delete(FileFullPath);
            }
        }

        #endregion

        #region ����ɾ��
        public static void FileDelete(string filePath)
        {
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(filePath));
        }
        #endregion

        #region �ϴ��ļ�,���ط������ļ���
        /// <summary>
        /// �ϴ��ļ�,���ط������ļ���
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

        #region ��ȡ�����ļ��ı�����
        /// <summary>
        /// ��ȡ�����ļ��ı�����
        /// </summary>
        /// <param name="fileName">��ȡ�ļ�·���ļ���</param>
        /// <param name="encoding">����Ĭ��Ϊ'gb2312'</param>
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

        #region �����ļ�
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="fileContent">�ļ�����</param>
        /// <param name="SavePath">����·��</param>
        /// <param name="encoding">����Ĭ��Ϊ'gb2312'</param>
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

        #region ת���ļ�
        /// <summary>
        /// ת���ļ�
        /// </summary>
        /// <param name="OldFile">�����ļ���ַ(���������·���ļ���)</param>
        /// <param name="NewPath">���ļ�����·��(���������·�������ļ���)</param>
        /// <param name="IsDeleteOld">�Ƿ�ɾ��ԭ�ļ�</param>
        /// <param name="IsRewriteFileName">�Ƿ���д�ļ���</param>
        /// <param name="IsReturnFullPath">�Ƿ񷵻�����·��</param>
        /// <returns>ת�ƺ���ļ���ַ</returns>
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
