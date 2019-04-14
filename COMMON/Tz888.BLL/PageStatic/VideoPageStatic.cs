using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;

using Tz888.Model.Info;
using Tz888.DALFactory;
using Tz888.IDAL.Info;
using Tz888.IDAL;
using System.Data;

namespace Tz888.BLL.PageStatic
{
    public class VideoPageStatic
    {
        private const string VideoTempFeeFileName = "TempVideoFee.htm";         //VideoFee���ģ��·��
        private const string VideoTempEndFileTo = "";                           //�����ļ������·��
        private const string VideoPicPath = "http://images.topfo.com/";         //ͼƬ·��
        private const string VideoResourcePath = "";                            //��Դ·��
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultMerchant.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly ITPVideo dal = DataAccess.CreateITPVideo();

        #region �����̬ҳ���ļ�
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        /// <param name="IsLog">�Ƿ���Ҫ����Ϣд����־</param>
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageVideo(string InfoID, string HtmlUrlStr, Tz888.Model.TPVideo TheVideo, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); ////ϵͳ·��,��̬ҳ��ĸ�Ŀ¼
                string TempVideoPath = ConfigurationManager.AppSettings["VideoTmpPath"].ToString(); ////ģ��·��,����ģ��Ĵ��λ��
                string TempVideoPathTo = ConfigurationManager.AppSettings["VideoTmpPathTo"].ToString(); ////Ŀ��·��,����ģ��Ĵ��λ��
                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����
                //Tz888.Model.TPVideo TheVideo = new Tz888.Model.TPVideo();

                string AuditingRemark = "";
                int AuditingStatus = 0;
                string Author = "";
                string CityID = "";
                string Content = "";
                string CountyID = "";
                string Createby = "";
                DateTime Created = new DateTime();
                string Descript = "";
                long Hit = 0;
                string HtmlURL = "";
                string InfoCode = "";
                long infoID = 0;
                string infotypeID = "";
                int IsCore = 0;
                int IsRedirect = 0;
                string KeyWord = "";
                string LoginName = "";
                string MiniatureUrl = "";
                string Origin = "";
                string ProvinceID = "";
                DateTime publishT = new DateTime();
                string RedirectUrl = "";
                string strRemark = "";
                string subTitle = "";
                string Summary = "";
                string Title = "";

                #endregion

                //TheVideo = this.objGetVideoInfoByInfoID(long.Parse(InfoID.Trim()));

                #region ��ȡģ���������ȡģ������
                string TempName = VideoTempFeeFileName;     //��ȡģ������

                //��ȡģ������
                StreamReader srSource;
                string TmpFileName;
                TmpFileName = ApplicationRootPath + TempVideoPath + TempName;
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

                #region ������ֵ
                AuditingRemark = TheVideo.AuditingRemark;
                AuditingStatus = TheVideo.AuditingStatus;
                Author = TheVideo.Author;
                CityID = TheVideo.CityID;
                Content = TheVideo.Content;
                CountyID = TheVideo.CountyID;
                Createby = TheVideo.Createby;
                Created = TheVideo.Created;
                Descript = TheVideo.Descript;
                Hit = TheVideo.Hit;
                HtmlURL = TheVideo.HtmlURL;
                InfoCode = TheVideo.InfoCode;
                infoID = TheVideo.infoID;
                infotypeID = TheVideo.infotypeID;
                IsCore = TheVideo.IsCore;
                IsRedirect = TheVideo.IsRedirect;
                KeyWord = TheVideo.KeyWord;
                LoginName = TheVideo.LoginName;
                MiniatureUrl = TheVideo.MiniatureUrl;
                Origin = TheVideo.Origin;
                ProvinceID = TheVideo.ProvinceID;
                publishT = TheVideo.publishT;
                RedirectUrl = TheVideo.RedirectUrl;
                strRemark = TheVideo.strRemark;
                subTitle = TheVideo.subTitle;
                Summary = TheVideo.Summary;
                Title = TheVideo.Title;
                #endregion

                #region �����ж�
                if (TheVideo == null || TheVideo.infoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                if (AuditingStatus != 1)
                {
                    sbUpdateMsg.Append("[E]��Ϣδͨ����ˣ����������ɾ�̬�ļ�!<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                #endregion

                #region �滻��ѵ�ģ��
                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;
                long HaveDoneCount = 0;

                if (TempName.Trim() == VideoTempFeeFileName)//��ѵ�ģ��
                {
                    TmpTmpSource = TmpSource;
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-DisplayTitle#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-Descript#", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-KeyWords#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", "�й�" + " " + getAddrNameById(ProvinceID ,CityID , CountyID));
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", "����");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublisLoginName#", publishT.ToString());
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-VideoUrl#", ImageDomain + HtmlURL);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Content#", Content);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", Created.ToShortDateString());
                }
                #endregion

                #region ����ļ�
                OutPutFilePath = ApplicationRootPath + TempVideoPathTo.Trim() + HtmlUrlStr;

                //���·���Ƿ���ȷ
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Video<br>");
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
        #endregion

        #region ��ȡ��ַ
        /// <summary>
        /// ͨ��InfoID��ȡһ��Merchant����Ϣʵ��
        /// </summary>
        /// <returns></returns>
        public string getAddrNameById(string ProvinceID,string CityID,string CountyID)
        {
            return dal.getAddrNameById(ProvinceID, CityID, CountyID);
        }
        #endregion

        #region ͨ��InfoID��ȡһ����Ϣʵ��
        /// <summary>
        /// ͨ��InfoID��ȡһ��Merchant����Ϣʵ��
        /// </summary>
        /// <returns></returns>
        public Tz888.Model.TPVideo objGetVideoInfoByInfoID(long InfoID)
        {
            Tz888.Model.TPVideo theTpVideo = new Tz888.Model.TPVideo();
            theTpVideo = dal.GetVideoModelByID(InfoID);
            return theTpVideo;
        }
        #endregion

    }
}
