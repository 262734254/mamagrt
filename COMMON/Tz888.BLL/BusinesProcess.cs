using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using System.Data;

namespace Tz888.BLL
{
    public class BusinesProcess
    {
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Tz888.Model.BusinesProcess model)
        {
            Tz888.SQLServerDAL.BusinesProcess dal = new Tz888.SQLServerDAL.BusinesProcess();
            return dal.Add(model);
        }
        /// <summary>
        /// ��С���ѯ
        /// </summary>
        /// <param name="big"></param>
        /// <returns></returns>
        public DataSet SelectBig(int big)
        {
            Tz888.SQLServerDAL.BusinesProcess dal = new Tz888.SQLServerDAL.BusinesProcess();
            return dal.SelectBig(big);
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="IndustryID"></param>
        /// <returns></returns>
        public DataSet SelectIndustry(int IndustryID)
        {
            Tz888.SQLServerDAL.BusinesProcess dal = new Tz888.SQLServerDAL.BusinesProcess();
            return dal.SelectIndustry(IndustryID);
        }
    
    }
}
