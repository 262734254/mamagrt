<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="充值订单管理-拓富中心-中国招商投资网"
    AutoEventWireup="true" CodeFile="strike_wait.aspx.cs" ResponseEncoding="GB2312"
    Inherits="PayManage_strike_wait" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/javascript/comm.js"></script>

    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript" language="javascript">
    function chkValue()
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
		    deleteOrder(str);
		}
		else
		{
		   alert("请选择所要删除的项");
		}
	}
    function deleteOrder(orderid)
    {
        var s = orderid;
       	if(confirm('确定删除所选择的充值订单吗?'))
            PayManage_strike_wait.deleteOrd(s,backres);
       
    }
    function backres(res)
    {
       if(res.value)
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
        <div class="titled">
            <div class="left">
                充值管理</div>
            <div class="right">
                <a href="http://www.topfo.com/help/AccountCZ.shtml#13" target="_blank">如何管理自己的充值记录</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox lightc allxian">
            <h1>
                重要提示：</h1>
            您现在共有<asp:Label ID="lblCount1" runat="server" Text="0"></asp:Label>条未完成的充值订单，总金额<strong><asp:Label
                ID="lblPoint" runat="server" Text="0"></asp:Label></strong>元
            <br />
            请及时处理您的充值定单，超过10天仍未完成付款的订单将会被系统自动关闭！
        </div>
        <div class="blank20">
        </div>
        <!-- -->
        <div class="handtop">
            <ul>
                <li class="liwai">充值订单管理</li><li><a href="strike_records.aspx" style="text-decoration: none">
                    完成的充值</a> </li>
            </ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
<DIV class=" cshibiank"><DIV class="search"><DIV class="lefts">充值查询： <SELECT id="sDiff" name="jumpMenu" runat="server"> <OPTION value="all" selected>---全部---</OPTION> <OPTION value="90">三个月以上</OPTION> <OPTION value="60">最近三个月</OPTION> <OPTION value="30">最近一个月</OPTION> <OPTION value="7">最近一周内</OPTION></SELECT> <SELECT id="sType" name="jumpMenu2" runat="server"> <OPTION selected>充值方式</OPTION></SELECT> <LABEL></LABEL>&nbsp;<LABEL> 充值帐户：<INPUT style="WIDTH: 120px" id="txtLoginName" type=text name="textarea2" runat="server" /> <INPUT id="btnSearch" type=button value="查询" name="button" runat="server" onserverclick="btnSearch_ServerClick" /></LABEL></DIV><DIV class="rights"><P><A href="#"><asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" __designer:wfdid="w16">上一页</asp:LinkButton></A>&nbsp;&nbsp;&nbsp; <A href="#"><asp:LinkButton id="LinkButton2" onclick="LinkButton2_Click" runat="server" __designer:wfdid="w17">下一页</asp:LinkButton></A> </P></DIV><DIV class="clear"></DIV></DIV><TABLE class="taba" cellSpacing=0 cellPadding=0 width="100%" align=center border=0><TBODY><TR class="tabtitle"><td width="4%"  align="center" class="tabtitle">
                    <a href="javascript:;" onclick="chkAll()">选择</a>
                    </td><TD class="tabtitle" align=center width="10%">订单号</TD><TD class="tabtitle" align=center width="17%">充值账户</TD><TD class="tabtitle" align=center width="13%">充值金额(元)</TD><TD class="tabtitle" align=center width="14%">生成时间</TD><TD class="tabtitle" align=center width="14%">充值方式</TD><TD class="tabtitle" align=center width="15%">订单管理</TD></TR><asp:Repeater id="myList" runat="server">
                    <ItemTemplate>
                        <tr>
                        <td align=center><input type=checkbox name=checkbox value="<%#Eval("OrderNO") %>" /></td>
                            <td align="center">
                                <%#Eval("OrderNO")%>
                            </td>
                            <td align="center">
                                <%#Eval("StrikeLoginName")%>
                            </td>
                            <td align="center">
                                <%#Eval("TransMoney","{0:N}")%>
                                元
                            </td>
                            <td align="center">
                                <%#Eval("OrderTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("payTypeName")%>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" onclick="deleteOrder('<%#Eval("OrderNO")%>')">删除订单</a>
                                <a href="strike_details.aspx?action=0&order_no=<%#Eval("OrderNO") %>">明细</a></td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="taba">
                        <td  class="taba"><input type=checkbox name=checkbox value="<%#Eval("OrderNO") %>" /></td>
                            <td align="center" class="taba">
                                <%#Eval("OrderNO")%>
                            </td>
                            <td align="center" class="taba">
                                <%#Eval("StrikeLoginName")%>
                            </td>
                            <td align="center" class="taba">
                                <%#Eval("TransMoney","{0:N}")%>
                                元
                            </td>
                            <td align="center" class="taba">
                                <%#Eval("OrderTime")%>
                            </td>
                            <td align="center" class="taba">
                                <%#Eval("payTypeName")%>
                            </td>
                            <td align="center" class="taba">
                                <a href="javascript:void(0)" onclick="deleteOrder('<%#Eval("OrderNO")%>')">删除订单</a>
                                <a href="strike_details.aspx?action=0&order_no=<%#Eval("OrderNO") %>">明细</a></td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                
                
                </TBODY></TABLE></DIV>
            <table><tr><td colspan=5 align=center> <a href="javascript:;" onclick="chkAll2()">全选</a>/<a href="javascript:;" onclick="chkAll()">反选</a>  <input type="button" value="删除所选" class="buttomal" onclick="chkValue()" /></td></tr></table>
                <DIV class="pagebox"><DIV class="right">共 <asp:Literal id="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal id="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal id="lblPageCount" runat="server" Text="0"></asp:Literal>页&nbsp; <asp:LinkButton id="FirstPage" onclick="FirstPage_Click" runat="server">首页</asp:LinkButton>&nbsp;&nbsp; <asp:LinkButton id="PerPage" onclick="PerPage_Click" runat="server">上一页</asp:LinkButton> &nbsp;&nbsp; <asp:LinkButton id="NextPage" onclick="NextPage_Click" runat="server">下一页</asp:LinkButton>&nbsp;&nbsp; <asp:LinkButton id="LastPage" onclick="LastPage_Click" runat="server">尾页</asp:LinkButton>&nbsp;&nbsp;<SPAN>转到 第 <INPUT style="WIDTH: 36px; HEIGHT: 15px" id="txtPage" type=text name="textarea" runat="server" /> 页</SPAN> <INPUT style="FONT-SIZE: 12px; WIDTH: 30px; HEIGHT: 20px" id="btnGo" type=button value="GO" name="button2" runat="server" onserverclick="btnGo_ServerClick" /> </DIV><DIV class="clear"></DIV></DIV>
</contenttemplate>
        </asp:UpdatePanel>
        <!-- -->
        <div class="print">
            <img src="../images/PayManage/biao_print.gif" />
            <a href="javascript:;" onclick="window.print()">打印该页</a></div>
    </div>
</asp:Content>
