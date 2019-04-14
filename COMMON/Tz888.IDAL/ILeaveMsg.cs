using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ILeaveMsg
    {
        //��ȡ�ظ�����
        Tz888.Model.LeaveMsg ReadComment(int ID, int type);//0 ��ȡ������Ϣ  1 ��ȡ�ظ�����
        //���ûظ�����
        bool SetResponse(Tz888.Model.LeaveMsg model);
        //ɾ������
        bool DeleteLeaveMsg(int ID, int flag);//0 ����ɾ������  1 ��Զɾ������
        //�������Թ���
        bool PublishManageLeaveMsg(Tz888.Model.LeaveMsg model);
        //�ָ��������ռ���
        bool RestoreLeaveMsg(int ID);
        //ͳ����������
        int GetCount(long InfoID);
        //�����Ƿ񹫿�
        int IsAuditLeaveMsg(string IDStr, int audit);
    }
}
