<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="�ҵĹ��ﳵ-�ظ�����-�й�����Ͷ����" AutoEventWireup="true" CodeFile="trade_other_list.aspx.cs"
    Inherits="PayManage_trade_other_list" %>

<%@ Register Src="../Controls/PayPageFoot.ascx" TagName="PayPageFoot" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/paymanage.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!--�ҵĹ��ﳵ -->
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                �������׹���
            </div>
            <div class="right">
                <a href="http://www.topfo.com/help/resourceswap.shtml" target="_blank" class="chenglink">
                    ������ȫ�̳�</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="suggestbox allxian">
            <h1>
                ��ܰ��ʾ��</h1>
            <p>
                ����Ϊ����ͨ�˶���֧�����������۽���С�Կ�����֧����
                <br />
                ��������˻������㣬ʹ���˻����֧�������ݵ�֧����ʽ�������ڵ��˻����Ϊ<asp:Literal ID="lblUserPoint" runat="server"></asp:Literal>Ԫ��
                ���&gt;&gt;<a href="account_cz.aspx">������ֵ</a><br />
                Ϊ�������Ľ��׷��գ�����������ѡ��<a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml"
                    target="_blank">�ظ�ͨ��Ա</a>��������Դ��<br />
            </p>
        </div>
        <div class="blank20">
        </div>
        <!--�ҵĹ��ﳵ -->
        <div class="mycartbox">
            <div class="handtop">
                <ul>
                    <li class="liwai">�Ѹ����</li><li><a href="trade_other_wait.aspx" style="text-decoration: none">
                        δ�����</a> </li>
                </ul>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <contenttemplate>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        ��Դ��ѯ��<select id="sDiff" runat="server" name="jumpMenu">
                            <option selected="selected" value="all">---ȫ��---</option>
                            <option value="90">����������</option>
                            <option value="60">���������</option>
                            <option value="30">���һ����</option>
                            <option value="7">���һ����</option>
                        </select>
                        <input id="btnSearch" type="button" value="��ѯ" onserverclick="btnSearch_ServerClick"
                            runat="server" /></div>
                    <div class="rights">
                        ÿҳ��ʾ��<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>��
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        �� <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        ��</div>
                    <div class="clear">
                    </div>
                </div>
                <table width="100%" align="center" cellspacing="0" class="taba">
                    <tr class="tabtitle">
                        <td width="12%" align="center" class="tabtitle">
                            ���</td>
                        <td width="25%" align="center" class="tabtitle">
                            �������Ʒ</td>
                        <td width="10%" align="center" class="tabtitle">
                            �۸�</td>
                        <td width="14%" align="center" class="tabtitle">
                            ����ʱ��</td>
                        <td width="27%" align="center" class="tabtitle">
                            ״̬</td>
                    </tr>
                    <asp:Repeater runat="server" ID="myList">
                        <ItemTemplate>
                            <tr>
                                <td width="12%" height="25" align="center">
                                    <%#GetType(Eval("buyType"))%>
                                </td>
                                <td width="25%" align="center">
                                    <%#GetTitle(Eval("ConsumeType"),Eval("Quantity"))%>
                                </td>
                                <td width="10%" align="center">
                                    <%#Eval("DicAmount", "{0:N}")%>
                                    Ԫ
                                </td>
                                <td width="14%" align="center">
                                    <%#Eval("PayDate")%>
                                </td>
                                <td width="26%" align="center">
                                    �Ѹ��� |<a href="trade_detail.aspx?order_no=<%#Eval("orderNo")%>&type=<%#Eval("buyType")%>">��ϸ</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tabb">
                                <td width="12%" height="25" align="center" class="tabb">
                                    <%#GetType(Eval("buyType"))%>
                                </td>
                                <td width="25%" align="center" class="tabb">
                                    <%#GetTitle(Eval("ConsumeType"),Eval("Quantity"))%>
                                </td>
                                <td width="10%" align="center" class="tabb">
                                    <%#Eval("DicAmount", "{0:N}")%>
                                    Ԫ
                                </td>
                                <td width="14%" align="center" class="tabb">
                                    <%#Eval("PayDate")%>
                                </td>
                                <td width="26%" align="center" class="tabb">
                                    �Ѹ��� |<a href="trade_detail.aspx?order_no=<%#Eval("orderNo")%>&type=<%#Eval("buyType")%>">��ϸ</a>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
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
                        font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" /></p>
            </div>
            </contenttemplate>
            </asp:UpdatePanel>
        </div>
        <div class="blank20">
        </div>
        <!--���� -->
        <div class="helpbox">
            <div class="titleh">
                <img src="../images/PayManage/biao_print.gif" />
                <a href="javascript:;" onclick="windows.print()">��ӡ��ҳ</a></div>
            <div class="con">
                <h1>
                    <img src="../images/icon_yb.gif" align="absmiddle" />
                    ����</h1>
                <p>
                    ���"��ϸ"���Բ鿴��������ϸ�����
                    <br />
                    <uc1:PayPageFoot ID="PayPageFoot1" runat="server" />
                </p>
            </div>
        </div>
        <div class="blank20">
        </div>
    </div>
</asp:Content>
