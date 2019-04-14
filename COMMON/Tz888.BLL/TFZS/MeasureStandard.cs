using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.DALFactory;
using Tz888.IDAL.TFZS;

namespace Tz888.BLL.TFZS
{
    public class MeasureStandard
    {
        private readonly IMeasureStandard dal = DataAccess.CreateTFZS_MeasureStandard();
        /// <summary>
        /// ���ݱ���ָ������ȡ����Ŀ����Ϣ�б�
        /// </summary>
        /// <param name="expressCode">����ָ�����</param>
        /// <returns>����Ŀ����Ϣ�б�</returns>
        public List<TFZS_MeasureStandard> GetListByExpressCode(string expressCode)
        {
            return dal.GetListByExpressCode(expressCode);
        }
    }
}
