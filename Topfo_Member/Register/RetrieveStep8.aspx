<%@ Page Language="C#" MasterPageFile="~/Retrieve.master"  Title="找回密码 拓富—中国招商投资网" AutoEventWireup="true" CodeFile="RetrieveStep8.aspx.cs" Inherits="Register_RetrieveStep8"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right"><a href="succeedByMobile.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>
<div class="mainbox">


<div class="inforbox wi628 bgimg07">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">对不起，您输入的验证码不正确，请重新输入！</p>
<div class="blank0"></div>

<p class="pL180">请输入您收到的验证码：<asp:TextBox ID="TxtProof"  CssClass="oninpcss" runat="server"></asp:TextBox>
    <asp:Button ID="BtnConfirmMoible" runat="server"  CssClass="inputbtn" Text="提  交" OnClick="BtnConfirmMoible_Click" /></p>
    <p class="pL180">
        <asp:RequiredFieldValidator ID="rfcProof" runat="server" ControlToValidate="TxtProof"
        CssClass="font12 normal" ErrorMessage="验证码不能为空" Width="144px"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revProof" runat="server" ControlToValidate="TxtProof"
        Display="Dynamic" ErrorMessage="验证码为6个数字" ValidationExpression="^\d{6}$"></asp:RegularExpressionValidator>
        <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></p>

</div>




</div>


</asp:Content>

