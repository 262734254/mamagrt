<%@ Page Language="C#" AutoEventWireup="true" ResponseEncoding="GB2312" MasterPageFile="~/MasterPage.master"
    Title="֪ͨ����-�ظ�����-�й�����Ͷ����" CodeFile="getPromotion.aspx.cs" Inherits="helper_getPromotion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="/css/promotion.css" rel="stylesheet" type="text/css" />


    <script language="javascript" type="text/javascript">
    function chkAll()
    {
       var a =document.getElementsByTagName("input"); 
       for (var i=0; i<a.length; i++)
	   {
		 if (a[i].type == "checkbox") 
		 a[i].checked =!a[i].checked;
	    }
         
    }
    function chkValue(flag)
	{
	    var a = document.documentElement.getElementsByTagName("input");
		var str="";

		for (var i=0; i<a.length-3; i++) 
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
		      if(flag=="1")
		      {
		          if(confirm("ȷ��������ѡ�Ƽ���?���պ���û�������Ϣ��������յ�!"))
	              {
		            NoReceive(str);
		          }
		      }
		      if(flag=="2")
		      {
		          if(confirm("ȷ��ɾ���Ƽ���Դ��?"))
	              {       
		            DeleteInfo(str);
		          }
		      }
		}
		else
		{
		   alert("��ѡ����Ҫ���õ���");
		}
	}
	function NoReceive(str)
	{
	    helper_getPromotion.NoReceive(str,backres)
	}
	function DeleteInfo(str)
	{
	   helper_getPromotion.DeleteInfo(str,backres);
	}
	function DeleteAll()
	{
	   if(confirm("ȷ��ɾ�������Ƽ���Դ��?"))
	   { 
	        helper_getPromotion.DeleteAllInfo(backres);
	   }
	}
	function AddBlack(obj)
	{
	    if(confirm("���պ󽫲����յ�"+obj+"�Ƽ�����Դ"))
	    { 
	        helper_getPromotion.AddBlack(obj,backres);
	    }
	}
	function backres(res)
	{
	   
	    if(res.value=="success")
	    {
	        window.location.reload();
	    }
	}
	function del()
{
    return confirm('�⽫���ɻָ�,���Ҫɾ����');
}
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                �����ƹ�</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" alt="" width="14" height="15" align="absmiddle" />
                <a href="http://www.topfo.com/help/directionalextend.shtml#12" target="_blank">ʹ��˵��</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="handtop">
            <ul>
                <li><a href="/helper/myPromotion.aspx">�ƹ��ҵ�����</a> </li>
                <li class="liwai">���յ����Ƽ���Դ</li><li><a href="/helper/ReceivedSet.aspx">��������</a> </li>
                
            </ul>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <contenttemplate>
                <div class="demandbox cshibiank">
                    <h1 class="dottedl lightc">
                        <img src="/images/icon_tishi.gif" align="absmiddle" />
                        <span class="cheng">��ܰ��ʾ��</span>����㲻���յ��������ƹ����ݣ��������˶���������ϸ����������</h1>
                    <div class="blank20">
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="chkTab">
                        <tr>
                            <td colspan="2" class="tabtitle" style="width: 22%">
                                ��Դ����</td>
                            <td width="10%" align="center" class="tabtitle">
                                ��Դ����</td>
                            <td width="16%" align="left" class="tabtitle">
                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;������ҵ</td>
                            <td width="13%" align="left" class="tabtitle">
                                &nbsp;&nbsp;&nbsp;&nbsp;Ͷ������</td>
                            <td align="left" width="10%" class="tabtitle">
                                &nbsp; &nbsp;�۸�(Ԫ)</td>
                                
                            <td align="left" width="11%" class="tabtitle">
                                  &nbsp;&nbsp;&nbsp;����ʱ��</td>
                            <td align="left" width="15%" class="tabtitle">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����</td>
                        </tr>
                        <asp:Repeater runat="server" ID="myList" OnItemCommand="myList_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td colspan="2">
                                        <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>" />
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                            <%#GetTitle(Eval("Title")) %>
                                        </a>
                                    </td>
                                    <%--<td></td>--%>
                                    <td align="center">
                                    
                                        <%#GetTypeName(Eval("InfoTypeID")) %>
                                    </td>
                                    <td align="center">
                                      <%#GetIndustry(Eval("InfoID"))%>
                                    </td>
                                    <td align="center">
                                         <%#GetQu(Eval("InfoID"))%>
                                    </td>
                                    <td align="center" style="color:Red">
                                        <%--<%#Convert.ToDouble(Eval("MainPointCount") * 0.08).ToString("��0.00")%>--%>
                                        <%#GetPrice(Eval("MainPointCount"))%>
                                    </td>
                                    <td align="center">
                                        <%#Convert.ToDateTime(Eval("publishT")).ToString("yyyy-MM-dd")%>
                                    </td>
                                    <td align="left" class="taba">
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">�鿴</a>&nbsp; 
                                        <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("InfoID") %>' CommandName="Delete" OnClientClick="return del()" Text="ɾ��" />&nbsp;<%#GetCount(Eval("MainPointCount"), Eval("InfoID"))%></td>
                                 </tr>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <tr>
                                    <td class="tabb" colspan="2">
                                        <input type="checkbox" name="checkbox" value="<%#Eval("ID") %>" />
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                            <%#GetTitle(Eval("Title"))%>
                                        </a>
                                    </td>
                                    <%-- <td class="tabb">
                                
                                
                            </td>--%>
                                    <td align="center">
                                        <%#GetTypeName(Eval("InfoTypeID")) %>
                                    </td>
                                    <td align="center">
                                        <%#GetIndustry(Eval("InfoID"))%>
                                    </td>
                                    <td align="center">
                                         <%#GetQu(Eval("InfoID"))%>
                                    </td>
                                    <td align="center" style="color:Red">
                                            <%#GetPrice(Eval("MainPointCount"))%>
                                    </td>
                                    <td align="center">
                                        <%#Convert.ToDateTime(Eval("publishT")).ToString("yyyy-MM-dd")%>
                                    </td>
                                    <td align="left" class="taba">
                                        <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">�鿴</a>&nbsp;
                                        <asp:LinkButton ID="lbtnDel1" runat="server" CommandArgument='<%#Eval("InfoID") %>' CommandName="Delete" OnClientClick="return del()" Text="ɾ��" />&nbsp;<%#GetCount(Eval("MainPointCount"), Eval("InfoID"))%>
                                     </td>
                                </tr>
                            </AlternatingItemTemplate>
                        </asp:Repeater>
                    </table>
                    <div class="pagebox">
                        <div class="left">
                            <img src="../images/MessageManage/biao_01.gif" align="absbottom" />
                            <a href="javascript:void(0)" onclick="chkAll()">ȫѡ</a>/<a href="javascript:void(0)"
                                onclick="chkAll()">��ѡ</a></div>
                        <div class="right">
                            ��<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>�� ҳ�Σ�<asp:Literal
                                ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                                    runat="server" Text="0"></asp:Literal>ҳ&nbsp;
                            <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">��ҳ</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">��һҳ</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">��һҳ</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">βҳ</asp:LinkButton>&nbsp;<span>ת��
                                ��
                                <input name="textarea" type="text" id="txtPage" style="width: 36px; height: 15px;"
                                    runat="server" />
                                ҳ</span>
                            <input type="button" name="button2" id="btnGo" value="GO" style="width: 30px; height: 20px;
                                font-size: 12px;" runat="server" onserverclick="btnGo_ServerClick" />
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <p>
                        <input name="" type="button" class="buttomal" value="��������" style="display: none"
                            onclick="chkValue(1)" />
                        <input name="" type="button" class="buttomal" value="����ɾ��" onclick="chkValue(2)" />
                        <input name="" type="button" class="buttomal" value="���������Դ" onclick="DeleteAll()" />
                    </p>
                    <div class="clear">
                    </div>
                </div>
            </contenttemplate>
        </asp:UpdatePanel>
    </div>
    <div class="blank20">
    </div>
</asp:Content>
