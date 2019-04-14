using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IOrgRegister
    {
        #region 公司登记
        //前台公司登记
        int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model);

        //读取公司登记一信息(预览)
        Tz888.Model.Register.EnterpriseInfoModel getEnterpriseModel(int EnterpriseID);

        //修改
        int EnterpriseUpdate(int EnterpriseID);

        //查询
        DataTable getEnterpriseList();
        
        //审核
        bool AuditEnterprise();

        //删除
        bool DeleteEnterprise(int EnterpriseID);

        //静态化

        #endregion 

        #region 招商机构登记
        //前台公司登记
        int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model);

        //读取公司登记一信息(预览)
        Tz888.Model.Register.GovernmentInfoModel getGovernmentModel(int GovernmentID);

        //修改
        int GovernmentUpdate(int GovernmentID);

        //查询
        DataTable getGovernmentList();

        //审核
        bool AuditGovernment();

        //删除
        bool DeleteGovernment(int GovernmentID);

        //静态化

        //是否重复查询

        #endregion 

    }
}
