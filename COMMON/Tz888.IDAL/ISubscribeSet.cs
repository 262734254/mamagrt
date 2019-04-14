using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL
{
    public interface ISubscribeSet
    {
        bool SendSet(Tz888.Model.SubscribeSet model);
        bool Update(int id, string subType);
        bool UpdateSmsConsumeRecTab(int Recid);
        bool SendSet1(Tz888.Model.SubscribeSet model, out int id);
        bool ReceivedSet(Tz888.Model.SubscribeGetSet model);
        bool IsReveive(string LoginName, int isget);
        string GetDescript(long infoId, string infoTypeId, out string descript);
        bool DeleteInfo(long ID);

        bool DeleteAll(string LoginName);

        bool isSend(string ReceiveLoginName);

        DataTable GetReceivedList(string strWhere);

        Tz888.Model.SubscribeSet GetModels(int Id, out string infotypeid, out string htmlFile);
        DataTable GetMemberExpiredList();

        DataTable GetInfoExpiredList();

        Tz888.Model.SubscribeGetSet GetModel(string LoginName);

        DataTable GetMachInfoList(string LoginName);
        /// <summary>
        /// 定向推广，明细记录
        /// </summary>
        bool Insert(Tz888.Model.SubscribeSetTabLog model);
    }
}
