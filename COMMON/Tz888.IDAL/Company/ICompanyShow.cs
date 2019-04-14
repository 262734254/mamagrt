using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;
using System.Data;

namespace Tz888.IDAL.Company
{
   public  interface ICompanyShow
    {
       /// <summary>
       /// 添加企业展厅
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int AddShow(CompanyShow com);

       /// <summary>
       /// 添加资源联盟信息
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int ZylmAddShow(CompanyShow com);
       /// <summary>
       /// 添加融资联盟信息
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int rzAddShow(CompanyShow com);

       /// <summary>
       /// 添加投资联盟信息
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int tzAddShow(CompanyShow com);


       /// <summary>
       /// 添加
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int zfAddShow(CompanyShow com);
       /// <summary>
       /// 判断该用户是否已经发布了企业展厅
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfUserName(string name);
        /// <summary>
        /// 通过用户名查找会员的地域信息
        /// </summary>
        /// <returns></returns>
        DataSet GetMemberInfoByName(string loginName);
       /// <summary>
       /// 判断该用户发布的展厅信息是否审核通过
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfAudit(string name);
       /// <summary>
       /// 根据用户查找会员的有效期
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       string OverdueTime(string name);

       /// <summary>
       /// 判断该用户是否已经发布了资源联盟
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfUserName(string name, int roleid);

       /// <summary>
       /// 判断该用户是否已经发布了资源联盟
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfUserNameAudit(string name, int roleid);
       
       /// <summary>  
       /// 判断该用户发布的资源联盟是否审核通过
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfAudit(string name, int roleid);
       
    }
}
