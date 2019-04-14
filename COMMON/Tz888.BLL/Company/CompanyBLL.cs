using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Company;
using Tz888.DALFactory;
using Tz888.Model.Company;
using System.Data;

namespace Tz888.BLL.Company
{
    
    public class CompanyBLL
    {
        private readonly ICompanyInfoTab dal = DataAccess.CreateCompany();
        /// <summary>
        /// 企业名片添加
        /// </summary>
        /// <returns></returns>
        public int Company_Add(CompanyModel model)
        {
            return dal.Company_Add(model);
        }
        /// <summary>
        /// 企业名片修改
        /// </summary>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            return dal.Company_Update(model,id);
        }
        #region 判断是否发布了企业名片
        /// <summary>
        /// 判断是否发布了企业名片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfCompany(string name)
        {
            return dal.IfCompany(name);
        }
        #endregion

        #region 根据用户名查找审核状态
        /// <summary>
        /// 根据用户名查找审核状态
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelAdution(string name)
        {
            return dal.SelAdution(name);
        }
         #endregion
        /// <summary>
        /// 根据用户名查找相关的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CompanyModel SelCompany(string name)
        {
            return dal.SelCompany(name);
        }

        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvinceList()
        {
            return dal.GetProvinceList();
        }

        /// <summary>
        /// 市区列表
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public DataTable GetCity(string ProvinceID)
        {
            return dal.GetCity(ProvinceID);
        }

        ///// <summary>
        ///// 查询联系人信息
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string SelLinkName(int id)
        //{
        //    return dal.SelLinkName(id);
        //}
    }
}
