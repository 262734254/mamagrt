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
        private const string VideoTempFeeFileName = "TempVideoFee.htm";         //VideoFee免费模板路径
        private const string VideoTempEndFileTo = "";                           //最终文件的输出路径
        private const string VideoPicPath = "http://images.topfo.com/";         //图片路径
        private const string VideoResourcePath = "";                            //资源路径
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultMerchant.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly ITPVideo dal = DataAccess.CreateITPVideo();

        #region 输出静态页面文件
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        /// <param name="IsLog">是否需要将信息写入日志</param>
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageVideo(string InfoID, string HtmlUrlStr, Tz888.Model.TPVideo TheVideo, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); ////系统路径,静态页面的根目录
                string TempVideoPath = ConfigurationManager.AppSettings["VideoTmpPath"].ToString(); ////模板路径,融资模板的存放位置
                string TempVideoPathTo = ConfigurationManager.AppSettings["VideoTmpPathTo"].ToString(); ////目标路径,融资模板的存放位置
                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名
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

                #region 获取模板名称与读取模板内容
                string TempName = VideoTempFeeFileName;     //获取模板名称

                //读取模板内容
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
                    sbUpdateMsg.Append("[E]模板读取出错:" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                try
                {
                    TmpSource = srSource.ReadToEnd();
                }
                catch (Exception e)
                {
                    sbUpdateMsg.Append("[E]模板读取出错:" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                finally
                {
                    srSource.Close();
                }
                #endregion

                #region 变量赋值
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

                #region 错误判断
                if (TheVideo == null || TheVideo.infoID <= 0)
                {
                    sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                if (AuditingStatus != 1)
                {
                    sbUpdateMsg.Append("[E]信息未通过审核，不允许生成静态文件!<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                #endregion

                #region 替换免费的模板
                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;
                long HaveDoneCount = 0;

                if (TempName.Trim() == VideoTempFeeFileName)//免费的模板
                {
                    TmpTmpSource = TmpSource;
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-DisplayTitle#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-Descript#", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-KeyWords#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", "中国" + " " + getAddrNameById(ProvinceID ,CityID , CountyID));
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", "不限");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublisLoginName#", publishT.ToString());
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-VideoUrl#", ImageDomain + HtmlURL);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Content#", Content);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", Created.ToShortDateString());
                }
                #endregion

                #region 输出文件
                OutPutFilePath = ApplicationRootPath + TempVideoPathTo.Trim() + HtmlUrlStr;

                //检查路径是否正确
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Video<br>");
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
                    sbUpdateMsg.Append("[E]信息静态化[ " + InfoID.ToString() + " ]" + e.Message + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                try
                {
                    swOutPut.Write(TmpTmpSource);
                    swOutPut.Flush();
                    sbUpdateMsg.Append("[i]信息静态化[ " + InfoID.ToString() + " ]生成成功<br>");
                }
                catch (Exception e)
                {
                    sbUpdateMsg.Append("[E]信息静态化[ " + InfoID.ToString() + " ]" + e.Message + "<br>");
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

        #region 获取地址
        /// <summary>
        /// 通过InfoID获取一个Merchant的信息实体
        /// </summary>
        /// <returns></returns>
        public string getAddrNameById(string ProvinceID,string CityID,string CountyID)
        {
            return dal.getAddrNameById(ProvinceID, CityID, CountyID);
        }
        #endregion

        #region 通过InfoID获取一个信息实体
        /// <summary>
        /// 通过InfoID获取一个Merchant的信息实体
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
