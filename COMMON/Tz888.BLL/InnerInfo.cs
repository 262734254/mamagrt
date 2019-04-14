using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// ҵ���߼���InnerInfo ��ժҪ˵����
    /// </summary>
    public class InnerInfo
    {
        private readonly IInnerInfo dal = DataAccess.CreateIInnerInfo();


        #region  �ռ����Ա����
        ///<summary>
        ///�߼����飩ɾ������ 
        ///</summary>      
        public bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID)
        {
            bool bl = false;
            bl = dal.InfoReceivedTabVirtualDelete(LoginName, ReceivedID);
            return bl;
        }

        //ȡ�ռ�������Ϣ
        public Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID)
        {
            Tz888.Model.InnerInfoReceived model = new Tz888.Model.InnerInfoReceived();
            model = dal.ReadInfo(ReceivedID);
            return model;
        }

        //// ȡ�ռ�������Ϣ
        //public bool GetReceivedInfo()
        //{
        //    bool bl = false;
        //    Invest.DataClass.InnerInfo obj = new Invest.DataClass.InnerInfo();
        //    if (obj.GetReceivedInfo(this.ReceivedID.ToString()))
        //    {
        //        this.Topic = obj.Topic;
        //        this.Context = obj.Context;
        //        this.SendedMan = obj.SendedMan;
        //        this.ReceivedTime = obj.ReceivedTime;
        //        bl = true;
        //    }
        //    return bl;
        //}

        #endregion

        #region ������Ϣ
        //ִ�з�����Ϣ
        public bool SendInfo(Tz888.Model.InnerInfoSend model)
        {
            bool bl = false;
            bl = dal.SendInfo(model);
            return bl;
        }

        ////ִ�б�����Ϣ
        //public bool SaveInfo()
        //{
        //    bool bl = false;
        //    Invest.DataClass.InnerInfo obj = new Invest.DataClass.InnerInfo();
        //    obj.SendID = this.SendID;
        //    obj.LoginName = this.LoginName;
        //    obj.ReceivedMan = this.ReceivedMan;
        //    obj.Topic = this.Topic;
        //    obj.Context = this.Context;
        //    obj.Size = this.Size;
        //    if (obj.ExecSaveInfoSP())
        //    {
        //        bl = true;
        //    }
        //    return bl;
        //}

        #endregion

        #region �ҷ�������Ϣ

        //�߼����飩ɾ������
        public bool InfoSendTabVirtualDelete(string LoginName, int SendID)
        {
            bool bl = false;
            bl = dal.InfoSendTabVirtualDelete(LoginName, SendID);
            return bl;
        }
        #endregion

        #region ������

        //ִ������ɾ������(ѡ����Ϣ)
        public bool DeleteWasterInfo(int WasterID)
        {
            bool bl = false;
            bl = dal.DeleteWasterInfo(WasterID);
            return bl;
        }
        //��շϼ��䣨ȫ����
        public bool DeleteAllWasterInfo(string LoginName)
        {
            bool bl = false;
            bl = dal.DeleteAllWasterInfo(LoginName);
            return bl;
        }

        ////ȡ�ϼ�������Ϣ
        //public Tz888.Model.InnerInfoWaster GetWasterInfo(int WasterID)
        //{
        //    return dal.GetModel(WasterID);
        //}
        #endregion

        #region ���÷���
        /// <summary>
        /// �õ�վ����Ϣ�б�
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <param name="InfoStatus">��Ϣ״̬��0���ռ���Ϣ 1����������Ϣ��2����������Ϣ���߼�����������      
        /// <param name="ReadCondition">����ʱ�䣺0����յ�����Ϣ 1�����ڡ�2�����ڡ�3һ�����ڡ�4�������ڡ�5����������</param>
        /// <returns>վ����Ϣ�б�</returns>

        public DataTable GetInfoList(
            string LoginName,
            int InfoStatus,
            string ReadCondition,
            int PageSize,
            int PageIndex,
            int doCount)
        {
            string strNickName = "";
            //     *****************************GetMemberNameByLoginName δʵ��
            /*DataTable dt = obj.GetMemberNameByLoginName(LoginName, "0");
            if (dt.Rows.Count > 0)
            {
                strNickName = dt.Rows[0]["NickName"].ToString().Trim();
            }*/
            strNickName = "kittycat";
            //********************************************************

            if (ReadCondition != "")
            {
                ReadCondition = " AND " + ReadCondition;
            }

            DataTable dt;
            switch (InfoStatus)
            {
                case 0: //�ռ���
                    dt = dal.GetInfoList("InnerInfoReceivedTab", "*", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='��˫��'" + ReadCondition);//'" + strNickName + "'");
                    break;
                case 1: //������                 
                    dt = dal.GetInfoList("InnerInfoSendTab", "*", "SendID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'" + ReadCondition);
                    break;
                case 2://��������Ϣ               
                    dt = dal.GetInfoList("InnerInfoWasterTab", "*", "WasterID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "' " + ReadCondition);
                    break;
                default:
                    dt = null;
                    break;
            }
            return (dt);
        }

        #endregion

        #region �����б�
        public DataTable getFriends(string loginName)
        {
            return dal.getFriends(loginName);
        }
        #endregion

        #region sunray BLL����
        public bool InfoVirtualDelete(string LoginName, int InfoID, int TableType, string flag)
        {
            bool result = dal.InfoVirtualDelete(LoginName, InfoID, TableType, flag);
            return result;
        }
        public void ReadInfoSet(int receiveId)//0 �ռ��� �� 1 ������
        {
            bool result = dal.ReadInfoSet(receiveId);
        }
        public bool SendInfoBLL(Tz888.Model.InnerInfo model, bool isChecked)
        {
            bool result = false;
            if (isChecked)
            {
                dal.SaveInfoIDAL(model);
                result = dal.SendInfoIDAL(model);
            }
            else
            {
                result = dal.SendInfoIDAL(model);
            }
            return result;
        }

        public Tz888.Model.InnerInfo GetInfoContext(int InfoId, int infoTable)  //ReceiveId ��ѯ���� �� infoTable ��ѯ���
        {
            Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
            model = dal.GetInfoContext(InfoId, infoTable);
            return model;
        }
        #endregion

        #region ��ȡ���ж���Ⱥ��
        public DataSet GetMsgGroup()
        {
            return dal.GetMsgGroup();
        }
        #endregion

        #region ����Ⱥ�鷢��
        public int SendMsgToGroup(int ReceivedGroupID, string CONTEXT,string Topic, bool isRead, bool isSent, string SendName, DateTime ReceiveTime, string readName, DateTime Created, string Createby)
        {
            return dal.SendMsgToGroup(ReceivedGroupID, CONTEXT, Topic, isRead, isSent, SendName, ReceiveTime, readName, Created, Createby);
        }
        #endregion

        #region �����µ�Ⱥ����Ϣ
        public void CheckNewGroupMsg(string loginName)
        {
            dal.CheckNewGroupMsg(loginName);
        }
        #endregion

        #region д���ŵ��ռ���
        public bool SendInfoWithGroupCheck(Tz888.Model.InnerInfo model, int MessageID)
        {
            return dal.SendInfoWithGroupCheck(model, MessageID);
        }
        #endregion
    }
}

