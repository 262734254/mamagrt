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

        #region ��Ա����

        private const string MerchantTempChangeFileName = "TempMerchantChange.htm"; //MerchantChangeģ��·��
        private const string MerchantTempFeeFileName = "TempMerchantFee.htm";       //MerchantFeeģ��·��
        private const string MerchantTempVipFileName = "TempMerchantVip.htm";       //MerchantVip����·��
        private const string MerchantTempEndFileTo = "";                        //�����ļ������·��
        private const string MerchantPicPath = "http://images.topfo.com/";      //ͼƬ·��
        private const string MerchantResourcePath = "";                         //��Դ·��
        private const string TagsUrl = "http://search.topfo.com/SearchResultMerchant.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultMerchant.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly IMarchantInfo dal = DataAccess.CreateInfo_MarchantInfo();
        private const string Merchant_ZQ = "Merchant_ZQ.htm";           //ծȯ����
        private const string Merchant_GQ = "Merchant_GQ.htm";           //��Ȩ����
        private const string Merchant_ZQ_Vip = "Merchant_ZQ_Vip.htm";
        private const string Merchant_GQ_Vip = "Merchant_GQ_Vip.htm";

        #endregion


        #region �����̬ҳ���ļ�
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        /// <param name="IsLog">�Ƿ���Ҫ����Ϣд����־</param>
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageMerchant_before20100820(string InfoID,ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                //ϵͳ·��
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
                //ģ��·��
                string TempMerchantPath = ConfigurationManager.AppSettings["MerchantTmpPath"].ToString(); //����ģ��Ĵ��λ��
                //Ŀ��·��
                string TempMerchantPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //����ģ��Ĵ��λ��

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

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
                string InfoPriceName; //������ʾ         

                string InfoOriginRoleName;

                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = "";

                string MerchantNameTotal;//��Ͷ�ʽ��

                string MerchantTypeName;//�������

                string CooperationTypeName;//Ͷ�ʷ�ʽ:�ʽ���,��ȨͶ��,���س���/����....
                List<string> lstCooperationTypeName = new List<string>();

                string AreaName;//Ͷ������

                string IndustryName;//������ҵ 
                List<string> lstIndustryName = new List<string>();

                string PublishT;//��������
                string ValidatePeriod;//��Ч��
                string PublisLoginName;//������
                string TZYX;//Ͷ������,��Ŀ���
                string ContractPersonName = "";//��ϵ������
                string ContractCellPhone = "";//��ϵ���ֻ�
                string ContractPersonCompanyName = "";//��ϵ�˹�˾����
                string ContractPersonPhone = "";//��ϵ�˵绰
                string ContractPersonFax = "";//��ϵ�˴���
                string ContractPersonAddress = "";//��ϵ�˵�ַ
                string ContractPersonPostCode = "";//��ϵ���ʱ�
                string ContractPersonWebsite = "";//��ϵ�˹�˾��վ

                string ResourcePrice;//��Դ�۸�
                string ResourceValue;//��Դ�۸�
                string ResourceValueVip;//��Դ�ظ�ͨ��Ա��

                string CapitalTotal="";//��Ͷ��
                string MerchantToltal = "";//���ʶ�
                string CapitalCurrencyName; //��Ͷ�ʻ�������
                string CurrencyName; //��������

                string MerchantToltalName = "";//���ʶ�(Name)

                string ResourceInfo1 = "";//��Դ��ʾ��Ϣ1
                string ResourceInfo2 = "";//��Դ��ʾ��Ϣ2

                string ManageType = "";//��Ա����
                string UserDetail = "";//�û��Ĺ�˾��ϸ��Ϣ
                string ManageTypeName = ""; //�ظ�ͨ��Ա����

                string UserGradeTypeID = "";
                #endregion

                TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));

                #region ��ȡģ������
                string TempName = "";

                if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    //��֤��Դģ��
                    TempName = MerchantTempChangeFileName;
                }
                else
                {
                    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
                    UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(TheMerchant.MainInfoModel.LoginName.Trim());
                    if (UserGradeTypeID == "1001")
                    {
                        //��ͨ�û�ģ��
                        TempName = MerchantTempFeeFileName;
                    }
                    else
                    {
                        //VIP��Աģ��
                        TempName = MerchantTempVipFileName;
                    }
                }

                #endregion

                #region ��ȡģ������

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
                if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = TheMerchant.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
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
                MerchantTypeName = TheMerchant.MerchantInfoModel.MerchantTypeName.Trim();

                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString().Trim();
                CapitalCurrencyName = TheMerchant.MerchantInfoModel.CapitalCurrency.Trim().ToLower();
                switch (CapitalCurrencyName)
                {
                    case "cny":
                        CapitalCurrencyName = "�����";
                        break;
                    case "hkd":
                        CapitalCurrencyName = "�۱�";
                        break;
                    case "usd":
                        CapitalCurrencyName = "��Ԫ";
                        break;
                    default:
                        CapitalCurrencyName = "�����";
                        break;
                }

                MerchantToltal = TheMerchant.MerchantInfoModel.MerchantTotal.ToString().Trim();
                CurrencyName = TheMerchant.MerchantInfoModel.MerchantCurrency.Trim().ToLower();
                switch (CurrencyName)
                {
                    case "cny":
                        CurrencyName = "�����";
                        break;
                    case "hkd":
                        CurrencyName = "�۱�";
                        break;
                    case "usd":
                        CurrencyName = "��Ԫ";
                        break;
                    default:
                        CurrencyName = "�����";
                        break;
                };

                MerchantToltalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim();

                if (MerchantToltalName.Trim() == "����")
                    CurrencyName = "";

                //������ʽ
                CooperationTypeName = "";
                foreach (string sCoopTypeName in TheMerchant.MerchantInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }

                //Ͷ������
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
                


                //��������ҵ
                IndustryName = "";
                foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
                {
                    IndustryName = IndustryName + sTempIndustry.Trim();
                }

                //��ʼʱ��
                PublishT = TheMerchant.MainInfoModel.ValidateStartTime.ToShortDateString().Trim();
                //����ʱ��
                ValidatePeriod = TheMerchant.MainInfoModel.ValidateTerm.ToString().Trim();

                PublisLoginName = TheMerchant.MainInfoModel.LoginName.ToString().Trim();


                if (TheMerchant.MerchantInfoModel.ZoneAboutBrief.Trim() != "")
                    TZYX = TheMerchant.MerchantInfoModel.ZoneAboutBrief.Trim();
                else
                    TZYX = TheMerchant.MerchantInfoModel.ZoneAbout.Trim();

                loginName = TheMerchant.MainInfoModel.LoginName.Trim();

                //��ϵ�˸���
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
                    
                    //��ϵ�˹�����Ϣ

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

                //��Դ�۸�
                if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0))
                {
                    ResourceInfo1 = "Ϊ��߶Խ�����������Դ���û�����Ϊ������Դ";
                    ResourceInfo2 = "����";
                    ResourceValue = Convert.ToDecimal(TheMerchant.MainInfoModel.MainPointCount.ToString().Trim()).ToString("c");
                    Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
                    Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
                    objDic = diBll.GetModel("1");
                    ResourceValueVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * TheMerchant.MainInfoModel.MainPointCount)).ToString("c");
                    //ResourceValueVip = "0.00";

                    ResourcePrice = "<tr>" +
                                        "<td class=\"h\">" +
                                            "��Դ�۸�</td>" +
                                        "<td>" +
                                        "<span class=\"orange01\"><strong>" + ResourceValue + "</strong>" +
                                        "</span>Ԫ���ظ�ͨ��Ա�ۣ�<span class=\"orange01\"><strong>" + ResourceValueVip + "</strong></span>Ԫ��</td>" +
                                     "</tr>";
                }
                else
                {
                    ResourceInfo1 = "����ԴΪ�����Դ";
                    ResourceInfo2 = "�ղ�";
                    ResourcePrice = "";
                }


                ArrayList arrListPic = new ArrayList();
                ArrayList arrListDoc = new ArrayList();
                if (TheMerchant.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in TheMerchant.InfoResourceModels)
                    {
                        //ResourceType 0:�����ĵ� 1��ͼƬ 2����Ƶ
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
                    Doc1_r = "<li>" + Doc1_c + "��<a href='" + Doc1 + "'>�鿴</a><a href='" + MerchantResourcePath + Doc1 + "'>����</a></li>";
                }

                if (arrListDoc.Count > 1)
                {
                    string[] sDocTemp = (string[])arrListDoc[1];
                    Doc2 = sDocTemp[0];
                    Doc2_c = sDocTemp[1];
                    Doc2_r = "<li>" + Doc2_c + "��<a href='" + Doc2 + "'>�鿴</a><a href='" + MerchantResourcePath + Doc2 + "'>����</a></li>";
                }
                if (arrListDoc.Count > 2)
                {
                    string[] sDocTemp = (string[])arrListDoc[2];
                    Doc3 = sDocTemp[0];
                    Doc3_c = sDocTemp[1];
                    Doc3_r = "<li>" + Doc3_c + "��<a href='" + Doc3 + "'>�鿴</a><a href='" + MerchantResourcePath + Doc3 + "'>����</a></li>";
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
                    KeyWord = string.Format(TagslinkModel, "����", "����");

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = TheMerchant.MainInfoModel.HtmlFile;
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (TheMerchant.MainInfoModel.DisplayTitle == "")
                {
                    TheMerchant.MainInfoModel.DisplayTitle = Title;
                }
                DisplayTitle = TheMerchant.MainInfoModel.DisplayTitle + "��" + "�й�����Ͷ����";
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
                        ManageTypeName = "�ظ�ͨ��ҵ��Ա";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                        "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                            "<img src=\"/Web13/images/project/button_jlzd.gif\" /></a>" +
                        "<p class=\"rtb\">" +
                            "<a href=\"{2}\" target=\"{3}\">��˾����</a> | <a href=\"{4}\" target=\"{5}\">�ظ�ͨ����</a><br />" +
                            "��ҵ�����֤��<a href=\"http://www.topfo.com/topfocenter/degreeaffirm/index.shtml\" target=\"_blank\"><u>�˽���֤����</u></a><br />" +
                            "Ӫҵִ�գ�<u>�Ѿ�����֤</u></p>";
                    }
                    else
                    {
                        ManageTypeName = "��ͨ��ҵ��Ա";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                        "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                            "<img src=\"/Web13/images/project/button_jlzd.gif\" /></a>";
                    }

                    DataSet ds = this.GetEnterpriseInfo(loginName);

                    if (ds == null || ds.Tables[0].Rows.Count == 0 || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Domain"].ToString().Trim()))
                    {
                        WebUrl = "JavaScript:alert('����ҵ��δ����չ����');";
                        ComIntro = "JavaScript:alert('����ҵ��δ����չ����');";
                        TopfoDoc = "JavaScript:alert('����ҵ��δ����չ����');";
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
                        ManageTypeName = "�ظ�ͨ������Ա";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                            "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                                "<img src=\"/Web13/images/merchant/buttom_jlzsjg.gif\" /></a>" +
                            "<p class=\"rtb\">" +
                                "<a href=\"{2}\" target=\"{3}\">��������</a> | <a href=\"{4}\" target=\"{5}\">�ظ�ͨ����</a><br />" +
                                "���������֤�� <a href=\"http://www.topfo.com/help/TopfoServer.shtml#a2\" target=\"_blank\">" +
                                "<u>�˽���֤����</u></a><br /></p>";
                    }
                    else
                    {
                        ManageTypeName = "��ͨ������Ա";
                        UserDetailModel = "<div class=\"blank6\"></div>" +
                            "<a href=\"{0}\" class=\"spaces\" target=\"{1}\">" +
                                "<img src=\"/Web13/images/merchant/buttom_jlzsjg.gif\" /></a>";
                    }

                    DataSet ds = this.GetGovernmentInfo(loginName);

                    if (ds == null || ds.Tables[0].Rows.Count == 0 || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ExhibitionHall"].ToString().Trim()))
                    {
                        WebUrl = "JavaScript:alert('�����̻�����δ����չ����');";
                        ComIntro = "JavaScript:alert('�����̻�����δ����չ����');";
                        TopfoDoc = "JavaScript:alert('�����̻�����δ����չ����');";
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
                        ManageTypeName = "�ظ�ͨ���˻�Ա";
                    else
                        ManageTypeName = "��ͨ���˻�Ա";

                    UserDetail = "";
                }

                #endregion

                #region �滻ģ��

                #region Vip��ģ��
                if (TempName.Trim() == MerchantTempVipFileName)//Vipģ��
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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    if (CapitalTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "<tr><td class=\"h\">��Ͷ�ʣ�</td><td>" + CapitalTotal + "�� " + CapitalCurrencyName + "</td></tr>");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantToltal#", MerchantToltalName);//���ʽ��

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion

                #region �շѵ�ģ��
                if (TempName.Trim() == MerchantTempChangeFileName)//�շѵ�ģ��
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
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�շ���Դ");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourcePrice#", ResourcePrice);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo1#", ResourceInfo1);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo2#", ResourceInfo2);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    if (CapitalTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "<tr><td class=\"h\">��Ͷ�ʣ�</td><td>" + CapitalTotal + "�� " + CapitalCurrencyName + "</td></tr>");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantToltal#", MerchantToltalName);//���ʽ��

                }
                #endregion

                #region ��ѵ�ģ��
                if (TempName.Trim() == MerchantTempFeeFileName)//��ѵ�ģ��
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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyName#", ContractPersonCompanyName.Trim());
                    if (CapitalTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", "<tr><td class=\"h\">��Ͷ�ʣ�</td><td>" + CapitalTotal + "��" + CapitalCurrencyName + "</td></tr>");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MerchantToltal#", MerchantToltalName);//���ʽ��

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion


                #endregion

                #region ����ļ�
                OutPutFilePath = ApplicationRootPath + TempMerchantPathTo.Trim()+ HtmlFile;

                //���·���Ƿ���ȷ
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Merchant<br>");
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

        /// <summary>
        /// CreateStaticPage_V3��copy,��ҳ���ϵ��õ��Ǹ÷���,�·����ĳ���CreateStaticPage_V3,����ҳ�治�����Ķ�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="UpdateMsg"></param>
        /// <returns></returns>
        public bool CreateStaticPageMerchant(string InfoID, ref string UpdateMsg)
        {

            #region ��������

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //ϵͳ·��,��̬ҳ��ĸ�Ŀ¼
            string TempPagePath = ConfigurationManager.AppSettings["Temp_Info_V3"].ToString(); //����ģ��Ĵ��λ��
            //string TempProjectPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //����ģ�����ɴ��λ��
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //Ŀ��·��ͼƬ����
            string TempName = "Template/Temp_Info_V3/Temp_Merchant_V3.htm";  //��ȡģ������

            string OutPutFilePath = "";     //����ļ���·��
            StreamWriter swOutPut;          //
            long HaveDoneCount = 0;         //�Ƿ���ɹ�
            string TmpTmpSource = "";       //
            byte AuditingStatus;            //���״̬
            string loginName = "";          //����Ϣ�ķ����û�
            string CooperationDemandType = "";//���ʷ�ʽ
            string HtmlFile = "";           //��̬ҳ������·�����ļ���

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            MerchantSetModel TheMerchant = new MerchantSetModel();
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheMerchant.MainInfoModel.LoginName);
            CooperationDemandType = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheMerchant.MainInfoModel.HtmlFile;

            #endregion


            #region ��ȡģ������

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

            if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            loginName = TheMerchant.MainInfoModel.LoginName.Trim();

            //Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            //string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            string MemberGradeID = "";      //�Ƿ��ظ�ͨ��Ա
            AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
            if (AuditingStatus > 1)
            {
                sbUpdateMsg.Append("[E]���δͨ������Ϣ���������ɾ�̬�ļ�!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            if (AuditingStatus != 1 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() != "1002")
            {
                sbUpdateMsg.Append("[E]��Ϣδ����Ҳ����ظ�ͨ��Ա��Ϣ�����������ɾ�̬�ļ�!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            #endregion


            #region �滻ģ������Ϣ

            TmpTmpSource = TmpSource;

            //������Ϣ
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
            CooperationDemandType1 = CooperationDemandType1.Replace("3", "���س���/����");
            CooperationDemandType1 = CooperationDemandType1.Replace("4", "��Ŀ����ת��");
            CooperationDemandType1 = CooperationDemandType1.Replace("5", "BOT/BT");
            CooperationDemandType1 = CooperationDemandType1.Replace("6", "��Ͷ");
            CooperationDemandType1 = CooperationDemandType1.Replace("7", "����");
            CooperationDemandType1 = CooperationDemandType1.Replace("8", "��������");
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationDemandType1.Trim());

            string IndustryName = "";       //��������ҵ
            foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
            {
                IndustryName = IndustryName + sTempIndustry.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName.ToString());

            string AreaName = "";           //Ͷ������
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

            string CapitalTotal = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//��Ŀ��Ͷ��

            string CurrencyName = TheMerchant.MerchantInfoModel.MerchantCurrency.Trim().ToLower();
            switch (CurrencyName)
            {
                case "cny":
                    CurrencyName = "�����";
                    break;
                case "hkd":
                    CurrencyName = "�۱�";
                    break;
                case "usd":
                    CurrencyName = "��Ԫ";
                    break;
                default:
                    CurrencyName = "�����";
                    break;
            };
            string MerchantToltalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim();
            if (MerchantToltalName.Trim() == "����")
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
            string userDomain = GetSelfDomain(TheMerchant.MainInfoModel.LoginName.Trim());  //չ�� �û�����
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
                "����Դδ�����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>����֤��Դ����ʵ��</span>��";  //������֤��Դ
            if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "����Դ�Ѿ����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>��֤��Դ����ʵ��</span>��";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheMerchant));  //����Դ��Ϣ������(�ٷֱ�)
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(TheMerchant.MainInfoModel.InfoID.ToString()).ToString());  //����������


            #endregion

            #region Ϊ����Ϣ������ϵ��ʽ��cache [ȡ��]

            //string cacheName = "Cache_Info_" + InfoID;
            //if (HttpContext.Current.Cache[cacheName] == null)
            //{
            //    string cacheContent = "";

            //    #region ��ȡ����Ϣ����ϵ��ʽ����

            //    StringBuilder sbContact = new StringBuilder();

            //    sbContact.Append(TheMerchant.MerchantInfoModel.ProjectStatus);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.marketAbout);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.Benifit);
            //    sbContact.Append("|");

            //    string fujianStr = "";              //7,�����б�
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
            //        temp = temp.Replace("#ResType", restype == "image" ? "����鿴ͼƬ" : "��������ļ�");
            //        temp = temp.Replace("#ResURL", fileName.Trim());
            //        //temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
            //        temp = temp.Replace("#ResTitle", attachments[i].ResourceTitle);
            //        fujianStr += temp;
            //    }
            //    if (fujianStr.Trim() == "")
            //    {
            //        fujianStr = "<li>����ظ���</li>";
            //    }

            //    sbContact.Append(fujianStr.Trim());
            //    sbContact.Append("|");

            //    sbContact.Append("��Ŀ���赥λ��&nbsp;" + TheMerchant.InfoContactModel.OrganizationName.Trim() + "<br />");
            //    sbContact.Append("��ϵ�ˣ�&nbsp;" + TheMerchant.InfoContactModel.Name.Trim() + "<br />");
            //    sbContact.Append("ְλ��&nbsp;" + TheMerchant.InfoContactModel.Career.Trim() + "<br />");
            //    sbContact.Append("�̶��绰��&nbsp;" + TheMerchant.InfoContactModel.TelStateCode + "-" + TheMerchant.InfoContactModel.TelNum.Trim() + "<br />");
            //    sbContact.Append("�ֻ���&nbsp;" + TheMerchant.InfoContactModel.Mobile.Trim() + "<br />");
            //    sbContact.Append("�������䣺&nbsp;" + TheMerchant.InfoContactModel.Email + "<br />");
            //    sbContact.Append("��Ŀ��λ��ϸ��ַ��&nbsp;" + TheMerchant.InfoContactModel.Address + "<br />");
            //    sbContact.Append("��Ŀ��λ��ַ��&nbsp;" + TheMerchant.InfoContactModel.WebSite);

            //    cacheContent = sbContact.ToString();

            //    #endregion

            //    HttpContext.Current.Cache[cacheName] = cacheContent;
            //}

            #endregion

            #region ����ļ�

            OutPutFilePath = ApplicationRootPath + HtmlFile;

            //���·���Ƿ���ȷ
            if (!Common.BulidFolder(OutPutFilePath, true))
            {
                sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Project<br>");
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
            UpdateMsg = sbUpdateMsg.ToString();
            return true;

            #endregion

        }
        #endregion


        #region ͨ��InfoID��ȡһ����Ϣʵ��
        /// <summary>
        /// ͨ��InfoID��ȡһ��Merchant����Ϣʵ��
        /// </summary>
        /// <returns></returns>
        public MerchantSetModel objGetMerchantInfoByInfoID(long InfoID)
        {

            MerchantSetModel TheMerchantInfo = new MerchantSetModel();
            TheMerchantInfo = dal.GetIntegrityModel(InfoID);
            return TheMerchantInfo;
        }
        #endregion


        #region ��ȡ��Ա��չ������

        /// <summary>
        /// ��ȡ��ҵ��Ա��չ������
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
        /// ��ȡ���̻�Ա��չ������
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetGovernmentInfo(string loginName)
        {
            Tz888.BLL.Register.common combll = new Tz888.BLL.Register.common();
            return combll.GetGovernmentInfo(loginName);
        }
        #endregion


        #region ��ȡ��Ա����
        public string GetManageType(string loginName)
        {
            Tz888.BLL.Register.LoginInfoBLL lbll = new Tz888.BLL.Register.LoginInfoBLL();
            return lbll.GetManageTypeID(loginName);
        }

        #endregion


        #region ��ģ�徲̬ҳ��
        public bool CreateStaticPageMerchant_New(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            //try
            //{
            #region ��������
            string OutPutFilePath = "";
            StreamWriter swOutPut;
            long HaveDoneCount = 0;
            string TmpTmpSource = "";
            byte AuditingStatus;
            string loginName = "";
            //ϵͳ·��
            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
            //ģ��·��
            string TempProjectPath = ConfigurationManager.AppSettings["MerchantTmpPath"].ToString(); //����ģ��Ĵ��λ��
            //Ŀ��·��
            string TempProjectPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //����ģ�����ɴ��λ��
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

            string CooperationDemandType = "";//���ʷ�ʽ
            bool IsCheck = false;//�Ƿ���֤��Դ
            string HtmlFile = "";

            MerchantSetModel TheMerchant = new MerchantSetModel();

            TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString().Trim();

            HtmlFile = TheMerchant.MainInfoModel.HtmlFile;
            #endregion


            #region ��ȡģ������
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
                //��ͨ�û�ģ��
                if (CooperationDemandType.Trim() == "9")//ծȯ����
                {
                    TempName = Merchant_ZQ;
                }
                else
                {
                    TempName = Merchant_GQ;
                }
            }


            #endregion

            #region ��֤��־
            if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
            {
                //��֤��Դģ��
                IsCheck = true;
            }
            #endregion

            #region ��ȡģ������

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

            if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheMerchant.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
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

            #region �滻ģ��
            //������Ϣ
            TmpTmpSource = TmpSource;
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheMerchant.MainInfoModel.Title.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheMerchant.MainInfoModel.publishT.ToShortDateString());
            //�û����
             string webself="";
            if (TempName == Merchant_GQ || TempName == Merchant_ZQ)
            {
                string ManageTypeName = ""; //�������
                string ManageTypeID = this.GetManageType(TheMerchant.MainInfoModel.LoginName.Trim()).Trim();
                string strTopfo = "��ͨ";
                string memberType = "������Ա";
                if (UserGradeTypeID.Trim() == "1002")
                {
                    strTopfo = "�ظ�ͨ";
                }
                if (ManageTypeID == "2004")
                {
                    memberType = "�н��Ա";
                }
                //չ��
                string userDomain = GetSelfDomain(loginName);//�û�����
                string webUrl = "";
                if (userDomain != "")
                {
                    string u = "http://" + userDomain + ".gov.topfo.com";
                    webUrl = "<a target='_blank' href='" + u + "')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";
                    webself = "( <a class='blue' href='" + u + "' target='_blank'>��������̻���������չ��</a> )";
                    
                }
                //else
                //{
                //    webUrl = "<a href='javascript:alert('��δ����չ��...')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";
                //}
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SelfWeb#", webUrl);
                ManageTypeName = strTopfo + memberType;
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);

            }
            TmpTmpSource = TmpTmpSource.Replace(" #@TmpFeild-WebSelf#", webself);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GradeID#", UserGradeTypeID.Trim());
            //��������ҵ
            string IndustryName = "";
            foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
            //Ͷ������
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
            //��Ч����
            string endDate = "";
            endDate = TheMerchant.MainInfoModel.ValidateStartTime.AddMonths(TheMerchant.MainInfoModel.ValidateTerm).ToShortDateString();
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValiDate#", endDate);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", TheMerchant.MerchantInfoModel.ZoneAbout);
            string capitalName = "����";
            if (TheMerchant.MerchantInfoModel.MerchantTotal.Trim() != "0")
            {
                capitalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim() + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);//���

            string CapitalTotal = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//��Ŀ��Ͷ��
            string marketAbout = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.marketAbout.Trim() != "")
            {
                marketAbout = TheMerchant.MerchantInfoModel.marketAbout.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MarketAbout#", marketAbout);//�г�����
            Tz888.BLL.Conn dal = new Conn();
            string financingID = "0";
            string financingName = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.financingID.ToString() != "")
            {
                financingID = TheMerchant.MerchantInfoModel.financingID.ToString();
                DataTable dtF = dal.GetList("SETfinancingTargetTAB", "financingName", "financingID", 1, 1, 0, 1, "financingID='" + financingID + "'");
                if (dtF.Rows.Count > 0)
                {
                    financingName = dtF.Rows[0]["financingName"].ToString();
                }
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalObj#", financingName);//���ʶ���
            if (IsCheck)//��֤��־
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-isCheck#", "<img src='/images/tiem_09.jpg'>");
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-isCheck#", "");
            }
            

            #region ծȯ��������
            //if (CooperationDemandType.Trim().IndexOf("10")==-1)
            //{
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheMerchant.MerchantInfoModel.warrant.ToString());
            string CompanyYearIncome = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CompanyYearIncome != 0 && TheMerchant.MerchantInfoModel.CompanyYearIncome.ToString() != "")
            {
                CompanyYearIncome = TheMerchant.MerchantInfoModel.CompanyYearIncome.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyYearIncome#", CompanyYearIncome);
            string CompanyNG = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CompanyNG != 0 && TheMerchant.MerchantInfoModel.CompanyNG.ToString() != "")
            {
                CompanyNG = TheMerchant.MerchantInfoModel.CompanyNG.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyNG#", CompanyNG);
            string CompanyTotalCapital = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CompanyTotalCapital != 0 && TheMerchant.MerchantInfoModel.CompanyTotalCapital.ToString() != "")
            {
                CompanyTotalCapital = TheMerchant.MerchantInfoModel.CompanyTotalCapital.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalCapital#", CompanyTotalCapital);
            string CompanyTotalDebet = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CompanyTotalDebet != 0 && TheMerchant.MerchantInfoModel.CompanyTotalDebet.ToString() != "")
            {
                CompanyTotalDebet = TheMerchant.MerchantInfoModel.CompanyTotalDebet.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalDebet#", CompanyTotalDebet);
            //}
            #endregion

            #region ��Ȩ��������
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
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnModel#", "��δ�ṩ");//�˳���ʽ
            }
            else
            {
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnModel#", ReturnModeName);//�˳���ʽ
            }
            string SellStockShare = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.SellStockShare != 0 || TheMerchant.MerchantInfoModel.SellStockShare.ToString() == "")
            {
                SellStockShare = TheMerchant.MerchantInfoModel.SellStockShare.ToString() + "%";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", SellStockShare);//���ùɷ�
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectAbout#", TheMerchant.MerchantInfoModel.ProjectAbout == "" ? "��δ�ṩ" : TheMerchant.MerchantInfoModel.ProjectAbout);//��Ʒ����
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-competitioAbout#", TheMerchant.MerchantInfoModel.competitioAbout == "" ? "��δ�ṩ" : TheMerchant.MerchantInfoModel.competitioAbout);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BussinessModeAbout#", TheMerchant.MerchantInfoModel.BussinessModeAbout == "" ? "��δ�ṩ" : TheMerchant.MerchantInfoModel.BussinessModeAbout);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTeamAbout#", TheMerchant.MerchantInfoModel.ManageTeamAbout == "" ? "��δ�ṩ" : TheMerchant.MerchantInfoModel.ManageTeamAbout);
            //}
            #endregion

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheMerchant.MainInfoModel.HtmlFile.Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PID#", TheMerchant.MerchantInfoModel.ProvinceID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CID#", TheMerchant.MerchantInfoModel.CityID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-XID#", TheMerchant.MerchantInfoModel.CountyID.Trim());
            string CommentIframe = ConfigurationManager.AppSettings["MemberDomain"];
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Comment#", CommentIframe);//��������
            //��Ŀ����


            #region ����ļ�
            OutPutFilePath = ApplicationRootPath + TempProjectPathTo.Trim() + HtmlFile;

            //���·���Ƿ���ȷ
            if (!Common.BulidFolder(OutPutFilePath, true))
            {
                sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Project<br>");
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


        #region ģ��V3�����ɾ�̬ҳ��
        public bool CreateStaticPage_V3(string InfoID, ref string UpdateMsg)
        {

            #region ��������

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //ϵͳ·��,��̬ҳ��ĸ�Ŀ¼
            string TempPagePath = ConfigurationManager.AppSettings["Temp_Info_V3"].ToString(); //����ģ��Ĵ��λ��
            //string TempProjectPathTo = ConfigurationManager.AppSettings["MerchantTmpPathTo"].ToString(); //����ģ�����ɴ��λ��
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //Ŀ��·��ͼƬ����
            string TempName = "Template/Temp_Info_V3/Temp_Merchant_V3.htm";  //��ȡģ������

            string OutPutFilePath = "";     //����ļ���·��
            StreamWriter swOutPut;          //
            long HaveDoneCount = 0;         //�Ƿ���ɹ�
            string TmpTmpSource = "";       //
            byte AuditingStatus;            //���״̬
            string loginName = "";          //����Ϣ�ķ����û�
            string CooperationDemandType = "";//���ʷ�ʽ
            string HtmlFile = "";           //��̬ҳ������·�����ļ���

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            MerchantSetModel TheMerchant = new MerchantSetModel();
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            TheMerchant = this.objGetMerchantInfoByInfoID(long.Parse(InfoID.Trim()));
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheMerchant.MainInfoModel.LoginName);
            CooperationDemandType = TheMerchant.MerchantInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheMerchant.MainInfoModel.HtmlFile;

            #endregion


            #region ��ȡģ������

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

            if (TheMerchant.MerchantInfoModel == null || TheMerchant.MerchantInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            loginName = TheMerchant.MainInfoModel.LoginName.Trim();

            //Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            //string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            string MemberGradeID = "";      //�Ƿ��ظ�ͨ��Ա
            AuditingStatus = (byte)TheMerchant.MainInfoModel.AuditingStatus;
            if (AuditingStatus > 1)
            {
                sbUpdateMsg.Append("[E]���δͨ������Ϣ���������ɾ�̬�ļ�!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
            if (AuditingStatus != 1 && dt_login.Rows[0]["MemberGradeID"].ToString().Trim() != "1002")
            {
                sbUpdateMsg.Append("[E]��Ϣδ����Ҳ����ظ�ͨ��Ա��Ϣ�����������ɾ�̬�ļ�!<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            #endregion


            #region �滻ģ������Ϣ

            TmpTmpSource = TmpSource;

            //������Ϣ
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
            CooperationDemandType1 = CooperationDemandType1.Replace("3", "���س���/����");
            CooperationDemandType1 = CooperationDemandType1.Replace("4", "��Ŀ����ת��");
            CooperationDemandType1 = CooperationDemandType1.Replace("5", "BOT/BT");
            CooperationDemandType1 = CooperationDemandType1.Replace("6", "��Ͷ");
            CooperationDemandType1 = CooperationDemandType1.Replace("7", "����");
            CooperationDemandType1 = CooperationDemandType1.Replace("8", "��������");
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationDemandType1.Trim());

            string IndustryName = "";       //��������ҵ
            foreach (string sTempIndustry in TheMerchant.MerchantInfoModel.IndustryBName)
            {
                IndustryName = IndustryName + sTempIndustry.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName.ToString());

            string AreaName = "";           //Ͷ������
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

            string CapitalTotal = "��δ�ṩ";
            if (TheMerchant.MerchantInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheMerchant.MerchantInfoModel.CapitalTotal.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//��Ŀ��Ͷ��

            string CurrencyName = TheMerchant.MerchantInfoModel.MerchantCurrency.Trim().ToLower();
            switch (CurrencyName)
            {
                case "cny":
                    CurrencyName = "�����";
                    break;
                case "hkd":
                    CurrencyName = "�۱�";
                    break;
                case "usd":
                    CurrencyName = "��Ԫ";
                    break;
                default:
                    CurrencyName = "�����";
                    break;
            };
            string MerchantToltalName = TheMerchant.MerchantInfoModel.Merchanttotalname.Trim();
            if (MerchantToltalName.Trim() == "����")
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
            string userDomain = GetSelfDomain(TheMerchant.MainInfoModel.LoginName.Trim());  //չ�� �û�����
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
                "����Դδ�����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>����֤��Դ����ʵ��</span>��";  //������֤��Դ
            if ((Convert.ToInt32(TheMerchant.MainInfoModel.FixPriceID) > 1 && TheMerchant.MainInfoModel.MainPointCount > 0) 
                || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheMerchant.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "����Դ�Ѿ����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>��֤��Դ����ʵ��</span>��";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheMerchant));  //����Դ��Ϣ������(�ٷֱ�)
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(TheMerchant.MainInfoModel.InfoID.ToString()).ToString());  //����������


            #endregion

            #region Ϊ����Ϣ������ϵ��ʽ��cache [ȡ��]

            //string cacheName = "Cache_Info_" + InfoID;
            //if (HttpContext.Current.Cache[cacheName] == null)
            //{
            //    string cacheContent = "";
                
            //    #region ��ȡ����Ϣ����ϵ��ʽ����

            //    StringBuilder sbContact = new StringBuilder();

            //    sbContact.Append(TheMerchant.MerchantInfoModel.ProjectStatus);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.marketAbout);
            //    sbContact.Append("|");
            //    sbContact.Append(TheMerchant.MerchantInfoModel.Benifit);
            //    sbContact.Append("|");

            //    string fujianStr = "";              //7,�����б�
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
            //        temp = temp.Replace("#ResType", restype == "image" ? "����鿴ͼƬ" : "��������ļ�");
            //        temp = temp.Replace("#ResURL", fileName.Trim());
            //        //temp = temp.Replace("#ResDec", ResModel.ResourceDescrib);
            //        temp = temp.Replace("#ResTitle", attachments[i].ResourceTitle);
            //        fujianStr += temp;
            //    }
            //    if (fujianStr.Trim() == "")
            //    {
            //        fujianStr = "<li>����ظ���</li>";
            //    }

            //    sbContact.Append(fujianStr.Trim());
            //    sbContact.Append("|");

            //    sbContact.Append("��Ŀ���赥λ��&nbsp;" + TheMerchant.InfoContactModel.OrganizationName.Trim() + "<br />");
            //    sbContact.Append("��ϵ�ˣ�&nbsp;" + TheMerchant.InfoContactModel.Name.Trim() + "<br />");
            //    sbContact.Append("ְλ��&nbsp;" + TheMerchant.InfoContactModel.Career.Trim() + "<br />");
            //    sbContact.Append("�̶��绰��&nbsp;" + TheMerchant.InfoContactModel.TelStateCode + "-" + TheMerchant.InfoContactModel.TelNum.Trim() + "<br />");
            //    sbContact.Append("�ֻ���&nbsp;" + TheMerchant.InfoContactModel.Mobile.Trim() + "<br />");
            //    sbContact.Append("�������䣺&nbsp;" + TheMerchant.InfoContactModel.Email + "<br />");
            //    sbContact.Append("��Ŀ��λ��ϸ��ַ��&nbsp;" + TheMerchant.InfoContactModel.Address + "<br />");
            //    sbContact.Append("��Ŀ��λ��ַ��&nbsp;" + TheMerchant.InfoContactModel.WebSite);

            //    cacheContent = sbContact.ToString();

            //    #endregion
                
            //    HttpContext.Current.Cache[cacheName] = cacheContent;
            //}

            #endregion

            #region ����ļ�

            OutPutFilePath = ApplicationRootPath + HtmlFile;

            //���·���Ƿ���ȷ
            if (!Common.BulidFolder(OutPutFilePath, true))
            {
                sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Project<br>");
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
            UpdateMsg = sbUpdateMsg.ToString();
            return true;

            #endregion

        }

        #endregion


        #region ����Դ��Ϣ������(�ٷֱ�)

        public string getCompleteDegreeById(MerchantSetModel model)
        {
            int degree = 50;

            if (model.MerchantInfoModel.ProjectStatus != null && model.MerchantInfoModel.ProjectStatus.Trim() == "")//��Ŀ��״���滮
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.EconomicIndicators != null && model.MerchantInfoModel.EconomicIndicators.Trim() == "")//����Ч�����
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.marketAbout != null && model.MerchantInfoModel.marketAbout.Trim() == "")//��Ŀ���Ƽ��г�����
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.InvestmentEnvironment != null && model.MerchantInfoModel.InvestmentEnvironment.Trim() == "")//�ط�����ָ������
            {
                degree += 5;
            }
            if (model.MerchantInfoModel.Benefit != null && model.MerchantInfoModel.Benefit.Trim() == "")//Ͷ�ʻ�������
            {
                degree += 5;
            }
            if (model.InfoResourceModels != null && model.InfoResourceModels.Count > 0)//��������
            {
                degree += 10;
            }
            if (model.InfoContactModel.OrganizationName != null && model.InfoContactModel.OrganizationName.Trim() == "")//���̻�������
            {
                degree += 7;
            }
            if (model.InfoContactModel.TelNum != null && model.InfoContactModel.Mobile != null && model.InfoContactModel.TelNum.Trim() == "" || model.InfoContactModel.Mobile.Trim() == "")//���̻�������
            {
                degree += 2;
            }
            if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.Trim() == "")//���̻�������
            {
                degree += 2;
            }
            if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.Trim() == "")//���̻�������
            {
                degree += 2;
            }
            if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.Trim() == "")//���̻�������
            {
                degree += 2;
            }

            return degree.ToString() + "%";
        }

        #endregion
        


    }
}
