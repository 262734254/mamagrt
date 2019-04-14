using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace Tz888.Common.Pager
{
    /// <summary>
    /// 页面基类，使用分页控件的页面必须继承此类
    /// </summary>
    public abstract class BasePage : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        //页面回调返回值
        private string serverReturn;

        #region 控件声明，用于分页数据
        protected Pager PagerBase;
        protected GridView GridViewBase = null;
        protected Repeater RepeaterBase = null;
        protected BaseDataList DataListBase = null;
        protected ListControl ListBase = null;
        #endregion

        #region 控件脚本资源输出
        /// <summary>
        /// 呈现前
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.Page != null)
            {
                StringBuilder Builder = new StringBuilder();
                Builder.Append("<script language='javascript' defer>");
                Builder.Append("function setPageTo(pageIndex,panel){" +
                         "var context=document.getElementById(panel);" +
                         "context.innerHTML='数据加载中...';" +
                         "var arg=pageIndex;" +
                         this.Page.ClientScript.GetCallbackEventReference(this, "arg", "onCallServerComplete", "context") +
                         "}");
                Builder.Append("function onCallServerComplete(result,context){context.innerHTML=result;}");
                Builder.Append("</script>");
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Method", Builder.ToString());
            }
            base.OnPreRender(e);
        }
        #endregion

        #region Ajax分页处理
        //引发回调事件处理
        public void RaiseCallbackEvent(string eventArgument)
        {
            serverReturn = eventArgument;
        }

        //回传回调结果
        public string GetCallbackResult()
        {
            return PageChange(serverReturn);
        }
        /// <summary>
        /// 执行分页操作
        /// </summary>
        /// <param name="newIndex">新页面的索引</param>
        /// <returns>需显示的页面数据</returns>
        private string PageChange(string newIndex)
        {
            int newPageIndex = int.Parse(newIndex);
            PagerBase.GoToPage(newPageIndex);
            return GetRenderCode();
        }

        /// <summary>
        /// 将读取的数据呈现在客户端
        /// </summary>
        /// <returns></returns>
        private string GetRenderCode()
        {
            StringWriter writer1 = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);
            HtmlTextWriter writer2 = new HtmlTextWriter(writer1);

            if (GridViewBase != null)
            {
                GridViewBase.Visible = true;
                GridViewBase.RenderControl(writer2);
            }
            else if (RepeaterBase != null)
            {
                RepeaterBase.Visible = true;
                RepeaterBase.RenderControl(writer2);
            }
            else if (DataListBase != null)
            {
                DataListBase.Visible = true;
                DataListBase.RenderControl(writer2);
            }
            else if (ListBase != null)
            {
                ListBase.Visible = true;
                ListBase.RenderControl(writer2);
            }
            PagerBase.RenderControl(writer2);
            writer2.Flush();
            writer2.Close();
            return writer1.ToString();
        }
        #endregion

        #region ViewState压缩/解压
        /// <summary>
        /// 重写SavePageStateToPersistenceMedium()方法。在这个方法中，压缩ViewState并存储它到隐藏域中。
        /// </summary>
        /// <param name="state"></param>
        protected override void SavePageStateToPersistenceMedium(object state)
        {
            LosFormatter formatter = new LosFormatter();
            StringWriter writer = new StringWriter();
            formatter.Serialize(writer, state);
            string viewState = writer.ToString();
            byte[] data = Convert.FromBase64String(viewState);
            byte[] compressedData = ViewStateHelper.Compress(data);
            string str = Convert.ToBase64String(compressedData);
            ClientScript.RegisterHiddenField("__MYVIEWSTATE", str);
        }

        /// <summary>
        /// 重写LoadPageStateFromPersistenceMedium()方法。在这个方法中，解压ViewState。
        /// </summary>
        /// <returns></returns>
        protected override object LoadPageStateFromPersistenceMedium()
        {
            string viewstate = Request.Form["__MYVIEWSTATE"];
            byte[] data = Convert.FromBase64String(viewstate);
            byte[] uncompressedData =
            ViewStateHelper.Decompress(data);
            string str = Convert.ToBase64String(uncompressedData);
            LosFormatter formatter = new LosFormatter();
            return formatter.Deserialize(str);
        }
        #endregion
    }
}
