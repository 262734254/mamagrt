<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExtensionOperation.aspx.cs"
    Inherits="Manage_ExtensionOperation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="../css/refresh.css" type="text/css" rel="stylesheet">

   <div id="mainconbox">
        <div class="titled">
            <div class="left">
               有效期设置</div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="cshibiank">
            <div class="setubcon">
                <table border="0" cellpadding="0" cellspacing="0" class="table_bcol" style="width: 649px">
                    <tr>
                        <td align="left" valign="top">
                            <table border="0" align="center" cellpadding="0" cellspacing="0" style="width: 569px">
                                <tr>
                                    <td>
                                        <p>
                                            您在<asp:Literal ID="ltPubDate" runat="server"></asp:Literal>日发布的
                                            “<asp:Literal ID="ltTitle" runat="server"></asp:Literal>”信息已经在<asp:Literal ID="ltStartDate" runat="server"></asp:Literal>
                                              过期，如果要继续展示请选择延期时间：</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="50">
                                            <strong>★ 免费延期</strong><br />
                                            请选择有效期：
                                            <select id="stTerm" runat="server" name="stTerm">
                                                <option value="1" selected>1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="5">5</option>
                                                <option value="6">6</option>
                                                <option value="7">7</option>
                                                <option value="8">8</option>
                                                <option value="9">9</option>
                                                <option value="10">10</option>
                                                <option value="11">11</option>
                                                <option value="12">12</option>
                                            </select>
                                            个月<asp:Button ID="ibModify" runat="server" Text="修改" OnClick="ibModify_Click">
                                            </asp:Button> 
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
