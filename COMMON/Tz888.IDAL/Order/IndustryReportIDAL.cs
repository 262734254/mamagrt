using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
namespace Tz888.IDAL.Order
{
    public interface IndustryReportIDAL
    {
         /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       IndustryReport GetModel(string orderNo);
       
    }
}
