using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.TFZS;
using Tz888.DALFactory;

namespace Tz888.BLL.TFZS
{
    public class TFZS_ProjectDetaiSubBLL
    {
        private readonly ITFZS_ProjectDetaiSub dal = DataAccess.CreateTFZS_ProjectDetaiSub();

        /// <summary>
        /// 保存拓富指数答案
        /// </summary>
        /// <param name="model">答案信息实体</param>
        /// <param name="IsSave">是否将数据保存入数据库</param>
        /// <returns></returns>
        public decimal Save(Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel model, bool IsSave)
        {
            return dal.Save(model,IsSave);
        }
    }
}
