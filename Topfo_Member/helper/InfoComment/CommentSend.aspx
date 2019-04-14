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
       //����ͷģ���е��������е�CheckBoxȡ��
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
                ���Թ���</div>
            <div class="right" style="margin-bottom:13px;">
             <img src="http://member.topfo.com/images/hand_1_2.gif" /> <a  href="http://www.topfo.com/help/leaveword.shtml" target="_blank">�����Ч�ع�������</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank20"></div>
        <div class="receivedbox">
            <div class="handtop">
                <ul>
                    <li><a href="commentReceive.aspx">���յ�������</a></li>
                    <li class="liwai">�ҷ���������</li>
                    <li><a href="CommentDelete.aspx">��������</a></li>
                </ul>
            </div>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        <asp:DropDownList runat="server" ID="ddlCommentType">
                            <asp:ListItem Text="�Ƿ�ظ�" Value="0"></asp:ListItem>
                            <asp:ListItem Value="1">�ѻظ�</asp:ListItem>
                            <asp:ListItem Value="2">δ�ظ�</asp:ListItem>
                        </asp:DropDownList>&nbsp;
                        <asp:DropDownList runat="server" ID="ddlCommentTime" EnableViewState="False">
                            <asp:ListItem Value="3">������</asp:ListItem>
                            <asp:ListItem Value="7">������</asp:ListItem>
                            <asp:ListItem Value="30">һ������</asp:ListItem>
                            <asp:ListItem Value="90" Selected="True">��������</asp:ListItem>
                            <asp:ListItem Value="91" >����������</asp:ListItem>
                        </asp:DropDownList>
                        <label>
                        </label>
                        <strong>
                            <asp:TextBox runat="server" ID="txtCommentSelect" Text="����ؼ���" EnableViewState="False"></asp:TextBox>
                        </strong>
                        <asp:Button runat="server" ID="btnCommentSelect" Text="��ѯ" OnClick="btnCommentSelect_Click" />
                    </div>
                    <div class="rights">
                    ÿҳ��ʾ��<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>��
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        �� <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        ��</div>
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
                                    </a>�� <a href="#">
                                        <%#Eval("title") %>
                                    </a>������
                                   
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
                                    </a>�� <a href="#">
                                        <%#Eval("title") %>
                                    </a>������
                                   
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
                            <a href="javascript:;" onclick="SelectAll()">ȫѡ</a>/<a href="javascript:;" onclick="SelectAll()">��ѡ</a>                        
                            <asp:Button ID="btnOut" runat="server" Text="����" OnClick="btnOut_Click" /></div>
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
                        <div class="clear">
                        </div>
          </div>
        </div>
    </div>
    
</asp:Content>
