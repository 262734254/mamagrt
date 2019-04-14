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

public partial class Manage_MatchInfoList : System.Web.UI.UserControl
{
    private long _infoID = 0;

    public long InfoID
    {
       set { _infoID = value; }
    }
    private string _matchType = "";

    public string MatchType
    {
        set { _matchType = value; }
    }

    protected string wwwdomain;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.wwwdomain = Tz888.Common.Common.GetWWWDomain();
        if(this._infoID != 0 && this._matchType != "")
        {
            this.BindData();
            this.btnMore.PostBackUrl = "./PertinentMoreLink.aspx?id=" + this._infoID + "&type=" + this._matchType;
        } 
    }

    protected string GetValiditeInfo(object time)
    {
        DateTime dt = new DateTime();
        string request = "";
        try
        {
            dt = Convert.ToDateTime(time);
            request = "有效期至:" + dt.ToString("yyyy-MM-dd hh:mm:ss");
        }
        catch
        {
            request = "未设置有效期";
        }
        return request;
    }

    private void BindData()
    {
        Tz888.BLL.Info.MatchInfoBLL bll = new Tz888.BLL.Info.MatchInfoBLL();
        long intCurrentPage = 1;                   
        long intCurrentPageSize = 5;
        long intTotalCount = 5;
        this.RfInfo.DataSource = bll.GetMatchList(this._matchType, this._infoID, "*", "", "PublishT Desc,InfoID DESC", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);
        this.RfInfo.DataBind();
        DataView dv = new DataView();
       dv = bll.GetMatchList(this._matchType, this._infoID, "*", "", "PublishT Desc,InfoID DESC", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);
    
    }

    protected string GetTitle()
    {
        string title = "";
        switch (this._matchType)
        {
            case "MC":
            case "PC":
                title = "相关投资资源";
                break;
            case "CM":
            case "PM":
                title = "相关招商资源";
                break;
            case "MP":
            case "CP":
                title = "相关融资资源";
                break;
            default:
                title = "相关资源";
                break;
        }
        return title;
    }


    /// <summary>
    /// 获取所属行业
    /// </summary>
    /// <param name="industry"></param>
    /// <returns></returns>
    protected string GetIndustry(object industry)
    { 
         string ReValue="";
         Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        // DataTable dt = dal.GetList("dicttab", "*", "idictvalue", 10, 1, 0, 0, " cdicttype='jgtdgm' ");

         string Indu = Tz888.Common.Text.FormatDh(industry.ToString(), ",");
       // Response.Write(Indu);
        Indu = Indu.Replace(",", "','");
         
         DataTable dt = new DataTable();
         dt = dal.GetList("SetIndustryBTab", "*", "Sort", 30, 1, 0, 0, "industryBID in ('" + Indu + "')");
         for (int i = 0; i < dt.Rows.Count - 1; i++)
         {
           ReValue+=dt.Rows[i]["industryBName"].ToString()+" ";
             
         }
         return ReValue;
   
       
    }
    /// <summary>
    /// 获取地区
    /// </summary>
    /// <param name="country"></param>
    /// <returns></returns>
    protected string GetCounty(object county)
    {
        string ReCounty = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = new DataTable();

        dt = dal.GetList("SetProvinceTab", "*", "ProvinceID", 10, 1, 0, 0, "ProvinceID='"+county + "'");
        for(int i=0;i<dt.Rows.Count;i++)
        {
            ReCounty = dt.Rows[i]["ProvinceName"].ToString()+" ";
        }

        return ReCounty;
    }

    /// <summary>
    /// 是否认证
    /// </summary>
    /// <param name="renZheng"></param>
    /// <returns></returns>
    protected string GetRenZheng(object renZheng)

    {
        string ReRenzheng = "";

        if (renZheng.ToString() == "1")
            return ReRenzheng = "已认证";
        else
            return ReRenzheng = "未认证";
    }

    /// <summary>
    /// 资源对比
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kk = "";
        CheckBox cb = new CheckBox();
        //HtmlInputHidden id;
        string id;
        for (int rowindex = 0; rowindex < this.RfInfo.Items.Count; rowindex++)
        {
            cb = (CheckBox)this.RfInfo.Items[rowindex].FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                id = ((HtmlInputHidden)RfInfo.Items[rowindex].FindControl("txtID")).Value.ToString();
               
                kk +=id.ToString()+",";
            }

        }
      
        
        //跨域的对比
        if (kk.Trim().Length > 0)
        {   
            kk = kk.Substring(0, kk.Length - 1);
            // Response.Redirect("#?id=" + kk);
            Response.Redirect("http://search.topfo.com/compare/compare_Capital.aspx?InfoID=," + kk);

        }
    }

    /// <summary>
    /// 购物车GetCount
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnGouWuCar_Click(object sender, EventArgs e)
    {
        string kk = "";
        CheckBox cb = new CheckBox();
       // HtmlInputHidden id;
        string id;
        for (int rowindex = 0; rowindex < this.RfInfo.Items.Count; rowindex++)
        {
            cb = (CheckBox)this.RfInfo.Items[rowindex].FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                id = ((HtmlInputHidden)RfInfo.Items[rowindex].FindControl("txtID")).Value.ToString();
                kk += id.ToString() + ",";
            }

        }
        if (kk.Trim().Length > 0)
        {
            Response.Redirect("http://member.topfo.com/payManage/ShopCarMany.aspx?InfoIDList="+kk);
           // http://member.topfo.com/payManage/ShopCarMany.aspx?InfoIDList=1372966,1343327,

        }
    }
    /// <summary>
    /// 马上购买
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnQGou_Click(object sender, EventArgs e)
    {

        string kk ="";
        CheckBox cb = new CheckBox();
        //HtmlInputHidden id;
        string id;
        for (int rowindex = 0; rowindex < this.RfInfo.Items.Count; rowindex++)
        {
            cb = (CheckBox)this.RfInfo.Items[rowindex].FindControl("CheckBox1");
            if (cb.Checked == true)
            {
                id = ((HtmlInputHidden)RfInfo.Items[rowindex].FindControl("txtID")).Value.ToString();
                kk += id.ToString() + ",";
            }

        }
        if (kk.Trim().Length > 0)
        { 
        Response.Redirect("http://pay.topfo.com/account/Lotaccountpay.aspx?order_no=" + kk); 
        }
    }
}
