using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using Tz888.IDAL;
using System.Data.SqlClient;
using Tz888.DBUtility;//请先添加引用

namespace Tz888.SQLServerDAL
{
    public class UserInfoH 
    {
        

        #region 申请提供专业服务信息（机构）


        public long OfferInsert(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
          Tz888.Model.UserInfoZ model,
           Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------资源信息主体----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
					//new SqlParameter("@Title", SqlDbType.VarChar,100),
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
                    new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
					//new SqlParameter("@Descript", SqlDbType.NChar,2000),
					//new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					 new SqlParameter("@Descript", SqlDbType.NVarChar,100),
                  

                //---------------------------END---------------------------
               //-------------------------短信息--------------------------

					
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),
                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
                //---------------------------END---------------------------
               
                //-----------------------申请提供服务详细信息-----------------
					new SqlParameter("@CompanyName", SqlDbType.VarChar,50),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
					new SqlParameter("@ServiesBID", SqlDbType.VarChar,150),
					new SqlParameter("@ServiesMID", SqlDbType.VarChar,150),
					new SqlParameter("@EmployeeCount", SqlDbType.Int,4),
					new SqlParameter("@RegistMoeny", SqlDbType.Float,8),
					new SqlParameter("@RegistYear", SqlDbType.Float,8),
					new SqlParameter("@Turnover", SqlDbType.Float,8),
					new SqlParameter("@BusinesDetails", SqlDbType.VarChar,500),
					new SqlParameter("@WebSite", SqlDbType.VarChar,100),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkTel", SqlDbType.VarChar,20),
					new SqlParameter("@LinkFax", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@CompanyAbout", SqlDbType.Text),
                    new SqlParameter("@isOpen", SqlDbType.Bit),
                    new SqlParameter("@AuditStatus", SqlDbType.Int),
                    new SqlParameter("@AuditMan", SqlDbType.VarChar,20),
                    new SqlParameter("@ContactDefault", SqlDbType.Bit),
                    new SqlParameter("@StructID", SqlDbType.VarChar,10),
                //---------------------------END---------------------------

            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = mainInfoModel.HtmlFile;
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
            parameters[18].Value = mainInfoModel.ValidateTerm;
            parameters[19].Value = mainInfoModel.TemplateID;
            //parameters[18].Value = mainInfoModel.Descript;
            //parameters[19].Value = mainInfoModel.DisplayTitle;
            parameters[20].Value = mainInfoModel.FrontDisplayTime;
            parameters[21].Value = mainInfoModel.ValidateStartTime;
            parameters[22].Value = mainInfoModel.Descript;

            parameters[23].Value = shortInfoModel.ShortTitle;
            parameters[24].Value = shortInfoModel.ShortContent;
            parameters[25].Value = shortInfoModel.Remark;
            parameters[26].Value = shortInfoModel.ShortInfoControlID;


           // parameters[26].Value = model.UserName;
            parameters[27].Value = model.CompanyName;
            parameters[28].Value = model.CountryCode;
            parameters[29].Value = model.ProvinceID;
            parameters[30].Value = model.CityID;
            parameters[31].Value = model.CountyID;
            parameters[32].Value = model.ServiesBID;
            parameters[33].Value = model.ServiesMID;
            parameters[34].Value = model.EmployeeCount;
            parameters[35].Value = model.RegistMoeny;
            parameters[36].Value = model.RegistYear;
            parameters[37].Value = model.Turnover;
            parameters[38].Value = model.BusinesDetails;
            parameters[39].Value = model.WebSite;
            parameters[40].Value = model.LinkMan;
            parameters[41].Value = model.LinkTel;
            parameters[42].Value = model.LinkFax;
            parameters[43].Value = model.Email;
            parameters[44].Value = model.CompanyAbout;
            parameters[45].Value = model.isOpen;
            parameters[46].Value = model.AuditStatus;
            parameters[47].Value = model.AuditMan;
            parameters[48].Value = model.ContactDefault;
            parameters[49].Value = model.Structid;
           


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Offer_Insert", parameters, out rowsAffected);
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
        #region 修改
       

        public bool update(Tz888.Model.Info.MainInfoModel mainInfoModel,
          Tz888.Model.UserInfoZ model,
         Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                         //-------------------------短信息--------------------------


					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),


                //---------------------------END---------------------------
                //---------------------资源信息主体----------------------

					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@Descript", SqlDbType.NVarChar,2000),
					
                //---------------------------END---------------------------

                //-----------------------申请提供服务详细信息-----------------

					
					new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@ServiesBID", SqlDbType.VarChar,150),
					new SqlParameter("@ServiesMID", SqlDbType.VarChar,150),
					new SqlParameter("@EmployeeCount", SqlDbType.Int,4),
					new SqlParameter("@RegistMoeny", SqlDbType.Float,8),
					new SqlParameter("@RegistYear", SqlDbType.Float,8),
					new SqlParameter("@Turnover", SqlDbType.Float,8),
					new SqlParameter("@BusinesDetails", SqlDbType.VarChar,500),
					new SqlParameter("@WebSite", SqlDbType.VarChar,100),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@LinkTel", SqlDbType.VarChar,20),
					new SqlParameter("@LinkFax", SqlDbType.VarChar,20),
                    new SqlParameter("@InfoID", SqlDbType.Int),
                    new SqlParameter("@StructID", SqlDbType.VarChar,10),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@flag", SqlDbType.VarChar,50),


                //---------------------------END---------------------------
       
             };
            parameters[0].Value = shortInfoModel.ShortTitle;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.Descript;
          
            parameters[4].Value = model.CountryCode;
            parameters[5].Value = model.ProvinceID;
            parameters[6].Value = model.CityID;
            parameters[7].Value = model.CountyID;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.ServiesBID;
            parameters[10].Value = model.ServiesMID;
            parameters[11].Value = model.EmployeeCount;
            parameters[12].Value = model.RegistMoeny;
            parameters[13].Value = model.RegistYear;
            parameters[14].Value = model.Turnover;
            parameters[15].Value = model.BusinesDetails;
            parameters[16].Value = model.WebSite;
            parameters[17].Value = model.LinkMan;
            parameters[18].Value = model.LinkTel;
            parameters[19].Value = model.LinkFax;

            parameters[20].Value = model.InfoID;
            parameters[21].Value = model.Structid;
            parameters[22].Value = model.UserName;
            parameters[23].Value = "userupdate";

            return DbHelperSQL.RunProcLob("OfferUpdate", parameters);



        }


        #endregion
        public Tz888.Model.UserInfoZ getModel(string tablename,string fieldname,string where)
        {
            Tz888.Model.UserInfoZ mode = new Tz888.Model.UserInfoZ();

            SqlParameter[] parameters = {
					new SqlParameter("@tableName", SqlDbType.VarChar,200),
                    new SqlParameter("@fieldName", SqlDbType.VarChar,1000),
                    new SqlParameter("@where", SqlDbType.VarChar,500),

                };
            parameters[0].Value =tablename;
            parameters[1].Value=fieldname;
            parameters[2].Value=where;
            DataSet ds = DbHelperSQL.RunProcedures("Conn", parameters, "OfferInfoTab");
            if (ds != null)
            {
                DataTable dt = ds.Tables["OfferInfoTab"];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        mode.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                        mode.CountryCode = dt.Rows[0]["CountryCode"].ToString();
                        mode.ProvinceID = dt.Rows[0]["ProvinceID"].ToString();
                        mode.CityID = dt.Rows[0]["CityID"].ToString();
                        mode.CountyID = dt.Rows[0]["CountyID"].ToString();
                        mode.Email = dt.Rows[0]["Email"].ToString();
                        mode.Structid = dt.Rows[0]["Structid"].ToString();
                        mode.ServiesBID = dt.Rows[0]["ServiesBID"].ToString();
                        mode.ServiesMID = dt.Rows[0]["ServiesMID"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["EmployeeCount"].ToString()))
                        {  mode.EmployeeCount =int.Parse( dt.Rows[0]["EmployeeCount"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["RegistMoeny"].ToString()))
                        {
                            mode.RegistMoeny =decimal.Parse( dt.Rows[0]["RegistMoeny"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["RegistYear"].ToString()))
                        { mode.RegistYear =decimal.Parse( dt.Rows[0]["RegistYear"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Turnover"].ToString()))
                        {  mode.Turnover =decimal.Parse( dt.Rows[0]["Turnover"].ToString());
                        }
                      
                        mode.BusinesDetails = dt.Rows[0]["BusinesDetails"].ToString();
                        mode.WebSite = dt.Rows[0]["WebSite"].ToString();
                        mode.LinkMan = dt.Rows[0]["LinkMan"].ToString();
                        mode.LinkFax = dt.Rows[0]["LinkFax"].ToString();
                        mode.LinkTel = dt.Rows[0]["LinkTel"].ToString();
                      

                    }

                }
            }
              return mode;

        }

        public bool delete(int infoid)
        {
            SqlParameter[] parameters = { new SqlParameter("@InfoID", SqlDbType.Int), new SqlParameter("@flag", SqlDbType.VarChar,50), };
            parameters[0].Value = infoid;
            parameters[1].Value ="delete";

            return DbHelperSQL.RunProcLob("OfferUpdate", parameters);
        }
    }
}
