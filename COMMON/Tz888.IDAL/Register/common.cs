using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.IDAL.Register;

namespace Tz888.IDAL.Register
{
    public interface common
    {
        #region ��˾�����Ǽǹ������
        //����ϵ�����
        bool InsertContactMan(SqlConnection sqlConn, SqlTransaction sqlTran,
            Tz888.Model.Register.OrgContactMan model);
      
        //��ȡ��ϵ���б�
        List<Tz888.Model.Register.OrgContactMan> GetOrgContactMan(string LoginName);

        //�����ϵ��
        void AddOrgContect(Tz888.Model.Register.OrgContactModel orgModel);

        List<Tz888.Model.MemberResourceModel> GetMemberResourceModel(string LoginName, 
            int ResourceProperty);

        //��ȡ��ϵ����Ϣ
        Tz888.Model.Register.OrgContactModel getContactModel(string LoginName);
        
        //��˹�˾�������Ǽ���Ϣ
        int AuditOrg(Tz888.Model.Register.OrgAuditModel model);

        //��Ա��Ϣ�޸�ʱ�޸ĵǼ�Ĭ����ϵ����Ϣ
        long OrgContactMan_FromMemberMessage(Tz888.Model.Register.OrgContactModel model);

        #region  ����չ������

        //���
        int AddSelfCreateWebInfo(string loginName, string domain);

        //�޸�
        int UpdateSelfCreateWebInfo(int webId, string loginName, string domain);

        //��ѯչ�������Ƿ�ʹ��      
        int CheckDomain(string domain,string loginName);
        
        #endregion

        #region ��ȡ�û���չ������
        
        //��ȡ��ҵ��Ա��չ������       
        DataSet GetEnterpriseInfo(string loginName);
        
        // ��ȡ���̻�Ա��չ������        
        DataSet GetGovernmentInfo(string loginName);

        /// �ڶ���д��ѯ��ϵ����ϸ��Ϣ
        Tz888.Model.Register.MemberInfoModel SelorgContact(string lognName);
        #endregion
        #endregion 
    }
}
