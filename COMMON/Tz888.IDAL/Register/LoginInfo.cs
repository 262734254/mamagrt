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

      //��ȡ��Ա�ȼ�(��ͨ1001���ظ�ͨ1002���ظ�ͨ����1003)
        string GetMemberGradeID(string loginName);

        string GetManageTypeID(string loginName);

        string GetPropertyID(string loginName);

    //����ע��(���Ӽ�¼������)
        bool InviterRegiste(string ip, string email, string loginName);
    }
}
