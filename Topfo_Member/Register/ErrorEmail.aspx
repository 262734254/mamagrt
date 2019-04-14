<%@ Page Language="C#" MasterPageFile="~/Retrieve.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ErrorEmail.aspx.cs" Inherits="Register_ErrorEmail" Title="找回用户名 拓富—中国招商投资网" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="NavTitle">
<h3 class="leftfloat"><span>找回用户名</span></h3>
<div style="text-align: right" ><a href="RetrieveStep10.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>

<div class="mainbox">


<div class="inforbox wi628 bgimg05">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">
    系统没有找到（<span class="orange02 normal"><asp:Label ID="LblEmail" runat="server"></asp:Label></span>）的邮箱，请重新输入您的注册邮箱！</p>
<div class="blank0"></div>

<p class="pL180">请输入您的注册邮箱：<asp:textbox  CssClass="oninpcss" id="txtEmail" runat="server"></asp:textbox>
    <asp:Button ID="BtnConfirm" runat="server" CssClass="inputbtn" Text="提  交" OnClick="BtnConfirm_Click" />&nbsp;
</p> 
<p>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:requiredfieldvalidator id="rfcEmail" runat="server" ErrorMessage="电子邮箱不能为空" ControlToValidate="txtEmail"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revEmail" runat="server" ErrorMessage="电子邮箱范例为webmaster@tz888.cn" ControlToValidate="txtEmail"
																Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
    </p>	
    <p>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></p>
    <p >
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; 您可以<a href="http://member.topfo.com/Register/Register.aspx" style="color: blue"><span style="text-decoration: underline">点击这里</span></a>重新注册</p>
</div>




</div>
</asp:Content>
