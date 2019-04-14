using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// 业务逻辑类InnerInfo 的摘要说明。
    /// </summary>
    public class InnerInfo
    {
        private readonly IInnerInfo dal = DataAccess.CreateIInnerInfo();


        #region  收件箱成员方法
        ///<summary>
        ///逻辑（虚）删除操作 
        ///</summary>      
        public bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID)
        {
            bool bl = false;
            bl = dal.InfoReceivedTabVirtualDelete(LoginName, ReceivedID);
            return bl;
        }

        //取收件箱内信息
        public Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID)
        {
            Tz888.Model.InnerInfoReceived model = new Tz888.Model.InnerInfoReceived();
            model = dal.ReadInfo(ReceivedID);
            return model;
        }

        //// 取收件箱内信息
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

        #region 发送信息
        //执行发送信息
        public bool SendInfo(Tz888.Model.InnerInfoSend model)
        {
            bool bl = false;
            bl = dal.SendInfo(model);
            return bl;
        }

        ////执行保存信息
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

        #region 我发出的信息

        //逻辑（虚）删除操作
        public bool InfoSendTabVirtualDelete(string LoginName, int SendID)
        {
            bool bl = false;
            bl = dal.InfoSendTabVirtualDelete(LoginName, SendID);
            return bl;
        }
        #endregion

        #region 垃圾箱

        //执行物理删除操作(选中信息)
        public bool DeleteWasterInfo(int WasterID)
        {
            bool bl = false;
            bl = dal.DeleteWasterInfo(WasterID);
            return bl;
        }
        //清空废件箱（全部）
        public bool DeleteAllWasterInfo(string LoginName)
        {
            bool bl = false;
            bl = dal.DeleteAllWasterInfo(LoginName);
            return bl;
        }

        ////取废件箱内信息
        //public Tz888.Model.InnerInfoWaster GetWasterInfo(int WasterID)
        //{
        //    return dal.GetModel(WasterID);
        //}
        #endregion

        #region 共用方法
        /// <summary>
        /// 得到站内信息列表
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <param name="InfoStatus">信息状态，0：收件信息 1：发件箱信息，2：垃圾箱信息（逻辑，物理册除）      
        /// <param name="ReadCondition">接收时间：0最近收到的信息 1三天内、2七天内、3一个月内、4三个月内、5三个月以上</param>
        /// <returns>站内信息列表</returns>

        public DataTable GetInfoList(
            string LoginName,
            int InfoStatus,
            string ReadCondition,
            int PageSize,
            int PageIndex,
            int doCount)
        {
            string strNickName = "";
            //     *****************************GetMemberNameByLoginName 未实现
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
                case 0: //收件箱
                    dt = dal.GetInfoList("InnerInfoReceivedTab", "*", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='汪双娥'" + ReadCondition);//'" + strNickName + "'");
                    break;
                case 1: //发件箱                 
                    dt = dal.GetInfoList("InnerInfoSendTab", "*", "SendID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'" + ReadCondition);
                    break;
                case 2://垃圾箱信息               
                    dt = dal.GetInfoList("InnerInfoWasterTab", "*", "WasterID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "' " + ReadCondition);
                    break;
                default:
                    dt = null;
                    break;
            }
            return (dt);
        }

        #endregion

        #region 好友列表
        public DataTable getFriends(string loginName)
        {
            return dal.getFriends(loginName);
        }
        #endregion

        #region sunray BLL方法
        public bool InfoVirtualDelete(string LoginName, int InfoID, int TableType, string flag)
        {
            bool result = dal.InfoVirtualDelete(LoginName, InfoID, TableType, flag);
            return result;
        }
        public void ReadInfoSet(int receiveId)//0 收件箱 ， 1 发件箱
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

        public Tz888.Model.InnerInfo GetInfoContext(int InfoId, int infoTable)  //ReceiveId 查询条件 ， infoTable 查询表号
        {
            Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
            model = dal.GetInfoContext(InfoId, infoTable);
            return model;
        }
        #endregion

        #region 获取所有短信群组
        public DataSet GetMsgGroup()
        {
            return dal.GetMsgGroup();
        }
        #endregion

        #region 短信群组发送
        public int SendMsgToGroup(int ReceivedGroupID, string CONTEXT,string Topic, bool isRead, bool isSent, string SendName, DateTime ReceiveTime, string readName, DateTime Created, string Createby)
        {
            return dal.SendMsgToGroup(ReceivedGroupID, CONTEXT, Topic, isRead, isSent, SendName, ReceiveTime, readName, Created, Createby);
        }
        #endregion

        #region 接收新的群组信息
        public void CheckNewGroupMsg(string loginName)
        {
            dal.CheckNewGroupMsg(loginName);
        }
        #endregion

        #region 写短信到收件箱
        public bool SendInfoWithGroupCheck(Tz888.Model.InnerInfo model, int MessageID)
        {
            return dal.SendInfoWithGroupCheck(model, MessageID);
        }
        #endregion
    }
}

