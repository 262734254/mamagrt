using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.Register;
using Tz888.DBUtility;
using Tz888.Model.Register;
using System.Collections.Generic;
using Tz888.SQLServerDAL.Register;
using Tz888.Model.Common;

namespace Tz888.SQLServerDAL.Register
{
    public class EnterpriseRegister : IEnterpriseRegister
    {
        private Tz888.SQLServerDAL.Conn obj;

        #region  前台公司登记
        public int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                  List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                #region  公司基本信息
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,200),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@ComAboutBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@SetComTypeID", SqlDbType.Char,10),
					new SqlParameter("@Industrylist", SqlDbType.Char,10),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@currency", SqlDbType.Char,10),
					new SqlParameter("@RegCapital", SqlDbType.Float,8),
					new SqlParameter("@MainProduct", SqlDbType.VarChar,30),
					new SqlParameter("@RequirInfo", SqlDbType.Char,30),
					new SqlParameter("@AuditingStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@ExhibitionHall", SqlDbType.VarChar,100),
                    new SqlParameter("@hits", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
                #endregion

                #region 联系方式
				
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
					new SqlParameter("@remark1", SqlDbType.VarChar,100)
                #endregion 
            
            };
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.EnterpriseName;
            parameters[3].Value = model.ComAbout;
            parameters[4].Value = model.ComAboutBrief;
            parameters[5].Value = model.SetComTypeID;
            parameters[6].Value = model.Industrylist;
            parameters[7].Value = model.RegisterDate;
            parameters[8].Value = model.CountryCode;
            parameters[9].Value = model.ProvinceID;
            parameters[10].Value = model.CityID;
            parameters[11].Value = model.CountyID;
            parameters[12].Value = model.currency;
            parameters[13].Value = model.RegCapital;
            parameters[14].Value = model.MainProduct;
            parameters[15].Value = model.RequirInfo;
            parameters[16].Value = model.AuditingStatus;
            parameters[17].Value = model.ExhibitionHall;
            parameters[18].Value = model.hits;
            parameters[19].Value = model.remark;

            parameters[20].Value = model.EnterpriseName; ;//ContactModel.Name;
            parameters[21].Value = ContactModel.Name;//默认联系人
            parameters[22].Value = ContactModel.Career;
            parameters[23].Value = ContactModel.TelCountryCode;
            parameters[24].Value = ContactModel.TelStateCode;
            parameters[25].Value = ContactModel.TelNum;
            parameters[26].Value = ContactModel.FaxCountryCode;
            parameters[27].Value = ContactModel.FaxStateCode;
            parameters[28].Value = ContactModel.FaxNum;
            parameters[29].Value = ContactModel.Email;
            parameters[30].Value = ContactModel.Mobile;
            parameters[31].Value = ContactModel.address;
            parameters[32].Value = ContactModel.PostCode;
            parameters[33].Value = ContactModel.Website;
            parameters[34].Value = ContactModel.IsDel;
            parameters[35].Value = ContactModel.remark;

            int rowsAffected;
            int EnterpriseID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {

                    //插入信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "UP_EnterpriseTab_ADD", parameters, out rowsAffected);
                    EnterpriseID = (int)parameters[0].Value;
                    if (EnterpriseID <= 0)
                        throw new Exception();
                      
                   
                    //添加多个联系人(检查原联系人列表中是否己存在 LoginName = model.LoginName的联系人，
                    //如果己存就，将先删除全部后重新添加,obj2.InsertContactMan代码逻辑中)
                    Tz888.SQLServerDAL.Register.common obj2 = new common ();
                    if (ContactManModels != null)
                    {
                        for (int i = 0; i < ContactManModels.Count; i++)
                        {
                            if (ContactManModels[i].Name != "" && ContactManModels[i].Name != null)
                            {
                                foreach (Tz888.Model.Register.OrgContactMan cm in ContactManModels)
                                {
                                    // model.ContactID = ContactID;
                                    if (!obj2.InsertContactMan(sqlConn, sqlTran, cm))
                                        throw new Exception();
                                }
                            }
                        }
                    }

                    if (infoResourceModels != null)
                    {
                        //图片资源
                        Tz888.SQLServerDAL.MemberResourceDAL obj3 = new MemberResourceDAL();
                        foreach (Tz888.Model.MemberResourceModel modelRes in infoResourceModels)
                        {
                            modelRes.LoginName = model.LoginName;
                            int i = obj3.Add(sqlConn, sqlTran, modelRes);
                        }
                    }
                    sqlTran.Commit();
                }
                catch
                {
                    sqlTran.Rollback();
                    EnterpriseID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

            return EnterpriseID;
        }
        #endregion

        //读取公司登记一信息(预览)
        public DataTable getEnterpriseModel(string LoginName)
        {
            Tz888.SQLServerDAL.Conn obj = new Conn();
            DataTable dt = obj.GetList("EnterpriseView", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName+"'");
            if (dt.Rows.Count>0)
            {
                return dt;
            }
            else
            {
                return null;
            }        
        }

        //修改
        public int EnterpriseUpdate(Tz888.Model.Register.EnterpriseInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
            List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                #region  公司基本信息
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,200),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@ComAboutBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@SetComTypeID", SqlDbType.Char,10),
					new SqlParameter("@Industrylist", SqlDbType.Char,10),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@currency", SqlDbType.Char,10),
					new SqlParameter("@RegCapital", SqlDbType.Float,8),
					new SqlParameter("@MainProduct", SqlDbType.VarChar,30),
					new SqlParameter("@RequirInfo", SqlDbType.Char,30),
					new SqlParameter("@AuditingStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@ExhibitionHall", SqlDbType.VarChar,100),
                    new SqlParameter("@hits", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
                #endregion

                #region 联系方式
				
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
					new SqlParameter("@remark1", SqlDbType.VarChar,100)
                #endregion 
            
            };
            parameters[0].Value = model.EnterpriseID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.EnterpriseName;
            parameters[3].Value = model.ComAbout;
            parameters[4].Value = model.ComAboutBrief;
            parameters[5].Value = model.SetComTypeID;
            parameters[6].Value = model.Industrylist;
            parameters[7].Value = model.RegisterDate;
            parameters[8].Value = model.CountryCode;
            parameters[9].Value = model.ProvinceID;
            parameters[10].Value = model.CityID;
            parameters[11].Value = model.CountyID;
            parameters[12].Value = model.currency;
            parameters[13].Value = model.RegCapital;
            parameters[14].Value = model.MainProduct;
            parameters[15].Value = model.RequirInfo;
            parameters[16].Value = model.AuditingStatus;
            parameters[17].Value = model.ExhibitionHall;
            parameters[18].Value = model.hits;
            parameters[19].Value = model.remark;

            parameters[20].Value = model.EnterpriseName; ;//ContactModel.Name;
            parameters[21].Value = ContactModel.Name;
            parameters[22].Value = ContactModel.Career;
            parameters[23].Value = ContactModel.TelCountryCode;
            parameters[24].Value = ContactModel.TelStateCode;
            parameters[25].Value = ContactModel.TelNum;
            parameters[26].Value = ContactModel.FaxCountryCode;
            parameters[27].Value = ContactModel.FaxStateCode;
            parameters[28].Value = ContactModel.FaxNum;
            parameters[29].Value = ContactModel.Email;
            parameters[30].Value = ContactModel.Mobile;
            parameters[31].Value = ContactModel.address;
            parameters[32].Value = ContactModel.PostCode;
            parameters[33].Value = ContactModel.Website;
            parameters[34].Value = ContactModel.IsDel;
            parameters[35].Value = ContactModel.remark;

            int rowsAffected;
            int EnterpriseID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "UP_EnterpriseTab_Update", parameters, out rowsAffected);
                    if (rowsAffected > 0)
                    {
                        EnterpriseID = (int)parameters[0].Value;
                    }
                    else
                    {
                        EnterpriseID = 0;
                    }
                 
                    Tz888.SQLServerDAL.Register.common obj2 = new common ();
                    if (ContactManModels != null)
                    {
                        for(int i=0;i<ContactManModels.Count;i++)
                        {
                            if(ContactManModels[i].Name!="" && ContactManModels[i].Name!=null)
                            {
                                foreach (Tz888.Model.Register.OrgContactMan cm in ContactManModels)
                                {
                                    // model.ContactID = ContactID;
                                    if (!obj2.InsertContactMan(sqlConn, sqlTran, cm))
                                        throw new Exception();
                                }
                            }
                        }
                    }

                    if (infoResourceModels != null)
                    {
                        //图片资源
                        Tz888.SQLServerDAL.MemberResourceDAL obj3 = new MemberResourceDAL();
                        foreach (Tz888.Model.MemberResourceModel modelRes in infoResourceModels)
                        {
                            modelRes.LoginName = model.LoginName;
                            int i = obj3.Add(sqlConn, sqlTran, modelRes);
                        }
                    }
                    sqlTran.Commit();
                }
                catch
                {
                    sqlTran.Rollback();
                    EnterpriseID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return EnterpriseID;
        }

        //查询
        public DataTable getEnterpriseList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            obj = new Tz888.SQLServerDAL.Conn();
            return (obj.GetList(
                       tblName,
                       strGetFields,
                       fldName,
                       PageSize,
                       PageIndex,
                       doCount,
                       OrderType,
                       strWhere));
            return null;
            
        }

        //审核
        public bool AuditEnterprise(Tz888.Model.Register.EnterpriseInfoModel Enterprise, Tz888.Model.Register.OrgAuditModel OrgAudi)
        {
            SqlParameter[] parameters = {
                    #region  公司基本信息
					new SqlParameter("@EnterpriseID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@EnterpriseName", SqlDbType.VarChar,200),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@ComAboutBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
					new SqlParameter("@Industrylist", SqlDbType.Char,10),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@currency", SqlDbType.Char,10),
					new SqlParameter("@RegCapital", SqlDbType.Float,8),
					new SqlParameter("@MainProduct", SqlDbType.VarChar,30),
					new SqlParameter("@RequirInfo", SqlDbType.Char,30),
					new SqlParameter("@AuditingStatus", SqlDbType.TinyInt,1),//审核结果(1审核通过,2审核不通过)
					new SqlParameter("@ExhibitionHall", SqlDbType.VarChar,100),//展厅
                    new SqlParameter("@hits", SqlDbType.VarChar,100),//点数
					new SqlParameter("@remark", SqlDbType.VarChar,100),//备注
                    #endregion
                    #region 附加信息
                    
                    #endregion
                    #region 联系方式
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@OrganizationName", SqlDbType.VarChar,100),
					new SqlParameter("@Name", SqlDbType.VarChar,20),
					new SqlParameter("@Career", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
					new SqlParameter("@TelStateCode", SqlDbType.Char,4),
					new SqlParameter("@TelNum", SqlDbType.VarChar,60),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,3),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,4),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,60),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
                    #endregion 
                    #region  审核记录
					//new SqlParameter("@OrgName", SqlDbType.VarChar,200),= @EnterpriseName
					//new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),//未通过审核原因
					new SqlParameter("@AuditingBy", SqlDbType.VarChar,20),//审核人
					new SqlParameter("@AuditingDate", SqlDbType.DateTime),//审核时间
					new SqlParameter("@FeedbackStatus", SqlDbType.TinyInt,1),//反馈状态
					new SqlParameter("@FeedBackNote", SqlDbType.VarChar,300),//邮件反馈内容
					new SqlParameter("@OrgType", SqlDbType.TinyInt,1),//组织类型(0企业，1政府机构)
					new SqlParameter("@Memo", SqlDbType.VarChar,200)//备注
                    #endregion
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = Enterprise.LoginName;
            parameters[2].Value = Enterprise.EnterpriseName;
            parameters[3].Value = Enterprise.ComAbout;
            parameters[4].Value = Enterprise.ComAboutBrief;
            parameters[5].Value = Enterprise.SetComTypeID;
            parameters[6].Value = Enterprise.Industrylist;
            parameters[7].Value = Enterprise.RegisterDate;
            parameters[8].Value = Enterprise.CountryCode;
            parameters[9].Value = Enterprise.ProvinceID;
            parameters[10].Value = Enterprise.CityID;
            parameters[11].Value = Enterprise.CountyID;
            parameters[12].Value = Enterprise.currency;
            parameters[13].Value = Enterprise.RegCapital;
            parameters[14].Value = Enterprise.MainProduct;
            parameters[15].Value = Enterprise.RequirInfo;
            parameters[16].Value = Enterprise.AuditingStatus;
            parameters[17].Value = Enterprise.ExhibitionHall;
            parameters[18].Value = Enterprise.hits;
            parameters[19].Value = Enterprise.remark;

            parameters[20].Value = OrgAudi.AuditingRemark;
            parameters[21].Value = OrgAudi.AuditingBy;
            parameters[22].Value = OrgAudi.AuditingDate;
            parameters[23].Value = OrgAudi.FeedbackStatus;
            parameters[24].Value = OrgAudi.FeedBackNote;
            parameters[25].Value = OrgAudi.OrgType;
            parameters[26].Value = OrgAudi.Memo;
            return true;
        }


        //刷新
        public bool UpdateRefresh(int EnterpriseID)
        {
            int rowsAffected;
            bool bl;
            try
            {
                SqlParameter[] parameters = {
					    new SqlParameter("@EnterpriseID", SqlDbType.Int,4)
				    };
                parameters[0].Value = EnterpriseID;
                DbHelperSQL.RunProcedure("UP_EntFrontDisplayTime_Update", parameters, out rowsAffected);
                if (rowsAffected > 0)
                {
                    bl = true;
                }
                else
                {
                    bl = false;
                }
            }
            catch
            { bl = false; }
            return bl;
        }

        //删除
        public bool DeleteEnterprise(string loginName)
        { 
            int rowsAffected;
            bool bl;
            try{
			    SqlParameter[] parameters = {
					    new SqlParameter("@LoginName", SqlDbType.Char,16)
				    };
                parameters[0].Value = loginName;
                DbHelperSQL.RunProcedure("EnterpriseTab_RealDel", parameters, out rowsAffected);
                if (rowsAffected > 0)
                {
                    bl = true;
                }
                else
                {
                    bl = false;
                }
            }
            catch
            {   bl = false;     }
            return bl;
        }

        //静态化

        //附加信息添加
        public int addEnterprise_Additive()
        {

            return 0;
        }

        //读取企业性质
        public DataTable getEnterpriceManageType()
        {
            DataTable dt = null;
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            dt = obj.GetList("SetComTypeTab", "*", "SetComTypeID", 30, 1, 0, 0, ""); //表没有添加X
            return dt;
        }

        //修改输入
        public int UpdateOrganizationCode(string LoginName, string OrganizationCode)
        {
            return DbHelperSQL.ExecuteSql("UPDATE  EnterpriseTab SET  OrganizationCode='" + OrganizationCode + "' WHERE LoginName ='" + LoginName + "'");
        }
       //读取
        public string GetOrganizationCode(string LoginName)
        {
            Tz888.SQLServerDAL.Conn obj = new Conn();
            DataTable dt = obj.GetList("EnterpriseTab", "OrganizationCode", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["OrganizationCode"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
 