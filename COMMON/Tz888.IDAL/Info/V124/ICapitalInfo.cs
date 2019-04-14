using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info.V124
{
    public interface ICapitalInfo
    {
        /// <summary>
        /// 添加投资资源信息
        /// </summary> 
        long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.V124.CapitalInfoModel capitalInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels,
            //List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            );
        Tz888.Model.Info.V124.CapitalInfoModel GetModel(long InfoID);

        Tz888.Model.Info.V124.CapitalSetModel GetIntegrityModel(long InfoID);

        bool Update(Tz888.Model.Info.V124.CapitalSetModel model);

        bool UpdateInformationIntegrity(Tz888.Model.Info.V124.CapitalInfoModel model1);
    }
}
