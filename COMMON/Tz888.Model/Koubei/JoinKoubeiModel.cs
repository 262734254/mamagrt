using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Koubei
{
    /// <summary>
    /// 项目信息实体类
    /// </summary>
    public class JoinKoubeiModel
    {
        public JoinKoubeiModel()
        { }

        private long _join_ID;
        private string _join_InfoType;
        private long _join_InfoID;
        private string _join_URL;
        private int _join_Type;
        private string _join_CountyName;
        private int _join_AreaCode;
        private DateTime _join_StartTime;
        private DateTime _join_EndTime;
        private string _join_LinkMan;
        private string _join_Tel;
        private string _join_Tel2;
        private string _join_Email;
        private DateTime _join_AddTime;
        private int _join_State;
        //----
        private string _join_Content;
        private string _join_Title;
        //----
        private string _temp_partner_id;
        private string _temp_sign_key;
        private string _temp_category_id;
        private int _temp_debug;
        private string _temp_contact_person;
        private string _temp_contact_phone1;

        public long Join_ID
        {
            set { _join_ID = value; }
            get { return _join_ID; }
        }
        public string Join_InfoType
        {
            set { _join_InfoType = value; }
            get { return _join_InfoType; }
        }
        public long Join_InfoID
        {
            set { _join_InfoID = value; }
            get { return _join_InfoID; }
        }
        public string Join_URL
        {
            set { _join_URL = value; }
            get { return _join_URL; }
        }
        public int Join_Type
        {
            set { _join_Type = value; }
            get { return _join_Type; }
        }
        public string Join_CountyName
        {
            set { _join_CountyName = value; }
            get { return _join_CountyName; }
        }
        public int Join_AreaCode
        {
            set { _join_AreaCode = value; }
            get { return _join_AreaCode; }
        }
        public DateTime Join_StartTime
        {
            set { _join_StartTime = value; }
            get { return _join_StartTime; }
        }
        public DateTime Join_EndTime
        {
            set { _join_EndTime = value; }
            get { return _join_EndTime; }
        }
        public string Join_LinkMan
        {
            set { _join_LinkMan = value; }
            get { return _join_LinkMan; }
        }
        public string Join_Tel
        {
            set { _join_Tel = value; }
            get { return _join_Tel; }
        }
        public string Join_Tel2
        {
            set { _join_Tel2 = value; }
            get { return _join_Tel2; }
        }
        public string Join_Email
        {
            set { _join_Email = value; }
            get { return _join_Email; }
        }
        public DateTime Join_AddTime
        {
            set { _join_AddTime = value; }
            get { return _join_AddTime; }
        }
        public int Join_State
        {
            set { _join_State = value; }
            get { return _join_State; }
        }
        public string Join_Content
        {
            set { _join_Content = value; }
            get { return _join_Content; }
        }
        public string Join_Title
        {
            set { _join_Title = value; }
            get { return _join_Title; }
        }

        public string Temp_partner_id
        {
            set { _temp_partner_id = value; }
            get { return _temp_partner_id; }
        }
        public string Temp_sign_key
        {
            set { _temp_sign_key = value; }
            get { return _temp_sign_key; }
        }
        public string Temp_category_id
        {
            set { _temp_category_id = value; }
            get { return _temp_category_id; }
        }
        public int Temp_debug
        {
            set { _temp_debug = value; }
            get { return _temp_debug; }
        }
        public string Temp_contact_person
        {
            set { _temp_contact_person = value; }
            get { return _temp_contact_person; }
        }
        public string Temp_contact_phone1
        {
            set { _temp_contact_phone1 = value; }
            get { return _temp_contact_phone1; }
        }
    }
}
