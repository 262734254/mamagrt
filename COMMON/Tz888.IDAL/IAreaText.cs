using System;
using System.Data;
namespace Tz888.IDAL
{
    /// <summary>
    /// 接口层IAreaTextTab 的摘要说明。
    /// </summary>
    public interface IAreaText
    {
        #region  成员方法
        int Add(Tz888.Model.AreaText model);

        int Update(Tz888.Model.AreaText model);

        int Delete(int AreaID);

        void AddHit(int AreaID);

        void UpdateOrderNum(int ArearID, int OrderNum);

        Tz888.Model.AreaText GetModel(int AreaID);
        #endregion  成员方法
    }
}
