<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Retrieve.master" Title="找回密码 拓富—中国招商投资网" CodeFile="succeedByemail.aspx.cs" Inherits="Register_succeedByemail" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div class="rightfloat"><a href="">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>


<div class="mainbox">

 <p class="bg1 bgimg01">您的身份得到确认！系统已经自动给您的邮箱（<span class="orange02 normal"><asp:Label
     ID="LblEmail" runat="server" Text="LblEmail"></asp:Label></span>）发送<br />

了一封邮件，请查收邮件，并在24小时内根据邮件的提示重新设置密码。<br /><span class="orange02">如果您没有收到邮件，请尝试使用以下两种方式找回密码：</span></p>


<p class="bg2 bgimg02"><a href="RetrieveStep5.aspx" class="line">通过您设置的密码保护问题找回密码</a><br />
<a href="RetrieveStep7.aspx" class="line">通过您注册时填写的手机找回密码</a></p>
</div>
 </asp:Content>