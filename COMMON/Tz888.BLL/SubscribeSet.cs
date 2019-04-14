using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL
{
    public class SubscribeSet
    {
        private static readonly ISubscribeSet dal = Tz888.DALFactory.DataAccess.CreateSubscribeSet();
        /// <summary>
        /// �ƹ�����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendSet(Tz888.Model.SubscribeSet model)
        {
            return dal.SendSet(model);
        }
        /// <summary>
        /// �ƹ�����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendSet1(Tz888.Model.SubscribeSet model,out int id)
        {
            return dal.SendSet1(model,out id);
        } 
        /// <summary>
        /// �ƹ��������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public bool ReceivedSet(Tz888.Model.SubscribeGetSet model)
        {
            return dal.ReceivedSet(model);
        }
        /// <summary>
        /// �Ƿ�����ƹ�
        /// </summary>
        /// <param name="isget"></param>
        /// <returns></returns>
        public bool IsReveive(string LoginName, int isget)
        {
            return dal.IsReveive(LoginName,isget);
        }
        public bool DeleteInfo(long ID)
        {
            return dal.DeleteInfo(ID);
        }
        public bool DeleteAll(string LoginName)
        {
            return dal.DeleteAll(LoginName);
        }
        /// <summary>
        /// �޸ķ���״̬
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool isSend(string ReceiveLoginName)
        {
            return dal.isSend(ReceiveLoginName);
        }
        /// <summary>
        /// �����ƹ�������б�
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetReceivedList(string strWhere)
        {
            return dal.GetReceivedList(strWhere);
        }
        /// <summary>
        /// ��Դ���Ľ������б�
        /// </summary>
        /// <param name="LoginName">LoginNameΪ"" ȡ���ж����˵�loginname,����ΪȡLoginName�Ķ����б�ID</param>
        /// <returns></returns>
        public DataTable GetMachInfoList(string LoginName)
        {
            return dal.GetMachInfoList(LoginName);
        }
         /// <summary>
        /// ����ID��ѯ��������Ϣ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Tz888.Model.SubscribeSet GetModels(int Id, out string infotypeid, out string htmlFile)
        {
            return dal.GetModels(Id, out infotypeid, out htmlFile);
        }
        /// <summary>
        /// ��Ա����Ԥ��֪ͨ
        /// </summary>
        /// <returns></returns>
        public DataTable GetMemberExpiredList()
        {
            return dal.GetMemberExpiredList();
        }
        /// <summary>
        /// ��Դ����Ԥ��֪ͨ
        /// </summary>
        /// <returns></returns>
        public DataTable GetInfoExpiredList()
        {
            return dal.GetInfoExpiredList();
        }
        public Tz888.Model.SubscribeGetSet GetModel(string LoginName)
        {
            return dal.GetModel(LoginName);
        }
        public bool Update(int id, string subType)
        {
            return dal.Update(id, subType);
        }
         /// <summary>
        /// ������ϸ��
        /// ����ID��orderNo������SmsConsumeRecTab��
        /// </summary>
        public bool UpdateSmsConsumeRecTab(int Recid)
        {
            return dal.UpdateSmsConsumeRecTab(Recid);
        }
         /// <summary>
        /// �����ƹ㣬��ϸ��¼
        /// </summary>
        public bool Insert(Tz888.Model.SubscribeSetTabLog model)
        {
            return dal.Insert(model);
        }
         /// <summary>
        /// ��������ƥ�����������������ȡ���е���Ŀ����
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="infoTypeId"></param>
        /// <returns></returns>
        public string GetDescript(long infoId, string infoTypeId, out string descript)
        {
            return dal.GetDescript(infoId, infoTypeId, out descript);
        }
    }
}
