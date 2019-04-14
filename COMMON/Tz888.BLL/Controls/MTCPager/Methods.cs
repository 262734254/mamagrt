using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace OurControl
{
    public partial class MTCPager
    {
        //public event Eventhandler OnBindData; 

        //���ְ�Ť�飯ǰ��Nҳ����Nҳ N=this.ShowPageNumberCount
        LinkButton[] lbDigits = null;
        LinkButton lbPreBatch = null;
        LinkButton lbNextBatch = null;

        //��ҳ����һҳ����һҳ��βҳ�� ��ť
        LinkButton lbFirst = null;
        LinkButton lbNext = null;
        LinkButton lbPrevious = null;
        LinkButton lbLast = null;

        TextBox tbJumpIndex = null;
        Button btnJump = null;

        DropDownList ddlJumpIndex = null;

        DropDownList ddlNumOfPager = null;

        // ��дICompositeControlDesignerAccessor�ӿڵ�RecreateChildContrls����
        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

        // ��дControl�����CreateChildControls����
        protected override void CreateChildControls()
        {
            // ��������ӿؼ�
            Controls.Clear();

            if (this.PageCount == 0)
                return;

            lbFirst = new LinkButton();
            lbFirst.ID = "lbFirst";
            lbFirst.CommandName = "LinkJump";
            lbFirst.Text = this.FirstPageDescription;
            lbLast = new LinkButton();
            lbLast.ID = "lbLast";
            lbLast.CommandName = "LinkJump";
            lbLast.Text = this.LastPageDescription;
            if (this.PagingMode == PagingMode.Default)
            {
                if (this.PageIndex > 1)
                {
                    lbPrevious = new LinkButton();
                    lbPrevious.ID = "lbPrevious";
                    lbPrevious.CommandName = "LinkJump";
                    lbPrevious.Text = this.PagePreviousDescription;
                }
                if (this.PageIndex < this.PageCount)
                {
                    lbNext = new LinkButton();
                    lbNext.ID = "lbNext";
                    lbNext.CommandName = "LinkJump";
                    lbNext.Text = this.PageNextDescription;
                }
            }
            else if (this.PagingMode == PagingMode.Digit)
            {
                //ÿ����ʾ��ҳ��             
                int count = this.ShowPageNumberCount;
                int numIndex = (this.PageIndex / count) * count;
                int firtNum;
                int lastNum;
                if (this.PageIndex == numIndex)
                {
                    firtNum = numIndex - count + 1;
                }
                else
                {
                    firtNum = numIndex + 1;
                }
                lastNum = firtNum + count - 1;
                if (lastNum > this.PageCount) lastNum = this.PageCount;
                if (firtNum > 0)
                {
                    lbPreBatch = new LinkButton();
                    lbPreBatch.ID = "lbPreBatch";
                    lbPreBatch.CommandName = "LinkJump";
                    lbPreBatch.Text = this.PageUpDescription;
                }
                //�������ַ�ҳ�ؼ�����
                lbDigits = new LinkButton[lastNum - firtNum + 1];
                int j = 0;
                for (int i = firtNum; i <= lastNum; i++)
                {
                    lbDigits[j] = new LinkButton();
                    lbDigits[j].ID = "lb" + i.ToString();
                    lbDigits[j].Text = i.ToString();
                    lbDigits[j].CommandName = "LinkJump";
                    if (i == this.PageIndex)
                    {
                        lbDigits[j].Font.Bold = true;
                    }
                    j++;
                }
                if (lastNum < this.PageCount)
                {
                    lbNextBatch = new LinkButton();
                    lbNextBatch.ID = "lbNextBatch";
                    lbNextBatch.CommandName = "LinkJump";
                    lbNextBatch.Text = this.PageDownDescription;
                }

            }

            if (this.PageJump.Visiable == true)
            {
                //���������б��
                if (this.PageJump.PageJumpType == PageJumpType.DropDownList)
                {
                    ddlJumpIndex = new DropDownList();
                    ddlJumpIndex.Items.Clear();
                    ddlJumpIndex.ID = "ddlJumpIndex";
                    for (int i = 1; i <= this.PageCount; i++)
                    {
                        ddlJumpIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                    ddlJumpIndex.SelectedValue = this.PageIndex.ToString();
                    ddlJumpIndex.EnableViewState = false;
                    ddlJumpIndex.AutoPostBack = true;
                    ddlJumpIndex.SelectedIndexChanged += new EventHandler(this.DropDownList_SelectedIndexChanged);
                }
                else
                {
                    //��������������ת
                    tbJumpIndex = new TextBox();
                    tbJumpIndex.ID = "tbJumpIndex";
                    tbJumpIndex.Text = this.PageIndex.ToString();
                    //tbJumpIndex.Attributes.Add("onkeyup", @"value=value.replace(/[^\d]/g,'')");
                    //tbJumpIndex.Attributes.Add("onbeforepaste", @"clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))");
                    btnJump = new Button();
                    btnJump.ID = "btnJump";
                    btnJump.CommandName = "ButtonJump";
                    btnJump.Text = this.PageJump.ButtonText;
                }
            }

            ddlNumOfPager = new DropDownList();
            ddlNumOfPager.Items.Clear();
            ddlNumOfPager.ID = "ddlNumOfPager";
            string aPageNum = "";
            for (int i = 1; i <= 10; i++)
            {
                aPageNum = Convert.ToString(i * 10);
                ddlNumOfPager.Items.Add(new ListItem(aPageNum, aPageNum));
            }

            ddlNumOfPager.SelectedValue = this.PageSize.ToString();
            ddlNumOfPager.EnableViewState = false;
            ddlNumOfPager.Visible = this.PageJump.DDLVisiable;
            ddlNumOfPager.AutoPostBack = true;
            ddlNumOfPager.SelectedIndexChanged += new EventHandler(this.ShowNum_SelectedIndexChanged);

            if (lbFirst != null)
                this.Controls.Add(lbFirst);
            if (lbPrevious != null)
                this.Controls.Add(lbPrevious);
            if (lbPreBatch != null)
                this.Controls.Add(lbPreBatch);
            if (lbDigits != null)
            {
                foreach (LinkButton lb in lbDigits)
                {
                    this.Controls.Add(lb);
                }
            }
            if (lbNextBatch != null)
                this.Controls.Add(lbNextBatch);
            if (lbNext != null)
                this.Controls.Add(lbNext);
            if (lbLast != null)
                this.Controls.Add(lbLast);
            if (tbJumpIndex != null)
                this.Controls.Add(tbJumpIndex);
            if (btnJump != null)
                this.Controls.Add(btnJump);
            if (ddlJumpIndex != null)
                this.Controls.Add(ddlJumpIndex);
            if (ddlNumOfPager != null)
                this.Controls.Add(ddlNumOfPager);
        }

        /// <summary>
        /// ����ҳ�벿��
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        private void RenderPageNumber(HtmlTextWriter output)
        {
            if (lbDigits == null)
                return;

            output.AddStyleAttribute(HtmlTextWriterStyle.TextDecoration, "none");

            foreach (LinkButton lb in lbDigits)
            {
                string temp = "";
                //if (lb.Text == "1")
                //    temp = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

                output.Write(temp + this.TextBeforePageNumber);
                if (lb.Text == this.PageIndex.ToString())
                {
                    // ��ǰѡ��ҳ��������ɫ���
                    output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.SelectedPageNumberColor);
                }
                else
                {
                    output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.PageNumberColor);
                }
                lb.RenderControl(output);
                output.Write(this.TextAfterPageNumber);


                output.Write("&nbsp;&nbsp;");
            }

        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>
        /// <param name="selectedPageNumberColor">��ǰѡ��ҳ�����ɫ</param>
        public void RenderPageIndexContent(HtmlTextWriter output)
        {
            PageJump pageJump = this.PageJump;
            if (pageJump.Visiable)
            {
                switch (pageJump.PageJumpType)
                {
                    //ʹ�����������ҳ����ת
                    case PageJumpType.TextBox:
                        output.Write(pageJump.LeftText + "&nbsp;");
                        output.AddStyleAttribute(HtmlTextWriterStyle.Color, this.SelectedPageNumberColor);
                        output.AddStyleAttribute("text-align", "center");
                        if (tbJumpIndex != null)
                        {
                            tbJumpIndex.Style.Add("width", "20px");
                            tbJumpIndex.Style.Add("height", "14px");
                            tbJumpIndex.Style.Add("line-height", "14px");
                            tbJumpIndex.RenderControl(output);
                        }
                        output.Write("&nbsp;" + pageJump.RightText + "&nbsp;");
                        if (btnJump != null)
                        {
                            btnJump.RenderControl(output);
                        }
                        output.Write("&nbsp;&nbsp;");
                        break;
                    //�����б����ת
                    case PageJumpType.DropDownList:
                        output.Write("&nbsp;&nbsp;");
                        // �������
                        output.Write(pageJump.LeftText);
                        ddlJumpIndex.RenderControl(output);
                        // �ұ�����
                        output.Write(pageJump.RightText);
                        output.Write("&nbsp;&nbsp;");
                        break;
                }
            }
        }

        /// <summary>
        /// ����ҳ����ʾ������ת����
        /// </summary>
        /// <param name="output">HtmlTextWriter</param>        
        public void RenderPageNumJump(HtmlTextWriter output)
        {
            if (ddlNumOfPager != null)
            {
                if (this.PageJump.DDLVisiable == true)
                {
                    output.Write("&nbsp;&nbsp;");
                    // �������
                    output.Write("ÿҳ��ʾ");
                }
                ddlNumOfPager.RenderControl(output);
                // �ұ�����
                if (this.PageJump.DDLVisiable == true)
                {
                    output.Write("��");
                    output.Write("&nbsp;&nbsp;");
                }
            }
        }
    }
}
