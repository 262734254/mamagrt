using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IMerchantSite
    {
        int Add(Tz888.Model.MerchantSite model);

        int Update(Tz888.Model.MerchantSite model);

        int Delete(int ID);

        int Auditing(int ID, int AuditStatus, string AuditLoginName);
    }
}
