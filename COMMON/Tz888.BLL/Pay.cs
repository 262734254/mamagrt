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
        /// ���ɳ�ֵ�����򶩵�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateCardOrder(Tz888.Model.Pay model)
        {
            return dal.CreateCardOrder(model);
        }

        /// <summary>
        /// ���ɹ����û���Ϣ����
        /// </summary>
        /// <param name="loginName">�û���</param>
        /// <param name="point">�ܽ��</param>
        /// <param name="buyType">��������</param>
        /// <returns>������</returns>
        public int CreateUserInfoOrder(string loginName, int point)
        {
            return dal.CreateUserInfoOrder(loginName, point);
        }

        /// <summary>
        /// ���ɹ���Vip��Ա����
        /// </summary>
        /// <param name="LoginName">������</param>
        /// <param name="VipType">����Vip����</param>
        /// <returns></returns>
        public int CreateVipOrder(string LoginName, string @VipType)
        {
            return dal.CreateVipOrder(LoginName, @VipType);
        }
        /// <summary>
        /// ����֧����Ϊ�ʻ���ֵ
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PointCount">��ֵ���</param>
        /// <param name="ForeignTradeNo">�ⲿ���׺�</param>
        /// <param name="StrikeType">֧����ʽ</param>
        /// <returns>��ֵ״̬</returns>
        public int MemberStrike(string LoginName, double PointCount, string ForeignTradeNo, string StrikeType)
        {
            return dal.MemberStrike(LoginName, PointCount, ForeignTradeNo, StrikeType);
        }
        /// <summary>
        /// ��ֵ�ɹ��󶩵�����[���ڹ���]
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="LoginName">֧����</param>
        /// <param name="PayType">֧������</param>
        /// <returns>����״̬</returns>
        public int ConsumePay(long OrderNo, string LoginName, string PayType)
        {
            return dal.ConsumePay(OrderNo, LoginName, PayType);
        }
        /// <summary>
        /// ������ϸ
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public DataTable getOrderDetails(long OrderNo, string LoginName)
        {
            return dal.getOrderDetails(OrderNo, LoginName);
        }

        /// <summary>
        /// ���㹺���û���Ϣ����
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
        /// ���빺�ﳵ
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
