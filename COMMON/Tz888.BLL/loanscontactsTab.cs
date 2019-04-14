using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;

namespace Tz888.BLL
{
   public  class loanscontactsTab
    {
       private readonly IloanscontactsTab dal = DataAccess.CreateIloanscontactsTab();
       public Tz888.Model.LoanscontactsTab GetLoanscontactsTabByLoansInfoId(int LoansInfoId)
       {
           return dal.GetLoanscontactsTabByLoansInfoId(LoansInfoId);
       }
       public int UpdateloanscontactsTab(Tz888.Model.LoanscontactsTab loansinfo, int LoansInfoId)
       {
           return dal.UpdateloanscontactsTab(loansinfo, LoansInfoId);
       }
       public int DeleteloanscontactsTab(int loansInfoID)
       {
           return dal.DeleteloanscontactsTab(loansInfoID);
       }
    }
}
