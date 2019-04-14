using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.Model.Register;
using Tz888.IDAL.Register;

namespace Tz888.SQLServerDAL.Register
{
    public class MemberInfoDAL : IMemberInfo
   {
       Tz888.SQLServerDAL.Conn obj = new Conn();
       #region MemberInfoTab表  根据条件得到一个对象实体
       /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public Tz888.Model.Register.MemberInfoModel GetModel(string strCriteria)
        {

            DataTable dt = obj.GetList("MemberInfoTab","*","LoginName",1,1,0,1,strCriteria);
            Tz888.Model.Register.MemberInfoModel model = new MemberInfoModel();
            if (dt.Rows.Count > 0)
            {              
                model.LoginName = dt.Rows[0]["LoginName"].ToString();
                model.MemberName = dt.Rows[0]["MemberName"].ToString();
                if (dt.Rows[0]["Sex"].ToString() != "")
                {
                    if ((dt.Rows[0]["Sex"].ToString() == "1") || (dt.Rows[0]["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                 
                model.NickName = dt.Rows[0]["NickName"].ToString();
                if (dt.Rows[0]["Birthday"].ToString() != "")
                {

                    model.Birthday = DateTime.Parse(dt.Rows[0]["Birthday"].ToString());
                }
                model.CityID = dt.Rows[0]["CityID"].ToString();
                model.CertificateID = dt.Rows[0]["CertificateID"].ToString();
                model.CertificateNumber = dt.Rows[0]["CertificateNumber"].ToString();
                model.CountryCode = dt.Rows[0]["CountryCode"].ToString();
                model.ProvinceID = dt.Rows[0]["ProvinceID"].ToString();
                model.CountyID = dt.Rows[0]["CountyID"].ToString();
                model.Address = dt.Rows[0]["Address"].ToString();
                model.PostCode = dt.Rows[0]["PostCode"].ToString();
                model.Tel = dt.Rows[0]["Tel"].ToString();
                model.Mobile = dt.Rows[0]["Mobile"].ToString();
                model.FAX = dt.Rows[0]["FAX"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                if (dt.Rows[0]["IsSecurity"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsSecurity"].ToString() == "1") || (dt.Rows[0]["IsSecurity"].ToString().ToLower() == "true"))
                    {
                        model.IsSecurity = true;
                    }
                    else
                    {
                        model.IsSecurity = false;
                    }
                }

                model.ManageTypeID = dt.Rows[0]["ManageTypeID"].ToString();
                model.RequirInfo = dt.Rows[0]["RequirInfo"].ToString();
                model.RequirInfoDesc = dt.Rows[0]["RequirInfoDesc"].ToString();
                model.HeadPortrait = dt.Rows[0]["HeadPortrait"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
      #endregion

        #region LogoInfoTab表  根据条件得到一个对象实体
        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
       public Tz888.Model.LoginInfo GetLoginInfoModel(string strCriteria)
        {

            DataTable dt = obj.GetList("LoginInfoTab", "*", "LoginName", 1, 1, 0, 1, strCriteria);
            Tz888.Model.LoginInfo model = new Tz888.Model.LoginInfo();           
            if (dt.Rows.Count > 0)
            {
                model.LoginName = dt.Rows[0]["LoginName"].ToString();
                model.RoleName = dt.Rows[0]["RoleName"].ToString();
                model.NickName = dt.Rows[0]["NickName"].ToString();
                model.Tel = dt.Rows[0]["Tel"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.RequirInfo = dt.Rows[0]["RequirInfo"].ToString();
                if (dt.Rows[0]["IsCheckUp"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsCheckUp"].ToString() == "1") || (dt.Rows[0]["IsCheckUp"].ToString().ToLower() == "true"))
                    {
                        model.IsCheckUp = true;
                    }
                    else
                    {
                        model.IsCheckUp = false;
                    }
                }

                model.ManageTypeID = dt.Rows[0]["ManageTypeID"].ToString();
                model.MemberGradeID = dt.Rows[0]["MemberGradeID"].ToString();
                if (dt.Rows[0]["Enable"].ToString() != "")
                {
                    if ((dt.Rows[0]["Enable"].ToString() == "1") || (dt.Rows[0]["Enable"].ToString().ToLower() == "true"))
                    {
                        model.Enable = true;
                    }
                    else
                    {
                        model.Enable = false;
                    }
                }

                if (dt.Rows[0]["RegisterTime"].ToString() != "")
                {

                    model.RegisterTime = DateTime.Parse(dt.Rows[0]["RegisterTime"].ToString());
                }
                model.RealName = dt.Rows[0]["RealName"].ToString();
                if (dt.Rows[0]["IsSingleLevel"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsSingleLevel"].ToString() == "1") || (dt.Rows[0]["IsSingleLevel"].ToString().ToLower() == "true"))
                    {
                        model.IsSingleLevel = true;
                    }
                    else
                    {
                        model.IsSingleLevel = false;
                    }
                }

                if (dt.Rows[0]["CreatePlanMemberStatus"].ToString() != "")
                {
                    model.CreatePlanMemberStatus = int.Parse(dt.Rows[0]["CreatePlanMemberStatus"].ToString());
                }
                if (dt.Rows[0]["IsAlliance"].ToString() != "")
                {
                    model.IsAlliance = int.Parse(dt.Rows[0]["IsAlliance"].ToString());
                }
                if (dt.Rows[0]["IsEmailNotify"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsEmailNotify"].ToString() == "1") || (dt.Rows[0]["IsEmailNotify"].ToString().ToLower() == "true"))
                    {
                        model.IsEmailNotify = true;
                    }
                    else
                    {
                        model.IsEmailNotify = false;
                    }
                }

                model.MemberGradeParamID = dt.Rows[0]["MemberGradeParamID"].ToString();
                if (dt.Rows[0]["SetMealID"].ToString() != "")
                {
                    model.SetMealID = int.Parse(dt.Rows[0]["SetMealID"].ToString());
                }
                if (dt.Rows[0]["IsRefresh"].ToString() != "")
                {
                    model.IsRefresh = int.Parse(dt.Rows[0]["IsRefresh"].ToString());
                }
                if (dt.Rows[0]["VipInvalidDate"].ToString() != "")
                {

                    model.VipInvalidDate = DateTime.Parse(dt.Rows[0]["VipInvalidDate"].ToString());
                }
                if (dt.Rows[0]["TryStatus"].ToString() != "")
                {
                    model.TryStatus = int.Parse(dt.Rows[0]["TryStatus"].ToString());
                }
            //    model.HeadPortrait = dt.Rows[0]["HeadPortrait"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

   		#region-- 根据NickName查找LoginName  ---------------
		public string getLoginName(string NickName)
		{
            DataTable dt = obj.GetList("logininfotab", "*", "LoginName", 1, 1, 0, 1, "NickName='" + NickName + "'");
			if(dt.Rows.Count<=0)
			{
				return "";
			}
			else
			{
                string LoginName = dt.Rows[0]["LoginName"].ToString();
				return LoginName;		
			}
		}
		#endregion

        #region--  根据LoginName查找NickName  ---------------
		public string getNickName(string LoginName)
		{
            DataTable dt = obj.GetList("logininfotab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
			if(dt.Rows.Count<=0)
			{
				return "";
			}
			else
			{
                string NickName = dt.Rows[0]["NickName"].ToString();
                return NickName;
			}
		}
		#endregion

        #region ---根据LoginName 查找 Email
        public string GetEmailByLoginName(string loginName)
        {
            DataTable dt = obj.GetList("logininfotab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + loginName + "'");
            if (dt.Rows.Count <= 0)
            {
                return "";
            }
            else
            {
                string NickName = dt.Rows[0]["Email"].ToString();
                return NickName;
            }
        }
        #endregion
        #region --检查EMAIL是否可注册－－－－－
        /// <summary>
        /// -检查EMAIL是否可注册
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>0 可注册　１不可注册</returns>
        public int ValidEmail(string email)
        {
            DataTable dt = obj.GetList("logininfotab", "*", "LoginName", 1, 1, 0, 1, "email='" + email + "'");
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        #endregion

        /// <summary>
        ///   //增加会员积分
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="integral">积分值</param>
        public void AddIntegral(string loginName, int integral)
        {
            DbHelperSQL.ExecuteSql("update createcardtab set IntegralCount = IntegralCount+"+ integral.ToString()
                + " where loginName = '"+ loginName +"'");
        }

        //会员信息表添加
        public int MemberMessage_Insert(Tz888.Model.Register.MemberInfoModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@MemberName", SqlDbType.VarChar,12),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@CertificateID", SqlDbType.Char,10),
					new SqlParameter("@CertificateNumber", SqlDbType.VarChar,20),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.Char,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@FAX", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@IsSecurity", SqlDbType.Bit,1),
					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
					new SqlParameter("@RequirInfo", SqlDbType.Char,50),
					new SqlParameter("@RequirInfoDesc", SqlDbType.VarChar,255),
					new SqlParameter("@HeadPortrait", SqlDbType.VarChar,100),

					new SqlParameter("@ContactName", SqlDbType.VarChar,100),
					new SqlParameter("@ContactTitle", SqlDbType.VarChar,100)
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.MemberName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.NickName;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.CertificateID;
            parameters[7].Value = model.CertificateNumber;
            parameters[8].Value = model.CountryCode;
            parameters[9].Value = model.ProvinceID;
            parameters[10].Value = model.CityID;
            parameters[11].Value = model.CountyID;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.PostCode;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.Mobile;
            parameters[16].Value = model.FAX;
            parameters[17].Value = model.Email;
            parameters[18].Value = model.IsSecurity;
            parameters[19].Value = model.ManageTypeID;
            parameters[20].Value = model.RequirInfo;
            parameters[21].Value = model.RequirInfoDesc;
            parameters[22].Value = model.HeadPortrait;

            parameters[23].Value = model.ContactName;
            parameters[24].Value = model.ContactTitle;

            DbHelperSQL.RunProcedure("MemberInfoTab_Insert", parameters, out rowsAffected);
            return 1;// (int)parameters[0].Value;
        }

        //会员信息修改
        public int MemberMessage_Update(Tz888.Model.Register.MemberInfoModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@MemberName", SqlDbType.VarChar,12),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Birthday", SqlDbType.DateTime),
					new SqlParameter("@CertificateID", SqlDbType.Char,10),
					new SqlParameter("@CertificateNumber", SqlDbType.VarChar,20),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@PostCode", SqlDbType.Char,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@FAX", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@IsSecurity", SqlDbType.Bit,1),
					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
					new SqlParameter("@RequirInfo", SqlDbType.Char,50),
					new SqlParameter("@RequirInfoDesc", SqlDbType.VarChar,255),
					new SqlParameter("@HeadPortrait", SqlDbType.VarChar,100),

					new SqlParameter("@ContactName", SqlDbType.VarChar,100),
					new SqlParameter("@ContactTitle", SqlDbType.VarChar,100)
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.MemberName;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.NickName;
            parameters[5].Value = model.Birthday;
            parameters[6].Value = model.CertificateID;
            parameters[7].Value = model.CertificateNumber;
            parameters[8].Value = model.CountryCode;
            parameters[9].Value = model.ProvinceID;
            parameters[10].Value = model.CityID;
            parameters[11].Value = model.CountyID;
            parameters[12].Value = model.Address;
            parameters[13].Value = model.PostCode;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.Mobile;
            parameters[16].Value = model.FAX;
            parameters[17].Value = model.Email;
            parameters[18].Value = model.IsSecurity;
            parameters[19].Value = model.ManageTypeID;
            parameters[20].Value = model.RequirInfo;
            parameters[21].Value = model.RequirInfoDesc;
            parameters[22].Value = model.HeadPortrait;

            parameters[23].Value = model.ContactName;
            parameters[24].Value = model.ContactTitle;


            DbHelperSQL.RunProcedure("MemberInfoTab_Update", parameters, out rowsAffected);
            return 1;// (int)parameters[0].Value;
        }

        #region//检查注册会员名是否可用
        public int ValideNameUseable(string name)
        {
            SqlParameter[] parameters = {
                                   new SqlParameter("@seccess",SqlDbType.Int,4),
                                   new SqlParameter("@name",SqlDbType.VarChar,16)
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = name;

            DbHelperSQL.RunProcedure("LoginInfoTabValideName", parameters);
            return((int)parameters[0].Value);
        }
        #endregion

        //检查注册会员名是否可用
        public int ValideNikeName(string name)
        {
            SqlParameter[] parameters = {
                                   new SqlParameter("@seccess",SqlDbType.Int,4),
                                   new SqlParameter("@name",SqlDbType.VarChar,14)
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = name;

            DbHelperSQL.RunProcedure("LoginInfoTabValideNickName", parameters);
            return ((int)parameters[0].Value);
        }


        #region 获取会员Email
        public string GetEmail(string LoginName)
        {
            string SqlText = "Select Email from LoginInfoTab where LoginName = '" + LoginName + "'";

            object reObj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText, null);

            if (reObj != null)
                return Convert.ToString(reObj).Trim();
            else
                return "";
        }
        #endregion

        #region 通过电子邮件取回登录名
        public string GetLoginNameByEmail(string strEmail)
        {
 
            string strSql = "select LoginName from LoginInfoTab where Email='" + strEmail + "'";

            object reObj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);

            if (reObj != null)
                return Convert.ToString(reObj).Trim();
            else
                return "";

        }
        #endregion

        #region 通过电子邮件取回登录名
        public string GetPassWordByEmail(string LoginName,string strEmail)
        { 
            string strSql = "select PassWord from LoginInfoTab where LoginName='" + LoginName + "' and  Email='" + strEmail + "'";

            object reObj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);

            if (reObj != null)
                return Convert.ToString(reObj).Trim();
            else
                return "";

        }
        #endregion

        #region 获取会员注册问题
        public string GetQuestionByEmail(string LoginName)
        { 
            string strSql = "select PasswordQuestion from LoginInfoTab where LoginName='" + LoginName + "'";

            object reObj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);

            if (reObj != null)
                return Convert.ToString(reObj).Trim();
            else
                return "";

        }
        #endregion

        #region 获取会员注册答案
        public string GetAnswerByEmail(string LoginName)
        {
 
            string strSql = "select PasswordAnswer from LoginInfoTab where LoginName='" + LoginName + "'";

            object reObj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);

            if (reObj != null)
                return Convert.ToString(reObj).Trim();
            else
                return "";

        }
        #endregion

        #region 获取会员注册手机
        public string GetMobileByName(string LoginName)
        {

            string strSql = "select Tel from LoginInfoTab where LoginName='" + LoginName + "'";

            object reObj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, strSql, null);

            if (reObj != null)
                return Convert.ToString(reObj).Trim();
            else
                return "";

        }
        #endregion

        #region 产生随机数 用来生成密码
        public string RndNum(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9";

            string[] VcArray = Vchar.Split(new Char[] { ',' });
            string VNum = "";
            int temp = -1;

            Random rand = new Random();

            for (int i = 1; i < VcodeNum + 1; i++)
            {


                int valNum = rand.Next(10);
                if (temp != -1 && temp == valNum)
                {
                    return RndNum(VcodeNum);
                }
                temp = valNum;
                VNum += VcArray[valNum];
            }
            return VNum;
        }
        #endregion

        #region 检查充值卡卡号是否正确

        /// <summary>
        /// 检查充值卡卡号是否正确
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int RechargeCard(string card)
        {
            SqlParameter[] parameters = {
                                   new SqlParameter("@seccess",SqlDbType.Int,4),
                                   new SqlParameter("@card",SqlDbType.VarChar,20)
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = card;

            DbHelperSQL.RunProcedure("RechargeCardProc", parameters);
            return ((int)parameters[0].Value);
        }

        #endregion
        #region IMemberInfo 成员

        /// <summary>
        /// 判断充值卡密码是否正确
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public int CardPassWord(string passWord, string Card)
        {
            SqlParameter[] parameters = {
                                   new SqlParameter("@seccess",SqlDbType.Int,4),
                                   new SqlParameter("@passWord",SqlDbType.VarChar,16),
                                   new SqlParameter("@Card",SqlDbType.VarChar,20)
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Card;
            parameters[2].Value = passWord;

            DbHelperSQL.RunProcedure("CarPassword", parameters);
            return ((int)parameters[0].Value);
        }

            #endregion
        #region IMemberInfo 成员


        public string CarMoney(string Number)
        {
            SqlParameter[] parameters = {
                                   new SqlParameter("@seccess",SqlDbType.VarChar,20),
                                   new SqlParameter("@Number",SqlDbType.VarChar,20)
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Number;

            DbHelperSQL.RunProcedure("CardMoneyProc", parameters);
            return Convert.ToString(parameters[0].Value);
        }

            #endregion

        #region 检查充值卡号是否被充值

        /// <summary>
        /// 检查充值卡号是否被充值
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int RechargeStateCard(string card)
        {
            SqlParameter[] parameters = {
                                   new SqlParameter("@seccess",SqlDbType.Int,4),
                                   new SqlParameter("@card",SqlDbType.VarChar,20)
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = card;

            DbHelperSQL.RunProcedure("RechargeCardStateProc", parameters);
            return ((int)parameters[0].Value);
        }

        #endregion
    }
}
