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

public partial class Company_CompanyMadeView : System.Web.UI.Page
{
    Tz888.BLL.Company.CompanyMadeBLL company = new Tz888.BLL.Company.CompanyMadeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            dataBind();
            //删除的时候用 如果传真存在，执行删除方法
            if (Convert.ToInt32(Request["MadeId"]) != 0)
            {
                int madeID = Convert.ToInt32(Request["MadeId"]);
                int aduit = Convert.ToInt32(Request["Audit"]);
                Delete(madeID,aduit);
            }
        }
    }
    //删除方法
    private void Delete(int madeID, int Audit)
    {
        //判断 如果审核通过啦，不能执行删除
        if (Audit == 1)
        {
            Tz888.Common.MessageBox.Show(this.Page,"删除失败\\n您的定制已经成功，如要删除，请联系客服");
        }
        else
        {
            int num = company.Delete(madeID);
            if (num == 0)
            {
                Tz888.Common.MessageBox.Show(this.Page, "删除成功");
            }
            else {
                Tz888.Common.MessageBox.Show(this.Page,"删除失败");
            }
        }
        dataBind();
        
    }

    #region 绑定分页
    /// <summary>
    /// 绑定分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        dataBind();
    }
    #endregion

    #region 绑定
    /// <summary>
    /// 绑定
    /// </summary>
    protected void dataBind()
    {
        string strCriteria = "";

        strCriteria = " UserName='"+Page.User.Identity.Name+"'";
      
        long CurrentPage = Convert.ToInt64(this.AspNetPager1.CurrentPageIndex);
        int PageNum = 10;
        long TotalCount = 1;
        long PageCount = 1;
        AspNetPager1.PageSize = PageNum;
        DataTable dt = company.GetListT("CompanyMadeTab", "MadeID", "*", strCriteria, "CreateDate desc", ref CurrentPage, PageNum, ref TotalCount);
        if (dt != null)
        {
            this.AspNetPager1.RecordCount = Convert.ToInt32(TotalCount);
            this.RfList.DataSource = dt.DefaultView;

            this.RfList.DataBind();

            if (TotalCount % PageNum > 0)
                PageCount = TotalCount / PageNum + 1;
            else
                PageCount = TotalCount / PageNum;

            this.pinfo.InnerText = Convert.ToString(TotalCount);
        }
    }
    #endregion

    #region 如果是审核通过 将删除操作隐藏
    protected string afram(int ad,int made)
    {
        string num = "";
        if (ad == 1)
        {
            num = "";
        }
        else
        {
            num = "<a class=\"lan1\" href='JavaScript:DelNav("+made+","+ad+");' onclick= \"if(confirm( '确认要删除吗？')){ return   true;}else{return   false;} \">删除</a>";
            
        }
        return num;
    }
    #endregion

    #region 翻译审核状态信息
    protected string AuditName(int n)
    {
        string num = "";
        switch (n)
        { 
            case 0:
                num = "处理中";
                break;
            case 1:
                num = "有效";
                break;
            case 2:
                num = "无效";
                break;
            case 3:
                num = "已过期";
                break;
        }
        return num;
    }
    #endregion

    #region 解析时间
    protected string SetTime(string time)
    {
        string num = "";
        if (time != "")
        {
            DateTime data = Convert.ToDateTime(time);
            num = data.ToString("yyyy-MM-dd");
        }
        return num;
    }
    #endregion

    #region 解析定制广告名称
    protected string CompanyName(string name)
    {
        string num = "";
        string[] ad = name.Split('-');
        if (ad[0] != "")
        {
            string index = ad[0].Substring(0,1);
            string indexTitle = title(index);
            string IndexNameC = IndexName(ad[0]);
            num += indexTitle + "-" + IndexNameC+"<br/>";
        }
        if (ad[1] != "")
        {
            string Rz = ad[1].Substring(0,1);
            string RzTitle = title(Rz);
            string RzNameC = RzName(ad[1]);
            num += RzTitle + "-" + RzNameC + "<br/>";
        }
        if (ad[2] != "")
        {
            string Tz = ad[2].Substring(0,1);
            string TzTitle = title(Tz);
            string TzNameC = TzName(ad[2]);
            num += TzTitle + "-" + TzNameC + "<br/>";
        }
        if(ad.Length!=3)
        {
            if (ad[3] != "")
            {
                string Zs = ad[3].Substring(0, 1);
                string ZsTitle = title(Zs);
                string ZsNameC = ZsName(ad[3]);
                num += ZsTitle + "-" + ZsNameC;
            }
        }
        return num;
    }

    private string title(string n)
    {
        string num = "";
        if (n != "")
        {
            switch (n)
            { 
                case "A":
                    num = "首页";
                    break;
                case "B":
                    num = "融资";
                    break;
                case "C":
                    num = "投资";
                    break;
                case "D":
                    num = "招商";
                    break;
            }
        }
        return num;
    }

    #region 根据首页广告得出价格
    private string  IndexName(string Index)
    {
        string name = "";
        if (Index != "")
        {
            switch (Index)
            {
                case "A1":
                    name = "顶部通栏";
                    break;
                case "A2":
                    name = "首页轮换";
                    break;
                case "A3":
                    name = "右上小方块";
                    break;
                case "A4":
                    name = "右上大方块";
                    break;
                case "A5":
                    name = "中屏通栏";
                    break;
                case "A6":
                    name = "右下方块";
                    break;
                case "A7":
                    name = "品牌推广栏目";
                    break;
                case "A8":
                    name = "底部通栏（左）";
                    break;
                case "A9":
                    name = "底部通栏（右）";
                    break;
            }
        }
        return name;
    }
    #endregion

    #region 根据融资广告得出价格
    private string RzName(string rz)
    {
        string name = "";
        if (rz != "")
        {
            switch (rz)
            {
                case "B1":
                    name = "顶部左方块";
                    break;
                case "B2":
                    name = "顶部中间";
                    break;
                case "B3":
                    name = "顶部右方块";
                    break;
                case "B4":
                    name = "内页轮播";
                    break;
                case "B5":
                    name = "右上方块";
                    break;
                case "B6":
                    name = "中上通栏";
                    break;
                case "B7":
                    name = "中下通栏";
                    break;
            }
        }
        return name;
    }
    #endregion

    #region 根据投资广告得出价格
    private string TzName(string tz)
    {
        string name = "";
        if (tz != "")
        {
            switch (tz)
            {
                case "C1":
                    name = "顶部左方块";
                    break;
                case "C2":
                    name = "顶部中间";
                    break;
                case "C3":
                    name = "顶部右方块";
                    break;
                case "C4":
                    name = "右上方块";
                    break;
                case "C5":
                    name = "中上通栏";
                    break;
                case "C6":
                    name = "左下方块";
                    break;
                case "C7":
                    name = "中下通栏";
                    break;
                case "C8":
                    name = "右下方块";
                    break;
            }
        }
        return name;
    }
    #endregion

    private string ZsName(string zs)
    {
        string name = "";
        if (zs != "")
        {
            switch (zs)
            { 
                case "D1":
                    name = "顶部左方块";
                    break;
                case "D2":
                    name = "顶部中间";
                    break;
                case "D3":
                    name = "顶部右方块";
                    break;
                case "D4":
                    name = "中上通栏";
                    break;
                case "D5":
                    name = "右下方块";
                    break;
                case "D6":
                    name = "左下方块";
                    break;
            }
        } return name;
    }
    #endregion
}
