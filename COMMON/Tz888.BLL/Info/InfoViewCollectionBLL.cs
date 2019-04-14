using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class InfoViewCollectionBLL
    {
        private readonly IInfoViewCollection dal = DataAccess.CreateInfoViewCollection();

        #region-- 查看该资源的用户 --------------
        /// <summary>
        /// 查看该资源的用户
        /// </summary>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageRows">每页取的记录条数</param>
        /// <param name="PageCount">总记录</param>
        /// <returns></returns>
        public DataTable GetViewLoginName(
            long InfoID,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            PageCount = 0;

            return (dal.GetList(
                "*",
                "InfoID=" + InfoID + " AND DeleteStatus<>1",
                "CreateDate DESC,ID ASC",
                ref CurrentPage,
                PageRows,
                ref PageCount));
        }
        #endregion

        #region-- 收藏该资源的用户 --------------
        public DataTable GetSaveLoginName(
            string LoginName,
            long InfoID,
            ref long CurrentPage,
            long PageRows,
            out long PageCount)
        {
            PageCount = 0;
            return (dal.GetList(
                "*",
                "InfoID=" + InfoID + " AND IsCollect=1 AND DeleteStatus<>2",
                "CreateDate DESC,ID ASC",
                ref CurrentPage,
                PageRows,
                ref PageCount));
        }
        #endregion
    }
}
