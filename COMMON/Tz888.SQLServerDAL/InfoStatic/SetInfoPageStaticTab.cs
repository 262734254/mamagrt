using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.InfoStatic;

namespace Tz888.SQLServerDAL.InfoStatic
{
    public class SetInfoPageStaticTab : ISetInfoPageStaticTab
    {
        #region  成员方法
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.InfoStatic.SetInfoPageStaticTab model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4),
											new SqlParameter("@LastUpdateTime", SqlDbType.DateTime),
											new SqlParameter("@MinUpdateTime", SqlDbType.Int,4),
											new SqlParameter("@IsActive", SqlDbType.Bit,1),
											new SqlParameter("@RunTime", SqlDbType.VarChar,50),
											new SqlParameter("@StartTime", SqlDbType.DateTime),
											new SqlParameter("@EndTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LastUpdateTime;
            parameters[2].Value = model.MinUpdateTime;
            parameters[3].Value = model.IsActive;
            parameters[4].Value = model.RunTime;
            parameters[5].Value = model.StartTime;
            parameters[6].Value = model.EndTime;

            DbHelperSQL.RunProcedure("SetInfoPageStaticTab_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)
										};
            parameters[0].Value = ID;
            DbHelperSQL.RunProcedure("SetInfoPageStaticTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.InfoStatic.SetInfoPageStaticTab GetModel(int ID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ID", SqlDbType.Int,4)
										};
            parameters[0].Value = ID;
            Tz888.Model.InfoStatic.SetInfoPageStaticTab model = new Tz888.Model.InfoStatic.SetInfoPageStaticTab();

            DataSet ds = DbHelperSQL.RunProcedure("SetInfoPageStaticTab_GetModel", parameters, "ds");
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["LastUpdateTime"].ToString() != "")
                {

                    model.LastUpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MinUpdateTime"].ToString() != "")
                {
                    model.MinUpdateTime = int.Parse(ds.Tables[0].Rows[0]["MinUpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsActive"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsActive"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsActive"].ToString().ToLower() == "true"))
                    {
                        model.IsActive = true;
                    }
                    else
                    {
                        model.IsActive = false;
                    }
                }

                model.RunTime = ds.Tables[0].Rows[0]["RunTime"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {

                    model.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {

                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取全站信息静态化服务设置信息
        /// </summary>
        /// <param name="GetFields"></param>
        /// <param name="OrderName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="doCount"></param>
        /// <param name="OrderType"></param>
        /// <param name="StrWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string GetFields, string OrderName, int PageSize, int PageIndex, int doCount, int OrderType, string StrWhere)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@tblName",SqlDbType.VarChar,255),
											new SqlParameter("@strGetFields", SqlDbType.VarChar, 1000),
											new SqlParameter("@fldName", SqlDbType.VarChar, 255),
											new SqlParameter("@PageSize", SqlDbType.Int),
											new SqlParameter("@PageIndex", SqlDbType.Int),
											new SqlParameter("@doCount",SqlDbType.Bit),
											new SqlParameter("@OrderType",SqlDbType.Bit),
											new SqlParameter("@strWhere", SqlDbType.VarChar,4000),
			};
            parameters[0].Value = "SetInfoPageStaticTab";
            parameters[1].Value = GetFields;
            parameters[2].Value = OrderName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = doCount;
            parameters[6].Value = OrderType;
            parameters[7].Value = StrWhere;

            return DbHelperSQL.RunProcedure("Sp_Conn_Sort", parameters, "ds");
        }

        #endregion  成员方法
    }
}
