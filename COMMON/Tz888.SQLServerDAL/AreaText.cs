using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;//请先添加引用;
namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 数据访问类AreaTextTab 。
    /// </summary>
    public class AreaText : IAreaText
    {
        public AreaText()
        { }
        #region  成员方法
       

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int Add(Tz888.Model.AreaText model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@Subtitle", SqlDbType.NVarChar),
					new SqlParameter("@HtmlURL", SqlDbType.VarChar,100),
					new SqlParameter("@URL", SqlDbType.VarChar,100),
					new SqlParameter("@Orderby", SqlDbType.Int,4),
					new SqlParameter("@AreaKind", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateBy", SqlDbType.Char,16),
					new SqlParameter("@areaType", SqlDbType.TinyInt,1),
					new SqlParameter("@hit", SqlDbType.Int,4),
					new SqlParameter("@InfoType", SqlDbType.Int,4),
                    new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
                    new SqlParameter("@ShortDescript", SqlDbType.VarChar,100),
                    new SqlParameter("@Created", SqlDbType.VarChar,100),
                    };
            parameters[0].Value = "Insert";
            parameters[1].Value = model.Subtitle;
            parameters[2].Value = model.HtmlURL;
            parameters[3].Value = model.URL;
            parameters[4].Value = model.Orderby;
            parameters[5].Value = model.AreaKind;
            parameters[6].Value = model.CreateBy;
            parameters[7].Value = model.areaType;
            parameters[8].Value = model.hit;
            parameters[9].Value = model.InfoType;

            parameters[10].Value = model.CountryCode;
            parameters[11].Value = model.ProvinceID;
            parameters[12].Value = model.CityID;
            parameters[13].Value = model.CountyID;
            parameters[14].Value = model.ShortDescript;
            parameters[15].Value = model.Created;
            DbHelperSQL.RunProcedure("AreaText_Sp", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tz888.Model.AreaText model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.BigInt,8),
					new SqlParameter("@Subtitle", SqlDbType.NVarChar),
					new SqlParameter("@HtmlURL", SqlDbType.VarChar,100),
					new SqlParameter("@URL", SqlDbType.VarChar,100),
					new SqlParameter("@Orderby", SqlDbType.Int,4),
					new SqlParameter("@AreaKind", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateBy", SqlDbType.Char,16),
					new SqlParameter("@areaType", SqlDbType.TinyInt,1),
					new SqlParameter("@InfoType", SqlDbType.Int,4),
                    
                    new SqlParameter("@CountryCode", SqlDbType.VarChar,10),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
                    new SqlParameter("@ShortDescript", SqlDbType.VarChar,100),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)};
            parameters[0].Value = model.AreaID;
            parameters[1].Value = model.Subtitle;
            parameters[2].Value = model.HtmlURL;
            parameters[3].Value = model.URL;
            parameters[4].Value = model.Orderby;
            parameters[5].Value = model.AreaKind;
            parameters[6].Value = model.CreateBy;
            parameters[7].Value = model.areaType;
            parameters[8].Value = model.InfoType;

            parameters[9].Value = model.CountryCode;
            parameters[10].Value = model.ProvinceID;
            parameters[11].Value = model.CityID;
            parameters[12].Value = model.CountyID;
            parameters[13].Value = model.ShortDescript;
            parameters[14].Value = "Update";

            DbHelperSQL.RunProcedure("AreaText_Sp", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int AreaID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = AreaID;
            parameters[1].Value = "Delete";
            DbHelperSQL.RunProcedure("AreaText_Sp", parameters, out rowsAffected);
            return rowsAffected;
        }
        public Tz888.Model.AreaText GetModel(int AreaID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
                     new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = AreaID;
            parameters[1].Value = "Select";
            Tz888.Model.AreaText model = new Tz888.Model.AreaText();

            DataSet ds = DbHelperSQL.RunProcedure("AreaText_Sp", parameters, "ds");
            model.AreaID = AreaID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Subtitle = ds.Tables[0].Rows[0]["Subtitle"].ToString();
                model.ShortDescript = ds.Tables[0].Rows[0]["ShortDescript"].ToString();
                model.HtmlURL = ds.Tables[0].Rows[0]["HtmlURL"].ToString();
                model.URL = ds.Tables[0].Rows[0]["URL"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();
                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();
                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();
                if (ds.Tables[0].Rows[0]["Orderby"].ToString() != "")
                {
                    model.Orderby = int.Parse(ds.Tables[0].Rows[0]["Orderby"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaKind"].ToString() != "")
                {
                    model.AreaKind = int.Parse(ds.Tables[0].Rows[0]["AreaKind"].ToString());
                }
                model.CreateBy = ds.Tables[0].Rows[0]["CreateBy"].ToString();
                if (ds.Tables[0].Rows[0]["Created"].ToString() != "")
                {

                    model.Created = DateTime.Parse(ds.Tables[0].Rows[0]["Created"].ToString());
                }
                if (ds.Tables[0].Rows[0]["areaType"].ToString() != "")
                {
                    model.areaType = int.Parse(ds.Tables[0].Rows[0]["areaType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["hit"].ToString() != "")
                {
                    model.hit = int.Parse(ds.Tables[0].Rows[0]["hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InfoType"].ToString() != "")
                {
                    model.InfoType = int.Parse(ds.Tables[0].Rows[0]["InfoType"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public void AddHit(int AreaID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = AreaID;
            parameters[1].Value = "AddHit";
            DbHelperSQL.RunProcedure("AreaText_Sp", parameters, out rowsAffected);
        }
        public void UpdateOrderNum(int AreaID, int OrderNum)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@AreaID", SqlDbType.Int,4),
                    new SqlParameter("@OrderBy", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30)
				};
            parameters[0].Value = AreaID;
            parameters[1].Value = OrderNum;
            parameters[2].Value = "UpdateOrder";
            DbHelperSQL.RunProcedure("AreaText_Sp", parameters, out rowsAffected);
        }
        #endregion  成员方法
    }
}

