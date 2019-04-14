<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FriendRefresh.aspx.cs" Inherits="helper_FriendManager_FriendRefresh" MasterPageFile="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <link href="../../css/messagemanage.css" rel="stylesheet" type="text/css" />
<link href="../../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../../img/member.css" rel="stylesheet" type="text/css" />
    <link href="../../css/common.css" rel="stylesheet" type="text/css" />
          
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
                    <li class="liwai"><a href="FriendList.aspx">好友列表</a></li>
                    <li><a href="FriendAttention.aspx">关注我的用户</a></li>
                    <li><a href="FriendBlacklist.aspx">黑名单</a></li>
                    <li><a href="FriendConfig.aspx">防骚扰设置</a></li>
                </ul>
            </div>
            <div class=" cshibiank">
                <div class="search">
                    <div class="lefts">
                        &nbsp;&nbsp;<label></label>
                    好友更新</div>
                    <div class="rights">
                        </div>
                    <div class="clear">
                    </div>
                </div>
                    <asp:GridView ID="friendRefreshGridView" runat="server" AutoGenerateColumns="False"
                        Width="100%" DataKeyNames="infoId" OnRowDataBound="friendRefreshGridView_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="资源类别">
                                <HeaderStyle CssClass="tabtitle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="资源名称">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle CssClass="tabtitle" Height="20px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    &nbsp;
                                    <asp:HyperLink ID="hlkTitle" runat="server" Text="" Target="_blank" ></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="更新时间" DataField="ApproveTime">
                                <HeaderStyle CssClass="tabtitle" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    
            </div>
            <div class="pagebox">
                <div class="left">
                    &nbsp;&nbsp;
                </div>
                <div class="right">
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
                        好友更新指被您列入好友的用户，只要发布了新的需求或者更改了新的资料，通过审核后都会在这里进行提示；
                        
                        </p>
                </div>
            </div>
        </div>
        
 </asp:Content>
