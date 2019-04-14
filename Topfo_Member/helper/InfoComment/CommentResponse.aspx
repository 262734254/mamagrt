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
                    留言管理</div>
                <div class="right">
                    <a href="http://www.topfo.com/web13/help/leaveword.shtml" class="chenglink">如何有效地管理留言</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank20">
                </div>
            <div class="receivedbox">
                <div class="handtop">
                    <ul>
                        <li class="liwai">我收到的留言</li><li><a href="CommentSend.aspx">我发出的留言</a></li><li><a
                            href="CommentDelete.aspx">垃圾留言</a></li></ul>
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
                                    </a>对 <a href="#">
                                        <asp:Label runat="server" ID="commentTile"></asp:Label>
                                    </a>的留言                                    
                                </h1>
                                <div class="mescon">                                  
                                    <div class="right" >
                                    <p>
                                        <asp:TextBox  ReadOnly="true" runat="server" ID="commentText" TextMode="MultiLine" Width="663px" Height="53px"></asp:TextBox>
                                    </p>    
                                        <br />
                                      <a>你对此留言的回复</a>  
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
                         <asp:Button runat="server" ID="btnRes" CssClass="buttomal" Text="回复" OnClick="btnRes_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                         <asp:Button runat="server" ID="btnBack" CssClass="buttomal" Text="返回" OnClick="btnBack_Click" />            

                    </div>
                    <div class="right">
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="blank20">
            </div>
            <!--帮助 -->
            <div class="helpbox" runat="server" id="panelClue">
                <div class="con">
                    <h1>
                        <img src="../../images/icon_yb.gif" /><strong> 重要提示</strong>
                    </h1>
                    <p>
                        1. 您不是拓富通会员，目前还不能使用<span class="hong">新留言</span>的手机短信提醒服务。
                        <br />
                        2. 您想收到更多优质用户的留言吗？据统计，拓富通会员收到的留言是普通会员的<span class="chengcu">12</span>倍。
                        <br />
                        <a href="/Register/VIPMemberRegister_In.aspx">立即升级拓富通会员服务</a> <a href="/ContactUs.shtml">
                            在线客服</a>
                    </p>
                </div>
            </div>
        </div>
        </div>
        
</asp:Content>

