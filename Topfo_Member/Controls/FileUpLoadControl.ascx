<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUpLoadControl.ascx.cs"
    Inherits="Tz888.Member.Controls.FileUpLoadControl" %>
<link href="../../css/common.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">

function ChangeTab(index){
    var objTabs = document.getElementsByName("tab");
    var objDetailTabs = document.getElementsByName("tabDetail");
    var numTabs = objTabs.length;
    var numDetailTabs = objDetailTabs.length;
    var preMenuIndex = index - 1;
    for(i=0;i<numTabs;i++){
        objTabs[i].className = "";
    }
    for(j=0;j<numDetailTabs;j++){
		objDetailTabs[j].style.display = "none";
	}
    objTabs[index].className = "liwai";
    objDetailTabs[index].style.display = "block";
}
</script>

<style type="text/css">
.addinfobox{
	border: 1px solid #CCCCCC;
	padding-bottom: 20px;
}
.addinfobox h1{
	border-bottom-width: 1px;
	border-bottom-style: solid;
	border-bottom-color: #CCCCCC;
	font-weight: normal;
	background-color: #F5F5F5;
	padding: 5px 10px 5px 10px;
}
.addinfobox ul{
	width: 610px;
	margin: 0 auto;
	padding: 15px 0 0 0;
}
.addinfobox li{
	width: 150px;
	float: left;
	font-weight: bold;
	color: #10247D;
	CURSOR: pointer;
}
.addinfobox .liwai{color:#FD3A00}
.addinfobox table{
	border: 1px dashed #CCCCCC;
	margin: 0 auto;
	float:left!important;float:none;
}  
    </style>
<div class="addinfobox">
    <h1>
        您可上传关于项目的资质证明、文档、视频等，让客户更全面地了解您的项目，对您更信任！<br />
        <span class="cheng">您可以为文件设置密码，只有特定的用户才能查看。</span></h1>
    <ul>
        <li id="tab" name="tab" onclick="javascript:ChangeTab(0)">上传立项批文 </li>
        <li id="tab" name="tab" onclick="javascript:ChangeTab(1)">上传商业计划书 </li>
        <li id="tab" name="tab" onclick="javascript:ChangeTab(2)">上传更多文档</li>
    </ul>
    <div id="tabDetail" name="tabDetail" style="display:none;">
        <iframe id="iframe1" src="../Publish/p_upload_file.aspx?id=2&code=<%=this.InfoID %>&frm=iframe1" frameborder="no" scrolling="no" style="width:750px; height:110px;"></iframe>
    </div>
    <div id="tabDetail" name="tabDetail" style="display:none;">
        <iframe id="iframe2" src="../Publish/p_upload_file.aspx?id=3&code=<%=this.InfoID %>&frm=iframe2" frameborder="no" scrolling="no" style="width:750px; height:110px;"></iframe>
    </div>
    <div id="tabDetail" name="tabDetail" style="display:none;">
        <iframe id="iframe3" src="../Publish/p_upload_file.aspx?id=0&code=<%=this.InfoID %>&frm=iframe3" frameborder="no" scrolling="no" style="width:750px; height:110px;"></iframe>
    </div>
</div>
<script language="javascript">
ChangeTab(1);
</script>