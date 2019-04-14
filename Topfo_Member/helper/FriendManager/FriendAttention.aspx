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
				if(confirm("确定操作吗?将不能恢复"))
				{
					helper_FriendManager_FriendAttention.ToRecycle(str,backres);
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
        <div id="ListDiv">
            <div class="topzi">
                <div class="left">
                    我的好友</div>
                <div class="right">
                    <img src="../../images/AccountInfo/handbiao.gif" width="16" height="10" />
                  <a href="http://www.topfo.com/help/friendmanage.shtml" target="_blank">如何添加/管理好友</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank0">
            </div>
            <div class="handtop">
                <ul>
                    <li><a href="FriendSearch.aspx">添加好友</a></li>
                    <li><a href="FriendList.aspx">好友列表</a></li>
                    <li class="liwai">关注我的用户</li>
                    <li><a href="FriendBlacklist.aspx">黑名单</a></li>
                    <li><a href="FriendConfig.aspx">防骚扰设置</a></li>
                </ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        共有<asp:Label runat="server" ID="lbCount"></asp:Label>
                        位会员将您添加为好友：&nbsp;
                    </div>
                    <div class="rights">
                        每页显示：<a href="#"><asp:LinkButton ID="PageSize10" runat="server" OnClick="PageSize10_Click">10</asp:LinkButton></a>条
                        <asp:LinkButton ID="PageSize20" runat="server" OnClick="PageSize20_Click">20</asp:LinkButton>
                        条 <a href="#">
                            <asp:LinkButton ID="PageSize30" runat="server" OnClick="PageSize30_Click">30</asp:LinkButton></a>
                        条</div>
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
                                <a href="javascript:;" onclick="chkAll()">选择</a>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center"/>
                            <ControlStyle Height="20px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="会员名称">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                            <ItemTemplate>
                                 <a href="<%#viewLink(Eval("LoginName"))%>" target="_blank"><%#view(Eval("LoginName"))%></a>
                                <asp:Image runat="server" ID="imgTopfo" Visible="false" ImageUrl="../../images/tfzs.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="会员类型" ConvertEmptyStringToNull="False">
                            <HeaderStyle CssClass="tabtitle" Height="20px"  HorizontalAlign="Center"/>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="会员意向">
                            <HeaderStyle CssClass="tabtitle"   HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="来自何处">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="添加时间">
                            <HeaderStyle CssClass="tabtitle"  HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="操作">
                            <HeaderStyle CssClass="tabtitle" Height="20px" Wrap="False"  HorizontalAlign="Center"/>
                            <ItemTemplate>

                                <asp:Button ID="btnAddFriend" runat="server" BackColor="White" BorderStyle="None"
                                    CssClass="lanlink" Font-Overline="False" Font-Underline="True" ForeColor="RoyalBlue"
                                    Height="17px" Text="加为好友" Width="51px" OnClick="btnAddFriend_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" Wrap="False" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="pagebox">
                <div class="left">
                    <img src="../../images/MessageManage/biao_01.gif" alt="" width="14" height="16" align="absbottom" /> 
                    <a href="javascript:;" onclick="chkAll2()">全选</a> /<a href="javascript:;" onclick="chkAll()">反选</a>将选中的用户
                    <label>
                    <input name="button2" type="button" class="buttomal" id="button2" value="放入黑名单" onclick="goRecycle()" />
</label>
              </div>
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
                <div class="clear">
                </div>
            </div>
            <div class="suggestbox " style="display: none">
                <h1>
                    重要提示</h1>
                <p>
                    想得到更多用户的关注吗？据统计，拓富通会员得到的关注比普通会员高6倍！<br />
                    <a href="http://www.topfo.com/web13/help/TopfoServer.shtml#a5">了解拓富通更多特权</a>0755-89805558 </p>
            </div>
        </div>
    </div>
    
</asp:Content>
