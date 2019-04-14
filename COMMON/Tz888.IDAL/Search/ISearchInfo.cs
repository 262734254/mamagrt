using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL.Search
{
    public interface ISearchInfo
    {
        DataView InfoListDataBind(
          string MenuType,
          string LoginName,
          string Criteria,
          ref long CurrentPage,
          long PageRows,
          out long PageCount);

        DataView GetInfoListByRecycle(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        DataView GetInfoListBySelf(
            string Criteria,
            string loginName,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        DataTable GetMainInfoTabList(string fields, string where, bool orderType, int pageSize, int pageCur, bool isJustCount);


        DataView GetInfoList(
            string SelectStr,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        DataView GetInfoList(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        DataView GetInfoFrontList2(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        DataView GetInfoFrontList(
            string SelectCol,
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        DataView GetRefreshList(
            string SelectCol,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);

        DataView GetPointCount(long InfoID);

        #region-- �ж���Ϣ�Ƿ���Ч ---------------
        int IsValidInfo(string loginName, string infoID);
        #endregion

        string getCommentNum(long InfoID);


        #region-- ������Ϣ�б� ---------------
        /// <summary>
        /// ������Ϣ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        DataView InfoCommentList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);

        #endregion

        #region-- ������վ�����̡�Ͷ�ʡ����ʲ�ѯ�б� ---------------
        /// <summary>
        /// ������վ�����̡�Ͷ�ʡ����ʲ�ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>ͷ����ѯ�б�</returns>
        DataView GetAgentMCPList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);

        #endregion

        #region-- ��վ������ѯ�б� ---------------
        /// <summary>
        /// ��վ������ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>ͷ����ѯ�б�</returns>
        DataView GetWebTrendList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
        #endregion


        #region ���ĳ������Ϣ,ͨ�����Է�������
        /// <summary>
        /// ���ĳ������Ϣ,ͨ�����Է�������
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
        bool HasGetInfoItemForManage(long InfoID);
        #endregion

        Tz888.Model.Search.SearchInfo objGetSearchInfoByInfoID(long InfoID);


        #region ��ȡȫ������Ϣ�б���ʾ����վǰ̨��
        /// <summary>
        /// ��ȡȫ������Ϣ�б���ʾ����վǰ̨��
        /// </summary>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>����ȫ������Ϣ�б���ѯ��¼����ҳ��</returns>
        DataView GetInfoListForFrontView(
            string Criteria,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );
        #endregion


        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);


        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>
        /// <param name="mySql">�������ݿ���</param>
        /// <param name="FNStrName">�����ַ���</param>
        /// <param name="Key">�ؼ���</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
        DataView GetList(
            string FNStrName,
            string Key,
            string SelectStr,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount
            );

        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        bool InsertKeyWord(string Keyword, string InfoTypeID);


        
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        bool InsertKeywordForMember(string Keyword, string InfoTypeID, string LoginName);

       
        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        DataView GetListForMemberKeyword(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);



        #region  ��ѯ��عؼ����б�

        DataView GetRelateKeyword(string Keyword, string InfoTypeID);
        #endregion

          /// <summary>
        /// ��ȡͶ�ʵĲ�ѯ����б�
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="SortBy"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataView GetSearchResultCapital(
            string SelectCol,
            string Criteria,            
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

         /// <summary>
        /// ��ȡDataSet���͵�Ͷ�ʲ�ѯ����б�
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataSet dsGetSearchResultCapital(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

         /// <summary>
        /// ��ȡDataSet���͵����ʲ�ѯ����б�
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataSet dsGetSearchResultProject(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );

        /// <summary>
        /// ��ȡDataSet���͵����̲�ѯ����б�
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        DataSet dsGetSearchResultMerchant(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount // ���ظò�ѯ�ж�������¼
            );
        ///<summary>
        ///��ȡDateSet���͵���Ѷ��ѯ����б�
        ///</summary>
        ///<param name="SelectCol"></param>
        ///<param name="Criteria"></param>
        ///<param name="CurrentPage"></param>
        ///<param name="PageSize"></param>
        ///<param name="PageCount"></param>
        ///<returns></returns>
        DataTable  dsGetSearchResultNews(
            string SelectCol,
            string Criteria,
            string SortBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount //���ظò�ѯ�ж�������¼
            );
    }
}
