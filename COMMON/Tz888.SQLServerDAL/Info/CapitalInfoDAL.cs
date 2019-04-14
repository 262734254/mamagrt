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
    /// 投资信息数据库访问逻辑类
    /// </summary>
    public class CapitalInfoDAL : ICapitalInfo
    {
        private const string SP_CapitalInfoInfo_Insert = "CapitalInfoTab_Insert";

        #region 添加投资资源
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.CapitalInfoModel capitalInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels,
           // List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
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

                //--------------------投资资源个性信息---------------------

                    new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBreif", SqlDbType.VarChar,-1),
                    //new SqlParameter("@CountryCode", SqlDbType.Char,10),
                    //new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    //new SqlParameter("@CityID", SqlDbType.Char,10),
                    //new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,30),
					new SqlParameter("@currency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Char,10),
					new SqlParameter("@CapitalTypeID", SqlDbType.Char,10),

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
                    new SqlParameter ("@RegisteredCapital",SqlDbType.Char,30),
                    

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

            parameters[25].Value = capitalInfoModel.ComAbout;
            parameters[26].Value = capitalInfoModel.ComBreif;
            //parameters[25].Value = capitalInfoModel.CountryCode;
            //parameters[26].Value = capitalInfoModel.ProvinceID;
            //parameters[27].Value = capitalInfoModel.CityID;
            //parameters[28].Value = capitalInfoModel.CountyID;
            parameters[27].Value = capitalInfoModel.IndustryBID;
            parameters[28].Value = capitalInfoModel.CooperationDemandType;
            parameters[29].Value = capitalInfoModel.Currency;
            parameters[30].Value = capitalInfoModel.CapitalID;
            parameters[31].Value = capitalInfoModel.CapitalTypeID;

            parameters[32].Value = infoContactModel.OrganizationName;
            parameters[33].Value = infoContactModel.Name;
            parameters[34].Value = infoContactModel.TelCountryCode;
            parameters[35].Value = infoContactModel.TelStateCode;
            parameters[36].Value = infoContactModel.TelNum;
            parameters[37].Value = infoContactModel.FaxCountryCode;
            parameters[38].Value = infoContactModel.FaxStateCode;
            parameters[39].Value = infoContactModel.FaxNum;
            parameters[40].Value = infoContactModel.Mobile;
            parameters[41].Value = infoContactModel.Address;
            parameters[42].Value = infoContactModel.PostCode;
            parameters[43].Value = infoContactModel.Email;
            parameters[44].Value = infoContactModel.WebSite;

            parameters[45].Value = shortInfoModel.ShortInfoControlID;
            parameters[46].Value = shortInfoModel.ShortTitle;
            parameters[47].Value = shortInfoModel.ShortContent;
            parameters[48].Value = shortInfoModel.Remark;
            parameters[49].Value = capitalInfoModel.IsVip;
            parameters[50].Value = capitalInfoModel.RegisteredCapital;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入投资资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_CapitalInfoInfo_Insert, parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    string countrycode = "";
                    string ProvinceID = "";
                    string CityID = "";
                    string countyID = "";

                    if (capitalInfoAreaModels != null)
                    {

                        //为投资信息添加多个投资区域
                        Tz888.SQLServerDAL.Info.CapitalInfoAreaDAL obj1 = new CapitalInfoAreaDAL();
                        foreach (Tz888.Model.Info.CapitalInfoAreaModel model in capitalInfoAreaModels)
                        {
                            model.InfoID = infoID;
                            obj1.Insert(sqlConn, sqlTran, model);

                            if (!string.IsNullOrEmpty(model.CountryCode))
                                countrycode += model.CountryCode.Trim() + ",";
                            if (!string.IsNullOrEmpty(model.ProvinceID))
                                ProvinceID += model.ProvinceID.Trim() + ",";
                            if (!string.IsNullOrEmpty(model.CityID))
                                CityID += model.CityID.Trim() + ",";
                            if (!string.IsNullOrEmpty(model.CountyID))
                                countyID += model.CountyID.Trim() + ",";
                        }

                        //序列化投资区域信息
                        this.CapitalInfoAreaQuery(infoID, countrycode, ProvinceID, CityID, countyID);
                    }

                    //if (infoContactManModels != null)
                    //{
                    //    //为投资资源添加多个联系人
                    //    Tz888.SQLServerDAL.Info.InfoContactManDAL obj2 = new InfoContactManDAL();
                    //    foreach (Tz888.Model.Info.InfoContactManModel model in infoContactManModels)
                    //    {
                    //        model.InfoID = infoID;
                    //        obj2.InsertContactMan(sqlConn, sqlTran, model);
                    //    }
                    //}

                    if (infoResourceModels != null)
                    {
                        //为投资信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            obj3.InsertInfoResource(sqlConn, sqlTran, model);
                        }
                    }

                    sqlTran.Commit();
                }
                catch
                {
                    sqlTran.Rollback();
                    infoID = -1;
                }
                finally
                {
                    sqlConn.Close();
                }
            }

            return infoID;
        }
        #endregion

        #region 修改投资资源
        /// <summary>
        /// 修改投资资源
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.CapitalSetModel model)
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
                                    //new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    new SqlParameter ("@AuditingStatus",SqlDbType.TinyInt,8),

                                    //投资资源表信息
                                    new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
					                new SqlParameter("@ComBreif", SqlDbType.VarChar,-1),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,30),
					                new SqlParameter("@currency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTypeID", SqlDbType.Char,10),

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

                                    //短信息
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                                    new SqlParameter("@IsVip", SqlDbType.Int), 

                                    //投资资源表信息 2010-7-7修改
                                    new SqlParameter ("@RegisteredCapital",SqlDbType.Char,30),
                                    new SqlParameter ("@TeamScale",SqlDbType.Char,30),
                                    new SqlParameter ("@AverageInvestment",SqlDbType.Char,30),
                                    new SqlParameter("@SuccessfulInvestment",SqlDbType.Char,30),
                                    new SqlParameter("@InvestmentDemand",SqlDbType.VarChar,100),
                                    new SqlParameter("@Prorganizers",SqlDbType.VarChar,100),
                                    new SqlParameter("@CountryID",SqlDbType.Char,30),
                                    new SqlParameter("@ProvinceID",SqlDbType.Char,30),
                                    new SqlParameter("@CityID",SqlDbType.Char,30),
                                    new SqlParameter("@CountyID",SqlDbType.Char,30),
                                    new SqlParameter ("@Position",SqlDbType.VarChar,50)
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
            //parameters[11].Value = model.MainInfoModel.HtmlFile;
            parameters[11].Value = model.MainInfoModel.AuditingStatus;

            parameters[12].Value = model.CapitalInfoModel.ComAbout;
            parameters[13].Value = model.CapitalInfoModel.ComBreif;
            parameters[14].Value = model.CapitalInfoModel.IndustryBID;
            parameters[15].Value = model.CapitalInfoModel.CooperationDemandType;
            parameters[16].Value = model.CapitalInfoModel.Currency;
            parameters[17].Value = model.CapitalInfoModel.CapitalID;
            parameters[18].Value = model.CapitalInfoModel.CapitalTypeID;

            parameters[19].Value = model.InfoContactModel.OrganizationName;
            parameters[20].Value = model.InfoContactModel.Name;
            parameters[21].Value = model.InfoContactModel.TelCountryCode;
            parameters[22].Value = model.InfoContactModel.TelStateCode;
            parameters[23].Value = model.InfoContactModel.TelNum;
            parameters[24].Value = model.InfoContactModel.FaxCountryCode;
            parameters[25].Value = model.InfoContactModel.FaxStateCode;
            parameters[26].Value = model.InfoContactModel.FaxNum;
            parameters[27].Value = model.InfoContactModel.Mobile;
            parameters[28].Value = model.InfoContactModel.Address;
            parameters[29].Value = model.InfoContactModel.PostCode;
            parameters[30].Value = model.InfoContactModel.Email;
            parameters[31].Value = model.InfoContactModel.WebSite;

            parameters[32].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[33].Value = model.ShortInfoModel.ShortTitle;
            parameters[34].Value = model.ShortInfoModel.ShortContent;
            parameters[35].Value = model.ShortInfoModel.Remark;
            parameters[36].Value = model.CapitalInfoModel.IsVip;

            parameters[37].Value = model.CapitalInfoModel.RegisteredCapital;
            parameters[38].Value = model.CapitalInfoModel.TeamScale;
            parameters[39].Value = model.CapitalInfoModel.AverageInvestment;
            parameters[40].Value = model.CapitalInfoModel.SuccessfulInvestment;
            parameters[41].Value = model.CapitalInfoModel.InvestmentDemand;
            parameters[42].Value = model.CapitalInfoModel.Prorganizers;
            parameters[43].Value = model.CapitalInfoModel.SCountryID;
            parameters[44].Value = model.CapitalInfoModel.SProvinceID;
            parameters[45].Value = model.CapitalInfoModel.SCityID;
            parameters[46].Value = model.CapitalInfoModel.SCountyID;
            parameters[47].Value = model.InfoContactModel.Position;

            bool ReturnValue = false;
            long infoID = model.MainInfoModel.InfoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //插入投资资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "CapitalInfoTab_Update", parameters, out rowsAffected);

                    string countrycode = "";
                    string ProvinceID = "";
                    string CityID = "";
                    string countyID = "";

                    //为投资资源更新投资区域信息
                    Tz888.SQLServerDAL.Info.CapitalInfoAreaDAL obj1 = new CapitalInfoAreaDAL();
                    obj1.DeleteByInfoID(sqlConn, sqlTran, infoID);
                    if (model.CapitalInfoAreaModels != null)
                    {
                        foreach (Tz888.Model.Info.CapitalInfoAreaModel tmpModel in model.CapitalInfoAreaModels)
                        {
                            tmpModel.InfoID = infoID;
                            obj1.Insert(sqlConn, sqlTran, tmpModel);

                            if (!string.IsNullOrEmpty(tmpModel.CountryCode))
                                countrycode += tmpModel.CountryCode.Trim() + ",";
                            if (!string.IsNullOrEmpty(tmpModel.ProvinceID))
                                ProvinceID += tmpModel.ProvinceID.Trim() + ",";
                            if (!string.IsNullOrEmpty(tmpModel.CityID))
                                CityID += tmpModel.CityID.Trim() + ",";
                            if (!string.IsNullOrEmpty(tmpModel.CountyID))
                                countyID += tmpModel.CountyID.Trim() + ",";
                        }
                    }

                    //为投资资源更新联系人信息
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

                    //为投资信息添加多个资源
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
                    ReturnValue = true;

                    //序列化投资区域信息
                    this.CapitalInfoAreaQuery(infoID, countrycode, ProvinceID, CityID, countyID);

                    sqlTran.Commit();
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

        #region 得到一个对象实体(只包含CapitalInfoTab信息)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.CapitalInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.CapitalInfoModel model = new Tz888.Model.Info.CapitalInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("CapitalInfoTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.IndustryBID = ds.Tables[0].Rows[0]["IndustryBID"].ToString();
                model.CooperationDemandType = ds.Tables[0].Rows[0]["CooperationDemandType"].ToString();
                model.Currency = ds.Tables[0].Rows[0]["currency"].ToString();
                model.CapitalID = ds.Tables[0].Rows[0]["CapitalID"].ToString();
                model.CapitalTypeID = ds.Tables[0].Rows[0]["CapitalTypeID"].ToString();
                model.CapitalTypeName = ds.Tables[0].Rows[0]["CapitalTypeName"].ToString();
                model.ComAbout = ds.Tables[0].Rows[0]["ComAbout"].ToString();
                model.ComBreif = ds.Tables[0].Rows[0]["ComBreif"].ToString();
                model.Remrk = ds.Tables[0].Rows[0]["Remrk"].ToString();
                model.CapitalName = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                model.RegisteredCapital = ds.Tables[0].Rows[0]["RegisteredCapital"].ToString().Trim();
                model.AverageInvestment = ds.Tables[0].Rows[0]["AverageInvestment"].ToString().Trim();
                model.TeamScale = ds.Tables[0].Rows[0]["TeamScale"].ToString().Trim();
                model.SuccessfulInvestment = ds.Tables[0].Rows[0]["SuccessfulInvestment"].ToString().Trim();
                model.InvestmentDemand = ds.Tables[0].Rows[0]["InvestmentDemand"].ToString().Trim();
                model.Prorganizers = ds.Tables[0].Rows[0]["Prorganizers"].ToString().Trim();
                model.SCountryID = ds.Tables[0].Rows[0]["CountryID"].ToString().Trim();
                model.SCountyID = ds.Tables[0].Rows[0]["CountyID"].ToString().Trim();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["EvaluationPop"].ToString() != "")
                {
                    model.EvaluationPop = Convert.ToInt32(ds.Tables[0].Rows[0]["EvaluationPop"]);
                }
                if (ds.Tables[0].Rows[0]["TopCertification"].ToString().Trim() != "")
                {
                    model.TopCertification = Convert.ToInt32(ds.Tables[0].Rows[0]["TopCertification"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["InformationIntegrity"].ToString().Trim() != "")
                {
                    model.InformationIntegrity = Convert.ToInt32(ds.Tables[0].Rows[0]["InformationIntegrity"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["isVip"].ToString() != "")
                {
                    model.IsVip = Convert.ToInt32(ds.Tables[0].Rows[0]["isVip"]);
                }

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
                    string sCooperationDemandTypeNameTemp = ds.Tables[2].Rows[i]["CooperationDemandName"].ToString().Trim();
                    string sCooperationDemandTypeIDTemp = ds.Tables[2].Rows[i]["CooperationDemandTypeID"].ToString().Trim();
                    if (model.CooperationDemandType.Trim().IndexOf(sCooperationDemandTypeIDTemp.Trim()) != -1)
                    {
                        lstCooperationDemandTypeName.Add(sCooperationDemandTypeNameTemp);
                    }
                }
                model.CooperationDemandTypeName = lstCooperationDemandTypeName;

                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region --得到采集招商实体--
        public Tz888.Model.Info.ExcavateCapitalInfoModel GetExcavateCapitalModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ExcavateCapitalInfoModel model = new ExcavateCapitalInfoModel();
            DataSet ds = DbHelperSQL.RunProcedure("UP_ExcavateCapitalTab_Model", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.InvestTitle = ds.Tables[0].Rows[0]["investTitle"].ToString();
                model.InvestGov = ds.Tables[0].Rows[0]["investGov"].ToString();
                model.InvestGovIntro = ds.Tables[0].Rows[0]["InvestGovIntro"].ToString();
                model.InvestGovMan = ds.Tables[0].Rows[0]["InvestGovMan"].ToString();
                model.InvestTel = ds.Tables[0].Rows[0]["InvestTel"].ToString();
                model.InvestIntent = ds.Tables[0].Rows[0]["InvestIntent"].ToString();
                model.InvestIndustry = ds.Tables[0].Rows[0]["InvestIndustry"].ToString();
                model.InvestMode = ds.Tables[0].Rows[0]["InvestMode"].ToString();
                model.InvestCountry = ds.Tables[0].Rows[0]["InvestCountry"].ToString();
                model.InvestProvince = ds.Tables[0].Rows[0]["InvestProvince"].ToString();
                model.InvestMoney = ds.Tables[0].Rows[0]["InvestMoney"].ToString();
                model.ManAddress = ds.Tables[0].Rows[0]["ManAddress"].ToString();
                model.ManCode = ds.Tables[0].Rows[0]["ManCode"].ToString();
                model.ManMobile = ds.Tables[0].Rows[0]["ManMobile"].ToString();
                model.ManTel = ds.Tables[0].Rows[0]["ManTel"].ToString();
                model.ManTax = ds.Tables[0].Rows[0]["ManTax"].ToString();
                model.ManEmail = ds.Tables[0].Rows[0]["ManEmail"].ToString();
                model.WebUrl = ds.Tables[0].Rows[0]["WebUrl"].ToString();
                model.PublishTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PublishTime"]);
                model.InvestMan = ds.Tables[0].Rows[0]["InvestMan"].ToString();
            }
            return model;
        }
        #endregion

        #region --修改发布状态--
        public bool excavateCapitaltabUpdatePublish(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_excavateCapitaltab_IsPublishUpdate", parameters);
            return result;
        }
        #endregion

        #region --修改删除状态--
        public bool excavateCapitaltabUpdateDelete(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_excavateCapitaltab_IsDeleteUpdate", parameters);
            return result;
        }
        #endregion

        #region 得到一个对象实体(完整的投资资源信息)
        /// <summary>
        /// 获取一个完整的投资资源信息实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.CapitalSetModel GetIntegrityModel(long InfoID)
        {
            Tz888.Model.Info.CapitalSetModel model = new CapitalSetModel();

            //获取主要信息
            MainInfoDAL obj1 = new MainInfoDAL();
            model.MainInfoModel = obj1.GetModel(InfoID);

            //获取投资资源个性信息
            model.CapitalInfoModel = this.GetModel(InfoID);

            //获取信息联系方式
            InfoContactDAL obj3 = new InfoContactDAL();
            model.InfoContactModel = obj3.GetModel(InfoID);

            //获取投资信息联系人
            InfoContactManDAL obj4 = new InfoContactManDAL();
            model.InfoContactManModels = obj4.GetModelList(InfoID);

            //获取信息相关资源
            InfoResourceDAL obj5 = new InfoResourceDAL();
            model.InfoResourceModels = obj5.GetModelList(InfoID);

            //获取信息投资区域
            CapitalInfoAreaDAL obj6 = new CapitalInfoAreaDAL();
            model.CapitalInfoAreaModels = obj6.GetModelList(InfoID);

            //短信息
            ShortInfoDAL obj7 = new ShortInfoDAL();
            model.ShortInfoModel = obj7.GetModel(InfoID);

            return model;
        }
        #endregion

        #region 序列化投资区域信息
        public bool CapitalInfoAreaQuery(long InfoID, string countrycode, string ProvinceID, string CityID, string countyID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                new SqlParameter("@countrycode",SqlDbType.VarChar,1000),
                new SqlParameter("@ProvinceID", SqlDbType.VarChar,1000),
                new SqlParameter("@CityID", SqlDbType.VarChar,1000),
                new SqlParameter("@countyID", SqlDbType.VarChar,1000),

				};
            parameters[0].Value = InfoID;
            parameters[1].Value = countrycode;
            parameters[2].Value = ProvinceID;
            parameters[3].Value = CityID;
            parameters[4].Value = countyID;

            DbHelperSQL.RunProcedure("UP_CapitalInfoAreaQueryTab_INSERT", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
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
                "CapitalInfoTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion


        #region 判断某一个用户是否购买了某一条信息
        /// <summary>
        /// 判断某一个用户是否购买了某一条信息;
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="InfoID">信息的InfoID</param>
        /// <returns></returns>
        public bool bBuyInfoOfUserName(string UserName, string InfoID)
        {
            SqlParameter[] parameters = {
                                    //主表信息
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@UserName", SqlDbType.VarChar,100),
					              
            };
            parameters[0].Value = InfoID;
            parameters[1].Value = UserName;

            DataSet ds = DbHelperSQL.RunProcedure("CapitalInfoBuyByUser", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
