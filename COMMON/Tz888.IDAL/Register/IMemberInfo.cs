using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
namespace Tz888.IDAL.Register
{
    public interface IMemberInfo
    {
       /// <summary>
        /// 根据条件得到一个对象实体MemberInfoTab
        /// </summary>
       Tz888.Model.Register.MemberInfoModel GetModel(string strCriteria);
        /// <summary>
        /// 根据条件得到一个对象实体LoginInfoTab
        /// </summary>
        Tz888.Model.LoginInfo GetLoginInfoModel(string strCriteria);

        string GetEmailByLoginName(string loginName);

        void AddIntegral(string loginName, int integral);

        string getLoginName(string NickName);

        string getNickName(string LoginName);
        //修改会员信息
        int MemberMessage_Insert(Tz888.Model.Register.MemberInfoModel model);
        int MemberMessage_Update(Tz888.Model.Register.MemberInfoModel model);
        
        //检查用户名是否可注册
        int ValideNameUseable(string name);

        //检查用户名是否可注册
        int CardPassWord(string passWord, string Card);
        //检查充值卡卡号是否正确
        int RechargeCard(string card);
        /// <summary>
        /// 检查充值卡号是否被充值
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        int RechargeStateCard(string card);
        /// <summary>
        /// 根据卡号查金额
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        string CarMoney(string Number);
       
            

        //检查昵称是否可注册
        int ValideNikeName(string name);

        //检查EMAIL是否可注册
        int ValidEmail(string email);

        //获取会员的注册邮箱
        string GetEmail(string LoginName);

        string GetMobileByName(string LoginName);

        string RndNum(int VcodeNum);

        string GetLoginNameByEmail(string strEmail);

        string GetQuestionByEmail(string LoginName);
        string GetAnswerByEmail(string LoginName);
    }
}
