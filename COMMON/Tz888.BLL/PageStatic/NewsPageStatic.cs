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
    /// 资讯静态页面生成
    /// </summary>
    public class NewsPageStatic
    {
        private readonly ITPMerchant obj = DataAccess.CreateITPMerchant();

        //NewsChange模板路径
        private const string NewsTempFileName = "TempNewsChange.htm"; 
        //最终文件的输出路径
        private const string NewsTempEndFileTo = "";
        //图片路径
        private const string NewsPicPath = "http://images.topfo.com/";
        //资源路径
        private const string NewsResourcePath = "";

        private const string TagsUrl = "http://search.topfo.com/SearchResultNews.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultNews.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly ITPMerchant dal = DataAccess.CreateITPMerchant();
        #region 输出静态页面文件
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        /// <param name="IsLog">是否需要将信息写入日志</param>
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageNews(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                //系统路径
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
                //模板路径
                string TempNewsPath = ConfigurationManager.AppSettings["NewsTmpPath"].ToString(); //融资模板的存放位置
                //目标路径
                string TempNewsPathTo = ConfigurationManager.AppSettings["NewsTmpPathTo"].ToString(); //融资模板的存放位置

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

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
                string InfoPriceName; //用于显示         
 
                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = ""; 

                string NewsTypeName;//资讯类型           
 
                string PublishT;//发布日期 
                string PublisLoginName;//发布者 
                #endregion 
                TheNews = obj.objGetNewsInfoByInfoID(long.Parse(InfoID.Trim()));  
                #region 读取模板内容

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

                #region 错误判断

                if (TheNews == null || TheNews.infoID <= 0)
                {
                    sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = TheNews.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)TheNews.auditingstatus;
                if (AuditingStatus > 1)
                {
                    sbUpdateMsg.Append("[E]审核未通过的信息不允许生成静态文件!<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }
                if (AuditingStatus != 1 && MemberGradeID != "1002")
                {
                    sbUpdateMsg.Append("[E]信息未审核且不是拓富通会员信息，不允许生成静态文件!<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                #endregion

                #region 变量赋值

                NewsTypeName = TheNews.NewsTypeName.Trim(); 
 

                //开始时间
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
                    KeyWord = "资讯";

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = TheNews.HtmlFile;
                if (HtmlFile.Trim() == "")
                {
                    HtmlFile = Tz888.BLL.Info.Common.createStaticPageFileName("News", TheNews.InfoCode.Trim(), TheNews.infoID); 
                    bool status = false;
                    status = obj.UpdateHtmlFile(TheNews.infoID, HtmlFile);
                    if (status == false)
                    {
                        sbUpdateMsg.Append("生成HtmlFile失败");
                        UpdateMsg = sbUpdateMsg.ToString();
                        return false;
                    }
                }
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (TheNews.DisplayTitle == "")
                {
                    TheNews.DisplayTitle = Title;
                }
                DisplayTitle = TheNews.DisplayTitle + "－" + "中国招商投资网";
                Descript = TheNews.Descript;
                TemplateID = Convert.ToInt32(TheNews.TemplateID);

                FrontDisplayTime = TheNews.FrontDisplayTime.ToShortDateString();

                #endregion

                #region 替换模版   
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

                #region 输出文件


                OutPutFilePath = ApplicationRootPath + TempNewsPathTo.Trim() + HtmlFile;

                //检查路径是否正确
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：News<br>");
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
    }
}
