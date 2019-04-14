using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;

namespace Tz888.BLL
{
  public   class LoansInfo
    {
      private readonly IloansInfo dal = DataAccess.CreateILoansInfo();
      public Tz888.Model.LoansInfo GetLoansInfoByLoansInfoId(int LoansInfoId)
      {
          return dal.GetLoansInfoByLoansInfoId(LoansInfoId);
      }
      public int UpdateLoansInfoTab(Tz888.Model.LoansInfo loansinfo, int LoansInfoId)
      {
          return dal.UpdateloansInfo(loansinfo, LoansInfoId);
      }
      public int DeleteLoansInfo(int loansInfoID)
      {
          return dal.DeleteLoansInfo(loansInfoID);
      }
      public int ShenHeloansInfo(Tz888.Model.LoansInfo loansinfo, int LoansInfoId)
      {
          return dal.ShenHeloansInfo(loansinfo, LoansInfoId);
      }
      public string GetProvinceNameByProvinceId(string ProvinceId)
      {
          return dal.GetProvinceNameByProvinceId(ProvinceId);
      }
    }
}
