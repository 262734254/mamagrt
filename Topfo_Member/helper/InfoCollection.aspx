<%@ Page Language="C#" EnableEventValidation="false" ViewStateEncryptionMode="Never"
    AutoEventWireup="true" CodeFile="InfoCollection.aspx.cs" Inherits="helper_InfoCollection"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                �ҵ��ղ�</div>
            <div class="right">
                <img src="http://member.topfo.com/images/jygl.gif" width="16" align="absmiddle" />
                <a href="http://www.topfo.com/web13/help/favorite.shtml#50" target="_blank">���ʹ���ҵ��ղ�</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank0">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai">��Դ�ղ� </li>
                <li><a href="OrgCollection.aspx">����չ���ղ�</a> </li>
                <li class="linonec">
                    <asp:TextBox ID="tbKey" runat="server" Width="193px">��������Դ���ơ������ߡ����͵�</asp:TextBox>&nbsp;<asp:Button
                        ID="btSearch" runat="server" Text="��ѯ" OnClick="btSearch_Click" /></li></ul>
        </div>
        <div class=" cshibiank">
            <div class="search">
                <div class="lefts">
                    �����ڲ鿴���ǣ� &nbsp;<asp:DropDownList ID="ddCreateTime" runat="server" OnSelectedIndexChanged="ddCreateTime_SelectedIndexChanged"
                        Width="117px" AutoPostBack="True">
                        <asp:ListItem Value="3">������</asp:ListItem>
                        <asp:ListItem Value="7">������</asp:ListItem>
                        <asp:ListItem Value="30">һ������</asp:ListItem>
                        <asp:ListItem Value="90">��������</asp:ListItem>
                        <asp:ListItem Value="91">����������</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="rights">
                    ÿҳ��ʾ��<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">10</asp:LinkButton>
                    ��
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">20</asp:LinkButton><a
                        href="#" class="lanlink"></a> ��
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">30</asp:LinkButton>
                    ��</div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div id="ListDiv">
            <asp:GridView ID="dgCollection" runat="server" AutoGenerateColumns="False" DataKeyNames="InfoID"
                Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <a href="javascript:;" onclick="SelectAll()">ѡ��</a>
                        </HeaderTemplate>
                        <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <input type="checkbox" value="<%#Eval("LoginName").ToString().Trim() %>|<%#Eval("ID") %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="��Դ����">
                        <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center" />
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <a target="_blank" href="http://www.topfo.com/<%#Eval("HtmlFile") %>">
                                <%#Eval("Title") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="������" DataField="PublishMan">
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="InfoTypeName" HeaderText="����">
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MainPointCount" HeaderText="��Դ�۸�Ԫ��">
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����ʱ��" DataField="InfoOverdueTime">
                        <HeaderStyle CssClass="tabtitle" HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <div class="blank6">
            </div>
            <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>
            <div class="pagebox">
                <div class="left">
                    <img src="../images/MessageManage/biao_01.gif" width="14" height="16" align="absbottom" />
                    <a href="javascript:;" onclick="SelectAll()">ȫѡ</a>/<a href="javascript:;" onclick="SelectAll()">��ѡ</a>
                    ��ѡ�е���Դ
                    <input name="button2" type="button" class="buttomal" id="button2" value="ɾ ��" onclick="goDelete()" />

                </div>
                <div class="right">
                    <cc1:Pager ID="Pager1" runat="server" BackColor="White" ControlToPaginate="dgCollection"
                        PagerStyle="CustomAndNumeric" SortColumn="CreateDate" KeyColumn="InfoID" ControlToAjaxPanel="ListDiv"
                        TableViewName="InfoViewCollectionVIW" PagingMode="NonCached" ContentPlaceHolder="ContentPlaceHolder1"
                        BorderStyle="None" SortType="DESC"></cc1:Pager>
                </div>
            </div>
        </div>
    </div>

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
	    function goDelete()
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
					helper_InfoCollection.dele(str,backres);
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

</asp:Content>
