<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilesUploadControl.ascx.cs"
    Inherits="Tz888.Member.Controls.FilesUploadControl" %>
<style type="text/css">
.divuploadimg ul{
	padding: 0 0 0 15px;
}
.divuploadimg li{
	width: 110px;
	float: left;
}
.divuploadimg li div{
	text-align: center;
	padding: 7px 15px 7px 0;
}
.divupload {
    padding: 0 0 0 15px;
}
</style>
    <input type="hidden" id="hdIsShow" value="N" runat="server"/>
    <input type="hidden" id="hdShowIndex" value="0" runat="server"/>
<div id="divuploadimg" class="divuploadimg" runat="server">
    <asp:Literal ID="ltOutput" runat="server"></asp:Literal>
</div><div style="clear:both;" />
<div id="divuploadiframe" runat="server" />
<script type="text/javascript" language="javascript">
//document.domain = "tz888.cn";
function UploadPic(uploadURL,uploadDIVID,maxUploadCount,noneCount,userName,hdIsShowID,hdShowIndex,hdImageURLID,hdIsUploadID,hdImageDESCID,clientObjID,imgBoxID,noneImgURL,infoType)
{
    this.UploadURL = uploadURL; //图片上传页面的URL地址
    this.UploadDIVID = uploadDIVID; //图片上传位置的容器ID
    this.MaxUploadCount = maxUploadCount; //最大允许上传图片数
    this.NoneCount = noneCount; //普通会员允许上传图片数
    this.UserName = userName; //当前登陆的用户名
    this.HdIsShowID = hdIsShowID; //图片上传页面是否已显示
    this.HdShowIndex = hdShowIndex; //当前显示的图片上传页面是为第几个图片上传框显示
    this.HdImageURLID = hdImageURLID; //保存已上传图片URL地址的隐藏容器的ID头
    this.HdIsUploadID = hdIsUploadID; //标识当前位置是否已有上传图片的隐藏容器的ID头
    this.HdImageDESCID = hdImageDESCID;//图片描述隐藏容器ID头
    this.ClientObjID = clientObjID; //图片上传控件的JS操作对象的ID
    this.ImgBoxID = imgBoxID; //图片显示容器的ID头
    this.NoneImgURL = noneImgURL; //普通会员默认图片
    this.InfoType = infoType;  //信息类型
}

UploadPic.prototype.uploadnodoor = function(){
    if(confirm('只有拓富通会员才可以上传多个文件。您希望现在就升级为拓富通会员吗？')){
        window.open("<%=this.UserRegUrl %>","applytp");
    }
    return true;
}
    
UploadPic.prototype.showupload = function(id)
{
    var isShow = document.getElementById(this.HdIsShowID).value;
    var showIndex = document.getElementById(this.HdShowIndex).value;
    if(isShow == "Y"){
        document.getElementById(this.UploadDIVID).innerHTML = "";
        document.getElementById(this.UploadDIVID).style.display == "none";
        document.getElementById(this.HdIsShowID).value = "N";
        if(showIndex == id)
            return;
    }
    var iframe = '<iframe id="iframe1" style="width:100%;height:180px;" src="UploadURL" marginwidth=0 marginheight=0 frameborder=0></iframe>';
    var url = this.UploadURL + "?id=" + id + "&u=" + this.UserName + "&obj=" + this.ClientObjID + "&type=" + this.InfoType + "&frm=iframe1";
    
    var str = iframe.replace(/UploadURL/g,url);
    document.getElementById(this.UploadDIVID).innerHTML = str;
    document.getElementById(this.UploadDIVID).style.display == "block";
    document.getElementById(this.HdIsShowID).value = "Y";
    document.getElementById(this.HdShowIndex).value = id;
}

UploadPic.prototype.showloadPic = function(w,l,id,desc){
    var imageUrlID = this.HdImageURLID + id;
    var isUploadID = this.HdIsUploadID + id;
    var imageDESCID = this.HdImageDESCID + id;
    var imgBoxID = this.ImgBoxID + id;
    var imgurl = w + l;
    document.getElementById(imageUrlID).value = l;

    document.getElementById(imgBoxID).src = imgurl;
    if(l.indexOf('.doc')>0||l.indexOf('.ppt')>0||l.indexOf('.pdf')>0)
    {
        document.getElementById(imgBoxID).src = "http://images.topfo.com/doc.jpg";
    }
    document.getElementById(imageDESCID).value = desc;
    document.getElementById(isUploadID).value = "Y";
    
    document.getElementById(this.UploadDIVID).innerHTML = "";
    document.getElementById(this.UploadDIVID).style.display == "none";
    document.getElementById(this.HdIsShowID).value = "N";
}
UploadPic.prototype.deletePic = function(id){
    var isUploadID = this.HdIsUploadID + id;
    if(document.getElementById(isUploadID).value != "Y")
        return;
    if(confirm('你确定要删除已上传的文件吗?')){
        var imageUrlID = this.HdImageURLID + id;
        var imgBoxID = this.ImgBoxID + id;
        var imageDESCID = this.HdImageDESCID + id;
        document.getElementById(imageUrlID).value = "";
        document.getElementById(imageDESCID).value = "";
        document.getElementById(imgBoxID).src = this.NoneImgURL;
        document.getElementById(isUploadID).value = "N";
    }
}

var <%=this.ClientID %>_UploadPic = new UploadPic("<%=UploadImageURL %>","<%=this.divuploadiframe.ClientID %>",3,1,"Clandylee","<%=this.hdIsShow.ClientID %>","<%=this.hdShowIndex.ClientID %>","<%=this.ClientID %>_ImageURL","<%=this.ClientID %>_IsUpload","<%=this.ClientID %>_ImageDESC","<%=this.ClientID %>_UploadPic","<%=this.ClientID %>_IMGBOX","<%=this.NoneImageURL %>","<%=this.InfoType %>");
</script>