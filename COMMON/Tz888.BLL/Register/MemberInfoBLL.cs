using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;
using Tz888.IDAL.Register;
using Tz888.DALFactory;
namespace Tz888.BLL.Register
{
    public class MemberInfoBLL
    {
        private readonly IMemberInfo dal = DataAccess.CreateIMemberInfo();
        /// <summary>
        /// ���������õ���Ա��Ϣ��һ������ʵ��
        /// </summary>
        public Tz888.Model.Register.MemberInfoModel GetModel(string strCriteria)
        {
            return dal.GetModel(strCriteria);
        } 

        public Tz888.Model.LoginInfo GetLoginInfoModel(string strCriteria)
        {
            return dal.GetLoginInfoModel(strCriteria);
        }
        //--------------
        public string GetEmailByLoginName(string loginName)
        {
            return dal.GetEmailByLoginName(loginName);
        }

        //���ӻ���
        public void AddIntegral(string loginName, int integral)
        {
            dal.AddIntegral(loginName, integral);
        }

        #region-- ����NickName����LoginName  ---------------
        public string getLoginName(string NickName)
        {
            return dal.getLoginName(NickName);
        }
        #endregion

        #region--  ����LoginName����NickName  ---------------
        public string getNickName(string LoginName)
        {
            return dal.getNickName(LoginName);
        }
        #endregion

        public int MemberMessage_Insert(Tz888.Model.Register.MemberInfoModel model)
        {
            return dal.MemberMessage_Insert(model);
        }

        public int MemberMessage_Update(Tz888.Model.Register.MemberInfoModel model)
        {
            return dal.MemberMessage_Update(model);
        }
        //����û���
        public int ValideNameUseable(string name)
        {
            return dal.ValideNameUseable(name);
        }
        //����ǳ�
        public int ValidNikeName(string name)
        {
            return dal.ValideNikeName(name);
        }

        /// <summary>
        /// ����ֵ�������Ƿ���ȷ
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int RechargeCard(string card)
        {
            return dal.RechargeCard(card);
        }

        public int CardPassWord(string passWord, string Card)
        {
            return dal.CardPassWord(passWord, Card);
        }
        public string CarMoney(string Number)
        {
            return dal.CarMoney(Number);
        }
        /// <summary>
        /// ����ֵ�����Ƿ񱻳�ֵ
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int RechargeStateCard(string card)
        {
            return dal.RechargeStateCard(card);
        }
        //���EMAIL
        public int ValidEmail(string email)
        {
            return dal.ValidEmail(email);
        }
        //��ȡ��Ա��ע������
        public string GetEmail(string LoginName)
        {
            return dal.GetEmail(LoginName); 
        }

        public string GetMobileByName(string LoginName)
        {
            return dal.GetMobileByName(LoginName);
        }

        public string RndNum(int VcodeNum)
        {
            return dal.RndNum(VcodeNum);
        }

        public string GetLoginNameByEmail(string strEmail)
        {
            return dal.GetLoginNameByEmail(strEmail);
        }

        public string GetQuestionByEmail(string LoginName)
        {
            return dal.GetQuestionByEmail(LoginName);
        }
        public string GetAnswerByEmail(string LoginName)
        {
            return dal.GetAnswerByEmail(LoginName);
        }
    }
}
