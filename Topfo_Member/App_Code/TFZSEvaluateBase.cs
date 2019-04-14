using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// TFZSEvaluateBase 的摘要说明
/// </summary>
public class TFZSEvaluateBase : System.Web.UI.UserControl
{
    private long _infoID = 0;

    public long InfoID
    {
        get
        {
            _infoID = Convert.ToInt64(this.ViewState["InfoID"]);
            return _infoID;
        }
        set
        {
            _infoID = value;
            this.ViewState["InfoID"] = _infoID;
        }
    }
    public virtual decimal GetEvaluate()
    {
        return 0;
    }

    public virtual decimal SaveEvaluate()
    {
        return 0;
    }
}
