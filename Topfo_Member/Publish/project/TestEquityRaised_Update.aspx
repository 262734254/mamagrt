<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestEquityRaised_Update.aspx.cs" Inherits="Publish_project_TestEquityRaised_Update" %>
<%@ Register Src="../../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc4" %>
<%@ Register Src="../../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc1" %>
<%@ Register Src="../../Controls/SelectIndustryControl.ascx" TagName="SelectIndustryControl"
    TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    
    
<script language="javascript" type="text/javascript">
   

   

        
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
    //----------------------END-----------------------------------
   

    //-------------------公用 ，选择checkbox------------------------
    function ChkCbl(kjID,kjName)
    {
        if(GetCheckBoxListCheckNum(kjID)<=0)
        {
            alert("请选择"+kjName);
            document.getElementById(kjID).focus();
            return false;
        }
        else
        {
            return true;
        }
    }
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
    //-------------------------------END----------------------------------
    
    
    //判断多少个汉字,限制汉字
    function checkByteLength(str,minlen,maxlen) 
    {
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
    
    
    
//////////////////////
//去除字符串两边空格的函数
//参数：mystr传入的字符串
//返回：字符串mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//去除前面空格
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//去除后面空格
if (mystr==" "){
mystr="";
}
return mystr;
}


//替换掉字符串空格
function repl(obj)
{
    if(obj.value.length>0)
    {
        obj.value=trim(obj.value);
    }
}
//////////////////////////
   </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="step1" style="display: block;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding: 5px 10px;" class="f_14">
                    <span class="f_red strong">项目详细资料</span><span class="f_gray">（以下基本信息均为必填项）</span>
                </td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td width="145" class="tdbg">
                    <span class="f_red">*</span> <strong>项目标题：</strong>
                </td>
                <td>
                    <input id="txtProjectName" style="width: 286px" size="15" runat="server" />
                    <span class="f_gray">标题最好控制在25个字以内</span>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>所属行业：</strong>
                </td>
                <td>
                    <span class="f_gray">
                        <uc2:SelectIndustryControl ID="SelectIndustryControl1" runat="server" />
                    </span>
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>所属区域：</strong>
                </td>
                <td>
                    <uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>项目投资总额：</strong>
                </td>
                <td>
                    <asp:TextBox ID="txtCapitalTotal" MaxLength="15" runat="server" Width="75px" onkeyup="value=value.replace(/[^\d]/g,'') "> </asp:TextBox>
                    万人民币
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="项目投资总额不能为空！"
                        ControlToValidate="txtCapitalTotal" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtCapitalTotal"
                        Display="Dynamic" ErrorMessage="请输入数字,保留两位小数！" ValidationExpression="^[1-9]+(.[0-9]{1,2})?"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdbg" style="height: 40px">
                    <span class="f_red">*</span> <strong>融资金额：</strong>
                </td>
                <td style="height: 40px">
                    <asp:RadioButtonList ID="rbtnCapital" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>&nbsp;
                </td>
            </tr>
            <%--<tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>产品市场增长率：</strong>
                </td>
                <td>
                    <asp:TextBox ID="tbCpsczzl" Width="80px" runat="server" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbCpsczzl"
                        Display="Dynamic" ErrorMessage="产品市场增长率！"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="tbCpsczzl"
                        Display="Dynamic" ErrorMessage="产品市场增长率0到100，请输入！" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>产品市场容量：</strong>
                </td>
                <td>
                    <asp:TextBox ID="tbCpscyl" Width="80px" runat="server" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbCpscyl"
                        Display="Dynamic" ErrorMessage="行业市场增长率不能为空！"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="tbCpscyl"
                        Display="Dynamic" ErrorMessage="行业市场增长率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>资产负债率：</strong>
                </td>
                <td style="line-height: 18px;">
                    <asp:TextBox ID="tbZcfzl" Width="80px" runat="server" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbZcfzl"
                        Display="Dynamic" ErrorMessage="资产负债率不能为空！"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="tbZcfzl"
                        Display="Dynamic" ErrorMessage="资产负债率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>流动比率：</strong>
                </td>
                <td style="line-height: 18px;">
                    <asp:TextBox ID="tbLdbl" Width="80px" runat="server" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbLdbl"
                        Display="Dynamic" ErrorMessage="资产负债率不能为空！"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="tbLdbl"
                        Display="Dynamic" ErrorMessage="资产负债率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>投资收益率：</strong>
                </td>
                <td style="line-height: 18px;">
                    <asp:TextBox ID="tbTzsyl" Width="80px" runat="server" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="tbTzsyl"
                        Display="Dynamic" ErrorMessage="资产负债率不能为空！"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="tbTzsyl"
                        Display="Dynamic" ErrorMessage="资产负债率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>销售利润率：</strong>
                </td>
                <td style="line-height: 18px;">
                    <asp:TextBox ID="tbXslyl" Width="80px" runat="server" MaxLength="5" onkeyup="value=value.replace(/[^\d]/g,'') "></asp:TextBox>
                    %<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="tbXslyl"
                        Display="Dynamic" ErrorMessage="资产负债率不能为空！"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="tbXslyl"
                        Display="Dynamic" ErrorMessage="资产负债率的范围0到100，请输入！" MaximumValue="100" MinimumValue="0"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>--%>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>项目有效期限：</strong>
                </td>
                <td>
                    发布之日起
                    <asp:RadioButtonList ID="rblXmyxqxx" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                    </asp:RadioButtonList>&nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>资金使用计划：</strong>
                </td>
                <td>
                    <textarea id="txtProIntro" runat="server" rows="5" cols="50" style="width: 558px;
                        height: 215px"></textarea><span id="spProIntro"></span>
                    <br />
                    <span class="f_gray">为吸引投资方的关注，请对项目重点内容进行简单、清晰的描述，建议200字以内（不少于50字）！</span>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>项目详细描述：</strong>
                </td>
                <td>
                    <textarea id="txtXmqxms" runat="server" rows="7" cols="50" style="width: 558px; height: 215px"></textarea>
                    <br />
                    <span class="f_gray">项目内容越详细越有利于投资方了解您项目的具体情况，请尽量详尽完善！</span>
                </td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td valign="top" class="tdbg">
                    <span class="f_red">*</span> <strong>管理团队：</strong>
                </td>
                <td>
                    <textarea id="txtManageTeamAbout" cols="50" rows="5" style="width: 80%" runat="server"></textarea>
                    <br />
                    <span class="f_gray">团队架构、高管人员的从业经历等。</span>
                </td>
            </tr>
            <tr>
                <td valign="top" class="tdbg">
                    <strong>项目资料附件：</strong>
                </td>
                <td>
                    <%--<uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />--%>
                    <uc4:FilesUploadControl ID="FilesUploadControl1" runat="server" />
                    <span class="f_gray">您可以上传项目的相关文件，如营业执照、项目批文、证书等；</span>
                </td>
            </tr>
            <%--</table>
        <table width="100%" cellspacing="0" style="text-align: center;">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <!--########### 第二步，确认联络方式 #########-->
    <div id="step2">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">--%>
            <tr>
                <td class="f_14 f_red strong" style="padding: 5px 10px;">
                    联系方式确认
                </td>
            </tr>
        </table>
        <table cellspacing="0" class="mem_tab1">
            <tr>
                <td width="130" class="tdbg">
                    <span class="f_red">*</span> <strong>项目单位名称：</strong>
                </td>
                <td>
                    <input id="txtCompanyName" class="show" type="text" style="width: 210px" runat="server" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>联系人：</strong>
                </td>
                <td>
                    <input id="txtLinkMan" class="show" type="text" style="width: 210px" runat="server" />&nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>联系电话：</strong>
                </td>
                <td>
                    固话
                    <input id="telArea1" type="text" size="3" value="+86" runat="server" />
                    <input id="txtTelStateCode" type="text" size="5" runat="server" />
                    <input id="txtTel" type="text" size="15" runat="server" />
                    <input id="telFg" type="text" size="5" runat="server" />
                    &nbsp;&nbsp;
                    <br />
                    手机
                    <input id="txtMobile" class="show" maxlength="11" type="text" style="width: 210px"
                        runat="server" />&nbsp;
                    <span class="f_gray">（固定电话或手机至少填写一项）</span>
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <span class="f_red">*</span> <strong>电子邮箱：</strong>
                </td>
                <td>
                    <input id="txtEmail" class="show" type="text" style="width: 210px" runat="server" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>项目单位详细地址：</strong>
                </td>
                <td>
                    <input id="txtAddress" type="text" value="" style="width: 210px" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <strong>单位网址：</strong>
                </td>
                <td>
                    <input id="txtWebSite" type="text" value="" style="width: 210px" runat="server" />&nbsp;
                </td>
            </tr>
        </table>
        <table width="100%" cellspacing="0" style="height: 60px; text-align: center;">
            <tr>
                <td>
                    <asp:Button ID="btnOK" runat="server" Text="确认修改" OnClick="BtnOk_Click" />
                </td>
            </tr>
        </table>
    </div>
    <!--###########  第二步结束  #########-->
    </form>
</body>
</html>
