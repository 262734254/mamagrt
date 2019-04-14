using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Tz888.DALFactory;
using Tz888.IDAL;

namespace Tz888.BLL.Email
{
    public class EmailBLL
    {
        private readonly Tz888.IDAL.Email.IEmail dal = DataAccess.CreateIEmailDAL();

        public EmailBLL()
        {
        }

        #region 邮件分组

        //获取所有的分组
        public DataTable getEmailGroup()
        {
            return dal.getEmailGroup();
        }

        //获取一个分组
        public Tz888.Model.Email.EmailUserModel getEmailGroupByID(int groupID)
        {
            return dal.getEmailGroupByID(groupID);
        }

        //添加分组
        public int addEmailGroup(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.addEmailGroup(emodel);
        }

        //修改分组
        public int modifyEmailGroup(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.modifyEmailGroup(emodel);
        }

        //删除分组
        public int delEmailGroup(int groupID)
        {
            return dal.delEmailGroup(groupID);
        }

        #endregion


        #region 邮件用户

        //获取所有的邮件用户
        public DataTable getEmailUser()
        {
            return dal.getEmailUser();
        }
        
        public int isEmailUser(string name, string email)
        {
            return dal.isEmailUser(name, email);
        }

        public DataTable getTopEmailUser(int top)
        {
            return dal.getTopEmailUser(top);
        }

        public DataTable getEmailUserByGID(int Group_ID)
        {
            return dal.getEmailUserByGID(Group_ID);
        }

        //获取某个组的邮件用户
        public Tz888.Model.Email.EmailUserModel getEmailUser(int groupID)
        {
            return dal.getEmailUser(groupID);
        }

        //添加邮件用户
        public int addEmailUser(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.addEmailUser(emodel);
        }

        //修改邮件用户
        public int modifyEmailUser(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.modifyEmailUser(emodel);
        }

        //删除邮件用户
        public int delEmailUser(int UserID)
        {
            return dal.delEmailUser(UserID);
        }

        #endregion



        #region 群发过的邮件记录
        public int addEmail(Tz888.Model.Email.EmailModel model, List<Tz888.Model.Email.EmailAnnexModel> EmailAnnex)
        {
            return dal.addEmail(model, EmailAnnex);
        }
        #endregion


        #region 群发邮件记录日志
        public int addEmailLog(Tz888.Model.Email.EmailLogModel model)
        {
            return dal.addEmailLog(model); ;
        }
        #endregion

        #region 检查用户是否重复
        public bool CheckUser(string userID, string UserEmail, string EUserID)
        {
            return dal.CheckUser(userID, UserEmail,EUserID);
        }
        #endregion

    }
}
