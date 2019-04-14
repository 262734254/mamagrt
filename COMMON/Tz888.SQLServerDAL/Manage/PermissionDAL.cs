using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DBUtility;
using Tz888.SQLServerDAL;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.Model;

namespace Tz888.SQLServerDAL.Manage
{
    public class PermissionDAL:IDAL.Manage.IPermission
    {
        #region --权限检验--
        public  bool Check(Tz888.Model.Manage.Permission model)
        {
            SqlParameter[] parameters = {	
											new SqlParameter("@LoginName",SqlDbType.Char,16),
											new SqlParameter("@WorkType",SqlDbType.Char,10),
											new SqlParameter("@InfoTypeID",SqlDbType.Char,10),
											new SqlParameter("@InfoPermissionTypeCode",SqlDbType.Char,10),
											new SqlParameter("@Value",SqlDbType.TinyInt)
										};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.WorkType;
            parameters[2].Value = model.InfoTypeId;
            parameters[3].Value = model.InfoPermissionTypeCode;

            parameters[4].Value = 0;
            parameters[4].Direction = System.Data.ParameterDirection.InputOutput;
            bool result=false;
            try
            {
                bool temp = DbHelperSQL.RunProcLob("PermissionTab_Set", parameters);
                result = Convert.ToBoolean(parameters[4].Value);
            }
            catch (System.Exception err)
            {
                throw err;
            }
            finally
            {
            }
            return result;
        }
        #endregion 
        #region 权限设置
        public bool PermissionSet(Tz888.Model.Manage.Permission model,int IsDelete)
        {
            try
            {
                SqlParameter[] parameters = {	
											new SqlParameter("@loginName",SqlDbType.Char,16),
                                            new SqlParameter("@roleGroup",SqlDbType.Char,10),
                                            new SqlParameter("@workType",SqlDbType.Char,10),
                                            new SqlParameter("@changeBy",SqlDbType.Char,16),
                                            new SqlParameter("@isDelete",SqlDbType.TinyInt)
									 
			                                };

                parameters[0].Value =model.LoginName;
                parameters[1].Value = model.RoleGroup;
                parameters[2].Value = model.WorkType;
                parameters[3].Value = model.ChangeBy;
                parameters[4].Value = IsDelete;
                bool result = DbHelperSQL.RunProcLob("PermissionTab_Assign", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }
        #endregion 

        #region 角色组

        #region 角色组添加
        public bool RoleGroupInsert(Tz888.Model.Manage.Permission model)
        {
            bool result = false;

            SqlParameter[] parameters = {	new SqlParameter("@RoleGroup",SqlDbType.Char,10),
											new SqlParameter("@RoleGroupName",SqlDbType.VarChar,50)
										};

            parameters[0].Value = model.RoleGroup;
            parameters[1].Value = model.RoleGroupName;


            try
            {
                result = DbHelperSQL.RunProcLob("SetRoleGroupTab_Insert", parameters);
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

        #region 角色组修改
        public bool RoleGroupUpdate(Tz888.Model.Manage.Permission model)
        {
            bool result = false;

            SqlParameter[] parameters = {	new SqlParameter("@RoleGroup",SqlDbType.Char,10),
											new SqlParameter("@RoleGroupName",SqlDbType.VarChar,50)
										};

            parameters[0].Value = model.RoleGroup;
            parameters[1].Value = model.RoleGroupName;


            try
            {
                result = DbHelperSQL.RunProcLob("SetRoleGroupTab_Update", parameters);
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

        #region 角色组删除
        public bool RoleGroupDelete(Tz888.Model.Manage.Permission model)
        {
            bool result = false;


            SqlParameter[] parameters = {	new SqlParameter("@RoleGroup",SqlDbType.Char,10)
										};

            parameters[0].Value = model.RoleGroup;


            try
            {
                result = DbHelperSQL.RunProcLob("SetRoleGroupTab_Delete", parameters);
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

        #endregion

        #region --角色--
        #region --角色添加--
        public bool WorkTypeAdd(Tz888.Model.Manage.Permission model)
        {            
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@WorkType",SqlDbType.Char,10),
											new SqlParameter("@WorkTypeName",SqlDbType.VarChar,50),
											new SqlParameter("@RoleGroup",SqlDbType.Char,10),
											new SqlParameter("@Active",SqlDbType.TinyInt),
											new SqlParameter("@Remark",SqlDbType.VarChar,50),
											new SqlParameter("@ChangeBy",SqlDbType.Char, 16)	
										};

                parameters[0].Value = model.WorkType;
                parameters[1].Value = model.WorkTypeName;
                parameters[2].Value = model.RoleGroup;
                parameters[3].Value = model.Active;
                parameters[4].Value = model.Remark;
                parameters[5].Value = model.ChangeBy;

                bool result = DbHelperSQL.RunProcLob("SetWorkTypeTab_Insert", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }
        #endregion

        #region --角色修改--
        public bool WorkTypeUpdate(Tz888.Model.Manage.Permission model)
        {
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@WorkType",SqlDbType.Char,10),
											new SqlParameter("@WorkTypeName",SqlDbType.VarChar,50),
											new SqlParameter("@RoleGroup",SqlDbType.Char,10),
											new SqlParameter("@Active",SqlDbType.TinyInt),
											new SqlParameter("@Remark",SqlDbType.VarChar,50),
											new SqlParameter("@ChangeBy",SqlDbType.Char, 16)	
										};

                parameters[0].Value = model.WorkType;
                parameters[1].Value = model.WorkTypeName;
                parameters[2].Value = model.RoleGroup;
                parameters[3].Value = model.Active;
                parameters[4].Value = model.Remark;
                parameters[5].Value = model.ChangeBy;

                bool result = DbHelperSQL.RunProcLob("SetWorkTypeTab_Update", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }
        #endregion

        #region --角色删除--
        public bool WorkTypeDelete(Tz888.Model.Manage.Permission model)
        {
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@WorkType",SqlDbType.Char,10)
	
										};
                parameters[0].Value = model.WorkType;

                bool result = DbHelperSQL.RunProcLob("SetWorkTypeTab_Delete", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }
        #endregion
        #endregion
        //菜单、系统设置
        public bool MeneSysTypeSet(Tz888.Model.Manage.Permission model)
        {
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@WorkType",SqlDbType.Char,10),
											new SqlParameter("@InfoTypeId",SqlDbType.Char,10),
											new SqlParameter("@Code",SqlDbType.Char,10),
											new SqlParameter("@Value",SqlDbType.TinyInt),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),
											new SqlParameter("@IsDelete",SqlDbType.TinyInt)	
										};

                parameters[0].Value = model.WorkType;
                parameters[1].Value = "";
                parameters[2].Value = model.MenuType;
                parameters[3].Value = model.Value;
                parameters[4].Value = model.ChangeBy;
                parameters[5].Value = model.IsDelete;

                bool result = DbHelperSQL.RunProcLob("PermissionTab_Set", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }

        //信息权限设置
        public bool InfoTypeSet(Tz888.Model.Manage.Permission model)
        {

            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@WorkType",SqlDbType.Char,10),
											new SqlParameter("@InfoTypeId",SqlDbType.Char,10),
											new SqlParameter("@Code",SqlDbType.Char,10),
											new SqlParameter("@Value",SqlDbType.TinyInt),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),
											new SqlParameter("@IsDelete",SqlDbType.TinyInt)	
										};

                parameters[0].Value = model.WorkType;
                parameters[1].Value = model.InfoTypeId;
                parameters[2].Value = model.InfoPermissionTypeCode;
                parameters[3].Value = model.Value;
                parameters[4].Value = model.ChangeBy;
                parameters[5].Value = model.IsDelete;

                bool result = DbHelperSQL.RunProcLob("PermissionTab_Set", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }

        #region --菜单--

        #region --删除--
        public bool MenuDelete(Tz888.Model.Manage.Permission model)
        {

            bool result = false;

            SqlParameter[] parameters = {	new SqlParameter("@MenuType",SqlDbType.Char,10),	
			};

            parameters[0].Value = model.MenuType;

            try
            {
                result = DbHelperSQL.RunProcLob("SetMenuTypeTab_Delete", parameters);
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
        #region-- 修改 ---
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool MenuUpdate(Tz888.Model.Manage.Permission model)
        {
            bool result = false;

            SqlParameter[] parameters = {	new SqlParameter("@MenuType",SqlDbType.Char,10),
											new SqlParameter("@MenuTypeName",SqlDbType.VarChar,50),
											new SqlParameter("@IsMenu",SqlDbType.TinyInt),
											new SqlParameter("@URL",SqlDbType.VarChar,250),
											new SqlParameter("@Remark",SqlDbType.VarChar,50),
											new SqlParameter("@Sequence",SqlDbType.Int),
											new SqlParameter("@Active",SqlDbType.TinyInt),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16)
										};

            parameters[0].Value = model.MenuType;
            parameters[1].Value = model.MenuTypeName;
            parameters[2].Value = model.IsMenu;
            parameters[3].Value = model.Url;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.MenuSequence;
            parameters[6].Value = model.Active;
            parameters[7].Value = model.ChangeBy;

            try
            {
                result = DbHelperSQL.RunProcLob("SetMenuTypeTab_Update", parameters);
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

        #region-- 添加 ---
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool MenuInsert(Tz888.Model.Manage.Permission model)
        {
            bool result = false;

            SqlParameter[] parameters = {	new SqlParameter("@MenuType",SqlDbType.Char,10),
											new SqlParameter("@MenuTypeName",SqlDbType.VarChar,50),
											new SqlParameter("@IsMenu",SqlDbType.TinyInt),
											new SqlParameter("@URL",SqlDbType.VarChar,250),
											new SqlParameter("@Remark",SqlDbType.VarChar,50),
											new SqlParameter("@Sequence",SqlDbType.Int),
											new SqlParameter("@Active",SqlDbType.TinyInt),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16)
										};

            parameters[0].Value = model.MenuType;
            parameters[1].Value = model.MenuTypeName;
            parameters[2].Value = model.IsMenu;
            parameters[3].Value = model.Url;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.MenuSequence;
            parameters[6].Value = model.Active;
            parameters[7].Value = model.ChangeBy;

            try
            {
                result = DbHelperSQL.RunProcLob("SetMenuTypeTab_Insert", parameters);
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

        #endregion

        #region --信息权限--
        public bool InfoPermissionUpdate(Tz888.Model.Manage.Permission model)
        {
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@InfoPermissionTypeCode",SqlDbType.Char,10),
											new SqlParameter("@InfoPermissionTypeName",SqlDbType.VarChar,50),
											new SqlParameter("@Remark",SqlDbType.VarChar,50),
											new SqlParameter("@Active",SqlDbType.TinyInt),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),											
										};

                parameters[0].Value = model.InfoPermissionType;
                parameters[1].Value = model.InfoPermissionTypeName;
                parameters[2].Value = model.Remark;
                parameters[3].Value = model.Active;
                parameters[4].Value = model.ChangeBy;

                bool result = DbHelperSQL.RunProcLob("SetInfoPermissionTypeTab_Update", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }

        public bool InfoPermissionInsert(Tz888.Model.Manage.Permission model)
        {
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@InfoPermissionTypeCode",SqlDbType.Char,10),
											new SqlParameter("@InfoPermissionTypeName",SqlDbType.VarChar,50),
											new SqlParameter("@Remark",SqlDbType.VarChar,50),
											new SqlParameter("@Active",SqlDbType.TinyInt),
											new SqlParameter("@ChangeBy",SqlDbType.Char,16),											
										};

                parameters[0].Value = model.InfoPermissionType;
                parameters[1].Value = model.InfoPermissionTypeName;
                parameters[2].Value = model.Remark;
                parameters[3].Value = model.Active;
                parameters[4].Value = model.ChangeBy;


                bool result = DbHelperSQL.RunProcLob("SetInfoPermissionTypeTab_Insert", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }

        public bool InfoPermissionDelete(Tz888.Model.Manage.Permission model)
        {
            try
            {
                SqlParameter[] parameters = {	new SqlParameter("@InfoPermissionTypeCode",SqlDbType.Char,10),	
			};

                parameters[0].Value = model.InfoPermissionType;

                bool result = DbHelperSQL.RunProcLob("SetInfoPermissionTypeTab_Delete", parameters);
                return result;
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
        }
        #endregion
    }
}
