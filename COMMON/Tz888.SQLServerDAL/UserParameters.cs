using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class UserParameters : IUserParameters
    {
       /// <summary>
       /// 接收手机和邮件
       /// </summary>
       /// <param name="LoginName"></param>
       /// <param name="NoticeEmail"></param>
       /// <param name="NoticeMobile"></param>
       /// <returns></returns>
        public bool NoticeSet(string LoginName, string NoticeEmail, string NoticeMobile)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@LoginName", SqlDbType.Char,10),
					new SqlParameter("@NoticeEmail", SqlDbType.VarChar,20),
					new SqlParameter("@NoticeMobile", SqlDbType.VarChar,24)};
            parameters[0].Value = "NoticeSet";
            parameters[1].Value = LoginName;
            parameters[2].Value = NoticeEmail;
            parameters[3].Value = NoticeMobile;
           bool b= DbHelperSQL.RunProcLob("UserParameters", parameters);
           return b;
        }
        public bool MachSet(Tz888.Model.UserParameters model)
        {
             bool b = false;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,40),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@NoticeEmail", SqlDbType.VarChar,50),
					new SqlParameter("@NoticeMobile", SqlDbType.VarChar,24),
					
					new SqlParameter("@InfoMatchingNotice", SqlDbType.Char,10),
					};
            parameters[0].Value = "SetMach";
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.NoticeEmail;
            parameters[3].Value = model.NoticeMobile;
            parameters[4].Value = model.InfoMatchingNotice;

            b = DbHelperSQL.RunProcLob("UserParameters", parameters);
            return b;
        }
        public bool NoticeTypeSet(Tz888.Model.UserParameters model)
        {
            bool b = false;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,40),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@NoticeEmail", SqlDbType.VarChar,50),
					new SqlParameter("@NoticeMobile", SqlDbType.VarChar,24),
					new SqlParameter("@InfoCheckNotice", SqlDbType.Char,10),
					new SqlParameter("@SubscribeNotice", SqlDbType.Char,10),
					new SqlParameter("@InfoExpiredNotice", SqlDbType.Char,10),
					new SqlParameter("@VipExpiredNotice", SqlDbType.Char,10),
					new SqlParameter("@FriendAddNotice", SqlDbType.Char,10),
					new SqlParameter("@InfoCommentNotice", SqlDbType.Char,10),
					new SqlParameter("@InfoMatchingNotice", SqlDbType.Char,10),
					new SqlParameter("@PayNotice", SqlDbType.Char,10),
					new SqlParameter("@StrikeNotice", SqlDbType.Char,10),
                    new SqlParameter("@RebackNotice", SqlDbType.Char,10)};
            parameters[0].Value = "NoticeTypeSet";
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.NoticeEmail;
            parameters[3].Value = model.NoticeMobile;
            parameters[4].Value = model.InfoCheckNotice;
            parameters[5].Value = model.SubscribeNotice;
            parameters[6].Value = model.InfoExpiredNotice;
            parameters[7].Value = model.VipExpiredNotice;
            parameters[8].Value = model.FriendAddNotice;
            parameters[9].Value = model.InfoCommentNotice;
            parameters[10].Value = model.InfoMatchingNotice;
            parameters[11].Value = model.PayNotice;
            parameters[12].Value = model.StrikeNotice;
            parameters[13].Value = model.RebackNotice;
          

            b = DbHelperSQL.RunProcLob("UserParameters", parameters);
            return b;
        }
    }
}
