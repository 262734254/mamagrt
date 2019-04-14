using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Info;
using Tz888.DALFactory;

namespace Tz888.BLL.Info
{
    public class MatchInfoBLL
    {
        private readonly IMatchInfo dal = DataAccess.CreateMatchInfo();

        #region ����ƥ���б�
        /// <summary>
        /// ����ƥ���б�
        /// </summary>
        /// <param name="MatchType">ƥ������</param>
        /// <param name="InfoID">ƥ����ϢID</param>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        public DataView GetMatchList(
            string MatchType,
            long InfoID,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount)
        {
            return dal.GetMatchList(MatchType, InfoID, SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref TotalCount);
        }
        #endregion

        #region ͳ����Ϣƥ����Ŀ
        /// <summary>
        /// ͳ����Ϣƥ����Ŀ
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(long InfoID, string MatchType, string Criteria)
        {
            return dal.GetCount(InfoID, MatchType, Criteria);
        }
        #endregion

        #region ��ȡĳһ�û�������������Ϣ
        /// <summary>
        /// ��ȡĳһ�û�������������Ϣ
        /// </summary>        
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public DataView dvGetOtherInfoOfUser(string InfoID)
        {
            return dal.dvGetUserOtherInfo(InfoID);
        }
        #endregion

        #region
        /// <summary>
       /// ĳһ����Ϣ�ж������ղأ�ͬʱ����hit����
       /// </summary>
       /// <param name="InfoID"></param>
       /// <returns></returns>
        public DataView dvViewCollectionCount(string InfoID)
        {
            return dal.dvViewCollectCount(InfoID);
        }
        #endregion


    }
}
