using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;
using Tz888.IDAL.Info;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 信息联系人数据库访问逻辑类
    /// </summary>
    public class InfoContactManDAL : IInfoContactMan
    {
        private const string SP_InfoContactMan_Insert = "InfoContactManTab_Insert";


        /// <summary>
        /// 获取指定资源ID的所有联系人信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public List<Tz888.Model.Info.InfoContactManModel> GetModelList(long InfoID)
        {
            List<Tz888.Model.Info.InfoContactManModel> lists = new List<InfoContactManModel>();
            SqlParameter[] parameters = {new SqlParameter("@InfoID", SqlDbType.BigInt,8)};
            parameters[0].Value = InfoID;
            DataSet ds = DbHelperSQL.RunProcedure("InfoContactManTab_GetListByInfoID", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Tz888.Model.Info.InfoContactManModel model = new Tz888.Model.Info.InfoContactManModel();
                model.InfoID = InfoID;
                if (ds.Tables[0].Rows[i]["ContactManID"].ToString() != "")
                {
                    model.ContactManID = Convert.ToInt64(ds.Tables[0].Rows[0]["ContactManID"]);
                }
                model.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                model.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                model.Remark = ds.Tables[0].Rows[i]["Remark"].ToString();
                lists.Add(model);
            }
            return lists;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ContactManID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContactManID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = ContactManID;
            DbHelperSQL.RunProcedure("InfoContactManTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除指定InfoID的所有联系人信息
        /// </summary>
        public void DeleteByInfoID(long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure("InfoContactManTab_DeleteByInfoID", parameters, out rowsAffected);
        }

        #region 带事务方法

        /// <summary>
        /// 添加信息联系人(使用事务控制)
        /// </summary>
        public bool InsertContactMan(SqlConnection sqlConn, SqlTransaction sqlTran, Tz888.Model.Info.InfoContactManModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContactManID", SqlDbType.BigInt,8),
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Name", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.InfoID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Remark;

            DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_InfoContactMan_Insert, parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除指定InfoID的所有联系人信息
        /// </summary>
        public bool DeleteByInfoID(SqlConnection sqlConn, SqlTransaction sqlTran, long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure(sqlConn, sqlTran, "InfoContactManTab_DeleteByInfoID", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion
    }
}
