using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IEnterprise
    {
        #region 前台
        //公司信息登记
        bool AddEnterprise();
        //公司信息审核
        bool AuditEnterprise();        
        //公司信息修改
        bool UpdateEnterprise();
        //多联系人添加
        bool AddLinkMan();
        #endregion

        #region 后台
        //查询,预览
        Tz888.Model.Enterprise GetEnterprise();
        //删除
        bool DeleteEnterprise();
        //静态化

        #endregion
    }
}
