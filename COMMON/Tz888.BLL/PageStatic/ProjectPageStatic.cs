using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;

using Tz888.Model.Info;
using Tz888.DALFactory;
using Tz888.IDAL.Info;
using System.Data;

namespace Tz888.BLL.PageStatic
{
    public class ProjectPageStatic
    {
        private const string ProjectTempChangeFileName = "TempProjectChange.htm";   //ProjectChange模板路径
        private const string ProjectTempFeeFileName = "TempProjectFee.htm";         //ProjectFee模板路径
        private const string ProjectTempFeeFileName_New = "TempProjectFee_New.htm";
        private const string ProjectTempVipFileName = "TempProjectVip.htm";         //ProjectVip摸版路径
        private const string ProjectTempVipFileName_New = "TempProjectVip_New.htm";
        private const string ProjectTempEndFileTo = "";                             //最终文件的输出路径
        private const string ProjectPicPath = "http://images.topfo.com/";           //图片路径
        private const string ProjectResourcePath = "";                              //资源路径
        //=========新模板
        // private const string Project_Check
        private const string Project_ZQ = "Project_ZQ.htm";//债券融资
        private const string Project_GQ = "Project_GQ.htm";//股权融资
        private const string Project_ZQ_Vip = "Project_ZQ_Vip.htm";
        private const string Project_GQ_Vip = "Project_GQ_Vip.htm";
        private const string TagsUrl = "http://search.topfo.com/SearchResultProject.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultProject.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";
        private readonly IProjectInfo dal = DataAccess.CreateInfo_ProjectInfo();


        #region 输出静态页面文件
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        /// <param name="IsLog">是否需要将信息写入日志</param>
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageProject_before20100820(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                //系统路径
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
                //模板路径
                string TempProjectPath = ConfigurationManager.AppSettings["ProjectTmpPath"].ToString(); //融资模板的存放位置
                //目标路径
                string TempProjectPathTo = ConfigurationManager.AppSettings["ProjectTmpPathTo"].ToString(); //融资模板生成存放位置

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

                ProjectSetModel TheProject = new ProjectSetModel();

                byte AuditingStatus;
                string Title;
                string FrontDisplayTime;
                string Hit;
                string PriceIndex;
                bool blisCore;
                string Industry;
                string Area;

                string ComAbout;
                string Strategy;
                bool HasPic;
                string Pic1 = "";
                string Pic1_c = "";
                string Pic1_s = "";
                string Pic1_r = "";
                string Pic2 = "";
                string Pic2_c = "";
                string Pic2_s = "";
                string Pic2_r = "";
                string Pic3 = "";
                string Pic3_c = "";
                string Pic3_s = "";
                string Pic3_r = "";
                string Pic4 = "";
                string Pic4_c = "";
                string Pic4_s = "";
                string Pic4_r = "";
                string Pic5 = "";
                string Pic5_c = "";
                string Pic5_s = "";
                string Pic5_r = "";
                string Pic6 = "";
                string Pic6_c = "";
                string Pic6_s = "";
                string Pic6_r = "";

                string Doc1 = "";
                string Doc1_c = "";
                string Doc1_r = "";
                string Doc2 = "";
                string Doc2_c = "";
                string Doc2_r = "";
                string Doc3 = "";
                string Doc3_c = "";
                string Doc3_r = "";

                string FixPriceID;
                string DisplayTitle;
                string KeyWord;
                string Descript;
                int TemplateID;
                string HtmlFile;
                string loginName;

                float InfoPrice;
                string InfoPriceName; //用于显示         

                string InfoOriginRoleName;

                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = "";

                string ProjectName;
                string CapitalName = ""; //资本金额
                string CurrencyName; //货币种类

                string ProjectNameTotal;//总投资金额
                string ProjectCurrencyName; //总投资货币种类

                string ProjectTypeName;//资本类型:直投,银行,担保,风险....            

                string CooperationTypeName;//投资方式:资金借贷,股权投资,土地出让/租赁....
                List<string> lstCooperationTypeName = new List<string>();

                string AreaName;//投资区域

                string IndustryName;//所属行业 
                List<string> lstIndustryName = new List<string>();

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

                string UserGradeTypeID = "";//会员类型
                #endregion

                TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));

                #region 获取模板名称
                string TempName = "";

                if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    //认证资源模版
                    TempName = ProjectTempChangeFileName;
                }
                else
                {
                    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
                    UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(TheProject.MainInfoModel.LoginName.Trim());
                    if (UserGradeTypeID == "1001")
                    {
                        //普通用户模板
                        TempName = ProjectTempFeeFileName;
                    }
                    else
                    {
                        //VIP会员模板
                        TempName = ProjectTempVipFileName;
                    }
                }

                #endregion

                #region 读取模板内容

                StreamReader srSource;
                string TmpFileName;
                TmpFileName = ApplicationRootPath + TempProjectPath + TempName;
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

                if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = TheProject.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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

                ProjectTypeName = "";
                ProjectName = TheProject.ProjectInfoModel.ProjectName.Trim();
                ProjectNameTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString().Trim();


                //合作方式
                CooperationTypeName = "";
                foreach (string sCoopTypeName in TheProject.ProjectInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName += sCoopTypeName.Trim() + " ";
                }

                //投资区域
                AreaName = "";

                if (TheProject.ProjectInfoModel != null)
                {
                    if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountryName))
                    {
                        AreaName = TheProject.ProjectInfoModel.CountryName.Trim();
                    }
                    if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.ProvinceName))
                    {
                        AreaName += " " + TheProject.ProjectInfoModel.ProvinceName;
                    }
                    if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CityName))
                    {
                        AreaName += " " + TheProject.ProjectInfoModel.CityName;
                    }
                    if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountyName))
                    {
                        AreaName += " " + TheProject.ProjectInfoModel.CountyName;
                    }
                }



                //所属于行业
                IndustryName = "";
                foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }

                //开始时间
                PublishT = TheProject.MainInfoModel.ValidateStartTime.ToShortDateString().Trim();
                //结束时间
                ValidatePeriod = TheProject.MainInfoModel.ValidateTerm.ToString().Trim();

                PublisLoginName = TheProject.MainInfoModel.LoginName.ToString().Trim();
                TZYX = TheProject.ProjectInfoModel.ComAbout.Trim();

                if (TheProject.ProjectInfoModel.ComBrief.Trim() != "")
                    TZYX = TheProject.ProjectInfoModel.ComBrief.Trim();
                else
                    TZYX = TheProject.ProjectInfoModel.ComAbout.Trim();

                //联系人个人
                ContractPersonName = "";
                ContractCellPhone = "";

                if (TheProject.InfoContactModel != null)
                {
                    ContractPersonName = TheProject.InfoContactModel.Name.Trim();
                    ContractCellPhone = TheProject.InfoContactModel.Mobile.Trim();
                    if (TheProject.InfoContactManModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoContactManModel icmTemp in TheProject.InfoContactManModels)
                        {
                            ContractPersonName = ContractPersonName + icmTemp.Name.Trim();
                            ContractCellPhone = ContractCellPhone + icmTemp.Mobile.Trim();
                        }
                    }
                    //联系人公司

                    ContractPersonCompanyName = TheProject.InfoContactModel.OrganizationName.Trim();
                    ContractPersonPhone = TheProject.InfoContactModel.TelNum.Trim();
                    ContractPersonFax = TheProject.InfoContactModel.FaxNum.Trim();
                    ContractPersonAddress = TheProject.InfoContactModel.Address.Trim();
                    ContractPersonPostCode = TheProject.InfoContactModel.PostCode.Trim();
                    ContractPersonWebsite = TheProject.InfoContactModel.WebSite.Trim();
                }

                Title = TheProject.MainInfoModel.Title;
                FrontDisplayTime = TheProject.MainInfoModel.FrontDisplayTime.ToShortDateString();
                Hit = TheProject.MainInfoModel.Hit.ToString();
                blisCore = TheProject.MainInfoModel.IsCore;
                FixPriceID = TheProject.MainInfoModel.FixPriceID;

                Industry = TheProject.ProjectInfoModel.IndustryBID;

                loginName = TheProject.MainInfoModel.LoginName.Trim();



                ProjectName = TheProject.ProjectInfoModel.ProjectName;
                ProjectNameTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString().Trim();
                ProjectCurrencyName = TheProject.ProjectInfoModel.CapitalCurrency.Trim().ToLower();
                switch (ProjectCurrencyName)
                {
                    case "cny":
                        ProjectCurrencyName = "人民币";
                        break;
                    case "hkd":
                        ProjectCurrencyName = "港币";
                        break;
                    case "usd":
                        ProjectCurrencyName = "美元";
                        break;
                    default:
                        ProjectCurrencyName = "人民币";
                        break;
                }

                CapitalName = TheProject.ProjectInfoModel.CapitalName;
                CurrencyName = TheProject.ProjectInfoModel.ProjectCurrency.Trim().ToLower();
                switch (CurrencyName)
                {
                    case "cny":
                        CurrencyName = "人民币";
                        break;
                    case "hkd":
                        CurrencyName = "港币";
                        break;
                    case "usd":
                        CurrencyName = "美元";
                        break;
                    default:
                        CurrencyName = "人民币";
                        break;
                }
                if (CapitalName.Trim() == "不限")
                    CurrencyName = "";


                //资源价格
                if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0))
                {
                    ResourceInfo1 = "为提高对接质量，该资源被用户设置为付费资源";
                    ResourceInfo2 = "购买";
                    ResourceValue = Convert.ToDecimal(TheProject.MainInfoModel.MainPointCount.ToString().Trim()).ToString("c");
                    Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
                    Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
                    objDic = diBll.GetModel("1");
                    ResourceValueVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * TheProject.MainInfoModel.MainPointCount)).ToString("c");
                    //ResourceValueVip = "0.00";

                    ResourcePrice = "<tr>" +
                                        "<td class=\"h\">" +
                                            "资源价格：</td>" +
                                        "<td>" +
                                        "<span class=\"orange01\"><strong>" + ResourceValue + "</strong>" +
                                        "</span>元（拓富通会员价：<span class=\"orange01\"><strong>" + ResourceValueVip + "</strong></span>元）</td>" +
                                     "</tr>";
                }
                else
                {
                    ResourceInfo1 = "该资源为免费资源";
                    ResourceInfo2 = "收藏";
                    ResourcePrice = "";
                }


                ArrayList arrListPic = new ArrayList();
                ArrayList arrListDoc = new ArrayList();
                if (TheProject.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in TheProject.InfoResourceModels)
                    {
                        //ResourceType 0:其他文档 1：图片 2：视频
                        if (objModelResource.ResourceType.ToString().Trim() == "1")
                        {
                            string[] arTempPic = new string[2];
                            arTempPic[0] = objModelResource.ResourceAddr.Trim();
                            arTempPic[1] = objModelResource.ResourceName.Trim();
                            arrListPic.Add(arTempPic);
                        }
                        if (objModelResource.ResourceType.ToString().Trim() == "0")
                        {
                            string[] arTempDoc = new string[2];
                            arTempDoc[0] = objModelResource.ResourceAddr.Trim();
                            arTempDoc[1] = objModelResource.ResourceName.Trim();
                            arrListDoc.Add(arTempDoc);
                        }
                    }
                }
                if (arrListPic.Count > 0)
                {
                    string[] sPicTemp = (string[])arrListPic[0];
                    Pic1 = sPicTemp[0];
                    Pic1_c = sPicTemp[1];
                    //Pic1_s = Common.GetMiniPic(Pic1);
                    Pic1_s = Pic1;
                    Pic1_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic1_s.Trim() + "\" target=\"_blank\"><img src=" + ProjectPicPath.Trim() + Pic1_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }

                if (arrListPic.Count > 1)
                {
                    string[] sPicTemp = (string[])arrListPic[1];
                    Pic2 = sPicTemp[0];
                    Pic2_c = sPicTemp[1];
                    //Pic2_s = Common.GetMiniPic(Pic2);
                    Pic2_s = Pic2;
                    Pic2_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic2_s.Trim() + "\" target=\"_blank\"><img src=" + ProjectPicPath.Trim() + Pic2_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 2)
                {
                    string[] sPicTemp = (string[])arrListPic[2];
                    Pic3 = sPicTemp[0];
                    Pic3_c = sPicTemp[1];
                    //Pic3_s = Common.GetMiniPic(Pic3);
                    Pic3_s = Pic3;
                    Pic3_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic3_s.Trim() + "\" target=\"_blank\"><img src=" + ProjectPicPath.Trim() + Pic3_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 3)
                {
                    string[] sPicTemp = (string[])arrListPic[3];
                    Pic4 = sPicTemp[0];
                    Pic4_c = sPicTemp[1];
                    //Pic4_s = Common.GetMiniPic(Pic4);
                    Pic4_s = Pic4;
                    Pic4_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic4_s.Trim() + "\" target=\"_blank\"><img src=" + ProjectPicPath.Trim() + Pic4_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 4)
                {
                    string[] sPicTemp = (string[])arrListPic[4];
                    Pic5 = sPicTemp[0];
                    Pic5_c = sPicTemp[1];
                    //Pic5_s = Common.GetMiniPic(Pic5);
                    Pic5_s = Pic5;
                    Pic5_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic5_s.Trim() + "\" target=\"_blank\"><img src=" + ProjectPicPath.Trim() + Pic5_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 5)
                {
                    string[] sPicTemp = (string[])arrListPic[5];
                    Pic6 = sPicTemp[0];
                    Pic6_c = sPicTemp[1];
                    //Pic6_s = Common.GetMiniPic(Pic6);
                    Pic6_s = Pic6;
                    Pic6_r = "<li><a href=\"" + ProjectPicPath.Trim() + Pic6_s.Trim() + "\" target=\"_blank\"><img src=" + ProjectPicPath.Trim() + Pic6_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }


                if (arrListDoc.Count > 0)
                {
                    string[] sDocTemp = (string[])arrListDoc[0];
                    Doc1 = sDocTemp[0];
                    Doc1_c = sDocTemp[1];
                    Doc1_r = "<li>" + Doc1_c + "：<a href='" + Doc1 + "'>查看</a><a href='" + ProjectResourcePath + Doc1 + "'>下载</a></li>";
                }

                if (arrListDoc.Count > 1)
                {
                    string[] sDocTemp = (string[])arrListDoc[1];
                    Doc2 = sDocTemp[0];
                    Doc2_c = sDocTemp[1];
                    Doc2_r = "<li>" + Doc2_c + "：<a href='" + Doc2 + "'>查看</a><a href='" + ProjectResourcePath + Doc2 + "'>下载</a></li>";
                }
                if (arrListDoc.Count > 2)
                {
                    string[] sDocTemp = (string[])arrListDoc[2];
                    Doc3 = sDocTemp[0];
                    Doc3_c = sDocTemp[1];
                    Doc3_r = "<li>" + Doc3_c + "：<a href='" + Doc3 + "'>查看</a><a href='" + ProjectResourcePath + Doc3 + "'>下载</a></li>";
                }

                HasPic = false;
                if (Pic1 != "")
                    HasPic = true;



                KeyWord = TheProject.MainInfoModel.KeyWord;
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
                    KeyWord = string.Format(TagslinkModel, "融资", "融资");

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = TheProject.MainInfoModel.HtmlFile;
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (TheProject.MainInfoModel.DisplayTitle == "")
                {
                    TheProject.MainInfoModel.DisplayTitle = Title;
                }
                DisplayTitle = TheProject.MainInfoModel.DisplayTitle + "－" + "中国招商投资网";
                Descript = TheProject.MainInfoModel.Descript;
                TemplateID = Convert.ToInt32(TheProject.MainInfoModel.TemplateID);


                #region 判断该信息是否需要价格 -------------------------------------
                InfoPrice = 0;
                InfoOriginRoleName = TheProject.MainInfoModel.InfoOriginRoleName;
                int WorthPoint = 0;


                //V1.2 一
                if (FixPriceID == "1" || (TheProject.MainInfoModel.FeeStatus == 0 && InfoOriginRoleName == "0"))//免费
                {
                    //该信息已经被设置为免费信息
                    InfoPrice = 0;
                }
                else
                {
                    InfoPrice = (float)TheProject.MainInfoModel.MainPointCount;
                }

                string UserInfo = "";

                string HotIndex = "";
                PriceIndex = TheProject.MainInfoModel.MainEvaluation.ToString().Trim();

                if (blisCore)
                {
                    InfoPriceName = Common.GetFloatToString(InfoPrice, 2) + "元（核心资源）";
                }
                else
                {
                    InfoPriceName = Common.GetFloatToString(InfoPrice, 2) + "元";
                }

                if (blisCore || InfoPrice > 0)//核心信息 或者 收费信息
                {
                    ComAbout = TheProject.ProjectInfoModel.ComAbout;
                    Strategy = TheProject.ProjectInfoModel.ComBrief;
                }
                else
                {
                    //免费信息 -- 显示免费标志												
                    ComAbout = TheProject.ProjectInfoModel.ComAbout;
                    Strategy = TheProject.ProjectInfoModel.ComBrief;
                }

                ManageType = this.GetManageType(loginName).Trim();
                string WebUrl = "";
                string ComIntro = "";
                string TopfoDoc = "";
                string Target = "_self";
                if (ManageType == "1003")
                {
                    string UserDetailModel = "";

                    if (UserGradeTypeID == "1002")
                    {
                        ManageTypeName = "拓富通企业会员";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                        "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                            "<img src=\"/Web13/images/project/button_jlzd.gif\" /></a>" +
                        "<p class=\"rtb\">" +
                            "<a href=\"{2}\" target=\"{3}\">公司介绍</a> | <a href=\"{4}\" target=\"{5}\">拓富通档案</a><br />" +
                            "企业身份认证：<a href=\"http://www.topfo.com/topfocenter/degreeaffirm/index.shtml\" target=\"_blank\"><u>了解认证详情</u></a><br />" +
                            "营业执照：<u>已经过验证</u></p>";
                    }
                    else
                    {
                        ManageTypeName = "普通企业会员";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                        "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                            "<img src=\"/Web13/images/project/button_jlzd.gif\" /></a>";
                    }

                    DataSet ds = this.GetEnterpriseInfo(loginName);

                    if (ds == null || ds.Tables[0].Rows.Count == 0 || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ExhibitionHall"].ToString().Trim()))
                    {
                        WebUrl = "JavaScript:alert('该企业尚未创建展厅！');";
                        ComIntro = "JavaScript:alert('该企业尚未创建展厅！');";
                        TopfoDoc = "JavaScript:alert('该企业尚未创建展厅！');";
                    }
                    else
                    {
                        string ExhibitionHall = ds.Tables[0].Rows[0]["ExhibitionHall"].ToString().Trim();
                        WebUrl = "http://" + ExhibitionHall + ".co.topfo.com";
                        ComIntro = WebUrl;
                        TopfoDoc = WebUrl;
                        Target = "_blank";
                    }

                    UserDetail = string.Format(UserDetailModel, WebUrl, Target, ComIntro, Target, TopfoDoc, Target);
                }
                else if (ManageType == "1004")
                {
                    string UserDetailModel = "";

                    if (UserGradeTypeID == "1002")
                    {
                        ManageTypeName = "拓富通政府会员";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                            "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                                "<img src=\"/Web13/images/merchant/buttom_jlzsjg.gif\" /></a>" +
                            "<p class=\"rtb\">" +
                                "<a href=\"{2}\" target=\"{3}\">机构介绍</a> | <a href=\"{4}\" target=\"{5}\">拓富通档案</a><br />" +
                                "机构身份认证： <a href=\"http://www.topfo.com/help/TopfoServer.shtml#a2\" target=\"_blank\">" +
                                "<u>了解认证详情</u></a><br /></p>";
                    }
                    else
                    {
                        ManageTypeName = "普通政府会员";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                            "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                                "<img src=\"/Web13/images/merchant/buttom_jlzsjg.gif\" /></a>";
                    }

                    DataSet ds = this.GetGovernmentInfo(loginName);

                    if (ds == null || ds.Tables[0].Rows.Count == 0 || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ExhibitionHall"].ToString().Trim()))
                    {
                        WebUrl = "JavaScript:alert('该招商机构尚未创建展厅！');";
                        ComIntro = "JavaScript:alert('该招商机构尚未创建展厅！');";
                        TopfoDoc = "JavaScript:alert('该招商机构尚未创建展厅！');";
                    }
                    else
                    {
                        string ExhibitionHall = ds.Tables[0].Rows[0]["ExhibitionHall"].ToString().Trim();
                        WebUrl = "http://" + ExhibitionHall + ".gov.topfo.com";
                        ComIntro = WebUrl;
                        TopfoDoc = WebUrl;
                        Target = "_blank";
                    }

                    UserDetail = string.Format(UserDetailModel, WebUrl, Target, ComIntro, Target, TopfoDoc, Target);
                }
                else
                {
                    if (UserGradeTypeID == "1002")
                        ManageTypeName = "拓富通个人会员";
                    else
                        ManageTypeName = "普通个人会员";

                    UserDetail = "";
                }

                #endregion

                #endregion

                #region 替换模版

                #region Vip的模板
                if (TempName.Trim() == ProjectTempVipFileName)//Vip模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    if (string.IsNullOrEmpty(ProjectNameTotal) || ProjectNameTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "<tr><td class=\"h\">总投资：</td><td>" + ProjectNameTotal + "万 " + ProjectCurrencyName + "</td></tr>");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectTypeName#", ProjectTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", PublishT);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", ValidatePeriod);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublisLoginName#", PublisLoginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TZYX#", TZYX);


                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonName#", ContractPersonName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractCellPhone#", ContractCellPhone);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonCompanyName#", ContractPersonCompanyName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonPhone#", ContractPersonPhone);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonFax#", ContractPersonFax);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonAddress#", ContractPersonAddress);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonPostCode#", ContractPersonPostCode);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonWebsite#", ContractPersonWebsite);

                    if (HasPic)
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpStyle-ForPic#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpStyle-ForPic#", " style='display:none'");


                    //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Price#", InfoPriceName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Contact#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-ShopCar#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Collection#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Comment#", InfoID + "&Title=" + Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Recommend#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Lodge#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-DisplayTitle#", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-Descript#", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Domain#", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-LoginName#", loginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc1#", Doc1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc2#", Doc2_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc3#", Doc3_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic1#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic2#", Pic2_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic3#", Pic3_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic4#", Pic4_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic5#", Pic5_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic6#", Pic6_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "免费资源");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    #region 拓富指数

                    Tz888.BLL.TFZS.MainTarget tfzs = new Tz888.BLL.TFZS.MainTarget();

                    #region 债权融资
                    //领导团队： #@TmpFeild-ZQ1#<br />
                    //市场前景： #@TmpFeild-ZQ2#<br />
                    //盈利模式： #@TmpFeild-ZQ3#<br />
                    //财务指标： #@TmpFeild-ZQ4#<br />
                    //风险控制： #@TmpFeild-ZQ5#<br />
                    //拓富指数： #@TmpFeild-ZQ6#<br />
                    //项目评价： #@TmpFeild-ZQPJ#

                    decimal ZQ1 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "1");
                    decimal ZQ2 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "2");
                    decimal ZQ3 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "3");
                    decimal ZQ4 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "4");
                    decimal ZQ5 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "5");
                    decimal ZQ6 = 0;
                    string ZQPJ = "--";

                    if (ZQ1 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ1#", ZQ1.ToString());
                        ZQ6 += ZQ1;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ1#", "--");
                    if (ZQ2 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ2#", ZQ2.ToString());
                        ZQ6 += ZQ2;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ2#", "--");
                    if (ZQ3 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ3#", ZQ3.ToString());
                        ZQ3 += ZQ3;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ3#", "--");
                    if (ZQ4 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ4#", ZQ4.ToString());
                        ZQ6 += ZQ4;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ4#", "--");
                    if (ZQ5 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ5#", ZQ5.ToString());
                        ZQ6 += ZQ5;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ5#", "--");

                    if (ZQ6 != 0)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ6#", ZQ6.ToString());
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ6#", "--");

                    if (ZQ6 > 0 && ZQ6 < 40)
                        ZQPJ = "项目资源表现很差，投资风险巨大。";
                    else if (ZQ6 >= 40 && ZQ6 < 60)
                        ZQPJ = "项目资源质量不好，投资具有较大的风险。";
                    else if (ZQ6 >= 60 && ZQ6 < 80)
                        ZQPJ = "项目资源表现良好，具有一定投资价值。";
                    else if (ZQ6 >= 80)
                        ZQPJ = "项目资源非常优异，非常具有投资价值。";
                    else
                        ZQPJ = "该用户没有进行此类项目投资价值评估，无评价！";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQPJ#", ZQPJ);

                    #endregion

                    #region 股权融资
                    //市场前景： #@TmpFeild-GQ1#<br />
                    //财务指标： #@TmpFeild-GQ2#<br />
                    //收益指标： #@TmpFeild-GQ3#<br />
                    //项目风险： #@TmpFeild-GQ4#<br />
                    //经营风险： #@TmpFeild-GQ5#<br />
                    //拓富指数： #@TmpFeild-GQ6#<br />
                    //项目评价： #@TmpFeild-GQPJ#
                    decimal GQ1 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "6");
                    decimal GQ2 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "7");
                    decimal GQ3 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "8");
                    decimal GQ4 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "9");
                    decimal GQ5 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "10");
                    decimal GQ6 = 0;
                    string GQPJ = "";

                    if (GQ1 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ1#", GQ1.ToString());
                        GQ6 += GQ1;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ1#", "--");
                    if (GQ2 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ2#", GQ2.ToString());
                        GQ6 += GQ2;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ2#", "--");
                    if (GQ3 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ3#", GQ3.ToString());
                        GQ6 += GQ3;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ3#", "--");
                    if (GQ4 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ4#", GQ4.ToString());
                        GQ6 += GQ4;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ4#", "--");
                    if (GQ5 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ5#", GQ5.ToString());
                        GQ6 += GQ5;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ5#", "--");

                    if (GQ6 != 0)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ6#", GQ6.ToString());
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ6#", "--");

                    if (GQ6 > 0 && GQ6 < 40)
                        GQPJ = "项目资源表现很差，投资风险巨大。";
                    else if (GQ6 >= 40 && GQ6 < 60)
                        GQPJ = "项目资源质量不好，投资具有较大的风险。";
                    else if (GQ6 >= 60 && GQ6 < 80)
                        GQPJ = "项目资源表现良好，具有一定投资价值。";
                    else if (GQ6 >= 80)
                        GQPJ = "项目资源非常优异，非常具有投资价值。";
                    else
                        GQPJ = "该用户没有进行此类项目投资价值评估，无评价！";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQPJ#", GQPJ);
                    #endregion


                    #endregion

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "免费资源");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "免费资源");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "免费资源");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);

                }
                #endregion

                #region 收费的模板
                if (TempName.Trim() == ProjectTempChangeFileName)//收费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    if (string.IsNullOrEmpty(ProjectNameTotal) || ProjectNameTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "<tr><td class=\"h\">总投资：</td><td>" + ProjectNameTotal + "万 " + ProjectCurrencyName + "</td></tr>");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectTypeName#", ProjectTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", PublishT);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", ValidatePeriod);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublisLoginName#", PublisLoginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TZYX#", TZYX);


                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonName#", ContractPersonName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractCellPhone#", ContractCellPhone);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonCompanyName#", ContractPersonCompanyName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonPhone#", ContractPersonPhone);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonFax#", ContractPersonFax);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonAddress#", ContractPersonAddress);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonPostCode#", ContractPersonPostCode);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonWebsite#", ContractPersonWebsite);

                    if (HasPic)
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpStyle-ForPic#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpStyle-ForPic#", " style='display:none'");


                    //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Price#", InfoPriceName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Contact#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-ShopCar#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Collection#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Comment#", InfoID + "&Title=" + Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Recommend#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Lodge#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-DisplayTitle#", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-KeyWord#", KeyWord);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-Descript#", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Domain#", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-LoginName#", loginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc1#", Doc1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc2#", Doc2_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc3#", Doc3_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic1#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic2#", Pic2_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic3#", Pic3_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic4#", Pic4_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic5#", Pic5_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic6#", Pic6_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "收费资源");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourcePrice#", ResourcePrice);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo1#", ResourceInfo1);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo2#", ResourceInfo2);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    #region 拓富指数

                    Tz888.BLL.TFZS.MainTarget tfzs = new Tz888.BLL.TFZS.MainTarget();

                    #region 债权融资
                    //领导团队： #@TmpFeild-ZQ1#<br />
                    //市场前景： #@TmpFeild-ZQ2#<br />
                    //盈利模式： #@TmpFeild-ZQ3#<br />
                    //财务指标： #@TmpFeild-ZQ4#<br />
                    //风险控制： #@TmpFeild-ZQ5#<br />
                    //拓富指数： #@TmpFeild-ZQ6#<br />
                    //项目评价： #@TmpFeild-ZQPJ#

                    decimal ZQ1 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "1");
                    decimal ZQ2 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "2");
                    decimal ZQ3 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "3");
                    decimal ZQ4 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "4");
                    decimal ZQ5 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "5");
                    decimal ZQ6 = 0;
                    string ZQPJ = "--";

                    if (ZQ1 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ1#", ZQ1.ToString());
                        ZQ6 += ZQ1;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ1#", "--");
                    if (ZQ2 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ2#", ZQ2.ToString());
                        ZQ6 += ZQ2;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ2#", "--");
                    if (ZQ3 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ3#", ZQ3.ToString());
                        ZQ3 += ZQ3;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ3#", "--");
                    if (ZQ4 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ4#", ZQ4.ToString());
                        ZQ6 += ZQ4;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ4#", "--");
                    if (ZQ5 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ5#", ZQ5.ToString());
                        ZQ6 += ZQ5;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ5#", "--");

                    if (ZQ6 != 0)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ6#", ZQ6.ToString());
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ6#", "--");

                    if (ZQ6 > 0 && ZQ6 < 40)
                        ZQPJ = "项目资源表现很差，投资风险巨大。";
                    else if (ZQ6 >= 40 && ZQ6 < 60)
                        ZQPJ = "项目资源质量不好，投资具有较大的风险；";
                    else if (ZQ6 >= 60 && ZQ6 < 80)
                        ZQPJ = "项目资源表现良好，具有一定投资价值；";
                    else if (ZQ6 >= 80)
                        ZQPJ = "项目资源非常优异，非常具有投资价值；";
                    else
                        ZQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQPJ#", ZQPJ);

                    #endregion

                    #region 股权融资
                    //市场前景： #@TmpFeild-GQ1#<br />
                    //财务指标： #@TmpFeild-GQ2#<br />
                    //收益指标： #@TmpFeild-GQ3#<br />
                    //项目风险： #@TmpFeild-GQ4#<br />
                    //经营风险： #@TmpFeild-GQ5#<br />
                    //拓富指数： #@TmpFeild-GQ6#<br />
                    //项目评价： #@TmpFeild-GQPJ#
                    decimal GQ1 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "6");
                    decimal GQ2 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "7");
                    decimal GQ3 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "8");
                    decimal GQ4 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "9");
                    decimal GQ5 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "10");
                    decimal GQ6 = 0;
                    string GQPJ = "";

                    if (GQ1 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ1#", GQ1.ToString());
                        GQ6 += GQ1;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ1#", "--");
                    if (GQ2 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ2#", GQ2.ToString());
                        GQ6 += GQ2;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ2#", "--");
                    if (GQ3 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ3#", GQ3.ToString());
                        GQ6 += GQ3;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ3#", "--");
                    if (GQ4 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ4#", GQ4.ToString());
                        GQ6 += GQ4;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ4#", "--");
                    if (GQ5 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ5#", GQ5.ToString());
                        GQ6 += GQ5;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ5#", "--");

                    if (GQ6 != 0)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ6#", GQ6.ToString());
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ6#", "--");

                    if (GQ6 > 0 && GQ6 < 40)
                        GQPJ = "项目资源表现很差，投资风险巨大。";
                    else if (GQ6 >= 40 && GQ6 < 60)
                        GQPJ = "项目资源质量不好，投资具有较大的风险；";
                    else if (GQ6 >= 60 && GQ6 < 80)
                        GQPJ = "项目资源表现良好，具有一定投资价值；";
                    else if (GQ6 >= 80)
                        GQPJ = "项目资源非常优异，非常具有投资价值；";
                    else
                        GQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQPJ#", GQPJ);
                    #endregion


                    #endregion

                }
                #endregion

                #region 免费的模板
                if (TempName.Trim() == ProjectTempFeeFileName)//免费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    if (string.IsNullOrEmpty(ProjectNameTotal) || ProjectNameTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "<tr><td class=\"h\">总投资：</td><td>" + ProjectNameTotal + "万 " + ProjectCurrencyName + "</td></tr>");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectTypeName#", ProjectTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", PublishT);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", ValidatePeriod);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublisLoginName#", PublisLoginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TZYX#", TZYX);


                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonName#", ContractPersonName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractCellPhone#", ContractCellPhone);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonCompanyName#", ContractPersonCompanyName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonPhone#", ContractPersonPhone);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonFax#", ContractPersonFax);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonAddress#", ContractPersonAddress);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonPostCode#", ContractPersonPostCode);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ContractPersonWebsite#", ContractPersonWebsite);

                    if (HasPic)
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpStyle-ForPic#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpStyle-ForPic#", " style='display:none'");


                    //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Price#", InfoPriceName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Contact#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-ShopCar#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Collection#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Comment#", InfoID + "&Title=" + Title);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Recommend#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpLinkFeild-Lodge#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-DisplayTitle#", DisplayTitle);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-KeyWord#", KeyWord);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpPageFeild-Descript#", Descript);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Domain#", Common.GetDomain());
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-LoginName#", loginName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc1#", Doc1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc2#", Doc2_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Doc3#", Doc3_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic1#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic2#", Pic2_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic3#", Pic3_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic4#", Pic4_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic5#", Pic5_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Pic6#", Pic6_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "免费资源");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyName#", ContractPersonCompanyName.Trim());

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);

                    #region 拓富指数

                    Tz888.BLL.TFZS.MainTarget tfzs = new Tz888.BLL.TFZS.MainTarget();

                    #region 债权融资
                    //领导团队： #@TmpFeild-ZQ1#<br />
                    //市场前景： #@TmpFeild-ZQ2#<br />
                    //盈利模式： #@TmpFeild-ZQ3#<br />
                    //财务指标： #@TmpFeild-ZQ4#<br />
                    //风险控制： #@TmpFeild-ZQ5#<br />
                    //拓富指数： #@TmpFeild-ZQ6#<br />
                    //项目评价： #@TmpFeild-ZQPJ#

                    decimal ZQ1 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "1");
                    decimal ZQ2 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "2");
                    decimal ZQ3 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "3");
                    decimal ZQ4 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "4");
                    decimal ZQ5 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "5");
                    decimal ZQ6 = 0;
                    string ZQPJ = "--";

                    if (ZQ1 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ1#", ZQ1.ToString());
                        ZQ6 += ZQ1;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ1#", "--");
                    if (ZQ2 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ2#", ZQ2.ToString());
                        ZQ6 += ZQ2;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ2#", "--");
                    if (ZQ3 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ3#", ZQ3.ToString());
                        ZQ3 += ZQ3;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ3#", "--");
                    if (ZQ4 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ4#", ZQ4.ToString());
                        ZQ6 += ZQ4;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ4#", "--");
                    if (ZQ5 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ5#", ZQ5.ToString());
                        ZQ6 += ZQ5;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ5#", "--");

                    if (ZQ6 != 0)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ6#", ZQ6.ToString());
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQ6#", "--");

                    if (ZQ6 > 0 && ZQ6 < 40)
                        ZQPJ = "项目资源表现很差，投资风险巨大。";
                    else if (ZQ6 >= 40 && ZQ6 < 60)
                        ZQPJ = "项目资源质量不好，投资具有较大的风险；";
                    else if (ZQ6 >= 60 && ZQ6 < 80)
                        ZQPJ = "项目资源表现良好，具有一定投资价值；";
                    else if (ZQ6 >= 80)
                        ZQPJ = "项目资源非常优异，非常具有投资价值；";
                    else
                        ZQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQPJ#", ZQPJ);

                    #endregion

                    #region 股权融资
                    //市场前景： #@TmpFeild-GQ1#<br />
                    //财务指标： #@TmpFeild-GQ2#<br />
                    //收益指标： #@TmpFeild-GQ3#<br />
                    //项目风险： #@TmpFeild-GQ4#<br />
                    //经营风险： #@TmpFeild-GQ5#<br />
                    //拓富指数： #@TmpFeild-GQ6#<br />
                    //项目评价： #@TmpFeild-GQPJ#
                    decimal GQ1 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "6");
                    decimal GQ2 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "7");
                    decimal GQ3 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "8");
                    decimal GQ4 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "9");
                    decimal GQ5 = tfzs.GetEvaluateCount(Convert.ToInt64(InfoID), "10");
                    decimal GQ6 = 0;
                    string GQPJ = "";

                    if (GQ1 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ1#", GQ1.ToString());
                        GQ6 += GQ1;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ1#", "--");
                    if (GQ2 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ2#", GQ2.ToString());
                        GQ6 += GQ2;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ2#", "--");
                    if (GQ3 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ3#", GQ3.ToString());
                        GQ6 += GQ3;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ3#", "--");
                    if (GQ4 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ4#", GQ4.ToString());
                        GQ6 += GQ4;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ4#", "--");
                    if (GQ5 != -1)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ5#", GQ5.ToString());
                        GQ6 += GQ5;
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ5#", "--");

                    if (GQ6 != 0)
                    {
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ6#", GQ6.ToString());
                    }
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQ6#", "--");

                    if (GQ6 > 0 && GQ6 < 40)
                        GQPJ = "项目资源表现很差，投资风险巨大。";
                    else if (GQ6 >= 40 && GQ6 < 60)
                        GQPJ = "项目资源质量不好，投资具有较大的风险；";
                    else if (GQ6 >= 60 && GQ6 < 80)
                        GQPJ = "项目资源表现良好，具有一定投资价值；";
                    else if (GQ6 >= 80)
                        GQPJ = "项目资源非常优异，非常具有投资价值；";
                    else
                        GQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQPJ#", GQPJ);
                    #endregion


                    #endregion

                }
                #endregion

                #endregion

                #region 输出文件
                OutPutFilePath = ApplicationRootPath + TempProjectPathTo.Trim() + HtmlFile;

                //检查路径是否正确
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Project<br>");
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
        /// <summary>
        /// CreateStaticPageProject_V3 的copy,因页面上调用的是该方法,新方法改成了CreateStaticPageProject_V3,这样页面不用作改动
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="UpdateMsg"></param>
        /// <returns></returns>
        public bool CreateStaticPageProject(string InfoID, ref string UpdateMsg)
        {

            #region 变量定义

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString();//静态页面的根目录
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString();                //图片域名
            string TempProjectZQ_V3 = "Template/Temp_Info_V3/Temp_Project_Zq_V3.htm";
            string TempProjectGQ_V3 = "Template/Temp_Info_V3/Temp_Project_Gq_V3.htm";

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            string OutPutFilePath = "";
            StreamWriter swOutPut;
            long HaveDoneCount = 0;
            string TmpTmpSource = "";
            byte AuditingStatus;
            string loginName = "";
            string CooperationDemandType = "";  //融资方式
            bool IsCheck = false;               //是否认证资源
            string HtmlFile = "";
            string TmpFileName;                 //模版的完整位置

            ProjectSetModel TheProject = new ProjectSetModel();
            TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheProject.ProjectInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheProject.MainInfoModel.HtmlFile;
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheProject.MainInfoModel.LoginName);
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            string TempName = (CooperationDemandType.Trim() == "9" ? TempProjectZQ_V3 : TempProjectGQ_V3);  //获取模板名称
            string ProjectInfoType = (CooperationDemandType.Trim() == "9" ? "ZQ" : "GQ");                   //融资信息类别GQ&ZQ
            if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = true; //认证资源模版
            }
            #endregion


            #region 读取模板内容

            StreamReader srSource;
            TmpFileName = ApplicationRootPath + TempName;
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

            if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheProject.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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


            #region 替换模版
            //共有信息
            TmpTmpSource = TmpSource;
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheProject.ProjectInfoModel.ProjectName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheProject.MainInfoModel.publishT.ToShortDateString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheProject.MainInfoModel.HtmlFile.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", TheProject.MainInfoModel.Descript.ToString());

            string IndustryName = "";   //所属于行业
            foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

            string financingName = "暂未提供";  //融资对象
            string financingID = TheProject.ProjectInfoModel.financingID.ToString();
            if (financingID != "")
            {
                Tz888.BLL.Conn dal = new Conn();
                DataTable dtF = dal.GetList("SETfinancingTargetTAB", "financingName", "financingID", 1, 1, 0, 1, "financingID='" + financingID + "'");
                if (dtF.Rows.Count > 0)
                {
                    financingName = dtF.Rows[0]["financingName"].ToString();
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalObj#", financingName);

            string AreaName = "";       //投资区域
            if (TheProject.ProjectInfoModel != null)
            {
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountryName))
                {
                    AreaName = TheProject.ProjectInfoModel.CountryName.Trim();
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.ProvinceName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.ProvinceName;
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CityName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.CityName;
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountyName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.CountyName;
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

            string CapitalTotal = "暂未提供";       //项目总投资
            if (TheProject.ProjectInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);

            string cZqXmlxqkb = TheProject.ProjectInfoModel.cZqXmlxqkb.ToString();
            cZqXmlxqkb = cZqXmlxqkb.Replace("1", "缺少项目批文");
            cZqXmlxqkb = cZqXmlxqkb.Replace("2", "缺少项目所需执照");
            cZqXmlxqkb = cZqXmlxqkb.Replace("3", "缺少项目所需证");
            cZqXmlxqkb = cZqXmlxqkb.Replace("4", "项目手续齐全");
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqXmlxqkb#", cZqXmlxqkb);//项目立项情况

            string cZqQyfzjd = "";      //企业发展阶段
            switch (TheProject.ProjectInfoModel.cZqQyfzjd.ToString().Trim())
            {
                case "1": cZqQyfzjd = "种子期"; break;
                case "2": cZqQyfzjd = "创立期"; break;
                case "3": cZqQyfzjd = "成长期"; break;
                case "4": cZqQyfzjd = "成熟期"; break;
                case "5": cZqQyfzjd = "Pro-IPO"; break;
                case "6": cZqQyfzjd = "稳定期"; break;
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqQyfzjd#", cZqQyfzjd.ToString()); //企业发展阶段

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", TheProject.MainInfoModel.MainPointCount.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", TheProject.MainInfoModel.ValidateTerm.ToString());
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(InfoID).ToString());

            string _IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                "该资源未经过中国招商投资网核实认证<br />我们<span class='f_org strong'>不保证资源的真实性</span>！";  //不是认证资源
            if (IsCheck)
            {
                _IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "该资源已经过中国招商投资网核实认证<br />我们<span class='f_org strong'>保证资源的真实性</span>！";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", _IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheProject));

            string userDomain = GetSelfDomain(TheProject.MainInfoModel.LoginName.Trim());  //展厅 用户域名
            if (userDomain != "" && dt_login != null && dt_login.Rows.Count > 0)
            {
                if (dt_login.Rows[0]["ManageTypeID"].ToString().Trim() == "2004")
                {
                    userDomain = "_blank' href='http://" + userDomain + ".gov.topfo.com";
                }
                else
                {
                    userDomain = "_blank' href='http://" + userDomain + ".co.topfo.com";
                }
            }
            else
            {
                userDomain = "#";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Exhibition#", userDomain);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComBrief#", TheProject.ProjectInfoModel.ComBrief.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", TheProject.ProjectInfoModel.ComAbout.ToString());
            List<InfoResourceModel> attachments = attachmentbll.GetModelList(TheProject.MainInfoModel.InfoID);
            if (attachments != null)
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", attachments.Count.ToString());
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", "0");
            }

            if (ProjectInfoType.Trim() == "ZQ")
            {
                string capitalName = "不限";            //借款
                if (TheProject.ProjectInfoModel.CapitalID.Trim() != "0")
                {
                    capitalName = TheProject.ProjectInfoModel.CapitalName.Trim() + "元人民币";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqZcfzl#", TheProject.ProjectInfoModel.iZqZcfzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzsl#", TheProject.ProjectInfoModel.iZqTzsl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpsczzl#", TheProject.ProjectInfoModel.iZqCpsczzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpscYl#", TheProject.ProjectInfoModel.iZqCpscYl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYdbl#", TheProject.ProjectInfoModel.iZqYdbl.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqXslyl#", TheProject.ProjectInfoModel.iZqXslyl.ToString());

                string iZqYqjjdwqk = "";      //要求资金到位情况
                switch (TheProject.ProjectInfoModel.iZqYqjjdwqk.ToString().Trim())
                {
                    case "1": iZqYqjjdwqk = "资金一步到"; break;
                    case "2": iZqYqjjdwqk = "资金分步实施"; break;
                    case "3": iZqYqjjdwqk = "不限"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYqjjdwqk#", iZqYqjjdwqk.ToString());

                string iZqTzfbq = "";           //项目投资回报周期
                switch (TheProject.ProjectInfoModel.iZqTzfbq.ToString().Trim())
                {
                    case "0":
                    case "1": iZqTzfbq = "≤3年"; break;
                    case "2": iZqTzfbq = "3-5年"; break;
                    case "3": iZqTzfbq = "5-7年"; break;
                    case "4": iZqTzfbq = "7-10年"; break;
                    case "5": iZqTzfbq = ">10年"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzfbq#", iZqTzfbq.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheProject.ProjectInfoModel.warrant.ToString());
            }
            else
            {
                string financingAmount = "";    //要求资金到位情况
                switch (TheProject.ProjectInfoModel.financingAmount.ToString().Trim())
                {
                    case "0": financingAmount = "不限"; break;
                    case "1": financingAmount = "500万以下"; break;
                    case "2": financingAmount = "500-2000万"; break;
                    case "3": financingAmount = "2000万-1亿"; break;
                    case "4": financingAmount = "1-10亿"; break;
                    case "5": financingAmount = "10亿以上"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-financingAmount#", financingAmount.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", TheProject.ProjectInfoModel.SellStockShare.ToString());

                string returnModelStr = "不限";
                if (TheProject.ProjectInfoModel.ReturnModeID != null && TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim() != "")   //退出方式
                {
                    returnModelStr = TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim();
                    returnModelStr = returnModelStr.Replace("1", "股权转");
                    returnModelStr = returnModelStr.Replace("2", "IPO(公开上市)");
                    returnModelStr = returnModelStr.Replace("3", "回购");
                    returnModelStr = returnModelStr.Replace("4", "其它");
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnmodeID#", returnModelStr.ToString());

                string iYqzjdwqk = "";      //要求资金到位情况
                switch (TheProject.ProjectInfoModel.iYqzjdwqk.ToString().Trim())
                {
                    case "1": iYqzjdwqk = "资金一步到"; break;
                    case "2": iYqzjdwqk = "资金分步实施"; break;
                    case "3": iYqzjdwqk = "不限"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-yqzjdwqk#", iYqzjdwqk.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Hysczzl#", TheProject.ProjectInfoModel.iHysczzl.ToString());

                string hbzq = "";           //项目投资回报周期
                switch (TheProject.ProjectInfoModel.iXmtzfbzq.ToString().Trim())
                {
                    case "0":
                    case "1": hbzq = "≤3年"; break;
                    case "2": hbzq = "3-5年"; break;
                    case "3": hbzq = "5-7年"; break;
                    case "4": hbzq = "7-10年"; break;
                    case "5": hbzq = ">10年"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-xmtzfbzq#", hbzq.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Sczylfy#", TheProject.ProjectInfoModel.iSczylfy.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Zcfzl#", TheProject.ProjectInfoModel.iZcfzl.ToString());
            }

            #endregion


            #region 输出文件

            OutPutFilePath = ApplicationRootPath + HtmlFile;
            if (!Common.BulidFolder(OutPutFilePath, true))      //检查路径是否正确
            {
                sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Project<br>");
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
        #endregion


        #region 新模板静态页面
        public bool CreateStaticPageProject_New(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            //try
            //{
            #region 变量定义
            string OutPutFilePath = "";
            StreamWriter swOutPut;
            long HaveDoneCount = 0;
            string TmpTmpSource = "";
            byte AuditingStatus;
            string loginName = "";
            //系统路径
            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
            //模板路径
            string TempProjectPath = ConfigurationManager.AppSettings["ProjectTmpPath"].ToString(); //融资模板的存放位置
            //目标路径
            string TempProjectPathTo = ConfigurationManager.AppSettings["ProjectTmpPathTo"].ToString(); //融资模板生成存放位置
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

            string CooperationDemandType = "";//融资方式
            bool IsCheck = false;//是否认证资源
            string HtmlFile = "";

            ProjectSetModel TheProject = new ProjectSetModel();

            TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheProject.ProjectInfoModel.CooperationDemandType.ToString().Trim();

            HtmlFile = TheProject.MainInfoModel.HtmlFile;
            #endregion


            #region 获取模板名称
            string TempName = "";
            string UserGradeTypeID = "";
            Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
            UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(TheProject.MainInfoModel.LoginName.Trim()).Trim();

            if (UserGradeTypeID.Trim() == "1002")
            {
                if (CooperationDemandType.Trim() == "9")
                {
                    TempName = Project_ZQ_Vip;
                }
                else
                {
                    TempName = Project_GQ_Vip;
                }
            }
            else
            {
                //普通用户模板
                if (CooperationDemandType.Trim() == "9")//债券融资
                {
                    TempName = Project_ZQ;
                }
                else
                {
                    TempName = Project_GQ;
                }
            }


            #endregion

            #region 认证标志
            if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
            {
                //认证资源模版
                IsCheck = true;
            }
            #endregion

            #region 读取模板内容

            StreamReader srSource;
            string TmpFileName;
            TmpFileName = ApplicationRootPath + TempProjectPath + TempName;
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

            if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheProject.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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

            #region 替换模版
            //共有信息
            TmpTmpSource = TmpSource;
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheProject.ProjectInfoModel.ProjectName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheProject.MainInfoModel.publishT.ToShortDateString());
            //用户身份
            if (TempName == Project_GQ || TempName == Project_ZQ)
            {
                string ManageTypeName = ""; //身份类型
                string ManageTypeID = this.GetManageType(TheProject.MainInfoModel.LoginName.Trim()).Trim();
                string strTopfo = "普通";
                string memberType = "项目方";
                if (UserGradeTypeID.Trim() == "1002")
                {
                    strTopfo = "拓富通";
                }
                if (ManageTypeID == "2004")
                {
                    memberType = "中介会员";
                }
                //展厅
                string userDomain = GetSelfDomain(loginName);//用户域名
                string webUrl = "";
                if (userDomain != "")
                {
                    string u = "http://" + userDomain + ".co.topfo.com";
                    webUrl = "<a target='_blank' href='" + u + "')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";

                }
                //else
                //{
                //    webUrl = "<a href='javascript:alert('尚未创建展厅...')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";
                //}
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SelfWeb#", webUrl);
                ManageTypeName = strTopfo + memberType;
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);

            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GradeID#", UserGradeTypeID.Trim());
            //所属于行业
            string IndustryName = "";
            foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
            //投资区域
            string AreaName = "";
            if (TheProject.ProjectInfoModel != null)
            {
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountryName))
                {
                    AreaName = TheProject.ProjectInfoModel.CountryName.Trim();
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.ProvinceName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.ProvinceName;
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CityName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.CityName;
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountyName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.CountyName;
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);
            //有效期至
            string endDate = "";
            endDate = TheProject.MainInfoModel.ValidateStartTime.AddMonths(TheProject.MainInfoModel.ValidateTerm).ToShortDateString();
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValiDate#", endDate);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", TheProject.ProjectInfoModel.ComAbout);
            string capitalName = "不限";
            if (TheProject.ProjectInfoModel.CapitalID.Trim()!="0")
            {
                capitalName = TheProject.ProjectInfoModel.CapitalName.Trim() + "元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);//借款

            string CapitalTotal = "暂未提供";
            if (TheProject.ProjectInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//项目总投资
            string marketAbout = "暂未提供";
            if( TheProject.ProjectInfoModel.marketAbout.Trim()!="")
            {
                marketAbout = TheProject.ProjectInfoModel.marketAbout.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MarketAbout#", marketAbout);//市场介绍
            Tz888.BLL.Conn dal = new Conn();
            string financingID = "0";
            string financingName = "暂未提供";
            if (TheProject.ProjectInfoModel.financingID!=null && TheProject.ProjectInfoModel.financingID.ToString().Trim() != "")
            {
                financingID = TheProject.ProjectInfoModel.financingID.ToString();
                DataTable dtF = dal.GetList("SETfinancingTargetTAB", "financingName", "financingID", 1, 1, 0, 1, "financingID='" + financingID + "'");
                if (dtF.Rows.Count > 0)
                {
                    financingName = dtF.Rows[0]["financingName"].ToString();
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalObj#", financingName);//融资对象
            if (IsCheck)//认证标志
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-isCheck#", "<img src='/images/tiem_09.jpg'>");
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-isCheck#", "");

            }
            string UserEvaluation = "未评价";
            if (TheProject.MainInfoModel.UserEvaluation.ToString() != "" && TheProject.MainInfoModel.UserEvaluation != 0)
            {
                UserEvaluation = TheProject.MainInfoModel.UserEvaluation.ToString();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TopFoZS#", UserEvaluation);//TF指数 

            #region 债券融资属性
            //if (CooperationDemandType.Trim().IndexOf("10")==-1)
            //{
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheProject.ProjectInfoModel.warrant.ToString());
                string CompanyYearIncome = "暂未提供";
                if (TheProject.ProjectInfoModel.CompanyYearIncome != 0 && TheProject.ProjectInfoModel.CompanyYearIncome.ToString() != "")
                {
                    CompanyYearIncome = TheProject.ProjectInfoModel.CompanyYearIncome.ToString("0.00") + "万元人民币";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyYearIncome#", CompanyYearIncome);
                string CompanyNG = "暂未提供";
                if (TheProject.ProjectInfoModel.CompanyNG != 0 && TheProject.ProjectInfoModel.CompanyNG.ToString() != "")
                {
                    CompanyNG = TheProject.ProjectInfoModel.CompanyNG.ToString("0.00") + "万元人民币";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyNG#", CompanyNG);
                string CompanyTotalCapital = "暂未提供";
                if (TheProject.ProjectInfoModel.CompanyTotalCapital != 0 && TheProject.ProjectInfoModel.CompanyTotalCapital.ToString() != "")
                {
                    CompanyTotalCapital = TheProject.ProjectInfoModel.CompanyTotalCapital.ToString("0.00") + "万元人民币";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalCapital#", CompanyTotalCapital);
                string CompanyTotalDebet = "暂未提供";
                if (TheProject.ProjectInfoModel.CompanyTotalDebet != 0 && TheProject.ProjectInfoModel.CompanyTotalDebet.ToString() != "")
                {
                    CompanyTotalDebet = TheProject.ProjectInfoModel.CompanyTotalDebet.ToString("0.00") + "万元人民币";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalDebet#", CompanyTotalDebet);
            //}
            #endregion

            #region 股权融资属性
            //else//CooperationDemandType.Trim().Contains("10")
            //{
                string ReturnMode = TheProject.ProjectInfoModel.ReturnModeID;
                string ReturnModeName = "暂未提供";
                DataTable dtM = null;
                if (!string.IsNullOrEmpty(ReturnMode))
                {
                    string[] s = ReturnMode.Split(',');
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] != "")
                        {
                            dtM = dal.GetList("SetReturnModeTAB", "ReturnModeName", "ReturnModeID", 1, 1, 0, 1, "ReturnModeID=" + Convert.ToInt32(s[i]));
                            if (dtM.Rows.Count > 0)
                            {
                                ReturnModeName += dtM.Rows[0]["ReturnModeName"].ToString() + " ";
                            }
                        }
                    }
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnModel#", ReturnModeName);//退出方式
                string SellStockShare = "暂未提供";
                if (TheProject.ProjectInfoModel.SellStockShare != 0 || TheProject.ProjectInfoModel.SellStockShare.ToString() == "")
                {
                    SellStockShare = TheProject.ProjectInfoModel.SellStockShare.ToString()+"%";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", SellStockShare);//出让股份
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectAbout#", TheProject.ProjectInfoModel.ProjectAbout == "" ? "暂未提供" : TheProject.ProjectInfoModel.ProjectAbout);//产品介绍
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-competitioAbout#", TheProject.ProjectInfoModel.competitioAbout == "" ? "暂未提供" : TheProject.ProjectInfoModel.competitioAbout);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BussinessModeAbout#", TheProject.ProjectInfoModel.BussinessModeAbout == "" ? "暂未提供" : TheProject.ProjectInfoModel.BussinessModeAbout);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTeamAbout#", TheProject.ProjectInfoModel.ManageTeamAbout == "" ? "暂未提供" : TheProject.ProjectInfoModel.ManageTeamAbout);
            //}
            #endregion

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheProject.MainInfoModel.HtmlFile.Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PID#", TheProject.ProjectInfoModel.ProvinceID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CID#", TheProject.ProjectInfoModel.CityID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-XID#", TheProject.ProjectInfoModel.CountyID.Trim());
            string CommentIframe = ConfigurationManager.AppSettings["MemberDomain"];
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Comment#", CommentIframe);//评论域名
            //项目附件


            #region 输出文件
            OutPutFilePath = ApplicationRootPath + TempProjectPathTo.Trim() + HtmlFile;

            //检查路径是否正确
            if (!Common.BulidFolder(OutPutFilePath, true))
            {
                sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Project<br>");
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

            #endregion
            //}
            //catch (Exception e)
            //{
            //    string err = e.Message.ToString().Trim();
            //    sbUpdateMsg.Append(err);
            //    UpdateMsg = sbUpdateMsg.ToString();
            //    return false;
            //}
        }

        #endregion


        #region 通过InfoID获取一个信息实体
        /// <summary>
        /// 通过InfoID获取一个Project的信息实体
        /// </summary>
        /// <returns></returns>
        public ProjectSetModel objGetProjectInfoByInfoID(long InfoID)
        {

            ProjectSetModel TheProjectInfo = new ProjectSetModel();
            TheProjectInfo = dal.GetIntegrityModel(InfoID);
            return TheProjectInfo;
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
            Tz888.BLL.Conn dal = new Conn();
            DataTable dt = dal.GetWebSiteList("SelfCreateWebInfo", "Domain", "WebID", 1, 1, 0, 1, "loginname='" + loginName + "'");
            return dt.DataSet;
        }
        public string GetSelfDomain(string loginname)
        {
            Tz888.BLL.Conn dal = new Conn();
            string domain = "";
            DataTable dt = dal.GetWebSiteList("SelfCreateWebInfo", "Domain", "WebID", 1, 1, 0, 1, "loginname='" + loginname + "'");
            if (dt.Rows.Count > 0)
            {
                domain = dt.Rows[0]["Domain"].ToString().Trim();
            }
            return domain;
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
            return lbll.GetManageTypeID(loginName).Trim();
        }

        #endregion


        #region 模板V3版生成静态页面

        public bool CreateStaticPageProject_V3(string InfoID, ref string UpdateMsg)
        {
        
            #region 变量定义

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString();//静态页面的根目录
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString();                //图片域名
            string TempProjectZQ_V3 = "Template/Temp_Info_V3/Temp_Project_Zq_V3.htm";
            string TempProjectGQ_V3 = "Template/Temp_Info_V3/Temp_Project_Gq_V3.htm";

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            string OutPutFilePath = "";
            StreamWriter swOutPut;
            long HaveDoneCount = 0;
            string TmpTmpSource = "";
            byte AuditingStatus;
            string loginName = "";
            string CooperationDemandType = "";  //融资方式
            bool IsCheck = false;               //是否认证资源
            string HtmlFile = "";
            string TmpFileName;                 //模版的完整位置

            ProjectSetModel TheProject = new ProjectSetModel();
            TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheProject.ProjectInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheProject.MainInfoModel.HtmlFile;
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheProject.MainInfoModel.LoginName);
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            string TempName = (CooperationDemandType.Trim() == "9" ? TempProjectZQ_V3 : TempProjectGQ_V3);  //获取模板名称
            string ProjectInfoType = (CooperationDemandType.Trim() == "9" ? "ZQ" : "GQ");                   //融资信息类别GQ&ZQ
            if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = true; //认证资源模版
            }
            #endregion


            #region 读取模板内容

            StreamReader srSource;
            TmpFileName = ApplicationRootPath + TempName;
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

            if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheProject.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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


            #region 替换模版
            //共有信息
            TmpTmpSource = TmpSource;
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheProject.ProjectInfoModel.ProjectName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheProject.MainInfoModel.publishT.ToShortDateString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheProject.MainInfoModel.HtmlFile.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", TheProject.MainInfoModel.Descript.ToString()); 

            string IndustryName = "";   //所属于行业
            foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

            string financingName = "暂未提供";  //融资对象
            string financingID = TheProject.ProjectInfoModel.financingID.ToString();
            if (financingID != "")
            {
                Tz888.BLL.Conn dal = new Conn();
                DataTable dtF = dal.GetList("SETfinancingTargetTAB", "financingName", "financingID", 1, 1, 0, 1, "financingID='" + financingID + "'");
                if (dtF.Rows.Count > 0)
                {
                    financingName = dtF.Rows[0]["financingName"].ToString();
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalObj#", financingName);

            string AreaName = "";       //投资区域
            if (TheProject.ProjectInfoModel != null)
            {
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountryName))
                {
                    AreaName = TheProject.ProjectInfoModel.CountryName.Trim();
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.ProvinceName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.ProvinceName;
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CityName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.CityName;
                }
                if (!string.IsNullOrEmpty(TheProject.ProjectInfoModel.CountyName))
                {
                    AreaName += " " + TheProject.ProjectInfoModel.CountyName;
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

            string CapitalTotal = "暂未提供";       //项目总投资
            if (TheProject.ProjectInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);

            string cZqXmlxqkb = TheProject.ProjectInfoModel.cZqXmlxqkb.ToString();
            cZqXmlxqkb = cZqXmlxqkb.Replace("1", "缺少项目批文");
            cZqXmlxqkb = cZqXmlxqkb.Replace("2", "缺少项目所需执照");
            cZqXmlxqkb = cZqXmlxqkb.Replace("3", "缺少项目所需证");
            cZqXmlxqkb = cZqXmlxqkb.Replace("4", "项目手续齐全"); 
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqXmlxqkb#", cZqXmlxqkb);//项目立项情况

            string cZqQyfzjd = "";      //企业发展阶段
            switch (TheProject.ProjectInfoModel.cZqQyfzjd.ToString().Trim())
            {
                case "1": cZqQyfzjd = "种子期"; break;
                case "2": cZqQyfzjd = "创立期"; break;
                case "3": cZqQyfzjd = "成长期"; break;
                case "4": cZqQyfzjd = "成熟期"; break;
                case "5": cZqQyfzjd = "Pro-IPO"; break;
                case "6": cZqQyfzjd = "稳定期"; break;
            } 
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqQyfzjd#", cZqQyfzjd.ToString()); //企业发展阶段

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", TheProject.MainInfoModel.MainPointCount.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", TheProject.MainInfoModel.ValidateTerm.ToString());
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(InfoID).ToString());

            string _IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                "该资源未经过中国招商投资网核实认证<br />我们<span class='f_org strong'>不保证资源的真实性</span>！";  //不是认证资源
            if (IsCheck)
            {
                _IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "该资源已经过中国招商投资网核实认证<br />我们<span class='f_org strong'>保证资源的真实性</span>！";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", _IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheProject));

            string userDomain = GetSelfDomain(TheProject.MainInfoModel.LoginName.Trim());  //展厅 用户域名
            if (userDomain != "" && dt_login != null && dt_login.Rows.Count > 0)
            {
                if (dt_login.Rows[0]["ManageTypeID"].ToString().Trim() == "2004")
                {
                    userDomain = "_blank' href='http://" + userDomain + ".gov.topfo.com";
                }
                else
                {
                    userDomain = "_blank' href='http://" + userDomain + ".co.topfo.com";
                }
            }
            else
            {
                userDomain = "#";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Exhibition#", userDomain);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComBrief#", TheProject.ProjectInfoModel.ComBrief.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", TheProject.ProjectInfoModel.ComAbout.ToString());
            List<InfoResourceModel> attachments = attachmentbll.GetModelList(TheProject.MainInfoModel.InfoID);
            if (attachments != null)
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", attachments.Count.ToString());
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", "0");
            }

            if (ProjectInfoType.Trim() == "ZQ")
            {
                string capitalName = "不限";            //借款
                if (TheProject.ProjectInfoModel.CapitalID.Trim() != "0")
                {
                    capitalName = TheProject.ProjectInfoModel.CapitalName.Trim() + "元人民币";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqZcfzl#", TheProject.ProjectInfoModel.iZqZcfzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzsl#", TheProject.ProjectInfoModel.iZqTzsl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpsczzl#", TheProject.ProjectInfoModel.iZqCpsczzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpscYl#", TheProject.ProjectInfoModel.iZqCpscYl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYdbl#", TheProject.ProjectInfoModel.iZqYdbl.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqXslyl#", TheProject.ProjectInfoModel.iZqXslyl.ToString());

                string iZqYqjjdwqk = "";      //要求资金到位情况
                switch (TheProject.ProjectInfoModel.iZqYqjjdwqk.ToString().Trim())
                {
                    case "1": iZqYqjjdwqk = "资金一步到"; break;
                    case "2": iZqYqjjdwqk = "资金分步实施"; break;
                    case "3": iZqYqjjdwqk = "不限"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYqjjdwqk#", iZqYqjjdwqk.ToString());

                string iZqTzfbq = "";           //项目投资回报周期
                switch (TheProject.ProjectInfoModel.iZqTzfbq.ToString().Trim())
                {
                    case "0":
                    case "1": iZqTzfbq = "≤3年"; break;
                    case "2": iZqTzfbq = "3-5年"; break;
                    case "3": iZqTzfbq = "5-7年"; break;
                    case "4": iZqTzfbq = "7-10年"; break;
                    case "5": iZqTzfbq = ">10年"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzfbq#", iZqTzfbq.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheProject.ProjectInfoModel.warrant.ToString());
            }
            else
            {
                string financingAmount = "";    //要求资金到位情况
                switch (TheProject.ProjectInfoModel.financingAmount.ToString().Trim())
                {
                    case "0": financingAmount = "不限"; break;
                    case "1": financingAmount = "500万以下"; break;
                    case "2": financingAmount = "500-2000万"; break;
                    case "3": financingAmount = "2000万-1亿"; break;
                    case "4": financingAmount = "1-10亿"; break;
                    case "5": financingAmount = "10亿以上"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-financingAmount#", financingAmount.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", TheProject.ProjectInfoModel.SellStockShare.ToString());

                string returnModelStr = "不限";
                if (TheProject.ProjectInfoModel.ReturnModeID != null && TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim() != "")   //退出方式
                {
                    returnModelStr = TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim();
                    returnModelStr = returnModelStr.Replace("1", "股权转");
                    returnModelStr = returnModelStr.Replace("2", "IPO(公开上市)");
                    returnModelStr = returnModelStr.Replace("3", "回购");
                    returnModelStr = returnModelStr.Replace("4", "其它");
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnmodeID#", returnModelStr.ToString());

                string iYqzjdwqk = "";      //要求资金到位情况
                switch (TheProject.ProjectInfoModel.iYqzjdwqk.ToString().Trim())
                {
                    case "1": iYqzjdwqk = "资金一步到"; break;
                    case "2": iYqzjdwqk = "资金分步实施"; break;
                    case "3": iYqzjdwqk = "不限"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-yqzjdwqk#", iYqzjdwqk.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Hysczzl#", TheProject.ProjectInfoModel.iHysczzl.ToString());

                string hbzq = "";           //项目投资回报周期
                switch (TheProject.ProjectInfoModel.iXmtzfbzq.ToString().Trim())
                {
                    case "0": 
                    case "1": hbzq = "≤3年"; break;
                    case "2": hbzq = "3-5年"; break;
                    case "3": hbzq = "5-7年"; break;
                    case "4": hbzq = "7-10年"; break;
                    case "5": hbzq = ">10年"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-xmtzfbzq#", hbzq.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Sczylfy#", TheProject.ProjectInfoModel.iSczylfy.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Zcfzl#", TheProject.ProjectInfoModel.iZcfzl.ToString());
            }

            #endregion


            #region 输出文件

            OutPutFilePath = ApplicationRootPath + HtmlFile;
            if (!Common.BulidFolder(OutPutFilePath, true))      //检查路径是否正确
            {
                sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Project<br>");
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

        #endregion


        #region 该资源信息完整度(百分比)

        public string getCompleteDegreeById(ProjectSetModel model)
        {
            int degree = 0;

            if (model.ProjectInfoModel.CooperationDemandType == "9")//债券
            {
                degree = 35;
                if (model.ProjectInfoModel.iZqTzfbq != null && model.ProjectInfoModel.iZqTzfbq.ToString() != "")   //项目投资回报期
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.iZqYdbl != null && model.ProjectInfoModel.iZqYdbl.ToString() != "")   //流动比率
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.iZqXslyl != null && model.ProjectInfoModel.iZqXslyl.ToString() != "") //销售利润率
                {
                    degree += 2;
                }
                if (model.ProjectInfoModel.nDwlyysy != null && model.ProjectInfoModel.nDwlyysy.ToString().Trim() != "") //单位年营业收入
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwljly != null && model.ProjectInfoModel.nDwljly.ToString().Trim() != "") //单位年净利润
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzzc != null && model.ProjectInfoModel.nDwzzc.ToString().Trim() != "") //单位总资产
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzfz != null && model.ProjectInfoModel.nDwzfz.ToString().Trim() != "") //单位总负债
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.ComAbout != null && model.ProjectInfoModel.ComAbout.ToString().Trim() != "") //产品概述
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqXmlxqkb != null && model.ProjectInfoModel.cZqXmlxqkb.ToString().Trim() != "") //市场前景
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqJzfx != null && model.ProjectInfoModel.cZqJzfx.ToString().Trim() != "") //竞争分析
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqSyms != null && model.ProjectInfoModel.cZqSyms.ToString().Trim() != "") //商业模式
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqGltd != null && model.ProjectInfoModel.cZqGltd.ToString().Trim() != "") //管理团队
                {
                    degree += 6;
                }
                if (model.InfoResourceModels != null && model.InfoResourceModels.Count > 0) //项目资料附件
                {
                    degree += 10;
                }
                if (model.InfoContactModel.TelNum != null && model.InfoContactModel.TelNum.ToString().Trim() != "" || model.InfoContactModel.Mobile.ToString().Trim() != "") //联系电话
                {
                    degree += 2;
                }
                if (model.InfoContactModel.Name != null && model.InfoContactModel.Name.ToString().Trim() != "") //项目单位名称
                {
                    degree += 2;
                }
                if (model.InfoContactModel.Email != null && model.InfoContactModel.Email.ToString().Trim() != "") //电子邮箱
                {
                    degree += 1;
                }
                if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.ToString().Trim() != "") //项目单位详细地址
                {
                    degree += 1;
                }
                if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.ToString().Trim() != "") //项目单位网址
                {
                    degree += 1;
                }

            }
            else//股权
            {
                degree = 35;
                if (model.ProjectInfoModel.iZqTzfbq != null && model.ProjectInfoModel.iZqTzfbq.ToString() != "")   //项目投资回报期
                {
                    degree += 2;
                }
                if (model.MainInfoModel.KeyWord != null && model.MainInfoModel.KeyWord.ToString() != "")   //项目关键字
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.nDwlyysy != null && model.ProjectInfoModel.nDwlyysy.ToString() != "")   //项目关键字
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.nDwlyysy != null && model.ProjectInfoModel.nDwlyysy.ToString().Trim() != "") //单位年营业收入
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwljly != null && model.ProjectInfoModel.nDwljly.ToString().Trim() != "") //单位年净利润
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzzc != null && model.ProjectInfoModel.nDwzzc.ToString().Trim() != "") //单位总资产
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzfz != null && model.ProjectInfoModel.nDwzfz.ToString().Trim() != "") //单位总负债
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.ComAbout != null && model.ProjectInfoModel.ComAbout.ToString().Trim() != "") //产品概述
                {
                    degree += 8;
                }
                if (model.ProjectInfoModel.cZqXmlxqkb != null && model.ProjectInfoModel.cZqXmlxqkb.ToString().Trim() != "") //市场前景
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqJzfx != null && model.ProjectInfoModel.cZqJzfx.ToString().Trim() != "") //竞争分析
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqSyms != null && model.ProjectInfoModel.cZqSyms.ToString().Trim() != "") //商业模式
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqGltd != null && model.ProjectInfoModel.cZqGltd.ToString().Trim() != "") //管理团队
                {
                    degree += 6;
                }
                if (model.InfoResourceModels != null && model.InfoResourceModels.Count > 0) //项目资料附件
                {
                    degree += 10;
                }
                if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.ToString().Trim() != "") //职位
                {
                    degree += 1;
                }
                if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.ToString().Trim() != "") //项目单位详细地址
                {
                    degree += 1;
                }
                if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.ToString().Trim() != "") //项目单位网址
                {
                    degree += 1;
                }
            }

            return degree.ToString() + "%";
        }

        #endregion

    }
}
