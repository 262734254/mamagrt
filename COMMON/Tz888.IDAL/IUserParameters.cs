using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IUserParameters
    {
        bool NoticeSet(string LoginName, string NoticeEmail, string NoticeMobile);


        bool MachSet(Tz888.Model.UserParameters model);

        bool NoticeTypeSet(Tz888.Model.UserParameters model);
    }
}
