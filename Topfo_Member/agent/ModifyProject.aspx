<%@ Page Language="C#"  AutoEventWireup="true" ValidateRequest="false"
    CodeFile="ModifyProject.aspx.cs" Inherits="Manage_ModifyProject" Title="Untitled Page" %>

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
<form runat=server id=aspnetForm>

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
        document.getElementById("spProjectName").innerHTML = "&nbsp;&nbsp;&nbsp;投资需求名称必须填写！";
        document.getElementById("spProjectName").className = "noteawoke";
        obj.focus();
        //obj.select();
        return false;
    }
    else if(obj.value.length > 20)
    {
        document.getElementById("spProjectName").innerHTML = "&nbsp;&nbsp;&nbsp;请正确填写投资名称，限20字以内！";
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
        document.getElementById("spCooperationDemand").innerHTML = "&nbsp;&nbsp;&nbsp;请选择融资方式！";
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
        document.getElementById("spCapitalTotal").innerHTML = "&nbsp;&nbsp;&nbsp;总投资额必须为数字，请正确填写！";
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
        document.getElementById("spProIntro").innerHTML = "&nbsp;&nbsp;&nbsp;请填写您的项目介绍！";
        document.getElementById("spProIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(obj.value.length > 0 && obj.value.length < 50)
    {
        document.getElementById("spProIntro").innerHTML = "&nbsp;&nbsp;&nbsp;您的项目介绍过于简短，必须在50字以上！";
        document.getElementById("spProIntro").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(obj.value.length > 2000)
    {
        document.getElementById("spProIntro").innerHTML = "&nbsp;&nbsp;&nbsp;项目介绍必须在2000字以内！";
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
    </script><input type="hidden" id="hdswitchpublish" value="1" />
    <div id="mainconbox">
        <div class="titled">
            <div class="stepsbox">
            <ul>
                <li class="liwai">修改融资项目信息 </li>
            </ul>
            </div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="#" class="lanlink">需求发布案例</a> <a href="#" class="lanlink">需求发布规则</a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="blank0">
        </div>
        <div id="switchtext">
            带 <span class="hong">*</span> 的为必填项 （您可以<a href="javascript:switchPublish();" class="lanlink">切换到快速发布</a>）</div>
        <div class="blank0">
        </div>
        <div class="infozi">
            基本信息</div>
        <table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>项目名称：</strong></td>
                <td width="630">
                    <asp:TextBox ID="txtProjectName" onchange="checkProjectName();" runat="server" MaxLength="20" Width="297px"></asp:TextBox>
                    <span id="spProjectName" class="hui">限20个汉字 </span>
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span><strong> 所属区域：</strong></td>
                <td width="630">
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>所属行业：</strong></td>
                <td width="630">
                    <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">* </span><strong>融资方式：</strong></td>
                <td width="630">
                    <asp:CheckBoxList ID="chkLstCooperationDemand" runat="server" RepeatLayout="Flow"
                        RepeatDirection="Horizontal" />
                    &nbsp;<span class="hui">（可多选）</span>
                    <span id="spCooperationDemand"></span>
                </td>
            </tr>
            <tr id="trswitchpublish" name="trswitchpublish">
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <strong>总投资：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlCurrencyTotal" runat="server" Width="76px">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCapitalTotal" onchange="checkCapitalTotal()" runat="server" Width="75px"></asp:TextBox>
                    万
                    <span id="spCapitalTotal"></span>
              </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">* </span><strong>融资金额：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlCurrency" runat="server" Width="76px">
                    </asp:DropDownList>&nbsp;<asp:DropDownList ID="ddlCapital" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr id="tr1" name="trswitchpublish">
                <td width="124" align="right" valign="top" bgcolor="#F7F7F7">
                    <strong>项目关键字：</strong></td>
                <td width="630" valign="top">
                                       <asp:TextBox ID="txtKeyword1" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="txtKeyword2" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>&nbsp;
                    <asp:TextBox ID="txtKeyword3" onchange="checkKeyword();" runat="server" Width="72px"></asp:TextBox>
                    <br />
                    <span id="spKeyMsg"></span>
                     <span class="hui">用户更多地通过搜索来寻找需求，定义跟项目相关的关键字能让您的需求更容易被投资方找到。</span><a href="#">如何定义关键字</a></td>
            </tr>
            <tr id="tr2" name="trswitchpublish">
                <td width="124" align="right" valign="top" bgcolor="#F7F7F7">
                    <strong>图片上传：</strong></td>
                <td width="630" valign="top" class="nonepad">
                    <uc3:ImageUploadControl ID="ImageUploadControl1" runat="server" Count="4" InfoType="Project"
                        NoneCount="4" />
              </td>
            </tr>
            <tr>
                <td width="124" align="right" valign="top" bgcolor="#F7F7F7" style="height: 71px">
                    <span class="hong">*</span> <strong>项目简介：</strong>
                    <br />
              （50－2000字）</td>
                <td width="630" valign="top" style="height: 71px">
                   <textarea id="txtProIntro" onchange="checkProIntro();"  runat="server" style="width: 513px;
                            height:168px"></textarea><span id="spProIntro"></span><br />
						 <span class="hui"> 	请从项目背景、项目内容及规模、项目进展、项目市场前景等方面对项目进行介绍；
                        <br />
                  联系方式（电话、传真、手机、电子邮箱等）请在下一步填写，此处重复填写将无法通过审核。</span>
                       
                </td>
            </tr>
            <tr>
                <td width="124" align="right" bgcolor="#F7F7F7">
                    <span class="hong">*</span> <strong>有效期：</strong></td>
                <td width="630">
                    <asp:DropDownList ID="ddlValiditeTerm" runat="server">
                        <asp:ListItem Value="3">三个月内</asp:ListItem>
                        <asp:ListItem Value="6">半年内</asp:ListItem>
                    </asp:DropDownList><br />
                    <span class="hui">重要提示：如果您发布的需求在有效期内因为各种原因已经失效，请及时在需求管理中将该需求从“<a href="#">通过审核</a>”列表转移到“<a
                        href="">已过期</a>”列表，否则您的信用将会受到损害，切记！</span></td>
            </tr>
      </table>
        <div class="blank0">
        </div>
        <div class="dottedlline">
        </div>
        <!--附加信息 -->
        <div class="infozi">
            附加信息</div>
        <uc4:FileUpLoadControl ID="FileUpLoadControl1" runat="server" />
        <div class="blank0">
        </div>
        <div class="dottedlline">
        </div>
        <!--联系方式 -->
        <div class="infozi">
            联系方式</div>
        <div class="blank0">
        </div>
        <uc5:ProjectAddressInfo ID="ProjectAddressInfo1" runat="server" />
        <div class="dottedlline">
        </div>
        <div class="mbbuttom">
            <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="btnUpdate_Click" Width="144px" /></div>
    </div>
</form>