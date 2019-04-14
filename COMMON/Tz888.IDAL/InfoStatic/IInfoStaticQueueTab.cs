using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.InfoStatic
{
    public interface IInfoStaticQueueTab
    {

        /// <summary>
        ///  更新一条数据
        /// </summary>
        bool Update(Tz888.Model.InfoStatic.InfoStaticQueueTab model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int InfoID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.InfoStatic.InfoStaticQueueTab GetModel(int InfoID);


        //获取排行榜设置信息列表
        DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere);

        /// <summary>
        /// 创建静态化队列
        /// </summary>
        /// <param name="StartTime">信息</param>
        /// <param name="EndTime"></param>
        /// <param name="Command"></param>
        /// <param name="Count"></param>
        /// <param name="State"></param>
        int Create(System.DateTime StartTime, System.DateTime EndTime, int Command, ref int Count, ref int State);

        /// <summary>
        /// 获取队列中记录的总数
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
