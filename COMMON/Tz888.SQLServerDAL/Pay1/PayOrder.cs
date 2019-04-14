using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Tz888.IDAL.LoginInfo;
using Tz888.DBUtility;
using System.Security.Cryptography;

namespace Tz888.SQLServerDAL.Pay1
{
    /// <summary>
    /// PayOrder 的摘要说明。
    /// </summary>
    public class PayOrder : ErrorBase
    {
        private SqlConn mySql;

        public PayOrder()
        {
            mySql = new SqlConn();
        }

        #region 生成推广短信购买订单
        public int CreatePromotionOrder1(string LoginName, int smscount, int Id, float totalPrice, ref int mintErrorID, ref string mstrErrorMsg)
        {

            SqlParameter[] parameters = {
											
											new SqlParameter("@smscount", SqlDbType.Int),
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@sId", SqlDbType.Int),
											new SqlParameter("@TotalPrice", SqlDbType.Float,8),
											new SqlParameter("@OrderNo", SqlDbType.Int),
			};
            parameters[0].Value = smscount;
            parameters[1].Value = LoginName;
            parameters[2].Value = Id;
            parameters[3].Value = totalPrice;
            parameters[4].Direction = ParameterDirection.Output;

            int orderid = DbHelperSQL.RunProcReturn("ShopCarTab_Order_Promotion1", parameters);
            return orderid;
        }
        #endregion
        #region 生成资源购买订单
        public int CreateInfoOrder(long InfoID, string LoginName, ref int mintErrorID, ref string mstrErrorMsg)
        {
            int orderid = 0;
            SqlParameter[] parameters = {
											
											new SqlParameter("@InfoID", SqlDbType.BigInt,8),
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@OrderNo", SqlDbType.BigInt,8),
			};
            parameters[0].Value = InfoID;
            parameters[1].Value = LoginName;
            parameters[2].Direction = ParameterDirection.Output;
            try
            {
                //mySql.GetConnection();
                orderid = DbHelperSQL.RunProcReturn("ShopCarTab_Order_InsertNews", parameters);

            }
            catch (Exception err)
            {
                throw err;
            }
            //finally
            //{
            //    mySql.CloseCn();
            //}
            return orderid;
        }
        #endregion

        /// <summary>
        /// 充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool PaySuccess(string orderNo, string LoginName, string total_fee)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@orderNo", SqlDbType.VarChar,30),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@total_fee", SqlDbType.Float),

			};
            parameters[0].Value = orderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = total_fee;

            try
            {
                b = DbHelperSQL.RunProcLob("SP_ConsumeRecTab_ADD", parameters);
            }
            catch (Exception err)
            { throw err; }
            return b;
        }


        /// <summary>
        /// 银联支付 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool PaySuccessQuick(string orderNo, string LoginName, string total_fee)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@orderNo", SqlDbType.VarChar,30),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@total_fee", SqlDbType.Float),

			};
            parameters[0].Value = orderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = total_fee;

            try
            {
                b = DbHelperSQL.RunProcLob("SP_ConsumeRecTabQuick_ADD", parameters);
            }
            catch (Exception err)
            { throw err; }
            return b;
        }

        
        /// <summary>
        /// 卡充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool accountPaySuccess(string orderNo, string LoginName, string total_fee, string UserMoney)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@orderNo", SqlDbType.VarChar,30),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@total_fee", SqlDbType.Float),
                	new SqlParameter("@UserMoney", SqlDbType.Float),

			};
            parameters[0].Value = orderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = total_fee;
            parameters[3].Value = UserMoney;

            try
            {
                b = DbHelperSQL.RunProcLob("SP_accountPay_ADD", parameters);
            }
            catch (Exception err)
            { throw err; }
            return b;
        }

        #region 检查日期是否过期
        public int CheckDate(long InfoID, string IsNOValidate)
        {
            int orderid = 0;
            SqlParameter[] parameters = {
											
											new SqlParameter("@InfoID", SqlDbType.BigInt,8),
											new SqlParameter("@IsNOValidate", SqlDbType.Char,16),
										
			};
            parameters[0].Value = InfoID;
            parameters[1].Direction = ParameterDirection.Output;
            try
            {
                //mySql.GetConnection();
                orderid = DbHelperSQL.RunProcReturn("[Info_ValidateD]", parameters);

            }
            catch (Exception err)
            {
                throw err;
            }
            //finally
            //{
            //    mySql.CloseCn();
            //}
            return orderid;
        }
        #endregion

        #region 检查是否购买该资源
        public  string OrderByMoney(long InfoID, string loginName)
        {
            string name = "";
            string sql = "	SELECT	ID FROM	dbo.ConsumeRecTab WHERE	 InfoID = @InfoID AND LoginName =@loginName";
            SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,20),
                new SqlParameter("@loginName",SqlDbType.VarChar,20)
            };
            para[0].Value = InfoID;
            para[1].Value = loginName;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0]["ID"].ToString();
            }
            return name;
        } 
        #endregion

        #region 生成购买Vip会员订单
        public int CreateVipInfoOrder(string LoginName,string price,string Valdate, ref int mintErrorID, ref string mstrErrorMsg)
        {
            int orderid = 0;
            SqlParameter[] parameters = {
											

											new SqlParameter("@LoginName", SqlDbType.Char,16),
                                             new SqlParameter("@price", SqlDbType.Char,16),
                                              new SqlParameter("@Valdate", SqlDbType.BigInt,8),
											new SqlParameter("@OrderNo", SqlDbType.BigInt,8),
                                             
                                           
			};

            parameters[0].Value = LoginName;
            parameters[1].Value= price;
            parameters[2].Value = Valdate;
            parameters[3].Direction = ParameterDirection.Output;
         
            try
            {
                //mySql.GetConnection();
                orderid = DbHelperSQL.RunProcReturn("ShopCarTabVip_Order_InsertNews", parameters);

            }
            catch (Exception err)
            {
                throw err;
            }
            //finally
            //{
            //    mySql.CloseCn();
            //}
            return orderid;
        }
        #endregion
        /// <summary>
        /// Vip卡充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool VipaccountPaySuccess(string orderNo, string LoginName, string total_fee, string UserMoney, string Validate, string Vadate)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@orderNo", SqlDbType.VarChar,30),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@total_fee", SqlDbType.Float),
                	new SqlParameter("@UserMoney", SqlDbType.Float),
                     new SqlParameter("@Validate", SqlDbType.VarChar,30),
                   new SqlParameter("@Vadate", SqlDbType.VarChar,30),

			};
            parameters[0].Value = orderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = total_fee;
            parameters[3].Value = UserMoney;
            parameters[4].Value = Validate;
            parameters[5].Value = Vadate;
            try
            {
                b = DbHelperSQL.RunProcLob("SP_VIPaccountPay_ADD", parameters);
            }
            catch (Exception err)
            { throw err; }
            return b;
        }
        /// <summary>
        /// 升级VIP充值成功 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool PayVipSuccess(string orderNo, string LoginName, string total_fee)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@orderNo", SqlDbType.VarChar,30),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@total_fee", SqlDbType.Float)


			};
            parameters[0].Value = orderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = total_fee;
   
            try
            {
                b = DbHelperSQL.RunProcLob("SP_VIPConsumeRecTab_ADD", parameters);
            }
            catch (Exception err)
            { throw err; }
            return b;
        }

        /// <summary>
        /// 添加联盟分红信息 
        /// </summary>
        /// <param name="OrderNO"></param>
        /// <returns></returns>
        public bool AddLmOrder(string orderNo, string LoginName, string total_fee, string UserMoney)
        {
            bool b = false;
            SqlParameter[] parameters = {
                    new SqlParameter("@orderNo", SqlDbType.VarChar,30),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@total_fee", SqlDbType.Float),
                	new SqlParameter("@UserMoney", SqlDbType.Float),

			};
            parameters[0].Value = orderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = total_fee;
            parameters[3].Value = UserMoney;

            try
            {
                b = DbHelperSQL.RunProcLob("SP_LmOrderPay_ADD", parameters);
            }
            catch (Exception err)
            { throw err; }
            return b;
        }
      

    }
}
