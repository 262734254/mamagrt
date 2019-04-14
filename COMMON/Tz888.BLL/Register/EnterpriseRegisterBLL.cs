using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using Tz888.IDAL.Register;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Register
{
    public class EnterpriseRegisterBLL
    {
        private readonly IEnterpriseRegister dal = DataAccess.CreateEnterpriseRegister();
        //前台公司登记
        public  int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels
            )
        {
            return dal.EnterpriseAdd(model, ContactModel, ContactManModels, infoResourceModels);
        }

        //读取公司登记一信息(预览)
        public DataTable getEnterpriseModel(string LoginName)
        {
            return dal.getEnterpriseModel(LoginName);
        }

        //修改
        public int EnterpriseUpdate(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            return dal.EnterpriseUpdate(model, ContactModel, ContactManModels, infoResourceModels);
        }

        //查询
        public DataTable getEnterpriseList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return dal.getEnterpriseList(tblName, strGetFields, fldName,
          PageSize, PageIndex, doCount, OrderType, strWhere);
        }

        //审核
        public bool AuditEnterprise()
        {
            return true;//dal.AuditEnterprise();
        }

        //删除
        public bool DeleteEnterprise(string loginName)
        {
            return dal.DeleteEnterprise(loginName);
        }

        //刷新
        public bool UpdateRefresh(int EnterpriseID)
        {
            return dal.UpdateRefresh(EnterpriseID);
        }
        //静态化

        //读取企业性质
        public DataTable getEnterpriceManageType()
        {
            return dal.getEnterpriceManageType();
        }

        //修改输入
        public int UpdateOrganizationCode(string LoginName, string OrganizationCode)
        {
            return dal.UpdateOrganizationCode(LoginName, OrganizationCode);
        }

        //读取
        public string GetOrganizationCode(string LoginName)
        {
            return dal.GetOrganizationCode(LoginName);
        }

    }
}
