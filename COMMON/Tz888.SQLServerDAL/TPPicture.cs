using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
   　public class TPPicture : ITPPicture
    {
        /// <summary>
        ///  添加视频信息 
        /// </summary>
        public bool InsertPicMess(Tz888.Model.TPPicture model)
        {
            long infoID;

            SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
                    new SqlParameter("@infoCode",SqlDbType.Char,30),
                    new SqlParameter("@infotypeID",SqlDbType.Char,10),
                    new SqlParameter("@subTitle",SqlDbType.VarChar,100),
                    new SqlParameter("@HtmlURL",SqlDbType.VarChar,100), 
					new SqlParameter("@Origin", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,20),
                    new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
                    new SqlParameter("@IsRedirect", SqlDbType.Bit),
                    new SqlParameter("@Summary", SqlDbType.Text),
                    new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@Created",SqlDbType.DateTime,8),
                    new SqlParameter("@Createby", SqlDbType.VarChar,16), 
                    new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    new SqlParameter("@CityID", SqlDbType.Char,10),
                    new SqlParameter("@CountyID", SqlDbType.Char,10), 
                    new SqlParameter("@Remark",SqlDbType.NVarChar,400),
                    new SqlParameter("@loginname",SqlDbType.VarChar,16),
                    new SqlParameter("@KeyWord",SqlDbType.VarChar,50),
                    new SqlParameter("@MiniatureUrl",SqlDbType.VarChar,100),
                    new SqlParameter("@publishT",SqlDbType.DateTime,8),
                    new SqlParameter("@Hit",SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore",SqlDbType.Bit,1),
                    new SqlParameter("@Descript",SqlDbType.VarChar,100),
                    new SqlParameter("@AuditingStatus",SqlDbType.TinyInt,1)
                
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.InfoCode;
            parameters[3].Value = model.infotypeID;
            parameters[4].Value = model.subTitle;
            parameters[5].Value = model.HtmlURL;
            parameters[6].Value = model.Origin;
            parameters[7].Value = model.Author;
            parameters[8].Value = model.RedirectUrl;
            parameters[9].Value = model.IsRedirect;
            parameters[10].Value = model.Summary;
            parameters[11].Value = model.Content;
            parameters[12].Value = model.Created;
            parameters[13].Value = model.Createby;
            parameters[14].Value = model.ProvinceID;
            parameters[15].Value = model.CityID;
            parameters[16].Value = model.CountyID;
            parameters[17].Value = model.strRemark;
            parameters[18].Value = model.LoginName;
            parameters[19].Value = model.KeyWord;
            parameters[20].Value = model.MiniatureUrl;
            parameters[21].Value = model.publishT;
            parameters[22].Value = model.Hit;
            parameters[23].Value = model.IsCore;
            parameters[24].Value = model.Descript;
            parameters[25].Value = model.AuditingStatus;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "ImagesInfotab_INSERT_Manage", parameters);

            infoID = (long)parameters[0].Value;

            if (infoID > 0)
                return true;
            return false;
        }


        /// <summary>
        ///  添加视频信息 
        /// </summary>
        public bool UpdatePicMess(Tz888.Model.TPPicture model)
        {

            try
            {
                SqlParameter[] parameters = {
					new SqlParameter("@infoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
                    new SqlParameter("@infoCode",SqlDbType.Char,30),
                    new SqlParameter("@infotypeID",SqlDbType.Char,10),
                    new SqlParameter("@subTitle",SqlDbType.VarChar,100),
                    new SqlParameter("@HtmlURL",SqlDbType.VarChar,100), 
					new SqlParameter("@Origin", SqlDbType.VarChar,100),
					new SqlParameter("@Author", SqlDbType.VarChar,20),
                    new SqlParameter("@RedirectUrl", SqlDbType.VarChar,100),
                    new SqlParameter("@IsRedirect", SqlDbType.Bit),
                    new SqlParameter("@Summary", SqlDbType.Text),
                    new SqlParameter("@Content", SqlDbType.Text),
                    new SqlParameter("@Created",SqlDbType.DateTime,8),
                    new SqlParameter("@Createby", SqlDbType.VarChar,16), 
                    new SqlParameter("@ProvinceID", SqlDbType.Char,10),
                    new SqlParameter("@CityID", SqlDbType.Char,10),
                    new SqlParameter("@CountyID", SqlDbType.Char,10), 
                    new SqlParameter("@Remark",SqlDbType.NVarChar,400),
                    new SqlParameter("@loginname",SqlDbType.VarChar,16),
                    new SqlParameter("@KeyWord",SqlDbType.VarChar,50),
                    new SqlParameter("@MiniatureUrl",SqlDbType.VarChar,100),
                    new SqlParameter("@publishT",SqlDbType.DateTime,8),
                    new SqlParameter("@Hit",SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore",SqlDbType.Bit,1),
                    new SqlParameter("@Descript",SqlDbType.VarChar,100),
                    new SqlParameter("@AuditingStatus",SqlDbType.TinyInt,1),
                    new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100)
            };
                parameters[0].Value = model.infoID;
                parameters[1].Value = model.Title;
                parameters[2].Value = model.InfoCode;
                parameters[3].Value = model.infotypeID;
                parameters[4].Value = model.subTitle;
                parameters[5].Value = model.HtmlURL;
                parameters[6].Value = model.Origin;
                parameters[7].Value = model.Author;
                parameters[8].Value = model.RedirectUrl;
                parameters[9].Value = model.IsRedirect;
                parameters[10].Value = model.Summary;
                parameters[11].Value = model.Content;
                parameters[12].Value = model.Created;
                parameters[13].Value = model.Createby;
                parameters[14].Value = model.ProvinceID;
                parameters[15].Value = model.CityID;
                parameters[16].Value = model.CountyID;
                parameters[17].Value = model.strRemark;
                parameters[18].Value = model.LoginName;
                parameters[19].Value = model.KeyWord;
                parameters[20].Value = model.MiniatureUrl;
                parameters[21].Value = model.publishT;
                parameters[22].Value = model.Hit;
                parameters[23].Value = model.IsCore;
                parameters[24].Value = model.Descript;
                parameters[25].Value = model.AuditingStatus;
                parameters[26].Value = model.AuditingRemark;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "ImagesInfotab_update_Manage", parameters);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idLST">编号列表以“，”隔开但不以“，”结尾</param>
        /// <returns></returns>
        #region------------删除
        public bool DeletePicMess(string idLST)
        {
            SqlParameter[] parameters ={ new SqlParameter("@idlst", SqlDbType.VarChar, 300) };

            parameters[0].Value = idLST;

            return DBUtility.DbHelperSQL.RunProcLob("ImagesTab_Delete_Images", parameters);
        }
        #endregion


        /// <summary>
        /// 视频信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetPicMess(
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
                                            "ImagesTabList",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }

        public DataSet GetOnePicMess(string InfoID)
        {
            string strsql = "select * from ImagesInfoVIW where InfoID=" + InfoID;
            DataSet ds= DBUtility.DbHelperSQL.Query(strsql);
            return ds;
        }
    }
}

