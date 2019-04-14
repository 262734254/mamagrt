using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL.Register;
using Tz888.DBUtility;
using Tz888.Model.Register;

namespace Tz888.SQLServerDAL.Register
{
    public class VIPMemberRegister : IVIPMemberRegister
    {
        private Tz888.SQLServerDAL.Conn obj;
        public VIPMemberRegister()
		{
          
        }


        #region 前台拓富通会员审请
        public int AddVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
                int bl;
                int rowsAffected;
                SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
					new SqlParameter("@BuyTerm", SqlDbType.SmallInt,2),
					new SqlParameter("@OrgName", SqlDbType.Char,16),
					new SqlParameter("@RealName", SqlDbType.VarChar,30),
					new SqlParameter("@Position", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
					new SqlParameter("@TelStateCode", SqlDbType.Char,4),
					new SqlParameter("@TelNum", SqlDbType.VarChar,60),
					new SqlParameter("@Mobile", SqlDbType.VarChar,30),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@ApplyDate", SqlDbType.DateTime),
					new SqlParameter("@IsPay", SqlDbType.TinyInt,1),
					new SqlParameter("@OprStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@OprDescript", SqlDbType.VarChar,500),
					new SqlParameter("@OprMan", SqlDbType.VarChar,30),
					new SqlParameter("@OprDate", SqlDbType.DateTime),
					new SqlParameter("@Memo", SqlDbType.VarChar,100),

                    new SqlParameter("@MarketPersonName", SqlDbType.Char,16),
                    new SqlParameter("@VIPValidateDate", SqlDbType.DateTime),

					new SqlParameter("@Money", SqlDbType.Money),
					new SqlParameter("@Years", SqlDbType.Int),

                    new SqlParameter("@ServiceType", SqlDbType.Char,10),
                    new SqlParameter("@Price", SqlDbType.Money)                   
                
                };
                parameters[0].Direction = ParameterDirection.InputOutput;
                parameters[1].Value = model.LoginName;
                parameters[2].Value = model.ManageTypeID;
                parameters[3].Value = model.BuyTerm;
                parameters[4].Value = model.OrgName;
                parameters[5].Value = model.RealName;
                parameters[6].Value = model.Position;
                parameters[7].Value = model.Sex;
                parameters[8].Value = model.TelCountryCode;
                parameters[9].Value = model.TelStateCode;
                parameters[10].Value = model.TelNum;
                parameters[11].Value = model.Mobile;
                parameters[12].Value = model.Email;
                parameters[13].Value = model.ApplyDate;
                parameters[14].Value = model.IsPay;
                parameters[15].Value = model.OprStatus;
                parameters[16].Value = model.OprDescript;
                parameters[17].Value = model.OprMan;
                parameters[18].Value = model.OprDate;
                parameters[19].Value = model.Memo;
                parameters[20].Value = model.MarketPersonName;
                parameters[21].Value = model.VIPValidateDate;
                parameters[22].Value = model.Money;
                parameters[23].Value = model.Years;
                parameters[24].Value = model.ServiceType;
                parameters[25].Value = model.Price;

                bl = DbHelperSQL.RunProcedure("UP_VipApplyTab_ADD", parameters, out rowsAffected);

                if (rowsAffected > 0)
                {
                    return (int)parameters[0].Value;
                }
                else {
                    return 0;
                }            
        }
        #endregion

        #region 后台会员申请列表/后台拓富通会员列表
        public DataTable GetMemberList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            obj = new Tz888.SQLServerDAL.Conn();
            return (obj.GetList(
                       tblName,
                       strGetFields,
                       fldName,
                       PageSize,
                       PageIndex,
                       doCount,
                       OrderType,
                       strWhere));
            return null;
        }
        #endregion
      

        #region 获取一条记录信息（查看）
        public Tz888.Model.Register.VIPMemberRegister GetVIPMemberModel(int ApplyID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4)
				};
            parameters[0].Value = ApplyID;
            Tz888.Model.Register.VIPMemberRegister model = new Tz888.Model.Register.VIPMemberRegister();

            DataSet ds = DbHelperSQL.RunProcedure("UP_VipApplyTab_GetModel", parameters, "ds");
            model.ApplyID = ApplyID;
            if (ds.Tables[0].Rows.Count > 0) 
            {
                model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                if (ds.Tables[0].Rows[0]["ManageTypeID"].ToString() != "")
                {
                    model.ManageTypeID = ds.Tables[0].Rows[0]["ManageTypeID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BuyTerm"].ToString() != "")
                {
                    model.BuyTerm = int.Parse(ds.Tables[0].Rows[0
                        
                        ]["BuyTerm"].ToString());
                }
                model.OrgName = ds.Tables[0].Rows[0]["OrgName"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sex"].ToString().Trim().ToLower() == "false"))
                    {
                        model.Sex = false;
                        //model.Email = "ffff";
                    }
                    else
                    {
                        model.Sex = true;
                        //model.Email = "tttt";
                    }
                }

                model.TelCountryCode = ds.Tables[0].Rows[0]["TelCountryCode"].ToString();
                model.TelStateCode = ds.Tables[0].Rows[0]["TelStateCode"].ToString();
                model.TelNum = ds.Tables[0].Rows[0]["TelNum"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["ApplyDate"].ToString() != "")
                {

                    model.ApplyDate = DateTime.Parse(ds.Tables[0].Rows[0]["ApplyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OprStatus"].ToString() != "")
                {
                    model.OprStatus = int.Parse(ds.Tables[0].Rows[0]["OprStatus"].ToString());
                }
                model.OprDescript = ds.Tables[0].Rows[0]["OprDescript"].ToString();
                model.OprMan = ds.Tables[0].Rows[0]["OprMan"].ToString();
                if (ds.Tables[0].Rows[0]["OprDate"].ToString() != "")
                {

                    model.OprDate = DateTime.Parse(ds.Tables[0].Rows[0]["OprDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VIPValidateDate"].ToString() != "")
                {

                    model.VIPValidateDate = DateTime.Parse(ds.Tables[0].Rows[0]["VIPValidateDate"].ToString());
                }
                model.Memo = ds.Tables[0].Rows[0]["Memo"].ToString();
                model.MarketPersonName = ds.Tables[0].Rows[0]["MarketPersonName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 审核
        public bool AuditVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {	
			        new SqlParameter("@ApplyID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.Char,16),
                	new SqlParameter("@AuditStatus", SqlDbType.SmallInt,2), 
					new SqlParameter("@ManageTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@CycleID", SqlDbType.SmallInt,2),
					new SqlParameter("@VIPValidateDate", SqlDbType.DateTime),
                    new SqlParameter("@MarketPersonName", SqlDbType.VarChar,30),
                    new SqlParameter("@IsPay", SqlDbType.TinyInt,1),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2) 
            };
            parameters[0].Value = model.ApplyID;		
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.OprStatus;
            parameters[3].Value = model.ManageTypeID;
            parameters[4].Value = model.BuyTerm;
            parameters[5].Value = model.VIPValidateDate;
            parameters[6].Value = model.OprMan;
            parameters[7].Value = model.IsPay;
            parameters[8].Direction = ParameterDirection.Output;////--0成功 1逻辑失败 2数据库失败*/
          
            DbHelperSQL.RunProcedure("VIP_MEMBER_AUDIT", parameters, out rowsAffected);
            if (rowsAffected>0)//parameters[0].Value.ToString() == "0")// Status = (int)parameters[8].Value;
                return true;
            else
            return false;
        }
        #endregion 

        #region 删除
        public bool DeleteVIPMember(int ApplyID)
        {
            int rowsAffected;           
            SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4)
				};
            parameters[0].Value = ApplyID;
            rowsAffected = DbHelperSQL.RunProcedure("UP_VipApplyTab_Delete", parameters, out rowsAffected);

            if (rowsAffected == 1)
                return true;
            else
                return false;
        }
        #endregion 

        /// <summary>
        /// 获取拓富通购买价格
        /// </summary>
        /// <param name="ManageTypeID">会员类型</param>
        /// <param name="BuyTerm">购买期限</param>
        /// <returns></returns>
        public string getPriceByType(string ManageTypeID, int BuyTerm)
        {
            string value = ManageTypeID + BuyTerm;
            obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = (obj.GetList("SetVIPPriceTab", "*", "PriceCode", 1, 1, 0, 1,
                "ManageTypeID='" + ManageTypeID + "'AND CycleID =" + BuyTerm));
            return dt.Rows[0]["Price"].ToString();
        }

        #region 修改
        public bool UpdateVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4),//

					new SqlParameter("@LoginName", SqlDbType.Char,16),

					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),//

					new SqlParameter("@BuyTerm", SqlDbType.SmallInt,2),//
                    new SqlParameter("@OrgName", SqlDbType.Char,16),
                    new SqlParameter("@RealName", SqlDbType.VarChar,30),
                    new SqlParameter("@Position", SqlDbType.VarChar,50),
                    new SqlParameter("@Sex", SqlDbType.Bit,1),
                    new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
                    new SqlParameter("@TelStateCode", SqlDbType.Char,4),
                    new SqlParameter("@TelNum", SqlDbType.VarChar,60),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,30),
                    new SqlParameter("@Email", SqlDbType.VarChar,50),
                    new SqlParameter("@ApplyDate", SqlDbType.DateTime),
                    new SqlParameter("@IsPay", SqlDbType.TinyInt,1),
                    new SqlParameter("@OprStatus", SqlDbType.SmallInt,2),
                    new SqlParameter("@OprDescript", SqlDbType.VarChar,500),
					new SqlParameter("@OprMan", SqlDbType.VarChar,30),//
					new SqlParameter("@OprDate", SqlDbType.DateTime),//
					new SqlParameter("@Memo", SqlDbType.VarChar,100),//

                    new SqlParameter("@MarketPersonName", SqlDbType.Char,16),
                    new SqlParameter("@VIPValidateDate", SqlDbType.DateTime),

                    ////new SqlParameter("@Money", SqlDbType.Money),
                    ////new SqlParameter("@Years", SqlDbType.Int),

                    //new SqlParameter("@ServiceType", SqlDbType.Char,10),
                    //new SqlParameter("@Price", SqlDbType.Money)
 
            };
            parameters[0].Value = model.ApplyID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.ManageTypeID;
            parameters[3].Value = model.BuyTerm;
            parameters[4].Value = model.OrgName;
            parameters[5].Value = model.RealName;
            parameters[6].Value = model.Position;
            parameters[7].Value = model.Sex;
            parameters[8].Value = model.TelCountryCode;
            parameters[9].Value = model.TelStateCode;
            parameters[10].Value = model.TelNum;
            parameters[11].Value = model.Mobile;
            parameters[12].Value = model.Email;
            parameters[13].Value = model.ApplyDate;
            parameters[14].Value = model.IsPay;
            parameters[15].Value = model.OprStatus;
            parameters[16].Value = model.OprDescript;
            parameters[17].Value = model.OprMan;
            parameters[18].Value = model.OprDate;
            parameters[19].Value = model.Memo;
            parameters[20].Value = model.MarketPersonName;
            parameters[21].Value = model.VIPValidateDate;
            ////parameters[22].Value = model.Money;
            ////parameters[23].Value = model.Years;
            ////parameters[24].Value = model.ServiceType;
            ////parameters[25].Value = model.Price;
  

            DbHelperSQL.RunProcedure("UP_VipApplyTab_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            else
            return false;
            
        }
        #endregion

        /// <summary>
        /// 审核拓富通会员
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="ManageTypeID"></param>
        /// <param name="CycleID"></param>
        /// <returns></returns>
        public bool UpdateVIPMember_sh(Tz888.Model.Register.VIPMemberRegister model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ApplyID", SqlDbType.Int,4),//

					//new SqlParameter("@LoginName", SqlDbType.Char,16),

					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),//

					new SqlParameter("@BuyTerm", SqlDbType.SmallInt,2),//
                    //new SqlParameter("@OrgName", SqlDbType.Char,16),
                    //new SqlParameter("@RealName", SqlDbType.VarChar,30),
                    //new SqlParameter("@Position", SqlDbType.VarChar,50),
                    //new SqlParameter("@Sex", SqlDbType.Bit,1),
                    //new SqlParameter("@TelCountryCode", SqlDbType.Char,3),
                    //new SqlParameter("@TelStateCode", SqlDbType.Char,4),
                    //new SqlParameter("@TelNum", SqlDbType.VarChar,60),
                    //new SqlParameter("@Mobile", SqlDbType.VarChar,30),
                    //new SqlParameter("@Email", SqlDbType.VarChar,50),
                    //new SqlParameter("@ApplyDate", SqlDbType.DateTime),
                    //new SqlParameter("@IsPay", SqlDbType.TinyInt,1),
                    //new SqlParameter("@OprStatus", SqlDbType.SmallInt,2),
                    //new SqlParameter("@OprDescript", SqlDbType.VarChar,500),
					new SqlParameter("@OprMan", SqlDbType.VarChar,30),//
					//new SqlParameter("@OprDate", SqlDbType.DateTime),//
					new SqlParameter("@Memo", SqlDbType.VarChar,100),//

                    //new SqlParameter("@MarketPersonName", SqlDbType.Char,16),
                    //new SqlParameter("@VIPValidateDate", SqlDbType.DateTime),

                    ////new SqlParameter("@Money", SqlDbType.Money),
                    ////new SqlParameter("@Years", SqlDbType.Int),

                    //new SqlParameter("@ServiceType", SqlDbType.Char,10),
                    //new SqlParameter("@Price", SqlDbType.Money)
 
            };
            parameters[0].Value = model.ApplyID;
            //parameters[1].Value = model.LoginName;
            parameters[1].Value = model.ManageTypeID;
            parameters[2].Value = model.BuyTerm;
            //parameters[4].Value = model.OrgName;
            //parameters[5].Value = model.RealName;
            //parameters[6].Value = model.Position;
            //parameters[7].Value = model.Sex;
            //parameters[8].Value = model.TelCountryCode;
            //parameters[9].Value = model.TelStateCode;
            //parameters[10].Value = model.TelNum;
            //parameters[11].Value = model.Mobile;
            //parameters[12].Value = model.Email;
           // parameters[13].Value = model.ApplyDate;
            //parameters[13].Value = model.IsPay;
            //parameters[14].Value = model.OprStatus;
            //parameters[15].Value = model.OprDescript;
            parameters[3].Value = model.OprMan;
            //parameters[17].Value = model.OprDate;
            parameters[4].Value = model.Memo;
            //parameters[19].Value = model.MarketPersonName;
            //parameters[21].Value = model.VIPValidateDate;
            ////parameters[22].Value = model.Money;
            ////parameters[23].Value = model.Years;
            ////parameters[24].Value = model.ServiceType;
            ////parameters[25].Value = model.Price;
  

            DbHelperSQL.RunProcedure("UP_VipApplyTab_Update", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            else
            return false;
            
        }

        #region  拓富通会员删除（只取消此人的拓富通会员资格）
        public bool VIPMember_Delete(string LoginName, string ManageTypeID, int CycleID)
        {
            bool b;
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,10),
                	new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
                	new SqlParameter("@CycleID", SqlDbType.Int,4)
				};
            parameters[0].Value = LoginName;
            parameters[1].Value = ManageTypeID;
            parameters[2].Value = CycleID;
            try
            {
                DbHelperSQL.RunProcedure("VIP_MEMBER_DELETE", parameters, out rowsAffected);
                 b=true;
            }
            catch
            {
                b= false;
            }
            return b;
            
        }
         #endregion 

        #region 判断是否己存在
        public bool VIP_IsExist(string loginName, string ManageTypeID, int BuyTerm)
        { 
           Tz888.SQLServerDAL.Conn objcon=new Conn();
           DataTable  dt =  objcon.GetList("VipApplyTab", "*", "ApplyID", 1, 1, 0, 1, "LoginName='" + loginName + "'");//AND ManageTypeID='" + ManageTypeID + "'AND BuyTerm=" + BuyTerm);
           if (dt != null && dt.Rows.Count > 0)           
               return true;           
           else
               return false;
        }
        #endregion

        #region 修改拓富通申请赠送参数相关
        public void UpdateVIPPrice(Tz888.Model.Register.SetVIPPriceModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@VIPPriceID", SqlDbType.SmallInt,2),
					new SqlParameter("@PriceCode", SqlDbType.VarChar,20),
					new SqlParameter("@CycleID", SqlDbType.SmallInt,2),
					new SqlParameter("@ManageTypeID", SqlDbType.Char,10),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@PresentPoint", SqlDbType.Float,8),
					new SqlParameter("@PresentIntegral", SqlDbType.Int,4),
					new SqlParameter("@PresentExtension", SqlDbType.Int,4),
					new SqlParameter("@PresentCustomMessage", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,200)};
            parameters[0].Value = model.VIPPriceID;
            parameters[1].Value = model.PriceCode;
            parameters[2].Value = model.CycleID;
            parameters[3].Value = model.ManageTypeID;
            parameters[4].Value = model.Price;
            parameters[5].Value = model.PresentPoint;
            parameters[6].Value = model.PresentIntegral;
            parameters[7].Value = model.PresentExtension;
            parameters[8].Value = model.PresentCustomMessage;
            parameters[9].Value = model.remark;

            DbHelperSQL.RunProcedure("UP_SetVIPPriceTab_Update", parameters, out rowsAffected);
        }
        #endregion

        #region  读取一条信息
        public Tz888.Model.Register.SetVIPPriceModel getVIPPriceModel(int VIPPriceID)
        {
            Tz888.Model.Register.SetVIPPriceModel model = new SetVIPPriceModel();
            Tz888.SQLServerDAL.Conn objVIP = new Conn();
            DataTable ds = objVIP.GetList("SetVIPPriceTab", "*", "VIPPriceID", 1, 1, 0, 1, "VIPPriceID=" + VIPPriceID);

            if (ds.Rows.Count > 0)
            {
                model.PriceCode = ds.Rows[0]["PriceCode"].ToString();
                if (ds.Rows[0]["CycleID"].ToString() != "")
                {
                    model.CycleID = int.Parse(ds.Rows[0]["CycleID"].ToString());
                }
                model.ManageTypeID = ds.Rows[0]["ManageTypeID"].ToString();
                if (ds.Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Rows[0]["Price"].ToString());
                }
                if (ds.Rows[0]["PresentPoint"].ToString() != "")
                {
                    model.PresentPoint = decimal.Parse(ds.Rows[0]["PresentPoint"].ToString());
                }
                if (ds.Rows[0]["PresentIntegral"].ToString() != "")
                {
                    model.PresentIntegral = int.Parse(ds.Rows[0]["PresentIntegral"].ToString());
                }
                if (ds.Rows[0]["PresentExtension"].ToString() != "")
                {
                    model.PresentExtension = int.Parse(ds.Rows[0]["PresentExtension"].ToString());
                }
                if (ds.Rows[0]["PresentCustomMessage"].ToString() != "")
                {
                    model.PresentCustomMessage = int.Parse(ds.Rows[0]["PresentCustomMessage"].ToString());
                }
                model.remark = ds.Rows[0]["remark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion 

        public void Delete(int VIPPriceID)
        {          
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@VIPPriceID", SqlDbType.Int,4)
				};
			parameters[0].Value = VIPPriceID;
			DbHelperSQL.RunProcedure("UP_SetVIPPriceTab_Delete",parameters,out rowsAffected);
		
        }
    }
}
