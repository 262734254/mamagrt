using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IGovernmentRegister
    {
        #region 招商机构登记
        //机构登记（添加）
        int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model,
                 Tz888.Model.Register.OrgContactModel ContactModel,
                 List<Tz888.Model.Register.OrgContactMan> ContactManModels,
                 List<Tz888.Model.MemberResourceModel> infoResourceModels);

        //根据用户ID读取公司信息
        DataTable getGovernmentModel(string LoginName);

        //政府机构注册
        void GovernmentReg(GovernmentInfoModel model);

        //修改
        int GovernmentUpdate(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels);

        //查询
        DataTable getGovernmentList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);

        //审核
        bool AuditGovernment();

        bool UpdateRefresh(int GovernmentID);
        
        //删除
        bool DeleteGovernment(string loginName);

        //静态化（展厅）

        //是否重复查询
         DataTable getMerchantTypeTab();
        bool YuMing(string ExhibitionHall);

        #endregion 

        
    }
} 
