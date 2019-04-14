using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// 资源联系方式数据库访问逻辑接口定义
    /// </summary>
    public interface IInfoContact
    {
        bool Add(Tz888.Model.Info.InfoContactModel model);
        Tz888.Model.Info.InfoContactModel GetModel(long InfoID);
        bool Update(Tz888.Model.Info.InfoContactModel model);
        void UpdateUndertaker(long InfoID, string ReceiveOrganization);
    }
}
