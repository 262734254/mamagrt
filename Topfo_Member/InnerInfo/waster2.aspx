<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="waster2.aspx.cs" Inherits="InnerInfo_waster2" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" %>

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
					InnerInfo_waster2.ToRecycle(str,backres);
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
                    �ҵĶ���Ϣ</div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li><a href="SendView.aspx">���Ͷ���Ϣ</a></li><li><a href="inbox2.aspx">���յ�����Ϣ</a> </li>
                    <li><a href="SendBox2.aspx">�ҷ����Ķ���Ϣ</a> </li>
                    <li class="liwai">����վ</li></ul>
            </div>

                        <div class=" cshibiank">
                            <div class="search">
                                <div class="lefts">
                                    
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
                            <td width="8%" align="center" class="tabtitle">
                             <a href="javascript:;" onclick="chkAll()">ѡ��</a></td>
                            <td width="31%" align="left" class="tabtitle">
                                ����
                            </td>
                            <td width="11%" align="center" class="tabtitle">
                                ������</td>
                           <td width="11%" align="center" class="tabtitle">
                               �ռ���</td>
                            <td width="30%" align="center" class="tabtitle">
                                ɾ��ʱ��</td>
                          
                        </tr>
                        <asp:Repeater runat="server" ID="infoWasterGridView">
                            <ItemTemplate>
                                <tr>
                                    <td align="center" class="taba">
                                        <input type="checkbox" name="checkbox" id="checkbox1" value='<%#Eval("WasterId")%>' />
                                    </td>
                                   
                                    <td align="left" class="taba">
                                        <a class="blue" href="wasterView.aspx?wasterId=<%#Eval("WasterId") %>"> <%#Eval("topic") %></a>
                                    </td>
                                     <td align="center" class="taba">
                                     <a href="<%#viewLink(Eval("SendedMan"))%>" target="_blank"><%#view(Eval("SendedMan"))%></a> 
                                    </td>
                                    <td align="center" class="taba">
                                    <a href="<%#viewLink(Eval("ReceiveDman"))%>" target="_blank"><%#view(Eval("ReceiveDman"))%></a> 
                                    </td>
                                    <td align="center" class="taba">
                                        <%#Eval("ChangeTime")%>
                                    </td>
                                   
                                </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td align="center" class="tabb">
                                        <input type="checkbox" name="checkbox3" id="checkbox2" value='<%#Eval("WasterId")%>' />
                                    </td>
                                   
                                    <td align="left" class="tabb">
                                       <a class="blue"  href="wasterView.aspx?wasterId=<%#Eval("WasterId") %>"> <%#Eval("topic") %></a>
                                    </td>
                                    <td align="center" class="tabb">
                                    <a href="<%#viewLink(Eval("SendedMan"))%>" target="_blank"><%#view(Eval("SendedMan"))%></a> 
                                    </td>
                                     <td align="center" class="tabb">
                                     <a href="<%#viewLink(Eval("ReceiveDman"))%>" target="_blank"><%#view(Eval("ReceiveDman"))%></a> 
                                    </td>
                                    <td align="center" class="tabb">
                                        <%#Eval("ChangeTime")%>
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
                               
                                    <input name="button2" type="button" class="buttomal" id="button2" value="����ɾ��" onclick="goRecycle()" />
                               
                                    <asp:Button ID="btnOut" runat="server" Text="����"  CssClass="buttomal" OnClick="btnOut_Click" />
                                    <asp:Button runat="server" ID="btnClear" Text="��ջ���վ" CssClass="buttomal" OnClick="btnClear_Click"  style="width:80px" />
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
                        <div class="suggestbox ">
                        </div>

        </div>
    </div>
    
</asp:Content>
