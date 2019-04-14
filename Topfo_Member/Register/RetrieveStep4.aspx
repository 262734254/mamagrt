<%@ Page Language="C#" MasterPageFile="~/Retrieve.master" EnableEventValidation="false"  Title="找回密码 拓富—中国招商投资网" AutoEventWireup="true" CodeFile="RetrieveStep4.aspx.cs" Inherits="Register_RetrieveStep4"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right"><a href="RetrieveStep2.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>


<div class="mainbox">


<div class="inforbox wi628 bgimg07">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">对不起，您输入的邮箱与您注册时填写的邮箱不一致，请重新输入！</p>
<div class="blank0"></div>

<p class="pL180">请输入您的注册邮箱：<asp:textbox  CssClass="oninpcss" id="txtEmail" runat="server"></asp:textbox><asp:Button id="BtnSendmail" runat="server" Text="提  交" Height="23px" Width="76px" Font-Size="Small" OnClick="BtnSendmail_Click"></asp:Button></p>
<p>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:requiredfieldvalidator id="rfcEmail" runat="server" ErrorMessage="电子邮箱不能为空" ControlToValidate="txtEmail"></asp:requiredfieldvalidator><asp:regularexpressionvalidator id="revEmail" runat="server" ErrorMessage="电子邮箱范例为webmaster@tz888.cn" ControlToValidate="txtEmail"
																Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></p>	&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp;<asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></div>




</div>


</asp:Content>

