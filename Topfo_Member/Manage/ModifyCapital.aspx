<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false"
    CodeFile="ModifyCapital.aspx.cs" Inherits="Manage_ModifyCapital" Title="Untitled Page" %>
<%@ Register Src="../Controls/CapitalAddressInfo.ascx" TagName="CapitalAddressInfo"
    TagPrefix="uc4" %>

<%@ Register Src="../Controls/ZoneMoreSelectControl.ascx" TagName="ZoneMoreSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<!--
<link href="/css/publish.css" rel="stylesheet" type="text/css" />
 <link href="../css/publish.css" rel="stylesheet" type="text/css" />
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
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>
-->
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
	var checkobject = document.getElementsByName(checkobjectname);
//	var checkobject = eval("document.all." + checkobjectname + "");
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

function checkCapitalName()
{
    var txtCapitalNameID = "<%=this.txtCapitalName.ClientID %>";
    var obj = document.getElementById(txtCapitalNameID);
    if(obj.value == "")
    {
        document.getElementById("spCapitalName2").innerHTML = "&nbsp;&nbsp;&nbsp;投资需求名称必须填写！";
        document.getElementById("spCapitalName2").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,1,60))
    {
        document.getElementById("spCapitalName2").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写投资名称，限30字以内！";
        document.getElementById("spCapitalName2").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalName2").innerHTML = "";
        document.getElementById("spCapitalName2").className = "";
        return true;
    }
}

function checkCapitalType()
{
    var rblCapitalTypeID = "<%=this.rblCapitalType.ClientID %>";
    var rblCapitalTypeName = rblCapitalTypeID.replace(/_/g,"$");
    if(GetCheckNum(rblCapitalTypeName) <= 0){
        document.getElementById("spCapitalType").innerHTML = "&nbsp;&nbsp;&nbsp;请选择资本类型！";
        document.getElementById("spCapitalType").className = "noteawoke";
        document.getElementById(rblCapitalTypeID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCapitalType").innerHTML = "";
        document.getElementById("spCapitalType").className = "";
		return true;
	}
}

function checkCooperationDemand()
{
    var chkLstCooperationDemandID = "<%=this.chkLstCooperationDemand.ClientID %>";
    
    if(GetCheckBoxListCheckNum(chkLstCooperationDemandID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "&nbsp;&nbsp;&nbsp;请选择投资方式！";
        document.getElementById("spCooperationDemand").className = "noteawoke";
        document.getElementById(chkLstCooperationDemandID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCooperationDemand").innerHTML = "";
        document.getElementById("spCooperationDemand").className = "";
		return true;
	}
}

function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()");
}

function checkCapitalIntent()
{
    var id = "<%=this.txtCapitalIntent.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spCaptialIntent").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的投资意向！";
        document.getElementById("spCaptialIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spCaptialIntent").innerHTML = "&nbsp;&nbsp;&nbsp;您的投资意向过于简短，必须在50字以上！";
        document.getElementById("spCaptialIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spCaptialIntent").innerHTML = "&nbsp;&nbsp;&nbsp;投资意向必须在5000字以内！";
        document.getElementById("spCaptialIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCaptialIntent").innerHTML = "";
        document.getElementById("spCaptialIntent").className = "";
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

function checkCapitalAddress()
{
    var id = "<%=this.CapitalAddressInfo1.ClientID %>";
    return eval(id+"_AddContact.checkAll()");
}

function CheckForm()
{
    var revalue = true;
    
    if(!checkCapitalName()){
        if(revalue) revalue = false;}
    if(!checkCapitalType()){
        if(revalue) revalue = false;}
    if(!checkCooperationDemand()){
        if(revalue) revalue = false;}
    if(!checkIndustry()){
        if(revalue) revalue = false;}
    if(!checkCapitalIntent()){
        if(revalue) revalue = false;}
    if(!checkKeyword()){
        if(revalue) revalue = false;}  
    if(!checkCapitalAddress()){
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
        document.getElementById("switchtext").innerHTML = '基本信息<span>（您可以<a href="javascript:switchPublish();" class="lanlink">切换到完整发布</a>）</span>';
    }
    else{
        document.getElementById("hdswitchpublish").value = 1;
        document.getElementById("switchtext").innerHTML = '基本信息<span>（您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）</span>';
    }
    //alert(objs.length);
    for(var i=0; i <objs.length; i++)
    {
        objs[i].className = style;
    }
}
</script><input type="hidden" id="hdswitchpublish" value="1" />
    <div id="mainconbox">
        <div class="titled">
            <div class="stepsbox">
            <ul>
                <li class="liwai">修改投资信息</li>
            </ul>
            </div>
            <div class="clear">
            </div>
        </div>
        <div>
            带<span class="hong">*</span> 的为必填项
        </div>
        <div class="blank6">
        </div>
        <div class="dottedlline">
        </div>
        <div class="blank6">
        </div>
        <div class="infozi" id="switchtext">
            基本信息<span>（您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）</span></div>
        <table border="0" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td width="133" align="right" bgcolor="#F7F7F7">
                   <span class="hong">*</span> <strong>投资需求名称：</strong></td>
                <td width="625">
                    <strong>
                  <asp:TextBox ID="txtCapitalName" onchange="JavaScrpit:checkCapitalName()" runat="server" Width="299px"></asp:TextBox></strong>
                        <span id="spCapitalName2"></span>
              </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>资本类型：</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblCapitalType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        Height="2px">
                    </asp:RadioButtonList>
                    <span id="spCapitalType"></span>
              </td>
            </tr>
            <tr>
                <td align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>投资方式：</strong></td>
                <td>
                    <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                        RepeatDirection="Horizontal" />
                    &nbsp;<span class="hui">（可多选）</span>
                    <span id="spCooperationDemand"></span>
              </td>
            </tr>
            <tr id="trswitchpublish" name="trswitchpublish">
                <td width="133" align="right" bgcolor="#F7F7F7">
                    <strong>投资区域：</strong></td>
                <td width="625">
                    <uc1:ZoneMoreSelectControl ID="ZoneMoreSelectControl1" runat="server" /><span style="color: #0000ff"></span>
              </td>
            </tr>
            <tr>
                <td width="133" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>投资行业：</strong></td>
                <td width="625">
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                    
              </td>
            </tr>
            <tr>
                <td width="133" align="right" bgcolor="#F7F7F7">
                    <span class="hong">* </span><strong>投资金额：</strong></td>
                <td width="625">
                    <asp:DropDownList ID="ddlCurrency" runat="server" Width="76px">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlCapital" runat="server">
              </asp:DropDownList></td>
            </tr>
            <tr>
                <td width="133" align="right" valign="top" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>投资意向：</strong>
                    <br /></td>
              <td width="625" valign="top">
                                       <label>
                        <textarea id="txtCapitalIntent" onchange="JavaScrpit:checkCapitalIntent()" runat="server" cols="50" rows="10" style="width: 558px;
                            height: 300px"></textarea>
                    </label>
                  <span id="spCaptialIntent"></span>
				   <span class="hui">
                      <br />
                   请从投资方向、投资要求等方面进行介绍，联系方式（电话、传真、手机、电子邮箱等）请在下一步填写，此处重复填写将无法通过审核。               </span>                </td>
            </tr>
            <tr id="tr1" name="trswitchpublish">
                <td width="133" align="right" bgcolor="#F7F7F7">
                    <strong>投资关键字：</strong></td>
                <td width="625" valign="top">
                <a href="#" class="lanlink">如何定义关键字</a>
                        <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                        &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                        <br />
                        <span id="spKeyMsg"></span>
						  <span class="hui">用户现在更多地通过搜索来寻找资源，定义相关的关键字能让您的需求更容易被项目方找到。</span>
                  
              </td>
            </tr>
            <tr id="tr2" name="trswitchpublish">
                <td width="133" align="right" bgcolor="#F7F7F7">
                    <strong>图片上传：</strong></td>
                <td width="625" valign="top" class="nonepad">
                    <uc3:ImageUploadControl ID="ImageUploadControl1" InfoType="Capital" runat="server" />
                    
              </td>
            </tr>
            <tr>
                <td width="133" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>有效期：</strong></td>
                <td width="625">
                 <%--<asp:DropDownList ID="ddlValiditeTerm" runat="server">
                        <asp:ListItem Value="3">三个月内</asp:ListItem>
                        <asp:ListItem Value="6">半年内</asp:ListItem>
                        <asp:ListItem Value="12">一年内</asp:ListItem>
              </asp:DropDownList>--%> 
               
                  <p>
                     自发布之日起<asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                     Height="2px">
                                </asp:RadioButtonList></p>
              </td>
            </tr>
      </table>
        <div class="blank0">
        </div>
        <div class="dottedlline">
        </div>
        <!--附加信息 -->
        <div class="blank0">
        </div>
        <!--联系方式 -->
        <div class="infozi">
            联系方式</div>
        <uc4:capitaladdressinfo id="CapitalAddressInfo1" runat="server" />
        <div class="mbbuttom">
            <asp:Button ID="btnUpdate" runat="server" Text="修改" Width="145px" OnClick="btnUpdate_Click" /></div>
    </div>
</asp:Content>
