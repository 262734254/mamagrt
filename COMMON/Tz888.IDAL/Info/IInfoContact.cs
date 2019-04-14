using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// ��Դ��ϵ��ʽ���ݿ�����߼��ӿڶ���
    /// </summary>
    public interface IInfoContact
    {
        bool Add(Tz888.Model.Info.InfoContactModel model);
        Tz888.Model.Info.InfoContactModel GetModel(long InfoID);
        bool Update(Tz888.Model.Info.InfoContactModel model);
        void UpdateUndertaker(long InfoID, string ReceiveOrganization);
    }
}
