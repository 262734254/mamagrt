using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace Tz888.Common.Pager
{
    /// <summary>
    /// ҳ����࣬ʹ�÷�ҳ�ؼ���ҳ�����̳д���
    /// </summary>
    public abstract class BasePage : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        //ҳ��ص�����ֵ
        private string serverReturn;

        #region �ؼ����������ڷ�ҳ����
        protected Pager PagerBase;
        protected GridView GridViewBase = null;
        protected Repeater RepeaterBase = null;
        protected BaseDataList DataListBase = null;
        protected ListControl ListBase = null;
        #endregion

        #region �ؼ��ű���Դ���
        /// <summary>
        /// ����ǰ
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
                         "context.innerHTML='���ݼ�����...';" +
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

        #region Ajax��ҳ����
        //�����ص��¼�����
        public void RaiseCallbackEvent(string eventArgument)
        {
            serverReturn = eventArgument;
        }

        //�ش��ص����
        public string GetCallbackResult()
        {
            return PageChange(serverReturn);
        }
        /// <summary>
        /// ִ�з�ҳ����
        /// </summary>
        /// <param name="newIndex">��ҳ�������</param>
        /// <returns>����ʾ��ҳ������</returns>
        private string PageChange(string newIndex)
        {
            int newPageIndex = int.Parse(newIndex);
            PagerBase.GoToPage(newPageIndex);
            return GetRenderCode();
        }

        /// <summary>
        /// ����ȡ�����ݳ����ڿͻ���
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

        #region ViewStateѹ��/��ѹ
        /// <summary>
        /// ��дSavePageStateToPersistenceMedium()����������������У�ѹ��ViewState���洢�����������С�
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
        /// ��дLoadPageStateFromPersistenceMedium()����������������У���ѹViewState��
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
