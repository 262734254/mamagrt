using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IloansInfoTab
    {
        int InsertLoansInfoTab(Tz888 .Model .LoansInfoTab loansinfotab,Tz888 .Model .LoansInfo loansinfo,Tz888 .Model .LoanscontactsTab loanscontactstab);
        Tz888.Model.LoansInfoTab GetLoansInfoTabByLoansInfoId(int LoansInfoId);
        int UpdateLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab);
         int UpdateLoansInfoTabauditID(int id);
        List<Tz888.Model.LoansInfoTab> GetAllInfoTab();
        int DeleteLoansInfoTab(int loansInfoID);
        int ShenHeLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab);
    }
}
