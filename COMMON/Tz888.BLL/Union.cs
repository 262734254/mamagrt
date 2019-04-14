using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Tz888.BLL
{
  public   class Union
    {
        /// <summary>
        /// 通用查询列表
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetList(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
        ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.GetList(TableViewName, Key, SelectStr, Criteria, Sort, ref  CurrentPage, PageSize, ref  TotalCount);
        }

        /// <summary>
        ///获取服务信息 /需求，机构，人才 从各表 查询单列  并需要查询条件
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public DataTable GetList(string FileName, string TableName, string Where, int Top)
        {
            Tz888.SQLServerDAL.Union dal = new  Tz888.SQLServerDAL.Union();
            return dal.GetList(FileName, TableName, Where, Top);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string table,string where)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.Delete(table ,where);
        }

        /// <summary>
        /// 服务一级分类名称
        /// </summary>
        /// <returns></returns>
        public string GetServiesBNameByID(int ServiesBID)
        {
            string str = "";
            if (ServiesBID != 0)
            {
                Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
                DataTable dt = dal.GetList("ServiesBName", "setServiesBigTab", "where ServiesBID=" + ServiesBID, 1);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        str = dt.Rows[0]["ServiesBName"].ToString();
                    }
                }


            }
            return str;
        }

        /// <summary>
        /// 服务二级分类名称
        /// </summary>
        /// <returns></returns>
        public string GetServiesMNameByID(int ServiesMID)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            DataTable dt = dal.GetList("ServiesMName", "setServiesSmallTab",  "where ServiesMID=" + ServiesMID,1);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ServiesMName"].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 根据小类ID取得大类Name
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public string GetBNameByMID(int MID)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            DataTable dt = dal.GetList("ServiesbName", "setServiesbigtab",  "where ServiesBID=(select ServiesBID from setServiessmalltab where ServiesMID=" + MID + ")",1);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["ServiesbName"].ToString();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 服务二级分类列表
        /// </summary>
        /// <param name="isShow">isShow为true 显示出isshow=1的,否则显示出所有</param>
        /// <returns></returns>
        public DataView GetServiesList(int ServiesBID, bool isShow)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.GetServiesList(ServiesBID, isShow);
        }

        /// <summary>
        /// 服务一级分类列表
        /// </summary>
        /// <param name="isShow">isShow为true 显示出isshow=1的,否则显示出所有</param>
        /// <returns></returns>
        public DataView GetServiesList(bool isShow)
        {
            Tz888.SQLServerDAL.Union dal = new Tz888.SQLServerDAL.Union();
            return dal.GetServiesList(isShow);
        }
    }
}
