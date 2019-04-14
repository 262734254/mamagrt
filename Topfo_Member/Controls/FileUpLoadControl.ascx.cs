using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Tz888.Member.Controls
{
    public partial class FileUpLoadControl : System.Web.UI.UserControl
    {
        private long _infoID = -1;

        public long InfoID
        {
            get { return _infoID; }
            set { _infoID = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
