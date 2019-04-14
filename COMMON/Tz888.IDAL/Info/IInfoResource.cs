using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// ��Ϣ��Դ�߼������ӿ�
    /// </summary>
    public interface IInfoResource
    {

        long Insert(Tz888.Model.Info.InfoResourceModel model);
        bool Delete(long ResourceID);
        bool DeleteByInfoID(long InfoID);
        Tz888.Model.Info.InfoResourceModel GetModel(long ResourceID);
    }
}
