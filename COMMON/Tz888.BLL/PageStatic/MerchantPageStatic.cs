using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;

using System.Web;
using Tz888.Model.Info;
using Tz888.DALFactory;
using Tz888.IDAL.Info;
using System.Data;
using System.Reflection;

namespace Tz888.BLL.PageStatic
{
    public class MerchantPageStatic
    {

        #region 成员变量

        private const string MerchantTempChangeFileName = "TempMerchantChange.htm"; //MerchantChange模板路径
        private const string MerchantTempFeeFileName = "TempMerchantFee.htm";       //MerchantFee模板路径
        private const string MerchantTempVipFileName = "TempMerchantVip.htm";       //MerchantVip摸版路径
        private const string MerchantTempEndFileTo = "";                        //最终文件的输出路径
        private const string MerchantPicPath = "http://images.topfo.com/";      //图片路径
        private const string MerchantResourcePath = "";                         //资源路径
        private const string TagsUrl = "http://search.topfo.com/SearchResultMerchant.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultMerchant.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly IMarchantInfo dal = DataAccess.CreateInfo_MarchantInfo();
        private const string Merchant_ZQ = "Merchant_ZQ.htm";           //债券融资
        private const string Merchant_GQ = "Merchant_GQ.htm";           //股权融资
        private const string Merchant_ZQ_Vip = "Merchant_ZQ_Vip.htm";
        private const string Merchant_GQ_Vip = "Merchant_GQ_Vip.htm";

        #endregion


        #region 输出静态页面文件
        /// <summary>
        /// 创建静态页面
        /// </summary>		
        /// <param name="InfoIDArr">需要更新的信息ID列表</param>
        /// <param name="IsLog">是否需要将信息写入日志</param>
        /// <param name="UpdateMsg">处理的日志</param>
        /// <returns></returns>
        public bool CreateStaticPageMerchant_before20100820(string InfoID,ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region 变量定义

                //系统路径
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //静态页面的根目录
                //模板路径
                string TempMerchantPath = ConfigurationManager.AppSettings["MerchantTmpPath"].ToString(); //融资模板的存放位置
                //目标路径
                string TempMerchantPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //融资模板的存放位置

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

                MerchantSetModel TheMerchant = new MerchantSetModel();

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

                string MerchantNameTotal;//总投资金额

                string MerchantTypeName;//招商类别

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

                string CapitalTotal="";//总投资
                string MerchantToltal = "";//引资额
                string CapitalCurrencyName; //总投资货币种类
                string CurrencyName; //货币种类

                string MerchantToltalName = "";//引资额(Name)

                string ResourceInfo1 = "";//资源提示信息1
                string ResourceInfo2 = "";//资源提示信息2

                string ManageType = "";//会员类型
                string UserDetail = "";//用户的公司详细信息
                string ManageTypeName = ""; //拓富通会员类型

                string UserGradeTypeID = "";
                #endregion

                TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));

                #region 获取模板名称
                string TempName = "";

                if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    //认证资源模版
                    TempName = MerchantTempChangeFileName;
                }
                else
                {
                    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
                    UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(TheMerchant.MainInfoModel.LoginName.Trim());
                    if (UserGradeTypeID == "1001")
                    {
                        //普通用户模板
                        TempName = MerchantTempFeeFileName;
                    }
                    else
                    {
                        //VIP会员模板
                        TempName = MerchantTempVipFileName;
                    }
                }

                #endregion

                #region 读取模板内容

                StreamReader srSource;
                string TmpFileName;
                TmpFileName = ApplicationRootPath + TempMerchantPath + TempName;
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
                if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = TheMerchant.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
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
                MerchantTypeName = TheMerchant.MerchantInfoModel.MerchantTypeName.Trim();

                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString().Trim();
                CapitalCurrencyName = TheMerchant.MerchantInfoModel.CapitalCurrency.Trim().ToLower();
                switch (CapitalCurrencyName)
                {
                    case "cny":
                        CapitalCurrencyName = "人民币";
                        break;
                    case "hkd":
                        CapitalCurrencyName = "港币";
                        break;
                    case "usd":
                        CapitalCurrencyName = "美元";
                        break;
                    default:
                        CapitalCurrencyName = "人民币";
                        break;
                }

                MerchantToltal = TheMerchant.MerchantInfoModel.MerchantTotal.ToString().Trim();
                CurrencyName = TheMerchant.MerchantInfoModel.MerchantCurrency.Trim().ToLower();
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
                };

                MerchantToltalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim();

                if (MerchantToltalName.Trim() == "不限")
                    CurrencyName = "";

                //合作方式
                CooperationTypeName = "";
                foreach (string sCoopTypeName in TheMerchant.MerchantInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }

                //投资区域
                AreaName = "";

                if (TheMerchant.MerchantInfoModel != null)
                {
                    if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountryName))
                    {
                        AreaName = TheMerchant.MerchantInfoModel.CountryName.Trim();
                    }
                    if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.ProvinceName))
                    {
                        AreaName += " " + TheMerchant.MerchantInfoModel.ProvinceName.Trim();
                    }
                    if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CityName))
                    {
                        AreaName += " " + TheMerchant.MerchantInfoModel.CityName.Trim();
                    }
                    if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountyName))
                    {
                        AreaName += " " + TheMerchant.MerchantInfoModel.CountyName.Trim();
                    }
                }
                


                //所属于行业
                IndustryName = "";
                foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
                {
                    IndustryName = IndustryName + sTempIndustry.Trim();
                }

                //开始时间
                PublishT = TheMerchant.MainInfoModel.ValidateStartTime.ToShortDateString().Trim();
                //结束时间
                ValidatePeriod = TheMerchant.MainInfoModel.ValidateTerm.ToString().Trim();

                PublisLoginName = TheMerchant.MainInfoModel.LoginName.ToString().Trim();


                if (TheMerchant.MerchantInfoModel.ZoneAboutBrief.Trim() != "")
                    TZYX = TheMerchant.MerchantInfoModel.ZoneAboutBrief.Trim();
                else
                    TZYX = TheMerchant.MerchantInfoModel.ZoneAbout.Trim();

                loginName = TheMerchant.MainInfoModel.LoginName.Trim();

                //联系人个人
                ContractPersonName = "";
                ContractCellPhone = "";

                
                //if (TheMerchant.InfoContactManModels != null)
                if (TheMerchant.InfoContactModel != null)
                {
                    ContractPersonName = TheMerchant.InfoContactModel.Name.Trim();
                    ContractCellPhone = TheMerchant.InfoContactModel.Mobile.Trim();
                    if (TheMerchant.InfoContactManModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoContactManModel icmTemp in TheMerchant.InfoContactManModels)
                        {
                            ContractPersonName = ContractPersonName + icmTemp.Name.Trim();
                            ContractCellPhone = ContractCellPhone + icmTemp.Mobile.Trim();
                        }
                    }
                    
                    //联系人公共信息

                    ContractPersonCompanyName = TheMerchant.InfoContactModel.OrganizationName.Trim();
                    ContractPersonPhone = TheMerchant.InfoContactModel.TelNum.Trim();
                    ContractPersonFax = TheMerchant.InfoContactModel.FaxNum.Trim();
                    ContractPersonAddress = TheMerchant.InfoContactModel.Address.Trim();
                    ContractPersonPostCode = TheMerchant.InfoContactModel.PostCode.Trim();
                    ContractPersonWebsite = TheMerchant.InfoContactModel.WebSite.Trim();
                }

                Title = TheMerchant.MainInfoModel.Title;
                FrontDisplayTime = TheMerchant.MainInfoModel.FrontDisplayTime.ToShortDateString();
                Hit = TheMerchant.MainInfoModel.Hit.ToString();
                blisCore = TheMerchant.MainInfoModel.IsCore;
                FixPriceID = TheMerchant.MainInfoModel.FixPriceID;

                Industry = TheMerchant.MerchantInfoModel.IndustryClassList;

                MerchantNameTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString().Trim();

                //资源价格
                if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0))
                {
                    ResourceInfo1 = "为提高对接质量，该资源被用户设置为付费资源";
                    ResourceInfo2 = "购买";
                    ResourceValue = Convert.ToDecimal(TheMerchant.MainInfoModel.MainPointCount.ToString().Trim()).ToString("c");
                    Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
                    Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
                    objDic = diBll.GetModel("1");
                    ResourceValueVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * TheMerchant.MainInfoModel.MainPointCount)).ToString("c");
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
                if (TheMerchant.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in TheMerchant.InfoResourceModels)
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
                    Pic1_r = "<li><a href=\""+ MerchantPicPath.Trim() + Pic1_s.Trim() + "\" target=\"_blank\"><img src=" + MerchantPicPath.Trim() + Pic1_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }

                if (arrListPic.Count > 1)
                {
                    string[] sPicTemp = (string[])arrListPic[1];
                    Pic2 = sPicTemp[0];
                    Pic2_c = sPicTemp[1];
                    //Pic2_s = Common.GetMiniPic(Pic2);
                    Pic2_s = Pic2;
                    Pic2_r = "<li><a href=\"" + MerchantPicPath.Trim() + Pic2_s.Trim() + "\" target=\"_blank\"><img src=" + MerchantPicPath.Trim() + Pic2_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 2)
                {
                    string[] sPicTemp = (string[])arrListPic[2];
                    Pic3 = sPicTemp[0];
                    Pic3_c = sPicTemp[1];
                    //Pic3_s = Common.GetMiniPic(Pic3);
                    Pic3_s = Pic3;
                    Pic3_r = "<li><a href=\"" + MerchantPicPath.Trim() + Pic3_s.Trim() + "\" target=\"_blank\"><img src=" + MerchantPicPath.Trim() + Pic3_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 3)
                {
                    string[] sPicTemp = (string[])arrListPic[3];
                    Pic4 = sPicTemp[0];
                    Pic4_c = sPicTemp[1];
                    //Pic4_s = Common.GetMiniPic(Pic4);
                    Pic4_s = Pic4;
                    Pic4_r = "<li><a href=\"" + MerchantPicPath.Trim() + Pic4_s.Trim() + "\" target=\"_blank\"><img src=" + MerchantPicPath.Trim() + Pic4_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 4)
                {
                    string[] sPicTemp = (string[])arrListPic[4];
                    Pic5 = sPicTemp[0];
                    Pic5_c = sPicTemp[1];
                    //Pic5_s = Common.GetMiniPic(Pic5);
                    Pic5_s = Pic5;
                    Pic5_r = "<li><a href=\"" + MerchantPicPath.Trim() + Pic5_s.Trim() + "\" target=\"_blank\"><img src=" + MerchantPicPath.Trim() + Pic5_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }
                if (arrListPic.Count > 5)
                {
                    string[] sPicTemp = (string[])arrListPic[5];
                    Pic6 = sPicTemp[0];
                    Pic6_c = sPicTemp[1];
                    //Pic6_s = Common.GetMiniPic(Pic6);
                    Pic6_s = Pic6;
                    Pic6_r = "<li><a href=\"" + MerchantPicPath.Trim() + Pic6_s.Trim() + "\" target=\"_blank\"><img src=" + MerchantPicPath.Trim() + Pic6_s.Trim() + " style=\"width:200px; height:200px;\"></a></li>";
                }


                if (arrListDoc.Count > 0)
                {
                    string[] sDocTemp = (string[])arrListDoc[0];
                    Doc1 = sDocTemp[0];
                    Doc1_c = sDocTemp[1];
                    Doc1_r = "<li>" + Doc1_c + "：<a href='" + Doc1 + "'>查看</a><a href='" + MerchantResourcePath + Doc1 + "'>下载</a></li>";
                }

                if (arrListDoc.Count > 1)
                {
                    string[] sDocTemp = (string[])arrListDoc[1];
                    Doc2 = sDocTemp[0];
                    Doc2_c = sDocTemp[1];
                    Doc2_r = "<li>" + Doc2_c + "：<a href='" + Doc2 + "'>查看</a><a href='" + MerchantResourcePath + Doc2 + "'>下载</a></li>";
                }
                if (arrListDoc.Count > 2)
                {
                    string[] sDocTemp = (string[])arrListDoc[2];
                    Doc3 = sDocTemp[0];
                    Doc3_c = sDocTemp[1];
                    Doc3_r = "<li>" + Doc3_c + "：<a href='" + Doc3 + "'>查看</a><a href='" + MerchantResourcePath + Doc3 + "'>下载</a></li>";
                }

                HasPic = false;
                if (Pic1 != "")
                    HasPic = true;


                KeyWord = TheMerchant.MainInfoModel.KeyWord;

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
                    KeyWord = string.Format(TagslinkModel, "招商", "招商");

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = TheMerchant.MainInfoModel.HtmlFile;
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (TheMerchant.MainInfoModel.DisplayTitle == "")
                {
                    TheMerchant.MainInfoModel.DisplayTitle = Title;
                }
                DisplayTitle = TheMerchant.MainInfoModel.DisplayTitle + "－" + "中国招商投资网";
                Descript = TheMerchant.MainInfoModel.Descript;
                TemplateID = Convert.ToInt32(TheMerchant.MainInfoModel.TemplateID);

                ManageType = this.GetManageType(loginName).Trim();
                string WebUrl = "";
                string ComIntro = "";
                string TopfoDoc = "";
                string Target = "_self";
                if (ManageType == "2002" || ManageType == "2003")
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

                    if (ds == null || ds.Tables[0].Rows.Count == 0 || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Domain"].ToString().Trim()))
                    {
                        WebUrl = "JavaScript:alert('该企业尚未创建展厅！');";
                        ComIntro = "JavaScript:alert('该企业尚未创建展厅！');";
                        TopfoDoc = "JavaScript:alert('该企业尚未创建展厅！');";
                    }
                    else
                    {
                        string ExhibitionHall = ds.Tables[0].Rows[0]["Domain"].ToString().Trim();
                        WebUrl = "http://" + ExhibitionHall + ".co.topfo.com";
                        ComIntro = WebUrl;
                        TopfoDoc = WebUrl;
                        Target = "_blank";
                    }

                    UserDetail = string.Format(UserDetailModel, WebUrl, Target, ComIntro, Target, TopfoDoc, Target);
                }
                else if (ManageType == "2001")
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

                #region 替换模版

                #region Vip的模板
                if (TempName.Trim() == MerchantTempVipFileName)//Vip模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantNameTotal#", MerchantNameTotal);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTypeName#", MerchantTypeName);
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

                    if (CapitalTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "<tr><td class=\"h\">总投资：</td><td>" + CapitalTotal + "万 " + CapitalCurrencyName + "</td></tr>");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantToltal#", MerchantToltalName);//引资金额

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion

                #region 收费的模板
                if (TempName.Trim() == MerchantTempChangeFileName)//收费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantNameTotal#", MerchantNameTotal);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTypeName#", MerchantTypeName);
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

                    if (CapitalTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "<tr><td class=\"h\">总投资：</td><td>" + CapitalTotal + "万 " + CapitalCurrencyName + "</td></tr>");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantToltal#", MerchantToltalName);//引资金额

                }
                #endregion

                #region 免费的模板
                if (TempName.Trim() == MerchantTempFeeFileName)//免费的模板
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantNameTotal#", MerchantNameTotal);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTypeName#", MerchantTypeName);
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
                    if (CapitalTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "<tr><td class=\"h\">总投资：</td><td>" + CapitalTotal + "万" + CapitalCurrencyName + "</td></tr>");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantToltal#", MerchantToltalName);//引资金额

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion


                #endregion

                #region 输出文件
                OutPutFilePath = ApplicationRootPath + TempMerchantPathTo.Trim()+ HtmlFile;

                //检查路径是否正确
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]路径" + OutPutFilePath + "不正确!资源类型：Merchant<br>");
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
        /// CreateStaticPage_V3的copy,因页面上调用的是该方法,新方法改成了CreateStaticPage_V3,这样页面不用作改动
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="UpdateMsg"></param>
        /// <returns></returns>
        public bool CreateStaticPageMerchant(string InfoID, ref string UpdateMsg)
        {

            #region 变量定义

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //系统路径,静态页面的根目录
            string TempPagePath = ConfigurationManager.AppSettings["Temp_Info_V3"].ToString(); //招商模板的存放位置
            //string TempProjectPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //招商模板生成存放位置
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //目标路径图片域名
            string TempName = "Template/Temp_Info_V3/Temp_Merchant_V3.htm";  //获取模板名称

            string OutPutFilePath = "";     //输出文件的路径
            StreamWriter swOutPut;          //
            long HaveDoneCount = 0;         //是否处理成功
            string TmpTmpSource = "";       //
            byte AuditingStatus;            //审核状态
            string loginName = "";          //该信息的发布用户
            string CooperationDemandType = "";//融资方式
            string HtmlFile = "";           //静态页的生成路径与文件名

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            MerchantSetModel TheMerchant = new MerchantSetModel();
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheMerchant.MainInfoModel.LoginName);
            CooperationDemandType = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheMerchant.MainInfoModel.HtmlFile;

            #endregion


            #region 读取模板内容

            StreamReader srSource;
            string TmpFileName;
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

            if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            loginName = TheMerchant.MainInfoModel.LoginName.Trim();

            //Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            //string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            string MemberGradeID = "";      //是否拓富通会员
            AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
            if (AuditingStatus > 1)
            {
                sbUpdateMsg.Append("[E]审核未通过的信息不允许生成静态文件!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            if (AuditingStatus != 1 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() != "1002")
            {
                sbUpdateMsg.Append("[E]信息未审核且不是拓富通会员信息，不允许生成静态文件!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            #endregion


            #region 替换模版中信息

            TmpTmpSource = TmpSource;

            //共有信息
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheMerchant.MainInfoModel.Title.ToString().Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheMerchant.MainInfoModel.HtmlFile.ToString().Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", TheMerchant.MainInfoModel.Descript.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTypeName#", TheMerchant.MerchantInfoModel.MerchantTypeName.ToString());
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-WhetherCharges#", WhetherCharges.ToString()); 

            if (dt_login != null && dt_login.Rows.Count > 0 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
            {
                MemberGradeID = "<img src=\"/CommonV3/img/res3_icon1.gif\">";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());

            List<InfoResourceModel> attachments = attachmentbll.GetModelList(TheMerchant.MainInfoModel.InfoID);
            if (attachments != null)
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", attachments.Count.ToString());
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", "0");
            }

            string CooperationDemandType1 = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString();
            CooperationDemandType1 = CooperationDemandType1.Replace("3", "土地出让/租赁");
            CooperationDemandType1 = CooperationDemandType1.Replace("4", "项目整体转让");
            CooperationDemandType1 = CooperationDemandType1.Replace("5", "BOT/BT");
            CooperationDemandType1 = CooperationDemandType1.Replace("6", "风投");
            CooperationDemandType1 = CooperationDemandType1.Replace("7", "融资");
            CooperationDemandType1 = CooperationDemandType1.Replace("8", "其它合作");
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationDemandType1.Trim());

            string IndustryName = "";       //所属于行业
            foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
            {
                IndustryName = IndustryName + sTempIndustry.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName.ToString());

            string AreaName = "";           //投资区域
            if (TheMerchant.MerchantInfoModel != null)
            {
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountryName))
                {
                    AreaName = TheMerchant.MerchantInfoModel.CountryName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.ProvinceName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.ProvinceName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CityName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.CityName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountyName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.CountyName.Trim();
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName.ToString());

            string CapitalTotal = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//项目总投资

            string CurrencyName = TheMerchant.MerchantInfoModel.MerchantCurrency.Trim().ToLower();
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
            };
            string MerchantToltalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim();
            if (MerchantToltalName.Trim() == "不限")
                CurrencyName = "";
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTotal#", MerchantToltalName.ToString());

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", TheMerchant.MainInfoModel.MainPointCount.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", TheMerchant.MainInfoModel.ValidateTerm.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZoneAboutBrief#", TheMerchant.MerchantInfoModel.ZoneAboutBrief.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZoneAbout#", TheMerchant.MerchantInfoModel.ZoneAbout.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-EconomicIndicators#", TheMerchant.MerchantInfoModel.EconomicIndicators.ToString());

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InvestmentEnvironment#", TheMerchant.MerchantInfoModel.InvestmentEnvironment.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheMerchant.MainInfoModel.publishT.ToShortDateString());
            string userDomain = GetSelfDomain(TheMerchant.MainInfoModel.LoginName.Trim());  //展厅 用户域名
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

            string IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                "该资源未经过中国招商投资网核实认证<br />我们<span class='f_org strong'>不保证资源的真实性</span>！";  //不是认证资源
            if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "该资源已经过中国招商投资网核实认证<br />我们<span class='f_org strong'>保证资源的真实性</span>！";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheMerchant));  //该资源信息完整度(百分比)
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(TheMerchant.MainInfoModel.InfoID.ToString()).ToString());  //购买者评级


            #endregion

            #region 为此信息建立联系方式的cache [取消]

            //string cacheName = "Cache_Info_" + InfoID;
            //if (HttpContext.Current.Cache[cacheName] == null)
            //{
            //    string cacheContent = "";

            //    #region 获取该信息的联系方式内容

            //    StringBuilder sbContact = new StringBuilder();

            //    sbContact.Append(TheMerchant.MerchantInfoModel.ProjectStatus);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.marketAbout);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.Benifit);
            //    sbContact.Append("|");

            //    string fujianStr = "";              //7,附件列表
            //    string tempStr = "<li><a href=\"#ResURL\"><div class=\"pic\"><img src=\"/CommonV3/img/res_ad2.gif\" alt=\"#ResType\"></div>#ResTitle</a></li>";
            //    for (int i = 0; i < attachments.Count; i++)
            //    {
            //        string temp = tempStr;
            //        string restype = "image";
            //        string fileName = attachments[i].ResourceAddr.Trim();
            //        if (fileName != "")
            //        {
            //            fileName = "http://images.topfo.com/" + attachments[i].ResourceAddr;
            //        }
            //        else
            //        {
            //            fileName = "#";
            //        }
            //        if (fileName.IndexOf(".doc") > 0 || fileName.IndexOf(".ppt") > 0 || fileName.IndexOf(".pdf") > 0)
            //        {
            //            restype = "file";
            //        }
            //        temp = temp.Replace("#ResType", restype == "image" ? "点击查看图片" : "点击下载文件");
            //        temp = temp.Replace("#ResURL", fileName.Trim());
            //        //temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
            //        temp = temp.Replace("#ResTitle", attachments[i].ResourceTitle);
            //        fujianStr += temp;
            //    }
            //    if (fujianStr.Trim() == "")
            //    {
            //        fujianStr = "<li>无相关附件</li>";
            //    }

            //    sbContact.Append(fujianStr.Trim());
            //    sbContact.Append("|");

            //    sbContact.Append("项目建设单位：&nbsp;" + TheMerchant.InfoContactModel.OrganizationName.Trim() + "<br />");
            //    sbContact.Append("联系人：&nbsp;" + TheMerchant.InfoContactModel.Name.Trim() + "<br />");
            //    sbContact.Append("职位：&nbsp;" + TheMerchant.InfoContactModel.Career.Trim() + "<br />");
            //    sbContact.Append("固定电话：&nbsp;" + TheMerchant.InfoContactModel.TelStateCode + "-" + TheMerchant.InfoContactModel.TelNum.Trim() + "<br />");
            //    sbContact.Append("手机：&nbsp;" + TheMerchant.InfoContactModel.Mobile.Trim() + "<br />");
            //    sbContact.Append("电子邮箱：&nbsp;" + TheMerchant.InfoContactModel.Email + "<br />");
            //    sbContact.Append("项目单位详细地址：&nbsp;" + TheMerchant.InfoContactModel.Address + "<br />");
            //    sbContact.Append("项目单位网址：&nbsp;" + TheMerchant.InfoContactModel.WebSite);

            //    cacheContent = sbContact.ToString();

            //    #endregion

            //    HttpContext.Current.Cache[cacheName] = cacheContent;
            //}

            #endregion

            #region 输出文件

            OutPutFilePath = ApplicationRootPath + HtmlFile;

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
            UpdateMsg = sbUpdateMsg.ToString();
            return true;

            #endregion

        }
        #endregion


        #region 通过InfoID获取一个信息实体
        /// <summary>
        /// 通过InfoID获取一个Merchant的信息实体
        /// </summary>
        /// <returns></returns>
        public MerchantSetModel objGetMerchantInfoByInfoID(long InfoID)
        {

            MerchantSetModel TheMerchantInfo = new MerchantSetModel();
            TheMerchantInfo = dal.GetIntegrityModel(InfoID);
            return TheMerchantInfo;
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
            return lbll.GetManageTypeID(loginName);
        }

        #endregion


        #region 新模板静态页面
        public bool CreateStaticPageMerchant_New(string InfoID, ref string UpdateMsg)
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
            string TempProjectPath = ConfigurationManager.AppSettings["MerchantTmpPath"].ToString(); //招商模板的存放位置
            //目标路径
            string TempProjectPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //招商模板生成存放位置
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //图片域名

            string CooperationDemandType = "";//融资方式
            bool IsCheck = false;//是否认证资源
            string HtmlFile = "";

            MerchantSetModel TheMerchant = new MerchantSetModel();

            TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString().Trim();

            HtmlFile = TheMerchant.MainInfoModel.HtmlFile;
            #endregion


            #region 获取模板名称
            string TempName = "";
            string UserGradeTypeID = "";
            Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
            UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(TheMerchant.MainInfoModel.LoginName.Trim()).Trim();

            if (UserGradeTypeID.Trim() == "1002")
            {
                if (CooperationDemandType.Trim() == "9")
                {
                    TempName = Merchant_ZQ_Vip;
                }
                else
                {
                    TempName = Merchant_GQ_Vip;
                }
            }
            else
            {
                //普通用户模板
                if (CooperationDemandType.Trim() == "9")//债券融资
                {
                    TempName = Merchant_ZQ;
                }
                else
                {
                    TempName = Merchant_GQ;
                }
            }


            #endregion

            #region 认证标志
            if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
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

            if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheMerchant.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
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
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheMerchant.MainInfoModel.Title.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheMerchant.MainInfoModel.publishT.ToShortDateString());
            //用户身份
             string webself="";
            if (TempName == Merchant_GQ || TempName == Merchant_ZQ)
            {
                string ManageTypeName = ""; //身份类型
                string ManageTypeID = this.GetManageType(TheMerchant.MainInfoModel.LoginName.Trim()).Trim();
                string strTopfo = "普通";
                string memberType = "政府会员";
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
                    string u = "http://" + userDomain + ".gov.topfo.com";
                    webUrl = "<a target='_blank' href='" + u + "')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";
                    webself = "( <a class='blue' href='" + u + "' target='_blank'>进入该招商机构的网上展厅</a> )";
                    
                }
                //else
                //{
                //    webUrl = "<a href='javascript:alert('尚未创建展厅...')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";
                //}
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SelfWeb#", webUrl);
                ManageTypeName = strTopfo + memberType;
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);

            }
            TmpTmpSource = TmpTmpSource.Replace(" #@TmpFeild-WebSelf#", webself);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GradeID#", UserGradeTypeID.Trim());
            //所属于行业
            string IndustryName = "";
            foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
            //投资区域
            string AreaName = "";
            if (TheMerchant.MerchantInfoModel != null)
            {
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountryName))
                {
                    AreaName = TheMerchant.MerchantInfoModel.CountryName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.ProvinceName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.ProvinceName;
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CityName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.CityName;
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountyName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.CountyName;
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);
            //有效期至
            string endDate = "";
            endDate = TheMerchant.MainInfoModel.ValidateStartTime.AddMonths(TheMerchant.MainInfoModel.ValidateTerm).ToShortDateString();
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValiDate#", endDate);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", TheMerchant.MerchantInfoModel.ZoneAbout);
            string capitalName = "不限";
            if (TheMerchant.MerchantInfoModel.MerchantTotal.Trim() != "0")
            {
                capitalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim() + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);//借款

            string CapitalTotal = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//项目总投资
            string marketAbout = "暂未提供";
            if (TheMerchant.MerchantInfoModel.marketAbout.Trim() != "")
            {
                marketAbout = TheMerchant.MerchantInfoModel.marketAbout.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MarketAbout#", marketAbout);//市场介绍
            Tz888.BLL.Conn dal = new Conn();
            string financingID = "0";
            string financingName = "暂未提供";
            if (TheMerchant.MerchantInfoModel.financingID.ToString() != "")
            {
                financingID = TheMerchant.MerchantInfoModel.financingID.ToString();
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
            

            #region 债券融资属性
            //if (CooperationDemandType.Trim().IndexOf("10")==-1)
            //{
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheMerchant.MerchantInfoModel.warrant.ToString());
            string CompanyYearIncome = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CompanyYearIncome != 0 && TheMerchant.MerchantInfoModel.CompanyYearIncome.ToString() != "")
            {
                CompanyYearIncome = TheMerchant.MerchantInfoModel.CompanyYearIncome.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyYearIncome#", CompanyYearIncome);
            string CompanyNG = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CompanyNG != 0 && TheMerchant.MerchantInfoModel.CompanyNG.ToString() != "")
            {
                CompanyNG = TheMerchant.MerchantInfoModel.CompanyNG.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyNG#", CompanyNG);
            string CompanyTotalCapital = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CompanyTotalCapital != 0 && TheMerchant.MerchantInfoModel.CompanyTotalCapital.ToString() != "")
            {
                CompanyTotalCapital = TheMerchant.MerchantInfoModel.CompanyTotalCapital.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalCapital#", CompanyTotalCapital);
            string CompanyTotalDebet = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CompanyTotalDebet != 0 && TheMerchant.MerchantInfoModel.CompanyTotalDebet.ToString() != "")
            {
                CompanyTotalDebet = TheMerchant.MerchantInfoModel.CompanyTotalDebet.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalDebet#", CompanyTotalDebet);
            //}
            #endregion

            #region 股权融资属性
            //else//CooperationDemandType.Trim().Contains("10")
            //{
            string ReturnMode = TheMerchant.MerchantInfoModel.ReturnModeID;
            string ReturnModeName = "";
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
            if (ReturnModeName == "")
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnModel#", "暂未提供");//退出方式
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnModel#", ReturnModeName);//退出方式
            }
            string SellStockShare = "暂未提供";
            if (TheMerchant.MerchantInfoModel.SellStockShare != 0 || TheMerchant.MerchantInfoModel.SellStockShare.ToString() == "")
            {
                SellStockShare = TheMerchant.MerchantInfoModel.SellStockShare.ToString() + "%";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", SellStockShare);//出让股份
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectAbout#", TheMerchant.MerchantInfoModel.ProjectAbout == "" ? "暂未提供" : TheMerchant.MerchantInfoModel.ProjectAbout);//产品介绍
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-competitioAbout#", TheMerchant.MerchantInfoModel.competitioAbout == "" ? "暂未提供" : TheMerchant.MerchantInfoModel.competitioAbout);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BussinessModeAbout#", TheMerchant.MerchantInfoModel.BussinessModeAbout == "" ? "暂未提供" : TheMerchant.MerchantInfoModel.BussinessModeAbout);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTeamAbout#", TheMerchant.MerchantInfoModel.ManageTeamAbout == "" ? "暂未提供" : TheMerchant.MerchantInfoModel.ManageTeamAbout);
            //}
            #endregion

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheMerchant.MainInfoModel.HtmlFile.Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PID#", TheMerchant.MerchantInfoModel.ProvinceID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CID#", TheMerchant.MerchantInfoModel.CityID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-XID#", TheMerchant.MerchantInfoModel.CountyID.Trim());
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


        #region 模板V3版生成静态页面
        public bool CreateStaticPage_V3(string InfoID, ref string UpdateMsg)
        {

            #region 变量定义

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //系统路径,静态页面的根目录
            string TempPagePath = ConfigurationManager.AppSettings["Temp_Info_V3"].ToString(); //招商模板的存放位置
            //string TempProjectPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //招商模板生成存放位置
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //目标路径图片域名
            string TempName = "Template/Temp_Info_V3/Temp_Merchant_V3.htm";  //获取模板名称

            string OutPutFilePath = "";     //输出文件的路径
            StreamWriter swOutPut;          //
            long HaveDoneCount = 0;         //是否处理成功
            string TmpTmpSource = "";       //
            byte AuditingStatus;            //审核状态
            string loginName = "";          //该信息的发布用户
            string CooperationDemandType = "";//融资方式
            string HtmlFile = "";           //静态页的生成路径与文件名

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            MerchantSetModel TheMerchant = new MerchantSetModel();
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheMerchant.MainInfoModel.LoginName);
            CooperationDemandType = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheMerchant.MainInfoModel.HtmlFile;

            #endregion


            #region 读取模板内容

            StreamReader srSource;
            string TmpFileName;
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

            if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]没有找到该信息" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            loginName = TheMerchant.MainInfoModel.LoginName.Trim();

            //Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            //string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            string MemberGradeID = "";      //是否拓富通会员
            AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
            if (AuditingStatus > 1)
            {
                sbUpdateMsg.Append("[E]审核未通过的信息不允许生成静态文件!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            if (AuditingStatus != 1 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() != "1002")
            {
                sbUpdateMsg.Append("[E]信息未审核且不是拓富通会员信息，不允许生成静态文件!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            #endregion


            #region 替换模版中信息

            TmpTmpSource = TmpSource;

            //共有信息
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheMerchant.MainInfoModel.Title.ToString().Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheMerchant.MainInfoModel.HtmlFile.ToString().Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", TheMerchant.MainInfoModel.Descript.ToString()); 
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTypeName#", TheMerchant.MerchantInfoModel.MerchantTypeName.ToString());
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-WhetherCharges#", WhetherCharges.ToString()); 

            if (dt_login != null && dt_login.Rows.Count > 0 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
            {
                MemberGradeID = "<img src=\"/CommonV3/img/res3_icon1.gif\">";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());

            List<InfoResourceModel> attachments = attachmentbll.GetModelList(TheMerchant.MainInfoModel.InfoID);
            if (attachments != null)
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", attachments.Count.ToString());
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AttachmentCount#", "0");
            }

            string CooperationDemandType1= TheMerchant.MerchantInfoModel.CooperationDemandType.ToString();
            CooperationDemandType1 = CooperationDemandType1.Replace("3", "土地出让/租赁");
            CooperationDemandType1 = CooperationDemandType1.Replace("4", "项目整体转让");
            CooperationDemandType1 = CooperationDemandType1.Replace("5", "BOT/BT");
            CooperationDemandType1 = CooperationDemandType1.Replace("6", "风投");
            CooperationDemandType1 = CooperationDemandType1.Replace("7", "融资");
            CooperationDemandType1 = CooperationDemandType1.Replace("8", "其它合作");
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationDemandType1.Trim());

            string IndustryName = "";       //所属于行业
            foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
            {
                IndustryName = IndustryName + sTempIndustry.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName.ToString());

            string AreaName = "";           //投资区域
            if (TheMerchant.MerchantInfoModel != null)
            {
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountryName))
                {
                    AreaName = TheMerchant.MerchantInfoModel.CountryName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.ProvinceName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.ProvinceName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CityName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.CityName.Trim();
                }
                if (!string.IsNullOrEmpty(TheMerchant.MerchantInfoModel.CountyName))
                {
                    AreaName += " " + TheMerchant.MerchantInfoModel.CountyName.Trim();
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName.ToString());

            string CapitalTotal = "暂未提供";
            if (TheMerchant.MerchantInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString("0.00") + "万元人民币";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//项目总投资

            string CurrencyName = TheMerchant.MerchantInfoModel.MerchantCurrency.Trim().ToLower();
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
            };
            string MerchantToltalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim();
            if (MerchantToltalName.Trim() == "不限")
                CurrencyName = "";
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantTotal#", MerchantToltalName.ToString());

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", TheMerchant.MainInfoModel.MainPointCount.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", TheMerchant.MainInfoModel.ValidateTerm.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZoneAboutBrief#", TheMerchant.MerchantInfoModel.ZoneAboutBrief.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZoneAbout#", TheMerchant.MerchantInfoModel.ZoneAbout.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-EconomicIndicators#", TheMerchant.MerchantInfoModel.EconomicIndicators.ToString());

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InvestmentEnvironment#", TheMerchant.MerchantInfoModel.InvestmentEnvironment.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheMerchant.MainInfoModel.publishT.ToShortDateString());
            string userDomain = GetSelfDomain(TheMerchant.MainInfoModel.LoginName.Trim());  //展厅 用户域名
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

            string IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" + 
                "该资源未经过中国招商投资网核实认证<br />我们<span class='f_org strong'>不保证资源的真实性</span>！";  //不是认证资源
            if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0) 
                || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "该资源已经过中国招商投资网核实认证<br />我们<span class='f_org strong'>保证资源的真实性</span>！";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheMerchant));  //该资源信息完整度(百分比)
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(TheMerchant.MainInfoModel.InfoID.ToString()).ToString());  //购买者评级


            #endregion

            #region 为此信息建立联系方式的cache [取消]

            //string cacheName = "Cache_Info_" + InfoID;
            //if (HttpContext.Current.Cache[cacheName] == null)
            //{
            //    string cacheContent = "";
                
            //    #region 获取该信息的联系方式内容

            //    StringBuilder sbContact = new StringBuilder();

            //    sbContact.Append(TheMerchant.MerchantInfoModel.ProjectStatus);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.marketAbout);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.Benifit);
            //    sbContact.Append("|");

            //    string fujianStr = "";              //7,附件列表
            //    string tempStr = "<li><a href=\"#ResURL\"><div class=\"pic\"><img src=\"/CommonV3/img/res_ad2.gif\" alt=\"#ResType\"></div>#ResTitle</a></li>";
            //    for (int i = 0; i < attachments.Count; i++)
            //    {
            //        string temp = tempStr;
            //        string restype = "image";
            //        string fileName = attachments[i].ResourceAddr.Trim();
            //        if (fileName != "")
            //        {
            //            fileName = "http://images.topfo.com/" + attachments[i].ResourceAddr;
            //        }
            //        else
            //        {
            //            fileName = "#";
            //        }
            //        if (fileName.IndexOf(".doc") > 0 || fileName.IndexOf(".ppt") > 0 || fileName.IndexOf(".pdf") > 0)
            //        {
            //            restype = "file";
            //        }
            //        temp = temp.Replace("#ResType", restype == "image" ? "点击查看图片" : "点击下载文件");
            //        temp = temp.Replace("#ResURL", fileName.Trim());
            //        //temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
            //        temp = temp.Replace("#ResTitle", attachments[i].ResourceTitle);
            //        fujianStr += temp;
            //    }
            //    if (fujianStr.Trim() == "")
            //    {
            //        fujianStr = "<li>无相关附件</li>";
            //    }

            //    sbContact.Append(fujianStr.Trim());
            //    sbContact.Append("|");

            //    sbContact.Append("项目建设单位：&nbsp;" + TheMerchant.InfoContactModel.OrganizationName.Trim() + "<br />");
            //    sbContact.Append("联系人：&nbsp;" + TheMerchant.InfoContactModel.Name.Trim() + "<br />");
            //    sbContact.Append("职位：&nbsp;" + TheMerchant.InfoContactModel.Career.Trim() + "<br />");
            //    sbContact.Append("固定电话：&nbsp;" + TheMerchant.InfoContactModel.TelStateCode + "-" + TheMerchant.InfoContactModel.TelNum.Trim() + "<br />");
            //    sbContact.Append("手机：&nbsp;" + TheMerchant.InfoContactModel.Mobile.Trim() + "<br />");
            //    sbContact.Append("电子邮箱：&nbsp;" + TheMerchant.InfoContactModel.Email + "<br />");
            //    sbContact.Append("项目单位详细地址：&nbsp;" + TheMerchant.InfoContactModel.Address + "<br />");
            //    sbContact.Append("项目单位网址：&nbsp;" + TheMerchant.InfoContactModel.WebSite);

            //    cacheContent = sbContact.ToString();

            //    #endregion
                
            //    HttpContext.Current.Cache[cacheName] = cacheContent;
            //}

            #endregion

            #region 输出文件

            OutPutFilePath = ApplicationRootPath + HtmlFile;

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
            UpdateMsg = sbUpdateMsg.ToString();
            return true;

            #endregion

        }

        #endregion


        #region 该资源信息完整度(百分比)

        public string getCompleteDegreeById(MerchantSetModel model)
        {
            int degree = 50;

            if (model.MerchantInfoModel.ProjectStatus != null && model.MerchantInfoModel.ProjectStatus.Trim() == "")//项目现状及规划
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.EconomicIndicators != null && model.MerchantInfoModel.EconomicIndicators.Trim() == "")//经济效益分析
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.marketAbout != null && model.MerchantInfoModel.marketAbout.Trim() == "")//项目优势及市场分析
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.InvestmentEnvironment != null && model.MerchantInfoModel.InvestmentEnvironment.Trim() == "")//地方经济指标描述
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.Benefit != null && model.MerchantInfoModel.Benefit.Trim() == "")//投资环境描述
            {
                degree += 5;
            }
            if (model.InfoResourceModels != null && model.InfoResourceModels.Count > 0)//附件资料
            {
                degree += 10;
            }
            if (model.InfoContactModel.OrganizationName != null && model.InfoContactModel.OrganizationName.Trim() == "")//招商机构名称
            {
                degree += 7;
            }
            if (model.InfoContactModel.TelNum != null && model.InfoContactModel.Mobile != null && model.InfoContactModel.TelNum.Trim() == "" || model.InfoContactModel.Mobile.Trim() == "")//招商机构名称
            {
                degree += 2;
            }
            if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.Trim() == "")//招商机构名称
            {
                degree += 2;
            }
            if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.Trim() == "")//招商机构名称
            {
                degree += 2;
            }
            if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.Trim() == "")//招商机构名称
            {
                degree += 2;
            }

            return degree.ToString() + "%";
        }

        #endregion
        


    }
}
