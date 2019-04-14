using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL
{
    public class ErrowTabDAL
    {
        /// <summary>
        /// 增加错误处理的一条数据
        /// </summary>
        public int Add(ErrowTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ErrowTab(");
            strSql.Append("LoginName,LinkURL,QuestionDescript,Connetions,BoolChuLi,BoolReturn,ReturnContext,Descript,createtime,updatetime)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@LinkURL,@QuestionDescript,@Connetions,@BoolChuLi,@BoolReturn,@ReturnContext,@Descript,@createtime,@updatetime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.NVarChar,300),
					new SqlParameter("@LinkURL", SqlDbType.NVarChar,300),
					new SqlParameter("@QuestionDescript", SqlDbType.Text),
					new SqlParameter("@Connetions", SqlDbType.NVarChar,300),
					new SqlParameter("@BoolChuLi", SqlDbType.Int,4),
					new SqlParameter("@BoolReturn", SqlDbType.Int,4),
					new SqlParameter("@ReturnContext", SqlDbType.Text),
					new SqlParameter("@Descript", SqlDbType.NVarChar,500),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.LinkURL;
            parameters[2].Value = model.QuestionDescript;
            parameters[3].Value = model.Connetions;
            parameters[4].Value = model.BoolChuLi;
            parameters[5].Value = model.BoolReturn;
            parameters[6].Value = model.ReturnContext;
            parameters[7].Value = model.Descript;
            parameters[8].Value = model.createtime;
            parameters[9].Value = model.updatetime;

            object obj = DBHelpe.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        //修改数据
        public int Update(ErrowTab model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ErrowTab set ");
            strSql.Append("LinkURL=@LinkURL,");
            strSql.Append("QuestionDescript=@QuestionDescript,");
            strSql.Append("Connetions=@Connetions,");
            strSql.Append("BoolChuLi=@BoolChuLi,");
            strSql.Append("BoolReturn=@BoolReturn,");
            strSql.Append("ReturnContext=@ReturnContext,");
            strSql.Append("Descript=@Descript,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("updatetime=@updatetime");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@LinkURL", SqlDbType.NVarChar,300),
					new SqlParameter("@QuestionDescript", SqlDbType.Text),
					new SqlParameter("@Connetions", SqlDbType.NVarChar,300),
					new SqlParameter("@BoolChuLi", SqlDbType.Int,4),
					new SqlParameter("@BoolReturn", SqlDbType.Int,4),
					new SqlParameter("@ReturnContext", SqlDbType.Text),
					new SqlParameter("@Descript", SqlDbType.NVarChar,500),
					new SqlParameter("@LoginName", SqlDbType.NVarChar,300),
					new SqlParameter("@createtime", SqlDbType.DateTime),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.LinkURL;
            parameters[2].Value = model.QuestionDescript;
            parameters[3].Value = model.Connetions;
            parameters[4].Value = model.BoolChuLi;
            parameters[5].Value = model.BoolReturn;
            parameters[6].Value = model.ReturnContext;
            parameters[7].Value = model.Descript;
            parameters[8].Value = model.LoginName;
            parameters[9].Value = model.createtime;
            parameters[10].Value = model.updatetime;

            return DBHelpe.ExecuteCommand(strSql.ToString(), parameters);
        }
        //通过ID获取一个实体对象
        public ErrowTab GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LinkURL,QuestionDescript,Connetions,BoolChuLi,BoolReturn,ReturnContext,Descript,LoginName,createtime,updatetime from ErrowTab ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            ErrowTab model = new ErrowTab();
            DataSet ds = DBHelpe.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LinkURL = ds.Tables[0].Rows[0]["LinkURL"].ToString();
                model.QuestionDescript = ds.Tables[0].Rows[0]["QuestionDescript"].ToString();
                model.Connetions = ds.Tables[0].Rows[0]["Connetions"].ToString();
                if (ds.Tables[0].Rows[0]["BoolChuLi"].ToString() != "")
                {
                    model.BoolChuLi = int.Parse(ds.Tables[0].Rows[0]["BoolChuLi"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BoolReturn"].ToString() != "")
                {
                    model.BoolReturn = int.Parse(ds.Tables[0].Rows[0]["BoolReturn"].ToString());
                }
                model.ReturnContext = ds.Tables[0].Rows[0]["ReturnContext"].ToString();
                model.Descript = ds.Tables[0].Rows[0]["Descript"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.createtime = ds.Tables[0].Rows[0]["createtime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.updatetime = ds.Tables[0].Rows[0]["updatetime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        //获取实体对象集合
        public List<ErrowTab> GetModelList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,LinkURL,QuestionDescript,Connetions,BoolChuLi,BoolReturn,ReturnContext,Descript,LoginName,createtime,updatetime from ErrowTab ");

            List<ErrowTab> list = new List<ErrowTab>();
            DataSet ds = DBHelpe.Query(strSql.ToString());
            foreach (DataRow row in ds.Tables [0].Rows)
            {
                ErrowTab model = new ErrowTab();
                if (row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.LinkURL = ds.Tables[0].Rows[0]["LinkURL"].ToString();
                model.QuestionDescript = ds.Tables[0].Rows[0]["QuestionDescript"].ToString();
                model.Connetions = ds.Tables[0].Rows[0]["Connetions"].ToString();
                if (ds.Tables[0].Rows[0]["BoolChuLi"].ToString() != "")
                {
                    model.BoolChuLi = int.Parse(ds.Tables[0].Rows[0]["BoolChuLi"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BoolReturn"].ToString() != "")
                {
                    model.BoolReturn = int.Parse(ds.Tables[0].Rows[0]["BoolReturn"].ToString());
                }
                model.ReturnContext = ds.Tables[0].Rows[0]["ReturnContext"].ToString();
                model.Descript = ds.Tables[0].Rows[0]["Descript"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.createtime = ds.Tables[0].Rows[0]["createtime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["updatetime"].ToString() != "")
                {
                    model.updatetime = ds.Tables[0].Rows[0]["updatetime"].ToString();
                }
                list.Add(model);
            }
            return list;

        }
    }
}
