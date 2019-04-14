using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// Model的业务实体类
    /// </summary>
    public class Model
    {
        private readonly IModel dal = DataAccess.CreateIModel();

        #region 成员方法
        public Tz888.Model.Model GetModel()
        {
            return dal.GetModel();
        }
        #endregion
    }
}
