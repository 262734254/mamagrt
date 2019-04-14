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
    public class MainInfoDAL : IMainInfo
    {
        #region IMainInfo 成员

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public MainInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.MainInfoModel model = new Tz888.Model.Info.MainInfoModel();
            DataSet ds = new DataSet();
            try
            {
                ds = DbHelperSQL.RunProcedure("MainInfoTab_GetModel", parameters, "ds");
            }
            catch (Exception ex)
            {

            }
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = Convert.ToInt64(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsVip"].ToString() != "")
                {
                    model.IsVip = Convert.ToInt32(ds.Tables[0].Rows[0]["IsVip"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.InfoCode = ds.Tables[0].Rows[0]["InfoCode"].ToString();
                if (ds.Tables[0].Rows[0]["publishT"].ToString() != "")
                {

                    model.publishT = DateTime.Parse(ds.Tables[0].Rows[0]["publishT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());
                }
                model.InfoTypeID = ds.Tables[0].Rows[0]["InfoTypeID"].ToString();
                if (ds.Tables[0].Rows[0]["IsCore"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsCore"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsCore"].ToString().ToLower() == "true"))
                    {
                        model.IsCore = true;
                    }
                    else
                    {
                        model.IsCore = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["IndexOrderNum"].ToString() != "")
                {
                    model.IndexOrderNum = int.Parse(ds.Tables[0].Rows[0]["IndexOrderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IndexTopValidateDate"].ToString() != "")
                {
                    model.IndexTopValidateDate = int.Parse(ds.Tables[0].Rows[0]["IndexTopValidateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IndexPicInfoNum"].ToString() != "")
                {
                    model.IndexPicInfoNum = int.Parse(ds.Tables[0].Rows[0]["IndexPicInfoNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InfoTypeOrderNum"].ToString() != "")
                {
                    model.InfoTypeOrderNum = int.Parse(ds.Tables[0].Rows[0]["InfoTypeOrderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InfoTypeTopValidateDate"].ToString() != "")
                {
                    model.InfoTypeTopValidateDate = int.Parse(ds.Tables[0].Rows[0]["InfoTypeTopValidateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InfoTypePicInfoNum"].ToString() != "")
                {
                    model.InfoTypePicInfoNum = int.Parse(ds.Tables[0].Rows[0]["InfoTypePicInfoNum"].ToString());
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                model.InfoOriginRoleName = ds.Tables[0].Rows[0]["InfoOriginRoleName"].ToString();
                model.GradeID = ds.Tables[0].Rows[0]["GradeID"].ToString();
                model.FixPriceID = ds.Tables[0].Rows[0]["FixPriceID"].ToString();
                if (ds.Tables[0].Rows[0]["FeeStatus"].ToString() != "")
                {
                    model.FeeStatus = int.Parse(ds.Tables[0].Rows[0]["FeeStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AuditingStatus"].ToString() != "")
                {
                    model.AuditingStatus = int.Parse(ds.Tables[0].Rows[0]["AuditingStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DelStatus"].ToString() != "")
                {
                    model.DelStatus = int.Parse(ds.Tables[0].Rows[0]["DelStatus"].ToString());
                }
                model.ApproveBy = ds.Tables[0].Rows[0]["ApproveBy"].ToString();
                if (ds.Tables[0].Rows[0]["ApproveTime"].ToString() != "")
                {

                    model.ApproveTime = DateTime.Parse(ds.Tables[0].Rows[0]["ApproveTime"].ToString());
                }
                model.ContentKeyword = ds.Tables[0].Rows[0]["ContentKeyword"].ToString();
                model.KeyWord = ds.Tables[0].Rows[0]["KeyWord"].ToString();
                model.Descript = ds.Tables[0].Rows[0]["Descript"].ToString();
                model.DisplayTitle = ds.Tables[0].Rows[0]["DisplayTitle"].ToString();
                if (ds.Tables[0].Rows[0]["FrontDisplayTime"].ToString() != "")
                {

                    model.FrontDisplayTime = DateTime.Parse(ds.Tables[0].Rows[0]["FrontDisplayTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValidateStartTime"].ToString() != "")
                {

                    model.ValidateStartTime = DateTime.Parse(ds.Tables[0].Rows[0]["ValidateStartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ValidateTerm"].ToString() != "")
                {
                    model.ValidateTerm = int.Parse(ds.Tables[0].Rows[0]["ValidateTerm"].ToString());
                }
                model.TemplateID = ds.Tables[0].Rows[0]["TemplateID"].ToString();
                model.HtmlFile = ds.Tables[0].Rows[0]["HtmlFile"].ToString();
                model.HtmlFile1 = ds.Tables[0].Rows[0]["HtmlFile1"].ToString();
                if (ds.Tables[0].Rows[0]["UserEvaluation"].ToString() != "")
                {
                    model.UserEvaluation = int.Parse(ds.Tables[0].Rows[0]["UserEvaluation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsIntegralInfo"].ToString() != "")
                {
                    model.IsIntegralInfo = int.Parse(ds.Tables[0].Rows[0]["IsIntegralInfo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MainPointCount"].ToString() != "")
                {
                    model.MainPointCount = decimal.Parse(ds.Tables[0].Rows[0]["MainPointCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MainEvaluation"].ToString() != "")
                {
                    model.MainEvaluation = int.Parse(ds.Tables[0].Rows[0]["MainEvaluation"].ToString());
                }
                if (ds.Tables[0].Rows[0]["refreshtag"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["refreshtag"].ToString() == "1") || (ds.Tables[0].Rows[0]["refreshtag"].ToString().ToLower() == "true"))
                    {
                        model.refreshtag = true;
                    }
                    else
                    {
                        model.refreshtag = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["IsVoucherInfo"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsVoucherInfo"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsVoucherInfo"].ToString().ToLower() == "true"))
                    {
                        model.IsVoucherInfo = true;
                    }
                    else
                    {
                        model.IsVoucherInfo = false;
                    }
                }
                

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetOneList(string InfoID)
        {
            string strsql = "select * from MenberInfo_ViewCar where InfoID=" + InfoID;
            return DBUtility.DbHelperSQL.Query(strsql);
        }
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns></returns>
        public DataSet IndustryList()
        {
            string strsql = "select * from SetIndustryCraveOutTab";
            return DBUtility.DbHelperSQL.Query(strsql);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            DataTable dt = dal.GetList("MainInfoVIW", strGetFields, fldName, PageSize, PageIndex, 0, OrderType, strWhere);
            DataSet ds = new DataSet();

            ds.Tables.Add(dt.Copy());

            return ds;
        }

        /// <summary>
        /// 根据条件统计信息数目
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string InfoType, string strWhere)
        {
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            string SpName = "MainInfoVIW";

            switch (InfoType.ToLower())
            {
                case "merchant":
                    SpName = "MerchantInfo_VIW";
                    break;
                case "project":
                    SpName = "ProjectInfo_VIW";
                    break;
                case "capital":
                    SpName = "CapitalInfo_VIW";
                    break;
                default:
                    break;
            }
            return dal.GetCount(SpName, "InfoID", strWhere);
        }

        #endregion

        #region 用户删除信息
        /// <summary>
        /// 用户删除信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <param name="ErrorID"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public bool UserDelete(long InfoID, string LoginName, ref int ErrorID, ref string ErrorMsg)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@LoginName", SqlDbType.Char,16),
                    new SqlParameter("@IsMendaciousInfo", SqlDbType.TinyInt,2)
				};
            parameters[0].Value = InfoID;
            parameters[1].Value = LoginName;
            try
            {
                DbHelperSQL.RunProcedure("MainInfoTab_UserDelete", parameters, out rowsAffected);
            }
            catch (SqlException ex)
            {
                ErrorID = ex.Number;
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(ex.Number.ToString(), ex.Message);
            }
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 删除信息 HasDelete
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public virtual bool HasDelete(long InfoID, string LoginName, bool IsMendaciousInfo, ref int ErrorID, ref string ErrorMsg)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@LoginName",SqlDbType.Char,16),
                                            new SqlParameter("@IsMendaciousInfo",SqlDbType.TinyInt),
			};

            parameters[0].Value = InfoID;
            parameters[1].Value = LoginName;
            parameters[2].Value = Convert.ToByte(IsMendaciousInfo);
            try
            {
                DbHelperSQL.RunProcedure("MainInfoTab_Delete", parameters, out rowsAffected);
            }
            catch (SqlException ex)
            {
                ErrorID = ex.Number;
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(ex.Number.ToString(), ex.Message);
            }
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 完全删除信息 HasCompleteDelete
        /// <summary>
        /// 完全删除信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public bool HasCompleteDelete(long InfoID, string LoginName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@LoginName",SqlDbType.Char,16),
			};

            parameters[0].Value = InfoID;
            parameters[1].Value = LoginName;

            DbHelperSQL.RunProcedure("MainInfoTab_CompleteDelete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 从资源主表视图获取数据
        /// <summary>
        /// 从资源主表视图获取数据
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="OrderBy"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataTable GetMainInfoViewList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            return (dal.GetList(
                "MainInfoViw",
                "InfoID",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }

        #endregion

        #region 资源刷新
        /// <summary>
        /// 资源刷新
        /// </summary>
        /// <returns></returns>
        public bool UpdateRefresh(long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = { new SqlParameter("@InfoID", SqlDbType.BigInt, 8) };
            parameters[0].Value = InfoID;

            DbHelperSQL.RunProcedure("MainInfoTab_FrontDisplayTime_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 设置信息有效期

        /// <summary>
        /// 设置信息有效期
        /// </summary>
        /// <returns></returns>
        public bool SetValidateTerm(long InfoID, int ValidateTerm)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@ValidateTerm" , SqlDbType.Int,4)
				};
            parameters[0].Value = InfoID;
            parameters[1].Value = ValidateTerm;
            DbHelperSQL.RunProcedure("MainInfoTab_SetOverdue", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 更新有效期
        /// <summary>
        /// 更新有效期
        /// </summary>
        /// <param name="infoId">信息ID</param>
        /// <param name="startDay">开始有效时间</param>
        /// <param name="terms">有效期限</param>
        /// <returns>是否更新成功</returns>
        public bool ChangeValidTerm(long infoId, DateTime startDay, int terms)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	
											new SqlParameter("@InfoId",SqlDbType.BigInt),
											new SqlParameter("@ValidateStartTime",SqlDbType.DateTime),
											new SqlParameter("@ValidateTerm",SqlDbType.Int)
										};
            parameters[0].Value = infoId;
            parameters[1].Value = startDay;
            parameters[2].Value = terms;

            DbHelperSQL.RunProcedure("MainInfoTabUpdateTerm", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        #region 审核信息
        /// <summary>
        /// 审核信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <param name="AuditingStatus">审核状态:0未审核， 1审核通过，2审核未通过</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public bool HasAuditing(long InfoID, byte AuditingStatus, bool IsCore, long Hit, string LoginName,
            string AuditingRemark, string HtmlFile, string HtmlFile1, short IsIntegral, float MainPointCount)
        {
            int rowsAffected;

            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@AuditingStatus",SqlDbType.TinyInt),
											new SqlParameter("@IsCore",SqlDbType.Bit),
											new SqlParameter("@Hit",SqlDbType.BigInt),
											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@AuditingRemark",SqlDbType.VarChar,150),
											new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),//该字段不需要更新，只有在审核时才更新
											new SqlParameter("@HtmlFile1",SqlDbType.VarChar,100),
											new SqlParameter("@IsIntegralInfo",SqlDbType.TinyInt),
											new SqlParameter("@MainPointCount",SqlDbType.Float)
			};

            parameters[0].Value = InfoID;
            parameters[1].Value = AuditingStatus;
            parameters[2].Value = IsCore;
            parameters[3].Value = Hit;
            parameters[4].Value = LoginName;
            parameters[5].Value = AuditingRemark;
            parameters[6].Value = HtmlFile;
            parameters[7].Value = HtmlFile1;
            parameters[8].Value = IsIntegral;
            parameters[9].Value = MainPointCount;

            DbHelperSQL.RunProcedure("MainInfoTab_Approve", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        #region 获得重复信息列表
        /// <summary>
        /// 获得重复信息列表
        /// </summary>
        /// <param name="infoId">信息ID</param>
        /// <param name="count">重复数量</param>
        /// <param name="isJustCount">是否只计算数量</param>
        /// <returns>返回信息列表</returns>
        public DataTable GetRepeatedList(long infoId, ref int count, bool isJustCount)
        {
            SqlParameter[] parameters = {	
											new SqlParameter("@InfoId",SqlDbType.Char),
											new SqlParameter("@isCount",SqlDbType.Bit),
											new SqlParameter("@RecCount",SqlDbType.Int)
										};
            parameters[0].Value = infoId;
            parameters[1].Value = isJustCount;
            parameters[2].Direction = System.Data.ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure("GetRepeatedInfo", parameters, "ds");

            count = Convert.ToInt32(parameters[2].Value);

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        #endregion

        #region 信息审核状态记录

        /// <summary>
        /// 信息审核状态记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InfoAuditNote(Tz888.Model.Info.InfoAuditModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@InfoTypeID", SqlDbType.Char,10),
					new SqlParameter("@PostDate", SqlDbType.DateTime),
					new SqlParameter("@AuditStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@AuditingRemark", SqlDbType.VarChar,100),
					new SqlParameter("@AuditingBy", SqlDbType.VarChar,20),
					new SqlParameter("@AuditingDate", SqlDbType.DateTime),
					new SqlParameter("@FeedbackStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@FeedBackNote", SqlDbType.VarChar,300),
					new SqlParameter("@Memo", SqlDbType.VarChar,200)};
            parameters[0].Value = model.InfoID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.LoginName;
            parameters[3].Value = model.InfoTypeID;
            parameters[4].Value = model.PostDate;
            parameters[5].Value = model.AuditStatus;
            parameters[6].Value = model.AuditingRemark;
            parameters[7].Value = model.AuditingBy;
            parameters[8].Value = model.AuditingDate;
            parameters[9].Value = model.FeedbackStatus;
            parameters[10].Value = model.FeedBackNote;
            parameters[11].Value = model.Memo;

            DbHelperSQL.RunProcedure("InfoAuditTab_LOG", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 获取审核状态记录

        public Tz888.Model.Info.InfoAuditModel GetInfoAuditNote(long InfoID)
        {
            string SqlText = "Select * from InfoAuditTab Where InfoID = " + InfoID.ToString();
            Tz888.Model.Info.InfoAuditModel model = new InfoAuditModel();
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SqlText, null))
            {
                if (rdr.Read())
                {
                    model.InfoID = InfoID;
                    model.InfoTypeID = rdr["InfoTypeID"].ToString();
                    model.LoginName = rdr["LoginName"].ToString();
                    model.AuditingBy = rdr["AuditingBy"].ToString();
                    model.AuditingDate = Convert.ToDateTime(rdr["AuditingDate"]);
                    model.AuditingRemark = rdr["AuditingRemark"].ToString();
                    model.AuditStatus = Convert.ToInt32(rdr["AuditStatus"]);
                    model.Memo = rdr["Memo"].ToString();
                    model.PostDate = Convert.ToDateTime(rdr["PostDate"]);
                    model.Title = rdr["Title"].ToString();
                    model.FeedBackNote = rdr["FeedBackNote"].ToString();
                    model.FeedbackStatus = Convert.ToInt32(rdr["FeedBackStatus"]);
                }
            }
            return model;
        }

        #endregion

        #region 信息定价 HasFixPrice
        /// <summary>
        /// 信息定价
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <param name="FixPriceID">定价等级ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public bool HasFixPrice(long InfoID, string FixPriceID, string LoginName)
        {
            int rowsAffected;

            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@FixPriceID",SqlDbType.Char,10),
											new SqlParameter("@LoginName",SqlDbType.Char,16),
			};

            parameters[0].Value = InfoID;
            parameters[1].Value = FixPriceID;
            parameters[2].Value = LoginName;


            DbHelperSQL.RunProcedure("MainInfoTab_FixPrice", parameters, out  rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion

        #region 设置购物券
        public int HasCost(long InfoID, int flg)
        {
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@IsVoucherInfo",SqlDbType.Int),
                                            new SqlParameter("@ResultStatus",SqlDbType.Int),
			};
            parameters[0].Value = InfoID;
            parameters[1].Value = flg;
            parameters[2].Direction = ParameterDirection.Output;
            int isIntegralInfo = DbHelperSQL.RunProcReturn("MainInfoSetCost", parameters);
            return isIntegralInfo;
        }
        #endregion

        #region 更新信息拓富指数

        public bool HasMainEvaluation(long InfoID, decimal MainEvaluation)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@MainEvaluation",SqlDbType.Decimal),
			};
            parameters[0].Value = InfoID;
            parameters[1].Value = MainEvaluation;

            DbHelperSQL.RunProcedure("MainInfoTab_MainEvaluation", parameters, out  rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;

        }

        #endregion

        #region 更新信息的静态化地址
        public bool HasHtmlFile(long InfoID, string HtmlFile)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	new SqlParameter("@InfoID",SqlDbType.BigInt),
											new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
			};
            parameters[0].Value = InfoID;
            parameters[1].Value = HtmlFile;

            DbHelperSQL.RunProcedure("MainInfoTab_HtmlFile", parameters, out  rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        #region 会员查看免费信息限制
        /// <summary>
        /// 会员查看免费信息限制
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="ip">用户所使用的IP</param>
        /// <param name="infoId">信息ID</param>
        /// <param name="viewOptions">--0未验证可通过,1 已经验证通过,2未验证不通过</param>
        /// <param name="validateOptions">--0未超出限制 ,1 会员规定取阅数超出限制,2 IP取阅数超出限制</param>
        /// <returns>是否执行成功</returns>
        public bool FreeInfoView(string loginName, string ip, long infoId, ref int viewOptions, ref int validateOptions)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	
											new SqlParameter("@LoginName",SqlDbType.VarChar,30),
											new SqlParameter("@IP",SqlDbType.VarChar,30),
											new SqlParameter("@VerifyFlag",SqlDbType.SmallInt),
											new SqlParameter("@OverflowFlag",SqlDbType.SmallInt),
											new SqlParameter("@InfoId",SqlDbType.BigInt)
										};
            parameters[0].Value = loginName;
            parameters[1].Value = ip;
            parameters[2].Direction = System.Data.ParameterDirection.Output;
            parameters[3].Direction = System.Data.ParameterDirection.Output;
            parameters[4].Value = infoId;

            DbHelperSQL.RunProcedure("FreeViewInfo", parameters, out rowsAffected);

            validateOptions = Convert.ToInt32(parameters[2].Value);
            viewOptions = Convert.ToInt32(parameters[3].Value);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        #endregion

        #region 获取信息类型
        public string GetInfoTypeID(long InfoID)
        {
            string SqlText = "Select InfoTypeID from MainInfoTab Where InfoID = " + InfoID.ToString();
            return Convert.ToString(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
        }
        #endregion

        #region 统计信息购买人数
        public int GetInfoBuyersCount(long InfoID)
        {
            string SqlText = "Select Count(1) from ConsumeRecTab Where InfoID = " + InfoID.ToString();
            return Convert.ToInt32(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
        }
        #endregion

        #region 设置融资信息置顶
        public bool SetProjectInfoTop(long InfoID, int IsTop)
        {
            string SqlText = "Update ProjectInfoTab set IsTop = " + IsTop.ToString() + " where InfoID = " + InfoID.ToString();
            int reff = DbHelperSQL.ExecuteSql(SqlText);

            if (reff > 0)
                return true;
            return false;
        }
        #endregion

        public bool AddHit(long InfoID)
        {
            string SqlText = "Update MainInfoTab set Hit =Hit+1 where InfoID = " + InfoID.ToString();
            int reff = DbHelperSQL.ExecuteSql(SqlText);

            if (reff > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 资源举报
        /// </summary>
        /// <param name="InfoID">举报信息</param>
        /// <param name="reportMan">举报人</param>
        /// <param name="Remark">说明</param>
        /// <returns></returns>
        public bool InfoReport(long InfoID, string reportMan, string Remark)
        {
            SqlParameter[] parameters = { new  SqlParameter("@InfoID",SqlDbType.BigInt),
                                          new  SqlParameter("@RePortMan",SqlDbType.VarChar,16),
                                          new  SqlParameter("@RePortRemark",SqlDbType.VarChar,100),
                                          new  SqlParameter("@flag",SqlDbType.VarChar,30),
            };
            parameters[0].Value = InfoID;
            parameters[1].Value = reportMan;
            parameters[2].Value = Remark;
            parameters[3].Value = "report";
            bool b = DbHelperSQL.RunProcLob("InfoReport", parameters);
           return b;
        }
        /// <summary>
        /// 举报处理
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="chkMan">处理人</param>
        /// <param name="Remark">处理结果</param>
        /// <returns></returns>
        public bool InfoReportCheck(int ID, string chkMan, string Remark)
        {
            SqlParameter[] parameters = { new  SqlParameter("@ID",SqlDbType.Int),
                                          new  SqlParameter("@CheckMan",SqlDbType.VarChar,16),
                                          new  SqlParameter("@CheckRemark",SqlDbType.VarChar,100),
                                          new  SqlParameter("@flag",SqlDbType.VarChar,30),
            };
            parameters[0].Value = ID;
            parameters[1].Value = chkMan;
            parameters[2].Value = Remark;
            parameters[3].Value = "chk";
            bool b = DbHelperSQL.RunProcLob("InfoReport", parameters);
            return b;
        }

        /// <summary>
        /// 获取此条信息用户 然后发送通知
        /// </summary>
        /// <param name="infoid">该条资源ID</param>
        /// <returns></returns>
        public string GetMaininfo(string InfoID)
        {           
            string sql="select loginname from MainInfoTab where infoid="+InfoID.Replace("'","").Replace("--","");
            return DbHelperSQL.GetSingle(sql).ToString();
        }
        /// <summary>
        /// 更新推广状态
        /// </summary>
        /// <param name="InfoId">该条资源ID</param>
        /// <param name="PromotionStatu">修改的列</param>
        /// <returns></returns>
        public bool UpdatePromotionStatu(long InfoId, int PromotionStatu)
        {
            string sql = "update maininfotab set PromotionStatu="+PromotionStatu+" where infoid='"+InfoId+"'";
            int reff= DbHelperSQL.ExecuteSql(sql);
            if (reff>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 获取资源积分
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoID">主表信息编号</param>
        /// <param name="MainEvaluation">积分</param>
        /// <returns></returns>
        public int GetInfoMainEvaluation(long InfoID, int MainEvaluation)
        {
            string SqlText = "update MainInfoTab set MainEvaluation = MainEvaluation+" + MainEvaluation.ToString() + " where InfoID =" + InfoID.ToString();
            return DbHelperSQL.ExecuteSql(SqlText);
        }
        #endregion
    }
}