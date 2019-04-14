<%@ Page Language="C#" MasterPageFile="~/Retrieve.master" Title="找回密码 拓富—中国招商投资网"  AutoEventWireup="true" CodeFile="RetrieveStep9.aspx.cs" Inherits="Register_RetrieveStep9"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right"><a href="RetrieveStep7.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>
<div class="mainbox">


<div class="inforbox wi628 bgimg07">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">对不起，您输入的手机号码与您注册时填写的手机号码不一致，请重新输入！</p>
<div class="blank0"></div>

<p class="pL180">请输入您注册时填写的手机号码：<asp:TextBox ID="TxtMobile"  CssClass="oninpcss" runat="server"></asp:TextBox>
    <asp:Button ID="BtnConfirmMoible" runat="server"  CssClass="inputbtn" Text="提  交" OnClick="BtnConfirmMoible_Click" /> </p>
    <p class="pL180">
        &nbsp;<asp:RequiredFieldValidator ID="rfcPr" runat="server" ControlToValidate="TxtMobile"
            CssClass="font12 normal" ErrorMessage="手机号码不能为空" Width="144px"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revMoible" runat="server" ControlToValidate="TxtMobile"
        Display="Dynamic" ErrorMessage="手机号码为11个数字" ValidationExpression="^\d{11}$"></asp:RegularExpressionValidator>
        <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></p>

</div>




</div>


</asp:Content>

