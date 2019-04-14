using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
namespace Tz888.BLL.Pay1
{
    /// <summary>
    /// PayOrder 的摘要说明。
    /// </summary>
    public class PayOrder
    {
        Tz888.SQLServerDAL.Pay1.PayOrder obj = new Tz888.SQLServerDAL.Pay1.PayOrder();

        #region 生成推广短信购买订单
        public int CreatePromotionOrder1(string LoginName, int smscount, int Id, float totalPrice, ref int mintErrorID, ref string mstrErrorMsg)
        {
            return obj.CreatePromotionOrder1(LoginName, smscount,Id, totalPrice, ref mintErrorID, ref mstrErrorMsg);
        }
        #endregion
        #region 生成购买资源订单
        /// <summary>
        /// 生成购买资源订单
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <param name="ErrorID"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>

        public int CreateInfoOrder(long InfoID, string LoginName, ref int ErrorID, ref string ErrorMsg)
        {
            return obj.CreateInfoOrder(InfoID, LoginName, ref ErrorID, ref ErrorMsg);
        }
        /// <summary>
        /// 生成购买VIP订单
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="price"></param>
        /// <param name="mintErrorID"></param>
        /// <param name="mstrErrorMsg"></param>
        /// <returns></returns>
        public int CreateVipInfoOrder(string LoginName, string price,string Valdate, ref int mintErrorID, ref string mstrErrorMsg)
        {
            return obj.CreateVipInfoOrder(LoginName, price,Valdate, ref mintErrorID, ref mstrErrorMsg);
        }
        #endregion
         /// <summary>
        /// 充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool PaySuccess(string orderNo, string LoginName, string total_fee)
        {
            return obj.PaySuccess(orderNo, LoginName, total_fee);
        }

        /// <summary>
        /// 银联支付 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool PaySuccessQuick(string orderNo, string LoginName, string total_fee)
        {
            return obj.PaySuccessQuick(orderNo, LoginName, total_fee);
        }
        #region 检查是否过期
        public int CheckDate(long InfoID, string Validate)
        {
            return obj.CheckDate(InfoID, Validate);
        } 
        #endregion
        #region 检查是否购买
        public string OrderByMoney(long InfoID, string loginName)
        {
            return obj.OrderByMoney(InfoID, loginName);
        } 
        #endregion
          /// <summary>
        /// 充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool accountPaySuccess(string orderNo, string LoginName, string total_fee,string UserMoney)
        {
            return obj.accountPaySuccess(orderNo, LoginName, total_fee, UserMoney);
        }
        /// <summary>
        /// 升级VIP充值成功 
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="LoginName"></param>
        /// <param name="total_fee"></param>
        /// <param name="UserMoney"></param>
        /// <param name="Validate"></param>
        /// <returns></returns>
        public bool VipaccountPaySuccess(string orderNo, string LoginName, string total_fee, string UserMoney, string Validate,string Vadate)
        {
            return obj.VipaccountPaySuccess(orderNo, LoginName, total_fee, UserMoney, Validate,Vadate);
        }
        /// <summary>
        /// 升级VIP充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool PayVipSuccess(string orderNo, string LoginName, string total_fee)

        {
            return obj.PayVipSuccess(orderNo, LoginName, total_fee);
         }
         /// <summary>
         /// 资源联盟添加分红 
         /// </summary>
         /// <param name="OrderNO"></param>
         /// <returns></returns>
        public bool AddLmOrder(string orderNo, string LoginName, string total_fee, string UserMoney)
         {
             return obj.AddLmOrder(orderNo, LoginName, total_fee, UserMoney);
         }
        

    }
}
