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
    public partial class ImageUploadControl : System.Web.UI.UserControl
    {
        private string noneUploadControl = "<li><div>图片{0}</div>"+
            "<img id={1} src={2} style='width:100px; height:100px;' alt=''/><div>" +
            "<input type='button' onclick='{3}' value='上传' />" +
            "<input type='button' onclick='{4}' value='删除' />" +
            "<input type='hidden' id='{5}' name='{6}' value='{7}' />" +
            "<input type='hidden' id='{8}' name='{9}' value='{10}' /> " +
            "<input type='hidden' id='{11}' name='{12}' value='{13}' /> " +
            "</div></li>";

        private string memberUploadControl = "<li><div>图片{0}</div>" +
            "<a href='{1}' target='_blank'><img src={2} style='width:100px; height:100px;' alt='拓富通会员使用'/></a><div>" +
            "<input type='button' onclick='{3}' value='上传' /></div></li>";

        private string noneInfoModel = "<span class='hui'>您现在是普通会员，只能上传<span class='hong'>{0}</span>张介绍项目的图片，拓富通会员可上传<span class='hong'>{1}</span>张。</span>";

        private string memberInfoModel = "<span class='hui'>您现在可以上传<span class='hong'>{0}</span>张项目图片，图片须为jpg或gif格式，大小不超过500k。</span>";

        private string _uploadImageURL = "../publish/p_upload_picture.aspx";
        private string _noneImageURL = "/images/publish/noneimg.gif";
        private string _memberImageURL = "/images/publish/memberimg.gif";
        private string _userRegUrl = "/Register/VIPMemberRegister_In.aspx";

        private int _noneCount = 2;
        private int _count = 5;
        private int _repeatColumns;
        private string _infoType;
        private string _outputcode;
        private bool _isTopfoUser = false;

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
        /// 是否为拓富通会员
        /// </summary>
        public bool IsTopfoUser
        {
            set { _isTopfoUser = value; }
        }

        /// <summary>
        /// 上传图片的集合
        /// </summary>
        public List<Tz888.Model.Info.InfoResourceModel> InfoList
        {
            get {
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
                            model.ResourceName = InfoType;
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
                            string temp = string.Format(this.noneUploadControl, count.ToString(),
                                                        string.Format(this.ClientID + "_IMGBOX{0}", count.ToString()),
                                                        Tz888.Common.Common.GetImageDomain() + "/" + model.ResourceAddr,
                                                        string.Format(this.ClientID + "_UploadPic.showupload({0})", count.ToString()),
                                                        string.Format(this.ClientID + "_UploadPic.deletePic({0})", count.ToString()),
                                                        string.Format(this.ClientID + "_ImageURL{0}", count.ToString()),
                                                        string.Format(this.ClientID + "_ImageURL{0}", count.ToString()), model.ResourceAddr,
                                                        string.Format(this.ClientID + "_ImageDESC{0}", count.ToString()),
                                                        string.Format(this.ClientID + "_ImageDESC{0}", count.ToString()), model.ResourceDescrib,
                                                        string.Format(this.ClientID + "_IsUpload{0}", count.ToString()),
                                                        string.Format(this.ClientID + "_IsUpload{0}", count.ToString()),
                                                        "Y");
                            sb.Append(temp);
                            count++;
                            if (count > this.Count)
                                break;
                        }
                    }
                    if (count <= this.Count)
                    {
                        if (!this._isTopfoUser)
                        {
                            if (count <= this.NoneCount)
                            {
                                for (int i = count; i <= this.NoneCount; i++)
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
                                                                    "N");
                                    sb.Append(temp);
                                    count++;
                                }
                            }
                            if (count <= this.Count)
                            {
                                for (int p = count; p <= this.Count; p++)
                                {
                                    string temp = string.Format(this.memberUploadControl, count.ToString(),
                                                                    this.UserRegUrl,
                                                                    this.MemberImageURL,
                                                                    this.ClientID + "_UploadPic.uploadnodoor()");
                                    sb.Append(temp);
                                    count++;
                                }
                            }
                        }
                        else
                        {
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
                                                                    "N");
                                    sb.Append(temp);
                                    count++;
                                }
                            }
                        }
                    }
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }

        protected string GetPromptInfo()
        {
            if (this._isTopfoUser)
                return string.Format(this.memberInfoModel, this._count.ToString());
            else
                return string.Format(this.noneInfoModel, this._noneCount.ToString(), this._count.ToString());
        }
    }
}
