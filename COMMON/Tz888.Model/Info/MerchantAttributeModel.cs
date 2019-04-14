using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class MerchantAttributeModel
    {
        private string _merchantAttributeID;
        private string _merchantAttributeName;

        public string MerchantAttributeID
        {
            get { return _merchantAttributeID; }
            set { _merchantAttributeID = value; }
        }

        public string MerchantAttributeName
        {
            get { return _merchantAttributeName; }
            set { _merchantAttributeName = value; }
        }

        public MerchantAttributeModel(string merchantAttributeID, string merchantAttributeName)
        {
            this._merchantAttributeID = merchantAttributeID;
            this._merchantAttributeName = merchantAttributeName;
        }
    }
}
