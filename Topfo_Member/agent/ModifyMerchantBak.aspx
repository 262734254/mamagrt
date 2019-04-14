<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ModifyMerchantBak.aspx.cs"
    Inherits="Manage_ModifyMerchant" Title="Untitled Page" %>

<%@ Register Src="../Controls/MerchantInfoAddressInfo.ascx" TagName="MerchantInfoAddressInfo"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<link href="../css/publish.css" rel="stylesheet" type="text/css" />
<link href="../css/common.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.trnone{
    display:none;
    }
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
	background-image:url("http://img.china.alibaba.com/images/cn/common/icon/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>
<form runat="server" id="aspnetForm">

    <script type="text/javascript" language="javascript">
function GetCheckBoxListCheckNum(checkobjectid)
{
    var selectedItemCount = 0;
    var liIndex = 0;
    var currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    while (currentListItem != null)
    {
        if (currentListItem.checked) selectedItemCount++;
        liIndex++;
        currentListItem = document.getElementById(checkobjectid + '_' + liIndex.toString());
    }
    return selectedItemCount;
}

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

function checkMerchantType()
{
    var rblCapitalTypeID = "<%=this.rblMerchantType.ClientID %>";
    if(GetCheckNum(rblCapitalTypeID.replace(/_/g,"$")) <= 0){
        document.getElementById("spMerchantType").innerHTML = "&nbsp;&nbsp;&nbsp;请选择招商类别！";
        document.getElementById("spMerchantType").className = "noteawoke";
        document.getElementById(rblCapitalTypeID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spMerchantType").innerHTML = "";
        document.getElementById("spMerchantType").className = "";
		return true;
	}
}

function checkMerchantTopic()
{
    var txtCapitalNameID = "<%=this.txtMerchantTopic.ClientID %>";
    var obj = document.getElementById(txtCapitalNameID);
    if(obj.value == "")
    {
        document.getElementById("spMerchantTopic").innerHTML = "&nbsp;&nbsp;&nbsp;招商主题必须填写！";
        document.getElementById("spMerchantTopic").className = "noteawoke";
        obj.focus();
        //obj.select();
        return false;
    }
    else if(obj.value.length > 20)
    {
        document.getElementById("spMerchantTopic").innerHTML = "";
        document.getElementById("spMerchantTopic").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写招商主题，限20字以内！";
        document.getElementById("spMerchantTopic").className = "noteawoke";
        obj.focus();
        //obj.select();
        return false;
    }
    else
    {
        document.getElementById("spMerchantTopic").innerHTML = "";
        document.getElementById("spMerchantTopic").className = "";
        return true;
    }
}

function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()");
}

function checkCooperationDemand()
{
    var cblCooperationDemandTypeID = "<%=this.cblCooperationDemandType.ClientID %>";
    
    if(GetCheckBoxListCheckNum(cblCooperationDemandTypeID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "&nbsp;&nbsp;&nbsp;请至少选择一种合作方式！";
        document.getElementById("spCooperationDemand").className = "noteawoke";
        document.getElementById(cblCooperationDemandTypeID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCooperationDemand").innerHTML = "";
        document.getElementById("spCooperationDemand").className = "";
		return true;
	}
}

function checkCapitalTotal()
{
    var id = "<%=this.txtCapitalTotal.ClientID %>";
    var str = document.getElementById(id).value.trim();
    document.getElementById(id).value = str;
    filter = /^[0-9]*[1-9][0-9]*$/;
    if(str == "" || filter.test(str)){
        document.getElementById("spCapitalTotal").innerHTML = "";
        document.getElementById("spCapitalTotal").className = "";
        return true;
    }
    else{
        document.getElementById("spCapitalTotal").innerHTML = "&nbsp;&nbsp;&nbsp;总投资额必须为数字，请正确填写！";
        document.getElementById("spCapitalTotal").className = "noteawoke";
        document.getElementById("spCapitalTotal").focus();
        return false;
    }
}

function checkZoneAbout()
{
    var id = "<%=this.txtZoneAbout.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spZoneAbout").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的主题介绍！";
        document.getElementById("spZoneAbout").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(obj.value.length > 0 && obj.value.length < 50)
    {
        document.getElementById("spZoneAbout").innerHTML = "&nbsp;&nbsp;&nbsp;您的主题介绍过于简短，必须在50字以上！";
        document.getElementById("spZoneAbout").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(obj.value.length > 2000)
    {
        document.getElementById("spZoneAbout").innerHTML = "&nbsp;&nbsp;&nbsp;主题介绍必须在2000字以内！";
        document.getElementById("spZoneAbout").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spZoneAbout").innerHTML = "";
        document.getElementById("spZoneAbout").className = "";
        return true;
    }
}


function checkKeyword()
{
    var key1ID = "<%=this.txtKeyword1.ClientID %>";
    var key2ID = "<%=this.txtKeyword2.ClientID %>";
    var key3ID = "<%=this.txtKeyword3.ClientID %>";
    
    var revalue = true;
    var filter=/^\s*[\u4e00-\u9fa5A-Za-z0-9_]{0,10}\s*$/;
    if(filter.test(document.getElementById(key1ID).value)&&filter.test(document.getElementById(key2ID).value)&&filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "";
        document.getElementById("spKeyMsg").className = "";
        return true;
    }
    if (!filter.test(document.getElementById(key1ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key1ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key2ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key2ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key3ID).focus();
        return false;
    }
}

function checkMerchantInfoAddress()
{
    var id = "<%=this.MerchantInfoAddressInfo1.ClientID %>";
    return eval(id+"_AddContact.checkAll()");
}

function CheckForm()
{
    var revalue = true;
    
    if(!checkMerchantType()){
        if(revalue) revalue = false;}
    if(!checkMerchantTopic()){
        if(revalue) revalue = false;}
    if(!checkIndustry()){
        if(revalue) revalue = false;}
    if(!checkCooperationDemand()){
        if(revalue) revalue = false;}
    if(!checkCapitalTotal()){
        if(revalue) revalue = false;}    
    if(!checkZoneAbout()){
        if(revalue) revalue = false;}
    if(!checkKeyword()){
        if(revalue) revalue = false;}  
    if(!checkMerchantInfoAddress()){
        if(revalue) revalue = false;}  
    return revalue;
}

document.getElementById("aspnetForm").onsubmit = CheckForm;
    </script>

    <script type="text/javascript" language="javascript">
        function switchPublish()
        {
            var tag = document.getElementById("hdswitchpublish").value;
            var objs = document.getElementsByName("trswitchpublish");
            if(objs == null)
                return;
            var style = "";
            if(tag == 1){
                style = "trnone";  
                document.getElementById("hdswitchpublish").value = 0;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到完整发布</a>）</span>';
            }
            else{
                document.getElementById("hdswitchpublish").value = 1;
                document.getElementById("switchtext").innerHTML = '带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）';
            }
            //alert(objs.length);
            for(var i=0; i <objs.length; i++)
            {
                objs[i].className = style;
            }
        }
    </script>

    <input type="hidden" id="hdswitchpublish" value="1" />
    <div id="mainconbox">
        <div class="titled">
            <div class="stepsbox">
                <ul>
                    <li class="liwai">修改招商项目信息</li>
                </ul>
            </div>
        </div>
        <div class="blank6">
        </div>
        <div id="switchtext">
            带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）</div>
        <div class="blank0">
        </div>
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7" style="height: 2px">
                    <span class="hong">* </span><strong>招商类别：</strong></td>
                <td width="618">
                    <asp:radiobuttonlist id="rblMerchantType" runat="server" repeatdirection="Horizontal"
                        repeatlayout="Flow">
                    </asp:radiobuttonlist>
                    <span id="spMerchantType"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <strong>招商主题：</strong></td>
                <td>
                    <asp:textbox id="txtMerchantTopic" onchange="checkMerchantTopic" runat="server" width="270px"></asp:textbox>
                    <span id="spMerchantTopic"></span>
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属区域：</strong></td>
                <td width="618">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属行业：</strong></td>
                <td width="630">
                    <uc2:SelectIndustryControl MaxCount="3" ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>合作方式：</strong></td>
                <td valign="top">
                    <asp:checkboxlist id="cblCooperationDemandType" runat="server" repeatdirection="Horizontal"
                        repeatlayout="Flow">
                    </asp:checkboxlist>
                    &nbsp; <span class="hong">(可多选)</span> <span id="spCooperationDemand"></span>
                </td>
            </tr>
            <tr id="trswitchpublish" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>总投资：</strong></td>
                <td width="630">
                    <asp:dropdownlist id="ddlCapitalCurrency" runat="server">
                    </asp:dropdownlist>
                    <asp:textbox id="txtCapitalTotal" onchange="checkCapitalTotal();" runat="server"
                        width="75px"></asp:textbox>
                    万元 <span id="spCapitalTotal"></span>
                </td>
            </tr>
            <tr id="tr1" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>引资金额：</strong></td>
                <td width="630">
                    <asp:dropdownlist id="ddlMerchantCurrency" runat="server">
                    </asp:dropdownlist>
                    &nbsp;<asp:dropdownlist id="ddlMerchantTotal" runat="server">
                    </asp:dropdownlist></td>
            </tr>
            <tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>产业简介：</strong>
                    <br />
                    （50－2000字）</td>
                <td width="618" valign="top">
                    <textarea id="txtZoneAbout" onchange="checkZoneAbout();" runat="server" style="width: 474px;
                        height: 173px"></textarea><span id="spZoneAbout"></span>
                    <br />
                    <span class="hui">请从投资环境、优惠政策、项目进度情况等方面进行介绍，联系方式（电话、传真、手机、电子邮箱等）请在下一步填写，此处重复填写将无法通过审核。</span>
                </td>
            </tr>
            <tr id="tr2" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>招商关键字：</strong></td>
                <td width="630" valign="top">
                    <asp:textbox id="txtKeyword1" onchange="checkKeyword();" runat="server" width="72px"></asp:textbox>
                    &nbsp;<asp:textbox id="txtKeyword2" onchange="checkKeyword();" runat="server" width="72px"></asp:textbox>&nbsp;
                    <asp:textbox id="txtKeyword3" onchange="checkKeyword();" runat="server" width="72px"></asp:textbox>
                    <br />
                    <span id="spKeyMsg"></span><span class="hui">用户现在更多地通过搜索来寻找资源，定义跟相关的关键字能让您的需求更容易被潜在合作方找到。</span>
                </td>
            </tr>
            <tr id="tr3" name="trswitchpublish">
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <strong>图片上传：</strong></td>
                <td width="618" valign="top" class="nonepad">
                    <uc3:ImageUploadControl ID="ImageUploadControl1" NoneCount="3" Count="3" InfoType="Merchant"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>有效期：</strong></td>
                <td width="630">
                    <asp:dropdownlist id="ddlValiditeTerm" runat="server">
                        <asp:ListItem Value="3">三个月内</asp:ListItem>
                        <asp:ListItem Value="6">半年内</asp:ListItem>
                        <asp:ListItem Value="12">一年内</asp:ListItem>
                    </asp:dropdownlist>
                </td>
            </tr>
        </table>
        <div class="blank0">
        </div>
        <div class="dottedlline">
        </div>
        <!--联系方式 -->
        <div class="infozi">
            <strong>招商机构联系方式</strong></div>
        <uc4:MerchantInfoAddressInfo ID="MerchantInfoAddressInfo1" runat="server"></uc4:MerchantInfoAddressInfo>
        <!--申请域名 建立我的展厅 -->
        <div class="blank0">
        </div>
        <div class="mbbuttom">
            <asp:button id="btnUpdate" runat="server" text="修改" onclick="btnUpdate_Click" width="144px" />
        </div>
    </div>
</form>
