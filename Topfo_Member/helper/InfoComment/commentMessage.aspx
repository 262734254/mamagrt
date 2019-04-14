<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commentMessage.aspx.cs" Inherits="helper_InfoComment_commentMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<link href="http://www.topfo.com/V4/css/common.css" rel="stylesheet" type="text/css"/>
<link href="http://www.topfo.com/V4/css/sj.css" rel="stylesheet" type="text/css"/>
<link href="http://www.topfo.com/V4/css/Investment_Details.css" rel="stylesheet" type="text/css"/>
<link href="http://www.topfo.com/V4/css/Latest_Merchants_Project.css" rel="stylesheet" type="text/css"/>

<script language="javascript" type="text/javascript">
<!--


// -->
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="con3">
    <div class="con3_t f_yahei f_16 f_org">给发布方留言<span class="liuyan"><asp:Literal ID="ltCount" runat="server"></asp:Literal></span></div>
			<div class="f_gray"  id="divLogin" runat="server">如果您已经是注册会员请先登陆后留言这将有助于您更好的与对方沟通！ <a href="http://member.topfo.com/Login.aspx" target="_blank">&gt;&gt;登陆留言</a></div>
			<%--<div class="con3_t f_yahei f_16 f_org">给发布方<asp:Label runat="server" ID="lbInfoOwner"></asp:Label>留言</div>
            <div style="float:right;width:100px; text-align:right;"><asp:Literal ID="ltCount" runat="server"></asp:Literal></div>
			<div class="f_gray" id="divLogin" runat="server">如果您已经是注册会员，请先<a href="http://member.topfo.com/Login.aspx" target="_blank">登陆</a>后留言，这将有助于您更好的与对方沟通！ <a href="http://member.topfo.com/Login.aspx" target="_blank">&gt;&gt;登陆留言</a></div>--%>
		</div>
		
		   <table width="637px" border="0" cellspacing="0" cellpadding="0" class="tab2">
          <tr>
            <td width="12%" align="right">姓名：</td>
            <td width="88%"><input type="text" name="textfield3" id="txtName" runat="server" class="inp2">
            电话：
            <input type="text" id="txtTel" runat="server" name="textfield32" class="inp2" />
            邮箱：
            <input type="text" id="txtEmail" runat="server" name="textfield322" class="inp2" />
            </td>
          </tr>

          <tr>
            <td align="right">留言内容：</td>
            <td><textarea name="textarea" id="txtComment" runat="server" rows="5" style="width:90%;"></textarea></td>
          </tr>
          <tr>
            <td colspan="2" align="center"><asp:Button runat="server" ID="btnOk" Text="确认" CssClass="btn2" OnClick="btnOk_Click" /> 
              &nbsp;<asp:Button runat="server" ID="btnCancel" Text="重填" CssClass="btn2" OnClick="btnCancel_Click" /> 
            </td>
          </tr>
        </table>
     
     
    </form>
</body>
</html>
