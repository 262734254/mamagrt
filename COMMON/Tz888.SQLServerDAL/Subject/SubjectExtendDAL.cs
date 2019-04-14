using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.Subject;
using Tz888.IDAL.Subject;

namespace Tz888.SQLServerDAL.Subject
{
    public class SubjectExtendDAL:ISubjectExtend
    {
        #region ISubjectExtend 成员
        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        #region 添加专题推广信息
        public int AddSubjectExtend(SubjectExtendModel model)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@Remark", SqlDbType.NVarChar,4000),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.Int,4),
					new SqlParameter("@HtmlUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@SubType", SqlDbType.Int,4),
					new SqlParameter("@SubTime", SqlDbType.DateTime),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Picture", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.SubTitle;
            parameters[2].Value = model.Remark;
            parameters[3].Value = model.Audit;
            parameters[4].Value = model.Source;
            parameters[5].Value = model.HtmlUrl;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.SubType;
            parameters[8].Value = model.SubTime;
            parameters[9].Value = model.LinkMan;
            parameters[10].Value = model.Phone;
            parameters[11].Value = model.Picture;
            num = crm.RunProcedure("SP_SubjectExtendTab_Add", parameters, out rowsAffected);
            return num;
        }
        #endregion

        #region 修改专题推广信息
        public int ModfiySubjectExtend(SubjectExtendModel model, int id)
        {
            int rowsAffected;
            int num = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@SubID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@SubTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@Remark", SqlDbType.NVarChar,4000),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@Source", SqlDbType.Int,4),
					new SqlParameter("@HtmlUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@SubType", SqlDbType.Int,4),
					new SqlParameter("@SubTime", SqlDbType.DateTime),
					new SqlParameter("@LinkMan", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Picture", SqlDbType.NVarChar,1000)
            };
            model.SubID = id;
            parameters[0].Value = model.SubID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.Remark;
            parameters[4].Value = model.Audit;
            parameters[5].Value = model.Source;
            parameters[6].Value = model.HtmlUrl;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.SubType;
            parameters[9].Value = model.SubTime;
            parameters[10].Value = model.LinkMan;
            parameters[11].Value = model.Phone;
            parameters[12].Value = model.Picture;
            num = crm.RunProcedure("SP_SubjectExtendTab_Update", parameters, out rowsAffected);
            return num;
        }
        #endregion

        #region 删除专题推广信息
        public int DeleteSubjectExtend(int id)
        {
            int num = 0;
            string sql = "delete from SubjectExtendTab where SubID=@id";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }
        #endregion

        #region 跟进ID查询实体类信息
        public SubjectExtendModel SelSubject(int id)
        {
            SubjectExtendModel model = new SubjectExtendModel();
            string sql = "select  SubID,LoginName,SubTitle,Remark,Audit,Source,HtmlUrl,Sort,SubType,SubTime,LinkMan,Phone,Picture from SubjectExtendTab where SubID=@id  ";
            SqlParameter[] para ={ 
                 new SqlParameter("@id",SqlDbType.Int,4)
            };
            para[0].Value = id;
            DataSet ds = crm.Query(sql,para);
            if (ds !=null & ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SubID"].ToString() != "")
                {
                    model.SubID = int.Parse(ds.Tables[0].Rows[0]["SubID"].ToString());//主键
                }
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();//用户名
                model.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();//专题标题
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();//专题说明
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());//审核状态
                }
                if (ds.Tables[0].Rows[0]["Source"].ToString() != "")
                {
                    model.Source = int.Parse(ds.Tables[0].Rows[0]["Source"].ToString());//来源
                }
                model.HtmlUrl = ds.Tables[0].Rows[0]["HtmlUrl"].ToString();//访问地址
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());//排序
                }
                if (ds.Tables[0].Rows[0]["SubType"].ToString() != "")
                {
                    model.SubType = int.Parse(ds.Tables[0].Rows[0]["SubType"].ToString());//类型
                }
                if (ds.Tables[0].Rows[0]["SubTime"].ToString() != "")
                {
                    model.SubTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubTime"].ToString());//发布时间
                }
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();//联系人
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();//联系人电话
                model.Picture = ds.Tables[0].Rows[0]["Picture"].ToString();//图片
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 分页
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }
        #endregion
        #endregion
    }
}
