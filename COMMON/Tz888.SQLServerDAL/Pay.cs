using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    public class Pay:IPay
    {
        /// <summary>
        /// ������Դ����
        /// </summary>
        public Pay()
        { }

        public int CreateInfoOrder(long InfoID, string LoginName)
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
            orderid = DbHelperSQL.RunProcReturn("ShopCarTab_Order_Insert", parameters);
            return orderid;
        }
        #region ���ɹ����ֵ������
        /// <summary>
        /// ���ɹ����ֵ������
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public int CreateCardOrder(Tz888.Model.Pay model)
        {
            
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@RealName", SqlDbType.VarChar,16),
											new SqlParameter("@Email", SqlDbType.VarChar,25),
                                            new SqlParameter("@OtherInfo", SqlDbType.VarChar,50),
											new SqlParameter("@Tel", SqlDbType.VarChar,16),
											new SqlParameter("@MobileNo", SqlDbType.VarChar,20),
                                            new SqlParameter("@card1", SqlDbType.Int),
                                            new SqlParameter("@card2", SqlDbType.Int),
											new SqlParameter("@card3", SqlDbType.Int),
											new SqlParameter("@card4", SqlDbType.Int),
                                            new SqlParameter("@OrderNo", SqlDbType.BigInt,8)
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.OtherInfo;
            parameters[4].Value = model.Tel;
            parameters[5].Value = model.MobileNo;
            parameters[6].Value = model.card1;
            parameters[7].Value = model.card2;
            parameters[8].Value = model.card3;
            parameters[9].Value = model.card4;
            parameters[10].Direction = ParameterDirection.Output;
            int orderid = DbHelperSQL.RunProcReturn("ShopCarTab_Order_TofoCard", parameters);
            return orderid;
        }
        #endregion

        #region ���ɹ����ظ�ͨ��Ա����
        public int CreateVipOrder(string LoginName, string @VipType)
        {
            int orderid = 0;
            int rwaw = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@@VipType", SqlDbType.VarChar,16),
											new SqlParameter("@OrderNo", SqlDbType.BigInt,8),
			};
            parameters[0].Value = LoginName;
            parameters[1].Value = @VipType;
            parameters[2].Direction = ParameterDirection.Output;
            try
            {
                orderid = DbHelperSQL.RunProcedure("ShopCarTab_Order_Vip", parameters, out rwaw);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return orderid;
        }

        #endregion


        #region ���ɹ����û���Ϣ����

        public int CreateUserInfoOrder(string loginName, int point)
        {
            int orderid = 0;
            int rwaw = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@PointTatol", SqlDbType.Int),
                                            new SqlParameter("@BuyType", SqlDbType.VarChar,20),
											new SqlParameter("@OrderNo", SqlDbType.BigInt,8),
			};
            parameters[0].Value = loginName;
            parameters[1].Value = point;
            parameters[2].Value = "userInfo";
            parameters[3].Direction = ParameterDirection.Output;
            try
            {
                orderid = DbHelperSQL.RunProcReturn("ShopCarTab_Order_UserInfo", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return orderid;
        }

        #endregion

        #region �����û���Ϣ����

        public int ConsumePayUserInfo(long OrderNo, long view_ID, string LoginName, int pointTotal, string PayType)
        {
            int state = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@OrderNo", SqlDbType.BigInt),
                                            new SqlParameter("@View_ID", SqlDbType.BigInt),
											new SqlParameter("@LoginName", SqlDbType.Char,16),
                                            new SqlParameter("@PointTatol", SqlDbType.Int),
                                            new SqlParameter("@PayType", SqlDbType.Char,10),
											new SqlParameter("@status", SqlDbType.Int),
			};
            parameters[0].Value = OrderNo;
            parameters[1].Value = view_ID;
            parameters[2].Value = LoginName;
            parameters[3].Value = pointTotal;
            parameters[4].Value = PayType;
            parameters[5].Direction = ParameterDirection.Output;
            try
            {
                state = Convert.ToInt16(DbHelperSQL.RunProcReturn("ShopCarTab_Consume_UserInfo", parameters));
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return state;
        }

        #endregion


        #region ����֧��-��ֵ���ʻ�
        /// <summary>
        /// ��ֵ
        /// </summary>
        /// <param name="LoginName">��ֵ��</param>
        /// <param name="PointCount">��ֵ���</param>
        /// <param name="ForeignTradeNo">������ˮ��</param>
        /// <param name="StrikeType">��ֵ��ʽ</param>
        /// <returns></returns>
        public int MemberStrike(string LoginName, double PointCount, string ForeignTradeNo, string StrikeType)
        {
            int ResultFlag = 0;//���صĽ��
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@PointCount", SqlDbType.Float),
											new SqlParameter("@ForeignTradeNo", SqlDbType.VarChar,60),
											new SqlParameter("@StrikeType", SqlDbType.Char,16),
											new SqlParameter("@ResultFlag", SqlDbType.SmallInt),			
			};

            parameters[0].Value = LoginName;
            parameters[1].Value = PointCount;
            parameters[2].Value = ForeignTradeNo;
            parameters[3].Value = StrikeType;
            parameters[4].Direction = ParameterDirection.Output;
            try
            {
                ResultFlag = DbHelperSQL.RunProcReturn("MemberStrike", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            return ResultFlag;
        }
        #endregion

        #region ����֧��-���ʻ��۳����
        public int ConsumePay(long OrderNo, string LoginName, string PayType)
        {
            int ResultStatu = 0;//���صĶ���֧�����
            SqlParameter[] parameters = {
											new SqlParameter("@OrderNo", SqlDbType.BigInt),
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@PayType", SqlDbType.Char,10),
											new SqlParameter("@status", SqlDbType.SmallInt)			
										};

            parameters[0].Value = OrderNo;
            parameters[1].Value = LoginName;
            parameters[2].Value = PayType;
            parameters[3].Direction = ParameterDirection.Output;

            try
            {

                ResultStatu = DbHelperSQL.RunProcReturn("OnlinePay", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                
            }
            return ResultStatu;
        }
        #endregion

        #region Get������ϸ����
        public DataTable getOrderDetails(long OrderNo, string LoginName)
        {
            SqlParameter[] parameters = {
                                                new SqlParameter("@OrderNo", SqlDbType.BigInt),
											    new SqlParameter("@LoginName", SqlDbType.Char,16),
                                        };
            parameters[0].Value = OrderNo;
            parameters[1].Value = LoginName;
            DataSet ds = DbHelperSQL.RunProcedure("OrderDetails", parameters,"ds");
            return ds.Tables[0];
        }
        #endregion

        #region ��ӽ����ﳵ
        public bool ShopCar_Add(long InfoID, string LoginName)
        {
            SqlParameter[] parameters = {
                                                new SqlParameter("@InfoID", SqlDbType.BigInt),
											    new SqlParameter("@LoginName", SqlDbType.Char,16),
                                              };
            parameters[0].Value = InfoID;
            parameters[1].Value = LoginName;
            bool b= DbHelperSQL.RunProcLob("ShopCarTab_Insert", parameters);
            return b;
        }
        #endregion

        #region ɾ�����ﳵBYID
        public bool ShopCar_Delete(long ShopCarID)
        {
        SqlParameter[] parameters = {
                                                new SqlParameter("@ShopCarID", SqlDbType.BigInt),
                                              };
            parameters[0].Value = ShopCarID;
            bool b= DbHelperSQL.RunProcLob("ShopCarTab_Delete", parameters);
            return b;
        }
        #endregion

    }
}
