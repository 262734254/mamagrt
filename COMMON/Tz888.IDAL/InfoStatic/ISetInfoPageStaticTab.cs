using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.InfoStatic
{
    public interface ISetInfoPageStaticTab
    {
        #region  ��Ա����
        /// <summary>
        ///  ����һ������
        /// </summary>
        bool Update(Tz888.Model.InfoStatic.SetInfoPageStaticTab model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int ID);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.InfoStatic.SetInfoPageStaticTab GetModel(int ID);

        /// <summary>
        /// ��ȡȫվ��Ϣ��̬������������Ϣ
        /// </summary>
        /// <param name="GetFields"></param>
        /// <param name="OrderName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="doCount"></param>
        /// <param name="OrderType"></param>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere);

        #endregion  ��Ա����
    }
}
