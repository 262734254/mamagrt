using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;
using Tz888.IDAL.Info.V124;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Info.V124
{
    public class CapitalInfoDAL : ICapitalInfo
    {
        private const string SP_CapitalInfoInfo_Insert = "CapitalInfoTab_Insert";

        #region 添加投资资源
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.V124.CapitalInfoModel capitalInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels,
            // List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        //以下是启用上传文件实体
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

                    new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,30),
					new SqlParameter("@currency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Char,10),
					new SqlParameter("@CapitalTypeID", SqlDbType.Char,10),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@ComBreif", SqlDbType.VarChar,-1),
					new SqlParameter("@Remrk", SqlDbType.VarChar,200),
					new SqlParameter("@isVIP", SqlDbType.TinyInt,1),
					new SqlParameter("@stageID", SqlDbType.TinyInt,1),
					new SqlParameter("@joinManageID", SqlDbType.TinyInt,1),
					new SqlParameter("@CooperationDemandTypeRemark", SqlDbType.VarChar,-1),

                //---------------------------END---------------------------

                //-----------------------资源联系信息--------------------------

					new SqlParameter("@ComName", SqlDbType.VarChar,40),
                    new SqlParameter("@OrgIntro", SqlDbType.Text,-1),
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

                //添加资本资源的其他参数
                  new SqlParameter("@RegisteredCapital",SqlDbType.Char,30),
                  new SqlParameter("@TeamScale",SqlDbType.Char,30),
                 new SqlParameter("@AverageInvestment",SqlDbType.Char,30),
                 new SqlParameter("@SuccessfulInvestment",SqlDbType.Char,30),
                 new SqlParameter("@InvestmentDemand",SqlDbType.NVarChar,100),
                new SqlParameter("@CountryID",SqlDbType.Char,10),
                new SqlParameter("@ProvinceID",SqlDbType.Char,10),
                new SqlParameter("@CityID",SqlDbType.Char,10),
                new SqlParameter("@CountyID",SqlDbType.Char,10),
                new SqlParameter("@Prorganizers",SqlDbType.NVarChar,100)
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

            parameters[25].Value = capitalInfoModel.IndustryBID;
            parameters[26].Value = capitalInfoModel.CooperationDemandType;
            parameters[27].Value = capitalInfoModel.currency;
            parameters[28].Value = capitalInfoModel.CapitalID;
            parameters[29].Value = capitalInfoModel.CapitalTypeID;
            parameters[30].Value = capitalInfoModel.ComAbout;
            parameters[31].Value = capitalInfoModel.ComBreif;
            parameters[32].Value = capitalInfoModel.Remrk;
            parameters[33].Value = capitalInfoModel.isVIP;
            parameters[34].Value = capitalInfoModel.stageID;
            parameters[35].Value = capitalInfoModel.joinManageID;
            parameters[36].Value = capitalInfoModel.CooperationDemandTypeRemark;
            //新加的资本资源的 参数
            parameters[55].Value = capitalInfoModel.RegisteredCapital;
            parameters[56].Value = capitalInfoModel.TeamScale;
            parameters[57].Value = capitalInfoModel.AverageInvestment;
            parameters[58].Value = capitalInfoModel.SuccessfulInvestment;
            parameters[59].Value = capitalInfoModel.InvestmentDemand;
            parameters[60].Value = capitalInfoModel.SCountryID;
            parameters[61].Value = capitalInfoModel.SProvinceID;
            parameters[62].Value = capitalInfoModel.SCityID;
            parameters[63].Value = capitalInfoModel.SCountyID;
            parameters[64].Value = capitalInfoModel.Prorganizers;
            //结束处

            parameters[37].Value = infoContactModel.OrganizationName;
            parameters[38].Value = infoContactModel.OrgIntro;
            parameters[39].Value = infoContactModel.Name;
            parameters[40].Value = infoContactModel.TelCountryCode;
            parameters[41].Value = infoContactModel.TelStateCode;
            parameters[42].Value = infoContactModel.TelNum;
            parameters[43].Value = infoContactModel.FaxCountryCode;
            parameters[44].Value = infoContactModel.FaxStateCode;
            parameters[45].Value = infoContactModel.FaxNum;
            parameters[46].Value = infoContactModel.Mobile;
            parameters[47].Value = infoContactModel.Address;
            parameters[48].Value = infoContactModel.PostCode;
            parameters[49].Value = infoContactModel.Email;
            parameters[50].Value = infoContactModel.WebSite;

            parameters[51].Value = shortInfoModel.ShortInfoControlID;
            parameters[52].Value = shortInfoModel.ShortTitle;
            parameters[53].Value = shortInfoModel.ShortContent;
            parameters[54].Value = shortInfoModel.Remark;
            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入投资资源信息
                    try
                    {
                        DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_CapitalInfoInfo_Insert, parameters, out rowsAffected);
                    }
                    catch (Exception ex2)
                    {

                        throw ex2;
                    }
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
                            obj3.InsertInfoResource(sqlConn, sqlTran, model, 1);
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

        #region  得到一个对象实体
        public Tz888.Model.Info.V124.CapitalInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.V124.CapitalInfoModel model = new Tz888.Model.Info.V124.CapitalInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("CapitalInfoTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.IndustryBID = ds.Tables[0].Rows[0]["IndustryBID"].ToString();
                model.CooperationDemandType = ds.Tables[0].Rows[0]["CooperationDemandType"].ToString();
                model.currency = ds.Tables[0].Rows[0]["currency"].ToString();
                model.CapitalID = ds.Tables[0].Rows[0]["CapitalID"].ToString();
                model.CapitalName = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                model.CapitalTypeID = ds.Tables[0].Rows[0]["CapitalTypeID"].ToString();
                model.CapitalTypeName = ds.Tables[0].Rows[0]["CapitalTypeName"].ToString();
                model.StageName = ds.Tables[0].Rows[0]["StageName"].ToString();
                model.ComAbout = ds.Tables[0].Rows[0]["ComAbout"].ToString();
                model.ComBreif = ds.Tables[0].Rows[0]["ComBreif"].ToString();
                model.Remrk = ds.Tables[0].Rows[0]["Remrk"].ToString();
                //2010-06-12新增
                model.RegisteredCapital = ds.Tables[0].Rows[0]["RegisteredCapital"].ToString();

                //CountyID
                model.TeamScale = ds.Tables[0].Rows[0]["TeamScale"].ToString();
                model.AverageInvestment = ds.Tables[0].Rows[0]["AverageInvestment"].ToString();
                model.SuccessfulInvestment = ds.Tables[0].Rows[0]["SuccessfulInvestment"].ToString();
                model.InvestmentDemand = ds.Tables[0].Rows[0]["InvestmentDemand"].ToString();
                model.SCountryID = ds.Tables[0].Rows[0]["CountryID"].ToString();
                model.SProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.SCityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.SCountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.Prorganizers = ds.Tables[0].Rows[0]["Prorganizers"].ToString();

                if (ds.Tables[0].Rows[0]["isVIP"].ToString() != "")
                {
                    model.isVIP = int.Parse(ds.Tables[0].Rows[0]["isVIP"].ToString());
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

                if (ds.Tables[0].Rows[0]["stageID"].ToString() != "")
                {
                    model.stageID = int.Parse(ds.Tables[0].Rows[0]["stageID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["joinManageID"].ToString() != "")
                {
                    model.joinManageID = int.Parse(ds.Tables[0].Rows[0]["joinManageID"].ToString());
                }
                model.CooperationDemandTypeRemark = ds.Tables[0].Rows[0]["CooperationDemandTypeRemark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  成员方法

        #region 得到一个对象实体(完整的投资资源信息)
        /// <summary>
        /// 获取一个完整的投资资源信息实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.V124.CapitalSetModel GetIntegrityModel(long InfoID)
        {
            Tz888.Model.Info.V124.CapitalSetModel model = new Tz888.Model.Info.V124.CapitalSetModel();
            //获取主要信息
            MainInfoDAL obj1 = new MainInfoDAL();
            model.MainInfoModel = obj1.GetModel(InfoID);

            //获取投资资源个性信息
            model.CapitalInfoModel = this.GetModel(InfoID);

            //获取信息联系方式
            InfoContactDAL obj3 = new InfoContactDAL();
            model.InfoContactModel = obj3.GetModel(InfoID);

            //获取信息投资区域
            CapitalInfoAreaDAL obj6 = new CapitalInfoAreaDAL();
            model.CapitalInfoAreaModels = obj6.GetModelList(InfoID);

            //短信息
            ShortInfoDAL obj7 = new ShortInfoDAL();
            model.ShortInfoModel = obj7.GetModel(InfoID);

            InfoResourceDAL obj8 = new InfoResourceDAL();
            model.InfoResourceModels = obj8.GetModelList(InfoID);

            return model;
        }
        #endregion

        /// <summary>
        /// 修改投资资源
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.V124.CapitalSetModel model)
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
                                    new SqlParameter("@AuditingStatus", SqlDbType.TinyInt,1),
                                    //投资资源表信息
                                    new SqlParameter("@IndustryBID", SqlDbType.Char,10),
                                    new SqlParameter("@CooperationDemandType", SqlDbType.Char,30),
                                    new SqlParameter("@currency", SqlDbType.Char,10),
                                    new SqlParameter("@CapitalID", SqlDbType.Char,10),
                                    new SqlParameter("@CapitalTypeID", SqlDbType.Char,10),
                                    new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBreif", SqlDbType.VarChar,-1),
                                    new SqlParameter("@Remrk", SqlDbType.VarChar,200),
                                    new SqlParameter("@isVIP", SqlDbType.TinyInt,1),
                                    new SqlParameter("@stageID", SqlDbType.TinyInt,1),
                                    new SqlParameter("@joinManageID", SqlDbType.TinyInt,1),
                                    new SqlParameter("@CooperationDemandTypeRemark", SqlDbType.VarChar,-1),

                                    //联系信息
                                    new SqlParameter("@ComName", SqlDbType.VarChar,40),
                                    new SqlParameter("@OrgIntro", SqlDbType.Text,-1),
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

                                    //短信息
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
                                    new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
                                    new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
                                    new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                                      //2010-06-12新增的
                                    //添加资本资源的其他参数
                                    new SqlParameter("@RegisteredCapital",SqlDbType.Char,30),
                                    new SqlParameter("@TeamScale",SqlDbType.Char,30),
                                    new SqlParameter("@AverageInvestment",SqlDbType.Char,30),
                                    new SqlParameter("@SuccessfulInvestment",SqlDbType.Char,30),
                                    new SqlParameter("@InvestmentDemand",SqlDbType.NVarChar,100),
                                    new SqlParameter("@CountryID",SqlDbType.Char,10),
                                    new SqlParameter("@ProvinceID",SqlDbType.Char,10),
                                    new SqlParameter("@CityID",SqlDbType.Char,10),
                                    new SqlParameter("@CountyID",SqlDbType.Char,10),
                                    new SqlParameter("@Prorganizers",SqlDbType.NVarChar,100), //10
                                     //new SqlParameter("@AuditingStatus",SqlDbType.TinyInt,1), //10
                                    new SqlParameter("@Position",SqlDbType.VarChar,50), //10
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
            parameters[11].Value = model.MainInfoModel.AuditingStatus;

            parameters[12].Value = model.CapitalInfoModel.IndustryBID;
            parameters[13].Value = model.CapitalInfoModel.CooperationDemandType;
            parameters[14].Value = model.CapitalInfoModel.currency;
            parameters[15].Value = model.CapitalInfoModel.CapitalID;
            parameters[16].Value = model.CapitalInfoModel.CapitalTypeID;
            parameters[17].Value = model.CapitalInfoModel.ComAbout;
            parameters[18].Value = model.CapitalInfoModel.ComBreif;
            parameters[19].Value = model.CapitalInfoModel.Remrk;
            parameters[20].Value = model.CapitalInfoModel.isVIP;
            parameters[21].Value = model.CapitalInfoModel.stageID;
            parameters[22].Value = model.CapitalInfoModel.joinManageID;
            parameters[23].Value = model.CapitalInfoModel.CooperationDemandTypeRemark;

            parameters[24].Value = model.InfoContactModel.OrganizationName;
            parameters[25].Value = model.InfoContactModel.OrgIntro;
            parameters[26].Value = model.InfoContactModel.Name;
            parameters[27].Value = model.InfoContactModel.TelCountryCode;
            parameters[28].Value = model.InfoContactModel.TelStateCode;
            parameters[29].Value = model.InfoContactModel.TelNum;
            parameters[30].Value = model.InfoContactModel.FaxCountryCode;
            parameters[31].Value = model.InfoContactModel.FaxStateCode;
            parameters[32].Value = model.InfoContactModel.FaxNum;
            parameters[33].Value = model.InfoContactModel.Mobile;
            parameters[34].Value = model.InfoContactModel.Address;
            parameters[35].Value = model.InfoContactModel.PostCode;
            parameters[36].Value = model.InfoContactModel.Email;
            parameters[37].Value = model.InfoContactModel.WebSite;

            parameters[38].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[39].Value = model.ShortInfoModel.ShortTitle;
            parameters[40].Value = model.ShortInfoModel.ShortContent;
            parameters[41].Value = model.ShortInfoModel.Remark;
            //新加的资本资源的 参数

            parameters[42].Value = model.CapitalInfoModel.RegisteredCapital;
            parameters[43].Value = model.CapitalInfoModel.TeamScale;
            parameters[44].Value = model.CapitalInfoModel.AverageInvestment;
            parameters[45].Value = model.CapitalInfoModel.SuccessfulInvestment;
            parameters[46].Value = model.CapitalInfoModel.InvestmentDemand;
            parameters[47].Value = model.CapitalInfoModel.SCountryID;
            parameters[48].Value = model.CapitalInfoModel.SProvinceID;
            parameters[49].Value = model.CapitalInfoModel.SCityID;
            parameters[50].Value = model.CapitalInfoModel.SCountyID;
            parameters[51].Value = model.CapitalInfoModel.Prorganizers;
            //parameters[52].Value = model.MainInfoModel.AuditingStatus;
            parameters[52].Value = model.InfoContactModel.Position;
            //end
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


        //以下更新信息完整度的
        public bool UpdateInformationIntegrity(Tz888.Model.Info.V124.CapitalInfoModel model)
        {
            SqlParameter[] parameters ={
                    new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@InformationIntegrity", SqlDbType.Int,8)
                                        };
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.InformationIntegrity;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //更改信息完整度
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "InformationIntegrity_Update", parameters, out rowsAffected);
                    return true;

                }

                catch
                {
                    sqlTran.Rollback();
                    return false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }


        }

    }
}
