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
    /// Ͷ�ʾ�̬ҳ������
    /// </summary>
    public class CapitalPageStatic
    {
        private const string CapitalTempChangeFileName = "TempCapitalChange.htm";   //CapitalChangeģ��·��
        private const string CapitalTempFeeFileName = "TempCapitalFee.htm";         //CapitalFeeģ��·��
        private const string CapitalTempVipFileName = "TempCapitalVip.htm";         //CaiptalVip����·��
        private const string CapitalTempEndFileTo = "";                             //�����ļ������·��
        private const string CapitalPicPath = "http://images.topfo.com/";           //ͼƬ·��
        private const string CapitalResourcePath = "";                              //��Դ·��
        private const string TagsUrl = "http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";
        private readonly ICapitalInfo dal = DataAccess.CreateInfo_CapitalInfo();
       

        #region �����̬ҳ���ļ�
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageCapital_before20100820(string InfoID,ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                //ϵͳ·��
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
                //ģ��·��
                string TempCapitalPath = ConfigurationManager.AppSettings["CapitalTmpPath"].ToString(); //Ͷ��ģ��Ĵ��λ��
                //Ŀ��·��
                string TempCapitalPathTo = ConfigurationManager.AppSettings["CapitalTmpPathTo"].ToString(); //Ͷ��ģ��Ĵ��λ��

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����
                
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
                string InfoPriceName; //������ʾ         

                string InfoOriginRoleName;

                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = "";

                string CapitalName;    //�ʱ����
                string CurrencyName; //��������

                string CapitalTypeName;//�ʱ�����:ֱͶ,����,����,����....            

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

                string ResourceInfo1 = "";//��Դ��ʾ��Ϣ1
                string ResourceInfo2 = "";//��Դ��ʾ��Ϣ2

                string ManageType = "";//��Ա����
                string UserDetail = "";//�û��Ĺ�˾��ϸ��Ϣ
                string ManageTypeName = ""; //�ظ�ͨ��Ա����

                string UserGradeTypeID = "";
                #endregion

                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));

                #region ��ȡģ������
                string TempName = "";

                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    //��֤��Դģ��
                    TempName = CapitalTempChangeFileName;
                }
                else
                {
                    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
                    UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(theCapital.MainInfoModel.LoginName.Trim());
                    
                    if (UserGradeTypeID == "1001")
                    {
                        //��ͨ�û�ģ��
                        TempName = CapitalTempFeeFileName;
                    }
                    else
                    {
                        //VIP��Աģ��
                        TempName = CapitalTempVipFileName;
                    }
                }
                #endregion

                #region ��ȡģ������

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

                if (theCapital.CapitalInfoModel == null || theCapital.CapitalInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = theCapital.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)theCapital.MainInfoModel.AuditingStatus;

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

                CapitalTypeName = theCapital.CapitalInfoModel.CapitalTypeName.Trim();
                
                CapitalName = theCapital.CapitalInfoModel.CapitalName.Trim();
                if (CapitalName == "0")
                    CapitalName = "";



                //������ʽ
                CooperationTypeName = "";
                foreach (string sCoopTypeName in theCapital.CapitalInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }

                //Ͷ������
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
                    AreaName = "����";
                }

                //��������ҵ
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

                //��ϵ�˸���
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

                    //��ϵ�˹�˾
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
                }

                if (CapitalName.Trim() == "����")
                    CurrencyName = "";

                //��Դ�۸�
                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0))
                {
                    ResourceInfo1 = "Ϊ��߶Խ�����������Դ���û�����Ϊ������Դ";
                    ResourceInfo2 = "����";
                    ResourceValue = Convert.ToDecimal(theCapital.MainInfoModel.MainPointCount.ToString().Trim()).ToString("c");
                    Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
                    Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
                    objDic = diBll.GetModel("1");
                    ResourceValueVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * theCapital.MainInfoModel.MainPointCount)).ToString("c");
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
                if (theCapital.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in theCapital.InfoResourceModels)
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
                    Doc1_r = "<li>" + Doc1_c + "��<a href='" + Doc1 + "'>�鿴</a><a href='" + CapitalResourcePath + Doc1 + "'>����</a></li>";
                }

                if (arrListDoc.Count > 1)
                {
                    string[] sDocTemp = (string[])arrListDoc[1];
                    Doc2 = sDocTemp[0];
                    Doc2_c = sDocTemp[1];
                    Doc2_r = "<li>" + Doc2_c + "��<a href='" + Doc2 + "'>�鿴</a><a href='" + CapitalResourcePath + Doc2 + "'>����</a></li>";
                }
                if (arrListDoc.Count > 2)
                {
                    string[] sDocTemp = (string[])arrListDoc[2];
                    Doc3 = sDocTemp[0];
                    Doc3_c = sDocTemp[1];
                    Doc3_r = "<li>" + Doc3_c + "��<a href='" + Doc3 + "'>�鿴</a><a href='" + CapitalResourcePath + Doc3 + "'>����</a></li>";
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
                    KeyWord = string.Format(TagslinkModel, "Ͷ��", "Ͷ��");

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = theCapital.MainInfoModel.HtmlFile;
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (theCapital.MainInfoModel.DisplayTitle == "")
                {
                    theCapital.MainInfoModel.DisplayTitle = Title;
                }
                DisplayTitle = theCapital.MainInfoModel.DisplayTitle + "��" + "�й�����Ͷ����";
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

                    if (ds == null || ds.Tables[0].Rows.Count == 0 || string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ExhibitionHall"].ToString().Trim()))
                    {
                        WebUrl = "JavaScript:alert('����ҵ��δ����չ����');";
                        ComIntro = "JavaScript:alert('����ҵ��δ����չ����');";
                        TopfoDoc = "JavaScript:alert('����ҵ��δ����չ����');";
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

                #endregion ������ֵ

                #region �滻ģ��

                #region Vip��ģ��
                if (TempName.Trim() == CapitalTempVipFileName)//Vipģ��
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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion

                #region �շѵ�ģ��
                if (TempName.Trim() == CapitalTempChangeFileName)//�շѵ�ģ��
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
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�շ���Դ");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourcePrice#", ResourcePrice);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo1#", ResourceInfo1);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo2#", ResourceInfo2);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                }
                #endregion

                #region ��ѵ�ģ��
                if (TempName.Trim() == CapitalTempFeeFileName)//��ѵ�ģ��
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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyName#", ContractPersonCompanyName.Trim());

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);
                }
                #endregion

                #endregion

                #region ����ļ�
                OutPutFilePath = ApplicationRootPath + TempCapitalPathTo.Trim() + HtmlFile;

                //���·���Ƿ���ȷ
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Capital<br>");
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
            catch(Exception ex)
            {
                string err = ex.Message.ToString().Trim();
                sbUpdateMsg.Append(err);
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }
        }

        /// <summary>
        /// CreateStaticPageCapital_V3 ��copy,��ҳ���ϵ��õ��Ǹ÷���,�·����ĳ���CreateStaticPageCapital_V3,����ҳ�治�����Ķ�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="UpdateMsg"></param>
        /// <returns></returns>
        public bool CreateStaticPageCapital(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
                string TempCapitalPath = ConfigurationManager.AppSettings["CapitalTmpPath"].ToString(); //Ͷ��ģ��Ĵ��λ��
                string TempCapitalPathTo = ConfigurationManager.AppSettings["CapitalTmpPathTo"].ToString(); //Ͷ��ģ��Ĵ��λ��
                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

                string TempName = "Template/Temp_Info_V3/Temp_Capital_V3.htm";  //��ȡģ������
                CapitalSetModel theCapital = new CapitalSetModel();
                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));
                Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
                DataTable dt_login = login.GetLoginInfo(theCapital.MainInfoModel.LoginName);

                string loginName;
                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;
                byte AuditingStatus;
                string HtmlFile = theCapital.MainInfoModel.HtmlFile;

                #endregion


                #region ��ȡģ������

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

                if (theCapital.CapitalInfoModel == null || theCapital.CapitalInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = theCapital.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)theCapital.MainInfoModel.AuditingStatus;

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

                string CooperationTypeName = ""; //������ʽ
                foreach (string sCoopTypeName in theCapital.CapitalInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);

                string AreaName = ""; //Ͷ������
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
                    AreaName = "����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", theCapital.CapitalInfoModel.CapitalName.Trim());

                string CurrencyName = theCapital.CapitalInfoModel.Currency.Trim().ToLower();
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
                }
                if (theCapital.CapitalInfoModel.CapitalName.Trim() == "����")
                    CurrencyName = "";
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                string stageID = "";      //��ҵ��չ�׶�
                switch (theCapital.CapitalInfoModel.stageID.ToString().Trim())
                {
                    case "0":
                    case "1": stageID = "������"; break;
                    case "2": stageID = "������"; break;
                    case "3": stageID = "�ɳ���"; break;
                    case "4": stageID = "������"; break;
                    case "5": stageID = "Pro-IPO"; break;
                    case "6": stageID = "�ȶ���"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-stageID#", stageID);

                if (theCapital.CapitalInfoModel.RegisteredCapital != null)
                {
                    string RegisteredCapital = "";
                    switch (theCapital.CapitalInfoModel.RegisteredCapital.ToString().Trim())
                    {
                        case "0":
                        case "1": RegisteredCapital = "5000������"; break;
                        case "2": RegisteredCapital = "5000��-1��"; break;
                        case "3": RegisteredCapital = "1-2��"; break;
                        case "4": RegisteredCapital = "2-10��"; break;
                        case "5": RegisteredCapital = "Pro-IPO"; break;
                        case "6": RegisteredCapital = "10������"; break;
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
                        case "1": AverageInvestment = "0��"; break;
                        case "2": AverageInvestment = "1-2��"; break;
                        case "3": AverageInvestment = "3-5��"; break;
                        case "4": AverageInvestment = "5������"; break;
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
                        case "1": SuccessfulInvestment = "0��"; break;
                        case "2": SuccessfulInvestment = "1-10��"; break;
                        case "3": SuccessfulInvestment = "10-30��"; break;
                        case "4": SuccessfulInvestment = "30-60��"; break;
                        case "5": SuccessfulInvestment = "60������"; break;
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
                        case "0": joinManageID = "����"; break;
                        case "1": joinManageID = "������"; break;
                        case "2": joinManageID = "����"; break;
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
                        case "1": TeamScale = "5������"; break;
                        case "2": TeamScale = "5-10��"; break;
                        case "3": TeamScale = "10-20��"; break;
                        case "4": TeamScale = "20-30��"; break;
                        case "5": TeamScale = "30-50��"; break;
                        case "6": TeamScale = "50������"; break;
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
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(theCapital));  //����Դ��Ϣ������(�ٷֱ�)

                string IndustryName = "";   //��������ҵ
                foreach (string sTempIndustry in theCapital.CapitalInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

                string IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                    "����Դδ�����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>����֤��Դ����ʵ��</span>��";  //������֤��Դ
                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                        "����Դ�Ѿ����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>��֤��Դ����ʵ��</span>��";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

                string userDomain = GetSelfDomain(theCapital.MainInfoModel.LoginName.Trim());  //չ�� �û�����
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

                //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(theCapital.MainInfoModel.InfoID.ToString()).ToString());  //����������
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


                #region ����ļ�
                OutPutFilePath = ApplicationRootPath + HtmlFile;

                //���·���Ƿ���ȷ
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Capital<br>");
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


        #region ͨ��InfoID��ȡһ����Ϣʵ��
        /// <summary>
        /// ͨ��InfoID��ȡһ��Capital����Ϣʵ��
        /// </summary>
        /// <returns></returns>
        public CapitalSetModel objGetCapitalInfoByInfoID(long InfoID)
        {
           
            CapitalSetModel TheCapitalInfo = new CapitalSetModel();
            TheCapitalInfo = dal.GetIntegrityModel(InfoID);
            return TheCapitalInfo;             
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
            Tz888.BLL.Register.common combll = new Tz888.BLL.Register.common();
            return combll.GetEnterpriseInfo(loginName);
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


        #region ģ��V3�����ɾ�̬ҳ��
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageCapital_V3(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
                string TempCapitalPath = ConfigurationManager.AppSettings["CapitalTmpPath"].ToString(); //Ͷ��ģ��Ĵ��λ��
                string TempCapitalPathTo = ConfigurationManager.AppSettings["CapitalTmpPathTo"].ToString(); //Ͷ��ģ��Ĵ��λ��
                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

                string TempName = "Template/Temp_Info_V3/Temp_Capital_V3.htm";  //��ȡģ������
                CapitalSetModel theCapital = new CapitalSetModel();
                theCapital = this.objGetCapitalInfoByInfoID(long.Parse(InfoID.Trim()));
                Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
                Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
                DataTable dt_login = login.GetLoginInfo(theCapital.MainInfoModel.LoginName);

                string loginName;
                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;
                byte AuditingStatus;
                string HtmlFile = theCapital.MainInfoModel.HtmlFile;

                #endregion


                #region ��ȡģ������

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

                if (theCapital.CapitalInfoModel == null || theCapital.CapitalInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = theCapital.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)theCapital.MainInfoModel.AuditingStatus;

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
                
                string CooperationTypeName = ""; //������ʽ
                foreach (string sCoopTypeName in theCapital.CapitalInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName = CooperationTypeName + " " + sCoopTypeName.Trim();
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CooperationDemandType#", CooperationTypeName);
               
                string AreaName = ""; //Ͷ������
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
                    AreaName = "����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-AreaName#", AreaName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalName#", theCapital.CapitalInfoModel.CapitalName.Trim());

                string CurrencyName = theCapital.CapitalInfoModel.Currency.Trim().ToLower();
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
                }
                if (theCapital.CapitalInfoModel.CapitalName.Trim() == "����")
                    CurrencyName = "";
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                string stageID = "";      //��ҵ��չ�׶�
                switch (theCapital.CapitalInfoModel.stageID.ToString().Trim())
                {
                    case "0":
                    case "1": stageID = "������"; break;
                    case "2": stageID = "������"; break;
                    case "3": stageID = "�ɳ���"; break;
                    case "4": stageID = "������"; break;
                    case "5": stageID = "Pro-IPO"; break;
                    case "6": stageID = "�ȶ���"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-stageID#", stageID);

                if (theCapital.CapitalInfoModel.RegisteredCapital != null)
                {
                    string RegisteredCapital = "";   
                    switch (theCapital.CapitalInfoModel.RegisteredCapital.ToString().Trim())
                    {
                        case "0":
                        case "1": RegisteredCapital = "5000������"; break;
                        case "2": RegisteredCapital = "5000��-1��"; break;
                        case "3": RegisteredCapital = "1-2��"; break;
                        case "4": RegisteredCapital = "2-10��"; break;
                        case "5": RegisteredCapital = "Pro-IPO"; break;
                        case "6": RegisteredCapital = "10������"; break;
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
                        case "1": AverageInvestment = "0��"; break;
                        case "2": AverageInvestment = "1-2��"; break;
                        case "3": AverageInvestment = "3-5��"; break;
                        case "4": AverageInvestment = "5������"; break;
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
                        case "1": SuccessfulInvestment = "0��"; break;
                        case "2": SuccessfulInvestment = "1-10��"; break;
                        case "3": SuccessfulInvestment = "10-30��"; break;
                        case "4": SuccessfulInvestment = "30-60��"; break;
                        case "5": SuccessfulInvestment = "60������"; break;
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
                        case "0": joinManageID = "����"; break;
                        case "1": joinManageID = "������"; break;
                        case "2": joinManageID = "����"; break;
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
                        case "1": TeamScale = "5������"; break;
                        case "2": TeamScale = "5-10��"; break;
                        case "3": TeamScale = "10-20��"; break;
                        case "4": TeamScale = "20-30��"; break;
                        case "5": TeamScale = "30-50��"; break;
                        case "6": TeamScale = "50������"; break;
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
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(theCapital));  //����Դ��Ϣ������(�ٷֱ�)

                string IndustryName = "";   //��������ҵ
                foreach (string sTempIndustry in theCapital.CapitalInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

                string IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" + 
                    "����Դδ�����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>����֤��Դ����ʵ��</span>��";  //������֤��Դ
                if ((Convert.ToInt32(theCapital.MainInfoModel.FixPriceID) > 1 && theCapital.MainInfoModel.MainPointCount > 0) 
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                        "����Դ�Ѿ����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>��֤��Դ����ʵ��</span>��";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", IsCheck);

                string userDomain = GetSelfDomain(theCapital.MainInfoModel.LoginName.Trim());  //չ�� �û�����
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

                //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(theCapital.MainInfoModel.InfoID.ToString()).ToString());  //����������
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


                #region ����ļ�
                OutPutFilePath = ApplicationRootPath + HtmlFile;

                //���·���Ƿ���ȷ
                if (!Common.BulidFolder(OutPutFilePath, true))
                {
                    sbUpdateMsg.Append("[E]·��" + OutPutFilePath + "����ȷ!��Դ���ͣ�Capital<br>");
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


        #region ����Դ��Ϣ������(�ٷֱ�)

        public string getCompleteDegreeById(CapitalSetModel model)
        {
            int degree = 50;
            if (model.CapitalInfoModel.TeamScale != null && model.CapitalInfoModel.TeamScale.Trim() != "")  //�����Ŷӹ�ģ
            {
                degree += 6;
            }
            if (model.CapitalInfoModel.TeamScale != null && model.CapitalInfoModel.AverageInvestment.Trim() != "")  //����Ͷ���¼���
            {
                degree += 6;
            }
            if (model.CapitalInfoModel.TeamScale != null && model.CapitalInfoModel.SuccessfulInvestment.Trim() != "")  //�ɹ�Ͷ���¼�����
            {
                degree += 6;
            }
            if (model.InfoContactModel.OrgIntro != null && model.InfoContactModel.OrgIntro.Trim() != "")  //Ͷ�ʻ������
            {
                degree += 2;
            }
            if (model.InfoContactModel.Name != null && model.InfoContactModel.Name.Trim() != "")  //��ϵ��
            {
                degree += 2;
            }
            if (model.InfoContactModel.TelNum != null && model.InfoContactModel.TelNum.Trim() != "" || model.InfoContactModel.Mobile.Trim() != "")  //��ϵ�绰
            {
                degree += 2;
            }
            if (model.InfoContactModel.Email != null && model.InfoContactModel.Email.Trim() != "")  //��������
            {
                degree += 2;
            }
            if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.Trim() != "")  //��������
            {
                degree += 2;
            }
            if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.Trim() != "")  //ְλ
            {
                degree += 2;
            }
            if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.Trim() != "")  //ְλ
            {
                degree += 2;
            }
            if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.Trim() != "")  //ְλ
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
