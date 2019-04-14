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
        #region IMainInfo ��Ա

        /// <summary>
        /// �õ�һ������ʵ��
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
        /// ��ѯ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetOneList(string InfoID)
        {
            string strsql = "select * from MenberInfo_ViewCar where InfoID=" + InfoID;
            return DBUtility.DbHelperSQL.Query(strsql);
        }
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet IndustryList()
        {
            string strsql = "select * from SetIndustryCraveOutTab";
            return DBUtility.DbHelperSQL.Query(strsql);
        }

        /// <summary>
        /// ��ȡ�����б�
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
        /// ��������ͳ����Ϣ��Ŀ
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

        #region �û�ɾ����Ϣ
        /// <summary>
        /// �û�ɾ����Ϣ
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

        #region ɾ����Ϣ HasDelete
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
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

        #region ��ȫɾ����Ϣ HasCompleteDelete
        /// <summary>
        /// ��ȫɾ����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
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

        #region ����Դ������ͼ��ȡ����
        /// <summary>
        /// ����Դ������ͼ��ȡ����
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

        #region ��Դˢ��
        /// <summary>
        /// ��Դˢ��
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

        #region ������Ϣ��Ч��

        /// <summary>
        /// ������Ϣ��Ч��
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

        #region ������Ч��
        /// <summary>
        /// ������Ч��
        /// </summary>
        /// <param name="infoId">��ϢID</param>
        /// <param name="startDay">��ʼ��Чʱ��</param>
        /// <param name="terms">��Ч����</param>
        /// <returns>�Ƿ���³ɹ�</returns>
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

        #region �����Ϣ
        /// <summary>
        /// �����Ϣ
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <param name="AuditingStatus">���״̬:0δ��ˣ� 1���ͨ����2���δͨ��</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
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
											new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),//���ֶβ���Ҫ���£�ֻ�������ʱ�Ÿ���
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

        #region ����ظ���Ϣ�б�
        /// <summary>
        /// ����ظ���Ϣ�б�
        /// </summary>
        /// <param name="infoId">��ϢID</param>
        /// <param name="count">�ظ�����</param>
        /// <param name="isJustCount">�Ƿ�ֻ��������</param>
        /// <returns>������Ϣ�б�</returns>
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

        #region ��Ϣ���״̬��¼

        /// <summary>
        /// ��Ϣ���״̬��¼
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

        #region ��ȡ���״̬��¼

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

        #region ��Ϣ���� HasFixPrice
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="InfoID">��ϢID</param>
        /// <param name="FixPriceID">���۵ȼ�ID</param>
        /// <returns>��������ɹ�����true�����򷵻�false</returns>
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

        #region ���ù���ȯ
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

        #region ������Ϣ�ظ�ָ��

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

        #region ������Ϣ�ľ�̬����ַ
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

        #region ��Ա�鿴�����Ϣ����
        /// <summary>
        /// ��Ա�鿴�����Ϣ����
        /// </summary>
        /// <param name="loginName">�û���</param>
        /// <param name="ip">�û���ʹ�õ�IP</param>
        /// <param name="infoId">��ϢID</param>
        /// <param name="viewOptions">--0δ��֤��ͨ��,1 �Ѿ���֤ͨ��,2δ��֤��ͨ��</param>
        /// <param name="validateOptions">--0δ�������� ,1 ��Ա�涨ȡ������������,2 IPȡ������������</param>
        /// <returns>�Ƿ�ִ�гɹ�</returns>
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

        #region ��ȡ��Ϣ����
        public string GetInfoTypeID(long InfoID)
        {
            string SqlText = "Select InfoTypeID from MainInfoTab Where InfoID = " + InfoID.ToString();
            return Convert.ToString(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
        }
        #endregion

        #region ͳ����Ϣ��������
        public int GetInfoBuyersCount(long InfoID)
        {
            string SqlText = "Select Count(1) from ConsumeRecTab Where InfoID = " + InfoID.ToString();
            return Convert.ToInt32(DbHelperSQL.Query(SqlText).Tables[0].Rows[0][0]);
        }
        #endregion

        #region ����������Ϣ�ö�
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
        /// ��Դ�ٱ�
        /// </summary>
        /// <param name="InfoID">�ٱ���Ϣ</param>
        /// <param name="reportMan">�ٱ���</param>
        /// <param name="Remark">˵��</param>
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
        /// �ٱ�����
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="chkMan">������</param>
        /// <param name="Remark">������</param>
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
        /// ��ȡ������Ϣ�û� Ȼ����֪ͨ
        /// </summary>
        /// <param name="infoid">������ԴID</param>
        /// <returns></returns>
        public string GetMaininfo(string InfoID)
        {           
            string sql="select loginname from MainInfoTab where infoid="+InfoID.Replace("'","").Replace("--","");
            return DbHelperSQL.GetSingle(sql).ToString();
        }
        /// <summary>
        /// �����ƹ�״̬
        /// </summary>
        /// <param name="InfoId">������ԴID</param>
        /// <param name="PromotionStatu">�޸ĵ���</param>
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

        #region ��ȡ��Դ����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoID">������Ϣ���</param>
        /// <param name="MainEvaluation">����</param>
        /// <returns></returns>
        public int GetInfoMainEvaluation(long InfoID, int MainEvaluation)
        {
            string SqlText = "update MainInfoTab set MainEvaluation = MainEvaluation+" + MainEvaluation.ToString() + " where InfoID =" + InfoID.ToString();
            return DbHelperSQL.ExecuteSql(SqlText);
        }
        #endregion
    }
}