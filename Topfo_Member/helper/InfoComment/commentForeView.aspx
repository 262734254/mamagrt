<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commentForeView.aspx.cs" Inherits="helper_InfoComment_commentForeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
  <link href="http://www.topfo.com/web13/css/base.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
.messagesbox{}
.messagesbox h1{
	font-size: 14px;
	border-bottom-width: 2px;
	border-bottom-style: solid;
	border-bottom-color: #C9C9C9;
	padding: 3px 0 1px 7px;
}
.messagesbox p{
	padding: 3px 0 3px 20px;
}
.messagesbox p.padtb{padding:10px 0 10px 20px;}
.messagesbox p.padl{padding:5px 0 0px 10px;}
.messagesbox .mbluek{
	background-color: #F6F6F6;
	border: 1px solid #D4D4D4;
	padding: 6px 0 6px 20px;
}
-->
    </style>
</head>
<body>
    <form id="form1" runat="server" >
             <div class="messagesbox">
                        <h1 runat="server" id="h1">
                            </h1>
                        <div style="float:left;width:306px;">给项目发布者 <span class="orange01"><asp:Label runat="server" ID="lbInfoOwner"></asp:Label></span> 留言</div>
                        <div style="float:right;width:100px; text-align:right;"><asp:Literal ID="ltCount" runat="server"></asp:Literal></div>
                        <div class="clear"></div>
						<div class="mbluek"  runat="server" id="divLogin">推荐您 <a href="http://member.topfo.com/Login.aspx" target="_blank">登陆</a> 后再向发布者留言，用户可以查看您的更多信息，对您更信任。<i></i> <a href="http://member.topfo.com/Register/Register.aspx" target="_blank">免费注册&gt;&gt;</a></div>
                        <p class="padtb">
                            姓名：
                            <asp:TextBox runat="server" ID="txtName" Width="150px"></asp:TextBox>
                            <i></i>电话：
                            <asp:TextBox runat="server" ID="txtTel" Width="150px"></asp:TextBox>
                            <i></i>E-mail：
                            <asp:TextBox runat="server" ID="txtEmail" Width="150"></asp:TextBox>
                        </p>
                        <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Wrap="true" Width="630px" Columns="110" Rows="10"></asp:TextBox>&nbsp;
                        <p class="padtb">
                            
                            <asp:Button runat="server" ID="btnOk" Text="提 交" OnClick="btnOk_Click" />
                            <label>
                               
                                <asp:Button runat="server" ID="btnCancel" Text="重 置" OnClick="btnCancel_Click" />
                            </label>
                        </p>
      </div>
    </form>
</body>
</html>
