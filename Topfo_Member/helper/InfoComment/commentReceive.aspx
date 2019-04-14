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
       //将除头模板中的其它所有的CheckBox取反
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
				if(confirm("确定操作吗?将不能恢复"))
				{
					helper_InfoComment_commentReceive.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("请选选择所要删除的项");
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
				if(confirm("确定公开留言吗？"))
				{
					helper_InfoComment_commentReceive.ToPublic(str,backres);
				}
			}
			else
			{
				alert("请选择公开的项");
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
		        alert("失败!");
		    }
		}

        		
    </script>


  <link href="../../css/common.css" rel="stylesheet" type="text/css" />
        <div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    留言管理</div>
                <div class="right">
                    <a href="http://www.topfo.com/help/leaveword.shtml" class="chenglink" target="_blank">如何有效地管理留言</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="suggestbox lightc allxian">
                <h1>
                    <img src="/images/icon_tishi.gif" align="absmiddle" /> 温馨提示：</h1>
                <p style=" text-indent:25px;">
                    所有留言默认不在页面上显示，如果您想显示所有留言或其中的部分留言，请选中想要公开的留言，点击“公开留言”即可。 为了保证留言不对您或您的企业产生不良影响，<span
                        class="hong">请在仔细审核留言内容后再选择是否公开</span>。
                    <br />
                </p>
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
                        <div class="lefts">
                            <asp:DropDownList runat="server" ID="ddlCommentType">
                                <asp:ListItem Text="新留言" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">已阅读</asp:ListItem>
                                <asp:ListItem Value="2">已回复</asp:ListItem>
                                <asp:ListItem Value="3">已公开</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlCommentFrom">
                                <asp:ListItem Text="来自" Value="0"></asp:ListItem>
                                <asp:ListItem Value="1">拓富通会员</asp:ListItem>
                                <asp:ListItem Value="２">普通会员</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList runat="server" ID="ddlCommentTime" EnableViewState="False">
                                <asp:ListItem Value="3" >三天内</asp:ListItem>
                                <asp:ListItem Value="7">七天内</asp:ListItem>
                                <asp:ListItem Value="30">一个月内</asp:ListItem>
                                <asp:ListItem Value="90" Selected="True">三个月内</asp:ListItem>
                                <asp:ListItem Value="91">三个月以上</asp:ListItem>
                            </asp:DropDownList>
                            <label>
                            </label>
                            <strong>
                                <asp:TextBox runat="server" ID="txtCommentSelect" EnableViewState="False"></asp:TextBox>
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
                    <!---->
                    <asp:Repeater ID="rptCommentReceive" runat="server" OnItemDataBound="rptCommentReceive_ItemDataBound">
                        <ItemTemplate>
                            <div>
                                <h1>
                                    <a href="#">
                                        <%#Eval("LoginName") %>
                                    </a>对 <a href="#">
                                        <%#Eval("title") %>
                                    </a>的留言
                                    <ul style="display: none">
                                        姓名：刘晓飞 | 联系电话：0755-89805589 | E-mail：lxfei@tz888.cn | 2007-7-25 17:18
                                    </ul>
                                </h1>
                                <div class="mescon">
                                    <input type="checkbox" name="checkbox3" id="checkbox2"  runat="server" value='<%#Eval("Id")%>' />
                                    <div class="right" >
                                        <%#Eval("CommentContent") %>
                                        <br />
                                        <div runat="server" id="divResView" class="cshibiank lightc mesreply"  >
                                         &nbsp&nbsp&nbsp 我 对 此留言的回复：
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label>   
                                        </div>
                                        <p>
                                         <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnRes" OnClick="brnRes_Click" >回复</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("loginName")%>' runat="server" ID="btnFriend" OnClick="brnFriend_Click" >加为好友</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnPublic" OnClick="brnPublic_Click"  Text='<%#status(Eval("IsAudit"))%>'></asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnDelete" OnClick="brnDelete_Click" >删除</asp:LinkButton>
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
                                    </a>对 <a href="#">
                                        <%#Eval("title") %>
                                    </a>的留言
                                    <ul style="display: none">
                                        姓名：刘晓飞 | 联系电话：0755-89805589 | E-mail：lxfei@tz888.cn | 2007-7-25 17:18
                                    </ul>
                                </h1>
                                <div class="mescon">
                                    <input type="checkbox" name="checkbox3" id="checkbox2"  runat="server" value='<%#Eval("Id")%>' />
                                    <div class="right">
                                        <%#Eval("CommentContent") %>
                                        <br />
                                        <div runat="server" id="divResView" class="cshibiank lightc mesreply">
                                        &nbsp&nbsp&nbsp 我 对 此留言的回复：
                                        <br />
                                        <asp:Label runat="server" ID="ResView" Text=""></asp:Label>
                                        </div>
                                        <p>
                                         <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnRes" OnClick="brnRes_Click" >回复</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("loginName")%>' runat="server" ID="btnFriend" OnClick="brnFriend_Click" >加为好友</asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnPublic" OnClick="brnPublic_Click"  Text='<%#status(Eval("IsAudit"))%>'></asp:LinkButton>
                                        <asp:LinkButton CommandName='<%#Eval("Id")%>' runat="server" ID="btnDelete" OnClick="brnDelete_Click" >删除</asp:LinkButton>
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
                        <a href="javascript:;" onclick="SelectAll()">全选</a>/<a href="javascript:;" onclick="SelectAll()">反选</a>
                        <input name="button2" type="button" class="buttomal" id="button2" value="删除" onclick="goRecycle()" />
                        <input name="button2" type="button" class="buttomal" id="button1" value="公开留言" onclick="goPublic()" />
                        <asp:Button ID="btnOut" runat="server" Text="导出"  CssClass="buttomal" OnClick="btnOut_Click" /></div>
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
                    <div class="xia">
                        <asp:HyperLink runat="server" ID="hplViewTelNumber" NavigateUrl="/helper/Notice.aspx"
                            Text="设置留言通知"></asp:HyperLink></div>
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
                        <img src="../../images/icon_yb.gif" align="absmiddle" /><strong> 重要提示</strong>                    </h1>
                    <p>
                        1. 您不是拓富通会员，目前还不能使用<span class="hong">新留言</span>的手机短信提醒服务。
                        <br />
                        2. 您想收到更多优质用户的留言吗？据统计，拓富通会员收到的留言是普通会员的<span class="chengcu">12</span>倍。
                        <br />
                        <a href="/Register/VIPMemberRegister_In.aspx">立即升级拓富通会员服务</a> 
                    </p>
                </div>
            </div>
        </div>
        
</asp:Content>
