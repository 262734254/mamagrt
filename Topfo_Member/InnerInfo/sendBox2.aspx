<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="sendBox2.aspx.cs" Inherits="InnerInfo_sendBox2" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="/javascript/comm.js"></script>
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
				if(confirm("ȷ��������?�����ָܻ�"))
				{
					InnerInfo_sendBox2.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("��ѡѡ����Ҫɾ������");
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
		        alert("ɾ��ʧ��!");
		    }
		}
    </script>
 

    
    <div class="mainconbox">
        <div id="ListDiv">
            <div class="topzi">
                <div class="left">
                    �ҵĶ���Ϣ
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li><u><a href="SendView.aspx">���Ͷ���Ϣ</a></u></li><li><a href="inbox2.aspx">���յ�����Ϣ</a>
                    </li>
                    <li class="liwai">�ҷ����Ķ���Ϣ</li><li><a href="waster2.aspx">����վ</a></li></ul>
            </div>

            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        �����ڲ鿴���ǣ�&nbsp;
                        <asp:DropDownList ID="infoSendTime" runat="server" AutoPostBack="True" OnSelectedIndexChanged="infoSendTime_SelectedIndexChanged">
                            <asp:ListItem Value="3">������</asp:ListItem>
                            <asp:ListItem Value="7">������</asp:ListItem>
                            <asp:ListItem Value="30">һ������</asp:ListItem>
                            <asp:ListItem Value="90">��������</asp:ListItem>
                            <asp:ListItem Value="91">����������</asp:ListItem>
                        </asp:DropDownList>
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
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="13%" align="center" class="tabtitle">
                             <a href="javascript:;" onclick="chkAll()">ѡ��</a></td>
                            <td width="49%" align="left" class="tabtitle">
                                ����                            </td>
                            <td width="17%" align="center" class="tabtitle">
                                �ռ���</td>
                            <td width="21%" align="center" class="tabtitle">
                                ����ʱ��</td>
                          
                        </tr>
                        <asp:Repeater runat="server" ID="infoSendGridView">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" class="taba">
                                        <input type="checkbox" name="checkbox" id="checkbox1" value='<%#Eval("ReceivedID")%>' />
                                    </td>
                                   
                                    <td align="left" class="taba">
                                        <a class="blue" href="SendView.aspx?name=%&SendID=<%#Eval("SendID") %>"> <%#Eval("topic") %></a>
                                    </td>
                                    <td align="center" class="taba">
                                    <a href="<%#viewLink(Eval("ReceiveDman"))%>" target="_blank"><%#view(Eval("ReceiveDman"))%></a> 
                                    </td>
                                    <td align="center" class="taba">
                                        <%#Eval("SendTime")%>
                                    </td>
                                   
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td align="center" class="tabb">
                                        <input type="checkbox" name="checkbox3" id="checkbox2" value='<%#Eval("SendID")%>' />
                                    </td>
                                   
                                    <td align="left" class="tabb">
                                       <a class="blue"  href="SendView.aspx?SendID=<%#Eval("SendID") %>"> <%#Eval("topic") %></a>
                                    </td>
                                    <td align="center" class="tabb">
                                    <a href="<%#viewLink(Eval("ReceiveDman"))%>" target="_blank"><%#view(Eval("ReceiveDman"))%></a>
                                    </td>
                                    <td align="center" class="tabb">
                                        <%#Eval("SendTime")%>
                                    </td>
                                   
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
               
            </div>
            <div class="pagebox">
                    <div class="left">
                       <img src="../images/MessageManage/biao_01.gif" align="absbottom" /> 
                       <a href="javascript:;" onclick="chkAll2()">ȫѡ</a> /<a href="javascript:;" onclick="chkAll()">��ѡ</a>
                        <label>
                            <input name="button2" type="button" class="buttomal" id="button2" value="ɾ��" onclick="goRecycle()" />
                        </label>
                        <label>
                        </label>
                        <asp:Button ID="btnOut" runat="server" Text="����"  CssClass="buttomal" OnClick="btnOut_Click" />
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
                    <div class="clear">
                    </div>
                </div>

            <div class="suggestbox " style="display: none">
                &nbsp; �յ��µ�վ�ڶ���ʱ��ϵͳ���Ქ������ <span class="left">
                    <input type="reset" name="button3" id="button3" value="�ر�" onclick="return button3_onclick()" />
                </span>
            </div>
        </div>
    </div>
    
    
</asp:Content>