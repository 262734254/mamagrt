using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface ISetDefaultValue
    {
        #region-- ��� -------------------
        /// <summary>
        /// ���
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        long Insert(Tz888.Model.Info.DefaultValueModel model);
        #endregion

        #region-- �޸� -------------------
        /// <summary>
        /// �޸�ְ���������
        /// </summary>
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        bool Update(Tz888.Model.Info.DefaultValueModel model);
        #endregion

        #region-- ɾ�� -------------------
        /// <summary>
        /// ɾ��
        /// </summary>		
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        bool Delete(long ID);
        #endregion

        #region-- ȡֵ -------------------
        /// <summary>
        /// ȡֵ
        /// </summary>		
        /// <returns>����Dataview</returns>
        DataView GetValue(Tz888.Model.Info.DefaultValueModel model);
        #endregion

        #region-- ��ѯ��Ӧ��¼ -----------
        /// <summary>
        /// ��ѯ��Ӧ��¼
        /// </summary>
        /// <param name="Key">�ؼ���</param>		
        /// <returns>�Ƿ�����ɹ���true�ɹ���falseʧ�ܣ�</returns>
        Tz888.Model.Info.DefaultValueModel GetDetail(string Key);

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
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
        #endregion

        #region
        /// <summary>
        /// ��������,
        /// </summary>
        /// <param name="sourceID">ԴID</param>
        /// <returns></returns>
        long Clone(long sourceID, Tz888.Model.Info.DefaultValueModel model);
        #endregion

    }
}
