using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;

using Tz888.Model;
using Tz888.DALFactory;
using Tz888.IDAL;
using System.Data;

namespace Tz888.BLL.PageStatic
{   
    /// <summary>
    /// ��Ѷ��̬ҳ������
    /// </summary>
    public class NewsPageStatic
    {
        private readonly ITPMerchant obj = DataAccess.CreateITPMerchant();

        //NewsChangeģ��·��
        private const string NewsTempFileName = "TempNewsChange.htm"; 
        //�����ļ������·��
        private const string NewsTempEndFileTo = "";
        //ͼƬ·��
        private const string NewsPicPath = "http://images.topfo.com/";
        //��Դ·��
        private const string NewsResourcePath = "";

        private const string TagsUrl = "http://search.topfo.com/SearchResultNews.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultNews.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly ITPMerchant dal = DataAccess.CreateITPMerchant();
        #region �����̬ҳ���ļ�
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        /// <param name="IsLog">�Ƿ���Ҫ����Ϣд����־</param>
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageNews(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                //ϵͳ·��
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
                //ģ��·��
                string TempNewsPath = ConfigurationManager.AppSettings["NewsTmpPath"].ToString(); //����ģ��Ĵ��λ��
                //Ŀ��·��
                string TempNewsPathTo = ConfigurationManager.AppSettings["NewsTmpPathTo"].ToString(); //����ģ��Ĵ��λ��

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

                Tz888.Model.TPMerchant TheNews = new Tz888.Model.TPMerchant();

                byte AuditingStatus;
                string Title;
                string FrontDisplayTime; 
                string DisplayTitle;
                string KeyWord;
                string Descript;
                int TemplateID;
                string HtmlFile;
                string loginName;
                string Origin;
                string Author;
                string Pic1;
                string PicAbout;
                string Content;

                float InfoPrice;
                string InfoPriceName; //������ʾ         
 
                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = ""; 

                string NewsTypeName;//��Ѷ����           
 
                string PublishT;//�������� 
                string PublisLoginName;//������ 
                #endregion 
                TheNews = obj.objGetNewsInfoByInfoID(long.Parse(InfoID.Trim()));  
                #region ��ȡģ������

                StreamReader srSource;
                string TmpFileName;
                TmpFileName = ApplicationRootPath + TempNewsPath + NewsTempFileName;
                string TmpSource = "";
                srSource = null;
                try
                {
                    srSource = new StreamReader(TmpFileName, System.Text.Encoding.GetEncoding("GB2312"));
                }
                catch (Exception e)
                {
                    sbUpdateMsg.Append("[E]ģ���ȡ����:" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                try
                {
                    TmpSource = srSource.ReadToEnd();
                }
                catch (Exception e)
                {
                    sbUpdateMsg.Append("[E]ģ���ȡ����:" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                finally
                {
                    srSource.Close();
                }
                #endregion

                #region �����ж�

                if (TheNews == null || TheNews.infoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = TheNews.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)TheNews.auditingstatus;
                if (AuditingStatus > 1)
                {
                    sbUpdateMsg.Append("[E]���δͨ������Ϣ���������ɾ�̬�ļ�!<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                if (AuditingStatus != 1 && MemberGradeID != "1002")
                {
                    sbUpdateMsg.Append("[E]��Ϣδ����Ҳ����ظ�ͨ��Ա��Ϣ�����������ɾ�̬�ļ�!<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                #endregion

                #region ������ֵ

                NewsTypeName = TheNews.NewsTypeName.Trim(); 
 

                //��ʼʱ��
                PublishT = TheNews.ValidateStartTime.ToShortDateString().Trim(); 
                PublisLoginName = TheNews.LoginName.ToString().Trim(); 
 

                Title = TheNews.Title;
                Content = TheNews.Content;

                loginName = TheNews.LoginName.Trim();
                Origin=TheNews.Origin;
                Author =TheNews.Author;
                Pic1= TheNews.Pic1;
                PicAbout=TheNews.PicAbout;
  

                KeyWord = TheNews.KeyWord;
                string[] keys = KeyWord.Split(',');
                KeyWord = "";
                foreach (string temp in keys)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        KeyWord += temp + " ";
                    }
                }

                if (string.IsNullOrEmpty(KeyWord))
                    KeyWord = "��Ѷ";

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = TheNews.HtmlFile;
                if (HtmlFile.Trim() == "")
                {
                    HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("News", TheNews.InfoCode.Trim(), TheNews.infoID); 
                    bool status = false;
                    status = obj.UpdateHtmlFile(TheNews.infoID, HtmlFile);
                    if (status == false)
                    {
                        sbUpdateMsg.Append("����HtmlFileʧ��");
                        UpdateMsg = sbUpdateMsg.ToString();
                        return false;
                    }
                }
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (TheNews.DisplayTitle == "")
                {
                    TheNews.DisplayTitle = Title;
                }
                DisplayTitle = TheNews.DisplayTitle + "��" + "�й�����Ͷ����";
                Descript = TheNews.Descript;
                TemplateID = Convert.ToInt32(TheNews.TemplateID);

                FrontDisplayTime = TheNews.FrontDisplayTime.ToShortDateString();

                #endregion

                #region �滻ģ��   
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpReffer-NewsTypeName#", NewsTypeName); 

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", Title); 
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", PublishT);
 
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublisLoginName#", PublisLoginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FrontDisplayTime#", FrontDisplayTime);
 
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Collection#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@LastCommentList#", "InfoID=" + InfoID + "&Title=" + Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Recommend#", InfoID); 
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-DisplayTitle#", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-Descript#", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Domain#", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-LoginName#", loginName);
 
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Origin#", Origin);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Author#", Author);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Editor#", loginName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PicUrl-1#", Pic1);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Content#", Content);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MatchII#", "");  
  
                #endregion

                #endregion

                #region ����ļ�


                OutPutFilePath = ApplicationRootPath + TempNewsPathTo.Trim() + HtmlFile;

                //���·���Ƿ���ȷ
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�News<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                swOutPut = null;
                try
                {
                    swOutPut = new StreamWriter(OutPutFilePath, false, System.Text.Encoding.GetEncoding("GB2312"));
                }
                catch (Exception e)
                {
                    sbUpdateMsg.Append("[E]��Ϣ��̬��[ " + InfoID.ToString() + " ]" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                try
                {
                    swOutPut.Write(TmpTmpSource);
                    swOutPut.Flush();
                    sbUpdateMsg.Append("[i]��Ϣ��̬��[ " + InfoID.ToString() + " ]���ɳɹ�<br>");
                }
                catch (Exception e)
                {
                    sbUpdateMsg.Append("[E]��Ϣ��̬��[ " + InfoID.ToString() + " ]" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                finally
                {
                    swOutPut.Close();
                }
                HaveDoneCount++;
                #endregion

                UpdateMsg = sbUpdateMsg.ToString();
                return true;
            }
            catch (Exception e)
            {
                string err = e.Message.ToString().Trim();
                sbUpdateMsg.Append(err);
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
        } 
    }
}
