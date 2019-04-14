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
    public class GovernmentRegister : IGovernmentRegister
    {
        private Tz888.SQLServerDAL.Conn obj;
        //前台机构登记
        public int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                    #region 基本信息
					new SqlParameter("@GovernmentID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@GovernmentName", SqlDbType.VarChar,200),
					new SqlParameter("@GovAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@GovAboutBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@SubjectType", SqlDbType.Char,10),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@AuditingStatus", SqlDbType.TinyInt,1),					
					new SqlParameter("@ExhibitionHall", SqlDbType.VarChar,100),
                    new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
                    #endregion 
                    #region 联系方式					
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
                    new SqlParameter("@Website", SqlDbType.VarChar,200),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark1", SqlDbType.VarChar,100)
                   #endregion             
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.GovernmentName;
            parameters[3].Value = model.GovAbout;
            parameters[4].Value = model.GovAboutBrief;
            parameters[5].Value = model.SubjectType;
            parameters[6].Value = model.CountryCode;
            parameters[7].Value = model.ProvinceID;
            parameters[8].Value = model.CityID;
            parameters[9].Value = model.CountyID;
            parameters[10].Value = model.AuditingStatus;
            parameters[11].Value = model.ExhibitionHall;
            parameters[12].Value = model.Hits;
            parameters[13].Value = model.remark;

            parameters[14].Value = model.GovernmentName;
            parameters[15].Value = ContactModel.Name;
            parameters[16].Value = ContactModel.Career;
            parameters[17].Value = ContactModel.TelCountryCode;
            parameters[18].Value = ContactModel.TelStateCode;
            parameters[19].Value = ContactModel.TelNum;
            parameters[20].Value = ContactModel.FaxCountryCode;
            parameters[21].Value = ContactModel.FaxStateCode;
            parameters[22].Value = ContactModel.FaxNum;
            parameters[23].Value = ContactModel.Email;
            parameters[24].Value = ContactModel.Mobile;
            parameters[25].Value = ContactModel.address;
            parameters[26].Value = ContactModel.PostCode;
            parameters[27].Value = ContactModel.Website;
            parameters[28].Value = ContactModel.IsDel;
            parameters[29].Value = ContactModel.remark;


            int rowsAffected;
            int GovernmentID;

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "UP_GovernmentTab_ADD", parameters, out rowsAffected);
                    GovernmentID = (int)parameters[0].Value;
                    if (GovernmentID <= 0)
                        throw new Exception();

                    //添加多个联系人(检查原联系人列表中是否己存在 LoginName = model.LoginName的联系人，
                    //如果己存就，将先删除全部后重新添加,obj2.InsertContactMan代码逻辑中)
                    Tz888.SQLServerDAL.Register.common obj2 = new common();
                    if (ContactManModels != null)
                    {
                        for (int i = 0; i < ContactManModels.Count; i++)
                        {
                            if (ContactManModels[i].Name != "" && ContactManModels[i].Name != null)
                            {
                                foreach (Tz888.Model.Register.OrgContactMan cm in ContactManModels)
                                {
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
                    GovernmentID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

            return GovernmentID;
        }
        #region --检查域名是否否可注册－－－－－
        /// <summary>
        /// -检查域名是否否可注册
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>0 可注册　１不可注册</returns>
        public bool YuMing(string ExhibitionHall)  //如果存在信息则返回false
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ExhibitionHall", SqlDbType.VarChar,16),
                  
				};
            parameters[0].Value = ExhibitionHall;
            DataSet ds = DbHelperSQL.RunProcedure("SP_Yuming", parameters, "ds");
            int count;
            if (ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        //政府机构注册
        public void GovernmentReg(GovernmentInfoModel model)
        {
            SqlParameter[] parameters = {
                            new SqlParameter("@LoginName",SqlDbType.VarChar,16),
                            new SqlParameter("@GovernmentName",SqlDbType.VarChar,200),
                            new SqlParameter("@SubjectType",SqlDbType.VarChar,10),
                            new SqlParameter("@CountryCode",SqlDbType.VarChar,10),
                            new SqlParameter("@ProvinceID",SqlDbType.VarChar,10),
                            new SqlParameter("@CityID",SqlDbType.VarChar,10),
                            new SqlParameter("@AuditingStatus",SqlDbType.TinyInt,16)
            };

            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.GovernmentName;
            parameters[2].Value = model.SubjectType;
            parameters[3].Value = model.CountryCode;
            parameters[4].Value = model.ProvinceID;
            parameters[5].Value = model.CityID;
            parameters[6].Value = model.AuditingStatus;

            DbHelperSQL.RunProcedure("GovernmentTab_add", parameters);

        }

        //读取公司登记一信息(预览)
        public DataTable getGovernmentModel(string LoginName)
        {
            Tz888.SQLServerDAL.Conn obj = new Conn();
            DataTable dt = obj.GetList("GovernmentView", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }       
        }

        //修改
        public int GovernmentUpdate(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                    #region 基本信息
					new SqlParameter("@GovernmentID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@GovernmentName", SqlDbType.VarChar,200),
					new SqlParameter("@GovAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@GovAboutBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@SubjectType", SqlDbType.Char,10),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@AuditingStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@hits", SqlDbType.Int,4),
					new SqlParameter("@ExhibitionHall", SqlDbType.VarChar,100),
					new SqlParameter("@remark", SqlDbType.VarChar,100),               
                    #endregion 
                    #region 联系方式				
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
                    new SqlParameter("@Website", SqlDbType.VarChar,200),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@remark1", SqlDbType.VarChar,100)
                   #endregion             
            };
            parameters[0].Value = model.GovernmentID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.GovernmentName;
            parameters[3].Value = model.GovAbout;
            parameters[4].Value = model.GovAboutBrief;
            parameters[5].Value = model.SubjectType;
            parameters[6].Value = model.CountryCode;
            parameters[7].Value = model.ProvinceID;
            parameters[8].Value = model.CityID;
            parameters[9].Value = model.CountyID;
            parameters[10].Value = model.AuditingStatus;
            parameters[11].Value = model.Hits;
            parameters[12].Value = model.ExhibitionHall;
            parameters[13].Value = model.remark;

            parameters[14].Value = model.GovernmentName;
            parameters[15].Value = ContactModel.Name;
            parameters[16].Value = ContactModel.Career;
            parameters[17].Value = ContactModel.TelCountryCode;
            parameters[18].Value = ContactModel.TelStateCode;
            parameters[19].Value = ContactModel.TelNum;
            parameters[20].Value = ContactModel.FaxCountryCode;
            parameters[21].Value = ContactModel.FaxStateCode;
            parameters[22].Value = ContactModel.FaxNum;
            parameters[23].Value = ContactModel.Email;
            parameters[24].Value = ContactModel.Mobile;
            parameters[25].Value = ContactModel.address;
            parameters[26].Value = ContactModel.PostCode;
            parameters[27].Value = ContactModel.Website;
            parameters[28].Value = ContactModel.IsDel;
            parameters[29].Value = ContactModel.remark;


            int rowsAffected;
            int GovernmentID;

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "UP_GovernmentTab_Update", parameters, out rowsAffected);
                    if (rowsAffected > 0)
                    {
                        GovernmentID = (int)parameters[0].Value;
                    }
                    else
                    {
                        GovernmentID = 0;
                    }
                    //添加多个联系人(检查原联系人列表中是否己存在 LoginName = model.LoginName的联系人，
                    //如果己存就，将先删除全部后重新添加,obj2.InsertContactMan代码逻辑中)
                    Tz888.SQLServerDAL.Register.common obj2 = new common();
                    if (ContactManModels != null)
                    {
                        for (int i = 0; i < ContactManModels.Count; i++)
                        {
                            if (ContactManModels[i].Name != "" && ContactManModels[i].Name != null)
                            {
                                foreach (Tz888.Model.Register.OrgContactMan cm in ContactManModels)
                                {
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
                    GovernmentID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

            return GovernmentID;
        }

        //查询
        public DataTable getGovernmentList(string tblName, string strGetFields, string fldName,
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
        public bool AuditGovernment()
        {
            return true;
        }


        //刷新
        public bool UpdateRefresh(int GovernmentID)
        {
            int rowsAffected;
            bool bl;
            try
            {
                SqlParameter[] parameters = {
					    new SqlParameter("@GovernmentID", SqlDbType.Int,4)
				    };
                parameters[0].Value = GovernmentID;
                DbHelperSQL.RunProcedure("UP_GovFrontDisplayTime_Update", parameters, out rowsAffected);
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
        public bool DeleteGovernment(string  loginName)
        {
            int rowsAffected;
            bool bl;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,16)
				};
            parameters[0].Value = loginName;
            DbHelperSQL.RunProcedure("GovernmentTab_RealDel", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                bl = true;
            }
            else
            {
                bl = false;
            }
            return bl;
        }

        //静态化

        //是否重复查询

        //读取机构主体
        public DataTable getMerchantTypeTab()
        {
            DataTable dt = null;
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            dt = obj.GetList("SetMerchantTypeTab", "*", "MerchantTypeID", 30, 1, 0, 0, ""); //表没有添加X
            return dt;
        }

    }
}
