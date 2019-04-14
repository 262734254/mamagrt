using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;
namespace Tz888.BLL.Info
{

    public class InfoResourceBLL
    {
        private readonly IInfoResource dal = DataAccess.CreateInfo_InfoResource();
        public Tz888.Model.Info.InfoResourceModel GetModel(long ResourceID)
        {
            return dal.GetModel(ResourceID);
        }
        public long Insert(Tz888.Model.Info.InfoResourceModel model)
        {
            return dal.Insert(model);
        }
        public bool DeleteByInfoID(long InfoID)
        {
            return dal.DeleteByInfoID(InfoID);
        }
        public bool Delete(long ResID)
        {
            return dal.Delete(ResID);
        }
        
    }
}
 