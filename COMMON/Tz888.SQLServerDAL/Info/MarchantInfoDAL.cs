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
    /// 招商信息数据库访问逻辑类
    /// </summary>
    public class MarchantInfoDAL : IMarchantInfo
    {
        private const string SP_MarchantInfo_Insert = "MerchantInfoTab_Insert";

        /// <summary>
        ///2010-06-26 添加资源列表信息
        /// </summary>
        /// <param name="resourcesModel"></param>
        /// <returns></returns>
        public int InsertResources(
            Tz888.Model.Info.ResourcesModel resourcesModel)
        {
            SqlParameter[] parameters ={
           new SqlParameter("@InfoID",SqlDbType.BigInt,10),
           new SqlParameter("@ResourceID",SqlDbType.Int,8),
           new SqlParameter("@OrderNumberID",SqlDbType.Int,8)
         };
            parameters[0].Value = resourcesModel.InfoID;
            parameters[1].Value = resourcesModel.ResourceID;
            parameters[2].Value = resourcesModel.OrderNumberID;
             
            ////存储过程方法的开始处
            //int rowsAffected = 0;
            //using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            //{
            //    sqlConn.Open();
            //    SqlTransaction sqlTran = sqlConn.BeginTransaction();
            //    try
            //    {
            //        //插入招商资源信息插如方法
            //        DbHelperSQL.RunProcedure(sqlConn, sqlTran, "ResourcesAdd", parameters, out rowsAffected);
            //        // DbHelperSQL.RunProcedure(  
            //        // if (rowsAffected > 0)
            //        // return rowsAffected;
            //    }
            //    catch
            //    {
            //        sqlTran.Rollback();

            //    }
            //    finally
            //    {
            //        sqlConn.Close();
            //    }
            //}
            //return rowsAffected;
            //存储过程方法的结束处


            //以下是不用存储过程的方法
            string sql = "insert into RecommendTab (InfoID,ResourceID,OrderNumberID)values(@InfoID,@ResourceID,@OrderNumberID)";
            if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql, parameters) > 0)
                return 1;
            else
                return 0;

        }

        public Tz888.Model.Register.OrgContactModel SelLoginName(string name)
        {
            Tz888.Model.Register.OrgContactModel orgModel = new Tz888.Model.Register.OrgContactModel();
            string sql = "select a.OrganizationName,a.[Name],a.Position,a.TelCountryCode,a.TelStateCode,a.TelNum,a.Email,a.Mobile,a.Address from OrgContactTab as a inner join LoginInfoTab as b on a.LoginName=b.LoginName inner join MemberInfoTab as c on b.LoginName=c.LoginName where b.LoginName='" + name + "'";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                orgModel.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                orgModel.OrganizationName = ds.Tables[0].Rows[0]["OrganizationName"].ToString(); 
                orgModel.Position = ds.Tables[0].Rows[0]["Position"].ToString(); 
                orgModel.TelCountryCode = ds.Tables[0].Rows[0]["TelCountryCode"].ToString(); 
                orgModel.TelStateCode = ds.Tables[0].Rows[0]["TelStateCode"].ToString(); 
                orgModel.TelNum = ds.Tables[0].Rows[0]["TelNum"].ToString(); 
                orgModel.Email = ds.Tables[0].Rows[0]["Email"].ToString(); 
                orgModel.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString(); 
                orgModel.address = ds.Tables[0].Rows[0]["Address"].ToString(); 
            }

            return orgModel;
        }


        #region 添加一条招商信息
        /// <summary>
        /// 添加招商资源信息
        /// </summary>
        /// <param name="mainInfoModel">资源信息主体</param>
        /// <param name="merchantInfoModel">招商资源个性信息</param>
        /// <param name="infoContactModel">资源联系信息</param>
        /// <param name="shortInfoModel">资源短信息</param>
        /// <param name="infoContactManModels">多联系人列表</param>
        /// <returns>招商资源ID</returns>
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.MerchantInfoModel merchantInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
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

                //--------------------招商资源个性信息---------------------

					new SqlParameter("@MerchantTypeID", SqlDbType.Char,10),
					new SqlParameter("@IndustryClassList", SqlDbType.VarChar,150),
                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@MerchantCurrency", SqlDbType.Char,10),
					new SqlParameter("@MerchantTotal", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.VarChar,30),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@ZoneAbout", SqlDbType.VarChar,-1),
					new SqlParameter("@ZoneAboutBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@ReceiveOrganization", SqlDbType.VarChar,100),
					new SqlParameter("@MerchantOrganization", SqlDbType.Int,4),


                //---------------------------END---------------------------

                //-----------------------资源联系信息--------------------------

					new SqlParameter("@Organization", SqlDbType.VarChar,40),
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
                //这里是2010-06-01 添加政府招商的参数 有5个参数
                    new SqlParameter("@EconomicIndicators",SqlDbType.NVarChar,100),
                    new SqlParameter("@InvestmentEnvironment",SqlDbType.NVarChar,100),
                    new SqlParameter("@ProjectStatus",SqlDbType.NVarChar,100),
                    new SqlParameter("@Market",SqlDbType.NVarChar,100),
                    new SqlParameter("@Benefit",SqlDbType.NVarChar,100),
                 //新添加结束处
                    //这里是2010-06-02添加政府招商联系信息的参数
                    new SqlParameter("@Position",SqlDbType.VarChar,50),
                    //这里是2010-06-08添加信息完整度
                   new SqlParameter("@InformationIntegrity",SqlDbType.Int,8),
                   new SqlParameter("@Merchanreturns",SqlDbType.Int,8)
                 
 
                //---------------------------END---------------------------
            };

            //---------------------资源信息主体参数----------------------
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
            
           

            //End
            parameters[25].Value = merchantInfoModel.MerchantTypeID;
            parameters[26].Value = merchantInfoModel.IndustryClassList;
            parameters[27].Value = merchantInfoModel.CapitalCurrency;
            parameters[28].Value = merchantInfoModel.CapitalTotal;
            parameters[29].Value = merchantInfoModel.MerchantCurrency;
            parameters[30].Value = merchantInfoModel.MerchantTotal;
            parameters[31].Value = merchantInfoModel.CooperationDemandType;
            parameters[32].Value = merchantInfoModel.CountryCode;
            parameters[33].Value = merchantInfoModel.ProvinceID;
            parameters[34].Value = merchantInfoModel.CityID;
            parameters[35].Value = merchantInfoModel.CountyID;
            parameters[36].Value = merchantInfoModel.ZoneAbout;
            parameters[37].Value = merchantInfoModel.ZoneAboutBrief;
            parameters[38].Value = merchantInfoModel.ReceiveOrganization;
            parameters[39].Value = merchantInfoModel.MerchantOrganization;
            //2010-06-01以下是根据需求添加的
            parameters[57].Value = merchantInfoModel.EconomicIndicators;
            parameters[58].Value = merchantInfoModel.InvestmentEnvironment;
            parameters[59].Value = merchantInfoModel.ProjectStatus;
            parameters[60].Value = merchantInfoModel.Market;
            parameters[61].Value = merchantInfoModel.Benefit;
              //添加信息完整度
            parameters[63].Value = merchantInfoModel.InformationIntegrity;
            //End



            parameters[40].Value = infoContactModel.OrganizationName;
            parameters[41].Value = infoContactModel.Name;
            parameters[42].Value = infoContactModel.TelCountryCode;
            parameters[43].Value = infoContactModel.TelStateCode;
            parameters[44].Value = infoContactModel.TelNum;
            parameters[45].Value = infoContactModel.FaxCountryCode;
            parameters[46].Value = infoContactModel.FaxStateCode;
            parameters[47].Value = infoContactModel.FaxNum;
            parameters[48].Value = infoContactModel.Mobile;
            parameters[49].Value = infoContactModel.Address;
            parameters[50].Value = infoContactModel.PostCode;
            parameters[51].Value = infoContactModel.Email;
            parameters[52].Value = infoContactModel.WebSite;
            //2010-06-02以下是招商联系人职位
            parameters[62].Value = infoContactModel.Position;
            //end

            parameters[53].Value = shortInfoModel.ShortInfoControlID;
            parameters[54].Value = shortInfoModel.ShortTitle;
            parameters[55].Value = shortInfoModel.ShortContent;
            parameters[56].Value = shortInfoModel.Remark;
            parameters[64].Value = merchantInfoModel.Merchanreturns;
            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入招商资源信息插如方法
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_MarchantInfo_Insert, parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    //注释掉多个联系人
                    //if (infoContactManModels != null)
                    //{
                    //    //为招商资源添加多个联系人
                    //    Tz888.SQLServerDAL.Info.InfoContactManDAL obj1 = new InfoContactManDAL();
                    //    foreach (Tz888.Model.Info.InfoContactManModel model in infoContactManModels)
                    //    {
                    //        model.InfoID = infoID;
                    //        obj1.InsertContactMan(sqlConn, sqlTran, model);
                    //    }
                    //}

                    if (infoResourceModels != null)
                    {
                        //为招商信息添加多个资源
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj2 = new InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            obj2.InsertInfoResource(sqlConn, sqlTran, model);
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

        #region 修改招商信息
        public bool Update(Tz888.Model.Info.MerchantSetModel model)
        {
            SqlParameter[] parameters = {
                                    //主表信息
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10), //4

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100), //8
                                    
                                    //招商信息
					                new SqlParameter("@MerchantTypeID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryClassList", SqlDbType.VarChar,150),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@MerchantCurrency", SqlDbType.Char,10),
					                new SqlParameter("@MerchantTotal", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.VarChar,30),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@ZoneAbout", SqlDbType.VarChar,-1),
					                new SqlParameter("@ZoneAboutBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@ReceiveOrganization", SqlDbType.VarChar,100),
					                new SqlParameter("@MerchantOrganization", SqlDbType.Int,4), //15
                                  
                                    //联系信息
					                new SqlParameter("@Organization", SqlDbType.VarChar,100),
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
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200), //13
                                    
                                    //短信息表
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
                                    new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                                     //2010-06-11新增的
                                    new SqlParameter("@PriceByUser", SqlDbType.Int,4),
					                
                                    
                                     //这里是2010-06-11 添加政府招商的参数 有5个参数
                                    new SqlParameter("@EconomicIndicators",SqlDbType.NVarChar,100),
                                    new SqlParameter("@InvestmentEnvironment",SqlDbType.NVarChar,100),
                                    new SqlParameter("@ProjectStatus",SqlDbType.NVarChar,100),
                                    new SqlParameter("@Market",SqlDbType.NVarChar,100),
                                    new SqlParameter("@Benefit",SqlDbType.NVarChar,100), //10
                                    
                                    new SqlParameter("@InformationIntegrity",SqlDbType.Int,8),
                                    new SqlParameter("@Position",SqlDbType.VarChar,50),
                                     new SqlParameter("@Merchanreturns",SqlDbType.Int,8),


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

            parameters[12].Value = model.MerchantInfoModel.MerchantTypeID;
            parameters[13].Value = model.MerchantInfoModel.IndustryClassList;
            parameters[14].Value = model.MerchantInfoModel.CapitalCurrency;
            parameters[15].Value = model.MerchantInfoModel.CapitalTotal;
            parameters[16].Value = model.MerchantInfoModel.MerchantCurrency;
            parameters[17].Value = model.MerchantInfoModel.MerchantTotal;
            parameters[18].Value = model.MerchantInfoModel.CooperationDemandType;
            parameters[19].Value = model.MerchantInfoModel.CountryCode;
            parameters[20].Value = model.MerchantInfoModel.ProvinceID;
            parameters[21].Value = model.MerchantInfoModel.CityID;
            parameters[22].Value = model.MerchantInfoModel.CountyID;
            parameters[23].Value = model.MerchantInfoModel.ZoneAbout;
            parameters[24].Value = model.MerchantInfoModel.ZoneAboutBrief;
            parameters[25].Value = model.MerchantInfoModel.ReceiveOrganization;
            parameters[26].Value = model.MerchantInfoModel.MerchantOrganization;

            parameters[27].Value = model.InfoContactModel.OrganizationName;
            parameters[28].Value = model.InfoContactModel.Name;
            parameters[29].Value = model.InfoContactModel.TelCountryCode;
            parameters[30].Value = model.InfoContactModel.TelStateCode;
            parameters[31].Value = model.InfoContactModel.TelNum;
            parameters[32].Value = model.InfoContactModel.FaxCountryCode;
            parameters[33].Value = model.InfoContactModel.FaxStateCode;
            parameters[34].Value = model.InfoContactModel.FaxNum;
            parameters[35].Value = model.InfoContactModel.Mobile;
            parameters[36].Value = model.InfoContactModel.Address;
            parameters[37].Value = model.InfoContactModel.PostCode;
            parameters[38].Value = model.InfoContactModel.Email;
            parameters[39].Value = model.InfoContactModel.WebSite;
           

            parameters[40].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[41].Value = model.ShortInfoModel.ShortTitle;
            parameters[42].Value = model.ShortInfoModel.ShortContent;
            parameters[43].Value = model.ShortInfoModel.Remark;

          
           
            //2010-06-11以下是根据需求添加的
            parameters[44].Value = 1;
            parameters[45].Value = model.MerchantInfoModel.EconomicIndicators; 
            parameters[46].Value = model.MerchantInfoModel.InvestmentEnvironment;
            parameters[47].Value = model.MerchantInfoModel.ProjectStatus;
            parameters[48].Value = model.MerchantInfoModel.Market;
            parameters[49].Value = model.MerchantInfoModel.Benefit;
            //添加信息完整度
            parameters[50].Value = model.MerchantInfoModel.InformationIntegrity;
            //2010-06-11以下是招商联系人职位
            parameters[51].Value = model.InfoContactModel.Position;
            parameters[52].Value = model.MerchantInfoModel.Merchanreturns;
            //End
           
            bool ReturnValue = false;
            long infoID = model.MainInfoModel.InfoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //修改招商信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "MerchantInfoTab_Update", parameters, out rowsAffected);

                    //为招商信息更新联系人信息
                    Tz888.SQLServerDAL.Info.InfoContactManDAL obj2 = new InfoContactManDAL();
                    obj2.DeleteByInfoID(sqlConn, sqlTran, infoID); 
                    //if (model.InfoContactManModels != null)
                    //{
                    //    foreach (Tz888.Model.Info.InfoContactManModel tmpModel in model.InfoContactManModels)
                    //    {
                    //        tmpModel.InfoID = infoID;
                    //        obj2.InsertContactMan(sqlConn, sqlTran, tmpModel);
                    //    }
                    //}

                    //为招商信息添加多个资源
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

        #region  得到一个对象实体(只包含MerchantInfoTab信息)
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Info.MerchantInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.MerchantInfoModel model = new Tz888.Model.Info.MerchantInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("MerchantInfoTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MerchantTypeID = ds.Tables[0].Rows[0]["MerchantTypeID"].ToString();
                model.VipAbout = ds.Tables[0].Rows[0]["VipAbout"].ToString();
                model.MerchantTypeName = ds.Tables[0].Rows[0]["MerchantAttributeName"].ToString();
           
                model.IndustryClassList = ds.Tables[0].Rows[0]["IndustryClassList"].ToString();
                model.CapitalCurrency = ds.Tables[0].Rows[0]["CapitalCurrency"].ToString();
                if (ds.Tables[0].Rows[0]["CapitalTotal"].ToString() != "")
                {
                    model.CapitalTotal = decimal.Parse(ds.Tables[0].Rows[0]["CapitalTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Merchanreturns"].ToString() != "")
                {
                    model.Merchanreturns = Convert.ToInt32(ds.Tables[0].Rows[0]["Merchanreturns"].ToString());
                }
                //2010-06-11新增
                model.Market = ds.Tables[0].Rows[0]["Market"].ToString();
                
                model.EconomicIndicators = ds.Tables[0].Rows[0]["EconomicIndicators"].ToString();
                model.InvestmentEnvironment = ds.Tables[0].Rows[0]["InvestmentEnvironment"].ToString();
                model.ProjectStatus = ds.Tables[0].Rows[0]["ProjectStatus"].ToString();
                model.Benefit = ds.Tables[0].Rows[0]["Benefit"].ToString();
                model.InformationIntegrity = 0;
                if (ds.Tables[0].Rows[0]["InformationIntegrity"].ToString() != "")
                {
                    model.InformationIntegrity = Convert.ToInt32(ds.Tables[0].Rows[0]["InformationIntegrity"]);
                }
                //end
                model.MerchantCurrency = ds.Tables[0].Rows[0]["MerchantCurrency"].ToString();
                model.MerchantTotal = ds.Tables[0].Rows[0]["MerchantTotal"].ToString();
                model.CooperationDemandType = ds.Tables[0].Rows[0]["CooperationDemandType"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                model.ZoneAbout = ds.Tables[0].Rows[0]["ZoneAbout"].ToString();
                model.ZoneAboutBrief = ds.Tables[0].Rows[0]["ZoneAboutBrief"].ToString();
                model.ReceiveOrganization = ds.Tables[0].Rows[0]["ReceiveOrganization"].ToString();
                if (ds.Tables[0].Rows[0]["MerchantOrganization"].ToString() != "")
                {
                    model.MerchantOrganization = int.Parse(ds.Tables[0].Rows[0]["MerchantOrganization"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                
                List<string> lstIndustryBName = new List<string>();
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string sIndustryNameTemp = ds.Tables[1].Rows[i]["IndustryBName"].ToString().Trim();
                    string sIndustryIDTemp = ds.Tables[1].Rows[i]["IndustryBID"].ToString().Trim();
                    if (model.IndustryClassList.IndexOf(sIndustryIDTemp) != -1)
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

                if (ds.Tables[7] != null && ds.Tables[7].Rows.Count > 0)
                {
                    model.Merchanttotalname = ds.Tables[7].Rows[0]["CapitalName"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  

        #region --得到采集招商实体--
        public Tz888.Model.Info.ExcavateMerchantInfoMode GetExcavateModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ExcavateMerchantInfoMode model = new ExcavateMerchantInfoMode();
            DataSet ds = DbHelperSQL.RunProcedure("UP_ExcavateTab_Model", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                model.PrjCompany = ds.Tables[0].Rows[0]["prjCompany"].ToString();
                model.CompanyInfo = ds.Tables[0].Rows[0]["companyInfo"].ToString();
                model.PrjContactMan = ds.Tables[0].Rows[0]["prjContactMan"].ToString();
                model.PrjTel = ds.Tables[0].Rows[0]["prjTel"].ToString();
                model.PrjInfo = ds.Tables[0].Rows[0]["prjInfo"].ToString();
                model.Industry = ds.Tables[0].Rows[0]["industry"].ToString();
                model.PrjCountryName = ds.Tables[0].Rows[0]["CountryName"].ToString();
                model.PrjProvinceName = ds.Tables[0].Rows[0]["provinceName"].ToString();
                model.RequireMoney = ds.Tables[0].Rows[0]["requireMoney"].ToString();
                model.CooperateMode = ds.Tables[0].Rows[0]["cooperateMode"].ToString();
                model.ContactMan = ds.Tables[0].Rows[0]["ContactMan"].ToString();
                model.ManTel = ds.Tables[0].Rows[0]["manTel"].ToString();
                model.ManMobile = ds.Tables[0].Rows[0]["manMobile"].ToString();
                model.ManAddress = ds.Tables[0].Rows[0]["manAddress"].ToString();
                model.ManCode = ds.Tables[0].Rows[0]["manCode"].ToString();
                model.ManTax = ds.Tables[0].Rows[0]["manTax"].ToString();
                model.ManEmail = ds.Tables[0].Rows[0]["manEmail"].ToString();
                model.WebUrl = ds.Tables[0].Rows[0]["webUrl"].ToString();
                model.PublishTime = ds.Tables[0].Rows[0]["publishTime"].ToString();
            }
            return model;
        }
        #endregion

        #region --修改发布状态--
        public bool ExcavateTabUpdatePublish(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value =id;
            bool result =DbHelperSQL.RunProcLob("UP_ExcavateTab_IsPublishUpdate", parameters);
            return result;
        }
        #endregion

        #region --修改删除状态--
        public bool ExcavateTabUpdateDelete(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_ExcavateTab_IsDeleteUpdate", parameters);
            return result;
        }
        #endregion

        #region 得到一个对象实体(完整的招商信息)
        /// <summary>
        /// 获取一个完整的招商信息实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MerchantSetModel GetIntegrityModel(long InfoID)
        {
            Tz888.Model.Info.MerchantSetModel model = new MerchantSetModel();

            //获取主要信息
            MainInfoDAL obj1 = new MainInfoDAL();
            model.MainInfoModel = obj1.GetModel(InfoID);

            //获取投资资源个性信息
            model.MerchantInfoModel = this.GetModel(InfoID);

            //获取信息联系方式
            InfoContactDAL obj3 = new InfoContactDAL();
            model.InfoContactModel = obj3.GetModel(InfoID);

            //获取招商信息联系人
            //InfoContactManDAL obj4 = new InfoContactManDAL();
            //model.InfoContactManModels = obj4.GetModelList(InfoID);

            //获取招商信息相关资源
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
                "MerchantInfoTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion
    }
}
