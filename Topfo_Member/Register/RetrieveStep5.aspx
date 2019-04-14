<%@ Page Language="C#" MasterPageFile="~/Retrieve.master" EnableEventValidation="false" Title="找回密码 拓富—中国招商投资网" AutoEventWireup="true" CodeFile="RetrieveStep5.aspx.cs" Inherits="Register_RetrieveStep5"%>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
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
function checkAnswer()
{
    var txtNameID = "<%=this.TxtAnswer.ClientID %>";
    var obj = document.getElementById(txtNameID);
    if(obj.value == "")
    {
        document.getElementById("spAnswer").innerHTML = "&nbsp;&nbsp;&nbsp;密码保护问题答案不为空！";
        document.getElementById("spAnswer").className = "noteawoke";
        obj.focus();
        return false;
    }
    if(checkByteLength(obj.value,0,50))
    {
        document.getElementById("spAnswer").innerHTML = "";
        document.getElementById("spAnswer").className = "";
        return true; 
    }
    else 
    {
        document.getElementById("spAnswer").innerHTML = "&nbsp;&nbsp;&nbsp;密码保护问题答案必须少于25字！";
        document.getElementById("spAnswer").className = "noteawoke";
        obj.focus();
        return false;
    }

}
function CheckForm()
{
    var revalue = true;
    if(!checkAnswer()){
        if(revalue) revalue = false;} 
    return revalue;
}


document.getElementById("aspnetForm").onsubmit = CheckForm;
</script> 
<div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right" ><a href="RetrieveStep1.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>
<div class="mainbox">


<div class="inforbox wi800 bgimg06">

<div class="blank0"></div><div class="blank20"></div>


<div class="pL180">
<p><b>请回答您的密码保护问题：</b></p>
<div class="blank0"></div>

<div >
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="marbottom12">
  <tr>
    <td width="29%" height="43" align="right" class="font14">您的密码保护问题为：</td>
    <td width="71%"  class="font14">
        <asp:Label ID="LblQuestion" runat="server" Text="LblQuestion "></asp:Label></td>

    </tr>
  <tr>
    <td align="right"><span class="font14">请输入密码保护问题答案：</span></td>
    <td>
        <asp:TextBox ID="TxtAnswer"　onchange="JavaScrpit:checkAnswer()" CssClass="oninpcss" runat="server" ></asp:TextBox> 
        <asp:Button ID="BtnConfirm" CssClass="inputbtn" runat="server" Text="确  定" OnClick="BtnConfirm_Click" /><span
            id="spAnswer" style="color:Red"></span>
        <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></td>
    </tr>
</table>
</div>

</div>
</div>
</div>
</asp:Content>

