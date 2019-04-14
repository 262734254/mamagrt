using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
   public  class AccountInfo
    {
       private readonly IAccountInfo dal = DataAccess.CreateIAccountInfo();

       public DataTable GetAccountInfo(string LoginName)
       {
           return dal.GetAccountInfo(LoginName);
       }
       public  string account(string LoginName, string param)
       {
           AccountInfo dal = new AccountInfo();
           DataTable dt = dal.GetAccountInfo(LoginName);
           DataRow[] drs = null;
           string paramvalue = "0";
           if (dt != null)
           {
               drs = dt.Select("param='" + param + "'");
               if (drs.GetLength(0) > 0)
               {
                   paramvalue = drs[0]["value"].ToString() == "" ? "0" : drs[0]["value"].ToString();
               }
           }
           return paramvalue;
          
       }
    }
}
