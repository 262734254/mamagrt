using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
using Tz888.IDAL.Common;

namespace Tz888.BLL
{
	/// <summary>
	/// ҵ���߼���InnerInfo ��ժҪ˵����
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

		#region  �ռ����Ա����    
        ///<summary>
        ///�߼����飩ɾ������ 
        ///</summary>      
        public bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID)
        {          
            bool bl = false;
           // bl = obj.InfoReceivedTabVirtualDelete(LoginName, ReceivedID);           
            return bl;
        }
        

        //ȡ�ռ�������Ϣ
        public Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID)
        {
             Tz888.Model.InnerInfoReceived model = new Tz888.Model.InnerInfoReceived();         
          //   model = obj.ReadInfo(ReceivedID);
             return model;
        }       
		#endregion  

        #region ������Ϣ
        //ִ�з�����Ϣ
        public bool SendInfo(Tz888.Model.InnerInfoSend model)
        {
            bool bl = false;
         //   bl = obj.SendInfo(model);
            return bl;
        }       
        #endregion 

        #region �ҷ�������Ϣ

        //�߼����飩ɾ������
        public bool InfoSendTabVirtualDelete(string LoginName, int SendID)
        {
            bool bl = false;          
          // bl = obj.InfoSendTabVirtualDelete(LoginName, SendID);            
            return bl;
        }
        #endregion

        #region ������

        //ִ������ɾ������(ѡ����Ϣ)
        public bool DeleteWasterInfo(int WasterID)
        {
            bool bl = false;
          //  bl = obj.DeleteWasterInfo(WasterID);
            return bl;
        }
        //��շϼ��䣨ȫ����
        public bool DeleteAllWasterInfo(string LoginName)
        {
            bool bl = false;
          //  bl = obj.DeleteAllWasterInfo(LoginName);
            return bl;
        }

   
       #endregion

        #region ���÷���
        /// <summary>
        /// �õ�վ����Ϣ�б�
        /// </summary>
        /// <param name="LoginName">�û���</param>
        /// <param name="InfoStatus">��Ϣ״̬��0���ռ���Ϣ���Ѷ���δ������
        /// 1����������Ϣ���Լ���δ������Ϣ����2���ѷ�����Ϣ��3����������Ϣ����ɾ����Ϣ��
        /// <param name="ReadStatus">��ȡ״̬��0��δ�� 1���Ѷ� 2��ȫ��</param>
        /// <returns>վ����Ϣ�б�</returns>
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
                   // dt = obj.GetInfoList("InnerInfoReceivedTab", "*", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='��˫��'");//'" + strNickName + "'");
                    
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
                 //  dt = obj.GetInfoList("InnerInfoReceivedTab", "Topic,SendedMan,ReceivedTime", "ReceivedTime", PageSize, PageIndex, doCount, 1, "ReceivedName='��˫��'");//'" + strNickName + "'");
                    
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

        #region δ���ʼ�
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

        #region δ���ʼ�
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

        #region �յ����ʼ�
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

        #region ���͵��ʼ�
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
