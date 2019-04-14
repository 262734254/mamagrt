using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.InfoStatic;

namespace Tz888.SQLServerDAL.InfoStatic
{
    public class InfoStaticQueueTab : IInfoStaticQueueTab
    {
        public InfoStaticQueueTab()
        {

        }

        #region  成员方法
        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(Tz888.Model.InfoStatic.InfoStaticQueueTab model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@InfoID", SqlDbType.BigInt,8),
											new SqlParameter("@InfoType", SqlDbType.Char,10),
											new SqlParameter("@StateFlag", SqlDbType.Int,4)};
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.InfoType;
            parameters[2].Value = model.StateFlag;

            DbHelperSQL.RunProcedure("InfoStaticQueueTab_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int InfoID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@InfoID", SqlDbType.Int,4)
										};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure("InfoStaticQueueTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.InfoStatic.InfoStaticQueueTab GetModel(int InfoID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@InfoID", SqlDbType.Int,4)
										};
            parameters[0].Value = InfoID;
            Tz888.Model.InfoStatic.InfoStaticQueueTab model = new Tz888.Model.InfoStatic.InfoStaticQueueTab();

            DataSet ds = DbHelperSQL.RunProcedure("InfoStaticQueueTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["InfoID"].ToString() != "")
                {
                    model.InfoID = int.Parse(ds.Tables[0].Rows[0]["InfoID"].ToString());
                }
                model.InfoType = ds.Tables[0].Rows[0]["InfoType"].ToString();
                if (ds.Tables[0].Rows[0]["StateFlag"].ToString() != "")
                {
                    model.StateFlag = int.Parse(ds.Tables[0].Rows[0]["StateFlag"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        //获取静态化队列列表
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
            parameters[0].Value = "InfoStaticQueueTab";
            parameters[1].Value = GetFields;
            parameters[2].Value = OrderName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = doCount;
            parameters[6].Value = OrderType;
            parameters[7].Value = StrWhere;

            return DbHelperSQL.RunProcedure("Sp_Conn_Sort", parameters, "ds");
        }

        /// <summary>
        /// 创建静态化队列
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="Command"></param>
        /// <param name="Count"></param>
        /// <param name="State"></param>
        public int Create(System.DateTime StartTime, System.DateTime EndTime, int Command, ref int Count, ref int State)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
											new SqlParameter("@StartTime",SqlDbType.DateTime),
											new SqlParameter("@EndTime",SqlDbType.DateTime),
											new SqlParameter("@Command",SqlDbType.Int,4),
											new SqlParameter("@Count",SqlDbType.Int,4),
											new SqlParameter("@State",SqlDbType.Int,4),
			};
            parameters[0].Value = StartTime;
            parameters[1].Value = EndTime;
            parameters[2].Value = Command;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[3].Value = Count;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[4].Value = State;
            try
            {

                DbHelperSQL.RunProcedure("InfoStaticQueueTab_Create", parameters, out rowsAffected);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }

            Count = Convert.ToInt32(parameters[3].Value);
            State = Convert.ToInt32(parameters[4].Value);

            return rowsAffected;
        }

        /// <summary>
        /// 获取队列中记录的总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            string StrSql = "Select Count(*) from InfoStaticQueueTab Where StateFlag = 0";
            return Convert.ToInt32(DbHelperSQL.Query(StrSql).Tables[0].Rows[0][0]);
        }

        #endregion  成员方法
    }
}