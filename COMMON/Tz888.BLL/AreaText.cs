using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
    /// <summary>
    /// ҵ���߼���AreaTextTab ��ժҪ˵����
    /// </summary>
    public class AreaText
    {
        private readonly IAreaText dal = DataAccess.CreateAreaText();
        public AreaText()
        { }
        #region  ��Ա����
       
        /// <summary>
        ///  ����һ������
        /// </summary>
        public int Add(Tz888.Model.AreaText model)
        {
            return dal.Add(model);
        }

        public int Update(Tz888.Model.AreaText model)
        {
            return dal.Update(model);
        }

        public int Delete(int AreaID)
        {
            return dal.Delete(AreaID);
        }

        public void AddHit(int AreaID)
        {
            dal.AddHit(AreaID);
        }

        public void UpdateOrderNum(int AreaID, int OrderNum)
        {
            dal.UpdateOrderNum(AreaID, OrderNum);
        }

        public Tz888.Model.AreaText GetModel(int AreaID)
        {
            return dal.GetModel(AreaID);
        }
        #endregion  ��Ա����
    }
}

