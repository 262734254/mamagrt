
<%@ Page Language="C#"   AutoEventWireup="true" CodeFile="FriendBlacklist.aspx.cs"  MasterPageFile="~/MasterPage.master" 
Inherits="helper_FriendManager_FriendBlacklist"  EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
<link href="../../css/common.css" rel="stylesheet" type="text/css" />

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
					helper_FriendManager_FriendBlacklist.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("��ѡѡ����Ҫɾ������");
			}
		}
	    function goFriend()
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
				if(confirm("ȷ����Ϊ���ѣ�"))
				{
					helper_FriendManager_FriendBlacklist.GoFriend(str,backres);
				}
			}
			else
			{
				alert("��ѡѡ���Ա");
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
            <div class="topzi">
                <div class="left">
                    �ҵĺ���</div>
                <div class="right">
                    <img src="../../images/AccountInfo/handbiao.gif" width="16" height="10" />
                  <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">������/�������</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li><a href="FriendSearch.aspx">��Ӻ���</a></li>
                    <li><a href="FriendList.aspx">�����б�</a></li>
                    <li><a href="InfoView.aspx">�����û���Դ</a></li>
                    <li class="liwai">������</li>
                    <li><a href="FriendConfig.aspx">��ɧ������</a></li>
                </ul>
            </div>
            <div class=" cshibiank">
                 <div class="search">
                    <div class="lefts">
                        ����������<asp:Label runat="server" ID="lbCount"></asp:Label>
                        λ��Ա��&nbsp;
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
                <div class="blacktopbox">
                    <h1 class="dottedl">
                        <img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" align="absmiddle" />
                        <strong>��ʾ��</strong>��������������еĻ�Ա�����޷�������Ϊ���ѣ�Ҳ�޷���������վ�ڶ��š�</h1>
                    <div class="blank0">
                    </div>
                    <table width="745" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="3" style="height: 31px">
                                <strong>��ָ����Ա�����������</strong></td>
                        </tr>
                        <tr>
                            <td width="92" align="right" valign="top">
                                ��Ա�ǳƣ�</td>
                            <td>
                                <p>
                                    <label>
                                        &nbsp;<asp:TextBox ID="tboxName" runat="server" Width="418px"></asp:TextBox></label><br />
                                    <span class="hui">ѡ�����û�����;����</span></p>
                            </td>
                            <td valign="top">
                                <asp:Button ID="btnOk" runat="server" Text="ȷ��" CssClass="buttomal" OnClick="btnOk_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="����" CssClass="buttomal" OnClick="btnClear_Click" />&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:GridView ID="friendBlackListGridView" runat="server" AutoGenerateColumns="False"
                    Width="754px" DataKeyNames="ContactId" OnRowDataBound="friendBlackListGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <a href="javascript:;" onclick="chkAll()">ѡ��</a>
                            </HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <input type="checkbox" name="checkbox3" id="checkbox2" value='<%#Eval("ContactId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��Ա����">
                            <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <a href="<%#viewLink(Eval("contactName"))%>" target="_blank"><%#view(Eval("contactName"))%></a>
                                <asp:Image runat="server" ID="imgTofo" Visible="false" ImageUrl="../../images/tfzs.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="��Ա����" ConvertEmptyStringToNull="False">
                            <HeaderStyle CssClass="tabtitle" Height="20px"  HorizontalAlign="Center"/>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="���Ժδ�">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="����">
                            <HeaderStyle CssClass="tabtitle" Height="20px" Wrap="False"  HorizontalAlign="Center"/>
                            <ItemTemplate>
                                <asp:Button ID="btnAddFriend" runat="server" BackColor="White" BorderStyle="None"
                                    CssClass="lanlink" Font-Overline="False" Font-Underline="True" ForeColor="RoyalBlue"
                                    Height="17px" Text="�������" Width="51px" OnClick="btnAddFriend_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" Wrap="False" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
                <div class="clear">
                </div>
            </div>
			<div class="pagebox">
                    <div class="left">
                        <img src="../../images/MessageManage/biao_01.gif" alt="" align="absbottom" /> 
                        <a href="javascript:;" onclick="chkAll2()">ȫѡ</a> /<a href="javascript:;" onclick="chkAll()">��ѡ</a>
                        <input name="button2" type="button" class="buttomal" id="button2" value="����ɾ��" onclick="goRecycle()" />
                        <input name="button2" type="button" class="buttomal" id="button1" value="�������" onclick="goFriend()" />                        
                        <label>
                        </label>
                        <label>
                        </label>
						<div style="height:8px;clear:both; overflow:hidden;font-size:1px;"></div>
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
          </div>
        </div>
        
</asp:Content>
