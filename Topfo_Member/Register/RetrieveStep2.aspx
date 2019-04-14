<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  MasterPageFile="~/Retrieve.master" Title="找回密码 拓富—中国招商投资网" CodeFile="RetrieveStep2.aspx.cs" Inherits="Register_RetrieveStep2" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right" ><a href="RetrieveStep1.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>


<div class="mainbox">

 <div class="inforbox wi628 bgimg05">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">我们需要确认您的身份</p>
<div class="blank0"></div>

<p class="pL180">请输入您的注册邮箱：<asp:textbox  CssClass="oninpcss" id="txtEmail" runat="server"></asp:textbox>
    <asp:Button ID="BtnSendmail" runat="server" Font-Size="Small" Height="23px" OnClick="BtnSendmail_Click"
        Text="提  交" Width="76px" /></p>
<p>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:requiredfieldvalidator id="rfcEmail" runat="server" ErrorMessage="电子邮箱不能为空" ControlToValidate="txtEmail"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revEmail" runat="server" ErrorMessage="电子邮箱范例为webmaster@tz888.cn" ControlToValidate="txtEmail"
																Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
    <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></p>	
</div>
</div>
 </asp:Content>
 