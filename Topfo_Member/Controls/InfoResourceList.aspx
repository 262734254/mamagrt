<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoResourceList.aspx.cs"
    Inherits="Controls_InfoResourceList" %>

<input style="width: 62px" id="txtCount" type="hidden" runat="server" />
<asp:repeater runat="server" id="FileList">
        <ItemTemplate>
            <ul style="float:left">
                <li style="float:left">
                    <img src='<%#GetImg(Eval("resourceaddr")) %>' width="47" height="46"></li>
                <li>
                    <%#Tz888.Common.Utility.PageValidate.FixLenth(Eval("ResourceName").ToString().Trim() == "" ? ".." : Eval("ResourceName").ToString(),8,"")%>
                </li>
                <li><a href="javascript:;" onclick='DeleteID(<%#Eval("resourceID") %>)'>删除</a></li>
            </ul>
        </ItemTemplate>
    </asp:repeater>
