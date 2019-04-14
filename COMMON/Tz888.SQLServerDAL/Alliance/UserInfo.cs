using System;
using System.Collections.Generic;
using System.Text; 
using System.Data; 
using System.Data.SqlClient;
using System.Security.Cryptography;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class UserInfo:IUserInfo
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Add(Tz888.Model.UserInfo model)
        {

            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(model.Password);
            SqlParameter[] parameters = {
                new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@Password", SqlDbType.VarBinary,50),
					new SqlParameter("@RoleName", SqlDbType.Char,10),
                    new SqlParameter("@IsCheckUp", SqlDbType.Bit,1),
                    new SqlParameter("@MemberGradeID", SqlDbType.Char,10),
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50), 
                    new SqlParameter("@companyname",SqlDbType.VarChar,100),
                    new SqlParameter("@QQMSN",SqlDbType.VarChar,50), 
                    new SqlParameter("@flag",SqlDbType.VarChar,30)
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = bytePassword;
            parameters[2].Value = model.RoleName;
            parameters[3].Value = model.IsCheckUp;
            parameters[4].Value = model.MemberGradeID;
            parameters[5].Value = model.RealName;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.CompanyName;
            parameters[9].Value = model.QQMSN;
            parameters[10].Value = "Insert";


            bool b = DbHelperSQL.RunProcLob("SP_UserInfo", parameters);
            return b;
        }



        /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(Tz888.Model.UserInfo model)
        {

            SqlParameter[] parameters = { 
                    new SqlParameter("@LoginName", SqlDbType.Char,16),    
					new SqlParameter("@RealName", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50), 
                    new SqlParameter("@companyname",SqlDbType.VarChar,100),
                    new SqlParameter("@QQMSN",SqlDbType.VarChar,50),
                    new SqlParameter("@AuditMan",SqlDbType.VarChar,30),
                    new SqlParameter("@AuditTime",SqlDbType.DateTime,8),
                    new SqlParameter("@AuditStatus",SqlDbType.Int,4),
                    new SqlParameter("@flag",SqlDbType.VarChar,30)
					};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.Tel;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.CompanyName;
            parameters[5].Value = model.QQMSN;
            parameters[6].Value = model.AuditMan;
            parameters[7].Value = model.AuditTime;
            parameters[8].Value = model.AuditStatus;
            parameters[9].Value = "Update";
            bool b = DbHelperSQL.RunProcLob("SP_UserInfo", parameters);
            return b;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool UpdatePassWord(string UserName, string PassWord)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(PassWord.ToString().Trim()));
            SqlParameter[] parameters = {
                                        new SqlParameter("@LoginName",SqlDbType.Char,16),
                                        new SqlParameter("@PassWord ",SqlDbType.VarBinary,50),		
				                        new SqlParameter("@flag ",SqlDbType.VarChar,30)						
                                        };
            parameters[0].Value = UserName.Trim();       //登录名
            parameters[1].Value = bytePassword;
            parameters[2].Value = "UpdatePWD";
            bool b = DbHelperSQL.RunProcLob("SP_UserInfo", parameters);
            return b;

        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool ValidatePassWord(string UserName, string PassWord)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(PassWord.ToString().Trim()));

            SqlParameter[] parameters = {
                                        new SqlParameter("@LoginName",SqlDbType.VarChar,16),
                                        new SqlParameter("@PassWord ",SqlDbType.VarBinary,50),		
				                        new SqlParameter("@flag ",SqlDbType.VarChar,30)					
                                        };
            parameters[0].Value = UserName.Trim();       //登录名
            parameters[1].Value = bytePassword;
            parameters[2].Value = "ValidatePWD";
            DataSet ds = DbHelperSQL.RunProcedure("SP_UserInfo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        #region 插入登录日志
        public bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
											new SqlParameter("@RoleName",SqlDbType.Char,10),				//角色（EG："0 会员""1　代理商","2　员工"）
										
											new SqlParameter("@LoginTime",SqlDbType.DateTime),				//登录时间
											
											new SqlParameter("@LoginIP",SqlDbType.VarChar,20)					//登录IP
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = strRoleName;

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = dtLoginTime;

            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = strLoginIP;

            DbHelperSQL.RunProcedure("LoginLogTab_Insert", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        /// <summary>
        /// 用户详细信息
        /// </summary>
        public Tz888.Model.UserInfo GetModel(string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,16),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = UserName;
            parameters[1].Value = "Select";
            Tz888.Model.UserInfo model = new Tz888.Model.UserInfo();

            DataSet ds = DbHelperSQL.RunProcedure("SP_UserInfo", parameters, "ds");
            model.LoginName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.QQMSN = ds.Tables[0].Rows[0]["QQMSN"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["AuditMan"].ToString() != "")
                {
                    model.AuditMan = ds.Tables[0].Rows[0]["AuditMan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AuditTime"].ToString() != "")
                {
                    model.AuditTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AuditStatus"].ToString() != "")
                {
                    model.AuditStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditStatus"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 联盟申请信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetUserTabList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                    )
        {
            DataSet ds = new DataSet();
            TotalCount = 0;
            SqlParameter[] parameters = {	
                                        new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
                                        new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
					                    new SqlParameter("@Sort",SqlDbType.VarChar,255), 
					                    new SqlParameter("@Page",SqlDbType.BigInt),
					                    new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
					                    new SqlParameter("@TotalCount",SqlDbType.BigInt),  
			                };
            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;
            parameters[3].Value =  Page;
            parameters[4].Value =CurrentPageRow;

            parameters[5].Value = TotalCount;
            parameters[5].Direction = ParameterDirection.InputOutput;

            try
            {
                ds = DbHelperSQL.RunProcedure("Sp_UserTabList", parameters, "ds");

                if (ds != null)
                {
                    DataView dv = new DataView();
                    //dv = dt.DefaultView;
                    dv = ds.Tables[0].DefaultView;
                    int count = ds.Tables[0].Rows.Count;
                    if (Page > 0)
                    {
                        TotalCount = Convert.ToInt64(parameters[5].Value);
                    }
                    else
                    {
                        TotalCount = dv.Count;
                        if (TotalCount > 0)
                        {
                            CurrentPageRow = 1;
                        }
                        else
                        {
                            CurrentPageRow = 0;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            return ds;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.Int,4),
                     new SqlParameter("@flag", SqlDbType.VarChar,30),

				};
            parameters[0].Value = UserID;
            parameters[1].Value = "Delete";
            bool b = DbHelperSQL.RunProcLob("SP_UserInfo", parameters);
            return b;
        }

    }

}
