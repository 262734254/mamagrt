<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentElite.aspx.cs" Inherits="helper_InfoComment_CommentElite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="http://www.topfo.com/css/common.css" rel="stylesheet" type="text/css">
    <link href="http://Elite2.topfo.com/css/elite.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="elitetit">
            <h1>
                网友评论</h1>
        </div>
        <div class="etempb">
            <div class="blank6">
            </div>
            <asp:Repeater runat="server" ID="ComentList">
                <ItemTemplate>
                    <dl>
                        <dd>
                            <%#Eval("LoginName")%>
                            发表于
                            <%#Eval("CommentTime")%>
                            <dt>
                                <%#GetStr(Eval("CommentContent"),50)%>
                                <p>
                                </p>
                            </dt>
                    </dl>
                </ItemTemplate>
            </asp:Repeater>
            <div class="etemppage">
                共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                    ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                        runat="server" Text="0"></asp:Literal>页
                <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>转到
                    第<input id="txtPage" runat="server" name="textarea" style="width: 48px" type="text" />
                    页</span>
                <input id="btnGo" runat="server" onserverclick="btnGo_ServerClick" type="button"
                    value="GO" /></div>
        </div>
        <div class="blank0">
        </div>
        <!-- -->
        <div class="elitetit">
            <h1>
                我要发表评论</h1>
        </div>
        <div class="etempb etempcomment" style="width: 574px">
            <div runat="server" id="divLogin">
                用户名：
                <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                密 码
                <asp:TextBox runat="server" ID="txtPwd" TextMode="Password"></asp:TextBox>
                <input type="button" name="button" runat="server" id="btnLogin" value="登陆" onserverclick="btnLogin_ServerClick">
                <a href="http://member.topfo.com/Register/Register.aspx" target="_blank">免费注册</a></div>
            <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Wrap="true" Width="550px"
                Columns="110" Rows="10" Height="126px"></asp:TextBox>
            <asp:Button runat="server" ID="btnOk" Text="提交评论" OnClick="btnOk_Click" />
        </div>
    </form>
</body>
</html>
