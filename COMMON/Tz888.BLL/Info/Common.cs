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
        /// 获取所有项目合作类型
        /// </summary>
        /// <returns>合作类型列表</returns>
        public static List<CooperationDemandTypeModel> GetCooperationDemandList(string InfoType)
        {
            return dal.GetCooperationDemandList(InfoType);
        }

        /// <summary>
        /// 获取所有招商类型
        /// </summary>
        /// <returns></returns>
        public static List<Tz888.Model.Info.MerchantAttributeModel> GetMerchantAttributeList()
        {
            return dal.GetMerchantAttributeList();
        }

        /// <summary>
        /// 获取信息类型所对应的代码
        /// </summary>
        /// <param name="InfoTypeID">信息类型</param>
        /// <returns></returns>
        public static string GetInfoTypeCode(string InfoTypeID)
        {
            return dal.GetInfoTypeCode(InfoTypeID);
        }

        /// <summary>
        /// 创建InfoCode
        /// </summary>
        /// <param name="InfoTypeID"></param>
        /// <param name="IndustryCode"></param>
        /// <param name="ZoneCode"></param>
        /// <param name="publishT"></param>
        /// <returns></returns>
        public static string CreateInfoCode(string InfoTypeID, string IndustryCode, string ZoneCode, DateTime publishT)
        {
            //资本I＋行业代码＋地区代码＋发布日期年月日（20050721）＋顺序号（四位0001-9999）
            //项目P＋行业代码＋地区代码＋发布日期年月日（20050721）＋顺序号（四位0001-9999）
            //获得信息前缀
            ICommon obj = DataAccess.CreateInfo_Common();
            string InfoTypeCode = obj.GetInfoTypeCode(InfoTypeID);

            return InfoTypeCode.Trim() + IndustryCode.Replace("*", "").Replace("#", "") + ZoneCode + publishT.Year.ToString()
                + publishT.Month.ToString("00") + publishT.Day.ToString("00");
        }

        /// <summary>
        /// 生成文件路径
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
        /// 生成文件路径2
        /// </summary>
        /// <param name="InfoTypeID"></param>
        /// <param name="InfoCode"></param>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public static string createStaticPageFileName(string InfoTypeID, string InfoCode, long InfoID, DateTime theDate)
        {
            return InfoTypeID + @"/" + theDate.Year.ToString("0000") + theDate.Month.ToString("00") + @"/" + InfoCode.Trim() + "_" + InfoID + ".shtml";
        }


        #region 删除指定文件的操作 --------------------------------------------------
        /// <summary>
        /// 删除指定文件的操作
        /// </summary>
        /// <param name="htmlFilePath">不包含根目录的网站目录地址</param>
        /// <returns></returns>
        public static bool DeleteWebFile(string htmlFilePath, ref string deleteMsg)
        {
            if (htmlFilePath == "")
            {
                deleteMsg = "文件地址错误！无法删除文件！";
                return false;
            }
            string ApplicationRoot = ConfigurationSettings.AppSettings["ApplicationRootPath"].ToString();
            if (ApplicationRoot == "")
            {
                deleteMsg = "系统配置错误，请与管理员联系！";
                return false;
            }
            string TmpFilePath = ApplicationRoot + htmlFilePath;
            if (File.Exists(TmpFilePath))
            {
                File.Delete(TmpFilePath);
                deleteMsg = "已经删除指定的文件 -- " + htmlFilePath;
                return true;
            }
            else
            {
                deleteMsg = "系统配置错误，请与管理员联系！";
                return false;
            }

        }
        #endregion 


        #region 根据信息类型返回List
        /// <summary>
        /// 根据信息类型ID返回DataView
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
