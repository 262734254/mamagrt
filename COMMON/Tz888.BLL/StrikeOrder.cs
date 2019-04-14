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
        /// �������߳�ֵ����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateStrikeOrder(Tz888.Model.StrikeOrder model)
        {
            return dal.CreateStrikeOrder(model);
        }
        /// <summary>
        /// ���ط��ص�֧���ɹ�����г�ֵ����
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool StrikeSuccess(string OrderNO, string PayType, string tradeNo, string OperationMan)
        {
            return dal.StrikeSuccess(OrderNO, PayType, tradeNo,OperationMan);
        }
        /// <summary>
        /// ���ط��ص�֧���ɹ�����г�ֵ����
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool RechargeCardSuccess(string OrderNO, string PayType, string tradeNo, string OperationMan, string Number, int Free)
        {
            return dal.RechargeCardSuccess(OrderNO, PayType, tradeNo, OperationMan, Number, Free);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool StrikeOrderDelete(string OrderNO)
        {
            return dal.StrikeOrderDelete(OrderNO);
        }
        /// <summary>
        /// ��ֵ����ֵ
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
            #region ����֪ͨ
            if (k == 0) //��ֵ�ɹ� ����֪ͨ
            {
                string Content = "��ϲ" + LoginName + "��ֵ�ɹ������½�ظ�ͨ�鿴��";
                string Title = "��ֵ֪ͨ";
                Notice.StrikeSucess(LoginName,Content,Title,Content,Content);
            }
            #endregion

            return k;
        }
        /// <summary>
        /// ȷ�ϳ�ֵ
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
