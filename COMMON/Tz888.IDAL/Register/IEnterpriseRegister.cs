using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IEnterpriseRegister
    {
        #region ��˾�Ǽ�
        //��˾�Ǽ�(���)
        int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
                List<Tz888.Model.MemberResourceModel> infoResourceModels);

        //�����û�ID��ȡ��˾�Ǽ�һ��Ϣ(Ԥ��)
         DataTable getEnterpriseModel(string LoginName);

        //�޸�
        int EnterpriseUpdate(Tz888.Model.Register.EnterpriseInfoModel model,
               Tz888.Model.Register.OrgContactModel ContactModel,
               List<Tz888.Model.Register.OrgContactMan> ContactManModels,
               List<Tz888.Model.MemberResourceModel> infoResourceModels);
        //��ѯ
        DataTable getEnterpriseList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);

        //���
        bool AuditEnterprise(Tz888.Model.Register.EnterpriseInfoModel Enterprise, 
             Tz888.Model.Register.OrgAuditModel OrgAudi);

        //ɾ��
        bool DeleteEnterprise(string loginName);

        //ˢ��
        bool UpdateRefresh(int EnterpriseID);
       
        //��̬����չ����

        //������Ϣ���
         int addEnterprise_Additive();

        //��ȡ��ҵ����
        DataTable getEnterpriceManageType();

        //�޸�������֯��������(����)
        int UpdateOrganizationCode(string LoginName, string OrganizationCode);

        //��ȡ��֯��������(����)
        string GetOrganizationCode(string LoginName);
        
        #endregion 

    }
}
