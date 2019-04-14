using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
namespace Tz888.BLL.MyHome
{
    public class HomeTypeManager
    {
        HomeTypeService type = new HomeTypeService();
        #region 查询所有类型数据
        /// <summary>
        /// 查询所有类型数据
        /// </summary>
        /// <returns></returns>
        public IList<MyHomeType> GetHomeTypeList(string LoginName)
        {
            try
            {
                return type.GetHomeTypeList(LoginName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        
        #endregion

        #region 查看类型
        /// <summary>
        /// 根据ID查看类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MyHomeType GetAllTypeById(int Id)
        {
            try
            {
                return type.GetAllTypeById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion

        #region IHomeType 添加类型

        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int InsertHomeType(MyHomeType cs)
        {
            try
            {
                return type.InsertHomeType(cs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        #endregion
        #region 查询类别
        /// <summary>
        /// 查询类别
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public List<MyHomeType> SelectHomeType(string LoginName)
        {
            try
            {
                return type.SelectHomeType(LoginName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion
        #region 查询所有的类别ID
        public DataTable GetAlTypeId(string LoginName)
        {
            string sql = "select TID,TypeName,LoginName,LoginID,sort,Datatimes from  HomeType where LoginName='"+ LoginName +" '";
        
            DataTable db = Tz888.DBUtility.DBHelpe.GetDataSet(sql);
            return db;
        

        } 
        #endregion
        #region 根据ID修改和删除信息
        /// <summary>
        /// 根据ID删除信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int deleteHomeType(int Id)
        {
            try
            {
                return type.deleteHomeType(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// 根据ID修改信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int UpdateHomeType(MyHomeType cs)
        {
            try
            {
                return type.UpdateHomeType(cs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion
    }
}
