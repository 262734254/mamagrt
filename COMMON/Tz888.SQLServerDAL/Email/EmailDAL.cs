using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Tz888.Model;

namespace Tz888.SQLServerDAL.Email
{
    public class EmailDAL : Tz888.IDAL.Email.IEmail
    {
        #region 邮件分组

        //获取所有的分组
        public DataTable getEmailGroup()
        {
            DataTable dt = new DataTable();
            string sqlStr = "select * from EmailGroupTab";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        //获取一个分组
        public Tz888.Model.Email.EmailUserModel getEmailGroupByID(int groupID)
        {
            Tz888.Model.Email.EmailUserModel emodel = new Tz888.Model.Email.EmailUserModel();
            string sqlStr = "select * from EmailGroupTab where Group_ID=" + groupID.ToString();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                emodel.Group_ID = groupID;
                emodel.Group_Name = dr["Group_Name"].ToString().Trim();
                emodel.Group_AddTime = Convert.ToDateTime(dr["Group_AddTime"].ToString().Trim());
            }
            ds.Clear();
            return emodel;
        }

        //添加分组
        public int addEmailGroup(Tz888.Model.Email.EmailUserModel emodel)
        {
            string sqlStr = "insert EmailGroupTab(Group_Name) values ('" + emodel.Group_Name.Trim() + "')";
            int flag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            return flag;
        }

        //修改分组
        public int modifyEmailGroup(Tz888.Model.Email.EmailUserModel emodel)
        {
            string sqlStr = "update EmailGroupTab set Group_Name='" + emodel.Group_Name.Trim() + "' where Group_ID=" + emodel.Group_ID.ToString();
            int flag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            return flag;
        }

        //删除分组
        public int delEmailGroup(int groupID)
        {
            string sqlStr = "delete from EmailGroupTab where Group_ID=" + groupID.ToString();
            int flag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            return flag;
        }

        #endregion


        #region 邮件用户

        //获取所有的邮件用户
        public DataTable getEmailUser()
        {
            DataTable dt = new DataTable();
            string sqlStr = "select * from EmailUserTab left join EmailGroupTab on EmailUserTab.Euser_Group=EmailGroupTab.Group_ID ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        public int isEmailUser(string name,string email)
        {
            int flag = 0;
            try
            {
                string sqlStr = "select count(*) from EmailUserTab where Euser_Name='" + name.Trim() + "' or Euser_Email='" + email.Trim() + "'";
                DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
                if (ds != null && ds.Tables.Count > 0)
                {
                    flag = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            catch 
            {
            }
            return flag;
        }

        public DataTable getTopEmailUser(int top)
        {
            DataTable dt = new DataTable();
            string sqlStr = "select top " + top.ToString() + " * from EmailUserTab left join EmailGroupTab " +
                " on EmailUserTab.Euser_Group=EmailGroupTab.Group_ID order by Euser_ID desc ";
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        public DataTable getEmailUserByGID(int Group_ID)
        {
            DataTable dt = new DataTable();
            string sqlStr = "select * from EmailUserTab left join EmailGroupTab on EmailUserTab.Euser_Group=EmailGroupTab.Group_ID where Group_ID=" + Group_ID.ToString();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        //获取某个组的邮件用户
        public Tz888.Model.Email.EmailUserModel getEmailUser(int userID)
        {
            Tz888.Model.Email.EmailUserModel emodel = new Tz888.Model.Email.EmailUserModel();
            string sqlStr = "select * from EmailUserTab left join EmailGroupTab on EmailUserTab.Euser_Group=EmailGroupTab.Group_ID "+
                " where Euser_ID=" + userID.ToString();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                emodel.Euser_ID = userID;
                emodel.Euser_Name = dr["Euser_Name"].ToString().Trim();
                emodel.Euser_Group = Convert.ToInt32(dr["Euser_Group"].ToString().Trim());
                emodel.Euser_Email = dr["Euser_Email"].ToString().Trim();
                emodel.Group_Name = dr["Group_Name"].ToString().Trim();
                emodel.Euser_AddTime = Convert.ToDateTime(dr["Euser_AddTime"].ToString().Trim());
            }
            ds.Clear();
            return emodel;
        }

        //添加邮件用户
        public int addEmailUser(Tz888.Model.Email.EmailUserModel emodel)
        {
            string sqlStr = "insert EmailUserTab(Euser_Name,Euser_Group,Euser_Email) values ('" + emodel.Euser_Name.Trim() 
                + "'," + emodel.Euser_Group.ToString().Trim() + ",'" + emodel.Euser_Email.Trim() + "')";
            int flag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            return flag;
        }

        //修改邮件用户
        public int modifyEmailUser(Tz888.Model.Email.EmailUserModel emodel)
        {
            string sqlStr = "update EmailUserTab set Euser_Name='" + emodel.Euser_Name.Trim() + "',Euser_Group=" + emodel.Euser_Group.ToString().Trim()
                + ",Euser_Email='" + emodel.Euser_Email.Trim() + "' where Euser_ID=" + emodel.Euser_ID.ToString();
            int flag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            return flag;
        }

        //删除邮件用户
        public int delEmailUser(int UserID)
        {
            string sqlStr = "delete from EmailUserTab where Euser_ID=" + UserID.ToString();
            int flag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            return flag;
        }

        #endregion


        #region 群发过的邮件记录
        public int addEmail(Tz888.Model.Email.EmailModel model, List<Tz888.Model.Email.EmailAnnexModel> EmailAnnex)
        {
            int flag = 0;
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Email_Name",model.Email_Name),
                new SqlParameter("@Email_RUser",model.Email_RUser),
                new SqlParameter("@Email_Content",model.Email_Content),
                new SqlParameter("@Email_AddTime",model.Email_AddTime),
                new SqlParameter("@Email_IsSuc",model.Email_IsSuc),
                };
            DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedures("proc_Email_add", param, "ds");
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                flag = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                if (flag > 0 && EmailAnnex!=null&&EmailAnnex.Count>0)
                {
                    for (int i = 0; i < EmailAnnex.Count; i++)
                    {
                        Tz888.Model.Email.EmailAnnexModel amodel=EmailAnnex[i];
                        amodel.Annex_EmailID = flag;
                        string sqlStr2 = "insert  into EmailAnnexTab(Annex_EmailID,Annex_Name,Annex_Addr)" +
                                " values (" + flag + ",'" + amodel.Annex_Name + "','" + amodel.Annex_Addr + "')";
                        int aflag = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr2);
                    }
                }
            }
            return flag;
        }
        #endregion

        #region 信息反馈
        public int UPdateEmailFeedBack(string LogID)
        {
            string sql = "update EmailLogTab set Log_IsRead=1 where Log_ID=" + LogID;
            int i = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql);
            return i;
        }
        #endregion

        #region 群发邮件记录日志
        public int addEmailLog(Tz888.Model.Email.EmailLogModel model)
        {
            string sqlStr = "insert EmailLogTab(Log_EmailID,Log_UserID,Log_IsRead)" +
                " values (" + model.Log_EmailID + "," + model.Log_UserID + "," + model.Log_IsRead + ");select @@identity as ID";
            object flag = Tz888.DBUtility.DbHelperSQL.GetSingle(sqlStr);
            return int.Parse(flag.ToString());
        }
        #endregion

        #region 检查用户是否重复
        public bool CheckUser(string userID, string UserEmail,string EUserID)
        {
            string sql = "select * from EmailUserTab where Euser_Name=@UserID or Euser_Email=@UserEmail and Euser_ID<>@Euser_ID";
            SqlParameter[] parme ={
                                  new SqlParameter("@UserID",userID),
                                  new SqlParameter("@UserEmail",UserEmail),
                                  new SqlParameter("@Euser_ID",EUserID) 
                                  };
            SqlDataReader dr = Tz888.DBUtility.DbHelperSQL.ExecuteReader(sql, parme);
            return dr.Read();
        }
        #endregion
    }
}
