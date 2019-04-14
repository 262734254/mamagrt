using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IMatchInfo
    {
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
        DataView GetMatchList(
            string MatchType,
            long InfoID,
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount);

        /// <summary>
        /// ͳ����Ϣƥ����Ŀ
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        int GetCount(long InfoID, string MatchType, string Criteria);

        /// <summary>
        /// ��ȡĳһ�û���������Ϣ
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        DataView dvGetUserOtherInfo(string InfoID);

         #region ĳһ����Ϣ�ж����˹�ע
        /// <summary>
        /// ĳһ����Ϣ�ж������ղ�,ͬʱ�����û��ĵ������
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        DataView dvViewCollectCount(string InfoID);
        #endregion
    }
}
