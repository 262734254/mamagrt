using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.SQLServerDAL;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.Model;


namespace Tz888.SQLServerDAL
{
    public class MemberManageInfoDAL:IMemberInfo
    {
        /// <summary>
        /// 取得会员
        /// </summary>
        /// <returns></returns>
        public DataView GetMemberInfoByLoginName(string LoginName)
        {
            long tintCurrentPage = 1;
            long intCurrentPageSize = 10;
            long tintTotalCount = 0;
            
            Common.CommonFunction mCF = new Tz888.SQLServerDAL.Common.CommonFunction();
            DataView dv = mCF.GetListSet("MemberPreVIW_list","*","LoginName='" + LoginName + "'",
                "LoginName ASC",
                ref tintCurrentPage,
                (long)intCurrentPageSize,
                ref tintTotalCount);

            return dv;
        }

        public MemberManageInfo objGetMemberInfoByLoginName(string LoginName)
        {
            //Set up a return value
            MemberManageInfo MemberInfo = new MemberManageInfo();           
            DataTable dt = GetDataTable("LoginInfoTab_List", "*", " LoginName='" + LoginName + "'", "LoginName ASC");
            //Execute the query	
            if (dt != null && dt.Rows.Count > 0)
            {
                MemberInfo.LoginName = dt.Rows[0]["NickName"].ToString().Trim();
                MemberInfo.SendBy = dt.Rows[0]["Email"].ToString().Trim();
            }
            return MemberInfo;
        }

      
        public DataTable GetDataTable(
           string SPName,
        string SelectStr,
        string Criteria,
        string Sort
       
        )
        {
            DataView dv = null;
            DataTable dtGet = null;
        

            SqlParameter[] parameters = {	
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
									 
			};

            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;

         

            try
            {
                dtGet = DbHelperSQL.RunProcedure(SPName, parameters, "tbGetDT").Tables[0];

                if (dtGet != null)
                {
                    dv = dtGet.DefaultView;
                    
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }

            return dtGet;
        }
        #region 会员删除
        public void DeleleMember(string loginName)
        {
            try
            {
                SqlParameter[] parameters = {	
											new SqlParameter("@loginName",SqlDbType.Char,16),
									 
			};

                parameters[0].Value = loginName;
                bool result=DbHelperSQL.RunProcLob("LoginInfoTab_Delete", parameters);
                return;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }
        #endregion
    }
}
