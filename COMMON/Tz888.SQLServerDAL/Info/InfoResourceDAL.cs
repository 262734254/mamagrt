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
    /// 信息资源数据库访问逻辑类
    /// </summary>
    public class InfoResourceDAL : IInfoResource
    {

        private const string SP_InfoResource_Insert = "InfoResourceTab_Insert";
        private const string SP_InfoResource_InsertMany = "InfoResourceTab_InsertMany";  //上传多个文件

        #region 添加资源信息
        /// <summary>
        /// 添加资源信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.InfoResourceModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.BigInt,8),
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.Char,13),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@UpDate", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.InfoID;
            parameters[2].Value = model.ResourceName;
            parameters[3].Value = model.ResourceTitle;
            parameters[4].Value = model.ResourceDescrib;
            parameters[5].Value = model.ResourceType;
            parameters[6].Value = model.ResourceAddr;
            parameters[7].Value = model.ResourceProperty;
            parameters[8].Value = model.ResourcePassword;
            parameters[9].Value = model.UpDate;
            parameters[10].Value = model.IsDel;
            parameters[11].Value = model.remark;
            
            DbHelperSQL.RunProcedure(SP_InfoResource_Insert, parameters, out rowsAffected);

            return (long)parameters[0].Value;
        }
        #endregion

        /// <summary>
        /// 获取一条资源信息
        /// </summary>
        /// <param name="ResourceID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.InfoResourceModel GetModel(long ResourceID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = ResourceID;
            Tz888.Model.Info.InfoResourceModel model = new Tz888.Model.Info.InfoResourceModel();

            DataSet ds = DbHelperSQL.RunProcedure("InfoResourceTab_GetModel", parameters, "ds");
            model.ResourceID = ResourceID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["InfoID"].ToString() != "")
                {
                    model.InfoID = int.Parse(ds.Tables[0].Rows[0]["InfoID"].ToString());
                }
                model.ResourceName = ds.Tables[0].Rows[0]["ResourceName"].ToString();
                model.ResourceTitle = ds.Tables[0].Rows[0]["ResourceTitle"].ToString();
                model.ResourceDescrib = ds.Tables[0].Rows[0]["ResourceDescrib"].ToString();
                model.ResourceType = Convert.ToInt32(ds.Tables[0].Rows[0]["ResourceType"]); 
                model.ResourceAddr = ds.Tables[0].Rows[0]["ResourceAddr"].ToString();
                if (ds.Tables[0].Rows[0]["ResourceProperty"].ToString() != "")
                {
                    model.ResourceProperty = int.Parse(ds.Tables[0].Rows[0]["ResourceProperty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ResourcePassword"].ToString() != "")
                {
                    model.ResourcePassword = (new UnicodeEncoding()).GetBytes(ds.Tables[0].Rows[0]["ResourcePassword"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpDate"].ToString() != "")
                {

                    model.UpDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDel"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDel"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }

                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定资源ID的所有资源信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public List<Tz888.Model.Info.InfoResourceModel> GetModelList(long InfoID)
        {
            List<InfoResourceModel> lists = new List<InfoResourceModel>();
            SqlParameter[] parameters ={ new SqlParameter("@InfoID", SqlDbType.BigInt, 8) };
            parameters[0].Value = InfoID;
            DataSet ds = DbHelperSQL.RunProcedure("InfoResourceTab_GetListByInfoID", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Tz888.Model.Info.InfoResourceModel model = new InfoResourceModel();
                model.InfoID = InfoID;
                if (ds.Tables[0].Rows[i]["ResourceID"].ToString() != "")
                {
                    model.ResourceID = int.Parse(ds.Tables[0].Rows[i]["ResourceID"].ToString());
                }
                model.ResourceName = ds.Tables[0].Rows[i]["ResourceName"].ToString();
                model.ResourceTitle = ds.Tables[0].Rows[i]["ResourceTitle"].ToString();
                model.ResourceDescrib = ds.Tables[0].Rows[i]["ResourceDescrib"].ToString();
                model.ResourceType = Convert.ToInt32(ds.Tables[0].Rows[i]["ResourceType"]); 
                model.ResourceAddr = ds.Tables[0].Rows[i]["ResourceAddr"].ToString();
                if (ds.Tables[0].Rows[i]["ResourceProperty"].ToString() != "")
                {
                    model.ResourceProperty = int.Parse(ds.Tables[0].Rows[i]["ResourceProperty"].ToString());
                }
                if (ds.Tables[0].Rows[i]["ResourcePassword"].ToString() != "")
                {
                    model.ResourcePassword = (new UnicodeEncoding()).GetBytes(ds.Tables[0].Rows[i]["ResourcePassword"].ToString());
                }
                if (ds.Tables[0].Rows[i]["UpDate"].ToString() != "")
                {

                    model.UpDate = DateTime.Parse(ds.Tables[0].Rows[i]["UpDate"].ToString());
                }
                if (ds.Tables[0].Rows[i]["IsDel"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[i]["IsDel"].ToString() == "1") || (ds.Tables[0].Rows[i]["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }
                model.remark = ds.Tables[0].Rows[i]["remark"].ToString();

                lists.Add(model);
            }
            return lists;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long ResourceID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = ResourceID;
            DbHelperSQL.RunProcedure("InfoResourceTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除指定InfoID的所有资源
        /// </summary>
        public bool DeleteByInfoID(long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure("InfoResourceTab_DeleteByInfoID", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }


        #region 带事务的方法

        /// <summary>
        /// 添加资源信息(带事务控制的方法)
        /// </summary>
        public bool InsertInfoResource(SqlConnection sqlConn, SqlTransaction sqlTran, Tz888.Model.Info.InfoResourceModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.BigInt,8),
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.Char,13),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@UpDate", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.InfoID;
            parameters[2].Value = model.ResourceName;
            parameters[3].Value = model.ResourceTitle;
            parameters[4].Value = model.ResourceDescrib;
            parameters[5].Value = model.ResourceType;
            parameters[6].Value = model.ResourceAddr;
            parameters[7].Value = model.ResourceProperty;
            parameters[8].Value = model.ResourcePassword;
            parameters[9].Value = model.UpDate;
            parameters[10].Value = model.IsDel;
            parameters[11].Value = model.remark;

            DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_InfoResource_Insert, parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        ///  添加资源信息(带事务控制的方法2.一次上传多个文件并写入库中)
        /// </summary>
        /// <param name="sqlConn"></param>
        /// <param name="sqlTran"></param>
        /// <param name="model"></param>
        /// <param name="IsMany">1表示为一次上传多个文件并写入表中</param>
        /// <returns></returns>
        public bool InsertInfoResource(SqlConnection sqlConn, SqlTransaction sqlTran, Tz888.Model.Info.InfoResourceModel model,int IsMany)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.BigInt,8),
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.Char,13),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@UpDate", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.InfoID;
            parameters[2].Value = model.ResourceName;
            parameters[3].Value = model.ResourceTitle;
            parameters[4].Value = model.ResourceDescrib;
            parameters[5].Value = model.ResourceType;
            parameters[6].Value = model.ResourceAddr;
            parameters[7].Value = model.ResourceProperty;
            parameters[8].Value = model.ResourcePassword;
            parameters[9].Value = model.UpDate;
            parameters[10].Value = model.IsDel;
            parameters[11].Value = model.remark;

            if (IsMany == 1)  //将多个文件写入表中
            {
                DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_InfoResource_InsertMany, parameters, out rowsAffected);
            }
            else
            {
                DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_InfoResource_Insert, parameters, out rowsAffected);
            }
            

            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除指定InfoID的所有资源
        /// </summary>
        public void DeleteByInfoID(SqlConnection sqlConn, SqlTransaction sqlTran, long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure(sqlConn, sqlTran, "InfoResourceTab_DeleteByInfoID", parameters, out rowsAffected);
        }
        #endregion
    }
}
