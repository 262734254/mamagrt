<%@ Page Language="C#" AutoEventWireup="true" CodeFile="publishCapital1.aspx.cs" Inherits="offer_publishCapital1" %>
<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
    <%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc3" %>
  <%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"  TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>资源发布与管理</title>
<link href="css/member.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
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

function checkRegister()
{
    var rdlRegisterID = "<%=this.rblRegister.ClientID %>";
    var rblRegisterIDName = rdlRegisterID.replace(/_/g,"$");
    if(GetCheckNum(rblRegisterIDName) <= 0){
        document.getElementById("spRegister").innerHTML = "请选择机构注册资金";
        document.getElementById("spRegister").className = "noteawoke";
        document.getElementById(rdlRegisterID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spRegister").innerHTML = "";
        document.getElementById("spRegister").className = "";
		return true;
	}
}

function checkScale()
{
    var rdlScaleID = "<%=this.rblScale.ClientID %>";
    var rblScaleIDName = rdlScaleID.replace(/_/g,"$");
    if(GetCheckNum(rblScaleIDName) <= 0){
        document.getElementById("spScale").innerHTML = "请选择机构团队规模";
        document.getElementById("spScale").className = "noteawoke";
        document.getElementById(rdlScaleID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spScale").innerHTML = "";
        document.getElementById("spScale").className = "";
		return true;
	}
}
function checkAverage()
{
    var rdlAverageID = "<%=this.rblAverage.ClientID %>";
    var rblAverageIDName = rdlAverageID.replace(/_/g,"$");
    if(GetCheckNum(rblAverageIDName) <= 0){
        document.getElementById("spAverage").innerHTML = "请选择机构年平均投资事件数";
        document.getElementById("spAverage").className = "noteawoke";
        document.getElementById(rdlAverageID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spAverage").innerHTML = "";
        document.getElementById("spAverage").className = "";
		return true;
	}
}
function checkCount()
{
    var rdlCountID = "<%=this.rblCount.ClientID %>";
    var rblCountIDName = rdlCountID.replace(/_/g,"$");
    if(GetCheckNum(rblCountIDName) <= 0){
        document.getElementById("spCount").innerHTML = "请选择机构成功投资事件总数";
        document.getElementById("spCount").className = "noteawoke";
        document.getElementById(rdlCountID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spCount").innerHTML = "";
        document.getElementById("spCount").className = "";
		return true;
	}
}
function checkScale()
{
    var rdlScaleID = "<%=this.rblScale.ClientID %>";
    var rblScaleIDName = rdlScaleID.replace(/_/g,"$");
    if(GetCheckNum(rblScaleIDName) <= 0){
        document.getElementById("spScale").innerHTML = "请选择机构团队规模";
        document.getElementById("spScale").className = "noteawoke";
        document.getElementById(rdlScaleID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spScale").innerHTML = "";
        document.getElementById("spScale").className = "";
		return true;
	}
}
function checkScale()
{
    var rdlScaleID = "<%=this.rblScale.ClientID %>";
    var rblScaleIDName = rdlScaleID.replace(/_/g,"$");
    if(GetCheckNum(rblScaleIDName) <= 0){
        document.getElementById("spScale").innerHTML = "请选择机构团队规模";
        document.getElementById("spScale").className = "noteawoke";
        document.getElementById(rdlScaleID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spScale").innerHTML = "";
        document.getElementById("spScale").className = "";
		return true;
	}
}
function checkScale()
{
    var rdlScaleID = "<%=this.rblScale.ClientID %>";
    var rblScaleIDName = rdlScaleID.replace(/_/g,"$");
    if(GetCheckNum(rblScaleIDName) <= 0){
        document.getElementById("spScale").innerHTML = "请选择机构团队规模";
        document.getElementById("spScale").className = "noteawoke";
        document.getElementById(rdlScaleID).focus();
		return false;
	}
	else
	{
	    document.getElementById("spScale").innerHTML = "";
        document.getElementById("spScale").className = "";
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
function ChecktCapitalSummary(){
    var txtCapitalSummaryID = "<%=this.txtCapitalSummary.ClientID %>";
    var obj = document.getElementById(txtCapitalSummaryID);
    if(!checkByteLength(obj.value,1,10000))
    {
        document.getElementById("spCapitalSummary").innerHTML = "请正确投资需求摘要";
        document.getElementById("spCapitalSummary").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalSummary").innerHTML = "";
        document.getElementById("spCapitalSummary").className = "";
        return true;
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

function ChecktCapitalStructure(){
    var txtCapitalStructureID = "<%=this.txtCapitalStructure.ClientID %>";
    var obj = document.getElementById(txtCapitalStructureID);
    if(!checkByteLength(obj.value,1,10000))
    {
        document.getElementById("spCapitalStructure").innerHTML = "请正确投资机构简介";
        document.getElementById("spCapitalStructure").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spCapitalStructure").innerHTML = "";
        document.getElementById("spCapitalStructure").className = "";
        return true;
    }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="60" border="0" cellpadding="0" cellspacing="0" style="text-align:center; line-height:20px; margin:15px 0;" class="f_14">
  <tr>
    <td width="130" class="strong">发布资源只需<span class="f_red">2</span>步：</td>
    <td width="125" style="background:url(images/member_bg1_on.gif) no-repeat;" class="f_red strong">第一步<br />
      填写项目信息</td>
    <td width="50"><img src="images/member_icon1.gif" /></td>
    <td width="125" style="background:url(images/member_bg1_off.gif) no-repeat;">第二步<br />
      确认联系方式</td>
    <td>&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="f_14 f_red strong" style="padding:5px 10px;">资本资源发布</td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td width="145" class="tdbg"><span class="f_red">*</span> <strong>投资需求标题：</strong></td>
    <td><input name="txtCapitalName" type="text" size="25" />
      <span class="f_gray">标题最好控制在25个字以内</span></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>资本类型：</strong></td>
    <td>
	  <asp:RadioButtonList ID="rblfinancingTarget" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        Height="2px">
        </asp:RadioButtonList>
         <span id="spCapitalType" ></span>
   </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>所属区域：</strong></td>
   <td ><uc3:ZoneSelectControl id="ZoneSelect2" runat="server">
                    </uc3:ZoneSelectControl></td> 
    
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>拟投资行业：</strong></td>
     <td width="593">
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />

      </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>拟投向区域：</strong></td>
     <td width="593">
                    <uc1:ZoneSelect id="ZoneSelect1" runat="server">
                    </uc1:ZoneSelect></td>
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><span class="f_red">*</span> <strong>单项目可投资金额：</strong></td>
     <td width="593" style="height: 40px">
                    <p>
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                       <span class="f_gray">(单位/人民币) </span></p>
                </td>
    
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><span class="f_red">*</span> <strong>投资项目阶段：</strong></td>
     <td style="height: 40px" >
                        <asp:RadioButtonList ID="rblStage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spStage"></span>
                </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>机构注册资金：</strong></td>
    <td><asp:RadioButtonList ID="rblRegister" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spRegister"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><span class="f_red">*</span> <strong>机构团队规模：</strong></td>
    <td style="height: 40px"> <asp:RadioButtonList ID="rblScale" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spScale"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>机构年平均投资事件数：</strong></td>
    <td><asp:RadioButtonList ID="rblAverage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spAverage"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>机构成功投资事件总数：</strong></td>
    <td><asp:RadioButtonList ID="rblCount" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spCount"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>投资方式：</strong></td>
   <td width="593">   
           <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" /><span id="spCooperationDemand"></span>
                </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>是否参与项目方管理：</strong></td>
    <td width="593">
           <asp:RadioButtonList ID="rdlJoinManage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><span id="spJoinManage"></span>
                </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>投资需求摘要：</strong></td>
    <td><textarea id="txtCapitalSummary" runat="server" rows="5" onchange="ChecktCapitalSummary();" style="width:80%;"></textarea>
      <br />
      <span class="f_gray">用最简洁扼要的语言介绍您的投资需求，建议字数控制在200字以内！</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>投资意向详细说明：</strong></td>
    <td >
                        <textarea id="txtCapitalIntent" runat="server" rows="7" onchange="ChecktCapitalIntent();" style="width: 80%"></textarea>
                        <span id="spCapitalIntent"></span><br />
                        <span class="f_gray">请详细填写您的投资需求：如投资对象,及对项目方的要求等；联系方式请在下一步进行确认，不要在此填写，以免审核无法通过，谢谢！</span>
                </td>
   
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>意向有效期限：</strong></td>
     <td >
                        自发布之日起<asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" Height="2px">
                            <asp:ListItem Value="3" Text="三个月内"></asp:ListItem>
                            <asp:ListItem Value="6" Text="半年内"></asp:ListItem>
                            <asp:ListItem Value="9" Text="一年内"></asp:ListItem>
                        </asp:RadioButtonList><span id="spValiditeTerm"></span>
                </td>
   
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>投资机构简介：</strong></td>
    <td><textarea id="txtCapitalStructure" rows="7" runat="server" style="width:80%;"></textarea>
    <span id="spStructure"></span>
    <br />
    <span class="f_gray">机构的历史介绍，资本性质、投资条件、投资方向及运作团队，投资领域等介绍，以及之前运作的成功案例；</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>上传附件：</strong></td>
    
     <td width="618" valign="top" class="nonepad">
            <uc4:FilesUploadControl id="FilesUploadControl1" infotype="Project" runat="server" />
                       <span class="f_gray">您可以上传投资成功的案例资料及资本运作的相关文件等；</span>  </td>
  </tr>
</table>
<table width="100%" cellspacing="0" style="text-align:center;">
  <tr>
    <td height="40"><input type="checkbox" name="checkbox7" value="checkbox" />
    我已阅读<span class="f_red"><a href="#">《拓富·中国招商投资网服务协议》</a></span></td>
  </tr>
  <tr>
    <td><input type="submit" name="Submit33" value="下一步：确认联系方式" /></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
