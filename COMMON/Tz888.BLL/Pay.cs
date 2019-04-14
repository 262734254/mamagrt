using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class Pay
    {
        private readonly IPay dal = DataAccess.CreateIPay();
        public Pay()
        { }
        public int CreateInfoOrder(long InfoID,string LoginName)
        {
           return dal.CreateInfoOrder(InfoID, LoginName);
        }
        /// <summary>
        /// 生成充值卡购买订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateCardOrder(Tz888.Model.Pay model)
        {
            return dal.CreateCardOrder(model);
        }

        /// <summary>
        /// 生成购买用户信息订单
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="point">总金额</param>
        /// <param name="buyType">购买类型</param>
        /// <returns>订单号</returns>
        public int CreateUserInfoOrder(string loginName, int point)
        {
            return dal.CreateUserInfoOrder(loginName, point);
        }

        /// <summary>
        /// 生成购买Vip会员订单
        /// </summary>
        /// <param name="LoginName">购买人</param>
        /// <param name="VipType">购买Vip类型</param>
        /// <returns></returns>
        public int CreateVipOrder(string LoginName, string @VipType)
        {
            return dal.CreateVipOrder(LoginName, @VipType);
        }
        /// <summary>
        /// 在线支付后为帐户充值
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PointCount">充值金额</param>
        /// <param name="ForeignTradeNo">外部交易号</param>
        /// <param name="StrikeType">支付方式</param>
        /// <returns>充值状态</returns>
        public int MemberStrike(string LoginName, double PointCount, string ForeignTradeNo, string StrikeType)
        {
            return dal.MemberStrike(LoginName, PointCount, ForeignTradeNo, StrikeType);
        }
        /// <summary>
        /// 充值成功后订单结算[用于购买]
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <param name="LoginName">支付人</param>
        /// <param name="PayType">支付类型</param>
        /// <returns>结算状态</returns>
        public int ConsumePay(long OrderNo, string LoginName, string PayType)
        {
            return dal.ConsumePay(OrderNo, LoginName, PayType);
        }
        /// <summary>
        /// 订单详细
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public DataTable getOrderDetails(long OrderNo, string LoginName)
        {
            return dal.getOrderDetails(OrderNo, LoginName);
        }

        /// <summary>
        /// 结算购买用户信息订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="loginName"></param>
        /// <param name="pointTatol"></param>
        /// <param name="payType"></param>
        /// <returns></returns>
        public int ConsumePayUserInfo(long orderno,long view_ID, string loginName, int pointTatol, string payType)
        {
            return dal.ConsumePayUserInfo(orderno, view_ID, loginName, pointTatol, payType);
        }

        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool ShopCar_Add(long InfoID, string LoginName)
        {
            return dal.ShopCar_Add(InfoID, LoginName);
        }
        public bool ShopCar_Delete(long ShopCarID)
        {
            return dal.ShopCar_Delete(ShopCarID);
        }
    }
}
