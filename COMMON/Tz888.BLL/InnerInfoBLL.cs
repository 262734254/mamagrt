using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
using Tz888.IDAL.Common;

namespace Tz888.BLL
{
	/// <summary>
	/// 业务逻辑类InnerInfo 的摘要说明。
	/// </summary>
	public class InnerInfoBLL
	{
        private readonly IInnerInfo dal = DataAccess.CreateIInnerInfo();
        private readonly ICommonFunction dalComm = DALFactory.DataAccess.CreateICommon_CommonFunction();
      
       // private Tz888.SQLServerDAL.InnerInfo obj;    
     

		public InnerInfoBLL()
		{
            //obj = new Tz888.SQLServerDAL.InnerInfo();
        }

		#region  收件箱成员方法    
        ///<summary>
        ///逻辑（虚）删除操作 
        ///</summary>      
        public bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID)
        {          
            bool bl = false;
           // bl = obj.InfoReceivedTabVirtualDelete(LoginName, ReceivedID);           
            return bl;
        }
        

        //取收件箱内信息
        public Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID)
        {
             Tz888.Model.InnerInfoReceived model = new Tz888.Model.InnerInfoReceived();         
          //   model = obj.ReadInfo(ReceivedID);
             return model;
        }       
		#endregion  

        #region 发送信息
        //执行发送信息
        public bool SendInfo(Tz888.Model.InnerInfoSend model)
        {
            bool bl = false;
         //   bl = obj.SendInfo(model);
            return bl;
        }       
        #endregion 

        #region 我发出的信息

        //逻辑（虚）删除操作
        public bool InfoSendTabVirtualDelete(string LoginName, int SendID)
        {
            bool bl = false;          
          // bl = obj.InfoSendTabVirtualDelete(LoginName, SendID);            
            return bl;
        }
        #endregion

        #region 垃圾箱

        //执行物理删除操作(选中信息)
        public bool DeleteWasterInfo(int WasterID)
        {
            bool bl = false;
          //  bl = obj.DeleteWasterInfo(WasterID);
            return bl;
        }
        //清空废件箱（全部）
        public bool DeleteAllWasterInfo(string LoginName)
        {
            bool bl = false;
          //  bl = obj.DeleteAllWasterInfo(LoginName);
            return bl;
        }

   
       #endregion

        #region 共用方法
        /// <summary>
        /// 得到站内信息列表
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <param name="InfoStatus">信息状态，0：收件信息（已读和未读），
        /// 1：发件箱信息（自己的未发送信息），2：已发送信息，3：垃圾箱信息（已删除信息）
        /// <param name="ReadStatus">读取状态：0：未读 1：已读 2：全部</param>
        /// <returns>站内信息列表</returns>
        ///   public DataTable GetInfoList(string tblName, string strGetFields, string fldName,
        ///   int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)

        public DataTable GetInfoList(
            string LoginName,
            int InfoStatus,            
            int PageSize,
            int PageIndex,
            int doCount)
        {
            DataTable dt= new DataTable();              
            switch (InfoStatus)
            {
                case 0:                 
                    
                //dt = obj.GetInfoList("InnerInfoReceivedTab", "*", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='kittycat'");//'" + strNickName + "'");
                   // dt = obj.GetInfoList("InnerInfoReceivedTab", "*", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='汪双娥'");//'" + strNickName + "'");
                    
                    break;
                case 1:                   
                  //  dt = obj.GetInfoList("InnerInfoSendTab", "*", "SendID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'");
                    break;
                case 2:                   
                 //   dt = obj.GetInfoList("InnerInfoSendTab", "*", "SendID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'");
                    break;

                case 3:                 
               //     dt = obj.GetInfoList("InnerInfoWasterTab", "*", "WasterID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'");
                    break;
                default:
                    dt = null;
                    break;
            }
            return (dt);
        }
        #endregion 


        public DataTable GetInfoListForUserCenter(
            string LoginName,
            int InfoStatus,            
            int PageSize,
            int PageIndex,
            int doCount)
        {
            DataTable dt=new DataTable();              
            switch (InfoStatus)
            {
                case 0:                 
                    
                //dt = obj.GetInfoList("InnerInfoReceivedTab", "*", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='kittycat'");//'" + strNickName + "'");
                 //  dt = obj.GetInfoList("InnerInfoReceivedTab", "Topic,SendedMan,ReceivedTime", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='汪双娥'");//'" + strNickName + "'");
                    
                    break;
                case 1:                   
              //      dt = obj.GetInfoList("InnerInfoSendTab", "*", "SendID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'");
                    break;
                case 2:                   
               //     dt = obj.GetInfoList("InnerInfoSendTab", "*", "SendID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'");
                    break;

                case 3:                 
              //      dt = obj.GetInfoList("InnerInfoWasterTab", "*", "WasterID", PageSize, PageIndex, doCount, 1, "LoginName='" + LoginName + "'");
                    break;
                default:
                    dt = null;
                    break;
            }
            return (dt);
        }

        #region 未读邮件
        public long InnerInfoReceivedCountNoReaded(string strNickName)
        {
            long CurrentPage = 0;
            long PageRows = 0;
            long lgPageCount = 0;
            DataView dv;
            
            string strReadStatus = " AND IsReaded=0";
            dv = dalComm.GetListSet("InnerInfoReceivedTabList",
                "*",                 
                "ReceivedName='" + strNickName + "'" + strReadStatus,
                "ReceivedTime desc",
                ref CurrentPage,
                0,
                ref lgPageCount);

            return lgPageCount;
        }
        #endregion

        #region 未读邮件
        public DataView dsGetAllInnerNoRead(string strNickName,ref long lgPageCount)
        {
            long CurrentPage = 0;
            long PageRows = 0;            
            DataView dv;
            string strReadStatus = " AND IsReaded=0";
            dv = dalComm.GetListSet("InnerInfoReceivedTabList",
                "*",
                "ReceivedName='" + strNickName + "'" + strReadStatus,
                "ReceivedTime desc",
                ref CurrentPage,
                0,
                ref lgPageCount);

            return dv;
        }
        #endregion

        #region 收到的邮件
        public long InnerInfoReceivedCount(string strNickName)
        {
            long CurrentPage = 0;
            long PageRows = 0;
            long lgPageCount = 0;

            DataView dv;
            
            string strReadStatus = "";

            dv = dalComm.GetListSet(
                "InnerInfoReceivedTabList",
                "*",
                //	"LoginName='" + LoginName + "'" + strReadStatus,
                "ReceivedName='" + strNickName + "'",
                "ReceivedTime desc",
                ref CurrentPage,
                0,
                ref lgPageCount);

            return lgPageCount;
        }
        #endregion

        #region 发送的邮件
        public long InnerInfoSendedCount(string LoginName)
        {
            long CurrentPage = 0;
            long PageRows = 0;
            long lgPageCount = 0;

            DataView dv;
            
            string strReadStatus = "";

            dv = dalComm.GetListSet(
                "InnerInfoReceivedTabList",
                "*",
                "LoginName='" + LoginName + "'" + strReadStatus,
                "ReceivedTime desc",
                ref CurrentPage,
                0,
                ref lgPageCount);

            return lgPageCount;
        }
        #endregion    

    }
}
