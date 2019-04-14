using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.MyHome;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.IDAL.MyHome
{
   public interface IHomeLink
    {
        #region �ӿ�
        /// <summary>
        /// ������ѯ
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        List<MyHomeLink> SelectHomeList(string LoginName);
        /// <summary>
        /// ͨ��
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<MyHomeLink> GetHomeList(SqlDataReader reader);
        /// <summary>
        /// ����ҵ���ҳ��Ϣ
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int InsertHomeLink(MyHomeLink cs);
        /// <summary>
        /// ��ѯ�����ҵ���ҳ��Ϣ
        /// </summary>
        /// <returns></returns>
        IList<MyHomeLink> GetAllMyHome(string LoginName);
        /// <summary>
        /// ����IDɾ����Ϣ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int deleteMyHome(int Id);
        /// <summary>
        /// ����ID�鿴��Ϣ
        /// </summary>
        /// <returns></returns>
        MyHomeLink GetAllMyHomeById(int Id);
        /// <summary>
        /// �޸���ҳ��Ϣ
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int UpdateMyHome(MyHomeLink cs);
       /// <summary>
       /// ���ݲ�ѯ���з����ֶ�
       /// </summary>
       /// <returns></returns>
       string SelectType(string LoginName);
        #endregion
    }
}
