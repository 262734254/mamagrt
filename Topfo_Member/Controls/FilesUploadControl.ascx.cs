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
using System.Text;
using System.Collections.Generic;

namespace Tz888.Member.Controls
{
    public partial class FilesUploadControl : System.Web.UI.UserControl
    {
        private static string imageWebSiteUrl = Tz888.Common.ConfigHelper.GetConfigString("ImageDomain");
        private static string fileWebSiteUrl = Tz888.Common.ConfigHelper.GetConfigString("MemberDomain");

        private string noneUploadControl = "<li><div>文件{0}</div>"+
            "<a href='{14}' target='_blank' alt='点击查看文件'><img id={1} src={2} style='width:100px; height:100px;' alt=''/></a><div>" +
            "<input type='button' onclick='{3}' value='上传' />" +
            "<input type='button' onclick='{4}' value='删除' />" +
            "<input type='hidden' id='{5}' name='{6}' value='{7}' />" +
            "<input type='hidden' id='{8}' name='{9}' value='{10}' /> " +
            "<input type='hidden' id='{11}' name='{12}' value='{13}' /> " +
            "</div></li>";

        private string _uploadImageURL = "../Info/p_upload_file.aspx";
        private string _noneImageURL = "http://manage.topfo.com/images/noneimg.gif";
        private string _memberImageURL = "http://manage.topfo.com/images/memberimg.gif";
        private string _userRegUrl;

        private int _noneCount = 3;
        private int _count = 5;
        private int _repeatColumns;
        private string _infoType;
        private string _outputcode;

        private List<Tz888.Model.Info.InfoResourceModel> _infoList = new List<Tz888.Model.Info.InfoResourceModel>();

        #region 属性
        /// <summary>
        /// 图片位总数
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        /// <summary>
        /// 普通会员可上传图片数
        /// </summary>
        public int NoneCount
        {
            get { return _noneCount; }
            set { _noneCount = value; }
        }

        /// <summary>
        /// 普通会员使用图片
        /// </summary>
        public string NoneImageURL
        {
            get { return this._noneImageURL;}
            set { _noneImageURL = value; }
        }

        /// <summary>
        /// 拓富通会员使用图片
        /// </summary>
        public string MemberImageURL
        {
            get { return this._memberImageURL; }
            set { _memberImageURL = value; }
        }

        /// <summary>
        /// 用于布局项的列数
        /// </summary>
        public int RepeatColumns
        {
            get { return this._repeatColumns; }
            set { _repeatColumns = value; }
        }

        /// <summary>
        /// 图片上传页面的URL地址
        /// </summary>
        public string UploadImageURL
        {
            get { return _uploadImageURL; }
            set { _uploadImageURL = value; }
        }

        /// <summary>
        /// 生成界面代码
        /// </summary>
        public string Outputcode
        {
            get {
                this._outputcode = this.CreateControlCode();
                return _outputcode; }
        }

        /// <summary>
        /// 拓富通会员跳转页面URL
        /// </summary>
        public string UserRegUrl
        {
            get { return _userRegUrl; }
            set { _userRegUrl = value; }
        }

        /// <summary>
        /// 上传资源所属的信息类型
        /// </summary>
        public string InfoType
        {
            get { return _infoType; }
            set { _infoType = value; }
        }

        /// <summary>
        /// 上传图片的集合
        /// </summary>
        public List<Tz888.Model.Info.InfoResourceModel> InfoList
        {
            get {
                this._infoList = new List<Tz888.Model.Info.InfoResourceModel>();
                for (int i = 0; i <= this.NoneCount; i++)
                {
                    string isloadControlID = this.ClientID + "_IsUpload" + i.ToString();
                    string imageURLControlID = this.ClientID + "_ImageURL" + i.ToString();
                    string imageDESCContorlID = this.ClientID + "_ImageDESC" + i.ToString();
                    Tz888.Model.Info.InfoResourceModel model = new Tz888.Model.Info.InfoResourceModel();
                    if (this.Page.Request.Form[isloadControlID] != null)
                    {
                        string isLoad = Convert.ToString(this.Page.Request.Form[isloadControlID]);
                        if (isLoad == "Y")
                        {
                            model.ResourceAddr = Convert.ToString(this.Page.Request.Form[imageURLControlID]);
                            model.ResourceDescrib = Convert.ToString(this.Page.Request.Form[imageDESCContorlID]);
                            model.IsDel = false;
                            model.remark = "";
                            model.UpDate = DateTime.Now;
                            model.ResourceName = this.ViewState["InfoType"].ToString() ;
                            model.ResourceTitle = model.ResourceDescrib;
                            model.ResourceType = (int)Tz888.Common.ResourceType.Image;
                            model.ResourceProperty = (int)Tz888.Common.ResourceProperty.InfoImage;
                            this._infoList.Add(model);
                        }
                    }
                }
                return _infoList; }
            set {_infoList = value; }
        }

        #endregion

        /// <summary>
        /// 生成图片上传控件的呈现代码
        /// </summary>
        /// <returns></returns>
        private string CreateControlCode()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Count > 0)
            {
                int count = 1;
                sb.Append("<ul>");
                if (this.Count > 0)
                {
                    if (this._infoList != null)
                    {
                        foreach (Tz888.Model.Info.InfoResourceModel model in this._infoList)
                        {
                            string temp_url = Tz888.Common.Common.GetImageDomain() + "/" + model.ResourceAddr;
                            if (model.ResourceAddr.IndexOf(".doc") > 0 || model.ResourceAddr.IndexOf(".pdf") > 0 || model.ResourceAddr.IndexOf(".ppt") > 0)
                            {
                                temp_url = "http://images.topfo.com/doc.jpg";
                            }
                            string temp = string.Format(this.noneUploadControl, count.ToString(),
                                                        string.Format(this.ClientID + "_IMGBOX{0}", count.ToString()),
                                                        temp_url,
                                                        string.Format(this.ClientID + "_UploadPic.showupload({0})", count.ToString()),
                                                        string.Format(this.ClientID + "_UploadPic.deletePic({0})", count.ToString()),
                                                        string.Format(this.ClientID + "_ImageURL{0}", count.ToString()),
                                                        string.Format(this.ClientID + "_ImageURL{0}", count.ToString()), model.ResourceAddr,
                                                        string.Format(this.ClientID + "_ImageDESC{0}", count.ToString()),
                                                        string.Format(this.ClientID + "_ImageDESC{0}", count.ToString()), model.ResourceDescrib,
                                                        string.Format(this.ClientID + "_IsUpload{0}", count.ToString()),
                                                        string.Format(this.ClientID + "_IsUpload{0}", count.ToString()),
                                                        "Y",
                                                        Tz888.Common.Common.GetImageDomain() + "/" + model.ResourceAddr);
                            sb.Append(temp);
                            count++;
                            if (count > this.Count)
                                break;
                        }
                    }
                    if (count <= this.Count)
                    {
                        for (int i = count; i <= this.Count; i++)
                        {
                            string temp = string.Format(this.noneUploadControl, count.ToString(),
                                                            string.Format(this.ClientID + "_IMGBOX{0}", count.ToString()),
                                                            this.NoneImageURL,
                                                            string.Format(this.ClientID + "_UploadPic.showupload({0})", count.ToString()),
                                                            string.Format(this.ClientID + "_UploadPic.deletePic({0})", count.ToString()),
                                                            string.Format(this.ClientID + "_ImageURL{0}", count.ToString()),
                                                            string.Format(this.ClientID + "_ImageURL{0}", count.ToString()), "",
                                                            string.Format(this.ClientID + "_ImageDESC{0}", count.ToString()),
                                                            string.Format(this.ClientID + "_ImageDESC{0}", count.ToString()), "",
                                                            string.Format(this.ClientID + "_IsUpload{0}", count.ToString()),
                                                            string.Format(this.ClientID + "_IsUpload{0}", count.ToString()),
                                                            "N",
                                                            "#");
                            sb.Append(temp);
                            count++;
                        }
                    }
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ltOutput.Text = this.Outputcode;
                this.ViewState["InfoType"] = this._infoType;
            }
            if (IsPostBack)
            {
                if (this.InfoList != null && this.InfoList.Count > 0)
                {
                    this.ltOutput.Text = this.Outputcode;
                    this.ViewState["ImageUpload"] = this.ltOutput.Text;
                }
                else
                {
                    if (this.ViewState["ImageUpload"] != null)
                        this.ltOutput.Text = this.ViewState["ImageUpload"].ToString();
                }

            }
        }
    }
}
