<%@ Page Language="C#" MasterPageFile="~/Retrieve.master" EnableEventValidation="false" Title="找回密码 拓富—中国招商投资网" AutoEventWireup="true" CodeFile="RetrieveStep10.aspx.cs" Inherits="Register_RetrieveStep10"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="NavTitle">
<h3 class="leftfloat"><span>找回用户名</span></h3>
<div style="text-align: right" ><a href="RetrieveStep1.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>

<div class="mainbox">


<div class="inforbox wi628 bgimg05">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">请输入您注册时填写的E-mail地址，系统会自动将您的用户名发送到您的邮箱中！</p>
<div class="blank0"></div>

<p class="pL180">请输入您的注册邮箱：<asp:textbox  CssClass="oninpcss" id="txtEmail" runat="server"></asp:textbox>
    <asp:Button ID="BtnConfirm" runat="server" CssClass="inputbtn" Text="提  交" OnClick="BtnConfirm_Click" />&nbsp;
</p> 
<p>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:requiredfieldvalidator id="rfcEmail" runat="server" ErrorMessage="电子邮箱不能为空" ControlToValidate="txtEmail"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revEmail" runat="server" ErrorMessage="电子邮箱范例为webmaster@tz888.cn" ControlToValidate="txtEmail"
																Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></p>	</div>




</div>


</asp:Content>

