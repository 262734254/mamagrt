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
        /// 获取所有投资类型设置
        /// </summary>
        /// <returns></returns>
        public DataView GetAllCapitalType()
        {
            return dal.GetAllCapitalType();
        }

        /// <summary>
        /// 投资退出方式
        /// </summary>
        /// <returns></returns>
        public DataView GetALLReturnMode()
        {
            return dal.GetALLReturnMode();
        }

        /// <summary>
        /// 项目发展阶段
        /// </summary>
        /// <returns></returns>
        public DataView GetALLStage()
        {
            return dal.GetALLStage();
        }

        /// <summary>
        /// 资本类型（V1.2.4）
        /// </summary>
        /// <returns></returns>
        public DataView GetALLfinancingTarget()
        {
            return dal.GetALLfinancingTarget();
        }

        /// <summary>
        /// 投资方参与管理的方式
        /// </summary>
        /// <returns></returns>
        public DataView GetALLJoinManageTab()
        {
            return dal.GetALLJoinManageTab();
        }

    }
}
