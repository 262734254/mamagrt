using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL;
using System.Data;
namespace Tz888.BLL
{
    public class MerchantChanel
    {
        private readonly IMerchantChanel obj = DataAccess.CreateMerchantChanel();
        Conn dal = new Conn();
       /// <summary>
        /// 所有招商视频数量
       /// </summary>
       /// <returns></returns>
        public string GetVideoCount()
        {
            DataTable dt = dal.GetList("VideoInfoviw", "InfoID", "InfoID", 1, 1, 1, 1, "AuditingStatus=1");
            return dt.Rows[0].ItemArray[0].ToString();
        }
        /// <summary>
        /// 省招商视频数量
        /// </summary>
        /// <returns></returns>
        public string GetVideoCount(string provinceid)
        {
            DataTable dt = dal.GetList("VideoInfoviw", "InfoID", "InfoID", 1, 1, 1, 1, "AuditingStatus=1 and provinceid='" + provinceid + "'");
            return dt.Rows[0].ItemArray[0].ToString();
        }
        /// <summary>
        /// 所有图片数量
        /// </summary>
        /// <returns></returns>
        public string GetImageCount()
        {
            DataTable dt = dal.GetList("ImagesInfoviw", "InfoID", "InfoID", 1, 1, 1, 1, "AuditingStatus=1");
            return dt.Rows[0].ItemArray[0].ToString();
        }
        /// <summary>
        /// 省图片数量
        /// </summary>
        /// <param name="provinceid"></param>
        /// <returns></returns>
        public string GetImageCount(string provinceid)
        {
            DataTable dt = dal.GetList("ImagesInfoviw", "InfoID", "InfoID", 1, 1, 1, 1, "AuditingStatus=1 and provinceid='" + provinceid + "'");
            return dt.Rows[0].ItemArray[0].ToString();
        }
        /// <summary>
        /// 评论数
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public string GetCommentCount(long InfoID)
        {
            DataTable dt = dal.GetList("InfoCommentViw", "InfoID", "InfoID", 1, 1, 1, 1, "InfoID="+InfoID);
            return dt.Rows[0].ItemArray[0].ToString();
        }
        /// <summary>
        /// 收藏数
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public string GetFavCount(long InfoID)
        {
            DataTable dt = dal.GetList("InfoViewCollectionTab", "InfoID", "InfoID", 1, 1, 1, 1, "IsCollect=1 and InfoID=" + InfoID);
            return dt.Rows[0].ItemArray[0].ToString();
        }
        public DataTable GetRowNumList(string strWhere)
        {
            return obj.GetRowNumList(strWhere);
        }


    }
}
