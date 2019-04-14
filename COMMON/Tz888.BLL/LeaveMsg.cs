using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;


namespace Tz888.BLL
{
    public class LeaveMsg
    {
        private readonly Tz888.IDAL.ILeaveMsg dal = Tz888.DALFactory.DataAccess.CreateILeaveMsg();
        Tz888.BLL.SendNotice Noction = new Tz888.BLL.SendNotice();
        
        //��ȡ����
        public Tz888.Model.LeaveMsg GetComment(int ID, int type) //0 ��ȡ������Ϣ  1 ��ȡ�ظ�����
        {
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            model = dal.ReadComment(ID,type);           
            return model;
        }
        
        //���ûظ�����
        public bool SetResponse(Tz888.Model.LeaveMsg model)
        {
            bool result = false;
            result = dal.SetResponse(model);
            #region ���Իظ�֪ͨ
            if (result)
            {
                string Contents = model.LoginName+"�ظ���������Դ��Ϣ!";
                string Title = "���Իظ�֪ͨ";
                Noction.GetMaininfo(model.InfoID.ToString(), Contents, Title);
            }
            #endregion

            return result;
        }
        //ɾ������
        public bool DeleteLeaveMsg(int ID, int flag)//flag 0 ����ɾ������  1 ��Զɾ������
        {
            bool result = false;
            result = dal.DeleteLeaveMsg(ID,flag);
            return result;
        }
        //�������Թ���
        public bool PublishManageLeaveMsg(Tz888.Model.LeaveMsg model)
        {
            bool result = false;
            result = dal.PublishManageLeaveMsg(model);
            return result; 
        }
        //�ָ����յ�����
        public bool RestoreLeaveMsg(int ID)
        {
            bool result = false;
            result = dal.RestoreLeaveMsg(ID);
            return result;
        }

        //ͳ����Ϣ��������Ŀ
        public int GetCount(long InfoID)
        {
            return dal.GetCount(InfoID);
        }

        public int IsAuditLeaveMsg(string IDStr, int audit)
        {
            return dal.IsAuditLeaveMsg(IDStr, audit);
        }
    }
}
