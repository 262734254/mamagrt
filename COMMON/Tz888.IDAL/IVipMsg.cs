using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL
{
    public interface IVipMsg
    {
        int Add(Tz888.Model.VipMsg model);
        int InsertError(string LoginName, string ErrorMsg);
        DataTable valiLoginPwd(string LoginName, string LoginPwd);
    }
}
