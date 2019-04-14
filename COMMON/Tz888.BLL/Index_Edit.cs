using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
    /// <summary>
    /// ҵ���߼���tzIndex_Edit ��ժҪ˵����
    /// </summary>
    public class Index_Edit
    {
        private readonly IIndex_Edit dal = DataAccess.CreateIndex_Edit();
        public Index_Edit()
        { }
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tz888.Model.Index_Edit model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Tz888.Model.Index_Edit model)
        {
            return dal.Update(model);
        }
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }
        #endregion  ��Ա����
    }
}

