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
    public  class OpportunityInfoDAL:IOpportunityInfol
    {

        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.OpportunityInfoModel opportunity,
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            )
        {
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@Title",SqlDbType.VarChar,100),
											new SqlParameter("@InfoCode",SqlDbType.Char,30),
											new SqlParameter("@publishT",SqlDbType.DateTime),
											new SqlParameter("@Hit",SqlDbType.BigInt),

											new SqlParameter("@IsCore",SqlDbType.Bit),
											new SqlParameter("@IndexOrderNum",SqlDbType.BigInt),
											new SqlParameter("@IndexTopValidateDate",SqlDbType.Int),
											new SqlParameter("@IndexPicInfoNum",SqlDbType.BigInt),
											new SqlParameter("@InfoTypeOrderNum",SqlDbType.BigInt),
											new SqlParameter("@InfoTypeTopValidateDate",SqlDbType.Int),
											new SqlParameter("@InfoTypePicInfoNum",SqlDbType.BigInt),

											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@InfoOriginRoleName",SqlDbType.Char,10),

											new SqlParameter("@GradeID",SqlDbType.Char,10),
											new SqlParameter("@FixPriceID",SqlDbType.Char,10),
											new SqlParameter("@FeeStatus",SqlDbType.TinyInt),

											//2005/12/12  add
											new SqlParameter("@KeyWord",SqlDbType.VarChar,50),
											new SqlParameter("@Descript",SqlDbType.VarChar,100),
											new SqlParameter("@DisplayTitle",SqlDbType.VarChar,50),
											new SqlParameter("@FrontDisplayTime",SqlDbType.SmallDateTime),
											new SqlParameter("@ValidateStartTime",SqlDbType.SmallDateTime),
											new SqlParameter("@ValidateTerm",SqlDbType.Int),
											new SqlParameter("@TemplateID",SqlDbType.Char,10),
											new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),//该字段不需要更新，只有在审核时才更新

											//商机信息
											new SqlParameter("@AdTitle",SqlDbType.VarChar,50),
											new SqlParameter("@OpportunityType",SqlDbType.Char,10),
											new SqlParameter("@CountryCode",SqlDbType.Char,10),
											new SqlParameter("@ProvinceID",SqlDbType.Char,10),
											new SqlParameter("@CountyID",SqlDbType.Char,10),
											
											new SqlParameter("@IndustryOpportunityID",SqlDbType.Char,10),
											new SqlParameter("@ValidateID",SqlDbType.Char,10),

											new SqlParameter("@Pic1",SqlDbType.VarChar,100),											
											new SqlParameter("@Content",SqlDbType.Text),
											new SqlParameter("@Analysis",SqlDbType.Text),
											new SqlParameter("@Request",SqlDbType.Text),
											new SqlParameter("@Flow",SqlDbType.Text),
											new SqlParameter("@Remark",SqlDbType.Text),											

											new SqlParameter("@ComName",SqlDbType.VarChar, 40),
											new SqlParameter("@LinkMan",SqlDbType.VarChar,20),
											new SqlParameter("@Tel",SqlDbType.VarChar,30),
											new SqlParameter("@Fax",SqlDbType.VarChar,30),
											new SqlParameter("@Mobile",SqlDbType.VarChar,20),
											new SqlParameter("@Address",SqlDbType.VarChar,50),
											new SqlParameter("@PostCode",SqlDbType.VarChar,6),
											new SqlParameter("@Email",SqlDbType.VarChar,40),
											new SqlParameter("@WebSite",SqlDbType.VarChar,40),
	
											// 短内容信息表
											new SqlParameter("@ShortInfoControlID",SqlDbType.Char,20),
											new SqlParameter("@ShortTitle",SqlDbType.VarChar,100),
											new SqlParameter("@ShortContent",SqlDbType.VarChar,100),
											new SqlParameter("@strRemark",SqlDbType.VarChar,50)	
										};

            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[0].Value = mainInfoModel.InfoID;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.publishT;
            parameters[4].Value = mainInfoModel.Hit;

            parameters[5].Value =mainInfoModel.IsCore;
            parameters[6].Value =0;
            parameters[7].Value =0;
            parameters[8].Value =0;
            parameters[9].Value =0;
            parameters[10].Value =0;
            parameters[11].Value =0;

            parameters[12].Value =mainInfoModel.LoginName;
            parameters[13].Value =mainInfoModel.InfoOriginRoleName;

            parameters[14].Value ="0";
            parameters[15].Value ="1";
            parameters[16].Value = 2; //付费 0付费,1未付费,2无需付费

            parameters[17].Value = AlterKeyWord(mainInfoModel.KeyWord);
            parameters[18].Value =mainInfoModel.Descript;
            parameters[19].Value =mainInfoModel.DisplayTitle;
            parameters[20].Value =mainInfoModel.FrontDisplayTime;
            parameters[21].Value =mainInfoModel.ValidateStartTime;
            parameters[22].Value =mainInfoModel.ValidateTerm;
            parameters[23].Value =mainInfoModel.TemplateID;
            parameters[24].Value =mainInfoModel.HtmlFile;

            //商机信息
            parameters[25].Value = opportunity.AdTitle;
            parameters[26].Value = opportunity.OpportunityType;

            parameters[27].Value = opportunity.CountryCode;

            if (opportunity.ProvinceID  == "")
                parameters[28].Value = System.DBNull.Value;
            else
                parameters[28].Value = opportunity.ProvinceID;

            if (opportunity.CountyID == "")
                parameters[29].Value = System.DBNull.Value;
            else
                parameters[29].Value = opportunity.CountyID;

            parameters[30].Value = opportunity.IndustryOpportunityID;
            parameters[31].Value = opportunity.ValidateID;

            parameters[32].Value = opportunity.Pic1;
            parameters[33].Value = opportunity.Content;
            parameters[34].Value = opportunity.Analysis;
            parameters[35].Value = opportunity.Request;
            parameters[36].Value = opportunity.Flow;
            parameters[37].Value = opportunity.Remark;

            parameters[38].Value = opportunity.ComName;
            parameters[39].Value = opportunity.LinkMan;
            parameters[40].Value = opportunity.Tel; 
            parameters[41].Value = opportunity.Fax; 
            parameters[42].Value = opportunity.Mobile;
            parameters[43].Value = opportunity.Address; 
            parameters[44].Value = opportunity.PostCode; 
            parameters[45].Value = opportunity.Email; 
            parameters[46].Value = opportunity.WebSite;


            parameters[47].Value = shortInfoModel.ShortInfoControlID; 
            parameters[48].Value = shortInfoModel.ShortTitle; 
            parameters[49].Value = shortInfoModel.ShortContent; 
            parameters[50].Value = shortInfoModel.Remark;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "OpportunityInfoTabnewss_Insert", parameters, out rowsAffected);
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

        public static string AlterKeyWord(string KeyWord)
        {
            string[] strKeyword = KeyWord.Trim().Split(' ');
            string strtmpKeyword = "";
            for (int i = 0; i < strKeyword.Length; i++)
            {
                if (strKeyword[i].ToString() != "")
                {
                    strtmpKeyword = strtmpKeyword + strKeyword[i].ToString() + ",";
                }
            }
            if (strtmpKeyword.Trim() != "")
            {
                strtmpKeyword = strtmpKeyword.Substring(0, strtmpKeyword.Length - 1);
            }

            return (strtmpKeyword.Replace(" ", ","));
        }

        /// <summary>
        /// 所属行业
        /// </summary>
        public DataView GetIndustry()
        {
            string sql = "select IndustryOpportunityID,IndustryOpportunityName from SetIndustryOpportunityTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 商机类别
        /// </summary>
        public DataView GetOpportun()
        {
            string sql = "select OpportunityTypeID,OpportunityTypeName from SetOpportunityTypeTab";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].DefaultView;
        }

    }
}
