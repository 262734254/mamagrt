using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class OrderManage:IOrderManage
    {
        /// <summary>
        /// ɾ����Դ����
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="action">1 Ϊ�߼�ɾ�� ��Ϊ����ɾ��</param>
        /// <returns></returns>
        public bool deleInfoOrder(long OrderNo,int action)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@OrderNO", SqlDbType.VarChar,20),
                    new SqlParameter("@action", SqlDbType.Int),
                    
			};
            parameters[0].Value = "DeleteInfo";
            parameters[1].Value = OrderNo;
            parameters[2].Value = action;
            try
            {
                b = DbHelperSQL.RunProcLob("OrderManage_Delete", parameters);
            }
            catch
            { }
            return b;
        }
        /// <summary>
        /// ɾ������Դ����
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="action">1 Ϊ�߼�ɾ�� ��Ϊ����ɾ��</param>
        /// <returns></returns>
        public bool deleOtherOrder(long OrderNo,int action)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@OrderNO", SqlDbType.VarChar,20),    
                    new SqlParameter("@action", SqlDbType.Int),
			};
            parameters[0].Value = "DeleteOther";
            parameters[1].Value = OrderNo;
            parameters[2].Value = action;
            try
            {
                b = DbHelperSQL.RunProcLob("OrderManage_Delete", parameters);
            }
            catch
            { }
            return b;
        }
        /// <summary>
        /// ɾ����ֵ����
        /// </summary>
        /// <param name="OrderNo">������</param>
        /// <param name="action">1 Ϊ�߼�ɾ�� ��Ϊ����ɾ��</param>
        /// <returns></returns>
        public bool deleStrikeOrder(string StrikeOrder, int action)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@StrikeOrder", SqlDbType.VarChar,20),    
                     new SqlParameter("@action", SqlDbType.Int),
			};
            parameters[0].Value = "DeleteStrike";
            parameters[1].Value = StrikeOrder;
            parameters[2].Value = action;
            try
            {
                b = DbHelperSQL.RunProcLob("OrderManage_Delete", parameters);
            }
            catch
            { }
            return b;
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
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderNo", SqlDbType.BigInt),
                    new SqlParameter("@PayMoney", SqlDbType.Float),
					new SqlParameter("@OperationMan", SqlDbType.VarChar,20),    
                    new SqlParameter("@Remark", SqlDbType.VarChar,100),
			};
            parameters[0].Value = OrderNo;
            parameters[1].Value = PayMoney;
            parameters[2].Value = OperationMan;
            parameters[3].Value = Remark;
            try
            {
                b = DbHelperSQL.RunProcLob("ShopCarConfirmed", parameters);
            }
            catch
            { }
            return b;
        }
    }
}
