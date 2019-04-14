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
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public partial class websearhing : System.Web.UI.Page
{
    //protected System.Web.UI.WebControls.Button btnSubmitSearch;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["start"]))
            {
                string searchKeyWord = Server.UrlDecode(Request.QueryString["q"]);

                if(searchKeyWord.Trim()=="")
                {
                    Response.Write("无相关资讯，请输入查询内容。");
                    Response.End();
                }
                //int pageSize = Convert.ToInt16(Request.QueryString["start"].Trim());
                int pageSize = 0;

                string googleAddress = "http://www.google.com.hk/search?hl=zh-CN&newwindow=1&start=" + pageSize + "&q=" + searchKeyWord + "&btnG=Google+%E6%90%9C%E7%B4%A2&meta=&aq=f&oq=";
                Response.Write(spider(googleAddress, searchKeyWord, pageSize));
            }
        }
    }
    protected void btnSubmitSearch_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string searchKeyWord = this.searchKeyWord.Text.Trim();

            if (searchKeyWord.Trim() == "")
            {
                Response.Write("无相关资讯，请输入查询内容。");
                Response.End();
            }

            string googleAddress = "http://www.google.com.hk//search?hl=zh-CN&newwindow=1&start=&q=" + searchKeyWord + "&btnG=Google+%E6%90%9C%E7%B4%A2&meta=&aq=f&oq=";
            string result = spider(googleAddress, searchKeyWord, 0);

            Response.Write(result);
        }
    }

    protected string spider(string theURL,string searchKey,int pagesize)
    {
        WebRequest req = WebRequest.Create(theURL);
        WebResponse rep = req.GetResponse();
        StreamReader redStream = new StreamReader(rep.GetResponseStream(), Encoding.Default);
        string str = redStream.ReadToEnd();

        #region 正文获取后取标题链接

        //int textStart = str.ToString().IndexOf("<li class=g>");
        int textStart = str.ToString().IndexOf("获得约");
        int textEnd = str.ToString().IndexOf("id=hcache") - textStart;
        //int titleEnd = str.ToString().IndexOf("条结果") - textStart;
        Response.Write(textEnd.ToString());

        string contentBody = "";
        string searchTitleLink = "";
        string fullContentBody = "";

    
        contentBody = str.ToString().Substring(textStart, textEnd);

        string[] contentBodyArray = System.Text.RegularExpressions.Regex.Split(contentBody, "</div>");

        Regex titleReg = new Regex(@"class=r>.*?<em>.*?</em>.*?</h3>");

        string replaceKey = "<font color='red'>" + searchKey + "</font>";

        foreach (string i in contentBodyArray)
        {
            //Response.Write(titleReg.Match(i.ToString()).Value.ToString().Replace("class=r>", ""));
            searchTitleLink += titleReg.Match(i.ToString()).Value.ToString().Replace("class=r>", "").Replace(searchKey,replaceKey);
        }

        Regex searchResultReg = new Regex(@"获得约.*?条结果");
        string searchResult;
        int totalSearch;

        searchResult = searchResultReg.Match(contentBody.ToString()).Value.ToString().Replace("获得约 ", "").Replace("条结果", "").Replace("<b>", "").Replace("</b>", "").Replace(",", ""); //搜索总数

        if (int.Parse(searchResult) > 2000000)
        {
            totalSearch = 2000000;
        }
        else
        {
            totalSearch = int.Parse( searchResult );
        }

        searchResult = "约有" + totalSearch + "项符合<font color='red'>" + searchKey + "</font>的查询结果<br/>";

        #endregion

        #region 正文获取后取分页页码

        int theStart = str.ToString().IndexOf("<table id=nav");
        int theEnd = str.ToString().IndexOf("下一页") - theStart;

        string theBody = str.ToString().Substring(theStart, theEnd);

        Regex linkReg = new Regex(@"\?q=.*?\&amp");

        //Response.Write(linkReg.Match(theBody.ToString()).Value.ToString());
        //Response.End();

        //string[] linkArray = System.Text.RegularExpressions.Regex.Split(theBody, "<br>");

        //foreach (string i in linkArray)
        //{
            //Response.Write(linkReg.Match(i.ToString()).Value.ToString());
        //}
        //Response.End();
        //Response.Write(theBody.ToString().Replace("/search", "websearching.aspx") + "下一页</b></a></table>");

        //fullContentBody = searchTitleLink + theBody.ToString().Replace("/search", "websearching.aspx") + "下一页</b></a></table>";

        string nextPage = "<a href='websearching.aspx?q=" + Server.UrlEncode(searchKey) + "&start=" + Convert.ToInt16( pagesize + 10) + "'>下一页</a>";
        string forwardPage = "";

        if (pagesize == 0 || pagesize.ToString() == "")
        {
            forwardPage = "上一页";
        }
        else
        {
            forwardPage = "<a href='websearching.aspx?q=" + Server.UrlEncode(searchKey) + "&start=" + Convert.ToInt16(pagesize - 10) + "'>上一页</a>";
        }

        fullContentBody = searchResult + searchTitleLink + forwardPage.ToString() + nextPage.ToString();

        #endregion

        rep.Close();

        return fullContentBody;
    }
}
