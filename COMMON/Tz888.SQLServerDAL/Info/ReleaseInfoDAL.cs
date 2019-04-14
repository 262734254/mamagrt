using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.Info;
using Tz888.IDAL.Info;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL.Info
{
    public class ReleaseInfoDAL
    {
        #region 发布需求服务信息


        public long ReleaseInsert(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.BusinesProcess model,
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
					new SqlParameter("@Descript", SqlDbType.NChar,2000),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------发布需求详细信息-----------------

					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					//new SqlParameter("@Title", SqlDbType.VarChar,50),（上方已有）
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@SubmitMan", SqlDbType.VarChar,16),
					//new SqlParameter("@Descript", SqlDbType.VarChar,300),（上方已有）
					new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
                    new SqlParameter("@Email", SqlDbType.VarChar,100),
                    new SqlParameter("@ServiesBID", SqlDbType.Int),
                    new SqlParameter("@ServiesMID", SqlDbType.Int),

                //---------------------------END---------------------------



                //-------------------------短信息--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

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



            parameters[25].Value = model.UserName;
            // parameters[26].Value = model.Title;
            parameters[26].Value = model.CompanyName;
            parameters[27].Value = model.SubmitMan;
            //parameters[29].Value = model.Descript;
            parameters[28].Value = model.CountryCode;
            parameters[29].Value = model.ProvinceID;
            parameters[30].Value = model.CityID;
            parameters[31].Value = model.CountyID;
            parameters[32].Value = model.Address;
            parameters[33].Value = model.Tel;
            parameters[34].Value = model.Fax;
            parameters[35].Value = model.Email;
            parameters[36].Value = model.ServiesBID;
            parameters[37].Value = model.ServiesMID;

            parameters[38].Value = shortInfoModel.ShortInfoControlID;
            parameters[39].Value = shortInfoModel.ShortTitle;
            parameters[40].Value = shortInfoModel.ShortContent;
            parameters[41].Value = shortInfoModel.Remark;



            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //插入融资(项目)资源信息
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Release_Insert", parameters, out rowsAffected);
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
        public bool update(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.BusinesProcess model,
           Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                         //-------------------------短信息--------------------------


					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),


                //---------------------------END---------------------------
                //---------------------资源信息主体----------------------

					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@InfoCode", SqlDbType.Char,30),
					new SqlParameter("@Descript", SqlDbType.NChar,2000),
					
                //---------------------------END---------------------------

                //-----------------------发布需求详细信息-----------------

					//new SqlParameter("@Title", SqlDbType.VarChar,50),（上方已有）
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@SubmitMan", SqlDbType.VarChar,16),
					//new SqlParameter("@Descript", SqlDbType.VarChar,300),（上方已有）
					new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Fax", SqlDbType.VarChar,20),
                    new SqlParameter("@Email", SqlDbType.VarChar,100),
                    new SqlParameter("@ServiesBID", SqlDbType.Int),
                    new SqlParameter("@ServiesMID", SqlDbType.Int),
                	new SqlParameter("@LoginName", SqlDbType.Char,50),
                new SqlParameter("@InfoID", SqlDbType.BigInt),
                

                //---------------------------END---------------------------



       
             };
            parameters[0].Value = shortInfoModel.ShortTitle;
            parameters[1].Value = mainInfoModel.Title;
            parameters[2].Value = mainInfoModel.InfoCode;
            parameters[3].Value = mainInfoModel.Descript;
            // parameters[26].Value = model.Title;
            parameters[4].Value = model.CompanyName;
            parameters[5].Value = model.SubmitMan;
            //parameters[29].Value = model.Descript;
            parameters[6].Value = model.CountryCode;
            parameters[7].Value = model.ProvinceID;
            parameters[8].Value = model.CityID;
            parameters[9].Value = model.CountyID;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Tel;
            parameters[12].Value = model.Fax;
            parameters[13].Value = model.Email;
            parameters[14].Value = model.ServiesBID;
            parameters[15].Value = model.ServiesMID;
            parameters[16].Value = model.UserName;
            parameters[17].Value = mainInfoModel.InfoID;
            return DbHelperSQL.RunProcLob("ReleaseUserUpdate", parameters);



        }

        public Tz888.Model.BusinesProcess getModel(int id)
        {

            Tz888.Model.BusinesProcess model = new Tz888.Model.BusinesProcess();
            SqlParameter[] parameters = { new SqlParameter("@InfoID", SqlDbType.Int), };
            parameters[0].Value = id;
            DataSet ds = DbHelperSQL.RunProcedure("ReleaseGetModel", parameters, "Release");
            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["InfoID"].ToString()))
                {
                    model.InfoID = int.Parse(dt.Rows[0]["InfoID"].ToString());
                }
                if (!string.IsNullOrEmpty(dt.Rows[0]["Price"].ToString()))
                { model.Price = decimal.Parse(dt.Rows[0]["Price"].ToString()); }
            }
            model.ProvinceID = dt.Rows[0]["ProvinceID"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["ServiesBID"].ToString()))
            {
                model.ServiesBID = int.Parse(dt.Rows[0]["ServiesBID"].ToString());

            }
            if (!string.IsNullOrEmpty(dt.Rows[0]["ServiesMID"].ToString()))
            {
                model.ServiesMID = int.Parse(dt.Rows[0]["ServiesMID"].ToString());
            }
            model.SubmitMan = dt.Rows[0]["SubmitMan"].ToString();
            model.Tel = dt.Rows[0]["Tel"].ToString();
            model.Title = dt.Rows[0]["Title"].ToString();
            model.UserName = dt.Rows[0]["UserName"].ToString();
            model.Fax = dt.Rows[0]["Fax"].ToString();
            model.Email = dt.Rows[0]["Email"].ToString();
            model.Descript = dt.Rows[0]["Descript"].ToString();

            if (!string.IsNullOrEmpty(dt.Rows[0]["CreateDate"].ToString()))
            {
                model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
            }
            model.CountyID = dt.Rows[0]["CountyID"].ToString();
            model.CountryCode = dt.Rows[0]["CountryCode"].ToString();
            model.CompanyName = dt.Rows[0]["CompanyName"].ToString();
            model.CityID = dt.Rows[0]["CityID"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["AuditStatus"].ToString()))
            { model.AuditStatus = int.Parse(dt.Rows[0]["AuditStatus"].ToString()); }
            model.Address = dt.Rows[0]["Address"].ToString();
            return model;

        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Int64 InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt),
                  
				};
            parameters[0].Value = InfoID;

            bool b = DbHelperSQL.RunProcLob("ReleaseDelete", parameters);
            return b;
        }

        public Tz888.Model.SS_ProfessionalServicesModel getProModel(int id)
        {
            Tz888.Model.SS_ProfessionalServicesModel model = new Tz888.Model.SS_ProfessionalServicesModel();
            SqlParameter[] para ={ new SqlParameter("@PSID", SqlDbType.BigInt) };
            para[0].Value = id;
            DataSet ds = DbHelperSQL.RunProcedure("ss_ProSelect", para, "model");
            DataTable dt = ds.Tables["model"];
            if (ds != null)
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["PSID"].ToString()))
                        {
                            model.PSID = int.Parse(dt.Rows[0]["PSID"].ToString());
                        }

                        model.LoginName = dt.Rows[0]["LoginName"].ToString();
                        model.NnitName = dt.Rows[0]["NnitName"].ToString();
                        model.RealName = dt.Rows[0]["RealName"].ToString();
                        model.Address = dt.Rows[0]["Address"].ToString();

                        model.CountryCode = dt.Rows[0]["CountryCode"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ProvinceID"].ToString()))
                        {
                            model.ProvinceID = int.Parse(dt.Rows[0]["ProvinceID"].ToString());
                        }
                        model.BefCase = dt.Rows[0]["BefCase"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["CityID"].ToString()))
                        {
                            model.CityID = int.Parse(dt.Rows[0]["CityID"].ToString());
                        }
                        if (!string.IsNullOrEmpty(dt.Rows[0]["AreaID"].ToString()))
                        {
                            model.AreaID = int.Parse(dt.Rows[0]["AreaID"].ToString());
                        }

                        model.Doc = dt.Rows[0]["Doc"].ToString();
                        model.Email = dt.Rows[0]["Email"].ToString();
                        model.FAX = dt.Rows[0]["FAX"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["IsChekUp"].ToString()))
                        {
                            model.IsChekUp = int.Parse(dt.Rows[0]["IsChekUp"].ToString());
                        }

                        model.Job = dt.Rows[0]["Job"].ToString();
                        model.Mobile = dt.Rows[0]["Mobile"].ToString();
                        model.Pic = dt.Rows[0]["Pic"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["Regdate"].ToString()))
                        {
                            model.Regdate = DateTime.Parse(dt.Rows[0]["Regdate"].ToString());
                        }

                        model.Resume = dt.Rows[0]["Resume"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["ServiceBigtype"].ToString()))
                        {
                            model.ServiceBigtype = int.Parse(dt.Rows[0]["ServiceBigtype"].ToString());
                        }

                        model.ServiceSmalltype = dt.Rows[0]["ServiceSmalltype"].ToString();
                        model.Specialty = dt.Rows[0]["Specialty"].ToString();
                        if (!string.IsNullOrEmpty(dt.Rows[0]["TalentType"].ToString()))
                        {
                            model.TalentType = int.Parse(dt.Rows[0]["TalentType"].ToString());
                        }

                        model.Tel = dt.Rows[0]["Tel"].ToString();

                    }
                }

            }

            return model;
        }
    }
}

