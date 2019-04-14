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

        #region-- �鿴����Դ���û� --------------
        /// <summary>
        /// �鿴����Դ���û�
        /// </summary>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageRows">ÿҳȡ�ļ�¼����</param>
        /// <param name="PageCount">�ܼ�¼</param>
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

        #region-- �ղظ���Դ���û� --------------
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
