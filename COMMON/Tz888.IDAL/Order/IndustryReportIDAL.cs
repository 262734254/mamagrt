using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
namespace Tz888.IDAL.Order
{
    public interface IndustryReportIDAL
    {
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
       IndustryReport GetModel(string orderNo);
       
    }
}
