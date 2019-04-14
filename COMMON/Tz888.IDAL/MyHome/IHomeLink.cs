using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.MyHome;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.IDAL.MyHome
{
   public interface IHomeLink
    {
        #region 接口
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        List<MyHomeLink> SelectHomeList(string LoginName);
        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<MyHomeLink> GetHomeList(SqlDataReader reader);
        /// <summary>
        /// 添加我的主页信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int InsertHomeLink(MyHomeLink cs);
        /// <summary>
        /// 查询所有我的主页信息
        /// </summary>
        /// <returns></returns>
        IList<MyHomeLink> GetAllMyHome(string LoginName);
        /// <summary>
        /// 根据ID删除信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int deleteMyHome(int Id);
        /// <summary>
        /// 根据ID查看信息
        /// </summary>
        /// <returns></returns>
        MyHomeLink GetAllMyHomeById(int Id);
        /// <summary>
        /// 修改主页信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int UpdateMyHome(MyHomeLink cs);
       /// <summary>
       /// 根据查询所有分类字段
       /// </summary>
       /// <returns></returns>
       string SelectType(string LoginName);
        #endregion
    }
}
