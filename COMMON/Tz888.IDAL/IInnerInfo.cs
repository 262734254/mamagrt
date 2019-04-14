using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    /// <summary>
    /// 接口层IInnerInfo的摘要说明。
    /// </summary>
    public interface IInnerInfo
    {
        #region 收件箱成员方法
        //逻辑（虚）删除操作     
        bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID);

        // 取收件箱内信息       
        Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID);
        #endregion 

        #region 发送信息
        //执行发送信息
        bool SendInfo(Tz888.Model.InnerInfoSend model);

         //执行保存信息   
       // bool SaveInfo(Tz888.Model.InnerInfoSend model);
        #endregion 

        #region 我发出的信息
        //逻辑（虚）删除操作
        bool InfoSendTabVirtualDelete(string LoginName, int SendID);
        #endregion 

        #region 垃圾箱
        //执行物理删除操作(选中信息) 
        bool DeleteWasterInfo(int WasterID);

        //清空废件箱（全部） 
        bool DeleteAllWasterInfo(string LoginName);       
        #endregion 

        #region 共用方法 
        //取废件箱内信息 
       // Tz888.Model.InnerInfoWaster GetWasterInfo(string tblName, string strGetFields, string fldName,
      //      int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);

        // 得到站内信息列表 
        DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);             
        #endregion 

        #region  sunray方法
        bool InfoVirtualDelete(string LoginName, int ReceiveId, int TableType, string flag);
        bool ReadInfoSet(int InfoID);//设置已读状态
        bool SendInfoIDAL(Tz888.Model.InnerInfo model);
        bool SaveInfoIDAL(Tz888.Model.InnerInfo model);
        Tz888.Model.InnerInfo GetInfoContext(int InfoId, int infoTable);
        #endregion

        DataTable getFriends(string loginName);

        #region 获取所有短信群组
        DataSet GetMsgGroup();
        #endregion

        #region 发送群组短信
        int SendMsgToGroup(int ReceivedGroupID, string CONTEXT, string Topic, bool isRead, bool isSent, string SendName, DateTime ReceiveTime, string readName, DateTime Created, string Createby);
        #endregion

        #region 接收新的群组信息
        void CheckNewGroupMsg(string loginName);
	    #endregion

        #region 写信息到收件箱
        bool SendInfoWithGroupCheck(Tz888.Model.InnerInfo model, int MessageID);
        #endregion

    }
}
 