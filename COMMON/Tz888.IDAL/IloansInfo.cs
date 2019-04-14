using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IloansInfo
    {
        Tz888.Model.LoansInfo GetLoansInfoByLoansInfoId(int LoansInfoId);
        int UpdateloansInfo(Tz888.Model.LoansInfo loansinfo, int LoansInfoId);
         int DeleteLoansInfo(int loansInfoID);
         int ShenHeloansInfo(Tz888.Model.LoansInfo loansinfo, int LoansInfoId);
        string GetProvinceNameByProvinceId(string ProvinceId);
    }
}
