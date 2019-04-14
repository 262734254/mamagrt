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
        /// ɾ����Դ����
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="action">1 Ϊ�߼�ɾ�� ��Ϊ����ɾ��</param>
        /// <returns></returns>
        public bool deleInfoOrder(long OrderNo, int action)
        {
            return dal.deleInfoOrder(OrderNo, action);
        }
        /// <summary>
        /// ɾ������Դ����
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="action">1 Ϊ�߼�ɾ�� ��Ϊ����ɾ��</param>
        /// <returns></returns>
        public bool deleOtherOrder(long OrderNo, int action)
        {
            return dal.deleOtherOrder(OrderNo, action);
        }
        /// <summary>
        /// ɾ����ֵ����
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="action">1 Ϊ�߼�ɾ�� ��Ϊ����ɾ��</param>
        /// <returns></returns>
        public bool deleStrikeOrder(string StrikeOrder, int action)
        {
            return dal.deleStrikeOrder(StrikeOrder, action);
        }
       
        /// <summary>
        /// ȷ�ϼ�¼
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
