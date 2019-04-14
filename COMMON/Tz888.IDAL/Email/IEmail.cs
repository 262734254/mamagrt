using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Email
{
    public interface IEmail
    {
        #region 邮件分组

        //获取所有的分组
        DataTable getEmailGroup();

        //获取一个分组
        Tz888.Model.Email.EmailUserModel getEmailGroupByID(int groupID);

        //添加分组
        int addEmailGroup(Tz888.Model.Email.EmailUserModel emodel);

        //修改分组
        int modifyEmailGroup(Tz888.Model.Email.EmailUserModel emodel);

        //删除分组;
        int delEmailGroup(int groupID);

        #endregion


        #region 邮件用户

        //获取所有的邮件用户
        DataTable getEmailUser();

        int isEmailUser(string name, string email);

        DataTable getTopEmailUser(int top);

        DataTable getEmailUserByGID(int Group_ID);

        //获取某个组的邮件用户
        Tz888.Model.Email.EmailUserModel getEmailUser(int groupID);

        //添加邮件用户
        int addEmailUser(Tz888.Model.Email.EmailUserModel emodel);

        //修改邮件用户
        int modifyEmailUser(Tz888.Model.Email.EmailUserModel emodel);

        //删除邮件用户
        int delEmailUser(int UserID);

        #endregion


        #region 群发过的邮件记录
        int addEmail(Tz888.Model.Email.EmailModel model, List<Tz888.Model.Email.EmailAnnexModel> EmailAnnex);

        #endregion


        #region 群发邮件记录日志
        int addEmailLog(Tz888.Model.Email.EmailLogModel model);

        #endregion

         #region 检查用户是否重复
        bool CheckUser(string userID, string UserEmail,string EUserID);
        #endregion
    }
}
