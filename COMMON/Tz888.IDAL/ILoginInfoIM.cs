using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ILoginInfoIM
    {
        #region ����ǡ̸
        //���
        string Add(Tz888.Model.LoginInfoIMModel model);

        //�޸�
        void Update(Tz888.Model.LoginInfoIMModel model);
        #endregion
    }
}
