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
        /// �õ�һ������ʵ��
        /// </summary>
        public OrderMain GetModel(string orderNo)
        {
            return dal.GetModel(orderNo);
        }
        /// <summary>
        /// ����һ������
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
        /// �޸�һ������
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
