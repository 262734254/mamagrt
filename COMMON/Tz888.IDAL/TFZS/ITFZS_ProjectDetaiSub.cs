using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.TFZS
{
    public interface ITFZS_ProjectDetaiSub
    {
        #region  成员方法
        /// <summary>
        /// 保存拓富指数选项
        /// </summary>
        decimal Save(Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel model, bool IsSave);
        #endregion  成员方法
    }
}
