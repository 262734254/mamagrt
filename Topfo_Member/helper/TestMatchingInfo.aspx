<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestMatchingInfo.aspx.cs" Inherits="helper_TestMatchingInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">搜索定阅</span></span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="#" class="publica-fbxq">需求发布规则</a></span></h1>
    <div  runat="server" id="showMessage">
      </div>
      <asp:Panel runat="server" ID="forTFT">
        <h2>
        <ul>
         <li  class="btn_on"  id="sh_btn_1">我的订阅1</li>
         </ul>
        </h2>
     <div class="manage" id="sh_con_1">
         <table width="100%" border="0"  cellpadding="0" cellspacing="0">
                    <tr>
                        <td  colspan="5">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                Width="100%" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand"
                                OnRowDeleting="GridView1_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="订阅名称">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
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
                                    <%--<asp:TemplateField HeaderText="发送频率">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbValidateTerm" runat="server"></asp:Label>
                                            <%#GetStr(Eval("ValidateTerm"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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
                            <%--<asp:Button ID="btnAdd" runat="server" CssClass="buttomal" Text="订阅新的搜索 " OnClick="btnAdd_Click" />--%>
                            <input type="button" id="btnAdd" runat="server" class="btn-003" value="订阅新的搜索" onclick="window.location.href='MyMatching.aspx?tag=Add'" onserverclick="btnAdd_ServerClick" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 21px">
                            <div id="forReg" runat="server">
                                &nbsp;</div>
                        </td>
                    </tr>
                </table>
    </div>
</asp:Panel>
    <div class="zhuyi">
     <h3><span class="fl" style="margin:2px 10px 0 0"><img src="http://img2.topfo.com/member/images/manage_23.jpg"  /></span> <span class="fl" >注意事项</span></h3>
   <p>
                · 您可以修改您发布的需求，但修改后的内容需要经过我们的审核才能出现在网上。
                <br>
                · 经常刷新您发布的需求，可以让需求尽量排在同类信息的前面！刷新功能为拓富通会员专享。1元钱体验拓富通会员服务 <a href="/Register/VIPMemberRegister.aspx" target="_blank" class="publica-fbxq">申请拓富通</a>
                <br>
                · 您可以通过设置，指示系统将匹配的资源通过邮件或站内短信的形式发送给您！<a href="/helper/Notice.aspx" class="publica-fbxq">点此立即设置 </a>
                <br>

            </p>
    </div>
      </div>
</div>
    </div>
    </form>
</body>
</html>
