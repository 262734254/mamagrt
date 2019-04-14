using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
   public  class PayPwd:IPayPwd
    {
       //支付密码设置
       public PayPwd()
       {
       }

       #region 设置支付密码
       /// <summary>
       /// 设置支付密码
       /// </summary>
       /// <param name="LoginName"></param>
       /// <param name="paypwd"></param>
       /// <returns></returns>
       public bool changePayPwd(string LoginName, string PayPassword)
       {
           bool b = false;
           SHA1 sha1 = SHA1.Create();
           byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(PayPassword));
           SqlParameter[] parameters = {
				
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@PayPassword", SqlDbType.VarBinary,50),
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					};

           parameters[0].Value = LoginName;
           parameters[1].Value = bytePassword;
           parameters[2].Value = "setPayPwd";
           try
           {
               b = DbHelperSQL.RunProcLob("PayPwd", parameters);
           }
           catch
           { }
          
           return b;

       }
       #endregion

       #region 设置密码保护问题
       /// <summary>
       /// 设置密码保护问题
       /// </summary>
       /// <param name="LoginName"></param>
       /// <param name="Question"></param>
       /// <param name="Answer"></param>
       /// <returns></returns>
       public bool setPwdQuestion(string LoginName, string Question, string Answer,string Email)
       {
           bool b = false;
           SqlParameter[] parameters = {
				
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@Question", SqlDbType.VarChar,50),
                    new SqlParameter("@Answer", SqlDbType.VarChar,50),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
                    
					};

           parameters[0].Value = LoginName;
           parameters[1].Value = Question;
           parameters[2].Value = Answer;
           parameters[3].Value = Email;
           parameters[4].Value = "setQuestion";
           try
           {
               b = DbHelperSQL.RunProcLob("PayPwd", parameters);
           }
           catch
           { }
           return b;
       }
        #endregion

       #region 密码保护身份证
       /// <summary>
       /// 设置密码保护身份证
       /// </summary>
       /// <param name="LoginName"></param>
       /// <param name="RealName"></param>
       /// <param name="CardID"></param>
       /// <returns></returns>
       public bool setCardID(string LoginName, string RealName, string CardID)
       {
           bool b = false;
           SqlParameter[] parameters = {
				
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@RealName", SqlDbType.Char,16),
					new SqlParameter("@CardID", SqlDbType.VarChar,50),
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					};

           parameters[0].Value = LoginName;
           parameters[1].Value = RealName;
           parameters[2].Value = CardID;
           parameters[3].Value = "setPwdCardID";
           try
           {
               b = DbHelperSQL.RunProcLob("PayPwd", parameters);
           }
           catch
           { }
           return b;
       }

       #endregion

       #region 验证支付密码
       public DataTable valiPayPwd(string LoginName,string PayPwd)
       {
           DataSet ds = null;
           SHA1 sha1 = SHA1.Create();
           byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(PayPwd));
           SqlParameter[] parameters = {
				
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@PayPassword", SqlDbType.VarBinary,50),
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					};

           parameters[0].Value = LoginName;
           parameters[1].Value = bytePassword;
           parameters[2].Value = "valipaypwd";
           try
           {
              ds = DbHelperSQL.RunProcedure("PayPwd", parameters,"ds");
           }
           catch
           { }
           return ds.Tables[0];
       }
       #endregion

       #region 验证支付密码保护 
       public DataTable valiPayAsk(string LoginName,string Question,string Answer)
       {
           DataSet ds = null;
           SqlParameter[] parameters = {
				
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@Question", SqlDbType.VarChar,50),
					new SqlParameter("@Answer", SqlDbType.VarChar,50),
                    new SqlParameter("@flag", SqlDbType.VarChar,50),
					};

           parameters[0].Value = LoginName;
           parameters[1].Value = Question;
           parameters[2].Value = Answer;
           parameters[3].Value = "valipayask";
           try
           {
               ds = DbHelperSQL.RunProcedure("PayPwd", parameters,"ds");
           }
           catch
           { }
           return ds.Tables[0];
       }
       #endregion
       #region 验证登录密码
       public DataTable valiLoginPwd(string LoginName, string LoginPwd)
       {
           DataSet ds = null;
           SHA1 sha1 = SHA1.Create();
           byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(LoginPwd));
           SqlParameter[] parameters = {
				
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@PayPassword", SqlDbType.VarBinary,50),
											new SqlParameter("@flag", SqlDbType.VarChar,50),
			};

           parameters[0].Value = LoginName;
           parameters[1].Value = bytePassword;
           parameters[2].Value = "valiloginpwd";
           try
           {
               ds = DbHelperSQL.RunProcedure("PayPwd", parameters, "ds");
           }
           catch
           { }
           return ds.Tables[0];
       }
       #endregion	

   }
}
