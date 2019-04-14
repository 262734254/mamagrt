using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Register
{
    public class common : Tz888.IDAL.Register.common  
    {
        #region �Ǽ���Ӷ���ϵ��     
        /// <summary>
        /// �����Ϣ��ϵ��(ʹ���������)
        /// </summary>
        public bool InsertContactMan(SqlConnection sqlConn, SqlTransaction sqlTran, Tz888.Model.Register.OrgContactMan model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@Name", SqlDbType.VarChar,20),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
                   
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Mobile;
            parameters[3].Value = model.Remark;

            //��ѯ����LoginName�Ƿ񼺴��ڲ����           
           
            int rv= this.Delete(model.LoginName);

            DbHelperSQL.RunProcedure("UP_OrgContactManTab_ADD", parameters, out rowsAffected);       
           // if (rowsAffected > 0)
                return true;
            //return false;
        }
        #endregion

        /// <summary>
        /// ɾ����ϵ��
        /// </summary>
        /// <returns>0������LoginName����ϵ�ˣ�1���ڲ�ɾ���ɹ�</returns>
        public int Delete(string  LoginName)
        {
           return DbHelperSQL.ExecuteSql("DELETE OrganizationContactManTab  WHERE LoginName ='"+LoginName+"'");//("UP_OrganizationContactManTab_Delete", parameters, out rowsAffected);    
        }

        //�����ϵ��
        public void AddOrgContect(OrgContactModel orgModel)
        { 
            SqlParameter[] parameters = {
                new SqlParameter("@loginName",SqlDbType.Char,16),
                new SqlParameter("@organizationName",SqlDbType.VarChar,100),
                new SqlParameter("@name",SqlDbType.VarChar,20),
                new SqlParameter("@telCountry",SqlDbType.Char,6),
                new SqlParameter("@telZone",SqlDbType.Char,8),
                new SqlParameter("@tel",SqlDbType.VarChar,100),
                new SqlParameter("@email",SqlDbType.VarChar,50),
                new SqlParameter("@mobile",SqlDbType.VarChar,30),
                new SqlParameter("@isdel",SqlDbType.Bit),
                new SqlParameter("@PostCode",SqlDbType.VarChar,20),
                new SqlParameter("@address",SqlDbType.VarChar,100)

            };

            parameters[0].Value = orgModel.LoginName;
            parameters[1].Value = orgModel.OrganizationName;
            parameters[2].Value = orgModel.Name;
            parameters[3].Value = orgModel.TelCountryCode;
            parameters[4].Value = orgModel.TelStateCode;
            parameters[5].Value = orgModel.TelNum;
            parameters[6].Value = orgModel.Email;
            parameters[7].Value = orgModel.Mobile;
            parameters[8].Value = orgModel.IsDel;
            parameters[9].Value = orgModel.PostCode;
            parameters[10].Value = orgModel.address;

            try
            {

                DbHelperSQL.RunProcedure("OrgContectTab_Add", parameters);
            }
            catch (SqlException exp)
            {
                throw new Exception(exp.Message);
            }
        }
            

        /// <summary>
        /// ��ȡ����ϵ��
        /// </summary>
        /// <returns>��ϵ���б�</returns>
        public List<Tz888.Model.Register.OrgContactMan> GetOrgContactMan(string LoginName)
        {
            List<OrgContactMan> lists = new List<OrgContactMan>();
            SqlParameter[] parameters = {     new SqlParameter("@LoginName",SqlDbType.Char,16),				//--��¼��
										};
            parameters[0].Value = LoginName;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "UP_OrganizationContactManTab_GetList", parameters))
            {
                while (rdr.Read())
                {
                    try
                    {
                        OrgContactMan item = new OrgContactMan(rdr.GetString(0).Trim(), rdr.GetString(1).Trim());
                        lists.Add(item);
                    }
                    catch
                    {                       
                        lists = null;

                    }                   
                }
            }
        
            return lists;
            //else //Ĭ����ϵ��
            //{
            //    Tz888.Model.Register.OrgContactModel model= new OrgContactModel();
            //    model = this.getContactModel(LoginName);
            //    if (model != null)
            //    {
            //        OrgContactMan item = new OrgContactMan(model.Name, model.Mobile);
            //        lists.Add(item);
            //    }
            //    else
            //    {
            //        lists = null;
            //    }
            //    return lists;
            //}
        }

       #region ��˾�Ǽ�ͼƬ
        public List<Tz888.Model.MemberResourceModel> GetMemberResourceModel(string LoginName, int ResourceProperty)
        {
            List<Tz888.Model.MemberResourceModel> lists = new List<Tz888.Model.MemberResourceModel>();
            SqlParameter[] parameters = {     new SqlParameter("@LoginName",SqlDbType.Char,16),		
                                         new SqlParameter("@ResourceProperty",SqlDbType.Int ,16)//--��¼��
										};
            parameters[0].Value = LoginName;
            parameters[1].Value = ResourceProperty;
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "UP_MemberResourceTab_GetList", parameters))
            {
                while (rdr.Read())
                {
                    Tz888.Model.MemberResourceModel item = new Tz888.Model.MemberResourceModel(rdr.GetString(0).Trim(), rdr.GetString(1).Trim());
                    lists.Add(item);
                }
            }
                return lists;                  
        }
        #endregion
        /// <summary>
        /// ��ȡ��ϵ����ϸ��Ϣ�����ע����Ϣ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>

        public Tz888.Model.Register.OrgContactModel getContactModel(string LoginName)
        {
            Tz888.SQLServerDAL.Conn con = new Conn();
            Tz888.Model.Register.OrgContactModel model = new OrgContactModel();
           
           DataTable dt = con.GetList("OrgContactTab", "*", "ContactID", 100, 1, 0, 1, "LoginName like '" + LoginName+"%'");
           
            if (dt.Rows.Count > 0)
            { 
               // model.ContactID = ContactID;
                model.LoginName = dt.Rows[0]["LoginName"].ToString();
                model.OrganizationName = dt.Rows[0]["OrganizationName"].ToString();
                model.Name = dt.Rows[0]["Name"].ToString();
                model.Career = dt.Rows[0]["Career"].ToString();
                model.TelCountryCode = dt.Rows[0]["TelCountryCode"].ToString();
                model.TelStateCode = dt.Rows[0]["TelStateCode"].ToString();
                model.TelNum = dt.Rows[0]["TelNum"].ToString();
                 
                //ȡ��ע�͵�ԭ��
                model.FaxCountryCode = dt.Rows[0]["FaxCountryCode"].ToString();
                model.FaxStateCode = dt.Rows[0]["FaxStateCode"].ToString();
                model.FaxNum = dt.Rows[0]["FaxNum"].ToString();
                model.PostCode = dt.Rows[0]["PostCode"].ToString();
                model.Website = dt.Rows[0]["Website"].ToString();
                 //������
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Mobile = dt.Rows[0]["Mobile"].ToString();
                model.address = dt.Rows[0]["address"].ToString();
               
                //���� �¼� ְλ
                model.Position = dt.Rows[0]["Position"].ToString();

                if (dt.Rows[0]["IsDel"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsDel"].ToString() == "1") || (dt.Rows[0]["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }

                model.remark = dt.Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        //��Ա��Ϣ�޸�ʱ ��ӵǼ�Ĭ����ϵ��
        public long OrgContactMan_FromMemberMessage(Tz888.Model.Register.OrgContactModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ContactID", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@OrganizationName", SqlDbType.VarChar,100),
					new SqlParameter("@Name", SqlDbType.VarChar,20),
					new SqlParameter("@Career", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,6),
					new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					new SqlParameter("@TelNum", SqlDbType.VarChar,100),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,6),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,8),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,100),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@Website", SqlDbType.VarChar,200),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.OrganizationName;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.Career;
            parameters[5].Value = model.TelCountryCode;
            parameters[6].Value = model.TelStateCode;
            parameters[7].Value = model.TelNum;
            parameters[8].Value = model.FaxCountryCode;
            parameters[9].Value = model.FaxStateCode;
            parameters[10].Value = model.FaxNum;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.Mobile;
            parameters[13].Value = model.address;
            parameters[14].Value = model.PostCode;
            parameters[15].Value = model.Website;
            parameters[16].Value = model.IsDel;
            parameters[17].Value = model.remark;

            DbHelperSQL.RunProcedure("UP_OrgContactTab_FormMemberMessage", parameters, out rowsAffected);
            return 1;// (long)parameters[0].Value;
        }

        #region �Ǽ���Ϣ���
        public int AuditOrg(Tz888.Model.Register.OrgAuditModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@OrgAudID", SqlDbType.BigInt,8),
					new SqlParameter("@OrgName", SqlDbType.VarChar,200),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),
					new SqlParameter("@AuditingBy", SqlDbType.VarChar,20),
					new SqlParameter("@AuditingDate", SqlDbType.DateTime),
					new SqlParameter("@FeedbackStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@FeedBackNote", SqlDbType.VarChar,300),
					new SqlParameter("@OrgType", SqlDbType.TinyInt,1),
					new SqlParameter("@Memo", SqlDbType.VarChar,200)};
            parameters[0].Value = model.OrgAudID;
            parameters[1].Value = model.OrgName;
            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.AuditingRemark;
            parameters[4].Value = model.AuditingBy;
            parameters[5].Value = model.AuditingDate;
            parameters[6].Value = model.FeedbackStatus;
            parameters[7].Value = model.FeedBackNote;
            parameters[8].Value = model.OrgType;
            parameters[9].Value = model.Memo;

            DbHelperSQL.RunProcedure("UP_OrgAuditTab_Audit", parameters, out rowsAffected);
            return rowsAffected;
        }
        #endregion

        #region  ����չ������ 
        //���
        public int AddSelfCreateWebInfo(string loginName,string domain)
        {
            SqlParameter[] parameters = {              
					new SqlParameter("@WebID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@Config", SqlDbType.VarChar,4000),
					new SqlParameter("@ClickCount", SqlDbType.Int),
					new SqlParameter("@Domain", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime)              
            
            };
            parameters[0].Value = null;
            parameters[1].Value = loginName;
            parameters[2].Value = null;
            parameters[3].Value = null;
            parameters[4].Value = domain;
            parameters[5].Value = null;
            parameters[6].Value = null;

            int rowsAffected;
            int WebID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection2())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //������Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "sp_AddSelfCreateWebInfo", parameters, out rowsAffected);
                    WebID = (int)parameters[0].Value;
                    if (WebID <= 0)
                        throw new Exception();
                    sqlTran.Commit();
                }
                catch
                {
                    sqlTran.Rollback();
                    WebID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

            return WebID;
        }
        //�޸�
        public int UpdateSelfCreateWebInfo(int webId,string loginName, string domain)
        {
            SqlParameter[] parameters = {     
					new SqlParameter("@WebID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@Config", SqlDbType.VarChar,4000),
					new SqlParameter("@ClickCount", SqlDbType.Int),
					new SqlParameter("@Domain", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime)              
            
            };
            parameters[0].Value = webId;
            parameters[1].Value = loginName;
            parameters[2].Value = null;
            parameters[3].Value = null;
            parameters[4].Value = domain;
            parameters[5].Value = null;
            parameters[6].Value = null;

            int rowsAffected;
            int WebID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection2())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //������Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "sp_UpdateSelfCreateWebInfo", parameters, out rowsAffected);
                    WebID = (int)parameters[0].Value;
                    if (WebID <= 0)
                        throw new Exception();
                    sqlTran.Commit();
                }
                catch
                {
                    sqlTran.Rollback();
                    WebID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

            return WebID;
        }

        //��ѯչ�������Ƿ�ʹ��      
        public int CheckDomain(string domain,string loginName)
        {
            Tz888.SQLServerDAL.Conn obj = new Conn();
            DataTable dt = obj.GetWebSiteList("SelfCreateWebInfo", "*", "Domain", 1, 1, 0, 1, "Domain='" + domain + "' AND LoginName!='"+loginName+"'");
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else 
            {
                return 0;
            }            

            //int rowsAffected;
            //SqlParameter[] parameters = {
            //        new SqlParameter("@Domain", SqlDbType.VarChar,50)
            //    };
            //parameters[0].Value = domain;//t(string tblName, string fldName, string strWhere)
            //int result = DbHelperSQL.GetWebSiteList("UserInfo_Exists", parameters,);
            //return result;
        }

       
        #endregion

        #region ��ȡ�û���չ������
        /// <summary>
        /// ��ȡ��ҵ��Ա��չ������
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetEnterpriseInfo(string loginName)
        {
            string SqlText = "Select * from EnterpriseTab Where loginName = '" + loginName + "'";
            return DbHelperSQL.Query(SqlText);
        }

        /// <summary>
        /// ��ȡ���̻�Ա��չ������
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public DataSet GetGovernmentInfo(string loginName)
        {
            string SqlText = "Select * from GovernmentTab Where loginName = '" + loginName + "'";
            return DbHelperSQL.Query(SqlText);
        }
        #endregion

        /// <summary>
        /// �ڶ���д��ѯ��ϵ����ϸ��Ϣ
        /// </summary>
        /// <param name="lognName"></param>
        /// <returns></returns>
        public Tz888.Model.Register.MemberInfoModel SelorgContact(string lognName)
        {
            Tz888.Model.Register.MemberInfoModel org = new MemberInfoModel();
            string name = lognName.ToString().Trim();
            string sql = "select Address,NickName,Tel,Mobile,Email from MemberInfoTab where LoginName=@name";
            SqlParameter[] para = { 
               new SqlParameter("@name",SqlDbType.VarChar,200)
            };
            para[0].Value = name;
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sql, para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                org.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                org.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                org.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                org.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                org.Email = ds.Tables[0].Rows[0]["Email"].ToString();
            }
            return org;
        }
    }
}
