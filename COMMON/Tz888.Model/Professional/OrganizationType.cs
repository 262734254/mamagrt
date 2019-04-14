using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Professional
{
    public class OrganizationType
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int orderId;
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
    }
}
