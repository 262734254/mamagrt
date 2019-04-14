<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inbox.aspx.cs" Inherits="InnerInfo_inbox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>我收到的消息</title>
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />

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
					InnerInfo_inbox.ToRecycle(str,backres);
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

</head>
<body>
    <form runat="server">
        <div id="mainconbox">
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
                    <li><a href="SendBox.aspx?Count=10&Time=7">我发出的消息</a> </li>
                    <li><a href="WasterBox.aspx">回收站</a></li></ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        您现在查看的是：
                        <asp:DropDownList ID="infoReceiveTime" runat="server" AutoPostBack="True" 
                        EnableViewState="False" OnSelectedIndexChanged="infoReceiveTime_SelectedIndexChanged1">
                        
                        <asp:ListItem Value="3">三天内</asp:ListItem>
                        <asp:ListItem Value="7">七天内</asp:ListItem>
                        <asp:ListItem Value="30">一个月内</asp:ListItem>
                        <asp:ListItem Value="90" Selected=true>三个月内</asp:ListItem>
                        <asp:ListItem Value="91">三个月以上</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <div class="rights">
                        每页显示：<a href="#" class="lanlink">10</a> 条 <a href="#" class="lanlink">20</a> 条 <a
                            href="#" class="lanlink">30</a> 条</div>
                    <div class="clear">
                    </div>
                </div>
                <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="8%" align="center" class="tabtitle">
                            <input type="checkbox" name="checkbox2" onclick="SelectAll()" id="checkbox3" /></td>
                        <td width="12%" align="left" class="tabtitle">
                            状态</td>
                        <td width="31%" align="left" class="tabtitle">
                            标题
                        </td>
                        <td width="11%" align="center" class="tabtitle">
                            发送人</td>
                        <td width="30%" align="center" class="tabtitle">
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
                                    <%#Eval("IsReaded") %>
                                </td>
                                <td align="left" class="taba">
                                    <%#Eval("topic") %>
                                </td>
                                <td align="center" class="taba">
                                    <%#Eval("SendedMan")%>
                                </td>
                                <td align="center" class="taba">
                                    <%#Eval("ReceivedTime")%>
                                </td>
                                <td align="center" class="taba">
                                    <a href="infoView.aspx?Ac=1&ReceivedID=<%#Eval("ReceivedId") %>">回复</a></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td align="center" class="tabb">
                                    <input type="checkbox" name="checkbox3" id="checkbox2" value='<%#Eval("ReceivedID")%>' />
                                </td>
                                <td align="left" class="tabb">
                                    <%#Eval("IsReaded") %>
                                </td>
                                <td align="left" class="tabb">
                                    <%#Eval("topic") %>
                                </td>
                                <td align="center" class="tabb">
                                    <%#Eval("SendedMan")%>
                                </td>
                                <td align="center" class="tabb">
                                    <%#Eval("ReceivedTime")%>
                                </td>
                                <td align="center" class="tabb">
                                    <a href="infoView.aspx?Ac=1&ReceivedID=<%#Eval("ReceivedId") %>">回复</a></td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="pagebox">
                <div class="left">
                    <img src="../images/MessageManage/biao_01.gif" width="14" height="16" /><a href="javascript:;"
                        onclick="SelectAll()">全选</a>/<a href="javascript:;" onclick="SelectAll()">反选</a>
                    将选中的短消息
                    <label>
                        <input name="button2" type="button" class="buttomal" id="button2" value="删除" onclick="goRecycle()" />
                    </label>
                    <label>
                    </label>
                    <input name="button" type="button" class="buttomal" id="button" value="导出" />
                </div>
                <div class="right">
                    上一页 下一页 转到第
                    <input name="textarea" type="text" id="textarea" value="" size="3" />
                    页
                    <input type="submit" name="button4" id="button4" value="GO" />
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
    </form>
</body>
</html>
