using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Register
{
    public class SS_Agency_ServicesBLL
    {
        Tz888.SQLServerDAL.Register.SS_Agency_Services mode = new Tz888.SQLServerDAL.Register.SS_Agency_Services();
        // 会员注册
        public void AgencyAdd(Tz888.Model.Register.SS_Agency_Services model)
        {

            mode.AgencyAdd(model);
        }
        public Tz888.Model.Register.SS_Agency_Services getModel(string FileName, string TableName, string Where, int Top)
        {
            return mode.getModel(FileName, TableName, Where, Top);
        }
        public bool SS_StrUpdate(Tz888.Model.Register.SS_Agency_Services model)
        {
            return mode.SS_StrUpdate(model);
        }
    }
}
