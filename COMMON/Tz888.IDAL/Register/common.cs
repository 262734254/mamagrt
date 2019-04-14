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
        #region 公司机机登记共用相关
        //多联系人添加
        bool InsertContactMan(SqlConnection sqlConn, SqlTransaction sqlTran,
            Tz888.Model.Register.OrgContactMan model);
      
        //获取联系人列表
        List<Tz888.Model.Register.OrgContactMan> GetOrgContactMan(string LoginName);

        //添加联系人
        void AddOrgContect(Tz888.Model.Register.OrgContactModel orgModel);

        List<Tz888.Model.MemberResourceModel> GetMemberResourceModel(string LoginName, 
            int ResourceProperty);

        //获取联系人信息
        Tz888.Model.Register.OrgContactModel getContactModel(string LoginName);
        
        //审核公司、机构登记信息
        int AuditOrg(Tz888.Model.Register.OrgAuditModel model);

        //会员信息修改时修改登记默认联系人信息
        long OrgContactMan_FromMemberMessage(Tz888.Model.Register.OrgContactModel model);

        #region  网上展厅申请

        //添加
        int AddSelfCreateWebInfo(string loginName, string domain);

        //修改
        int UpdateSelfCreateWebInfo(int webId, string loginName, string domain);

        //查询展厅域名是否己使用      
        int CheckDomain(string domain,string loginName);
        
        #endregion

        #region 获取用户的展厅资料
        
        //获取企业会员的展厅资料       
        DataSet GetEnterpriseInfo(string loginName);
        
        // 获取招商会员的展厅资料        
        DataSet GetGovernmentInfo(string loginName);

        /// 第二次写查询联系人详细信息
        Tz888.Model.Register.MemberInfoModel SelorgContact(string lognName);
        #endregion
        #endregion 
    }
}
