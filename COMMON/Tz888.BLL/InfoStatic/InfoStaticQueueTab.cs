using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace Tz888.BLL.InfoStatic
{
    /// <summary>
    /// IInfoStaticQueueTab ��ժҪ˵����
    /// </summary>
    public class InfoStaticQueueTab
    {
        private static readonly Tz888.IDAL.InfoStatic.IInfoStaticQueueTab dal = Tz888.DALFactory.DataAccess.CreateInfoStaticQueue();
        public InfoStaticQueueTab()
        { }
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Tz888.Model.InfoStatic.InfoStaticQueueTab model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int InfoID)
        {
            return dal.Delete(InfoID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.InfoStatic.InfoStaticQueueTab GetModel(int InfoID)
        {
            return dal.GetModel(InfoID);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        public DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere)
        {
            return dal.GetList(GetFields, OrderName, PageSize, PageIndex, doCount, OrderType, StrWhere);
        }

        /// <summary>
        /// ������̬���б�
        /// </summary>
        /// <param name="StartTime">ͳ��ʱ�����ʼʱ��</param>
        /// <param name="EndTime">ͳ��ʱ��ν���ʱ��</param>
        /// <param name="Command">�Ƿ�ǿ��ˢ�¶��У�0��ǿ�д�������0ǿ�д���</param>
        /// <param name="Count">���ز��������ص�ǰ�����еȴ��ļ�¼����</param>
        /// <param name="State">���ض��д���״̬</param>
        /// <returns></returns>
        public int Create(System.DateTime StartTime, System.DateTime EndTime, int Command, ref int Count, ref int State)
        {
            return dal.Create(StartTime, EndTime, Command, ref Count, ref State);
        }

        /// <summary>
        ///�����еȴ��ļ�¼��
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return dal.Count();
        }

        #endregion  ��Ա����


        /// <summary>
        /// ��ȡ�ȴ������еļ�¼
        /// </summary>
        /// <param name="count">��Ҫ��ȡ�ļ�¼��</param>
        /// <param name="stateFlag">Ҫ��ȡ��¼��״̬</param>
        /// <returns></returns>
        public System.Collections.ArrayList GetStaticQueueList(int count, int stateFlag)
        {
            System.Collections.ArrayList arrRequest = new System.Collections.ArrayList();
            string StrWhere = "StateFlag = " + stateFlag;
            DataView dw = this.GetList("*", "InfoID", count, 1, 0, 1, StrWhere).Tables[0].DefaultView;
            for (int i = 0; i < dw.Count; i++)
            {
                StringDictionary paramCollection = new StringDictionary();
                paramCollection.Add("InfoID", dw[i]["InfoID"].ToString());
                paramCollection.Add("InfoType", dw[i]["InfoType"].ToString());
                paramCollection.Add("StateFlag", dw[i]["StateFlag"].ToString());
                arrRequest.Add(paramCollection);
            }
            return arrRequest;
        }

        /// <summary>
        /// ���Ķ����еȴ���Ϣ��״̬
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="StateFlag"></param>
        /// <returns></returns>
        public bool SetNoteStateFlag(int InfoID, int StateFlag)
        {
            Tz888.Model.InfoStatic.InfoStaticQueueTab model = this.GetModel(InfoID);
            if (model == null)
                return false;
            model.StateFlag = StateFlag;
            return this.Update(model);
        }
    }
}