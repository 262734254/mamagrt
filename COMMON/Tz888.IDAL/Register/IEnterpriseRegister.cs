using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IEnterpriseRegister
    {
        #region 公司登记
        //公司登记(添加)
        int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
                List<Tz888.Model.MemberResourceModel> infoResourceModels);

        //根据用户ID读取公司登记一信息(预览)
         DataTable getEnterpriseModel(string LoginName);

        //修改
        int EnterpriseUpdate(Tz888.Model.Register.EnterpriseInfoModel model,
               Tz888.Model.Register.OrgContactModel ContactModel,
               List<Tz888.Model.Register.OrgContactMan> ContactManModels,
               List<Tz888.Model.MemberResourceModel> infoResourceModels);
        //查询
        DataTable getEnterpriseList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);

        //审核
        bool AuditEnterprise(Tz888.Model.Register.EnterpriseInfoModel Enterprise, 
             Tz888.Model.Register.OrgAuditModel OrgAudi);

        //删除
        bool DeleteEnterprise(string loginName);

        //刷新
        bool UpdateRefresh(int EnterpriseID);
       
        //静态化（展厅）

        //附加信息添加
         int addEnterprise_Additive();

        //读取企业性质
        DataTable getEnterpriceManageType();

        //修改输入组织机构代码(附件)
        int UpdateOrganizationCode(string LoginName, string OrganizationCode);

        //读取组织机构代码(附件)
        string GetOrganizationCode(string LoginName);
        
        #endregion 

    }
}
