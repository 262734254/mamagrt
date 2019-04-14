using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class CustomInfoDAL : ICustomInfo
    {
       #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
			parameters[0].Value = ID;
			int result= DbHelperSQL.RunProcedure("UP_CustomInfoTab_Exists",parameters,out rowsAffected);
			if(result==1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(Tz888.Model.CustomInfoModel model)
		{
          

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),		//--登录名
											new SqlParameter("@Accept",SqlDbType.Bit),				//是否接收中国招商投资网的所有通讯
											new SqlParameter("@Email",SqlDbType.VarChar,100),		//-按收定制信息的E-mail 
											new SqlParameter("@CustomCyc",SqlDbType.TinyInt ),		//接收定制信息的周期 
											new SqlParameter("@CustomType",SqlDbType.TinyInt ),		//订制类型
											new SqlParameter("@Type",SqlDbType.VarChar,100),		//类别	
											new SqlParameter("@Genre",SqlDbType.VarChar,100),		//类型
											new SqlParameter("@Money",SqlDbType.VarChar,100),		//金额
											new SqlParameter("@Calling",SqlDbType.VarChar,100),		//行业
											new SqlParameter("@SmallCalling",SqlDbType.VarChar,100),//小行业	
											new SqlParameter("@City",SqlDbType.VarChar,50),			//城市
											new SqlParameter("@Keyword",SqlDbType.VarChar,50),		//关键字
											new SqlParameter("@CallingTxt",SqlDbType.VarChar,100),		//行业文本
											new SqlParameter("@SmallCallingTxt",SqlDbType.VarChar,100),//小行业文本	
											new SqlParameter("@CityTxt",SqlDbType.VarChar,50),			//城市文本
											new SqlParameter("@Title",SqlDbType.VarChar,100),
											new SqlParameter("@ValidateTerm",SqlDbType.Int),
											new SqlParameter("@ItemCount",SqlDbType.Int),
                	                        new SqlParameter("@currency",SqlDbType.Char,10),
											new SqlParameter("@CooperationDemandTypeID",SqlDbType.Char,10),
                                            //----------------------------2010-06新增字段-------------------------------
                                            new SqlParameter("@StageForenterpriseDevelop",SqlDbType.NVarChar,100),
                                            new SqlParameter("@financingObject",SqlDbType.NVarChar,100),
                                            new SqlParameter("@trade",SqlDbType.NVarChar,100),
										};

            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Accept;
            parameters[2].Value = model.Email;
            parameters[3].Value = Convert.ToByte(model.CustomCyc);
            parameters[4].Value = Convert.ToByte(model.CustomType);
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Genre;
            parameters[7].Value = model.Money;
            parameters[8].Value = model.Calling;
            parameters[9].Value = model.SmallCalling;
            parameters[10].Value = model.City;
            parameters[11].Value = model.Keyword;
            parameters[12].Value = model.CallingTxt;
            parameters[13].Value = model.SmallCallingTxt;
            parameters[14].Value = model.CityTxt;
            parameters[15].Value = model.Title;
            

            if (model.ValidateTerm.ToString().Trim() != "")
            {
                parameters[16].Value = model.ValidateTerm;
            }
            else
            {
                parameters[16].Value = System.DBNull.Value;
            }

            if (model.ItemCount.ToString().Trim() != "")
            {
                parameters[17].Value = model.ItemCount;
            }
            else
            {
                parameters[17].Value = System.DBNull.Value;
            }
            parameters[18].Value = model.currency;
            parameters[19].Value = model.CooperationDemandTypeID;

            //----------------------------2010-06新增字段-------------------------------
            parameters[20].Value = model.StageForenterpriseDevelop;
            parameters[21].Value = model.FinancingObject;
            parameters[22].Value = model.Trade;

            int rowsAffected = 0;
            try
            {
                //DbHelperSQL.RunProcedure("CustomInfoTab_Insert", parameters, out rowsAffected);
                return DbHelperSQL.RunProcedure("CustomInfoTab_Insert", parameters, out rowsAffected);
                //return (int)parameters[0].Value;
            }
            catch 
            {
                return 0;
            }
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
        public void Update(Tz888.Model.CustomInfoModel model)
		{
           

            SqlParameter[] parameters = { 
											
											new SqlParameter("@LoginName",SqlDbType.Char,16),		//--登录名
											new SqlParameter("@Accept",SqlDbType.Bit),				//是否接收中国招商投资网的所有通讯
											new SqlParameter("@Email",SqlDbType.VarChar,100),		//-按收定制信息的E-mail 
											new SqlParameter("@CustomCyc",SqlDbType.TinyInt ),		//接收定制信息的周期 
											new SqlParameter("@CustomType",SqlDbType.TinyInt ),		//订制类型
											new SqlParameter("@Type",SqlDbType.VarChar,100),		//类别	
											new SqlParameter("@Genre",SqlDbType.VarChar,100),		//类型
											new SqlParameter("@Money",SqlDbType.VarChar,100),		//金额
											new SqlParameter("@Calling",SqlDbType.VarChar,100),		//行业
											new SqlParameter("@SmallCalling",SqlDbType.VarChar,100),//小行业	
											new SqlParameter("@City",SqlDbType.VarChar,50),			//城市
											new SqlParameter("@Keyword",SqlDbType.VarChar,50),		//关键字
											new SqlParameter("@CallingTxt",SqlDbType.VarChar,100),		//行业
											new SqlParameter("@SmallCallingTxt",SqlDbType.VarChar,100),//小行业	
											new SqlParameter("@CityTxt",SqlDbType.VarChar,50),			//城市
											new SqlParameter("@Title",SqlDbType.VarChar,100),
											new SqlParameter("@ValidateTerm",SqlDbType.Int),
											new SqlParameter("@ItemCount",SqlDbType.Int),
											new SqlParameter("@ID",SqlDbType.BigInt),
                                	        new SqlParameter("@currency",SqlDbType.Char,10),
											new SqlParameter("@CooperationDemandTypeID",SqlDbType.Char,10),
                                            //----------------------------2010-06新增字段-------------------------------
                                            new SqlParameter("@StageForenterpriseDevelop",SqlDbType.NVarChar,100),
                                            new SqlParameter("@financingObject",SqlDbType.NVarChar,100),
                                            new SqlParameter("@trade",SqlDbType.NVarChar,100),
										};

            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Accept;
            parameters[2].Value = model.Email;
            parameters[3].Value = Convert.ToInt16(model.CustomCyc);
            parameters[4].Value = Convert.ToInt16(model.CustomType);
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Genre;
            parameters[7].Value = model.Money;
            parameters[8].Value = model.Calling;
            parameters[9].Value = model.SmallCalling;
            parameters[10].Value = model.City;
            parameters[11].Value = model.Keyword;
            parameters[12].Value = model.CallingTxt;
            parameters[13].Value = model.SmallCallingTxt;
            parameters[14].Value = model.CityTxt;
            parameters[15].Value = model.Title;
            parameters[16].Value = model.ValidateTerm;
            parameters[17].Value = model.ItemCount;
            parameters[18].Value = model.ID;
            parameters[19].Value = model.currency;
            parameters[20].Value = model.CooperationDemandTypeID;
            //----------------------------2010-06新增字段-------------------------------
            parameters[21].Value = model.StageForenterpriseDevelop;
            parameters[22].Value = model.FinancingObject;
            parameters[23].Value = model.Trade;

            int rowsAffected = 0;
            DbHelperSQL.RunProcedure("CustomInfoTab_Update", parameters, out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{

			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
			parameters[0].Value = ID;  
            DbHelperSQL.RunProcedure("CustomInfoTab_Delete", parameters, out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tz888.Model.CustomInfoModel GetModel(int ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
			parameters[0].Value = ID;
            Tz888.Model.CustomInfoModel model = new Tz888.Model.CustomInfoModel();

			DataSet ds= DbHelperSQL.RunProcedure("UP_CustomInfoTab_GetModel",parameters,"ds");
			model.ID=ID;
			if(ds.Tables[0].Rows.Count>0)
			{
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.LoginName=ds.Tables[0].Rows[0]["LoginName"].ToString();
				if(ds.Tables[0].Rows[0]["Accept"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Accept"].ToString()=="1")||(ds.Tables[0].Rows[0]["Accept"].ToString().ToLower()=="true"))
					{
						model.Accept=true;
					}
					else
					{
						model.Accept=false;
					}
				}

				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				if(ds.Tables[0].Rows[0]["CustomCyc"].ToString()!="")
				{
					model.CustomCyc=int.Parse(ds.Tables[0].Rows[0]["CustomCyc"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CustomType"].ToString()!="")
				{
					model.CustomType=int.Parse(ds.Tables[0].Rows[0]["CustomType"].ToString());
				}
				model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				model.Genre=ds.Tables[0].Rows[0]["Genre"].ToString();
				model.Money=ds.Tables[0].Rows[0]["Money"].ToString();
				model.Calling=ds.Tables[0].Rows[0]["Calling"].ToString();
				model.CallingTxt=ds.Tables[0].Rows[0]["CallingTxt"].ToString();
				model.SmallCalling=ds.Tables[0].Rows[0]["SmallCalling"].ToString();
				model.SmallCallingTxt=ds.Tables[0].Rows[0]["SmallCallingTxt"].ToString();
				model.City=ds.Tables[0].Rows[0]["City"].ToString();
				model.CityTxt=ds.Tables[0].Rows[0]["CityTxt"].ToString();
				model.Keyword=ds.Tables[0].Rows[0]["Keyword"].ToString();
				if(ds.Tables[0].Rows[0]["ValidateTerm"].ToString()!="")
				{
					model.ValidateTerm=int.Parse(ds.Tables[0].Rows[0]["ValidateTerm"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ItemCount"].ToString()!="")
				{
					model.ItemCount=int.Parse(ds.Tables[0].Rows[0]["ItemCount"].ToString());
				}
                //201006新增字段
                if (ds.Tables[0].Rows[0]["StageForenterpriseDevelop"].ToString() != "")
                {
                    model.StageForenterpriseDevelop = ds.Tables[0].Rows[0]["StageForenterpriseDevelop"].ToString();
                }
                if (ds.Tables[0].Rows[0]["financingObject"].ToString() != "")
                {
                    model.FinancingObject = ds.Tables[0].Rows[0]["financingObject"].ToString();
                }
                if (ds.Tables[0].Rows[0]["trade"].ToString() != "")
                {
                    model.Trade = ds.Tables[0].Rows[0]["trade"].ToString();
                }
                
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获取数据列表
		/// </summary>
		public DataSet GetList()
		{
            return null;
			//return DbHelperSQL.RunProcedure("UP_CustomInfoTab_GetList",parameters,"ds");
		}

		#endregion  成员方法
	}
}