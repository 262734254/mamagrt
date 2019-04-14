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
        /// ����֧������
        /// </summary>
        /// <param name="LoginName">��¼��</param>
        /// <param name="LoginPwd">��¼����</param>
        /// <param name="PayPwd">֧������</param>
        /// <returns></returns>
        public bool changePayPwd(string LoginName, string PayPassword)
        {
            return dal.changePayPwd(LoginName, PayPassword);
        }
        /// <summary>
        /// ����֧�����뱣������
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
        /// ����ȡ��֧����������֤����
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
        /// ��֤֧������
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="PayPwd"></param>
        /// <returns></returns>
        public DataTable valiPayPwd(string LoginName, string PayPwd)
        {
            return dal.valiPayPwd(LoginName,PayPwd);
        }
         
        
        /// <summary>
        /// ��֤֧�����뱣��
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
        /// �Ƿ�������֧������
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
