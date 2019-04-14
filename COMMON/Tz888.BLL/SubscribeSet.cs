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
        /// 推广设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendSet(Tz888.Model.SubscribeSet model)
        {
            return dal.SendSet(model);
        }
        /// <summary>
        /// 推广设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendSet1(Tz888.Model.SubscribeSet model,out int id)
        {
            return dal.SendSet1(model,out id);
        } 
        /// <summary>
        /// 推广接收设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public bool ReceivedSet(Tz888.Model.SubscribeGetSet model)
        {
            return dal.ReceivedSet(model);
        }
        /// <summary>
        /// 是否接收推广
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
        /// 修改发送状态
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool isSend(string ReceiveLoginName)
        {
            return dal.isSend(ReceiveLoginName);
        }
        /// <summary>
        /// 定向推广接收人列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetReceivedList(string strWhere)
        {
            return dal.GetReceivedList(strWhere);
        }
        /// <summary>
        /// 资源订阅接收人列表
        /// </summary>
        /// <param name="LoginName">LoginName为"" 取所有订阅人的loginname,否则为取LoginName的订阅列表ID</param>
        /// <returns></returns>
        public DataTable GetMachInfoList(string LoginName)
        {
            return dal.GetMachInfoList(LoginName);
        }
         /// <summary>
        /// 根据ID查询完整的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Tz888.Model.SubscribeSet GetModels(int Id, out string infotypeid, out string htmlFile)
        {
            return dal.GetModels(Id, out infotypeid, out htmlFile);
        }
        /// <summary>
        /// 会员过期预警通知
        /// </summary>
        /// <returns></returns>
        public DataTable GetMemberExpiredList()
        {
            return dal.GetMemberExpiredList();
        }
        /// <summary>
        /// 资源过期预警通知
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
        /// 订单明细表
        /// 根据ID和orderNo来更新SmsConsumeRecTab表
        /// </summary>
        public bool UpdateSmsConsumeRecTab(int Recid)
        {
            return dal.UpdateSmsConsumeRecTab(Recid);
        }
         /// <summary>
        /// 定向推广，明细记录
        /// </summary>
        public bool Insert(Tz888.Model.SubscribeSetTabLog model)
        {
            return dal.Insert(model);
        }
         /// <summary>
        /// 根据主表匹配三个表的类型来获取表中的项目描述
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
