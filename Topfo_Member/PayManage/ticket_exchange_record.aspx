<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    ResponseEncoding="GB2312" Title="�ҵĹ���ȯ-�ظ�����-�й�����Ͷ����" CodeFile="ticket_exchange_record.aspx.cs"
    Inherits="PayManage_ticket_exchange_record" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />
    <!--�ҵĹ��ﳵ -->
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                �ҵĹ���ȯ
            </div>
            <div class="clear">
            </div>
        </div>
        <!--����ȯ�һ� -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li><a href="ticket_exchange.aspx">����ȯ�һ�</a></li><li class="liwai">�һ���¼</li><li><a
                        href="http://pay.topfo.com/cost/project.aspx" target="_blank">����ȯ��Դר��</a> </li>
                </ul>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
            <div class="con cshibiank">
                <div class="titlea">
                  <span class="chengcu">  <asp:Literal ID="lblLoginName" runat="server"></asp:Literal></span>����ϸ�һ���¼</div>
                <div class="titleb cyibank">
                    �ۼƻ���<asp:Literal ID="lblJifenCount" runat="server" Text="0"></asp:Literal>�֣����һ�<asp:Literal
                        ID="lblVoucherNum" runat="server" Text="0"></asp:Literal>�Σ��ۼƶһ�����ȯ�ܶ� <font class="chengcu"> <asp:Literal
                            ID="lblBalanceNum" runat="server" Text="0" ></asp:Literal></font>Ԫ����ʹ��<font class="chengcu"><asp:Literal
                                ID="lblUseNum" runat="server" Text="0"></asp:Literal></font>Ԫ<span></span>
                </div>
                <table width="757" border="0" cellpadding="0" cellspacing="0"  class="taba">
                    <tr class="tabtitle">
                        <td width="111" align="center" class="tabtitle">
                            ���
                        </td>
                        <td width="126" align="center" class="tabtitle">
                            �һ�ʱ��</td> 
                        <td width="120" align="center" class="tabtitle">
                            �һ�����
                        </td>
                        <td width="128" align="center" class="tabtitle">
                            �һ����(Ԫ)</td>
                        <td width="121" align="center" class="tabtitle">
                            ʣ�����</td>
                        <td width="151" align="center" class="tabtitle">
                            ����ȯ��Ч��������
                        </td>
                    </tr>
                <asp:Repeater runat="server" ID="myList">
                    <ItemTemplate>
                            <tr>
                                <td width="110" align="center">
                                    <asp:Literal runat="server" ID="lblID"></asp:Literal>
                                </td>
                                <td width="127" align="center">
                                    <%#Eval("ConvertDate") %>
                                </td>
                                <td width="120" align="center">
                                    <%#Eval("ConvertIntegral") %>
                                    ��</td>
                                <td width="129" align="center">
                                    <%#Eval("VoucherMaxBalance","{0:N}") %>
                                    Ԫ</td>
                                <td width="120" align="center">
                                    <%#Eval("LeftIntegral")%>
                                    ��</td>
                                <td width="151" align="center">
                                    <%#Eval("ExpiredDate","{0:yyyy-MM-dd}") %>
                                </td>
                            </tr>
                      
                    </ItemTemplate>
                     <AlternatingItemTemplate>
                     <tr class="tabb">
                                <td width="110" align="center"  class="tabb">
                                    <asp:Literal runat="server" ID="lblID"></asp:Literal>
                                </td>
                                <td width="127" align="center"  class="tabb">
                                    <%#Eval("ConvertDate") %>
                                </td>
                                <td width="120" align="center"  class="tabb">
                                    <%#Eval("ConvertIntegral") %>
                                    ��</td>
                                <td width="129" align="center"  class="tabb">
                                    <%#Eval("VoucherMaxBalance","{0:N}") %>
                                    Ԫ</td>
                                <td width="120" align="center"  class="tabb">
                                    <%#Eval("LeftIntegral")%>
                                    ��</td>
                                <td width="151" align="center"  class="tabb">
                                    <%#Eval("ExpiredDate","{0:yyyy-MM-dd}") %>
                                </td>
                            </tr>
                     </AlternatingItemTemplate>
                </asp:Repeater>
                  </table>
                <div class="bottom">
                    <p>
                        ��<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>�� ҳ�Σ�<asp:Literal
                            ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                                runat="server" Text="0"></asp:Literal>ҳ
                        <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">��ҳ</asp:LinkButton>
                        <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">��һҳ</asp:LinkButton>
                        <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">��һҳ</asp:LinkButton>
                        <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">βҳ</asp:LinkButton><span>ת��
                            ��
                            <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                                runat="server">
                            ҳ</span>
                        <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                            font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                    </p>
                </div>
                <div class="clear">
                </div>
            </div>
            
            </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <!--���� -->
    </div>
</asp:Content>
