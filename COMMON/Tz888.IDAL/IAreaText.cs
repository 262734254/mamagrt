using System;
using System.Data;
namespace Tz888.IDAL
{
    /// <summary>
    /// �ӿڲ�IAreaTextTab ��ժҪ˵����
    /// </summary>
    public interface IAreaText
    {
        #region  ��Ա����
        int Add(Tz888.Model.AreaText model);

        int Update(Tz888.Model.AreaText model);

        int Delete(int AreaID);

        void AddHit(int AreaID);

        void UpdateOrderNum(int ArearID, int OrderNum);

        Tz888.Model.AreaText GetModel(int AreaID);
        #endregion  ��Ա����
    }
}
