using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// ���ƣ��Ƽ���Ϣ��
    /// ��ѯ��CommendVIW
    /// ��;��Ϊ�Ƽ���Ϣ�����ṩ��Ӧ�ķ���������
    /// ����ˣ�wangwei
    /// �������ڣ�2009-06-03
    public class CommendBLL
    {
        private readonly ICommendDAL dal = DataAccess.CreateICommendDAL();

        public CommendBLL()
        { }

        #region-- ���� -------------------
        /// <summary>
        /// ����
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool Send(Tz888.Model.Commend com)
        {
            return dal.Send(com);
        }
        #endregion

        #region-- ɾ�� -------------------
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool Update(Tz888.Model.Commend com)
        {
            return dal.Update(com);
        }
        #endregion

        #region-- ��ѯ��Ӧ��¼ -----------
        /// <summary>
        /// ��ѯ��Ӧ��¼
        /// </summary>
        /// <param name="Key">�ؼ���</param>		
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool GetDetail(string Key)
        {
            return dal.GetDetail(Key);
        }
        #endregion

        #region-- ��ѯ�б� ---------------
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
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return dal.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize,ref  PageCount);
        }
        #endregion

        #region-- ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        public bool Insert(Tz888.Model.Commend commend)
        {
            return dal.Insert(commend);
        }
        #endregion

        #region-- ��ѯ�б� ---------------
        /// <summary>
        /// ��ѯ�Ƽ��Ĵ���
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ�Ƽ�����ϢID��</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        public int GetListCount(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return dal.GetListCount(SelectCol, Criteria, OrderBy, ref  CurrentPage, PageSize, ref  PageCount);
        }
        #endregion
    }
}
