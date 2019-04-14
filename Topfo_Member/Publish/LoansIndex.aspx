<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoansIndex.aspx.cs" Inherits="Publish_LoansIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvlistLoansManager" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="项目名称">
                <ItemTemplate>
                <asp:Label ID="labtitlename" runat="server" Text ='<%# Eval("LoansTitle") %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="地域">
                <ItemTemplate>
                <asp:Label  ID="labProvinceName" runat="server" Text='<%# GetProvinceName(Convert.ToInt32(Eval("LoansInfoID"))) %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="贷款总金额">
                <ItemTemplate>
                <asp:Label ID="AmountMoney" runat="server"  Text='<%# GetAmountMoney(Convert.ToInt32(Eval("LoansInfoID"))) %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="贷款类型">
                <ItemTemplate>
                <asp:Label ID="BorrowingType" Text='<%#GetBorrowingType(Convert.ToInt32( Eval("BorrowingType"))) %>' runat ="server"></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="详细"></asp:TemplateField>
            </Columns>
       
        </asp:GridView>
    </div>
    </form>
</body>
</html>
