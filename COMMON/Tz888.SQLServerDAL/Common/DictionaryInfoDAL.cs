using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.Common;
using Tz888.DBUtility;
using Tz888.Model.Common;
namespace Tz888.SQLServerDAL.Common
{
    public class DictionaryInfoDAL : IDictionaryInfo
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Tz888.Model.Common.DictionaryInfoModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DictionaryInfoId", SqlDbType.Int,4),
					new SqlParameter("@DictionaryCode", SqlDbType.Char,25),
					new SqlParameter("@DictionaryInfoName", SqlDbType.NVarChar),
					new SqlParameter("@DictionaryTypeCode", SqlDbType.Char,10),
					new SqlParameter("@DictionaryInfoParam", SqlDbType.Char,12),
					new SqlParameter("@DictionaryInfoRemark", SqlDbType.NVarChar)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.DictionaryCode;
            parameters[2].Value = model.DictionaryInfoName;
            parameters[3].Value = model.DictionaryTypeCode;
            parameters[4].Value = model.DictionaryInfoParam;
            parameters[5].Value = model.DictionaryInfoRemark;

            DbHelperSQL.RunProcedure("UP_DictionaryInfoTab_ADD", parameters, out rowsAffected);           

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tz888.Model.Common.DictionaryInfoModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DictionaryInfoId", SqlDbType.Int,4),
					new SqlParameter("@DictionaryCode", SqlDbType.Char,25),
					new SqlParameter("@DictionaryInfoName", SqlDbType.NVarChar),
					new SqlParameter("@DictionaryTypeCode", SqlDbType.Char,10),
					new SqlParameter("@DictionaryInfoParam", SqlDbType.Char,12),
					new SqlParameter("@DictionaryInfoRemark", SqlDbType.NVarChar)};
            parameters[0].Value = model.DictionaryInfoId;
            parameters[1].Value = model.DictionaryCode;
            parameters[2].Value = model.DictionaryInfoName;
            parameters[3].Value = model.DictionaryTypeCode;
            parameters[4].Value = model.DictionaryInfoParam;
            parameters[5].Value = model.DictionaryInfoRemark;

            DbHelperSQL.RunProcedure("UP_DictionaryInfoTab_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int DictionaryInfoId)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@DictionaryInfoId", SqlDbType.Int,4)
				};
            parameters[0].Value = DictionaryInfoId;
            DbHelperSQL.RunProcedure("UP_DictionaryInfoTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Common.DictionaryInfoModel GetModel(string DictionaryCode)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@DictionaryInfoId", SqlDbType.Int,4),
				};
            parameters[0].Value = DictionaryCode;
            Tz888.Model.Common.DictionaryInfoModel model = new Tz888.Model.Common.DictionaryInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("DictionaryInfoTab_GetModel", parameters, "ds");
            model.DictionaryCode = DictionaryCode;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.DictionaryInfoName = ds.Tables[0].Rows[0]["DictionaryInfoName"].ToString();
                model.DictionaryTypeCode = ds.Tables[0].Rows[0]["DictionaryTypeCode"].ToString();
                model.DictionaryInfoParam = ds.Tables[0].Rows[0]["DictionaryInfoParam"].ToString();
                model.DictionaryInfoRemark = ds.Tables[0].Rows[0]["DictionaryInfoRemark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        public DataView GetList()
        {
            return null;
        }
        #endregion  成员方法


        /// <summary>
        /// 查询对应记录
        /// </summary>
        /// <param name="Key">关键字</param>		
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public string GetDetail(string Key)
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("SetIndustryBTab", "*", "IndustryBID", 1, 1, 0, 1, "IndustryBID='" + Key.Trim() + "'");

            if (dt != null && dt.Rows.Count == 1)
            {
                return (dt.Rows[0]["IndustryBName"].ToString());
            }
            else
            {
                return ("");
            }
        }

        public string GetDetailCarveout(string Key)
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("SetIndustryCraveOutTab", "*", "IndustryCarveOutID", 1, 1, 0, 1, "IndustryCarveOutID='" + Key.Trim() + "'");

            if (dt != null && dt.Rows.Count == 1)
            {
                return (dt.Rows[0]["IndustryCarveOutName"].ToString());
            }
            else
            {
                return ("");
            }
        }

        public string GetDetailOpportunity(string Key)
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("SetIndustryOpportunityTab", "*", "IndustryOpportunityID", 1, 1, 0, 1, "IndustryOpportunityID='" + Key.Trim() + "'");

            if (dt != null && dt.Rows.Count == 1)
            {
                return (dt.Rows[0]["IndustryOpportunityName"].ToString());
            }
            else
            {
                return ("");
            }
        }

        public string GetIndustryExhibitionName(string Key)
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("SetIndustryExhibitionTab", "*", "IndustryExhibitionID", 1, 1, 0, 1, "IndustryExhibitionID='" + Key.Trim() + "'");

            if (dt != null && dt.Rows.Count == 1)
            {
                return (dt.Rows[0]["IndustryExhibitionName"].ToString());
            }
            else
            {
                return ("");
            }
        }

        public string GetProvinceName(string Key)
        {
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("SetProvinceTab", "*", "ProvinceID", 1, 1, 0, 1, "ProvinceID='" + Key.Trim() + "'");

            if (dt != null && dt.Rows.Count == 1)
            {
                return (dt.Rows[0]["ProvinceName"].ToString());
            }
            else
            {
                return ("");
            }
        }
    }
}
