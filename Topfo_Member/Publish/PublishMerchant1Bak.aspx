<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeFile="PublishMerchant1Bak.aspx.cs"
    Inherits="Publish_PublishMerchant1" Title="招商信息-招商机构登记" %>

<%@ Register Src="../Register/Control/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/MerchantAddressInfo.ascx" TagName="MerchantAddressInfo"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%-- <link href="../css/publish.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.note
{
	float:left;
	text-align:left;
	font-size:12px;
	color:#999999;
	padding:3px;
	line-height:130%;
	background:#ffffff;
	border:#ffffff 1px solid;
}
.notetrue
{
	float:left;
	text-align:left;
	font-size:12px;
	padding:3px;
	line-height:130%;
	color:#485E00;
	background:#F7FFDD;
	border:#485E00 1px solid;
}
.noteawoke
{
	float:left;
	text-align:left;
	padding:3px;
	line-height:130%;
	background:#fff5d8;
	border:#ff7300 1px solid;
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>--%>

    <script type="text/javascript" language="javascript">
function GetCheckNum(checkobjectname)
{
	var truei2 = 0;
	checkobject = document.getElementsByName(checkobjectname);
	var inum = checkobject.length;
	if (isNaN(inum))
	{
		inum = 0;
	}
	for(i=0;i<inum;i++){
		if (checkobject[i].checked == 1){
			truei2 = truei2 + 1;
		}
	}
	return truei2;
}
function checkByteLength(str,minlen,maxlen) {
	if (str == null) return false;
	var l = str.length;
	var blen = 0;
	for(i=0; i<l; i++) {
		if ((str.charCodeAt(i) & 0xff00) != 0) {
			blen ++;
		}
		blen ++;
	}
	if (blen > maxlen || blen < minlen) {
		return false;
	}
	return true;
} 

function checkMerchantName()
{
    var txtMerchantNameID = "<%=this.txtMerchantName.ClientID %>";
    var obj = document.getElementById(txtMerchantNameID);
    if(obj.value == "")
    {
        document.getElementById("spMerchantName").innerHTML = "&nbsp;&nbsp;&nbsp;招商机构名称必须填写！";
        document.getElementById("spMerchantName").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spMerchantName").innerHTML = "";
        document.getElementById("spMerchantName").className = "";
        return true;
    }
}

function checkMerchantIntro()
{
    var id = "<%=this.txtMerchantIntro.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spMerchantIntro").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的机构简介！";
        document.getElementById("spMerchantIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spMerchantIntro").innerHTML = "&nbsp;&nbsp;&nbsp;您的机构简介过于简短，必须在50字以上！";
        document.getElementById("spMerchantIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spMerchantIntro").innerHTML = "&nbsp;&nbsp;&nbsp;机构简介必须在5000字以内！";
        document.getElementById("spMerchantIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spMerchantIntro").innerHTML = "";
        document.getElementById("spMerchantIntro").className = "";
        return true;
    }
}


function checkMerchantAddress()
{
    var id = "<%=this.MerchantAddressInfo1.ClientID %>";
    return eval(id+"_AddContact.checkAll()");
}


function CheckDomain(domain,loginName)
{
	if(domain!="")
    {
     AjaxMethod.CheckDomain(domain,loginName,showMessage);
    }	
}

function showMessage(res)
{
    var ln = document.getElementById("<%=this.lblMsg.ClientID %>");			
     var hid=document.getElementById("<%=this.hidExhibitionHall.ClientID %>");
     hid.value=res.value;
    ln.innerHTML ="<font color='red'>"+res.value+"</font>";
}

function checkExhibitionHall()
{
    var ln = document.getElementById("<%=this.lblMsg.ClientID %>");			
    var hid=document.getElementById("<%=this.hidExhibitionHall.ClientID %>");
    var id = "<%=this.txtExhibitionHall.ClientID %>";
    var obj = document.getElementById(id);
    if(!checkByteLength(obj.value,1,40))
    {
        alert("展厅域名不能为空！");
        obj.focus();
        return false;
    }
    return true;
}

function CheckForm()
{
    var revalue = true;
    if(!checkMerchantName()){
        if(revalue) revalue = false;}
    if(!checkMerchantIntro()){
        if(revalue) revalue = false;}
    if(!checkMerchantAddress()){
        if(revalue) revalue = false;}  
    if(!checkExhibitionHall()){
        if(revalue) revalue = false;} 
    return revalue;
}


document.getElementById("aspnetForm").onsubmit = CheckForm;
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布政府招商需求
            </div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" align="absmiddle" />
                <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">需求发布规则</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="stepsbox">
            <ul>
                <li class="liwai">第1步 登记招商机构 </li>
                <li class="liimg">
                    <img src="../images/publish/projectbg.gif" align="left" /></li>
                <li>第2步 填写招商项目信息</li>
                <li class="liimg">
                    <img src="../images/publish/projectbg.gif" align="left" /></li>
                <li class="lishort">第3步 发布成功</li>
            </ul>
            <div class="clear">
            </div>
            <div class="blank0">
            </div>
            <div class="suggestbox lightc allxian">
                <h1>
                    <strong>重要提示</strong></h1>
                ·您发布的招商机构信息请确保真实有效，由于发布虚假信息产生的任何责任，由发布者自行承担！<br />
                ·含有详细招商机构信息的招商项目将被更多投资方认可！</div>
        </div>
        <div class="blank0">
        </div>
        <div>
            带 <span class="hong">*</span> 的为必填项</div>
        <div class='dottedlline'>
        </div>
        <div class="blank6">
        </div>
        <div class="infozi">
            招商机构基本资料</div>
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td width="124" align="right" bgcolor="#f7f7f7" style="height: 2px">
                    <span class="hong">* </span><strong>招商机构名称</strong>：</td>
                <td width="618" style="height: 2px">
                    <asp:TextBox ID="txtMerchantName" onchange="JavaScrpit:checkMerchantName()" runat="server"
                        Width="286px"></asp:TextBox>
                    <span id="spMerchantName"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7">
                    <span class="hong">* </span><strong>机构主体：</strong></td>
                <td>
                    <asp:DropDownList ID="ddlSubjectType" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" bgcolor="#f7f7f7" style="height: 5px">
                    <span class="hong">*</span> <strong>所属区域：</strong></td>
                <td width="618" style="height: 5px">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#f7f7f7">
                    <span class="hong">*</span> <strong>招商机构介绍：</strong>
                    <br />
                </td>
                <td width="618" valign="top">
                    <textarea id="txtMerchantIntro" onchange="JavaScrpit:checkMerchantIntro()" runat="server"
                        cols="50" rows="10" style="width: 558px; height: 300px"></textarea>
                    <span id="spMerchantIntro"></span>
                    <br />
                    <span class="hui">请用中文介绍招商机构的相关内容，如果内容过于简单，有可能无法通过审核。<br />
                        联系方式（电话、传真、手机、电子邮箱等）请在下一步填写，此处重复填写将无法通过审核</span>
                </td>
            </tr>
            <%--<tr>
                <td align="right" valign="top" bgcolor="#f7f7f7">
                    <strong>图片上传：</strong></td>
                <td width="618" valign="top" class="nonepad">
                    <uc2:ImageUploadControl ID="ImageUploadControl1" runat="server"></uc2:ImageUploadControl>
                </td>
            </tr>--%>
        </table>
        <!--联系方式 -->
        <div class="blank0">
        </div>
        <div class="infozi">
            <strong>招商机构联系方式</strong></div>
        <uc3:MerchantAddressInfo ID="MerchantAddressInfo1" runat="server"></uc3:MerchantAddressInfo>
        <div class="blank20">
        </div>
        <!--申请域名 建立我的展厅 -->
        <div class="infozi">
            申请域名 建立我的展厅</div>
        <div class="viewbox lightc cshibiank">
            我的展厅是我们推出的一项最新服务，方便用户全面展示自己的公司/机构，获得合作方更多信任。 <a href="http://www.topfo.com/help/setup.shtml"
                target="_blank">了解更多</a></div>
        <div class="blank0">
        </div>
        <div>
            <b>我的域名：http://<asp:TextBox ID="txtExhibitionHall" runat="server" Width="66px"></asp:TextBox>
                .gov.topfo.com </b><span>只有申请了域名，招商机构介绍才能上网展示!
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    <input id="hidExhibitionHall" type="hidden" runat="server" /></span></div>
        <div class="mbbuttom">
            <p>
                <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank">点此阅读中国招商投资网服务条款</a></p>
            <asp:ImageButton ID="IbtnSubmit" ImageUrl="../images/publish/buttom_tywftk.gif" runat="server"
                OnClick="IbtnSubmit_Click" />
        </div>
    </div>
</asp:Content>
