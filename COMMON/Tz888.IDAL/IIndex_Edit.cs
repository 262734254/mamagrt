using System;
using System.Data;
namespace Tz888.IDAL
{
    /// <summary>
    /// �ӿڲ�ItzIndex_Edit ��ժҪ˵����
    /// </summary>
    public interface IIndex_Edit
    {
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Tz888.Model.Index_Edit model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Tz888.Model.Index_Edit model);

        int Delete(int ID);


        #endregion  ��Ա����
    }
}
