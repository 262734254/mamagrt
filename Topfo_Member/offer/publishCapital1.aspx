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
<title>��Դ���������</title>
<link href="css/member.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
function checkCapitalType()
{
    var rblCapitalTypeID = "<%=this.rblfinancingTarget.ClientID %>";
    var rblCapitalTypeName = rblCapitalTypeID.replace(/_/g,"$");
    if(GetCheckNum(rblCapitalTypeName) <= 0){
        document.getElementById("spCapitalType").innerHTML = "��ѡ���ʱ�����";
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
        document.getElementById("spCurrency").innerHTML = "��ѡ�񵥸���Ŀ��Ͷ���ʽ�";
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
        document.getElementById("spStage").innerHTML = "��ѡ����Ŀ�׶�";
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
        document.getElementById("spRegister").innerHTML = "��ѡ�����ע���ʽ�";
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
        document.getElementById("spScale").innerHTML = "��ѡ������Ŷӹ�ģ";
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
        document.getElementById("spAverage").innerHTML = "��ѡ�������ƽ��Ͷ���¼���";
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
        document.getElementById("spCount").innerHTML = "��ѡ������ɹ�Ͷ���¼�����";
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
        document.getElementById("spScale").innerHTML = "��ѡ������Ŷӹ�ģ";
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
        document.getElementById("spScale").innerHTML = "��ѡ������Ŷӹ�ģ";
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
        document.getElementById("spScale").innerHTML = "��ѡ������Ŷӹ�ģ";
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
        document.getElementById("spCooperationDemand").innerHTML = "��ѡ��Ͷ�ʷ�ʽ";
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
        document.getElementById("spJoinManage").innerHTML = "��ѡ���Ƿ������Ŀ������";
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
        document.getElementById("spCapitalIntent").innerHTML = "����ȷ����Ͷ������˵��";
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
        document.getElementById("spCapitalSummary").innerHTML = "����ȷͶ������ժҪ";
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
        document.getElementById("spValiditeTerm").innerHTML = "��ѡ����Ч��";
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
        document.getElementById("spCapitalStructure").innerHTML = "����ȷͶ�ʻ������";
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
    <td width="130" class="strong">������Դֻ��<span class="f_red">2</span>����</td>
    <td width="125" style="background:url(images/member_bg1_on.gif) no-repeat;" class="f_red strong">��һ��<br />
      ��д��Ŀ��Ϣ</td>
    <td width="50"><img src="images/member_icon1.gif" /></td>
    <td width="125" style="background:url(images/member_bg1_off.gif) no-repeat;">�ڶ���<br />
      ȷ����ϵ��ʽ</td>
    <td>&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="f_14 f_red strong" style="padding:5px 10px;">�ʱ���Դ����</td>
  </tr>
</table>
<table cellspacing="0" class="mem_tab1">
  <tr>
    <td width="145" class="tdbg"><span class="f_red">*</span> <strong>Ͷ��������⣺</strong></td>
    <td><input name="txtCapitalName" type="text" size="25" />
      <span class="f_gray">������ÿ�����25��������</span></td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>�ʱ����ͣ�</strong></td>
    <td>
	  <asp:RadioButtonList ID="rblfinancingTarget" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                        Height="2px">
        </asp:RadioButtonList>
         <span id="spCapitalType" ></span>
   </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>��������</strong></td>
   <td ><uc3:ZoneSelectControl id="ZoneSelect2" runat="server">
                    </uc3:ZoneSelectControl></td> 
    
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��Ͷ����ҵ��</strong></td>
     <td width="593">
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />

      </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>��Ͷ������</strong></td>
     <td width="593">
                    <uc1:ZoneSelect id="ZoneSelect1" runat="server">
                    </uc1:ZoneSelect></td>
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><span class="f_red">*</span> <strong>����Ŀ��Ͷ�ʽ�</strong></td>
     <td width="593" style="height: 40px">
                    <p>
                        <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                       <span class="f_gray">(��λ/�����) </span></p>
                </td>
    
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><span class="f_red">*</span> <strong>Ͷ����Ŀ�׶Σ�</strong></td>
     <td style="height: 40px" >
                        <asp:RadioButtonList ID="rblStage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spStage"></span>
                </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>����ע���ʽ�</strong></td>
    <td><asp:RadioButtonList ID="rblRegister" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spRegister"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg" style="height: 40px"><span class="f_red">*</span> <strong>�����Ŷӹ�ģ��</strong></td>
    <td style="height: 40px"> <asp:RadioButtonList ID="rblScale" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spScale"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>������ƽ��Ͷ���¼�����</strong></td>
    <td><asp:RadioButtonList ID="rblAverage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spAverage"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>�����ɹ�Ͷ���¼�������</strong></td>
    <td><asp:RadioButtonList ID="rblCount" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList>
                        <span id="spCount"></span>
	</td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>Ͷ�ʷ�ʽ��</strong></td>
   <td width="593">   
           <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" /><span id="spCooperationDemand"></span>
                </td>
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>�Ƿ������Ŀ������</strong></td>
    <td width="593">
           <asp:RadioButtonList ID="rdlJoinManage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            Height="2px">
                        </asp:RadioButtonList><span id="spJoinManage"></span>
                </td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>Ͷ������ժҪ��</strong></td>
    <td><textarea id="txtCapitalSummary" runat="server" rows="5" onchange="ChecktCapitalSummary();" style="width:80%;"></textarea>
      <br />
      <span class="f_gray">�������Ҫ�����Խ�������Ͷ�����󣬽�������������200�����ڣ�</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>Ͷ��������ϸ˵����</strong></td>
    <td >
                        <textarea id="txtCapitalIntent" runat="server" rows="7" onchange="ChecktCapitalIntent();" style="width: 80%"></textarea>
                        <span id="spCapitalIntent"></span><br />
                        <span class="f_gray">����ϸ��д����Ͷ��������Ͷ�ʶ���,������Ŀ����Ҫ��ȣ���ϵ��ʽ������һ������ȷ�ϣ���Ҫ�ڴ���д����������޷�ͨ����лл��</span>
                </td>
   
  </tr>
  <tr>
    <td class="tdbg"><span class="f_red">*</span> <strong>������Ч���ޣ�</strong></td>
     <td >
                        �Է���֮����<asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" Height="2px">
                            <asp:ListItem Value="3" Text="��������"></asp:ListItem>
                            <asp:ListItem Value="6" Text="������"></asp:ListItem>
                            <asp:ListItem Value="9" Text="һ����"></asp:ListItem>
                        </asp:RadioButtonList><span id="spValiditeTerm"></span>
                </td>
   
  </tr>
  <tr>
    <td valign="top" class="tdbg"><span class="f_red">*</span> <strong>Ͷ�ʻ�����飺</strong></td>
    <td><textarea id="txtCapitalStructure" rows="7" runat="server" style="width:80%;"></textarea>
    <span id="spStructure"></span>
    <br />
    <span class="f_gray">��������ʷ���ܣ��ʱ����ʡ�Ͷ��������Ͷ�ʷ��������Ŷӣ�Ͷ������Ƚ��ܣ��Լ�֮ǰ�����ĳɹ�������</span></td>
  </tr>
  <tr>
    <td valign="top" class="tdbg"><strong>�ϴ�������</strong></td>
    
     <td width="618" valign="top" class="nonepad">
            <uc4:FilesUploadControl id="FilesUploadControl1" infotype="Project" runat="server" />
                       <span class="f_gray">�������ϴ�Ͷ�ʳɹ��İ������ϼ��ʱ�����������ļ��ȣ�</span>  </td>
  </tr>
</table>
<table width="100%" cellspacing="0" style="text-align:center;">
  <tr>
    <td height="40"><input type="checkbox" name="checkbox7" value="checkbox" />
    �����Ķ�<span class="f_red"><a href="#">���ظ����й�����Ͷ��������Э�顷</a></span></td>
  </tr>
  <tr>
    <td><input type="submit" name="Submit33" value="��һ����ȷ����ϵ��ʽ" /></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
