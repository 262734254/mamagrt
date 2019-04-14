using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using Tz888.IDAL.LoginInfo;
using Tz888.DBUtility;
using System.Security.Cryptography;


namespace Tz888.SQLServerDAL.LoginInfo
{
    /// <summary>
    /// 数据访问类LoginInfo 。
    /// </summary>
    public class LoginInfo : ILoginInfo
    {
        private Tz888.SQLServerDAL.Conn coon;                //数据库连接对象
        public LoginInfo()
        {
            coon = new Conn();
        }
        /// <summary>
		/// 登录系统
		/// </summary>
		/// <returns>是否登录成功</returns>
		public bool LoginSys()
		{
			return( true );
		}	

		#region 修改密码
		public bool ChangePassword(string strLoginName,string strNewPassword)
		{
           // ////加密密码
           // SHA1 sha1 = SHA1.Create();
           // byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strNewPassword.ToString().Trim()));


           // DbHelperSQL.ExecuteSql("update loginInfotab set password=" + bytePassword + " where loginname='test'"); //'"+strLoginName+"'");
           //return true;
            int iRcount = 0;
            int rowsAffected = 0;
            //加密密码
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strNewPassword.ToString().Trim()));


            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.Char,16),
                new SqlParameter("@PassWord ",SqlDbType.VarBinary)
													
                                        };
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName.Trim();       //登录名

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = bytePassword;  //密码

            try
            {
                rowsAffected = DbHelperSQL.RunProcedure("LoginInfoTab_ChangePassword", parameters, out iRcount);
               
                    return true;
             
            }
            catch (Exception err)
            {
                throw err;
                return false;
            }              
        }
		#endregion

        #region 通过登录名获取代理商名称

        public DataTable GetMemberNameByLoginName(string strLoginName, string strRoleName)
        {
            
            DataTable dt = new DataTable();

            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@RoleName",SqlDbType.Char,10)
											// new SqlParameter("@VarLoginName",SqlDbType.Char,16)

										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = strRoleName;

            //			parameters[2].Direction =ParameterDirection.Output;


            try
            {               
                dt = DbHelperSQL.RunProcedure("LoginInfoTab_GetMemberName", parameters,"aaaaa").Tables[0];
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
              
            }
            return dt;
        }  


        // 
 
        public DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return (coon.GetList(
                   tblName,
                   strGetFields,
                   fldName,
                   PageSize,
                   PageIndex,
                   doCount,
                   OrderType,
                   strWhere));
        }      
        #endregion


        #region 验证会员登录
        public DataTable AuthMemberLogin(
            string strLoginName,
            long lgCardNo,
            string strPassWord,
            bool IsOnlyCheck)
        {
          
            DataTable dt = null;

            //加密密码
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strPassWord.Trim()));

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@CardID",SqlDbType.BigInt),
											new SqlParameter("@PassWord",SqlDbType.VarBinary),
											new SqlParameter("@IsOnlyCheck",SqlDbType.Bit)			
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;       //登录名

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = lgCardNo;       //登录名

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = bytePassword;  //密码

            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = IsOnlyCheck;

            try
            {
                //DataSet ds = DbHelperSQL.RunProcedure("LoginInfoTab_MAuthenticate", parameters, "ddddddd")
                dt = DbHelperSQL.RunProcedure("LoginInfoTab_MAuthenticate", parameters, "ddddddd").Tables[0];            
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                
            }
            return dt;

        }
        #endregion	





        #region 论坛登陆信息更新
        /// <summary>
        /// 论坛登陆信息更新 kevin 2006-11-24
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="ip">最后登陆IP</param>
        /// <param name="truePassword">新的随机密码</param>
        /// <returns>返回组名,返回空或null为无效</returns>
        public string BBSLoginUpdate(int userId, string ip, string truePassword)
        {
            string groupName;       

            SqlParameter[] parameters = { new SqlParameter("@UserId",SqlDbType.Int),
											new SqlParameter("@tpwd",SqlDbType.VarChar,20),
											new SqlParameter("@GroupName",SqlDbType.VarChar,20),
											new SqlParameter("@ip",SqlDbType.VarChar,30)
																							
			};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = userId;
            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = truePassword;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Input;
            parameters[3].Value = ip;

            try
            {
                int iRowsAffected = 0;
                int iRet = DbHelperSQL.RunProcedure("BBS_LoginUpdate", parameters,out iRowsAffected);
                groupName = parameters[2].Value.ToString().Trim();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                 
            }
            return groupName;
        }
        #endregion 


        #region 检查登录失败次数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="LoginTimeRange"></param>
        /// <param name="AllowErrorTimes"></param>
        /// <returns></returns>
        public int CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes)
        {
        
            DataTable dt = new DataTable();
            int intReturnVal = 0;

            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.Char,16),
										new SqlParameter("@LoginTimeRange",SqlDbType.Int),
										new SqlParameter("@AllowErrorTimes",SqlDbType.Int),
										 new SqlParameter("@ReturnValue",SqlDbType.Int)

										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = LoginTimeRange;

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = AllowErrorTimes;

            parameters[3].Direction = ParameterDirection.Output;


            try
            {
                int iRowsAffected = 0;
                int iRet = DbHelperSQL.RunProcedure("LoginErrorLogTab_Check", parameters,out iRowsAffected);
                intReturnVal = Convert.ToInt32(parameters[3].Value.ToString().Trim());
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                 
            }
            return intReturnVal;

        }
        #endregion



        #region-- 查询登录信息列表
		/// <summary>
		/// 查询登录信息列表
		/// </summary>
		/// <param name="SelectCol">选择列</param>		
		/// <param name="Criteria">查询条件</param>
		/// <param name="OrderBy">排序</param>
		/// <param name="CurrentPage">显示的当前页号</param>
		/// <param name="PageSize">页大小</param>
		/// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
		/// <returns>查询列表</returns>
		public DataTable GetLoginInfoList(
			string SelectCol,
			string Criteria,
			string Sort
			)
		{
			 
			DataTable   dt = new DataTable();

			SqlParameter[] parameters = { new SqlParameter("@SelectStr",SqlDbType.VarChar,200),
											new SqlParameter("@Criteria",SqlDbType.VarChar,200),
											new SqlParameter("@Sort",SqlDbType.VarChar,200)
					
										};

			parameters[0].Direction =ParameterDirection.Input;
			parameters[0].Value = SelectCol;       

			parameters[1].Direction =ParameterDirection.Input;
			parameters[1].Value = Criteria;  

			parameters[2].Direction =ParameterDirection.Input;
			parameters[2].Value = Sort;  
			

			try
			{

                dt = DbHelperSQL.RunProcedure("LoginInfoTab_List", parameters, "ddddddd").Tables[0];
				
			}
			catch(Exception err)
			{
				throw err;
			}
			finally
			{
			 
			}
			return dt;
		}
		#endregion


        #region-- 查询登录信息列表
        /// <summary>
        /// 查询登录信息列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public DataTable GetLoginInfo(
           string LoginName
            )
        {

            DataTable dt = new DataTable();

            SqlParameter[] parameters = { new SqlParameter("@LoginName",SqlDbType.VarChar,200)										 
										};
            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = LoginName;
            try
            {
                dt = DbHelperSQL.RunProcedure("TJ_UserCenter_LOGIN_INFO", parameters, "ddddddd").Tables[0];
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return dt;
        }
        #endregion


        #region 验证员工登录
        public DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            bool IsOnlyCheck)
        {
            //加密密码
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(strPassWord.Trim()));

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char ,16),
											new SqlParameter("@PassWord ",SqlDbType.VarBinary),
											new SqlParameter("@IsOnlyCheck",SqlDbType.Bit)				
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;       //登录名

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = bytePassword;  //密码

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = IsOnlyCheck;

            DataSet ds = DbHelperSQL.RunProcedure("LoginInfoTab_Authenticate",parameters,"ds");

            if(ds!=null && ds.Tables.Count > 0)
                return ds.Tables["ds"];
            return null;
        }
        #endregion

        #region 验证员工登录
        public DataTable LmAuthenticate(
            string strLoginName,
            bool IsOnlyCheck)
        {
          

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char ,16),
											new SqlParameter("@IsOnlyCheck",SqlDbType.Bit)				
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;       //登录名

          

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = IsOnlyCheck;

            DataSet ds = DbHelperSQL.RunProcedure("LMLoginInfoTab_Authenticate", parameters, "ds");

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables["ds"];
            return null;
        }
        #endregion

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

            DbHelperSQL.RunProcedure("LoginLogTab_Insert", parameters,out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        public bool CreateLoginErrorLog(string strLoginName, DateTime dtLoginTime, string strLoginIP, bool blFlag)
		{
            int rowsAffected;
            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
											new SqlParameter("@LoginTime",SqlDbType.DateTime),				//登录时间
											new SqlParameter("@LoginIP",SqlDbType.VarChar,20),					//登录IP
											new SqlParameter("@Flag",SqlDbType.Bit)							//登录IP
										};

         			parameters[0].Direction=ParameterDirection.Input;
			parameters[0].Value=strLoginName;



			parameters[1].Direction=ParameterDirection.Input;
			parameters[1].Value=dtLoginTime;

			parameters[2].Direction=ParameterDirection.Input;
			parameters[2].Value=strLoginIP;

			parameters[3].Direction=ParameterDirection.Input;
			parameters[3].Value= blFlag;

            DbHelperSQL.RunProcedure("LoginErrorLogTab_Insert", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }


        ///--------------------------------------
        ///---20090811 wangwei
        ///--------------------------------------

        #region 会员发布信息的权限验证
        //验证条件：注册后一个小时、必须是没有被锁定的帐户
        public bool yanzheng(string loginName)
        {
            bool flag = false;
            string sqlStr = "select count(LoginName) from LoginInfoTab where LoginName='" + loginName.Trim() + "' "
                + " and (AuditStatus is null or AuditStatus!=3 ) ";    //没有被锁定
               // + " and datediff(n,LoginInfoTab.RegisterTime,getdate())>=30 ";  //注册至少半个小时后才可以
            //string sqlStr1 = "";

            try 
            {
                SqlDataReader dr = DbHelperSQL.ExecuteReader(sqlStr);
                dr.Read();
                if (dr!=null && dr[0].ToString().Trim() == "1")
                {
                    flag = true;
                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw err;
                flag = false;
            }
            return flag;
        }
        #endregion

        #region 是否锁定该用户 //0未审核，1审核通过，2审核未通过，3锁定
        public int LockUser(string loginName, int AuditStatus)
        {
            //int AuditStatus = IsLock ? 2 : 1;
            int rowsAffected = 0;
            string sqlStr = "update LoginInfoTab set AuditStatus=" + AuditStatus.ToString() + " where LoginName='" + loginName.Trim() + "'";

            try
            {
                rowsAffected = DbHelperSQL.ExecuteSql(sqlStr);
            }
            catch (Exception err)
            {
                throw err;
                rowsAffected = 0;
            }
            return rowsAffected;
        }
        #endregion




        #region 验证会员登录
        public DataTable LmAuthMemberLogin(
            string strLoginName,
            long lgCardNo,
            bool IsOnlyCheck)
        {

            DataTable dt = null;

      
            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@CardID",SqlDbType.BigInt),
											new SqlParameter("@IsOnlyCheck",SqlDbType.Bit)			
										};

            parameters[0].Direction = ParameterDirection.Input;
            parameters[0].Value = strLoginName;       //登录名

            parameters[1].Direction = ParameterDirection.Input;
            parameters[1].Value = lgCardNo;       //登录名

            parameters[2].Direction = ParameterDirection.Input;
            parameters[2].Value = IsOnlyCheck;

            try
            {
                //DataSet ds = DbHelperSQL.RunProcedure("LoginInfoTab_MAuthenticate", parameters, "ddddddd")
                dt = DbHelperSQL.RunProcedure("LMLoginInfoTab_MAuthenticate", parameters, "ddddddd").Tables[0];
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return dt;

        }
        #endregion	

   
    }
}
