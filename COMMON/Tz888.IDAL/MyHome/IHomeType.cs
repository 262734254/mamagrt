using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.MyHome;

namespace Tz888.IDAL.MyHome
{
    public interface IHomeType
    {
        /// <summary>
        /// ����IDɾ����Ϣ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int deleteHomeType(int Id);
        /// <summary>
        /// �޸���ҳ��Ϣ
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int UpdateHomeType(MyHomeType cs);
        /// <summary>
        /// ��ѯ�������ͱ�����
        /// </summary>
        /// <returns></returns>
        IList<MyHomeType> GetHomeTypeList(string LoginName);
        /// <summary>
        /// ����ID��ѯ��ҳ����
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MyHomeType GetAllTypeById(int Id);
       
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int InsertHomeType(MyHomeType cs);
        /// <summary>
        /// ���ݵ�¼����ѯ
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        List<MyHomeType> SelectHomeType(string LoginName);
        /// <summary>
        /// ͨ��
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<MyHomeType> GetCars(SqlDataReader reader);

        
    }
}
