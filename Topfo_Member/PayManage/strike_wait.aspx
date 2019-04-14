<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="��ֵ��������-�ظ�����-�й�����Ͷ����"
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
		   alert("��ѡ����Ҫɾ������");
		}
	}
    function deleteOrder(orderid)
    {
        var s = orderid;
       	if(confirm('ȷ��ɾ����ѡ��ĳ�ֵ������?'))
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
         alert("ɾ��ʧ��!");
       }
    }
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                ��ֵ����</div>
            <div class="right">
                <a href="http://www.topfo.com/help/AccountCZ.shtml#13" target="_blank">��ι����Լ��ĳ�ֵ��¼</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="suggestbox lightc allxian">
            <h1>
                ��Ҫ��ʾ��</h1>
            �����ڹ���<asp:Label ID="lblCount1" runat="server" Text="0"></asp:Label>��δ��ɵĳ�ֵ�������ܽ��<strong><asp:Label
                ID="lblPoint" runat="server" Text="0"></asp:Label></strong>Ԫ
            <br />
            �뼰ʱ�������ĳ�ֵ����������10����δ��ɸ���Ķ������ᱻϵͳ�Զ��رգ�
        </div>
        <div class="blank20">
        </div>
        <!-- -->
        <div class="handtop">
            <ul>
                <li class="liwai">��ֵ��������</li><li><a href="strike_records.aspx" style="text-decoration: none">
                    ��ɵĳ�ֵ</a> </li>
            </ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
<DIV class=" cshibiank"><DIV class="search"><DIV class="lefts">��ֵ��ѯ�� <SELECT id="sDiff" name="jumpMenu" runat="server"> <OPTION value="all" selected>---ȫ��---</OPTION> <OPTION value="90">����������</OPTION> <OPTION value="60">���������</OPTION> <OPTION value="30">���һ����</OPTION> <OPTION value="7">���һ����</OPTION></SELECT> <SELECT id="sType" name="jumpMenu2" runat="server"> <OPTION selected>��ֵ��ʽ</OPTION></SELECT> <LABEL></LABEL>&nbsp;<LABEL> ��ֵ�ʻ���<INPUT style="WIDTH: 120px" id="txtLoginName" type=text name="textarea2" runat="server" /> <INPUT id="btnSearch" type=button value="��ѯ" name="button" runat="server" onserverclick="btnSearch_ServerClick" /></LABEL></DIV><DIV class="rights"><P><A href="#"><asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" __designer:wfdid="w16">��һҳ</asp:LinkButton></A>&nbsp;&nbsp;&nbsp; <A href="#"><asp:LinkButton id="LinkButton2" onclick="LinkButton2_Click" runat="server" __designer:wfdid="w17">��һҳ</asp:LinkButton></A> </P></DIV><DIV class="clear"></DIV></DIV><TABLE class="taba" cellSpacing=0 cellPadding=0 width="100%" align=center border=0><TBODY><TR class="tabtitle"><td width="4%"  align="center" class="tabtitle">
                    <a href="javascript:;" onclick="chkAll()">ѡ��</a>
                    </td><TD class="tabtitle" align=center width="10%">������</TD><TD class="tabtitle" align=center width="17%">��ֵ�˻�</TD><TD class="tabtitle" align=center width="13%">��ֵ���(Ԫ)</TD><TD class="tabtitle" align=center width="14%">����ʱ��</TD><TD class="tabtitle" align=center width="14%">��ֵ��ʽ</TD><TD class="tabtitle" align=center width="15%">��������</TD></TR><asp:Repeater id="myList" runat="server">
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
                                Ԫ
                            </td>
                            <td align="center">
                                <%#Eval("OrderTime")%>
                            </td>
                            <td align="center">
                                <%#Eval("payTypeName")%>
                            </td>
                            <td align="center">
                                <a href="javascript:void(0)" onclick="deleteOrder('<%#Eval("OrderNO")%>')">ɾ������</a>
                                <a href="strike_details.aspx?action=0&order_no=<%#Eval("OrderNO") %>">��ϸ</a></td>
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
                                Ԫ
                            </td>
                            <td align="center" class="taba">
                                <%#Eval("OrderTime")%>
                            </td>
                            <td align="center" class="taba">
                                <%#Eval("payTypeName")%>
                            </td>
                            <td align="center" class="taba">
                                <a href="javascript:void(0)" onclick="deleteOrder('<%#Eval("OrderNO")%>')">ɾ������</a>
                                <a href="strike_details.aspx?action=0&order_no=<%#Eval("OrderNO") %>">��ϸ</a></td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                
                
                </TBODY></TABLE></DIV>
            <table><tr><td colspan=5 align=center> <a href="javascript:;" onclick="chkAll2()">ȫѡ</a>/<a href="javascript:;" onclick="chkAll()">��ѡ</a>  <input type="button" value="ɾ����ѡ" class="buttomal" onclick="chkValue()" /></td></tr></table>
                <DIV class="pagebox"><DIV class="right">�� <asp:Literal id="lblCount" runat="server" Text="0"></asp:Literal>�� ҳ�Σ�<asp:Literal id="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal id="lblPageCount" runat="server" Text="0"></asp:Literal>ҳ&nbsp; <asp:LinkButton id="FirstPage" onclick="FirstPage_Click" runat="server">��ҳ</asp:LinkButton>&nbsp;&nbsp; <asp:LinkButton id="PerPage" onclick="PerPage_Click" runat="server">��һҳ</asp:LinkButton> &nbsp;&nbsp; <asp:LinkButton id="NextPage" onclick="NextPage_Click" runat="server">��һҳ</asp:LinkButton>&nbsp;&nbsp; <asp:LinkButton id="LastPage" onclick="LastPage_Click" runat="server">βҳ</asp:LinkButton>&nbsp;&nbsp;<SPAN>ת�� �� <INPUT style="WIDTH: 36px; HEIGHT: 15px" id="txtPage" type=text name="textarea" runat="server" /> ҳ</SPAN> <INPUT style="FONT-SIZE: 12px; WIDTH: 30px; HEIGHT: 20px" id="btnGo" type=button value="GO" name="button2" runat="server" onserverclick="btnGo_ServerClick" /> </DIV><DIV class="clear"></DIV></DIV>
</contenttemplate>
        </asp:UpdatePanel>
        <!-- -->
        <div class="print">
            <img src="../images/PayManage/biao_print.gif" />
            <a href="javascript:;" onclick="window.print()">��ӡ��ҳ</a></div>
    </div>
</asp:Content>
