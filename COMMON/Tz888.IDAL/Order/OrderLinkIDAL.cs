using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
namespace Tz888.IDAL.Order
{
    public interface OrderLinkIDAL
    {
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        OrderLink GetModel(string orderNo);
        
    }
}
