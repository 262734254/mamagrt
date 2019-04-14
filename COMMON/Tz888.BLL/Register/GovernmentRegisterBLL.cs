using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using Tz888.IDAL.Register;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Register
{
    public class GovernmentRegisterBLL
    {
        private readonly IGovernmentRegister dal = DataAccess.CreateGovernmentRegister();
        //前台公司登记
        public int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels, 
            List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            return dal.GovernmentAdd(model, ContactModel, ContactManModels, infoResourceModels); 
        }

        //政府注册
        public void GovernmentReg(GovernmentInfoModel model)
        {
            dal.GovernmentReg(model);
        }

        //读取公司登记一信息(预览)
        public DataTable getGovernmentModel(string LoginName)
        {
            return dal.getGovernmentModel(LoginName);
        }
        //修改
        public int GovernmentUpdate(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            return dal.GovernmentUpdate(model, ContactModel, ContactManModels, infoResourceModels);
        }

        //查询
        public DataTable getGovernmentList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return dal.getGovernmentList(tblName, strGetFields, fldName,
          PageSize, PageIndex, doCount, OrderType, strWhere);
        }

        //审核
        public bool AuditGovernment()
        {
            return dal.AuditGovernment();
        }

         //刷新
        public bool UpdateRefresh(int EnterpriseID)
        {
            return dal.UpdateRefresh(EnterpriseID);
        }
        //删除
        public bool DeleteGovernment(string loginName)
        {
            return dal.DeleteGovernment(loginName);
        }
   
        //静态化

        //是否重复查询

        //机构主体
        public DataTable getGovernmentSubjectType()
        {
            DataTable dt = null;
            //con.GetList();//机构主体表还没建
            return dt;
        }
        //检查域名
         public bool YuMing(string ExhibitionHall) 
         {
            return dal.YuMing(ExhibitionHall);
        }
        //读取机构主体
        public DataTable getMerchantTypeTab()
        {
            return dal.getMerchantTypeTab();
        }

    }
}
