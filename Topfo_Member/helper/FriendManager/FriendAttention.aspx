<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
CodeFile="FriendAttention.aspx.cs" Inherits="helper_FriendManager_FriendAttention"  EnableEventValidation="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <%--<link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
<link href="../../css/common.css" rel="stylesheet" type="text/css" />--%>
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
					helper_FriendManager_FriendAttention.ToRecycle(str,backres);
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
                    <li class="liwai">��ע�ҵ��û�</li>
                    <li><a href="FriendBlacklist.aspx">������</a></li>
                    <li><a href="FriendConfig.aspx">��ɧ������</a></li>
                </ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        ����<asp:Label runat="server" ID="lbCount"></asp:Label>
                        λ��Ա�������Ϊ���ѣ�&nbsp;
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
                <asp:GridView ID="friendAttentionGridView" runat="server" AutoGenerateColumns="False"
                    Width="756px" DataKeyNames="ContactId" OnRowDataBound="friendAttentionGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <input type="checkbox" name="checkbox3" id="checkbox2" value='<%#Eval("contactId")%>' />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <a href="javascript:;" onclick="chkAll()">ѡ��</a>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"/>
                            <ControlStyle Height="20px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��Ա����">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                            <ItemTemplate>
                                 <a href="<%#viewLink(Eval("LoginName"))%>" target="_blank"><%#view(Eval("LoginName"))%></a>
                                <asp:Image runat="server" ID="imgTopfo" Visible="false" ImageUrl="../../images/tfzs.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="��Ա����" ConvertEmptyStringToNull="False">
                            <HeaderStyle CssClass="tabtitle" Height="20px"  HorizontalAlign="Center"/>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="��Ա����">
                            <HeaderStyle CssClass="tabtitle"   HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="���Ժδ�">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="���ʱ��">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="����">
                            <HeaderStyle CssClass="tabtitle" Height="20px" Wrap="False"  HorizontalAlign="Center"/>
                            <ItemTemplate>

                                <asp:Button ID="btnAddFriend" runat="server" BackColor="White" BorderStyle="None"
                                    CssClass="lanlink" Font-Overline="False" Font-Underline="True" ForeColor="RoyalBlue"
                                    Height="17px" Text="��Ϊ����" Width="51px" OnClick="btnAddFriend_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" Wrap="False" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="pagebox">
                <div class="left">
                    <img src="../../images/MessageManage/biao_01.gif" alt="" width="14" height="16" align="absbottom" /> 
                    <a href="javascript:;" onclick="chkAll2()">ȫѡ</a> /<a href="javascript:;" onclick="chkAll()">��ѡ</a>��ѡ�е��û�
                    <label>
                    <input name="button2" type="button" class="buttomal" id="button2" value="���������" onclick="goRecycle()" />
</label>
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
                <h1>
                    ��Ҫ��ʾ</h1>
                <p>
                    ��õ������û��Ĺ�ע�𣿾�ͳ�ƣ��ظ�ͨ��Ա�õ��Ĺ�ע����ͨ��Ա��6����<br />
                    <a href="http://www.topfo.com/web13/help/TopfoServer.shtml#a5">�˽��ظ�ͨ������Ȩ</a>0755-89805558 </p>
            </div>
        </div>
    </div>
    
</asp:Content>
