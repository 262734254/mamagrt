using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IPermission
    {

        /// <summary>
        /// ��ȡ���в˵���
        /// </summary>
        DataTable GetAllMenu();

        /// <summary>
        /// ��ȡ���в˵�Ȩ����
        /// </summary>
        /// <returns></returns>
        DataTable GetMenuPermission();

        /// <summary>
        /// ��ȡ���й���Ȩ����
        /// </summary>
        /// <returns></returns>
        DataTable GetPowerPermission();
    }
}
