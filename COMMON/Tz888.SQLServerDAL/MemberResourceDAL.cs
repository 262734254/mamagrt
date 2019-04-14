using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 数据访问类MemberResourceTab 。
    /// </summary>
    public class MemberResourceDAL : IMemberResource
    {
        public MemberResourceDAL()
        { }
        #region  成员方法        
        /// <summary>
        ///  增加一条数据(公司图片上传时一起的 使用事务)
        /// </summary>       
       public int Add(SqlConnection sqlConn, SqlTransaction sqlTran, Tz888.Model.MemberResourceModel model)
        {    
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.VarChar,50),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@UpDate", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
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

            DbHelperSQL.RunProcedure(sqlConn, sqlTran, "UP_MemberResourceTab_ADD", parameters, out rowsAffected);
            return 1;// (int)parameters[0].Value;
        }
        /// <summary>
        /// 添加会员认证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddMemberCert(Tz888.Model.MemberResourceModel model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.VarChar,50),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.ResourceName;
            parameters[3].Value = model.ResourceTitle;
            parameters[4].Value = model.ResourceDescrib;
            parameters[5].Value = model.ResourceType;
            parameters[6].Value = model.ResourceAddr;
            parameters[7].Value = model.ResourceProperty;
            parameters[8].Value = model.ResourcePassword;
            parameters[9].Value = model.remark;

           bool b= DbHelperSQL.RunProcLob("MemberCertInsert", parameters);
           return b;
        }
        /// <summary>
        ///  信息结果页面的上传（EnterpriseRegisterResult.aspx）
        /// </summary>       
        public void AddFromResult(Tz888.Model.MemberResourceModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.VarChar,50),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@UpDate", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
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

            DbHelperSQL.RunProcedure("UP_MemberResourceTab_ADD", parameters, out rowsAffected);
           
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(Tz888.Model.MemberResourceModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@ResourceName", SqlDbType.VarChar,100),
					new SqlParameter("@ResourceTitle", SqlDbType.VarChar,50),
					new SqlParameter("@ResourceDescrib", SqlDbType.VarChar,1000),
					new SqlParameter("@ResourceType", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourceAddr", SqlDbType.VarChar,300),
					new SqlParameter("@ResourceProperty", SqlDbType.SmallInt,2),
					new SqlParameter("@ResourcePassword", SqlDbType.Binary,1),
					new SqlParameter("@UpDate", SqlDbType.DateTime),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Value = model.ResourceID;
            parameters[1].Value = model.LoginName;
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

            DbHelperSQL.RunProcedure("UP_MemberResourceTab_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ResourceID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ResourceID", SqlDbType.Int,4)
				};
            parameters[0].Value = ResourceID;
            DbHelperSQL.RunProcedure("UP_MemberResourceTab_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 获取指定所有登记图片信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public List<Tz888.Model.MemberResourceModel> GetModelList(string LoginName, int ResourceProperty)
        {
            List<Tz888.Model.MemberResourceModel> lists = new List<Tz888.Model.MemberResourceModel>();
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,20),
                    new SqlParameter("@ResourceProperty",SqlDbType.Int)
				};
            parameters[0].Value = LoginName;
            parameters[1].Value = ResourceProperty;

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberResourceTab_GetAllList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Tz888.Model.MemberResourceModel model = new Tz888.Model.MemberResourceModel();

                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.ResourceName = ds.Tables[0].Rows[0]["ResourceName"].ToString();
                model.ResourceTitle = ds.Tables[0].Rows[0]["ResourceTitle"].ToString();
                model.ResourceDescrib = ds.Tables[0].Rows[0]["ResourceDescrib"].ToString();
                if (ds.Tables[0].Rows[0]["ResourceType"].ToString() != "")
                {
                    model.ResourceType = int.Parse(ds.Tables[0].Rows[0]["ResourceType"].ToString());
                }
                model.ResourceAddr = ds.Tables[0].Rows[0]["ResourceAddr"].ToString();
                if (ds.Tables[0].Rows[0]["ResourceProperty"].ToString() != "")
                {
                    model.ResourceProperty = int.Parse(ds.Tables[0].Rows[0]["ResourceProperty"].ToString());
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

                lists.Add(model);
            }
            return lists;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.MemberResourceModel GetModel(string  LoginName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,20)
				};
            parameters[0].Value = LoginName;
            Tz888.Model.MemberResourceModel model = new Tz888.Model.MemberResourceModel();

            DataSet ds = DbHelperSQL.RunProcedure("UP_MemberResourceTab_GetModel", parameters, "ds");           
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.ResourceName = ds.Tables[0].Rows[0]["ResourceName"].ToString();
                model.ResourceTitle = ds.Tables[0].Rows[0]["ResourceTitle"].ToString();
                model.ResourceDescrib = ds.Tables[0].Rows[0]["ResourceDescrib"].ToString();
                if (ds.Tables[0].Rows[0]["ResourceType"].ToString() != "")
                {
                    model.ResourceType = int.Parse(ds.Tables[0].Rows[0]["ResourceType"].ToString());
                }
                model.ResourceAddr = ds.Tables[0].Rows[0]["ResourceAddr"].ToString();
                if (ds.Tables[0].Rows[0]["ResourceProperty"].ToString() != "")
                {
                    model.ResourceProperty = int.Parse(ds.Tables[0].Rows[0]["ResourceProperty"].ToString());
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
        #endregion  成员方法
    }
}


