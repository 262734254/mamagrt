using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.MyHome;

namespace Tz888.IDAL.MyHome
{
    public interface IHomeType
    {
        /// <summary>
        /// 根据ID删除信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int deleteHomeType(int Id);
        /// <summary>
        /// 修改主页信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int UpdateHomeType(MyHomeType cs);
        /// <summary>
        /// 查询所有类型表数据
        /// </summary>
        /// <returns></returns>
        IList<MyHomeType> GetHomeTypeList(string LoginName);
        /// <summary>
        /// 根据ID查询主页类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MyHomeType GetAllTypeById(int Id);
       
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        int InsertHomeType(MyHomeType cs);
        /// <summary>
        /// 根据登录名查询
        /// </summary>
        /// <param name="Mark"></param>
        /// <param name="typeid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        List<MyHomeType> SelectHomeType(string LoginName);
        /// <summary>
        /// 通用
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        List<MyHomeType> GetCars(SqlDataReader reader);

        
    }
}
