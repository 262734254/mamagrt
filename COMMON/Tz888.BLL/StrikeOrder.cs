using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using Tz888.IDAL;

namespace Tz888.BLL
{

    public class StrikeOrder
    {

        private static readonly IStrikeOrder dal = Tz888.DALFactory.DataAccess.CreateStrikeOrder();
        Tz888.BLL.SendNotice Notice = new SendNotice();
        /// <summary>
        /// 生成在线充值订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateStrikeOrder(Tz888.Model.StrikeOrder model)
        {
            return dal.CreateStrikeOrder(model);
        }
        /// <summary>
        /// 网关返回的支付成功后进行充值操作
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool StrikeSuccess(string OrderNO, string PayType, string tradeNo, string OperationMan)
        {
            return dal.StrikeSuccess(OrderNO, PayType, tradeNo,OperationMan);
        }
        /// <summary>
        /// 网关返回的支付成功后进行充值操作
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool RechargeCardSuccess(string OrderNO, string PayType, string tradeNo, string OperationMan, string Number, int Free)
        {
            return dal.RechargeCardSuccess(OrderNO, PayType, tradeNo, OperationMan, Number, Free);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool StrikeOrderDelete(string OrderNO)
        {
            return dal.StrikeOrderDelete(OrderNO);
        }
        /// <summary>
        /// 充值卡充值
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="CardNo"></param>
        /// <param name="CardPwd"></param>
        /// <param name="changeBy"></param>
        /// <param name="Remark"></param>
        /// <param name="mintErrorID"></param>
        /// <param name="mstrErrorMsg"></param>
        /// <returns></returns>
        public int CardStrike(string LoginName, long CardNo, string CardPwd, string changeBy, string Remark)
        {
            int k=dal.CardStrike(LoginName, CardNo, CardPwd, changeBy, Remark);
            #region 发送通知
            if (k == 0) //充值成功 发送通知
            {
                string Content = "恭喜" + LoginName + "充值成功，请登陆拓富通查看余额！";
                string Title = "充值通知";
                Notice.StrikeSucess(LoginName,Content,Title,Content,Content);
            }
            #endregion

            return k;
        }
        /// <summary>
        /// 确认充值
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <param name="PayType"></param>
        /// <param name="tradeNo"></param>
        /// <param name="OperationMan"></param>
        /// <param name="StrikeMoney"></param>
        /// <returns></returns>
        public bool StrikeOrderConfirmed(string OrderNO, string PayType, string tradeNo, string OperationMan, double StrikeMoney)
        {
            return dal.StrikeOrderConfirmed(OrderNO, PayType, tradeNo, OperationMan, StrikeMoney);
        }
    }
}
