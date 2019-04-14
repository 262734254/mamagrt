<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentForeList.aspx.cs"
    Inherits="helper_InfoComment_CommentForeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>留言</title>
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
        temp.value="请输入内容";
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
				if(confirm("确定回复？"))
				{
				    var strtmp=obj+"^";
				    strtmp=strtmp+str;
					helper_InfoComment_CommentForeList.ToReply(strtmp,backres);
					
				}
			}
			else
			{
				alert("请输入回复内容！");
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
		        alert("请登录后引用回复！")
		    }
		    else
		    {
		        alert("失败!");
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
                    <span class="font14"><strong>全部评论</strong></span>（<asp:Label ID="lbCount" runat="server"
                        Height="15px" Text="Label" Width="24px"></asp:Label>条）</div>
                <div class="right cheng">
                    ( 评论只代表网友个人观点 不代表本网立场 )</div>
                <div class="clear">
                </div>
            </div>
            <!--留言内容 -->
            <div class="meslistbox xiancolor" runat="server" id="divcontentMain">
                <asp:Repeater ID="rptCommentForeList" runat="server" OnItemDataBound="rptCommentForeList_ItemDataBound">
                    <ItemTemplate>
                        <dl class="xiancolor">
                            <dt class="titlec"><span><a href="#">
                                <%#Eval("LoginName") %></span></a>对 <a href="#">
                                    <%#Eval("title") %>
                                </a>的留言 <span class="data"><a>
                                    <%#Eval("CommentTime")%>
                                </a></span></dt>
                            <dd >
                                <%#Eval("CommentContent") %>
                                <br />
                                <dd class="res" style=" display:<%#view(Eval("id"))?"block":"none"%>">
                                    <div runat="server"  >
                                        &nbsp&nbsp&nbsp
                                        项目发布者&nbsp
                                        对 此留言的回复：
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label></div>
                                </dd>
                                
                            </dd>
                            <dd >
                                <textarea name="textarea4" id="txt<%#Eval("Id")%>" cols="110" rows="10" style=" display:none" ></textarea>
                                <b>
                                    
                                    <input type="button" name="btnOK<%#Eval("Id")%>" id="btnOK<%#Eval("Id")%>" value="确 定"  runat="server" style=" display:none" onclick="goReply(<%#Eval("Id")%>);"/>
                                    <input type="button" name="btnCancel<%#Eval("Id")%>" id="btnCancel<%#Eval("Id")%>" value="取 消" onclick="ReplyDdCancel(<%#Eval("Id")%>);" style=" display:none" />
                                </b>
                            </dd>
                            <dd class="textr">
                                
                                <div id="aReply" runat="server"><a onclick="ReplyDdShow(<%#Eval("Id")%>);"  href="#">引用回复>></a></div></dd>
                        </dl>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <dl class="xiancolor">
                            <dt class="titlec"><a href="#">
                                <%#Eval("LoginName") %>
                            </a>对 <a href="#">
                                <%#Eval("title") %>
                            </a>的留言 <a href="#">
                                <%#Eval("CommentTime")%>
                            </a></dt>
                            <dd>
                                <%#Eval("CommentContent") %>
                                <br />
                                <dd class="res" style=" display:<%#view(Eval("id"))?"block":"none"%>" >
                                    <div runat="server" >
                                        &nbsp&nbsp&nbsp 项目发布者&nbsp 对 此留言的回复：
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label>
                                    </div>
                                </dd>
                                <dd runat="server" >
                                <textarea name="textarea4" cols="110" rows="10" id="txt<%#Eval("Id")%>" style=" display:none">请输入内容</textarea>
                                <b>
                                    <input type="button" name="btnOK<%#Eval("Id")%>" id="btnOK<%#Eval("Id")%>" value="确 定"  runat="server" style=" display:none"/>
                                    <input type="button" name="btnCancel<%#Eval("Id")%>" id="btnCancel<%#Eval("Id")%>" onclick="ReplyDdCancel(<%#Eval("Id")%>);" value="取 消" style=" display:none" />
                                </b>
                            </dd>
                                <dd class="textr">                                    
                                    <div id="aReply" runat="server"><a onclick="ReplyDdShow(<%#Eval("Id")%>);"  href="#">引用回复>></a></div></dd>
                            </dd>
                        </dl>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </div>
            <div class="mespage" runat="server" id="divmessageMain">
                共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                    ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                        runat="server" Text="0"></asp:Literal>页
                <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>
                    <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                        runat="server" />
                </span>
                <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                    font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
            </div>
            <div class="blank0">
            </div>
            <!--留言框 -->
             <div class="messagesbox">
                        <h1 runat="server" id="h1">
                            </h1>
                        <p>
                            给项目发布者 <span class="orange01"><asp:Label runat="server" ID="lbInfoOwner"></asp:Label></span> 留言</p>
							    <div class="mbluek"  runat="server" id="divLogin">推荐您 <a href="http://member.topfo.com/Login.aspx" target="_blank">登陆</a> 后再向发布者留言，用户可以查看您的更多信息，对您更信任。<i></i> <a href="http://member.topfo.com/Register/Register.aspx" target="_blank">免费注册&gt;&gt;</a></div>
                        <p class="padtb">
                            姓名：
                            <asp:TextBox runat="server" ID="txtName" Width="150px"></asp:TextBox>
                            <i></i>电话：
                            <asp:TextBox runat="server" ID="txtTel" Width="150px"></asp:TextBox>
                            <i></i>E-mail：
                            <asp:TextBox runat="server" ID="txtEmail" Width="150"></asp:TextBox>
                        </p>
                        <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Wrap="true" Width="630px" Columns="110" Rows="10"></asp:TextBox>&nbsp;
                        <p class="padtb">
                            
                            <asp:Button runat="server" ID="btnOk" Text="提 交" OnClick="btnOk_Click" />
                            <label>
                               
                                <asp:Button runat="server" ID="btnCancel" Text="重 置" OnClick="btnCancel_Click" />
                            </label>
                        </p>
      </div>
            
        </div>
        <!--#include file="../../Common/allfooter.html" -->
    </form>
</body>
</html>
