using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.InfoStatic
{
    public interface ISetInfoPageStaticTab
    {
        #region  成员方法
        /// <summary>
        ///  更新一条数据
        /// </summary>
        bool Update(Tz888.Model.InfoStatic.SetInfoPageStaticTab model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.InfoStatic.SetInfoPageStaticTab GetModel(int ID);

        /// <summary>
        /// 获取全站信息静态化服务设置信息
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

        #endregion  成员方法
    }
}
