using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Security.Cryptography;
namespace Tz888.SQLServerDAL
{
    public class StrikeOrder : IStrikeOrder
    {
     /// <summary>
     /// 充值
     /// </summary>
        public StrikeOrder()
        { }

        #region  在线充值
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateStrikeOrder(Tz888.Model.StrikeOrder model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,50),

					new SqlParameter("@PayTypeCode", SqlDbType.Char,10),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@StrikeName", SqlDbType.VarChar,50),

					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@MobileNo", SqlDbType.VarChar,23),
					new SqlParameter("@RealName", SqlDbType.Char,8),

					new SqlParameter("@TotalCount", SqlDbType.Float,8),			
					new SqlParameter("@OtherInfo", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
                    new SqlParameter("@OperationMan", SqlDbType.VarChar,100),
                    new SqlParameter("@OrderNo", SqlDbType.BigInt),};

            parameters[0].Value = "Order_Insert";
            parameters[1].Value = model.PayTypeCode;

            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.StrikeLoginName;

            parameters[4].Value = model.Email;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.MobileNo;
            parameters[7].Value = model.RealName;

            parameters[8].Value = model.TotalCount;        
            parameters[9].Value = model.OtherInfo;

            parameters[10].Value = model.remark;
            parameters[11].Value = model.OperationMan;

            parameters[12].Direction = ParameterDirection.Output;
            

            int orderno= DbHelperSQL.RunProcReturn("StrikeOrder", parameters);

            return orderno;
        }
        //删除超过10天未成功的订单
        public bool StrikeOrderDelete(string OrderNO)
        {
         
            SqlParameter[] parameters = {
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					new SqlParameter("@OrderNO", SqlDbType.VarChar,20),                   
			};
            parameters[0].Value = "Order_Delete";
            parameters[1].Value =OrderNO;
            bool  b = DbHelperSQL.RunProcLob("StrikeOrder", parameters);     
            return b;
        }
        /// <summary>
        /// 充值成功 更新帐户金额
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool StrikeSuccess(string OrderNO,string PayType,string tradeNo,string OperationMan)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@OperationMan", SqlDbType.VarChar,16),
                    new SqlParameter("@PayType", SqlDbType.VarChar,30),
					new SqlParameter("@OrderNO", SqlDbType.VarChar,20),
                    new SqlParameter("@tradeNo", SqlDbType.VarChar,20),   
			};
            parameters[0].Value = OperationMan;
            parameters[1].Value = PayType;
            parameters[2].Value =OrderNO;
            parameters[3].Value = tradeNo;
            try
            {
                b = DbHelperSQL.RunProcLob("StrikeOrderSuccess", parameters);
            }
            catch
            { }
            return b;
        }

        /// <summary>
        /// 确认充值订单
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool StrikeOrderConfirmed(string OrderNO, string PayType, string tradeNo, string OperationMan, double StrikeMoney)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@OperationMan", SqlDbType.VarChar,16),
                    new SqlParameter("@PayType", SqlDbType.VarChar,30),
					new SqlParameter("@OrderNO", SqlDbType.VarChar,20),
                    new SqlParameter("@tradeNo", SqlDbType.VarChar,20),
                    new SqlParameter("@StrikeMoney", SqlDbType.Float),  
			};
            parameters[0].Value = OperationMan;
            parameters[1].Value = PayType;
            parameters[2].Value = OrderNO;
            parameters[3].Value = tradeNo;
            parameters[4].Value = StrikeMoney;
            try
            {
                b = DbHelperSQL.RunProcLob("StrikeOrderConfirmed", parameters);
            }
            catch
            { }
            return b;
        }
        #endregion

        #region IStrikeOrder 充值成功 更新帐户金额

        /// <summary>
        /// 充值成功 更新帐户金额
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool RechargeCardSuccess(string OrderNO, string PayType, string tradeNo, string OperationMan, string Number, int Free)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@OperationMan", SqlDbType.VarChar,16),
                    new SqlParameter("@PayType", SqlDbType.VarChar,30),
					new SqlParameter("@OrderNO", SqlDbType.VarChar,20),
                    new SqlParameter("@tradeNo", SqlDbType.VarChar,20),   
                  new SqlParameter("@Number", SqlDbType.VarChar,20),   
                  new SqlParameter("@Free", SqlDbType.Int),   
			};
            parameters[0].Value = OperationMan;
            parameters[1].Value = PayType;
            parameters[2].Value = OrderNO;
            parameters[3].Value = tradeNo;
            parameters[4].Value = Number;
            parameters[5].Value = Free;
            try
            {
                b = DbHelperSQL.RunProcLob("RechargeCardSuccess", parameters);
            }
            catch
            { }
            return b;
        }

        #endregion

        #region 充值卡充值
        public int CardStrike(string LoginName, long CardNo, string CardPwd, string changeBy, string Remark)
        {
            int ret = 0;
            SHA1 sha = SHA1.Create();
            byte[] cardpwd = sha.ComputeHash(System.Text.Encoding.Unicode.GetBytes(CardPwd));
            SqlParameter[] parameters = {
											
											new SqlParameter("@LoginName", SqlDbType.VarChar,16),
											new SqlParameter("@CardNo", SqlDbType.BigInt,8),
											new SqlParameter("@Password", SqlDbType.VarBinary),
											new SqlParameter("@changeBy", SqlDbType.VarChar,50),
											new SqlParameter("@Remark", SqlDbType.VarChar,100),
                                            new SqlParameter("@ResultFlag", SqlDbType.Int),
                
			};
            parameters[0].Value = LoginName;
            parameters[1].Value = CardNo;
            parameters[2].Value = cardpwd;
            parameters[3].Value = changeBy;
            parameters[4].Value = Remark;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {

                ret = DbHelperSQL.RunProcReturn("MemberStrike_ByCard", parameters);

            }
            catch (Exception err)
            {
                throw err;
            }

            return ret;
        }
        #endregion   

    }
}
