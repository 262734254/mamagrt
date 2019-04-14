using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model;

namespace Tz888.IDAL
{
    public interface IMemberInfo
    {
        DataView GetMemberInfoByLoginName(string LoginName);


        /// <summary>
        /// Get information on a specific item
        /// </summary>
        /// <param name="itemId">Unique identifier for an item</param>
        /// <returns>Business Entity representing an item</returns>

        MemberManageInfo objGetMemberInfoByLoginName(string LoginName);
        void DeleleMember(string loginName);
    }
}
