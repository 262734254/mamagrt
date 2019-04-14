using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;
using Tz888.IDAL.Register;
using Tz888.DALFactory;

namespace Tz888.BLL.Register
{
   public class LoginInfoBLL
    {
       private readonly LoginInfo dal = DataAccess.CreateLoginInfo();
        //会员注册
       public void LogInfoAdd(Tz888.Model.Register.LoginInfoModel model)
       {
           dal.LogInfoAdd(model);
       }
       public int UpdateLoginCompanyName(string loginName, string Company,string ConnectName,string ConnectTitle)
       {
           return dal.UpdateLoginCompanyName(loginName, Company, ConnectName,ConnectTitle);
       }
       public int UpdateLoginPropertyID(string str, int par, int ManagerTypeId)
       {
           return dal.UpdateLoginPropertyID(str, par, ManagerTypeId);
       }
       public   int CheckLoginName(string name)
       {
           return dal.CheckLoginName(name);
       }
       //会员验证

       public void ValidUser(string loginname)
       {
           dal.ValidUser(loginname);
       }

       //获取用户类型
       public string GetManagerType(string loginName)
       {
           return dal.GetManagerType(loginName);
       }

       //更改用户邮箱

       public void ChangeEmail(string loginName, string newEmail)
       {
           dal.ChangeEmail(loginName, newEmail);
       }


       //获取会员等级(普通1001，拓富通1002，拓富通试用1003)
       public string GetMemberGradeID(string loginName)
       {
           return dal.GetMemberGradeID(loginName).Trim();
       }

       //获取用户类型(政府招商机构2001，投资方2002，项目方2003,中介机构2004)
       public string GetManageTypeID(string loginName)
       {
           return dal.GetManageTypeID(loginName);
       }

       //获取会员属性ID(0:企业;1:个人;2:招商机构;3:中介机构)
       public string GetPropertyID(string loginName)
       {
           return dal.GetPropertyID(loginName);
       }
       
       // 邀请注册(增加记录及积分)
       /// <summary>
       /// 邀请的朋友注册
       /// </summary>
       /// <param name="ip">受邀者IP</param>
       /// <param name="email">受邀者邮箱</param>
       /// <param name="loginName">邀请人登陆名</param>
       /// <returns></returns>
       public bool InviterRegiste(string ip, string email, string loginName)
       {
           return dal.InviterRegiste(ip, email, loginName);
       }
    }
}
