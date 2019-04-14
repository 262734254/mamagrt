using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class TPVideo : ITPVideo
    {

        /// <summary>
        ///  添加视频信息 
        /// </summary>
        public bool InsertVideoMess(Tz888.Model.TPVideo model)
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
                    new SqlParameter("@publishT",SqlDbType.DateTime,8),
                    new SqlParameter("@Hit",SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore",SqlDbType.Bit,1),
                    new SqlParameter("@Descript",SqlDbType.VarChar,100),
                    new SqlParameter("@MiniatureUrl",SqlDbType.VarChar,100),
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
            parameters[20].Value = model.publishT;
            parameters[21].Value = model.Hit;
            parameters[22].Value = model.IsCore;
            parameters[23].Value = model.Descript;
            parameters[24].Value = model.MiniatureUrl;
            parameters[25].Value = model.AuditingStatus;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "VideoInfotab_INSERT_Manage", parameters);

            infoID = (long)parameters[0].Value;

            if (infoID > 0)
                return true;
            return false;
        }


        /// <summary>
        ///  更新视频信息 
        /// </summary>
        public bool UpdateVideoMess(Tz888.Model.TPVideo model)
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
                    new SqlParameter("@publishT",SqlDbType.DateTime,8),
                    new SqlParameter("@Hit",SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore",SqlDbType.Bit,1),
                    new SqlParameter("@Descript",SqlDbType.VarChar,100),
                    new SqlParameter("@AuditingStatus",SqlDbType.TinyInt,1),
                    new SqlParameter("@MiniatureUrl",SqlDbType.VarChar,100),
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
                parameters[20].Value = model.publishT;
                parameters[21].Value = model.Hit;
                parameters[22].Value = model.IsCore;
                parameters[23].Value = model.Descript;
                parameters[24].Value = model.AuditingStatus;
                parameters[25].Value = model.MiniatureUrl;
                parameters[26].Value = model.AuditingRemark;
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "VideoInfotab_Update_Manage", parameters);
                return true;
            }
            catch
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
        public bool DeleteVideoMess(string idLST)
        {
            SqlParameter[] parameters ={ new SqlParameter("@idlst", SqlDbType.VarChar, 300) };

            parameters[0].Value = idLST;

            return DBUtility.DbHelperSQL.RunProcLob("VideoTab_Delete_Video", parameters);
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
        public DataSet dsGetVideoMess(
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
                                            "VideoTabList",
                                            SelectStr,
                                            Criteria,
                                            Sort,
                                            Page,
                                            CurrentPageRow,
                                            ref TotalCount));
        }

        public DataSet GetOneVideoMess(string InfoID)
        {
            string strsql = "select * from VideoInfoVIW where InfoID=" + InfoID;
            DataSet ds = DBUtility.DbHelperSQL.Query(strsql);
            return ds;
        }

        #region
        ///<summary>
        ///获取对象，获取地址
        ///design by ww
        ///2009-05-06
        ///</summary>
        public Tz888.Model.TPVideo GetVideoModelByID(long InfoID)
        {
            Tz888.Model.TPVideo tpVideo = new Tz888.Model.TPVideo();
            string strsql = "select * from VideoInfoVIW where InfoID=" + InfoID.ToString();
            DataSet ds = DBUtility.DbHelperSQL.Query(strsql);
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                Common.ZoneSelectDAL zone = new Tz888.SQLServerDAL.Common.ZoneSelectDAL();
                tpVideo.AuditingRemark = ds.Tables[0].Rows[0]["AuditingRemark"].ToString();
                tpVideo.AuditingStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
                tpVideo.Author = ds.Tables[0].Rows[0]["Author"].ToString();
                if (tpVideo.CityID.Trim() == "")
                    tpVideo.CityID = "";
                else
                    tpVideo.CityID = zone.GetCityNameByCode(ds.Tables[0].Rows[0]["CityID"].ToString());
                tpVideo.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (tpVideo.CountyID.Trim() == "")
                    tpVideo.CountyID = "";
                else
                    tpVideo.CountyID = zone.GetCountyNameByCode(ds.Tables[0].Rows[0]["CountyID"].ToString());
                tpVideo.Createby = ds.Tables[0].Rows[0]["Createby"].ToString();
                tpVideo.Created = Convert.ToDateTime(ds.Tables[0].Rows[0]["Created"].ToString());
                tpVideo.Descript = ds.Tables[0].Rows[0]["Summary"].ToString();
                tpVideo.Hit = Convert.ToInt64(ds.Tables[0].Rows[0]["Hit"].ToString());
                tpVideo.HtmlURL = ds.Tables[0].Rows[0]["HtmlURL"].ToString();
                tpVideo.InfoCode = ds.Tables[0].Rows[0]["InfoCode"].ToString();
                tpVideo.infoID = Convert.ToInt64(ds.Tables[0].Rows[0]["infoID"].ToString());
                tpVideo.infotypeID = ds.Tables[0].Rows[0]["infotypeID"].ToString();
                tpVideo.IsCore = Convert.ToInt32(ds.Tables[0].Rows[0]["IsCore"].ToString());
                tpVideo.IsRedirect = Convert.ToInt32(ds.Tables[0].Rows[0]["IsRedirect"].ToString());
                tpVideo.KeyWord = ds.Tables[0].Rows[0]["KeyWord"].ToString();
                tpVideo.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                tpVideo.MiniatureUrl = ds.Tables[0].Rows[0]["MiniatureUrl"].ToString();
                tpVideo.Origin = ds.Tables[0].Rows[0]["Origin"].ToString();
                if (tpVideo.ProvinceID.Trim() == "")
                    tpVideo.ProvinceID = "";
                else
                    tpVideo.ProvinceID = zone.GetProvinceNameByCode(ds.Tables[0].Rows[0]["ProvinceID"].ToString());
                tpVideo.publishT = Convert.ToDateTime(ds.Tables[0].Rows[0]["publishT"].ToString());
                tpVideo.RedirectUrl = ds.Tables[0].Rows[0]["RedirectUrl"].ToString();
                tpVideo.strRemark = ds.Tables[0].Rows[0]["Remark"].ToString();
                tpVideo.subTitle = ds.Tables[0].Rows[0]["subTitle"].ToString();
                tpVideo.Summary = ds.Tables[0].Rows[0]["Summary"].ToString();
                tpVideo.Title = ds.Tables[0].Rows[0]["Title"].ToString();

                return tpVideo;
            }
            else
            {
                return null;
            }
        }

        public string getAddrNameById(string ProvinceID, string CityID, string CountyID)
        {
            string addrStr = "";
            Common.ZoneSelectDAL zone = new Tz888.SQLServerDAL.Common.ZoneSelectDAL();
            addrStr = zone.GetProvinceNameByCode(CountyID) + " ";
            addrStr += zone.GetCityNameByCode(CityID) + " ";
            addrStr += zone.GetCountyNameByCode(CountyID);
            return addrStr.Trim();
        }

        public long InsertVideo(Tz888.Model.TPVideo model)
        {
            long infoID = 0;

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
                    new SqlParameter("@publishT",SqlDbType.DateTime,8),
                    new SqlParameter("@Hit",SqlDbType.BigInt,8),
                    new SqlParameter("@IsCore",SqlDbType.Bit,1),
                    new SqlParameter("@Descript",SqlDbType.VarChar,100),
                    new SqlParameter("@MiniatureUrl",SqlDbType.VarChar,100),
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
            parameters[20].Value = model.publishT;
            parameters[21].Value = model.Hit;
            parameters[22].Value = model.IsCore;
            parameters[23].Value = model.Descript;
            parameters[24].Value = model.MiniatureUrl;
            parameters[25].Value = model.AuditingStatus;
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "VideoInfotab_INSERT_Manage", parameters);

            infoID = (long)parameters[0].Value;

            return infoID;
        }

        #endregion
    }
}