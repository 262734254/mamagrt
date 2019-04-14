using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    /// <summary>
    /// �ӿڲ�IInnerInfo��ժҪ˵����
    /// </summary>
    public interface IInnerInfo
    {
        #region �ռ����Ա����
        //�߼����飩ɾ������     
        bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID);

        // ȡ�ռ�������Ϣ       
        Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID);
        #endregion 

        #region ������Ϣ
        //ִ�з�����Ϣ
        bool SendInfo(Tz888.Model.InnerInfoSend model);

         //ִ�б�����Ϣ   
       // bool SaveInfo(Tz888.Model.InnerInfoSend model);
        #endregion 

        #region �ҷ�������Ϣ
        //�߼����飩ɾ������
        bool InfoSendTabVirtualDelete(string LoginName, int SendID);
        #endregion 

        #region ������
        //ִ������ɾ������(ѡ����Ϣ) 
        bool DeleteWasterInfo(int WasterID);

        //��շϼ��䣨ȫ���� 
        bool DeleteAllWasterInfo(string LoginName);       
        #endregion 

        #region ���÷��� 
        //ȡ�ϼ�������Ϣ 
       // Tz888.Model.InnerInfoWaster GetWasterInfo(string tblName, string strGetFields, string fldName,
      //      int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);

        // �õ�վ����Ϣ�б� 
        DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);             
        #endregion 

        #region  sunray����
        bool InfoVirtualDelete(string LoginName, int ReceiveId, int TableType, string flag);
        bool ReadInfoSet(int InfoID);//�����Ѷ�״̬
        bool SendInfoIDAL(Tz888.Model.InnerInfo model);
        bool SaveInfoIDAL(Tz888.Model.InnerInfo model);
        Tz888.Model.InnerInfo GetInfoContext(int InfoId, int infoTable);
        #endregion

        DataTable getFriends(string loginName);

        #region ��ȡ���ж���Ⱥ��
        DataSet GetMsgGroup();
        #endregion

        #region ����Ⱥ�����
        int SendMsgToGroup(int ReceivedGroupID, string CONTEXT, string Topic, bool isRead, bool isSent, string SendName, DateTime ReceiveTime, string readName, DateTime Created, string Createby);
        #endregion

        #region �����µ�Ⱥ����Ϣ
        void CheckNewGroupMsg(string loginName);
	    #endregion

        #region д��Ϣ���ռ���
        bool SendInfoWithGroupCheck(Tz888.Model.InnerInfo model, int MessageID);
        #endregion

    }
}
 