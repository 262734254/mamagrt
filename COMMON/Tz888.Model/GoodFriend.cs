using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class GoodFriend
    {
        private string _loginName;
        private string _contactName;
        private int _groupId;
        private int _contactId;
        private string _addressFrom;
        private DateTime _time;
        private string _reflashInfo;//更新信息


        private int _memberGrade;
        private int _memberType;
        private int _memberIntent;

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public int ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }




        public string AddressFrom
        {
            get { return _addressFrom; }
            set { _addressFrom = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string ReflashInfo
        {
            get { return _reflashInfo; }
            set { _reflashInfo = value; }
        }


        public int MemberGrade
        {
            get { return _memberGrade; }
            set { _memberGrade = value; }
        }
        public int MemberType
        {
            get { return _memberType; }
            set { _memberType = value; }
        }
        public int MemberIntent
        {
            get { return _memberIntent; }
            set { _memberIntent = value; }
        }
        
    }

}
