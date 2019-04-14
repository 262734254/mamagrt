using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;
using Tz888.IDAL.Info;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 项目信息数据库访问逻辑类
    /// </summary>
    public class ProjectInfoDAL : IProjectInfo
    {
        private const string SP_ProjectInfo_Insert = "ProjectInfoTab_Insert";
        private const string SP_InfoContactMan_Insert = "InfoContactManTab_Insert";
        private const string SP_InfoResource_Insert = "InfoResourceTab_Insert";
        private const string SP_InfoResource_InsertNew = "Project_gq_InsertNew";


        #region --得到采集招商实体--
        public Tz888.Model.Info.ExcavateProjectModel GetExcavateProjectModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ExcavateProjectModel model = new ExcavateProjectModel();
            DataSet ds = DbHelperSQL.RunProcedure("UP_ExcavateProjectTab_Model", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                model.Com = ds.Tables[0].Rows[0]["com"].ToString();
                model.ComInfo = ds.Tables[0].Rows[0]["cominfo"].ToString();
                model.ComMan = ds.Tables[0].Rows[0]["comMan"].ToString();
                model.ComTel = ds.Tables[0].Rows[0]["comTel"].ToString();
                model.Intent = ds.Tables[0].Rows[0]["intent"].ToString();
                model.Industry = ds.Tables[0].Rows[0]["Industry"].ToString();
                model.Mode = ds.Tables[0].Rows[0]["mode"].ToString();
                model.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.Prjmoney = ds.Tables[0].Rows[0]["Prjmoney"].ToString();
                model.ManAddress = ds.Tables[0].Rows[0]["ManAddress"].ToString();
                model.ManCode = ds.Tables[0].Rows[0]["ManCode"].ToString();
                model.ManMobile = ds.Tables[0].Rows[0]["ManMobile"].ToString();
                model.ManTel = ds.Tables[0].Rows[0]["ManTel"].ToString();
                model.ManTax = ds.Tables[0].Rows[0]["ManTax"].ToString();
                model.ManEmail = ds.Tables[0].Rows[0]["ManEmail"].ToString();
                model.WebUrl = ds.Tables[0].Rows[0]["WebUrl"].ToString();
                model.PublishTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PublishTime"]);
                model.Man = ds.Tables[0].Rows[0]["man"].ToString();
                model.ProjectInfo = ds.Tables[0].Rows[0]["projectInfo"].ToString();
            }
            return model;
        }
        #endregion

        #region --修改发布状态--
        public bool excavateProjecttabUpdatePublish(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_ExcavateProjectTab_IsPublishUpdate", parameters);
            return result;
        }
        #endregion

        #region --修改删除状态--
        public bool excavateProjecttabUpdateDelete(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_ExcavateProjectTab_IsDeleteUpdate", parameters);
            return result;
        }
        #endregion

        #region 添加一条项目信息
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@publishT", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.BigInt,8),

					new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@IndexOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@IndexTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@IndexPicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@InfoTypePicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoOriginRoleName", SqlDbType.Char,10),
					new SqlParameter("@GradeID", SqlDbType.Char,10),
					new SqlParameter("@FixPriceID", SqlDbType.Char,10),
					new SqlParameter("@FeeStatus", SqlDbType.TinyInt,1),

					new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------融资(项目)资源个性信息-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------资源联系信息--------------------------

					new SqlParameter("@ComName", SqlDbType.VarChar,40),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
					new SqlParameter("@TelStateCode", SqlDbType.Char,4),
					new SqlParameter("@TelNum", SqlDbType.VarChar,60),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,3),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,4),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,60),

					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),

                //---------------------------END---------------------------

                //-------------------------短信息--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------优质项目信息--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = mainInfoModel.IndexOrderNum;
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum;
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum;
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;
            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;
            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID;
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = mainInfoModel.KeyWord;
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            parameters[39].Value = infoContactModel.OrganizationName;
            parameters[40].Value = infoContactModel.Name;
            parameters[41].Value = infoContactModel.TelCountryCode;
            parameters[42].Value = infoContactModel.TelStateCode;
            parameters[43].Value = infoContactModel.TelNum;
            parameters[44].Value = infoContactModel.FaxCountryCode;
            parameters[45].Value = infoContactModel.FaxStateCode;
            parameters[46].Value = infoContactModel.FaxNum;
            parameters[47].Value = infoContactModel.Mobile;
            parameters[48].Value = infoContactModel.Address;
            parameters[49].Value = infoContactModel.PostCode;
            parameters[50].Value = infoContactModel.Email;
            parameters[51].Value = infoContactModel.WebSite;

            parameters[52].Value = shortInfoModel.ShortInfoControlID;
            parameters[53].Value = shortInfoModel.ShortTitle;
            parameters[54].Value = shortInfoModel.ShortContent;
            parameters[55].Value = shortInfoModel.Remark;

            parameters[56].Value = projectInfoModel.IsRec;
            parameters[57].Value = projectInfoModel.IsTop;
            parameters[58].Value = projectInfoModel.RecTime;
            parameters[59].Value = projectInfoModel.RecRemark;
            parameters[60].Value = projectInfoModel.RecTerm;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_ProjectInfo_Insert, parameters, out rowsAffected);
                    //DbHelperSQL.RunProcedure(SP_ProjectInfo_Insert, parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    if (infoContactManModels != null)
                    {
                        //为融资资源添加多个联系人
                        Tz888.SQLServerDAL.Info.InfoContactManDAL obj1 = new InfoContactManDAL();
                        foreach (Tz888.Model.Info.InfoContactManModel model in infoContactManModels)
                        {
                            model.InfoID = infoID;
                            obj1.InsertContactMan(sqlConn, sqlTran, model);
                        }
                    }

                    if (infoResourceModels != null)
                    {
                        //为融资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj2 = new InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            obj2.InsertInfoResource(sqlConn, sqlTran, model);
                        }
                    }
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }
        #endregion

        #region 修改项目信息
        public bool Update(Tz888.Model.Info.ProjectSetModel model)
        {
            SqlParameter[] parameters = {
                                    //主表信息
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10),

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    
                                    //项目信息
                                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					                new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					                new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Float,8),
                                    
                                    //联系信息
					                new SqlParameter("@ComName", SqlDbType.VarChar,100),
					                new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					                new SqlParameter("@TelCountryCode", SqlDbType.Char,6),
					                new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					                new SqlParameter("@TelNum", SqlDbType.VarChar,100),
					                new SqlParameter("@FaxCountryCode", SqlDbType.Char,6),
					                new SqlParameter("@FaxStateCode", SqlDbType.Char,8),
					                new SqlParameter("@FaxNum", SqlDbType.VarChar,100),
                                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					                new SqlParameter("@Address", SqlDbType.VarChar,100),
					                new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					                new SqlParameter("@Email", SqlDbType.VarChar,50),
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                                    
                                    //短信息表
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                                //-------------------------优质项目信息--------------------------
                	                new SqlParameter("@IsRec", SqlDbType.Bit,1),
					                new SqlParameter("@IsTop", SqlDbType.Bit,1),
					                new SqlParameter("@RecTime", SqlDbType.DateTime),
					                new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					                new SqlParameter("@RecTerm", SqlDbType.Int,4),
                                //---------------------------END---------------------------
                                    
            };
            parameters[0].Value = model.MainInfoModel.InfoID;
            parameters[1].Value = model.MainInfoModel.Title;
            parameters[2].Value = model.MainInfoModel.publishT;
            parameters[3].Value = model.MainInfoModel.LoginName;

            parameters[4].Value = model.MainInfoModel.KeyWord;
            parameters[5].Value = model.MainInfoModel.Descript;
            parameters[6].Value = model.MainInfoModel.DisplayTitle;
            parameters[7].Value = model.MainInfoModel.FrontDisplayTime;
            parameters[8].Value = model.MainInfoModel.ValidateStartTime;
            parameters[9].Value = model.MainInfoModel.ValidateTerm;
            parameters[10].Value = model.MainInfoModel.TemplateID;
            parameters[11].Value = model.MainInfoModel.HtmlFile;

            parameters[12].Value = model.ProjectInfoModel.ProjectName;
            parameters[13].Value = model.ProjectInfoModel.ProjectNameBrief;
            parameters[14].Value = model.ProjectInfoModel.ComAbout;
            parameters[15].Value = model.ProjectInfoModel.ComBrief;
            parameters[16].Value = model.ProjectInfoModel.CountryCode;
            parameters[17].Value = model.ProjectInfoModel.ProvinceID;
            parameters[18].Value = model.ProjectInfoModel.CityID;
            parameters[19].Value = model.ProjectInfoModel.CountyID;
            parameters[20].Value = model.ProjectInfoModel.IndustryBID;
            parameters[21].Value = model.ProjectInfoModel.CooperationDemandType;
            parameters[22].Value = model.ProjectInfoModel.CapitalCurrency;
            parameters[23].Value = model.ProjectInfoModel.CapitalTotal;
            parameters[24].Value = model.ProjectInfoModel.ProjectCurrency;
            parameters[25].Value = model.ProjectInfoModel.CapitalID;

            parameters[26].Value = model.InfoContactModel.OrganizationName;
            parameters[27].Value = model.InfoContactModel.Name;
            parameters[28].Value = model.InfoContactModel.TelCountryCode;
            parameters[29].Value = model.InfoContactModel.TelStateCode;
            parameters[30].Value = model.InfoContactModel.TelNum;
            parameters[31].Value = model.InfoContactModel.FaxCountryCode;
            parameters[32].Value = model.InfoContactModel.FaxStateCode;
            parameters[33].Value = model.InfoContactModel.FaxNum;
            parameters[34].Value = model.InfoContactModel.Mobile;
            parameters[35].Value = model.InfoContactModel.Address;
            parameters[36].Value = model.InfoContactModel.PostCode;
            parameters[37].Value = model.InfoContactModel.Email;
            parameters[38].Value = model.InfoContactModel.WebSite;

            parameters[39].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[40].Value = model.ShortInfoModel.ShortTitle;
            parameters[41].Value = model.ShortInfoModel.ShortContent;
            parameters[42].Value = model.ShortInfoModel.Remark;

            parameters[43].Value = model.ProjectInfoModel.IsRec;
            parameters[44].Value = model.ProjectInfoModel.IsTop;
            parameters[45].Value = model.ProjectInfoModel.RecTime;
            parameters[46].Value = model.ProjectInfoModel.RecRemark;
            parameters[47].Value = model.ProjectInfoModel.RecTerm;


            bool ReturnValue = false;
            long infoID = model.MainInfoModel.InfoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //修改项目信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "ProjectInfoTab_Update", parameters, out rowsAffected);

                    //为项目信息更新联系人信息
                    Tz888.SQLServerDAL.Info.InfoContactManDAL obj2 = new InfoContactManDAL();
                    obj2.DeleteByInfoID(sqlConn, sqlTran, infoID);
                    if (model.InfoContactManModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoContactManModel tmpModel in model.InfoContactManModels)
                        {
                            tmpModel.InfoID = infoID;
                            obj2.InsertContactMan(sqlConn, sqlTran, tmpModel);
                        }
                    }

                    //为项目信息添加多个资源
                    Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                    obj3.DeleteByInfoID(sqlConn, sqlTran, infoID);
                    if (model.InfoResourceModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoResourceModel tmpModel in model.InfoResourceModels)
                        {
                            tmpModel.InfoID = infoID;
                            obj3.InsertInfoResource(sqlConn, sqlTran, tmpModel);
                        }
                    }
                    sqlTran.Commit();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion

        #region  得到一个对象实体(只包含ProjectInfoTab表信息)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Info.ProjectInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ProjectInfoModel model = new Tz888.Model.Info.ProjectInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("ProjectInfoTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                model.ProjectNameBrief = ds.Tables[0].Rows[0]["ProjectNameBrief"].ToString();
                model.ComAbout = ds.Tables[0].Rows[0]["ComAbout"].ToString();
                model.ComBrief = ds.Tables[0].Rows[0]["ComBrief"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();

                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();

                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();

                model.IndustryBID = ds.Tables[0].Rows[0]["IndustryBID"].ToString();
                model.CooperationDemandType = ds.Tables[0].Rows[0]["CooperationDemandType"].ToString();
                model.CapitalCurrency = ds.Tables[0].Rows[0]["CapitalCurrency"].ToString();
                if (ds.Tables[0].Rows[0]["CapitalTotal"].ToString() != "")
                {
                    model.CapitalTotal = decimal.Parse(ds.Tables[0].Rows[0]["CapitalTotal"].ToString());
                }
                model.ProjectCurrency = ds.Tables[0].Rows[0]["ProjectCurrency"].ToString();
                model.CapitalID = ds.Tables[0].Rows[0]["CapitalID"].ToString();
                model.CapitalName = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                model.Remrk = ds.Tables[0].Rows[0]["Remrk"].ToString();

                //---08.6.2增加属性

                if (ds.Tables[0].Rows[0]["SellStockShare"].ToString() != "")
                {
                    model.SellStockShare = int.Parse(ds.Tables[0].Rows[0]["SellStockShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnModeID"].ToString() != "")
                {
                    model.ReturnModeID = ds.Tables[0].Rows[0]["ReturnModeID"].ToString();
                }
                model.ProjectAbout = ds.Tables[0].Rows[0]["ProjectAbout"].ToString();
                model.marketAbout = ds.Tables[0].Rows[0]["marketAbout"].ToString();
                model.competitioAbout = ds.Tables[0].Rows[0]["competitioAbout"].ToString();
                model.BussinessModeAbout = ds.Tables[0].Rows[0]["BussinessModeAbout"].ToString();
                model.ManageTeamAbout = ds.Tables[0].Rows[0]["ManageTeamAbout"].ToString();

                model.warrant = ds.Tables[0].Rows[0]["warrant"].ToString();
                if (ds.Tables[0].Rows[0]["Dwlyysy"].ToString() != "")
                {
                    model.nDwlyysy = decimal.Parse(ds.Tables[0].Rows[0]["Dwlyysy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dwljly"].ToString() != "")
                {
                    model.nDwljly = decimal.Parse(ds.Tables[0].Rows[0]["Dwljly"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dwzzc"].ToString() != "")
                {
                    model.nDwzzc = decimal.Parse(ds.Tables[0].Rows[0]["Dwzzc"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dwzfz"].ToString() != "")
                {
                    model.nDwzfz = decimal.Parse(ds.Tables[0].Rows[0]["Dwzfz"].ToString());
                }

                model.financingID = ds.Tables[0].Rows[0]["financingID"].ToString();


                //201006资源超市第二次改版，新增字段
                //债券
                model.cZqXmlxqkb = ds.Tables[0].Rows[0]["cZqXmlxqkb"].ToString();   //--	项目立项情况
                model.cZqQyfzjd = ds.Tables[0].Rows[0]["cZqQyfzjd"].ToString();     //--企业发展阶段
                if (IsNumber(ds.Tables[0].Rows[0]["iZqYqjjdwqk"].ToString()))
                {
                    model.iZqYqjjdwqk = FormatData(ds.Tables[0].Rows[0]["iZqYqjjdwqk"].ToString()); //--要求资金到位情况
                }
                else
                {
                    model.iZqYqjjdwqk = 0;
                }
                //--投资回报期 model.ProjectInfoModel.iZqTzfbq
                if (IsNumber(ds.Tables[0].Rows[0]["iZqTzfbq"].ToString()))
                {
                    model.iZqTzfbq = FormatData(ds.Tables[0].Rows[0]["iZqTzfbq"].ToString());
                }
                else
                {
                    model.iZqTzfbq = 0;
                }
                //股权
                model.sXmlxqk = ds.Tables[0].Rows[0]["Xmlxqk"].ToString();   //--	项目立项情况
                model.sQyfzjd = ds.Tables[0].Rows[0]["Qyfzjd"].ToString();     //--企业发展阶段
                if (IsNumber(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()))
                {
                    model.iYqzjdwqk = FormatData(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()); //--要求资金到位情况
                }
                else
                {
                    model.iYqzjdwqk = 0;
                }
                //市场占有率份额
                if (IsNumber(ds.Tables[0].Rows[0]["Sczylfy"].ToString()))
                {
                    model.iSczylfy = FormatData(ds.Tables[0].Rows[0]["Sczylfy"].ToString());
                }
                else
                {
                    model.iSczylfy = 0;
                }
                //行业市场增长率
                if (IsNumber(ds.Tables[0].Rows[0]["Hysczzl"].ToString()))
                {
                    model.iHysczzl = FormatData(ds.Tables[0].Rows[0]["Hysczzl"].ToString());
                }
                else
                {
                    model.iHysczzl = 0;
                }
                //资产负债率
                if (IsNumber(ds.Tables[0].Rows[0]["Zcfzl"].ToString()))
                {
                    model.iZcfzl = FormatData(ds.Tables[0].Rows[0]["Zcfzl"].ToString());
                }
                else
                {
                    model.iZcfzl = 0;
                }
                //单位年营收入
                try
                {
                    model.CompanyYearIncome = decimal.Parse(ds.Tables[0].Rows[0]["CompanyYearIncome"].ToString());
                }
                catch
                {
                    model.CompanyYearIncome = decimal.Parse("0");
                }
                //单位年净利润
                try
                {
                    model.CompanyNG = decimal.Parse(ds.Tables[0].Rows[0]["CompanyNG"].ToString());
                }
                catch
                {
                    model.CompanyNG = decimal.Parse("0");
                }

                //单位总资产
                try
                {
                    model.CompanyTotalCapital = decimal.Parse(ds.Tables[0].Rows[0]["CompanyTotalCapital"].ToString());
                }
                catch
                {
                    model.CompanyTotalCapital = decimal.Parse("0");
                }
                //单位总负债
                try
                {
                    model.CompanyTotalDebet = decimal.Parse(ds.Tables[0].Rows[0]["CompanyTotalDebet"].ToString());
                }
                catch
                {
                    model.CompanyTotalDebet = decimal.Parse("0");
                }
                if (IsNumber(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()))
                {
                    model.iYqzjdwqk = FormatData(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()); //--要求资金到位情况
                }
                else
                {
                    model.iYqzjdwqk = 0;
                }
                //--产品市场增长率
                if (IsNumber(ds.Tables[0].Rows[0]["iZqCpsczzl"].ToString()))
                {
                    model.iZqCpsczzl = FormatData(ds.Tables[0].Rows[0]["iZqCpsczzl"].ToString());
                }
                else
                {
                    model.iZqCpsczzl = 0;
                }
                //--产品市场容量
                if (IsNumber(ds.Tables[0].Rows[0]["iZqCpscYl"].ToString()))
                {
                    model.iZqCpscYl = FormatData(ds.Tables[0].Rows[0]["iZqCpscYl"].ToString());
                }
                else
                {
                    model.iZqCpscYl = 0;
                }
                //--资产负债率
                if (IsNumber(ds.Tables[0].Rows[0]["iZqZcfzl"].ToString()))
                {
                    model.iZqZcfzl = FormatData(ds.Tables[0].Rows[0]["iZqZcfzl"].ToString());
                }
                else
                {
                    model.iZqZcfzl = 0;
                }
                //--流动比率
                if (IsNumber(ds.Tables[0].Rows[0]["iZqYdbl"].ToString()))
                {
                    model.iZqYdbl = FormatData(ds.Tables[0].Rows[0]["iZqYdbl"].ToString());
                }
                else
                {
                    model.iZqYdbl = 0;
                }

                //--投资收益率
                if (IsNumber(ds.Tables[0].Rows[0]["iZqTzsl"].ToString()))
                {
                    model.iZqTzsl = FormatData(ds.Tables[0].Rows[0]["iZqTzsl"].ToString());
                }
                else
                {
                    model.iZqTzsl = 0;
                }
                //--销售利润率
                if (IsNumber(ds.Tables[0].Rows[0]["iZqXslyl"].ToString()))
                {
                    model.iZqXslyl = FormatData(ds.Tables[0].Rows[0]["iZqXslyl"].ToString());
                }
                else
                {
                    model.iZqXslyl = 0;
                }
                //--投资回报期
                if (IsNumber(ds.Tables[0].Rows[0]["Xmtzfbzq"].ToString()))
                {
                    model.iXmtzfbzq = FormatData(ds.Tables[0].Rows[0]["Xmtzfbzq"].ToString());
                }
                else
                {
                    model.iXmtzfbzq = 0;
                }
                //--项目有效期限
                if (IsNumber(ds.Tables[0].Rows[0]["iZqXmyxqs"].ToString()))
                {
                    model.iZqXmyxqs = FormatData(ds.Tables[0].Rows[0]["iZqXmyxqs"].ToString());
                }
                else
                {
                    model.iZqXmyxqs = 0;
                }

                model.cZqXmzy = ds.Tables[0].Rows[0]["cZqXmzy"].ToString();    //--项目摘要
                model.cZqXmgjz = ds.Tables[0].Rows[0]["cZqXmgjz"].ToString();    //--项目关键字
                model.cZqCpks = ds.Tables[0].Rows[0]["ProjectAbout"].ToString();  //--产品概述
                model.sXmgjz = ds.Tables[0].Rows[0]["xmgjz"].ToString();
                model.cZqJzfx = ds.Tables[0].Rows[0]["competitioAbout"].ToString();  //--竞争分析
                model.cZqSyms = ds.Tables[0].Rows[0]["BussinessModeAbout"].ToString();    //--商业模式
                model.cZqGltd = ds.Tables[0].Rows[0]["ManageTeamAbout"].ToString();    //--管理团队

                //--信息完整度
                if (IsNumber(ds.Tables[0].Rows[0]["InformationIntegrity"].ToString()))
                {
                    model.InformationIntegrity = FormatData(ds.Tables[0].Rows[0]["InformationIntegrity"].ToString());
                }
                else
                {
                    model.InformationIntegrity = 0;
                }

                if (ds.Tables[0].Rows[0]["IsRec"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsRec"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRec"].ToString().ToLower() == "true"))
                    {
                        model.IsRec = true;
                    }
                    else
                    {
                        model.IsRec = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsTop"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["RecTime"].ToString() != "")
                {

                    model.RecTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecTime"].ToString());
                }
                model.RecRemark = ds.Tables[0].Rows[0]["RecRemark"].ToString();
                if (ds.Tables[0].Rows[0]["RecTerm"].ToString() != "")
                {
                    model.RecTerm = int.Parse(ds.Tables[0].Rows[0]["RecTerm"].ToString());
                }
                //
                List<string> lstIndustryBName = new List<string>();
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string sIndustryNameTemp = ds.Tables[1].Rows[i]["IndustryBName"].ToString().Trim();
                    string sIndustryIDTemp = ds.Tables[1].Rows[i]["IndustryBID"].ToString().Trim();
                    if (model.IndustryBID.IndexOf(sIndustryIDTemp) != -1)
                    {
                        lstIndustryBName.Add(sIndustryNameTemp);
                    }
                }
                model.IndustryBName = lstIndustryBName;

                List<string> lstCooperationDemandTypeName = new List<string>();
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    string sInfoType = ds.Tables[2].Rows[i]["InfoType"].ToString().Trim().ToLower();
                    if (sInfoType == "project")
                    {
                        string sCooperationDemandTypeNameTemp = ds.Tables[2].Rows[i]["CooperationDemandName"].ToString().Trim();
                        string sCooperationDemandTypeIDTemp = ds.Tables[2].Rows[i]["CooperationDemandTypeID"].ToString().Trim();
                        if (model.CooperationDemandType.Trim().IndexOf(sCooperationDemandTypeIDTemp.Trim()) != -1)
                        {
                            lstCooperationDemandTypeName.Add(sCooperationDemandTypeNameTemp);
                        }
                    }
                }
                model.CooperationDemandTypeName = lstCooperationDemandTypeName;

                if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                {
                    model.CountryName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                }
                if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                {
                    model.ProvinceName = ds.Tables[4].Rows[0]["ProvinceName"].ToString();
                }
                if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
                {
                    model.CityName = ds.Tables[5].Rows[0]["CityName"].ToString();
                }
                if (ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0)
                {
                    model.CountyName = ds.Tables[6].Rows[0]["CountyName"].ToString();
                }


                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 得到一个对象实体(完整项目信息)
        /// <summary>
        /// 获取一个完整的项目信息实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ProjectSetModel GetIntegrityModel(long InfoID)
        {
            Tz888.Model.Info.ProjectSetModel model = new ProjectSetModel();

            //获取主要信息
            MainInfoDAL obj1 = new MainInfoDAL();
            model.MainInfoModel = obj1.GetModel(InfoID);

            //获取项目资源个性信息
            model.ProjectInfoModel = this.GetModel(InfoID);

            //获取信息联系方式
            InfoContactDAL obj3 = new InfoContactDAL();
            model.InfoContactModel = obj3.GetModel(InfoID);

            //获取项目信息联系人
            //InfoContactManDAL obj4 = new InfoContactManDAL();
            //model.InfoContactManModels = obj4.GetModelList(InfoID);

            //获取项目信息相关资源
            InfoResourceDAL obj5 = new InfoResourceDAL();
            model.InfoResourceModels = obj5.GetModelList(InfoID);

            //短信息
            ShortInfoDAL obj6 = new ShortInfoDAL();
            model.ShortInfoModel = obj6.GetModel(InfoID);

            return model;
        }
        #endregion

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Tz888.SQLServerDAL.Conn dal = new Conn();
            return (dal.GetList(
                "ProjectInfoTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion

        //新属性
        #region 债券 发布 第一步
        public long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@publishT", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.BigInt,8),

					new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@IndexOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@IndexTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@IndexPicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@InfoTypePicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoOriginRoleName", SqlDbType.Char,10),
					new SqlParameter("@GradeID", SqlDbType.Char,10),
					new SqlParameter("@FixPriceID", SqlDbType.Char,10),
					new SqlParameter("@FeeStatus", SqlDbType.TinyInt,1),

					new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------融资(项目)资源个性信息-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------新属性--------------------------

				
					new SqlParameter("@warrant", SqlDbType.VarChar,-1),
					new SqlParameter("@financingID", SqlDbType.VarChar,20),
                //---------------------------END---------------------------

                //-------------------------短信息--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------优质项目信息--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------201006资源超市第二次改版计划------------//
                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//	项目立项情况
                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //企业发展阶段
                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int),  //要求资金到位情况
                new SqlParameter("@iZqCpsczzl",SqlDbType.Int),   //产品市场增长率
                new SqlParameter("@iZqCpscYl",SqlDbType.Int),    //产品市场容量
                new SqlParameter("@iZqZcfzl",SqlDbType.Int),     //资产负债率
                new SqlParameter("@iZqYdbl",SqlDbType.Int),      //流动比率
                new SqlParameter("@iZqTzsl",SqlDbType.Int),      //投资收益率
                new SqlParameter("@iZqXslyl",SqlDbType.Int),     //销售利润率
                new SqlParameter("@iZqTzfbq",SqlDbType.Int),     //投资回报期
                new SqlParameter("@iZqXmyxqs",SqlDbType.Int),    //项目有效期限
                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//项目摘要
                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//项目关键字
                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//产品概述
                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//竞争分析
                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//商业模式
                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//管理团队
                //-------------------END------------------------------------//


                 //-------------将以前的第二步的内容，改为第一步里----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------

                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //信息完整度

                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //单位年营业收入
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //单位年净利润
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //单位总资产
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //单位总负债
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = mainInfoModel.IndexOrderNum;
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum;
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum;
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;
            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;
            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID;
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = mainInfoModel.KeyWord;
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //新属性

            parameters[39].Value = projectInfoModel.warrant;
            parameters[40].Value = projectInfoModel.financingID;

            parameters[41].Value = shortInfoModel.ShortInfoControlID;
            parameters[42].Value = shortInfoModel.ShortTitle;
            parameters[43].Value = shortInfoModel.ShortContent;
            parameters[44].Value = shortInfoModel.Remark;

            parameters[45].Value = projectInfoModel.IsRec;
            parameters[46].Value = projectInfoModel.IsTop;
            parameters[47].Value = projectInfoModel.RecTime;
            parameters[48].Value = projectInfoModel.RecRemark;
            parameters[49].Value = projectInfoModel.RecTerm;
            parameters[50].Value = "project_zq1";


            //-------------------201006资源超市第二次改版计划------------//
            parameters[51].Value = projectInfoModel.cZqXmlxqkb;//	项目立项情况
            parameters[52].Value = projectInfoModel.cZqQyfzjd; //企业发展阶段
            parameters[53].Value = projectInfoModel.iZqYqjjdwqk;  //要求资金到位情况
            parameters[54].Value = projectInfoModel.iZqCpsczzl;   //产品市场增长率
            parameters[55].Value = projectInfoModel.iZqCpscYl;    //产品市场容量
            parameters[56].Value = projectInfoModel.iZqZcfzl;     //资产负债率
            parameters[57].Value = projectInfoModel.iZqYdbl;      //流动比率
            parameters[58].Value = projectInfoModel.iZqTzsl;      //投资收益率
            parameters[59].Value = projectInfoModel.iZqXslyl;     //销售利润率
            parameters[60].Value = projectInfoModel.iZqTzfbq;     //投资回报期
            parameters[61].Value = projectInfoModel.iZqXmyxqs;    //项目有效期限
            parameters[62].Value = projectInfoModel.cZqXmzy;//项目摘要
            parameters[63].Value = projectInfoModel.cZqXmgjz;//项目关键字
            parameters[64].Value = projectInfoModel.cZqCpks;//产品概述
            parameters[65].Value = projectInfoModel.cZqJzfx;//竞争分析
            parameters[66].Value = projectInfoModel.cZqSyms;//商业模式
            parameters[67].Value = projectInfoModel.cZqGltd;//管理团队
            //-------------------END------------------------------------//

            //-------------将以前的第二步的内容，改为第一步里----------
            parameters[68].Value = projectInfoModel.ProjectAbout;
            parameters[69].Value = projectInfoModel.marketAbout;
            parameters[70].Value = projectInfoModel.competitioAbout;
            parameters[71].Value = projectInfoModel.BussinessModeAbout;
            parameters[72].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------

            parameters[73].Value = projectInfoModel.InformationIntegrity; //信息完整度

            parameters[74].Value = projectInfoModel.nDwlyysy;  //借款单位年营业收入
            parameters[75].Value = projectInfoModel.nDwljly;   //借款单位年净利润
            parameters[76].Value = projectInfoModel.nDwzzc;    //借款单位总资产
            parameters[77].Value = projectInfoModel.nDwzfz;    //借款单位总负债

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_zq_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }
        #endregion

        #region 债券 发布 第一步[重构，新添加的包括上传多个文件]
        public long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@publishT", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.BigInt,8),

					new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@IndexOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@IndexTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@IndexPicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@InfoTypePicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoOriginRoleName", SqlDbType.Char,10),
					new SqlParameter("@GradeID", SqlDbType.Char,10),
					new SqlParameter("@FixPriceID", SqlDbType.Char,10),
					new SqlParameter("@FeeStatus", SqlDbType.TinyInt,1),

					new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------融资(项目)资源个性信息-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------新属性--------------------------

				
					new SqlParameter("@warrant", SqlDbType.VarChar,-1),
					new SqlParameter("@financingID", SqlDbType.VarChar,20),
                //---------------------------END---------------------------

                //-------------------------短信息--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------优质项目信息--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------201006资源超市第二次改版计划------------//
                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//	项目立项情况
                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //企业发展阶段
                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int),  //要求资金到位情况
                new SqlParameter("@iZqCpsczzl",SqlDbType.Int),   //产品市场增长率
                new SqlParameter("@iZqCpscYl",SqlDbType.Int),    //产品市场容量
                new SqlParameter("@iZqZcfzl",SqlDbType.Int),     //资产负债率
                new SqlParameter("@iZqYdbl",SqlDbType.Int),      //流动比率
                new SqlParameter("@iZqTzsl",SqlDbType.Int),      //投资收益率
                new SqlParameter("@iZqXslyl",SqlDbType.Int),     //销售利润率
                new SqlParameter("@iZqTzfbq",SqlDbType.Int),     //投资回报期
                new SqlParameter("@iZqXmyxqs",SqlDbType.Int),    //项目有效期限
                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//项目摘要
                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//项目关键字
                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//产品概述
                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//竞争分析
                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//商业模式
                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//管理团队
                //-------------------END------------------------------------//


                 //-------------将以前的第二步的内容，改为第一步里----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------

                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //信息完整度

                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //单位年营业收入
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //单位年净利润
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //单位总资产
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //单位总负债
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = mainInfoModel.IndexOrderNum;
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum;
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum;
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;
            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;
            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID;
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = mainInfoModel.KeyWord;
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //新属性

            parameters[39].Value = projectInfoModel.warrant;
            parameters[40].Value = projectInfoModel.financingID;

            parameters[41].Value = shortInfoModel.ShortInfoControlID;
            parameters[42].Value = shortInfoModel.ShortTitle;
            parameters[43].Value = shortInfoModel.ShortContent;
            parameters[44].Value = shortInfoModel.Remark;

            parameters[45].Value = projectInfoModel.IsRec;
            parameters[46].Value = projectInfoModel.IsTop;
            parameters[47].Value = projectInfoModel.RecTime;
            parameters[48].Value = projectInfoModel.RecRemark;
            parameters[49].Value = projectInfoModel.RecTerm;
            parameters[50].Value = "project_zq1";


            //-------------------201006资源超市第二次改版计划------------//
            parameters[51].Value = projectInfoModel.cZqXmlxqkb;//	项目立项情况
            parameters[52].Value = projectInfoModel.cZqQyfzjd; //企业发展阶段
            parameters[53].Value = projectInfoModel.iZqYqjjdwqk;  //要求资金到位情况
            parameters[54].Value = projectInfoModel.iZqCpsczzl;   //产品市场增长率
            parameters[55].Value = projectInfoModel.iZqCpscYl;    //产品市场容量
            parameters[56].Value = projectInfoModel.iZqZcfzl;     //资产负债率
            parameters[57].Value = projectInfoModel.iZqYdbl;      //流动比率
            parameters[58].Value = projectInfoModel.iZqTzsl;      //投资收益率
            parameters[59].Value = projectInfoModel.iZqXslyl;     //销售利润率
            parameters[60].Value = projectInfoModel.iZqTzfbq;     //投资回报期
            parameters[61].Value = projectInfoModel.iZqXmyxqs;    //项目有效期限
            parameters[62].Value = projectInfoModel.cZqXmzy;//项目摘要
            parameters[63].Value = projectInfoModel.cZqXmgjz;//项目关键字
            parameters[64].Value = projectInfoModel.cZqCpks;//产品概述
            parameters[65].Value = projectInfoModel.cZqJzfx;//竞争分析
            parameters[66].Value = projectInfoModel.cZqSyms;//商业模式
            parameters[67].Value = projectInfoModel.cZqGltd;//管理团队
            //-------------------END------------------------------------//

            //-------------将以前的第二步的内容，改为第一步里----------
            parameters[68].Value = projectInfoModel.ProjectAbout;
            parameters[69].Value = projectInfoModel.marketAbout;
            parameters[70].Value = projectInfoModel.competitioAbout;
            parameters[71].Value = projectInfoModel.BussinessModeAbout;
            parameters[72].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------

            parameters[73].Value = projectInfoModel.InformationIntegrity; //信息完整度

            parameters[74].Value = projectInfoModel.nDwlyysy;  //借款单位年营业收入
            parameters[75].Value = projectInfoModel.nDwljly;   //借款单位年净利润
            parameters[76].Value = projectInfoModel.nDwzzc;    //借款单位总资产
            parameters[77].Value = projectInfoModel.nDwzfz;    //借款单位总负债

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_zq_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    //将上传文件
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();

                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, model, 1))
                                iUploadCount += 1;
                        }
                        //没有成功
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            return 0;
                        }
                    }


                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }
        #endregion

        #region 债券 发布 第二步
        public bool PublishProjectZQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@marketAbout", SqlDbType.NText),
                    new SqlParameter("@CompanyYearIncome", SqlDbType.Money,8),
					new SqlParameter("@CompanyNG", SqlDbType.Money,8),
					new SqlParameter("@CompanyTotalCapital", SqlDbType.Money,8),
					new SqlParameter("@CompanyTotalDebet", SqlDbType.Money,8),
				    new SqlParameter("@flag", SqlDbType.VarChar,30),
            };
            parameters[0].Value = projectInfoModel.InfoID;
            parameters[1].Value = projectInfoModel.marketAbout;
            parameters[2].Value = projectInfoModel.CompanyYearIncome;
            parameters[3].Value = projectInfoModel.CompanyNG;
            parameters[4].Value = projectInfoModel.CompanyTotalCapital;
            parameters[5].Value = projectInfoModel.CompanyTotalDebet;
            parameters[6].Value = "project_zq2";

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    int rowsAffected = 0;
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_zq_Insert", parameters, out rowsAffected);

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return true;
        }
        #endregion

        #region 债券修改
        public bool ProjectInfoZQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                                    //主表信息
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10),

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    
                                    //项目信息
                                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					                new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					                new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Float,8),
                                    
                                    //联系信息
					                new SqlParameter("@ComName", SqlDbType.VarChar,100),
					                new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
                                    new SqlParameter("@Career", SqlDbType.VarChar,20),
					                new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					                new SqlParameter("@TelNum", SqlDbType.VarChar,100),
                                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					                new SqlParameter("@Address", SqlDbType.VarChar,100),
					                new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					                new SqlParameter("@Email", SqlDbType.VarChar,50),
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                                    
                                    //短信息表
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                                //-------------------------优质项目信息--------------------------
                	                new SqlParameter("@IsRec", SqlDbType.Bit,1),
					                new SqlParameter("@IsTop", SqlDbType.Bit,1),
					                new SqlParameter("@RecTime", SqlDbType.DateTime),
					                new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					                new SqlParameter("@RecTerm", SqlDbType.Int,4),
                                //---------------------------新属性---------------------------
                                    new SqlParameter("@warrant", SqlDbType.VarChar,-1),
                                    new SqlParameter("@marketAbout", SqlDbType.NText),
                                    new SqlParameter("@CompanyYearIncome", SqlDbType.Money,8),
					                new SqlParameter("@CompanyNG", SqlDbType.Money,8),
					                new SqlParameter("@CompanyTotalCapital", SqlDbType.Money,8),
					                new SqlParameter("@CompanyTotalDebet", SqlDbType.Money,8),
                                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
                               //201006资源超市第二次改版，新增字段
                                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//--	项目立项情况
                                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //--企业发展阶段
                                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int,4),  //--要求资金到位情况
                                new SqlParameter("@iZqCpsczzl",SqlDbType.Int,4),   //--产品市场增长率
                                new SqlParameter("@iZqCpscYl",SqlDbType.Int,4),    //--产品市场容量
                                new SqlParameter("@iZqZcfzl",SqlDbType.Int,4),     //--资产负债率
                                new SqlParameter("@iZqYdbl",SqlDbType.Int,4),      //--流动比率
                                new SqlParameter("@iZqTzsl",SqlDbType.Int,4),     //--投资收益率
                                new SqlParameter("@iZqXslyl",SqlDbType.Int,4),     //--销售利润率
                                new SqlParameter("@iZqTzfbq",SqlDbType.Int,4),     //--投资回报期
                                new SqlParameter("@iZqXmyxqs",SqlDbType.Int,4),    //--项目有效期限
                                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//--项目摘要
                                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//--项目关键字
                                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//--产品概述
                                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//--竞争分析
                                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//--商业模式
                                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//--管理团队
                                //-------END---------------------------

                                new SqlParameter("@iInformationIntegrity",SqlDbType.Int,4), //--信息完整度
                                //-----------20100629------------------
                                new SqlParameter("@iSczylfy",SqlDbType.NVarChar,100),//--市场占有率(份额)
                                new SqlParameter("@iHysczzl",SqlDbType.NVarChar,100),//--行业市场增长率
                                new SqlParameter("@iZcfzl",SqlDbType.NVarChar,100) //--资产负债率
            };
            parameters[0].Value = model.MainInfoModel.InfoID;
            parameters[1].Value = model.MainInfoModel.Title;
            parameters[2].Value = model.MainInfoModel.publishT;
            parameters[3].Value = model.MainInfoModel.LoginName;

            parameters[4].Value = model.MainInfoModel.KeyWord;
            parameters[5].Value = model.MainInfoModel.Descript;
            parameters[6].Value = model.MainInfoModel.DisplayTitle;
            parameters[7].Value = model.MainInfoModel.FrontDisplayTime;
            parameters[8].Value = model.MainInfoModel.ValidateStartTime;
            parameters[9].Value = model.MainInfoModel.ValidateTerm;
            parameters[10].Value = model.MainInfoModel.TemplateID;
            parameters[11].Value = model.MainInfoModel.HtmlFile;

            parameters[12].Value = model.ProjectInfoModel.ProjectName;
            parameters[13].Value = model.ProjectInfoModel.ProjectNameBrief;
            parameters[14].Value = model.ProjectInfoModel.ComAbout;
            parameters[15].Value = model.ProjectInfoModel.ComBrief;
            parameters[16].Value = model.ProjectInfoModel.CountryCode;
            parameters[17].Value = model.ProjectInfoModel.ProvinceID;
            parameters[18].Value = model.ProjectInfoModel.CityID;
            parameters[19].Value = model.ProjectInfoModel.CountyID;
            parameters[20].Value = model.ProjectInfoModel.IndustryBID;
            parameters[21].Value = model.ProjectInfoModel.CooperationDemandType;
            parameters[22].Value = model.ProjectInfoModel.CapitalCurrency;
            parameters[23].Value = model.ProjectInfoModel.CapitalTotal;
            parameters[24].Value = model.ProjectInfoModel.ProjectCurrency;
            parameters[25].Value = model.ProjectInfoModel.CapitalID;

            parameters[26].Value = model.InfoContactModel.OrganizationName;
            parameters[27].Value = model.InfoContactModel.Name;
            parameters[28].Value = model.InfoContactModel.Career;
            parameters[29].Value = model.InfoContactModel.TelStateCode;
            parameters[30].Value = model.InfoContactModel.TelNum;
            parameters[31].Value = model.InfoContactModel.Mobile;
            parameters[32].Value = model.InfoContactModel.Address;
            parameters[33].Value = model.InfoContactModel.PostCode;
            parameters[34].Value = model.InfoContactModel.Email;
            parameters[35].Value = model.InfoContactModel.WebSite;

            parameters[36].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[37].Value = model.ShortInfoModel.ShortTitle;
            parameters[38].Value = model.ShortInfoModel.ShortContent;
            parameters[39].Value = model.ShortInfoModel.Remark;

            parameters[40].Value = model.ProjectInfoModel.IsRec;
            parameters[41].Value = model.ProjectInfoModel.IsTop;
            parameters[42].Value = model.ProjectInfoModel.RecTime;
            parameters[43].Value = model.ProjectInfoModel.RecRemark;
            parameters[44].Value = model.ProjectInfoModel.RecTerm;

            parameters[45].Value = model.ProjectInfoModel.warrant;

            parameters[46].Value = model.ProjectInfoModel.marketAbout;

            parameters[47].Value = model.ProjectInfoModel.nDwlyysy;//单位年营业收入
            parameters[48].Value = model.ProjectInfoModel.nDwljly; //单位年净利润
            parameters[49].Value = model.ProjectInfoModel.nDwzzc;//单位总资产
            parameters[50].Value = model.ProjectInfoModel.nDwzfz;//单位总负债

            parameters[51].Value = model.ProjectInfoModel.financingID;
            parameters[52].Value = "UpdateZQ";

            //201006资源超市第二次改版，新增字段
            parameters[53].Value = model.ProjectInfoModel.cZqXmlxqkb;   //--	项目立项情况
            parameters[54].Value = model.ProjectInfoModel.cZqQyfzjd;    //--企业发展阶段
            parameters[55].Value = model.ProjectInfoModel.iZqYqjjdwqk;    //--要求资金到位情况
            parameters[56].Value = model.ProjectInfoModel.iZqCpsczzl;    //--产品市场增长率
            parameters[57].Value = model.ProjectInfoModel.iZqCpscYl;    //--产品市场容量
            parameters[58].Value = model.ProjectInfoModel.iZqZcfzl;    //--资产负债率
            parameters[59].Value = model.ProjectInfoModel.iZqYdbl;    //--流动比率
            parameters[60].Value = model.ProjectInfoModel.iZqTzsl;    //--投资收益率
            parameters[61].Value = model.ProjectInfoModel.iZqXslyl;    //--销售利润率
            parameters[62].Value = model.ProjectInfoModel.iZqTzfbq;    //--投资回报期
            parameters[63].Value = model.ProjectInfoModel.iZqXmyxqs;    //--项目有效期限
            parameters[64].Value = model.ProjectInfoModel.cZqXmzy;    //--项目摘要
            parameters[65].Value = model.ProjectInfoModel.cZqXmgjz;    //--项目关键字
            parameters[66].Value = model.ProjectInfoModel.cZqCpks;    //--产品概述

            parameters[67].Value = model.ProjectInfoModel.cZqJzfx;    //--竞争分析
            parameters[68].Value = model.ProjectInfoModel.cZqSyms;    //--商业模式
            parameters[69].Value = model.ProjectInfoModel.cZqGltd;    //--管理团队
            parameters[70].Value = model.ProjectInfoModel.InformationIntegrity;    //--信息完整度
            //-------END---------------------------
            parameters[71].Value = model.ProjectInfoModel.iSczylfy;    //--市场占有率(份额)
            parameters[72].Value = model.ProjectInfoModel.iHysczzl;    //--行业市场增长率
            parameters[73].Value = model.ProjectInfoModel.iZcfzl;    //--资产负债率

            bool ReturnValue = false;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //修改项目信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_Update", parameters, out rowsAffected);

                    //将上传文件
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        //删除原有资源
                        obj3.DeleteByInfoID(sqlConn, sqlTran, model.MainInfoModel.InfoID);
                        foreach (Tz888.Model.Info.InfoResourceModel Infomodel in infoResourceModels)
                        {
                            Infomodel.InfoID = model.MainInfoModel.InfoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, Infomodel, 1))
                                iUploadCount += 1;
                        }
                        //没有成功
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            ReturnValue = false;
                        }
                    }
                    sqlTran.Commit();
                    sqlConn.Close();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion

        #region 股权 发布 第一步
        public long PublishProjectGQ1(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.ProjectInfoModel projectInfoModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@publishT", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.BigInt,8),

					new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@IndexOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@IndexTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@IndexPicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@InfoTypePicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoOriginRoleName", SqlDbType.Char,10),
					new SqlParameter("@GradeID", SqlDbType.Char,10),
					new SqlParameter("@FixPriceID", SqlDbType.Char,10),
					new SqlParameter("@FeeStatus", SqlDbType.TinyInt,1),

					new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------融资(项目)资源个性信息-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------新属性--------------------------

				
					new SqlParameter("@SellStockShare", SqlDbType.Int),
                    new SqlParameter("@ReturnModeID", SqlDbType.VarChar,20),
                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
					
                //---------------------------END---------------------------

                //-------------------------短信息--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------优质项目信息--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------------201006资源超市第二次改版，新增加的字段-------------------
                new SqlParameter("@cXmlxqk",SqlDbType.VarChar,20), //项目立项情况
                new SqlParameter("@cXmgjz",SqlDbType.NVarChar,100), //项目关键字
                new SqlParameter("@cQyfzjd",SqlDbType.VarChar,20), //企业发展阶段
                new SqlParameter("@iyqzjdwqk",SqlDbType.Int),//要求资金到位情况
                new SqlParameter("@iSczylfy",SqlDbType.Int), //市场占有率(份额)
                new SqlParameter("@iHysczzl",SqlDbType.Int), //行业市场增长率
                new SqlParameter("@iZcfzl",SqlDbType.Int), //资产负债率
                new SqlParameter("@ixmtzfbzq",SqlDbType.Int), //项目投资回报周期
                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //单位年营业收入
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //单位年净利润
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //单位总资产
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //单位总负债
                new SqlParameter("@cXmqxms",SqlDbType.NVarChar,1000), //项目详细描术
                //-------------------------END-----------------------------------


                //-------------将以前的第二步的内容，改为第一步里----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------
                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //信息完整度

            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = mainInfoModel.IndexOrderNum;
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum;
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum;
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;
            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;
            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID;
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = mainInfoModel.KeyWord;
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //新属性

            parameters[39].Value = projectInfoModel.SellStockShare;
            parameters[40].Value = projectInfoModel.ReturnModeID;
            parameters[41].Value = projectInfoModel.financingID;

            parameters[42].Value = shortInfoModel.ShortInfoControlID;
            parameters[43].Value = shortInfoModel.ShortTitle;
            parameters[44].Value = shortInfoModel.ShortContent;
            parameters[45].Value = shortInfoModel.Remark;

            parameters[46].Value = projectInfoModel.IsRec;
            parameters[47].Value = projectInfoModel.IsTop;
            parameters[48].Value = projectInfoModel.RecTime;
            parameters[49].Value = projectInfoModel.RecRemark;
            parameters[50].Value = projectInfoModel.RecTerm;
            parameters[51].Value = "project_gq1";


            //-------------------201006资源超市第二次改版，新增加的字段
            parameters[52].Value = projectInfoModel.sXmlxqk;  //项目立项情况
            parameters[53].Value = projectInfoModel.sXmgjz;     //项目关键字
            parameters[54].Value = projectInfoModel.sQyfzjd;//企业发展阶段
            parameters[55].Value = projectInfoModel.iYqzjdwqk;//要求资金到位情况
            parameters[56].Value = projectInfoModel.iSczylfy;//市场占有率(份额)
            parameters[57].Value = projectInfoModel.iHysczzl;//行业市场增长率
            parameters[58].Value = projectInfoModel.iZcfzl;//资产负债率
            parameters[59].Value = projectInfoModel.iXmtzfbzq;//项目投资回报周期
            parameters[60].Value = projectInfoModel.nDwlyysy;//单位年营业收入
            parameters[61].Value = projectInfoModel.nDwljly;//单位年净利润
            parameters[62].Value = projectInfoModel.nDwzzc;//单位总资产
            parameters[63].Value = projectInfoModel.nDwzfz;//单位总负债
            parameters[64].Value = projectInfoModel.sXmqxms;//项目详细描术
            //-------------------END---------------------------------------


            //-------------将以前的第二步的内容，改为第一步里----------
            parameters[65].Value = projectInfoModel.ProjectAbout;
            parameters[66].Value = projectInfoModel.marketAbout;
            parameters[67].Value = projectInfoModel.competitioAbout;
            parameters[68].Value = projectInfoModel.BussinessModeAbout;
            parameters[69].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------
            parameters[70].Value = projectInfoModel.InformationIntegrity; //信息完整度


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_gq_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }
        #endregion

        #region 股权 发布 第一步_新方法（包括上件文件)
        public long PublishProjectGQ1(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.ProjectInfoModel projectInfoModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel,
           List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@publishT", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.BigInt,8),

					new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@IndexOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@IndexTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@IndexPicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@InfoTypePicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoOriginRoleName", SqlDbType.Char,10),
					new SqlParameter("@GradeID", SqlDbType.Char,10),
					new SqlParameter("@FixPriceID", SqlDbType.Char,10),
					new SqlParameter("@FeeStatus", SqlDbType.TinyInt,1),

					new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------融资(项目)资源个性信息-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------新属性--------------------------

				
					new SqlParameter("@SellStockShare", SqlDbType.Int),
                    new SqlParameter("@ReturnModeID", SqlDbType.VarChar,20),
                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
					
                //---------------------------END---------------------------

                //-------------------------短信息--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------优质项目信息--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------------201006资源超市第二次改版，新增加的字段-------------------
                new SqlParameter("@cXmlxqk",SqlDbType.VarChar,20), //项目立项情况
                new SqlParameter("@cXmgjz",SqlDbType.NVarChar,100), //项目关键字
                new SqlParameter("@cQyfzjd",SqlDbType.VarChar,20), //企业发展阶段
                new SqlParameter("@iyqzjdwqk",SqlDbType.Int),//要求资金到位情况
                new SqlParameter("@iSczylfy",SqlDbType.Int), //市场占有率(份额)
                new SqlParameter("@iHysczzl",SqlDbType.Int), //行业市场增长率
                new SqlParameter("@iZcfzl",SqlDbType.Int), //资产负债率
                new SqlParameter("@ixmtzfbzq",SqlDbType.Int), //项目投资回报周期
                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //单位年营业收入
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //单位年净利润
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //单位总资产
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //单位总负债
                new SqlParameter("@cXmqxms",SqlDbType.NVarChar,1000), //项目详细描术
                //-------------------------END-----------------------------------


                //-------------将以前的第二步的内容，改为第一步里----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------
                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //信息完整度

            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = mainInfoModel.IndexOrderNum;
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum;
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum;
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;
            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;
            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID;
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = mainInfoModel.KeyWord;
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //新属性

            parameters[39].Value = projectInfoModel.SellStockShare;
            parameters[40].Value = projectInfoModel.ReturnModeID;
            parameters[41].Value = projectInfoModel.financingID;

            parameters[42].Value = shortInfoModel.ShortInfoControlID;
            parameters[43].Value = shortInfoModel.ShortTitle;
            parameters[44].Value = shortInfoModel.ShortContent;
            parameters[45].Value = shortInfoModel.Remark;

            parameters[46].Value = projectInfoModel.IsRec;
            parameters[47].Value = projectInfoModel.IsTop;
            parameters[48].Value = projectInfoModel.RecTime;
            parameters[49].Value = projectInfoModel.RecRemark;
            parameters[50].Value = projectInfoModel.RecTerm;
            parameters[51].Value = "project_gq1";


            //-------------------201006资源超市第二次改版，新增加的字段
            parameters[52].Value = projectInfoModel.sXmlxqk;  //项目立项情况
            parameters[53].Value = projectInfoModel.sXmgjz;     //项目关键字
            parameters[54].Value = projectInfoModel.sQyfzjd;//企业发展阶段
            parameters[55].Value = projectInfoModel.iYqzjdwqk;//要求资金到位情况
            parameters[56].Value = projectInfoModel.iSczylfy;//市场占有率(份额)
            parameters[57].Value = projectInfoModel.iHysczzl;//行业市场增长率
            parameters[58].Value = projectInfoModel.iZcfzl;//资产负债率
            parameters[59].Value = projectInfoModel.iXmtzfbzq;//项目投资回报周期
            parameters[60].Value = projectInfoModel.nDwlyysy;//单位年营业收入
            parameters[61].Value = projectInfoModel.nDwljly;//单位年净利润
            parameters[62].Value = projectInfoModel.nDwzzc;//单位总资产
            parameters[63].Value = projectInfoModel.nDwzfz;//单位总负债
            parameters[64].Value = projectInfoModel.sXmqxms;//项目详细描术
            //-------------------END---------------------------------------


            //-------------将以前的第二步的内容，改为第一步里----------
            parameters[65].Value = projectInfoModel.ProjectAbout;
            parameters[66].Value = projectInfoModel.marketAbout;
            parameters[67].Value = projectInfoModel.competitioAbout;
            parameters[68].Value = projectInfoModel.BussinessModeAbout;
            parameters[69].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------
            parameters[70].Value = projectInfoModel.InformationIntegrity; //信息完整度


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_gq_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();


                    //将上传文件
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, model, 1))
                                iUploadCount += 1;
                        }
                        //没有成功
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            return 0;
                        }
                    }


                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }
        #endregion



        #region 股权 发布 第二步
        public bool PublishProjectGQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                    new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
					new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
					new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
					new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
				    new SqlParameter("@flag", SqlDbType.VarChar,30),
            };
            parameters[0].Value = projectInfoModel.InfoID;
            parameters[1].Value = projectInfoModel.ProjectAbout;
            parameters[2].Value = projectInfoModel.marketAbout;
            parameters[3].Value = projectInfoModel.competitioAbout;
            parameters[4].Value = projectInfoModel.BussinessModeAbout;
            parameters[5].Value = projectInfoModel.ManageTeamAbout;
            parameters[6].Value = "project_gq2";

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    int rowsAffected = 0;
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_gq_Insert", parameters, out rowsAffected);

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return true;
        }
        #endregion

        #region 股权修改
        public bool ProjectInfoGQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                                    //主表信息
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10),

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    
                                    //项目信息
                                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					                new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					                new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Float,8),
                                    
                                    //联系信息
					                new SqlParameter("@ComName", SqlDbType.VarChar,100),
					                new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
                                    new SqlParameter("@Career", SqlDbType.VarChar,20),
					                new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					                new SqlParameter("@TelNum", SqlDbType.VarChar,100),
                                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					                new SqlParameter("@Address", SqlDbType.VarChar,100),
					                new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					                new SqlParameter("@Email", SqlDbType.VarChar,50),
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                                    
                                    //短信息表
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                                //-------------------------优质项目信息--------------------------
                	                new SqlParameter("@IsRec", SqlDbType.Bit,1),
					                new SqlParameter("@IsTop", SqlDbType.Bit,1),
					                new SqlParameter("@RecTime", SqlDbType.DateTime),
					                new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					                new SqlParameter("@RecTerm", SqlDbType.Int,4),
                                //---------------------------新属性---------------------------
                                    new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                                    new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
					                new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
					                new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
					                new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
                                    new SqlParameter("@SellStockShare",SqlDbType.TinyInt),
                                    new SqlParameter("@ReturnModeID",SqlDbType.VarChar,50),
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
                                   //201006资源超市第二次改版，新增字段
                                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//--	项目立项情况
                                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //--企业发展阶段
                                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int,4),  //--要求资金到位情况
                                new SqlParameter("@iZqCpsczzl",SqlDbType.Int,4),   //--产品市场增长率
                                new SqlParameter("@iZqCpscYl",SqlDbType.Int,4),    //--产品市场容量
                                new SqlParameter("@iZqZcfzl",SqlDbType.Int,4),     //--资产负债率
                                new SqlParameter("@iZqYdbl",SqlDbType.Int,4),      //--流动比率
                                new SqlParameter("@iZqTzsl",SqlDbType.Int,4),     //--投资收益率
                                new SqlParameter("@iZqXslyl",SqlDbType.Int,4),     //--销售利润率
                                new SqlParameter("@iZqTzfbq",SqlDbType.Int,4),     //--投资回报期
                                new SqlParameter("@iZqXmyxqs",SqlDbType.Int,4),    //--项目有效期限
                                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//--项目摘要
                                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//--项目关键字
                                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//--产品概述-----------
                                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//--竞争分析
                                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//--商业模式
                                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//--管理团队
                                //-------END---------------------------
                                new SqlParameter("@iInformationIntegrity",SqlDbType.Int,4), //--信息完整度   
                                //修改属性
                                new SqlParameter("@CompanyYearIncome",  model.ProjectInfoModel.CompanyYearIncome),
					            new SqlParameter("@CompanyNG", model.ProjectInfoModel.CompanyNG),
					            new SqlParameter("@CompanyTotalCapital",model.ProjectInfoModel.CompanyTotalCapital),
					            new SqlParameter("@CompanyTotalDebet",  model.ProjectInfoModel.CompanyTotalDebet),
                                //股权
                                new SqlParameter("@iSczylfy",model.ProjectInfoModel.iSczylfy),   //--市场占有率(份额)
                                new SqlParameter("@iHysczzl",model.ProjectInfoModel.iHysczzl),  //行业市场增长率
                                new SqlParameter("@iZcfzl",model.ProjectInfoModel.iZcfzl)   //资产负债率
            };
            parameters[0].Value = model.MainInfoModel.InfoID;
            parameters[1].Value = model.MainInfoModel.Title;
            parameters[2].Value = model.MainInfoModel.publishT;
            parameters[3].Value = model.MainInfoModel.LoginName;

            parameters[4].Value = model.MainInfoModel.KeyWord;
            parameters[5].Value = model.MainInfoModel.Descript;
            parameters[6].Value = model.MainInfoModel.DisplayTitle;
            parameters[7].Value = model.MainInfoModel.FrontDisplayTime;
            parameters[8].Value = model.MainInfoModel.ValidateStartTime;
            parameters[9].Value = model.MainInfoModel.ValidateTerm;
            parameters[10].Value = model.MainInfoModel.TemplateID;
            parameters[11].Value = model.MainInfoModel.HtmlFile;

            parameters[12].Value = model.ProjectInfoModel.ProjectName;
            parameters[13].Value = model.ProjectInfoModel.ProjectNameBrief;
            parameters[14].Value = model.ProjectInfoModel.ComAbout;
            parameters[15].Value = model.ProjectInfoModel.ComBrief;
            parameters[16].Value = model.ProjectInfoModel.CountryCode;
            parameters[17].Value = model.ProjectInfoModel.ProvinceID;
            parameters[18].Value = model.ProjectInfoModel.CityID;
            parameters[19].Value = model.ProjectInfoModel.CountyID;
            parameters[20].Value = model.ProjectInfoModel.IndustryBID;
            parameters[21].Value = model.ProjectInfoModel.CooperationDemandType;
            parameters[22].Value = model.ProjectInfoModel.CapitalCurrency;
            parameters[23].Value = model.ProjectInfoModel.CapitalTotal;
            parameters[24].Value = model.ProjectInfoModel.ProjectCurrency;
            parameters[25].Value = model.ProjectInfoModel.CapitalID;

            parameters[26].Value = model.InfoContactModel.OrganizationName;
            parameters[27].Value = model.InfoContactModel.Name;
            parameters[28].Value = model.InfoContactModel.Career;
            parameters[29].Value = model.InfoContactModel.TelStateCode;
            parameters[30].Value = model.InfoContactModel.TelNum;
            parameters[31].Value = model.InfoContactModel.Mobile;
            parameters[32].Value = model.InfoContactModel.Address;
            parameters[33].Value = model.InfoContactModel.PostCode;
            parameters[34].Value = model.InfoContactModel.Email;
            parameters[35].Value = model.InfoContactModel.WebSite;

            parameters[36].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[37].Value = model.ShortInfoModel.ShortTitle;
            parameters[38].Value = model.ShortInfoModel.ShortContent;
            parameters[39].Value = model.ShortInfoModel.Remark;

            parameters[40].Value = model.ProjectInfoModel.IsRec;
            parameters[41].Value = model.ProjectInfoModel.IsTop;
            parameters[42].Value = model.ProjectInfoModel.RecTime;
            parameters[43].Value = model.ProjectInfoModel.RecRemark;
            parameters[44].Value = model.ProjectInfoModel.RecTerm;

            parameters[45].Value = model.ProjectInfoModel.ProjectAbout;
            parameters[46].Value = model.ProjectInfoModel.marketAbout;
            parameters[47].Value = model.ProjectInfoModel.competitioAbout;
            parameters[48].Value = model.ProjectInfoModel.BussinessModeAbout;
            parameters[49].Value = model.ProjectInfoModel.ManageTeamAbout;
            parameters[50].Value = model.ProjectInfoModel.financingID;
            parameters[51].Value = model.ProjectInfoModel.SellStockShare;
            parameters[52].Value = model.ProjectInfoModel.ReturnModeID;
            parameters[53].Value = "UpdateGQ";

            //201006资源超市第二次改版，新增字段
            parameters[54].Value = model.ProjectInfoModel.cZqXmlxqkb;   //--	项目立项情况
            parameters[55].Value = model.ProjectInfoModel.cZqQyfzjd;    //--企业发展阶段
            parameters[56].Value = model.ProjectInfoModel.iZqYqjjdwqk;    //--要求资金到位情况
            parameters[57].Value = model.ProjectInfoModel.iZqCpsczzl;    //--产品市场增长率
            parameters[58].Value = model.ProjectInfoModel.iZqCpscYl;    //--产品市场容量
            parameters[59].Value = model.ProjectInfoModel.iZqZcfzl;    //--资产负债率
            parameters[60].Value = model.ProjectInfoModel.iZqYdbl;    //--流动比率
            parameters[61].Value = model.ProjectInfoModel.iZqTzsl;    //--投资收益率
            parameters[62].Value = model.ProjectInfoModel.iZqXslyl;    //--销售利润率
            parameters[63].Value = model.ProjectInfoModel.iXmtzfbzq;    //--投资回报期
            parameters[64].Value = model.ProjectInfoModel.iZqXmyxqs;    //--项目有效期限
            parameters[65].Value = model.ProjectInfoModel.cZqXmzy;    //--项目摘要
            parameters[66].Value = model.ProjectInfoModel.cZqXmgjz;    //--项目关键字
            parameters[67].Value = model.ProjectInfoModel.ProjectAbout;    //--产品概述

            parameters[68].Value = model.ProjectInfoModel.competitioAbout;    //--竞争分析
            parameters[69].Value = model.ProjectInfoModel.BussinessModeAbout;    //--商业模式
            parameters[70].Value = model.ProjectInfoModel.ManageTeamAbout;    //--管理团队
            parameters[71].Value = model.ProjectInfoModel.InformationIntegrity;    //--信息完整度
            //-------END---------------------------

            bool ReturnValue = false;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //修改项目信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_Update", parameters, out rowsAffected);

                    //将上传文件
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        //删除原有资源
                        obj3.DeleteByInfoID(sqlConn, sqlTran, model.MainInfoModel.InfoID);
                        foreach (Tz888.Model.Info.InfoResourceModel Infomodel in infoResourceModels)
                        {
                            Infomodel.InfoID = model.MainInfoModel.InfoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, Infomodel, 1))
                                iUploadCount += 1;
                        }
                        //没有成功
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            ReturnValue = false;
                        }
                    }
                    sqlTran.Commit();
                    sqlConn.Close();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion

        public int FormatData(string strData)
        {
            int iData = 0;
            if (strData.Trim() == "")
                iData = 0;
            try
            {
                iData = Convert.ToInt32(strData);
            }
            catch
            {
                iData = 0;
            }
            return iData;
        }

        /// <summary>
        /// 判断是否是正数
        /// </summary>
        /// <param name="str">参数值</param>
        /// <returns>返回true 或false</returns>
        public static bool IsNumber(string str)
        {
            try
            {
                decimal rest = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;

            }
        }

        /// <summary>
        /// 说明：判断是否是数字
        /// </summary>
        /// <param name="str">参数值</param>
        /// <returns>返回true 或false</returns>
        public static bool IsDecimal(string str)
        {
            try
            {
                decimal rest = Convert.ToDecimal(str);
                return true;
            }
            catch
            {
                return false;

            }
        }



        #region IProjectInfo 成员
        /// <summary>
        /// 最新添加股权融资
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <returns></returns>
        public long InsertNew(MainInfoModel mainInfoModel, ProjectInfoModel projectInfoModel, InfoContactModel infoContactModel, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@publishT", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.BigInt,8),

					new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@IndexOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@IndexTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@IndexPicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeOrderNum", SqlDbType.BigInt,8),
					new SqlParameter("@InfoTypeTopValidateDate", SqlDbType.Int,4),
					new SqlParameter("@InfoTypePicInfoNum", SqlDbType.BigInt,8),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoOriginRoleName", SqlDbType.Char,10),
					new SqlParameter("@GradeID", SqlDbType.Char,10),
					new SqlParameter("@FixPriceID", SqlDbType.Char,10),
					new SqlParameter("@FeeStatus", SqlDbType.TinyInt,1),

					new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------融资(项目)资源个性信息-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------资源联系信息--------------------------

					new SqlParameter("@ComName", SqlDbType.VarChar,40),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
					new SqlParameter("@TelStateCode", SqlDbType.Char,4),
					new SqlParameter("@TelNum", SqlDbType.VarChar,60),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,3),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,4),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,60),

					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                    new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),


            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value = mainInfoModel.IsCore;
            parameters[6].Value = mainInfoModel.IndexOrderNum;
            parameters[7].Value = mainInfoModel.IndexTopValidateDate;
            parameters[8].Value = mainInfoModel.IndexPicInfoNum;
            parameters[9].Value = mainInfoModel.InfoTypeOrderNum;
            parameters[10].Value = mainInfoModel.InfoTypeTopValidateDate;
            parameters[11].Value = mainInfoModel.InfoTypePicInfoNum;
            parameters[12].Value = mainInfoModel.LoginName;
            parameters[13].Value = mainInfoModel.InfoOriginRoleName;
            parameters[14].Value = mainInfoModel.GradeID;
            parameters[15].Value = mainInfoModel.FixPriceID;
            parameters[16].Value = mainInfoModel.FeeStatus;

            parameters[17].Value = mainInfoModel.KeyWord;
            parameters[18].Value = mainInfoModel.Descript;
            parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.ValidateTerm;
            parameters[23].Value = mainInfoModel.TemplateID;
            parameters[24].Value = mainInfoModel.HtmlFile;

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            parameters[39].Value = infoContactModel.OrganizationName;
            parameters[40].Value = infoContactModel.Name;
            parameters[41].Value = infoContactModel.TelCountryCode;
            parameters[42].Value = infoContactModel.TelStateCode;
            parameters[43].Value = infoContactModel.TelNum;
            parameters[44].Value = infoContactModel.FaxCountryCode;
            parameters[45].Value = infoContactModel.FaxStateCode;
            parameters[46].Value = infoContactModel.FaxNum;
            parameters[47].Value = infoContactModel.Mobile;
            parameters[48].Value = infoContactModel.Address;
            parameters[49].Value = infoContactModel.PostCode;
            parameters[50].Value = infoContactModel.Email;
            parameters[51].Value = infoContactModel.WebSite;
            parameters[52].Value = projectInfoModel.ManageTeamAbout;


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_InfoResource_InsertNew, parameters, out rowsAffected);
                     //将上传文件
                
                    //DbHelperSQL.RunProcedure(SP_ProjectInfo_Insert, parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //记录上传数
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        //删除原有资源
                        obj3.DeleteByInfoID(sqlConn, sqlTran, infoID);
                        foreach (Tz888.Model.Info.InfoResourceModel Infomodel in infoResourceModels)
                        {
                            Infomodel.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, Infomodel, 1))
                                iUploadCount += 1;
                        }
                    }
                    if (infoID < 0)
                        return -1;
                  sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    infoID = -1;
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return infoID;
        }

        #endregion
    }
}
