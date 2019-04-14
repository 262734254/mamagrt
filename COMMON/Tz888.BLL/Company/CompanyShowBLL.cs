using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL.Company;
using System.Data;

namespace Tz888.BLL.Company
{
     public class CompanyShowBLL
    {
         private readonly ICompanyShow dal = DataAccess.CreateCompanyShow();
         /// <summary>
         /// 添加展厅
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int AddShow(Tz888.Model.Company.CompanyShow model)
         {
             return dal.AddShow(model);
         }
         /// <summary>
         /// 添加展厅
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int ZylmAddShow(Tz888.Model.Company.CompanyShow model)
         {
             return dal.ZylmAddShow(model);
         }
         /// <summary>
        /// 添加融资拓富通
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         public int rzAddShow(Tz888.Model.Company.CompanyShow model)
         {
             try
             {
                 return dal.rzAddShow(model);
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }

         /// <summary>
         /// 添加投资拓富通
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int tzAddShow(Tz888.Model.Company.CompanyShow model)
         {
             try
             {
                 return dal.tzAddShow(model);
             }
             catch (Exception)
             {

                 throw;
             }
         }

         /// <summary>
         /// 添加专业服务拓富通
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int zfAddShow(Tz888.Model.Company.CompanyShow model)
         {
             try
             {
                 return dal.zfAddShow(model);
             }
             catch (Exception)
             {

                 throw;
             }
         }
         /// <summary>
        /// 判断该用户是否已经发布了企业展厅
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public int IfUserName(string name)
         {
             return dal.IfUserName(name);
         }
              /// <summary>
        /// 通过用户名查找会员的地域信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetMemberInfoByName(string loginName)
        {
            return dal.GetMemberInfoByName(loginName);
        }
        /// <summary>
        /// 判断该用户是否已经发布了资源联盟
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfUserName(string name, int roleid)
        {
            return dal.IfUserName(name, roleid);
        }
        /// <summary>  
        /// 判断该用户发布的资源联盟是否审核通过
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfAudit(string name, int roleid)
        {
            
            return dal.IfAudit(name,roleid);
        }
         /// <summary>
         /// 判断该用户发布的展厅信息是否审核通过
         /// </summary>
         /// <param name="name"></param>
         /// <returns></returns>
         public int IfAudit(string name)
         {
             return dal.IfAudit(name);
         } /// <summary>
        /// 判断该用户是否已经发布了资源联盟
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public int IfUserNameAudit(string name, int roleid)
        {
            return dal.IfUserNameAudit(name, roleid);
        }
         
    }
}
