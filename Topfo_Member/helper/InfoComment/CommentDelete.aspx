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
		          if(confirm("是否删除?"))
	              {
		            deleteAllchk(str);
		          }
		      }
		      if(flag=="move")
		      {
		          if(confirm("确定转移吗?"))
	              {       
		             movechk(str);
		          }
		      }
		}
		else
		{
		   alert("请选择项");
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
	       alert("操作失败!"); 
	    }
	}
    </script>


    
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                留言管理</div>
            <div class="right" style="margin-bottom:13px;">
             <img src="http://member.topfo.com/images/hand_1_2.gif" /> <a href="http://www.topfo.com/help/leaveword.shtml" target="_blank" >如何有效地管理留言</a></div>
            <div class="clear">
            </div>
        </div>
        <!--我的购物车 -->
        <div class="receivedbox">
            <div class="handtop">
                <ul>
                    <li><a href="commentReceive.aspx">我收到的留言</a></li>
                    <li><a href="CommentSend.aspx">我发出的留言</a></li>
                    <li class="liwai">垃圾留言</li>
                </ul>
            </div>
            <div class="con cshibiank">
                <div class="search">
                    <div class="lefts">
                        您有<span class="hong"><asp:Label runat="server" ID="lbCommentNum" Text=""></asp:Label></span>条垃圾留言！
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
                    <asp:Repeater ID="rptCommentDelete" runat="server" OnItemDataBound="rptCommentDelete_ItemDataBound">
                        <ItemTemplate>
                            <div>
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>对 <a href="#">
                                        <%#Eval("title") %>
                                    </a>的留言
                                    <ul>
                                        姓名：刘晓飞 | 联系电话：0755-89805589 | E-mail：lxfei@tz888.cn | 2007-7-25 17:18
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
                                    </a>对 <a href="#">
                                        <%#Eval("title") %>
                                    </a>的留言
                                    <ul>
                                        姓名：刘晓飞 | 联系电话：0755-89805589 | E-mail：lxfei@tz888.cn | 2007-7-25 17:18
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
                            <a href="javascript:;" onclick="SelectAll()">全选</a>/<a href="javascript:;" onclick="SelectAll()">反选</a>
                            <input id="Button1" type="button" value="永久删除" class="buttomal" onclick="chkValue('del')" />
                            <input id="Button2" type="button" value="转移到我收到的留言" class="buttomal" onclick="chkValue('move')" style="width:120px" />
              </div>
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
          </div>
          
        </div>
        <div class="blank20">
        </div>
        <!--帮助 -->
        <div class="helpbox">
            <div class="con">
                <h1>
                    <img src="../../images/icon_yb.gif" align="absmiddle" /><strong> 重要提示</strong></h1>
                <p>
                    ·请定时清理您收到的垃圾留言，每条垃圾留言最长保留1个月，1个月后将自行删除；
                    <br />
                    ·垃圾留言不能进行回复，如果想对垃圾留言进行回复，请将该垃圾留言转至“收到的留言”中，这样您就可以对此留言进行回复。
                </p>
            </div>
        </div>
    </div>
</asp:Content>
