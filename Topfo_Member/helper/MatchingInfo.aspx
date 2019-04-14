<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MatchingInfo.aspx.cs" Inherits="helper_MatchingInfo"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />--%>

    <div class="member-right">
        <div class="publication">
            <h1>
                <span class="fl"><span class="f_14px strong f_cen">搜索定阅</span></span><span class="fr pb-mg01">
                    <img src="../images/biao_01.gif" align="absMiddle" />
                    <a href="http://www.topfo.com/help/subscribe.shtml" class="publica-fbxq">如何订阅</a></span>
            </h1>
            <div class="fbcg">
                <div class="fbcg1" style="width: 740px">
                    <div id="showMessage" runat="server">
                    </div>
                </div>
            </div>
        </div>
       </div>
        <asp:Panel ID="forTFT" runat="server">
            <div class="handtop"  style="display:none">
                <ul>
                    <li class="btn_on">我的订阅 </li>
                    <li class="btn_on"><a href="MyMatching.aspx">添加订阅</a></li>
                </ul>
            </div>
            <div class=" cshibiank" style="padding: 5px">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" colspan="5">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                Width="685px" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand"
                                OnRowDeleting="GridView1_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="订阅名称">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <%--<asp:HyperLink ID="hlTitle" runat="server" Text='<%#Eval("Title")%>' NavigateUrl='<%#Eval("ID","MachingMessage.aspx?ID={0}")%>'></asp:HyperLink>--%>
                                            <%--
                                        <asp:HyperLink ID="hlTitle" runat="server" Text='<%#Eval("Title")%>' 
                                        NavigateUrl='MachingMessage.aspx?ID=<%# Eval("ID")%>'></asp:HyperLink>
                                        --%>
                                            <%--<a id="hlTitle" href='MachingMessage.aspx?ID=<%# Eval("ID")%>&type=<%# Eval("CustomType")%>' runat="server"><%#Eval("Title")%></a>--%>
                                            <a id="hlTitle" href='<%# GetTitleUrl(Eval("ID"), Eval("CustomType"))%>'>
                                                <%#Eval("Title")%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="类型">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <%#GetCustomType(Eval("CustomType"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="发送频率">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbValidateTerm" runat="server"></asp:Label>
                                            <%#GetStr(Eval("ValidateTerm"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="订阅匹配数量(条)">
                                        <EditItemTemplate>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                            <%#GetMatchingCount(Eval("ID"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="管理功能">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlUpdate" runat="server" NavigateUrl=' <%#GetUrl(Eval("ID"), Eval("CustomType"))%>'
                                                Text="修改"></asp:HyperLink>
                                            <asp:LinkButton ID="hlDel" runat="server" CommandArgument='<%#Eval("ID")%>' Text="删除" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnAdd" runat="server" CssClass="buttomal" Text="订阅新的搜索 " OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5" style="height: 21px">
                            <div id="forReg" runat="server">
                                &nbsp;</div>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <div class="pagebox" align="center">
            &nbsp;</div>
</asp:Content>
