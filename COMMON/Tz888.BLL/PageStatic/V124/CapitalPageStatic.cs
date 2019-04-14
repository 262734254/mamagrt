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
    /// Ͷ�ʾ�̬ҳ������
    /// </summary>
    public class CapitalPageStatic
    {
        //��֤��Դģ��·��
        private const string CapitalTempChangeFileName = "CapitalTemplateCharges.html";
        //��ͨ��Աģ��·��
        private const string CapitalTempFeeFileName = "CapitalTemplateFee.html";
        //�ظ�ͨ��Ա����·��
        private const string CapitalTempVipFileName = "CapitalTemplateVIP.html";

        //�����ļ������·��
        private const string CapitalTempEndFileTo = "";
        //ͼƬ·��
        private const string CapitalPicPath = "http://images.topfo.com/";
        //��Դ·��
        private const string CapitalResourcePath = "";

        private const string TagsUrl = "http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}";

        private const string TagslinkModel = "<a href=\"http://search.topfo.com/SearchResultCapital.aspx?KeywordUrl={0}\" target=\"_blank\">{1}</a>";

        private readonly ICapitalInfo dal = DataAccess.CreateCapitalInfo_V124();
       
        #region �����̬ҳ���ļ�
        /// <summary>
        /// ������̬ҳ��
        /// </summary>		
        /// <param name="InfoIDArr">��Ҫ���µ���ϢID�б�</param>
        
        /// <param name="UpdateMsg">�������־</param>
        /// <returns></returns>
        public bool CreateStaticPageCapital(string InfoID,ref string UpdateMsg)
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

                string CapitalName = "";    //�ʱ����
                string CurrencyName = ""; //��������

                string CapitalTypeName = "";//�ʱ�����:ֱͶ,����,����,����....            

                string CooperationTypeName = "";//Ͷ�ʷ�ʽ:�ʽ���,��ȨͶ��,���س���/����....
                List<string> lstCooperationTypeName = new List<string>();

                string AreaName;//Ͷ������

                string IndustryName = "";//������ҵ 
                List<string> lstIndustryName = new List<string>();

                string StageName;
                string JionManageName;

                string OrgIntro;
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
                    || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 1 || Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 2 ||
                    Convert.ToInt32(theCapital.MainInfoModel.InfoOriginRoleName) == 5)
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

                //Ͷ������
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
                    AreaName = "����";
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

                if (ManageType == "2005")
                {
                    ManageTypeName = "��Դ���˻�Ա";
                }
                else if (ManageType == "2004")
                {
                    ManageTypeName = "��Դ��֤����";
                }

                #endregion ������ֵ

                #region �滻ģ��

                #region Vip��ģ��
                if (TempName.Trim() == CapitalTempVipFileName)//Vipģ��
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

                #region �շѵ�ģ��
                if (TempName.Trim() == CapitalTempChangeFileName)//�շѵ�ģ��
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

                #region ��ѵ�ģ��
                if (TempName.Trim() == CapitalTempFeeFileName)//��ѵ�ģ��
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

    }
}
