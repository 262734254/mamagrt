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
    public class SetSubDefaultValue : ISetSubDefaultValue
    {

        public long Insert(Tz888.Model.Info.SubDefaultValueModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[10];

            parameters[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            parameters[0].Value = model.ID;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1] = new SqlParameter("@SetDefaultValueID", SqlDbType.BigInt);
            parameters[1].Value = model.SetDefaultValueID;

            parameters[2] = new SqlParameter("@DefType", SqlDbType.TinyInt);
            parameters[2].Value = model.DefType;

            parameters[3] = new SqlParameter("@FromColumn", SqlDbType.NVarChar);
            parameters[3].Size = 200;
            parameters[3].Value = model.FromColumn;

            parameters[4] = new SqlParameter("@FromColumnName", SqlDbType.NVarChar);
            parameters[4].Size = 200;
            parameters[4].Value = model.FromColumnName;

            parameters[5] = new SqlParameter("@FromValue", SqlDbType.NVarChar);
            parameters[5].Size = 2000;
            parameters[5].Value = model.FromValue;

            parameters[6] = new SqlParameter("@IsDefaultSelect", SqlDbType.TinyInt);
            parameters[6].Value = model.IsDefaultSelect;

            parameters[7] = new SqlParameter("@IsNeeded", SqlDbType.TinyInt);
            parameters[7].Value = model.IsNeeded;

            parameters[8] = new SqlParameter("@Seq", SqlDbType.TinyInt);
            parameters[8].Value = model.Seq;

            parameters[9] = new SqlParameter("@Remark", SqlDbType.NVarChar);
            parameters[9].Size = 100;
            parameters[9].Value = model.Remark;

            DbHelperSQL.RunProcedure("SetSubDefaultValueTab_Insert", parameters, out rowsAffected);
            return Convert.ToInt64(parameters[0].Value);

        }

        public bool Update(Tz888.Model.Info.SubDefaultValueModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            parameters[0].Value = model.ID;

            parameters[1] = new SqlParameter("@Remark", SqlDbType.NVarChar);
            parameters[1].Size = 100;
            parameters[1].Value = model.Remark;

            parameters[2] = new SqlParameter("@DefType", SqlDbType.TinyInt);
            parameters[2].Value = model.DefType;

            parameters[3] = new SqlParameter("@FromColumn", SqlDbType.NVarChar);
            parameters[3].Size = 200;
            parameters[3].Value = model.FromColumn;

            parameters[4] = new SqlParameter("@FromColumnName", SqlDbType.NVarChar);
            parameters[4].Size = 200;
            parameters[4].Value = model.FromColumnName;

            parameters[5] = new SqlParameter("@FromValue", SqlDbType.NVarChar);
            parameters[5].Size = 2000;
            parameters[5].Value = model.FromValue;

            parameters[6] = new SqlParameter("@IsDefaultSelect", SqlDbType.TinyInt);
            parameters[6].Value = model.IsDefaultSelect;

            parameters[7] = new SqlParameter("@IsNeeded", SqlDbType.TinyInt);
            parameters[7].Value = model.IsNeeded;

            parameters[8] = new SqlParameter("@Seq", SqlDbType.TinyInt);
            parameters[8].Value = model.Seq;

            DbHelperSQL.RunProcedure("SetSubDefaultValueTab_Update", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;

        }

        public bool Delete(long ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("SetSubDefaultValueTab_Delete", parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false; ;
        }

        public Tz888.Model.Info.SubDefaultValueModel GetDetail(string Key)
        {
            long PageCount = 0;
            long CurrentPage = 1;
            Tz888.SQLServerDAL.Conn dal = new Conn();
            DataView dv = dal.GetList(
                "SetSubDefaultValueTabList",
                "*",
                "(ID=" + Key + ")",
                "",
                ref CurrentPage,
                -1,
                ref PageCount);
            if (dv != null)
            {
                return Fill(dv);
            }
            return null;
        }

        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Tz888.SQLServerDAL.Conn dal = new Conn();
            return dal.GetList("SetSubDefaultValueTabList",SelectCol,Criteria,OrderBy,ref CurrentPage, PageSize,ref PageCount);
        }
        #region Ìî³äÊý¾Ý
        private Tz888.Model.Info.SubDefaultValueModel Fill(DataView dv)
        {
            Tz888.Model.Info.SubDefaultValueModel model = new Tz888.Model.Info.SubDefaultValueModel();
            model.ID = Convert.ToInt64(dv[0]["ID"]);

            model.SetDefaultValueID = Convert.ToInt64(dv[0]["SetDefaultValueID"]);

            model.DefType = Convert.ToByte(dv[0]["DefType"]);

            model.FromColumn = dv[0]["FromColumn"].ToString().TrimEnd();

            model.FromColumnName = Convert.ToString(dv[0]["FromColumnName"]).TrimEnd();

            model.FromValue = dv[0]["FromValue"].ToString().TrimEnd();

            model.IsDefaultSelect = Convert.ToByte(dv[0]["IsDefaultSelect"]);

            model.IsNeeded = Convert.ToByte(dv[0]["IsNeeded"]);

            model.Seq = Convert.ToByte(dv[0]["Seq"]);

            model.Remark = dv[0]["Remark"].ToString().TrimEnd();

            return model;

        }
        #endregion
    }
}
