<%@ Page Language="C#" AutoEventWireup="true"   MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
     CodeFile="commentSend.aspx.cs" Inherits="helper_InfoComment_CommentSend"  EnableEventValidation="false" %>
     
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
  <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
<link href="../../css/common.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
   function SelectAll()
   {
       //将除头模板中的其它所有的CheckBox取反
			var a = document.getElementsByTagName("input"); 
			for (var i=0; i<a.length; i++)
			{
				if (a[i].type=="checkbox" && a[i].id!="chkSendMessage") 
				a[i].checked =!a[i].checked;
			}    
	}		
    </script>



    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                留言管理</div>
            <div class="right" style="margin-bottom:13px;">
             <img src="http://member.topfo.com/images/hand_1_2.gif" /> <a  href="http://www.topfo.com/help/leaveword.shtml" target="_blank">如何有效地管理留言</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank20"></div>
        <div class="receivedbox">
            <div class="handtop">
                <ul>
                    <li><a href="commentReceive.aspx">我收到的留言</a></li>
                    <li class="liwai">我发出的留言</li>
                    <li><a href="CommentDelete.aspx">垃圾留言</a></li>
                </ul>
            </div>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        <asp:DropDownList runat="server" ID="ddlCommentType">
                            <asp:ListItem Text="是否回复" Value="0"></asp:ListItem>
                            <asp:ListItem Value="1">已回复</asp:ListItem>
                            <asp:ListItem Value="2">未回复</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                        <asp:DropDownList runat="server" ID="ddlCommentTime" EnableViewState="False">
                            <asp:ListItem Value="3">三天内</asp:ListItem>
                            <asp:ListItem Value="7">七天内</asp:ListItem>
                            <asp:ListItem Value="30">一个月内</asp:ListItem>
                            <asp:ListItem Value="90" Selected="True">三个月内</asp:ListItem>
                            <asp:ListItem Value="91" >三个月以上</asp:ListItem>
                        </asp:DropDownList>
                        <label>
                        </label>
                        <strong>
                            <asp:TextBox runat="server" ID="txtCommentSelect" Text="输入关键字" EnableViewState="False"></asp:TextBox>
                        </strong>
                        <asp:Button runat="server" ID="btnCommentSelect" Text="查询" OnClick="btnCommentSelect_Click" />
                    </div>
                    <div class="rights">
                    每页显示：<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>条
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        条 <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        条</div>
                    <div class="clear">
                    </div>
                </div>
                <div id="ListDiv">
                    <asp:Repeater ID="rptCommentSend" runat="server">
                        <ItemTemplate>
                            <div>
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>对 <a href="#">
                                        <%#Eval("title") %>
                                    </a>的留言
                                   
                                </h1>
                                <div class="mescon">
                                    <asp:CheckBox runat="server" ID="chkCommentSelect" />
                                    <div class="right">
                                        <%#Eval("CommentContent") %>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <div class="color">
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>对 <a href="#">
                                        <%#Eval("title") %>
                                    </a>的留言
                                   
                                </h1>
                                <div class="mescon">
                                    <asp:CheckBox runat="server" ID="chkCommentSelect" />
                                    <div class="right">
                                        <%#Eval("CommentContent") %>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                    
                </div>
            </div>
			<div class="pagebox">
                        <div class="left">
                            <img src="../../images/MessageManage/biao_01.gif" width="14" height="16" align="absbottom" />
                            <a href="javascript:;" onclick="SelectAll()">全选</a>/<a href="javascript:;" onclick="SelectAll()">反选</a>                        
                            <asp:Button ID="btnOut" runat="server" Text="导出" OnClick="btnOut_Click" /></div>
                        <div class="right">
                        共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                            runat="server" Text="0"></asp:Literal>页
                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>
                        <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                            runat="server">
                    </span>
                    <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                        font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                       
                        </div>
                        <div class="clear">
                        </div>
          </div>
        </div>
    </div>
    
</asp:Content>
