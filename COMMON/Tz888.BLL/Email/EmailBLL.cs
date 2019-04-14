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

        #region �ʼ�����

        //��ȡ���еķ���
        public DataTable getEmailGroup()
        {
            return dal.getEmailGroup();
        }

        //��ȡһ������
        public Tz888.Model.Email.EmailUserModel getEmailGroupByID(int groupID)
        {
            return dal.getEmailGroupByID(groupID);
        }

        //��ӷ���
        public int addEmailGroup(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.addEmailGroup(emodel);
        }

        //�޸ķ���
        public int modifyEmailGroup(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.modifyEmailGroup(emodel);
        }

        //ɾ������
        public int delEmailGroup(int groupID)
        {
            return dal.delEmailGroup(groupID);
        }

        #endregion


        #region �ʼ��û�

        //��ȡ���е��ʼ��û�
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

        //��ȡĳ������ʼ��û�
        public Tz888.Model.Email.EmailUserModel getEmailUser(int groupID)
        {
            return dal.getEmailUser(groupID);
        }

        //����ʼ��û�
        public int addEmailUser(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.addEmailUser(emodel);
        }

        //�޸��ʼ��û�
        public int modifyEmailUser(Tz888.Model.Email.EmailUserModel emodel)
        {
            return dal.modifyEmailUser(emodel);
        }

        //ɾ���ʼ��û�
        public int delEmailUser(int UserID)
        {
            return dal.delEmailUser(UserID);
        }

        #endregion



        #region Ⱥ�������ʼ���¼
        public int addEmail(Tz888.Model.Email.EmailModel model, List<Tz888.Model.Email.EmailAnnexModel> EmailAnnex)
        {
            return dal.addEmail(model, EmailAnnex);
        }
        #endregion


        #region Ⱥ���ʼ���¼��־
        public int addEmailLog(Tz888.Model.Email.EmailLogModel model)
        {
            return dal.addEmailLog(model); ;
        }
        #endregion

        #region ����û��Ƿ��ظ�
        public bool CheckUser(string userID, string UserEmail, string EUserID)
        {
            return dal.CheckUser(userID, UserEmail,EUserID);
        }
        #endregion

    }
}
