<%@ Page Language="C#" AutoEventWireup="true"  Title="找回密码 拓富—中国招商投资网" MasterPageFile="~/Retrieve.master" CodeFile="RetrieveStep1.aspx.cs" Inherits="Register_RetrieveStep1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div  style="text-align: right;" ><a href="http://www.topfo.com/">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>


<div class="mainbox">

 <div class="bg1 bgimg03">

<b>第一步：填写登录名</b><br />
     <asp:TextBox ID="TxtUserName" CssClass="oninpcss" runat="server"></asp:TextBox>
<span class="font12 normal">如果您忘记登录名，<a href="RetrieveStep10.aspx" class="line">请点此找回</a></span><br />
<p><asp:requiredfieldvalidator id="rfcUserName"  CssClass="font12 normal" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="TxtUserName" Width="144px"></asp:requiredfieldvalidator>
    <asp:RegularExpressionValidator ID="revLoginName" runat="server" ControlToValidate="TxtUserName"
        CssClass="font12 normal" Display="Dynamic" ErrorMessage="会员登录名只能由（4－16个）数字或英文组成"
        ValidationExpression="^[a-zA-Z0-9]\w{3,16}$"></asp:RegularExpressionValidator></p>
<b>第二步：选择找回密码的方式</b><br />
<div class="bgimg04">
    <asp:LinkButton ID="LbEmail" CssClass="line normal" runat="server" OnClick="LbEmail_Click">通过您注册时填写的邮箱找回密码</asp:LinkButton>&nbsp;
<br />
    <asp:LinkButton ID="LbQuestion" runat="server" CssClass="line normal" OnClick="LbQuestion_Click">通过您设置的密码保护问题找回密码</asp:LinkButton><br />
    <asp:LinkButton ID="LbPhone" runat="server" CssClass="line normal" OnClick="LbPhone_Click">通过您注册时填写的手机找回密码</asp:LinkButton></div>

<div class="blank0"></div>
</div>
</div>

 </asp:Content>
