<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
CodeFile="commentReceive.aspx.cs" Inherits="helper_InfoComment_commentReceive" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
  <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />

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
		    function goRecycle()
		{	
			 
			var a = document.getElementsByTagName("input");
			var str="";
			for (var i=0; i<a.length; i++) 
			{
				if (a[i].type == "checkbox" && a[i].id!="chkSendMessage")
				{
					if(a[i].checked)
					{
						str+=a[i].value+",";
					}
				}
			}
			if(str!="")
			{
				if(confirm("ȷ��������?�����ָܻ�"))
				{
					helper_InfoComment_commentReceive.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("��ѡѡ����Ҫɾ������");
			}
		}

		
		function goPublic()
		{	
			 
			var a = document.getElementsByTagName("input");
			var str="";
			for (var i=0; i<a.length; i++) 
			{
				if (a[i].type == "checkbox")
				{
					if(a[i].checked)
					{
						str+=a[i].value+",";
					}
				}
			}
			if(str!="")
			{
				if(confirm("ȷ������������"))
				{
					helper_InfoComment_commentReceive.ToPublic(str,backres);
				}
			}
			else
			{
				alert("��ѡ�񹫿�����");
			}
		}
		function backres(res)
		{
		    if(res.value=="ok")
		    {
		        window.location.reload();
		    }
		    
		    else
		    {
		        alert("ʧ��!");
		    }
		}

        		
    </script>


  <link href="../../css/common.css" rel="stylesheet" type="text/css" />
        <div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    ���Թ���</div>
                <div class="right">
                    <a href="http://www.topfo.com/help/leaveword.shtml" class="chenglink" target="_blank">�����Ч�ع�������</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="suggestbox lightc allxian">
                <h1>
                    <img src="/images/icon_tishi.gif" align="absmiddle" /> ��ܰ��ʾ��</h1>
                <p style=" text-indent:25px;">
                    ��������Ĭ�ϲ���ҳ������ʾ�����������ʾ�������Ի����еĲ������ԣ���ѡ����Ҫ���������ԣ�������������ԡ����ɡ� Ϊ�˱�֤���Բ�������������ҵ��������Ӱ�죬<span
                        class="hong">������ϸ����������ݺ���ѡ���Ƿ񹫿�</span>��
                    <br />
                </p>
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
                        <div class="lefts">
                            <asp:DropDownList runat="server" ID="ddlCommentType">
                                <asp:ListItem Text="������" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">���Ķ�</asp:ListItem>
                                <asp:ListItem Value="2">�ѻظ�</asp:ListItem>
                                <asp:ListItem Value="3">�ѹ���</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlCommentFrom">
                                <asp:ListItem Text="����" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">�ظ�ͨ��Ա</asp:ListItem>
                                <asp:ListItem Value="��">��ͨ��Ա</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlCommentTime" EnableViewState="False">
                                <asp:ListItem Value="3" >������</asp:ListItem>
                                <asp:ListItem Value="7">������</asp:ListItem>
                                <asp:ListItem Value="30">һ������</asp:ListItem>
                                <asp:ListItem Value="90" Selected="True">��������</asp:ListItem>
                                <asp:ListItem Value="91">����������</asp:ListItem>
                            </asp:DropDownList>
                            <label>
                            </label>
                            <strong>
                                <asp:TextBox runat="server" ID="txtCommentSelect" EnableViewState="False"></asp:TextBox>
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
                    <!---->
                    <asp:Repeater ID="rptCommentReceive" runat="server" OnItemDataBound="rptCommentReceive_ItemDataBound">
                        <ItemTemplate>
                            <div>
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>�� <a href="#">
                                        <%#Eval("title") %>
                                    </a>������
                                    <ul style="display: none">
                                        ������������ | ��ϵ�绰��0755-89805589 | E-mail��lxfei@tz888.cn | 2007-7-25 17:18
                                    </ul>
                                </h1>
                                <div class="mescon">
                                    <input type="checkbox" name="checkbox3" id="checkbox2"  runat="server" value='<%#Eval("Id")%>' />
                                    <div class="right" >
                                        <%#Eval("CommentContent") %>
                                        <br />
                                        <div runat="server" id="divResView" class="cshibiank lightc mesreply"  >
                                         &nbsp&nbsp&nbsp �� �� �����ԵĻظ���
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label>   
                                        </div>
                                        <p>
                                         <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnRes" OnClick="brnRes_Click" >�ظ�</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("loginName")%>' runat="server" ID="btnFriend" OnClick="brnFriend_Click" >��Ϊ����</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnPublic" OnClick="brnPublic_Click"  Text='<%#status(Eval("IsAudit"))%>'></asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnDelete" OnClick="brnDelete_Click" >ɾ��</asp:LinkButton>
                                        </p>
                                        <div runat="server" id="divRes" style="display:none"></div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                       <%-- <AlternatingItemTemplate>
                            <div class="color">
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>�� <a href="#">
                                        <%#Eval("title") %>
                                    </a>������
                                    <ul style="display: none">
                                        ������������ | ��ϵ�绰��0755-89805589 | E-mail��lxfei@tz888.cn | 2007-7-25 17:18
                                    </ul>
                                </h1>
                                <div class="mescon">
                                    <input type="checkbox" name="checkbox3" id="checkbox2"  runat="server" value='<%#Eval("Id")%>' />
                                    <div class="right">
                                        <%#Eval("CommentContent") %>
                                        <br />
                                        <div runat="server" id="divResView" class="cshibiank lightc mesreply">
                                        &nbsp&nbsp&nbsp �� �� �����ԵĻظ���
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label>
                                        </div>
                                        <p>
                                         <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnRes" OnClick="brnRes_Click" >�ظ�</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("loginName")%>' runat="server" ID="btnFriend" OnClick="brnFriend_Click" >��Ϊ����</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnPublic" OnClick="brnPublic_Click"  Text='<%#status(Eval("IsAudit"))%>'></asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnDelete" OnClick="brnDelete_Click" >ɾ��</asp:LinkButton>
                                            </p>
                                            <div runat="server" id="divRes" style="display:none"></div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </AlternatingItemTemplate>--%>
                    </asp:Repeater>
                    <!---->
                    <span style="padding-left:15px"><asp:Label ID="lbMessage" runat="server" Text="Label" ForeColor="red"></asp:Label></span><br/>
                </div>
                <div class="pagebox">
                    <div class="left">
                        <img src="../../images/MessageManage/biao_01.gif" width="14" height="16" align="absbottom" />
                        <a href="javascript:;" onclick="SelectAll()">ȫѡ</a>/<a href="javascript:;" onclick="SelectAll()">��ѡ</a>
                        <input name="button2" type="button" class="buttomal" id="button2" value="ɾ��" onclick="goRecycle()" />
                        <input name="button2" type="button" class="buttomal" id="button1" value="��������" onclick="goPublic()" />
                        <asp:Button ID="btnOut" runat="server" Text="����"  CssClass="buttomal" OnClick="btnOut_Click" /></div>
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
                    <div class="xia">
                        <asp:HyperLink runat="server" ID="hplViewTelNumber" NavigateUrl="/helper/Notice.aspx"
                            Text="��������֪ͨ"></asp:HyperLink></div>
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
                        <img src="../../images/icon_yb.gif" align="absmiddle" /><strong> ��Ҫ��ʾ</strong>                    </h1>
                    <p>
                        1. �������ظ�ͨ��Ա��Ŀǰ������ʹ��<span class="hong">������</span>���ֻ��������ѷ���
                        <br />
                        2. �����յ����������û��������𣿾�ͳ�ƣ��ظ�ͨ��Ա�յ�����������ͨ��Ա��<span class="chengcu">12</span>����
                        <br />
                        <a href="/Register/VIPMemberRegister_In.aspx">���������ظ�ͨ��Ա����</a> 
                    </p>
                </div>
            </div>
        </div>
        
</asp:Content>
