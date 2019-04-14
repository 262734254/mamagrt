using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
    /// <summary>
    /// 业务逻辑类tzIndex_Edit 的摘要说明。
    /// </summary>
    public class Index_Edit
    {
        private readonly IIndex_Edit dal = DataAccess.CreateIndex_Edit();
        public Index_Edit()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.Index_Edit model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tz888.Model.Index_Edit model)
        {
            return dal.Update(model);
        }
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }
        #endregion  成员方法
    }
}

