using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class Permission
    {
        private static readonly IPermission dal = Tz888.DALFactory.DataAccess.CreatePermission();

        #region 菜单(页面)权限控制

        /// <summary>
        /// 获取所有菜单项,缓存处理
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMenu()
        {
            System.Web.Caching.Cache cache = HttpContext.Current.Cache;
            DataTable menus = cache["tz888_Member_Menus_Cache"] as DataTable;
            if (menus == null)
            {
                menus = dal.GetAllMenu();
                if (menus != null)
                    cache.Insert("tz888_Member_Menus_Cache", menus, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return menus;
        }


        /// <summary>
        /// 获取下一级的菜单(已排序)
        /// </summary>
        /// <param name="parentCode"></param>
        /// <returns></returns>

        public DataRow[] GetMenu(string parentCode, string sort)
        {
            DataRow[] drs = null;
            DataTable menus = GetAllMenu();
            if (menus != null)
            {
                drs = menus.Select("ParentCode='" + parentCode + "' and isActive=1", sort);
            }
            return drs;
        }
        /// <summary>
        /// 获取下一级的菜单,根据指定角色(已排序) 
        /// </summary>
        /// <param name="parentCode"></param>
        /// <param name="sort"></param>
        /// <param name="role"></param>
        /// <returns></returns>

        public DataRow[] GetMenu(string parentCode, string sort, string role)
        {
            DataRow[] drs = null;
            DataTable menus = GetAllMenu();
            if (menus != null)
            {
                drs = menus.Select("ParentCode='" + parentCode + "' and isActive=1 and remark like '%" + role + "%' ", sort);
            }
            return drs;
        }
        /// <summary>
        /// 获取所有菜单权限项,缓存处理
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenuPermission()
        {
            System.Web.Caching.Cache cache = HttpContext.Current.Cache;
            DataTable menuPermissions = cache["tz888_Member_MenuPermissions_Cache"] as DataTable;
            if (menuPermissions == null)
            {
                menuPermissions = dal.GetMenuPermission();
                if (menuPermissions != null)
                    cache.Insert("tz888_Member_MenuPermissions_Cache", menuPermissions, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return menuPermissions;
        }

        /// <summary>
        /// 会员所在组是否有某个页面/菜单的访问权限
        /// </summary>
        /// <param name="memberType">会员所在组编码</param>
        /// <param name="menuCode">菜单(页面)编码</param>
        /// <returns>有权限则返回true</returns>
        public bool isMenuPermited(string memberType, string menuCode)
        {
            bool isPermited = true;
            DataTable menuPermissions = GetMenuPermission();
            if (menuPermissions != null)
            {
                int count = menuPermissions.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (menuCode == menuPermissions.Rows[i]["MemberMenuCode"].ToString().Trim() && memberType == menuPermissions.Rows[i]["MembeTypeCode"].ToString().Trim())
                    {
                        if (menuPermissions.Rows[i]["IsPermited"].ToString().Trim() == "0")
                        {
                            isPermited = false;
                        }
                        break;
                    }
                }
            }
            return isPermited;
        }

        /// <summary>
        /// 会员所在组是否有某个页面/菜单的访问权限
        /// </summary>
        /// <param name="memberType">会员所在组编码</param>
        /// <param name="pageUrl">页面URL,没有域名的绝对地址</param>
        /// <returns></returns>
        public bool isUrlPermited(string memberType, string pageUrl)
        {

            bool isPermited = true;
            string menuCode = getMenuCodeFromUrl(pageUrl);
            if (menuCode != null && menuCode.Length > 0)
            {
                isPermited = isMenuPermited(memberType, menuCode);
            }
            return isPermited;
        }


        /// <summary>
        /// 获取页面URL对应的菜单(页面编码)
        /// </summary>
        /// <param name="pageUrl">页面URL,没有域名的绝对地址</param>
        /// <returns>如果不存在,则返回null,否则返回菜单(页面)编码</returns>
        private string getMenuCodeFromUrl(string pageUrl)
        {
            string menuCode = null;
            DataTable menus = GetAllMenu();
            if (menus != null)
            {
                int count = menus.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (menus.Rows[i]["Url"].ToString().Trim().ToLower().IndexOf(pageUrl.ToLower()) >= 0)
                    {
                        menuCode = menus.Rows[i]["MemberMenuCode"].ToString().Trim();
                        break;
                    }
                }
            }
            return menuCode;
        }

        #endregion

        #region 会员功能权限控制

        /// <summary>
        /// 获取所有功能权限项,缓存处理
        /// </summary>
        /// <returns></returns>
        public DataTable GetPowerPermission()
        {

            System.Web.Caching.Cache cache = HttpContext.Current.Cache;
            DataTable powerPermissions = cache["tz888_Member_PowerPermissions_Cache"] as DataTable;
            if (powerPermissions == null)
            {
                powerPermissions = dal.GetPowerPermission();
                if (powerPermissions != null)
                    cache.Insert("tz888_Member_PowerPermissions_Cache", powerPermissions, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            return powerPermissions;
        }

        /// <summary>
        /// 会员所在组是否有某个功能的访问权限
        /// </summary>
        /// <param name="memberType">会员所在组编码</param>
        /// <param name="powerCode">功能项编码</param>
        /// <returns></returns>
        public bool isPowerPermited(string memberType, string powerCode)
        {
            bool isPermited = true;
            DataTable powerPermissions = GetPowerPermission();
            if (powerPermissions != null)
            {
                int count = powerPermissions.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (powerCode == powerPermissions.Rows[i]["PowerCode"].ToString().Trim() && memberType == powerPermissions.Rows[i]["MembeTypeCode"].ToString().Trim())
                    {
                        if (powerPermissions.Rows[i]["IsPermited"].ToString().Trim() == "0")
                        {
                            isPermited = false;
                        }
                        break;
                    }
                }
            }
            return isPermited;
        }

        /// <summary>
        /// 会员所在组拥有某项功能的使用范围(将首先调用isPowerPermited判断是否有权限)
        /// </summary>
        /// <param name="memberType">会员所在组编码</param>
        /// <param name="powerCode">功能项编码</param>
        /// <returns>-1表示没有权限,0表示没有限制,其他为int返回值</returns>
        public int GetPowerPermitedValue(string memberType, string powerCode)
        {
            int permitValue = 0;
            DataTable powerPermissions = GetPowerPermission();
            if (powerPermissions != null)
            {
                int count = powerPermissions.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (powerCode == powerPermissions.Rows[i]["PowerCode"].ToString().Trim() && memberType == powerPermissions.Rows[i]["MembeTypeCode"].ToString().Trim())
                    {
                        if (powerPermissions.Rows[i]["IsPermited"].ToString().Trim() == "0")
                        {
                            permitValue = -1;
                        }
                        else
                        {
                            permitValue = Convert.ToInt32(powerPermissions.Rows[i]["Value"]);
                        }
                        break;
                    }
                }
            }
            return permitValue;
        }

        /// <summary>
        /// 会员所在组拥有某项功能的使用范围(直接取值,不调用isPowerPermited判断是否拥有权限)
        /// </summary>
        /// <param name="memberType">会员所在组编码</param>
        /// <param name="powerCode">功能项编码</param>
        /// <returns>0表示没有限制,其他为int返回值</returns>
        public int GetPermitedValue(string memberType, string powerCode)
        {
            int permitValue = 0;
            DataTable powerPermissions = GetPowerPermission();
            if (powerPermissions != null)
            {
                int count = powerPermissions.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (powerCode == powerPermissions.Rows[i]["PowerCode"].ToString().Trim() && memberType == powerPermissions.Rows[i]["MembeTypeCode"].ToString().Trim())
                    {
                        permitValue = Convert.ToInt32(powerPermissions.Rows[i]["Value"]);
                        break;
                    }
                }
            }
            return permitValue;
        }
        #endregion
    }
}
