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
    /// <summary>
    /// ��Ŀ��Ϣ���ݿ�����߼���
    /// </summary>
    public class ProjectInfoDAL : IProjectInfo
    {
        private const string SP_ProjectInfo_Insert = "ProjectInfoTab_Insert";
        private const string SP_InfoContactMan_Insert = "InfoContactManTab_Insert";
        private const string SP_InfoResource_Insert = "InfoResourceTab_Insert";
        private const string SP_InfoResource_InsertNew = "Project_gq_InsertNew";


        #region --�õ��ɼ�����ʵ��--
        public Tz888.Model.Info.ExcavateProjectModel GetExcavateProjectModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ExcavateProjectModel model = new ExcavateProjectModel();
            DataSet ds = DbHelperSQL.RunProcedure("UP_ExcavateProjectTab_Model", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                model.Com = ds.Tables[0].Rows[0]["com"].ToString();
                model.ComInfo = ds.Tables[0].Rows[0]["cominfo"].ToString();
                model.ComMan = ds.Tables[0].Rows[0]["comMan"].ToString();
                model.ComTel = ds.Tables[0].Rows[0]["comTel"].ToString();
                model.Intent = ds.Tables[0].Rows[0]["intent"].ToString();
                model.Industry = ds.Tables[0].Rows[0]["Industry"].ToString();
                model.Mode = ds.Tables[0].Rows[0]["mode"].ToString();
                model.Country = ds.Tables[0].Rows[0]["Country"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.Prjmoney = ds.Tables[0].Rows[0]["Prjmoney"].ToString();
                model.ManAddress = ds.Tables[0].Rows[0]["ManAddress"].ToString();
                model.ManCode = ds.Tables[0].Rows[0]["ManCode"].ToString();
                model.ManMobile = ds.Tables[0].Rows[0]["ManMobile"].ToString();
                model.ManTel = ds.Tables[0].Rows[0]["ManTel"].ToString();
                model.ManTax = ds.Tables[0].Rows[0]["ManTax"].ToString();
                model.ManEmail = ds.Tables[0].Rows[0]["ManEmail"].ToString();
                model.WebUrl = ds.Tables[0].Rows[0]["WebUrl"].ToString();
                model.PublishTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["PublishTime"]);
                model.Man = ds.Tables[0].Rows[0]["man"].ToString();
                model.ProjectInfo = ds.Tables[0].Rows[0]["projectInfo"].ToString();
            }
            return model;
        }
        #endregion

        #region --�޸ķ���״̬--
        public bool excavateProjecttabUpdatePublish(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_ExcavateProjectTab_IsPublishUpdate", parameters);
            return result;
        }
        #endregion

        #region --�޸�ɾ��״̬--
        public bool excavateProjecttabUpdateDelete(long id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = id;
            bool result = DbHelperSQL.RunProcLob("UP_ExcavateProjectTab_IsDeleteUpdate", parameters);
            return result;
        }
        #endregion

        #region ���һ����Ŀ��Ϣ
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
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
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------����(��Ŀ)��Դ������Ϣ-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------��Դ��ϵ��Ϣ--------------------------

					new SqlParameter("@ComName", SqlDbType.VarChar,40),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
					new SqlParameter("@TelStateCode", SqlDbType.Char,4),
					new SqlParameter("@TelNum", SqlDbType.VarChar,60),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,3),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,4),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,60),

					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),

                //---------------------------END---------------------------

                //-------------------------����Ϣ--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------������Ŀ��Ϣ--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
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

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            parameters[39].Value = infoContactModel.OrganizationName;
            parameters[40].Value = infoContactModel.Name;
            parameters[41].Value = infoContactModel.TelCountryCode;
            parameters[42].Value = infoContactModel.TelStateCode;
            parameters[43].Value = infoContactModel.TelNum;
            parameters[44].Value = infoContactModel.FaxCountryCode;
            parameters[45].Value = infoContactModel.FaxStateCode;
            parameters[46].Value = infoContactModel.FaxNum;
            parameters[47].Value = infoContactModel.Mobile;
            parameters[48].Value = infoContactModel.Address;
            parameters[49].Value = infoContactModel.PostCode;
            parameters[50].Value = infoContactModel.Email;
            parameters[51].Value = infoContactModel.WebSite;

            parameters[52].Value = shortInfoModel.ShortInfoControlID;
            parameters[53].Value = shortInfoModel.ShortTitle;
            parameters[54].Value = shortInfoModel.ShortContent;
            parameters[55].Value = shortInfoModel.Remark;

            parameters[56].Value = projectInfoModel.IsRec;
            parameters[57].Value = projectInfoModel.IsTop;
            parameters[58].Value = projectInfoModel.RecTime;
            parameters[59].Value = projectInfoModel.RecRemark;
            parameters[60].Value = projectInfoModel.RecTerm;

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_ProjectInfo_Insert, parameters, out rowsAffected);
                    //DbHelperSQL.RunProcedure(SP_ProjectInfo_Insert, parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    if (infoContactManModels != null)
                    {
                        //Ϊ������Դ��Ӷ����ϵ��
                        Tz888.SQLServerDAL.Info.InfoContactManDAL obj1 = new InfoContactManDAL();
                        foreach (Tz888.Model.Info.InfoContactManModel model in infoContactManModels)
                        {
                            model.InfoID = infoID;
                            obj1.InsertContactMan(sqlConn, sqlTran, model);
                        }
                    }

                    if (infoResourceModels != null)
                    {
                        //Ϊ������Ϣ��Ӷ����Դ
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj2 = new InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            obj2.InsertInfoResource(sqlConn, sqlTran, model);
                        }
                    }
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

        #region �޸���Ŀ��Ϣ
        public bool Update(Tz888.Model.Info.ProjectSetModel model)
        {
            SqlParameter[] parameters = {
                                    //������Ϣ
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10),

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    
                                    //��Ŀ��Ϣ
                                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					                new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					                new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Float,8),
                                    
                                    //��ϵ��Ϣ
					                new SqlParameter("@ComName", SqlDbType.VarChar,100),
					                new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					                new SqlParameter("@TelCountryCode", SqlDbType.Char,6),
					                new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					                new SqlParameter("@TelNum", SqlDbType.VarChar,100),
					                new SqlParameter("@FaxCountryCode", SqlDbType.Char,6),
					                new SqlParameter("@FaxStateCode", SqlDbType.Char,8),
					                new SqlParameter("@FaxNum", SqlDbType.VarChar,100),
                                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					                new SqlParameter("@Address", SqlDbType.VarChar,100),
					                new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					                new SqlParameter("@Email", SqlDbType.VarChar,50),
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                                    
                                    //����Ϣ��
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                                //-------------------------������Ŀ��Ϣ--------------------------
                	                new SqlParameter("@IsRec", SqlDbType.Bit,1),
					                new SqlParameter("@IsTop", SqlDbType.Bit,1),
					                new SqlParameter("@RecTime", SqlDbType.DateTime),
					                new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					                new SqlParameter("@RecTerm", SqlDbType.Int,4),
                                //---------------------------END---------------------------
                                    
            };
            parameters[0].Value = model.MainInfoModel.InfoID;
            parameters[1].Value = model.MainInfoModel.Title;
            parameters[2].Value = model.MainInfoModel.publishT;
            parameters[3].Value = model.MainInfoModel.LoginName;

            parameters[4].Value = model.MainInfoModel.KeyWord;
            parameters[5].Value = model.MainInfoModel.Descript;
            parameters[6].Value = model.MainInfoModel.DisplayTitle;
            parameters[7].Value = model.MainInfoModel.FrontDisplayTime;
            parameters[8].Value = model.MainInfoModel.ValidateStartTime;
            parameters[9].Value = model.MainInfoModel.ValidateTerm;
            parameters[10].Value = model.MainInfoModel.TemplateID;
            parameters[11].Value = model.MainInfoModel.HtmlFile;

            parameters[12].Value = model.ProjectInfoModel.ProjectName;
            parameters[13].Value = model.ProjectInfoModel.ProjectNameBrief;
            parameters[14].Value = model.ProjectInfoModel.ComAbout;
            parameters[15].Value = model.ProjectInfoModel.ComBrief;
            parameters[16].Value = model.ProjectInfoModel.CountryCode;
            parameters[17].Value = model.ProjectInfoModel.ProvinceID;
            parameters[18].Value = model.ProjectInfoModel.CityID;
            parameters[19].Value = model.ProjectInfoModel.CountyID;
            parameters[20].Value = model.ProjectInfoModel.IndustryBID;
            parameters[21].Value = model.ProjectInfoModel.CooperationDemandType;
            parameters[22].Value = model.ProjectInfoModel.CapitalCurrency;
            parameters[23].Value = model.ProjectInfoModel.CapitalTotal;
            parameters[24].Value = model.ProjectInfoModel.ProjectCurrency;
            parameters[25].Value = model.ProjectInfoModel.CapitalID;

            parameters[26].Value = model.InfoContactModel.OrganizationName;
            parameters[27].Value = model.InfoContactModel.Name;
            parameters[28].Value = model.InfoContactModel.TelCountryCode;
            parameters[29].Value = model.InfoContactModel.TelStateCode;
            parameters[30].Value = model.InfoContactModel.TelNum;
            parameters[31].Value = model.InfoContactModel.FaxCountryCode;
            parameters[32].Value = model.InfoContactModel.FaxStateCode;
            parameters[33].Value = model.InfoContactModel.FaxNum;
            parameters[34].Value = model.InfoContactModel.Mobile;
            parameters[35].Value = model.InfoContactModel.Address;
            parameters[36].Value = model.InfoContactModel.PostCode;
            parameters[37].Value = model.InfoContactModel.Email;
            parameters[38].Value = model.InfoContactModel.WebSite;

            parameters[39].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[40].Value = model.ShortInfoModel.ShortTitle;
            parameters[41].Value = model.ShortInfoModel.ShortContent;
            parameters[42].Value = model.ShortInfoModel.Remark;

            parameters[43].Value = model.ProjectInfoModel.IsRec;
            parameters[44].Value = model.ProjectInfoModel.IsTop;
            parameters[45].Value = model.ProjectInfoModel.RecTime;
            parameters[46].Value = model.ProjectInfoModel.RecRemark;
            parameters[47].Value = model.ProjectInfoModel.RecTerm;


            bool ReturnValue = false;
            long infoID = model.MainInfoModel.InfoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //�޸���Ŀ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "ProjectInfoTab_Update", parameters, out rowsAffected);

                    //Ϊ��Ŀ��Ϣ������ϵ����Ϣ
                    Tz888.SQLServerDAL.Info.InfoContactManDAL obj2 = new InfoContactManDAL();
                    obj2.DeleteByInfoID(sqlConn, sqlTran, infoID);
                    if (model.InfoContactManModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoContactManModel tmpModel in model.InfoContactManModels)
                        {
                            tmpModel.InfoID = infoID;
                            obj2.InsertContactMan(sqlConn, sqlTran, tmpModel);
                        }
                    }

                    //Ϊ��Ŀ��Ϣ��Ӷ����Դ
                    Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                    obj3.DeleteByInfoID(sqlConn, sqlTran, infoID);
                    if (model.InfoResourceModels != null)
                    {
                        foreach (Tz888.Model.Info.InfoResourceModel tmpModel in model.InfoResourceModels)
                        {
                            tmpModel.InfoID = infoID;
                            obj3.InsertInfoResource(sqlConn, sqlTran, tmpModel);
                        }
                    }
                    sqlTran.Commit();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion

        #region  �õ�һ������ʵ��(ֻ����ProjectInfoTab����Ϣ)
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.Info.ProjectInfoModel GetModel(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            Tz888.Model.Info.ProjectInfoModel model = new Tz888.Model.Info.ProjectInfoModel();

            DataSet ds = DbHelperSQL.RunProcedure("ProjectInfoTab_GetModel", parameters, "ds");
            model.InfoID = InfoID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                model.ProjectNameBrief = ds.Tables[0].Rows[0]["ProjectNameBrief"].ToString();
                model.ComAbout = ds.Tables[0].Rows[0]["ComAbout"].ToString();
                model.ComBrief = ds.Tables[0].Rows[0]["ComBrief"].ToString();
                model.CountryCode = ds.Tables[0].Rows[0]["CountryCode"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[0]["ProvinceID"].ToString();

                model.CityID = ds.Tables[0].Rows[0]["CityID"].ToString();

                model.CountyID = ds.Tables[0].Rows[0]["CountyID"].ToString();

                model.IndustryBID = ds.Tables[0].Rows[0]["IndustryBID"].ToString();
                model.CooperationDemandType = ds.Tables[0].Rows[0]["CooperationDemandType"].ToString();
                model.CapitalCurrency = ds.Tables[0].Rows[0]["CapitalCurrency"].ToString();
                if (ds.Tables[0].Rows[0]["CapitalTotal"].ToString() != "")
                {
                    model.CapitalTotal = decimal.Parse(ds.Tables[0].Rows[0]["CapitalTotal"].ToString());
                }
                model.ProjectCurrency = ds.Tables[0].Rows[0]["ProjectCurrency"].ToString();
                model.CapitalID = ds.Tables[0].Rows[0]["CapitalID"].ToString();
                model.CapitalName = ds.Tables[0].Rows[0]["CapitalName"].ToString();
                model.Remrk = ds.Tables[0].Rows[0]["Remrk"].ToString();

                //---08.6.2��������

                if (ds.Tables[0].Rows[0]["SellStockShare"].ToString() != "")
                {
                    model.SellStockShare = int.Parse(ds.Tables[0].Rows[0]["SellStockShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnModeID"].ToString() != "")
                {
                    model.ReturnModeID = ds.Tables[0].Rows[0]["ReturnModeID"].ToString();
                }
                model.ProjectAbout = ds.Tables[0].Rows[0]["ProjectAbout"].ToString();
                model.marketAbout = ds.Tables[0].Rows[0]["marketAbout"].ToString();
                model.competitioAbout = ds.Tables[0].Rows[0]["competitioAbout"].ToString();
                model.BussinessModeAbout = ds.Tables[0].Rows[0]["BussinessModeAbout"].ToString();
                model.ManageTeamAbout = ds.Tables[0].Rows[0]["ManageTeamAbout"].ToString();

                model.warrant = ds.Tables[0].Rows[0]["warrant"].ToString();
                if (ds.Tables[0].Rows[0]["Dwlyysy"].ToString() != "")
                {
                    model.nDwlyysy = decimal.Parse(ds.Tables[0].Rows[0]["Dwlyysy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dwljly"].ToString() != "")
                {
                    model.nDwljly = decimal.Parse(ds.Tables[0].Rows[0]["Dwljly"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dwzzc"].ToString() != "")
                {
                    model.nDwzzc = decimal.Parse(ds.Tables[0].Rows[0]["Dwzzc"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Dwzfz"].ToString() != "")
                {
                    model.nDwzfz = decimal.Parse(ds.Tables[0].Rows[0]["Dwzfz"].ToString());
                }

                model.financingID = ds.Tables[0].Rows[0]["financingID"].ToString();


                //201006��Դ���еڶ��θİ棬�����ֶ�
                //ծȯ
                model.cZqXmlxqkb = ds.Tables[0].Rows[0]["cZqXmlxqkb"].ToString();   //--	��Ŀ�������
                model.cZqQyfzjd = ds.Tables[0].Rows[0]["cZqQyfzjd"].ToString();     //--��ҵ��չ�׶�
                if (IsNumber(ds.Tables[0].Rows[0]["iZqYqjjdwqk"].ToString()))
                {
                    model.iZqYqjjdwqk = FormatData(ds.Tables[0].Rows[0]["iZqYqjjdwqk"].ToString()); //--Ҫ���ʽ�λ���
                }
                else
                {
                    model.iZqYqjjdwqk = 0;
                }
                //--Ͷ�ʻر��� model.ProjectInfoModel.iZqTzfbq
                if (IsNumber(ds.Tables[0].Rows[0]["iZqTzfbq"].ToString()))
                {
                    model.iZqTzfbq = FormatData(ds.Tables[0].Rows[0]["iZqTzfbq"].ToString());
                }
                else
                {
                    model.iZqTzfbq = 0;
                }
                //��Ȩ
                model.sXmlxqk = ds.Tables[0].Rows[0]["Xmlxqk"].ToString();   //--	��Ŀ�������
                model.sQyfzjd = ds.Tables[0].Rows[0]["Qyfzjd"].ToString();     //--��ҵ��չ�׶�
                if (IsNumber(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()))
                {
                    model.iYqzjdwqk = FormatData(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()); //--Ҫ���ʽ�λ���
                }
                else
                {
                    model.iYqzjdwqk = 0;
                }
                //�г�ռ���ʷݶ�
                if (IsNumber(ds.Tables[0].Rows[0]["Sczylfy"].ToString()))
                {
                    model.iSczylfy = FormatData(ds.Tables[0].Rows[0]["Sczylfy"].ToString());
                }
                else
                {
                    model.iSczylfy = 0;
                }
                //��ҵ�г�������
                if (IsNumber(ds.Tables[0].Rows[0]["Hysczzl"].ToString()))
                {
                    model.iHysczzl = FormatData(ds.Tables[0].Rows[0]["Hysczzl"].ToString());
                }
                else
                {
                    model.iHysczzl = 0;
                }
                //�ʲ���ծ��
                if (IsNumber(ds.Tables[0].Rows[0]["Zcfzl"].ToString()))
                {
                    model.iZcfzl = FormatData(ds.Tables[0].Rows[0]["Zcfzl"].ToString());
                }
                else
                {
                    model.iZcfzl = 0;
                }
                //��λ��Ӫ����
                try
                {
                    model.CompanyYearIncome = decimal.Parse(ds.Tables[0].Rows[0]["CompanyYearIncome"].ToString());
                }
                catch
                {
                    model.CompanyYearIncome = decimal.Parse("0");
                }
                //��λ�꾻����
                try
                {
                    model.CompanyNG = decimal.Parse(ds.Tables[0].Rows[0]["CompanyNG"].ToString());
                }
                catch
                {
                    model.CompanyNG = decimal.Parse("0");
                }

                //��λ���ʲ�
                try
                {
                    model.CompanyTotalCapital = decimal.Parse(ds.Tables[0].Rows[0]["CompanyTotalCapital"].ToString());
                }
                catch
                {
                    model.CompanyTotalCapital = decimal.Parse("0");
                }
                //��λ�ܸ�ծ
                try
                {
                    model.CompanyTotalDebet = decimal.Parse(ds.Tables[0].Rows[0]["CompanyTotalDebet"].ToString());
                }
                catch
                {
                    model.CompanyTotalDebet = decimal.Parse("0");
                }
                if (IsNumber(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()))
                {
                    model.iYqzjdwqk = FormatData(ds.Tables[0].Rows[0]["Yqzjdwqk"].ToString()); //--Ҫ���ʽ�λ���
                }
                else
                {
                    model.iYqzjdwqk = 0;
                }
                //--��Ʒ�г�������
                if (IsNumber(ds.Tables[0].Rows[0]["iZqCpsczzl"].ToString()))
                {
                    model.iZqCpsczzl = FormatData(ds.Tables[0].Rows[0]["iZqCpsczzl"].ToString());
                }
                else
                {
                    model.iZqCpsczzl = 0;
                }
                //--��Ʒ�г�����
                if (IsNumber(ds.Tables[0].Rows[0]["iZqCpscYl"].ToString()))
                {
                    model.iZqCpscYl = FormatData(ds.Tables[0].Rows[0]["iZqCpscYl"].ToString());
                }
                else
                {
                    model.iZqCpscYl = 0;
                }
                //--�ʲ���ծ��
                if (IsNumber(ds.Tables[0].Rows[0]["iZqZcfzl"].ToString()))
                {
                    model.iZqZcfzl = FormatData(ds.Tables[0].Rows[0]["iZqZcfzl"].ToString());
                }
                else
                {
                    model.iZqZcfzl = 0;
                }
                //--��������
                if (IsNumber(ds.Tables[0].Rows[0]["iZqYdbl"].ToString()))
                {
                    model.iZqYdbl = FormatData(ds.Tables[0].Rows[0]["iZqYdbl"].ToString());
                }
                else
                {
                    model.iZqYdbl = 0;
                }

                //--Ͷ��������
                if (IsNumber(ds.Tables[0].Rows[0]["iZqTzsl"].ToString()))
                {
                    model.iZqTzsl = FormatData(ds.Tables[0].Rows[0]["iZqTzsl"].ToString());
                }
                else
                {
                    model.iZqTzsl = 0;
                }
                //--����������
                if (IsNumber(ds.Tables[0].Rows[0]["iZqXslyl"].ToString()))
                {
                    model.iZqXslyl = FormatData(ds.Tables[0].Rows[0]["iZqXslyl"].ToString());
                }
                else
                {
                    model.iZqXslyl = 0;
                }
                //--Ͷ�ʻر���
                if (IsNumber(ds.Tables[0].Rows[0]["Xmtzfbzq"].ToString()))
                {
                    model.iXmtzfbzq = FormatData(ds.Tables[0].Rows[0]["Xmtzfbzq"].ToString());
                }
                else
                {
                    model.iXmtzfbzq = 0;
                }
                //--��Ŀ��Ч����
                if (IsNumber(ds.Tables[0].Rows[0]["iZqXmyxqs"].ToString()))
                {
                    model.iZqXmyxqs = FormatData(ds.Tables[0].Rows[0]["iZqXmyxqs"].ToString());
                }
                else
                {
                    model.iZqXmyxqs = 0;
                }

                model.cZqXmzy = ds.Tables[0].Rows[0]["cZqXmzy"].ToString();    //--��ĿժҪ
                model.cZqXmgjz = ds.Tables[0].Rows[0]["cZqXmgjz"].ToString();    //--��Ŀ�ؼ���
                model.cZqCpks = ds.Tables[0].Rows[0]["ProjectAbout"].ToString();  //--��Ʒ����
                model.sXmgjz = ds.Tables[0].Rows[0]["xmgjz"].ToString();
                model.cZqJzfx = ds.Tables[0].Rows[0]["competitioAbout"].ToString();  //--��������
                model.cZqSyms = ds.Tables[0].Rows[0]["BussinessModeAbout"].ToString();    //--��ҵģʽ
                model.cZqGltd = ds.Tables[0].Rows[0]["ManageTeamAbout"].ToString();    //--�����Ŷ�

                //--��Ϣ������
                if (IsNumber(ds.Tables[0].Rows[0]["InformationIntegrity"].ToString()))
                {
                    model.InformationIntegrity = FormatData(ds.Tables[0].Rows[0]["InformationIntegrity"].ToString());
                }
                else
                {
                    model.InformationIntegrity = 0;
                }

                if (ds.Tables[0].Rows[0]["IsRec"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsRec"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRec"].ToString().ToLower() == "true"))
                    {
                        model.IsRec = true;
                    }
                    else
                    {
                        model.IsRec = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsTop"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["RecTime"].ToString() != "")
                {

                    model.RecTime = DateTime.Parse(ds.Tables[0].Rows[0]["RecTime"].ToString());
                }
                model.RecRemark = ds.Tables[0].Rows[0]["RecRemark"].ToString();
                if (ds.Tables[0].Rows[0]["RecTerm"].ToString() != "")
                {
                    model.RecTerm = int.Parse(ds.Tables[0].Rows[0]["RecTerm"].ToString());
                }
                //
                List<string> lstIndustryBName = new List<string>();
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    string sIndustryNameTemp = ds.Tables[1].Rows[i]["IndustryBName"].ToString().Trim();
                    string sIndustryIDTemp = ds.Tables[1].Rows[i]["IndustryBID"].ToString().Trim();
                    if (model.IndustryBID.IndexOf(sIndustryIDTemp) != -1)
                    {
                        lstIndustryBName.Add(sIndustryNameTemp);
                    }
                }
                model.IndustryBName = lstIndustryBName;

                List<string> lstCooperationDemandTypeName = new List<string>();
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    string sInfoType = ds.Tables[2].Rows[i]["InfoType"].ToString().Trim().ToLower();
                    if (sInfoType == "project")
                    {
                        string sCooperationDemandTypeNameTemp = ds.Tables[2].Rows[i]["CooperationDemandName"].ToString().Trim();
                        string sCooperationDemandTypeIDTemp = ds.Tables[2].Rows[i]["CooperationDemandTypeID"].ToString().Trim();
                        if (model.CooperationDemandType.Trim().IndexOf(sCooperationDemandTypeIDTemp.Trim()) != -1)
                        {
                            lstCooperationDemandTypeName.Add(sCooperationDemandTypeNameTemp);
                        }
                    }
                }
                model.CooperationDemandTypeName = lstCooperationDemandTypeName;

                if (ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                {
                    model.CountryName = ds.Tables[3].Rows[0]["CountryName"].ToString();
                }
                if (ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                {
                    model.ProvinceName = ds.Tables[4].Rows[0]["ProvinceName"].ToString();
                }
                if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
                {
                    model.CityName = ds.Tables[5].Rows[0]["CityName"].ToString();
                }
                if (ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0)
                {
                    model.CountyName = ds.Tables[6].Rows[0]["CountyName"].ToString();
                }


                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region �õ�һ������ʵ��(������Ŀ��Ϣ)
        /// <summary>
        /// ��ȡһ����������Ŀ��Ϣʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ProjectSetModel GetIntegrityModel(long InfoID)
        {
            Tz888.Model.Info.ProjectSetModel model = new ProjectSetModel();

            //��ȡ��Ҫ��Ϣ
            MainInfoDAL obj1 = new MainInfoDAL();
            model.MainInfoModel = obj1.GetModel(InfoID);

            //��ȡ��Ŀ��Դ������Ϣ
            model.ProjectInfoModel = this.GetModel(InfoID);

            //��ȡ��Ϣ��ϵ��ʽ
            InfoContactDAL obj3 = new InfoContactDAL();
            model.InfoContactModel = obj3.GetModel(InfoID);

            //��ȡ��Ŀ��Ϣ��ϵ��
            //InfoContactManDAL obj4 = new InfoContactManDAL();
            //model.InfoContactManModels = obj4.GetModelList(InfoID);

            //��ȡ��Ŀ��Ϣ�����Դ
            InfoResourceDAL obj5 = new InfoResourceDAL();
            model.InfoResourceModels = obj5.GetModelList(InfoID);

            //����Ϣ
            ShortInfoDAL obj6 = new ShortInfoDAL();
            model.ShortInfoModel = obj6.GetModel(InfoID);

            return model;
        }
        #endregion

        #region-- ��ѯ�б� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Tz888.SQLServerDAL.Conn dal = new Conn();
            return (dal.GetList(
                "ProjectInfoTabList",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion

        //������
        #region ծȯ ���� ��һ��
        public long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
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
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------����(��Ŀ)��Դ������Ϣ-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------������--------------------------

				
					new SqlParameter("@warrant", SqlDbType.VarChar,-1),
					new SqlParameter("@financingID", SqlDbType.VarChar,20),
                //---------------------------END---------------------------

                //-------------------------����Ϣ--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------������Ŀ��Ϣ--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------201006��Դ���еڶ��θİ�ƻ�------------//
                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//	��Ŀ�������
                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //��ҵ��չ�׶�
                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int),  //Ҫ���ʽ�λ���
                new SqlParameter("@iZqCpsczzl",SqlDbType.Int),   //��Ʒ�г�������
                new SqlParameter("@iZqCpscYl",SqlDbType.Int),    //��Ʒ�г�����
                new SqlParameter("@iZqZcfzl",SqlDbType.Int),     //�ʲ���ծ��
                new SqlParameter("@iZqYdbl",SqlDbType.Int),      //��������
                new SqlParameter("@iZqTzsl",SqlDbType.Int),      //Ͷ��������
                new SqlParameter("@iZqXslyl",SqlDbType.Int),     //����������
                new SqlParameter("@iZqTzfbq",SqlDbType.Int),     //Ͷ�ʻر���
                new SqlParameter("@iZqXmyxqs",SqlDbType.Int),    //��Ŀ��Ч����
                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//��ĿժҪ
                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//��Ŀ�ؼ���
                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//��Ʒ����
                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//��������
                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//��ҵģʽ
                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//�����Ŷ�
                //-------------------END------------------------------------//


                 //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------

                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //��Ϣ������

                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //��λ��Ӫҵ����
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //��λ�꾻����
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //��λ���ʲ�
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //��λ�ܸ�ծ
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

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //������

            parameters[39].Value = projectInfoModel.warrant;
            parameters[40].Value = projectInfoModel.financingID;

            parameters[41].Value = shortInfoModel.ShortInfoControlID;
            parameters[42].Value = shortInfoModel.ShortTitle;
            parameters[43].Value = shortInfoModel.ShortContent;
            parameters[44].Value = shortInfoModel.Remark;

            parameters[45].Value = projectInfoModel.IsRec;
            parameters[46].Value = projectInfoModel.IsTop;
            parameters[47].Value = projectInfoModel.RecTime;
            parameters[48].Value = projectInfoModel.RecRemark;
            parameters[49].Value = projectInfoModel.RecTerm;
            parameters[50].Value = "project_zq1";


            //-------------------201006��Դ���еڶ��θİ�ƻ�------------//
            parameters[51].Value = projectInfoModel.cZqXmlxqkb;//	��Ŀ�������
            parameters[52].Value = projectInfoModel.cZqQyfzjd; //��ҵ��չ�׶�
            parameters[53].Value = projectInfoModel.iZqYqjjdwqk;  //Ҫ���ʽ�λ���
            parameters[54].Value = projectInfoModel.iZqCpsczzl;   //��Ʒ�г�������
            parameters[55].Value = projectInfoModel.iZqCpscYl;    //��Ʒ�г�����
            parameters[56].Value = projectInfoModel.iZqZcfzl;     //�ʲ���ծ��
            parameters[57].Value = projectInfoModel.iZqYdbl;      //��������
            parameters[58].Value = projectInfoModel.iZqTzsl;      //Ͷ��������
            parameters[59].Value = projectInfoModel.iZqXslyl;     //����������
            parameters[60].Value = projectInfoModel.iZqTzfbq;     //Ͷ�ʻر���
            parameters[61].Value = projectInfoModel.iZqXmyxqs;    //��Ŀ��Ч����
            parameters[62].Value = projectInfoModel.cZqXmzy;//��ĿժҪ
            parameters[63].Value = projectInfoModel.cZqXmgjz;//��Ŀ�ؼ���
            parameters[64].Value = projectInfoModel.cZqCpks;//��Ʒ����
            parameters[65].Value = projectInfoModel.cZqJzfx;//��������
            parameters[66].Value = projectInfoModel.cZqSyms;//��ҵģʽ
            parameters[67].Value = projectInfoModel.cZqGltd;//�����Ŷ�
            //-------------------END------------------------------------//

            //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
            parameters[68].Value = projectInfoModel.ProjectAbout;
            parameters[69].Value = projectInfoModel.marketAbout;
            parameters[70].Value = projectInfoModel.competitioAbout;
            parameters[71].Value = projectInfoModel.BussinessModeAbout;
            parameters[72].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------

            parameters[73].Value = projectInfoModel.InformationIntegrity; //��Ϣ������

            parameters[74].Value = projectInfoModel.nDwlyysy;  //��λ��Ӫҵ����
            parameters[75].Value = projectInfoModel.nDwljly;   //��λ�꾻����
            parameters[76].Value = projectInfoModel.nDwzzc;    //��λ���ʲ�
            parameters[77].Value = projectInfoModel.nDwzfz;    //��λ�ܸ�ծ

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_zq_Insert", parameters, out rowsAffected);
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

        #region ծȯ ���� ��һ��[�ع�������ӵİ����ϴ�����ļ�]
        public long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
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
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------����(��Ŀ)��Դ������Ϣ-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------������--------------------------

				
					new SqlParameter("@warrant", SqlDbType.VarChar,-1),
					new SqlParameter("@financingID", SqlDbType.VarChar,20),
                //---------------------------END---------------------------

                //-------------------------����Ϣ--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------������Ŀ��Ϣ--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------201006��Դ���еڶ��θİ�ƻ�------------//
                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//	��Ŀ�������
                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //��ҵ��չ�׶�
                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int),  //Ҫ���ʽ�λ���
                new SqlParameter("@iZqCpsczzl",SqlDbType.Int),   //��Ʒ�г�������
                new SqlParameter("@iZqCpscYl",SqlDbType.Int),    //��Ʒ�г�����
                new SqlParameter("@iZqZcfzl",SqlDbType.Int),     //�ʲ���ծ��
                new SqlParameter("@iZqYdbl",SqlDbType.Int),      //��������
                new SqlParameter("@iZqTzsl",SqlDbType.Int),      //Ͷ��������
                new SqlParameter("@iZqXslyl",SqlDbType.Int),     //����������
                new SqlParameter("@iZqTzfbq",SqlDbType.Int),     //Ͷ�ʻر���
                new SqlParameter("@iZqXmyxqs",SqlDbType.Int),    //��Ŀ��Ч����
                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//��ĿժҪ
                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//��Ŀ�ؼ���
                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//��Ʒ����
                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//��������
                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//��ҵģʽ
                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//�����Ŷ�
                //-------------------END------------------------------------//


                 //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------

                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //��Ϣ������

                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //��λ��Ӫҵ����
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //��λ�꾻����
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //��λ���ʲ�
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //��λ�ܸ�ծ
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

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //������

            parameters[39].Value = projectInfoModel.warrant;
            parameters[40].Value = projectInfoModel.financingID;

            parameters[41].Value = shortInfoModel.ShortInfoControlID;
            parameters[42].Value = shortInfoModel.ShortTitle;
            parameters[43].Value = shortInfoModel.ShortContent;
            parameters[44].Value = shortInfoModel.Remark;

            parameters[45].Value = projectInfoModel.IsRec;
            parameters[46].Value = projectInfoModel.IsTop;
            parameters[47].Value = projectInfoModel.RecTime;
            parameters[48].Value = projectInfoModel.RecRemark;
            parameters[49].Value = projectInfoModel.RecTerm;
            parameters[50].Value = "project_zq1";


            //-------------------201006��Դ���еڶ��θİ�ƻ�------------//
            parameters[51].Value = projectInfoModel.cZqXmlxqkb;//	��Ŀ�������
            parameters[52].Value = projectInfoModel.cZqQyfzjd; //��ҵ��չ�׶�
            parameters[53].Value = projectInfoModel.iZqYqjjdwqk;  //Ҫ���ʽ�λ���
            parameters[54].Value = projectInfoModel.iZqCpsczzl;   //��Ʒ�г�������
            parameters[55].Value = projectInfoModel.iZqCpscYl;    //��Ʒ�г�����
            parameters[56].Value = projectInfoModel.iZqZcfzl;     //�ʲ���ծ��
            parameters[57].Value = projectInfoModel.iZqYdbl;      //��������
            parameters[58].Value = projectInfoModel.iZqTzsl;      //Ͷ��������
            parameters[59].Value = projectInfoModel.iZqXslyl;     //����������
            parameters[60].Value = projectInfoModel.iZqTzfbq;     //Ͷ�ʻر���
            parameters[61].Value = projectInfoModel.iZqXmyxqs;    //��Ŀ��Ч����
            parameters[62].Value = projectInfoModel.cZqXmzy;//��ĿժҪ
            parameters[63].Value = projectInfoModel.cZqXmgjz;//��Ŀ�ؼ���
            parameters[64].Value = projectInfoModel.cZqCpks;//��Ʒ����
            parameters[65].Value = projectInfoModel.cZqJzfx;//��������
            parameters[66].Value = projectInfoModel.cZqSyms;//��ҵģʽ
            parameters[67].Value = projectInfoModel.cZqGltd;//�����Ŷ�
            //-------------------END------------------------------------//

            //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
            parameters[68].Value = projectInfoModel.ProjectAbout;
            parameters[69].Value = projectInfoModel.marketAbout;
            parameters[70].Value = projectInfoModel.competitioAbout;
            parameters[71].Value = projectInfoModel.BussinessModeAbout;
            parameters[72].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------

            parameters[73].Value = projectInfoModel.InformationIntegrity; //��Ϣ������

            parameters[74].Value = projectInfoModel.nDwlyysy;  //��λ��Ӫҵ����
            parameters[75].Value = projectInfoModel.nDwljly;   //��λ�꾻����
            parameters[76].Value = projectInfoModel.nDwzzc;    //��λ���ʲ�
            parameters[77].Value = projectInfoModel.nDwzfz;    //��λ�ܸ�ծ

            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_zq_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();

                    //���ϴ��ļ�
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //��¼�ϴ���
                        //ΪͶ����Ϣ��Ӷ����Դ
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();

                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, model, 1))
                                iUploadCount += 1;
                        }
                        //û�гɹ�
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            return 0;
                        }
                    }


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

        #region ծȯ ���� �ڶ���
        public bool PublishProjectZQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@marketAbout", SqlDbType.NText),
                    new SqlParameter("@CompanyYearIncome", SqlDbType.Money,8),
					new SqlParameter("@CompanyNG", SqlDbType.Money,8),
					new SqlParameter("@CompanyTotalCapital", SqlDbType.Money,8),
					new SqlParameter("@CompanyTotalDebet", SqlDbType.Money,8),
				    new SqlParameter("@flag", SqlDbType.VarChar,30),
            };
            parameters[0].Value = projectInfoModel.InfoID;
            parameters[1].Value = projectInfoModel.marketAbout;
            parameters[2].Value = projectInfoModel.CompanyYearIncome;
            parameters[3].Value = projectInfoModel.CompanyNG;
            parameters[4].Value = projectInfoModel.CompanyTotalCapital;
            parameters[5].Value = projectInfoModel.CompanyTotalDebet;
            parameters[6].Value = "project_zq2";

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    int rowsAffected = 0;
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_zq_Insert", parameters, out rowsAffected);

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return true;
        }
        #endregion

        #region ծȯ�޸�
        public bool ProjectInfoZQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                                    //������Ϣ
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10),

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    
                                    //��Ŀ��Ϣ
                                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					                new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					                new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Float,8),
                                    
                                    //��ϵ��Ϣ
					                new SqlParameter("@ComName", SqlDbType.VarChar,100),
					                new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
                                    new SqlParameter("@Career", SqlDbType.VarChar,20),
					                new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					                new SqlParameter("@TelNum", SqlDbType.VarChar,100),
                                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					                new SqlParameter("@Address", SqlDbType.VarChar,100),
					                new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					                new SqlParameter("@Email", SqlDbType.VarChar,50),
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                                    
                                    //����Ϣ��
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                                //-------------------------������Ŀ��Ϣ--------------------------
                	                new SqlParameter("@IsRec", SqlDbType.Bit,1),
					                new SqlParameter("@IsTop", SqlDbType.Bit,1),
					                new SqlParameter("@RecTime", SqlDbType.DateTime),
					                new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					                new SqlParameter("@RecTerm", SqlDbType.Int,4),
                                //---------------------------������---------------------------
                                    new SqlParameter("@warrant", SqlDbType.VarChar,-1),
                                    new SqlParameter("@marketAbout", SqlDbType.NText),
                                    new SqlParameter("@CompanyYearIncome", SqlDbType.Money,8),
					                new SqlParameter("@CompanyNG", SqlDbType.Money,8),
					                new SqlParameter("@CompanyTotalCapital", SqlDbType.Money,8),
					                new SqlParameter("@CompanyTotalDebet", SqlDbType.Money,8),
                                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
                               //201006��Դ���еڶ��θİ棬�����ֶ�
                                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//--	��Ŀ�������
                                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //--��ҵ��չ�׶�
                                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int,4),  //--Ҫ���ʽ�λ���
                                new SqlParameter("@iZqCpsczzl",SqlDbType.Int,4),   //--��Ʒ�г�������
                                new SqlParameter("@iZqCpscYl",SqlDbType.Int,4),    //--��Ʒ�г�����
                                new SqlParameter("@iZqZcfzl",SqlDbType.Int,4),     //--�ʲ���ծ��
                                new SqlParameter("@iZqYdbl",SqlDbType.Int,4),      //--��������
                                new SqlParameter("@iZqTzsl",SqlDbType.Int,4),     //--Ͷ��������
                                new SqlParameter("@iZqXslyl",SqlDbType.Int,4),     //--����������
                                new SqlParameter("@iZqTzfbq",SqlDbType.Int,4),     //--Ͷ�ʻر���
                                new SqlParameter("@iZqXmyxqs",SqlDbType.Int,4),    //--��Ŀ��Ч����
                                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//--��ĿժҪ
                                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//--��Ŀ�ؼ���
                                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//--��Ʒ����
                                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//--��������
                                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//--��ҵģʽ
                                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//--�����Ŷ�
                                //-------END---------------------------

                                new SqlParameter("@iInformationIntegrity",SqlDbType.Int,4), //--��Ϣ������
                                //-----------20100629------------------
                                new SqlParameter("@iSczylfy",SqlDbType.NVarChar,100),//--�г�ռ����(�ݶ�)
                                new SqlParameter("@iHysczzl",SqlDbType.NVarChar,100),//--��ҵ�г�������
                                new SqlParameter("@iZcfzl",SqlDbType.NVarChar,100) //--�ʲ���ծ��
            };
            parameters[0].Value = model.MainInfoModel.InfoID;
            parameters[1].Value = model.MainInfoModel.Title;
            parameters[2].Value = model.MainInfoModel.publishT;
            parameters[3].Value = model.MainInfoModel.LoginName;

            parameters[4].Value = model.MainInfoModel.KeyWord;
            parameters[5].Value = model.MainInfoModel.Descript;
            parameters[6].Value = model.MainInfoModel.DisplayTitle;
            parameters[7].Value = model.MainInfoModel.FrontDisplayTime;
            parameters[8].Value = model.MainInfoModel.ValidateStartTime;
            parameters[9].Value = model.MainInfoModel.ValidateTerm;
            parameters[10].Value = model.MainInfoModel.TemplateID;
            parameters[11].Value = model.MainInfoModel.HtmlFile;

            parameters[12].Value = model.ProjectInfoModel.ProjectName;
            parameters[13].Value = model.ProjectInfoModel.ProjectNameBrief;
            parameters[14].Value = model.ProjectInfoModel.ComAbout;
            parameters[15].Value = model.ProjectInfoModel.ComBrief;
            parameters[16].Value = model.ProjectInfoModel.CountryCode;
            parameters[17].Value = model.ProjectInfoModel.ProvinceID;
            parameters[18].Value = model.ProjectInfoModel.CityID;
            parameters[19].Value = model.ProjectInfoModel.CountyID;
            parameters[20].Value = model.ProjectInfoModel.IndustryBID;
            parameters[21].Value = model.ProjectInfoModel.CooperationDemandType;
            parameters[22].Value = model.ProjectInfoModel.CapitalCurrency;
            parameters[23].Value = model.ProjectInfoModel.CapitalTotal;
            parameters[24].Value = model.ProjectInfoModel.ProjectCurrency;
            parameters[25].Value = model.ProjectInfoModel.CapitalID;

            parameters[26].Value = model.InfoContactModel.OrganizationName;
            parameters[27].Value = model.InfoContactModel.Name;
            parameters[28].Value = model.InfoContactModel.Career;
            parameters[29].Value = model.InfoContactModel.TelStateCode;
            parameters[30].Value = model.InfoContactModel.TelNum;
            parameters[31].Value = model.InfoContactModel.Mobile;
            parameters[32].Value = model.InfoContactModel.Address;
            parameters[33].Value = model.InfoContactModel.PostCode;
            parameters[34].Value = model.InfoContactModel.Email;
            parameters[35].Value = model.InfoContactModel.WebSite;

            parameters[36].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[37].Value = model.ShortInfoModel.ShortTitle;
            parameters[38].Value = model.ShortInfoModel.ShortContent;
            parameters[39].Value = model.ShortInfoModel.Remark;

            parameters[40].Value = model.ProjectInfoModel.IsRec;
            parameters[41].Value = model.ProjectInfoModel.IsTop;
            parameters[42].Value = model.ProjectInfoModel.RecTime;
            parameters[43].Value = model.ProjectInfoModel.RecRemark;
            parameters[44].Value = model.ProjectInfoModel.RecTerm;

            parameters[45].Value = model.ProjectInfoModel.warrant;

            parameters[46].Value = model.ProjectInfoModel.marketAbout;

            parameters[47].Value = model.ProjectInfoModel.nDwlyysy;//��λ��Ӫҵ����
            parameters[48].Value = model.ProjectInfoModel.nDwljly; //��λ�꾻����
            parameters[49].Value = model.ProjectInfoModel.nDwzzc;//��λ���ʲ�
            parameters[50].Value = model.ProjectInfoModel.nDwzfz;//��λ�ܸ�ծ

            parameters[51].Value = model.ProjectInfoModel.financingID;
            parameters[52].Value = "UpdateZQ";

            //201006��Դ���еڶ��θİ棬�����ֶ�
            parameters[53].Value = model.ProjectInfoModel.cZqXmlxqkb;   //--	��Ŀ�������
            parameters[54].Value = model.ProjectInfoModel.cZqQyfzjd;    //--��ҵ��չ�׶�
            parameters[55].Value = model.ProjectInfoModel.iZqYqjjdwqk;    //--Ҫ���ʽ�λ���
            parameters[56].Value = model.ProjectInfoModel.iZqCpsczzl;    //--��Ʒ�г�������
            parameters[57].Value = model.ProjectInfoModel.iZqCpscYl;    //--��Ʒ�г�����
            parameters[58].Value = model.ProjectInfoModel.iZqZcfzl;    //--�ʲ���ծ��
            parameters[59].Value = model.ProjectInfoModel.iZqYdbl;    //--��������
            parameters[60].Value = model.ProjectInfoModel.iZqTzsl;    //--Ͷ��������
            parameters[61].Value = model.ProjectInfoModel.iZqXslyl;    //--����������
            parameters[62].Value = model.ProjectInfoModel.iZqTzfbq;    //--Ͷ�ʻر���
            parameters[63].Value = model.ProjectInfoModel.iZqXmyxqs;    //--��Ŀ��Ч����
            parameters[64].Value = model.ProjectInfoModel.cZqXmzy;    //--��ĿժҪ
            parameters[65].Value = model.ProjectInfoModel.cZqXmgjz;    //--��Ŀ�ؼ���
            parameters[66].Value = model.ProjectInfoModel.cZqCpks;    //--��Ʒ����

            parameters[67].Value = model.ProjectInfoModel.cZqJzfx;    //--��������
            parameters[68].Value = model.ProjectInfoModel.cZqSyms;    //--��ҵģʽ
            parameters[69].Value = model.ProjectInfoModel.cZqGltd;    //--�����Ŷ�
            parameters[70].Value = model.ProjectInfoModel.InformationIntegrity;    //--��Ϣ������
            //-------END---------------------------
            parameters[71].Value = model.ProjectInfoModel.iSczylfy;    //--�г�ռ����(�ݶ�)
            parameters[72].Value = model.ProjectInfoModel.iHysczzl;    //--��ҵ�г�������
            parameters[73].Value = model.ProjectInfoModel.iZcfzl;    //--�ʲ���ծ��

            bool ReturnValue = false;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //�޸���Ŀ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_Update", parameters, out rowsAffected);

                    //���ϴ��ļ�
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //��¼�ϴ���
                        //ΪͶ����Ϣ��Ӷ����Դ
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        //ɾ��ԭ����Դ
                        obj3.DeleteByInfoID(sqlConn, sqlTran, model.MainInfoModel.InfoID);
                        foreach (Tz888.Model.Info.InfoResourceModel Infomodel in infoResourceModels)
                        {
                            Infomodel.InfoID = model.MainInfoModel.InfoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, Infomodel, 1))
                                iUploadCount += 1;
                        }
                        //û�гɹ�
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            ReturnValue = false;
                        }
                    }
                    sqlTran.Commit();
                    sqlConn.Close();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion

        #region ��Ȩ ���� ��һ��
        public long PublishProjectGQ1(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.ProjectInfoModel projectInfoModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
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
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------����(��Ŀ)��Դ������Ϣ-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------������--------------------------

				
					new SqlParameter("@SellStockShare", SqlDbType.Int),
                    new SqlParameter("@ReturnModeID", SqlDbType.VarChar,20),
                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
					
                //---------------------------END---------------------------

                //-------------------------����Ϣ--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------������Ŀ��Ϣ--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------------201006��Դ���еڶ��θİ棬�����ӵ��ֶ�-------------------
                new SqlParameter("@cXmlxqk",SqlDbType.VarChar,20), //��Ŀ�������
                new SqlParameter("@cXmgjz",SqlDbType.NVarChar,100), //��Ŀ�ؼ���
                new SqlParameter("@cQyfzjd",SqlDbType.VarChar,20), //��ҵ��չ�׶�
                new SqlParameter("@iyqzjdwqk",SqlDbType.Int),//Ҫ���ʽ�λ���
                new SqlParameter("@iSczylfy",SqlDbType.Int), //�г�ռ����(�ݶ�)
                new SqlParameter("@iHysczzl",SqlDbType.Int), //��ҵ�г�������
                new SqlParameter("@iZcfzl",SqlDbType.Int), //�ʲ���ծ��
                new SqlParameter("@ixmtzfbzq",SqlDbType.Int), //��ĿͶ�ʻر�����
                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //��λ��Ӫҵ����
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //��λ�꾻����
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //��λ���ʲ�
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //��λ�ܸ�ծ
                new SqlParameter("@cXmqxms",SqlDbType.NVarChar,1000), //��Ŀ��ϸ����
                //-------------------------END-----------------------------------


                //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------
                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //��Ϣ������

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

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //������

            parameters[39].Value = projectInfoModel.SellStockShare;
            parameters[40].Value = projectInfoModel.ReturnModeID;
            parameters[41].Value = projectInfoModel.financingID;

            parameters[42].Value = shortInfoModel.ShortInfoControlID;
            parameters[43].Value = shortInfoModel.ShortTitle;
            parameters[44].Value = shortInfoModel.ShortContent;
            parameters[45].Value = shortInfoModel.Remark;

            parameters[46].Value = projectInfoModel.IsRec;
            parameters[47].Value = projectInfoModel.IsTop;
            parameters[48].Value = projectInfoModel.RecTime;
            parameters[49].Value = projectInfoModel.RecRemark;
            parameters[50].Value = projectInfoModel.RecTerm;
            parameters[51].Value = "project_gq1";


            //-------------------201006��Դ���еڶ��θİ棬�����ӵ��ֶ�
            parameters[52].Value = projectInfoModel.sXmlxqk;  //��Ŀ�������
            parameters[53].Value = projectInfoModel.sXmgjz;     //��Ŀ�ؼ���
            parameters[54].Value = projectInfoModel.sQyfzjd;//��ҵ��չ�׶�
            parameters[55].Value = projectInfoModel.iYqzjdwqk;//Ҫ���ʽ�λ���
            parameters[56].Value = projectInfoModel.iSczylfy;//�г�ռ����(�ݶ�)
            parameters[57].Value = projectInfoModel.iHysczzl;//��ҵ�г�������
            parameters[58].Value = projectInfoModel.iZcfzl;//�ʲ���ծ��
            parameters[59].Value = projectInfoModel.iXmtzfbzq;//��ĿͶ�ʻر�����
            parameters[60].Value = projectInfoModel.nDwlyysy;//��λ��Ӫҵ����
            parameters[61].Value = projectInfoModel.nDwljly;//��λ�꾻����
            parameters[62].Value = projectInfoModel.nDwzzc;//��λ���ʲ�
            parameters[63].Value = projectInfoModel.nDwzfz;//��λ�ܸ�ծ
            parameters[64].Value = projectInfoModel.sXmqxms;//��Ŀ��ϸ����
            //-------------------END---------------------------------------


            //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
            parameters[65].Value = projectInfoModel.ProjectAbout;
            parameters[66].Value = projectInfoModel.marketAbout;
            parameters[67].Value = projectInfoModel.competitioAbout;
            parameters[68].Value = projectInfoModel.BussinessModeAbout;
            parameters[69].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------
            parameters[70].Value = projectInfoModel.InformationIntegrity; //��Ϣ������


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_gq_Insert", parameters, out rowsAffected);
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

        #region ��Ȩ ���� ��һ��_�·����������ϼ��ļ�)
        public long PublishProjectGQ1(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.ProjectInfoModel projectInfoModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel,
           List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
)
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
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
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------����(��Ŀ)��Դ������Ϣ-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------������--------------------------

				
					new SqlParameter("@SellStockShare", SqlDbType.Int),
                    new SqlParameter("@ReturnModeID", SqlDbType.VarChar,20),
                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
					
                //---------------------------END---------------------------

                //-------------------------����Ϣ--------------------------

					new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                //---------------------------END---------------------------

                //-------------------------������Ŀ��Ϣ--------------------------
                	new SqlParameter("@IsRec", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@RecTime", SqlDbType.DateTime),
					new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					new SqlParameter("@RecTerm", SqlDbType.Int,4),
                //---------------------------END---------------------------
                new SqlParameter("@flag", SqlDbType.VarChar,30),


                //-------------------------201006��Դ���еڶ��θİ棬�����ӵ��ֶ�-------------------
                new SqlParameter("@cXmlxqk",SqlDbType.VarChar,20), //��Ŀ�������
                new SqlParameter("@cXmgjz",SqlDbType.NVarChar,100), //��Ŀ�ؼ���
                new SqlParameter("@cQyfzjd",SqlDbType.VarChar,20), //��ҵ��չ�׶�
                new SqlParameter("@iyqzjdwqk",SqlDbType.Int),//Ҫ���ʽ�λ���
                new SqlParameter("@iSczylfy",SqlDbType.Int), //�г�ռ����(�ݶ�)
                new SqlParameter("@iHysczzl",SqlDbType.Int), //��ҵ�г�������
                new SqlParameter("@iZcfzl",SqlDbType.Int), //�ʲ���ծ��
                new SqlParameter("@ixmtzfbzq",SqlDbType.Int), //��ĿͶ�ʻر�����
                new SqlParameter("@nDwlyysy",SqlDbType.Decimal), //��λ��Ӫҵ����
                new SqlParameter("@nDwljly",SqlDbType.Decimal), //��λ�꾻����
                new SqlParameter("@nDwzzc",SqlDbType.Decimal), //��λ���ʲ�
                new SqlParameter("@nDwzfz",SqlDbType.Decimal), //��λ�ܸ�ծ
                new SqlParameter("@cXmqxms",SqlDbType.NVarChar,1000), //��Ŀ��ϸ����
                //-------------------------END-----------------------------------


                //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
                new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
				new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
				new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
				new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                //----------------END--------------------------------------
                new SqlParameter("@iInformationIntegrity",SqlDbType.Int), //��Ϣ������

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

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            //������

            parameters[39].Value = projectInfoModel.SellStockShare;
            parameters[40].Value = projectInfoModel.ReturnModeID;
            parameters[41].Value = projectInfoModel.financingID;

            parameters[42].Value = shortInfoModel.ShortInfoControlID;
            parameters[43].Value = shortInfoModel.ShortTitle;
            parameters[44].Value = shortInfoModel.ShortContent;
            parameters[45].Value = shortInfoModel.Remark;

            parameters[46].Value = projectInfoModel.IsRec;
            parameters[47].Value = projectInfoModel.IsTop;
            parameters[48].Value = projectInfoModel.RecTime;
            parameters[49].Value = projectInfoModel.RecRemark;
            parameters[50].Value = projectInfoModel.RecTerm;
            parameters[51].Value = "project_gq1";


            //-------------------201006��Դ���еڶ��θİ棬�����ӵ��ֶ�
            parameters[52].Value = projectInfoModel.sXmlxqk;  //��Ŀ�������
            parameters[53].Value = projectInfoModel.sXmgjz;     //��Ŀ�ؼ���
            parameters[54].Value = projectInfoModel.sQyfzjd;//��ҵ��չ�׶�
            parameters[55].Value = projectInfoModel.iYqzjdwqk;//Ҫ���ʽ�λ���
            parameters[56].Value = projectInfoModel.iSczylfy;//�г�ռ����(�ݶ�)
            parameters[57].Value = projectInfoModel.iHysczzl;//��ҵ�г�������
            parameters[58].Value = projectInfoModel.iZcfzl;//�ʲ���ծ��
            parameters[59].Value = projectInfoModel.iXmtzfbzq;//��ĿͶ�ʻر�����
            parameters[60].Value = projectInfoModel.nDwlyysy;//��λ��Ӫҵ����
            parameters[61].Value = projectInfoModel.nDwljly;//��λ�꾻����
            parameters[62].Value = projectInfoModel.nDwzzc;//��λ���ʲ�
            parameters[63].Value = projectInfoModel.nDwzfz;//��λ�ܸ�ծ
            parameters[64].Value = projectInfoModel.sXmqxms;//��Ŀ��ϸ����
            //-------------------END---------------------------------------


            //-------------����ǰ�ĵڶ��������ݣ���Ϊ��һ����----------
            parameters[65].Value = projectInfoModel.ProjectAbout;
            parameters[66].Value = projectInfoModel.marketAbout;
            parameters[67].Value = projectInfoModel.competitioAbout;
            parameters[68].Value = projectInfoModel.BussinessModeAbout;
            parameters[69].Value = projectInfoModel.ManageTeamAbout;
            //----------------END--------------------------------------
            parameters[70].Value = projectInfoModel.InformationIntegrity; //��Ϣ������


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_gq_Insert", parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoID < 0)
                        throw new Exception();


                    //���ϴ��ļ�
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //��¼�ϴ���
                        //ΪͶ����Ϣ��Ӷ����Դ
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        foreach (Tz888.Model.Info.InfoResourceModel model in infoResourceModels)
                        {
                            model.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, model, 1))
                                iUploadCount += 1;
                        }
                        //û�гɹ�
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            return 0;
                        }
                    }


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



        #region ��Ȩ ���� �ڶ���
        public bool PublishProjectGQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel)
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
                    new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                    new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
					new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
					new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
					new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
				    new SqlParameter("@flag", SqlDbType.VarChar,30),
            };
            parameters[0].Value = projectInfoModel.InfoID;
            parameters[1].Value = projectInfoModel.ProjectAbout;
            parameters[2].Value = projectInfoModel.marketAbout;
            parameters[3].Value = projectInfoModel.competitioAbout;
            parameters[4].Value = projectInfoModel.BussinessModeAbout;
            parameters[5].Value = projectInfoModel.ManageTeamAbout;
            parameters[6].Value = "project_gq2";

            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    int rowsAffected = 0;
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_gq_Insert", parameters, out rowsAffected);

                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return true;
        }
        #endregion

        #region ��Ȩ�޸�
        public bool ProjectInfoGQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                                    //������Ϣ
					                new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					                new SqlParameter("@Title", SqlDbType.VarChar,100),
					                new SqlParameter("@publishT", SqlDbType.DateTime),
                                    new SqlParameter("@LoginName",SqlDbType.Char,10),

					                new SqlParameter("@KeyWord", SqlDbType.VarChar,50),
					                new SqlParameter("@Descript", SqlDbType.VarChar,100),
					                new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					                new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					                new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					                new SqlParameter("@TemplateID", SqlDbType.Char,10),
					                new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),
                                    
                                    //��Ŀ��Ϣ
                                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					                new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					                new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					                new SqlParameter("@CountryCode", SqlDbType.Char,10),
					                new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					                new SqlParameter("@CityID", SqlDbType.Char,10),
					                new SqlParameter("@CountyID", SqlDbType.Char,10),
					                new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					                new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					                new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					                new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					                new SqlParameter("@CapitalID", SqlDbType.Float,8),
                                    
                                    //��ϵ��Ϣ
					                new SqlParameter("@ComName", SqlDbType.VarChar,100),
					                new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
                                    new SqlParameter("@Career", SqlDbType.VarChar,20),
					                new SqlParameter("@TelStateCode", SqlDbType.Char,8),
					                new SqlParameter("@TelNum", SqlDbType.VarChar,100),
                                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					                new SqlParameter("@Address", SqlDbType.VarChar,100),
					                new SqlParameter("@PostCode", SqlDbType.VarChar,10),
					                new SqlParameter("@Email", SqlDbType.VarChar,50),
                                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                                    
                                    //����Ϣ��
                                    new SqlParameter("@ShortInfoControlID", SqlDbType.Char,20),
					                new SqlParameter("@ShortTitle", SqlDbType.VarChar,100),
					                new SqlParameter("@ShortContent", SqlDbType.VarChar,100),
					                new SqlParameter("@strRemark", SqlDbType.VarChar,50),

                                //-------------------------������Ŀ��Ϣ--------------------------
                	                new SqlParameter("@IsRec", SqlDbType.Bit,1),
					                new SqlParameter("@IsTop", SqlDbType.Bit,1),
					                new SqlParameter("@RecTime", SqlDbType.DateTime),
					                new SqlParameter("@RecRemark", SqlDbType.VarChar,300),
					                new SqlParameter("@RecTerm", SqlDbType.Int,4),
                                //---------------------------������---------------------------
                                    new SqlParameter("@ProjectAbout", SqlDbType.VarChar,500),
                                    new SqlParameter("@marketAbout", SqlDbType.VarChar,500),
					                new SqlParameter("@competitioAbout", SqlDbType.VarChar,500),
					                new SqlParameter("@BussinessModeAbout", SqlDbType.VarChar,500),
					                new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),
                                    new SqlParameter("@financingID", SqlDbType.VarChar,20),
                                    new SqlParameter("@SellStockShare",SqlDbType.TinyInt),
                                    new SqlParameter("@ReturnModeID",SqlDbType.VarChar,50),
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
                                   //201006��Դ���еڶ��θİ棬�����ֶ�
                                new SqlParameter("@cZqXmlxqkb",SqlDbType.VarChar,20),//--	��Ŀ�������
                                new SqlParameter("@cZqQyfzjd",SqlDbType.VarChar,20), //--��ҵ��չ�׶�
                                new SqlParameter("@iZqYqjjdwqk",SqlDbType.Int,4),  //--Ҫ���ʽ�λ���
                                new SqlParameter("@iZqCpsczzl",SqlDbType.Int,4),   //--��Ʒ�г�������
                                new SqlParameter("@iZqCpscYl",SqlDbType.Int,4),    //--��Ʒ�г�����
                                new SqlParameter("@iZqZcfzl",SqlDbType.Int,4),     //--�ʲ���ծ��
                                new SqlParameter("@iZqYdbl",SqlDbType.Int,4),      //--��������
                                new SqlParameter("@iZqTzsl",SqlDbType.Int,4),     //--Ͷ��������
                                new SqlParameter("@iZqXslyl",SqlDbType.Int,4),     //--����������
                                new SqlParameter("@iZqTzfbq",SqlDbType.Int,4),     //--Ͷ�ʻر���
                                new SqlParameter("@iZqXmyxqs",SqlDbType.Int,4),    //--��Ŀ��Ч����
                                new SqlParameter("@cZqXmzy",SqlDbType.NVarChar,400),//--��ĿժҪ
                                new SqlParameter("@cZqXmgjz",SqlDbType.NVarChar,50),//--��Ŀ�ؼ���
                                new SqlParameter("@cZqCpks",SqlDbType.NVarChar,400),//--��Ʒ����-----------
                                new SqlParameter("@cZqJzfx",SqlDbType.NVarChar,400),//--��������
                                new SqlParameter("@cZqSyms",SqlDbType.NVarChar,400),//--��ҵģʽ
                                new SqlParameter("@cZqGltd",SqlDbType.NVarChar,400),//--�����Ŷ�
                                //-------END---------------------------
                                new SqlParameter("@iInformationIntegrity",SqlDbType.Int,4), //--��Ϣ������   
                                //�޸�����
                                new SqlParameter("@CompanyYearIncome",  model.ProjectInfoModel.CompanyYearIncome),
					            new SqlParameter("@CompanyNG", model.ProjectInfoModel.CompanyNG),
					            new SqlParameter("@CompanyTotalCapital",model.ProjectInfoModel.CompanyTotalCapital),
					            new SqlParameter("@CompanyTotalDebet",  model.ProjectInfoModel.CompanyTotalDebet),
                                //��Ȩ
                                new SqlParameter("@iSczylfy",model.ProjectInfoModel.iSczylfy),   //--�г�ռ����(�ݶ�)
                                new SqlParameter("@iHysczzl",model.ProjectInfoModel.iHysczzl),  //��ҵ�г�������
                                new SqlParameter("@iZcfzl",model.ProjectInfoModel.iZcfzl)   //�ʲ���ծ��
            };
            parameters[0].Value = model.MainInfoModel.InfoID;
            parameters[1].Value = model.MainInfoModel.Title;
            parameters[2].Value = model.MainInfoModel.publishT;
            parameters[3].Value = model.MainInfoModel.LoginName;

            parameters[4].Value = model.MainInfoModel.KeyWord;
            parameters[5].Value = model.MainInfoModel.Descript;
            parameters[6].Value = model.MainInfoModel.DisplayTitle;
            parameters[7].Value = model.MainInfoModel.FrontDisplayTime;
            parameters[8].Value = model.MainInfoModel.ValidateStartTime;
            parameters[9].Value = model.MainInfoModel.ValidateTerm;
            parameters[10].Value = model.MainInfoModel.TemplateID;
            parameters[11].Value = model.MainInfoModel.HtmlFile;

            parameters[12].Value = model.ProjectInfoModel.ProjectName;
            parameters[13].Value = model.ProjectInfoModel.ProjectNameBrief;
            parameters[14].Value = model.ProjectInfoModel.ComAbout;
            parameters[15].Value = model.ProjectInfoModel.ComBrief;
            parameters[16].Value = model.ProjectInfoModel.CountryCode;
            parameters[17].Value = model.ProjectInfoModel.ProvinceID;
            parameters[18].Value = model.ProjectInfoModel.CityID;
            parameters[19].Value = model.ProjectInfoModel.CountyID;
            parameters[20].Value = model.ProjectInfoModel.IndustryBID;
            parameters[21].Value = model.ProjectInfoModel.CooperationDemandType;
            parameters[22].Value = model.ProjectInfoModel.CapitalCurrency;
            parameters[23].Value = model.ProjectInfoModel.CapitalTotal;
            parameters[24].Value = model.ProjectInfoModel.ProjectCurrency;
            parameters[25].Value = model.ProjectInfoModel.CapitalID;

            parameters[26].Value = model.InfoContactModel.OrganizationName;
            parameters[27].Value = model.InfoContactModel.Name;
            parameters[28].Value = model.InfoContactModel.Career;
            parameters[29].Value = model.InfoContactModel.TelStateCode;
            parameters[30].Value = model.InfoContactModel.TelNum;
            parameters[31].Value = model.InfoContactModel.Mobile;
            parameters[32].Value = model.InfoContactModel.Address;
            parameters[33].Value = model.InfoContactModel.PostCode;
            parameters[34].Value = model.InfoContactModel.Email;
            parameters[35].Value = model.InfoContactModel.WebSite;

            parameters[36].Value = model.ShortInfoModel.ShortInfoControlID;
            parameters[37].Value = model.ShortInfoModel.ShortTitle;
            parameters[38].Value = model.ShortInfoModel.ShortContent;
            parameters[39].Value = model.ShortInfoModel.Remark;

            parameters[40].Value = model.ProjectInfoModel.IsRec;
            parameters[41].Value = model.ProjectInfoModel.IsTop;
            parameters[42].Value = model.ProjectInfoModel.RecTime;
            parameters[43].Value = model.ProjectInfoModel.RecRemark;
            parameters[44].Value = model.ProjectInfoModel.RecTerm;

            parameters[45].Value = model.ProjectInfoModel.ProjectAbout;
            parameters[46].Value = model.ProjectInfoModel.marketAbout;
            parameters[47].Value = model.ProjectInfoModel.competitioAbout;
            parameters[48].Value = model.ProjectInfoModel.BussinessModeAbout;
            parameters[49].Value = model.ProjectInfoModel.ManageTeamAbout;
            parameters[50].Value = model.ProjectInfoModel.financingID;
            parameters[51].Value = model.ProjectInfoModel.SellStockShare;
            parameters[52].Value = model.ProjectInfoModel.ReturnModeID;
            parameters[53].Value = "UpdateGQ";

            //201006��Դ���еڶ��θİ棬�����ֶ�
            parameters[54].Value = model.ProjectInfoModel.cZqXmlxqkb;   //--	��Ŀ�������
            parameters[55].Value = model.ProjectInfoModel.cZqQyfzjd;    //--��ҵ��չ�׶�
            parameters[56].Value = model.ProjectInfoModel.iZqYqjjdwqk;    //--Ҫ���ʽ�λ���
            parameters[57].Value = model.ProjectInfoModel.iZqCpsczzl;    //--��Ʒ�г�������
            parameters[58].Value = model.ProjectInfoModel.iZqCpscYl;    //--��Ʒ�г�����
            parameters[59].Value = model.ProjectInfoModel.iZqZcfzl;    //--�ʲ���ծ��
            parameters[60].Value = model.ProjectInfoModel.iZqYdbl;    //--��������
            parameters[61].Value = model.ProjectInfoModel.iZqTzsl;    //--Ͷ��������
            parameters[62].Value = model.ProjectInfoModel.iZqXslyl;    //--����������
            parameters[63].Value = model.ProjectInfoModel.iXmtzfbzq;    //--Ͷ�ʻر���
            parameters[64].Value = model.ProjectInfoModel.iZqXmyxqs;    //--��Ŀ��Ч����
            parameters[65].Value = model.ProjectInfoModel.cZqXmzy;    //--��ĿժҪ
            parameters[66].Value = model.ProjectInfoModel.cZqXmgjz;    //--��Ŀ�ؼ���
            parameters[67].Value = model.ProjectInfoModel.ProjectAbout;    //--��Ʒ����

            parameters[68].Value = model.ProjectInfoModel.competitioAbout;    //--��������
            parameters[69].Value = model.ProjectInfoModel.BussinessModeAbout;    //--��ҵģʽ
            parameters[70].Value = model.ProjectInfoModel.ManageTeamAbout;    //--�����Ŷ�
            parameters[71].Value = model.ProjectInfoModel.InformationIntegrity;    //--��Ϣ������
            //-------END---------------------------

            bool ReturnValue = false;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    int rowsAffected;
                    //�޸���Ŀ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Project_Update", parameters, out rowsAffected);

                    //���ϴ��ļ�
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //��¼�ϴ���
                        //ΪͶ����Ϣ��Ӷ����Դ
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        //ɾ��ԭ����Դ
                        obj3.DeleteByInfoID(sqlConn, sqlTran, model.MainInfoModel.InfoID);
                        foreach (Tz888.Model.Info.InfoResourceModel Infomodel in infoResourceModels)
                        {
                            Infomodel.InfoID = model.MainInfoModel.InfoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, Infomodel, 1))
                                iUploadCount += 1;
                        }
                        //û�гɹ�
                        if (iUploadCount != infoResourceModels.Count)
                        {
                            ReturnValue = false;
                        }
                    }
                    sqlTran.Commit();
                    sqlConn.Close();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }
        #endregion

        public int FormatData(string strData)
        {
            int iData = 0;
            if (strData.Trim() == "")
                iData = 0;
            try
            {
                iData = Convert.ToInt32(strData);
            }
            catch
            {
                iData = 0;
            }
            return iData;
        }

        /// <summary>
        /// �ж��Ƿ�������
        /// </summary>
        /// <param name="str">����ֵ</param>
        /// <returns>����true ��false</returns>
        public static bool IsNumber(string str)
        {
            try
            {
                decimal rest = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;

            }
        }

        /// <summary>
        /// ˵�����ж��Ƿ�������
        /// </summary>
        /// <param name="str">����ֵ</param>
        /// <returns>����true ��false</returns>
        public static bool IsDecimal(string str)
        {
            try
            {
                decimal rest = Convert.ToDecimal(str);
                return true;
            }
            catch
            {
                return false;

            }
        }



        #region IProjectInfo ��Ա
        /// <summary>
        /// ������ӹ�Ȩ����
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <returns></returns>
        public long InsertNew(MainInfoModel mainInfoModel, ProjectInfoModel projectInfoModel, InfoContactModel infoContactModel, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            SqlParameter[] parameters = {
                //---------------------��Դ��Ϣ����----------------------
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
					new SqlParameter("@Descript", SqlDbType.VarChar,100),
					new SqlParameter("@DisplayTitle", SqlDbType.VarChar,50),
					new SqlParameter("@FrontDisplayTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateStartTime", SqlDbType.SmallDateTime),
					new SqlParameter("@ValidateTerm", SqlDbType.Int,4),
					new SqlParameter("@TemplateID", SqlDbType.Char,10),
                    new SqlParameter("@HtmlFile", SqlDbType.VarChar,100),

                //---------------------------END---------------------------

                //-----------------------����(��Ŀ)��Դ������Ϣ-----------------

                    new SqlParameter("@ProjectName", SqlDbType.VarChar,100),
					new SqlParameter("@ProjectNameBrief", SqlDbType.VarChar,100),
					new SqlParameter("@ComAbout", SqlDbType.VarChar,-1),
                    new SqlParameter("@ComBrief", SqlDbType.VarChar,-1),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10),
					new SqlParameter("@IndustryBID", SqlDbType.Char,10),
					new SqlParameter("@CooperationDemandType", SqlDbType.Char,10),
					new SqlParameter("@CapitalCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalTotal", SqlDbType.Float,8),
					new SqlParameter("@ProjectCurrency", SqlDbType.Char,10),
					new SqlParameter("@CapitalID", SqlDbType.Float,8),

                //---------------------------END---------------------------


                //-----------------------��Դ��ϵ��Ϣ--------------------------

					new SqlParameter("@ComName", SqlDbType.VarChar,40),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,20),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
					new SqlParameter("@TelStateCode", SqlDbType.Char,4),
					new SqlParameter("@TelNum", SqlDbType.VarChar,60),
					new SqlParameter("@FaxCountryCode", SqlDbType.Char,3),
					new SqlParameter("@FaxStateCode", SqlDbType.Char,4),
					new SqlParameter("@FaxNum", SqlDbType.VarChar,60),

					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@PostCode", SqlDbType.VarChar,10),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@WebSite", SqlDbType.VarChar,200),
                    new SqlParameter("@ManageTeamAbout", SqlDbType.VarChar,500),


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

            parameters[25].Value = projectInfoModel.ProjectName;
            parameters[26].Value = projectInfoModel.ProjectNameBrief;
            parameters[27].Value = projectInfoModel.ComAbout;
            parameters[28].Value = projectInfoModel.ComBrief;
            parameters[29].Value = projectInfoModel.CountryCode;
            parameters[30].Value = projectInfoModel.ProvinceID;
            parameters[31].Value = projectInfoModel.CityID;
            parameters[32].Value = projectInfoModel.CountyID;
            parameters[33].Value = projectInfoModel.IndustryBID;
            parameters[34].Value = projectInfoModel.CooperationDemandType;
            parameters[35].Value = projectInfoModel.CapitalCurrency;
            parameters[36].Value = projectInfoModel.CapitalTotal;
            parameters[37].Value = projectInfoModel.ProjectCurrency;
            parameters[38].Value = projectInfoModel.CapitalID;

            parameters[39].Value = infoContactModel.OrganizationName;
            parameters[40].Value = infoContactModel.Name;
            parameters[41].Value = infoContactModel.TelCountryCode;
            parameters[42].Value = infoContactModel.TelStateCode;
            parameters[43].Value = infoContactModel.TelNum;
            parameters[44].Value = infoContactModel.FaxCountryCode;
            parameters[45].Value = infoContactModel.FaxStateCode;
            parameters[46].Value = infoContactModel.FaxNum;
            parameters[47].Value = infoContactModel.Mobile;
            parameters[48].Value = infoContactModel.Address;
            parameters[49].Value = infoContactModel.PostCode;
            parameters[50].Value = infoContactModel.Email;
            parameters[51].Value = infoContactModel.WebSite;
            parameters[52].Value = projectInfoModel.ManageTeamAbout;


            int rowsAffected;
            long infoID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    //��������(��Ŀ)��Դ��Ϣ
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_InfoResource_InsertNew, parameters, out rowsAffected);
                     //���ϴ��ļ�
                
                    //DbHelperSQL.RunProcedure(SP_ProjectInfo_Insert, parameters, out rowsAffected);
                    infoID = (long)parameters[0].Value;
                    if (infoResourceModels != null)
                    {
                        int iUploadCount = 0; //��¼�ϴ���
                        //ΪͶ����Ϣ��Ӷ����Դ
                        Tz888.SQLServerDAL.Info.InfoResourceDAL obj3 = new InfoResourceDAL();
                        //ɾ��ԭ����Դ
                        obj3.DeleteByInfoID(sqlConn, sqlTran, infoID);
                        foreach (Tz888.Model.Info.InfoResourceModel Infomodel in infoResourceModels)
                        {
                            Infomodel.InfoID = infoID;
                            if (obj3.InsertInfoResource(sqlConn, sqlTran, Infomodel, 1))
                                iUploadCount += 1;
                        }
                    }
                    if (infoID < 0)
                        return -1;
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
    }
}
