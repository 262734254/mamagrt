using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL
{
    public class UserInfoH
    {
        Tz888.SQLServerDAL.UserInfoH dal = new Tz888.SQLServerDAL.UserInfoH();
        /// <summary>
        ///  增加一条数据  申请提供专业服务
        /// </summary>
        public long OfferInsert(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
          Tz888.Model.UserInfoZ model,
           Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            return dal.OfferInsert(mainInfoModel, model, shortInfoModel);
        }
        

        /// <summary>
        ///  修改一条数据  申请提供专业服务
        /// </summary>
     
        public bool update(Tz888.Model.Info.MainInfoModel mainInfoModel,
          Tz888.Model.UserInfoZ model,
         Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            return dal.update(mainInfoModel, model, shortInfoModel);
        }
        public Tz888.Model.UserInfoZ getModel(int Id)
        {
            return dal.getModel("OfferInfoTab", "*","where InfoID="+Id);
        }
        public bool delete(int infoid)
        {
            return dal.delete(infoid);
        }
    }
}
