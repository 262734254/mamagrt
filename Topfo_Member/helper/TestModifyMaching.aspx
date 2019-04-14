<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestModifyMaching.aspx.cs" Inherits="helper_TestModifyMaching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">搜索订阅</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
      <div class="jl-wxts">
         <h3><img src="http://img2.topfo.com/member/img/icon_tishi.gif" align="absMiddle" /> 如何设置搜索订阅</h3>
         <p>如果您无暇上网，又担心错过了好机会，请进行免费订阅设置。<br />
            第一时间抢占先机，万千财富滚滚来！ <br />
            如果你想拥有无限数量的订阅，请 <a href="/Register/VIPMemberRegister_In.aspx">申请拓富通会员</a><br />
            您是拓富通会员，享有无限数量的免费订阅权限 
           </p>
      </div>
       
        <h2 style="margin-bottom:0">
        <ul >
        <li  id="div0" class="btn_on"><a href="#" >订阅信息</a></li>
         <li><a href="MatchingInfo.aspx">我的订阅</a></li>
         
         </ul>
        </h2>

<!--共同部分 -->
  <table width="100%"  cellpadding="0" cellspacing="0"  class="publica">
     <tr>
        <td class="publica-td-left" width="20%">
           搜索订阅的名称：       
        </td>
        <td>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox> 
        </td>
    </tr>
<%--    <tr>
        <td class="publica-td-left" width="20%">
          发布时间：
        </td>
        <td>
        <asp:DropDownList ID="ddlValidateTerm" runat="server">
            <asp:ListItem Value="0" Selected="True">不限</asp:ListItem>
            <asp:ListItem Value="3">3天</asp:ListItem>
            <asp:ListItem Value="7">7天</asp:ListItem>
            <asp:ListItem Value="15">15天</asp:ListItem>
            <asp:ListItem Value="30">30天</asp:ListItem>
            <asp:ListItem Value="60">60天</asp:ListItem>
            <asp:ListItem Value="90">90天</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>--%>
      <tr>
        <td colspan="2" id="pub-tongyi" >
         <asp:Button CssClass="btn-003" ID="btnCustom" runat="server" Text="保存并搜索"  OnClick="btnCustom_Click"></asp:Button>
         </td>
        </tr>
   </table>
   <asp:Label ID="lbMobile" runat="server"></asp:Label>
    </div>
      </div>
    </form>
</body>
</html>
