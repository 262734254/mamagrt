<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Retrieve.master"  Title="找回密码 拓富—中国招商投资网" CodeFile="RetrieveStep3.aspx.cs" Inherits="Register_RetrieveStep3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="NavTitle">
<h3 class="leftfloat"><span>重新设置密码</span></h3>
<div class="rightfloat"><a href="">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>


<div class="mainbox">


<div class="inforbox wi800 bgimg06">

<div class="blank0"></div><div class="blank20"></div>


<div class="pL180">
<p>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="LblUserName" runat="server"></asp:Label>&nbsp;<asp:Label
        ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></p>
<div class="blank0"></div>

<div >
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="marbottom18">
  <tr>
    <td width="26%" height="43" align="right"><span class="font14">请输入您的新密码：</span></td>

    <td style="width: 170px; text-align: left">
        <asp:TextBox ID="TxtPwd" CssClass="oninpcss" runat="server" Width="147px" TextMode="Password"></asp:TextBox>&nbsp;</td>
    <td style="width: 325px"><span class="gray03">密码由6-20个英文字母或数字组成，建议采用易记、难猜的英文数字组合。<a href="http://www.topfo.com/help/register.shtml#15" class="Aorange02">&gt;&gt;如何设置安全的密码</a>
        <br /><asp:requiredfieldvalidator id="rfcPwd" runat="server" ErrorMessage="新密码不能为空" ControlToValidate="txtPwd"></asp:requiredfieldvalidator>
        <asp:RegularExpressionValidator ID="revPwd" runat="server" ControlToValidate="txtPwd"
            Display="Dynamic" ErrorMessage="密码由6－16个英文字母或数字组成,并区分英文字母大小写。" ValidationExpression="^[a-zA-Z0-9]\w{5,16}$"></asp:RegularExpressionValidator></span></td>
  </tr>
  <tr>
    <td align="right" style="height: 43px"><span class="font14">请再次输入您的新密码：</span></td>
    <td style="height: 43px; width: 170px; text-align: left;">
        <asp:TextBox ID="TxtRePwd" runat="server" CssClass="oninpcss" Width="151px" TextMode="Password"></asp:TextBox>
        </td>
    <td style="height: 43px; width: 325px;">
        &nbsp;<br /><asp:requiredfieldvalidator id="rfcRePwd" runat="server" ErrorMessage="确认密码不能为空" ControlToValidate="txtRePwd"></asp:requiredfieldvalidator>
        <asp:CompareValidator ID="cpvConfirmPassword" runat="server" ControlToCompare="txtPwd"
            ControlToValidate="TxtRePwd" Display="Dynamic" ErrorMessage="重复输入密码必须与密码一致"></asp:CompareValidator></td>

  </tr>
  <tr>
    <td height="21">&nbsp;</td>
    <td colspan="2"> 
        <asp:Button ID="BtnUpdatePwd" runat="server" CssClass="inputbtn" Text="确  定" Width="76px" OnClick="BtnUpdatePwd_Click" />
        <asp:Button ID="BtnCancel" runat="server" CssClass="inputbtn" Text="取  消" Width="74px" OnClick="BtnCancel_Click" /></td>
    </tr>
</table>
</div>

</div>
</div>
</div>
</asp:Content>


