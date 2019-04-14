using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Company;
using Tz888.Model.Company;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Company
{
    public class CompanyDAL:ICompanyInfoTab
    {
        #region ICompanyInfoTab ��Ա

        CrmDBHelper crm = new CrmDBHelper();
        #region
       
        /// <summary>
        /// ��ҵ��Ƭ���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Company_Add(CompanyModel model)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@RangeID", SqlDbType.Int,4),
					new SqlParameter("@RangeName", SqlDbType.VarChar,50),
					new SqlParameter("@NatureID", SqlDbType.Int,4),
					new SqlParameter("@NatureName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Integrity", SqlDbType.Int,4),
					new SqlParameter("@EstablishMent", SqlDbType.VarChar,50),
					new SqlParameter("@Employees", SqlDbType.BigInt,8),
					new SqlParameter("@Capital", SqlDbType.BigInt,8),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Logo", SqlDbType.VarChar,1000),
					new SqlParameter("@Introduction", SqlDbType.NVarChar,2000),
					new SqlParameter("@ServiceProce", SqlDbType.NVarChar,2000),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Keywords", SqlDbType.VarChar,100),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
                    new SqlParameter("@TelPhone",SqlDbType.VarChar,50),
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@AuditingStatus",SqlDbType.Int,4),
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),
                    new SqlParameter("@Ismake",SqlDbType.Int,4),
                    new SqlParameter("@IsDelete",SqlDbType.Int,4),
                    new SqlParameter("@Privice",SqlDbType.Int,4),
                    new SqlParameter("@City",SqlDbType.Int,4),
                    new SqlParameter("@FromId",SqlDbType.Int,4)
            };
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.CompanyName;
            parameters[2].Value = model.IndustryID;
            parameters[3].Value = model.IndustryName;
            parameters[4].Value = model.RangeID;
            parameters[5].Value = model.RangeName;
            parameters[6].Value = model.NatureID;
            parameters[7].Value = model.NatureName;
            parameters[8].Value = model.CreateDate;
            parameters[9].Value = model.Hit;
            parameters[10].Value = model.Integrity;
            parameters[11].Value = model.EstablishMent;
            parameters[12].Value = model.Employees;
            parameters[13].Value = model.Capital;
            parameters[14].Value = model.LinkName;
            parameters[15].Value = model.Email;
            parameters[16].Value = model.URL;
            parameters[17].Value = model.Address;
            parameters[18].Value = model.Logo;
            parameters[19].Value = model.Introduction;
            parameters[20].Value = model.ServiceProce;
            parameters[21].Value = model.Title;
            parameters[22].Value = model.Keywords;
            parameters[23].Value = model.Description;
            parameters[24].Value = model.Telphone;
            parameters[25].Value = model.Mobile;
            parameters[26].Value = model.Auditingstatus;
            parameters[27].Value = model.Htmlfile;
            parameters[28].Value = model.Ismake;
            parameters[29].Value = model.IsDelete;
            parameters[30].Value = model.Provice;
            parameters[31].Value = model.City;
            parameters[32].Value = 0;
            num=crm.RunProcedure("Pro_Company_Add", parameters, out rowsAffected);
            return num;
        }
        #endregion

        #region ��ҵ��Ƭ�޸�
        /// <summary>
        /// ��ҵ��Ƭ�޸�
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,200),
					new SqlParameter("@IndustryID", SqlDbType.Int,4),
					new SqlParameter("@IndustryName", SqlDbType.VarChar,50),
					new SqlParameter("@RangeID", SqlDbType.Int,4),
					new SqlParameter("@RangeName", SqlDbType.VarChar,50),
					new SqlParameter("@NatureID", SqlDbType.Int,4),
					new SqlParameter("@NatureName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@Integrity", SqlDbType.Int,4),
					new SqlParameter("@EstablishMent", SqlDbType.VarChar,50),
					new SqlParameter("@Employees", SqlDbType.BigInt,8),
					new SqlParameter("@Capital", SqlDbType.BigInt,8),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,50),
					new SqlParameter("@Logo", SqlDbType.VarChar,1000),
					new SqlParameter("@Introduction", SqlDbType.NVarChar,2000),
					new SqlParameter("@ServiceProce", SqlDbType.NVarChar,2000),
					new SqlParameter("@Title", SqlDbType.VarChar,50),
					new SqlParameter("@Keywords", SqlDbType.VarChar,100),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
                    new SqlParameter("@TelPhone",SqlDbType.VarChar,50),
                    new SqlParameter("@Mobile",SqlDbType.VarChar,50),
                    new SqlParameter("@AuditingStatus",SqlDbType.Int,4),
                    new SqlParameter("@HtmlFile",SqlDbType.VarChar,100),
                    new SqlParameter("@Ismake",SqlDbType.Int,4),
                    new SqlParameter("@IsDelete",SqlDbType.Int,4),
                    new SqlParameter("@Provice",SqlDbType.Int,4),
                    new SqlParameter("@City",SqlDbType.Int,4)
            };
            model.CompanyID = id;
            parameters[0].Value = model.CompanyID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.CompanyName;
            parameters[3].Value = model.IndustryID;
            parameters[4].Value = model.IndustryName;
            parameters[5].Value = model.RangeID;
            parameters[6].Value = model.RangeName;
            parameters[7].Value = model.NatureID;
            parameters[8].Value = model.NatureName;
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = model.Hit;
            parameters[11].Value = model.Integrity;
            parameters[12].Value = model.EstablishMent;
            parameters[13].Value = model.Employees;
            parameters[14].Value = model.Capital;
            parameters[15].Value = model.LinkName;
            parameters[16].Value = model.Email;
            parameters[17].Value = model.URL;
            parameters[18].Value = model.Address;
            parameters[19].Value = model.Logo;
            parameters[20].Value = model.Introduction;
            parameters[21].Value = model.ServiceProce;
            parameters[22].Value = model.Title;
            parameters[23].Value = model.Keywords;
            parameters[24].Value = model.Description;
            parameters[25].Value = model.Telphone;
            parameters[26].Value = model.Mobile;
            parameters[27].Value = model.Auditingstatus;
            parameters[28].Value = model.Htmlfile;
            parameters[29].Value = model.Ismake;
            parameters[30].Value = model.IsDelete;
            parameters[31].Value = model.Provice;
            parameters[32].Value = model.City;
            num=crm.RunProcedure("Pro_Company_Update", parameters, out rowsAffected);
            return num;
        }
        #endregion
        #region �ж��Ƿ񷢲�����ҵ��Ƭ
        /// <summary>
        /// �ж��Ƿ񷢲�����ҵ��Ƭ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfCompany(string name)
        {
            int num = 0;
            string sql = "select count(CompanyID) from CompanyTab where LoginName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingle(sql,para));
            return num;
        }
        #endregion
        #region �����û����������״̬
        /// <summary>
        /// �����û����������״̬
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelAdution(string name)
        {
            int num = 0;
            string sql = "select AuditingStatus from CompanyTab where LoginName=@name";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingle(sql,para));
            return num;
        }
        #endregion

        #region �����û�����ѯ����Ӧ����Ϣ
        public CompanyModel SelCompany(string name)
        {
            CompanyModel com = new CompanyModel();
            string sql = "select [CompanyID],[LoginName],[CompanyName],[IndustryID],[IndustryName],[RangeID],"
                + "[RangeName],[NatureID],[NatureName],[CreateDate],[Hit],[AuditingStatus],[HtmlFile],[Integrity],"
                + "[EstablishMent],[Employees],[Capital],[Ismake],[IsDelete],[LinkName],[Email],[TelPhone],[Mobile],"
                + "[URL],[Address],[Logo],[Introduction],[ServiceProce],[Title],[Keywords],[Description],[Sheng],[City] from [CompanyTab] "
                + "where LoginName=@name and IsDelete=0";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = crm.Query(sql, para);
            if (ds.Tables[0].Rows.Count <= 0)
                return null;
            com.CompanyID = Convert.ToInt32(ds.Tables[0].Rows[0]["CompanyID"].ToString());//�û����
            com.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();//�û��ʺ�
            com.CompanyName = ds.Tables[0].Rows[0]["CompanyName"].ToString();//��ҵ����
            com.IndustryID = Convert.ToInt32(ds.Tables[0].Rows[0]["IndustryID"].ToString());//��ҵID
            com.IndustryName = ds.Tables[0].Rows[0]["IndustryName"].ToString();//��ҵ����   
            com.RangeID = Convert.ToInt32(ds.Tables[0].Rows[0]["RangeID"].ToString());//����ID
            com.RangeName = ds.Tables[0].Rows[0]["RangeName"].ToString();//��������
            com.NatureID = Convert.ToInt32(ds.Tables[0].Rows[0]["NatureID"].ToString());//��ҵ����ID
            com.NatureName = ds.Tables[0].Rows[0]["NatureName"].ToString();//��ҵ��������

            com.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString());//��������
            com.Hit = Convert.ToInt32(ds.Tables[0].Rows[0]["Hit"].ToString());//�����
            com.Auditingstatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Auditingstatus"].ToString());//���״̬
            com.Htmlfile = ds.Tables[0].Rows[0]["Htmlfile"].ToString();//��̬·��
            com.Integrity = Convert.ToInt32(ds.Tables[0].Rows[0]["Integrity"].ToString());//����ָ��
            com.EstablishMent = ds.Tables[0].Rows[0]["EstablishMent"].ToString();//��������
            com.Employees = Convert.ToInt64(ds.Tables[0].Rows[0]["Employees"].ToString());//Ա������    
            com.Capital = Convert.ToInt64(ds.Tables[0].Rows[0]["Capital"].ToString());//ע���Լ�
            com.Ismake = Convert.ToInt32(ds.Tables[0].Rows[0]["Ismake"].ToString());//�Ƿ��Ƽ�  
            com.IsDelete = Convert.ToInt32(ds.Tables[0].Rows[0]["IsDelete"].ToString());//�Ƿ�ɾ��
            com.Provice = Convert.ToInt32(ds.Tables[0].Rows[0]["Sheng"].ToString());//ʡ��
            com.City = Convert.ToInt32(ds.Tables[0].Rows[0]["City"].ToString());//����

            com.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();//��ϵ��
            com.Email = ds.Tables[0].Rows[0]["Email"].ToString();//��������
            com.Telphone = ds.Tables[0].Rows[0]["TelPhone"].ToString();//�绰����
            com.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();//�ֻ�����
            com.URL = ds.Tables[0].Rows[0]["URL"].ToString();//��ַ
            com.Address = ds.Tables[0].Rows[0]["Address"].ToString();//��ϵ��ַ
            com.Logo = ds.Tables[0].Rows[0]["Logo"].ToString();//ͼƬ
            com.Introduction = ds.Tables[0].Rows[0]["Introduction"].ToString();//��ҵ����
            com.ServiceProce = ds.Tables[0].Rows[0]["ServiceProce"].ToString();//��Ӫ����
            com.Title = ds.Tables[0].Rows[0]["Title"].ToString();//����
            com.Keywords = ds.Tables[0].Rows[0]["Keywords"].ToString();//��ҳ�ؼ���
            com.Description = ds.Tables[0].Rows[0]["Description"].ToString();//��ҳ�̱���

            return com;
        }

        /// <summary>
        /// ��ȡʡ���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvinceList()
        {
            string sql = "select ProvinceID,ProvinceName from SetProvinceTab where ProvinceID!=0000";
            DataSet ds = DbHelperSQL.ExecuteQuery(sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public DataTable GetCity(string ProvinceID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ProvinceID", SqlDbType.Char,10),
			};
            parameters[0].Value = ProvinceID;
            DataSet ds = DbHelperSQL.RunProcedure("SetCityTab_GetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0];
        }

        /// <summary>
        /// ��ѯ��ϵ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public string SelLinkName(int id)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    CompanyModel com = new CompanyModel();
        //    com = SelCompany(id);
        //    sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab1\">");
        //    sb.Append("<tr><td class=\"col\">��ҵ���ƣ�</td>");
        //    sb.Append("<td colspan=\"3\">" + com.CompanyName + "</td></tr>");
        //    sb.Append("<tr><td width=\"17%\" class=\"col\">��ϵ�ˣ�</td><td width=\"30%\">" + com.LinkName + "</td>");
        //    sb.Append("<td width=\"15%\" class=\"col\">��ϵ�绰��</td><td>" + com.Telphone + "</td></tr>");
        //    sb.Append("<tr><td class=\"col\">��ҵ��ַ��</td><td>" + com.URL + "</td>");
        //    sb.Append("<td class=\"col\">  EMail:</td><td>" + com.Email + "</td></tr>");
        //    sb.Append("<tr><td class=\"col\">��ҵ��ַ��</td>");
        //    sb.Append("<td colspan=\"3\">" + com.Address + "</td></tr>");
        //    sb.Append("</table>");
        //    return sb.ToString();
        //}

        #endregion
        #endregion
    }
}
