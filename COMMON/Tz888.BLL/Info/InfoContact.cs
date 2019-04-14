using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.Info
{
    public class InfoContact
    {
        private readonly IInfoContact dal = DataAccess.CreateInfo_InfoContact();
        public bool Add(Tz888.Model.Info.InfoContactModel model)
        {
            return dal.Add(model);
        }
        public Tz888.Model.Info.InfoContactModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }

        public bool Update(Tz888.Model.Info.InfoContactModel model)
        {
            return dal.Update(model);
        }
        public void UpdateUndertaker(long InfoID, string ReceiveOrganization)
        {
            dal.UpdateUndertaker(InfoID, ReceiveOrganization);

        }
    }
     
}
