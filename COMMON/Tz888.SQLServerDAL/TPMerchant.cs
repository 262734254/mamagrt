using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class TPMerchant : ITPMerchant
    {
        /// <summary>
        ///  添加资讯信息 
        /// </summary>
        public bool InsertMerchantNews(Tz888.Model.TPMerchant model)
        {
            long infoID;

            SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
                    new SqlParameter("@publishT", SqlDbType.DateTime,8),
                    new SqlParameter("@Hit", SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
                    new SqlParameter("@DesCript", SqlDbType.VarChar,100), 
					new SqlParameter("@NewsTypeID", SqlDbType.Char,10),
					new SqlParameter("@subTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NewsLblStatus", SqlDbType.Char,10),
                    new SqlParameter("@NewsIndustryID",SqlDbType.Char,10),
					new SqlParameter("@Origin", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,20),
                    new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
                    new SqlParameter("@IsRedirect", SqlDbType.Bit),
                    new SqlParameter("@Summary", SqlDbType.Text),
                    new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@Pic1", SqlDbType.VarChar,100),
                    new SqlParameter("@PicAbout", SqlDbType.VarChar,30),
                    new SqlParameter("@PageStatus", SqlDbType.Int,4),
                    new SqlParameter("@PageCharCount", SqlDbType.BigInt,8),
                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
                    new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
                    new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                    new SqlParameter("@ResearchSpot", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    new SqlParameter("@CityID", SqlDbType.Char,10),
                    new SqlParameter("@CountyID", SqlDbType.Char,10),
                    new SqlParameter("@InfoCode",SqlDbType.Char,30),
                    new SqlParameter("@auditingstatus",SqlDbType.TinyInt,1)
                
            };
            //parameters[0].Direction = ParameterDirection.Output;
            parameters[0].Value = model.infoID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.publishT;
            parameters[3].Value = model.Hit;
            parameters[4].Value = model.IsCore;
            parameters[5].Value = model.LoginName;
            parameters[6].Value = model.KeyWord;
            parameters[7].Value = model.Descript;
            parameters[8].Value = model.NewsTypeID;
            parameters[9].Value = model.subTitle;
            parameters[10].Value = model.NewsLblStatus;
            parameters[11].Value = model.NewsIndustryID;
            parameters[12].Value = model.Origin;
            parameters[13].Value = model.Author;
            parameters[14].Value = model.RedirectUrl;
            parameters[15].Value = model.IsRedirect;
            parameters[16].Value = model.Summary;
            parameters[17].Value = model.Content;
            parameters[18].Value = model.Pic1;
            parameters[19].Value = model.PicAbout;
            parameters[20].Value = model.PageStatus;
            parameters[21].Value = model.PageCharCount;
            parameters[22].Value = model.ShortInfoControlID;
            parameters[23].Value = model.ShortTitle;
            parameters[24].Value = model.ShortContent;
            parameters[25].Value = model.ResearchSpot;
            parameters[26].Value = model.strRemark;
            parameters[27].Value = model.ProvinceID;
            parameters[28].Value = model.CityID;
            parameters[29].Value = model.CountyID;
            parameters[30].Value = model.InfoCode;
            parameters[31].Value = model.auditingstatus;
          infoID=SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Insert_New_Manage", parameters);

            //infoID = (long)parameters[0].Value;

            if (infoID > 0)
                return true;
            return false;
        }

        /// <summary>
        ///  添加活动资讯信息 
        /// </summary>
        public bool InsertMerchantActiveNews(Tz888.Model.TPMerchant model)
        {
            long infoID;
            SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
                    new SqlParameter("@publishT", SqlDbType.DateTime,8),
                    new SqlParameter("@Hit", SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
                    new SqlParameter("@DesCript", SqlDbType.VarChar,100),
					new SqlParameter("@NewsTypeID", SqlDbType.Char,10),
					new SqlParameter("@subTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NewsLblStatus", SqlDbType.Char,10),
                    new SqlParameter("@NewsIndustryID",SqlDbType.Char,10),
					new SqlParameter("@Origin", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,20),
                    new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
                    new SqlParameter("@IsRedirect", SqlDbType.Bit),
                    new SqlParameter("@Summary", SqlDbType.Text),
                    new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@Pic1", SqlDbType.VarChar,100),
                    new SqlParameter("@PicAbout", SqlDbType.VarChar,30),
                    new SqlParameter("@PageStatus", SqlDbType.Int,4),
                    new SqlParameter("@PageCharCount", SqlDbType.BigInt,8),
                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
                    new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
                    new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                    new SqlParameter("@ResearchSpot", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    new SqlParameter("@CityID", SqlDbType.Char,10),
                    new SqlParameter("@CountyID", SqlDbType.Char,10), 
                    new SqlParameter("@activeAdress",SqlDbType.VarChar,100),
                    new SqlParameter("@activeDateFrom",SqlDbType.VarChar,30),
                    new SqlParameter("@activeDateTo",SqlDbType.VarChar,30),
                    new SqlParameter("@mainUnit",SqlDbType.VarChar,100),
                    new SqlParameter("@secondUnit",SqlDbType.VarChar,100),
                    new SqlParameter("@OrganizationName",SqlDbType.VarChar,100),
                    new SqlParameter("@Name",SqlDbType.VarChar,100),
                    new SqlParameter("@TelCountryCode",SqlDbType.Char,6),
                    new SqlParameter("@TelStateCode",SqlDbType.Char,8),
                    new SqlParameter("@TelNum",SqlDbType.VarChar,100),
                    new SqlParameter("@FaxCountryCode",SqlDbType.Char,6),
                    new SqlParameter("@FaxStateCode",SqlDbType.Char,8),
                    new SqlParameter("@FaxNum",SqlDbType.VarChar,100),
                    new SqlParameter("@Mobile",SqlDbType.VarChar,30),
                    new SqlParameter("@address",SqlDbType.VarChar,30),
                    new SqlParameter("@WebSite",SqlDbType.VarChar,100),
                    new SqlParameter("@PostCode",SqlDbType.VarChar,10),
                    new SqlParameter("@email",SqlDbType.VarChar,50),
                    new SqlParameter("@auditingstatus",SqlDbType.TinyInt,1)
            };
           parameters[0].Direction = ParameterDirection.Output;
           
            parameters[1].Value = model.Title;
            parameters[2].Value = model.publishT;
            parameters[3].Value = model.Hit;
            parameters[4].Value = model.IsCore;
            parameters[5].Value = model.LoginName;
            parameters[6].Value = model.KeyWord;
            parameters[7].Value = model.Descript;
            parameters[8].Value = model.NewsTypeID;
            parameters[9].Value = model.subTitle;
            parameters[10].Value = model.NewsLblStatus;
            parameters[11].Value = model.NewsIndustryID;
            parameters[12].Value = model.Origin;
            parameters[13].Value = model.Author;
            parameters[14].Value = model.RedirectUrl;
            parameters[15].Value = model.IsRedirect;
            parameters[16].Value = model.Summary;
            parameters[17].Value = model.Content;
            parameters[18].Value = model.Pic1;
            parameters[19].Value = model.PicAbout;
            parameters[20].Value = model.PageStatus;
            parameters[21].Value = model.PageCharCount;
            parameters[22].Value = model.ShortInfoControlID;
            parameters[23].Value = model.ShortTitle;
            parameters[24].Value = model.ShortContent;
            parameters[25].Value = model.ResearchSpot;
            parameters[26].Value = model.strRemark;
            parameters[27].Value = model.ProvinceID;
            parameters[28].Value = model.CityID;
            parameters[29].Value = model.CountyID;
            parameters[30].Value = model.activeAdress;
            parameters[31].Value = model.activeDateFrom;
            parameters[32].Value = model.activeDateTo;
            parameters[33].Value = model.mainUnit;
            parameters[34].Value = model.secondUnit;
            parameters[35].Value = model.OrganizationName;
            parameters[36].Value = model.Name;
            parameters[37].Value = model.TelCountryCode;
            parameters[38].Value = model.TelStateCode;
            parameters[39].Value = model.TelNum;
            parameters[40].Value = model.FaxCountryCode;
            parameters[41].Value = model.FaxStateCode;
            parameters[42].Value = model.FaxNum;
            parameters[43].Value = model.Mobile;
            parameters[44].Value = model.address;
            parameters[45].Value = model.WebSite;
            parameters[46].Value = model.PostCode;
            parameters[47].Value = model.Email;
            parameters[48].Value = model.auditingstatus;
            int rowsAffected;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {

                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Insert_ActiveType_Manage", parameters);

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
            return true;
        }
        //    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Insert_ActiveType_Manage", parameters);

        //    infoID = (long)parameters[0].Value;

        //    if (infoID > 0)
        //        return true;
        //    return false;
        //}


        /// <summary>
        ///  更新资讯信息 
        /// </summary>
        public bool UpdateMerchantNews(Tz888.Model.TPMerchant model)
        {
            try
            {
                long infoID;
                SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
                    new SqlParameter("@publishT", SqlDbType.DateTime,8),
                    new SqlParameter("@Hit", SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
                    new SqlParameter("@DesCript", SqlDbType.VarChar,100), 
                    new SqlParameter("@DisplayTitle", SqlDbType.Char,50),
                    //new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime,4),
                    //new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime,4),
                    //new SqlParameter("@ValidateTerm",SqlDbType.Int,4),
                    //new SqlParameter("@TemplateID",SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100), 
                    new SqlParameter("@auditingstatus",SqlDbType.TinyInt,1),
					new SqlParameter("@NewsTypeID", SqlDbType.Char,10),
					new SqlParameter("@subTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NewsLblStatus", SqlDbType.Char,10),
                    new SqlParameter("@NewsIndustryID",SqlDbType.Char,10),
                    new SqlParameter("@Origin", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,20),
                    new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
                    new SqlParameter("@IsRedirect", SqlDbType.Bit),
                    new SqlParameter("@Summary", SqlDbType.Text),
                    new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@Pic1", SqlDbType.VarChar,100),
                    new SqlParameter("@PicAbout", SqlDbType.VarChar,30),
                    new SqlParameter("@PageStatus", SqlDbType.Int,4),
                    new SqlParameter("@PageCharCount", SqlDbType.BigInt,8),
                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
                    new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
                    new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                    new SqlParameter("@ResearchSpot", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    new SqlParameter("@CityID", SqlDbType.Char,10),
                    new SqlParameter("@CountyID", SqlDbType.Char,10),
                    //new SqlParameter("@InfoCode",SqlDbType.Char,30)
                    new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),
            };
                parameters[0].Value = model.infoID;
                parameters[1].Value = model.Title;
                parameters[2].Value = model.publishT;
                parameters[3].Value = model.Hit;
                parameters[4].Value = model.IsCore;
                parameters[5].Value = model.LoginName;
                parameters[6].Value = model.KeyWord;
                parameters[7].Value = model.Descript;
                parameters[8].Value = model.DisplayTitle;
                //parameters[9].Value = model.FrontDisplayTime;
                //parameters[10].Value = model.ValidateStartTime;
                //parameters[11].Value = model.ValidateTerm;
                //parameters[12].Value = model.TemplateID;
                parameters[9].Value = model.HtmlFile;
                parameters[10].Value = model.auditingstatus;
                parameters[11].Value = model.NewsTypeID;
                parameters[12].Value = model.subTitle;
                parameters[13].Value = model.NewsLblStatus;
                parameters[14].Value = model.NewsIndustryID;
                parameters[15].Value = model.Origin;
                parameters[16].Value = model.Author;
                parameters[17].Value = model.RedirectUrl;
                parameters[18].Value = model.IsRedirect;
                parameters[19].Value = model.Summary;
                parameters[20].Value = model.Content;
                parameters[21].Value = model.Pic1;
                parameters[22].Value = model.PicAbout;
                parameters[23].Value = model.PageStatus;
                parameters[24].Value = model.PageCharCount;
                parameters[25].Value = model.ShortInfoControlID;
                parameters[26].Value = model.ShortTitle;
                parameters[27].Value = model.ShortContent;
                parameters[28].Value = model.ResearchSpot;
                parameters[29].Value = model.strRemark;
                parameters[30].Value = model.ProvinceID;
                parameters[31].Value = model.CityID;
                parameters[32].Value = model.CountyID;
                //parameters[33].Value = model.InfoCode;
                parameters[33].Value = model.AuditingRemark;
            //    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Update_New_Manage", parameters);
            //    return true;
            //}
                int rowsAffected;
                using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
                {
                    sqlConn.Open();
                    SqlTransaction sqlTran = sqlConn.BeginTransaction();
                    try
                    {

                        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Update_New_Manage", parameters);

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
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        ///  更新活动资讯信息 
        /// </summary>
        public bool UpdateActiveMerchantNews(Tz888.Model.TPMerchant model)
        {
            try
            {
                long infoID;
                SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
                    new SqlParameter("@publishT", SqlDbType.DateTime,8),
                    new SqlParameter("@Hit", SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore", SqlDbType.Bit,1),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
                    new SqlParameter("@DesCript", SqlDbType.VarChar,100), 
                    new SqlParameter("@DisplayTitle", SqlDbType.Char,50), 
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100), 
                    new SqlParameter("@auditingstatus",SqlDbType.TinyInt,1),
					new SqlParameter("@NewsTypeID", SqlDbType.Char,10),
					new SqlParameter("@subTitle", SqlDbType.VarChar,100),
					new SqlParameter("@NewsLblStatus", SqlDbType.Char,10),
                    new SqlParameter("@NewsIndustryID",SqlDbType.Char,10), 
					new SqlParameter("@Author", SqlDbType.VarChar,20),
                    new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
                    new SqlParameter("@IsRedirect", SqlDbType.Bit),
                    new SqlParameter("@Summary", SqlDbType.Text),
                    new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@Pic1", SqlDbType.VarChar,100),
                    new SqlParameter("@PicAbout", SqlDbType.VarChar,30),
                    new SqlParameter("@PageStatus", SqlDbType.Int,4),
                    new SqlParameter("@PageCharCount", SqlDbType.BigInt,8),
                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
                    new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
                    new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
                    new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                    new SqlParameter("@ResearchSpot", SqlDbType.Char,10),
                    new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    new SqlParameter("@CityID", SqlDbType.Char,10),
                    new SqlParameter("@CountyID", SqlDbType.Char,10), 
                    new SqlParameter("@activeAdress",SqlDbType.VarChar,100),
                    new SqlParameter("@activeDateFrom",SqlDbType.VarChar,30),
                    new SqlParameter("@activeDateTo",SqlDbType.VarChar,30),
                    new SqlParameter("@Name", SqlDbType.VarChar,100),
                    new SqlParameter("@mainUnit", SqlDbType.VarChar,100),
                    new SqlParameter("@secondUnit", SqlDbType.VarChar,100),
                    new SqlParameter("@TelCountryCode", SqlDbType.Char,6),
                    new SqlParameter("@TelStateCode", SqlDbType.Char,8),
                    new SqlParameter("@TelNum", SqlDbType.VarChar,100),
                    new SqlParameter("@FaxCountryCode", SqlDbType.Char,6),
                    new SqlParameter("@FaxStateCode", SqlDbType.Char,8),
                    new SqlParameter("@FaxNum", SqlDbType.VarChar,100),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
                    new SqlParameter("@address", SqlDbType.VarChar,100),
                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                    new SqlParameter("@PostCode", SqlDbType.VarChar,10),
                    new SqlParameter("@email", SqlDbType.VarChar,50),
                    new SqlParameter("@OrganizationName", SqlDbType.VarChar,100),
                    new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),
            };
                parameters[0].Value = model.infoID;
                parameters[1].Value = model.Title;
                parameters[2].Value = model.publishT;
                parameters[3].Value = model.Hit;
                parameters[4].Value = model.IsCore;
                parameters[5].Value = model.LoginName;
                parameters[6].Value = model.KeyWord;
                parameters[7].Value = model.Descript;
                parameters[8].Value = model.DisplayTitle;
                parameters[9].Value = model.HtmlFile;
                parameters[10].Value = model.auditingstatus;
                parameters[11].Value = model.NewsTypeID;
                parameters[12].Value = model.subTitle;
                parameters[13].Value = model.NewsLblStatus;
                parameters[14].Value = model.NewsIndustryID;
                parameters[15].Value = model.Author;
                parameters[16].Value = model.RedirectUrl;
                parameters[17].Value = model.IsRedirect;
                parameters[18].Value = model.Summary;
                parameters[19].Value = model.Content;
                parameters[20].Value = model.Pic1;
                parameters[21].Value = model.PicAbout;
                parameters[22].Value = model.PageStatus;
                parameters[23].Value = model.PageCharCount;
                parameters[24].Value = model.ShortInfoControlID;
                parameters[25].Value = model.ShortTitle;
                parameters[26].Value = model.ShortContent;
                parameters[27].Value = model.ResearchSpot;
                parameters[28].Value = model.strRemark;
                parameters[29].Value = model.ProvinceID;
                parameters[30].Value = model.CityID;
                parameters[31].Value = model.CountyID;
                parameters[32].Value = model.activeAdress;
                parameters[33].Value = model.activeDateFrom;
                parameters[34].Value = model.activeDateTo;
                parameters[35].Value = model.Name;
                parameters[36].Value = model.mainUnit;
                parameters[37].Value = model.secondUnit;
                parameters[38].Value = model.TelCountryCode;
                parameters[39].Value = model.TelStateCode;
                parameters[40].Value = model.TelNum;
                parameters[41].Value = model.FaxCountryCode;
                parameters[42].Value = model.FaxStateCode;
                parameters[43].Value = model.FaxNum;
                parameters[44].Value = model.Mobile;
                parameters[45].Value = model.address;
                parameters[46].Value = model.WebSite;
                parameters[47].Value = model.PostCode;
                parameters[48].Value = model.Email;
                parameters[49].Value = model.OrganizationName;
                parameters[50].Value = model.AuditingRemark;
                int rowsAffected;
                using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
                {
                    sqlConn.Open();
                    SqlTransaction sqlTran = sqlConn.BeginTransaction();
                    try
                    {

                        SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Update_ActiveType_Manage", parameters);

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
                return true;
            }
            //    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Update_ActiveType_Manage", parameters);
            //    return true;
            //}
            catch (Exception ex)
            {
                return false;
            }

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idLST">编号列表以“，”隔开但不以“，”结尾</param>
        /// <returns></returns>
        #region------------删除资讯信息
        public bool DeleteMerchantNews(string idLST)
        {
            SqlParameter[] parameters ={ new SqlParameter("@idlst", SqlDbType.VarChar, 300) };

            parameters[0].Value = idLST;

            return DBUtility.DbHelperSQL.RunProcLob("NewsTab_Delete_New", parameters);
        }
        #endregion


        /// <summary>
        /// 资讯信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetNewsList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     ref long TotalCount
                                    )
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListNewsTopNums(
                                            "NewsTabList_New",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idLST">编号列表以“，”隔开但不以“，”结尾</param>
        /// <returns></returns>
        #region------------删除收藏夹信息
        public bool DeleteCollectionList(string idLST)
        {
            SqlParameter[] parameters ={ new SqlParameter("@idlst", SqlDbType.VarChar, 300) };

            parameters[0].Value = idLST;

            return DBUtility.DbHelperSQL.RunProcLob("CommendTab_Delete_Commend", parameters);
        }
        #endregion


        /// <summary>
        /// 收藏夹信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetCollectionList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     ref long TotalCount
                                    )
        {
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            return (mCF.dsGetListNewsTopNums(
                                            "NewsTabList_CommendTab",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }

        /// <summary>
        /// 查询资讯类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetNewsType()
        {
            string strsql = "select NewsTypeID,NewsTypeName from SETNEWSTYPETAB where remark='招商频道'";
            return DBUtility.DbHelperSQL.Query(strsql);
        }

        public DataSet GetOneNewsList(string InfoID)
        {
            string strsql = "select * from NewsVIW_Merchant where InfoID=" + InfoID;
            return DBUtility.DbHelperSQL.Query(strsql);
        }

        public Tz888.Model.TPMerchant objGetNewsInfoByInfoID(long InfoID)
        {
            Tz888.Model.TPMerchant model = new Tz888.Model.TPMerchant();
            string strsql = "select * from NewsVIW_Merchant where InfoID=" + InfoID;
            DataSet ds = new DataSet();
            ds = DBUtility.DbHelperSQL.Query(strsql);
            model.infoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {

                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.publishT = DateTime.Parse(ds.Tables[0].Rows[0]["publishT"].ToString());
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.Origin = ds.Tables[0].Rows[0]["Origin"].ToString();
                model.Pic1 = ds.Tables[0].Rows[0]["Pic1"].ToString();
                model.PicAbout = ds.Tables[0].Rows[0]["PicAbout"].ToString();
                model.auditingstatus = int.Parse(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
                model.KeyWord = ds.Tables[0].Rows[0]["KeyWord"].ToString();
                model.NewsTypeName = ds.Tables[0].Rows[0]["NewsTypeName"].ToString();
                model.Descript = ds.Tables[0].Rows[0]["Descript"].ToString();
                model.FrontDisplayTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["FrontDisplayTime"]);
                model.HtmlFile = ds.Tables[0].Rows[0]["HtmlFile"].ToString();
                model.InfoCode = ds.Tables[0].Rows[0]["InfoCode"].ToString();
                return model;
            }
            else
            {
                return null;
            }

        }

        public bool UpdateHtmlFile(long infoID, string htmlfile)
        {
            try
            {
                SqlParameter[] parameters = {
				                	new SqlParameter("@infoID", SqlDbType.BigInt,8),
                                     new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                         };
                parameters[0].Value = infoID;
                parameters[1].Value = htmlfile;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "NewsTab_Update_HtmlFile_Manage", parameters);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 获取招商热门区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetHostCity()
        {
            string strsql = "select * from HostCityViw";
            DataSet ds = DBUtility.DbHelperSQL.Query(strsql);
            return ds;
        }
        /// <summary>
        /// 获取招商热门产业园区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetHostArea()
        {
            string strsql = "select * from HostAreaViw";
            DataSet ds = DBUtility.DbHelperSQL.Query(strsql);
            return ds;
        }

        /// <summary>
        /// 获取省内资源总数
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public int GetCountResources(string ProvinceID)
        {
            string strsql = "select count(*) count from merchantinfotab where ProvinceID =" + ProvinceID;
            int count = DBUtility.DbHelperSQL.ExecuteSql(strsql);
            return count;
        }

        /// <summary>
        /// 获取市内资源总数
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public int GetCountCityResources(string CityID)
        {
            string strsql = "select count(*) count from merchantinfotab where CityID =" + CityID;
            int count = DBUtility.DbHelperSQL.ExecuteSql(strsql);
            return count;
        }
        /// <summary>
        /// 获取各总数
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllCountList()
        {
            string strsql = "select * from CountView";
            return DBUtility.DbHelperSQL.Query(strsql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public DataSet GetCountList(string ProvinceID)
        {
            DataSet ds = null;
            SqlParameter[] parameters = { new SqlParameter("@ProvinceID", SqlDbType.Char, 10) };
            parameters[0].Value = ProvinceID;
            try
            {
                ds = DBUtility.DbHelperSQL.RunProcedure("CountArea_MerchantMes", parameters, "ds");

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            return ds;
        }

        #region 专题列表
        public DataTable GetList()
        {
            DataTable dt = null;
            SqlParameter[] parameters = { new SqlParameter("@flag", SqlDbType.VarChar, 50) };
            parameters[0].Value = "Subject_Select";
            try
            {
                dt = DBUtility.DbHelperSQL.RunProcedure("SubjectTab_Up", parameters, "dtSubjectTab_Up").Tables[0];

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


        #region 栏目列表 得到指定专题的栏目 返回DataTable
        public DataTable GetList(int subjectID)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {
											new  SqlParameter("@SubjectID",SqlDbType.Int),
											new SqlParameter("@flag", SqlDbType.VarChar,50)};
            parameters[0].Value = subjectID;
            parameters[1].Value = "SelectBySubjectID";
            try
            {

                dt = DBUtility.DbHelperSQL.RunProcedure("SubjectMenu", parameters, "dtSubjectMenu").Tables[0];
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


        #region   添加
        public bool InsertInfo(Tz888.Model.subjectInfoNewTab model)
        {
            bool blRet = false;
            SqlParameter[] parameters = {
											new SqlParameter("@InfoID", SqlDbType.BigInt),
											new SqlParameter("@SubjectID", SqlDbType.Int,4),
											new SqlParameter("@MenuID", SqlDbType.Int,4),
											new SqlParameter("@Editorer", SqlDbType.VarChar,50),
											new SqlParameter("@isTop", SqlDbType.Int,4),
											new SqlParameter("@titleStyle", SqlDbType.VarChar,100),
											new SqlParameter("@flag", SqlDbType.VarChar,100)};
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.SubjectID;
            parameters[2].Value = model.MenuID;
            parameters[3].Value = model.Editorer;
            parameters[4].Value = model.isTop;
            parameters[5].Value = model.titleStyle;
            parameters[6].Value = "SubjectInfo_Insert";
            try
            {

                blRet = DBUtility.DbHelperSQL.RunProcLob("SubjectInfo", parameters);

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            return blRet;

        }
        #endregion
    }
}
