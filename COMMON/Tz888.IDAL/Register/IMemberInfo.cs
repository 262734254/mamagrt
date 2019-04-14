using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
namespace Tz888.IDAL.Register
{
    public interface IMemberInfo
    {
       /// <summary>
        /// ���������õ�һ������ʵ��MemberInfoTab
        /// </summary>
       Tz888.Model.Register.MemberInfoModel GetModel(string strCriteria);
        /// <summary>
        /// ���������õ�һ������ʵ��LoginInfoTab
        /// </summary>
        Tz888.Model.LoginInfo GetLoginInfoModel(string strCriteria);

        string GetEmailByLoginName(string loginName);

        void AddIntegral(string loginName, int integral);

        string getLoginName(string NickName);

        string getNickName(string LoginName);
        //�޸Ļ�Ա��Ϣ
        int MemberMessage_Insert(Tz888.Model.Register.MemberInfoModel model);
        int MemberMessage_Update(Tz888.Model.Register.MemberInfoModel model);
        
        //����û����Ƿ��ע��
        int ValideNameUseable(string name);

        //����û����Ƿ��ע��
        int CardPassWord(string passWord, string Card);
        //����ֵ�������Ƿ���ȷ
        int RechargeCard(string card);
        /// <summary>
        /// ����ֵ�����Ƿ񱻳�ֵ
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        int RechargeStateCard(string card);
        /// <summary>
        /// ���ݿ��Ų���
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        string CarMoney(string Number);
       
            

        //����ǳ��Ƿ��ע��
        int ValideNikeName(string name);

        //���EMAIL�Ƿ��ע��
        int ValidEmail(string email);

        //��ȡ��Ա��ע������
        string GetEmail(string LoginName);

        string GetMobileByName(string LoginName);

        string RndNum(int VcodeNum);

        string GetLoginNameByEmail(string strEmail);

        string GetQuestionByEmail(string LoginName);
        string GetAnswerByEmail(string LoginName);
    }
}
