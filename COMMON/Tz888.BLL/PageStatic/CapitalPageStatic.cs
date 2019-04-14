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
    /// <summary>
    /// 投资静态页面生成
    /// </summary>
    public class CapitalPageStatic
    {
        private const string CapitalTempChangeFileName = "TempCapitalChange.htm";   //CapitalChange模板路径
        private const string CapitalTempFeeFileName = "TempCapitalFee.htm";         //CapitalFee模板路径
        private const string CapitalTempVipFileName = "TempCapitalVip.htm";         //CaiptalVip摸版路径
        private const string CapitalTempEndFileTo = "";                             //最终文件的输出路径
        private const string CapitalPicPath = "http://images.topfo.com/";           //图片路径
        private const string CapitalResourcePath = "";                              //资源路径
        private const string TagsUrl = "http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";
        private readonly ICapitalInfo dal = DataAccess.CreateInfo_CapitalInfo();
       

        #region 输出静态页面文件
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageCapital_before20100820(string InfoID,ref string UpdateMsg)
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

                float InfoPrice;
                string InfoPriceName; //用于显示         

                string InfoOriginRoleName;

                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = "";

                string CapitalName;    //资本金额
                string CurrencyName; //货币种类

                string CapitalTypeName;//资本类型:直投,银行,担保,风险....            

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

                string UserGradeTypeID = "";
                #endregion

                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));

                #region 获取模板名称
                string TempName = "";

                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2)
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

                CapitalTypeName = theCapital.CapitalInfoModel.CapitalTypeName.Trim();
                
                CapitalName = theCapital.CapitalInfoModel.CapitalName.Trim();
                if (CapitalName == "0")
                    CapitalName = "";



                //合作方式
                CooperationTypeName = "";
                foreach (string sCoopTypeName in theCapital.CapitalInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }

                //投资区域
                AreaName = "";
                if (theCapital.CapitalInfoAreaModels != null)
                {
                    foreach (Tz888.Model.Info.CapitalInfoAreaModel tempCIAM in theCapital.CapitalInfoAreaModels)
                    {
                        if (!string.IsNullOrEmpty(tempCIAM.CountryName))
                        {
                            AreaName = tempCIAM.CountryName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.ProvinceName))
                        {
                            AreaName += " " + tempCIAM.ProvinceName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CityName))
                        {
                            AreaName += " " + tempCIAM.CityName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CountyName))
                        {
                            AreaName += " " + tempCIAM.CountyName.Trim();
                        }
                        if (!string.IsNullOrEmpty(AreaName))
                            AreaName += "<br />";
                    }
                }
                else
                {
                    AreaName = "不限";
                }

                //所属于行业
                IndustryName = "";
                foreach (string sTempIndustry in theCapital.CapitalInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }

                PublishT = theCapital.MainInfoModel.publishT.ToShortDateString();
                ValidatePeriod = theCapital.MainInfoModel.ValidateTerm.ToString().Trim();
                PublisLoginName = theCapital.MainInfoModel.LoginName.ToString().Trim();

                if (theCapital.CapitalInfoModel.ComBreif.Trim() != "")
                    TZYX = theCapital.CapitalInfoModel.ComBreif.Trim();
                else
                    TZYX = theCapital.CapitalInfoModel.ComAbout.Trim();

                loginName = theCapital.MainInfoModel.LoginName.Trim();

                //联系人个人
                ContractPersonName = "";
                ContractCellPhone = "";

                if (theCapital.InfoContactModel != null)
                {
                    ContractPersonName = theCapital.InfoContactModel.Name.Trim();
                    ContractCellPhone = theCapital.InfoContactModel.Mobile.Trim();
                    if (theCapital.InfoContactManModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoContactManModel icmTemp in theCapital.InfoContactManModels)
                        {
                            ContractPersonName = ContractPersonName + icmTemp.Name.Trim();
                            ContractCellPhone = ContractCellPhone + icmTemp.Mobile.Trim();
                        }
                    }

                    //联系人公司
                    ContractPersonCompanyName = theCapital.InfoContactModel.OrganizationName.Trim();
                    ContractPersonPhone = theCapital.InfoContactModel.TelNum.Trim();
                    ContractPersonFax = theCapital.InfoContactModel.FaxNum.Trim();
                    ContractPersonAddress = theCapital.InfoContactModel.Address.Trim();
                    ContractPersonPostCode = theCapital.InfoContactModel.PostCode.Trim();
                    ContractPersonWebsite = theCapital.InfoContactModel.WebSite.Trim();
                }

                Title = theCapital.MainInfoModel.Title;
                FrontDisplayTime = theCapital.MainInfoModel.FrontDisplayTime.ToShortDateString();
                Hit = theCapital.MainInfoModel.Hit.ToString();
                blisCore = theCapital.MainInfoModel.IsCore;
                FixPriceID = theCapital.MainInfoModel.FixPriceID;

                Industry = theCapital.CapitalInfoModel.IndustryBID;

                CapitalName = theCapital.CapitalInfoModel.CapitalName;

                CurrencyName = theCapital.CapitalInfoModel.Currency.Trim().ToLower();

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
                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0))
                {
                    ResourceInfo1 = "为提高对接质量，该资源被用户设置为付费资源";
                    ResourceInfo2 = "购买";
                    ResourceValue = Convert.ToDecimal(theCapital.MainInfoModel.MainPointCount.ToString().Trim()).ToString("c");
                    Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
                    Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
                    objDic = diBll.GetModel("1");
                    ResourceValueVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * theCapital.MainInfoModel.MainPointCount)).ToString("c");
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
                if (theCapital.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in theCapital.InfoResourceModels)
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
                    Pic1_r = "<li><a href=\"" + CapitalPicPath.Trim() + Pic1_s.Trim() + "\" target=\"_blank\"><img src=" + CapitalPicPath.Trim() + Pic1_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }

                if (arrListPic.Count > 1)
                {
                    string[] sPicTemp = (string[])arrListPic[1];
                    Pic2 = sPicTemp[0];
                    Pic2_c = sPicTemp[1];
                    //Pic2_s = Common.GetMiniPic(Pic2);
                    Pic2_s = Pic2;
                    Pic2_r = "<li><a href=\"" + CapitalPicPath.Trim() + Pic2_s.Trim() + "\" target=\"_blank\"><img src=" + CapitalPicPath.Trim() + Pic2_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 2)
                {
                    string[] sPicTemp = (string[])arrListPic[2];
                    Pic3 = sPicTemp[0];
                    Pic3_c = sPicTemp[1];
                    //Pic3_s = Common.GetMiniPic(Pic3);
                    Pic3_s = Pic3;
                    Pic3_r = "<li><a href=\"" + CapitalPicPath.Trim() + Pic3_s.Trim() + "\" target=\"_blank\"><img src=" + CapitalPicPath.Trim() + Pic3_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 3)
                {
                    string[] sPicTemp = (string[])arrListPic[3];
                    Pic4 = sPicTemp[0];
                    Pic4_c = sPicTemp[1];
                    //Pic4_s = Common.GetMiniPic(Pic4);
                    Pic4_s = Pic4;
                    Pic4_r = "<li><a href=\"" + CapitalPicPath.Trim() + Pic4_s.Trim() + "\" target=\"_blank\"><img src=" + CapitalPicPath.Trim() + Pic4_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 4)
                {
                    string[] sPicTemp = (string[])arrListPic[4];
                    Pic5 = sPicTemp[0];
                    Pic5_c = sPicTemp[1];
                    //Pic5_s = Common.GetMiniPic(Pic5);
                    Pic5_s = Pic5;
                    Pic5_r = "<li><a href=\"" + CapitalPicPath.Trim() + Pic5_s.Trim() + "\" target=\"_blank\"><img src=" + CapitalPicPath.Trim() + Pic5_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 5)
                {
                    string[] sPicTemp = (string[])arrListPic[5];
                    Pic6 = sPicTemp[0];
                    Pic6_c = sPicTemp[1];
                    //Pic6_s = Common.GetMiniPic(Pic6);
                    Pic6_s = Pic6;
                    Pic6_r = "<li><a href=\"" + CapitalPicPath.Trim() + Pic6_s.Trim() + "\" target=\"_blank\"><img src=" + CapitalPicPath.Trim() + Pic6_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }


                if (arrListDoc.Count > 0)
                {
                    string[] sDocTemp = (string[])arrListDoc[0];
                    Doc1 = sDocTemp[0];
                    Doc1_c = sDocTemp[1];
                    Doc1_r = "<li>" + Doc1_c + "：<a href='" + Doc1 + "'>查看</a><a href='" + CapitalResourcePath + Doc1 + "'>下载</a></li>";
                }

                if (arrListDoc.Count > 1)
                {
                    string[] sDocTemp = (string[])arrListDoc[1];
                    Doc2 = sDocTemp[0];
                    Doc2_c = sDocTemp[1];
                    Doc2_r = "<li>" + Doc2_c + "：<a href='" + Doc2 + "'>查看</a><a href='" + CapitalResourcePath + Doc2 + "'>下载</a></li>";
                }
                if (arrListDoc.Count > 2)
                {
                    string[] sDocTemp = (string[])arrListDoc[2];
                    Doc3 = sDocTemp[0];
                    Doc3_c = sDocTemp[1];
                    Doc3_r = "<li>" + Doc3_c + "：<a href='" + Doc3 + "'>查看</a><a href='" + CapitalResourcePath + Doc3 + "'>下载</a></li>";
                }

                HasPic = false;
                if (Pic1 != "")
                    HasPic = true;


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

                #endregion 变量赋值

                #region 替换模版

                #region Vip的模板
                if (TempName.Trim() == CapitalTempVipFileName)//Vip模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", CapitalName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTypeName#", CapitalTypeName);
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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion

                #region 收费的模板
                if (TempName.Trim() == CapitalTempChangeFileName)//收费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTypeName#", CapitalTypeName);
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

                }
                #endregion

                #region 免费的模板
                if (TempName.Trim() == CapitalTempFeeFileName)//免费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTypeName#", CapitalTypeName);
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

        /// <summary>
        /// CreateStaticPageCapital_V3 的copy,因页面上调用的是该方法,新方法改成了CreateStaticPageCapital_V3,这样页面不用作改动
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="UpdateMsg"></param>
        /// <returns></returns>
        public bool CreateStaticPageCapital(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
                string TempCapitalPath = ConfigurationManager.AppSettings["CapitalTmpPath"].ToString(); //投资模板的存放位置
                string TempCapitalPathTo = ConfigurationManager.AppSettings["CapitalTmpPathTo"].ToString(); //投资模板的存放位置
                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

                string TempName = "Template/Temp_Info_V3/Temp_Capital_V3.htm";  //获取模板名称
                CapitalSetModel theCapital = new CapitalSetModel();
                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));
                Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
                DataTable dt_login = login.GetLoginInfo(theCapital.MainInfoModel.LoginName);

                string loginName;
                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;
                byte AuditingStatus;
                string HtmlFile = theCapital.MainInfoModel.HtmlFile;

                #endregion


                #region 读取模板内容

                StreamReader srSource;
                string TmpFileName = ApplicationRootPath + TempName;
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


                #region 替换模版

                TmpTmpSource = TmpSource;
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", theCapital.MainInfoModel.Title);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", theCapital.MainInfoModel.Descript.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", theCapital.MainInfoModel.publishT.ToShortDateString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", theCapital.MainInfoModel.HtmlFile.ToString());

                if (dt_login != null && dt_login.Rows.Count > 0 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
                {
                    MemberGradeID = "<img src=\"/CommonV3/img/res3_icon1.gif\">";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());

                string CooperationTypeName = ""; //合作方式
                foreach (string sCoopTypeName in theCapital.CapitalInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);

                string AreaName = ""; //投资区域
                if (theCapital.CapitalInfoAreaModels != null)
                {
                    foreach (Tz888.Model.Info.CapitalInfoAreaModel tempCIAM in theCapital.CapitalInfoAreaModels)
                    {
                        if (!string.IsNullOrEmpty(tempCIAM.CountryName))
                        {
                            AreaName = tempCIAM.CountryName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.ProvinceName))
                        {
                            AreaName += " " + tempCIAM.ProvinceName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CityName))
                        {
                            AreaName += " " + tempCIAM.CityName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CountyName))
                        {
                            AreaName += " " + tempCIAM.CountyName.Trim();
                        }
                        if (!string.IsNullOrEmpty(AreaName))
                            AreaName += "<br />";
                    }
                }
                else
                {
                    AreaName = "不限";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", theCapital.CapitalInfoModel.CapitalName.Trim());

                string CurrencyName = theCapital.CapitalInfoModel.Currency.Trim().ToLower();
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
                if (theCapital.CapitalInfoModel.CapitalName.Trim() == "不限")
                    CurrencyName = "";
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                string stageID = "";      //企业发展阶段
                switch (theCapital.CapitalInfoModel.stageID.ToString().Trim())
                {
                    case "0":
                    case "1": stageID = "种子期"; break;
                    case "2": stageID = "创立期"; break;
                    case "3": stageID = "成长期"; break;
                    case "4": stageID = "成熟期"; break;
                    case "5": stageID = "Pro-IPO"; break;
                    case "6": stageID = "稳定期"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-stageID#", stageID);

                if (theCapital.CapitalInfoModel.RegisteredCapital != null)
                {
                    string RegisteredCapital = "";
                    switch (theCapital.CapitalInfoModel.RegisteredCapital.ToString().Trim())
                    {
                        case "0":
                        case "1": RegisteredCapital = "5000万以下"; break;
                        case "2": RegisteredCapital = "5000万-1亿"; break;
                        case "3": RegisteredCapital = "1-2亿"; break;
                        case "4": RegisteredCapital = "2-10亿"; break;
                        case "5": RegisteredCapital = "Pro-IPO"; break;
                        case "6": RegisteredCapital = "10亿以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-RegisteredCapital#", RegisteredCapital.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-RegisteredCapital#", "");
                }
                if (theCapital.CapitalInfoModel.AverageInvestment != null)
                {
                    string AverageInvestment = "";
                    switch (theCapital.CapitalInfoModel.AverageInvestment.ToString().Trim())
                    {
                        case "0":
                        case "1": AverageInvestment = "0个"; break;
                        case "2": AverageInvestment = "1-2个"; break;
                        case "3": AverageInvestment = "3-5个"; break;
                        case "4": AverageInvestment = "5个以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AverageInvestment#", AverageInvestment.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AverageInvestment#", "");
                }
                if (theCapital.CapitalInfoModel.SuccessfulInvestment != null)
                {
                    string SuccessfulInvestment = "";
                    switch (theCapital.CapitalInfoModel.SuccessfulInvestment.ToString().Trim())
                    {
                        case "0":
                        case "1": SuccessfulInvestment = "0个"; break;
                        case "2": SuccessfulInvestment = "1-10个"; break;
                        case "3": SuccessfulInvestment = "10-30个"; break;
                        case "4": SuccessfulInvestment = "30-60个"; break;
                        case "5": SuccessfulInvestment = "60个以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SuccessfulInvestment#", SuccessfulInvestment.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SuccessfulInvestment#", "");
                }

                if (theCapital.CapitalInfoModel.joinManageID != null)
                {
                    string joinManageID = "";
                    switch (theCapital.CapitalInfoModel.joinManageID.ToString().Trim())
                    {
                        case "0": joinManageID = "参与"; break;
                        case "1": joinManageID = "不参与"; break;
                        case "2": joinManageID = "面议"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-joinManageID#", joinManageID.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-joinManageID#", "");
                }

                if (theCapital.CapitalInfoModel.TeamScale != null)
                {
                    string TeamScale = "";
                    switch (theCapital.CapitalInfoModel.TeamScale.ToString().Trim())
                    {
                        case "0":
                        case "1": TeamScale = "5人以下"; break;
                        case "2": TeamScale = "5-10人"; break;
                        case "3": TeamScale = "10-20人"; break;
                        case "4": TeamScale = "20-30人"; break;
                        case "5": TeamScale = "30-50人"; break;
                        case "6": TeamScale = "50人以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TeamScale#", TeamScale.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TeamScale#", "");
                }

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", theCapital.MainInfoModel.ValidateTerm.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", theCapital.MainInfoModel.MainPointCount.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTypeName#", theCapital.CapitalInfoModel.CapitalTypeName.Trim());
                //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TeamScale#", theCapital.CapitalInfoModel.TeamScale.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(theCapital));  //该资源信息完整度(百分比)

                string IndustryName = "";   //所属于行业
                foreach (string sTempIndustry in theCapital.CapitalInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

                string IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                    "该资源未经过中国招商投资网核实认证<br />我们<span class='f_org strong'>不保证资源的真实性</span>！";  //不是认证资源
                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                        "该资源已经过中国招商投资网核实认证<br />我们<span class='f_org strong'>保证资源的真实性</span>！";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

                string userDomain = GetSelfDomain(theCapital.MainInfoModel.LoginName.Trim());  //展厅 用户域名
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

                //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(theCapital.MainInfoModel.InfoID.ToString()).ToString());  //购买者评级
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComBrief#", theCapital.CapitalInfoModel.ComBreif.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", theCapital.CapitalInfoModel.ComAbout.ToString());
                List<InfoResourceModel> attachments = attachmentbll.GetModelList(theCapital.MainInfoModel.InfoID);
                if (attachments != null)
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", attachments.Count.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", "0");
                }

                #endregion


                #region 输出文件
                OutPutFilePath = ApplicationRootPath + HtmlFile;

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
                #endregion


                UpdateMsg = sbUpdateMsg.ToString();
                return true;
            }
            catch (Exception ex)
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


        #region 模板V3版生成静态页面
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageCapital_V3(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
                string TempCapitalPath = ConfigurationManager.AppSettings["CapitalTmpPath"].ToString(); //投资模板的存放位置
                string TempCapitalPathTo = ConfigurationManager.AppSettings["CapitalTmpPathTo"].ToString(); //投资模板的存放位置
                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

                string TempName = "Template/Temp_Info_V3/Temp_Capital_V3.htm";  //获取模板名称
                CapitalSetModel theCapital = new CapitalSetModel();
                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));
                Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
                DataTable dt_login = login.GetLoginInfo(theCapital.MainInfoModel.LoginName);

                string loginName;
                string TmpTmpSource = "";
                string OutPutFilePath; //输出路径
                StreamWriter swOutPut;
                byte AuditingStatus;
                string HtmlFile = theCapital.MainInfoModel.HtmlFile;

                #endregion


                #region 读取模板内容

                StreamReader srSource;
                string TmpFileName = ApplicationRootPath + TempName;
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


                #region 替换模版

                TmpTmpSource = TmpSource;
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", theCapital.MainInfoModel.Title);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", theCapital.MainInfoModel.Descript.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", theCapital.MainInfoModel.publishT.ToShortDateString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", theCapital.MainInfoModel.HtmlFile.ToString());

                if (dt_login != null && dt_login.Rows.Count > 0 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
                {
                    MemberGradeID = "<img src=\"/CommonV3/img/res3_icon1.gif\">";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());
                
                string CooperationTypeName = ""; //合作方式
                foreach (string sCoopTypeName in theCapital.CapitalInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);
               
                string AreaName = ""; //投资区域
                if (theCapital.CapitalInfoAreaModels != null)
                {
                    foreach (Tz888.Model.Info.CapitalInfoAreaModel tempCIAM in theCapital.CapitalInfoAreaModels)
                    {
                        if (!string.IsNullOrEmpty(tempCIAM.CountryName))
                        {
                            AreaName = tempCIAM.CountryName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.ProvinceName))
                        {
                            AreaName += " " + tempCIAM.ProvinceName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CityName))
                        {
                            AreaName += " " + tempCIAM.CityName.Trim();
                        }
                        if (!string.IsNullOrEmpty(tempCIAM.CountyName))
                        {
                            AreaName += " " + tempCIAM.CountyName.Trim();
                        }
                        if (!string.IsNullOrEmpty(AreaName))
                            AreaName += "<br />";
                    }
                }
                else
                {
                    AreaName = "不限";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", theCapital.CapitalInfoModel.CapitalName.Trim());

                string CurrencyName = theCapital.CapitalInfoModel.Currency.Trim().ToLower();
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
                if (theCapital.CapitalInfoModel.CapitalName.Trim() == "不限")
                    CurrencyName = "";
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                string stageID = "";      //企业发展阶段
                switch (theCapital.CapitalInfoModel.stageID.ToString().Trim())
                {
                    case "0":
                    case "1": stageID = "种子期"; break;
                    case "2": stageID = "创立期"; break;
                    case "3": stageID = "成长期"; break;
                    case "4": stageID = "成熟期"; break;
                    case "5": stageID = "Pro-IPO"; break;
                    case "6": stageID = "稳定期"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-stageID#", stageID);

                if (theCapital.CapitalInfoModel.RegisteredCapital != null)
                {
                    string RegisteredCapital = "";   
                    switch (theCapital.CapitalInfoModel.RegisteredCapital.ToString().Trim())
                    {
                        case "0":
                        case "1": RegisteredCapital = "5000万以下"; break;
                        case "2": RegisteredCapital = "5000万-1亿"; break;
                        case "3": RegisteredCapital = "1-2亿"; break;
                        case "4": RegisteredCapital = "2-10亿"; break;
                        case "5": RegisteredCapital = "Pro-IPO"; break;
                        case "6": RegisteredCapital = "10亿以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-RegisteredCapital#", RegisteredCapital.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-RegisteredCapital#", "");
                }
                if (theCapital.CapitalInfoModel.AverageInvestment != null)
                {
                    string AverageInvestment = "";   
                    switch (theCapital.CapitalInfoModel.AverageInvestment.ToString().Trim())
                    {
                        case "0":
                        case "1": AverageInvestment = "0个"; break;
                        case "2": AverageInvestment = "1-2个"; break;
                        case "3": AverageInvestment = "3-5个"; break;
                        case "4": AverageInvestment = "5个以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AverageInvestment#", AverageInvestment.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AverageInvestment#", "");
                }
                if (theCapital.CapitalInfoModel.SuccessfulInvestment != null)
                {
                    string SuccessfulInvestment = "";
                    switch (theCapital.CapitalInfoModel.SuccessfulInvestment.ToString().Trim())
                    {
                        case "0":
                        case "1": SuccessfulInvestment = "0个"; break;
                        case "2": SuccessfulInvestment = "1-10个"; break;
                        case "3": SuccessfulInvestment = "10-30个"; break;
                        case "4": SuccessfulInvestment = "30-60个"; break;
                        case "5": SuccessfulInvestment = "60个以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SuccessfulInvestment#", SuccessfulInvestment.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SuccessfulInvestment#", "");
                }

                if (theCapital.CapitalInfoModel.joinManageID != null)
                {
                    string joinManageID = "";
                    switch (theCapital.CapitalInfoModel.joinManageID.ToString().Trim())
                    {
                        case "0": joinManageID = "参与"; break;
                        case "1": joinManageID = "不参与"; break;
                        case "2": joinManageID = "面议"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-joinManageID#", joinManageID.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-joinManageID#", "");
                }

                if (theCapital.CapitalInfoModel.TeamScale != null)
                { 
                    string TeamScale = "";
                    switch (theCapital.CapitalInfoModel.TeamScale.ToString().Trim())
                    {
                        case "0":
                        case "1": TeamScale = "5人以下"; break;
                        case "2": TeamScale = "5-10人"; break;
                        case "3": TeamScale = "10-20人"; break;
                        case "4": TeamScale = "20-30人"; break;
                        case "5": TeamScale = "30-50人"; break;
                        case "6": TeamScale = "50人以上"; break;
                    }
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TeamScale#", TeamScale.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TeamScale#", "");
                }
                
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", theCapital.MainInfoModel.ValidateTerm.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", theCapital.MainInfoModel.MainPointCount.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTypeName#", theCapital.CapitalInfoModel.CapitalTypeName.Trim());
                //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TeamScale#", theCapital.CapitalInfoModel.TeamScale.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(theCapital));  //该资源信息完整度(百分比)

                string IndustryName = "";   //所属于行业
                foreach (string sTempIndustry in theCapital.CapitalInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

                string IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" + 
                    "该资源未经过中国招商投资网核实认证<br />我们<span class='f_org strong'>不保证资源的真实性</span>！";  //不是认证资源
                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0) 
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                        "该资源已经过中国招商投资网核实认证<br />我们<span class='f_org strong'>保证资源的真实性</span>！";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

                string userDomain = GetSelfDomain(theCapital.MainInfoModel.LoginName.Trim());  //展厅 用户域名
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

                //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(theCapital.MainInfoModel.InfoID.ToString()).ToString());  //购买者评级
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComBrief#", theCapital.CapitalInfoModel.ComBreif.ToString());  
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", theCapital.CapitalInfoModel.ComAbout.ToString());  
                List<InfoResourceModel> attachments = attachmentbll.GetModelList(theCapital.MainInfoModel.InfoID);
                if (attachments != null)
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", attachments.Count.ToString());
                }
                else
                {
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", "0");
                }

                #endregion


                #region 输出文件
                OutPutFilePath = ApplicationRootPath + HtmlFile;

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
                #endregion


                UpdateMsg = sbUpdateMsg.ToString();
                return true;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString().Trim();
                sbUpdateMsg.Append(err);
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
        }
        #endregion


        #region 该资源信息完整度(百分比)

        public string getCompleteDegreeById(CapitalSetModel model)
        {
            int degree = 50;
            if (model.CapitalInfoModel.TeamScale != null && model.CapitalInfoModel.TeamScale.Trim() != "")  //机构团队规模
            {
                degree += 6;
            }
            if (model.CapitalInfoModel.TeamScale != null && model.CapitalInfoModel.AverageInvestment.Trim() != "")  //机构投资事件数
            {
                degree += 6;
            }
            if (model.CapitalInfoModel.TeamScale != null && model.CapitalInfoModel.SuccessfulInvestment.Trim() != "")  //成功投资事件总数
            {
                degree += 6;
            }
            if (model.InfoContactModel.OrgIntro != null && model.InfoContactModel.OrgIntro.Trim() != "")  //投资机构简介
            {
                degree += 2;
            }
            if (model.InfoContactModel.Name != null && model.InfoContactModel.Name.Trim() != "")  //联系人
            {
                degree += 2;
            }
            if (model.InfoContactModel.TelNum != null && model.InfoContactModel.TelNum.Trim() != "" || model.InfoContactModel.Mobile.Trim() != "")  //联系电话
            {
                degree += 2;
            }
            if (model.InfoContactModel.Email != null && model.InfoContactModel.Email.Trim() != "")  //电子邮箱
            {
                degree += 2;
            }
            if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.Trim() != "")  //电子邮箱
            {
                degree += 2;
            }
            if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.Trim() != "")  //职位
            {
                degree += 2;
            }
            if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.Trim() != "")  //职位
            {
                degree += 2;
            }
            if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.Trim() != "")  //职位
            {
                degree += 2;
            }

            return degree.ToString()+"%";
        }

        #endregion
        

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
    }
}
