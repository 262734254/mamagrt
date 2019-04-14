<%@ Page Language="C#"   AutoEventWireup="true"   MasterPageFile="~/MasterPage.master" 
CodeFile="FriendList.aspx.cs" Inherits="helper_FriendManager_FriendList" %>

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
					helper_FriendManager_FriendList.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("��ѡѡ����Ҫɾ������");
			}
		}

		
		function goBlackList()
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
					helper_FriendManager_FriendList.ToBlackList(str,backres);
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
            <div class="topzi">
                <div class="left">
                    �ҵĺ���</div>
                <div class="right" style="margin-bottom:13px;">
				<img src="http://member.topfo.com/images/hand_1_2.gif" /> <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">������/�������</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li><a href="FriendSearch.aspx">��Ӻ���</a></li>
                    <li class="liwai">�����б�</li>
                    <li><a href="InfoView.aspx">�����û���Դ</a></li>
                    <li><a href="FriendBlacklist.aspx">������</a></li>
                    <li><a href="FriendConfig.aspx">��ɧ������</a></li>
                </ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        ���Ѳ�ѯ��
                        <asp:DropDownList ID="DDListMemberGrade" runat="server" Width="102px">
                            <asp:ListItem Value="0">�Ƿ��ظ�ͨ��Ա</asp:ListItem>
                            <asp:ListItem Value="1">�ظ�ͨ��Ա</asp:ListItem>
                            <asp:ListItem Value="2">��ͨ��Ա</asp:ListItem>

                        </asp:DropDownList>
                        <asp:DropDownList ID="DDListMemberType" runat="server" Width="115px">
                        <asp:ListItem Value="0">ѡ���Ա����</asp:ListItem>
                            <asp:ListItem Value="1">������Ա</asp:ListItem>
                            <asp:ListItem Value="2">��ҵ��Ա</asp:ListItem>
                            <asp:ListItem Value="3">���˻�Ա</asp:ListItem>
                        </asp:DropDownList>
                        <label>
                        </label>
                        <asp:TextBox ID="txtSelectFriendName" Text="����������ǳ�"  onclick="this.value=''" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSelect" Text="��ѯ" runat="server" OnClick="btnSelect_Click" /></div>
                    <div class="rights">
                        ÿҳ��ʾ��<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>��
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        �� <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        ��</div>
                    <div class="clear">
                    </div>
                </div>
                <div id="ListDiv">
                    <asp:GridView ID="friendListGridView" runat="server" AutoGenerateColumns="False"
                        Width="100%" DataKeyNames="ContactId" OnRowDataBound="friendListGridView_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="checkbox" name="checkbox3" id="checkbox2"  runat="server" value='<%#Eval("contactId")%>' />
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <a href="javascript:;" onclick="SelectAll()">ѡ��</a>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"/>
                                <ControlStyle Height="20px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��������">
                                <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="hplContactName" Visible="false" Text='<%#Eval("nickName")%>'></asp:HyperLink>
                                    <a href="<%#viewLink(Eval("contactName"))%>" target="_blank"><%#view(Eval("contactName"))%></a>
                                    <asp:Image runat="server" ID="imgTofo" Visible="false" ImageUrl="../../images/tfzs.gif" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="��Ա����" ConvertEmptyStringToNull="False">
                                <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="���Ѹ���">
                                <HeaderStyle CssClass="tabtitle" />
                                <ItemTemplate>
                                    &nbsp;<asp:HyperLink ID="hlkRefresh" runat="server" Text="" Target="_blank"></asp:HyperLink>
                                    <br />
                                    &nbsp;<asp:HyperLink ID="hlkPersonRefresh" runat="server" Text="" Target="_blank"></asp:HyperLink><br />
                                    &nbsp;<asp:HyperLink ID="hlkEnRefresh" runat="server" Text="" Target="_blank"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����ѽ���">
                                <HeaderStyle CssClass="tabtitle" Height="20px" Wrap="False"  HorizontalAlign="Center"/>
                                <ItemTemplate>
                                    <asp:HyperLink ID="hplSendInfo" runat="server" NavigateUrl='<%# Eval("nickName", "../../innerinfo/SendView.aspx?Ac=1&Name={0}") %>'
                                        CssClass="lanlink" Target="_blank">��վ�ڶ���</asp:HyperLink>
                                                <div runat="server" id="divOnlineTalk" >
                                               </div>
                                </ItemTemplate>
                                <ItemStyle Width="250px" Wrap="False" HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="pagebox">
                <div class="left">
                    <img alt="" src="../../images/MessageManage/biao_01.gif" width="14" height="16" />

                        <input name="button2" type="button" class="buttomal" id="button2" value="ɾ��" onclick="goRecycle()" />
                        <input name="button2" type="button" class="buttomal" id="button1" value="���������" onclick="goBlackList()" />                        
                    <asp:Button ID="ButtonGroupSend" CssClass="buttomal" runat="server" Text="Ⱥ��վ�ڶ���"
                        Width="86px" OnClick="ButtonGroupSend_Click" /></div>
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
            <div class="blank20">
            </div>
            <div class="helpbox" runat="server" id="divHelp">
                <div class="con">
                    <h1>
                        <img src="../../images/icon_yb.gif" align="absmiddle" />
                        ��Ҫ��ʾ</h1>
                    <p>
                    1.���Ѹ���ָ����������ѵ��û���ֻҪ�������µ�������߸������µ����ϣ�ͨ����˺󶼻������������ʾ��
                    <br />
                        <asp:Label ID="lbClue" runat="server" Text="2.�ظ�ͨ��Ա���Ը����еĺ���Ⱥ��վ�ڶ��š�" Width="261px"></asp:Label>&nbsp;<asp:HyperLink
                            ID="hplMore" runat="server" Width="109px" NavigateUrl="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" Target="_blank">�˽��ظ�ͨ������Ȩ</asp:HyperLink>
                        <asp:Label ID="lbTelNumber" runat="server" Text="0755-89805558" Width="135px"></asp:Label>
                        </p>
                </div>
            </div>
        </div>
        
 </asp:Content>
