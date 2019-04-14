<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="publishCapitalBak.aspx.cs"
    Inherits="publishCapital" Title="Untitled Page" %>
<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--<link href="../css/publishCaptal.css" rel="stylesheet" type="text/css" />
<link href="../css/common.css" rel="stylesheet" type="text/css" />
<style type="text/css">
.trnone{
display:none;
}
.noteawoke{ background: url(../images/reg_step/icon_no.gif) no-repeat 8px 3px #fff5d8; border:#ff7300 1px solid; color:black;margin-left:10px; margin-right:10px; padding:3px 10px 3px 30px;color:#878585}
.divcheck {CLEAR: left;}
.divcheck SPAN {FONT-SIZE: 12px; margin-left:8px;margin-right:15px; CURSOR: pointer}
.btn2{ background:url(./images/btn03.jpg) no-repeat 0 0;font-size:12px;width:146px;height:24px;display:block; border:0;cursor:pointer;}

</style>--%>

<script language="javascript" type="text/javascript">
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

function CheckGovName(){
    var txtGovNameID = "<%=this.txtGovName.ClientID %>";
    var obj = document.getElementById(txtGovNameID);
    if(!checkByteLength(obj.value,1,60))
    {
        document.getElementById("spGovName").innerHTML = "请正确填写投资机构名称";
        document.getElementById("spGovName").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spGovName").innerHTML = "";
        document.getElementById("spGovName").className = "";
        return true;
    }
}

function CheckGovIntro(){
    var txtGovIntroID = "<%=this.txtGovIntro.ClientID %>";
    var obj = document.getElementById(txtGovIntroID);
    if(!checkByteLength(obj.value,1,5000))
    {
        document.getElementById("spGovIntro").innerHTML = "请正确填写投资机构介绍";
        document.getElementById("spGovIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spGovIntro").innerHTML = "";
        document.getElementById("spGovIntro").className = "";
        return true;
    }
}

function CheckCapitalName(){
    var txtCapitalNameID = "<%=this.txtCapitalName.ClientID %>";
    var obj = document.getElementById(txtCapitalNameID);
    if(!checkByteLength(obj.value,1,60))
    {
        document.getElementById("spCapitalName").innerHTML = "请正确填写投资意向，30字以内";
        document.getElementById("spCapitalName").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalName").innerHTML = "";
        document.getElementById("spCapitalName").className = "";
        return true;
    }
}

function checkCapitalType()
{
    var rblCapitalTypeID = "<%=this.rblfinancingTarget.ClientID %>";
    var rblCapitalTypeName = rblCapitalTypeID.replace(/_/g,"$");
    if(GetCheckNum(rblCapitalTypeName) <= 0){
        document.getElementById("spCapitalType").innerHTML = "请选择资本类型";
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

function checkIndustry()
{
    var id = "<%=this.SelectIndustryControl1.ClientID %>";
    return eval(id+"_SelectIndustry.check()");
}

function checkCurrency()
{
    var rblCurrencyID = "<%=this.rblCurreny.ClientID %>";
    var rblCurrencyIDName = rblCurrencyID.replace(/_/g,"$");
    if(GetCheckNum(rblCurrencyIDName) <= 0){
        document.getElementById("spCurrency").innerHTML = "请选择单个项目可投资资金";
        document.getElementById("spCurrency").className = "noteawoke";
        document.getElementById(rblCurrencyID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCurrency").innerHTML = "";
        document.getElementById("spCurrency").className = "";
		return true;
	}
}

function checkStage()
{
    var rdlStageID = "<%=this.rblStage.ClientID %>";
    var rblStageIDName = rdlStageID.replace(/_/g,"$");
    if(GetCheckNum(rblStageIDName) <= 0){
        document.getElementById("spStage").innerHTML = "请选择项目阶段";
        document.getElementById("spStage").className = "noteawoke";
        document.getElementById(rdlStageID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spStage").innerHTML = "";
        document.getElementById("spStage").className = "";
		return true;
	}
}

function checkJoinManage()
{
    var rdlJoinManageID = "<%=this.rdlJoinManage.ClientID %>";
    var rdlJoinManageName = rdlJoinManageID.replace(/_/g,"$");
    if(GetCheckNum(rdlJoinManageName) <= 0){
        document.getElementById("spJoinManage").innerHTML = "请选择是否参与项目方管理";
        document.getElementById("spJoinManage").className = "noteawoke";
        document.getElementById(rdlJoinManageID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spJoinManage").innerHTML = "";
        document.getElementById("spJoinManage").className = "";
		return true;
	}
}

function ChecktCapitalIntent(){
    var txtCapitalIntentID = "<%=this.txtCapitalIntent.ClientID %>";
    var obj = document.getElementById(txtCapitalIntentID);
    if(!checkByteLength(obj.value,1,10000))
    {
        document.getElementById("spCapitalIntent").innerHTML = "请正确您的投资意向说明";
        document.getElementById("spCapitalIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalIntent").innerHTML = "";
        document.getElementById("spCapitalIntent").className = "";
        return true;
    }
}

function checkCooperationDemand()
{
    var chkLstCooperationDemandID = "<%=this.chkLstCooperationDemand.ClientID %>";
    
    if(GetCheckBoxListCheckNum(chkLstCooperationDemandID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "请选择投资方式";
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
        document.getElementById("spKeyMsg").innerHTML = "请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key1ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key2ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key2ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "请正确填写关键字";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key3ID).focus();
        return false;
    }
}

function checkValiditeTerm()
{
    var rdlValiditeTermID = "<%=this.rdlValiditeTerm.ClientID %>";
    var rdlValiditeTermIDName = rdlValiditeTermID.replace(/_/g,"$");
    if(GetCheckNum(rdlValiditeTermIDName) <= 0){
        document.getElementById("spValiditeTerm").innerHTML = "请选择有效期";
        document.getElementById("spValiditeTerm").className = "noteawoke";
        document.getElementById(rdlValiditeTermID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spValiditeTerm").innerHTML = "";
        document.getElementById("spValiditeTerm").className = "";
		return true;
	}
}

function CheckCheck()
{
    var ckbCheckID = "<%=this.ckbCheck.ClientID %>";
    var obj = document.getElementById(ckbCheckID);
    if(!obj.checked){
        document.getElementById("spCheck").innerHTML = "发布前请阅读并接受接受服务协议";
        document.getElementById("spCheck").className = "noteawoke";
        obj.focus();
		return false;
	}
	else
	{
	    document.getElementById("spCheck").innerHTML = "";
        document.getElementById("spCheck").className = "";
		return true;
	}
}

function FormSubmit(){
    var revalue = true;
    
    if(!CheckGovName()){
        if(revalue) revalue = false;}
    if(!CheckGovIntro()){
        if(revalue) revalue = false;}
    if(!CheckCapitalName()){
        if(revalue) revalue = false;}
    if(!checkCapitalType()){
        if(revalue) revalue = false;}
    if(!checkCurrency()){
        if(revalue) revalue = false;}
    if(!checkIndustry()){
        if(revalue) revalue = false;}
    if(!checkStage()){
        if(revalue) revalue = false;}
    if(!checkJoinManage()){
        if(revalue) revalue = false;}
    if(!checkCooperationDemand()){
        if(revalue) revalue = false;}
    if(!checkKeyword()){
        if(revalue) revalue = false;}
    if(!checkValiditeTerm()){
        if(revalue) revalue = false;}  
    if(!ChecktCapitalIntent()){
        if(revalue) revalue = false;}
    if(!CheckCheck()){
        if(revalue) revalue = false;}  
    return revalue;
}

document.getElementById("aspnetForm").onsubmit = FormSubmit;
</script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                发布投资需求</div>
            <div class="right">
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="note01">
            <b>声明：</b>严禁发布虚假、欺骗或误导性信息，基于此信息而产生的任何法律后果由发布者自行承担。</div>
        <div class='dottedlline'>
        </div>
        <div class="blank6">
        </div>
        <div class="infozi" id="switchtext">
            <span class="fl4b">基本信息</span>（带<span class="hong">*</span>的为必填项）</div>
        <table border="0" cellspacing="1" cellpadding="0" class="tabbiank">
            <tr>
                <td width="162" class="tdgray1">
                    <span class="hong">*</span><b>投资机构名称：</b></td>
                <td width="593" valign="top">
                    <asp:TextBox ID="txtGovName" runat="server" onchange="JavaScrpit:CheckGovName()" Height="20px" Width="277px"></asp:TextBox>
                    <span id="spGovName"></span>
                    </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>投资方简介：</b></td>
                <td width="593" valign="top">
                    <textarea cols="50" rows="10" id="txtGovIntro" runat="server" onchange="JavaScrpit:CheckGovIntro()" style="width: 540px;
                        height: 100px"></textarea>
                    <span id="spGovIntro"></span>
                    <br />
                    <span class="hui">不少于50字</span> <a href="">查看范例</a></td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>投资需求名称：</b></td>
                <td width="593">
                    <asp:TextBox ID="txtCapitalName" runat="server" onchange="JavaScrpit:CheckCapitalName()" Height="20px" Width="319px"></asp:TextBox>
                    <span id="spCapitalName"></span>
                    <p>
                        <span class="hui">此栏是在外部展示的标题名称，最好不超过18个汉字。</span> <a href="">查看范例</a></p>
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>资本类型：</b></td>
                <td width="593">
                    <asp:RadioButtonList ID="rblfinancingTarget" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        Height="2px">
                    </asp:RadioButtonList>
                    <span id="spCapitalType"></span>
                    </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>拟投资行业：</b></td>
                <td width="593">
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>拟投向区域：</b></td>
                <td width="593">
                    <uc1:ZoneSelect id="ZoneSelect1" runat="server">
                    </uc1:ZoneSelect></td>
            </tr>
            <tr>
                <td width="180" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>单项目可投资金额：</b></td>
                <td width="593">
                    <p>
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><br />
                        <span class="hui">金额的货币单位为人民币</span><span id="spCurrency"></span></p>
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top">
                    <span class="hong">*</span><b>投资项目阶段：</b></td>
                <td width="593">
                    <p>
                        <asp:RadioButtonList ID="rblStage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spStage"></span>
                    </p>
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1">
                    <span class="hong">*</span><b>投资方式：</b></td>
                <td width="593">
                    <p>
                        <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" /><span id="spCooperationDemand"></span>
                    </p>
                </td>
            </tr>
            <tr>
                <td width="180" class="tdgray1" valign="top">
                    <b>是否参与项目方管理：</b></td>
                <td width="593">
                    <p>
                        <asp:RadioButtonList ID="rdlJoinManage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><span id="spJoinManage"></span></p> 
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1">
                    <span class="hong">*</span><b>投资意向详细说明：</b></td>
                <td width="593" valign="top">
                    <p>
                        <textarea id="txtCapitalIntent" runat="server" cols="50" onchange="ChecktCapitalIntent();" style="width: 558px; height: 204px"></textarea>
                        <span id="spCapitalIntent"></span><br />
                        <span class="hui">1.填写投资的对象、以及对项目方的要求等；<br />
                            2.不少于20字，不能含有联系方式如电话、E-mail等，否则将无法通过审核。</span><a href="">查看范例</a></p>
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1">
                    <b>关键字：</b></td>
                <td width="593">
                    <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px" Height="20px"></asp:TextBox>
                    <span id="spKeyMsg"></span>
                    <p>
                        <span class="hui">填写与投资意向相关的关键字更容易被项目方搜索到，空格内不能使用标点符号。</span></p>
                </td>
            </tr>
            <tr>
                <td width="162" class="tdgray1" valign="top" style="height: 20px">
                    <span class="hong">*</span><b>意向有效期限：</b></td>
                <td width="593" style="height: 20px">
                    <p>
                        自发布之日起<asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" Height="2px">
                            <asp:ListItem Value="3" Text="三个月内"></asp:ListItem>
                            <asp:ListItem Value="6" Text="半年内"></asp:ListItem>
                            <asp:ListItem Value="9" Text="一年内"></asp:ListItem>
                        </asp:RadioButtonList><span id="spValiditeTerm"></span></p>
                </td>
            </tr>
            <tr>
                        <td align="right" class="tdgray1">
                            <strong>验证码：</strong></td>
                        <td>
                            <label>
                                <asp:TextBox ID="ImageCode"  runat="server" Width="120px"></asp:TextBox> <img src="../ValidateNumber.aspx"  onclick="this.src='../ValidateNumber.aspx?temp=' + (new Date())" />
                            </label>
                        </td>
                    </tr>
        </table>
        <!--附加信息-->
        <div class="blank0">
        </div>
        <!--联系方式-->
        <div class="mbbuttom">
            <p>
                <asp:CheckBox ID="ckbCheck" onclick="JavaScript:CheckCheck();" Checked="true" runat="server" />
                我已阅读并同意<a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank">拓富·中国招商投资网服务</a>
                <span id="spCheck"></span></p>
            <input type="button" value="填好了，确认一下联系方式" class="setup" runat="server" id="btnSubmit" onserverclick="btnSubmit_ServerClick" />
        </div>
    </div>
</asp:Content>
