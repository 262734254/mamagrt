using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info.V124;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.Info.V124
{
    public class MerchantZoneBLL
    {
        private readonly IMerchantZone dal = DataAccess.CreateIMerchantZone();

        public long Insert(Tz888.Model.Info.V124.MerchantZoneModel model)
        {
            return dal.Insert(model);
        }

        public bool Update(Tz888.Model.Info.V124.MerchantZoneModel model)
        {
            return dal.Update(model);
        }

        public bool Update(string colName, string value, long infoID)
        {
            return dal.Update(colName, value, infoID);
        }
    }
}
