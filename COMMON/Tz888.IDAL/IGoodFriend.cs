using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IGoodFriend
    {
        void BlackListManage(int contactId,int flag);//����������  flag:0 ���������    1 �������ָ����� 
        void DeleteFriend(int contactId);//����ɾ������
        void AddFriend(Tz888.Model.GoodFriend model);//��Ӻ���

        bool IsSpecices(string loginName, string contactName, int type);//�������û��������û�

        #region  ��ɧ������
        //��ȡ����
        Tz888.Model.GoodFriend GetFriendSet(string loginName);     
        //���÷�ɧ��
        void SetFriendSet(Tz888.Model.GoodFriend model);
        //�����������
        DataTable ResourceRefresh(Tz888.Model.GoodFriend model);
        //�������ϸ���
        DataTable MemberInfoRefresh(Tz888.Model.GoodFriend model);
        // --���ѹ�˾�Ǽ�--
         bool EnterpriseRefresh(Tz888.Model.GoodFriend model);
        #endregion
    }
}
