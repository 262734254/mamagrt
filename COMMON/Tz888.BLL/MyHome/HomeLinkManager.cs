using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DALFactory;
using Tz888.IDAL;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
using Tz888.Pager;
using Tz888.DBUtility;
namespace Tz888.BLL.MyHome
{
     
    public class HomeLinkManager
    {

        HomeTypeService type = new HomeTypeService();
       HomeLinkService dal = new HomeLinkService();
       #region 添加主页信息
       /// <summary>
       ///  添加主页信息
       /// </summary>
       /// <param name="cs"></param>
       /// <returns></returns>
       public int InsertHomeLink(MyHomeLink cs)
       {
           try
           {
               return dal.InsertHomeLink(cs);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       } 
       #endregion

       #region 查询所有我的主页信息
       /// <summary>
       /// 查询所有我的主页信息
       /// </summary>
       /// <returns></returns>
        public IList<MyHomeLink> GetAllMyHome(string LoginName)
       {
           try
           {
               return dal.GetAllMyHome(LoginName);
           }
           catch (Exception ex)
           {
               throw new Exception(ex.ToString());
           }
       } 
       #endregion

       #region  根据登录名查询所有
       /// <summary>
        /// 说明：主页所有数据
        /// 操作人：
        /// 参数：
        /// 创建日期：2010-11-10
        /// 最后修改人：
        /// 最后修改日期：
        /// </summary>
        /// <returns>db</returns>
    
        public DataTable GetAllhome(string LoginName)
        {
            string sql = "usp_SelcectId";
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@LoginName",LoginName)
             
          };
            DataTable db = Tz888.DBUtility.DBHelper.GetDataTableProc(sql, para);
            return db;
        }

        #endregion

       #region 获得数据列表
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        ///// <param name="pb">分页基本信息</param>
        ///// <param name="count">返回总数</param>
        ///// <returns></returns>
        //public List<MyHomeLink> GetList(PageBase pb, ref int count)
        //{
        //    DataTable dt = dal.GetList(pb, ref count).Tables[0];
        //    List<MyHomeLink> modelList = new List<MyHomeLink>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0 && pb.DoCount == 0)
        //    {
        //        MyHomeLink model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = new MyHomeLink();
        //            if (dt.Rows[n]["LID"].ToString() != "")
        //            {
        //                model.LID = int.Parse(dt.Rows[n]["LID"].ToString());
        //            }
        //            model.Linkwww = dt.Rows[n]["Linkwww"].ToString();

        //            if (dt.Rows[n]["LoginID"].ToString() != "")
        //            {
        //                model.LoginID = int.Parse(dt.Rows[n]["LoginID"].ToString());
        //            }
        //            if (dt.Rows[n]["CreateTimes"].ToString() != "")
        //            {
        //                model.CreateTimes = DateTime.Parse(dt.Rows[n]["CreateTimes"].ToString());
        //            }
        //            if (dt.Rows[n]["States"].ToString() != "")
        //            {
        //                model.States = int.Parse(dt.Rows[n]["States"].ToString());
        //            }
        //            if (dt.Rows[n]["Typeid"].ToString() != "")
        //            {
        //                model.Typeid = type.GetAllTypeById(int.Parse(dt.Rows[n]["Typeid"].ToString()));
        //            }
        //            model.Linkwww = dt.Rows[n]["Linkwww"].ToString();
        //            model.LName = dt.Rows[n]["LName"].ToString();
        //            model.LoginName = dt.Rows[n]["LoginName"].ToString();
        //            model.PassWord = dt.Rows[n]["PassWord"].ToString();
        //            model.UserName = dt.Rows[n]["UserName"].ToString();
        //            model.WDoc = dt.Rows[n]["WDoc"].ToString();
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}
        #endregion

       #region 根据ID删除信息


        public int deleteMyHome(int Id)
        {
            try
            {
                return dal.deleteMyHome(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        #endregion

       #region 根据ID查询信息
        /// <summary>
        ///  根据ID查询信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MyHomeLink GetAllMyHomeById(int Id)
        {
            try
            {
                return dal.GetAllMyHomeById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion

       #region 修改信息
        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int UpdateMyHome(MyHomeLink cs)
        {
            try
            {
                return dal.UpdateMyHome(cs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

       #region 条件查询
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public List<MyHomeLink> SelectHomeList(string LoginName)
        {
            try
            {
                return dal.SelectHomeList(LoginName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion

        #region  根据类型ID查询所有
        /// <summary>
        /// 说明：主页所有数据
        /// 操作人：
        /// 参数：
        /// 创建日期：2010-11-10
        /// 最后修改人：
        /// 最后修改日期：
        /// </summary>
        /// <returns>db</returns>

        public DataTable GetAllhome(int id ,string LoginName)
        {
            string sql = "usp_SelcectTypeId";
            SqlParameter[] para = new SqlParameter[] 
          {
              new SqlParameter("@id",id),
             new SqlParameter("@LoginName",LoginName)
             
          };
            DataTable db = Tz888.DBUtility.DBHelper.GetDataTableProc(sql, para);
            return db;
        }

        #endregion

        #region 根据查询所有分类字段
        /// <summary>
        /// 根据查询所有分类字段
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public string SelectType(string LoginName)
        {
            try
            {
                return dal.SelectType(LoginName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        #endregion

    
    }
}
