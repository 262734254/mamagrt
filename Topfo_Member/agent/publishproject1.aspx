<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Publishproject1.aspx.cs" ValidateRequest="false"
    Inherits="agent_Publish_Publishproject1" %>

<%@ Register Src="../Controls/ProjectAddressInfo.ascx" TagName="ProjectAddressInfo"
    TagPrefix="uc5" %>
<%@ Register Src="../Controls/FileUpLoadControl.ascx" TagName="FileUpLoadControl"
    TagPrefix="uc4" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>
<%@ Register Src="../Controls/ImageUploadControl.ascx" TagName="ImageUploadControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ͼƬ�ϴ�</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
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
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>


</head>
<body>
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

function checkProjectName()
{
    var txtProjectNameID = "<%=this.txtProjectName.ClientID %>";
    var obj = document.getElementById(txtProjectNameID);
    if(obj.value == "")
    {
        document.getElementById("spProjectName").innerHTML = "&nbsp;&nbsp;&nbsp;Ͷ���������Ʊ�����д��";
        document.getElementById("spProjectName").className = "noteawoke";
        obj.focus();
        //obj.select();
        return false;
    }
    else if(obj.value.length > 20)
    {
        document.getElementById("spProjectName").innerHTML = "&nbsp;&nbsp;&nbsp;����ȷ��дͶ�����ƣ���20�����ڣ�";
        document.getElementById("spProjectName").className = "noteawoke";
        obj.focus();
        //obj.select();
        return false;
    }
    else
    {
        document.getElementById("spProjectName").innerHTML = "";
        document.getElementById("spProjectName").className = "";
        return true;
    }
}

function checkCooperationDemand()
{
    var chkLstCooperationDemandID = "<%=this.chkLstCooperationDemand.ClientID %>";
    
    if(GetCheckBoxListCheckNum(chkLstCooperationDemandID) <= 0){
        document.getElementById("spCooperationDemand").innerHTML = "&nbsp;&nbsp;&nbsp;��ѡ�����ʷ�ʽ��";
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
        document.getElementById("spCapitalTotal").innerHTML = "&nbsp;&nbsp;&nbsp;��Ͷ�ʶ����Ϊ���֣�����ȷ��д��";
        document.getElementById("spCapitalTotal").className = "noteawoke";
        document.getElementById("spCapitalTotal").focus();
        return false;
    }
}

function checkProIntro()
{
    var id = "<%=this.txtProIntro.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spProIntro").innerHTML = "&nbsp;&nbsp;&nbsp;����д������Ŀ���ܣ�";
        document.getElementById("spProIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(obj.value.length > 0 && obj.value.length < 50)
    {
        document.getElementById("spProIntro").innerHTML = "&nbsp;&nbsp;&nbsp;������Ŀ���ܹ��ڼ�̣�������50�����ϣ�";
        document.getElementById("spProIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(obj.value.length > 2000)
    {
        document.getElementById("spProIntro").innerHTML = "&nbsp;&nbsp;&nbsp;��Ŀ���ܱ�����2000�����ڣ�";
        document.getElementById("spProIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spProIntro").innerHTML = "";
        document.getElementById("spProIntro").className = "";
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

function checkProjectAddressI()
{
    var id = "<%=this.ProjectAddressInfo1.ClientID %>";
    return eval(id+"_AddContact.checkAll()");
}

function CheckForm()
{
    var revalue = true;
    if(!checkProjectName()){
        if(revalue) revalue = false;}
    if(!checkCooperationDemand()){
        if(revalue) revalue = false;}
    if(!checkIndustry()){
        if(revalue) revalue = false;}
    if(!checkProIntro()){
        if(revalue) revalue = false;}
    if(!checkCapitalTotal()){
        if(revalue) revalue = false;}
    if(!checkKeyword()){
        if(revalue) revalue = false;}  
    if(!checkProjectAddressI()){
        if(revalue) revalue = false;}  
    if(!checkZoneSelect(true)){
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
                document.getElementById("switchtext").innerHTML = '�� <span class="hong">*</span> ��Ϊ������ ��������<a href="javascript:switchPublish();" class="lanlink">�л�����������</a>��</span>';
            }
            else{
                document.getElementById("hdswitchpublish").value = 1;
                document.getElementById("switchtext").innerHTML = '�� <span class="hong">*</span> ��Ϊ������ ��������<a href="javascript:switchPublish();" class="lanlink">�л������ٷ���</a>��';
            }
            //alert(objs.length);
            for(var i=0; i <objs.length; i++)
            {
                objs[i].className = style;
            }
        }
    </script>
        <!--���ʷ��� -->
        <input type="hidden" id="hdswitchpublish" value="1" />
        <div class="mainconbox">
            <div class="titled">
                <div class="left">
                    ������������
                </div>
                <div class="right">
                    <img src="../images/publish/biao_01.gif" width="14" height="15" />
                    <a href="http://www.topfo.com/help/demandrelease.shtml#16" target="_blank">���󷢲�����</a>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="stepsbox">
                <ul>
                    <li class="liwai" style="width: 169px">��1�� ��д��Ŀ��Ϣ </li>
                    <li class="liimg">
                        <img src="../images/publish/projectbg.gif" align="left" /></li>
                    <li style="width: 172px">��2�� ��ĿͶ�ʼ�ֵ���� </li>
                    <li class="liimg">
                        <img src="../images/publish/projectbg.gif" align="left" /></li>
                    <li class="lishort">��3�� �����ɹ�</li>
                </ul>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div id="switchtext">
                �� <span class="hong">*</span> ��Ϊ������ ��������<a href="javascript:switchPublish();" class="lanlink">�л������ٷ���</a>��</div>
            <div class='dottedlline'>
            </div>
            <div class="blank6">
            </div>
            <div class="infozi">
                ������Ϣ</div>
            <table border="1" cellpadding="0" cellspacing="0" class="tabbiank" style="width: 630px">
                <tr>
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <span class="hong">*</span> <strong>��Ŀ���ƣ�</strong></td>
                    <td width="630">
                        <asp:TextBox ID="txtProjectName" onchange="checkProjectName();" runat="server" Width="297px"></asp:TextBox>
                        <span id="spProjectName" class="hui">��20������ </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <span class="hong">*</span><strong> ��������</strong></td>
                    <td width="630">
                        <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <span class="hong">*</span> <strong>������ҵ��</strong></td>
                    <td width="630">
                        <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <span class="hong">* </span><strong>���ʷ�ʽ��</strong></td>
                    <td width="630">
                        <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                            RepeatDirection="Horizontal" />
                        &nbsp;<span class="hui">���ɶ�ѡ��</span> <span id="spCooperationDemand"></span>
                    </td>
                </tr>
                <tr id="trswitchpublish" name="trswitchpublish">
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <strong>��Ͷ�ʣ�</strong></td>
                    <td width="630">
                        <asp:DropDownList ID="ddlCurrencyTotal" runat="server" Width="76px">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtCapitalTotal" onchange="checkCapitalTotal()" runat="server" Width="75px"></asp:TextBox>
                        �� <span id="spCapitalTotal"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <span class="hong">* </span><strong>���ʽ�</strong></td>
                    <td width="630">
                        <asp:DropDownList ID="ddlCurrency" runat="server" Width="76px">
                        </asp:DropDownList>
                        &nbsp;<asp:DropDownList ID="ddlCapital" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr id="trswitchpublish" name="trswitchpublish">
                    <td align="right" valign="top" bgcolor="#F7F7F7" style="width: 75px">
                        <strong>��Ŀ�ؼ��֣�</strong></td>
                    <td width="630" valign="top">
                        <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                        &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>&nbsp;
                        <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                        <br />
                        <span id="spKeyMsg"></span><span class="hui">�û������ͨ��������Ѱ�����󣬶������Ŀ��صĹؼ�������������������ױ�Ͷ�ʷ��ҵ���</span><a
                            href="http://www.topfo.com/help/demandmanage.shtml#19" target="_blank">��ζ���ؼ���</a></td>
                </tr>
                <tr id="trswitchpublish" name="trswitchpublish">
                    <td align="right" valign="top" bgcolor="#F7F7F7" style="width: 75px">
                        <strong>ͼƬ�ϴ���</strong></td>
                    <td width="630" valign="top" class="nonepad">
                        <uc3:ImageUploadControl ID="ImageUploadControl1" runat="server" Count="4" InfoType="Project"
                            NoneCount="4" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" bgcolor="#F7F7F7" style="height: 71px; width: 75px;">
                        <span class="hong">*</span> <strong>��Ŀ��飺</strong>
                        <br />
                        ��50��2000�֣�</td>
                    <td width="630" valign="top" style="height: 71px">
                        <textarea id="txtProIntro" onchange="checkProIntro();" runat="server"
                            style="width: 472px; height: 211px"></textarea><span id="spProIntro"></span><br />
                        <span class="hui">�����Ŀ��������Ŀ���ݼ���ģ����Ŀ��չ����Ŀ�г�ǰ���ȷ������Ŀ���н��ܣ�
                            <br />
                            ��ϵ��ʽ���绰�����桢�ֻ�����������ȣ�������һ����д���˴��ظ���д���޷�ͨ����ˡ�</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" bgcolor="#F7F7F7" style="width: 75px">
                        <span class="hong">*</span> <strong>��Ч�ڣ�</strong></td>
                    <td width="630">
                        <asp:DropDownList ID="ddlValiditeTerm" runat="server">
                            <asp:ListItem Value="3">��������</asp:ListItem>
                            <asp:ListItem Value="6">������</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <span class="hui">��Ҫ��ʾ���������������������Ч������Ϊ����ԭ���Ѿ�ʧЧ���뼰ʱ����������н�������ӡ�<a href="/Manage/ResourceManage_Pass.aspx">ͨ�����</a>���б�ת�Ƶ���<a
                            href="/Manage/ResourceManage_Overdue.aspx">�ѹ���</a>���б������������ý����ܵ��𺦣��мǣ�</span></td>
                </tr>
            </table>
            <%--         <div class="blank0">
        </div>
      
       <!--������Ϣ -->
        <div class="infozi">
            ������Ϣ</div>
        <div style="display:none;">
        <uc4:FileUpLoadControl ID="FileUpLoadControl1" runat="server" />
        </div>--%>
            <div class="blank0">
            </div>
            <!--��ϵ��ʽ -->
            <div class="infozi">
                ��ϵ��ʽ</div>
            <div class="blank0">
            </div>
            <uc5:ProjectAddressInfo ID="ProjectAddressInfo1" runat="server" />
            <div class="mbbuttom">
                <p>
                    <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml" target="_blank" class="lanlink">
                        ����Ķ��й�����Ͷ������������</a><span><a href="#">��ѯ�Ƿ������ظ���Ϣ</a></span></p>
                <asp:ImageButton ID="imgbtnSubmit" runat="server" AlternateText="ͬ��������� ��������" ImageUrl="../images/publish/buttom_tywftk.gif"
                    OnClick="imgbtnSubmit_Click" />
            </div>
        </div>
    </form>
</body>
</html>
