using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using Tz888.Model.Info;
using System.Data;
using System.IO;
using System.Configuration;

namespace Tz888.BLL.Info
{
    public class Common
    {
        private static readonly ICommon dal = DataAccess.CreateInfo_Common();
         /// <summary>
        /// ��ȡ������Ŀ��������
        /// </summary>
        /// <returns>���������б�</returns>
        public static List<CooperationDemandTypeModel> GetCooperationDemandList(string InfoType)
        {
            return dal.GetCooperationDemandList(InfoType);
        }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        /// <returns></returns>
        public static List<Tz888.Model.Info.MerchantAttributeModel> GetMerchantAttributeList()
        {
            return dal.GetMerchantAttributeList();
        }

        /// <summary>
        /// ��ȡ��Ϣ��������Ӧ�Ĵ���
        /// </summary>
        /// <param name="InfoTypeID">��Ϣ����</param>
        /// <returns></returns>
        public static string GetInfoTypeCode(string InfoTypeID)
        {
            return dal.GetInfoTypeCode(InfoTypeID);
        }

        /// <summary>
        /// ����InfoCode
        /// </summary>
        /// <param name="InfoTypeID"></param>
        /// <param name="IndustryCode"></param>
        /// <param name="ZoneCode"></param>
        /// <param name="publishT"></param>
        /// <returns></returns>
        public static string CreateInfoCode(string InfoTypeID, string IndustryCode, string ZoneCode, DateTime publishT)
        {
            //�ʱ�I����ҵ���룫�������룫�������������գ�20050721����˳��ţ���λ0001-9999��
            //��ĿP����ҵ���룫�������룫�������������գ�20050721����˳��ţ���λ0001-9999��
            //�����Ϣǰ׺
            ICommon obj = DataAccess.CreateInfo_Common();
            string InfoTypeCode = obj.GetInfoTypeCode(InfoTypeID);

            return InfoTypeCode.Trim() + IndustryCode.Replace("*", "").Replace("#", "") + ZoneCode + publishT.Year.ToString()
                + publishT.Month.ToString("00") + publishT.Day.ToString("00");
        }

        /// <summary>
        /// �����ļ�·��
        /// </summary>
        /// <param name="InfoTypeID"></param>
        /// <param name="InfoCode"></param>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public static string createStaticPageFileName(string InfoTypeID, string InfoCode, long InfoID)
        {
            string prefix = "";
            DateTime theDate = DateTime.Now;

            return InfoTypeID + @"/" + theDate.Year.ToString("0000") + theDate.Month.ToString("00") + @"/" + InfoCode.Trim() + "_" + InfoID + ".shtml";
        }

        /// <summary>
        /// �����ļ�·��2
        /// </summary>
        /// <param name="InfoTypeID"></param>
        /// <param name="InfoCode"></param>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public static string createStaticPageFileName(string InfoTypeID, string InfoCode, long InfoID, DateTime theDate)
        {
            return InfoTypeID + @"/" + theDate.Year.ToString("0000") + theDate.Month.ToString("00") + @"/" + InfoCode.Trim() + "_" + InfoID + ".shtml";
        }


        #region ɾ��ָ���ļ��Ĳ��� --------------------------------------------------
        /// <summary>
        /// ɾ��ָ���ļ��Ĳ���
        /// </summary>
        /// <param name="htmlFilePath">��������Ŀ¼����վĿ¼��ַ</param>
        /// <returns></returns>
        public static bool DeleteWebFile(string htmlFilePath, ref string deleteMsg)
        {
            if (htmlFilePath == "")
            {
                deleteMsg = "�ļ���ַ�����޷�ɾ���ļ���";
                return false;
            }
            string ApplicationRoot = ConfigurationSettings.AppSettings["ApplicationRootPath"].ToString();
            if (ApplicationRoot == "")
            {
                deleteMsg = "ϵͳ���ô����������Ա��ϵ��";
                return false;
            }
            string TmpFilePath = ApplicationRoot + htmlFilePath;
            if (File.Exists(TmpFilePath))
            {
                File.Delete(TmpFilePath);
                deleteMsg = "�Ѿ�ɾ��ָ�����ļ� -- " + htmlFilePath;
                return true;
            }
            else
            {
                deleteMsg = "ϵͳ���ô����������Ա��ϵ��";
                return false;
            }

        }
        #endregion 


        #region ������Ϣ���ͷ���List
        /// <summary>
        /// ������Ϣ����ID����DataView
        /// </summary>
        /// <param name="infoTypeID"></param>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="OrderBy"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public static DataView GetListByInfoType(string infoTypeID,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            if (infoTypeID == "")
            {
                return null;
            }
            DataView dv = null;
            switch (infoTypeID.Trim())
            {
                case "Merchant":
                    Tz888.BLL.Info.MarchantInfoBLL obj6 = new MarchantInfoBLL();
                    dv = obj6.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
                    break;
                case "Capital":
                    Tz888.BLL.Info.CapitalInfoBLL obj12 = new CapitalInfoBLL();
                    dv = obj12.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
                    break;
                case "Project":
                    Tz888.BLL.Info.ProjectInfoBLL obj13 = new ProjectInfoBLL();
                    dv = obj13.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
                    break;
                default:
                    break;
            }
            return dv;
        }
        #endregion
    }
}
