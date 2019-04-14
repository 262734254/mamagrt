<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageUpLoadForAdditive.ascx.cs" Inherits="Register_Control_ImageUpLoadForAdditive" %>
<table style="width: 371px; height: 1px"  >
    <tr >
        <td align="center" style="width: 437px">
            <asp:Label ID="lbName" runat="server">标题</asp:Label></td>
    </tr>
    <tr>
        <td align="center" style="width: 437px">
            <asp:Image ID="Image1" runat="server" Height="106px" Width="112px" ImageUrl=" ../../images/MemberData/men.jpg" />&nbsp;<br />
            &nbsp;<asp:Button ID="btOper" runat="server" Text="上传" OnClick="btOper_Click" />&nbsp;<asp:Button ID="imgCancelPic1"
                runat="server" OnClick="imgCancelPic1_Click1" Text="取消" />
     <INPUT id="hidePic1" style="WIDTH: 10px" type="hidden" size="1" name="Hidden1" runat="server"/></td>
    </tr>
    <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px" Visible="false">    
    <tr >
        <td align="right" style="width: 437px; height: 27px;">
            <INPUT id="uplPic1" type="file" name="file" runat="server" style="width: 251px"/>&nbsp;<asp:Button ID="imgbtnPic1"
                runat="server" OnClick="imgbtnPic1_Click1" Text="上  传" /></td>
    </tr>
    </asp:Panel>
</table>
<input id="Button1" type="button" value="button" runat="server" onserverclick="Button1_ServerClick" />
<asp:ImageButton ID="ImageButton1" runat="server" />
