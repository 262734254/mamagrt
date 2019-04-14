using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info.V124;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info.V124
{
    public class CapitalInfoBLL
    {
        private readonly ICapitalInfo dal = DataAccess.CreateCapitalInfo_V124();

        /// <summary>
        /// 投资信息发布
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="capitalInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <param name="shortInfoModel"></param>
        /// <param name="capitalInfoAreaModels"></param>
        /// <param name="infoContactManModels"></param>
        /// <returns></returns>
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.V124.CapitalInfoModel capitalInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels,
           // List<Tz888.Model.Info.InfoContactManModel> infoContactManModelsm,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
           // return dal.Insert(mainInfoModel, capitalInfoModel, infoContactModel, shortInfoModel, capitalInfoAreaModels, infoContactManModelsm,infoResourceModels);
            return dal.Insert(mainInfoModel, capitalInfoModel, infoContactModel, shortInfoModel, capitalInfoAreaModels,  infoResourceModels);
        }

        public Tz888.Model.Info.V124.CapitalInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }

        public Tz888.Model.Info.V124.CapitalSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        public bool Update(Tz888.Model.Info.V124.CapitalSetModel model)
        {
            return dal.Update(model);
        }
        //以下是插入数据
        public bool InsertInformationIntegrity(Tz888.Model.Info.InfoContactModel model)
        {
            int score = 94;
            if (model.Position.ToString().Length != 0)
            {
                score += 2;
            }
            if (model.Address.ToString().Length != 0)
            {
                score += 2;
            }
            if (model.WebSite.ToString().Length != 0)
            {
                score += 2;
            }
            Tz888.Model.Info.V124.CapitalInfoModel model1 = new Tz888.Model.Info.V124.CapitalInfoModel();
            model1.InfoID = model.InfoID;
            model1.InformationIntegrity = score;
            //信息的完整度
            return dal.UpdateInformationIntegrity(model1);
              

         }


    }

}
