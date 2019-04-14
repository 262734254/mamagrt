using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Email
{
    public interface IEmail
    {
        #region �ʼ�����

        //��ȡ���еķ���
        DataTable getEmailGroup();

        //��ȡһ������
        Tz888.Model.Email.EmailUserModel getEmailGroupByID(int groupID);

        //��ӷ���
        int addEmailGroup(Tz888.Model.Email.EmailUserModel emodel);

        //�޸ķ���
        int modifyEmailGroup(Tz888.Model.Email.EmailUserModel emodel);

        //ɾ������;
        int delEmailGroup(int groupID);

        #endregion


        #region �ʼ��û�

        //��ȡ���е��ʼ��û�
        DataTable getEmailUser();

        int isEmailUser(string name, string email);

        DataTable getTopEmailUser(int top);

        DataTable getEmailUserByGID(int Group_ID);

        //��ȡĳ������ʼ��û�
        Tz888.Model.Email.EmailUserModel getEmailUser(int groupID);

        //����ʼ��û�
        int addEmailUser(Tz888.Model.Email.EmailUserModel emodel);

        //�޸��ʼ��û�
        int modifyEmailUser(Tz888.Model.Email.EmailUserModel emodel);

        //ɾ���ʼ��û�
        int delEmailUser(int UserID);

        #endregion


        #region Ⱥ�������ʼ���¼
        int addEmail(Tz888.Model.Email.EmailModel model, List<Tz888.Model.Email.EmailAnnexModel> EmailAnnex);

        #endregion


        #region Ⱥ���ʼ���¼��־
        int addEmailLog(Tz888.Model.Email.EmailLogModel model);

        #endregion

         #region ����û��Ƿ��ظ�
        bool CheckUser(string userID, string UserEmail,string EUserID);
        #endregion
    }
}
