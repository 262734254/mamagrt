using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
 

namespace Tz888.IDAL.Common
{
    public interface ICommonFunction
    {
        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>        
        /// <param name="FNStrName">�����ַ���</param>
        /// <param name="Key">�ؼ���</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
        DataView GetList(string FNStrName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);

        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>       
        /// <param name="SPName">�洢���̵�����</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
        DataView GetListSet(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);

         /// 
        /// <summary>
        /// ��ȡ�����ö����Ĳ�ѯ����б�
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        DataView GetListSetForFirstTopNum(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, int FristTopNum, ref long TotalCount);


        /// <summary>
        /// ��ȡȫ������Ϣ�б�
        /// </summary>       
        /// <param name="SPName">�洢���̵�����</param>
        /// <param name="SelectStr">ѡ�����ַ���</param>
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="Sort">�����ַ���</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">ͨ���ò�ѯ���������صĲ�ѯ��¼����ҳ��</param>
        /// <returns>���ص�ǰҳ����Ϣ�б�</returns>
        DataTable GetDataTable(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);
        
 

         /// <summary>
        /// 
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        DataTable GetDTFromTableOrView(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);


        /// <summary>
        /// ��ȡ�����ö����Ĳ�ѯ����б�
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="FristTopNum"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>

        DataSet dsGetTopFirstNumContactBySP(string SPName,string InfoID);



    }     
}
