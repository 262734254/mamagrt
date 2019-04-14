using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
	public class OrderManage
	{
        private readonly IOrderManage dal = DataAccess.CreateOrderManage();
        /// <summary>
        /// É¾³ý×ÊÔ´¶©µ¥
        /// </summary>
        /// <param name="OrderNo">¶©µ¥ºÅ</param>
        /// <param name="action">1 ÎªÂß¼­É¾³ý ·ñÎª³¹µ×É¾³ý</param>
        /// <returns></returns>
        public bool deleInfoOrder(long OrderNo, int action)
        {
            return dal.deleInfoOrder(OrderNo, action);
        }
        /// <summary>
        /// É¾³ý·Ç×ÊÔ´¶©µ¥
        /// </summary>
        /// <param name="OrderNo">¶©µ¥ºÅ</param>
        /// <param name="action">1 ÎªÂß¼­É¾³ý ·ñÎª³¹µ×É¾³ý</param>
        /// <returns></returns>
        public bool deleOtherOrder(long OrderNo, int action)
        {
            return dal.deleOtherOrder(OrderNo, action);
        }
        /// <summary>
        /// É¾³ý³äÖµ¶©µ¥
        /// </summary>
        /// <param name="OrderNo">¶©µ¥ºÅ</param>
        /// <param name="action">1 ÎªÂß¼­É¾³ý ·ñÎª³¹µ×É¾³ý</param>
        /// <returns></returns>
        public bool deleStrikeOrder(string StrikeOrder, int action)
        {
            return dal.deleStrikeOrder(StrikeOrder, action);
        }
       
        /// <summary>
        /// È·ÈÏ¼ÇÂ¼
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="PayMoney"></param>
        /// <param name="OperationMan"></param>
        /// <param name="Remark"></param>
        /// <returns></returns>
        public bool ConfirmendLog(long OrderNo, double PayMoney, string OperationMan, string Remark)
        {
            return dal.ConfirmendLog(OrderNo, PayMoney, OperationMan, Remark);
        }
	}
}
