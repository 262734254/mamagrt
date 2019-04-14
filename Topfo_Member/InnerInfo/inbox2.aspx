<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inbox2.aspx.cs" Inherits="InnerInfo_inbox2" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
--%>    <script type="text/javascript" language="javascript" src="/javascript/comm.js"></script>
    <script language="javascript" type="text/javascript">
       function SelectAll()
       {
	      var a = document.getElementsByTagName("input"); 
	      for (var i=0; i<a.length; i++)
	      {
		    if (a[i].type=="checkbox") 
	         a[i].checked =!a[i].checked;
	      }
	    }
	    function goRecycle()
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
				if(confirm("确定操作吗?将不能恢复"))
				{
					InnerInfo_inbox2.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("请选选择所要删除的项");
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
		        alert("删除失败!");
		    }
		}
    </script>

    
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的短消息</div>
            <div class="clear">
            </div>
        </div>
        <div class="blank0">
        </div>
        <div class="handtop">
            <ul>
                <li><a href="SendView.aspx">发送短消息</a></li><li class="liwai">我收到的消息 </li>
                <li><a href="SendBox2.aspx">我发出的消息</a> </li>
                <li><a href="Waster2.aspx">回收站</a></li></ul>
        </div>
                <div class=" cshibiank">
                    <div class="search">
                        <div class="lefts">
                            您现在查看的是：
                            <asp:DropDownList ID="infoReceiveTime" runat="server" AutoPostBack="True" EnableViewState="False"
                                OnSelectedIndexChanged="infoReceiveTime_SelectedIndexChanged1">
                                <asp:ListItem Value="3">三天内</asp:ListItem>
                                <asp:ListItem Value="7">七天内</asp:ListItem>
                                <asp:ListItem Value="30">一个月内</asp:ListItem>
                                <asp:ListItem Value="90" Selected="true">三个月内</asp:ListItem>
                                <asp:ListItem Value="91">三个月以上</asp:ListItem>
                            </asp:DropDownList>
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
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="7%" align="center" class="tabtitle">
                          <a href="javascript:;" onclick="chkAll()">选择</a></td>
                            <td width="10%" align="left" class="tabtitle">
                                状态</td>
                            <td width="42%" align="left" class="tabtitle">
                                标题                            </td>
                            <td width="17%" align="center" class="tabtitle">
                                发送人</td>
                            <td width="16%" align="center" class="tabtitle">
                                接收时间</td>
                            <td width="8%" align="center" class="tabtitle">
                                回复</td>
                        </tr>
                        <asp:Repeater runat="server" ID="myList">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" class="taba">
                                        <input type="checkbox" name="checkbox" id="checkbox" value='<%#Eval("ReceivedID")%>' />
                                    </td>
                                    <td align="left" class="taba">
                                        <%#status(Eval("IsReaded"))%>
                                    </td>
                                    <td align="left" class="taba">
                                    <a class="blue" href="infoView.aspx?Ac=0&ReceivedID=<%#Eval("ReceivedId") %>"><%#Eval("topic") %></a>
                                        
                                    </td>
                                    <td align="center" class="taba">
                                    <a class="blue" href="<%#viewLink(Eval("SendedMan"))%>" target="_blank"><%#view(Eval("SendedMan"))%></a>
                                    </td>
                                    <td align="center" class="taba">
                                        <%#Eval("ReceivedTime")%>
                                    </td>
                                    <td align="center" class="taba">
                                        <%#this.viewReply(Eval("SendedMan"), Eval("ReceivedId"))%></td>
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td align="center" class="tabb">
                                        <input type="checkbox" name="checkbox3" id="checkbox2" value='<%#Eval("ReceivedID")%>' />
                                    </td>
                                    <td align="left" class="tabb">
                                        <%#status(Eval("IsReaded"))%>
                                    </td>
                                    <td align="left" class="tabb">
                                        <a class="blue" href="infoView.aspx?Ac=0&ReceivedID=<%#Eval("ReceivedId") %>"><%#Eval("topic") %></a>
                                    </td>
                                    <td align="center" class="tabb">
                                    <a href="<%#viewLink(Eval("SendedMan"))%>" target="_blank"><%#view(Eval("SendedMan"))%></a>                                        
                                    </td>
                                    <td align="center" class="tabb">
                                        <%#Eval("ReceivedTime")%>
                                    </td>
                                    <td align="center" class="tabb">
                                        <%#this.viewReply(Eval("SendedMan"), Eval("ReceivedId"))%></td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
                <div class="pagebox">
                    <div class="left">
                        <img src="../images/MessageManage/biao_01.gif" align="absbottom" /> 
                        <a href="javascript:;" onclick="chkAll2()">全选</a> /<a href="javascript:;" onclick="chkAll()">反选</a>
                        <label>
                            <input name="button2" type="button" class="buttomal" id="button2" value="删除" onclick="goRecycle()" />
                        </label>
                        <label>
                        </label>
                        <asp:Button ID="btnOut" runat="server" Text="导出"  CssClass="buttomal" OnClick="btnOut_Click" />
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
                    <div class="clear">
                    </div>
                </div>
        <div class="suggestbox " style="display: none">
            收到新的站内短信时，系统将会播放声音 <span class="left">
                <input type="reset" name="button3" id="button3" value="关闭" />
            </span>
        </div>
    </div>
    
</asp:Content>
