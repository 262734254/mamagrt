using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using Tz888.DALFactory;
using Tz888.IDAL;
namespace Tz888.BLL
{
    public class LoginInfoIMBLL
    {
        private readonly ILoginInfoIM dal = DataAccess.CreateLoginInfoIM();
        public string Add(Tz888.Model.LoginInfoIMModel model)
        {
            return dal.Add(model);
        }
        public void Update(Tz888.Model.LoginInfoIMModel model)
        {
            dal.Update(model);
        }
    }
}
