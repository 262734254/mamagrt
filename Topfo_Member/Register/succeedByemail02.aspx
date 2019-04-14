<%@ Page Language="C#" MasterPageFile="~/Retrieve.master"  Title="找回密码 拓富—中国招商投资网" AutoEventWireup="true" CodeFile="succeedByemail02.aspx.cs" Inherits="Register_succeedByemail02"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {
window.location.href="http://member.topfo.com/";
}

// ]]>
</script>

<div class="NavTitle">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right" ><a href="RetrieveStep2.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>
<div class="mainbox">


<div class="inforbox wi628 bgimg13">

<div class="blank0"></div><div class="blank20"></div>

<p class="pL180 bold">系统已经将您的用户名发送到您的邮箱（<span class="orange01 normal"><asp:Label
    ID="LblEmail" runat="server" Text="LblEmail"></asp:Label></span>），请注意查收并牢记您的用户名！</p>
<div class="blank0"></div>

<p class="pL180 centeralign">
  <input name="Input3" type="button"  class="inputbtn" value="返回登录页面" id="Button1" onclick="return Button1_onclick()"/>
</p>

</div>



</div>
</asp:Content>

