using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 资源信息短信息数据库访问逻辑类
    /// </summary>
    public class ShortInfoDAL
    {
        #region  得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Info.ShortInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ShortInfoModel model = new Tz888.Model.Info.ShortInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("ShortInfoTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.InfoID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.InfoType = ds.Tables[0].Rows[0]["InfoType"].ToString();
                model.ShortInfoControlID = ds.Tables[0].Rows[0]["ShortInfoControlID"].ToString();
                model.ShortTitle = ds.Tables[0].Rows[0]["ShortTitle"].ToString();
                model.ShortContent = ds.Tables[0].Rows[0]["ShortContent"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.ChangeBy = ds.Tables[0].Rows[0]["ChangeBy"].ToString();
                if (ds.Tables[0].Rows[0]["ChangeTime"].ToString() != "")
                {

                    model.ChangeTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChangeTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion 
    }
}
