using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
namespace Tz888.IDAL.Order
{
    public interface OrderMainIDAL
    {
       
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        OrderMain GetModel(string orderNo);
        
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
        bool InsertMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report);
        /// <summary>
        /// �޸�һ������
        /// </summary>
        /// <param name="main"></param>
        /// <param name="linkInfo"></param>
        /// <param name="report"></param>
        /// <returns></returns>
         bool UpdateMainThreeTab(OrderMain main, OrderLink linkInfo, IndustryReport report);
        bool DeleteMainByOrderNo(string OrderNo);
        
    }
}
