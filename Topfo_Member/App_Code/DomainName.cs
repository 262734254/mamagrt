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
/// DomainName 的摘要说明
/// </summary>
public class DomainName 
{
    public DomainName()
    {
    }
    /// <summary>
    /// 支付二级域名
    /// </summary>
    /// <returns></returns>
    public static string PayDomain()
    {
        return ConfigurationManager.AppSettings["PayDomain"];
    }
    /// <summary>
    /// 会员中心二级域名
    /// </summary>
    /// <returns></returns>
    public static string VipDomain()
    {
        return ConfigurationManager.AppSettings["MemberDomain"];
    }
    /// <summary>
    /// 顶级域名
    /// </summary>
    /// <returns></returns>
    public static string SiteDomain()
    {
        return ConfigurationManager.AppSettings["Domain"];
    }
    
}
