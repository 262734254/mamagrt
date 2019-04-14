using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class Vote_UserSurver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindVoteData();
    
    }

    private void BindVoteData()
    {
        string sqlSelect = "select * from Question where C_ID = 34 order by Q_ID";
        string itemClass = "";  //选项样式
        string rowClass = "baibg";   //行样式

        StringBuilder sbVote = new StringBuilder();
       
        DataSet dsQuses = TzVote.DB.Query(sqlSelect);

   
        for (int i = 1; i <= dsQuses.Tables[0].Rows.Count; i++)
        {
           
            if (i % 2 != 0)
            {
                sbVote.Append("<div class=\""+ rowClass +"\">");
                itemClass = "vllcont";
                if (rowClass == "baibg")
                    rowClass = "blackbg";
                else
                    rowClass = "baibg";
            }else
            {
                itemClass = "vrrcont";
            }

           

                //构造调查问题内容
            sbVote.Append("<div class=\"" + itemClass + "\">");
            sbVote.Append("<h3>"+ dsQuses.Tables[0].Rows[i-1]["Q_Title"].ToString() +"</h3>\r");
            sbVote.Append("<p>");

            //构造调查选项内容
            string sqlSelectAns = "select * from Answer where Q_ID = {0} order by A_ID";
            sqlSelectAns = string.Format(sqlSelectAns, dsQuses.Tables[0].Rows[i - 1]["Q_ID"]);
  
            DataSet dsAnswer = TzVote.DB.Query(sqlSelectAns);
            StringBuilder sbAnswer = new StringBuilder();       //选项
            for (int m = 0; m < dsAnswer.Tables[0].Rows.Count; m++)
            {
                string itemType = "";
                if (dsQuses.Tables[0].Rows[i - 1]["Q_Sort"].ToString() == "1")
                    itemType = "radio";
                else if (dsQuses.Tables[0].Rows[i - 1]["Q_Sort"].ToString() == "2")
                    itemType = "checkbox";
                sbAnswer.Append("<input name=\"poll" + (i-1).ToString() + "\" type=\"" + itemType + "\" value=\"" + dsAnswer.Tables[0].Rows[m]["A_ID"].ToString() + "\" />" +
                    dsAnswer.Tables[0].Rows[m]["A_Answer"].ToString() + "<br />\r");
            }
            sbAnswer.Append("<input type=\"hidden\" name=\"Q_ID\" value=\"" + dsQuses.Tables[0].Rows[i - 1]["Q_ID"].ToString() + "\" ID=\"Hidden1\" />");
           
            sbVote.Append(sbAnswer.ToString());
           // sbVote.Append("<input name=\"\" type=\"radio\" value=\"\" />每天都上<br />");
            sbVote.Append("\r</p>");
            sbVote.Append("</div>\r");

            if (i % 2 == 0)
            {
                sbVote.Append("<div class=\"clear\"></div>");
                sbVote.Append("</div>\r\r");
                
            }
        }



        votestart.InnerHtml = sbVote.ToString();
    }
}
