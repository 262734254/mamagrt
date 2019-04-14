using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;



/////////////////////////////////////////////////////////////////////////
////                                                                 ////
////    Name:DateTimeBox                                             ////
////    Authors:Clandy.lee                                           ////
////    Version:1.0 bate1                                            ////
////    CreateDate:2007-6-4                                          ////
////                                                                 ////
/////////////////////////////////////////////////////////////////////////

[assembly: System.Web.UI.WebResource("Tz888.Common.DateTimeBox.date.js", "application/x-javascript", PerformSubstitution = true)]
[assembly: System.Web.UI.WebResource("Tz888.Common.DateTimeBox.date.gif", "image/gif")]
namespace Tz888.Common.DateTimeBox
{
    [ToolboxBitmap(typeof(DateTimeBox), "DateTimeBox.ico")]
    public class DateTimeBox : TextBox 
    {
        private const string CSS=@"<style type=""text/css"">
            .Wdate{
            border:#999 1px solid;
            height:18px;
            background:url($ImageURL$) no-repeat right;
            }
            .WdateFmtErr
            {
                font-weight:bold;color:red;
             }</style>";
        protected override void OnPreRender(EventArgs e)
        {
            string calendar = CSS.Replace("$ImageURL$", this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Tz888.Common.DateTimeBox.date.gif"));
            if (!Page.ClientScript.IsClientScriptBlockRegistered("_calendar"))
                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "_calendar", calendar);
            
            this.Page.PreRenderComplete += new EventHandler(Page_PreRenderComplete);
            this.CssClass = "Wdate";
            this.Attributes.Add("onfocus","setday(this)");
            this.Attributes.Add("onchange", "checkDate(this.value)");
            base.OnPreRender(e);
        }

        void Page_PreRenderComplete(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptResource(this.GetType(), "Tz888.Common.DateTimeBox.date.js");
        }

        /// <summary>
        /// 弹出日期控件小图片的地址
        /// </summary>
        [Bindable(true)]
        [Category("图标设置")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ImaginURL
        {
            get
            {
                String s = (String)ViewState["ImaginURL"];
                return ((s == null) ? "" : s);
            }
            set
            {
                ViewState["ImaginURL"] = value;
            }
        }

        /// <summary>
        /// 设置日期，时间的初始格式。
        /// </summary>
        [Bindable(true)]
        [Category("初始化设置")]
        [DefaultValue(false)]
        [Localizable(true)]
        public bool ShowTime
        {
            get
            {
                bool s = (bool)ViewState["ShowTime"];
                if (ViewState["ShowTime"] != null)
                {
                    return s;
                }
                return false;
            }
            set
            {
                ViewState["ShowTime"] = value;
            }
        }


        /// <summary>
        /// 注样式文件
        /// </summary>
        /// <param name="path"></param>
        private void RegisterCssFile(string path)
        {
            HtmlLink link1 = new HtmlLink();
            link1.Attributes["type"] = "text/css";
            link1.Attributes["rel"] = "stylesheet";
            link1.Attributes["href"] = path;
            this.Page.Header.Controls.Add(link1);
        }
    }
}
