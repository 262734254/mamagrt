<%@ Page Language="C#"   MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    AutoEventWireup="true" CodeFile="FriendAdd.aspx.cs" Inherits="helper_FriendManager_FriendAdd" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
      <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />

        <div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    �ҵĺ���</div>
                <div class="right">
                    <img src="../../images/AccountInfo/handbiao.gif" width="16" height="10" />
                    <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">������/�������</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li class="liwai"><a href="FriendSearch.aspx">��Ӻ���</a></li><li><a href="FriendList.aspx">
                        �����б�</a></li><li><a href="FriendAttention.aspx">��ע�ҵ��û�</a></li><li><a href="FriendBlacklist.aspx">
                            ������</a></li><li><a href="FriendConfig.aspx">��ɧ������</a></li></ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        ����������Ϊ���ҵ��Ļ�Ա</div>
                    <div class="rights">
                        ÿҳ��ʾ��<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>��
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        �� <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        ��</div>
                    <div class="clear">
                    </div>
                </div>
                <div class="topaddzi">
                    <span class="hong">�ظ�ͨ��Ա������ͨ��Ա��ǰ��</span> <a href="#">�����ظ�ͨ��Ա������Щ��Ȩ</a></div>
                <div id="ListDiv">
                    <asp:GridView ID="friendAddGridView" runat="server" AutoGenerateColumns="False" Width="742px"
                        DataKeyNames="loginName" OnRowDataBound="friendAddGridView_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="��������">
                                <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center"/>
                                <ItemTemplate>
                                 <a href="<%#viewLink(Eval("LoginName"))%>" target="_blank"><%#view(Eval("LoginName"))%></a>
                                <asp:Image runat="server" ID="imgTopfo" Visible="false" ImageUrl="../../images/tfzs.gif" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="��Ա����" ConvertEmptyStringToNull="False">
                                <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="����">
                                <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center"  />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="���Ժδ�">
                                <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center"  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="����ѽ���">
                                <HeaderStyle CssClass="tabtitle" Height="20px" Wrap="False" HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <asp:Button ID="btnAddFriend" runat="server" BackColor="White" BorderStyle="None"
                                        CssClass="lanlink" Font-Overline="False" Font-Underline="True" ForeColor="RoyalBlue"
                                        Height="17px" Text="��Ϊ����" Width="51px" OnClick="btnAddFriend_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="150px" Wrap="False" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="pagebox">
                <div class="left">
                    <img alt="" src="../../images/MessageManage/biao_01.gif" width="14" height="16" />
                    <asp:Button ID="ButtonInfoDelete" runat="server" CssClass="buttomal" Text="��һ��" EnableViewState="False" OnClick="ButtonInfoDelete_Click" />
                    <asp:Button ID="ButtonOutExcel" CssClass="buttomal" runat="server" Text="�ر�" OnClick="ButtonOutExcel_Click" />
                </div>
                <div class="right">
                    ��<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>�� ҳ�Σ�<asp:Literal
                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                            runat="server" Text="0"></asp:Literal>ҳ
                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">��ҳ</asp:LinkButton>
                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">��һҳ</asp:LinkButton>
                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">��һҳ</asp:LinkButton>
                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">βҳ</asp:LinkButton><span>
                        <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                            runat="server">
                    </span>
                    <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                        font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                </div>
            </div>
            <div class="blank20">
            </div>
            <div class="helpbox" runat="server" id="divhelp">
                <div class="con">
                    <h1>
                        <img src="../../images/icon_yb.gif" width="17" height="17" align="absbottom" />
                        ��Ҫ��ʾ</h1>
                    <p>
                        ��ͨ�û����������100λ�û�Ϊ���ѣ��ظ�ͨ��Ա�����ơ�<a href="http://www.topfo.com/web13/help/TopfoServer.shtml#a5"
                            target="_blank">�˽��ظ�ͨ������Ȩ</a> 0755-89805558 </p>
                </div>
            </div>
        </div>
        
</asp:Content>
