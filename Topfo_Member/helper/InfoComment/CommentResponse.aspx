<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
CodeFile="CommentResponse.aspx.cs" Inherits="helper_InfoComment_CommentResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
<link href="../../css/common.css" rel="stylesheet" type="text/css" />
    
<div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    ���Թ���</div>
                <div class="right">
                    <a href="http://www.topfo.com/web13/help/leaveword.shtml" class="chenglink">�����Ч�ع�������</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank20">
                </div>
            <div class="receivedbox">
                <div class="handtop">
                    <ul>
                        <li class="liwai">���յ�������</li><li><a href="CommentSend.aspx">�ҷ���������</a></li><li><a
                            href="CommentDelete.aspx">��������</a></li></ul>
                </div>
                <div class="con cshibiank">
                    <div class="search">

                        <div class="clear">
                        </div>
                    </div>
                    <!---->
                            <div>
                                <h1>
                                    <a href="#">
                                        <asp:Label runat="server" ID="commentName" ></asp:Label>
                                    </a>�� <a href="#">
                                        <asp:Label runat="server" ID="commentTile"></asp:Label>
                                    </a>������                                    
                                </h1>
                                <div class="mescon">                                  
                                    <div class="right" >
                                    <p>
                                        <asp:TextBox  ReadOnly="true" runat="server" ID="commentText" TextMode="MultiLine" Width="663px" Height="53px"></asp:TextBox>
                                    </p>    
                                        <br />
                                      <a>��Դ����ԵĻظ�</a>  
                                    </div>
                                    <div class="right">
                                        <asp:TextBox ID="commentRes" runat="server" Height="132px" Width="671px"></asp:TextBox></div>
                                    <div class="clear">
                                    </div>
                                </div>
                    <!---->
                </div>
                <div class="pagebox">
                    <div class="left">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
                         <asp:Button runat="server" ID="btnRes" CssClass="buttomal" Text="�ظ�" OnClick="btnRes_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                         <asp:Button runat="server" ID="btnBack" CssClass="buttomal" Text="����" OnClick="btnBack_Click" />            

                    </div>
                    <div class="right">
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="blank20">
            </div>
            <!--���� -->
            <div class="helpbox" runat="server" id="panelClue">
                <div class="con">
                    <h1>
                        <img src="../../images/icon_yb.gif" /><strong> ��Ҫ��ʾ</strong>
                    </h1>
                    <p>
                        1. �������ظ�ͨ��Ա��Ŀǰ������ʹ��<span class="hong">������</span>���ֻ��������ѷ���
                        <br />
                        2. �����յ����������û��������𣿾�ͳ�ƣ��ظ�ͨ��Ա�յ�����������ͨ��Ա��<span class="chengcu">12</span>����
                        <br />
                        <a href="/Register/VIPMemberRegister_In.aspx">���������ظ�ͨ��Ա����</a> <a href="/ContactUs.shtml">
                            ���߿ͷ�</a>
                    </p>
                </div>
            </div>
        </div>
        </div>
        
</asp:Content>

