<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentForeList.aspx.cs"
    Inherits="helper_InfoComment_CommentForeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>����</title>
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../../css/messagellist/stylemess.css" rel="stylesheet" type="text/css" />
    <link href="../../css/messagellist/colorp.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function ReplyDdShow(obj)
    {
        var str="txt"+obj;
        str1="btnOK"+obj;
        str2="btnCancel"+obj;
        var temp=document.getElementById(str);
        temp1=document.getElementById(str1);
        temp2=document.getElementById(str2);
        temp.style.display="block";
        temp1.style.display="";
        temp2.style.display="";
    }
    function ReplyDdCancel(obj)
    {
        var str="txt"+obj;
        str1="btnOK"+obj;
        str2="btnCancel"+obj;
        var temp=document.getElementById(str);
        temp1=document.getElementById(str1);
        temp2=document.getElementById(str2);
        temp.value="����������";
        temp.style.display="none";
        temp1.style.display="none";
        temp2.style.display="none";
    }
    
    	function goReply(obj)
		{	
			 var a="txt"+obj;
			var temp=document.getElementById(a);
			var str=temp.value;
            
			if(str!="")
			{
				if(confirm("ȷ���ظ���"))
				{
				    var strtmp=obj+"^";
				    strtmp=strtmp+str;
					helper_InfoComment_CommentForeList.ToReply(strtmp,backres);
					
				}
			}
			else
			{
				alert("������ظ����ݣ�");
			}
		}
		
		function backres(res)
		{
		    if(res.value=="ok")
		    {
		        window.location.reload();
		    }
		    
		    else if(res.value=="login")
		    {
		        alert("���¼�����ûظ���")
		    }
		    else
		    {
		        alert("ʧ��!");
		    }
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="../../Common/channeltop.html" -->
        <div class="messwarp">
            <div class="tophr xiancolor">
            </div>
            <div class="mestitel">
                <asp:Label ID="lbInfoTitle" runat="server" Width="928px"></asp:Label><br />
            </div>
            <div class="mestopbox">
                <div class="left">
                    <span class="font14"><strong>ȫ������</strong></span>��<asp:Label ID="lbCount" runat="server"
                        Height="15px" Text="Label" Width="24px"></asp:Label>����</div>
                <div class="right cheng">
                    ( ����ֻ�������Ѹ��˹۵� ������������ )</div>
                <div class="clear">
                </div>
            </div>
            <!--�������� -->
            <div class="meslistbox xiancolor" runat="server" id="divcontentMain">
                <asp:Repeater ID="rptCommentForeList" runat="server" OnItemDataBound="rptCommentForeList_ItemDataBound">
                    <ItemTemplate>
                        <dl class="xiancolor">
                            <dt class="titlec"><span><a href="#">
                                <%#Eval("LoginName") %></span></a>�� <a href="#">
                                    <%#Eval("title") %>
                                </a>������ <span class="data"><a>
                                    <%#Eval("CommentTime")%>
                                </a></span></dt>
                            <dd >
                                <%#Eval("CommentContent") %>
                                <br />
                                <dd class="res" style=" display:<%#view(Eval("id"))?"block":"none"%>">
                                    <div runat="server"  >
                                        &nbsp&nbsp&nbsp
                                        ��Ŀ������&nbsp
                                        �� �����ԵĻظ���
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label></div>
                                </dd>
                                
                            </dd>
                            <dd >
                                <textarea name="textarea4" id="txt<%#Eval("Id")%>" cols="110" rows="10" style=" display:none" ></textarea>
                                <b>
                                    
                                    <input type="button" name="btnOK<%#Eval("Id")%>" id="btnOK<%#Eval("Id")%>" value="ȷ ��"  runat="server" style=" display:none" onclick="goReply(<%#Eval("Id")%>);"/>
                                    <input type="button" name="btnCancel<%#Eval("Id")%>" id="btnCancel<%#Eval("Id")%>" value="ȡ ��" onclick="ReplyDdCancel(<%#Eval("Id")%>);" style=" display:none" />
                                </b>
                            </dd>
                            <dd class="textr">
                                
                                <div id="aReply" runat="server"><a onclick="ReplyDdShow(<%#Eval("Id")%>);"  href="#">���ûظ�>></a></div></dd>
                        </dl>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <dl class="xiancolor">
                            <dt class="titlec"><a href="#">
                                <%#Eval("LoginName") %>
                            </a>�� <a href="#">
                                <%#Eval("title") %>
                            </a>������ <a href="#">
                                <%#Eval("CommentTime")%>
                            </a></dt>
                            <dd>
                                <%#Eval("CommentContent") %>
                                <br />
                                <dd class="res" style=" display:<%#view(Eval("id"))?"block":"none"%>" >
                                    <div runat="server" >
                                        &nbsp&nbsp&nbsp ��Ŀ������&nbsp �� �����ԵĻظ���
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label>
                                    </div>
                                </dd>
                                <dd runat="server" >
                                <textarea name="textarea4" cols="110" rows="10" id="txt<%#Eval("Id")%>" style=" display:none">����������</textarea>
                                <b>
                                    <input type="button" name="btnOK<%#Eval("Id")%>" id="btnOK<%#Eval("Id")%>" value="ȷ ��"  runat="server" style=" display:none"/>
                                    <input type="button" name="btnCancel<%#Eval("Id")%>" id="btnCancel<%#Eval("Id")%>" onclick="ReplyDdCancel(<%#Eval("Id")%>);" value="ȡ ��" style=" display:none" />
                                </b>
                            </dd>
                                <dd class="textr">                                    
                                    <div id="aReply" runat="server"><a onclick="ReplyDdShow(<%#Eval("Id")%>);"  href="#">���ûظ�>></a></div></dd>
                            </dd>
                        </dl>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </div>
            <div class="mespage" runat="server" id="divmessageMain">
                ��<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>�� ҳ�Σ�<asp:Literal
                    ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                        runat="server" Text="0"></asp:Literal>ҳ
                <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">��ҳ</asp:LinkButton>
                <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">��һҳ</asp:LinkButton>
                <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">��һҳ</asp:LinkButton>
                <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">βҳ</asp:LinkButton><span>
                    <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                        runat="server" />
                </span>
                <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                    font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
            </div>
            <div class="blank0">
            </div>
            <!--���Կ� -->
             <div class="messagesbox">
                        <h1 runat="server" id="h1">
                            </h1>
                        <p>
                            ����Ŀ������ <span class="orange01"><asp:Label runat="server" ID="lbInfoOwner"></asp:Label></span> ����</p>
							    <div class="mbluek"  runat="server" id="divLogin">�Ƽ��� <a href="http://member.topfo.com/Login.aspx" target="_blank">��½</a> �����򷢲������ԣ��û����Բ鿴���ĸ�����Ϣ�����������Ρ�<i></i> <a href="http://member.topfo.com/Register/Register.aspx" target="_blank">���ע��&gt;&gt;</a></div>
                        <p class="padtb">
                            ������
                            <asp:TextBox runat="server" ID="txtName" Width="150px"></asp:TextBox>
                            <i></i>�绰��
                            <asp:TextBox runat="server" ID="txtTel" Width="150px"></asp:TextBox>
                            <i></i>E-mail��
                            <asp:TextBox runat="server" ID="txtEmail" Width="150"></asp:TextBox>
                        </p>
                        <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Wrap="true" Width="630px" Columns="110" Rows="10"></asp:TextBox>&nbsp;
                        <p class="padtb">
                            
                            <asp:Button runat="server" ID="btnOk" Text="�� ��" OnClick="btnOk_Click" />
                            <label>
                               
                                <asp:Button runat="server" ID="btnCancel" Text="�� ��" OnClick="btnCancel_Click" />
                            </label>
                        </p>
      </div>
            
        </div>
        <!--#include file="../../Common/allfooter.html" -->
    </form>
</body>
</html>
