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
        //ǰ̨��˾�Ǽ�
        public  int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels
            )
        {
            return dal.EnterpriseAdd(model, ContactModel, ContactManModels, infoResourceModels);
        }

        //��ȡ��˾�Ǽ�һ��Ϣ(Ԥ��)
        public DataTable getEnterpriseModel(string LoginName)
        {
            return dal.getEnterpriseModel(LoginName);
        }

        //�޸�
        public int EnterpriseUpdate(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            return dal.EnterpriseUpdate(model, ContactModel, ContactManModels, infoResourceModels);
        }

        //��ѯ
        public DataTable getEnterpriseList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return dal.getEnterpriseList(tblName, strGetFields, fldName,
          PageSize, PageIndex, doCount, OrderType, strWhere);
        }

        //���
        public bool AuditEnterprise()
        {
            return true;//dal.AuditEnterprise();
        }

        //ɾ��
        public bool DeleteEnterprise(string loginName)
        {
            return dal.DeleteEnterprise(loginName);
        }

        //ˢ��
        public bool UpdateRefresh(int EnterpriseID)
        {
            return dal.UpdateRefresh(EnterpriseID);
        }
        //��̬��

        //��ȡ��ҵ����
        public DataTable getEnterpriceManageType()
        {
            return dal.getEnterpriceManageType();
        }

        //�޸�����
        public int UpdateOrganizationCode(string LoginName, string OrganizationCode)
        {
            return dal.UpdateOrganizationCode(LoginName, OrganizationCode);
        }

        //��ȡ
        public string GetOrganizationCode(string LoginName)
        {
            return dal.GetOrganizationCode(LoginName);
        }

    }
}
