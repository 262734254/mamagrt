using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Info.V124
{
    public interface IMerchantZone
    {
        long Insert(Tz888.Model.Info.V124.MerchantZoneModel model);
        bool Update(Tz888.Model.Info.V124.MerchantZoneModel model);
        bool Update(string colName, string value, long infoID);
    }
}
