using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// Model��ҵ��ʵ����
    /// </summary>
    public class Model
    {
        private readonly IModel dal = DataAccess.CreateIModel();

        #region ��Ա����
        public Tz888.Model.Model GetModel()
        {
            return dal.GetModel();
        }
        #endregion
    }
}
