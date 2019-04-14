<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TFZS.aspx.cs" Inherits="Controls_TFZS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>拓富指数</title>
    <link href="http://www.topfo.com/TopfoCenter/css/exponent.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="content">
        <ul class="res">
            <li class="title"><span>排名</span> <span class="neirong">资源标题</span> <span>指数</span>
            </li>
            <asp:Repeater runat="server" ID="myList">
                <ItemTemplate>
                    <li><span>
                        <asp:Image ID="Image1" runat="server" />
                    </span><a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>"><span
                        class="neirong" style="color: #0000ff">
                        <%#GetStr(Eval("Title"))%>
                    </span></a><span>
                        <%#Eval("TopValue")%>
                    </span></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</body>
</html>
