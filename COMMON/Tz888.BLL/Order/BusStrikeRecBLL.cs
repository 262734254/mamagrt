using System;
using System.Collections.Generic;
using System.Text;
using Tz888.SQLServerDAL.Order;
namespace Tz888.BLL.Order
{
   public class BusStrikeRecBLL
    {
      BusStrikeRecDAL dal = new BusStrikeRecDAL();
        /// <summary>
        /// 增加一条数据
        /// </summary>
       public int Add(Tz888.Model.Orders.BusStrikeRecTab model)
       {
           return dal.Add(model);
       }
    }
}
