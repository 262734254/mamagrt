using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ILoginInfoIM
    {
        #region 在线恰谈
        //添加
        string Add(Tz888.Model.LoginInfoIMModel model);

        //修改
        void Update(Tz888.Model.LoginInfoIMModel model);
        #endregion
    }
}
