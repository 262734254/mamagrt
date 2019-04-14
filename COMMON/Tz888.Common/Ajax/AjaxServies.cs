using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Tz888.Common.Ajax
{

    [AjaxPro.AjaxNamespace("AjaxServies")]
  public   class AjaxServies
    {
        public AjaxServies()  { }
      
        [AjaxPro.AjaxMethod]
        public string GetServiesList()
        {
            Tz888.BLL.Union dal = new Tz888.BLL.Union();
            DataView dv = dal.GetServiesList(true);

            string str = "|--选择服务大类别--";
            if (dv == null)
                return str;
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                try
                {
                    str += "," + dv[m]["ServiesBID"].ToString().Trim() + "|" + dv[m]["ServiesBName"].ToString().Trim();
                }
                catch
                {
                }
            }
            return str;
        } 



        [AjaxPro.AjaxMethod]
        public string GetServiesMList(int BID)
        {
            Tz888.BLL.Union dal = new Tz888.BLL.Union();
            DataView dv = dal.GetServiesList(BID, true);

            string str = "|--选择服务小类别--";
            if (dv == null)
                return str;
            for (int m = 0; m < dv.Table.Rows.Count; m++)
            {
                try
                {
                    str += "," + dv[m]["ServiesMID"].ToString().Trim() + "|" + dv[m]["ServiesMName"].ToString().Trim();
                }
                catch
                {
                }
            }
            return str;
        }
    }
}
