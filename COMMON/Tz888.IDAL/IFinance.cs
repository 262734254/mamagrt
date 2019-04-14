using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL
{
    public interface IFinance
    {
        bool SiteInfoInsert();

        DataTable SiteInfoList();

        bool PayInfoInsert();

        DataTable PayInfoList();
    }
}
