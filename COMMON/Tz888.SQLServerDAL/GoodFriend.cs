using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Collections.Generic;

namespace Tz888.SQLServerDAL
{
    public class GoodFriend:IGoodFriend
    {
        private Tz888.SQLServerDAL.Conn conn;                //数据库连接对象
        public GoodFriend()
        {
            conn = new Conn();
        }

        #region 黑名单管理
        public void BlackListManage(int contactId, int flag)  //flag:0 加入黑名单    1 黑名单恢复好友     
        {
            bool result = false;
            int groupId = 1;
            if (flag == 0)
            {
                groupId = 3;
            }
            else if (flag == 1)
            {
                groupId =2;
            }
            SqlParameter[] parameters ={
                new SqlParameter("@contactId",SqlDbType.Int),
                new SqlParameter("@groupId",SqlDbType.Int),
            };
            parameters[0].Value = contactId;
            parameters[1].Value = groupId;

            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoContactTab_Update", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
        }
        #endregion
 
        #region 彻底删除好友
        public void DeleteFriend(int contactId)
        {
            bool result = false;
            SqlParameter[] parameters ={
                new SqlParameter("@contactId",SqlDbType.Int),
            };
            parameters[0].Value = contactId;
            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoContactTab_Delete", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
        }
        #endregion

        #region  添加好友 
        public void AddFriend(Tz888.Model.GoodFriend model)
        {
            bool result = false;
            SqlParameter[] parameters ={
                new SqlParameter("@LoginName",SqlDbType.Char,16),
                new SqlParameter("@ContactName",SqlDbType.VarChar,30),
                new SqlParameter("@GroupId",SqlDbType.Int),
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.ContactName;
            parameters[2].Value = model.GroupId;
            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoContactTab_Insert", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
        }
        #endregion

        #region 查看是否黑名单用户或已为好友
        public bool IsSpecices(string loginName, string contactName, int type)
        {
            bool result = false;
            string strWhere="loginName='"+loginName+"' and contactName='"+contactName+"' and groupId='"+type+"'";
            int count = conn.GetCount("innerinfoContactTab", "contactId", strWhere);
            if (count > 0)
            {
                result = true;
            }
            return result;
        }
        #endregion

        #region  防骚扰设置
        //读取设置
        public Tz888.Model.GoodFriend GetFriendSet(string loginName)
        {
            string selectCondition = "loginName='" + loginName + "'";
            Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("InnerInfoContactSetTab", "ManageTypeSet,MemberGradeSet,MemberIntent", "MemberGradeset", 1, 1, 0, 1, selectCondition);
            if ((dt != null) && (dt.Rows.Count != 0))
            {
                model.MemberType = Convert.ToInt32(dt.Rows[0][0]);
                model.MemberGrade = Convert.ToInt32(dt.Rows[0][1]);
                model.MemberIntent = Convert.ToInt32(dt.Rows[0][2]);
                return model;
            }
            else
            {
                model = null;
                return model;
            }
            
        }

        //设置防骚扰
        public void SetFriendSet(Tz888.Model.GoodFriend model)
        {
            bool result = false;
            SqlParameter[] parameters ={
                new SqlParameter("@LoginName",SqlDbType.Char,16),
                new SqlParameter("@ManageTypeSet",SqlDbType.Int),
                new SqlParameter("@MemberGradeSet",SqlDbType.Int),
                new SqlParameter("@MemberIntent",SqlDbType.Int),//
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.MemberType;
            parameters[2].Value = model.MemberGrade;
            parameters[3].Value = model.MemberIntent;
            
            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoContactSetTab_Update", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
        }
        #endregion

        #region --好友需求更新--
        public DataTable ResourceRefresh(Tz888.Model.GoodFriend model)
        {
            
            SqlParameter[] parameters ={
                new SqlParameter("@LoginName",SqlDbType.Char,16),
                new SqlParameter("@ContactName",SqlDbType.VarChar,30),
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.ContactName;

            try
            {
                DataSet ds=DbHelperSQL.RunProcedure("UP_InfoForFriendRefreshVIW", parameters, "resource");
                DataTable dt = ds.Tables["resource"];
                return dt;

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
        }
        #endregion

        #region --好友资料更新--
        public DataTable MemberInfoRefresh(Tz888.Model.GoodFriend model)
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            long i = 0;
            long k = 0;
            long j = 0;
            DataTable dt = new DataTable();
            string  lastLogtime = "";
            string strWhere1 = "loginName = '" + model.LoginName + "'";
            dt = obj.GetList("loginlogTab", "loginlogid", "*", strWhere1, "loginlogid desc", ref i, k, ref j);
            if (dt != null && dt.Rows.Count >0)
            {
                lastLogtime = dt.Rows[1]["loginTime"].ToString();
            }
            else
            {
                return dt;
            }
            strWhere1 = "loginName = '" + model.ContactName + "'and Updated >= '"+lastLogtime+"'";
            dt = obj.GetList("MemberInfoTab_log", "MemberinfologId", "*", strWhere1, "MemberInfologId", ref i, k, ref j);
            return dt;
        }
        #endregion
        #region  --好友公司登记--
        public bool EnterpriseRefresh(Tz888.Model.GoodFriend model)
        {
            bool bl = false;
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            long i = 0;
            long k = 0;
            long j = 0;
            DataTable dt = new DataTable();
            string lastLogtime = "";
            string strWhere1 = "loginName = '" + model.LoginName + "'";
            dt = obj.GetList("loginlogTab", "loginlogid", "*", strWhere1, "loginlogid desc", ref i, k, ref j);
            if (dt != null && dt.Rows.Count > 0)
            {
                lastLogtime = dt.Rows[1]["loginTime"].ToString();
            }
            dt = null;
            if (lastLogtime == "")
            {
                return false;
            }
            strWhere1 = "loginName = '" + model.ContactName + "'and registerDate >= '" + lastLogtime + "'";
            dt = obj.GetList("enterprisetab", "EnterpriseId", "*", strWhere1, "EnterpriseId", ref i, k, ref j);
            if (dt != null && dt.Rows.Count > 0)
            {
                bl = true;
            }
            else
            {
                bl = false;
            }
            return bl;
        }
        #endregion

    }
}
