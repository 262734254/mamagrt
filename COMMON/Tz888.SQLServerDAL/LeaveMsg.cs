using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model;
using Tz888.IDAL;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class LeaveMsg:ILeaveMsg
    {
        private Tz888.SQLServerDAL.Conn coon;                // ˝æ›ø‚¡¨Ω”∂‘œÛ
        public LeaveMsg()
        {
            coon = new Conn();
        }
        #region   ∂¡»°ªÿ∏¥¡Ù—‘
        public Tz888.Model.LeaveMsg ReadComment(int ID,int type) //0 ∂¡»°¡Ù—‘–≈œ¢  1 ∂¡»°ªÿ∏¥¡Ù—‘
        {
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            string tableName = "";
            string selectCondition = "";
            DataTable dt = new DataTable();
            tableName = "InfoCommentManagerVIW";
            if (type == 0)
            {
                selectCondition = "ID=" + ID.ToString();
            }
            else if(type==1)
            {
                selectCondition = "fatherID=" + ID.ToString();
            }
            dt = coon.GetList(tableName, "CommentTime,CommentContent,IsAudit,IsDelete,IsResponse", "ID", 1, 1, 0, 1, selectCondition);
            if ((dt != null) && (dt.Rows.Count != 0))
            {
                model.CommentTime =(DateTime) dt.Rows[0][0];
                model.CommentContent = dt.Rows[0][1].ToString();
                model.IsAudit = Convert.ToInt32(dt.Rows[0][2]);
                model.IsDelete = Convert.ToInt32(dt.Rows[0][3]);
                model.IsResponse = Convert.ToInt32(dt.Rows[0][4]);
                
            }
            return model;
            //else
            //{
            //    model.IsResponse = false;
            //    return model;
            //}
        }
        #endregion


        #region ‘ˆº”ªÿ∏¥
        public bool SetResponse(Tz888.Model.LeaveMsg model)
        {
            bool result = false;
            SqlParameter[] parameters ={
                new SqlParameter("@infoId",SqlDbType.Int),
                new SqlParameter("@LoginName",SqlDbType.Char,16),
                new SqlParameter("@NickName",SqlDbType.VarChar,12),
                new SqlParameter("@CommentContent",SqlDbType.VarChar,2000),
                new SqlParameter("@CommentTime",SqlDbType.SmallDateTime),
                new SqlParameter("@CommentIP",SqlDbType.VarChar,30),
                new SqlParameter("@IsDelete",SqlDbType.Bit),
                new SqlParameter("@AuditRemark",SqlDbType.VarChar,100),
                new SqlParameter("@AuditMan",SqlDbType.VarChar,16),
                new SqlParameter("@AuditTime",SqlDbType.DateTime),
                new SqlParameter("@SendMailContent",SqlDbType.VarChar,1000),
                new SqlParameter("@IsAudit",SqlDbType.TinyInt),
                new SqlParameter("@EvaluationScore",SqlDbType.Int),
                new SqlParameter("@FatherId",SqlDbType.BigInt),
                new SqlParameter("@IsResponse",SqlDbType.Bit),//
            };
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = "";
            parameters[3].Value = model.CommentContent;
            parameters[4].Value = model.CommentTime;
            parameters[5].Value = "";
            parameters[6].Value = 0;
            parameters[7].Value = "";
            parameters[8].Value = "";
            parameters[9].Value = model.CommentTime;//…Û∫À ±º‰ 
            parameters[10].Value = " ";
            parameters[11].Value = 0;
            parameters[12].Value = 0;
            parameters[13].Value = model.FatherID;
            parameters[14].Value = 0;//
            try
            {
                result = DbHelperSQL.RunProcLob("InfoCommentTabManager_Insert", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region ¡Ù—‘ «∑Òπ´ø™
        public int IsAuditLeaveMsg(string IDStr, int audit) //0 –Èƒ‚…æ≥˝¡Ù—‘  1 ”¿‘∂…æ≥˝¡Ù—‘ 
        {
            int result = 0;

            try
            {
                result = DbHelperSQL.ExecuteSql("update InfoCommentTab set IsAudit=" + audit + " where ID in (" + IDStr + ")");
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region ¡Ù—‘…æ≥˝
        public bool DeleteLeaveMsg(int ID, int flag) //0 –Èƒ‚…æ≥˝¡Ù—‘  1 ”¿‘∂…æ≥˝¡Ù—‘ 
        {
            bool result = false;
            string procName = "";
            SqlParameter[] parameters ={
                new SqlParameter("@Id",SqlDbType.Int),
            };
            parameters[0].Value = ID;
            if (flag == 0)
            {
                procName="InfoCommentTab_Delete";
            }
            else if (flag == 1)
            {
                procName = "InfoCommentTabManagerEntirety_Delete";
            }
            try
            {
                result = DbHelperSQL.RunProcLob(procName, parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region ¡Ù—‘∑¢≤ºπ‹¿Ì
        public bool PublishManageLeaveMsg(Tz888.Model.LeaveMsg model)
        {
            bool result = false;
            SqlParameter[] parameters ={
                new SqlParameter("@Id",SqlDbType.Int),
                new SqlParameter("@IsAudit",SqlDbType.TinyInt),
                new SqlParameter("@AuditMan",SqlDbType.VarChar,16),
                new SqlParameter("@AuditTime",SqlDbType.SmallDateTime),
            };
            parameters[0].Value = model.CommentId;
            parameters[1].Value = model.IsAudit;
            parameters[2].Value = model.AuditMan;
            parameters[3].Value = model.AuditTime;
            try
            {
                result = DbHelperSQL.RunProcLob("InfoCommentTabManager_update", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region  ª÷∏¥÷¡ ’µΩ¡Ù—‘
        public bool RestoreLeaveMsg(int ID)  
        {
            bool result = false;
            SqlParameter[] parameters ={
                new SqlParameter("@Id",SqlDbType.Int),
            };
            parameters[0].Value = ID;
            try
            {
                result = DbHelperSQL.RunProcLob("InfoCommentTabManage_Restore", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region Õ≥º∆¡Ù—‘ ˝ƒø


        public int GetCount(long InfoID)
        {
            string SqlText = "Select count(1) from InfoCommentTab Where IsAudit=1 and fatherId=0 and isdelete=0 And InfoID = " + InfoID.ToString();
            return Convert.ToInt32(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
        }

        #endregion
    }
}
