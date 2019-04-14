using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;
using System.Data;

namespace Tz888.IDAL.Company
{
    public interface ICompanyInfoTab
    {
        /// <summary>
        /// 企业名片添加
        /// </summary>
        /// <returns></returns>
        int Company_Add(CompanyModel model);
        /// <summary>
        /// 企业名片修改
        /// </summary>
        /// <returns></returns>
        int Company_Update(CompanyModel model, int id);
        /// <summary>
        /// 判断是否发布了企业名片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int IfCompany(string name);
        /// <summary>
        /// 根据用户名查找审核状态
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        int SelAdution(string name);
        /// <summary>
        /// 根据用户名查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyModel SelCompany(string name);

        /// <summary>
        /// 获取省份列表
        /// </summary>
        /// <returns></returns>
        DataTable GetProvinceList();

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        DataTable GetCity(string ProvinceID);
    } 
}
