using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.LoginInfo
{
    public interface IMember
    {
        /// <summary>
        /// ȡ�û�Ա��Ϣ
        /// </summary>
        /// <returns></returns>
        DataView GetMerberInfo(
            string strSelect,
            string strCriteria,
            string strSort, ref  
            long intCurrentPage,
            long intCurrentPageSize,
            ref long intTotalCount);

        /// <summary>
        /// ���û�Աˢ��ʱ��
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="IsRefresh"></param>
        /// <returns></returns>
        bool RefreshMemberInfo(string LoginName, int IsRefresh);


        /// <summary>
        /// �����Ҫˢ�µ���Ϣ�б�
        /// </summary>
        /// <param name="InfoTypeID">��Ϣ����</param>
        /// <param name="LoginName">������</param>
        /// <returns>������Ϣ�б�</returns>
        DataView GetRefreshList(string LoginName, string InfoTypeID);
    }
}
