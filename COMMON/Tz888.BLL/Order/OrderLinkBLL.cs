using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
using Tz888.SQLServerDAL.Order;
using Tz888.IDAL.Order;
using Tz888.DALFactory;
namespace Tz888.BLL.Order
{
    public class OrderLinkBLL
    {
        OrderLinkIDAL dal = DataAccess.CreateOrderLink();
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public OrderLink GetModel(string orderNo)
        {
            return dal.GetModel(orderNo);
        }
    }
}
