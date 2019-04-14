using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
using Tz888.SQLServerDAL.Order;
using Tz888.IDAL.Order;
using Tz888.DALFactory;
namespace Tz888.BLL.Order
{
    public class OrderMainBLL
    {
        OrderMainIDAL dal = DataAccess.CreateOrderMain();
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OrderMain GetModel(string orderNo)
        {
            return dal.GetModel(orderNo);
        }
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        public bool InsertMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report)
        {
            return dal.InsertMainThreeTab(main, linkInfo, report);
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        public bool UpdateMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report)
        {
            return dal.UpdateMainThreeTab(main, linkInfo, report);
        }
        public bool DeleteMainByOrderNo(string OrderNo)
        {
            return dal.DeleteMainByOrderNo(OrderNo);
        }
    }
}
