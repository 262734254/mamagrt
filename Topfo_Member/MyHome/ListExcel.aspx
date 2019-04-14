<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListExcel.aspx.cs" Inherits="MyHome_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Œﬁ±ÍÃ‚“≥</title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
    <asp:Repeater ID="GridViewE" runat="server">
                <ItemTemplate>
                                <tr>                                    
                                        <td height="26" align="center" style="width: 9%">                                        
                                            <%#Eval("LName")%>
                                    </td>
                                    <td height="26" align="center" style="width: 9%">
                                        &nbsp;<%#Eval("Linkwww")%></td>
                                    <td height="26" align="center" style="width: 9%">
                                        &nbsp;<%#ShowUserName(Eval("nid").ToString())%></td>
                                    <td align="center" height="26" style="width: 9%">
                                            <%#Eval("CreateTimes","{0:yyyy-MM-dd}")%>
                                    </td>             
                                </tr>
                            </ItemTemplate>
                </asp:Repeater>          
                </table>     
    </form>
</body>
</html>
