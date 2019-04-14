using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Register
{
    public interface LoginInfo
    {
       void LogInfoAdd(Tz888.Model.Register.LoginInfoModel model);
       int UpdateLoginPropertyID(string str,int par, int ManagerTypeId);
        int UpdateLoginCompanyName(string loginName, string Company,string Conecname,string Conectitle);
        int CheckLoginName(string name);
        void ValidUser(string loginname);

        string GetManagerType(string managerTypeID);

        void ChangeEmail(string loginName, string newEmail);

      //获取会员等级(普通1001，拓富通1002，拓富通试用1003)
        string GetMemberGradeID(string loginName);

        string GetManageTypeID(string loginName);

        string GetPropertyID(string loginName);

    //邀请注册(增加记录及积分)
        bool InviterRegiste(string ip, string email, string loginName);
    }
}
