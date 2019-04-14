using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Orders;
using Tz888.SQLServerDAL.Order;
using Tz888.DALFactory;
using Tz888.IDAL.Order;
namespace Tz888.BLL.Order
{
   public class IndustryReportBLL
    {
       IndustryReportIDAL dal = DataAccess.CreateIndustryReport();
         /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public IndustryReport GetModel(string orderNo)
       {
           return dal.GetModel(orderNo);
       }
    }
}
