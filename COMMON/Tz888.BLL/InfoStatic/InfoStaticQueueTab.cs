using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

namespace Tz888.BLL.InfoStatic
{
    /// <summary>
    /// IInfoStaticQueueTab 的摘要说明。
    /// </summary>
    public class InfoStaticQueueTab
    {
        private static readonly Tz888.IDAL.InfoStatic.IInfoStaticQueueTab dal = Tz888.DALFactory.DataAccess.CreateInfoStaticQueue();
        public InfoStaticQueueTab()
        { }
        #region  成员方法
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.InfoStatic.InfoStaticQueueTab model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int InfoID)
        {
            return dal.Delete(InfoID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.InfoStatic.InfoStaticQueueTab GetModel(int InfoID)
        {
            return dal.GetModel(InfoID);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        public DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere)
        {
            return dal.GetList(GetFields, OrderName, PageSize, PageIndex, doCount, OrderType, StrWhere);
        }

        /// <summary>
        /// 创建静态化列表
        /// </summary>
        /// <param name="StartTime">统计时间段起始时间</param>
        /// <param name="EndTime">统计时间段结束时间</param>
        /// <param name="Command">是否强行刷新队列，0不强行创建，非0强行创建</param>
        /// <param name="Count">返回参数，返回当前队列中等待的记录总数</param>
        /// <param name="State">返回队列创建状态</param>
        /// <returns></returns>
        public int Create(System.DateTime StartTime, System.DateTime EndTime, int Command, ref int Count, ref int State)
        {
            return dal.Create(StartTime, EndTime, Command, ref Count, ref State);
        }

        /// <summary>
        ///队列中等待的记录数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return dal.Count();
        }

        #endregion  成员方法


        /// <summary>
        /// 获取等待队列中的记录
        /// </summary>
        /// <param name="count">需要获取的记录数</param>
        /// <param name="stateFlag">要获取记录的状态</param>
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
        /// 更改队列中等待信息的状态
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