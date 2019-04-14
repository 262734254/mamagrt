using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.InfoStatic
{
    public interface IInfoStaticQueueTab
    {

        /// <summary>
        ///  ����һ������
        /// </summary>
        bool Update(Tz888.Model.InfoStatic.InfoStaticQueueTab model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int InfoID);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.InfoStatic.InfoStaticQueueTab GetModel(int InfoID);


        //��ȡ���а�������Ϣ�б�
        DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere);

        /// <summary>
        /// ������̬������
        /// </summary>
        /// <param name="StartTime">��Ϣ</param>
        /// <param name="EndTime"></param>
        /// <param name="Command"></param>
        /// <param name="Count"></param>
        /// <param name="State"></param>
        int Create(System.DateTime StartTime, System.DateTime EndTime, int Command, ref int Count, ref int State);

        /// <summary>
        /// ��ȡ�����м�¼������
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
