using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IReportTab
    {
        //��Ӿٱ���Ϣ
        int addReportInfo(long InfoID, string Title, string content, string insertTime);
        int addReplayInfo(long InfoID, string InfoTypeID, string ReplayContent, DateTime ReplayDate, string checkMan, string ID, string checkRemark);
    }
}
