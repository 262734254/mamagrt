using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
namespace Tz888.IDAL.Order
{
    public interface OrderMainIDAL
    {
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        OrderMain GetModel(string orderNo);
        
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        bool InsertMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report);
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
         bool UpdateMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report);
        bool DeleteMainByOrderNo(string OrderNo);
        
    }
}
