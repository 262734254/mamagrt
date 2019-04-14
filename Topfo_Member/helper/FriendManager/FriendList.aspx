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
				if(confirm("确定操作吗?将不能恢复"))
				{
					helper_FriendManager_FriendList.ToRecycle(str,backres);
				}
			}
			else
			{
				alert("请选选择所要删除的项");
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
				if(confirm("确定操作吗?将不能恢复"))
				{
					helper_FriendManager_FriendList.ToBlackList(str,backres);
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


          
<div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    我的好友</div>
                <div class="right" style="margin-bottom:13px;">
				<img src="http://member.topfo.com/images/hand_1_2.gif" /> <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">如何添加/管理好友</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li><a href="FriendSearch.aspx">添加好友</a></li>
                    <li class="liwai">好友列表</li>
                    <li><a href="InfoView.aspx">互告用户资源</a></li>
                    <li><a href="FriendBlacklist.aspx">黑名单</a></li>
                    <li><a href="FriendConfig.aspx">防骚扰设置</a></li>
                </ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        好友查询：
                        <asp:DropDownList ID="DDListMemberGrade" runat="server" Width="102px">
                            <asp:ListItem Value="0">是否拓富通会员</asp:ListItem>
                            <asp:ListItem Value="1">拓富通会员</asp:ListItem>
                            <asp:ListItem Value="2">普通会员</asp:ListItem>

                        </asp:DropDownList>
                        <asp:DropDownList ID="DDListMemberType" runat="server" Width="115px">
                        <asp:ListItem Value="0">选择会员类型</asp:ListItem>
                            <asp:ListItem Value="1">政府会员</asp:ListItem>
                            <asp:ListItem Value="2">企业会员</asp:ListItem>
                            <asp:ListItem Value="3">个人会员</asp:ListItem>
                        </asp:DropDownList>
                        <label>
                        </label>
                        <asp:TextBox ID="txtSelectFriendName" Text="请输入好友昵称"  onclick="this.value=''" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSelect" Text="查询" runat="server" OnClick="btnSelect_Click" /></div>
                    <div class="rights">
                        每页显示：<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>条
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        条 <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        条</div>
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
                                    <a href="javascript:;" onclick="SelectAll()">选择</a>
                                </HeaderTemplate>
                                <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"/>
                                <ControlStyle Height="20px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="好友名称">
                                <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="hplContactName" Visible="false" Text='<%#Eval("nickName")%>'></asp:HyperLink>
                                    <a href="<%#viewLink(Eval("contactName"))%>" target="_blank"><%#view(Eval("contactName"))%></a>
                                    <asp:Image runat="server" ID="imgTofo" Visible="false" ImageUrl="../../images/tfzs.gif" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="会员类型" ConvertEmptyStringToNull="False">
                                <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="好友更新">
                                <HeaderStyle CssClass="tabtitle" />
                                <ItemTemplate>
                                    &nbsp;<asp:HyperLink ID="hlkRefresh" runat="server" Text="" Target="_blank"></asp:HyperLink>
                                    <br />
                                    &nbsp;<asp:HyperLink ID="hlkPersonRefresh" runat="server" Text="" Target="_blank"></asp:HyperLink><br />
                                    &nbsp;<asp:HyperLink ID="hlkEnRefresh" runat="server" Text="" Target="_blank"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="与好友交流">
                                <HeaderStyle CssClass="tabtitle" Height="20px" Wrap="False"  HorizontalAlign="Center"/>
                                <ItemTemplate>
                                    <asp:HyperLink ID="hplSendInfo" runat="server" NavigateUrl='<%# Eval("nickName", "../../innerinfo/SendView.aspx?Ac=1&Name={0}") %>'
                                        CssClass="lanlink" Target="_blank">发站内短信</asp:HyperLink>
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

                        <input name="button2" type="button" class="buttomal" id="button2" value="删除" onclick="goRecycle()" />
                        <input name="button2" type="button" class="buttomal" id="button1" value="放入黑名单" onclick="goBlackList()" />                        
                    <asp:Button ID="ButtonGroupSend" CssClass="buttomal" runat="server" Text="群发站内短信"
                        Width="86px" OnClick="ButtonGroupSend_Click" /></div>
                <div class="right">
                    共<asp:Literal ID="lblCount" runat="server" Text="0"></asp:Literal>条 页次：<asp:Literal
                        ID="lblCurrPage" runat="server" Text="0"></asp:Literal>/<asp:Literal ID="lblPageCount"
                            runat="server" Text="0"></asp:Literal>页
                    <asp:LinkButton ID="FirstPage" runat="server" OnClick="FirstPage_Click">首页</asp:LinkButton>
                    <asp:LinkButton ID="PerPage" runat="server" OnClick="PerPage_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="NextPage" runat="server" OnClick="NextPage_Click">下一页</asp:LinkButton>
                    <asp:LinkButton ID="LastPage" runat="server" OnClick="LastPage_Click">尾页</asp:LinkButton><span>
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
                        重要提示</h1>
                    <p>
                    1.好友更新指被您列入好友的用户，只要发布了新的需求或者更改了新的资料，通过审核后都会在这里进行提示；
                    <br />
                        <asp:Label ID="lbClue" runat="server" Text="2.拓富通会员可以给所有的好友群发站内短信。" Width="261px"></asp:Label>&nbsp;<asp:HyperLink
                            ID="hplMore" runat="server" Width="109px" NavigateUrl="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" Target="_blank">了解拓富通更多特权</asp:HyperLink>
                        <asp:Label ID="lbTelNumber" runat="server" Text="0755-89805558" Width="135px"></asp:Label>
                        </p>
                </div>
            </div>
        </div>
        
 </asp:Content>
