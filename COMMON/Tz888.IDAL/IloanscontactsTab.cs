using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
   public  interface IloanscontactsTab
    {
       Tz888.Model.LoanscontactsTab GetLoanscontactsTabByLoansInfoId(int LoansInfoId);
       int UpdateloanscontactsTab(Tz888.Model.LoanscontactsTab loansinfo, int LoansInfoId);
       int DeleteloanscontactsTab(int loansInfoID);
    }
}
