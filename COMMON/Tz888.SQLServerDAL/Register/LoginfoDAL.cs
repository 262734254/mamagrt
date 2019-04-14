using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Register
{
   public class LoginfoDAL:Tz888.IDAL.Register.LoginInfo
   {
       #region������Աע�ᣭ����������������������������
       public void LogInfoAdd(Tz888.Model.Register.LoginInfoModel model)
        {
            
            SqlParameter[] parameters = {
					
                
                new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@Password", SqlDbType.VarBinary,50),
					new SqlParameter("@RoleName", SqlDbType.Char,10),
                    new SqlParameter("@IsCheckUp", SqlDbType.Bit,1),
                    new SqlParameter("@MemberGradeID", SqlDbType.Char,10),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@RequirInfo", SqlDbType.Char,50),
					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
                    new SqlParameter("@companyname",SqlDbType.VarChar,100),
                    new SqlParameter("@contactname",SqlDbType.VarChar,30),
                    new SqlParameter("@contacttitle",SqlDbType.VarChar,30),
                    new SqlParameter("@propertyid",SqlDbType.TinyInt),
                    new SqlParameter("@autoReg",SqlDbType.Int), 
                    new SqlParameter("@adSiteID",SqlDbType.VarChar,50),
                    new SqlParameter("@Introducer",SqlDbType.Char,16)
			};
            
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.RoleName;
            parameters[3].Value = model.IsCheckUp;
            parameters[4].Value = model.MemberGradeID;
            parameters[5].Value = model.NickName;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.RequirInfo;
            parameters[9].Value = model.ManageTypeID;
            parameters[10].Value = model.CompanyName;
            parameters[11].Value = model.ContactName;
            parameters[12].Value = model.ContactTitle;
            parameters[13].Value = model.PropertyID;
            parameters[14].Value = model.autoReg;
            parameters[15].Value = model.adsiteID;
            parameters[16].Value = model.Introducer;

            try
            {
                DbHelperSQL.RunProcedure("LoginInfoTab_addLoginNews", parameters);
                
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
           // DbHelperSQL.RunProcedure(
        }
       #endregion

       #region ͨ��������֤��Ա
       public void ValidUser(string loginname)
       {
           SqlParameter[] parameters = { new SqlParameter("@loginname",SqlDbType.VarChar,16) };

           parameters[0].Value = loginname;

           try
           {
               DbHelperSQL.RunProcedure("LoginInfoTAb_ValidUsr", parameters);
           }catch(SqlException exp)
           {
               throw new Exception(exp.Message);
           }
       }
        #endregion

       #region  ��ȡ��Ա����
       public string GetManagerType(string loginName)
       {
           SqlParameter[] parameters = { 
               new SqlParameter("@managertype", SqlDbType.VarChar, 16),
               new SqlParameter("@loginname", SqlDbType.VarChar, 16)
           };

           parameters[0].Direction = ParameterDirection.Output;
           parameters[1].Value = loginName;
           try
           {
               DbHelperSQL.RunProcedure("LoginInfoTAb_GetManagerType", parameters);
               return parameters[0].Value.ToString();
           }catch(SqlException exp)
           {
                throw(new Exception(exp.Message));
           }
       }
       #endregion

       #region �����û����䣭����������������������
       public void ChangeEmail(string loginName, string newEmail)
       {
           SqlParameter[] parameters = { 
               new SqlParameter("@loginName", SqlDbType.VarChar, 16),
               new SqlParameter("@email", SqlDbType.VarChar, 50)
           };

           parameters[0].Value = loginName;
           parameters[1].Value = newEmail;
           try
           {
               DbHelperSQL.RunProcedure("LoginInfoTAb_ChangeEmail", parameters);
           }
           catch (SqlException exp)
           {
               throw (new Exception(exp.Message));
           }
       }
       #endregion

       #region ��ȡ��Ա�ȼ�(��ͨ1001���ظ�ͨ1002���ظ�ͨ����1003)
       public string GetMemberGradeID(string loginName)
       {
           SqlParameter[] parameters = {
               new SqlParameter("@MemberGradeID",SqlDbType.VarChar,16),
               new SqlParameter("@LoginName",SqlDbType.VarChar,16),
           };

           parameters[0].Direction = ParameterDirection.Output;
           parameters[1].Value = loginName;
           try
           {
               DbHelperSQL.RunProcedure("LoginInfoTab_GetMemberGradeID", parameters);
               return parameters[0].Value.ToString();
           }
           catch (SqlException exp)
           {
               throw (new Exception(exp.Message));
           }
       }
       #endregion

       #region ��ȡ��Ա����ID(�������̻���2001��Ͷ�ʷ�2002����Ŀ��2003,�н����2004)
       public string GetManageTypeID(string loginName)
       {
           string SqlText = "Select ManageTypeID from LoginInfoTab Where loginName = '" + loginName.Trim() + "'";
           return Convert.ToString(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
       }
       #endregion
       
       #region ��ȡ��Ա����ID(0:��ҵ;1:����;2:���̻���;3:�н����)
       public string GetPropertyID(string loginName)
       {
           string SqlText = "Select PropertyID from LoginInfoTab Where loginName = '" + loginName.Trim() + "'";
           return Convert.ToString(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
       }
       #endregion

       //��ѯʱ����Ƿ��Ѿ�����
       #region 
       public  int CheckLoginName(string name)
       {
           string sql = "select Count(*) from LoginInfoTab where loginName=@loginName";
           int result=0;
           try
           {
               DBHelper dbhelper = new DBHelper();
                result = DbHelperSQL.GetScalar(sql, new SqlParameter("@loginName", name));

           }
           catch (Exception)
           {

               throw;
           }
           return result;
       }
       #endregion
       public int UpdateLoginPropertyID(string str, int par,int ManagerTypeId)
       {
           string sql = "";
           int result = 0;
           if (par < 0)
           {
               sql = "update LoginInfotab set ManageTypeId=@ManageTypeId where loginName=@loginName";
               SqlParameter[] parameters = {
                           new SqlParameter ("@ManageTypeId",ManagerTypeId),
							new SqlParameter("@loginName",str)};
                result = DbHelperSQL.ExecuteCommand(sql, parameters);
           }
           else 
           {
               sql = "update LoginInfotab set PropertyID=@PropertyID,ManageTypeId=@ManageTypeId where loginName=@loginName";
               SqlParameter[] parameters = {
                           new SqlParameter ("@PropertyID",par),
                           new SqlParameter ("@ManageTypeId",ManagerTypeId),
							new SqlParameter("@loginName",str)};
                result = DbHelperSQL.ExecuteCommand(sql, parameters);
           }
          
           
           return result;
       }

       public int UpdateLoginCompanyName(string loginName, string Company,string ConnectName,string ConnectTitle)
       {
           string sql = "";
           int result = 0;
           sql = "update LoginInfotab set CompanyName=@CompanyName,ContactName=@ContactName,ContactTitle=@ContactTitle where loginName=@loginName";
           SqlParameter[] parameters = {
                       new SqlParameter ("@CompanyName",Company),
                       new SqlParameter ("@ContactName",ConnectName),
                        new SqlParameter ("@ContactTitle",ConnectTitle),
						new SqlParameter("@loginName",loginName)};
           result = DbHelperSQL.ExecuteCommand(sql, parameters);
           
           return result;
       }
       #region  ����ע��(���Ӽ�¼������)
       /// <summary>
       /// ���������ע��
       /// </summary>
       /// <param name="ip">������IP</param>
       /// <param name="email">����������</param>
       /// <param name="loginName">�����˵�½��</param>
       /// <returns></returns>
       public bool InviterRegiste(string ip, string email, string loginName)
       {
           bool isSuccess = false;
           SqlParameter[] parameters = {
                           new SqlParameter ("@LoginName",SqlDbType.Char,16),
							new SqlParameter("@RegisterIp",SqlDbType.NVarChar,255),
							new SqlParameter("@RegisterEmail",SqlDbType.NVarChar,255),
							new SqlParameter("@RegisterTime",SqlDbType.DateTime),
							new SqlParameter("@IsSuccess",SqlDbType.Bit)
           };

           parameters[0].Value = loginName;
           parameters[1].Value = ip;
           parameters[2].Value = email;
           parameters[3].Value = DateTime.Now;
           parameters[4].Direction = ParameterDirection.Output;

           try
           {
               DbHelperSQL.RunProcedure("InviteRegister", parameters);
               if (parameters[4].Value.ToString().Trim() == "1")
                   isSuccess = true;
           }
           catch (SqlException exp)
           {
               throw exp;
           }
           return isSuccess;
       }
       #endregion
   }
}
