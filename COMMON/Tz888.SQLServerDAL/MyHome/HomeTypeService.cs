using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.MyHome;
using Tz888.IDAL.MyHome;

namespace Tz888.SQLServerDAL.MyHome
{
    public class HomeTypeService : IHomeType
    {


        #region IHomeType 查询所有类型信息
        /// <summary>
        /// 查询所有客房类型信息
        /// </summary>
        /// <returns></returns
        public IList<MyHomeType> GetHomeTypeList(string LoginName)
        {
            //string sql = "select * from HomeType where LoginName=@LoginName";

            List<MyHomeType> list = new List<MyHomeType>();
      
            using (DataTable table = Tz888.DBUtility.DBHelper.GetDataSet("select * from HomeType where LoginName='" + LoginName + "' "))
            {
                foreach (DataRow row in table.Rows)
                {
                    MyHomeType home = new MyHomeType();
                    home.TID = (int)row["TID"];
                    home.LoginID = (int)row["LoginID"];
                    home.Datatimes = (DateTime)row["Datatimes"];
                    home.LoginName = (string)row["LoginName"];
                    home.sort = (int)row["sort"];
                    home.TypeName = (string)row["TypeName"];
                    list.Add(home);
                }
                return list;
            }
        }

        #endregion

        #region IHomeType根据ID查看类型

        /// <summary>
        /// 根据ID查看类型
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>home</returns>
        public MyHomeType GetAllTypeById(int Id)
        {
            string sql = "select TID,TypeName,LoginName,LoginID,sort,Datatimes from HomeType where TID=@Id";
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;
            MyHomeType model = new MyHomeType();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TID"].ToString() != "")
                {
                    model.TID = int.Parse(ds.Tables[0].Rows[0]["TID"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["LoginID"].ToString() != "")
                {
                    model.LoginID = int.Parse(ds.Tables[0].Rows[0]["LoginID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort"].ToString() != "")
                {
                    model.sort = int.Parse(ds.Tables[0].Rows[0]["sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Datatimes"].ToString() != "")
                {
                    model.Datatimes = DateTime.Parse(ds.Tables[0].Rows[0]["Datatimes"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
            
        }
    
        #endregion




        #region IHomeType 添加类型


        public int InsertHomeType(MyHomeType cs)
        {

            SqlParameter[] para = new SqlParameter[]
          {
                   new SqlParameter("@TID",cs.TID),
					new SqlParameter("@TypeName", cs.TypeName),
					new SqlParameter("@LoginName",cs.LoginName),
					new SqlParameter("@LoginID", cs.LoginID),
					new SqlParameter("@sort",cs.sort),
					new SqlParameter("@Datatimes", cs.Datatimes)
            };
            int num = Tz888.DBUtility.DBHelper.ExecuteNonQueryProc("SP_HomeType_ADD", para);
            return num;
        
        }

        #endregion

        #region 根据登录名查询


        public List<MyHomeType> SelectHomeType(string LoginName)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@LoginName",LoginName)
             

          };
            SqlDataReader reader = (SqlDataReader)Tz888.DBUtility.DBHelper.ExecuteReaderProc("usp_SelectCarsDark", para);
            List<MyHomeType> list = GetCars(reader);
            return list;
        }

        #endregion

        #region 条件查询此方法暂时没有用到
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public List<MyHomeType> SelectHomeTypeList(string LoginName)
        {
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@LoginName",LoginName)
            

          };
            SqlDataReader reader = (SqlDataReader)Tz888.DBUtility.DBHelper.ExecuteReaderProc("usp_SelectTypelist", para);
            List<MyHomeType> list = GetTypeList(reader);
            return list;
        }  
        #endregion

        #region 通用  方法暂时没有 用 到


        public List<MyHomeType> GetTypeList(SqlDataReader reader)
        {
            List<MyHomeType> list = new List<MyHomeType>();
            while (reader.Read())
            {
                MyHomeType home = new MyHomeType();
                home.TID = (int)reader["TID"];
                home.LoginID = (int)reader["LoginID"];
                home.Datatimes = (DateTime)reader["Datatimes"];
                home.LoginName = (string)reader["LoginName"];
                home.sort = (int)reader["sort"];
                home.TypeName = (string)reader["TypeName"];
                list.Add(home);
            }
            return list;
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
            SqlParameter[] para = new SqlParameter[] 
          {
             new SqlParameter("@Id",Id)

          };
            int num = Tz888.DBUtility.DBHelper.ExecuteNonQueryProc("usp_deleteHomeTypeById", para);
            return num;
        }
        /// <summary>
        /// 根据ID修改信息
        /// </summary>
        /// <param name="cs"></param>
        /// <returns></returns>
        public int UpdateHomeType(MyHomeType cs)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                    new SqlParameter("@TID",cs.TID),
					new SqlParameter("@TypeName", cs.TypeName),
					new SqlParameter("@LoginName",cs.LoginName),
					new SqlParameter("@LoginID", cs.LoginID),
					new SqlParameter("@sort",cs.sort),
					new SqlParameter("@Datatimes", cs.Datatimes)
            };
            int num = Tz888.DBUtility.DBHelper.ExecuteNonQueryProc("SP_HomeType_Update", para);
            return num;
        }

        #endregion

        #region IHomeType 成员


        public List<MyHomeType> GetCars(SqlDataReader reader)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
    
}
