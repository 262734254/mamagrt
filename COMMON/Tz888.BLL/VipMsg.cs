using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
   public class VipMsg
    {
       /// <summary>
       /// ∂Ã–≈ ‘”√
       /// </summary>
       private readonly IVipMsg dal = DataAccess.CreateVipMsg();
       public int Add(Tz888.Model.VipMsg model)
       {
           return dal.Add(model);
       }
       public int InsertError(string LoginName, string ErrorMsg)
       {
           return dal.InsertError(LoginName, ErrorMsg);
       }
       public DataTable valiLoginPwd(string LoginName, string LoginPwd)
       {
           return dal.valiLoginPwd(LoginName, LoginPwd);
       }
    }
}
