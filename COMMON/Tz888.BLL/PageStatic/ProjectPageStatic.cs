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
        private const string ProjectTempChangeFileName = "TempProjectChange.htm";   //ProjectChangeģ��·��
        private const string ProjectTempFeeFileName = "TempProjectFee.htm";         //ProjectFeeģ��·��
        private const string ProjectTempFeeFileName_New = "TempProjectFee_New.htm";
        private const string ProjectTempVipFileName = "TempProjectVip.htm";         //ProjectVip����·��
        private const string ProjectTempVipFileName_New = "TempProjectVip_New.htm";
        private const string ProjectTempEndFileTo = "";                             //�����ļ������·��
        private const string ProjectPicPath = "http://images.topfo.com/";           //ͼƬ·��
        private const string ProjectResourcePath = "";                              //��Դ·��
        //=========��ģ��
        // private const string Project_Check
        private const string Project_ZQ = "Project_ZQ.htm";//ծȯ����
        private const string Project_GQ = "Project_GQ.htm";//��Ȩ����
        private const string Project_ZQ_Vip = "Project_ZQ_Vip.htm";
        private const string Project_GQ_Vip = "Project_GQ_Vip.htm";
        private const string TagsUrl = "http://search.topfo.com/SearchResultProject.aspx?KeywordUrl={0}";
        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultProject.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";
        private readonly IProjectInfo dal = DataAccess.CreateInfo_ProjectInfo();


        #region �����̬ҳ���ļ�
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        /// <param name="IsLog">�Ƿ���Ҫ����Ϣд����־</param>
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageProject_before20100820(string InfoID, ref string UpdateMsg)
        {
            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            try
            {
                #region ��������

                //ϵͳ·��
                string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString(); //��̬ҳ��ĸ�Ŀ¼
                //ģ��·��
                string TempProjectPath = ConfigurationManager.AppSettings["ProjectTmpPath"].ToString(); //����ģ��Ĵ��λ��
                //Ŀ��·��
                string TempProjectPathTo = ConfigurationManager.AppSettings["ProjectTmpPathTo"].ToString(); //����ģ�����ɴ��λ��

                string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

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
                string InfoPriceName; //������ʾ         

                string InfoOriginRoleName;

                string TmpTmpSource = "";
                string OutPutFilePath; //���·��
                StreamWriter swOutPut;

                long HaveDoneCount = 0;
                string LodgeMsg = "";
                string Recommend = "";

                string ProjectName;
                string CapitalName = ""; //�ʱ����
                string CurrencyName; //��������

                string ProjectNameTotal;//��Ͷ�ʽ��
                string ProjectCurrencyName; //��Ͷ�ʻ�������

                string ProjectTypeName;//�ʱ�����:ֱͶ,����,����,����....            

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

                string UserGradeTypeID = "";//��Ա����
                #endregion

                TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));

                #region ��ȡģ������
                string TempName = "";

                if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                    || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
                {
                    //��֤��Դģ��
                    TempName = ProjectTempChangeFileName;
                }
                else
                {
                    Tz888.BLL.Login.LoginInfoBLL loginBll = new Tz888.BLL.Login.LoginInfoBLL();
                    UserGradeTypeID = loginBll.GetUserGradeTypeIDByLoginName(TheProject.MainInfoModel.LoginName.Trim());
                    if (UserGradeTypeID == "1001")
                    {
                        //��ͨ�û�ģ��
                        TempName = ProjectTempFeeFileName;
                    }
                    else
                    {
                        //VIP��Աģ��
                        TempName = ProjectTempVipFileName;
                    }
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

                if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
                {
                    sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                    UpdateMsg = sbUpdateMsg.ToString();
                    return false;
                }

                loginName = TheProject.MainInfoModel.LoginName.Trim();

                Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
                string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

                AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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

                ProjectTypeName = "";
                ProjectName = TheProject.ProjectInfoModel.ProjectName.Trim();
                ProjectNameTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString().Trim();


                //������ʽ
                CooperationTypeName = "";
                foreach (string sCoopTypeName in TheProject.ProjectInfoModel.CooperationDemandTypeName)
                {
                    CooperationTypeName += sCoopTypeName.Trim() + " ";
                }

                //Ͷ������
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



                //��������ҵ
                IndustryName = "";
                foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
                {
                    IndustryName += sTempIndustry.Trim() + " ";
                }

                //��ʼʱ��
                PublishT = TheProject.MainInfoModel.ValidateStartTime.ToShortDateString().Trim();
                //����ʱ��
                ValidatePeriod = TheProject.MainInfoModel.ValidateTerm.ToString().Trim();

                PublisLoginName = TheProject.MainInfoModel.LoginName.ToString().Trim();
                TZYX = TheProject.ProjectInfoModel.ComAbout.Trim();

                if (TheProject.ProjectInfoModel.ComBrief.Trim() != "")
                    TZYX = TheProject.ProjectInfoModel.ComBrief.Trim();
                else
                    TZYX = TheProject.ProjectInfoModel.ComAbout.Trim();

                //��ϵ�˸���
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
                    //��ϵ�˹�˾

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
                        ProjectCurrencyName = "�����";
                        break;
                    case "hkd":
                        ProjectCurrencyName = "�۱�";
                        break;
                    case "usd":
                        ProjectCurrencyName = "��Ԫ";
                        break;
                    default:
                        ProjectCurrencyName = "�����";
                        break;
                }

                CapitalName = TheProject.ProjectInfoModel.CapitalName;
                CurrencyName = TheProject.ProjectInfoModel.ProjectCurrency.Trim().ToLower();
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
                if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0))
                {
                    ResourceInfo1 = "Ϊ��߶Խ�����������Դ���û�����Ϊ������Դ";
                    ResourceInfo2 = "����";
                    ResourceValue = Convert.ToDecimal(TheProject.MainInfoModel.MainPointCount.ToString().Trim()).ToString("c");
                    Tz888.BLL.Common.DictionaryInfoBLL diBll = new Tz888.BLL.Common.DictionaryInfoBLL();
                    Tz888.Model.Common.DictionaryInfoModel objDic = new Tz888.Model.Common.DictionaryInfoModel();
                    objDic = diBll.GetModel("1");
                    ResourceValueVip = Convert.ToDecimal(Convert.ToString(Convert.ToDecimal(objDic.DictionaryInfoParam) * TheProject.MainInfoModel.MainPointCount)).ToString("c");
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
                if (TheProject.InfoResourceModels != null)
                {
                    foreach (Tz888.Model.Info.InfoResourceModel objModelResource in TheProject.InfoResourceModels)
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
                    Doc1_r = "<li>" + Doc1_c + "��<a href='" + Doc1 + "'>�鿴</a><a href='" + ProjectResourcePath + Doc1 + "'>����</a></li>";
                }

                if (arrListDoc.Count > 1)
                {
                    string[] sDocTemp = (string[])arrListDoc[1];
                    Doc2 = sDocTemp[0];
                    Doc2_c = sDocTemp[1];
                    Doc2_r = "<li>" + Doc2_c + "��<a href='" + Doc2 + "'>�鿴</a><a href='" + ProjectResourcePath + Doc2 + "'>����</a></li>";
                }
                if (arrListDoc.Count > 2)
                {
                    string[] sDocTemp = (string[])arrListDoc[2];
                    Doc3 = sDocTemp[0];
                    Doc3_c = sDocTemp[1];
                    Doc3_r = "<li>" + Doc3_c + "��<a href='" + Doc3 + "'>�鿴</a><a href='" + ProjectResourcePath + Doc3 + "'>����</a></li>";
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
                    KeyWord = string.Format(TagslinkModel, "����", "����");

                LodgeMsg = InfoID + "&Title=" + Title;

                HtmlFile = TheProject.MainInfoModel.HtmlFile;
                Recommend = InfoID + "&PageUrl=" + HtmlFile;

                if (TheProject.MainInfoModel.DisplayTitle == "")
                {
                    TheProject.MainInfoModel.DisplayTitle = Title;
                }
                DisplayTitle = TheProject.MainInfoModel.DisplayTitle + "��" + "�й�����Ͷ����";
                Descript = TheProject.MainInfoModel.Descript;
                TemplateID = Convert.ToInt32(TheProject.MainInfoModel.TemplateID);


                #region �жϸ���Ϣ�Ƿ���Ҫ�۸� -------------------------------------
                InfoPrice = 0;
                InfoOriginRoleName = TheProject.MainInfoModel.InfoOriginRoleName;
                int WorthPoint = 0;


                //V1.2 һ
                if (FixPriceID == "1" || (TheProject.MainInfoModel.FeeStatus == 0 && InfoOriginRoleName == "0"))//���
                {
                    //����Ϣ�Ѿ�������Ϊ�����Ϣ
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
                    InfoPriceName = Common.GetFloatToString(InfoPrice, 2) + "Ԫ��������Դ��";
                }
                else
                {
                    InfoPriceName = Common.GetFloatToString(InfoPrice, 2) + "Ԫ";
                }

                if (blisCore || InfoPrice > 0)//������Ϣ ���� �շ���Ϣ
                {
                    ComAbout = TheProject.ProjectInfoModel.ComAbout;
                    Strategy = TheProject.ProjectInfoModel.ComBrief;
                }
                else
                {
                    //�����Ϣ -- ��ʾ��ѱ�־												
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

                #endregion

                #endregion

                #region �滻ģ��

                #region Vip��ģ��
                if (TempName.Trim() == ProjectTempVipFileName)//Vipģ��
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    if (string.IsNullOrEmpty(ProjectNameTotal) || ProjectNameTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "<tr><td class=\"h\">��Ͷ�ʣ�</td><td>" + ProjectNameTotal + "�� " + ProjectCurrencyName + "</td></tr>");

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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    #region �ظ�ָ��

                    Tz888.BLL.TFZS.MainTarget tfzs = new Tz888.BLL.TFZS.MainTarget();

                    #region ծȨ����
                    //�쵼�Ŷӣ� #@TmpFeild-ZQ1#<br />
                    //�г�ǰ���� #@TmpFeild-ZQ2#<br />
                    //ӯ��ģʽ�� #@TmpFeild-ZQ3#<br />
                    //����ָ�꣺ #@TmpFeild-ZQ4#<br />
                    //���տ��ƣ� #@TmpFeild-ZQ5#<br />
                    //�ظ�ָ���� #@TmpFeild-ZQ6#<br />
                    //��Ŀ���ۣ� #@TmpFeild-ZQPJ#

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
                        ZQPJ = "��Ŀ��Դ���ֺܲͶ�ʷ��վ޴�";
                    else if (ZQ6 >= 40 && ZQ6 < 60)
                        ZQPJ = "��Ŀ��Դ�������ã�Ͷ�ʾ��нϴ�ķ��ա�";
                    else if (ZQ6 >= 60 && ZQ6 < 80)
                        ZQPJ = "��Ŀ��Դ�������ã�����һ��Ͷ�ʼ�ֵ��";
                    else if (ZQ6 >= 80)
                        ZQPJ = "��Ŀ��Դ�ǳ����죬�ǳ�����Ͷ�ʼ�ֵ��";
                    else
                        ZQPJ = "���û�û�н��д�����ĿͶ�ʼ�ֵ�����������ۣ�";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQPJ#", ZQPJ);

                    #endregion

                    #region ��Ȩ����
                    //�г�ǰ���� #@TmpFeild-GQ1#<br />
                    //����ָ�꣺ #@TmpFeild-GQ2#<br />
                    //����ָ�꣺ #@TmpFeild-GQ3#<br />
                    //��Ŀ���գ� #@TmpFeild-GQ4#<br />
                    //��Ӫ���գ� #@TmpFeild-GQ5#<br />
                    //�ظ�ָ���� #@TmpFeild-GQ6#<br />
                    //��Ŀ���ۣ� #@TmpFeild-GQPJ#
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
                        GQPJ = "��Ŀ��Դ���ֺܲͶ�ʷ��վ޴�";
                    else if (GQ6 >= 40 && GQ6 < 60)
                        GQPJ = "��Ŀ��Դ�������ã�Ͷ�ʾ��нϴ�ķ��ա�";
                    else if (GQ6 >= 60 && GQ6 < 80)
                        GQPJ = "��Ŀ��Դ�������ã�����һ��Ͷ�ʼ�ֵ��";
                    else if (GQ6 >= 80)
                        GQPJ = "��Ŀ��Դ�ǳ����죬�ǳ�����Ͷ�ʼ�ֵ��";
                    else
                        GQPJ = "���û�û�н��д�����ĿͶ�ʼ�ֵ�����������ۣ�";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQPJ#", GQPJ);
                    #endregion


                    #endregion

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);

                }
                #endregion

                #region �շѵ�ģ��
                if (TempName.Trim() == ProjectTempChangeFileName)//�շѵ�ģ��
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    if (string.IsNullOrEmpty(ProjectNameTotal) || ProjectNameTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "<tr><td class=\"h\">��Ͷ�ʣ�</td><td>" + ProjectNameTotal + "�� " + ProjectCurrencyName + "</td></tr>");

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
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�շ���Դ");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourcePrice#", ResourcePrice);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo1#", ResourceInfo1);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ResourceInfo2#", ResourceInfo2);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    #region �ظ�ָ��

                    Tz888.BLL.TFZS.MainTarget tfzs = new Tz888.BLL.TFZS.MainTarget();

                    #region ծȨ����
                    //�쵼�Ŷӣ� #@TmpFeild-ZQ1#<br />
                    //�г�ǰ���� #@TmpFeild-ZQ2#<br />
                    //ӯ��ģʽ�� #@TmpFeild-ZQ3#<br />
                    //����ָ�꣺ #@TmpFeild-ZQ4#<br />
                    //���տ��ƣ� #@TmpFeild-ZQ5#<br />
                    //�ظ�ָ���� #@TmpFeild-ZQ6#<br />
                    //��Ŀ���ۣ� #@TmpFeild-ZQPJ#

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
                        ZQPJ = "��Ŀ��Դ���ֺܲͶ�ʷ��վ޴�";
                    else if (ZQ6 >= 40 && ZQ6 < 60)
                        ZQPJ = "��Ŀ��Դ�������ã�Ͷ�ʾ��нϴ�ķ��գ�";
                    else if (ZQ6 >= 60 && ZQ6 < 80)
                        ZQPJ = "��Ŀ��Դ�������ã�����һ��Ͷ�ʼ�ֵ��";
                    else if (ZQ6 >= 80)
                        ZQPJ = "��Ŀ��Դ�ǳ����죬�ǳ�����Ͷ�ʼ�ֵ��";
                    else
                        ZQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQPJ#", ZQPJ);

                    #endregion

                    #region ��Ȩ����
                    //�г�ǰ���� #@TmpFeild-GQ1#<br />
                    //����ָ�꣺ #@TmpFeild-GQ2#<br />
                    //����ָ�꣺ #@TmpFeild-GQ3#<br />
                    //��Ŀ���գ� #@TmpFeild-GQ4#<br />
                    //��Ӫ���գ� #@TmpFeild-GQ5#<br />
                    //�ظ�ָ���� #@TmpFeild-GQ6#<br />
                    //��Ŀ���ۣ� #@TmpFeild-GQPJ#
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
                        GQPJ = "��Ŀ��Դ���ֺܲͶ�ʷ��վ޴�";
                    else if (GQ6 >= 40 && GQ6 < 60)
                        GQPJ = "��Ŀ��Դ�������ã�Ͷ�ʾ��нϴ�ķ��գ�";
                    else if (GQ6 >= 60 && GQ6 < 80)
                        GQPJ = "��Ŀ��Դ�������ã�����һ��Ͷ�ʼ�ֵ��";
                    else if (GQ6 >= 80)
                        GQPJ = "��Ŀ��Դ�ǳ����죬�ǳ�����Ͷ�ʼ�ֵ��";
                    else
                        GQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQPJ#", GQPJ);
                    #endregion


                    #endregion

                }
                #endregion

                #region ��ѵ�ģ��
                if (TempName.Trim() == ProjectTempFeeFileName)//��ѵ�ģ��
                {
                    TmpTmpSource = TmpSource;

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-InfoID#", InfoID);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectName#", CapitalName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CurrencyName#", CurrencyName);

                    if (string.IsNullOrEmpty(ProjectNameTotal) || ProjectNameTotal == "0")
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "");
                    else
                        TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectNameTotal#", "<tr><td class=\"h\">��Ͷ�ʣ�</td><td>" + ProjectNameTotal + "�� " + ProjectCurrencyName + "</td></tr>");

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

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ChangeOrFree#", "�����Դ");

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-FirstPic#", Pic1_r);

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyName#", ContractPersonCompanyName.Trim());

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);
                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-UserDetail#", UserDetail);

                    #region �ظ�ָ��

                    Tz888.BLL.TFZS.MainTarget tfzs = new Tz888.BLL.TFZS.MainTarget();

                    #region ծȨ����
                    //�쵼�Ŷӣ� #@TmpFeild-ZQ1#<br />
                    //�г�ǰ���� #@TmpFeild-ZQ2#<br />
                    //ӯ��ģʽ�� #@TmpFeild-ZQ3#<br />
                    //����ָ�꣺ #@TmpFeild-ZQ4#<br />
                    //���տ��ƣ� #@TmpFeild-ZQ5#<br />
                    //�ظ�ָ���� #@TmpFeild-ZQ6#<br />
                    //��Ŀ���ۣ� #@TmpFeild-ZQPJ#

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
                        ZQPJ = "��Ŀ��Դ���ֺܲͶ�ʷ��վ޴�";
                    else if (ZQ6 >= 40 && ZQ6 < 60)
                        ZQPJ = "��Ŀ��Դ�������ã�Ͷ�ʾ��нϴ�ķ��գ�";
                    else if (ZQ6 >= 60 && ZQ6 < 80)
                        ZQPJ = "��Ŀ��Դ�������ã�����һ��Ͷ�ʼ�ֵ��";
                    else if (ZQ6 >= 80)
                        ZQPJ = "��Ŀ��Դ�ǳ����죬�ǳ�����Ͷ�ʼ�ֵ��";
                    else
                        ZQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ZQPJ#", ZQPJ);

                    #endregion

                    #region ��Ȩ����
                    //�г�ǰ���� #@TmpFeild-GQ1#<br />
                    //����ָ�꣺ #@TmpFeild-GQ2#<br />
                    //����ָ�꣺ #@TmpFeild-GQ3#<br />
                    //��Ŀ���գ� #@TmpFeild-GQ4#<br />
                    //��Ӫ���գ� #@TmpFeild-GQ5#<br />
                    //�ظ�ָ���� #@TmpFeild-GQ6#<br />
                    //��Ŀ���ۣ� #@TmpFeild-GQPJ#
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
                        GQPJ = "��Ŀ��Դ���ֺܲͶ�ʷ��վ޴�";
                    else if (GQ6 >= 40 && GQ6 < 60)
                        GQPJ = "��Ŀ��Դ�������ã�Ͷ�ʾ��нϴ�ķ��գ�";
                    else if (GQ6 >= 60 && GQ6 < 80)
                        GQPJ = "��Ŀ��Դ�������ã�����һ��Ͷ�ʼ�ֵ��";
                    else if (GQ6 >= 80)
                        GQPJ = "��Ŀ��Դ�ǳ����죬�ǳ�����Ͷ�ʼ�ֵ��";
                    else
                        GQPJ = "--";

                    TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GQPJ#", GQPJ);
                    #endregion


                    #endregion

                }
                #endregion

                #endregion

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
        /// CreateStaticPageProject_V3 ��copy,��ҳ���ϵ��õ��Ǹ÷���,�·����ĳ���CreateStaticPageProject_V3,����ҳ�治�����Ķ�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="UpdateMsg"></param>
        /// <returns></returns>
        public bool CreateStaticPageProject(string InfoID, ref string UpdateMsg)
        {

            #region ��������

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString();//��̬ҳ��ĸ�Ŀ¼
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString();                //ͼƬ����
            string TempProjectZQ_V3 = "Template/Temp_Info_V3/Temp_Project_Zq_V3.htm";
            string TempProjectGQ_V3 = "Template/Temp_Info_V3/Temp_Project_Gq_V3.htm";

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            string OutPutFilePath = "";
            StreamWriter swOutPut;
            long HaveDoneCount = 0;
            string TmpTmpSource = "";
            byte AuditingStatus;
            string loginName = "";
            string CooperationDemandType = "";  //���ʷ�ʽ
            bool IsCheck = false;               //�Ƿ���֤��Դ
            string HtmlFile = "";
            string TmpFileName;                 //ģ�������λ��

            ProjectSetModel TheProject = new ProjectSetModel();
            TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheProject.ProjectInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheProject.MainInfoModel.HtmlFile;
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheProject.MainInfoModel.LoginName);
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            string TempName = (CooperationDemandType.Trim() == "9" ? TempProjectZQ_V3 : TempProjectGQ_V3);  //��ȡģ������
            string ProjectInfoType = (CooperationDemandType.Trim() == "9" ? "ZQ" : "GQ");                   //������Ϣ���GQ&ZQ
            if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = true; //��֤��Դģ��
            }
            #endregion


            #region ��ȡģ������

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

            if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheProject.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheProject.ProjectInfoModel.ProjectName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheProject.MainInfoModel.publishT.ToShortDateString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheProject.MainInfoModel.HtmlFile.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", TheProject.MainInfoModel.Descript.ToString());

            string IndustryName = "";   //��������ҵ
            foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

            string financingName = "��δ�ṩ";  //���ʶ���
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

            string AreaName = "";       //Ͷ������
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

            string CapitalTotal = "��δ�ṩ";       //��Ŀ��Ͷ��
            if (TheProject.ProjectInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);

            string cZqXmlxqkb = TheProject.ProjectInfoModel.cZqXmlxqkb.ToString();
            cZqXmlxqkb = cZqXmlxqkb.Replace("1", "ȱ����Ŀ����");
            cZqXmlxqkb = cZqXmlxqkb.Replace("2", "ȱ����Ŀ����ִ��");
            cZqXmlxqkb = cZqXmlxqkb.Replace("3", "ȱ����Ŀ����֤");
            cZqXmlxqkb = cZqXmlxqkb.Replace("4", "��Ŀ������ȫ");
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqXmlxqkb#", cZqXmlxqkb);//��Ŀ�������

            string cZqQyfzjd = "";      //��ҵ��չ�׶�
            switch (TheProject.ProjectInfoModel.cZqQyfzjd.ToString().Trim())
            {
                case "1": cZqQyfzjd = "������"; break;
                case "2": cZqQyfzjd = "������"; break;
                case "3": cZqQyfzjd = "�ɳ���"; break;
                case "4": cZqQyfzjd = "������"; break;
                case "5": cZqQyfzjd = "Pro-IPO"; break;
                case "6": cZqQyfzjd = "�ȶ���"; break;
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqQyfzjd#", cZqQyfzjd.ToString()); //��ҵ��չ�׶�

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", TheProject.MainInfoModel.MainPointCount.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", TheProject.MainInfoModel.ValidateTerm.ToString());
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(InfoID).ToString());

            string _IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                "����Դδ�����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>����֤��Դ����ʵ��</span>��";  //������֤��Դ
            if (IsCheck)
            {
                _IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "����Դ�Ѿ����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>��֤��Դ����ʵ��</span>��";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", _IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheProject));

            string userDomain = GetSelfDomain(TheProject.MainInfoModel.LoginName.Trim());  //չ�� �û�����
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
                string capitalName = "����";            //���
                if (TheProject.ProjectInfoModel.CapitalID.Trim() != "0")
                {
                    capitalName = TheProject.ProjectInfoModel.CapitalName.Trim() + "Ԫ�����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqZcfzl#", TheProject.ProjectInfoModel.iZqZcfzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzsl#", TheProject.ProjectInfoModel.iZqTzsl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpsczzl#", TheProject.ProjectInfoModel.iZqCpsczzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpscYl#", TheProject.ProjectInfoModel.iZqCpscYl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYdbl#", TheProject.ProjectInfoModel.iZqYdbl.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqXslyl#", TheProject.ProjectInfoModel.iZqXslyl.ToString());

                string iZqYqjjdwqk = "";      //Ҫ���ʽ�λ���
                switch (TheProject.ProjectInfoModel.iZqYqjjdwqk.ToString().Trim())
                {
                    case "1": iZqYqjjdwqk = "�ʽ�һ����"; break;
                    case "2": iZqYqjjdwqk = "�ʽ�ֲ�ʵʩ"; break;
                    case "3": iZqYqjjdwqk = "����"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYqjjdwqk#", iZqYqjjdwqk.ToString());

                string iZqTzfbq = "";           //��ĿͶ�ʻر�����
                switch (TheProject.ProjectInfoModel.iZqTzfbq.ToString().Trim())
                {
                    case "0":
                    case "1": iZqTzfbq = "��3��"; break;
                    case "2": iZqTzfbq = "3-5��"; break;
                    case "3": iZqTzfbq = "5-7��"; break;
                    case "4": iZqTzfbq = "7-10��"; break;
                    case "5": iZqTzfbq = ">10��"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzfbq#", iZqTzfbq.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheProject.ProjectInfoModel.warrant.ToString());
            }
            else
            {
                string financingAmount = "";    //Ҫ���ʽ�λ���
                switch (TheProject.ProjectInfoModel.financingAmount.ToString().Trim())
                {
                    case "0": financingAmount = "����"; break;
                    case "1": financingAmount = "500������"; break;
                    case "2": financingAmount = "500-2000��"; break;
                    case "3": financingAmount = "2000��-1��"; break;
                    case "4": financingAmount = "1-10��"; break;
                    case "5": financingAmount = "10������"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-financingAmount#", financingAmount.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", TheProject.ProjectInfoModel.SellStockShare.ToString());

                string returnModelStr = "����";
                if (TheProject.ProjectInfoModel.ReturnModeID != null && TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim() != "")   //�˳���ʽ
                {
                    returnModelStr = TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim();
                    returnModelStr = returnModelStr.Replace("1", "��Ȩת");
                    returnModelStr = returnModelStr.Replace("2", "IPO(��������)");
                    returnModelStr = returnModelStr.Replace("3", "�ع�");
                    returnModelStr = returnModelStr.Replace("4", "����");
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnmodeID#", returnModelStr.ToString());

                string iYqzjdwqk = "";      //Ҫ���ʽ�λ���
                switch (TheProject.ProjectInfoModel.iYqzjdwqk.ToString().Trim())
                {
                    case "1": iYqzjdwqk = "�ʽ�һ����"; break;
                    case "2": iYqzjdwqk = "�ʽ�ֲ�ʵʩ"; break;
                    case "3": iYqzjdwqk = "����"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-yqzjdwqk#", iYqzjdwqk.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Hysczzl#", TheProject.ProjectInfoModel.iHysczzl.ToString());

                string hbzq = "";           //��ĿͶ�ʻر�����
                switch (TheProject.ProjectInfoModel.iXmtzfbzq.ToString().Trim())
                {
                    case "0":
                    case "1": hbzq = "��3��"; break;
                    case "2": hbzq = "3-5��"; break;
                    case "3": hbzq = "5-7��"; break;
                    case "4": hbzq = "7-10��"; break;
                    case "5": hbzq = ">10��"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-xmtzfbzq#", hbzq.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Sczylfy#", TheProject.ProjectInfoModel.iSczylfy.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Zcfzl#", TheProject.ProjectInfoModel.iZcfzl.ToString());
            }

            #endregion


            #region ����ļ�

            OutPutFilePath = ApplicationRootPath + HtmlFile;
            if (!Common.BulidFolder(OutPutFilePath, true))      //���·���Ƿ���ȷ
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
        }
        #endregion


        #region ��ģ�徲̬ҳ��
        public bool CreateStaticPageProject_New(string InfoID, ref string UpdateMsg)
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
            string TempProjectPath = ConfigurationManager.AppSettings["ProjectTmpPath"].ToString(); //����ģ��Ĵ��λ��
            //Ŀ��·��
            string TempProjectPathTo = ConfigurationManager.AppSettings["ProjectTmpPathTo"].ToString(); //����ģ�����ɴ��λ��
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString(); //ͼƬ����

            string CooperationDemandType = "";//���ʷ�ʽ
            bool IsCheck = false;//�Ƿ���֤��Դ
            string HtmlFile = "";

            ProjectSetModel TheProject = new ProjectSetModel();

            TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheProject.ProjectInfoModel.CooperationDemandType.ToString().Trim();

            HtmlFile = TheProject.MainInfoModel.HtmlFile;
            #endregion


            #region ��ȡģ������
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
                //��ͨ�û�ģ��
                if (CooperationDemandType.Trim() == "9")//ծȯ����
                {
                    TempName = Project_ZQ;
                }
                else
                {
                    TempName = Project_GQ;
                }
            }


            #endregion

            #region ��֤��־
            if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
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

            if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheProject.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheProject.ProjectInfoModel.ProjectName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheProject.MainInfoModel.publishT.ToShortDateString());
            //�û����
            if (TempName == Project_GQ || TempName == Project_ZQ)
            {
                string ManageTypeName = ""; //�������
                string ManageTypeID = this.GetManageType(TheProject.MainInfoModel.LoginName.Trim()).Trim();
                string strTopfo = "��ͨ";
                string memberType = "��Ŀ��";
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
                    string u = "http://" + userDomain + ".co.topfo.com";
                    webUrl = "<a target='_blank' href='" + u + "')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";

                }
                //else
                //{
                //    webUrl = "<a href='javascript:alert('��δ����չ��...')'><img src='/images/huiy_23.jpg' width='206' height='30' style='ursor: hand' /></a>";
                //}
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SelfWeb#", webUrl);
                ManageTypeName = strTopfo + memberType;
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTypeName#", ManageTypeName);

            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-GradeID#", UserGradeTypeID.Trim());
            //��������ҵ
            string IndustryName = "";
            foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);
            //Ͷ������
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
            //��Ч����
            string endDate = "";
            endDate = TheProject.MainInfoModel.ValidateStartTime.AddMonths(TheProject.MainInfoModel.ValidateTerm).ToShortDateString();
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValiDate#", endDate);
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ComAbout#", TheProject.ProjectInfoModel.ComAbout);
            string capitalName = "����";
            if (TheProject.ProjectInfoModel.CapitalID.Trim()!="0")
            {
                capitalName = TheProject.ProjectInfoModel.CapitalName.Trim() + "Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);//���

            string CapitalTotal = "��δ�ṩ";
            if (TheProject.ProjectInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);//��Ŀ��Ͷ��
            string marketAbout = "��δ�ṩ";
            if( TheProject.ProjectInfoModel.marketAbout.Trim()!="")
            {
                marketAbout = TheProject.ProjectInfoModel.marketAbout.Trim();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MarketAbout#", marketAbout);//�г�����
            Tz888.BLL.Conn dal = new Conn();
            string financingID = "0";
            string financingName = "��δ�ṩ";
            if (TheProject.ProjectInfoModel.financingID!=null && TheProject.ProjectInfoModel.financingID.ToString().Trim() != "")
            {
                financingID = TheProject.ProjectInfoModel.financingID.ToString();
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
            string UserEvaluation = "δ����";
            if (TheProject.MainInfoModel.UserEvaluation.ToString() != "" && TheProject.MainInfoModel.UserEvaluation != 0)
            {
                UserEvaluation = TheProject.MainInfoModel.UserEvaluation.ToString();
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-TopFoZS#", UserEvaluation);//TFָ�� 

            #region ծȯ��������
            //if (CooperationDemandType.Trim().IndexOf("10")==-1)
            //{
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheProject.ProjectInfoModel.warrant.ToString());
                string CompanyYearIncome = "��δ�ṩ";
                if (TheProject.ProjectInfoModel.CompanyYearIncome != 0 && TheProject.ProjectInfoModel.CompanyYearIncome.ToString() != "")
                {
                    CompanyYearIncome = TheProject.ProjectInfoModel.CompanyYearIncome.ToString("0.00") + "��Ԫ�����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyYearIncome#", CompanyYearIncome);
                string CompanyNG = "��δ�ṩ";
                if (TheProject.ProjectInfoModel.CompanyNG != 0 && TheProject.ProjectInfoModel.CompanyNG.ToString() != "")
                {
                    CompanyNG = TheProject.ProjectInfoModel.CompanyNG.ToString("0.00") + "��Ԫ�����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyNG#", CompanyNG);
                string CompanyTotalCapital = "��δ�ṩ";
                if (TheProject.ProjectInfoModel.CompanyTotalCapital != 0 && TheProject.ProjectInfoModel.CompanyTotalCapital.ToString() != "")
                {
                    CompanyTotalCapital = TheProject.ProjectInfoModel.CompanyTotalCapital.ToString("0.00") + "��Ԫ�����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalCapital#", CompanyTotalCapital);
                string CompanyTotalDebet = "��δ�ṩ";
                if (TheProject.ProjectInfoModel.CompanyTotalDebet != 0 && TheProject.ProjectInfoModel.CompanyTotalDebet.ToString() != "")
                {
                    CompanyTotalDebet = TheProject.ProjectInfoModel.CompanyTotalDebet.ToString("0.00") + "��Ԫ�����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompanyTotalDebet#", CompanyTotalDebet);
            //}
            #endregion

            #region ��Ȩ��������
            //else//CooperationDemandType.Trim().Contains("10")
            //{
                string ReturnMode = TheProject.ProjectInfoModel.ReturnModeID;
                string ReturnModeName = "��δ�ṩ";
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
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnModel#", ReturnModeName);//�˳���ʽ
                string SellStockShare = "��δ�ṩ";
                if (TheProject.ProjectInfoModel.SellStockShare != 0 || TheProject.ProjectInfoModel.SellStockShare.ToString() == "")
                {
                    SellStockShare = TheProject.ProjectInfoModel.SellStockShare.ToString()+"%";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", SellStockShare);//���ùɷ�
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ProjectAbout#", TheProject.ProjectInfoModel.ProjectAbout == "" ? "��δ�ṩ" : TheProject.ProjectInfoModel.ProjectAbout);//��Ʒ����
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-competitioAbout#", TheProject.ProjectInfoModel.competitioAbout == "" ? "��δ�ṩ" : TheProject.ProjectInfoModel.competitioAbout);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BussinessModeAbout#", TheProject.ProjectInfoModel.BussinessModeAbout == "" ? "��δ�ṩ" : TheProject.ProjectInfoModel.BussinessModeAbout);
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ManageTeamAbout#", TheProject.ProjectInfoModel.ManageTeamAbout == "" ? "��δ�ṩ" : TheProject.ProjectInfoModel.ManageTeamAbout);
            //}
            #endregion

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheProject.MainInfoModel.HtmlFile.Trim());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PID#", TheProject.ProjectInfoModel.ProvinceID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CID#", TheProject.ProjectInfoModel.CityID.Trim());//
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-XID#", TheProject.ProjectInfoModel.CountyID.Trim());
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


        #region ͨ��InfoID��ȡһ����Ϣʵ��
        /// <summary>
        /// ͨ��InfoID��ȡһ��Project����Ϣʵ��
        /// </summary>
        /// <returns></returns>
        public ProjectSetModel objGetProjectInfoByInfoID(long InfoID)
        {

            ProjectSetModel TheProjectInfo = new ProjectSetModel();
            TheProjectInfo = dal.GetIntegrityModel(InfoID);
            return TheProjectInfo;
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
            return lbll.GetManageTypeID(loginName).Trim();
        }

        #endregion


        #region ģ��V3�����ɾ�̬ҳ��

        public bool CreateStaticPageProject_V3(string InfoID, ref string UpdateMsg)
        {
        
            #region ��������

            string ApplicationRootPath = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString();//��̬ҳ��ĸ�Ŀ¼
            string ImageDomain = ConfigurationManager.AppSettings["ImageDomain"].ToString();                //ͼƬ����
            string TempProjectZQ_V3 = "Template/Temp_Info_V3/Temp_Project_Zq_V3.htm";
            string TempProjectGQ_V3 = "Template/Temp_Info_V3/Temp_Project_Gq_V3.htm";

            System.Text.StringBuilder sbUpdateMsg = new System.Text.StringBuilder();
            string OutPutFilePath = "";
            StreamWriter swOutPut;
            long HaveDoneCount = 0;
            string TmpTmpSource = "";
            byte AuditingStatus;
            string loginName = "";
            string CooperationDemandType = "";  //���ʷ�ʽ
            bool IsCheck = false;               //�Ƿ���֤��Դ
            string HtmlFile = "";
            string TmpFileName;                 //ģ�������λ��

            ProjectSetModel TheProject = new ProjectSetModel();
            TheProject = this.objGetProjectInfoByInfoID(long.Parse(InfoID.Trim()));
            CooperationDemandType = TheProject.ProjectInfoModel.CooperationDemandType.ToString().Trim();
            HtmlFile = TheProject.MainInfoModel.HtmlFile;
            Tz888.SQLServerDAL.LoginInfo.LoginInfo login = new Tz888.SQLServerDAL.LoginInfo.LoginInfo();
            DataTable dt_login = login.GetLoginInfo(TheProject.MainInfoModel.LoginName);
            Tz888.SQLServerDAL.Info.InfoResourceDAL attachmentbll = new Tz888.SQLServerDAL.Info.InfoResourceDAL();
            string TempName = (CooperationDemandType.Trim() == "9" ? TempProjectZQ_V3 : TempProjectGQ_V3);  //��ȡģ������
            string ProjectInfoType = (CooperationDemandType.Trim() == "9" ? "ZQ" : "GQ");                   //������Ϣ���GQ&ZQ
            if ((Convert.ToInt32(TheProject.MainInfoModel.FixPriceID) > 1 && TheProject.MainInfoModel.MainPointCount > 0)
                || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(TheProject.MainInfoModel.InfoOriginRoleName) == 2)
            {
                IsCheck = true; //��֤��Դģ��
            }
            #endregion


            #region ��ȡģ������

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

            if (TheProject.ProjectInfoModel == null || TheProject.ProjectInfoModel.InfoID <= 0)
            {
                sbUpdateMsg.Append("[E]û���ҵ�����Ϣ" + InfoID + "<br>");
                UpdateMsg = sbUpdateMsg.ToString();
                return false;
            }

            loginName = TheProject.MainInfoModel.LoginName.Trim();

            Tz888.BLL.Register.LoginInfoBLL logionInfoBLL = new Tz888.BLL.Register.LoginInfoBLL();
            string MemberGradeID = logionInfoBLL.GetMemberGradeID(loginName).Trim();

            AuditingStatus = (byte)TheProject.MainInfoModel.AuditingStatus;
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
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Title#", TheProject.ProjectInfoModel.ProjectName.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-PublishT#", TheProject.MainInfoModel.publishT.ToShortDateString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MemberGradeID#", MemberGradeID.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-HtmlFile#", TheProject.MainInfoModel.HtmlFile.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Descript#", TheProject.MainInfoModel.Descript.ToString()); 

            string IndustryName = "";   //��������ҵ
            foreach (string sTempIndustry in TheProject.ProjectInfoModel.IndustryBName)
            {
                IndustryName += sTempIndustry.Trim() + " ";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IndustryName#", IndustryName);

            string financingName = "��δ�ṩ";  //���ʶ���
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

            string AreaName = "";       //Ͷ������
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

            string CapitalTotal = "��δ�ṩ";       //��Ŀ��Ͷ��
            if (TheProject.ProjectInfoModel.CapitalTotal.ToString() != "0")
            {
                CapitalTotal = TheProject.ProjectInfoModel.CapitalTotal.ToString("0.00") + "��Ԫ�����";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalTotal#", CapitalTotal);

            string cZqXmlxqkb = TheProject.ProjectInfoModel.cZqXmlxqkb.ToString();
            cZqXmlxqkb = cZqXmlxqkb.Replace("1", "ȱ����Ŀ����");
            cZqXmlxqkb = cZqXmlxqkb.Replace("2", "ȱ����Ŀ����ִ��");
            cZqXmlxqkb = cZqXmlxqkb.Replace("3", "ȱ����Ŀ����֤");
            cZqXmlxqkb = cZqXmlxqkb.Replace("4", "��Ŀ������ȫ"); 
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqXmlxqkb#", cZqXmlxqkb);//��Ŀ�������

            string cZqQyfzjd = "";      //��ҵ��չ�׶�
            switch (TheProject.ProjectInfoModel.cZqQyfzjd.ToString().Trim())
            {
                case "1": cZqQyfzjd = "������"; break;
                case "2": cZqQyfzjd = "������"; break;
                case "3": cZqQyfzjd = "�ɳ���"; break;
                case "4": cZqQyfzjd = "������"; break;
                case "5": cZqQyfzjd = "Pro-IPO"; break;
                case "6": cZqQyfzjd = "�ȶ���"; break;
            } 
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-cZqQyfzjd#", cZqQyfzjd.ToString()); //��ҵ��չ�׶�

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-MainPointCount#", TheProject.MainInfoModel.MainPointCount.ToString());
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ValidatePeriod#", TheProject.MainInfoModel.ValidateTerm.ToString());
            //TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-BuyerRating#", getBuyerRatingById(InfoID).ToString());

            string _IsCheck = "<img src='/CommonV3/img/res3_icon40.gif' /><br />" +
                "����Դδ�����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>����֤��Դ����ʵ��</span>��";  //������֤��Դ
            if (IsCheck)
            {
                _IsCheck = "<img src='/CommonV3/img/res3_icon4.gif' /><br />" +
                    "����Դ�Ѿ����й�����Ͷ������ʵ��֤<br />����<span class='f_org strong'>��֤��Դ����ʵ��</span>��";
            }
            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-IsCheck#", _IsCheck);

            TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CompleteDegree#", getCompleteDegreeById(TheProject));

            string userDomain = GetSelfDomain(TheProject.MainInfoModel.LoginName.Trim());  //չ�� �û�����
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
                string capitalName = "����";            //���
                if (TheProject.ProjectInfoModel.CapitalID.Trim() != "0")
                {
                    capitalName = TheProject.ProjectInfoModel.CapitalName.Trim() + "Ԫ�����";
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-CapitalID#", capitalName);

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqZcfzl#", TheProject.ProjectInfoModel.iZqZcfzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzsl#", TheProject.ProjectInfoModel.iZqTzsl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpsczzl#", TheProject.ProjectInfoModel.iZqCpsczzl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqCpscYl#", TheProject.ProjectInfoModel.iZqCpscYl.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYdbl#", TheProject.ProjectInfoModel.iZqYdbl.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqXslyl#", TheProject.ProjectInfoModel.iZqXslyl.ToString());

                string iZqYqjjdwqk = "";      //Ҫ���ʽ�λ���
                switch (TheProject.ProjectInfoModel.iZqYqjjdwqk.ToString().Trim())
                {
                    case "1": iZqYqjjdwqk = "�ʽ�һ����"; break;
                    case "2": iZqYqjjdwqk = "�ʽ�ֲ�ʵʩ"; break;
                    case "3": iZqYqjjdwqk = "����"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqYqjjdwqk#", iZqYqjjdwqk.ToString());

                string iZqTzfbq = "";           //��ĿͶ�ʻر�����
                switch (TheProject.ProjectInfoModel.iZqTzfbq.ToString().Trim())
                {
                    case "0":
                    case "1": iZqTzfbq = "��3��"; break;
                    case "2": iZqTzfbq = "3-5��"; break;
                    case "3": iZqTzfbq = "5-7��"; break;
                    case "4": iZqTzfbq = "7-10��"; break;
                    case "5": iZqTzfbq = ">10��"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-iZqTzfbq#", iZqTzfbq.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Warrant#", TheProject.ProjectInfoModel.warrant.ToString());
            }
            else
            {
                string financingAmount = "";    //Ҫ���ʽ�λ���
                switch (TheProject.ProjectInfoModel.financingAmount.ToString().Trim())
                {
                    case "0": financingAmount = "����"; break;
                    case "1": financingAmount = "500������"; break;
                    case "2": financingAmount = "500-2000��"; break;
                    case "3": financingAmount = "2000��-1��"; break;
                    case "4": financingAmount = "1-10��"; break;
                    case "5": financingAmount = "10������"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-financingAmount#", financingAmount.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-SellStockShare#", TheProject.ProjectInfoModel.SellStockShare.ToString());

                string returnModelStr = "����";
                if (TheProject.ProjectInfoModel.ReturnModeID != null && TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim() != "")   //�˳���ʽ
                {
                    returnModelStr = TheProject.ProjectInfoModel.ReturnModeID.ToString().Trim();
                    returnModelStr = returnModelStr.Replace("1", "��Ȩת");
                    returnModelStr = returnModelStr.Replace("2", "IPO(��������)");
                    returnModelStr = returnModelStr.Replace("3", "�ع�");
                    returnModelStr = returnModelStr.Replace("4", "����");
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-ReturnmodeID#", returnModelStr.ToString());

                string iYqzjdwqk = "";      //Ҫ���ʽ�λ���
                switch (TheProject.ProjectInfoModel.iYqzjdwqk.ToString().Trim())
                {
                    case "1": iYqzjdwqk = "�ʽ�һ����"; break;
                    case "2": iYqzjdwqk = "�ʽ�ֲ�ʵʩ"; break;
                    case "3": iYqzjdwqk = "����"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-yqzjdwqk#", iYqzjdwqk.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Hysczzl#", TheProject.ProjectInfoModel.iHysczzl.ToString());

                string hbzq = "";           //��ĿͶ�ʻر�����
                switch (TheProject.ProjectInfoModel.iXmtzfbzq.ToString().Trim())
                {
                    case "0": 
                    case "1": hbzq = "��3��"; break;
                    case "2": hbzq = "3-5��"; break;
                    case "3": hbzq = "5-7��"; break;
                    case "4": hbzq = "7-10��"; break;
                    case "5": hbzq = ">10��"; break;
                }
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-xmtzfbzq#", hbzq.ToString());

                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Sczylfy#", TheProject.ProjectInfoModel.iSczylfy.ToString());
                TmpTmpSource = TmpTmpSource.Replace("#@TmpFeild-Zcfzl#", TheProject.ProjectInfoModel.iZcfzl.ToString());
            }

            #endregion


            #region ����ļ�

            OutPutFilePath = ApplicationRootPath + HtmlFile;
            if (!Common.BulidFolder(OutPutFilePath, true))      //���·���Ƿ���ȷ
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
        }

        #endregion


        #region ����Դ��Ϣ������(�ٷֱ�)

        public string getCompleteDegreeById(ProjectSetModel model)
        {
            int degree = 0;

            if (model.ProjectInfoModel.CooperationDemandType == "9")//ծȯ
            {
                degree = 35;
                if (model.ProjectInfoModel.iZqTzfbq != null && model.ProjectInfoModel.iZqTzfbq.ToString() != "")   //��ĿͶ�ʻر���
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.iZqYdbl != null && model.ProjectInfoModel.iZqYdbl.ToString() != "")   //��������
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.iZqXslyl != null && model.ProjectInfoModel.iZqXslyl.ToString() != "") //����������
                {
                    degree += 2;
                }
                if (model.ProjectInfoModel.nDwlyysy != null && model.ProjectInfoModel.nDwlyysy.ToString().Trim() != "") //��λ��Ӫҵ����
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwljly != null && model.ProjectInfoModel.nDwljly.ToString().Trim() != "") //��λ�꾻����
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzzc != null && model.ProjectInfoModel.nDwzzc.ToString().Trim() != "") //��λ���ʲ�
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzfz != null && model.ProjectInfoModel.nDwzfz.ToString().Trim() != "") //��λ�ܸ�ծ
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.ComAbout != null && model.ProjectInfoModel.ComAbout.ToString().Trim() != "") //��Ʒ����
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqXmlxqkb != null && model.ProjectInfoModel.cZqXmlxqkb.ToString().Trim() != "") //�г�ǰ��
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqJzfx != null && model.ProjectInfoModel.cZqJzfx.ToString().Trim() != "") //��������
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqSyms != null && model.ProjectInfoModel.cZqSyms.ToString().Trim() != "") //��ҵģʽ
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqGltd != null && model.ProjectInfoModel.cZqGltd.ToString().Trim() != "") //�����Ŷ�
                {
                    degree += 6;
                }
                if (model.InfoResourceModels != null && model.InfoResourceModels.Count > 0) //��Ŀ���ϸ���
                {
                    degree += 10;
                }
                if (model.InfoContactModel.TelNum != null && model.InfoContactModel.TelNum.ToString().Trim() != "" || model.InfoContactModel.Mobile.ToString().Trim() != "") //��ϵ�绰
                {
                    degree += 2;
                }
                if (model.InfoContactModel.Name != null && model.InfoContactModel.Name.ToString().Trim() != "") //��Ŀ��λ����
                {
                    degree += 2;
                }
                if (model.InfoContactModel.Email != null && model.InfoContactModel.Email.ToString().Trim() != "") //��������
                {
                    degree += 1;
                }
                if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.ToString().Trim() != "") //��Ŀ��λ��ϸ��ַ
                {
                    degree += 1;
                }
                if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.ToString().Trim() != "") //��Ŀ��λ��ַ
                {
                    degree += 1;
                }

            }
            else//��Ȩ
            {
                degree = 35;
                if (model.ProjectInfoModel.iZqTzfbq != null && model.ProjectInfoModel.iZqTzfbq.ToString() != "")   //��ĿͶ�ʻر���
                {
                    degree += 2;
                }
                if (model.MainInfoModel.KeyWord != null && model.MainInfoModel.KeyWord.ToString() != "")   //��Ŀ�ؼ���
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.nDwlyysy != null && model.ProjectInfoModel.nDwlyysy.ToString() != "")   //��Ŀ�ؼ���
                {
                    degree += 1;
                }
                if (model.ProjectInfoModel.nDwlyysy != null && model.ProjectInfoModel.nDwlyysy.ToString().Trim() != "") //��λ��Ӫҵ����
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwljly != null && model.ProjectInfoModel.nDwljly.ToString().Trim() != "") //��λ�꾻����
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzzc != null && model.ProjectInfoModel.nDwzzc.ToString().Trim() != "") //��λ���ʲ�
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.nDwzfz != null && model.ProjectInfoModel.nDwzfz.ToString().Trim() != "") //��λ�ܸ�ծ
                {
                    degree += 3;
                }
                if (model.ProjectInfoModel.ComAbout != null && model.ProjectInfoModel.ComAbout.ToString().Trim() != "") //��Ʒ����
                {
                    degree += 8;
                }
                if (model.ProjectInfoModel.cZqXmlxqkb != null && model.ProjectInfoModel.cZqXmlxqkb.ToString().Trim() != "") //�г�ǰ��
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqJzfx != null && model.ProjectInfoModel.cZqJzfx.ToString().Trim() != "") //��������
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqSyms != null && model.ProjectInfoModel.cZqSyms.ToString().Trim() != "") //��ҵģʽ
                {
                    degree += 6;
                }
                if (model.ProjectInfoModel.cZqGltd != null && model.ProjectInfoModel.cZqGltd.ToString().Trim() != "") //�����Ŷ�
                {
                    degree += 6;
                }
                if (model.InfoResourceModels != null && model.InfoResourceModels.Count > 0) //��Ŀ���ϸ���
                {
                    degree += 10;
                }
                if (model.InfoContactModel.Position != null && model.InfoContactModel.Position.ToString().Trim() != "") //ְλ
                {
                    degree += 1;
                }
                if (model.InfoContactModel.Address != null && model.InfoContactModel.Address.ToString().Trim() != "") //��Ŀ��λ��ϸ��ַ
                {
                    degree += 1;
                }
                if (model.InfoContactModel.WebSite != null && model.InfoContactModel.WebSite.ToString().Trim() != "") //��Ŀ��λ��ַ
                {
                    degree += 1;
                }
            }

            return degree.ToString() + "%";
        }

        #endregion

    }
}
