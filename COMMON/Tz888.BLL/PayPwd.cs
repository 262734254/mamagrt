using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
    public class PayPwd
    {
        private readonly IPayPwd dal = DataAccess.CreateIPayPwd();
        
        /// <summary>
        /// 设置支付密码
        /// </summary>
        /// <param name="LoginName">登录名</param>
        /// <param name="LoginPwd">登录密码</param>
        /// <param name="PayPwd">支付密码</param>
        /// <returns></returns>
        public bool changePayPwd(string LoginName, string PayPassword)
        {
            return dal.changePayPwd(LoginName, PayPassword);
        }
        /// <summary>
        /// 设置支付密码保护问题
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Question"></param>
        /// <param name="Answer"></param>
        /// <returns></returns>
        public bool setPwdQuestion(string LoginName, string Question, string Answer,string Email)
        {
            return dal.setPwdQuestion(LoginName, Question, Answer,Email);
        }
        /// <summary>
        /// 设置取回支付密码的身份证号码
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="RealName"></param>
        /// <param name="CardID"></param>
        /// <returns></returns>
        public bool setCardID(string LoginName, string RealName, string CardID)
        {
            return dal.setCardID(LoginName,RealName,CardID);
        }
        /// <summary>
        /// 验证支付密码
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PayPwd"></param>
        /// <returns></returns>
        public DataTable valiPayPwd(string LoginName, string PayPwd)
        {
            return dal.valiPayPwd(LoginName,PayPwd);
        }
         
        
        /// <summary>
        /// 验证支付密码保护
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="Question"></param>
        /// <param name="Answer"></param>
        /// <returns></returns>
        public DataTable valiPayAsk(string LoginName, string Question, string Answer)
        {
            return dal.valiPayAsk(LoginName, Question, Answer);
        }
       
        /// <summary>
        /// 是否设置了支付密码
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool isSetPwd(string LoginName)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("PayPwdTab", "PayPassword", "QID", 1, 1, 0, 1, "LoginName='"+LoginName+"'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PayPassword"].ToString()!= "" || dt.Rows[0]["PayPassword"] != null || dt.Rows[0]["PayPassword"].ToString()!= null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public string isAsk(string LoginName)
        {
            Conn dal = new Conn();
            DataTable dt = dal.GetList("paypwdtab", "loginname,question,answer", "QID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["question"].ToString();
            }
            else
            {
                return "";
            }
        }
        public DataTable valiLoginPwd(string LoginName, string LoginPwd)
        {
            return dal.valiLoginPwd(LoginName, LoginPwd);
        }
    }
}
