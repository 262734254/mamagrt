<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TFZSEvaluateControl.ascx.cs"
    Inherits="Controls_TFZSEvaluateControl_ZQ" %>
<div class="assessbox cshibiank">
    <h1 class="lightc">
        投资机构对拓富指数非常重视，<span class="hong">请认真填写以下选项</span>。您也可以略过此步，但您可能因此错过改善项目质量、提升合作成功率的机会。</h1>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td style=" width:150px; height: 27px; text-align:right;">
                公司名称：</td>
            <td style="height: 27px">
                <asp:TextBox ID="txtComName" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                项目名称：</td>
            <td>
                <asp:TextBox ID="txtProjectName" runat="server" /></td>
        </tr>
        <tr>
            <td align="right">
                是否属于高新技术产业：</td>
            <td>
                <label>
                    <input type="checkbox" value="checkbox" name="checkbox">
                </label>
                高新技术产业
                <input type="checkbox" value="checkbox" name="checkbox2">
                传统产业</td>
        </tr>
        <tr>
            <td valign="top" align="right" style="height: 38px">
                项目立项情况：</td>
            <td style="height: 38px">
                <input type="checkbox" value="checkbox" name="checkbox3">
                缺少项目批文
                <input type="checkbox" value="checkbox" name="checkbox4">
                缺少项目所需执照
                <input type="checkbox" value="checkbox" name="checkbox5">
                缺少项目所需证件
                <input type="checkbox" value="checkbox" name="checkbox6">
                项目手续齐全<br>
                <span class="hui">说明：项目若缺乏所需批文、执照和证件，则对项目评价有较大影响</span></td>
        </tr>
        <asp:Repeater ID="RfOptions" runat="server">
            <ItemTemplate>
                <tr>
                    <td align="right" style="height: 20px;">
                        <%#Eval("ExpressName")%>
                        ：</td>
                    <td style="height: 20px">
                        <%#GetOptionDetails(Eval("ExpressCode").ToString(),Convert.ToBoolean(Eval("IsMulti")))%>
                        <br />
                        <span class="hui">评价描述:<%#Eval("ExpressDescript")%></span>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="buttom" style="width: 100%; text-align: center;">
        <input type="button" value="查看项目评价结果" />
    </div>
</div>

<script type="text/javascript" language="javascript">
function GetCheckNum(checkobjectname)
{
	var truei2 = 0;
	checkobject = eval("document.all."+checkobjectname);
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


function checknum(checkobjectname,maxnum){
	var truei2 = GetCheckNum(checkobjectname);
	if (truei2 > maxnum){
		alert("你已经选择了"+truei2+"个，而这个问题最大的选择数是"+maxnum+"个！！！");
		window.event.returnValue = false;
		return false;
	}
	return  true;
}

function isEmpty(s)
{  
	return ((s == null) || (s.length == 0))
}

</script>

