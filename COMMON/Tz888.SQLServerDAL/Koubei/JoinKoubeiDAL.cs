using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.Koubei;
using Tz888.IDAL.Koubei;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Koubei
{
    public class JoinKoubeiDAL:IJoinkoubei
    {
        public string endDays = System.Configuration.ConfigurationManager.AppSettings["koubeiDays"].ToString();

        #region --添加信息--
        public string insertData(JoinKoubeiModel model)
        {
            SqlParameter[] paramInsert = new SqlParameter[] {
                new SqlParameter("@Join_ID",model.Join_ID),
                new SqlParameter("@Join_InfoType",model.Join_InfoType),
                new SqlParameter("@Join_InfoID",model.Join_InfoID),
                new SqlParameter("@Join_URL",model.Join_URL),
                new SqlParameter("@Join_Type",model.Join_Type),
                new SqlParameter("@Join_AreaCode",model.Join_AreaCode),
                new SqlParameter("@Join_StartTime",model.Join_StartTime),
                new SqlParameter("@Join_EndTime",model.Join_EndTime),
                new SqlParameter("@Join_LinkMan",model.Join_LinkMan),
                new SqlParameter("@Join_Tel",model.Join_Tel),
                new SqlParameter("@Join_Tel2",model.Join_Tel2),
                new SqlParameter("@Join_Email",model.Join_Email),
                new SqlParameter("@Join_State",model.Join_State),
                new SqlParameter("@flag","Insert")
            };
            DataSet ds1 = DbHelperSQL.RunProcedure("Proc_JoinkoubeiTab", paramInsert, "join");
            string join_ID = ds1.Tables["join"].Rows[0][0].ToString();
            ds1.Clear();
            return join_ID;
        }
        #endregion

        #region --修改信息--
        public void updateData(JoinKoubeiModel model)
        {
            SqlParameter[] paramUpdate = new SqlParameter[] {
                new SqlParameter("@Join_ID",model.Join_ID),
                new SqlParameter("@Join_InfoType",model.Join_InfoType),
                new SqlParameter("@Join_InfoID",model.Join_InfoID),
                new SqlParameter("@Join_URL",model.Join_URL),
                new SqlParameter("@Join_Type",model.Join_Type),
                new SqlParameter("@Join_AreaCode",model.Join_AreaCode),
                new SqlParameter("@Join_StartTime",model.Join_StartTime),
                new SqlParameter("@Join_EndTime",model.Join_EndTime),
                new SqlParameter("@Join_LinkMan",model.Join_LinkMan),
                new SqlParameter("@Join_Tel",model.Join_Tel),
                new SqlParameter("@Join_Tel2",model.Join_Tel2),
                new SqlParameter("@Join_Email",model.Join_Email),
                new SqlParameter("@Join_State",model.Join_State),
                new SqlParameter("@flag","Update")
            };
            Tz888.DBUtility.DbHelperSQL.RunProcedure("Proc_JoinkoubeiTab", paramUpdate, "join");
        }
        #endregion

        #region --删除信息--
        public bool deleteData(int JoinID)
        {
            bool flag = false;
            string sqlStr = "delete JoinkoubeiTab where Join_ID=" + JoinID.ToString();
            int count = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            if (count >= 0)
            {
                flag = true;
            }
            return flag;
        
        }
        #endregion

        #region --查询一条信息--
        public JoinKoubeiModel selectOne(JoinKoubeiModel model)
        {
            SqlParameter[] paramselectOne = new SqlParameter[] {
                new SqlParameter("@Join_ID",model.Join_ID),
                new SqlParameter("@Join_InfoType",""),
                new SqlParameter("@Join_InfoID",Convert.ToInt64("0")),
                new SqlParameter("@Join_URL",""),
                new SqlParameter("@Join_Type",Convert.ToInt32("0")),
                new SqlParameter("@Join_AreaCode",Convert.ToInt32("0")),
                new SqlParameter("@Join_StartTime",Convert.ToDateTime(DateTime.Now)),
                new SqlParameter("@Join_EndTime",Convert.ToDateTime(DateTime.Now)),
                new SqlParameter("@Join_LinkMan",""),
                new SqlParameter("@Join_Tel",""),
                new SqlParameter("@Join_Tel2",""),
                new SqlParameter("@Join_Email",""),
                new SqlParameter("@Join_State",Convert.ToInt32("0")),
                new SqlParameter("@flag","SelectOne")
            };
            DataSet ds_join = DbHelperSQL.RunProcedure("Proc_JoinkoubeiTab", paramselectOne, "join");
            if (ds_join != null && ds_join.Tables[0] != null && ds_join.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds_join.Tables[0].Rows[0];
                model.Join_ID = model.Join_ID;
                model.Join_StartTime = Convert.ToDateTime(dr["Join_StartTime"].ToString().Trim());
                model.Join_EndTime = Convert.ToDateTime(dr["Join_EndTime"].ToString().Trim());
                model.Join_LinkMan = dr["Join_LinkMan"].ToString().Trim();
                model.Join_Tel = dr["Join_Tel"].ToString().Trim();
                model.Join_Tel2 = dr["Join_Tel2"].ToString().Trim();
                model.Join_Email = dr["Join_Email"].ToString().Trim();
                model.Join_AreaCode = Convert.ToInt32(dr["Join_AreaCode"].ToString().Trim());
                model.Join_URL = dr["Join_URL"].ToString();
                model.Join_Type = Convert.ToInt32(dr["Join_Type"].ToString().Trim());
                model.Join_State = Convert.ToInt32(dr["Join_State"].ToString());

                model.Join_InfoType = dr["Join_InfoType"].ToString().Trim();
                model.Join_InfoID = Convert.ToInt32(dr["Join_InfoID"].ToString().Trim());
            }
            ds_join.Clear();
            return model;
        }
        #endregion

        #region --查询一条信息--
        public JoinKoubeiModel selectOneById(long JoinID)
        {
            JoinKoubeiModel model = new JoinKoubeiModel();
            string sqlStr = "select * from JoinkoubeiTab where Join_ID=" + JoinID.ToString();
            DataSet ds_join = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds_join != null && ds_join.Tables[0] != null && ds_join.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds_join.Tables[0].Rows[0];
                model.Join_ID = JoinID;
                model.Join_StartTime = Convert.ToDateTime(dr["Join_StartTime"].ToString().Trim());
                model.Join_EndTime = Convert.ToDateTime(dr["Join_EndTime"].ToString().Trim());
                model.Join_LinkMan = dr["Join_LinkMan"].ToString().Trim();
                model.Join_Tel = dr["Join_Tel"].ToString().Trim();
                model.Join_Tel2 = dr["Join_Tel2"].ToString().Trim();
                model.Join_Email = dr["Join_Email"].ToString().Trim();
                model.Join_AreaCode = Convert.ToInt32(dr["Join_AreaCode"].ToString().Trim());
                model.Join_URL = dr["Join_URL"].ToString();
                model.Join_Type = Convert.ToInt32(dr["Join_Type"].ToString().Trim());
                model.Join_State = Convert.ToInt32(dr["Join_State"].ToString());

                model.Join_InfoType = dr["Join_InfoType"].ToString().Trim();
                model.Join_InfoID = Convert.ToInt32(dr["Join_InfoID"].ToString().Trim());
            }
            ds_join.Clear();
            return model;
        }
        #endregion

        #region --检查此信息是否有被推广--
        public bool checkKoubeiByInfoID(string InfoType, long InfoID)
        {
            bool flag = false;
            string TypeStr = "Oppor,CarveOut,Merchant,Project,Capital";//"15,7,13,19,6";
            if (TypeStr.IndexOf(InfoType.ToString()) != -1)
            {
                string sqlStr = "select * from JoinkoubeiTab where Join_InfoType='" + InfoType + "' and Join_InfoID=" + InfoID;
                SqlDataReader sr = Tz888.DBUtility.DbHelperSQL.ExecuteReader(sqlStr);
                if (sr.Read())
                {
                    flag = true;
                }
            }
            return flag;
        }
        #endregion

        #region --修改状态--
        public bool updateStateById(long JoinID, int state)
        {
            //state说明：默认为0 添加成功则为1
            bool flag = false;
            string sqlStr = "update JoinkoubeiTab set Join_State=" + state + " where Join_ID=" + JoinID.ToString();
            int count = Tz888.DBUtility.DbHelperSQL.ExecuteSql(sqlStr);
            if (count >= 0)
            {
                flag = true;
            }
            return flag;
        }
        #endregion

        #region getInfoFromMainInfo
        public JoinKoubeiModel getInfoFromMainInfo(string InfoType, long InfoID, string AreaAll)
        {
            JoinKoubeiModel model = new JoinKoubeiModel();
            //商机15，创业7，招商13，项目19，投资6
            //信息类别，信息表类型，获取信息From，获取信息Field，
            //string[] tableInfo = new string[] { 
            //    "Oppor;OpportunityInfoTab;MainInfoTab left join OpportunityInfoTab on MainInfoTab.ID=OpportunityInfoTab.InfoID left join SetCountyTab on OpportunityInfoTab.CountyID=SetCountyTab.CountyID;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,Content,ComName,LinkMan,Tel,Mobile,Email",
            //    "CarveOut;CarveOutInfoTab;MainInfoTab left join CarveOutInfoTab on MainInfoTab.ID=CarveOutInfoTab.InfoID left join SetCountyTab on CarveOutInfoTab.CountyID=SetCountyTab.CountyID;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,Content,ComName,LinkMan,Tel,Mobile,Email",
            //    "Merchant;MerchantInfoTab;MainInfoTab left join MerchantInfoTab on MainInfoTab.ID=MerchantInfoTab.InfoID left join InfoContactTab on MerchantInfoTab.InfoID=InfoContactTab.InfoID left join SetCountyTab on MerchantInfoTab.CountyID=SetCountyTab.CountyID;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ZoneAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email",
            //    "Project;ProjectInfoTab;MainInfoTab left join ProjectInfoTab on MainInfoTab.ID=ProjectInfoTab.InfoID left join InfoContactTab on ProjectInfoTab.InfoID=InfoContactTab.InfoID left join SetCountyTab on ProjectInfoTab.CountyID=SetCountyTab.CountyID;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ComAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email",
            //    "Capital;CapitalInfoTab;MainInfoTab left join CapitalInfoTab on MainInfoTab.ID=CapitalInfoTab.InfoID left join InfoContactTab on CapitalInfoTab.InfoID=InfoContactTab.InfoID left join CapitalInfoAreaTab on CapitalInfoTab.InfoID=CapitalInfoAreaTab.InfoID left join SetCountyTab on CapitalInfoAreaTab.CountyID=SetCountyTab.CountyID;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ComAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email"
            //};            
            string[] tableInfo = new string[] { 
                "15;OpportunityInfoTab;MainInfoTab left join OpportunityInfoTab on MainInfoTab.ID=OpportunityInfoTab.InfoID left join SetCountyTab on OpportunityInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on OpportunityInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=OpportunityInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,Content,ComName,LinkMan,Tel,Mobile,Email,ProvinceName,CountryName",
                "7;CarveOutInfoTab;MainInfoTab left join CarveOutInfoTab on MainInfoTab.ID=CarveOutInfoTab.InfoID left join SetCountyTab on CarveOutInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on CarveOutInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=CarveOutInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,Content,ComName,LinkMan,Tel,Mobile,Email,ProvinceName,CountryName",
                "13;MerchantInfoTab;MainInfoTab left join MerchantInfoTab on MainInfoTab.ID=MerchantInfoTab.InfoID left join InfoContactTab on MerchantInfoTab.InfoID=InfoContactTab.InfoID left join SetCountyTab on MerchantInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on MerchantInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=MerchantInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ZoneAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email,ProvinceName,CountryName",
                "19;ProjectInfoTab;MainInfoTab left join ProjectInfoTab on MainInfoTab.ID=ProjectInfoTab.InfoID left join InfoContactTab on ProjectInfoTab.InfoID=InfoContactTab.InfoID left join SetCountyTab on ProjectInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on ProjectInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=ProjectInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ComAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email,ProvinceName,CountryName",
                "6;CapitalInfoTab;MainInfoTab left join CapitalInfoTab on MainInfoTab.ID=CapitalInfoTab.InfoID left join InfoContactTab on CapitalInfoTab.InfoID=InfoContactTab.InfoID left join CapitalInfoAreaTab on CapitalInfoTab.InfoID=CapitalInfoAreaTab.InfoID left join SetCountyTab on CapitalInfoAreaTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on CapitalInfoAreaTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=CapitalInfoAreaTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ComAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email,ProvinceName,CountryName"
            };
            int type = 0;
            switch (InfoType.ToString())
            {
                case "Oppor": type = 1; break;
                case "CarveOut": type = 2; break;
                case "Merchant": type = 3; break;
                case "Project": type = 4; break;
                case "Capital": type = 5; break;
                default: type = 0; break;
            }
            if (type == 0)
                return model;
            string selectField = tableInfo[(type - 1)].Split(';')[3];
            string selectTables = tableInfo[(type - 1)].Split(';')[2];
            string selectTable = tableInfo[(type - 1)].Split(';')[1];
            string sqlStr = "select " + selectField + " from " + selectTables + " where " + selectTable + ".InfoID=" + InfoID.ToString();
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                model.Join_Content = dr["Content"].ToString().Trim();           //内容
                model.Join_StartTime = Convert.ToDateTime(dr["ValidateStartTime"].ToString().Trim());
                //model.Join_EndTime = model.Join_StartTime.AddDays(25);
                DateTime endTimeTemp = new DateTime();
                switch (dr["ValidateTerm"].ToString().Trim())
                {
                    case "3": endTimeTemp = model.Join_StartTime.AddDays(90); break;
                    case "6": endTimeTemp = model.Join_StartTime.AddDays(180); break;
                    case "12": endTimeTemp = model.Join_StartTime.AddDays(360); break;
                }
                double days=0;
                try
                {
                    days = Convert.ToDouble(endDays);
                }
                catch
                {
                    days = 7;
                }
                if (endTimeTemp >= System.DateTime.Now.AddDays(days) || endTimeTemp <= System.DateTime.Now)
                    model.Join_EndTime = System.DateTime.Now.AddDays(days);
                else
                    model.Join_EndTime = endTimeTemp;

                model.Join_LinkMan = dr["LinkMan"].ToString().Trim();
                model.Join_Tel = dr["Tel"].ToString().Trim();
                model.Join_Tel2 = dr["Mobile"].ToString().Trim();
                model.Join_Email = dr["Email"].ToString().Trim();
                model.Join_Title = dr["Title"].ToString().Trim();
                model.Join_CountyName = dr["CountyName"].ToString().Trim();
                //int areaIndex = AreaAll.IndexOf("," + dr["CountyName"].ToString().Trim() + ",");
                //if (areaIndex != -1)
                //    model.Join_AreaCode = AreaAll.Substring(0, areaIndex).Split(',').Length + 2;
                //else
                //    model.Join_AreaCode = 0;

                //ProvinceName,CountryName
                int areaIndex = AreaAll.IndexOf("," + dr["CountyName"].ToString().Trim() + ",");    //县级区域
                if (areaIndex == -1)
                {
                    areaIndex = AreaAll.IndexOf("," + dr["ProvinceName"].ToString().Trim() + ",");  //省级
                    if (areaIndex == -1)
                    {
                        areaIndex = AreaAll.IndexOf("," + dr["CountryName"].ToString().Trim() + ",");//国家
                        if (areaIndex == -1)
                        {
                            string CountryNameTemp = dr["CountryName"].ToString().Trim().Replace("中国", "");//如果是中国国香港 或者台湾的时候
                            //CountryName
                            areaIndex = AreaAll.IndexOf("," + CountryNameTemp.Trim() + ",");
                        }
                    }
                }
                if (areaIndex != -1)
                    model.Join_AreaCode = AreaAll.Substring(0, areaIndex).Split(',').Length + 2;
                else
                    model.Join_AreaCode = 0;

                model.Join_URL = dr["HtmlFile"].ToString();
            }
            ds.Clear();
            return model;
        }
        #endregion

        #region 获取标题与内容
        public string[] getTitleAndContent(string InfoType, long InfoID)
        {
            string[] InfoStr = new string[] {"","" };
            //商机15，创业7，招商13，项目19，投资6
            //信息类别，信息表类型，获取信息From，获取信息Field，
            string[] tableInfo = new string[] { 
                "15;OpportunityInfoTab;MainInfoTab left join OpportunityInfoTab on MainInfoTab.ID=OpportunityInfoTab.InfoID left join SetCountyTab on OpportunityInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on OpportunityInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=OpportunityInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,Content,ComName,LinkMan,Tel,Mobile,Email,ProvinceName,CountryName",
                "7;CarveOutInfoTab;MainInfoTab left join CarveOutInfoTab on MainInfoTab.ID=CarveOutInfoTab.InfoID left join SetCountyTab on CarveOutInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on CarveOutInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=CarveOutInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,Content,ComName,LinkMan,Tel,Mobile,Email,ProvinceName,CountryName",
                "13;MerchantInfoTab;MainInfoTab left join MerchantInfoTab on MainInfoTab.ID=MerchantInfoTab.InfoID left join InfoContactTab on MerchantInfoTab.InfoID=InfoContactTab.InfoID left join SetCountyTab on MerchantInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on MerchantInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=MerchantInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ZoneAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email,ProvinceName,CountryName",
                "19;ProjectInfoTab;MainInfoTab left join ProjectInfoTab on MainInfoTab.ID=ProjectInfoTab.InfoID left join InfoContactTab on ProjectInfoTab.InfoID=InfoContactTab.InfoID left join SetCountyTab on ProjectInfoTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on ProjectInfoTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=ProjectInfoTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ComAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email,ProvinceName,CountryName",
                "6;CapitalInfoTab;MainInfoTab left join CapitalInfoTab on MainInfoTab.ID=CapitalInfoTab.InfoID left join InfoContactTab on CapitalInfoTab.InfoID=InfoContactTab.InfoID left join CapitalInfoAreaTab on CapitalInfoTab.InfoID=CapitalInfoAreaTab.InfoID left join SetCountyTab on CapitalInfoAreaTab.CountyID=SetCountyTab.CountyID left join SetProvinceTab on CapitalInfoAreaTab.ProvinceID=SetProvinceTab.ProvinceID left join SetCountryTab on SetCountryTab.CountryCode=CapitalInfoAreaTab.CountryCode;Title,publishT,InfoTypeID,ValidateStartTime,ValidateTerm,TemplateID,HtmlFile,CountyName,ComAbout as Content,OrganizationName as ComName,Name as LinkMan,Ltrim(Rtrim(TelStateCode))+'-'+Ltrim(Rtrim(TelNum)) as Tel,Mobile,Email,ProvinceName,CountryName"
            };
            int type = 0;
            switch (InfoType.ToString().Trim())
            {
                case "Oppor": type = 1; break;
                case "CarveOut": type = 2; break;
                case "Merchant": type = 3; break;
                case "Project": type = 4; break;
                case "Capital": type = 5; break;
                default: type = 0; break;
            }
            if (type == 0)
                return InfoStr;
            string selectField = tableInfo[(type - 1)].Split(';')[3];
            string selectTables = tableInfo[(type - 1)].Split(';')[2];
            string selectTable = tableInfo[(type - 1)].Split(';')[1];
            string sqlStr = "select " + selectField + " from " + selectTables + " where " + selectTable + ".InfoID=" + InfoID.ToString();
            DataSet ds = Tz888.DBUtility.DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                InfoStr[0] = dr["Title"].ToString().Trim();
                InfoStr[1] = dr["Content"].ToString().Trim();           //内容
            }
            ds.Clear();
            return InfoStr;
        }
        #endregion
    }
}
