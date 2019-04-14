using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ISendNotice
    {
        bool SendMobileMsg(string mobile, string Content);
        int SendMobileSms(string mobile, string Content);
        bool UpdateMobileCount(string LoginName);
        bool UPdateSms(string id);

    }
}
