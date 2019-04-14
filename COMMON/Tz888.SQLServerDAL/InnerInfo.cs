using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 数据访问类InnerInfo 。
    /// </summary>
    public class InnerInfo : IInnerInfo
    {
        private Tz888.SQLServerDAL.Conn coon;                //数据库连接对象
        public InnerInfo()
        {
            coon = new Conn();
        }

        #region 收件箱成员方法
        //逻辑（虚）删除操作     
        public bool InfoReceivedTabVirtualDelete(string LoginName, int ReceivedID)
        {
            bool bl = false;

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
											new SqlParameter("@ReceivedID",SqlDbType.Int),				//站内信息ID
											
			};

            parameters[0].Value = LoginName;
            parameters[1].Value = ReceivedID;
            try
            {
                bl = DbHelperSQL.RunProcLob("InnerInfoReceivedTab_VirtualDelete", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
              //  DbHelperSQL..CloseCn();
            }
            return bl;
        }
        // 取收件箱内信息       
        public Tz888.Model.InnerInfoReceived ReadInfo(int ReceivedID)
        {
            Tz888.Model.InnerInfoReceived model = new Tz888.Model.InnerInfoReceived();
            DataSet ds = null;
            SqlParameter[] parameters = {
											new SqlParameter("@ReceivedID",SqlDbType.Int)
			};

            parameters[0].Value = ReceivedID;
            try
            {
               

                ds = DbHelperSQL.RunProcedure("InnerInfoReceivedTabReaded", parameters, "dt");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["SendID"].ToString() != "")
                    {
                        model.SendID = int.Parse(ds.Tables[0].Rows[0]["SendID"].ToString());
                    }
                    model.ReceivedName = ds.Tables[0].Rows[0]["ReceivedName"].ToString();
                    model.Topic = ds.Tables[0].Rows[0]["Topic"].ToString();
                    model.Context = ds.Tables[0].Rows[0]["Context"].ToString();
                    if (ds.Tables[0].Rows[0]["Size"].ToString() != "")
                    {
                        model.Size = int.Parse(ds.Tables[0].Rows[0]["Size"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["IsReaded"].ToString() != "")
                    {
                        model.IsReaded = int.Parse(ds.Tables[0].Rows[0]["IsReaded"].ToString());
                    }
                    model.SendedMan = ds.Tables[0].Rows[0]["SendedMan"].ToString();
                    if (ds.Tables[0].Rows[0]["ReceivedTime"].ToString() != "")
                    {

                        model.ReceivedTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReceivedTime"].ToString());
                    }
                    model.ChangeBy = ds.Tables[0].Rows[0]["ChangeBy"].ToString();
                    if (ds.Tables[0].Rows[0]["ChangeTime"].ToString() != "")
                    {

                        model.ChangeTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChangeTime"].ToString());
                    }                    
                }
            }
            catch (Exception err)
            {
                throw err;
            }          
            return model;          	
        }
        #endregion

        #region 发送信息
        //执行发送信息
        public bool SendInfo(Tz888.Model.InnerInfoSend model)
        {

            bool bl = false;

            SqlParameter[] parameters = {
											
											new SqlParameter("@LoginName",SqlDbType.Char,16),				
											new SqlParameter("@ReceivedMan",SqlDbType.Char,16),				
											new SqlParameter("@Topic",SqlDbType.VarChar,50),			
											new SqlParameter("@Context",SqlDbType.VarChar,-1),			
											new SqlParameter("@Size",SqlDbType.Int),
				                            new SqlParameter("@IsReaded",SqlDbType.Int),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),			
											new SqlParameter("@SendID",SqlDbType.Int),
			};

            parameters[0].Value = model.LoginName.Trim();
            parameters[1].Value = model.ReceivedMan.Trim();
            parameters[2].Value = model.Topic.Trim();
            parameters[3].Value = model.Context.Trim();
            parameters[4].Value = model.Topic.Length + model.Context.Length;
            parameters[5].Value = 0;
            parameters[6].Value = model.ChangeBy;
            parameters[7].Value = model.SendID;
            try
            {
                bl = DbHelperSQL.RunProcLob("InnerInfoSendTabNew", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
               
            }
            return bl;		
        }
          
        ////执行保存信息   
        //public bool SaveInfo(Tz888.Model.InnerInfoSend model)
        //{

        //    bool bl = false;

        //    SqlParameter[] parameters = {
        //                                    new SqlParameter("@SendID",SqlDbType.Int),
        //                                    new SqlParameter("@LoginName",SqlDbType.Char,16),
        //                                    new SqlParameter("@ReceivedMan",SqlDbType.Char,16),					
        //                                    new SqlParameter("@Topic",SqlDbType.VarChar,50),			
        //                                    new SqlParameter("@Context",SqlDbType.Char,16),
        //                                    new SqlParameter("@Size",SqlDbType.Int),
        //                                    new SqlParameter("@IsReaded",SqlDbType.Int),
        //                                    new SqlParameter("@ChangeBy",SqlDbType.Char,16)
        //    };

        //    parameters[0].Value = this.SendID;
        //    parameters[1].Value = this.LoginName.ToString().Trim();
        //    parameters[2].Value = this.ReceivedMan.ToString().Trim();
        //    parameters[3].Value = this.Topic.ToString().Trim();
        //    parameters[4].Value = this.Context;
        //    parameters[5].Value = this.Size;
        //    parameters[6].Value = this.LoginName;
        //    try
        //    {
        //        bl = DbHelperSQL.RunProcedure("InnerInfoSendTabNew", parameters, "ds");
        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //    finally
        //    {
              
        //    }
        //    return bl;		
        //}
        #endregion
         
        #region 我发出的信息
        //逻辑（虚）删除操作
        public bool InfoSendTabVirtualDelete(string LoginName, int SendID)
        {
            bool bl = false;

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
											new SqlParameter("@SendID",SqlDbType.Int),				//站内信息ID
											
										};

            parameters[0].Value = LoginName;
            parameters[1].Value = SendID;
            try
            {
                bl = DbHelperSQL.RunProcLob("InnerInfoSendTab_VirtualDelete", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
               
            }
            return bl;
        }
        #endregion

        #region 垃圾箱
        //执行物理删除操作(选中信息) 
        public bool DeleteWasterInfo(int WasterID)
        {
            bool bl = false;

            SqlParameter[] parameters = { 
											new SqlParameter("@WasterID",SqlDbType.Int),				//站内信息ID
											
			};
            parameters[0].Value = WasterID;
            try
            {
                bl = DbHelperSQL.RunProcLob("InnerInfoWasterTab_Delete", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
               
            }
            return bl;
        }
        //清空废件箱（全部） 
        public bool DeleteAllWasterInfo(string LoginName)
        {
            bool bl = false;

            SqlParameter[] parameters = { 
											new SqlParameter("@LoginName",SqlDbType.VarChar,50),
											new SqlParameter("@flag",SqlDbType.VarChar,100),
								
											
			};
            parameters[0].Value = LoginName;
            parameters[1].Value = "DeleteAll";
            try
            {
                bl = DbHelperSQL.RunProcLob("InnerInfoWasterTab_Delete", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
               
            }
            return bl;
        }

        #endregion

        #region 共用方法

        //取一条信息 
        //public Tz888.Model.InnerInfoWaster GetWasterInfo(string tblName, string strGetFields, string fldName,
        //    int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        //{
        //    Tz888.Model.InnerInfoWaster model = new Tz888.Model.InnerInfoWaster();

        //    DataTable dt = coon.GetList(conn.GetList(
        //           tblName,
        //           strGetFields,
        //           fldName,
        //           PageSize,
        //           PageIndex,
        //           doCount,
        //           OrderType,
        //           strWhere));

        //    if (dtTables[0].Rows.Count > 0)
        //    {
        //        model.WasterID = dt.Rows[0]["WasterID"].ToString();
        //        model.LoginName = dt.Rows[0]["LoginName"].ToString();
        //        model.Topic = dt.Rows[0]["Topic"].ToString();
        //        model.Context = dt.Rows[0]["Context"].ToString();
        //        if (dt.Rows[0]["Size"].ToString() != "")
        //        {
        //            model.Size = int.Parse(dt.Rows[0]["Size"].ToString());
        //        }
        //        model.SendedMan = dt.Rows[0]["SendedMan"].ToString();
        //        model.ReceivedMan = dt.Rows[0]["ReceivedMan"].ToString();
        //        if (dt.Rows[0]["TimeStatus"].ToString() != "")
        //        {

        //            model.TimeStatus = DateTime.Parse(dt.Rows[0]["TimeStatus"].ToString());
        //        }
        //        model.ChangeBy = dt.Rows[0]["ChangeBy"].ToString();
        //        if (dt.Rows[0]["ChangeTime"].ToString() != "")
        //        {

        //            model.ChangeTime = DateTime.Parse(dt.Rows[0]["ChangeTime"].ToString());
        //        }
        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        // 得到站内信息列表 
        public DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return (coon.GetList (      
                   tblName, 
                   strGetFields,
                   fldName, 
                   PageSize, 
                   PageIndex, 
                   doCount, 
                   OrderType, 
                   strWhere));
        }      
        #endregion 

        #region  sunray方法
        public bool InfoVirtualDelete(string LoginName, int InfoID,int TableType,string flag)
        {
            string procName = "";    
            bool result = false;
            string sqlPar1 = "@LoginName";
            string sqlPar2 = "@ReceivedID";
            string sqlPar3 = "@flag";
            int parNum = 2;
            switch (TableType)
            {
                case 0:
                    procName = "InnerInfoReceivedTab_VirtualDelete";
                    sqlPar1 = "@LoginName";
                    sqlPar2 = "@ReceivedID";
                    parNum = 2;

                    break;
                case 1:
                    procName = "InnerInfoSendTab_VirtualDelete";
                    sqlPar1 = "@LoginName";
                    sqlPar2 = "@SendID";
                    parNum = 2;

                    break;
                case 2:
                    procName = "InnerInfoWasterTab_Delete";
/*                    SqlParameter[] parameters = { 
										            new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
										            new SqlParameter("@WasterID",SqlDbType.Int),				//站内信息ID
            										
		            };
*/
                    sqlPar1 = "@LoginName";
                    sqlPar2 = "@WasterID";
                    sqlPar3 = "@flag";
                    parNum = 3;

                    break;
                default:
                    break;
            }

            if (parNum == 2)
            {
                SqlParameter[] parameters = { 
										            new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
										            new SqlParameter(sqlPar2,SqlDbType.Int),				//站内信息ID
            										
		            };

                parameters[0].Value = LoginName;
                parameters[1].Value = InfoID;
                try
                {
                    result = DbHelperSQL.RunProcLob(procName, parameters);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                }
            }
            else
            {
                SqlParameter[] parameters = { 
										            new SqlParameter("@LoginName",SqlDbType.Char,16),				//--登录名
										            new SqlParameter("@WasterID",SqlDbType.Int),				//站内信息ID
                                                    new SqlParameter("@flag",SqlDbType.Char,100),
            										
		            };

                parameters[0].Value = LoginName;
                parameters[1].Value = InfoID;
                parameters[2].Value = flag;
                try
                {
                    result = DbHelperSQL.RunProcLob(procName, parameters);
                }
                catch (Exception err)
                {
                    throw err;
                }
                finally
                {
                }
            }

            return result;
        }
        public bool ReadInfoSet(int InfoID)   
        {
            bool result = false;
            SqlParameter[] parameters = {
											new SqlParameter("@ReceivedID",SqlDbType.Int)
			};
            parameters[0].Value = InfoID;
            try
            {
                result=DbHelperSQL.RunProcLob("InnerInfoReceivedTabReaded",parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
            return result;
        }
        public bool SendInfoIDAL(Tz888.Model.InnerInfo model)
        {

            bool result = false;

            SqlParameter[] parameters = {
											
											new SqlParameter("@LoginName",SqlDbType.Char,16),				
											new SqlParameter("@ReceivedMan",SqlDbType.Char,16),				
											new SqlParameter("@Topic",SqlDbType.VarChar,50),			
											new SqlParameter("@Context",SqlDbType.VarChar,-1),			
											new SqlParameter("@Size",SqlDbType.Int),
			//	                            new SqlParameter("@IsReaded",SqlDbType.Int),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),			
											new SqlParameter("@SendID",SqlDbType.Int),
                                            new SqlParameter("@MessageID",SqlDbType.Int),
			};
            parameters[0].Value = model.SendName.Trim();
            parameters[1].Value = model.ReceiveName.Trim();
            parameters[2].Value = model.Topic.Trim();
            parameters[3].Value = model.Context.Trim();
            parameters[4].Value = model.Topic.Length + model.Context.Length;
 //           parameters[5].Value = 0;
            parameters[5].Value = model.ChangeBy;
            parameters[6].Value = 0;
            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoSendTabSend", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
               
            }
            return result;		
        }
        public bool SaveInfoIDAL(Tz888.Model.InnerInfo model)
        {
            bool result = false;

            SqlParameter[] parameters = {
											
											new SqlParameter("@LoginName",SqlDbType.Char,16),				
											new SqlParameter("@ReceivedMan",SqlDbType.Char,16),				
											new SqlParameter("@Topic",SqlDbType.VarChar,50),			
											new SqlParameter("@Context",SqlDbType.VarChar,-1),			
											new SqlParameter("@Size",SqlDbType.Int),
	//			                            new SqlParameter("@IsReaded",SqlDbType.Int),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),			
											new SqlParameter("@SendID",SqlDbType.Int),
                                            

			};

            parameters[0].Value = model.SendName.Trim();
            parameters[1].Value = model.ReceiveName.Trim();
            parameters[2].Value = model.Topic.Trim();
            parameters[3].Value = model.Context.Trim();
            parameters[4].Value = model.Topic.Length + model.Context.Length;
  //          parameters[5].Value = 0;
            parameters[5].Value = model.ChangeBy;
            parameters[6].Value = 0;
            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoSendTabSave", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        public Tz888.Model.InnerInfo GetInfoContext(int InfoId, int infoTable)
        {
            Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();
            DataTable dt = new DataTable();
            string tableName = "";
            string selectCondition = "";
            string selectValue="";
            switch (infoTable)
            {
                case 0: //收件箱
                    tableName = "InnerInfoReceivedTab";
                    selectCondition = "ReceivedId=" + InfoId;
                    dt = coon.GetList(tableName, "topic", "ReceivedId", 1, 1, 0, 1, selectCondition);
                    selectValue = dt.Rows[0][0].ToString();
                    if ((selectValue != null) && (selectValue != ""))
                    {
                        model.Topic = selectValue;
                    }
                    dt = coon.GetList(tableName, "SendedMan", "ReceivedId", 1, 1, 0, 1, selectCondition);
                    selectValue = dt.Rows[0][0].ToString();
                    if ((selectValue != null) && (selectValue != ""))
                    {
                        model.SendName = selectValue;
                    }
                    dt = coon.GetList(tableName, "ReceivedTime", "ReceivedId", 1, 1, 0, 1, selectCondition);
                    model.InfoTime = (DateTime)dt.Rows[0][0];
                    dt = coon.GetList(tableName, "Context", "ReceivedId", 1,1 , 0, 1, selectCondition);
                    selectValue=dt.Rows[0][0].ToString();
                    if ((selectValue != null) && (selectValue != ""))
                    {
                        model.Context = selectValue;
                    }
                    break;
                case 1: //发件箱                 
                    tableName = "InnerInfoSendTab";
                    selectCondition = "SendId=" + InfoId;
                    dt = coon.GetList(tableName, "ReceivedMan,topic,Context", "ReceivedId", 1, 1, 0, 1, selectCondition);
                    if((dt!=null)&&(dt.Rows.Count!=0))
                    {
                        model.ReceiveName = dt.Rows[0][0].ToString();
                        model.Topic = dt.Rows[0][1].ToString();
                        model.Context = dt.Rows[0][2].ToString();
                    }
                    break;
                case 2://垃圾箱信息               
                    tableName = "InnerInfoWasterTab";
                    selectCondition = "wasterId=" + InfoId;
                    dt = coon.GetList(tableName, "ReceivedMan,topic,Context,SendedMan", "wasterId", 1, 1, 0, 1, selectCondition);
                    if ((dt != null) && (dt.Rows.Count != 0))
                    {
                        model.ReceiveName = dt.Rows[0][0].ToString();
                        model.Topic = dt.Rows[0][1].ToString();
                        model.Context = dt.Rows[0][2].ToString();
                        model.SendName = dt.Rows[0][3].ToString();
                    }
                    break;
                default:
                    tableName="";
                    break;
            }
            return model;
        }
        #endregion

        #region 好友列表
        public DataTable getFriends(string loginName)
        {
            string selectCondition = "loginName='" + loginName+"'";
            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            return obj.GetList("InnerInfoContactTab", "*", "ContactId", 10, 1, 0, 1, selectCondition);
        }
        #endregion 

        #region 获取所有短信群组
        public DataSet GetMsgGroup()
        {
            string SqlText = "Select * from GroupTab";
            return DbHelperSQL.Query(SqlText);
        }
        #endregion

        #region 短信群组发送

        public int SendMsgToGroup(int ReceivedGroupID, string CONTEXT,string Topic, bool isRead, bool isSent, string SendName, DateTime ReceiveTime, string readName, DateTime Created, string Createby)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
                                        new SqlParameter("@MessageID",SqlDbType.Int),
										new SqlParameter("@ReceivedGroupID",SqlDbType.Int,4),
										new SqlParameter("@CONTEXT",SqlDbType.VarChar,-1),
										new SqlParameter("@isRead",SqlDbType.Bit),
										new SqlParameter("@isSent",SqlDbType.Bit),
										new SqlParameter("@SendName",SqlDbType.VarChar,16),
			                            new SqlParameter("@ReceiveTime",SqlDbType.DateTime),
                                        new SqlParameter("@readName",SqlDbType.VarChar,16),
										new SqlParameter("@Created",SqlDbType.DateTime),
                                        new SqlParameter("@Createby",SqlDbType.VarChar,16),
                                        new SqlParameter("@Topic",SqlDbType.VarChar,40)
			};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = ReceivedGroupID;
            parameters[2].Value = CONTEXT;
            parameters[3].Value = isRead;
            parameters[4].Value = isSent;
            parameters[5].Value = SendName;
            parameters[6].Value = ReceiveTime;
            parameters[7].Value = readName;
            parameters[8].Value = Created;
            parameters[9].Value = Createby;
            parameters[10].Value = Topic;

            DbHelperSQL.RunProcedure("InnerInfoGroupMessageTab_Insert", parameters, out rowsAffected);

            return (int)parameters[0].Value;

        }
        #endregion

        #region 获取会员的群组信息
        public DataSet GetGroupMessage(string loginName, bool IsAll)
        {
            SqlParameter[] parameters = {
                                        new SqlParameter("@LoginName",SqlDbType.VarChar,20),
                                        new SqlParameter("@IsAll",SqlDbType.Bit)
			};
            parameters[0].Value = loginName;
            parameters[1].Value = IsAll;

            return DbHelperSQL.RunProcedure("InnerInfo_GetGroupMessage", parameters, "ds");
        }

        public bool SendInfoWithGroupCheck(Tz888.Model.InnerInfo model,int MessageID)
        {
            bool result = false;
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName",SqlDbType.Char,16),				
											new SqlParameter("@ReceivedMan",SqlDbType.Char,16),				
											new SqlParameter("@Topic",SqlDbType.VarChar,50),			
											new SqlParameter("@Context",SqlDbType.VarChar,-1),			
											new SqlParameter("@Size",SqlDbType.Int),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),			
											new SqlParameter("@SendID",SqlDbType.Int),
                                            new SqlParameter("@MessageID",SqlDbType.Int),
			};
            parameters[0].Value = model.SendName.Trim();
            parameters[1].Value = model.ReceiveName.Trim();
            parameters[2].Value = model.Topic.Trim();
            parameters[3].Value = model.Context.Trim();
            parameters[4].Value = model.Topic.Length + model.Context.Length;
            parameters[5].Value = model.ChangeBy;
            parameters[6].Value = 0;
            parameters[7].Value = MessageID;
            try
            {
                result = DbHelperSQL.RunProcLob("InnerInfoSendTabSend", parameters);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {

            }
            return result;
        }
        #endregion

        #region 接收新的群发信息
        public void CheckNewGroupMsg(string loginName)
        {
            DataSet ds = this.GetGroupMessage(loginName, false);
            if (ds == null && ds.Tables["ds"].Rows.Count == 0)
                return;

            for (int i = 0; i < ds.Tables["ds"].Rows.Count; i++)
            {
                string SendName = ds.Tables["ds"].Rows[i]["SendName"].ToString().Trim();
                string Topic = ds.Tables["ds"].Rows[i]["Topic"].ToString().Trim();
                string Context = ds.Tables["ds"].Rows[i]["Context"].ToString().Trim();
                string CreateBy = ds.Tables["ds"].Rows[i]["CreateBy"].ToString().Trim();
                int MessageID = Convert.ToInt32(ds.Tables["ds"].Rows[i]["MessageID"]);

                Tz888.Model.InnerInfo model = new Tz888.Model.InnerInfo();

                model.SendName = SendName;
                model.ReceiveName = loginName;
                model.Topic = Topic;
                model.Context = Context;
                model.ChangeBy = CreateBy;

                this.SendInfoWithGroupCheck(model, MessageID);
            }
        }
        #endregion
    }
}

