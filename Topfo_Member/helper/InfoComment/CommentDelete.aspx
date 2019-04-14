<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="CommentDelete.aspx.cs" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Inherits="helper_InfoComment_CommentDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
  <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
<link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
   function SelectAll()
   {
       
			var a = document.getElementsByTagName("input"); 
			for (var i=0; i<a.length; i++)
			{
				if (a[i].type=="checkbox" && a[i].id!="chkSendMessage") 
				a[i].checked =!a[i].checked;
			}    
	}
	 function chkValue(flag)
	{
	    var a = document.documentElement.getElementsByTagName("input");
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
		      if(flag=="del")
		      {
		          if(confirm("�Ƿ�ɾ��?"))
	              {
		            deleteAllchk(str);
		          }
		      }
		      if(flag=="move")
		      {
		          if(confirm("ȷ��ת����?"))
	              {       
		             movechk(str);
		          }
		      }
		}
		else
		{
		   alert("��ѡ����");
		}
	}
	function deleteAllchk(str)
	{
	    helper_InfoComment_CommentDelete.deleteAll(str,backres);
	}		
	function movechk(str)
	{
	    helper_InfoComment_CommentDelete.moveMsg(str,backres);
	}
	function backres(res)
	{   
	    if(res.value=="ok")
	    {
	        window.location.reload();
	    }
	    else
	    {
	       alert("����ʧ��!"); 
	    }
	}
    </script>


    
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                ���Թ���</div>
            <div class="right" style="margin-bottom:13px;">
             <img src="http://member.topfo.com/images/hand_1_2.gif" /> <a href="http://www.topfo.com/help/leaveword.shtml" target="_blank" >�����Ч�ع�������</a></div>
            <div class="clear">
            </div>
        </div>
        <!--�ҵĹ��ﳵ -->
        <div class="receivedbox">
            <div class="handtop">
                <ul>
                    <li><a href="commentReceive.aspx">���յ�������</a></li>
                    <li><a href="CommentSend.aspx">�ҷ���������</a></li>
                    <li class="liwai">��������</li>
                </ul>
            </div>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        ����<span class="hong"><asp:Label runat="server" ID="lbCommentNum" Text=""></asp:Label></span>���������ԣ�
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
                    <asp:Repeater ID="rptCommentDelete" runat="server" OnItemDataBound="rptCommentDelete_ItemDataBound">
                        <ItemTemplate>
                            <div>
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>�� <a href="#">
                                        <%#Eval("title") %>
                                    </a>������
                                    <ul>
                                        ������������ | ��ϵ�绰��0755-89805589 | E-mail��lxfei@tz888.cn | 2007-7-25 17:18
                                    </ul>
                                </h1>
                                <div class="mescon">
                                    <input type="checkbox" name="checkbox" value='<%#Eval("ID") %>' />
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
                                    <ul>
                                        ������������ | ��ϵ�绰��0755-89805589 | E-mail��lxfei@tz888.cn | 2007-7-25 17:18
                                    </ul>
                                </h1>
                                <div class="mescon">
                                    <input type="checkbox" name="checkbox" value='<%#Eval("ID") %>' />
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
                <div class="clear">
                </div>
            </div>
			<div class="pagebox">
                        <div class="left">
                            <img src="../../images/MessageManage/biao_01.gif" align="absbottom"  />
                            <a href="javascript:;" onclick="SelectAll()">ȫѡ</a>/<a href="javascript:;" onclick="SelectAll()">��ѡ</a>
                            <input id="Button1" type="button" value="����ɾ��" class="buttomal" onclick="chkValue('del')" />
                            <input id="Button2" type="button" value="ת�Ƶ����յ�������" class="buttomal" onclick="chkValue('move')" style="width:120px" />
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
          
        </div>
        <div class="blank20">
        </div>
        <!--���� -->
        <div class="helpbox">
            <div class="con">
                <h1>
                    <img src="../../images/icon_yb.gif" align="absmiddle" /><strong> ��Ҫ��ʾ</strong></h1>
                <p>
                    ���붨ʱ�������յ����������ԣ�ÿ���������������1���£�1���º�����ɾ����
                    <br />
                    ���������Բ��ܽ��лظ����������������Խ��лظ����뽫����������ת�����յ������ԡ��У��������Ϳ��ԶԴ����Խ��лظ���
                </p>
            </div>
        </div>
    </div>
</asp:Content>
