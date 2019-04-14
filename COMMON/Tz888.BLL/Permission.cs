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

        #region �˵�(ҳ��)Ȩ�޿���

        /// <summary>
        /// ��ȡ���в˵���,���洦��
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
        /// ��ȡ��һ���Ĳ˵�(������)
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
        /// ��ȡ��һ���Ĳ˵�,����ָ����ɫ(������) 
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
        /// ��ȡ���в˵�Ȩ����,���洦��
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
        /// ��Ա�������Ƿ���ĳ��ҳ��/�˵��ķ���Ȩ��
        /// </summary>
        /// <param name="memberType">��Ա���������</param>
        /// <param name="menuCode">�˵�(ҳ��)����</param>
        /// <returns>��Ȩ���򷵻�true</returns>
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
        /// ��Ա�������Ƿ���ĳ��ҳ��/�˵��ķ���Ȩ��
        /// </summary>
        /// <param name="memberType">��Ա���������</param>
        /// <param name="pageUrl">ҳ��URL,û�������ľ��Ե�ַ</param>
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
        /// ��ȡҳ��URL��Ӧ�Ĳ˵�(ҳ�����)
        /// </summary>
        /// <param name="pageUrl">ҳ��URL,û�������ľ��Ե�ַ</param>
        /// <returns>���������,�򷵻�null,���򷵻ز˵�(ҳ��)����</returns>
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

        #region ��Ա����Ȩ�޿���

        /// <summary>
        /// ��ȡ���й���Ȩ����,���洦��
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
        /// ��Ա�������Ƿ���ĳ�����ܵķ���Ȩ��
        /// </summary>
        /// <param name="memberType">��Ա���������</param>
        /// <param name="powerCode">���������</param>
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
        /// ��Ա������ӵ��ĳ��ܵ�ʹ�÷�Χ(�����ȵ���isPowerPermited�ж��Ƿ���Ȩ��)
        /// </summary>
        /// <param name="memberType">��Ա���������</param>
        /// <param name="powerCode">���������</param>
        /// <returns>-1��ʾû��Ȩ��,0��ʾû������,����Ϊint����ֵ</returns>
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
        /// ��Ա������ӵ��ĳ��ܵ�ʹ�÷�Χ(ֱ��ȡֵ,������isPowerPermited�ж��Ƿ�ӵ��Ȩ��)
        /// </summary>
        /// <param name="memberType">��Ա���������</param>
        /// <param name="powerCode">���������</param>
        /// <returns>0��ʾû������,����Ϊint����ֵ</returns>
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
