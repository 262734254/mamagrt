using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL.Common
{
    public class ParameterBLL
    {
        private readonly IParameter dal = DataAccess.CreateParameter();
        /// <summary>
        /// ��ȡ����Ͷ����������
        /// </summary>
        /// <returns></returns>
        public DataView GetAllCapitalType()
        {
            return dal.GetAllCapitalType();
        }

        /// <summary>
        /// Ͷ���˳���ʽ
        /// </summary>
        /// <returns></returns>
        public DataView GetALLReturnMode()
        {
            return dal.GetALLReturnMode();
        }

        /// <summary>
        /// ��Ŀ��չ�׶�
        /// </summary>
        /// <returns></returns>
        public DataView GetALLStage()
        {
            return dal.GetALLStage();
        }

        /// <summary>
        /// �ʱ����ͣ�V1.2.4��
        /// </summary>
        /// <returns></returns>
        public DataView GetALLfinancingTarget()
        {
            return dal.GetALLfinancingTarget();
        }

        /// <summary>
        /// Ͷ�ʷ��������ķ�ʽ
        /// </summary>
        /// <returns></returns>
        public DataView GetALLJoinManageTab()
        {
            return dal.GetALLJoinManageTab();
        }

    }
}
