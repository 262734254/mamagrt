using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.MyHome;
using Tz888.IDAL.MyHome;
using Tz888.Pager;

namespace Tz888.SQLServerDAL.MyHome
{
    public class HomeLinkService :IHomeLink
    {
        

        HomeTypeService type = new HomeTypeService();   //实例化对象
        #region IHomeType 添加我的主页信息
        /// <summary>
       /// 添加我的主页信息
       /// </summary>
       /// <param name="cs"></param>
       /// <returns>num</returns>
        public int InsertHomeLink(MyHomeLink cs)
        {
            SqlParameter[] para = new SqlParameter[]
          {
                    new SqlParameter("@LID",cs.LID),
                    new SqlParameter("@NID", cs.Typeid.TID),
					new SqlParameter("@LName",cs.LName ),
					new SqlParameter("@Linkwww",cs.Linkwww ),
					new SqlParameter("@WDoc",cs.WDoc ),
					new SqlParameter("@WSort",cs.WSort ),
					new SqlParameter("@UserName", cs.UserName),
					new SqlParameter("@PassWord",cs.PassWord ),
					new SqlParameter("@States", cs.States),
					new SqlParameter("@CreateTimes", cs.CreateTimes),
					new SqlParameter("@LoginName",cs.LoginName ),
					new SqlParameter("@LoginID", cs.LoginID)

          };
            int num = Tz888.DBUtility.DBHelper.ExecuteNonQueryProc("usp_AddHomeLink", para);
            return num;
        }

        #endregion
        #region 分页
        /////// <summary>
        /////// 分页获取数据列表
        /////// </summary>
        /////// <param name="pb">分页基本信息</param>
        /////// <param name="count">返回总条数</param>
        /////// <returns></returns>
        //public DataSet GetList(PageBase pb, ref int count)
        //{
        //    SqlParameter[] parameters = 
        //    {
        //        new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
        //        new SqlParameter("@strGetFields", SqlDbType.NVarChar, 255),
        //        new SqlParameter("@fldName", SqlDbType.NVarChar, 255),
        //        new SqlParameter("@PageSize", SqlDbType.Int),
        //        new SqlParameter("@PageIndex", SqlDbType.Int),
        //        new SqlParameter("@doCount", SqlDbType.Int),
        //        new SqlParameter("@OrderType", SqlDbType.Int),
        //        new SqlParameter("@strWhere", SqlDbType.VarChar,5000),
        //    };
        //    parameters[0].Value = pb.TblName;
        //    parameters[1].Value = pb.StrGetFields;
        //    parameters[2].Value = pb.FldName;
        //    parameters[3].Value = pb.PageSize;
        //    parameters[4].Value = pb.PageIndex;
        //    parameters[5].Value = pb.DoCount;
        //    parameters[6].Value = pb.OrderType;
        //    parameters[7].Value = pb.StrWhere;

        //    DataSet ds = new DataSet();
        //    ds = Tz888.DBUtility.DbHelperSQL.RunProcedure(pb.ProcedureName, parameters, "ds");
        //    if (pb.DoCount == 1)
        //    {
        //        if (ds.Tables.Count == 1)
        //            count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        //    }
        //    return ds;
        //}
        
        #endregion
        #region IHomeLink查询所有我的主页信息此方法暂时没有使用

        /// <summary>
        /// 查询所有我的主页信息
        /// </summary>
        /// <returns>list</returns>
        public IList<MyHomeLink> GetAllMyHome(string LoginName)
        {
            string sql = "select * from HomeLink where LoginName =@LoginName";
            DataTable tb = Tz888.DBUtility.DBHelper.GetDataSet(sql);
            IList<MyHomeLink> list = new List<MyHomeLink>();
            foreach (DataRow r in tb.Rows)
            {
                MyHomeLink home = new MyHomeLink();
                home.CreateTimes = (DateTime)r["CreateTimes"];
                home.LID = (int)r["LID"];
                home.Linkwww = (string)r["Linkwww"];
                home.LName = (string)r["LName"];
                home.LoginID = (int)r["LoginID"];
                home.LoginName = (string)r["LoginName"];
                home.PassWord = (string)r["PassWord"];
                home.States = (int)r["States"];
                home.Typeid = type.GetAllTypeById((int)r["NID"]);
                home.UserName = (string)r["UserName"];
                home.WDoc = (string)r["WDoc"];
                home.WSort = (int)r["WSort"];
                list.Add(home);
            }
            return list;
        
        }

        #endregion

        #region 通用
        public List<MyHomeLink> GetHomeList(SqlDataReader reader)
        {
            List<MyHomeLink> list = new List<MyHomeLink>();
            while (reader.Read())
            {
                MyHomeLink home = new MyHomeLink();
                home.CreateTimes = (DateTime)reader["CreateTimes"];
                home.LID = (int)reader["LID"];
                home.Linkwww = (string)reader["Linkwww"];
                home.LName = (string)reader["LName"];
                home.LoginID = (int)reader["LoginID"];
                home.LoginName = (string)reader["LoginName"];
                home.PassWord = (string)reader["PassWord"];
                home.States = (int)reader["States"];
                home.Typeid = type.GetAllTypeById((int)reader["NID"]);
                home.UserName = (string)reader["UserName"];
                home.WDoc = (string)reader["WDoc"];
                home.WSort = (int)reader["WSort"];
                list.Add(home);
            }
            return list;
        } 
        #endregion

        #region 根据ID删除信息


        public int deleteMyHome(int Id)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@Id",Id)

          };
            int num = Tz888.DBUtility.DBHelper.ExecuteNonQueryProc("usp_deleteMyHomeById", para);
            return num;
        }

        #endregion

        #region 根据ID查看信息

        /// <summary>
        /// 根据ID查看信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MyHomeLink GetAllMyHomeById(int Id)
        {

            string sql = "usp_SelcectMyHomeById";
            MyHomeLink home = new MyHomeLink();
            using (SqlDataReader reader = Tz888.DBUtility.DBHelper.ExecuteReaderProc(sql, new SqlParameter("@Id", Id)))
            {
                while (reader.Read())
                {

                    home.CreateTimes = (DateTime)reader["CreateTimes"];
                    home.LID = (int)reader["LID"];
                    home.Linkwww = (string)reader["Linkwww"];
                    home.LName = (string)reader["LName"];
                    home.LoginID = (int)reader["LoginID"];
                    home.LoginName = (string)reader["LoginName"];
                    home.PassWord = (string)reader["PassWord"];
                    home.States = (int)reader["States"];
                    home.Typeid = type.GetAllTypeById((int)reader["NID"]);
                    home.UserName = (string)reader["UserName"];
                    home.WDoc = (string)reader["WDoc"];
                    home.WSort = (int)reader["WSort"];

                }

            }
            return home;
        }

        #endregion


        #region 修改信息


        public int UpdateMyHome(MyHomeLink cs)
        {
          //  SqlParameter[] para = new SqlParameter[]
          //{
          //          new SqlParameter("@LID",cs.LID),
          //          new SqlParameter("@NID", cs.Typeid.TID),
          //          new SqlParameter("@LName",cs.LName ),
          //          new SqlParameter("@Linkwww",cs.Linkwww ),
          //          new SqlParameter("@WDoc",cs.WDoc ),
          //          new SqlParameter("@WSort",cs.WSort ),
          //          new SqlParameter("@UserName", cs.UserName),
          //          new SqlParameter("@PassWord",cs.PassWord ),
          //          new SqlParameter("@States", cs.States),
          //          new SqlParameter("@CreateTimes", cs.CreateTimes),
          //          new SqlParameter("@LoginName",cs.LoginName ),
          //          new SqlParameter("@LoginID", cs.LoginID)
          //};
          //  int num = Tz888.DBUtility.DBHelper.ExecuteNonQueryProc("up_updateMyHome", para);
          //  return num;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HomeLink set ");
            strSql.Append("NID=@NID,");
            strSql.Append("LName=@LName,");
            strSql.Append("Linkwww=@Linkwww,");
            strSql.Append("WDoc=@WDoc,");
            strSql.Append("WSort=@WSort,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("PassWord=@PassWord,");
            strSql.Append("States=@States,");
            strSql.Append("CreateTimes=@CreateTimes,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("LoginID=@LoginID");
            strSql.Append(" where LID=@LID ");
            SqlParameter[] parameters = {
				  new SqlParameter("@LID",cs.LID),
                    new SqlParameter("@NID", cs.Typeid.TID),
                    new SqlParameter("@LName",cs.LName ),
                    new SqlParameter("@Linkwww",cs.Linkwww ),
                    new SqlParameter("@WDoc",cs.WDoc ),
                    new SqlParameter("@WSort",cs.WSort ),
                    new SqlParameter("@UserName", cs.UserName),
                    new SqlParameter("@PassWord",cs.PassWord ),
                    new SqlParameter("@States", cs.States),
                    new SqlParameter("@CreateTimes", cs.CreateTimes),
                    new SqlParameter("@LoginName",cs.LoginName ),
                    new SqlParameter("@LoginID", cs.LoginID)
            };
            parameters[0].Value = cs.LID;
            parameters[1].Value = cs.Typeid.TID;
;
            parameters[2].Value = cs.LName;
            parameters[3].Value = cs.Linkwww;
            parameters[4].Value = cs.WDoc;
            parameters[5].Value = cs.WSort;
            parameters[6].Value = cs.UserName;
            parameters[7].Value = cs.PassWord;
            parameters[8].Value = cs.States;
            parameters[9].Value = cs.CreateTimes;
            parameters[10].Value = cs.LoginName;
            parameters[11].Value = cs.LoginID;

            int num = Tz888.DBUtility.DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return num;
        }

        #endregion

        #region 条件查询没有，留着后期开发

        public List<MyHomeLink> SelectHomeList(string LoginName)
        {
            throw new Exception("The method or operation is not implemented.");
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
            MyHomeType  model = new MyHomeType();
            string sql = "select top 6 TID,  TypeName from  HomeType where LoginName='" + LoginName + "' order by sort";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.ExecuteQuery(sql);
            StringBuilder sb = new StringBuilder();

            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    int TID= Convert.ToInt32(dr["TID"].ToString());
                    string TypeName = dr["TypeName"].ToString();
                    sb.Append("<li id= nav_btn_" + (i + 3).ToString() + " onclick=SetBtn('nav'," + (i + 3).ToString() + ","+ (dr["TID"].ToString()) +")> " + dr["TypeName"].ToString() + "</li>");

                }
               
                return sb.ToString();
            }
            else
            {
                return "";
            }
               
        }


        #endregion
    }
}
