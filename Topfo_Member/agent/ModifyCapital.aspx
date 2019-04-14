<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="ModifyCapital.aspx.cs"
    Inherits="Manage_ModifyCapital" Title="Untitled Page" %>

<%--<%@ Register Src="Controls/ZoneSelect.ascx" TagName="ZoneSelect" TagPrefix="uc1" %>--%>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc3" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/CapitalAddressInfo.ascx" TagName="CapitalAddressInfo"
    TagPrefix="uc5" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <title>�ظ�����-�ظ����й�����Ͷ����</title>

    <script type="text/javascript" src="/JavaScript/png.js"></script>

    <script type="text/javascript" src="/javascript/OPCookie.js"></script>

    <script type="text/javascript" src="/javascript/UserCustom.js"></script>

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
.divcheck {CLEAR: left;}
.divcheck SPAN {FONT-SIZE: 12px; margin-left:8px;margin-right:15px; CURSOR: pointer}
.btn2{ background:url(./images/btn03.jpg) no-repeat 0 0;font-size:12px;width:146px;height:24px;display:block; border:0;cursor:pointer;}

</style>

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
        document.getElementById("spCapitalName2").innerHTML = "&nbsp;&nbsp;&nbsp;Ͷ���������Ʊ�����д��";
        document.getElementById("spCapitalName2").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,1,60))
    {
        document.getElementById("spCapitalName2").innerHTML = "&nbsp;&nbsp;&nbsp;����ȷ��дͶ�����ƣ���30�����ڣ�";
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
//Ͷ����Ŀ�׶�
function checkStage()
{
    var rdlStageID = "<%=this.rdlStage.ClientID %>";
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
  //����Ŀ��Ͷ�ʽ��
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
//�ʱ����͸�ΪͶ�ʷ�ʽ
function checkCapitalType()
{
    var rblCapitalTypeID = "<%=this.rblfinancingTarget.ClientID %>";
    var rblCapitalTypeName = rblCapitalTypeID.replace(/_/g,"$");
    if(GetCheckNum(rblCapitalTypeName) <= 0){
        document.getElementById("spCapitalType").innerHTML = "&nbsp;&nbsp;&nbsp;��ѡ���ʱ����ͣ�";
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
 //������Ч����
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
function checkCooperationDemand()
{
    var chkLstCooperationDemandID = "<%=this.chkLstCooperationDemand.ClientID %>";
    
    if(GetCheckBoxListCheckNum(chkLstCooperationDemandID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "&nbsp;&nbsp;&nbsp;��ѡ��Ͷ�ʷ�ʽ��";
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
        document.getElementById("spCaptialIntent").innerHTML = "&nbsp;&nbsp;&nbsp;����д����Ͷ������";
        document.getElementById("spCaptialIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(checkByteLength(obj.value,1,100))
    {
        document.getElementById("spCaptialIntent").innerHTML = "&nbsp;&nbsp;&nbsp;����Ͷ��������ڼ�̣�������50�����ϣ�";
        document.getElementById("spCaptialIntent").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,100,10000))
    {
        document.getElementById("spCaptialIntent").innerHTML = "&nbsp;&nbsp;&nbsp;Ͷ�����������5000�����ڣ�";
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
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;����ȷ��д�ؼ���";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key1ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key2ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;����ȷ��д�ؼ���";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key2ID).focus();
        return false;
    }
    if (!filter.test(document.getElementById(key3ID).value)){
        document.getElementById("spKeyMsg").innerHTML = "&nbsp;&nbsp;&nbsp;����ȷ��д�ؼ���";
        document.getElementById("spKeyMsg").className = "noteawoke";
        document.getElementById(key3ID).focus();
        return false;
    }
}
//��������ӵļ���
     //����ע���ʽ�
     function checkCurreny()
     {
        //rblRegisterdollar
        
        var rblRegisterdollarID = "<%=this.rblRegisterdollar.ClientID %>";
        var rblRegisterdollarIDName = rdlStageID.replace(/_/g,"$");
        if(GetCheckNum(rblRegisterdollarIDName) <= 0){
        document.getElementById("spdollar").innerHTML = "��ѡ�����ע���ʽ�";
        document.getElementById("spdollar").className = "noteawoke";
        document.getElementById(rblRegisterdollarID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("spdollar").innerHTML = "";
        document.getElementById("spdollar").className = "";
		return true;
	    }
     
    }
    
    //�Ŷӹ�ģ
    function checkTeam()
    {
        var rblTeamID = "<%=this.rblTeam.ClientID %>";
        var rblTeamIDName = rblTeamID.replace(/_/g,"$");
        if(GetCheckNum(rblTeamIDName) <= 0){
        document.getElementById("sprblTeam").innerHTML = "��ѡ���Ŷӹ�ģ";
        document.getElementById("sprblTeam").className = "noteawoke";
        document.getElementById(rblTeamID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("sprblTeam").innerHTML = "";
        document.getElementById("sprblTeam").className = "";
		return true;
	    }
    
    
    }
   //������ƽ��Ͷ���¼���
   function checkPinjun()
   {
       var rblPinJID = "<%=this.rblPinJ.ClientID %>";
        var rblTeamIDName = rblPinJID.replace(/_/g,"$");
        if(GetCheckNum(rblPinJIDName) <= 0){
        document.getElementById("sprblPinJ").innerHTML = "��ѡ��Ͷ���¼���";
        document.getElementById("sprblPinJ").className = "noteawoke";
        document.getElementById(rblTeamID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("sprblPinJ").innerHTML = "";
        document.getElementById("sprblPinJ").className = "";
		return true;
	    }
   
   }
   //�ɹ��¼���
   function checkSucess()
   {
   
   
       var rblSucessID = "<%=this.rblSucess.ClientID %>";
        var rblSucessIDName = rblSucessID.replace(/_/g,"$");
        if(GetCheckNum(rblSucessIDName) <= 0){
        document.getElementById("sprblSucess").innerHTML = "��ѡ��ɹ��¼���";
        document.getElementById("sprblSucess").className = "noteawoke";
        document.getElementById(rblTeamID).focus();
		return false;
	    }
	    else
	    {
	    document.getElementById("sprblSucess").innerHTML = "";
        document.getElementById("sprblSucess").className = "";
		return true;
	    }
   
   }
    
    //
     
     //Ͷ������ժҪ
     function checkZhaiYao()
     {
     
     var txtDemandID = "<%=this.txtDemand.ClientID %>";
    var obj = document.getElementById(txtDemandID);
    if(!checkByteLength(obj.value,1,5000))
    {
        document.getElementById("sptxtDemand").innerHTML = "����ȷ��д����ժҪ";
        document.getElementById("sptxtDemand").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("sptxtDemand").innerHTML = "";
        document.getElementById("sptxtDemand").className = "";
        return true;
    }
     }

//��������������ж�
function CheckForm()
{
    var revalue = true;
     //Ͷ�ʻ�������
    if(!CheckGovName())
        {
        if(revalue) revalue = false;
        }
        //Ͷ�ʷ����
    if(!CheckGovIntro())
        {
        if(revalue) revalue = false;
        }
        //Ͷ����������
    if(!CheckCapitalName())
        {
        if(revalue) revalue = false;
        }
       //�ʱ�����
    if(!checkCapitalType())
        {
        if(revalue) revalue = false;
        }
        //����Ŀ��Ͷ����
    if(!checkCurrency())
       {
        if(revalue) revalue = false;
       }
       //��Ͷ����ҵ
    if(!checkIndustry())
        {
        if(revalue) revalue = false;
        }
        //Ͷ����Ŀ�׶�
    if(!checkStage())
        {
        if(revalue) revalue = false;
        }
        //�Ƿ������Ŀ������
     if(!checkJoinManage())
        {
        if(revalue) revalue = false;
        }
        //Ͷ�ʷ�ʽ
    if(!checkCooperationDemand())
        {
        if(revalue) revalue = false;
        }
        //�ؼ��ֵ��ж�
    if(!checkKeyword())
        {
        if(revalue) revalue = false;
        }
     //������Ч����   
    if(!checkValiditeTerm())
        {
        if(revalue) revalue = false;
        }
     //Ͷ��������ϸ˵��     
    if(!ChecktCapitalIntent())
        {
        if(revalue) revalue = false;
        }
      //����Э��
    if(!CheckCheck())
        {
        if(revalue) revalue = false;
        } 
     //����ע���ʽ�
     if(!checkCurreny())
     {
       if(revalue) revalue=false;
     }
     //�Ŷӹ�ģ
     if(!checkTeam())
     {
       if(revalue) revalue=false;
     }
     //ƽ���¼���
     if(!checkPinjun())
     {
       if(revalue) revalue=false;
     }
     
      //�����ɹ�Ͷ���¼�����
      if(!checkSucess())
      {
        if(revalue) revalue=false;
      }
     
     //�а쵥λ
     //if(!checkSpors())
     //{
       //if(revalue) revalue=false;
     //}
     //��ĿժҪ
      if(!checkZhaiYao())
      {
       if(revalue) revalue=false;
      }
      if(!checkByteLength())
      {
      if(revalue) revalue=false;
       }
       if(!checkLinkMan())
       {
       if(revalue) revalue=false;
       }
       if(!checkGovName())
       {
        if(revalue) revalue=false;
       }
    return revalue;
}

document.getElementById("aspnetForm").onsubmit = CheckForm;

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
        document.getElementById("switchtext").innerHTML = '������Ϣ<span>��������<a href="javascript:switchPublish();" class="lanlink">�л�����������</a>��</span>';
    }
    else{
        document.getElementById("hdswitchpublish").value = 1;
        document.getElementById("switchtext").innerHTML = '������Ϣ<span>��������<a href="javascript:switchPublish();" class="lanlink">�л������ٷ���</a>��</span>';
    }
    //alert(objs.length);
    for(var i=0; i <objs.length; i++)
    {
        objs[i].className = style;
    }
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

function validateArea(obj){
	var str1 = obj.value.trim();
	var str = tot(str1); 
	obj.value = str;
	if(str.length == 0){
    	return -1;
    }
	var patn = /^[\+0-9]+$/;
	if(!patn.test(str)) return 1;
	return 0; 
}
function checkLinkMan()
{
   var value = document.getElementById("<%=this.txtLinkMan.ClientID %>").value;
   var LinkID="<%=this.txtLinkMan.ClientID%>";
    if(!checkByteLength(value,1,20)){
        document.getElementById("spCAComName").innerHTML = "&nbsp;&nbsp;&nbsp;��ϵ������������д��";
        document.getElementById("spCAComName").className = "noteawoke";
        document.getElementById(LinkID).focus();
        return false;
    }
    else
    {
        document.getElementById("spCAComName").innerHTML = "";
        document.getElementById("spCAComName").className = "";
        return true;
    }   
}
//����������
function checkGovName()
{
   var value = document.getElementById("<%=this.txtGovName.ClientID %>").value;
    var GovNameID="<%=this.txtGovName.ClientID%>";
    if(!checkByteLength(value,1,30)){
        document.getElementById("SpGovName").innerHTML = "&nbsp;&nbsp;&nbsp;Ͷ�ʻ���������д��";
        document.getElementById("SpGovName").className = "noteawoke";
        document.getElementById(GovNameID).focus();
        return false;
    }
    else
    {
        document.getElementById("SpGovName").innerHTML = "";
        document.getElementById("SpGovName").className = "";
        return true;
    }   
}
    </script>

</head>
<div>
    <table>
        <tr>
            <td style="width:80px;">
            </td>
         
            <td style=" width:auto;"> <div class="titled">
                <div class="stepsbox">
                    <ul>
                        <li class="liwai">�޸�Ͷ������</li></ul>
                </div>
                <div class="clear">
                </div>
            </div>
            <div>
                ��<span class="hong">*</span> ��Ϊ������
            </div>
            <div class="blank6">
            </div>
            <div class="infozi" id="switchtext">
                ������Ϣ<span>��������<a href="javascript:switchPublish();" class="lanlink">�л������ٷ���</a>�� </span>
            </div>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>

   <center>
    <body>
        <form method="post" id="form1" runat="server">
            <input type="hidden" id="hdswitchpublish" value="1" />
            <div id="mainconbox">
                <table border="0" cellpadding="0" cellspacing="0" class="tabbiank" style="width: 814px;
                    height: 1416px">
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <span style="color: #ff0000">*</span> <strong>Ͷ��������⣺</strong></td>
                        <td width="625">
                            <asp:TextBox ID="txtCapitalName" onchange="JavaScrpit:checkCapitalName()" runat="server"
                                Width="299px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7" style="width: 189px">
                            <span style="color: #ff0000">*</span> <strong>�ʱ����ͣ�</strong></td>
                        <td width="625">
                            <asp:RadioButtonList ID="rblfinancingTarget" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                Height="2px">
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <span class="hong">*</span> <strong>Ͷ�ʻ������ܣ�</strong></td>
                        <td width="625">
                            <strong>
                                <textarea cols="50" rows="10" id="txtGovIntro" runat="server" style="width: 540px;
                                    height: 100px"></textarea></strong> <span id="Span2"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <span class="hong" style="color: #000000"><strong>Ͷ������</strong></span></td>
                        <td width="625">
                            <strong></strong>&nbsp;<uc2:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                            <span id="spCapitalName2"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <span class="hong">*</span> <strong>Ͷ����ҵ��</strong></td>
                        <td width="625">
                            <uc3:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <span class="hong">*</span><b>������Ŀ��Ͷ�ʽ�</b></td>
                        <td>
                            <p>
                                <asp:RadioButtonList ID="rblCurreny" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                    Height="2px">
                                </asp:RadioButtonList>
                                <br />
                                <span class="hui">���Ļ��ҵ�λΪ�����</span></p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <b>Ͷ����Ŀ�׶Σ�</b></td>
                        <td>
                            <p>
                                <asp:RadioButtonList ID="rdlStage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                    Height="2px">
                                </asp:RadioButtonList>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdbg" style="width: 189px; height: 31px;" bgcolor="#F7F7F7" align="right">
                            <strong>����ע���ʽ�</strong></td>
                        <td style="width: 699px; height: 31px;">
                            <asp:RadioButtonList ID="rblRegisterdollar" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                Height="2px">
                            </asp:RadioButtonList>
                            <span id="spdollar"></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdbg" style="width: 189px; height: 31px;" align="right" bgcolor="#F7F7F7">
                            <strong>�����Ŷӹ�ģ��</strong></td>
                        <td style="width: 699px; height: 31px;">
                            <asp:RadioButtonList ID="rblTeam" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                Height="2px">
                            </asp:RadioButtonList>
                            <span id="sprblTeam"></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdbg" style="width: 189px" align="right" bgcolor="#F7F7F7">
                            <strong>������ƽ��Ͷ���¼�����</strong></td>
                        <td style="width: 699px">
                            <asp:RadioButtonList ID="rblPinJ" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                Height="2px">
                            </asp:RadioButtonList>
                            <span id="sprblPinJ"></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdbg" style="width: 189px" align="right" bgcolor="#F7F7F7">
                            <strong>�����ɹ�Ͷ���¼�������</strong></td>
                        <td style="width: 699px">
                            <asp:RadioButtonList ID="rblSucess" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                Height="2px">
                            </asp:RadioButtonList>
                            <span id="sprblSucess"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px; height: 26px;">
                            <span class="hong">*</span> <strong>Ͷ�ʷ�ʽ��</strong></td>
                        <td style="height: 26px">
                            <p>
                                <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                                    RepeatDirection="Horizontal" />
                            </p>
                            <span id="spCooperationDemand"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <b>�Ƿ������Ŀ������</b></td>
                        <td>
                            <p>
                                <asp:RadioButtonList ID="rdlJoinManage" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                    Height="2px">
                                </asp:RadioButtonList></p>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right" class="tdbg" bgcolor="#F7F7F7" style="width: 189px">
                            <span class="f_red"></span><strong>Ͷ������ժҪ��</strong></td>
                        <td style="width: 699px">
                            <textarea cols="50" rows="10" id="txtDemand" runat="server" onchange="javaScript:checkZhaiYao()"
                                style="width: 540px; height: 100px"></textarea>
                            <span id="sptxtDemand"></span>
                            <br />
                            <span class="f_gray">�������Ҫ�����Խ�������Ͷ�����󣬽�������������200�����ڣ�</span></td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" bgcolor="#F7F7F7" style="width: 189px">
                            <b>Ͷ��������ϸ˵����</b></td>
                        <td valign="top">
                            <p>
                                <textarea id="txtCapitalIntent" runat="server" cols="50" style="width: 558px; height: 204px"></textarea>
                                <br />
                                <span class="hui">1.��дͶ�ʵĶ����Լ�����Ŀ����Ҫ��ȣ�<br />
                                    2.������20�֣����ܺ�����ϵ��ʽ��绰��E-mail�ȣ������޷�ͨ����ˡ�</span><a href="">�鿴����</a></p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#f7f7f7" style="height: 21px; width: 189px;">
                            <strong>�ϴ�����:</strong></td>
                        <td bgcolor="#EFF6FF">
                            <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" Count="5" InfoType="Capital"
                                NoneCount="3" />
                        </td>
                    </tr>
                    <%--<tr>
                <td align="right" valign="top" bgcolor="#F7F7F7">
                    <b>�ϴ�����:</b>
                </td>
                <td bgcolor="#FFFFFF">
                    <uc4:UpFileControl ID="UpFileControl1" runat="server" />
                </td>
            </tr>--%>
                    <tr id="tr1" name="trswitchpublish">
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <strong>Ͷ�ʹؼ��֣�</strong></td>
                        <td width="625" valign="top">
                            <a href="#" class="lanlink">��ζ���ؼ���</a>
                            <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                            &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                            <br />
                            <span id="spKeyMsg"></span><span class="hui">�û����ڸ����ͨ��������Ѱ����Դ��������صĹؼ�������������������ױ���Ŀ���ҵ���</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" bgcolor="#F7F7F7" style="width: 189px">
                            <span class="hong">*</span> <strong>Ͷ����Ч�ڣ�</strong></td>
                        <td style="height: 20px">
                            <p>
                                �Է���֮����<asp:RadioButtonList ID="rdlValiditeTerm" runat="server" RepeatLayout="Flow"
                                    RepeatDirection="Horizontal" Height="2px">
                                </asp:RadioButtonList></p>
                        </td>
                    </tr>
                </table>
                <div class="dottedlline" style="width: 814px">
                </div>
                <!--������Ϣ -->
                <div class="infozi">
                    <div id="Div1" class="infozi" style="text-align:left">
                        <span class="hong" style="color: #000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;<strong>����Ͷ�����������������д����������ȷ����ϵ����Ϣ��</strong></span></div>
                    <table border="0" cellpadding="0" cellspacing="0" class="tabbiank" style="width: 814px;">
                        <tr>
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px">
                                <span class="hong" style="color: #000000">*</span> <strong>Ͷ�ʻ������ƣ�</strong></td>
                            <td width="638">
                                <asp:TextBox ID="txtGovName" runat="server" onchange="checkGovName()" Width="246px"></asp:TextBox>
                                <span id="SpGovName"></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px">
                                <span class="hong" style="color: #000000">*</span> <strong>��ϵ�ˣ�</strong></td>
                            <td width="638">
                                <asp:TextBox ID="txtLinkMan" runat="server" onchange="checkLinkMan()" Width="246px"></asp:TextBox>
                                <span id="splinkMan"></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px">
                                <strong>ְλ��</strong></td>
                            <td width="638">
                                <asp:TextBox ID="txtPosition" runat="server" Width="246px"></asp:TextBox>
                                <span id="Span3"></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px">
                                <span class="hong" style="color: #000000">*</span> <strong>�̶��绰��</strong></td>
                            <td valign="top" width="638">
                                <menu class="menulw">
                                    ����</menu>
                                <menu>
                                    ��������</menu>
                                <menu>
                                    �绰����</menu>
                                <br />
                                <asp:TextBox ID="txtTelCountry" runat="server" size="4">+86</asp:TextBox>
                                <asp:TextBox ID="txtTelZoneCode" runat="server" size="7"></asp:TextBox><strong> </strong>
                                <asp:TextBox ID="txtTelNumber" runat="server" size="18"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtMobile" runat="server" Width="127px"></asp:TextBox>���̶��绰���ֻ�������дһ�
                            </td>
                        </tr>
                        <tr id="Tr2" name="trswitchpublish">
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px; height: 26px">
                                <strong>��������</strong>��</td>
                            <td style="height: 26px" width="638">
                                <asp:TextBox ID="txtEmail" runat="server" size="18" Width="269px"></asp:TextBox>
                                <span id="spEmail" class="hui" style="color: #000000">����д����õĵ�������</span><strong> </strong>
                            </td>
                        </tr>
                        <tr id="Tr3" name="trswitchpublish" style="font-weight: bold">
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px; height: 44px">
                                <span style="background-color: #f7f7f7"><strong>Ͷ�ʻ�����ַ:</strong></span></td>
                            <td style="height: 44px; background-color: #f7f7f7" width="638">
                                <asp:TextBox ID="txtWebSite" runat="server" size="18" Width="269px"></asp:TextBox>
                            </td>
                        </tr>
                        <!--<tr id="tr2" name="trswitchpublish">
                <td align="right" bgcolor="#F7F7F7" style="width: 126px">
                    <strong>�� ��</strong><strong>��</strong></td>
                <td width="638">
                    <menu class="menulw">
                        ����</menu>
                    <menu>
                        ��������</menu>
                    <menu>
                        �绰����</menu>
                    <br />
                    <asp:TextBox ID="txtFaxCountry"  runat="server" size='4'>+86</asp:TextBox>
                    <asp:TextBox ID="txtFaxZoneCode"  runat="server" size='7' />
                    <asp:TextBox ID="txtFaxNumber"  runat="server" size='18' />
                    <span id="spFax"></span>
                </td>
   </tr>-->
                        <tr id="Tr4" name="trswitchpublish">
                            <td align="right" bgcolor="#f7f7f7" style="width: 126px">
                                <strong>Ͷ�ʻ�����ַ��</strong></td>
                            <td width="638">
                                <asp:TextBox ID="txtAddress" runat="server" size="18" Width="269px"></asp:TextBox></td>
                        </tr>
                        <!-- <tr id="tr4" name="trswitchpublish">
                <td align="right" bgcolor="#F7F7F7" style="height: 26px; width: 126px;">
                    <strong>�������룺</strong></td>
                <td width="638" style="height: 26px">
                    <asp:TextBox ID="txtPostCode" runat="server" size='18' Width="72px" />
                </td>
            </tr>-->
                    </table>
                    <!--������Ϣ-->
                    <br />
                    <div class="blank0" style="height: 31px; text-align: center; width: 806px;">
                        <asp:Button ID="btnUpdate" runat="server" Height="28px" Text="��  ��" Width="145px" OnClick="btnUpdate_Click" /></div>
                    <!--��ϵ��ʽ-->
                    <div class="mbbuttom">
                        &nbsp;</div>
                    <div>
                    </div>
                </div>
                <div class="mbbuttom">
                    &nbsp;</div>
            </div>
        </form>
    </body>
   </center>
</html>
