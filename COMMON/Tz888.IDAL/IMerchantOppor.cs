using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IMerchantOppor
    {
        bool IsVip(long InfoID, int isVip, string VipAbout);

        bool isTop(long InfoID, int isTop);
    }
}
