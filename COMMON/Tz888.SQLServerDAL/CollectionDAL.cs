using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    class CollectionDAL:ICollection
    {
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LoginName, long ID)
        { 
            int rowsAffected;
            SqlParameter[] parameters = { 	
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
											new SqlParameter("@ID",SqlDbType.BigInt,8)				//--信息ID
										};

            parameters[0].Value = LoginName;
            parameters[1].Value = ID;

            try
            {
                DbHelperSQL.RunProcedure("InfoFavorite_Delete", parameters, out rowsAffected);              
            }
            catch (Exception err)
            {
                throw err;
            }
            if (rowsAffected > 0) return true;
            else return false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool OrgDelete(string LoginName, long ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = { 	
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
											new SqlParameter("@ID",SqlDbType.BigInt,8)				//--信息ID
										};

            parameters[0].Value = LoginName;
            parameters[1].Value = ID;

            try
            {
                DbHelperSQL.RunProcedure("OrgFavorite_Delete", parameters, out rowsAffected);
            }
            catch (Exception err)
            {
                throw err;
            }
            if (rowsAffected > 0) return true;
            else return false;
        }

        #region  -- 我要收藏信息插入--------
        public bool InfoFavoriteInsert(long InfoID,string LoginName)         
        {
            bool bl;

            SqlParameter[] parameters = { 
											new SqlParameter("@InfoID",SqlDbType.BigInt),      //信息ID
											new SqlParameter("@LoginName",SqlDbType.Char,16)	//--登陆用户名
															
										};
            parameters[0].Value = InfoID;
            parameters[1].Value = LoginName;

            try
            {
                int rowsAffected = 0;
                DbHelperSQL.RunProcedure("InfoFavorite_Collect", parameters, out rowsAffected);
            }
            catch (Exception err)
            {
                bl = false;
            }
            finally
            {
                bl = true ;
            }
            return bl;
        }
        #endregion

        #region  -- 公司机构收藏信息插入--------
        public bool InfoFavoriteOrgInsert(Tz888.Model.CollectionModel model)
        {
            bool bl=true;
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,16),					
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@ContactLoginName", SqlDbType.Char,16),
					new SqlParameter("@CollectOrgType", SqlDbType.TinyInt,1),
					new SqlParameter("@CollectOrgName", SqlDbType.VarChar,100),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@Remrk", SqlDbType.VarChar,200)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.IndustryBID;
            parameters[2].Value = model.ContactLoginName;
            parameters[3].Value = model.CollectOrgType;
            parameters[4].Value = model.CollectOrgName;
            parameters[5].Value = model.CountryCode;
            parameters[6].Value = model.ProvinceID;
            parameters[7].Value = model.CityID;
            parameters[8].Value = model.CountyID;
            parameters[9].Value = model.Remrk;

            try
            {
                DbHelperSQL.RunProcedure("UP_OrgCollectionTab_ADD", parameters, out rowsAffected);
            }
            catch
            {
                bl = false;
            }
            return bl;           
        }
        #endregion
    }
}
