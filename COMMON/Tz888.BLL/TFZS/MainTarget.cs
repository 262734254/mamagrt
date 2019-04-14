using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.DALFactory;
using Tz888.IDAL.TFZS;

namespace Tz888.BLL.TFZS
{
    public class MainTarget
    {
        private readonly IMainTarget dal = DataAccess.CreateTFZS_MainTarget();

        /// <summary>
        /// �����������ͻ�ȡ��ָ���б�
        /// </summary>
        /// <param name="mainTargetType">�������ʹ��룺ծȨ->ZQ ��Ȩ->GQ</param>
        /// <returns>��Ӧ�������͵�������ָ����Ϣ</returns>
        public List<TFZS_MainTarget> GetListByTargetType(string mainTargetType)
        {
            return dal.GetListByTargetType(mainTargetType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="DicMainCode"></param>
        /// <returns></returns>
        public decimal GetEvaluateCount(long InfoID, string DicMainCode)
        {
            return dal.GetEvaluateCount(InfoID, DicMainCode);
        }
    }
}
