using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;

using Tz888.Model.Info.V124;
using Tz888.DALFactory;
using Tz888.IDAL.Info.V124;
using System.Data;

namespace Tz888.BLL.PageStatic.V124
{
    /// <summary>
    /// 投资静态页面生成
    /// </summary>
    public class CapitalPageStatic
    {
        //认证资源模板路径
        private const string CapitalTempChangeFileName = "CapitalTemplateCharges.html";
        //普通会员模板路径
        private const string CapitalTempFeeFileName = "CapitalTemplateFee.html";
        //拓富通会员摸版路径
        private const string CapitalTempVipFileName = "CapitalTemplateVIP.html";

        //最终文件的输出路径
        private const string CapitalTempEndFileTo = "";
        //图片路径
        private const string CapitalPicPath = "http://images.topfo.com/";
        //资源路径
        private const string CapitalResourcePath = "";

        private const string TagsUrl = "http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}";

        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly ICapitalInfo dal = DataAccess.CreateCapitalInfo_V124();
       
        #region 输出静态页面文件
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageCapital(string InfoID,ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                //系统路径
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
                //模板路径
                string TempCapitalPath = ConfigurationManager.AppSettings["CapitalTmpPath"].ToString(); //投资模板的存放位置
                //目标路径
                string TempCapitalPathTo = ConfigurationManager.AppSettings["CapitalTmpPathTo"].ToString(); //投资模板的存放位置

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名
                
                CapitalSetModel theCapital = new CapitalSetModel();

                byte AuditingStatus;
                string Title;
                string FrontDisplayTime;
                string Hit;
                string PriceIndex;
                bool blisCore;
                string Industry;
                string loginName;

                string ComAbout;
                string Strategy;
                bool HasPic;

                string FixPriceID;
                string DisplayTitle;
                string KeyWord;
                string Descript;
                int TemplateID;
                string HtmlFile;

                float InfoPrice;
                string InfoPriceName; //用于显示 

                string InfoOriginRoleName;

                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = "";

                string CapitalName = "";    //资本金额
                string CurrencyName = ""; //货币种类

                string CapitalTypeName = "";//资本类型:直投,银行,担保,风险....            

                string CooperationTypeName = "";//投资方式:资金借贷,股权投资,土地出让/租赁....
                List<string> lstCooperationTypeName = new List<string>();

                string AreaName;//投资区域

                string IndustryName = "";//所属行业 
                List<string> lstIndustryName = new List<string>();

                string StageName;
                string JionManageName;

                string OrgIntro;
                string PublishT;//发布日期
                string ValidatePeriod;//有效期
                string PublisLoginName;//发布者
                string TZYX;//投资意向,项目简介
                string ContractPersonName = "";//联系人姓名
                string ContractCellPhone = "";//联系人手机
                string ContractPersonCompanyName = "";//联系人公司名称
                string ContractPersonPhone = "";//联系人电话
                string ContractPersonFax = "";//联系人传真
                string ContractPersonAddress = "";//联系人地址
                string ContractPersonPostCode = "";//联系人邮编
                string ContractPersonWebsite = "";//联系人公司网站

                string ResourcePrice;//资源价格
                string ResourceValue;//资源价格
                string ResourceValueVip;//资源拓富通会员价

                string ResourceInfo1 = "";//资源提示信息1
                string ResourceInfo2 = "";//资源提示信息2

                string ManageType = "";//会员类型
                string UserDetail = "";//用户的公司详细信息
                string ManageTypeName = ""; //拓富通会员类型

                string UserGradeTypeID = "";
                #endregion

                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));

                #region 获取模板名称
                string TempName = "";

                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2 ||
                    Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 5)
                {
                    //认证资源模版
                    TempName = CapitalTempChangeFileName;
                }
                else
                {
                    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
                    UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(theCapital.MainInfoModel.LoginName.Trim());
                    
                    if (UserGradeTypeID == "1001")
                    {
                        //普通用户模板
                        TempName = CapitalTempFeeFileName;
                    }
                    else
                    {
                        //VIP会员模板
                        TempName = CapitalTempVipFileName;
                    }
                }
                #endregion

                #region 读取模板内容

                StreamReader srSource;
                string TmpFileName;
                TmpFileName = ApplicationRootPath + TempCapitalPath + TempName;
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

                if (theCapital.CapitalInfoModel == null || theCapital.CapitalInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = theCapital.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)theCapital.MainInfoModel.AuditingStatus;

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


                lstCooperationTypeName = theCapital.CapitalInfoModel.CooperationDemandTypeName;
                lstIndustryName = theCapital.CapitalInfoModel.IndustryBName;

                for(int i = 0; i < lstCooperationTypeName.Count ; i++)
                {
                    string temp = lstCooperationTypeName[i];
                    if (!string.IsNullOrEmpty(temp))
                    {
                        if(i != (lstCooperationTypeName.Count - 1))
                            CooperationTypeName += temp + " | ";
                        else
                            CooperationTypeName += temp;
                    }
                }

                for (int j = 0; j < lstIndustryName.Count; j++)
                {
                    string temp = lstIndustryName[j];
                    if (!string.IsNullOrEmpty(temp))
                    {
                        if (j != (lstIndustryName.Count - 1))
                            IndustryName += temp + " | ";
                        else
                            IndustryName += temp;
                    }
                }

                //投资区域
                AreaName = "";

                if (theCapital.CapitalInfoAreaModels != null)
                {
                    for (int k = 0; k < theCapital.CapitalInfoAreaModels.Count; k++)
                    {
                        string temparea = "";
                        Tz888.Model.Info.CapitalInfoAreaModel tempCIAM = theCapital.CapitalInfoAreaModels[k];
                        if (!string.IsNullOrEmpty(tempCIAM.CountryName))
                        {
                            temparea = tempCIAM.CountryName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.ProvinceName))
                        {
                            temparea += tempCIAM.ProvinceName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CityName))
                        {
                            temparea += tempCIAM.CityName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CountyName))
                        {
                            temparea += tempCIAM.CountyName.Trim();
                        }
                        if (!string.IsNullOrEmpty(AreaName) && k != theCapital.CapitalInfoAreaModels.Count - 1)
                            temparea += " | ";
                        AreaName += temparea;
                    }    
                }
                else
                {
                    AreaName = "不限";
                }

                StageName = theCapital.CapitalInfoModel.StageName;
                JionManageName = theCapital.CapitalInfoModel.Joinmanagename;
                OrgIntro = theCapital.InfoContactModel.OrgIntro;

                PublishT = theCapital.MainInfoModel.publishT.ToString("yyyy-MM-dd");
                ValidatePeriod = theCapital.MainInfoModel.publishT.AddMonths(theCapital.MainInfoModel.ValidateTerm).ToString("yyyy-MM-dd");

                if (theCapital.CapitalInfoModel.ComBreif.Trim() != "")
                    TZYX = theCapital.CapitalInfoModel.ComBreif.Trim();
                else
                    TZYX = theCapital.CapitalInfoModel.ComAbout.Trim();

                loginName = theCapital.MainInfoModel.LoginName.Trim();


                Title = theCapital.MainInfoModel.Title;
                FrontDisplayTime = theCapital.MainInfoModel.FrontDisplayTime.ToShortDateString();
                Hit = theCapital.MainInfoModel.Hit.ToString();
                blisCore = theCapital.MainInfoModel.IsCore;
                FixPriceID = theCapital.MainInfoModel.FixPriceID;

                CapitalTypeName = theCapital.CapitalInfoModel.CapitalTypeName.Trim();
                CapitalName = theCapital.CapitalInfoModel.CapitalName.Trim();

                KeyWord = theCapital.MainInfoModel.KeyWord;

                string[] keys = KeyWord.Split(',');

                KeyWord = "";

                foreach (string temp in keys)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        KeyWord += string.Format(TagslinkModel, temp, temp) + " ";
                    }
                }

                if (string.IsNullOrEmpty(KeyWord))
                    KeyWord = string.Format(TagslinkModel, "投资", "投资");

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = theCapital.MainInfoModel.HtmlFile;

                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (theCapital.MainInfoModel.DisplayTitle == "")
                {
                    theCapital.MainInfoModel.DisplayTitle = Title;
                }
                DisplayTitle = theCapital.MainInfoModel.DisplayTitle + "－" + "中国招商投资网";
                Descript = theCapital.MainInfoModel.Descript;
                TemplateID = Convert.ToInt32(theCapital.MainInfoModel.TemplateID);

                ManageType = this.GetManageType(loginName).Trim();
                string WebUrl = "";
                string ComIntro = "";
                string TopfoDoc = "";
                string Target = "_self";

                if (ManageType == "2005")
                {
                    ManageTypeName = "资源联盟会员";
                }
                else if (ManageType == "2004")
                {
                    ManageTypeName = "资源认证中心";
                }

                #endregion 变量赋值

                #region 替换模版

                #region Vip的模板
                if (TempName.Trim() == CapitalTempVipFileName)//Vip模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_Title}", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Title}", Title);
                    TmpTmpSource = TmpTmpSource.Replace("{#@LoginName}", loginName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@PublishTime}", PublishT);

                    TmpTmpSource = TmpTmpSource.Replace("{#@CapitalType}", CapitalTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Currency}", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CooperationDemand}", CooperationTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CapitalIntent}", TZYX);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Industry}", IndustryName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Area}", AreaName);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Stage}", StageName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@JoinManage}", JionManageName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@GovIntro}", OrgIntro);

                    TmpTmpSource = TmpTmpSource.Replace("{#@ValiditeTerm}", ValidatePeriod);
                    TmpTmpSource = TmpTmpSource.Replace("{#@InfoID}", InfoID);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_KeyWord}", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("{@Page_Descript}", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_Domain}", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_LoginName}", loginName);
                }
                #endregion

                #region 收费的模板
                if (TempName.Trim() == CapitalTempChangeFileName)//收费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_Title}", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Title}", Title);
                    TmpTmpSource = TmpTmpSource.Replace("{#@LoginName}", loginName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@PublishTime}", PublishT);

                    TmpTmpSource = TmpTmpSource.Replace("{#@InfoResource}", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CapitalType}", CapitalTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Currency}", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CooperationDemand}", CooperationTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CapitalIntent}", TZYX);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Industry}", IndustryName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Area}", AreaName);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Stage}", StageName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@JoinManage}", JionManageName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@GovIntro}", OrgIntro);

                    TmpTmpSource = TmpTmpSource.Replace("{#@ValiditeTerm}", ValidatePeriod);
                    TmpTmpSource = TmpTmpSource.Replace("{#@InfoID}", InfoID);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_KeyWord}", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("{@Page_Descript}", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_Domain}", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_LoginName}", loginName);
                }
                #endregion

                #region 免费的模板
                if (TempName.Trim() == CapitalTempFeeFileName)//免费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_Title}", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Title}", Title);
                    TmpTmpSource = TmpTmpSource.Replace("{#@PublishTime}", PublishT);
                    TmpTmpSource = TmpTmpSource.Replace("{#@LoginName}", loginName);

                    TmpTmpSource = TmpTmpSource.Replace("{#@CapitalType}", CapitalTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Currency}", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CooperationDemand}", CooperationTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@CapitalIntent}", TZYX);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Industry}", IndustryName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Area}", AreaName);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Stage}", StageName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@JoinManage}", JionManageName);
                    TmpTmpSource = TmpTmpSource.Replace("{#@GovIntro}", OrgIntro);

                    TmpTmpSource = TmpTmpSource.Replace("{#@ValiditeTerm}", ValidatePeriod);
                    TmpTmpSource = TmpTmpSource.Replace("{#@InfoID}", InfoID);

                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_KeyWord}", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("{@Page_Descript}", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_Domain}", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("{#@Page_LoginName}", loginName);
                }
                #endregion

                #endregion

                #region 输出文件
                OutPutFilePath = ApplicationRootPath + TempCapitalPathTo.Trim() + HtmlFile;

                //检查路径是否正确
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Capital<br>");
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
            catch(Exception ex)
            {
                string err = ex.Message.ToString().Trim();
                sbUpdateMsg.Append(err);
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
        }
        #endregion

        #region 通过InfoID获取一个信息实体
        /// <summary>
        /// 通过InfoID获取一个Capital的信息实体
        /// </summary>
        /// <returns></returns>
        public CapitalSetModel objGetCapitalInfoByInfoID(long InfoID)
        {
           
            CapitalSetModel TheCapitalInfo = new CapitalSetModel();
            TheCapitalInfo = dal.GetIntegrityModel(InfoID);
            return TheCapitalInfo;             
        }
        #endregion

        #region 获取会员的展厅资料
       
        /// <summary>
        /// 获取企业会员的展厅资料
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetEnterpriseInfo(string loginName)
        {
            Tz888.BLL.Register.common combll = new Tz888.BLL.Register.common();
            return combll.GetEnterpriseInfo(loginName);
        }

        /// <summary>
        /// 获取招商会员的展厅资料
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetGovernmentInfo(string loginName)
        {
            Tz888.BLL.Register.common combll = new Tz888.BLL.Register.common();
            return combll.GetGovernmentInfo(loginName);
        }
        #endregion

        #region 获取会员类型
        public string GetManageType(string loginName)
        {
            Tz888.BLL.Register.LoginInfoBLL lbll = new Tz888.BLL.Register.LoginInfoBLL();
            return lbll.GetManageTypeID(loginName);
        }
        
        #endregion

    }
}
