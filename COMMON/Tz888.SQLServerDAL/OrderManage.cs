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
        /// É¾³ý×ÊÔ´¶©µ¥
        /// </summary>
        /// <param name="OrderNo">¶©µ¥ºÅ</param>
        /// <param name="action">1 ÎªÂß¼­É¾³ý ·ñÎª³¹µ×É¾³ý</param>
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
        /// É¾³ý·Ç×ÊÔ´¶©µ¥
        /// </summary>
        /// <param name="OrderNo">¶©µ¥ºÅ</param>
        /// <param name="action">1 ÎªÂß¼­É¾³ý ·ñÎª³¹µ×É¾³ý</param>
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
        /// É¾³ý³äÖµ¶©µ¥
        /// </summary>
        /// <param name="OrderNo">¶©µ¥ºÅ</param>
        /// <param name="action">1 ÎªÂß¼­É¾³ý ·ñÎª³¹µ×É¾³ý</param>
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
        /// È·ÈÏ¼ÇÂ¼
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
